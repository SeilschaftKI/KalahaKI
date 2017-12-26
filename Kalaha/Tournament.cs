/*
 * Benutzer: Daniel
 * Datum: 16.10.2017
 * Zeit: 19:40
 */


using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Kalaha
{
	/// <summary>
	/// Description of Tournament.
	/// </summary>
	public class Tournament
	{
		private List<KIPlayer> competitors = new List<KIPlayer>();
		//private List<KIPlayer> winners = new List<KIPlayer>();
		//private List<Result> results = new List<Result>();
		Result[,] resultList;
		
		public Tournament(int NumCompetitors = 20)
		{
			for (int i = 0; i < NumCompetitors; i++) {				
				var KP = new KIPlayer(6);
				competitors.Add(KP);
			}			
			resultList = new Result[NumCompetitors, NumCompetitors];			
		}
		
		public void FillResultTableau()
		{
			Result NullResult = new Result(0, 0, 0);
			foreach (KIPlayer KP in competitors) {
				int IndKP = competitors.IndexOf(KP);				
				resultList[IndKP, IndKP] = NullResult; //Player gegen sich selbst wird nicht ausgespielt
				for (int i = 0; i < competitors.Count; i++) {
					if (IndKP == i) {
						
					}else{
						var Match = new KalahaMatch(KP, competitors[i], 6);
						resultList[competitors.IndexOf(KP), i] = Match.Match(); 
			
							
					}
				}
				
//				var Match = new KalahaMatch(competitors[0], competitors[1], 6);
//				Console.WriteLine("BLUBB");
//				resultList[0, 1] = Match.Match();
//				Console.WriteLine("SPIEL 1 AUS");
//				
//				var Match2 = new KalahaMatch(competitors[1], competitors[0], 6);
//				resultList[1, 0] = Match2.Match();
//				Console.WriteLine("SPIEL 2 AUS");
//				
//				var Match3 = new KalahaMatch(competitors[0], competitors[2], 6);
//				resultList[0, 2] = Match3.Match(); 
//				Console.WriteLine("SPIEL 3 AUS");
			
		}
			
			
			Console.ReadKey();
		}
		
		
		private void ratePlayers()
		{
			
		}
		
		
		
		
	}
}
