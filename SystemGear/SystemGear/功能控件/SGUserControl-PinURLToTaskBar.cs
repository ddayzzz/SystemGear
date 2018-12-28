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
    public partial class SGUserControl_PinURLToTaskBar : UserControl
    {
        public SGUserControl_PinURLToTaskBar()
        {
            InitializeComponent();
            //skin
            SGFunction.Skins.DrawAllControlInUserControl(this, SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "BK"));
            //coide
        }

        private void MyNormalButton5_OnButtonClick(object sender, EventArgs e)
        {

        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            string p, res;
            p=SGFunction.CommonDialogs.SelectIconDialog("选择一个网页的图标", sgTextBox3.Text, out res);
            if(res =="ok")
            {
                sgTextBox3.Text = p;
            }
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            if (sgTextBox1.Text != "" && sgTextBox2.Text != "")
            {
                string templink = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + @"\" + sgTextBox1.Text + ".lnk";
                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                SGFunction.SystemFunctionAndInformation.CreateLink(templink, "explorer.exe", @""""+sgTextBox2.Text+@"""", "", sgTextBox3.Text);
                SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, templink);
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功将您喜欢的网站固定到任务栏上", 1);
                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                this.Dispose();
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("哎 , 请您填写完必要的信息", 1);
            }
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            if (sgTextBox1.Text != "" && sgTextBox2.Text != "")
            {
                string templink = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + @"\" + sgTextBox1.Text  + ".website";
                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                SGFunction.DataOperate.SaveStringToTextFile(templink, Properties.Resources.DefaultWebSite);
                SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("{000214A0-0000-0000-C000-000000000046}", "Prop4", "31,"+ sgTextBox2.Text ,templink);
                SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "URL", sgTextBox2.Text, templink);
                string sui1 = SGFunction.StringOperate.GetRadamString(8);
                string sui2 = SGFunction.StringOperate.GetRadamString(8);
                SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}", "Prop5", "8,Microsoft.Website." + sui1 + "." + sui2, templink);
                string ico = sgTextBox3.Text;
                if (ico.Length >= 3)
                {
                    switch (ico.Substring(0, 3).ToUpper())
                    {
                        case "WWW":
                            SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconFile", ico,  templink);
                            SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconIndex", "1", templink);
                            break;
                        case "HTT":
                            SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconFile", ico,  templink);
                            SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconIndex", "1", templink);
                            break;
                        default:
                            string index = ico.Substring(ico.LastIndexOf(","), ico.Length - ico.LastIndexOf(",")).Replace(",", "");
                            string icolocation = ico.Substring(0, ico.LastIndexOf(","));
                            SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconFile", icolocation, templink);
                            SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconIndex", index, templink);
                            break;
                    }
                }
                SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, templink);
                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功将您喜欢的网站固定到任务栏上", 1);
                this.Dispose();
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("哎 , 请您填写完必要的信息", 1);
            }
        }
    }
}
