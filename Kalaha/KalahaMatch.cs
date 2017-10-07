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

		public KalahaMatch()
		{
            
        }

        public Result Match()
        {
            Result result = new Result();
            TheBoard.TestConsoleOut();
            TheBoard.move(4, 0);
            result.NeuerZug();
            TheBoard.TestConsoleOut();
            TheBoard.move(7, 1);
            result.NeuerZug();
            TheBoard.TestConsoleOut();
            TheBoard.move(2, 0);
            result.NeuerZug();
            TheBoard.TestConsoleOut();
            return result;
        }
    }
}
