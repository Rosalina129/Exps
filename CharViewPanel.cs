using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exps
{
    public partial class CharViewPanel : UserControl
    {
        public CharViewPanel()
        {
            InitializeComponent();
        }
        private int charID;
        public int CharID {
            get => charID;
            set
            {
                charID = value;
                char a = getCharID(charID);
                charidbutton.Text = Convert.ToString(a);
                label1.Text = "0x" + charID.ToString("X");
            } 
        }
        public char getCharID(int charID)
        {
            return Convert.ToChar(charID);
        }
    }
}
