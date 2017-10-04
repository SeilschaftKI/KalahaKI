/*
 * User: Daniel
 * Date: 02.10.2017
 * Time: 17:32
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
	/// Kalaha Board soll die Listen enthalten, die die Slotfüllung darstellen, sowie die zugehörige Dynamik,
	/// also sprich die implementierten "Züge"
	///
	/// Standardmäßig: jeder spieler hat 6 Felder + 1 Kalaha, Startfüllung von jedem Feld sind 6 Kugeln
	/// 
	/// </summary>
	public class KalahaBoard
	{	
		public static readonly ushort STD_BOARDSIZE = 6;
		
		private ushort BoardSize {get;set;}
		private ushort StartValue {get;set;}
		
		private ushort[] BlackSlots;
		private ushort[] WhiteSlots;
		
		public KalahaBoardDisplaySTD BoardDisplayInstance = new KalahaBoardDisplaySTD(); //Fürs KI Training sollte das optional sein.
																				  //wie das geht kommt mal in der EvoNet docu.
		
		//TODO wie kann ich eleganter von KalahaBoardDisplay zu KalahaBoardDisplaySTD Wechseln ohne immer hier zu ändern??																		  
		

//------------------------METHODEN------------------------------------------		
		private void fillSlots()
		{
			BlackSlots[0] = 0; //Kalaha-Feld zu Anfang leer
			WhiteSlots[0] = 0;
			
			for (ushort i = 1; i <= this.BoardSize; i++)
			{
				BlackSlots[i] = this.StartValue;
			
			}
			
		}
																						  
		public KalahaBoard() //Konstruktor ohne Argumente setzt Anfangskugelzahl u. Boardsize auf Standardert
		{
			Application.Run(BoardDisplayInstance); //Ruft das WinForm der Klasse KalahaBoardDisplay auf
			
			//HIER SCHEINTS ZU HÄNGEN :(((
			
			this.BoardSize = STD_BOARDSIZE; //Slotzahl jedes Spielers OHNE KalahaSlot
			this.StartValue = STD_BOARDSIZE;
			
			BlackSlots = new ushort[STD_BOARDSIZE+1]; //ACHTUNG: #Slots  ist STD_BOARDSIZE, aber indiziert von 0!
			WhiteSlots = new ushort[STD_BOARDSIZE+1]; // +1 jeweils Kalaha feld Slots[0..STD_BOARDSIZE] Wobei Slots[0] Kalahafeld
			//MessageBox.Show("Arrays in KalahaBoard wurden erzeugt");
			fillSlots();
			MessageBox.Show("fillSlots wurde ausgefuehrt, der DispBlackSlots[2] ist gleich\n"+ BlackSlots[2]);
			
		}
		
		//TODO flexibler Konstruktor
		
		public void moveBlack(int moveChoice) //TODO machen zwei zugmethoden wirklich sinn?
		{
			//Hier wird gezogen blabla
			
			
			//Jetzt werden neue Werte an den Array im KalahaBoardDisplaySTD übergeben
			BoardDisplayInstance.setBlackBKDSTD(2,55);
			
			
		}
		public void MoveWhite()
		{
			
		}
		
	}
}
