/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 22.09.2017
 * Time: 21:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NeuralNetwork
{
	/// <summary>
	/// Verbindung beinhaltet ihre Gewichtung, sowie das angehängte Neuron "links"
	/// </summary>
	public class Connection
	{
		private float weight;
		private Neuron neuron; 
		
		public float getWeight;
			
		
		
		
		public Connection(Neuron neuron, float weight) //Konstruktor
		{
			this.neuron = neuron;
			this.weight = weight;
		}
		
		public float getValue()
		{
			return neuron.getValue()*weight;
		}
	}
}
