using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SystemGear
{
    public partial class Form_ContextMenuStrip : Form
    {
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public Color BorderColor;
        public string[] Commands_Name;
        public string ret = "";
        MouseEventHandler[] MouseEvents;
        public Form_ContextMenuStrip(Color _BorderColor,string[] Commands_Name,MouseEventHandler[] MouseEvents)
        {
            InitializeComponent();
            this.BorderColor = _BorderColor;
            this.Commands_Name = Commands_Name;
            this.MouseEvents = MouseEvents;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //AnimateWindow(this.Handle, 1000, 0x20010);   // 居中逐渐显示。
            AnimateWindow(this.Handle, 150, 0xA0000); // 淡入淡出效果。
            //AnimateWindow(this.Handle, 300, 0x60004); // 自上向下。
            //AnimateWindow(this.Handle, 1000, 0x20004); // 自上向下。
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            //AnimateWindow(this.Handle, 1000, 0x10010);    // 居中逐渐隐藏。
            AnimateWindow(this.Handle, 150, 0x90000); // 淡入淡出效果。
            //AnimateWindow(this.Handle, 1000, 0x50008); // 自下而上。
            //AnimateWindow(this.Handle, 1000, 0x10008); // 自下而上。
        }

        private void Form_ContextMenuStrip_Load(object sender, EventArgs e)
        {
            
        }

        private void Form_ContextMenuStrip_Paint(object sender, PaintEventArgs e)
        {
            Graphics gd = e.Graphics;
            gd.DrawRectangle(new Pen(BorderColor, 5), 0, 0, this.Width - 1, this.Height - 1);
            //新建按钮
            int _X, _Y;
            _X = 3;
            _Y = 3;
            int V = 1;
            for (int g = 1; g <= Commands_Name.Length; g++)
            {
                if (Commands_Name[g - 1] != "|")
                {
                    Button btn = new Button();
                    btn.Text = Commands_Name[g - 1];
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.White;
                    btn.Location = new Point(_X, _Y);
                    Font font = new Font("微软雅黑", Convert.ToInt16(9), FontStyle.Bold);
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.ForeColor = BorderColor;
                    btn.Font = font;
                    btn.Size = new Size(183, 30);
                    btn.Tag = "B" + (g-V+1).ToString();
                    btn.MouseDown += new MouseEventHandler(MouseEvents[g - V]);
                    btn.Click += new EventHandler(this.Btn_Click);
                    this.Controls.Add(btn);
                    _Y = _Y + 30;
                }
                else
                {
                    Pen p = new Pen(BorderColor, 4);//设置笔的粗细为,颜色为蓝色
                    Graphics gH = e.Graphics;
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    gH.DrawLine(p, 0, _Y + 2, this.Size.Width, _Y + 2);
                    //gH.Dispose();
                    //p.Dispose();
                    //Refresh();
                    _Y = _Y + 2;
                    V++;
                }
            }
            this.Size = new Size(189, _Y+3);
        }

        private void Form_ContextMenuStrip_Shown(object sender, EventArgs e)
        {
            
        }
        public void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ret =btn.Tag.ToString().ToUpper();
            this.Close();
        }
        private void Form_ContextMenuStrip_Deactivate(object sender, EventArgs e)
        {
           this.Hide();
          // Application.DoEvents();
          // this.Close();
        }
        
    }
}
