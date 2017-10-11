﻿/*
 * User: Daniel
 * Date: 02.10.2017
 * Time: 17:32
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kalaha
{
    enum FieldKind { Normal, Kalaha };
    enum Player { P1, P2 };

    /// <summary>
    /// Kalaha Board soll die Listen enthalten, die die Slotfüllung darstellen, sowie die zugehörige Dynamik,
    /// also sprich die implementierten "Züge"
    ///
    /// Standardmäßig: jeder spieler hat 6 Felder + 1 Kalaha, Startfüllung von jedem Feld sind 6 Kugeln
    /// 
    /// </summary>
    public class KalahaBoard
    {
        public static readonly ushort STD_BOARDSIZE = 6;
        private Field[] Slots = new Field[STD_BOARDSIZE * 2 + 2];
        private Field[] SlotsP1 = new Field[STD_BOARDSIZE+1];
        private Field[] SlotsP2 = new Field[STD_BOARDSIZE+1];

        private int BoardSize { get; set; }
        private int StartValue { get; set; }

        public bool SideEmpty = false;

        private Hand hand = new Hand();

        public KalahaBoardDisplay_STD Display = new KalahaBoardDisplay_STD(6);      //Der will Startvalue nicht, für Dynamik später noch lösen

        //Das brauchen wir erst später wenn wir Forms dazu nehmen:	
        //public KalahaBoardDisplaySTD BoardDisplayInstance = new KalahaBoardDisplaySTD(); //Fürs KI Training sollte das optional sein.
        //wie das geht kommt mal in der EvoNet docu.

        //------------------------METHODEN------------------------------------------

        public KalahaBoard() //Konstruktor ohne Argumente setzt Anfangskugelzahl u. Boardsize auf Standardert
        {
            this.BoardSize = STD_BOARDSIZE; //Slotzahl jedes Spielers OHNE KalahaSlot
            this.StartValue = STD_BOARDSIZE; //in den Standard-Regeln wird zufällig damit begonnen
            CreateSlots();

            NeuralNetwork.NeuralNetwork nn2 = new NeuralNetwork.NeuralNetwork();

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Display);
        }

        public void TestConsoleOut()
        {
            for (int i = Slots.GetLength(0) - 1; i >= Slots.GetLength(0) / 2; i--)
            {
                Console.Write("|" + Slots[i].Value);
                if (Slots[i].Value < 10)
                {
                    Console.Write(" ");
                }
            }

            Console.Write("\n   ");
            for (int i = 0; i < Slots.GetLength(0) / 2; i++)
            {
                Console.Write("|" + Slots[i].Value);
                if (Slots[i].Value < 10)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("\n-------------------------\n\n");

        }

        private void CreateSlots() //Erstellt und füllt die Slots zu Anfang
        {
            Slots[0] = new Field(StartValue, 1, FieldKind.Normal, Player.P1, Display.btnP1_1);
            Slots[1] = new Field(StartValue, 2, FieldKind.Normal, Player.P1, Display.btnP1_2);
            Slots[2] = new Field(StartValue, 3, FieldKind.Normal, Player.P1, Display.btnP1_3);
            Slots[3] = new Field(StartValue, 4, FieldKind.Normal, Player.P1, Display.btnP1_4);
            Slots[4] = new Field(StartValue, 5, FieldKind.Normal, Player.P1, Display.btnP1_5);
            Slots[5] = new Field(StartValue, 6, FieldKind.Normal, Player.P1, Display.btnP1_6);
            Slots[6] = new Field(0, 7, FieldKind.Kalaha, Player.P1, Display.btnP1_Kalaha);
            Slots[7] = new Field(StartValue, 1, FieldKind.Normal, Player.P2, Display.btnP2_1);
            Slots[8] = new Field(StartValue, 2, FieldKind.Normal, Player.P2, Display.btnP2_2);
            Slots[9] = new Field(StartValue, 3, FieldKind.Normal, Player.P2, Display.btnP2_3);
            Slots[10] = new Field(StartValue, 4, FieldKind.Normal, Player.P2, Display.btnP2_4);
            Slots[11] = new Field(StartValue, 5, FieldKind.Normal, Player.P2, Display.btnP2_5);
            Slots[12] = new Field(StartValue, 6, FieldKind.Normal, Player.P2, Display.btnP2_6);
            Slots[13] = new Field(0, 7, FieldKind.Kalaha, Player.P2, Display.btnP2_Kalaha);

            for (int i = 0; i <= BoardSize * 2; i++)
            {
                Slots[i].Follower = Slots[i + 1];
            }
            Slots[13].Follower = Slots[0];

            for (int i = 0; i <= 6; i++)
            {
                SlotsP1[i] = Slots[i];
                SlotsP2[i] = Slots[i + 7];
            }
        }

        public bool Move(int moveChoice, int StartSide) //Funktion gibt true zurueck wenn man im eigenen kalaha-feld landet (dann darf man nommal)
        {

            //TODO: Eingabe überprüfen

            Console.WriteLine("move(" + (1 + moveChoice) + "," + StartSide + ") wird jetzt ausgeführt");

            Player AmZug;
            if (StartSide == 0)
            {
                hand.MoveTo(SlotsP1[moveChoice]);
                AmZug = Player.P1;
            } else
            {
                hand.MoveTo(SlotsP2[moveChoice]);
                AmZug = Player.P2;
            }

            hand.Take();
            hand.MoveToNext();

            while (hand.Value > 1)
            {
                hand.drop();
                hand.MoveToNext();
            }

            hand.drop();        //letzter Stein fällt

            //Nach dem Drop ins letzte Feld wird geprüft, ob irgendwelche Sonderregeln greifen
            if (hand.HoverOver.Kind == FieldKind.Kalaha && hand.HoverOver.Owner == AmZug)   //Neue Runde durch Kalahaende
            {
                return true;
            } else if (hand.HoverOver.Kind == FieldKind.Normal && hand.HoverOver.Value == 1 && hand.HoverOver.Owner == AmZug) //Steinchenklauregel
            {
                if (AmZug == Player.P1)
                {
                    hand.MoveTo(SlotsP2[7 - hand.HoverOver.Position]);      //Wechsel auf andere Seite
                    hand.Take();
                    hand.MoveTo(SlotsP1[7 - hand.HoverOver.Position]);      //Wechsel auf ursprüngliche Seite
                    hand.drop();
                } else
                {
                    hand.MoveTo(SlotsP1[7 - hand.HoverOver.Position]);      //Wechsel auf andere Seite
                    hand.Take();
                    hand.MoveTo(SlotsP2[7 - hand.HoverOver.Position]);      //Wechsel auf ursprüngliche Seite
                    hand.drop();
                }
            }
            return false;

        }

        public int getKalahaScore(int Player)
        {
            if (Player == 0)
            {
                return Slots[BoardSize + 1].Value;
            }
            else if (Player == 1)
            {
                return Slots[Slots.Length - 1].Value;
            }
            else
            {
                return 0;
            }

        }
    }
}