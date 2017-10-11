/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 22.09.2017
 * Time: 22:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NeuralNetwork
{
	
	/// <summary>
	/// Description of NeuralNetwork.
	/// </summary>
	public class NeuralNetwork
	{
		private List<InputNeuron> inputNeurons = new List<InputNeuron>();
		private List<WorkingNeuron> outputNeurons = new List<WorkingNeuron>();
		private List<WorkingNeuron> hiddenNeurons = new List<WorkingNeuron>();
		
		static private Random RNDGen = new Random();
		
		public InputNeuron createNewInput() //Methode, die ein neues Inputneuron zur liste inputNeurons hinzufügt und das Neue InputNeuron zurueckgibt
		{
			InputNeuron iN = new InputNeuron();
			inputNeurons.Add(iN);
			return iN;
		}
		
		public WorkingNeuron createNewOutput() //selbes wie bei InputNeuron oben
		{
			WorkingNeuron oN = new WorkingNeuron();
			outputNeurons.Add(oN);
			return oN;
		}
		
		public void  createNewHidden(int amount)
		{
			for(int i=1; i<=amount; i++)
			{
				hiddenNeurons.Add(new WorkingNeuron());
				
			}
		}
		
		public void createFullMesh() //Achtung ich glaub Benes Methode failed wenns keine hidden neuronen gibt!
		{
			if (hiddenNeurons.Count == 0)
			{			
				foreach(WorkingNeuron wN in outputNeurons)
				{
					foreach(InputNeuron iN in inputNeurons)
					{
						wN.addConnection(new Connection(iN, 0));
					
					}
				}
			}
			else
			{
				foreach(WorkingNeuron  hN in hiddenNeurons) //Connections zw hidden-Schicht (mitte) und input-schicht (links)
				{
					foreach(InputNeuron iN in inputNeurons)
					{
						hN.addConnection(new Connection(iN,0));
					}
				}
				
				//TODO Hier könnte man eine schleife ueber evt mehrere Hiddenschichten machen 
				//(konstrukt von unten mit schleife ueber liste der hiddenlisten aussenrum)
				
				foreach(WorkingNeuron  oN in outputNeurons) //Connections zw hidden-Schicht (mitte) und output-schicht (rechts)
				{
					foreach(WorkingNeuron hN in hiddenNeurons)
					{
						oN.addConnection(new Connection(hN,0));
					}
				}				
			}
				
		}
		
		public void createFullMesh(float[] weights) //float weights[]: erst input -> hidden: erstes hidden kriegt conn. zu allen input, der reihe nach mit allen hidden
													//		
													//				   		hidden -> output: erstes output kriegt conn. zu allen hidden...
		{
			//TODO exception bei unpassenden Gewichtungslisten (in else noch bissl komplizierter)!
			
			short i = 0;
			if (hiddenNeurons.Count == 0) 
			{			
				foreach(WorkingNeuron wN in outputNeurons)
				{
					foreach(InputNeuron iN in inputNeurons)
					{
						wN.addConnection(new Connection(iN, weights[i++])); //TODO sinnvolle möglichkeit gewichte zu uebergeben basteln
						
					}
				}
			}
			
			else 
			{	
				int shouldAmountweights=inputNeurons.Count*hiddenNeurons.Count + hiddenNeurons.Count*outputNeurons.Count;
				if (weights.GetLength(0) != shouldAmountweights)
				{
					throw new ArgumentException("Die Gewichtungsliste weights hat die falsche Größe!");
				}
				
				
				foreach(WorkingNeuron  hN in hiddenNeurons) //Connections zw hidden-Schicht (mitte) und input-schicht (links)
				{
					foreach(InputNeuron iN in inputNeurons)
					{
						hN.addConnection(new Connection(iN,weights[i++]));
					}
				}
								
				
				foreach(WorkingNeuron  oN in outputNeurons) //Connections zw hidden-Schicht (mitte) und output-schicht (rechts)
				{
					foreach(WorkingNeuron hN in hiddenNeurons)
					{
						oN.addConnection(new Connection(hN, weights[i++]));
					}
				}	
			}			
		}		
		
		//---------------------------AB HIER SELBST GEMACHT---------------------------------------------
		
		public NeuralNetwork(int amountIN, int amountHN, int amountON, float[] weights, bool RNDweights=false, float RangeRNDweights = 1, IActivationFunction ActFct = null)
		{
			
			for (int i = 0; i < amountIN; i++) {
				inputNeurons.Add(new InputNeuron());
			}
			for (int i = 0; i < amountON; i++) {
				outputNeurons.Add(new WorkingNeuron(ActFct));
			}
			createNewHidden(amountHN);
			if (RNDweights == false) {
				createFullMesh(weights);
			}
			
			if (RNDweights==true) {
				weights = new float[(inputNeurons.Count+outputNeurons.Count)*hiddenNeurons.Count];
				
				weights = CreateRandomArray(weights.GetLength(0),RangeRNDweights); //!!!
				
			}
			
			createFullMesh(weights);
		}
		
		public NeuralNetwork()
		{
			
		}
		
		public float[] GetAllOutputs()
		{			
			float[] res = new float[outputNeurons.Count];
			
			for (int i = 0; i < outputNeurons.Count; i++)
			{
				res[i]= outputNeurons[i].getValue();
			}
			return res;
			
		}
		
		public float[] GetAllInputs()
		{
			float[] res = new float[inputNeurons.Count-1];
			
			for (int i = 0; i < inputNeurons.Count; i++)
			{
				res[i]= inputNeurons[i].getValue();
			}
			return res;			
		}
		
		static private float CreateRandomFloat(float range, int sign = 0) //sign=0: pos od. neg. sign<0: neg., sonst pos
		{
			
			float rndNum = (float)RNDGen.NextDouble();
			if (sign == 0) {
				
				sign = RNDGen.Next(-1,1);
				if(sign != 0){sign = sign/Math.Abs(sign);}
				return sign*rndNum;
			}
			else if (sign<0) {
				return -rndNum;
			}
			else{return rndNum;}			
		}
		
		 static public float[] CreateRandomArray(int Length, float range=1, int sign = 0)
		{	
			float[] array = new float[Length];
			for (int i = 0; i < array.GetLength(0); i++) {
				array[i] = CreateRandomFloat(range,sign);
			}
			return array;
		}
		
	}
}
