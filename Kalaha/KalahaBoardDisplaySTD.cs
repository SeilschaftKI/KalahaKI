/*
 * User: Daniel
 * Date: 03.10.2017
 * Time: 16:10
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
	/// von hand im Designer erstelltes formular fuer standardgröße
	/// </summary>
	public partial class KalahaBoardDisplaySTD : KalahaBoardDisplay
	{
		private ushort[] DispBlackSlots;
		private ushort[] DispWhiteSlots;
		
		public KalahaBoardDisplaySTD() //Konstruktor
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();		
			
			DispBlackSlots = new ushort[Kalaha.KalahaBoard.STD_BOARDSIZE+1];
			DispWhiteSlots = new ushort[Kalaha.KalahaBoard.STD_BOARDSIZE+1];
			
//			foreach (Control b in Controls) //RUMPROBIEREN: beschriftet alle Buttons ausser Button_Exit mit 0
//			{
//				if(Equals(b, Button_Exit))
//				{
//				}
//				else
//				{
//						if(b is Button)
//						{					
//							b.Text = 0.ToString();					
//						}
//				}
//			} //Rumprobieren	
		}
		
		public void setBlackBKDSTD(int Index, ushort val)
		{
			DispBlackSlots[Index] = val;
			refreshDisplay();
			
		}
		
		private void refreshDisplay()
		{		
			button2.Text = DispBlackSlots[2].ToString();
			MessageBox.Show("humppa"); //kommt hier nicht an :(
		}
		
		
		
		
		
	}
}
