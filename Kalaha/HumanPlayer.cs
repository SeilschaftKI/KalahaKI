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
	public class HumanPlayer : Player, IChooseMove
	{
		public int ChooseMove()
		{
			string input = Console.ReadLine();
			
			return Int32.Parse(input);
			
		}
		
		public HumanPlayer(int PlaySide)
		{
			this.PlaySide = PlaySide;
		}
		
		public int getPlaySide()
		{
			return this.PlaySide;
		}
	}
}
