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
        int labelShowTime;
        bool isShowClipChar;
        private string FormName = "CharPanel";
        Random random = new Random((int)DateTime.Now.Ticks);
        public Form1()
        {
            InitializeComponent();
        }
        public int[] charDB = new int[16*7];
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
        public void initChars()
        {
            const int STARTX = 3;
            const int STARTY = 3;
            var x = 0;
            var y = 0;
            var time = 0;
            for (int a = 0; a < 7; a++)
            {
                y = a * 29;
                for (int b = 0; b < 16; b++)
                {
                    x = b * 47;
                    time++;
                    Button button = new Button
                    {
                        Name = FormName + Convert.ToString(time),
                        Location = new Point(STARTX + x, STARTY + y),
                        Size = new Size(43, 23),
                        Tag = time + 0x2ff,
                        Text = " "+Convert.ToString(Convert.ToChar(time + 0x2ff))
                    };
                    button.MouseDown += new MouseEventHandler(qwq_Click);
                    panel1.Controls.Add(button);
                    panel1.Size = new Size(STARTX * 2 + x+47, STARTY * 2 + y+29);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(325, 153);
            initChars();
        }
        private void qwq_Click(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            if (e.Button == MouseButtons.Left)
            {
                labelShowTime = 60;
                Clipboard.SetText(Convert.ToString(Convert.ToChar(btn.Tag)));
            }
            else if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(" " + Convert.ToString(Convert.ToChar(btn.Tag)) + "\n" + "ID: " + Convert.ToString(btn.Tag) + "\n" + "Unicode ID: " + "0x" + Convert.ToInt32(btn.Tag).ToString("X"));
            }
        }
        private void ClipboardChar(int a)
        {
            Clipboard.SetDataObject(Convert.ToString(a), true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (isShowClipChar == false)
            {
                btn.Text = "隐藏字符集";
                isShowClipChar = true;
                this.Size = new Size(787, 375);
                watermarkTextBox1.Size = new Size(757, 23);
            }
            else
            {
                btn.Text = "显示字符集";
                isShowClipChar = false;
                this.Size = new Size(325, 153);
                watermarkTextBox1.Size = new Size(297, 23);
            }
            panel1.Enabled = isShowClipChar;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (labelShowTime <= 0)
            {
                label5.Visible = false;
            }
            else
            {
                labelShowTime--;
                label5.Visible = true;
            }
        }
    }
}
