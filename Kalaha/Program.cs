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
//
//			HumanPlayer HuPlayer = new HumanPlayer();
//			KIPlayer KiPlayer =  new KIPlayer(6); 			
//			KalahaMatch TheMatch = new KalahaMatch(KiPlayer,HuPlayer,6);
//			Result res = TheMatch.Match();
		    
		   
//		    float[] myweights = {1f,2.77f,3f,4f,5f,6f,7f,8f};
//		    var NN = new NeuralNetwork(1,2,3,myweights);
//		    NN.DataToXML("Hugo_die_Ur-KI");
//		    
//		    var CreatedData = NeuralNetwork.XMLToData();
//		    Console.WriteLine(CreatedData.ToString());
		    Console.ReadKey();
//			
		}
		
	}
}
