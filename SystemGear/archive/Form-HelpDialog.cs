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
    public partial class Form_HelpDialog : Form
    {
        public Form_HelpDialog()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form_HelpDialog_Load(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
        }
    }
}
