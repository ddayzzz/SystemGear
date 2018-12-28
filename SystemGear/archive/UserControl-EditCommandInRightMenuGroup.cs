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
    public partial class UserControl_EditCommandInRightMenuGroup : UserControl
    {
        public UserControl_EditCommandInRightMenuGroup()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void UserControl_EditCommandInRightMenuGroup_Load(object sender, EventArgs e)
        {
            string sgcf=MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "rightmenugroupconfigfile", "", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
            textBox3.Text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(this.FindForm().Tag.ToString(), "regname", "", false, sgcf);
            textBox1.Text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(this.FindForm().Tag.ToString(), "name", "", false, sgcf);
            textBox2.Text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(this.FindForm().Tag.ToString(), "icon", "", true, sgcf);
            textBox4.Text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(this.FindForm().Tag.ToString(), "command", "", true, sgcf);
            string asadmin = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(this.FindForm().Tag.ToString(), "runasadmin", "F", false, sgcf);
            if (asadmin.ToUpper() == "T")
            {
                checkBox1.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string iconf = MyFunctions.Dialogs.ChooseIcon("选择在菜单的图标", @"%windir%\system32\imageres.dll,2");
            if (iconf != "")
            {
                textBox2.Text = iconf;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox1.Text != "" && textBox4.Text !="")
            {
                label6.Visible = label3.Visible = false;
                label8.Visible = false;
                string sgcf=MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "rightmenugroupconfigfile", "", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(this.FindForm().Tag.ToString(), "RegName", textBox3.Text, "RightMenuGroup", false, sgcf);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(this.FindForm().Tag.ToString(), "Name", textBox1.Text, "RightMenuGroup", false, sgcf);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(this.FindForm().Tag.ToString(), "Icon", textBox2.Text, "RightMenuGroup", false, sgcf);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(this.FindForm().Tag.ToString(), "Command", textBox4.Text, "RightMenuGroup", false, sgcf);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(this.FindForm().Tag.ToString(), "IsFenGeFu", "F", "RightMenuGroup", false, sgcf);
                string asadm = "F";
                if (checkBox1.Checked == true)
                {
                    asadm = "T";
                }
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(this.FindForm().Tag.ToString(), "RunAsAdmin", asadm, "RightMenuGroup", false, sgcf);
                this.Dispose();
            }
            else
            {
                if (textBox3.Text == "")
                {
                    label3.Visible = true;
                }
                if (textBox1.Text == "")
                {
                    label6.Visible = true;
                }
                if (textBox4.Text == "")
                {
                    label8.Visible = true;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string[] pp = MyFunctions.Dialogs.ChooseOperateOrExploreFunctionDialog("ope");
            if (pp != null)
            {
                if (pp.Length == 5)
                {
                    textBox1.Text = pp[0];
                    textBox4.Text = pp[1]+" " +pp[3];
                    textBox2.Text = pp[2];
                    if (pp[3] == "T")
                    {
                        checkBox1.Checked = true;
                    }
                    else { checkBox1.Checked = false; }
                }
            }
        }
    }
}
