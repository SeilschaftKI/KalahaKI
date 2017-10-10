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
		private int maxInd;
		
		
		
		
		private KalahaBoardDisplaySTD BoardDispInstance = new KalahaBoardDisplaySTD(); //Für später	
			
		//Das brauchen wir erst später wenn wir Forms dazu nehmen:	
		//public KalahaBoardDisplaySTD BoardDisplayInstance = new KalahaBoardDisplaySTD(); //Fürs KI Training sollte das optional sein.
		//wie das geht kommt mal in der EvoNet docu.

		//------------------------METHODEN------------------------------------------
		
		public KalahaBoard() //Konstruktor ohne Argumente setzt Anfangskugelzahl u. Boardsize auf Standardert
		{
			Application.DoEvents();
			//Application.Run(BoardDisplayInstance); //Ruft das WinForm der Klasse KalahaBoardDisplay auf (Außer Betrieb weil großes Problem)
			this.BoardSize = STD_BOARDSIZE; //Slotzahl jedes Spielers OHNE KalahaSlot
			this.StartValue = STD_BOARDSIZE; //in den Standard-Regeln wird zufällig damit begonnen
			Slots = new int[2*(STD_BOARDSIZE+1)]; //ACHTUNG: #Slots  ist STD_BOARDSIZE, aber indiziert von 0!
			this.maxInd = this.TotalSlots - 1;
			fillSlots();
			NeuralNetwork.NeuralNetwork nn2 = new NeuralNetwork.NeuralNetwork();
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
		
		private void fillSlots() //Fuellt die Slots zu Anfang
		{	
			
			for (int i = 0; i <= Slots.GetLength(0)-1; i++)
			{
				if (i == indKalahaSlot[0] || i == indKalahaSlot[1]) {
					Slots[i] = 0;
				} else{					
					Slots[i] = this.StartValue;
				}		
			}
//			fillForDebug();
		}
		
//		private void fillForDebug()
//		{
//			for (int i = 0; i < Slots.GetLength(0)-1; i++) {
//				Slots[i] = 0;
//			}
//			
//			Slots[2]= 2;
//			Slots[9]= 1;
//		}
		
		public int getKalahaScore(int Side){
			return Slots[indKalahaSlot[Side]];
		}
		
		public int getTotalSlots()
		{
			return TotalSlots;
		}
		
		public int getSlotfill(int Choice, int Side)
		{
			return Slots[Choice + Side*TotalSlots/2];
		}
		
		public bool move(int moveChoice, int StartSide) //Funktion gibt true zurueck wenn man im eigenen kalaha-feld landet (dann darf man nommal)
		{	
			     

			if ((moveChoice > maxInd/2-1) || (moveChoice < 0))
			{
				throw new System.ArgumentException("moveChoice="+moveChoice+" Liegt Außerhalb von [1,maxInd/2]");
			} else if (Slots[moveChoice + StartSide*TotalSlots/2] == 0) {
				throw new System.ArgumentException("Ein Zug wurde im leeren Feld begonnen!");				
			}
			
			
			Console.WriteLine("move("+(1+moveChoice)+","+StartSide+") wird jetzt ausgeführt");
			moveChoice += StartSide*TotalSlots/2;
			
			
			
			int ChoiceValue = Slots[moveChoice];
			int count = moveChoice;
			int lastPos = moveChoice;
			int forbiddenInd = indKalahaSlot[otherSide(StartSide)];
			int kept=0; //Übertrag, beim überspringen behaltene Kugeln
						
			Slots[moveChoice]=0;
						
			for (int i = moveChoice+1; i <= ChoiceValue+moveChoice+kept; i++)
			{
				count = i % TotalSlots;
			
				if (forbiddenInd != count) {
					Slots[count]++;		
				}else{
					kept++;
				}				
			}
			
			if((Slots[count]==1) && (count != indKalahaSlot[StartSide])){
				if (((count<TotalSlots/2)==(StartSide == 0)))
				{
					Slots[indKalahaSlot[StartSide]] += Slots[acrossInd(count)];
					Slots[acrossInd(count)] = 0;
					Slots[count] = 0;
					Slots[indKalahaSlot[StartSide]]++;
				}
			}
			
			if (count==indKalahaSlot[StartSide]) {
				return true;
			} else {
				return false;
			}
		}
		
		private int acrossInd(int Ind){
			return (maxInd-1) - Ind;			
		}
		
		private int otherSide(int val)
		{
			if (val == 1) {
				return 0;
			}
			else if(val == 0)
			{
				return 1;
			}
			else
			{
				throw new System.ArgumentException("Argument von otherSide ist invalid (Müsste 0 oder 1 sein)!");
			}
		}
		
		public bool SideEmpty(int Side)
		{
			bool alert = false;
			 
			for (int i =1+Side*TotalSlots/2; i < TotalSlots/2+Side*TotalSlots/2-1; i++) {
				if (Slots[i]!=0) {
					alert = true;
					break;
				}
			}
			if (alert==false){
				LastTransfer(Change0and1(Side));
				return true;
			}else{
				return false;
			}
		}
		
		private void LastTransfer(int Side) //Side ist die Seite, auf der noch Kugeln liegen
		{
			for (int i =1+Side*TotalSlots/2; i < TotalSlots/2+Side*TotalSlots/2-1; i++) {
				Slots[indKalahaSlot[Change0and1(Side)]]+=Slots[i];
				Slots[i] = 0;
			}
		}
		
		private int Change0and1(int val)
		{
			if (val <0 || val>1) {
				throw new ArgumentException();
			}
			
			return (val+1)%2;
		}
		
		
	}
}