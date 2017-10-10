/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 23.09.2017
 * Time: 01:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NeuralNetwork
{
	/// <summary>
	/// Interface für Aktivierungsfunktionen der Working Neuronen.
	/// </summary>
	public interface IActivationFunction
	{
//		public static Identity ActivationIdentity = new Identity();
//		public static Sigmoid ActivationSigmoid = new Sigmoid();
		float Activation(float input);
	}
}
