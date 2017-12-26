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
		
		private NNData Data;
		static private Random RNDGen = new Random();
		
		#region
		
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
			int i = 0;
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

		public NeuralNetwork CloneNN(float range=0f)
		 {
			if (range == 0f) {return new NeuralNetwork(this.Data);}
			else{
				return new NeuralNetwork(inputNeurons.Count,hiddenNeurons.Count,outputNeurons.Count,AddArrays(this.getWeightsAsArray(),CreateRandomArray(getWeightsAsArray().GetLength(0),range,0)), this.outputNeurons[0].ActFct);
		 	}
		 }
		
		public override string ToString()
		{
			return Data.ToString();
		}


		#endregion
		
		
		//-------------------------------------------------------------------------
		#region Konstruktoren
		public NeuralNetwork(int amountIN, int amountHN, int amountON, float[] weights, IActivationFunction ActFct = null)
		{//Keine Zufallsgewichte
			
			int amountWeights = ComputeNumOfWeights(amountIN, amountHN, amountON);
			
			if (ActFct == null) {ActFct = new Sigmoid();}
			
			if (amountWeights != weights.GetLength(0)) {
				throw new ArgumentException("weights-Array hat falsche anzahl an argumenten!");
			}
			
			for (int i = 0; i < amountIN; i++) {
				inputNeurons.Add(new InputNeuron());
			}
			for (int i = 0; i < amountON; i++) {
				outputNeurons.Add(new WorkingNeuron(ActFct));
			}
			createNewHidden(amountHN);
			createFullMesh(weights);
			refreshData();
		}
		
		public NeuralNetwork(int amountIN, int amountHN, int amountON, float RangeRNDweights = 1, IActivationFunction ActFct = null)
		{
			if (ActFct == null) {ActFct = new Sigmoid();}
			int amountWeights = 0;
			
			amountWeights = ComputeNumOfWeights(amountIN, amountHN, amountON);
			
			for (int i = 0; i < amountIN; i++) {
				inputNeurons.Add(new InputNeuron());
			}
			for (int i = 0; i < amountON; i++) {
				outputNeurons.Add(new WorkingNeuron(ActFct));
			}
			createNewHidden(amountHN);
			
			
			float[] weights = new float[ComputeNumOfWeights(amountIN,amountHN,amountON)];
				
			weights = CreateRandomArray(weights.GetLength(0),RangeRNDweights);
				
			createFullMesh(weights);
		}
		
		
		public NeuralNetwork(NNData Data) : this(Data.NumIpNeur,Data.NumHdNeur,Data.NumOpNeur, Data.Weights, Data.ActivFct){}
		
		public NeuralNetwork()
		{
			
		}
		
		#endregion
		
		#region Hilfsmethoden
		private static int ComputeNumOfWeights(int amountIN, int amountHN, int amountON){			
			if(amountHN == 0){return amountIN*amountON;}
			else{return amountHN*(amountIN+amountON);}			
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
		
		static private float CreateRandomFloat(float range)
		{			
			float rndNum = (float)RNDGen.NextDouble();

			return 2f*range*(rndNum-0.5f);
		}
			
			

		
		
		static public float[] CreateRandomArray(int Length, float range=1, int sign = 0)
		{	
			float[] array = new float[Length];
			for (int i = 0; i < array.GetLength(0); i++) {
				array[i] = CreateRandomFloat(range);
			}
			return array;
		}
		 

		 
		 static public float[] AddArrays(float[] arr1, float[] arr2)
		 {
		 	for (int i = 0; i < arr1.GetLength(0); i++) {
		 			arr1[i]+=arr2[i];		 			
		 		}
		 		return arr1;
		 }
		 
		 public float[] getWeightsAsArray()
		 {
		 	int amountWeights = ComputeNumOfWeights(inputNeurons.Count, hiddenNeurons.Count, outputNeurons.Count);
		 	float[] res = new float[amountWeights];		 	
			 
			 int counter = 0;	 	

			foreach (WorkingNeuron hN in hiddenNeurons) {	
			 	foreach (float weight in hN.getWeightsAsArray()) {
			 		res[counter]=weight;
			 		counter++;		 		
			 	}
		 	}			 	
		 	foreach (WorkingNeuron oN in outputNeurons) {	
			 	foreach (float weight in oN.getWeightsAsArray()) {
			 		res[counter]=weight;
			 		counter++;		 		
			 	}
		 	}
		 	
			return res;
		}
		 
		 public void setAllInputs(float[] inputs)
		 {	
		 	if (inputs.GetLength(0) <= inputNeurons.Count) {
		 		for (int i = 0; i < inputNeurons.Count; i++) {
		 			inputNeurons[i].setValue(inputs[i]);
		 		}
		 	}
		 	
		 }
		 
		 #endregion
		 
		 
		#region Data-Methoden
		 public void refreshData()
		 {
		 	this.Data.NumIpNeur = this.inputNeurons.Count;
		 	this.Data.NumHdNeur = this.hiddenNeurons.Count;
		 	this.Data.NumOpNeur = this.outputNeurons.Count;
		 	
		 	this.Data.Weights = this.getWeightsAsArray();
		 	this.Data.ActivFct = this.outputNeurons[0].ActFct;
		 }
		 	      
		 
		 
		 #endregion
		 
		 #region Müllhalde
		 
//		 public static float[] operator +(float[] arr1, float[] arr2)
//		 {
//		 	if (arr1.GetLength(0)!=arr2.GetLength(0)) {
//		 		throw new ArgumentException("Es können keine unterschiedlich langen Arrays addiert werden!");
//		 	}
//		 	else{		 		
//		 		return new float[arr1.GetLength(0)] = AddArrays(arr1, arr2);
//		 	}
//		 }
		 
//		 public static NeuralNetwork operator +(NeuralNetwork NN1, NeuralNetwork NN2)
//		 {
//		 	return new NeuralNetwork(
//		 }
		 
		 #endregion
		 
		
	}
}
