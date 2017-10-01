/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 22.09.2017
 * Time: 20:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;

namespace NeuralNetwork
{
	/// <summary>
	/// Abstrakte Oberklasse von der Neuronen (InputNeuron, WorkingNeuron) geerbt werden.
	/// </summary>
	public abstract class Neuron
	{
		public abstract float getValue();
	}
}
