using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear.功能控件
{
    public partial class SGUserControl_HelpUserToDo : UserControl
    {
        private string cfg;
        private string[] _images,_texts;
        public SGUserControl_HelpUserToDo(string[] images,string[] texts,string title,string cfg,string b1,string b2,bool rem)
        {
            InitializeComponent();
            sgCheckBox1.Checked = sgCheckBox1.Visible = rem;
           // this.FindForm().TopMost = true;
            //skin
            panel1.BackColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "light");
            flowLayoutPanel1.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("dialog_standard", "bk");
            sgCheckBox1.ForeColor = SGFunction.Skins.Skins_GetControlColorSetting("checkbox", "fr");
            MyNormalButton1.BackColor = MyNormalButton2.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "bk");
            MyNormalButton1.ForeColor = MyNormalButton2.ForeColor = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "fr");
            //code
            flowLayoutPanel1.Controls.Clear();
            this.cfg = cfg;
            for(int p=1;p<=images.Length;p++)
            {
                Panel pan = new Panel();
                pan.Size = new Size(345, 205);
                MyNormalButton btn = new MyNormalButton();
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Size = new System.Drawing.Size(345,158);
                if (System.IO.File.Exists(images[p - 1]) == true) { pic.Image = System.Drawing.Image.FromFile(images[p - 1]); }
                btn.Size = new Size(345, 45);
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.Font = new Font("微软雅黑", 9f, FontStyle.Bold);
                btn.Text = texts[p - 1];
                btn.Tag = p.ToString();
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.Click += new EventHandler(this.MyNormalButton3_Click);
                btn.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("BTN_OTHER", "BK");
                btn.ForeColor = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "fr");
                switch(p)
                {
                    case 1:
                        btn.Image = Properties.Resources.ToDoTip_1;
                        break;
                    case 2:
                        btn.Image = Properties.Resources.ToDoTip_2;
                        break;
                    case 3:
                        btn.Image = Properties.Resources.ToDoTip_3;
                        break;
                    case 4:
                        btn.Image = Properties.Resources.ToDoTip_4;
                        break;
                    case 5:
                        btn.Image = Properties.Resources.ToDoTip_5;
                        break;
                    default:
                        btn.Image = Properties.Resources.ToDoTip_1;
                        break;
                }
                btn.Cursor = System.Windows.Forms.Cursors.Hand;
                btn.Location = new Point(0,0);
                pic.Location = new Point(0,47);
                pan.Controls.Add(btn);
                pan.Controls.Add(pic);
                flowLayoutPanel1.Controls.Add(pan);
                if (b1 != "") { MyNormalButton1.Visible = true; MyNormalButton1.Text = b1; } else { MyNormalButton1.Visible = false; }
                if (b2 != "") { MyNormalButton2.Visible = true; MyNormalButton2.Text = b2; } else { MyNormalButton2.Visible = false; }
            }
        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string p = ((MyNormalButton)sender).Tag.ToString();
                string getstr = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("shell", p, "", cfg, false);
                if (getstr != "")
                {
                    SGFunction.RunCommand.ShellCommand(getstr);
                }
            }
            catch { }
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            if (sgCheckBox1.Checked == false)
            {
                this.FindForm().Tag = "b2";
            }
            else
            {
                this.FindForm().Tag = "b4";
            }
            this.Dispose();
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {

            if (sgCheckBox1.Checked == false)
            {
                this.FindForm().Tag = "b1";
            }
            else
            {
                this.FindForm().Tag = "b3";
            }
            this.Dispose();
        }
        
    }
}
