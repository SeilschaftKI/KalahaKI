/*
 * Benutzer: Daniel
 * Datum: 09.10.2017
 * Zeit: 12:54
 */


using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Kalaha
{
	/// <summary>
	/// Description of HumanPlayer.
	/// </summary>
	public class HumanPlayer : Player
	{
		
		override public int ChooseMove(int[] Slots)
		{			
			Console.WriteLine("Spieler {0} ist dran. Bitte Zug eingeben!\n", this.PlaySide);
			string input ="0";	

			do{
				input = Console.ReadLine();												
			}while(CheckIndInRange(input, Slots) ==false || CheckNoEmptyChoice(input, Slots) == false);
			
			return Int32.Parse(input)-1;	
		}
		
		public HumanPlayer()
		{			
		}
		
		private bool CheckIndInRange(string input, int[] Slots){
			if(Int32.Parse(input)<1 || Int32.Parse(input)>SlotsToChoose)
			{
				Console.WriteLine("Deine Wahl muss zwischen {0} und {1} liegen. Versuchen wirs nochmal:", 1,SlotsToChoose);
				return false;
			}
			else
			{return true;}
		}
		
		private bool CheckNoEmptyChoice(string input, int[] Slots){
			if(Slots[Int32.Parse(input)-1 + PlaySide*(SlotsToChoose+1)]==0)
			{
				Console.WriteLine("Das Feld in dem du ziehen willst ist leer! Versuchen wirs nochmal:");
				return false;
			}
			else{return true;}
		}
		
		
	}
}
