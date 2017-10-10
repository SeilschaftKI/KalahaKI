/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 22.09.2017
 * Time: 21:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NeuralNetwork
{
	/// <summary>
	/// Neuron das am Anfang des Netztes steht. Bekommt einen Wert und gibt diesen wieder, OHNE Aktivierungsfkt.
	/// </summary>
	public class InputNeuron : Neuron
	{
		
		private float value = 0;
		
		public override float getValue()
		{
			return value;
		}
		
		public void setValue(float value)
		{
			this.value = value;
		}
//		
//		public InputNeuron(float x) //TODO: evt hier noch konstruktor bauen??
//		{
//			value=x;
//		}
	}
}
