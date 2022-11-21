﻿/*
 * Benutzer: Daniel
 * Datum: 09.10.2017
 * Zeit: 12:53
 */


using System.Collections.Generic;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using NeuralNetwork;

namespace Kalaha
{
	
	using NeuralNetwork;
	/// <summary>
	/// Description of KIPlayer.
	/// </summary>
	public class KIPlayer : Player
	{
		
		private NeuralNetwork NN;
		
		public KIPlayer(NeuralNetwork NN) 
		{
			this.NN = NN;
		}
		
		public KIPlayer(int BoardSize)
		{
			int amountIN = 2*(BoardSize+1);
			int amountON = BoardSize;
			int amountHN = amountIN;
			int amountConns = amountHN*(amountIN+amountON);
			float[] weights = new float[amountConns];
			
			this.NN = new NeuralNetwork(amountIN, amountHN, amountON, 3);			
		}
		
		override public int ChooseMove(int[] UnAdjustedSlots) //muss von PLAYSIDE ABHÄNGEN!!!! immer bei ind 0 der eigenen seite starten!
		{
			int[] Slots = ShiftArray(UnAdjustedSlots,PlaySide*(SlotsToChoose+1));
			int res = 0;
			float[] fSlots = new float[Slots.GetLength(0)]; //Gleicher Array in float, um die input-Neur. damit zu füttern
			
			for (int i = 0; i < Slots.GetLength(0); i++) {
				fSlots[i]=(float)Slots[i];
			}
			
			NN.setAllInputs(fSlots); //Slot-Füllungen werden an Input-Neur. übegeben
			res = IndOfMax(NN.GetAllOutputs());
			
			while (Slots[res]==0) {
				res = (res+1) % this.SlotsToChoose;
			}
			
			return res;
		}
		
		public void refreshNNData()
		{
			this.NN.refreshData();
		}
		
		public void appendNNData2Xml(string ID, string TargetFile, string TargetNode, string Name="NonameNN")
		{
			this.NN.DataXMLappendToNode(@"..\StoredNNs.xml", TargetNode, ID, Name);
		}
		
		
				
		private static int IndOfMax(float[] array)
		{
			int maxind = 0;
			for (int i = 1; i < array.GetLength(0); i++) {
				if (array[maxind] < array[i] ) {
					maxind = i;
				 }
			}
			return maxind;
		}
		
		private static int[] ShiftArray(int[] arr, int steps)
		{
			int l = arr.GetLength(0);
			int[] WorkArr= new int[l];
			
			for (int i = 0; i < l; i++) {
				WorkArr[(i+steps)%l]= arr[i];
				
			}
			
			return WorkArr;
		}
		
	}
}
