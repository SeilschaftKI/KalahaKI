﻿/*
 * User: Daniel
 * Date: 02.10.2017
 * Time: 17:21
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
	/// Um die KI zu Trainieren müssen wir später viele Kalaha-Matches hintereinander Spielen lassen
	/// dies ist die Klasse eines einzelnen Matches
	/// </summary>
	public class KalahaMatch
	{
		
		private KalahaBoard TheBoard = new KalahaBoard();
		private ePlayer WhoseTurn=ePlayer.P1;
		private int duration=0;
		private bool SuppressOutput;		
		private int SlotsToChoose;
		
		private Player Player0;//Übegabe Reihenlänge, um Eingaben prüfen zu können
		private Player Player1;//TODO 2. Argument flexibel
		
		private void BoardConsOutIfNotSuppressed()
		{
			if (SuppressOutput == false) {
        		TheBoard.TestConsoleOut();
        	}
		}

		public KalahaMatch(Player Player0, Player Player1, int SlotsToChoose = 0, bool SuppressOutput = false)
		{	
			if (SlotsToChoose==0){SlotsToChoose = KalahaBoard.STD_BOARDSIZE;}
			else{this.SlotsToChoose = SlotsToChoose;}
			
			this.Player0 = Player0;
			this.Player0.setPlaySide(0);
			this.Player0.setSlotsToChoose(SlotsToChoose);
			
			this.Player1 = Player1;
			this.Player1.setPlaySide(1);
			this.Player1.setSlotsToChoose(SlotsToChoose);			
			
			this.SuppressOutput = SuppressOutput;
        }
		

        public Result Match()
        {
        	BoardConsOutIfNotSuppressed();        	
        	
        	while (TheBoard.SideEmpty == false)
        	{
        		TheBoard.TestConsoleOut();
        		if (WhoseTurn == ePlayer.P1)
                {
        			while((TheBoard.Move(Player0.ChooseMove(TheBoard.GetAllSlotValues()), Player0.getPlaySide()) == true))
                    {
        			    duration++;
        				BoardConsOutIfNotSuppressed();      			      		
        			}
        			WhoseTurn = ePlayer.P2;
        		} else
                {
        			while(TheBoard.Move(Player1.ChooseMove(TheBoard.GetAllSlotValues()), Player1.getPlaySide()) == true)
                    {
        			    duration++;        			      		
        			    BoardConsOutIfNotSuppressed();
        			      		
        			}
        			WhoseTurn = ePlayer.P1;
        		}        		
        	       
        	}
        	
        	BoardConsOutIfNotSuppressed();
        	
        	
        	if(SuppressOutput==false){
	        	if (TheBoard.getKalahaScore(0) > TheBoard.getKalahaScore(1)) {
	        		Console.WriteLine("\n=====================\n===PLAYER 0 WINS=====\n=====================\n");
	        	} else if (TheBoard.getKalahaScore(0) < TheBoard.getKalahaScore(1)){
	        		Console.WriteLine("\n=====================\n===PLAYER 0 WINS=====\n=====================\n");
	        	} else {
	        		Console.WriteLine("\n=====================\n===UNENTSCHIEDEN=====\n=====================\n\n\n");
	        	}
	        	
	        	Console.WriteLine("Score Spieler 0: {0}\nScore Spieler 1: {1}",TheBoard.getKalahaScore(0),TheBoard.getKalahaScore(1));
	        	
        	}
        	
        	Result res = new Result(TheBoard.getKalahaScore(1),TheBoard.getKalahaScore(0),duration);
        	Console.ReadKey();
        	return res;
        	
        }
    }
}
