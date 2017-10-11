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
	public class HumanPlayer : ePlayer, IChooseMove
	{
		private int SlotsToChoose;
		public int ChooseMove()
		{
			
			Console.WriteLine("Spieler {0} ist dran. Bitte Zug eingeben!\n", this.PlaySide);
			string input = Console.ReadLine();			
			
			while(Int32.Parse(input)<1 || Int32.Parse(input)>SlotsToChoose) {		
				Console.WriteLine("Deine Wahl muss zwischen {0} und {1} liegen. Versuchen wirs nochmal:", 1,SlotsToChoose);
				input = Console.ReadLine();
			}
			return Int32.Parse(input)-1;	
		}
		
		public HumanPlayer(int PlaySide, int SlotsToChoose)
		{
			this.PlaySide = PlaySide;
			this.SlotsToChoose = SlotsToChoose;
		}
		
		public int getPlaySide()
		{
			return this.PlaySide;
		}
	}
}
