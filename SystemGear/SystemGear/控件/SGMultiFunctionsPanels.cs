using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear.控件
{
    public partial class SGMultiFunctionsPanels : TabControl 
    {
        #region 私有变量
        private Region _oldregion;
        private Size _titlesize=new Size(50,10);
        private Color _titlefill_default_color = Color.FromArgb(0, 148, 255);
        private Color _titlefill_beselected_color = Color.FromArgb(0,0,0);
        #endregion
        /*
        #region 方法
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

                //this.Region = new Region(new RectangleF(this.Left, this.Top, this.Width, this.Height));
            
            Rectangle TabControlArea = this.ClientRectangle;
            Rectangle TabArea = this.DisplayRectangle;
            Graphics gs = e.Graphics;
            /*
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
                    //Brush j = new SolidBrush(_selecttitlecolor); //定义标签的颜色
                    //gs.FillRectangle(j, recBounds.Left, recBounds.Top, recBounds.Width, recBounds.Height);
                    //j.Dispose();
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
        #endregion
        */
        public SGMultiFunctionsPanels()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            _oldregion = this.Region;
        }

    }
}
