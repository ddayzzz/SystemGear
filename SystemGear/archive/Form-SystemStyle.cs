using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using Microsoft;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Threading;
using System.Security.Principal;
namespace SystemGear
{
    public partial class Form_SystemStyle : Form
    {
        public Form_SystemStyle()
        {
            InitializeComponent();
        }
        public string chooseuser="";
        [DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
                this.Dispose();
                string[] str=new string[1];
                str[0]="-B";
                Form_Main frm=new Form_Main(str);
                frm.Show();
            
        }
        public void Form_SystemStyle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }
        public  void button1_Click1(object sender, EventArgs e)
        {
            Class_SystemStyle.SystemStyle_Enter(1, 1, 1, this);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Class_SystemStyle.SystemStyle_Enter(2,2, 1, this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class_SystemStyle.SystemStyle_Enter(3,3, 1, this);
        }

        private void Form_SystemStyle_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            System.Environment.Exit(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.Image = Properties.Resources.CloseButton_MouseMove;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Image = Properties.Resources.CloseButton_Normal;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            switch (this.chooseuser.ToUpper())
            {
                case "SYSVIE":
                    int x=button7.Location.X +this.Location.X;
                    int y=button7.Location.Y +this.Location.Y;
                    Point xy=new Point(x,y);
                   MyFunctions.Dialogs.PingProgram(UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine,UserControl_SystemStyle_SystemView.ChooseFunction_Name,UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo,UserControl_SystemStyle_SystemView.ChooseFunction_Info,UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico,xy);
                    break;
            }
        }

        private void Form_SystemStyle_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(), 2.0f);//设置笔的粗细为,颜色为蓝色
            Graphics g = this.CreateGraphics();
            Point f, l;
            f = new Point(0 , 0);
            l = new Point(this.Size.Width, 0);
            g.DrawLine(p, f, l);
            //drawrights
            Point rf, rl;
            rf = new Point(this.Width, 0);
            rl = new Point(this.Width, this.Height);
            Pen p1 = new Pen(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(), 2.0f);//设置笔的粗细为,颜色为蓝色
            Graphics g1 = this.CreateGraphics();
            g1.DrawLine(p1, rf, rl);
            //drawdown
            Point df, dl;
            df = new Point(0, this.Height);
            dl = new Point(this.Width, this.Height);
            Pen p2 = new Pen(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(), 2.0f);//设置笔的粗细为,颜色为蓝色
            Graphics g2 = this.CreateGraphics();
            g2.DrawLine(p2, df, dl);
        }
    }
}
