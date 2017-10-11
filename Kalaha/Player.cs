/*
 * Benutzer: Daniel
 * Datum: 09.10.2017
 * Zeit: 12:41
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
	/// Description of Player.
	/// </summary>
	public abstract class Player
	{	
		protected int SlotsToChoose;
		protected int PlaySide; //0 oder 1
		
		abstract public int ChooseMove(int[] Slots);
		
		ArgumentException PlaySideArgExc = new ArgumentException("Player.PlaySide muss 0 oder 1 sein!");

		protected Player()
		{
			
		}		
		
		
		public void setSlotsToChoose(int stc)
		{
			this.SlotsToChoose=stc;
		}
		public int getPlaySide()
		{
			return this.PlaySide;
		}
		
		public void setPlaySide(int ps)
		{
			if(PlaySide != 0 && PlaySide != 1){throw PlaySideArgExc;}
			this.PlaySide = ps;
		}
	}
}
