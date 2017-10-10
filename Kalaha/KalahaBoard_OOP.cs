/*
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
		private int TotalSlots = STD_BOARDSIZE*2+2;
		int[] indKalahaSlot = {STD_BOARDSIZE, 2*STD_BOARDSIZE+1};		
		private int BoardSize {get;set;}
		private int StartValue {get;set;}
		private List<KalahaSlot> KalahaSlots;
						
		private KalahaBoardDisplaySTD BoardDispInstance =new KalahaBoardDisplaySTD(); //Für später	
			
		//Das brauchen wir erst später wenn wir Forms dazu nehmen:	
		//public KalahaBoardDisplaySTD BoardDisplayInstance = new KalahaBoardDisplaySTD(); //Fürs KI Training sollte das optional sein.
		//wie das geht kommt mal in der EvoNet docu.

		//------------------------METHODEN------------------------------------------
		
		public KalahaBoard() //Konstruktor ohne Argumente setzt Anfangskugelzahl u. Boardsize auf Standardert
		{
			//Application.DoEvents();
			//Application.Run(BoardDisplayInstance); //Ruft das WinForm der Klasse KalahaBoardDisplay auf (Außer Betrieb weil großes Problem)
			this.BoardSize = STD_BOARDSIZE; //Slotzahl jedes Spielers OHNE KalahaSlot
			this.StartValue = STD_BOARDSIZE; //in den Standard-Regeln wird zufällig damit begonnen
			//Slots = new int[2*(STD_BOARDSIZE+1)]; //ACHTUNG: #Slots  ist STD_BOARDSIZE, aber indiziert von 0!
			//fillSlots();--------------------------------------------------------------------------------------
			 
			KalahaSlots = new List<KalahaSlot>();
			
			
			for (int i = 0; i < TotalSlots; i++) { //Liste KalahaSlots wird Gefüllt
				KalahaSlots.Add(new KalahaSlot());
			}
			
			KalahaSlots[2].setNextSlot(KalahaSlots[3]);
//			
//			for (int i = TotalSlots-2; i >= 0; i--) {
//				Console.WriteLine("Aktueller Index ist. "+i);				
//				KalahaSlots[i].setNextSlot(KalahaSlots[i+1]);
//			}	
			
			Console.WriteLine("Test ob kalahaSlots[3] der nextSlot von 2 ist: "+Equals(KalahaSlots[2].getNextSlot()), KalahaSlots[3]);
			
		}	
		
		
//		private void fillSlots() //Fuellt die Slots zu Anfang
//		{			
//			for (int i = 0; i <= /Slots.GetLength(0)-1; i++)
//			{
//				if (i == indKalahaSlot[0] || i == indKalahaSlot[1]) {
//					//Slots[i] = 0;
//				} else{					
//					//Slots[i] = 13 ; // this.StartValue;
//				}		
//			}
//		}
		
	}
}
		
		
		
		
		
		
		
				
	//==============================================================================================================	
//		public void move(int moveChoice, int StartSide, bool EmptyChoice = true, int amount=0)
//		{	
//			
//			Console.WriteLine("Ausgeführter Zug: move("+moveChoice+","+StartSide+")\n");
//			
//			int forbiddenInd = indKalahaSlot[StartSide]; //evt Index noch anpassen
//			int ValueChoice = Slots[moveChoice];
//			int allowedTotalSlots = TotalSlots-1;
//			int RoundsFinished = (int)((Slots[moveChoice]) / (allowedTotalSlots)); //soviele vollst. runden  werden gemacht
//																	    //gegn. kalaha zählt später nicht zur runde
//																		//ers. TotalSlots durch TotalSlots-1
//			if (amount == 0) {
//				ValueChoice = amount;
//			}
//			if (EmptyChoice == true) {
//				Slots[moveChoice] = 0;
//			}											
//				
//
//				
//			Console.WriteLine("Kontrollausgabe RoundsFinished: "+RoundsFinished);
//				
//			kept = RoundsFinished*2; //Für jede volle Runde wird zweimal das gegn. Kalaha passiert
//			//----------------------------
//			moveFullRound(RoundsFinished, StartSide);
//			moveChoiceTowardsEnd(moveChoice, ValueChoice, StartSide);
//			moveFromZero((ValueChoice % TotalSlots) - (TotalSlots - 1 - moveChoice), StartSide);
//			//---jetzt noch die übrigen vom gegner-kalaha:
//			Console.WriteLine("Übertrag nach den drei funktionen ist: "+kept);
//			move(moveChoice, StartSide, false, kept); WAS SOLL MAN AUCH INS ERSTE ARGUMENT SCHREIBEN????
//			
//		}
//		
//		private void moveFullRound(int Rounds, int StartSide) //VOLLE RUNDE
//		{
//			for (int i = 0; i < TotalSlots; i++) {					
//				if(i != indKalahaSlot[StartSide]){
//					Slots[i] += Rounds;				
//				}
//			}
//		}
//		
//		private void moveChoiceTowardsEnd(int Choice, int amount, int StartSide) //ERSTE RUNDE BEENDEN (oder früher aufhören)
//		{
//			amount = amount % TotalSlots;
//			
//				for (int i = Choice+1 ; i <= intMin(TotalSlots-1,(amount % TotalSlots)+Choice); i++){
//						if(i != indKalahaSlot[StartSide]){Slots[i]++;}
//						else{kept++;}
//				}
//			
//		}
//		
//		private int moveFromZero(int amount, int StartSide) //REST LETZTE RUNDE
//		{	
//			int pos = 0;
//			for (int i = 0; i < amount; i++) {
//						if(i != indKalahaSlot[StartSide]){Slots[i]++;}
//						else{kept++;}
//						pos = i;
//			}
//			return pos;
//		}
//		
//		
//		private int intMin(int x,int y)
//		{
//			if (x <= y) {
//				return x;
//			} else {
//				return y;
//			}
//		}
//		
//		public void TestConsoleOut()
//		{
//			for (int i = Slots.GetLength(0)-1; i >= Slots.GetLength(0)/2; i--)
//			{
//				Console.Write("|"+Slots[i]);
//				if (Slots[i]<10) {
//					Console.Write(" ");
//				}
//			}
//			Console.Write("\n   ");
//			for (int i = 0; i < Slots.GetLength(0)/2; i++)
//			{
//				Console.Write("|"+Slots[i]);
//				if (Slots[i]<10) {
//					Console.Write(" ");
//				}				
//			}
//			Console.WriteLine("\n-------------------------\n\n");
//			
//		}
//		
//		
//	}
//}
//
