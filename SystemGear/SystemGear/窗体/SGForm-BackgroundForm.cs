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
    public partial class SGForm_BackgroundForm : Form
    {
        bool _hasanim = true;
        /// <summary>
        /// 遮挡窗体的初始化
        /// </summary>
        /// <param name="backcolor">背景色</param>
        /// <param name="hasanim">是否有动画 如果为true 则opi始终为1</param>
        /// <param name="opi">透明度</param>
        public SGForm_BackgroundForm(Color backcolor,bool hasanim=false,double  opi=0.7)
        {
            InitializeComponent();
            this.BackColor = backcolor;
            this._hasanim = hasanim;
            this.Opacity = opi;
        }

        private void SGForm_BackgroundForm_Load(object sender, EventArgs e)
        {

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
            if (_hasanim == true) { AnimateWindow(this.Handle, 100, 0xA0000); } // 淡入淡出效果。}
            //AnimateWindow(this.Handle, 1000, 0x60004); // 自上向下。
            //AnimateWindow(this.Handle, 1000, 0x20004); // 自上向下。
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            //AnimateWindow(this.Handle, 1000, 0x10010);    // 居中逐渐隐藏。
           if (_hasanim ==true){ AnimateWindow(this.Handle, 100, 0x90000); }// 淡入淡出效果。
            //AnimateWindow(this.Handle, 1000, 0x50008); // 自下而上。
            //AnimateWindow(this.Handle, 1000, 0x10008); // 自下而上。
        }
    }
}
