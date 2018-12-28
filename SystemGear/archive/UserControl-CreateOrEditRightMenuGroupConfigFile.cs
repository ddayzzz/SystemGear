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
    public partial class UserControl_CreateOrEditRightMenuGroupConfigFile : UserControl
    {
        public UserControl_CreateOrEditRightMenuGroupConfigFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string iconf = MyFunctions.Dialogs.ChooseIcon("选择主菜单的图标", textBox2.Text);
            if(iconf !="")
            {
                textBox2.Text =iconf;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.FindForm().Tag.ToString() == "CREATE")
            {
                if (textBox1.Text == "")
                {
                    label6.Visible = true;
                }
                else
                {
                    label6.Visible = false;
                    string sgcf = MyFunctions.Dialogs.SaveFileDialog("请选择新的配置文件的目录", "系统齿轮通用配置文件(*.SGCF)|*.SGCF", ".SGCF");
                    if (sgcf != "")
                    {
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "Name", textBox1.Text, "RightMenuGroup", false, sgcf);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "RegName", textBox1.Text, "RightMenuGroup", false, sgcf);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "Icon", textBox2.Text, "RightMenuGroup", false, sgcf);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", "0", "RightMenuGroup", false, sgcf);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "RightMenuGroupConfigFile", sgcf, "Config", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                        this.Dispose();
                    }
                }
            }
            else
            {
                if (textBox1.Text == "")
                {
                    label6.Visible = true;
                }
                else
                {
                    label6.Visible = false;
                    string sgcf = this.FindForm().Tag.ToString();
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "Name", textBox1.Text, "RightMenuGroup", false, sgcf);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "Icon", textBox2.Text, "RightMenuGroup", false, sgcf);
                        //SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", "0", "RightMenuGroup", false, sgcf);
                        this.Dispose();
                }
            }
        }

        private void UserControl_CreateOrEditRightMenuGroupConfigFile_Load(object sender, EventArgs e)
        {
            if (this.FindForm().Tag.ToString().ToUpper() == "CREATE")
            {
                label1.Text = "新建右键菜单的配置文件";
            }
            else
            {
                label1.Text = "编辑右键菜单的配置文件";
                string cmdname = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "", false, this.FindForm().Tag.ToString());
                string cmdico = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", "", true, this.FindForm().Tag.ToString());
                textBox1.Text = cmdname;
                textBox2.Text = cmdico;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.FindForm().Tag.ToString());
        }
    }
}
