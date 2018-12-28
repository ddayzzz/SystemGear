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
    public partial class Form_MessageDialog_Info : Form
    {
        private string _title;
        private int _count;
        private Point  _frm;
        public Form_MessageDialog_Info(string title,int count,Point  frm)
        {
            InitializeComponent();
            _title = title;
            _count = count;
            _frm = frm;
        }
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
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //left
            Pen p = new Pen(Color.FromArgb(0,148,255), 2.0f);//设置笔的粗细为,颜色为蓝色
            Graphics g = e.Graphics;
            Point f, l;
            f = new Point(0, 0);
            l = new Point(0, this.Size.Height);
            g.DrawLine(p, f, l);
            //drawrights
            Point rf, rl;
            rf = new Point(this.Width, 0);
            rl = new Point(this.Width, this.Height);
            Graphics g1 = e.Graphics;
            g1.DrawLine(p, rf, rl);
            //drawdown
            Point df, dl;
            df = new Point(0, this.Height);
            dl = new Point(this.Width, this.Height);
            Graphics g2 = e.Graphics;
            g2.DrawLine(p, df, dl);
            //drawtop
            Point dt, dtl;
            dt = new Point(0, 0);
            dtl = new Point(this.Width, 0);
            Graphics g3 = e.Graphics;
            g3.DrawLine(p, dt, dtl);
        }

        private void Form_MessageDialog_Info_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_MessageDialog_Info_Load(object sender, EventArgs e)
        {
            label1.Text = _title;
            label1.Location = new Point(2, 2);
            this.Size = new Size(label1.Width + 5, label1.Height + 5);
            this.Location = _frm;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
            
        }
    }
}
