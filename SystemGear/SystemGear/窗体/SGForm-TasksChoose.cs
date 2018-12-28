using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SystemGear.窗体
{
    public partial class SGForm_TasksChoose : Form
    {
        [DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        public string Returns = "";
        public string buttonclick = "exit";
        int sizeh = 50;
        public SGForm_TasksChoose(string title,string[] tasks,string ico)
        {
            InitializeComponent();
            //SKIN
            Color dialog_stand_bd = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "bd");
            Color dialog_stand_title_fr = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "title_fr");
            Color dialog_stand_title_bk = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "TITLE_BK");
            Color dialog_stand_bk = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "BK");
           // Color mainc = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
            Color mainpanel = SGFunction.Skins.Skins_GetControlColorSetting("SGTAB", "PC"); ; ;
            Color o_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "bk");
            Color o_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "fr");
            Color o1_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "bk");
            Color o1_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "fr");
            Color lab_ma_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_maininfo", "fr");
            Color lab_fu_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_funinfo", "fr");
            panel1.BackColor = dialog_stand_bd;
            MyNormalButton1.BackColor = dialog_stand_title_bk;
            this.BackColor = dialog_stand_bk;
            label_title.ForeColor = dialog_stand_title_fr;
            //load
            flowLayoutPanel1.Controls.Clear();
            this.Text = label_title.Text = title;
            bool isallico = true;
            string[] arr = ico.Split('|');
            Image r = null;
            if(arr !=null)
            {
                if (arr.Length == tasks.Length) { isallico = false; }
            }
            //图标选项
            if(isallico ==true)
            {
                r = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico);
            }
            for (int j = 1; j <= tasks.Length; j++)
            {
                MyNormalButton p = new MyNormalButton();
                p.BackColor = this.BackColor;
                p.Font = new System.Drawing.Font(this.Font.FontFamily, 10f,FontStyle.Bold);
                p.Size = new System.Drawing.Size(flowLayoutPanel1.Width - 5, 40);
                p.Text = "         "+tasks[j - 1];
                p.ForeColor = lab_ma_fr;
                p.ImageAlign =p.TextAlign = ContentAlignment.MiddleLeft;
                if(isallico ==false)
                {
                    r = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(arr[j - 1]);
                }
                p.Image = r;
                p.Tag = j.ToString();
                p.Click += new EventHandler(this.MyNormalButton1_OnButtonClick);
                //add
                flowLayoutPanel1.Controls.Add(p);
            }
        }

        private void SGForm_TasksChoose_Shown(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, this.flowLayoutPanel1.Location.Y + this.flowLayoutPanel1.Size.Height+5);
            this.panel1.Size = new Size(this.Size.Width, this.panel1.Size.Height);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SGFunction.CommonDialogs.SystemGearDialog_DrawBorder(e,this);
        }

        private void SGForm_TasksChoose_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }

        private void MyNormalButton1_MouseMove(object sender, MouseEventArgs e)
        {
            MyNormalButton1.BackColor = SGFunction.Skins.Skins_GetRoleColor("CLOSEBTN", "MOUSEMOVE");
        }

        private void MyNormalButton1_MouseLeave(object sender, EventArgs e)
        {
            MyNormalButton1.BackColor = SGFunction.Skins.Skins_GetRoleColor("CLOSEBTN","");
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MyNormalButton1_OnButtonClick(object sender, EventArgs e)
        {
            this.buttonclick = "ok";
            this.Returns = "t"+((MyNormalButton)sender).Tag.ToString();
            this.Close();
        }
    }
}
