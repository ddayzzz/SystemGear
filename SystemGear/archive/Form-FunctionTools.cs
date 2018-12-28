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
    public partial class Form_FunctionTools : Form
    {
        public UserControl user;
        public string title, ret;
        public Form_FunctionTools(string a,UserControl u)
        {
            InitializeComponent();
            title = a;
            user = u;
        }

        private void Form_FunctionTools_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (this.Tag != null)
            {
                try
                {
                    ret = this.Tag.ToString();
                    this.Close();
                }
                catch { ret = ""; }
            }
        }

        private void Form_FunctionTools_Load(object sender, EventArgs e)
        {
            this.Controls.Add(user);
            user.Location = new Point(13, panel1.Size.Height);
        }

        private void Form_FunctionTools_Shown(object sender, EventArgs e)
        {
            int ox = this.Size.Width;
            int oy = this.Size.Height;
            this.AutoSize = false;
            this.Size = new System.Drawing.Size(ox, oy);
            panel1.Size = new Size(this.Size.Width+10, 55);
        }
    }
}
