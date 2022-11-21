// /*
//  * Created by SharpDevelop.
//  * User: Daniel
//  * Date: 22.09.2017
//  * Time: 20:56
//  * 
//  * To change this template use Tools | Options | Coding | Edit Standard Headers.
//  */
// using System;

// namespace NeuralNetwork
// {
// 	class Program
// 	{
// 		public static void Main(string[] args)
// 		{
// //			InputNeuron iN = new InputNeuron();
// //			Console.WriteLine("Der wert aus iN ist: \n"+ iN.getValue());
			
// 			//----------------SINGLE PERCEPTRON TEST----------------
			
// 			NeuralNetwork NN = new NeuralNetwork();
			
// 			InputNeuron i1 = NN.createNewInput();
// 			InputNeuron i2 = NN.createNewInput();
// 			InputNeuron i3 = NN.createNewInput();
// 			InputNeuron i4 = NN.createNewInput();
			
// 			NN.createNewHidden(3);
			
// 			WorkingNeuron o1 = NN.createNewOutput();
			
// 			NN.createFullMesh(new float[]{10,0,0,0,
// 			                  		0,0,0,0,
// 			                  		0,0,0,0,
// 			                  		10,0,0}); //gebraucht sind: #Input*#Hidden + #hidden*#Output gewichte
			
			
// 			i1.setValue(1);
// 			i2.setValue(2);
// 			i3.setValue(3);
// 			i4.setValue(4);
			
// 			Console.Write("Das Output Neuron o1 gibt folgenden Wert aus:\n"+o1.getValue()+"\n\n");
			
			
// //			
			
			
// 			//------------ENDE PERCEPTRON TEST--------------------			
			
// 			Console.Write("Press any key to continue . . . ");
// 			Console.ReadKey(true);
// 		}
// 	}
// }
