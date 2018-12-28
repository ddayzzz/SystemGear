using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace SystemGear
{
    public partial class Form_MessageDialog_2 : Form
    {
        [DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果
        public Form_MessageDialog_2()
        {
            InitializeComponent();
        }
        public string ChooseButton;
        public string ErrorInfo;
        public string defaultbt;
        public bool IsExpand;
        public int FormX, FormY;
        public System.Drawing.Point FormLocation;
        public int orgx;
        public int orgy;
        private void button2_Click(object sender, EventArgs e)
        {
            ChooseButton = "B2";
            this.Close();
        }

        private void Form_MessageDialog_2_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(this.AcceptButton.ToString());
            IsExpand = false;
            FormX = this.Size.Width;
            FormY = this.Size.Height;
            myNormalButton3.Visible = true;
            if (ErrorInfo == "")
            {
                myNormalButton3.Visible = false;
            }
            switch (defaultbt.ToUpper())
            {
                case "B1":
                    myNormalButton1.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
                    myNormalButton1.ButtonForceColor = Color.White;
                    myNormalButton2.ButtonBackColor = Color.FromArgb(185, 185, 185);
                    myNormalButton2.ButtonForceColor = Color.Black;
                    break;
                case "B2":
                    myNormalButton2.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
                    myNormalButton2.ButtonForceColor = Color.White;
                    myNormalButton1.ButtonBackColor = Color.FromArgb(185, 185, 185);
                    myNormalButton1.ButtonForceColor = Color.Black;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseButton = "B1";
            this.Close();
        }

        private void Form_MessageDialog_2_Shown(object sender, EventArgs e)
        {
            
            
            
        }

        private void myNormalButton3_OnButtonClick(object sender, EventArgs e)
        {
            myTextBox1.TextBoxText = ErrorInfo;
            if(myNormalButton3.ButtonText =="显示详细信息")
            {
                this.panel2.Visible = true;
                this.Size = new Size(699, 330);
                myNormalButton3.ButtonText = "隐藏详细信息";
            }
            else
            {
                this.panel2.Visible = false;
                this.Size = new Size(699, 171);
                myNormalButton3.ButtonText = "显示详细信息";
            }
        }

        private void Form_MessageDialog_2_Paint(object sender, PaintEventArgs e)
        {
            //left
            Pen p = new Pen(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetBorderColor(), 2.0f);//设置笔的粗细为,颜色为蓝色
            Graphics g = e.Graphics;
            Point f, l;
            f = new Point(0, 0);
            l = new Point(0, this.Size.Height);
            g.DrawLine(p, f, l);
            //label1.Location = new Point(label1.Location.X, this.label1.Location.Y + 2);
            //this.button7.Location = new Point(this.button7.Location.X, this.button7.Location.Y + 3+1);
            //this.button6.Location = new Point(this.button6.Location.X, this.button6.Location.Y + 3+1);
            //this.button11.Location = new Point(this.button11.Location.X, this.button11.Location.Y + 3+1);
            //drawrights
            Point rf, rl;
            rf = new Point(this.Width, 0);
            rl = new Point(this.Width, this.Height);
            Pen p1 = new Pen(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(), 2.0f);//设置笔的粗细为,颜色为蓝色
            Graphics g1 = e.Graphics;
            g1.DrawLine(p1, rf, rl);
            //drawdown
            Point df, dl;
            df = new Point(0, this.Height);
            dl = new Point(this.Width, this.Height);
            Pen p2 = new Pen(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(), 2.0f);//设置笔的粗细为,颜色为蓝色
            Graphics g2 = e.Graphics;
            g2.DrawLine(p2, df, dl);
        }
        

        private void Form_MessageDialog_2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //AnimateWindow(this.Handle, 1000, 0x20010);   // 居中逐渐显示。
            AnimateWindow(this.Handle, 110, 0xA0000); // 淡入淡出效果。
            //AnimateWindow(this.Handle, 1000, 0x60004); // 自上向下。
            //AnimateWindow(this.Handle, 1000, 0x20004); // 自上向下。
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            //AnimateWindow(this.Handle, 1000, 0x10010);    // 居中逐渐隐藏。
            AnimateWindow(this.Handle, 110, 0x90000); // 淡入淡出效果。
            //AnimateWindow(this.Handle, 1000, 0x50008); // 自下而上。
            //AnimateWindow(this.Handle, 1000, 0x10008); // 自下而上。
        }
    }
}
