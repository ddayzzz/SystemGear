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
    [DefaultEvent("OnChooseSecond")]
    public partial class SGSlidingDrawer : UserControl
    {
        /// <summary>
        /// 事件的数据
        /// </summary>
        public class ChooseSecondEventArgs : EventArgs
        {
            /// <summary>
            /// 主选项的索引 (从1开始)
            /// </summary>
            public int MainIndex { get; set; }
            /// <summary>
            /// 二级选项的索引值 (如果只选择了主选项则该值为0)
            /// </summary>
            public int SecondIndex { get; set; }
            /// <summary>
            /// 对应Treeview节点的Tag数据
            /// </summary>
            public string Tag { get; set; }
        }
        public delegate void ChooseSecondEventHandler(object sender,ChooseSecondEventArgs  ce);
        #region 变量
        private ChooseSecondEventHandler  _OnChooseSecond = null;
        private int _当前展开的Main的索引 = 0;
        private int _当前展开的Second的索引 = 0;
        private string _tag = "";
        private TreeView  _treeview = null;
        private Color _maindefaultcolor = Color.FromArgb(34,34,34);
        private Color _mainselectcolor = Color.FromArgb(54,54,54);
        private Color _seconddefaultcolor = Color.FromArgb(54,54,54);
        private Color _secondselectcolor = Color.FromArgb(255,255,255);
        private Control[] _mainnames = null;
        private Color _mainfontdefalutcolor = Color.White;
        private Color _mainfontselectcolor = Color.White;
        private Color _secondfontselectcolor = Color.FromArgb(0,148,255);
        private Color _secondfontdefaultcolor = Color.White;
        private int _mainitemscount = 0;
        private int _size_h = 30;
        #endregion
        #region 属性
        #region 事件
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public event ChooseSecondEventHandler  OnChooseSecond
        {
            add { _OnChooseSecond += new ChooseSecondEventHandler (value); }
            remove { _OnChooseSecond -= new ChooseSecondEventHandler (value); }
        }


        #endregion
        [Browsable(true), Category("Settings"), Description("设置抽屉控件关联的树状图控件")]
        public TreeView  Settings_TreeView
        {
            get
            {
                return _treeview;
            }
            set
            {
              _treeview  = value;
              if(value !=null)
              {
                  int count = value.Nodes.Count;
                  _mainnames = new Control[count];
                  this.SetMainTitles();
              }
              else
              {
                  _mainnames = null;
                  this.Controls.Clear();
              }
              
            }
        }
        [Browsable(true), Category("Settings"), Description("设置抽屉控件主选项未选中的背景颜色")]
        public Color  Settings_MainBackColor_Default
        {
            get
            {
                return _maindefaultcolor;
            }
            set
            {
                _maindefaultcolor = value;
            }
        }
        [Browsable(true), Category("Settings"), Description("设置抽屉控件主选项选中的背景颜色")]
        public Color Settings_MainBackColor_Select
        {
            get
            {
                return _mainselectcolor;
            }
            set
            {
               _mainselectcolor  = value;
            }
        }
        [Browsable(true), Category("Settings"), Description("设置抽屉控件二级选项未选中的背景颜色")]
        public Color Settings_SecondBackColor_Default
        {
            get
            {
                return _seconddefaultcolor;
            }
            set
            {
                _seconddefaultcolor = value;
            }
        }
        [Browsable(true), Category("Settings"), Description("设置抽屉控件二级选项被选中的背景颜色")]
        public Color Settings_SecondBackColor_Select
        {
            get
            {
                return _secondselectcolor;
            }
            set
            {
              _secondselectcolor  = value;
            }
        }
        //
        [Browsable(true), Category("Settings"), Description("设置抽屉控件主选项未选中的字体颜色")]
        public Color Settings_MainForceColor_Default
        {
            get
            {
                return _mainfontdefalutcolor;
            }
            set
            {
                _mainfontdefalutcolor = value;
            }
        }
        [Browsable(true), Category("Settings"), Description("设置抽屉控件主选项选中的字体颜色")]
        public Color Settings_MainForceColor_Select
        {
            get
            {
                return _mainfontselectcolor;
            }
            set
            {
               _mainfontselectcolor = value;
            }
        }
        [Browsable(true), Category("Settings"), Description("设置抽屉控件二级选项未选中的字体颜色")]
        public Color Settings_SecondForceColor_Default
        {
            get
            {
                return _secondfontdefaultcolor;
            }
            set
            {
                _secondfontdefaultcolor = value;
            }
        }
        [Browsable(true), Category("Settings"), Description("设置抽屉控件二级选项被选中的字体颜色")]
        public Color Settings_SecondForceColor_Select
        {
            get
            {
                return _secondfontselectcolor;
            }
            set
            {
                _secondfontselectcolor = value;
            }
        }
        [Browsable(true), Category("Settings"), Description("设置抽屉控件主选项和二级选项的高度")]
        public int  Settings_Height
        {
            get
            {
                return _size_h;
            }
            set
            {
                _size_h = value;
            }
        }
        #endregion
        #region 私有方法
        private void SetMainTitles()
        {
            //添加主选项卡和二级选项卡
            if(_treeview  !=null)
            {
                if(_treeview.Nodes.Count  >0)
                {
                    int location_y = 0;
                    Image im = null;
                    _mainitemscount = _treeview.Nodes.Count;
                    for(int h=1;h<=_treeview.Nodes.Count ;h++)
                    {
                        MyNormalButton my = new MyNormalButton();
                        my.Text = _treeview.Nodes[h - 1].Text;
                        my.Size = new Size(this.Size.Width  , _size_h);
                        my.Location = new Point(0, location_y);
                        my.Name = "MainTitle_"+h.ToString();
                        my.BackColor = _maindefaultcolor;
                        my.ForeColor = _mainfontdefalutcolor;
                        my.Font = new System.Drawing.Font(my.Font, FontStyle.Bold);
                        if(_treeview.Nodes[h-1].Tag ==null)
                        {
                            my.Settings_Tags = new string[] { "" };
                        }else
                        {
                            my.Settings_Tags = new string[] { _treeview.Nodes[h - 1].Tag.ToString() };
                        }
                        if(_treeview.ImageList !=null)
                        {
                            int j = _treeview.Nodes[h - 1].ImageIndex;
                            if(j<=_treeview.ImageList.Images.Count -1)
                            {
                                if (j == -1) { j = 0; }
                                im = _treeview.ImageList.Images[j];
                            }
                        }
                        my.Image  = im;
                        _mainnames[h - 1] = my;
                        my.Click  += new EventHandler(PublicMainSelect);
                        my.Tag = h.ToString();
                        my.ImageAlign = ContentAlignment.MiddleLeft;
                        this.Controls.Add(my);
                        location_y = location_y + _size_h ;
                        //设置子节点 子节点动态加载
                        /*
                        int _seccount = _treeview.Nodes[h - 1].Nodes.Count;
                        int co=0;
                        if (_seccount > 0)
                        {
                            FlowLayoutPanel flo = new FlowLayoutPanel();
                            for (int o = 1; o <= _treeview.Nodes[h - 1].Nodes.Count; o++)
                            {                   
                                MyNormalButton secb = new MyNormalButton();
                                secb.ButtonBackColor = _seconddefaultcolor;
                                secb.ButtonText = _treeview.Nodes[h - 1].Nodes[o - 1].Text;
                                secb.Size = new Size(210, 30);
                                secb.Margin = new Padding(0, 0, 0, 0);
                                secb.Name = h.ToString()+"-"+o.ToString();
                                secb.ButtonForceColor = _secondfontdefaultcolor;
                                secb.OnButtonClick += new EventHandler(PublicSecondSelect);
                                flo.Controls.Add(secb);
                                co=co+1;
                            }
                            this.Controls.Add(flo);
                            flo.Visible = false;
                            flo.Size = new System.Drawing.Size(this.Size.Width, 30 * co);
                            flo.Name = "SecondTitle_" + h.ToString();
                            _secondmainnames[h - 1, 0] = flo.Name;
                        }
                        else
                        {
                        }
                         */
                    }
                    //ExpandSeconTitles(1,3);
                }
            }
        }
        private void ExpandSeconTitles_OnlySelectMain(int mainindex)
        {
            _当前展开的Main的索引 = mainindex;
            Control[] choosebutton=this.Controls.Find("MainTitle_"+mainindex.ToString(),false);
            int location_y=0;
            int buttonsize_h = _size_h;
            for(int p=1;p<=_mainnames.Length;p++)
            {
                if (_mainnames[p - 1].Name != choosebutton[0].Name)
                {
                    //未被选择
                    MyNormalButton  mn = (MyNormalButton )_mainnames[p - 1];
                    mn.BackColor  = _maindefaultcolor;
                    mn.ForeColor =_mainfontdefalutcolor;
                    //mn.ButtonBackImage = Properties.Resources.Default_Close_Main;
                }
                else
                {
                    //已被选择
                    _mainnames[p - 1].Location = new Point(0, location_y);
                    this.flowLayoutPanel1.Location = new Point(0, _mainnames[p - 1].Location.Y + buttonsize_h);
                    this.AddSecondItems(mainindex);
                    this.flowLayoutPanel1.Visible = true;
                   MyNormalButton  mn = (MyNormalButton )_mainnames[p - 1];
                    mn.BackColor = _mainselectcolor;
                    mn.ForeColor = _mainfontselectcolor;
                    _tag = mn.Settings_Tags[0];
                    //mn.ButtonBackImage  = Properties.Resources.Select_Expand_Main;
                    //将他后面的控件送到后边去
                    int m=1;
                    for (int w = p; w <= _mainnames.Length-1; w++)
                    {
                        _mainnames[w].Location = new Point(0, _mainnames[w - 1].Size.Height + _mainnames[w - 1].Location.Y + flowLayoutPanel1.Size.Height * m);
                        //MessageBox.Show("风格");
                        m = 0;
                    }
                    
                }
               location_y = location_y + buttonsize_h;
            }
            /*
            string  treeviewsecond=_treeview.Nodes[mainindex-1],
            Control b = FindControl(this, _mainnames[mainindex -1]) ;
            MyNormalButton nb = (MyNormalButton)b;
            if (c != null && b != null)
            {
                if (secondindex > 0)
                {
                    nb.ButtonForceColor = _mainfontselectcolor;
                    Point location = b.Location;
                    nb.ButtonBackColor = _mainselectcolor;
                    c.Location = new Point(location.X, location.Y + b.Size.Height + 0);
                    Control sec = FindControl(c, mainindex.ToString() + "-" + secondindex.ToString());
                    if (sec != null)
                    {
                        MyNormalButton secon = (MyNormalButton)sec;
                        secon.ButtonBackColor = _secondselectcolor;
                        secon.ButtonForceColor = _secondfontselectcolor;
                        //移除之前的选择
                        int panelcontrolscount = c.Controls.Count;
                        for (int j = 1; j <= panelcontrolscount; j++)
                        {
                            string cname = c.Controls[j - 1].Name;
                            string choosename = mainindex.ToString() + "-" + secondindex.ToString();
                            if (cname != choosename)
                            {
                                //其他的按钮
                                Control com = FindControl(c, cname);
                                if (com != null)
                                {
                                    MyNormalButton other = (MyNormalButton)com;
                                    other.ButtonBackColor = _seconddefaultcolor;
                                    other.ButtonForceColor = _secondfontdefaultcolor;
                                }
                            }
                            else
                            {
                                //是选择的按钮 不管他
                            }
                        }
                    }
                }
                else
                {
                    nb.ButtonForceColor = _mainfontselectcolor;
                    Point location = b.Location;
                    nb.ButtonBackColor = _mainselectcolor;
                    c.Location = new Point(location.X, location.Y + b.Size.Height + 0);
                }
                //按钮的绘制
                int maincount = _mainnames.Length;
                string selectindex = mainindex.ToString();
                Point choose_location = new Point(0, 0);
                for (int p = 1; p <= maincount; p++)
                {
                    string cname = "MainTitle_" + p.ToString();
                    Control button = FindControl(this, cname);
                    MyNormalButton myn = (MyNormalButton)button;
                    //获取关联的二级菜单组
                    Control s = FindControl(this, mainindex.ToString() + "-" + secondindex.ToString());
                    if(cname !="MainTitle_"+selectindex)
                    {
                        //其他的按钮

                    }
                    else
                    {
                        //选择的按钮
                    }
                    
                }
                c.Visible = true;
            }
             */
        }
        private void ExpandSeconTitles_OnlySelectSecond(int secondindex)
        {
            _当前展开的Second的索引 = secondindex;
            Control oj = FindControl(flowLayoutPanel1, secondindex.ToString());
            if(oj !=null)
            {
                MyNormalButton  m = (MyNormalButton )oj;
                m.BackColor  = _secondselectcolor;
                m.ForeColor  = _secondfontselectcolor;
                _tag = m.Settings_Tags[0];
                string choosename = m.Name;
                for(int u=1;u<=flowLayoutPanel1.Controls.Count;u++)
                {
                    if(flowLayoutPanel1.Controls[u-1].Name !=choosename )
                    {
                        MyNormalButton  ot = (MyNormalButton )FindControl(flowLayoutPanel1, flowLayoutPanel1.Controls[u - 1].Name);
                        ot.ForeColor  = _secondfontdefaultcolor;
                        ot.BackColor = _seconddefaultcolor;
                    }
                }
            }
        }
        private void AddSecondItems(int mainindex)
        {
            try
            {
                //Image  im = null;
                flowLayoutPanel1.Controls.Clear();
                int count  = _treeview.Nodes[mainindex - 1].Nodes.Count;
                for(int j=1;j<=count;j++)
                {
                    MyNormalButton  m = new MyNormalButton ();
                    m.Text = _treeview.Nodes[mainindex - 1].Nodes[j - 1].Text;
                    //im = _treeview.ImageList.Images[_treeview.Nodes[mainindex - 1].Nodes[j - 1].ImageIndex]; 
                    m.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    m.Tag = _treeview.Nodes[mainindex - 1].Nodes[j - 1].Tag;
                    m.BackColor = _seconddefaultcolor;
                    m.ForeColor  = _secondfontdefaultcolor;
                    if (_treeview.Nodes[mainindex - 1].Nodes[j - 1].Tag != null)
                    {
                        m.Settings_Tags = new string[] { _treeview.Nodes[mainindex - 1].Nodes[j - 1].Tag.ToString() };
                    }
                    else
                    { m.Settings_Tags = new string[] { "" }; }
                    //m.ButtonBackImage= im;
                    m.Size = new Size(this.Size.Width , 35);
                    m.Name = j.ToString();
                    m.Tag = j.ToString();
                    m.Click += new EventHandler(this.PublicSecondSelect);
                    flowLayoutPanel1.Controls.Add(m);
                }
                this.flowLayoutPanel1.Size = new Size(this.flowLayoutPanel1.Size.Width, 35 * count);
            }
            catch { }
        }
        /// <summary>
        /// 查找控件
        /// </summary>
        /// <param name="container">容器</param>
        /// <param name="controlName">控件名</param>
        /// <returns></returns>
        private Control FindControl(Control container, string controlName)  // 参数1为容器 参数2为控件名称
        {
            if (container.Name == controlName)
            {
                return container;
            }
            Control findControl = null;
            foreach (Control control in container.Controls)
            {
                Console.WriteLine(control.Name);
                if (control.Controls.Count == 0)
                {
                    if (control.Name == controlName)
                    {
                        findControl = control; break;
                    }
                }
                else
                {
                    findControl = FindControl(control, controlName);
                    if (findControl != null)
                    {
                        break;
                    }
                }
            }
            return findControl;
        }
        #endregion
        public SGSlidingDrawer()
        {
            InitializeComponent();
        }

        private void MySlidingDrawer_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Size = new Size(this.Size.Width, flowLayoutPanel1.Size.Height);
            foreach (Control c in this.Controls)
            {
                if (c is MyNormalButton )
                {
                    MyNormalButton  nc = ((MyNormalButton )c);
                    nc.Size = new Size(this.Size.Width, nc.Size.Height);
                }
            }
        }

        private void PublicMainSelect(object sender, EventArgs e)
        {
            MyNormalButton my = (MyNormalButton)sender;
            string tag = my.Tag.ToString();
            int m;
            int.TryParse(tag, out m);
            this.ExpandSeconTitles_OnlySelectMain(m);
            if (_OnChooseSecond != null)
            {
                ChooseSecondEventArgs vb = new ChooseSecondEventArgs();
                vb.MainIndex = _当前展开的Main的索引;
                vb.SecondIndex = _当前展开的Second的索引;
                vb.Tag = _tag;
                _OnChooseSecond(this, vb);
            }
        }
        private void PublicSecondSelect(object sender, EventArgs e)
        {
            MyNormalButton  my = (MyNormalButton )sender;
            string tag = my.Tag.ToString();
            int m;
            int.TryParse(tag, out m);
            this.ExpandSeconTitles_OnlySelectSecond(m);
            if(_OnChooseSecond !=null)
            {
                ChooseSecondEventArgs vb = new ChooseSecondEventArgs();
                vb.MainIndex = _当前展开的Main的索引;
                vb.SecondIndex = _当前展开的Second的索引;
                vb.Tag = _tag;
                _OnChooseSecond(this, vb);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        private  void whenchangecolor()
        {
            Color m = _maindefaultcolor;
            Color s = SGFunction.ColorOperate.GetColorInDeep(m, 50);
            _mainselectcolor = s;
        }
        private void whenclickmain()
        {
            if(_当前展开的Second的索引 ==0)
            {
                flowLayoutPanel1.Visible = false;
                int x, y;
                x = y = 0;
                for (int j = 1; j <= _mainitemscount; j++)
                {
                    MyNormalButton f = (MyNormalButton)this.Controls.Find("MainTitle_" + j, false)[0];
                    f.Location = new Point(x, y);
                    y = y +_size_h ;
                }
            }
        }
    }
}
