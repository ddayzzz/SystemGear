using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear
{
    public partial class Form_SpecialDialog : Form
    {
        public Form_SpecialDialog()
        {
            InitializeComponent();
        }

        private void Form_SpecialDialog_2_Load(object sender, EventArgs e)
        {
        }

        private void Form_SpecialDialog_2_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.Close();
        }

        private void Form_SpecialDialog_Shown(object sender, EventArgs e)
        {
            Size loc = this.Size;
            this.AutoSize = false;
            this.Size = loc;
            this.panel1.Width = loc.Width;
        }

        private void Form_SpecialDialog_Resize(object sender, EventArgs e)
        {
        }
    }
}
