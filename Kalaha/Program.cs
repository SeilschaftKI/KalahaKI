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
			KalahaBoard TheBoard = new KalahaBoard();
			//Application.Run(new KalahaBoardRender());				                  
			
			
//			Console.WriteLine("7/3 gerundet "+(int)(7/3));
//			Console.WriteLine("7/2 gerundet "+(int)(7/2));
//			Console.WriteLine("11/4 gerundet "+(int)(11/4));
			
			TheBoard.TestConsoleOut();
			TheBoard.move(4,0);
			TheBoard.TestConsoleOut();
			
			
			
			System.Console.ReadKey();
			
		}
		
	}
}
