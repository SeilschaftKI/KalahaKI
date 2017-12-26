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
		   	
//		    List<KIPlayer> dudes = new List<KIPlayer>();
//		    
//		    for (int i = 0; i < 10; i++) {
//		    	KIPlayer newdude = new KIPlayer(new NeuralNetwork(3,3,3,5f));
//		    	dudes.Add(newdude);
//		    	
//		    }
//		    
//		    foreach (KIPlayer KP in dudes) {
//		    	Console.WriteLine(dudes.IndexOf(KP));
//		    }
		    
//		    Console.WriteLine("ERSTMAL MIT HUMAN PLAYER TESTEN OB DIE ZUGWECHSEL FUNKTIONIEREN!!!!!");
		    Tournament Turnier = new Tournament(3);
		    Turnier.FillResultTableau();

//		    
//		   
//		    int[] arr = {0,1,2,3,4,5,6,7,8,9,10,11,12,13};
//		    int[] arr2 = KIPlayer.ShiftArray(arr,7);
//		    
//		    for (int i = 0; i < arr.GetLength(0); i++) {
//		    	Console.WriteLine(arr2[i]);
//		    }
		
//		KalahaMatch kalahaMatchHuman = new KalahaMatch(new HumanPlayer(), new HumanPlayer());
//        kalahaMatchHuman.Match(); 

//		KalahaMatch kalahaMatchKI = new KalahaMatch(new KIPlayer(6), new KIPlayer(6));
//        kalahaMatchKI.Match();        
          //  Console.WriteLine(kalahaMatch.Match());
//			
//			
//			
			System.Console.ReadKey();
			
		}
		
	}
}
