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
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new KalahaBoardRender());
			
			//------------Experimente------------
			
			KalahaBoard TheBoard = new KalahaBoard();
			//TheBoard.BoardDisplayInstance.MessageBox.Show("aufgerufen im Program");
			
			TheBoard.moveBlack(0);
			MessageBox.Show("blubb"); //kommmt hier nicht an :(
			
		}
		
	}
}
