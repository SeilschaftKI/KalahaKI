/*
 * Benutzer: Daniel
 * Datum: 14.10.2017
 * Zeit: 17:48
 */


using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace NeuralNetwork
{
	/// <summary>
	/// Description of NNData.
	/// </summary>
	public struct NNData : IEquatable<NNData>
	{
		
		
		private int member;
		private int _numIpNeur;
		private int _numHdNeur;
		private int _numOpNeur;
		private float[] _weights;
		private IActivationFunction _actFct;

		
		public override string ToString() //TODO Buggy! :(
		{
			char[] c = {};
			string weightString = new string(c);
//			weightString.
//			for (int i = 0; i < Weights.GetLength(0); i++) {
//				weightString.Insert(weightString.Length,Weights[i]+"#");
//			}
			
//			weightString.Insert(weightString.Length,Convert.ToString(Weights[4])+"#");
//			
//			Console.WriteLine(weightString);
//			Console.ReadKey();
//			return string.Format("[NNData NumIpNeur={0}, NumHdNeur={1}, NumOpNeur={2}, Weights={3}]", NumIpNeur.ToString(), NumHdNeur.ToString(), NumOpNeur, Weights.ToString());
			return string.Format("[NNData NumIpNeur={0}, NumHdNeur={1}, NumOpNeur={2}, Weights={3}]", NumIpNeur, NumHdNeur, NumOpNeur, Weights);
			
		}

		
		#region Accessors
		public int NumIpNeur
		{
			get{return _numIpNeur;}
			set{_numIpNeur=value;}
		}
		public int NumHdNeur
		{
			get{return _numHdNeur;}
			set{_numHdNeur=value;}
		}
		public int NumOpNeur
		{
			get{return _numOpNeur;}
			set{_numOpNeur=value;}
		}
		
		public float[] Weights
		{
			get{return _weights;}
			set{_weights=value;}
		}
		
		public IActivationFunction ActivFct
		{
			get{return _actFct;}
			set{_actFct = value;}
		}
		
		#endregion
		
		#region Equals and GetHashCode implementation
		// The code in this region is useful if you want to use this structure in collections.
		// If you don't need it, you can just remove the region and the ": IEquatable<NNData>" declaration.
		
		public override bool Equals(object obj)
		{
			if (obj is NNData)
				return Equals((NNData)obj); // use Equals method below
			else
				return false;
		}
		
		public bool Equals(NNData other)
		{
			// add comparisions for all members here
			return this.member == other.member;
		}
		
		public override int GetHashCode()
		{
			// combine the hash codes of all members here (e.g. with XOR operator ^)
			return member.GetHashCode();
		}
		
		public static bool operator ==(NNData left, NNData right)
		{
			return left.Equals(right);
		}
		
		public static bool operator !=(NNData left, NNData right)
		{
			return !left.Equals(right);
		}
		#endregion		
	}
	
}
	

	
