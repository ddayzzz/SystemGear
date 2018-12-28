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
     [DefaultEvent("OnTextChange")]
    public partial class MyTextBox : UserControl
    {
        #region vars
         public class MYEventArgs : EventArgs
         {
             public String TextData { get ; set; }
         }
         // 自定义事件类型
         public delegate void MYEventHandler(object sender, MYEventArgs ce);
         // 事件
         //public event MYEventHandler MYEvent;
        private event MYEventHandler  _OnTextChange = null;
        private bool DrawMouseMoveColor = false ;
        private bool _MultiLine =false;
        private Size _orgsize;
        private string _text = "";
        private Color _nochoosecolor = Color.FromArgb(195, 195, 195);
        private Color _mmcolor = Color.FromArgb(0, 148, 255);
        private Font _fonts = new Font("微软雅黑", 9f, FontStyle.Bold);
        private bool _readonly = false;
        private Char _password;
        private string _printtext = "";
        private Color _forcecolor = Color.FromArgb(0, 148, 255);
        private Color _printcolor = Color.FromArgb(195,195,195);
        private bool _usingsgdefaultstyle = true;
        private bool _allowdrop = true;
        private string[] _tags;
        private int _count = 0;
        #endregion
        #region shuxing
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public event MYEventHandler  OnTextChange
        {
            add { _OnTextChange += new MYEventHandler  (value); }
            remove { _OnTextChange -= new MYEventHandler  (value); }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的文字")]
        public string TextBoxText
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                this.textBox1.Text  = value;
                if(_MultiLine ==true)
                {
                    this.textBox1.Location = new Point(5, 5);
                    this.textBox1.Size = new Size(this.Size.Width  - 10, this.Size.Height  - 10);
                }
                this.setsgstyle(_usingsgdefaultstyle);
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的临时数据")]
        public string[] TextBoxTags
        {
            get
            {
                return _tags;
            }
            set
            {
                _tags = value;
               // this.setsgstyle(_usingsgdefaultstyle);
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的文字是否显示多行"), DefaultValue(typeof(bool), "false")]
        public bool TextBoxMultLine
        {
            get
            {
                return _MultiLine;
            }
            set
            {
                _MultiLine = value;
                textBox1.Multiline = value;
                if (_MultiLine == true)
                {
                    this.textBox1.Location = new Point(5, 5);
                    this.textBox1.Size = new Size(this.Size.Width - 10, this.Size.Height - 10);
                }
                //this.setsgstyle(_usingsgdefaultstyle);
            }
        }
        [Browsable(true), Category("ButtonSettings"), Description("设置文本框是否使用系统齿轮的默认方案"), DefaultValue(typeof(bool), "true")]
        public bool TextBoxUsingSGDefaultStyle
        {
            get
            {
                return _usingsgdefaultstyle;
            }
            set
            {
                _usingsgdefaultstyle = value;
                //this.setsgdefaultstyle(value);
                this.setsgstyle(_usingsgdefaultstyle);
            }
            
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的是否支持拖动"), DefaultValue(typeof(bool), "true")]
        public bool TextBoxAllowDrop
        {
            get
            {
                return _allowdrop;
            }
            set
            {
                _allowdrop = value;
                textBox1.AllowDrop = this.AllowDrop = value;
                if (value == true)
                {
                    this.textBox1.DragDrop += new DragEventHandler(this.textBox1_DragDrop);
                    this.textBox1.DragEnter += new DragEventHandler(this.textBox1_DragEnter);
                }
               // this.setsgstyle(_usingsgdefaultstyle);
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框未被选中的边框颜色"), DefaultValue(typeof(Color), "195,195,195")]
        public Color TextBoxBorderColor
        {
            get
            {
                return _nochoosecolor;
            }
            set
            {
                _nochoosecolor = value;
                //this.setsgstyle(_usingsgdefaultstyle);
            }

        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的鼠标移动时边框颜色"), DefaultValue(typeof(Color), "0,148,255")]
        public Color TextBoxMouseMoveBorderColor
        {
            get
            {
                return _mmcolor;
            }
            set
            {
               _mmcolor  = value;
                this.setsgstyle(_usingsgdefaultstyle);
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的提示文字颜色"), DefaultValue(typeof(Color), "195,195,195")]
        public Color TextBoxInfoTipForceColor
        {
            get
            {
                return _printcolor;
            }
            set
            {
                _printcolor  = value;
                this.setsgstyle(_usingsgdefaultstyle);
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的字体样式"), DefaultValue(typeof(Font), "微软雅黑, 9pt, style=Bold")]
        public Font TextBoxFont
        {
            get
            {
                return _fonts;
            }
            set
            {
                _fonts = value;
                textBox1.Font = value;
                //this.setsgstyle(_usingsgdefaultstyle);
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的文字是否只读"), DefaultValue(typeof(bool), "false")]
        public bool TextBoxReadOnly
        {
            get
            {
                return _readonly;
            }
            set
            {
                _readonly  = value;
                //this.setsgstyle(_usingsgdefaultstyle);
               
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的文字是否是密码框"), DefaultValue(typeof(string), "")]
        public Char TextBoxPasswordChar
        {
            get
            {
                return _password;
            }
            set
            {
                _password  = value;
                textBox1.PasswordChar  = value;
                //this.setsgstyle(_usingsgdefaultstyle);
            }
        }
        [Browsable(true), Category("TextBoxSettings"), Description("设置文本框的提示文字"), DefaultValue(typeof(string), "")]
        public string TextBoxInfoTip
        {
            get
            {
                return _printtext;
            }
            set
            {
                _printtext  = value;
            }
        }
        #endregion
        public MyTextBox()
        {
            InitializeComponent();
        }

        private void MyTextBox_SizeChanged(object sender, EventArgs e)
        {
            if(_count ==0)
            {
                _orgsize = this.Size;
                _count = 1;
            }
            this.sizechange();
        }
         void sizechange()
        {
            int m = 5;
            this.textBox1.Location = new Point(m, m);
            if (_MultiLine == false)
            {
                /*
                if (isload == true)
                {
                    isload = false;
                }
                else
                {
                 * */
                this.textBox1.Size = new Size(this.Size.Width - m * 2, 16);
                this.Size = new Size(this.Size.Width, 26);
                //}
            }
            else
            {
                this.textBox1.Size = new Size(_orgsize.Width - m * 2, _orgsize.Height - m * 2);
                //this.Size = new Size(this.Size.Width, 26);
            }
        }
        private void MyTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            this.DrawMouseMoveColor = true;
            this.DrawLine();
        }

        private void MyTextBox_MouseLeave(object sender, EventArgs e)
        {
            this.DrawMouseMoveColor = false;
            this.DrawLine();
        }
        private void DrawLine()
        {
            if(this.DrawMouseMoveColor ==false)
            {
                Graphics g = this.CreateGraphics();
                Pen p = new Pen(_nochoosecolor, 2);//设置笔的粗细为,颜色为蓝色
                g.DrawRectangle(p, 0, 0, this.Size.Width, this.Size.Height);//在画板上画矩形,起始坐标为(10,10),宽为,高为
            }
            else
            {
                Graphics g = this.CreateGraphics();
                Pen p = new Pen(_mmcolor, 2);//设置笔的粗细为,颜色为蓝色
                g.DrawRectangle(p, 0, 0, this.Size.Width, this.Size.Height);//在画板上画矩形,起始坐标为(10,10),宽为,高为
            }
        }

        private void MyTextBox_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Size.Height.ToString());
        }

        private void textBox1_SizeChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_MultilineChanged(object sender, EventArgs e)
        {
            
        }
        private void setsgstyle(bool set)
        {
            if(set==true)
            {
                _mmcolor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetBorderColor();
                _forcecolor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetForceColor();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (_readonly == true)
            {
                textBox1.Text = _text;
            }
            else
            {
                _text = textBox1.Text;
                if (_OnTextChange != null)
                {
                    MYEventArgs ce = new MYEventArgs();
                    ce.TextData = _text;
                    //MYEvent(this, ce);
                    _OnTextChange(this, ce);
                }
                if (textBox1.Text == "")
                {
                    label1.ForeColor = _printcolor;
                    label1.Visible = true;
                    label1.Text = _printtext;
                    label1.ForeColor = _printcolor;
                }
                else
                {
                    label1.Visible = false;



                }
            }
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
             
        }
        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files.Length > 0)
            {
                textBox1.Text = files[0];
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void MyTextBox_Paint(object sender, PaintEventArgs e)
        {
            this.DrawLine();
        }

    }


}
