/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 23.09.2017
 * Time: 01:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NeuralNetwork
{
	/// <summary>
	/// Description of Sigmoid.
	/// </summary>
	public class Sigmoid : IActivationFunction
	{
		public float Activation(float input)
		{
			return(float)(1f/(1+ Math.Pow(Math.E, -input)));
		}
	}
}
