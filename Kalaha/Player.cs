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

		int[] _stats = {0,0,0}; //(siege,niederlagen, punktedifferenz) siehe EnumAndOther
		
		#region Accesoren Statistik
		
		public void IncrWins()
		{
			_stats[(int)PlayerStats.WINS]++;
		}
		
		public void IncrLosses()
		{
			_stats[(int)PlayerStats.LOSSES]++;
		}
		
		public void AddToScoreDiff(int val)
		{
			_stats[(int)PlayerStats.SCOREDIFF]+=val;
		}
		
		public int[] Stats
		{
			get{return _stats;}
		}
		#endregion
		
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
