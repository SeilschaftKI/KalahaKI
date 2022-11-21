/*
 * Benutzer: Daniel
 * Datum: 16.10.2017
 * Zeit: 19:40
 */


using System.Collections.Generic;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Kalaha
{
	/// <summary>
	/// A Tournament is a series of matches. The matches'm results are saved in resultList, twodimensional array.
	/// </summary>
	public class Tournament
	{
		private List<Player> competitors = new List<Player>();
		private List<Player> winners = new List<Player>();
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
			foreach (Player PL in competitors) {
				int IndPL = competitors.IndexOf(PL);				
				resultList[IndPL, IndPL] = NullResult; //Player gegen sich selbst wird nicht ausgespielt
				for (int i = 0; i < competitors.Count; i++) {
					if (IndPL == i) {
						//NO OP
					}else{
						var Match = new KalahaMatch(PL, competitors[i], 6);
						resultList[competitors.IndexOf(PL), i] = Match.Match();								
					}
				}
			}			
			ratePlayers_NumOfWins();
		}	
		
		public List<Player>  WinnersOfTournament()
		{
			FillResultTableau();
			winners = ChooseWinners(ratePlayers_NumOfWins());
			foreach (KIPlayer Pl in winners) {
				Pl.refreshNNData();
			}
			
//			//Nur KIPlayer haben ein NN. zum speichern od. anderweitig verarbeiten der Sieger muss also eine Liste rein aus KI
//			//KIPlayer erstellt werden: KIwinners
//			List<KIPlayer> KIwinners = winners.OfType<KIPlayer>().ToList();
//			KIwinners[1].appendNNData2Xml("#000100",@"..\StoredNNs.xml","NeuralNetworks","OlberichAusBern");
			return winners;
		}
		
		private List<Player> ChooseWinners(List<Tuple<float,Player>> RatedPlayers, int numberOfWinners = 2)
		{
			// TODO SORTIEREN, im moment noch zufällig!!!
			RatedPlayers.Sort((x, y) => y.Item1.CompareTo(x.Item1));
			var sortedPlayers = new List<Player>();
			for (int i = 0; i < numberOfWinners; i++) {
				sortedPlayers.Add(RatedPlayers[i].Item2);
			}
			
			return sortedPlayers;
		}
		
		
		private List<Tuple<float,Player>> ratePlayers_NumOfWins()
		{
			int NumComp = competitors.Count;
			var PlayerValues = new List<Tuple<float,Player>>();
			
			
			foreach (Player PL in competitors) {
				var NextTuple = new Tuple<float,Player>(0f,PL);
				PlayerValues.Add(NextTuple);
			}
			
			foreach (Player PL in competitors) {
				int IndPL = competitors.IndexOf(PL);
				for (int IndOpp = 0; IndOpp < NumComp; IndOpp++) { //"Heimpsiele"
					if (resultList[IndPL,IndOpp].Score0 > resultList[IndPL,IndOpp].Score1) {
						PlayerValues[IndPL] = new Tuple<float,Player>(PlayerValues[IndPL].Item1+1,PL); //TODO Das Dauert lange und ist hässlich, weil man Tuples nicht verändern kann. Bessere ösung?
					}
				}
				
				for (int IndOpp = 0; IndOpp < NumComp; IndOpp++) { //"Auswärtsspiele"
					if (resultList[IndOpp,IndPL].Score0 < resultList[IndOpp,IndPL].Score1) {
						PlayerValues[IndPL] = new Tuple<float,Player>(PlayerValues[IndPL].Item1+1,PL); //TODO Das Dauert lange und ist hässlich, weil man Tuples nicht verändern kann. Bessere ösung?
					}
				}
			}
		
			return PlayerValues;
		}
				//TODO Besser wäre wahrscheinlich, jedem Tournament ein interface mit rating-funktionen zu geben. aber erstmal mach ichs nach dem motto "hauptsach läuft"
		
		private float evaluate_result(Result res) //TODO hier eine evaluierungsfunktion, die fuer ein result einen wert ausspuckt, das wäre flexibler
		{
				return 0;
		}
		
		
		
	}
}
