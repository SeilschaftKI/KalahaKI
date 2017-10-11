/*
 * Benutzer: Daniel
 * Datum: 09.10.2017
 * Zeit: 12:53
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
	using NeuralNetwork;
	/// <summary>
	/// Description of KIPlayer.
	/// </summary>
	public class KIPlayer : Player
	{
		NeuralNetwork NN;
		
		public KIPlayer(NeuralNetwork NN) 
		{
			this.NN = NN;
		}
		
		public KIPlayer(int ChooseMove)
		{
			int amountIN = 2*(ChooseMove+1);
			int amountON = ChooseMove;
			int amountHN = amountIN;
			int amountConns = amountHN*(amountIN+amountON);
			float[] weights = new float[amountConns];
			
			
			this.NN = new NeuralNetwork(amountIN, amountHN, amountON, weights/*NeuralNetwork.CreateRandomArray((uint)amountConns,4f)*/,true);
			
		}
		
		override public int ChooseMove(int[] Slots) //int und list, was ist besser??
		{
			int res = 0;
			//List<float> NNOutputs = NN.GetAllOutputs().ToList();
			res = IndOfMax(NN.GetAllOutputs());
			
			while (Slots[res]==0) {
				res = (res+1) % this.SlotsToChoose;
			}
			
			return res;
			
			
			return res; //TODO
		}
		
		int IndOfMax(float[] array)
		{
			int maxind = 0;
			for (int i = 1; i < array.GetLength(0); i++) {
				if (array[maxind] < array[i] ) {
					maxind = i;
				 }
			}
			
			
			return 0;
		}
		
	}
}
