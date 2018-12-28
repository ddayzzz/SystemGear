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
    public partial class UserControl_SLMGR : UserControl
    {
        public UserControl_SLMGR()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("更改密钥");
            comboBox1.Items.Add("激活备份");
            comboBox1.Items.Add("激活还原");
            comboBox1.SelectedIndex = 0;
            label3.Visible = false;
            textBox1.Visible = false;
            button22.Visible = false;
            label4.Visible = false;
            button1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("更改密钥");
            comboBox1.Items.Add("激活备份");
            comboBox1.Items.Add("激活还原");
            comboBox1.SelectedIndex = 0;
            label3.Visible = true;
            textBox1.Visible = true;
            button22.Visible = true;
            button1.Visible = true;
        }

        private void UserControl_SLMGR_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("更改密钥");
            comboBox1.Items.Add("激活备份");
            comboBox1.Items.Add("激活还原");
            comboBox1.SelectedIndex = 0;
            label3.Visible = false;
            textBox1.Visible = false;
            button22.Visible = false;
            label4.Visible = false;
            button1.Visible = true;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string path = MyFunctions.Dialogs.OpenFolder("选择Office的安装路径");
            if (System.IO.File.Exists(path + @"\ospp.vbs") == true)
            {
                textBox1.Text = path;
                label4.Visible = false;
            }
            else
            {
                label4.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        
                        break;
                    case 1:
                        string key="";
                        if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() != "6.1")
                        {
                            string res = MyFunctions.Dialogs.MessageDialog("是否输入密钥?", "输入密钥之后,还原激活信息时不需要在此输入密钥", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                            if (res == "B1")
                            {
                                key = MyFunctions.Dialogs.InputDialog("输入密钥", "输入一个有效的密钥 例如 :XXXXX-XXXXX-XXXXX-XXXXX-XXXXX", false, "", "", "", "");
                            }
                            this.SLMGR_WIN_WIN8("BAK", key);
                        }
                        break;
                    case 2:
                        if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() != "6.1")
                        {
                            SLMGR_WIN_WIN8("REC", "");
                        }
                        break;
                }
            }
        }
        void SLMGR_WIN_WIN8(string Operate, string Key)
        {
            switch (Operate)
            {
                case "BAK":
                    string folder = MyFunctions.Dialogs.OpenFolder("备份的目录");
                    if (System.IO.Directory.Exists(folder) == true)
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(folder + @"\cache");
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\spp\store\tokens.dat", folder + @"\tokens.dat");
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\spp\store\cache\cache.dat", folder + @"\cache\cache.dat");
                        if (Key != "")
                        {
                            MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("Key", "Key", Key, false, folder + @"\Key.ini");
                        }
                        MyFunctions.Dialogs.MessageDialog("备份成功", "成功备份了激活的信息", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    }
                    break;
                case "REC":
                    string res = MyFunctions.Dialogs.MessageDialog("是否要还原?", "是否要还原激活信息?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                    if (res == "B1")
                    {
                        string fol = MyFunctions.Dialogs.OpenFolder("选择备份的目录");
                        if (System.IO.File.Exists(fol + @"\tokens.dat") && System.IO.File.Exists(fol + @"\cache\cache.dat") == true)
                        {
                            string sn = "";
                            string newsn;
                           sn = MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_GetValue("key", "key", "", false, fol + @"\key.ini");
                           if (sn == "")
                           {
                               newsn = MyFunctions.Dialogs.InputDialog("输入密钥", "输入一个有效的密钥 例如 :XXXXX-XXXXX-XXXXX-XXXXX-XXXXX", false, "", "", "", "");
                           }
                           else
                           {
                               newsn = sn;
                           }
                           if (newsn != "")
                           {
                               MyFunctions.ProgramAndLinksOperate.ShellPrograms("cscript.exe", @"/nologo """+Environment.GetFolderPath(Environment.SpecialFolder.System)+@"\slmgr.vbs"" /ipk " + newsn, true, false, true, false, true);
                               MyFunctions.ProgramAndLinksOperate.ShellPrograms("net.exe", "stop sppsvc", true, false, true, false, true);
                               MyFunctions.FileSystemOperate.FileSystemOperate_GetAdminWithFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\spp\store\tokens.dat");
                               MyFunctions.FileSystemOperate.FileSystemOperate_GetAdminWithFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\spp\store\cache\cache.dat");
                               MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(fol + @"\tokens.dat", Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\spp\store\tokens.dat");
                               MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(fol + @"\cache\cache.dat", Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\spp\store\cache\cache.dat");
                               MyFunctions.ProgramAndLinksOperate.ShellPrograms("net.exe", "start sppsvc", true, false, true, false, true);
                               MyFunctions.Dialogs.MessageDialog("还原成功", "成功还原了激活的信息", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
                           }
                           else
                           {
                               MyFunctions.Dialogs.MessageDialog("错误", "请输入密钥", MyFunctions.Dialogs.MessageDialogIcon.Error , "", "b2", false, true, "是", "确定");
                           }
                        }
                        else
                        {
                            MyFunctions.Dialogs.MessageDialog("错误", "该目录不是一个有效的目录", MyFunctions.Dialogs.MessageDialogIcon.Error , "", "b2", false, true, "是", "确定");
                        }
                    }
                    break;
            }
        }
    }
}
