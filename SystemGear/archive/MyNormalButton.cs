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
    [DefaultEvent("OnButtonClick")]
    public partial class MyNormalButton : UserControl
    {
         
        #region 私有变量
        private EventHandler _OnButtonClick = null;
        private string _text = "Text";
        private Color _forcecolor = Color.White;
        private Font _fonts = new Font("微软雅黑", 9f,FontStyle.Bold);
        private Color _backcolor = Color.FromArgb(0, 148, 255);
        private System.Drawing.Image  _img = null;
        private Color _mousemove = Color.FromArgb(20, 168, 235);
        private int  _bordersize = 0;
        private Color _bordercolor = Color.White;
        private bool _usingsgdefaultstyle = false;
        private string[] _tags;
        //private Color _bordercolor = Color.FromArgb(0, 148, 255);
        //private int _bordersize = 0;
        #endregion
        #region 属性
        [Browsable(true), Category("ButtonSettings"), Description("设置按钮的标题"), DefaultValue(typeof(string), "Text")]
        public string ButtonText
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                label1.Text = value;
                this.setsgdefaultstyle(_usingsgdefaultstyle );
            }
        }
        [Browsable(true), Category("ButtonSettings"), Description("设置按钮标题的颜色"), DefaultValue(typeof(Color), "255,255,255")]
        public Color ButtonForceColor
        {
            get
            {
                return _forcecolor;
            }
            set
            {
                _forcecolor = value;
                label1.ForeColor = value;
                this.setsgdefaultstyle(_usingsgdefaultstyle);
            }
        }
        [Browsable(true), Category("ButtonSettings"), Description("设置按钮是否使用系统齿轮的默认方案"), DefaultValue(typeof(bool), "false")]
        public bool ButtonUsingSGDefaultStyle
        {
            get
            {
                return _usingsgdefaultstyle;
            }
            set
            {
                _usingsgdefaultstyle = value;
                this.setsgdefaultstyle(value);
            }
        }
        [Browsable(true), Category("ButtonSettings"), Description("设置按钮的边框大小"), DefaultValue(typeof(int), "0")]
        public int  ButtonBorderSize
        {
            get
            {
                return _bordersize;
            }
            set
            {
                _bordersize  = value;
                this.setsgdefaultstyle(_usingsgdefaultstyle);
                this.Refresh();
            }
        }
        [Browsable(true), Category("ButtonSettings"), Description("设置按钮的边框的颜色"), DefaultValue(typeof(Color ), "255,255,255")]
        public Color ButtonBorderColor
        {
            get
            {
                return _bordercolor;
            }
            set
            {
                _bordercolor = value;
                this.setsgdefaultstyle(_usingsgdefaultstyle);
                this.Refresh();
            }
        }
        [Browsable(true), Category("ButtonSettings"), Description("设置按钮标题字体样式"), DefaultValue(typeof(Font), "微软雅黑, 9pt, style=Bold")]
        public Font ButtonFontStyle
        {
            get
            {
                return _fonts;
            }
            set
            {
                _fonts = value;
                label1.Font = value;
                this.setsgdefaultstyle(_usingsgdefaultstyle);
                
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置按钮的临时数据")]
        public string[] ButtonTags
        {
            get
            {
                return _tags;
            }
            set
            {
                _tags = value;
                this.setsgdefaultstyle(_usingsgdefaultstyle);
            }
        }
        [Browsable(true), Category("ButtonSettings"), Description("设置按钮标的背景图片")]
        public Image ButtonBackImage
        {
            get
            {
                return _img;
            }
            set
            {
                _img = value;
                label1.Image = value;
                label1.ImageAlign = ContentAlignment.MiddleLeft;
                this.setsgdefaultstyle(_usingsgdefaultstyle);
            }
        }
        [Browsable(true), Category("ButtonSettings"), Description("设置按钮的背景颜色"), DefaultValue(typeof(Color), "0,148,255")]
        public Color ButtonBackColor
        {
            get
            {
                return _backcolor;
            }
            set
            {
                _backcolor = value;
                this.BackColor = value;
                this._mousemove = this.setmovecolor(value, 20);
                this.setsgdefaultstyle(_usingsgdefaultstyle);
            }
        }
        #endregion
        #region 事件
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public event EventHandler OnButtonClick
        {
            add { _OnButtonClick += new EventHandler(value); }
            remove { _OnButtonClick -= new EventHandler(value); }
        }

        private void lblCaption_Click(object sender, MouseEventArgs e)
        {
            //转移Click事件, 触发用户自定义事件 
            if (_OnButtonClick != null )
            {
                if (e.Button == MouseButtons.Left)
                {
                    _OnButtonClick(this,e);
                }
                else
                {
                }
            }
            else
            {

            }
        }

        #endregion

        public MyNormalButton()
        {
            InitializeComponent();
            //MessageBox.Show(_bordersize.ToString());
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |

                    ControlStyles.ResizeRedraw |

                    ControlStyles.AllPaintingInWmPaint, true);
        }
        private  Color setmovecolor(Color orgcolor,int str)
        {
            int nr;
            if (orgcolor.R <= 255 - str) { nr = orgcolor.R + str; } else { nr = orgcolor.R - str; }
            int nG;
            if (orgcolor.G <= 255 - str) { nG = orgcolor.G + str; } else { nG = orgcolor.G - str; }
            int nB;
            if (orgcolor.B <= 255 - str) { nB = orgcolor.B + str; } else { nB = orgcolor.B - str; }
            return Color.FromArgb(nr, nG, nB);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = _mousemove;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = _backcolor;
        }
        private void setsgdefaultstyle(bool set)
        {
            if(set==true)
            {
                _backcolor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
                _forcecolor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetForceColor();
                _mousemove = this.setmovecolor(_backcolor, 20);
                this.BackColor = _backcolor;
                this.label1.ForeColor = _forcecolor;
            }
        }
        private void MyNormalButton_Paint(object sender, PaintEventArgs e)
        {
            if (_bordersize > 0)
            {
                Graphics gra = e.Graphics;
                Pen myPen = new Pen(_bordercolor, _bordersize);
                gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gra.DrawRectangle(myPen,0, 0, this.Size.Width -1 , this.Size.Height-1);
                myPen.Dispose();
            }
        }

        private void MyNormalButton_ForeColorChanged(object sender, EventArgs e)
        {
            _forcecolor = this.ForeColor;
            label1.ForeColor = this.ForeColor;
        }

        private void label1_BackColorChanged(object sender, EventArgs e)
        {
        }
    }
}
