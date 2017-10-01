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
			{	//WIESO KANN MAN KEINE int MIT != VERGLEICHEN??
				//Bauern-exception
//				if (weights.Count != inputNeurons.Count*hiddenNeurons.Count + hiddenNeurons.Count*outputNeurons.Count)
//				{
//					Console.WriteLine("#Gewichte inhaltlich falsch!");
//				}
				
				Console.Write("Die Liste inputNeurons enthaelt "+ inputNeurons.Count +"Objekte\n");
				Console.Write("Die Liste hiddenNeurons enthaelt "+ hiddenNeurons.Count +"Objekte\n\n");
				
				foreach(WorkingNeuron  hN in hiddenNeurons) //Connections zw hidden-Schicht (mitte) und input-schicht (links)
				{
					foreach(InputNeuron iN in inputNeurons)
					{
						hN.addConnection(new Connection(iN,weights[i++]));
					}
				}
				
				Console.Write("die Input- und Hiddenschicht ist jetzt vermascht.\n Wert des schleifenzählers ist:\n "+i+"\n\n");
				//TODO Hier könnte man eine schleife ueber evt mehrere Hiddenschichten machen 
				//(konstrukt von unten mit schleife ueber liste der hiddenlisten aussenrum)
				
				foreach(WorkingNeuron  oN in outputNeurons) //Connections zw hidden-Schicht (mitte) und output-schicht (rechts)
				{
					foreach(WorkingNeuron hN in hiddenNeurons)
					{
						oN.addConnection(new Connection(hN, weights[i++]));
					}
				}	
			}			
		}
		
		
		
		
//		public NeuralNetwork()
//		{
//		}
	}
}
