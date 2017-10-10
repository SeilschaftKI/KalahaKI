/*
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
		private int WhoseTurn=0;
		private int duration=0;
		private bool SuppressOutput=false;
		
		
				
		
		private HumanPlayer Player0 = new HumanPlayer(0,6); //Übegabe Reihenlänge, um Eingaben prüfen zu können
		private HumanPlayer Player1 = new HumanPlayer(1,6); //TODO 2. Argument flexibel
		

		public KalahaMatch()
		{
            
        }

        public Result Match()
        {
        	TheBoard.TestConsoleOut();
        	
        	while ((TheBoard.SideEmpty(0)==false) && (TheBoard.SideEmpty(1)==false))
        	{
        		TheBoard.TestConsoleOut();
        		if (WhoseTurn%2 == 0) {
        			while(((TheBoard.SideEmpty(0)==false) && (TheBoard.SideEmpty(1)==false)) && (TheBoard.move(Player0.ChooseMove(),Player0.getPlaySide())==true)){
        			      		duration++;
        			      		TheBoard.TestConsoleOut();        			      		
        			      }
        			WhoseTurn++;
        	
        		}else{
        				while(((TheBoard.SideEmpty(0)==false) && (TheBoard.SideEmpty(1)==false)) && (TheBoard.move(Player1.ChooseMove(),Player1.getPlaySide())==true)){
        			      		duration++;        			      		
        			      		TheBoard.TestConsoleOut();
        			      		
        			      }
        			WhoseTurn++;
        		}        		
        	       
        	}
        	
        	TheBoard.TestConsoleOut();
        	
        	if (TheBoard.getKalahaScore(0) > TheBoard.getKalahaScore(1)) {
        		Console.WriteLine("\n=====================\n===PLAYER 0 WINS=====\n=====================\n");
        	} else if (TheBoard.getKalahaScore(0) < TheBoard.getKalahaScore(1)){
        		Console.WriteLine("\n=====================\n===PLAYER 0 WINS=====\n=====================\n");
        	} else {
        		Console.WriteLine("\n=====================\n===UNENTSCHIEDEN=====\n=====================\n\n\n");
        	}
        	
        	Console.WriteLine("Score Spieler 0: {0}\nScore Spieler 1: {1}",TheBoard.getKalahaScore(0),TheBoard.getKalahaScore(1));
        	
        	
        	
        	Result res = new Result(TheBoard.getKalahaScore(1),TheBoard.getKalahaScore(0),duration);
        	Console.ReadKey();
        	return res;
        	
        }
    }
}
