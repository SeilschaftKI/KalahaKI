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
		private int[] Slots;
		
		
		private int BoardSize {get;set;}
		private int StartValue {get;set;}
		
		int[] indKalahaSlot = {STD_BOARDSIZE, 2*STD_BOARDSIZE+1};
		private int TotalSlots = STD_BOARDSIZE*2+2;
		
		private KalahaBoardDisplaySTD BoardDispInstance =new KalahaBoardDisplaySTD(); //Für später
		
		//------------------------METHODEN------------------------------------------	
		
		
			
		
		
			
		//Das brauchen wir erst später wenn wir Forms dazu nehmen:	
		//public KalahaBoardDisplaySTD BoardDisplayInstance = new KalahaBoardDisplaySTD(); //Fürs KI Training sollte das optional sein.
																				  //wie das geht kommt mal in der EvoNet docu.
														  
		
		
																				  
		public KalahaBoard() //Konstruktor ohne Argumente setzt Anfangskugelzahl u. Boardsize auf Standardert
		{
			Application.DoEvents();
			//Application.Run(BoardDisplayInstance); //Ruft das WinForm der Klasse KalahaBoardDisplay auf HIEEEEER PROBLEM
			this.BoardSize = STD_BOARDSIZE; //Slotzahl jedes Spielers OHNE KalahaSlot
			this.StartValue = STD_BOARDSIZE; //in den Standard-Regeln wird zufällig damit begonnen
			Slots = new int[2*(STD_BOARDSIZE+1)]; //ACHTUNG: #Slots  ist STD_BOARDSIZE, aber indiziert von 0!
			//MessageBox.Show("Arrays in KalahaBoard wurden erzeugt");
			fillSlots();
			//MessageBox.Show("fillSlots wurde ausgefuehrt, der DispBlackSlots[2] ist gleich\n"+ BlackSlots[2]);
		}
		
		//TODO flexibler Konstruktor
		
		
		
		private void fillSlots() //Fuellt die Slots zu Anfang
		{
			
			
			
			for (int i = 0; i <= Slots.GetLength(0)-1; i++)
			{
				if (i == indKalahaSlot[0] || i == indKalahaSlot[1]) {
					Slots[i] = 0;
				} else{
				
					
					Slots[i] = 8 ; // this.StartValue;
				}
			
			}
		}
				
		
		public void move(int moveChoice, int StartSide) 
		{	
			
			Console.WriteLine("Ausgeführter Zug: move("+moveChoice+","+StartSide+")\n");
			
			int ValueChoice = Slots[moveChoice];
			int RoundsFinished = (int)((Slots[moveChoice]) / TotalSlots); //soviele vollst. runden  werden gemacht
																	    //gegn. kalaha zählt später nicht zur runde
																		//ers. TotalSlots durch TotalSlots-1
			
			
			Console.WriteLine("Kontrollausgabe RoundsFinished: "+RoundsFinished);
			Slots[moveChoice] = 0;
			
			
//			//ERSTE TEILRUNDE
//			if(!(ValueChoice % TotalSlots == 0)){
//				for (int i = moveChoice + 1; i <= intMin(TotalSlots-1,(ValueChoice % TotalSlots)+moveChoice); i++){
//							Slots[i]++;
//						}
//			}
//			
//			
//			
//			//VOLLE RUNDEN:
//											
//			for (int i = 0; i < TotalSlots; i++) {
//					
//				Slots[i] += RoundsFinished;
//			}				
//
//				
//			//LETZTE TEILRUNDE
//			for (int i = 0; i <= (ValueChoice % TotalSlots)-(TotalSlots - (moveChoice)); i++){
//						Slots[i]++;
//					}
			moveFullRound(RoundsFinished);
			moveChoiceTowardsEnd(moveChoice, ValueChoice);
			moveFromZero((ValueChoice % TotalSlots) - (TotalSlots - 1 - moveChoice));
			
		}
		
		private void moveFullRound(int Rounds) //VOLLE RUNDE
		{
			for (int i = 0; i < TotalSlots; i++) {					
				Slots[i] += Rounds;
			}	
		}
		
		private void moveChoiceTowardsEnd(int Choice, int amount) //ERSTE RUNDE BEENDEN (oder früher aufhören)
		{
			amount = amount % TotalSlots;			
				
			for (int i = Choice+1 ; i <= intMin(TotalSlots-1,(amount % TotalSlots)+Choice); i++){
						Slots[i]++;
				}
					
		}
		
		private void moveFromZero(int amount) //REST LETZTE RUND
		{
			for (int i = 0; i < amount; i++) {
				Slots[i]++;
			}
		}
		
		
		private int intMin(int x,int y)
		{
			if (x <= y) {
				return x;
			} else {
				return y;
			}
		}
		
		public void TestConsoleOut()
		{
			for (int i = Slots.GetLength(0)-1; i >= Slots.GetLength(0)/2; i--)
			{
				Console.Write("|"+Slots[i]);
				if (Slots[i]<10) {
					Console.Write(" ");
				}
			}
			Console.Write("\n   ");
			for (int i = 0; i < Slots.GetLength(0)/2; i++)
			{
				Console.Write("|"+Slots[i]);
				if (Slots[i]<10) {
					Console.Write(" ");
				}				
			}
			Console.WriteLine("\n-------------------------\n\n");
			
		}
		
		
	}
}

