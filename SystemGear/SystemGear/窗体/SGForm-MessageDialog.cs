using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SystemGear
{
    public partial class Form_MessageDialog : Form
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
        public string clickret = "";
        public Color bordercolor;
        public string _mesagetype;
        public bool showinfo = false;
        public Form_MessageDialog(string messagetype)
        {
            InitializeComponent();
            this._mesagetype = messagetype;
        }

        private void Form_MessageDialog_Load(object sender, EventArgs e)
        {

        }

        private void Form_MessageDialog_Paint(object sender, PaintEventArgs e)
        {
            //left
            Pen p = new Pen(bordercolor, 2.0f);//设置笔的粗细为,颜色为蓝色
            Graphics g = e.Graphics;
            Point f, l;
            f = new Point(1, 1);
            l = new Point(0, this.Size.Height);
            g.DrawLine(p, f, l);
            //RIGHT
            Point rf, rl;
            rf = new Point(this.Width-1, 0);
            rl = new Point(this.Width-1, this.Height-1);
            Graphics g1 = e.Graphics;
            g1.DrawLine(p, rf, rl);
            //drawdown
            Point df, dl;
            df = new Point(0, this.Height-1);
            dl = new Point(this.Width, this.Height-1);
            Graphics g2 = e.Graphics;
            g2.DrawLine(p, df, dl);
        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Visible == false)
            {
                clickret = "B1";
            }
            else
            {
                if (checkBox1.Checked == true)
                {
                    clickret = "B3";
                }
                else
                {
                    clickret = "B1";
                }
            }
            this.Close();
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Visible == false)
            {
                clickret = "B2";
            }
            else
            {
                if (checkBox1.Checked == true)
                {
                    clickret = "B4";
                }
                else
                {
                    clickret = "B2";
                }
            }
            this.Close();
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Text == "" && label3.Text != "")
            {
                //有信息但没有复选框
                if (showinfo == false)
                {
                    this.Size = new Size(this.Size.Width, 20 + panel2.Location.Y + panel2.Size.Height);
                    showinfo = true;
                    MyNormalButton1.Text = "隐藏详细信息";
                    label3.Visible = true;
                    panel2.Visible = true;
                }
                else
                {
                    this.Size = new Size(this.Size.Width, this.MyNormalButton1.Location.Y + 20 + this.MyNormalButton1.Size.Height);
                    showinfo = false;
                    MyNormalButton1.Text = "显示详细信息";
                    label3.Visible = panel2.Visible = false;
                }
            }
            if (checkBox1.Text != "" && label3.Text != "")
            {
                //什么都有
                if (showinfo == false)
                {
                    this.Size = new Size(this.Size.Width, 20 + panel2.Location.Y + panel2.Size.Height);
                    showinfo = true;
                    MyNormalButton1.Text = "隐藏详细信息";
                    label3.Visible = true;
                    panel2.Visible = true;
                }
                else
                {
                    this.Size = new Size(this.Size.Width, this.checkBox1.Location.Y + 20 + this.checkBox1.Size.Height);
                    showinfo = false;
                    MyNormalButton1.Text = "显示详细信息";
                    label3.Visible = false;
                    panel2.Visible = false;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
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
        private void toclipbord()
        {
            try
            {
                //MessageBox.Show("");
                string msgtype = "";
                string getmsg = "";
                switch (_mesagetype.ToLower())
                {
                    case "info":
                        msgtype = "提示消息";
                        break;
                    case "error":
                        msgtype = "错误消息";
                        break;
                    case "ques":
                        msgtype = "询问消息";
                        break;
                    default:
                        msgtype = "提示消息";
                        break;
                }
                getmsg = @"消息的类型 : """ + msgtype + @"""" + "\r\n" + @"消息的标题 : """ + label1.Text + @"""" + "\r\n" + @"消息的内容 : """ + label2.Text + @"""" + "\r\n" + @"详细信息 : """ + label3.Text + @"""";
                Clipboard.SetData(DataFormats.UnicodeText, getmsg);//复制内
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("复制成功",1);
            }
            catch { SGFunction.CommonDialogs.MessageDialog_ShowInfo("复制失败", 1); }
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
           // MessageBox.Show("");
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toclipbord();
        }
    }
}
