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
	partial class KalahaBoardDisplaySTD
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(94, 68);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(52, 33);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(204, 68);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(58, 33);
			this.button2.TabIndex = 2;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(329, 68);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(60, 33);
			this.button3.TabIndex = 3;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(420, 160);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(57, 52);
			this.button4.TabIndex = 4;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(329, 171);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(60, 31);
			this.button5.TabIndex = 5;
			this.button5.Text = "button5";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(204, 171);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(58, 31);
			this.button6.TabIndex = 6;
			this.button6.Text = "button6";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(94, 171);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(52, 31);
			this.button7.TabIndex = 7;
			this.button7.Text = "button7";
			this.button7.UseVisualStyleBackColor = true;
			
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(12, 68);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(54, 52);
			this.button8.TabIndex = 8;
			this.button8.Text = "button8";
			this.button8.UseVisualStyleBackColor = true;
			// 
			// KalahaBoardDisplaySTD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(830, 327);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "KalahaBoardDisplaySTD";
			this.Text = "KalahaBoardDisplaySTD";
			this.Controls.SetChildIndex(this.Button_Exit, 0);
			this.Controls.SetChildIndex(this.button1, 0);
			this.Controls.SetChildIndex(this.button2, 0);
			this.Controls.SetChildIndex(this.button3, 0);
			this.Controls.SetChildIndex(this.button4, 0);
			this.Controls.SetChildIndex(this.button5, 0);
			this.Controls.SetChildIndex(this.button6, 0);
			this.Controls.SetChildIndex(this.button7, 0);
			this.Controls.SetChildIndex(this.button8, 0);
			this.ResumeLayout(false);

		}
	}
}
