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
using System.Xml;
using System.Xml.XPath;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
		 
//		 public NNData getData() // gut und nötig?
//		 {
//		 	NNData res = this.Data;
//		 	return res;
//		 }
//		 
		 #endregion
		 
		#region Data-Methoden
//		TODO: inline-Methode dergestalt, dass sie das an gewünschter, übergebener stelle das NN rausspuckt, andere Methode zum Navigieren.
//		TODO: Flexible Pfade, flexibilität "alle NN in die gleiche datei" vs. "extra-Datei für einzelne NN"
		 public void refreshData()
		 {
		 	this.Data.NumIpNeur = this.inputNeurons.Count;
		 	this.Data.NumHdNeur = this.hiddenNeurons.Count;
		 	this.Data.NumOpNeur = this.outputNeurons.Count;
		 	
		 	this.Data.Weights = this.getWeightsAsArray();
		 	this.Data.ActivFct = this.outputNeurons[0].ActFct;
		 }
		 
		 public void DataXMLappendToNode(string TargetFile, string TargetNode, string ID, string Name = "NoNameNN")
		 {//attack here
		 	XmlDocument doc = new XmlDocument();
		 	doc.Load(TargetFile);
		 
		 	
		 	
//		 	TargetNode = docroot.Name+TargetNode;
//		 	TargetNode = doc.Name+TargetNode;
		 	
		 	
			XmlNode NNroot,NNhead, NumIpNeur_Node, NumHdNeur_Node, NumOpNeur_Node, Weights_Node;
			//....
//			try {
				NNroot = doc.SelectSingleNode(TargetNode);
//			}
//			catch
//			{
//				return;
//			}
				
			
			NNhead =  doc.CreateElement(Name);
			// Schreibe ID als Attribute in die Node des NN
			XmlAttribute ID_Attribute;
			ID_Attribute = doc.CreateAttribute("ID");
			ID_Attribute.InnerText = ID;
			NNhead.Attributes.Append(ID_Attribute);
			
			NNroot.AppendChild(NNhead);
			
////		 	var Weights_nodeList_xml = root.SelectNodes("/Weight");
//		 	var Weights_nodeList_xml = Weights_node_xml.ChildNodes;
//		 	int size = Weights_nodeList_xml.Count;
//		 	
//				
//				
		 	NumIpNeur_Node = doc.CreateElement("NumberOfIpNeurons");
		 	NumIpNeur_Node.InnerText = Data.NumIpNeur.ToString();
		 	NNhead.AppendChild(NumIpNeur_Node);
//		 	
		 	NumHdNeur_Node = doc.CreateElement("NumberOfHdNeurons");
		 	NumHdNeur_Node.InnerText = Data.NumHdNeur.ToString();
		 	NNhead.AppendChild(NumHdNeur_Node);
//		 	
		 	NumOpNeur_Node = doc.CreateElement("NumberOfOpNeurons");
			NumOpNeur_Node.InnerText = Data.NumOpNeur.ToString();
		 	NNhead.AppendChild(NumOpNeur_Node);
		 	
		 	var NNweights = Data.Weights;
		 	Weights_Node = doc.CreateElement("Weights");		 	
		 	for (int i = 0; i < NNweights.GetLength(0); i++) {
		 		var next_weight = doc.CreateElement("Weight");
		 		XmlAttribute Number_Attribute;
		 		Number_Attribute = doc.CreateAttribute("NR");
		 		Number_Attribute.InnerText = Convert.ToString(i);
		 		
		 		next_weight.InnerText = NNweights[i].ToString();
		 		next_weight.Attributes.Append(Number_Attribute);
		 		
		 		Weights_Node.AppendChild(next_weight);
		 	}		 	
		 	NNhead.AppendChild(Weights_Node);                              		 	
//		 	doc.Save(savepath);
		 	
		 	doc.Save(@"..\StoredNNs.xml");
		 	
		 }
		 
		 public void DataToXML(string NN_name = "DummyNameNN", string savepath = @"..\StoredNNs.xml")
		 {
		 	// @ deklariert den folgenden String als verbatim string, dh ua backslashs müssen in pfaden nicht doppelt gesetzt werden wie sonst nötig
		 	/*Nodes entsprechen Tags aus HTML
		 	 MotherNode.Append(ChildNode) fügt zu einer existierenden Node "MotherNode" eine node "ChildNode" hinzu, ähnlich einer Baumstruktur
		 	 der etxt innerhalb der Tags wird mit "MotherNode.InnerText = ..." bzw "childNode.InnerText = ...." gesetzt*/
		 	var NNweights = Data.Weights;
		 	XmlDocument doc = new XmlDocument();
		 	
		 	XmlNode docRoot, NNroot, NumIpNeur_Node, NumHdNeur_Node, NumOpNeur_Node, Weights_Node;
		 	docRoot = doc.CreateElement("subroot");
		 	doc.AppendChild(docRoot);
		 	NNroot =  doc.CreateElement(NN_name);
		   
		 	docRoot.AppendChild(NNroot);
		 	
		 	NumIpNeur_Node = doc.CreateElement("NumberOfIpNeurons");
		 	NumIpNeur_Node.InnerText = Data.NumIpNeur.ToString();
		 	NNroot.AppendChild(NumIpNeur_Node);
		 	
		 	NumHdNeur_Node = doc.CreateElement("NumberOfHdNeurons");
		 	NumHdNeur_Node.InnerText = Data.NumHdNeur.ToString();
		 	NNroot.AppendChild(NumHdNeur_Node);
		 	
		 	NumOpNeur_Node = doc.CreateElement("NumberOfOpNeurons");
			NumOpNeur_Node.InnerText = Data.NumOpNeur.ToString();
		 	NNroot.AppendChild(NumOpNeur_Node);
		 	
		 
		 	Weights_Node = doc.CreateElement("Weights");		 	
		 	for (int i = 0; i < NNweights.GetLength(0); i++) {
		 		var next_weight = doc.CreateElement("Weight");
		 		XmlAttribute Number_Attribute;
		 		Number_Attribute = doc.CreateAttribute("NR");
		 		Number_Attribute.InnerText = Convert.ToString(i);
		 		
		 		next_weight.InnerText = NNweights[i].ToString();
		 		next_weight.Attributes.Append(Number_Attribute);
		 		
		 		Weights_Node.AppendChild(next_weight);
		 	}		 	
		 	NNroot.AppendChild(Weights_Node);                              		 	
		 	doc.Save(savepath);
		 }
		 
		 public static NNData XMLToData(string filepath = @"..\StoredNNs.xml") //TODO UNDER CONSTRUCTION!. Später: standard-pfad nach entwicklung in was sinnvolles ändern
		 {
		 	NNData data = new NNData();
		 	XmlNode Weights_node_xml;
		 	
		 	XmlDocument doc = new XmlDocument();
		 	doc.Load(filepath);
		 	XmlElement root = doc.DocumentElement;
		 	
		 	Weights_node_xml = doc.SelectSingleNode(@"/subroot/Weights"); // attac here?"!
//		 	var Weights_nodeList_xml = root.SelectNodes("/Weight");
		 	var Weights_nodeList_xml = Weights_node_xml.ChildNodes;
		 	int size = Weights_nodeList_xml.Count;
		 	
		 	string NNname = "Hugognolf_die_Ur-KI";
		 	
		 	data.Weights = new float[size];
		 	
		 	XmlNode NumIp_xml, NumHd_xml, NumOp_xml;
		 	NumIp_xml = doc.SelectSingleNode(root.Name+"/"+NNname+"/NumberOfIpNeurons");
		 	int NIP = new int();
		 	NIP = Convert.ToInt32(NumIp_xml.InnerText);
		 	data.NumIpNeur = NIP;
		 	
		 	NumHd_xml = doc.SelectSingleNode(root.Name+"/"+NNname+"/NumberOfHdNeurons");
		 	int NHD = new int();
		 	NHD=Convert.ToInt32(NumHd_xml.InnerText);
		 	data.NumHdNeur = NHD;
		 	
		 	NumOp_xml = doc.SelectSingleNode(root.Name+"/"+NNname+"/NumberOfOpNeurons");
		 	int NOP = new int();
		 	NOP=Convert.ToInt32(NumOp_xml.InnerText);
		 	data.NumOpNeur = NOP;
		 	
//		 	int WeightsAmount = doc.SelectNodes("Weights_xml =  doc.SelectSingleNode(root.Name+"/Weights");
//		 	foreach (XmlNode weight in Weights_xml) {
//		 		int i = 0;5
//		 		data.Weights[i]= float.Parse(weight.InnerText);
//		 	}
		 	
		 	var checkchildnodes = Weights_node_xml.ChildNodes;
		 	int i = 0;
		 	foreach (XmlNode w in Weights_node_xml.ChildNodes) {
		 		
		 		data.Weights[i] = float.Parse(w.InnerText);
		 		i++;
		 	}
		 	return data;
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
