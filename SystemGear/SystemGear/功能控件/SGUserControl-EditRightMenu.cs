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
    public partial class SGUserControl_EditRightMenu : UserControl
    {
        string index, cfg;
        bool isfenge=false;
        public SGUserControl_EditRightMenu(string name,string ico,string cmd,string index,string cfg,bool admin,bool isfenge)
        {
            InitializeComponent();
            //SKIN
            SGFunction.Skins.DrawAllControlInUserControl(this, SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "BK"));
            //CODE
            this.index = index;
            this.cfg = cfg;
            this.isfenge = isfenge;
            if(isfenge ==true)
            {
                MyNormalButton1.Visible = false;
                MyNormalButton2.Location = new Point(446, 10);
                MyNormalButton2.Size = new Size(226, MyNormalButton2.Size.Height);
                MyNormalButton2.Text = "确定，并转换为普通菜单";
            }
            else
            {
                sgTextBox1.Text = name;
                sgTextBox2.Text = cmd;
                sgTextBox3.Text = ico;
                sgCheckBox1.Checked = admin;
            }
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            if (sgTextBox1.Text != "" && sgTextBox2.Text != "")
            {
                string ad = "F";
                if (sgCheckBox1.Checked == true) { ad = "T"; }
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + index, "IsFenGeFu", "F", "RightMenuGroup", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + index, "Name", sgTextBox1.Text, "RightMenuGroup", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + index, "Command", sgTextBox2.Text, "RightMenuGroup", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + index, "Icon", sgTextBox3.Text, "RightMenuGroup", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + index, "RunAsAdmin", ad, "RightMenuGroup", false, cfg);
                this.FindForm().Tag = "ok";
                this.Dispose();
            }
            else { 
                //SGFunction.CommonDialogs.MessageDialog_ShowInfo("请检查您所填写的信息是否完整 : 名称和命令", 3); 
                if (sgTextBox2.Text == "") { sgTextBox2.DoError("您似乎没有输入这个菜单的命令哦"); }
                if (sgTextBox1.Text == "") { sgTextBox1.DoError("您似乎没有输入这个菜单的名称哦"); }
            }
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要转换为分隔符吗?", "转换为分隔符后，您之前的设置将不会保存", "确定", "取消", "b2", "ques");
            if(res=="b1")
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + index, "IsFenGeFu", "T", "RightMenuGroup", false, cfg);
            }
            this.FindForm().Tag = "ok";
            this.Dispose();
        }

        private void MyNormalButton4_Click(object sender, EventArgs e)
        {
            string res;
            string[] arr = SGFunction.CommonDialogs.ShowMoreFunctionDialog("选择常用的操作", out res);
            if (res == "ok")
            {
                string name = arr[0];
                string app = arr[1];
                string arg = arr[2];
                string admin = arr[4];
                string ico = arr[3];
                sgTextBox1.Text = name;
                sgTextBox2.Text = @"""" + app + @""" " + arg;
                sgTextBox3.Text = ico;
                if (admin.ToUpper() == "TRUE") { sgCheckBox1.Checked = true; } else { sgCheckBox1.Checked = false; }
            }
        }

        private void MyNormalButton5_Click(object sender, EventArgs e)
        {
            string file = SGFunction.CommonDialogs.OpenFileDialog("选择文件", "所有文件(*.*)|*.*");
            if(file !="")
            {
                sgTextBox2.Text = @""""+file+@"""";
                string ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(file).ToLower();
                if(ext=="exe")
                {
                    sgTextBox3.Text = file + ",0";
                }
            }
        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            string res;
            string file = SGFunction.CommonDialogs.SelectIconDialog("选择菜单的图标", sgTextBox3.Text, out res);
            if (res=="ok")
            {
                sgTextBox3.Text = file;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
