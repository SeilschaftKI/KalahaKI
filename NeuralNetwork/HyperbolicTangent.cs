/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 23.09.2017
 * Time: 23:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NeuralNetwork
{
	/// <summary>
	/// tanh(x) = (exp(x)-exp(-x)) / (exp(x)+exp(-x))
	/// </summary>
	public class HyperbolicTangent : IActivationFunction
	{
		public float Activation(float input)
		{
			float epx = (float)Math.Pow(Math.E,input);
			float enx = (float)Math.Pow(Math.E,-input);
			
			return (float)((epx-enx)/(epx+enx));
		}
	}
}
