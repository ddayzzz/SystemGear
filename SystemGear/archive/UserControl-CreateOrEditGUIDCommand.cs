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
    public partial class UserControl_CreateOrEditGUIDCommand : UserControl
    {
        public string ChooseName;
        public UserControl_CreateOrEditGUIDCommand()
        {
            InitializeComponent();
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            string[] pp =MyFunctions.Dialogs.ChooseOperateOrExploreFunctionDialog("ope");
            if (pp != null)
            {
                if (pp.Length == 5)
                {
                    textBox1.Text = pp[0];
                    textBox3.Text = pp[1]+" "+pp[3];
                    textBox2.Text = pp[2];
                    if (pp[4] == "T")
                    {
                        checkBox1.Checked = true;
                    }
                    else { checkBox1.Checked = false; }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = MyFunctions.Dialogs.ChooseIcon("选择子菜单的图标", textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = MyFunctions.Dialogs.OpenFileDialog("选择一个可执行文件", "可执行文件(*.exe)|*.exe");
            if (res != "")
            {
                textBox3.Text = res;
                textBox2.Text = res+@",0";
            }
        }

        private void UserControl_CreateOrEditGUIDCommand_Load(object sender, EventArgs e)
        {
            this.ChooseName = this.FindForm().Tag.ToString();
            string fn = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("SystemStyle", "guidconfigfile", "", true, Application.StartupPath + @"\\config\\mainprogram.sgcf");
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(fn) == true)
            {
                textBox1.Text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(this.ChooseName, "name", "", true, fn);
                textBox2.Text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(this.ChooseName, "icon", "", true, fn);
                textBox3.Text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(this.ChooseName, "command", "", false, fn);
                string j = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(this.ChooseName, "runasadmin", "", true, fn);
                if (j.ToUpper() == "T") 
                {
                    checkBox1.Checked = true;
                }
            }
            else
            {
                this.Dispose();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            string fn = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("SystemStyle", "guidconfigfile", "", true, Application.StartupPath + @"\\config\\mainprogram.sgcf");
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(fn) == true)
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(this.ChooseName.ToString(), "Name", textBox1.Text, "GUIDIcon", true, fn);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(this.ChooseName.ToString(), "Icon", textBox2.Text, "GUIDIcon", true, fn);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(this.ChooseName.ToString(), "Command", textBox3.Text, "GUIDIcon", true, fn);
                string valcmd;
                if (checkBox1.Checked == true)
                {
                    valcmd = "T";
                }
                else
                {
                    valcmd = "F";
                }
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(this.ChooseName.ToString(), "RunAsAdmin", valcmd, "GUIDIcon", true, fn);
            }
            this.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("2222");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
