/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 01.10.2017
 * Time: 18:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Kalaha
{
    enum eFieldKind { Normal, Kalaha};
    enum ePlayer { P1, P2};
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		
		[STAThread]
		private static void Main(string[] args)
		{			
		      //zum entwickeln der Züge: Ausgabe des Slots-Array über die konsole
		      
		    Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			KalahaMatch kalahaMatch = new KalahaMatch(new KIPlayer(6), new HumanPlayer());
            
            Console.WriteLine(kalahaMatch.Match());
			
			
			
			System.Console.ReadKey();
			
		}
		
	}
}
