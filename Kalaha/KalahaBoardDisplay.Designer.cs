/*
 * Created by SharpDevelop.
 * User: Daniel
 * Date: 01.10.2017
 * Time: 18:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Kalaha
{
	partial class KalahaBoardDisplay
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		protected System.Windows.Forms.Button Button_Exit;
		private System.Windows.Forms.RadioButton rdb_BlackTurn;
		private System.Windows.Forms.RadioButton rdb_WhiteTurn;
		private System.Windows.Forms.RadioButton rdb_GameOver;
		private System.Windows.Forms.GroupBox gB_Turn;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.Button_Exit = new System.Windows.Forms.Button();
			this.rdb_BlackTurn = new System.Windows.Forms.RadioButton();
			this.gB_Turn = new System.Windows.Forms.GroupBox();
			this.rdb_GameOver = new System.Windows.Forms.RadioButton();
			this.rdb_WhiteTurn = new System.Windows.Forms.RadioButton();
			this.gB_Turn.SuspendLayout();
			this.SuspendLayout();
			// 
			// Button_Exit
			// 
			this.Button_Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.Button_Exit.Location = new System.Drawing.Point(711, 272);
			this.Button_Exit.Name = "Button_Exit";
			this.Button_Exit.Size = new System.Drawing.Size(127, 43);
			this.Button_Exit.TabIndex = 0;
			this.Button_Exit.Text = "Exit Game";
			this.Button_Exit.UseVisualStyleBackColor = true;
			this.Button_Exit.Click += new System.EventHandler(this.Button1Click);
			// 
			// rdb_BlackTurn
			// 
			this.rdb_BlackTurn.Location = new System.Drawing.Point(6, 19);
			this.rdb_BlackTurn.Name = "rdb_BlackTurn";
			this.rdb_BlackTurn.Size = new System.Drawing.Size(91, 37);
			this.rdb_BlackTurn.TabIndex = 1;
			this.rdb_BlackTurn.TabStop = true;
			this.rdb_BlackTurn.Text = "Black";
			this.rdb_BlackTurn.UseVisualStyleBackColor = true;
			this.rdb_BlackTurn.CheckedChanged += new System.EventHandler(this.Rdb_BlackTurnCheckedChanged);
			// 
			// gB_Turn
			// 
			this.gB_Turn.Controls.Add(this.rdb_GameOver);
			this.gB_Turn.Controls.Add(this.rdb_WhiteTurn);
			this.gB_Turn.Controls.Add(this.rdb_BlackTurn);
			this.gB_Turn.Location = new System.Drawing.Point(664, 45);
			this.gB_Turn.Name = "gB_Turn";
			this.gB_Turn.Size = new System.Drawing.Size(164, 93);
			this.gB_Turn.TabIndex = 2;
			this.gB_Turn.TabStop = false;
			this.gB_Turn.Text = "Whose Turn?";
			this.gB_Turn.Enter += new System.EventHandler(this.GroupBox1Enter);
			// 
			// rdb_GameOver
			// 
			this.rdb_GameOver.Cursor = System.Windows.Forms.Cursors.No;
			this.rdb_GameOver.Location = new System.Drawing.Point(70, 42);
			this.rdb_GameOver.Name = "rdb_GameOver";
			this.rdb_GameOver.Size = new System.Drawing.Size(88, 24);
			this.rdb_GameOver.TabIndex = 3;
			this.rdb_GameOver.TabStop = true;
			this.rdb_GameOver.Text = "Game Over";
			this.rdb_GameOver.UseVisualStyleBackColor = true;
			// 
			// rdb_WhiteTurn
			// 
			this.rdb_WhiteTurn.Location = new System.Drawing.Point(6, 62);
			this.rdb_WhiteTurn.Name = "rdb_WhiteTurn";
			this.rdb_WhiteTurn.Size = new System.Drawing.Size(104, 24);
			this.rdb_WhiteTurn.TabIndex = 2;
			this.rdb_WhiteTurn.TabStop = true;
			this.rdb_WhiteTurn.Text = "White";
			this.rdb_WhiteTurn.UseVisualStyleBackColor = true;
			// 
			// KalahaBoardDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(865, 327);
			this.Controls.Add(this.gB_Turn);
			this.Controls.Add(this.Button_Exit);
			this.Name = "KalahaBoardDisplay";
			this.Text = "Kalaha Board";
			this.Load += new System.EventHandler(this.KalahaBoardDisplayLoad);
			this.gB_Turn.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
