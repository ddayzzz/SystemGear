using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear
{
    public partial class SGLabel : Label
    {
        //private bool _hasvar = false;
        //private string _orgtext = "";
        //private bool _finishpaint = false;
        private string _role = "";
        public SGLabel()
        {
            InitializeComponent();
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置标签的角色信息")]
        public string Setting_Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role  = value;
            }
        }
        private void SGLabel_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SGLabel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
