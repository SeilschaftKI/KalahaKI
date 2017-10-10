using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kalaha
{
    public partial class KalahaBoardDisplay_STD : Form
    {
        public KalahaBoardDisplay_STD(int StartValue)
        {
            InitializeComponent();
            btnP1_1.Text = StartValue.ToString();
            btnP1_2.Text = StartValue.ToString();
            btnP1_3.Text = StartValue.ToString();
            btnP1_4.Text = StartValue.ToString();
            btnP1_5.Text = StartValue.ToString();
            btnP1_6.Text = StartValue.ToString();
            btnP2_1.Text = StartValue.ToString();
            btnP2_2.Text = StartValue.ToString();
            btnP2_3.Text = StartValue.ToString();
            btnP2_4.Text = StartValue.ToString();
            btnP2_5.Text = StartValue.ToString();
            btnP2_6.Text = StartValue.ToString();

            btnP1_Kalaha.Text = "0";
            btnP2_Kalaha.Text = "0";
        }

        public void Refresh(int[] Slots)
        {

        }

        private void btnP1_1_Click(object sender, EventArgs e)
        {

        }
    }
}
