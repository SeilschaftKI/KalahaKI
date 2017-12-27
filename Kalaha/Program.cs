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
{	using NeuralNetwork;
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
		    
		    Tournament Turnier = new Tournament(3);
		    var Gewinnerliste = Turnier.WinnersOfTournament();


			System.Console.ReadKey();
			
		}
		
	}
}
