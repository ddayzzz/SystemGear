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
    public partial class UserControl_CreateOrEditionGUIDMainInfo : UserControl
    {
        public UserControl_CreateOrEditionGUIDMainInfo()
        {
            InitializeComponent();
        }
        private void UserControl_CreateOrEditionGUIDMainInfo_Load(object sender, EventArgs e)
        {
            if (this.FindForm().Tag.ToString().ToUpper() == "CREATE")
            {
                System.Guid guid = System.Guid.NewGuid(); //Guid 类型
                string strGUID = "{"+System.Guid.NewGuid().ToString().ToUpper()+"}"; //直接返回字符串类型
                label3.Text = strGUID;
            }
            else
            {
                label1.Text = "编辑GUID图标的配置文件信息";
                button1.Visible = false;
                label3.Text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "guid", "", false, this.FindForm().Tag.ToString());
                textBox1.Text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "", false, this.FindForm().Tag.ToString());
                textBox2.Text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", "", false, this.FindForm().Tag.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Guid guid = System.Guid.NewGuid(); //Guid 类型
            string strGUID = "{" + System.Guid.NewGuid().ToString().ToUpper() + "}"; //直接返回字符串类型
            label3.Text = strGUID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = MyFunctions.Dialogs.ChooseIcon("选择GUID主项目的图标", textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (this.FindForm().Tag.ToString().ToUpper())
            {
                case "CREATE":
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        label6.Visible = label7.Visible = false;
                        string FileNaem=MyFunctions.Dialogs.SaveFileDialog("保存配置文件","系统齿轮通用配置文件(*.SGCF)|*.SGCF",".SGCF");
                        if(FileNaem !="")
                        {
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "GUID",label3.Text, "GUIDIcon", false, FileNaem);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo","Name",textBox1.Text,"GUIDIcon",false,FileNaem);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo","Icon",textBox2.Text,"GUIDIcon",false,FileNaem);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo","CommandCount","0","GUIDIcon",false,FileNaem);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle","GUIDConfigFile",FileNaem,"Config",false,Application.StartupPath +@"\Config\MainProgram.sgcf");
                            this.Dispose();
                        }
                    }
                    else
                    {
                        if (textBox1.Text == "") { label6.Visible = true; } else { label6.Visible = false; };
                        if(textBox2.Text ==""){label7.Visible =true;}else{label7.Visible =false;};
                    }
                    break;
                default:
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        label6.Visible = label7.Visible = false;
                        string FileNaem = this.FindForm().Tag.ToString();
                        if (FileNaem != null)
                        {
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "Name", textBox1.Text, "GUIDIcon", false, FileNaem);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "Icon", textBox2.Text, "GUIDIcon", false, FileNaem);
                            //SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", "0", "GUIDIcon", false, FileNaem);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "GUIDConfigFile", FileNaem, "Config", false, Application.StartupPath + @"\Config\MainProgram.sgcf");
                            this.Dispose();
                        }
                    }
                    else
                    {
                        if (textBox1.Text == "") { label6.Visible = true; } else { label6.Visible = false; };
                        if (textBox2.Text == "") { label7.Visible = true; } else { label7.Visible = false; };
                    }
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
