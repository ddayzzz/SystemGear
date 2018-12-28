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
[DefaultEvent("OnCheckedChange")]
    public partial class SGChooseBox : UserControl
    {
        
        public class MyEventArgs : EventArgs
        {
            /// <summary>
            /// 返回点击后的Index值 [1] [2]
             /// </summary>
            public int CheckedValue { get; set; }
        }
        // 自定义事件类型
        public delegate void MyEventHandler(object sender, MyEventArgs e);
        private event MyEventHandler _OnCheckedChange = null;
        #region vars
        private string _text1 = "";
        private string _text2 = "";
        private Color _text1_backcolor = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "bk_c1");
        private Color _text1_forcecolor = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "fr_c1");
        private Color _text2_backcolor = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "bk_c2");
        private Color _text2_forcecolor = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "fr_c2");
        private Color _mm1 = Color.FromArgb(20, 168, 235);
        private Color _mm2 = Color.FromArgb(225, 225, 225);
        private Color _backcolor=Color.Transparent;
        private int _choose = 1;
        private Image _pic1 = null, _pic2 = null;
        private int _sizew = 0;
        #endregion
        #region event
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public event MyEventHandler OnCheckedChange
        {
            add { _OnCheckedChange  += new MyEventHandler(value); }
            remove { _OnCheckedChange  -= new MyEventHandler(value); }
        }
        [Browsable(true), Category("MyChooseSettings"), Description("设置选项一的比平均大小多出多少")]
        public int MyChooseChoose1Text_LargeSize
        {
            get
            {
                return _sizew;
            }
            set
            {
                _sizew= value;
                //MyNormalButton1.Text = value;
            }
        }
        [Browsable(true), Category("MyChooseSettings"), Description("设置选项2的显示文字")]
        public string MyChooseChoose2Text
        {
            get
            {
                return _text1;
            }
            set
            {
                _text1 = value;
                MyNormalButton2.Text = value;
            }
        }
        [Browsable(true), Category("MyChooseSettings"), Description("设置选项控件的背景色")]
        public Color MyChooseBackColor
        {
            get
            {
                return _backcolor;
            }
            set
            {
                _backcolor = value;
                this.BackColor = value;
            }
        }
        [Browsable(true), Category("MyChooseSettings"), Description("设置选项2的背景图片")]
        public Image MyChooseChoose2Image
        {
            get
            {
                return _pic1;
            }
            set
            {
                _pic1 = value;
                MyNormalButton2.Image = value;
            }
        }
        [Browsable(true), Category("MyChooseSettings"), Description("设置选项1的背景图片")]
        public Image MyChooseChoose1Image
        {
            get
            {
                return _pic2;
            }
            set
            {
                _pic2 = value;
                MyNormalButton1.Image = value;
            }
        }
        [Browsable(true), Category("MyChooseSettings"), Description("设置选项1的显示文字")]
        public string MyChooseChoose1Text
        {
            get
            {
                return _text2;
            }
            set
            {
                _text2 = value;
                MyNormalButton1.Text = value;
            }
        }

        [Browsable(true), Category("MyChooseSettings"), Description("设置选项2的背景颜色")]
        public Color MyChooseChoose2BackColor
        {
            get
            {
                return _text1_backcolor;
            }
            set
            {
                _text1_backcolor = value;
                MyNormalButton2.BackColor = value;
            }
        }
        [Browsable(true), Category("MyChooseSettings"), Description("设置选项1的背景颜色")]
        public Color MyChooseChoose1BackColor
        {
            get
            {
                return _text2_backcolor;
            }
            set
            {
                _text2_backcolor = value;
                MyNormalButton1.BackColor = value;
            }
        }
        [Browsable(true), Category("MyChooseSettings"), Description("设置选项2的字体颜色")]
        public Color MyChooseChoose2ForceColor
        {
            get
            {
                return _text1_forcecolor;
            }
            set
            {
                _text1_forcecolor = value;
                MyNormalButton2.ForeColor = value;
            }
        }
        [Browsable(true), Category("MyChooseSettings"), Description("设置选项1的字体颜色")]
        public Color MyChooseChoose1ForceColor
        {
            get
            {
                return _text2_forcecolor;
            }
            set
            {
                _text2_forcecolor = value;
                MyNormalButton1.ForeColor = value;
            }
        }
        [Browsable(true), Category("MyChooseSettings"), Description("设置被选中的Index [1]选项一 [2]选项二")]
        public int MyChooseChooseChecked
        {
            get
            {
                return _choose;
            }
            set
            {
                _choose = value;
                //MessageBox.Show(value.ToString());
                if(value ==2)
                {
                    MyNormalButton2.Visible = true;
                    MyNormalButton1.Visible = false;
                }
                else
                {
                    MyNormalButton1.Visible = true;
                    MyNormalButton2.Visible = false;
                }
            }
        }
        #endregion
        public SGChooseBox()
        {
            InitializeComponent();
           // MyNormalButton1.Visible = true;
            //MyNormalButton2.Visible = false;
        }
        private Color setmovecolor(Color orgcolor, int str)
        {
            int nr;
            if (orgcolor.R <= 255 - str) { nr = orgcolor.R + str; } else { nr = orgcolor.R - str; }
            int nG;
            if (orgcolor.G <= 255 - str) { nG = orgcolor.G + str; } else { nG = orgcolor.G - str; }
            int nB;
            if (orgcolor.B <= 255 - str) { nB = orgcolor.B + str; } else { nB = orgcolor.B - str; }
            return Color.FromArgb(nr, nG, nB);
        }
        private void MyNormalButton1_MouseClick(object sender, EventArgs e)
        {
           // MessageBox.Show(_choose.ToString());
            if (_choose == 2)
            {
                MyNormalButton2.Visible = false;
                MyNormalButton1.Visible = true;
                _choose = 1;
            }
            else
            {
                MyNormalButton1.Visible = false;
                MyNormalButton2.Visible = true;
                _choose = 2;
            }
            if(_OnCheckedChange !=null)
            {
                MyEventArgs ce = new MyEventArgs();
                ce.CheckedValue = _choose;
                //MYEvent(this, ce);
                _OnCheckedChange(this, ce);
            }
        }


        private void MyNormalButton1_MouseMove(object sender, MouseEventArgs e)
        {
            if(_choose ==1)
            {
                MyNormalButton2.BackColor = _mm1;
            }
            else
            {
                MyNormalButton1.BackColor = _mm2;
            }
        }

        private void MyNormalButton1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void MyChooseBox_SizeChanged(object sender, EventArgs e)
        {
            //this.MyNormalButton1.Size = MyNormalButton2.Size = new Size(this.Width / 2, this.Height);
            //MyNormalButton1.Size = new System.Drawing.Size(MyNormalButton1.Size.Width + _sizew, MyNormalButton1.Size.Height);
            //MyNormalButton2.Location = new Point(MyNormalButton1.Size.Width, 0);
            int p = this.Size.Width / 3;
            MyNormalButton2.Size = MyNormalButton1.Size = new Size(p, MyNormalButton1.Size.Height);
            MyNormalButton1.Location = new Point(0, 0);
            MyNormalButton2.Location = new Point(p * 2, 0);
        }

        private void SGChooseBox_FontChanged(object sender, EventArgs e)
        {
            MyNormalButton2.Font = MyNormalButton1.Font = this.Font;
        }
    }
}
