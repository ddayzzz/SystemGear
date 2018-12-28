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
    public partial class Form_TasksChooseDialog : Form
    {
        public string ChooseTask;
        public Form_TasksChooseDialog()
        {
            InitializeComponent();
        }

        private void Form_TasksChooseDialog_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            this.ChooseTask = b.Tag.ToString().ToUpper();
            this.Close();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void Form_TasksChooseDialog_Resize(object sender, EventArgs e)
        {
            
        }

        private void Form_TasksChooseDialog_Shown(object sender, EventArgs e)
        {
            System.Drawing.Size org = this.Size;
            this.AutoSize = false;
            this.Size = org;
            this.panel1.Size =new Size(org.Width, panel1.Size.Height);
        }
    }
}
