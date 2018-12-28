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
     [DefaultEvent("OnChooseItem"),Description("当点击了任何一个项目时触发的事件")]
    public partial class SGItems : UserControl
    {
        public delegate void ChooseItemEventHandler(object sender, ChooseItemEventArgs ce);
        private ChooseItemEventHandler _OnChooseItem = null;
        private string[] _items;
        private Color _defaultcolor = Color.FromArgb(34, 34, 34);
        private Color _selectcolor = Color.FromArgb(255, 255, 255);
        private Color _defaultfontcolor = Color.FromArgb(255, 255, 255);
        private Color _selectfontcolor = Color.FromArgb(34, 34, 34);
        private int _selectindex = 1;
        private ImageList _selectimnage = null;
        private string[] _imagesitems = null;
        private ContentAlignment _imga = ContentAlignment.MiddleLeft;
        private int _height = 45;
        public SGItems()
        {
            InitializeComponent();
        }
        #region 属性
       
        public class ChooseItemEventArgs : EventArgs
        {
            public int Index { get; set; }
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public event ChooseItemEventHandler OnChooseItem
        {
            add { _OnChooseItem += new ChooseItemEventHandler(value); }
            remove { _OnChooseItem -= new ChooseItemEventHandler(value); }
        }
        [Browsable(true), Category("Settings"), Description("设置选项控件的项目")]
        public string[] Settings_Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                changeitems();
            }
        }
        [Browsable(true), Category("Settings"), Description("设置选项控件的项目的图片")]
        public string[] Settings_ImageItems
        {
            get
            {
                return _imagesitems;
            }
            set
            {
                _imagesitems  = value;
            }
        }
        [Browsable(true), Category("Settings"), Description("设置选项控件的图片的对齐方式")]
        public ContentAlignment  Settings_ImageAlignment
        {
            get
            {
                return _imga;
            }
            set
            {
                _imga = value;
               // changeitems();
            }
        }
        [Browsable(true), Category("Settings"), Description("设置选项控件的默认颜色")]
        public Color  Settings_DefaultColor
        {
            get
            {
                return _defaultcolor;
            }
            set
            {
                _defaultcolor = value;
            }
        }
        [Browsable(true), Category("Settings"), Description("设置选项控件的选中后的颜色")]
        public Color Settings_SelectColor
        {
            get
            {
                return _selectcolor;
            }
            set
            {
                _selectcolor  = value;
            }
        }
         [Browsable(true), Category("Settings"), Description("设置选项控件的选中后的字体颜色")]
        public Color Settings_SelectFontColor
        {
            get
            {
                return _selectfontcolor;
            }
            set
            {
               _selectfontcolor = value;
            }
        }
         [Browsable(true), Category("Settings"), Description("设置选项控件的默认的字体颜色")]
        public Color Settings_DefaultFontColor
        {
            get
            {
                return _defaultfontcolor ;
            }
            set
            {
               _defaultfontcolor = value;
            }
        }
         [Browsable(true), Category("Settings"), Description("设置或者获取当前选中的项目 例如[1]")]
         public int Settings_ChooseItemsIndex
         {
             get
             {
                 return _selectindex;
             }
             set
             {
                 _selectindex = value;
                 this.changechoosevalue();
             }
         }
         private void changechoosevalue()
         {
             if(_selectindex >0 && this.Controls.Count >0)
             {
                 try
                 {
                     Control co = this.Controls[_selectindex - 1];
                     if (co is MyNormalButton)
                     {
                         MyNormalButton g = (MyNormalButton)co;
                         string i = g.Tag.ToString();
                         int inde;
                         g.BackColor = _selectcolor;
                         g.ForeColor = _selectfontcolor;
                         g.BackgroundImage = Properties.Resources.选择滑块;
                         int.TryParse(i, out inde);
                         _selectindex = inde;
                         foreach (Control c in this.Controls)
                         {
                             if (c is MyNormalButton)
                             {
                                 MyNormalButton m = (MyNormalButton)c;
                                 if (c.Tag.ToString() != i)
                                 { c.BackColor = _defaultcolor; c.ForeColor = _defaultfontcolor; m.BackgroundImage = null; }
                             }
                         }
                     }
                 }
                 catch { }
             }
             //不引发事件
         }
         public void Setting_ClickItem(int index)
        {
            _selectindex = index;
            foreach (Control c in this.Controls)
            {
                if (c is MyNormalButton)
                {
                    MyNormalButton m = new MyNormalButton();
                    m = (MyNormalButton)c;
                    if (m.Tag.ToString() == _selectindex.ToString())
                    {
                        m.BackColor = _selectcolor;
                        m.ForeColor = _selectfontcolor;
                    }
                    else
                    {
                        c.BackColor = _defaultcolor;
                        c.ForeColor = _defaultfontcolor;
                    }
                }
            }
        }
         private void setimage()
         {
            if(_imagesitems !=null && _items !=null)
            {
                for(int u=1;u<=this.Controls.Count;u++)
                {
                    Control f = this.Controls[u - 1];
                    if(f is MyNormalButton )
                    {
                        MyNormalButton h = (MyNormalButton)f;
                        h.Image = SGFunction.Resources.GetImageFromResourcesCode(_imagesitems[u - 1]);
                        h.ImageAlign = _imga;
                    }
                }
            }
         }
        private  void changeitems()
        {
            this.Controls.Clear();
            int h = 0;
            for(int o=1;o<=_items.Length;o++)
            {
                MyNormalButton g = new MyNormalButton();
                g.Text = SGFunction.PathOperate.ConvertStringToTurePath(_items[o - 1],_items[o - 1]);
                g.Size = new Size(this.Size.Width, _height);
                g.Font = new Font("微软雅黑", 9.75f, FontStyle.Bold);
                g.Location = new Point(0, h);
                g.Click += new EventHandler(this.itemsclick);
                g.BackColor = _defaultcolor;
                g.BackgroundImageLayout = ImageLayout.Stretch;
                g.ForeColor =_defaultfontcolor;
                //g.ImageAlign = ContentAlignment.MiddleLeft;
                g.TextAlign = ContentAlignment.MiddleCenter;
                g.Tag = o;
                h = h + _height ;
                this.Controls.Add(g);
            }
        }
        private void itemsclick(object sender, EventArgs e)
        {
            MyNormalButton g = (MyNormalButton)sender;
            string i = g.Tag.ToString();
            int inde;
            g.BackColor = _selectcolor;
            g.ForeColor = _selectfontcolor;
            g.BackgroundImage = Properties.Resources.选择滑块;
            int.TryParse(i, out inde);
            _selectindex = inde;
            foreach (Control c in this.Controls)
            {
                if (c is MyNormalButton)
                {
                    MyNormalButton m = (MyNormalButton)c;
                    if (c.Tag.ToString() != i)
                    { c.BackColor = _defaultcolor; c.ForeColor = _defaultfontcolor; m.BackgroundImage = null; }
                }
            }
            if (_OnChooseItem != null)
            {
                ChooseItemEventArgs vb = new ChooseItemEventArgs();
                vb.Index = inde;
                _OnChooseItem(this, vb);
            }
        }
        #endregion

        private void SGItems_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is MyNormalButton)
                {
                    c.Size = new Size(this.Size.Width, c.Size.Height);
                }
            }
        }

        private void SGItems_Paint(object sender, PaintEventArgs e)
        {
            if( _items !=null)
            {
                this.setimage();
            }
        }
    }
}
