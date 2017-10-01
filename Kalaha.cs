/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 01.10.2017
 * Time: 18:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NeuralNetwork;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kalaha
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			NeuralNetwork NN = new NeuralNetwork();
//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	}
}
