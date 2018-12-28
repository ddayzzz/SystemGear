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
    public partial class SGTabPageControl : TabControl
    {
        #region 私有变量
        private bool _showtip = true;
        private Region _oldregion;
        private Color _titlebackcolor = Color.FromArgb(7, 107, 43);
        private Color _selecttitlecolor = Color.White;
        private Color _borderline = Color.White;
        private Color _titletextcolor = Color.White;
        private Color _selecttitletextcolor = Color.FromArgb(0, 55, 58);
        private Color _itmebuttomcolor = Color.White;
        private string _style = "normal";
        private Color _lightstyle_backcolor = Color.White;
        private Color _lightstyle_fontcolor = Color.FromArgb(185,185,185);
        private Color _lightstyle_selectfontcolor = Color.FromArgb(0, 55, 58);
        private Color _lightstyle_underlinecolor = Color.FromArgb(185, 185, 185);
        private Color _lightstyle_select_underlinecolor = Color.FromArgb(0, 55, 58);
        #endregion
        #region 属性
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡控件-是否显示标签")]
        public bool  SGCS_ShowTip
        {
            get
            {
                return _showtip;
            }
            set
            {
               _showtip  = value;
                if(value ==false)
                {
                }
                else
                {
                }
            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡控件-标签下部的边框颜色,一般指定为TabPage的颜色就可以了(可以绘制边框颜色)")]
        public Color  SGCS_ItemTitleButtomBorderColor
        {
            get
            {
                return _itmebuttomcolor;
            }
            set
            {
                _itmebuttomcolor = value;
            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡控件默认时标签的颜色")]
        public Color  SGCS_TitleBackColor
        {
            get
            {
                return _titlebackcolor;
            }
            set
            {
                _titlebackcolor = value;
            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡控件选中时标签的颜色")]
        public Color SGCS_SelectTitleBackColor
        {
            get
            {
                return _selecttitlecolor;
            }
            set
            {
                _selecttitlecolor  = value;
            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡控件边框的颜色(不要用)")]
        public Color SGCS_BorderColor
        {
            get
            {
                return _borderline;
            }
            set
            {
                _borderline = value;
            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡默认时标签字体的颜色")]
        public Color SGCS_TitleTextColor
        {
            get
            {
                return _titletextcolor;
            }
            set
            {
                _titletextcolor  = value;
            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡选中时标签字体的颜色")]
        public Color SGCS_SelectTitleTextColor
        {
            get
            {
                return _selecttitletextcolor;
            }
            set
            {
                _selecttitletextcolor  = value;
            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡样式 [normal]常规样式 [light]亮色(常用于做三级选项卡)")]
        public string SGCS_Style
        {
            get
            {
                return _style;
            }
            set
            {
                //string org = _style;
                //if(value.ToLower()!=org.ToLower())
                //{
                 //   this.Refresh();
                //}
                _style = value;

            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡使用亮色主题时的背景色")]
        public Color SGCS_Light_BackColor
        {
            get
            {
                return _lightstyle_backcolor;
            }
            set
            {
                _lightstyle_backcolor  = value;
            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡使用亮色主题时的下划线颜色")]
        public Color SGCS_Light_UnderLineColor
        {
            get
            {
                return _lightstyle_underlinecolor;
            }
            set
            {
               _lightstyle_underlinecolor = value;
            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡使用亮色主题时的选中时下划线颜色")]
        public Color SGCS_Light_SelectUnderLineColor
        {
            get
            {
                return _lightstyle_select_underlinecolor;
            }
            set
            {
                _lightstyle_select_underlinecolor  = value;
            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡使用亮色主题时的选中时字体颜色")]
        public Color SGCS_Light_SelectFontColor
        {
            get
            {
                return _lightstyle_selectfontcolor ;
            }
            set
            {
               _lightstyle_selectfontcolor  = value;
            }
        }
        [Browsable(true), Category("SGControlSettings"), Description("设置系统齿轮多选项卡使用亮色主题时的字体颜色")]
        public Color SGCS_Light_FontColor
        {
            get
            {
                return _lightstyle_fontcolor;
            }
            set
            {
                _lightstyle_fontcolor = value;
            }
        }
        #endregion
        public SGTabPageControl()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            _oldregion = this.Region;
        }

        private void SGTabPageControl_DrawItem(object sender, DrawItemEventArgs e)
        {
           /*
            //获取TabControl主控件的工作区域
            Rectangle rec = this.ClientRectangle;
            //获取背景图片，我的背景图片在项目资源文件中。
            //Image backImage = Properties.Resources.Select_Expand_Main;
            //新建一个StringFormat对象，用于对标签文字的布局设置
            StringFormat StrFormat = new StringFormat();
            StrFormat.LineAlignment = StringAlignment.Center;// 设置文字垂直方向居中
            StrFormat.Alignment = StringAlignment.Center;// 设置文字水平方向居中          
            // 标签背景填充颜色，也可以是图片
            SolidBrush bru = new SolidBrush(Color.FromArgb(205, 205, 205));
            SolidBrush bruFont = new SolidBrush(Color.FromArgb(0, 0, 0));// 标签字体颜色
            Font font = new System.Drawing.Font("微软雅黑", 12F);//设置标签字体样式
            //绘制主控件的背景
            //e.Graphics.DrawImage(backImage, 0, 0, this.Width, this.Height);
            //绘制标签样式
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                //获取标签头的工作区域
                Rectangle recChild = this.GetTabRect(i);
                //绘制标签头背景颜色
                e.Graphics.FillRectangle(bru, recChild);
                //绘制标签头的文字
                e.Graphics.DrawString(this.TabPages[i].Text, font, bruFont, recChild, StrFormat);
            }
            */
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            switch(_style.ToLower())
            {
                case "normal":
                    DrawStyle_Normal(e);
                    break;
                case "light":
                    DrawStyle_Light(e);
                    break;
            }
            
        }
        private void DrawStyle_Normal(PaintEventArgs e)
        {
            if (_showtip == false)
            {
                //_oldregion = this.Region;
                this.Region = new Region(new RectangleF(this.Left, this.Top, this.Width, this.Height));
            }
            else { this.Region = _oldregion; }
            Rectangle TabControlArea = this.ClientRectangle;
            Rectangle TabArea = this.DisplayRectangle;
            Graphics gs = e.Graphics;
            Brush brb = new SolidBrush(_borderline);
            gs.FillRectangle(brb, 0, 0, this.Width, this.Height);
            gs.DrawLine(new Pen(_borderline, 2), 0, 0, 0, this.Height);
            gs.DrawLine(new Pen(_borderline, 2), 0, this.Height, this.Width, this.Height);
            gs.DrawLine(new Pen(_borderline, 2), this.Width, 0, this.Width, this.Height);
            gs.DrawLine(new Pen(this._itmebuttomcolor, 3), 0, this.ItemSize.Height + 2, this.Width, this.ItemSize.Height + 2);
            gs.DrawLine(new Pen(this._itmebuttomcolor, 3), 0, this.ItemSize.Height + 2, 0, this.Height);
            gs.DrawLine(new Pen(this._itmebuttomcolor, 3), 0, this.Size.Height, this.Size.Width, this.Size.Height);
            gs.DrawLine(new Pen(this._itmebuttomcolor, 3), this.Size.Width, this.ItemSize.Height + 2, this.Size.Width, this.Size.Height);

            //TextureBrush tTabBg = new TextureBrush(Properties.Resources.TabControl_DefaultBack);
            //gs.FillRectangle(tTabBg, 0, 0, this.Width, Properties.Resources.TabControl_DefaultBack.Height+3);
            //tTabBg.Dispose();
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                bool bSelected = (this.SelectedIndex == i);
                Rectangle recBounds = this.GetTabRect(i);
                RectangleF tabTextArea = (RectangleF)this.GetTabRect(i);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                if (bSelected)
                {
                    Brush j = new SolidBrush(_selecttitlecolor); //定义标签的颜色
                    gs.FillRectangle(j, recBounds.Left, recBounds.Top, recBounds.Width, recBounds.Height);
                    j.Dispose();
                    //gs.DrawImage(Properties.Resources.TabControl_SelectBack, recBounds.Left - 1, 0);
                    //gs.DrawImage(Properties.Resources.TabControl_SelectBack, recBounds.Left + recBounds.Width - 5+5, 2+1);
                    System.Drawing.Font font = new Font(this.Font.FontFamily, 10, FontStyle.Bold);
                    Brush br = new SolidBrush(_selecttitletextcolor);
                    gs.DrawString(this.TabPages[i].Text, font, br, tabTextArea, stringFormat);
                }
                else
                {
                    Brush j = new SolidBrush(_titlebackcolor); //定义标签的颜色
                    gs.FillRectangle(j, recBounds.Left, recBounds.Top, recBounds.Width, recBounds.Height);
                    j.Dispose();
                    //gs.DrawImage(Properties.Resources.TabControl_DefaultBack, recBounds.Left - 1, 0);
                    //gs.DrawImage(Properties.Resources.TabControl_DefaultBack, recBounds.Left + recBounds.Width - 5+5, 2+1);
                    System.Drawing.Font font = new Font(this.Font.FontFamily, 10, FontStyle.Bold);
                    Brush br = new SolidBrush(_titletextcolor);
                    gs.DrawString(this.TabPages[i].Text, font, br, tabTextArea, stringFormat);
                }
            }
        }
        private void DrawStyle_Light(PaintEventArgs e)
        {
            if (_showtip == false)
            {
                //_oldregion = this.Region;
                this.Region = new Region(new RectangleF(this.Left, this.Top, this.Width, this.Height));
            }
            else { this.Region = _oldregion; }
            Rectangle TabControlArea = this.ClientRectangle;
            Rectangle TabArea = this.DisplayRectangle;
            Graphics gs = e.Graphics;
            Brush brb = new SolidBrush(_borderline);
            gs.FillRectangle(brb, 0, 0, this.Width, this.Height);
            gs.DrawLine(new Pen(_borderline, 2), 0, 0, 0, this.Height);
            gs.DrawLine(new Pen(_borderline, 2), 0, this.Height, this.Width, this.Height);
            gs.DrawLine(new Pen(_borderline, 2), this.Width, 0, this.Width, this.Height);
            gs.DrawLine(new Pen(this._itmebuttomcolor, 3), 0, this.ItemSize.Height + 2, this.Width, this.ItemSize.Height + 2);
            gs.DrawLine(new Pen(this._itmebuttomcolor, 3), 0, this.ItemSize.Height + 2, 0, this.Height);
            gs.DrawLine(new Pen(this._itmebuttomcolor, 3), 0, this.Size.Height, this.Size.Width, this.Size.Height);
            gs.DrawLine(new Pen(this._itmebuttomcolor, 3), this.Size.Width, this.ItemSize.Height + 2, this.Size.Width, this.Size.Height);
            int locationX = 0;
            //TextureBrush tTabBg = new TextureBrush(Properties.Resources.TabControl_DefaultBack);
            //gs.FillRectangle(tTabBg, 0, 0, this.Width, Properties.Resources.TabControl_DefaultBack.Height+3);
            //tTabBg.Dispose();
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                //locationX = locationX + i * this.ItemSize.Width;
                bool bSelected = (this.SelectedIndex == i);
                Rectangle recBounds = this.GetTabRect(i);
                RectangleF tabTextArea = (RectangleF)this.GetTabRect(i);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                locationX = recBounds.X;
                if (bSelected)
                {
                    Brush j = new SolidBrush(_lightstyle_backcolor); //定义标签的颜色
                    gs.FillRectangle(j, recBounds.Left, recBounds.Top, recBounds.Width, recBounds.Height);
                    j.Dispose();
                    //gs.DrawImage(Properties.Resources.TabControl_SelectBack, recBounds.Left - 1, 0);
                    //gs.DrawImage(Properties.Resources.TabControl_SelectBack, recBounds.Left + recBounds.Width - 5+5, 2+1);
                    System.Drawing.Font font = new Font(this.Font.FontFamily, 9, FontStyle.Bold  );
                    Brush br = new SolidBrush(_lightstyle_selectfontcolor);
                    gs.DrawString(this.TabPages[i].Text, font, br, tabTextArea, stringFormat);
                    ///绘制选择线条
                    Pen pen = new Pen(_lightstyle_select_underlinecolor,2);
                    gs.DrawLine(pen, new Point(locationX, recBounds.Height), new Point(locationX+recBounds.Width, recBounds.Height));
                    pen.Dispose();
                    br.Dispose();
                }
                else
                {
                    Brush j = new SolidBrush(_lightstyle_backcolor ); //定义标签的颜色
                    gs.FillRectangle(j, recBounds.Left, recBounds.Top, recBounds.Width, recBounds.Height);
                    j.Dispose();
                    //gs.DrawImage(Properties.Resources.TabControl_DefaultBack, recBounds.Left - 1, 0);
                    //gs.DrawImage(Properties.Resources.TabControl_DefaultBack, recBounds.Left + recBounds.Width - 5+5, 2+1);
                    System.Drawing.Font font = new Font(this.Font.FontFamily, 9, FontStyle.Bold);
                    Brush br = new SolidBrush(_lightstyle_fontcolor);
                    gs.DrawString(this.TabPages[i].Text, font, br, tabTextArea, stringFormat);
                    ///绘制选择线条
                    Pen pen = new Pen(_lightstyle_underlinecolor   , 2);
                    gs.DrawLine(pen, new Point(locationX, recBounds.Height), new Point(locationX+recBounds.Width, recBounds.Height));
                    pen.Dispose();
                    br.Dispose();
                }
            }
        }
    }
}
