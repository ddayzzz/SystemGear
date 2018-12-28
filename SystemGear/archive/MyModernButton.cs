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
    public partial class MyModernButton : UserControl
    {
       
       public enum ButtonStyle { Normal, NormalWithLogo, NormalWithoutBackPage }
        #region 私有变量
        private string _buttontext = "";
        private string[] _tags;
        private Image  _buttonsmlogo = null;
        private Image   _buttonbackimage = null;
        private Color _buttonbackcolor = Color.FromArgb(18,132,3);
        private Color _buttonbackpagecolor = Color.FromArgb(0, 148, 255);
        private Color _buttonforcecolor = Color.White;
        private ButtonStyle _btnstyle=ButtonStyle.Normal;
        private EventHandler _OnButtonClick = null;
        private MouseEventHandler _OnButtonMouseDown = null;
        private Color _bm = Color.FromArgb(38, 152, 23);
        private Color _bpm = Color.FromArgb(20, 168, 235);
        #endregion
        #region 属性
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
            }
        }
        [Browsable(true), Category("ButtonSettings"), Description("设置按钮的标题"), DefaultValue(typeof(string), "")]
        public string ButtonText
        {
            get
            {
                return _buttontext;
            }
            set
            {
                _buttontext = value;
                label1.Text = value.ToString();
                label2.Text = value;
            }
        }
        [Browsable(true), Category("ButtonSettings"), Description("设置按钮的样式")]
        public ButtonStyle ButtonType
        {
            get
            {
                return _btnstyle;
            }
            set
            {
                _btnstyle = value;
                this.changesizemode(value);
            }
        }
         [Browsable(true), Category("ButtonSettings"), Description("设置按钮的小图标")]
        public Image  ButtonSmallLogo
        {
            get 
            {
                return _buttonsmlogo;
            }
            set
            {
                _buttonsmlogo = value;
                pictureBox1.Image = value;
            }
        }
         [Browsable(true), Category("ButtonSettings"), Description("设置按钮的背景图片")]
         public Image  ButtonBackImage
         {
             get
             {
                 return _buttonbackimage;
             }
             set
             {
                 _buttonbackimage = value;
                 this.BackgroundImage = value;
             }
         }
         [Browsable(true), Category("ButtonSettings"), Description("设置按钮的背景颜色"), DefaultValue(typeof(Color), "18,132,3")]
         public Color ButtonBackColor
         {
             get
             {
                 return _buttonbackcolor;
             }
             set
             {
                 _buttonbackcolor = value;
                 this.BackColor = value;
                 this._bm =this.setmovecolor(value, 10);
             }
         }
         [Browsable(true), Category("ButtonSettings"), Description("设置按钮的遮挡背景色"), DefaultValue(typeof(Color), "0,148,255")]
         public Color ButtonBackPageColor
         {
             get
             {
                 return _buttonbackpagecolor;
             }
             set
             {
                 _buttonbackpagecolor = value;
                 panel1.BackColor = value;
                 this._bpm = this.setmovecolor(value, 10);
             }
         }
         [Browsable(true), Category("ButtonSettings"), Description("设置按钮的文字颜色"), DefaultValue(typeof(Color), "255,255,255")]
         public Color ButtonForceColor
         {
             get
             {
                 return _buttonforcecolor;
             }
             set
             {
                _buttonforcecolor = value;
                label1.ForeColor = value;
             }
         }
        #endregion
        #region 方法
        private void changesizemode(ButtonStyle btnstye)
        {
            switch(btnstye)
            {
                case ButtonStyle.Normal:
                    panel1.Size = new Size(panel1.Size.Width, 37);
                    panel1.Visible = true;
                    pictureBox1.Visible =false;
                    label1.Dock = DockStyle.Fill;
                    label1.TextAlign = ContentAlignment.MiddleLeft;
                    label1.Text = _buttontext;
                    label2.Visible = false;
                    break;
                case ButtonStyle.NormalWithLogo:
                    panel1.Size = new Size(panel1.Size.Width, 37);
                    panel1.Visible = true;
                    label1.Text = "         " + _buttontext;
                    pictureBox1.Visible = true;
                    pictureBox1.Location = new Point(3, 2);
                    label2.Visible = false;
                    break;
                case ButtonStyle.NormalWithoutBackPage:
                    panel1.Visible = false;
                    label2.Visible = true;
                    label2.ForeColor = _buttonforcecolor;
                    label2.Text = _buttontext;
                    label2.Dock = DockStyle.Bottom;
                    label2.TextAlign = ContentAlignment.MiddleLeft;
                    label2.BackColor = Color.Transparent;
                    break;
            }
        }
        #endregion
        #region 事件
        [EditorBrowsable(EditorBrowsableState.Always), Description("当鼠标点击按钮时触发")]
        [Browsable(true)]
        public event MouseEventHandler OnButtonMouseDown
        {
            add { _OnButtonMouseDown  += new MouseEventHandler(value); }
            remove { _OnButtonMouseDown  -= new MouseEventHandler(value); }
        }
        [EditorBrowsable(EditorBrowsableState.Always), Description("当鼠标左键点击时触发")]
        [Browsable(true)]
        public event EventHandler OnButtonClick
        {
            add { _OnButtonClick += new EventHandler(value); }
            remove { _OnButtonClick-= new EventHandler(value); }
        }
        private void lblCaption_Click(object sender, MouseEventArgs e)
        {
            //转移Click事件, 触发用户自定义事件 
            if (_OnButtonClick != null || _OnButtonMouseDown !=null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (_OnButtonClick != null) _OnButtonClick(this, e);
                }
                if (_OnButtonMouseDown != null) { _OnButtonMouseDown(this, e); }
            }
        }
        #endregion
        #region 按钮淡入淡出动画
        #endregion
        public MyModernButton()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |

                    ControlStyles.ResizeRedraw |

                    ControlStyles.AllPaintingInWmPaint, true);
        }
        private void MyModernButton_Load(object sender, EventArgs e)
        {
        }

        private void MyModernButton_SizeChanged(object sender, EventArgs e)
        {

        }

        private void MyModernButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = _bm;
            this.panel1.BackColor = _bpm;
        }

        private void MyModernButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = _buttonbackcolor;
            this.panel1.BackColor = _buttonbackpagecolor;
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
    }
}
