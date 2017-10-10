/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 01.10.2017
 * Time: 18:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalaha
{
	/// <summary>
	/// Das Formular, das das Visualisierte Spielbrett darstellt.
	/// Hier wird nur der aktuelle zustand des spiels bildlich dargestellt und NICHTS gerechnet
	/// Für Menschliche Player werden durch Click-Ereignisse hier die Züge ausgelöst
	/// </summary>
	/// 
	public partial class KalahaBoardDisplay_Dani	: Form
	{
//		private string TestString = "Honig"; //RUMSPIELEN, nacher löschen!!!
//		private int TestInt = 123;
		//----
		
		public KalahaBoardDisplay_Dani() //Konstruktor
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
					
		}
		
		
		//-------------------------STEUERELEMENTE-------------------------
		
		void Button1Click(object sender, EventArgs e) //Exit-Button
		{
			Application.Exit();
		}
		void Rdb_BlackTurnCheckedChanged(object sender, EventArgs e)
		{
	
		}
		void GroupBox1Enter(object sender, EventArgs e)
		{
	
		}
		void KalahaBoardDisplayLoad(object sender, EventArgs e)
		{
	
		}
		
		
	}
}
