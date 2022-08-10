using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Exps;

namespace Exps
{
    public partial class Form1 : Form
    {
        int genTime; 
        Random random = new Random((int)DateTime.Now.Ticks);
        public Form1()
        {
            InitializeComponent();
        }
        private string combinegens(string labelchar)
        {
            StringBuilder str = new StringBuilder();
            char c = ' ';
            for (int i = 0; i < genTime; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(Math.Floor(112 * random.NextDouble() + 0x300)));
                str.Append(c);
            }
            string actionchar = labelchar + str;
            return Convert.ToString(actionchar);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            genTime = Convert.ToInt32(numericUpDown1.Value);
            watermarkTextBox1.Text = combinegens(watermarkTextBox1.Text);
        }
    }
}
