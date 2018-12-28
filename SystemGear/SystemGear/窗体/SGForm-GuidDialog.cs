using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear.窗体
{
    public partial class SGForm_GuidDialog : Form
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        public object Returns="exit";
        UserControl uc;
        public SGForm_GuidDialog(string title,UserControl u)
        {
            InitializeComponent();
            uc = u;
            this.DrawSkin();
            //LOAD
            this.Controls.Add(u);
            u.Location = new Point(2, panel1.Size.Height);
            
            this.Text = label_title.Text = title;
            u.MouseDown += new MouseEventHandler(SGForm_GuidDialog_MouseDown);
        }
        private void SGForm_GuidDialog_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(uc.Size.Width + uc.Location.X + 2, uc.Location.Y + uc.Size.Height +2);
            this.panel1.Size = new Size(this.Size.Width, panel1.Size.Height);
        }

        private void SGForm_GuidDialog_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            this.Returns = "exit";
            this.Close();
        }

        private void MyNormalButton1_MouseMove(object sender, MouseEventArgs e)
        {
            MyNormalButton1.BackColor = Color.FromArgb(212, 64, 39);
        }

        private void MyNormalButton1_MouseLeave(object sender, EventArgs e)
        {
           MyNormalButton1.BackColor = Color.Transparent;
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(uc.Size.Width + uc.Location.X + 2, uc.Location.Y + uc.Size.Height + 2);
            MyNormalButton1.Location = new Point(panel1.Size.Width - MyNormalButton1.Size.Width, 0);
        }

        private void SGForm_GuidDialog_ControlRemoved(object sender, ControlEventArgs e)
        {
            
            object o = this.Tag;
            if(o==null)
            {
                this.Returns = "exit";
            }
            else
            {
                this.Returns = o.ToString();
            }
            this.Close();
        }

        private void SGForm_GuidDialog_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }
        public void DrawSkin()
        {
            //SKIN
            Color dialog_stand_bk = SGFunction.Skins.Skins_GetControlColorSetting("dialog_standard", "bk");
            Color dialog_stand_title_bk = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "TITLE_BK");
            Color dialog_stand_bd = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "bd");
            Color dialog_stand_title_fr = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "title_fr");
            MyNormalButton1.BackColor = dialog_stand_title_bk;
            panel1.BackColor = dialog_stand_title_bk;
            this.BackColor = dialog_stand_bd;
            label_title.ForeColor = dialog_stand_title_fr;
        }
    }
}
