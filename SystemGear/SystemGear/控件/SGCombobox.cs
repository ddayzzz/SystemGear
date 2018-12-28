using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ComboBox_Draw;

namespace SystemGear.控件
{
    public partial class SGCombobox : ComboBox 
    {
        private Color _selectbackcolor = Color.FromArgb(185, 223, 255);
        private ImageList _imagelist = null;
        public SGCombobox()
        {
            InitializeComponent();
        }
        [Browsable(true), Category("Settings"), Description("设置Combox的显示的图片")]
        public ImageList  Settings_ItemImages
        {
            get
            {
                return _imagelist;
            }
            set
            {
                _imagelist = value;
            }
        }
        [Browsable(true), Category("Settings"), Description("设置Combox的Item背景颜色")]
        public Color  Settings_ItemBackColor
        {
            get
            {
                return _selectbackcolor;
            }
            set
            {
                _selectbackcolor = value;
            }
        }

        private void SGCombobox_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if(_imagelist !=null)
                {
                    //鼠标选中在这个项上
                    if ((e.State & DrawItemState.Selected) != 0)
                    {
                        //渐变画刷
                        //LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, Color.FromArgb(255, 251, 237),
                        //Color.FromArgb(255, 236, 181), LinearGradientMode.Vertical);
                        SolidBrush brush = new SolidBrush(_selectbackcolor);
                        //填充区域
                        Rectangle borderRect = new Rectangle(3, e.Bounds.Y, e.Bounds.Width - 5, e.Bounds.Height - 2);

                        e.Graphics.FillRectangle(brush, borderRect);

                        //画边框
                        Pen pen = new Pen(_selectbackcolor);
                        e.Graphics.DrawRectangle(pen, borderRect);
                    }
                    else
                    {
                        SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                        e.Graphics.FillRectangle(brush, e.Bounds);
                    }

                    //获得项图片,绘制图片
                    //MyItem item = (MyItem)this.Items[e.Index];
                    Image img = _imagelist.Images[e.Index];//item.Img;

                    //图片绘制的区域
                    Rectangle imgRect = new Rectangle(e.Bounds.X + 3+3, e.Bounds.Y + 1, 32, 32);
                    //Rectangle imgRect = new Rectangle(6, (e.Bounds.Right - _imagelist.ImageSize.Height) / 2, _imagelist.ImageSize.Width, _imagelist.ImageSize.Height);
                    e.Graphics.DrawImage(img, imgRect);

                    //文本内容显示区域
                    Rectangle textRect =
                            new Rectangle(imgRect.Right + 2, imgRect.Y, e.Bounds.Width - imgRect.Width, e.Bounds.Height - 2);

                    //获得项文本内容,绘制文本
                    String itemText = this.Items[e.Index].ToString();

                    //文本格式垂直居中
                    StringFormat strFormat = new StringFormat();
                    strFormat.LineAlignment = StringAlignment.Center;
                    SolidBrush fontbrush = new SolidBrush(this.ForeColor);
                    e.Graphics.DrawString(itemText, this.Font, fontbrush, textRect, strFormat);
                }
            }
            catch { }
        }
    }
}
namespace ComboBox_Draw
{
    //自定义组合框项
    class MyItem
    {
        //项文本内容
        private String Text;

        //项图片
        public Image Img;

        //构造函数
        public MyItem(String text, Image img)
        {
            Text = text;
            Img = img;
        }

        //重写ToString函数，返回项文本
        public override string ToString()
        {
            return Text;
        }
    }
}
