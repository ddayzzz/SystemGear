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
    public partial class UserControl_PinWebSite : UserControl
    {
        public UserControl_PinWebSite()
        {
            InitializeComponent();
        }

        private void myNormalButton5_OnButtonClick(object sender, EventArgs e)
        {
            string ico = MyFunctions.Dialogs.ChooseIcon("选择一个图标", @"%windir%\system32\ieframe.dll,22");
            if(ico !="")
            {
                myTextBox3.TextBoxText = ico;
            }
        }

        private void myNormalButton1_OnButtonClick(object sender, EventArgs e)
        {
            if (myTextBox1.TextBoxText != "" && myTextBox2.TextBoxText != "")
            {
                string[] o = new string[] { "固定到任务栏", "固定到桌面", "固定到开始菜单" };
                string j = MyFunctions.Dialogs.TasksChooseDialog("选择固定的位置", o);
                string templink = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath("") + @"\" + myTextBox1.TextBoxText + ".lnk";
                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                MyFunctions.ProgramAndLinksOperate.CreateLink(templink, myTextBox2.TextBoxText, "", "", myTextBox3.TextBoxText, null);
                switch (j)
                {
                    case "T1":
                        MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, templink);
                        MyFunctions.Dialogs.MessageDialog("固定成功", "成功将快捷方式固定到指定位置", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                        this.Dispose();
                        break;
                    case "T2":
                        string desk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + myTextBox1.TextBoxText + ".lnk";
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(templink, desk);
                        MyFunctions.Dialogs.MessageDialog("固定成功", "成功将快捷方式固定到指定位置", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                        this.Dispose();
                        break;
                    case "T3":
                        string desk1 = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + @"\" + myTextBox1.TextBoxText + ".lnk";
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(templink, desk1);
                        MyFunctions.Dialogs.MessageDialog("固定成功", "成功将快捷方式固定到指定位置", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                        this.Dispose();
                        break;
                }
                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);

            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("固定失败", @"固定失败 : 信息不完整. 请检查""网站名称""或""网站地址""是否填写完整", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
            }
        }

        private void myNormalButton2_OnButtonClick(object sender, EventArgs e)
        {
            if (myTextBox1.TextBoxText != "" && myTextBox2.TextBoxText != "")
            {
                string[] o = new string[] { "固定到任务栏", "固定到桌面", "固定到开始菜单" };
                string j = MyFunctions.Dialogs.TasksChooseDialog("选择固定的位置", o);
                string templink = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath("") + @"\" + myTextBox1.TextBoxText + ".website";
                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                MyFunctions.StreamAndTextOperate.TextOperate.SaveTextFile(templink, Properties.Resources.DefaultWebSite);
                MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("{000214A0-0000-0000-C000-000000000046}", "Prop4", "31," + myTextBox2.TextBoxText, false, templink);
                MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "URL", myTextBox2.TextBoxText, false, templink);
                string sui1 = MyFunctions.StreamAndTextOperate.StrngOperate.SuiJiShengChengString(8);
                string sui2 = MyFunctions.StreamAndTextOperate.StrngOperate.SuiJiShengChengString(8);
                MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}", "Prop5", "8,Microsoft.Website." + sui1 + "." + sui2, false, templink);
                string ico = myTextBox3.TextBoxText;
                if (ico.Length >= 3)
                {
                    switch (ico.Substring(0, 3).ToUpper())
                    {
                        case "WWW":
                            MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconFile", ico, false, templink);
                            MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconIndex", "1", false, templink);
                            break;
                        case "HTT":
                            MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconFile", ico, false, templink);
                            MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconIndex", "1", false, templink);
                            break;
                        default:
                            string index = ico.Substring(ico.LastIndexOf(","), ico.Length - ico.LastIndexOf(",")).Replace(",", "");
                            string icolocation = ico.Substring(0, ico.LastIndexOf(","));
                            MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconFile", icolocation, false, templink);
                            MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("InternetShortcut", "IconIndex", index, false, templink);
                            break;
                    }
                }
                switch (j)
                {
                    case "T1":
                        MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, templink);
                        MyFunctions.Dialogs.MessageDialog("固定成功", "成功将快捷方式固定到指定位置", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                        this.Dispose();
                        break;
                    case "T2":
                        string desk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + myTextBox1.TextBoxText + ".website";
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(templink, desk);
                        MyFunctions.Dialogs.MessageDialog("固定成功", "成功将快捷方式固定到指定位置", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                        this.Dispose();
                        break;
                    case "T3":
                        string desk1 = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + @"\" + myTextBox1.TextBoxText + ".website";
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(templink, desk1);
                        MyFunctions.Dialogs.MessageDialog("固定成功", "成功将快捷方式固定到指定位置", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                        this.Dispose();
                        break;
                    default:
                        break;
                }
                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);  
            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("固定失败", @"固定失败 : 信息不完整. 请检查""网站名称""或""网站地址""是否填写完整", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
            }
        }
    }
}
