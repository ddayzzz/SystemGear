using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SystemGear
{
    public partial class SGTextBox : TextBox 
    {
        public SGTextBox()
        {
            InitializeComponent();
        }

        #region 变量
        private string _tiptext = "";
        private Color _tipcolor = Color.FromArgb(185,185,185);
        private Color _borderColor = Color.FromArgb(7, 107, 43);   // 设置默认的边框颜色
        private static int WM_NCPAINT = 0x0085;    // WM_NCPAINT message
        private static int WM_ERASEBKGND = 0x0014; // WM_ERASEBKGND message
        private static int WM_PAINT = 0x000F;      // WM_PAINT message
        private bool _losefocus = true;
        private Color _losecolor = Color.FromArgb(185, 185, 185);
        private Color _errorcolor = Color.Red;
        private bool _drawerror = false;
        private string _errortext = "";
        #endregion
        #region 属性
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的提示文字")]
        public string TextBoxInfoTip
        {
            get
            {
                return _tiptext;
            }
            set
            {
                _tiptext = value;
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的提示文字的颜色")]
        public Color TextBoxInfoTipColor
        {
            get
            {
                return _tipcolor;
            }
            set
            {
                _tipcolor = value;
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的失去焦点的颜色")]
        public Color TextBoxLoseFocusColor
        {
            get
            {
                return _losecolor;
            }
            set
            {
                _losecolor = value;
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的边框颜色")]
        public Color TextBoxInfoBorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
               _borderColor  = value;
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的错误信息颜色")]
        public Color TextBoxErrorMessageColor
        {
            get
            {
                return _errorcolor;
            }
            set
            {
                _errorcolor  = value;
            }
        }
        #endregion
        #region 方法
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);
        //释放DC
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                PaintInfoTip(ref m);
            }
            //绘制边框
            if (m.Msg == 0xf)//|| m.Msg == 0x133)
            {
                //拦截系统消息，获得当前控件进程以便重绘。
                //一些控件（如TextBox、Button等）是由系统进程绘制，重载OnPaint方法将不起作用.
                //所有这里并没有使用重载OnPaint方法绘制TextBox边框。
                //
                //MSDN:重写 OnPaint 将禁止修改所有控件的外观。
                //那些由 Windows 完成其所有绘图的控件（例如 Textbox）从不调用它们的 OnPaint 方法，
                //因此将永远不会使用自定义代码。请参见您要修改的特定控件的文档，
                //查看 OnPaint 方法是否可用。如果某个控件未将 OnPaint 作为成员方法列出，
                //则您无法通过重写此方法改变其外观。
                //
                //MSDN:要了解可用的 Message.Msg、Message.LParam 和 Message.WParam 值，
                //请参考位于 MSDN Library 中的 Platform SDK 文档参考。可在 Platform SDK（“Core SDK”一节）
                //下载中包含的 windows.h 头文件中找到实际常数值，该文件也可在 MSDN 上找到。
                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0)
                {
                    return;
                }
                Color dc = _losecolor;
                if (_losefocus == false) { dc = _borderColor; }
                if (_drawerror == true) { dc = _errorcolor; _drawerror = false; }
                System.Drawing.Pen pen = new Pen(dc , 2);
                //绘制边框
                System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                System.Drawing.Graphics g2 = Graphics.FromHdc(hDC);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                System.Drawing.Pen pen_hideback = new Pen(this.BackColor, 1);
                g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawRectangle(pen_hideback, 0, 0, this.Width - 1, this.Height - 1);
                g2.DrawLine(pen, new Point(0,this.Height-2), new Point(this.Width,this.Height -2));
                pen.Dispose();
                pen_hideback.Dispose();
                //返回结果
                m.Result = IntPtr.Zero;
                //释放
                ReleaseDC(m.HWnd, hDC);
            }
        }
        protected override void OnLostFocus(EventArgs e)
        {
            this._losefocus = true;
            //重绘 
            this.Invalidate();
            base.OnLostFocus(e);
        }
        protected override void OnGotFocus(EventArgs e)
        {

            this._losefocus = false;
            //重绘 
            this.Invalidate();
            base.OnGotFocus(e);
        } 

        private void PaintInfoTip(ref Message m)
        {
            Color drawcolor = _tipcolor;
            string textd = _tiptext;
            if (_drawerror == true) { drawcolor = _errorcolor; textd = _errortext;}
            Rectangle rectangle = new Rectangle(0, 0, Width, Height);
            using (Graphics graphics = Graphics.FromHwnd(base.Handle))
            {
                if (Text.Length == 0
                   && !string.IsNullOrEmpty(_tiptext)
                   )
                {
                    TextFormatFlags format =
                         TextFormatFlags.EndEllipsis |
                         TextFormatFlags.VerticalCenter;

                    if (RightToLeft == RightToLeft.Yes)
                    {
                        format |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
                    }

                    TextRenderer.DrawText(
                        graphics,
                        textd ,
                        Font,
                        base.ClientRectangle,
                        drawcolor,
                          format);
                }
            }
             
        }
       /// <summary>
        /// 使文本框发注警告色 TIPTEXT必须要有值(必须有水印文字)
       /// </summary>
       /// <param name="errortext">错误信息</param>
        public void DoError(string errortext = "")
        {

            _drawerror = true;
            this._errortext = errortext;
            this.Invalidate();
            this.Focus();
        }

        #endregion

        private void SGTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void SGTextBox_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
