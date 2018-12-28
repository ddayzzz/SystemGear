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
    public partial class MyNormalButton : Button
    {
        private string[] _tags = null;
        private string code = "OTHER";
        public MyNormalButton()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.Selectable, false);
            this.TabStop = false;
        }
        [Browsable(true), Category("Settings"), Description("设置按钮控件的多组自定义数据")]
        public string[] Settings_Tags
        {
            get
            {
                return _tags;
            }
            set
            {
                _tags = value;
            }
        }
        [Browsable(true), Category("Settings"), Description("设置按钮控件的在UI中扮演的角色 [OTHER]默认按钮 [OTHER1] 次级按钮"),DefaultValue(typeof(string), "OTHER")]
        public string Settings_Role
        {
            get
            {
                return code;
            }
            set
            {
                code= value;
               // ChangeRole(value);
            }
        }

        private void MyNormalButton_MouseMove(object sender, MouseEventArgs e)
        {
            switch(code.ToUpper())
            {
                case "CLOSEBTN":
                    this.BackColor = SGFunction.Skins.Skins_GetRoleColor(code, "MOUSEMOVE");
                    break;
            }
        }

        private void MyNormalButton_MouseLeave(object sender, EventArgs e)
        {
            switch (code.ToUpper())
            {
                case "CLOSEBTN":
                    this.BackColor = SGFunction.Skins.Skins_GetRoleColor(code);
                    break;
            }
        }
    }
}
