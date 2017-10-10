/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 23.09.2017
 * Time: 01:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NeuralNetwork
{
	/// <summary>
	/// Description of Identity.
	/// </summary>
	public class Identity : IActivationFunction
	{
		public float Activation(float input)
		{
			return(float) input;
		}
	}
}
