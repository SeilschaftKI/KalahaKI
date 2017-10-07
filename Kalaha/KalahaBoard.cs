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
		
		
		
		
		private KalahaBoardDisplaySTD BoardDispInstance =new KalahaBoardDisplaySTD(); //Für später	
			
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
					Slots[i] = 5 ; // this.StartValue;
				}		
			}
		}
				
		
		public bool move(int moveChoice, int StartSide) //Funktion gibt true zurueck wenn man im eigenen kalaha-feld landet (dann darf man nommal)
		{	
			if (!(((moveChoice<7)==(StartSide == 0))) || (moveChoice<0) || (moveChoice>=maxInd) || (moveChoice==indKalahaSlot[1]))
			{
				throw new System.ArgumentException("moveChoice Liegt Außerhalb des Indexbereichs oder auf der falschen Seite in relation zum Player");
			}
			
			Console.WriteLine("move("+moveChoice+","+StartSide+") wird jetzt ausgeführt");
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
				if (((count<7)==(StartSide == 0)))
				{
					Slots[indKalahaSlot[StartSide]] += Slots[acrossInd(count)];
					Slots[acrossInd(count)]=0;
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
	}
}