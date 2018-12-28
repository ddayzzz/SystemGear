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
    public partial class Form_PublicSettingsDialog : Form
    {
        public string title;
        public Color forcolor;
        UserControl user;
        public Form_PublicSettingsDialog(string tit,Color forcolor,UserControl user)
        {
            InitializeComponent();
            this.title = tit;
            this.forcolor = forcolor;
            this.user = user;
        }

        private void Form_PublicSettingsDialog_Load(object sender, EventArgs e)
        {
            int control_w = user.Size.Width;
            int control_h = user.Size.Height;
            //this.Size= new Size(9+control_w ,control_h +78);
            this.Controls.Add(user);
            user.Location = new Point(9, 45);
            this.Text = label1.Text = title;
            label1.ForeColor = forcolor;
        }

        private void Form_PublicSettingsDialog_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.Dispose();
        }
    }
}
