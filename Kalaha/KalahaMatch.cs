/*
 * User: Daniel
 * Date: 02.10.2017
 * Time: 17:21
 */

using System;
using System.Collections.Generic;
using System.Drawing;

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
		private int WhoseTurn=0;
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

		public KalahaMatch(Player Player0, Player Player1, int SlotsToChoose = 0, bool SuppressOutput = true)
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
        	
        	while ((TheBoard.SideEmpty(0)==false) && (TheBoard.SideEmpty(1)==false))
        	{
        		TheBoard.TestConsoleOut();
        		if (WhoseTurn%2 == 0) {
        			while(((TheBoard.SideEmpty(0)==false) && (TheBoard.SideEmpty(1)==false)) && (TheBoard.move(Player0.ChooseMove(TheBoard.getAllSlotFill()),Player0.getPlaySide())==true)){
        			      		duration++;
        						BoardConsOutIfNotSuppressed();      			      		
        			}
        			WhoseTurn++;
        	
        		}else{
        			while(((TheBoard.SideEmpty(0)==false) && (TheBoard.SideEmpty(1)==false)) && (TheBoard.move(Player1.ChooseMove(TheBoard.getAllSlotFill()),Player1.getPlaySide())==true)){
        			      		duration++;        			      		
        			      		BoardConsOutIfNotSuppressed();        			      		
        			}
        			WhoseTurn++;
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
        	
        	return res;
        	
        }
    }
}
