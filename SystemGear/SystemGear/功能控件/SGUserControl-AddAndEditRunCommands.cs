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
    public partial class SGUserControl_AddAndEditRunCommands : UserControl
    {
        string ty = "create";
        SGForm_Function_SystemStyle ff;
        string subname;
        int sleectindex = 0;
        bool islink = false;
        string shelllink = "";
        public SGUserControl_AddAndEditRunCommands(string type,SGForm_Function_SystemStyle f,string subname="",int select=0)
        {
            InitializeComponent();
            this.DrawSkin();
            ty = type;
            ff = f;
            this.subname = subname;
            this.sleectindex = select;
            if(type=="edit")
            {
                string loc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
                sgTextBox1.Text = subname.Substring(0,subname.LastIndexOf("."));
                string cmd = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Microsoft.Win32.Registry.LocalMachine, loc + "\\" + subname, "", "");
                string ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(cmd).ToLower();
                string arg = "";
                if(ext=="lnk")
                {
                    string lbkf=cmd;
                    //是LNK文件
                    cmd = SGFunction.SystemFunctionAndInformation.ReadLink(cmd, "path");
                    arg = SGFunction.SystemFunctionAndInformation.ReadLink(lbkf, "Args");
                    islink = true;
                    shelllink = lbkf;
                }
                sgTextBox3.Text = arg;
                sgTextBox2.Text = cmd;
                sgTextBox1.Enabled = false;
                //sgCheckBox1.Checked = false;
                //sgCheckBox1.Visible = false;
            }
        }

        private void MyNormalButton5_Click(object sender, EventArgs e)
        {
            string file = SGFunction.CommonDialogs.OpenFileDialog("选择文件", "可执行文件(*.exe)|*.exe");
            if (file != "")
            {
                sgTextBox2.Text = file;
                if(ty =="create")
                {
                    string nn = SGFunction.FileSystemOperate.FSO_GetFileNameWithoutExt(file);
                    sgTextBox1.Text = nn;
                }
            }
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            string fol = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("root") + "\\Shortcut";
            SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(fol);
            if (sgTextBox1.Text != "" && sgTextBox2.Text != "")
            {
                if (ty == "create")
                {
                    createcmd();
                }
                else { editcmd(); }
            }
            else
            { 
                //SGFunction.CommonDialogs.MessageDialog_ShowInfo("请您检查一下这些信息是否完整 : 菜单名称和执行的命令", 2); 
                if (sgTextBox1.Text == "") { sgTextBox1.DoError("你需要输入这个菜单的完整名称哦");}
                if (sgTextBox2.Text == "") { sgTextBox2.DoError("你需要输入这个菜单所执行命令哦"); }
            }
        }
        void createcmd()
        {
           if(sgCheckBox1.Checked ==false && sgTextBox3.Text =="")
           {
               string loc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
               SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Microsoft.Win32.Registry.LocalMachine, loc, sgTextBox1.Text +".exe");
               string cmd = sgTextBox2.Text;
               SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Microsoft.Win32.Registry.LocalMachine, loc + "\\" + sgTextBox1.Text +".exe", "", cmd);
               string exeico = sgTextBox2.Text;
               if (System.IO.File.Exists(exeico) == false)
               {
                   if (exeico.Length > 1)
                   {
                       string fl = exeico.Substring(0, 1);
                       string l = exeico.Substring(exeico.Length - 1, 1);
                       if (fl == @"""" && l == @"""")
                       {
                           exeico = exeico.Substring(1, exeico.Length - 1);
                           exeico = exeico.Substring(0, exeico.Length - 1);
                       }
                   }
               }
               //SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Microsoft.Win32.Registry.LocalMachine, loc + "\\" + sgTextBox1.Text, "icon",exeico);
               ff.imageList_runcommands.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(exeico));
               ff.listView6.Items.Add(sgTextBox1.Text +".exe").ImageIndex = ff.imageList_runcommands.Images.Count - 1;
               ff.listView6.Items[ff.listView6.Items.Count - 1].Tag = sgTextBox1.Text +".exe";
               ff.listView6.Items[ff.listView6.Items.Count - 1].SubItems.Add(cmd);
               string leibie = "程序";
               string ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(cmd);
               switch (ext.ToLower())
               {
                   case "lnk":
                       leibie = "快捷方式";
                       break;
                   case "exe":
                       leibie = "程序";
                       break;
                   default:
                       leibie = "文件或未知类型";
                       break;
               }
               ff.listView6.Items[ff.listView6.Items.Count - 1].SubItems.Add(leibie);
               ff.listView6.Items[ff.listView6.Items.Count - 1].SubItems.Add("是");
               this.Dispose();
           }
           else
           {
               string lnk = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("root") + "\\Shortcut\\" + sgTextBox1.Text +".exe" + ".lnk";
               //要管理元权限或者有命令行
               if(sgCheckBox1.Checked ==true )
               {
                   string admin = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("Programs") + "\\admin.lnk.sgo";
                   SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnk);
                   SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(admin, lnk, true);
                   SGFunction.SystemFunctionAndInformation.SetLink(lnk, "PATH", sgTextBox2.Text);
                   SGFunction.SystemFunctionAndInformation.SetLink(lnk, "ICON", sgTextBox2.Text);
                   SGFunction.SystemFunctionAndInformation.SetLink(lnk, "args", sgTextBox3.Text);
               }
               else
               {
                   SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnk);
                   SGFunction.SystemFunctionAndInformation.CreateLink(lnk, sgTextBox2.Text, sgTextBox3.Text, "", sgTextBox2.Text);
               }
               string loc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
               SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Microsoft.Win32.Registry.LocalMachine, loc, sgTextBox1.Text+".exe");
               string cmd = sgTextBox2.Text;
               SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Microsoft.Win32.Registry.LocalMachine, loc + "\\" + sgTextBox1.Text + ".exe", "", lnk);
               string exeico = sgTextBox2.Text;
               //SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Microsoft.Win32.Registry.LocalMachine, loc + "\\" + sgTextBox1.Text, "icon",exeico);
               ff.imageList_runcommands.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(exeico));
               ff.listView6.Items.Add(sgTextBox1.Text + ".exe").ImageIndex = ff.imageList_runcommands.Images.Count - 1;
               ff.listView6.Items[ff.listView6.Items.Count - 1].Tag = sgTextBox1.Text+".exe";
               ff.listView6.Items[ff.listView6.Items.Count - 1].SubItems.Add(cmd);
               string leibie = "快捷方式";
               ff.listView6.Items[ff.listView6.Items.Count - 1].SubItems.Add(leibie);
               ff.listView6.Items[ff.listView6.Items.Count - 1].SubItems.Add("是");
               this.Dispose();
           }

        }
        void editcmd()
        {
            string loc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
            if(sgCheckBox1.Checked ==false && sgTextBox3.Text =="")
            {
                //SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Microsoft.Win32.Registry.LocalMachine, loc, sgTextBox1.Text + ".exe");
                string cmd = sgTextBox2.Text;
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Microsoft.Win32.Registry.LocalMachine, loc + "\\" + subname , "", cmd);
                string exeico = sgTextBox2.Text;
                int imi = ff.listView6.Items[sleectindex].ImageIndex;
                //SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Microsoft.Win32.Registry.LocalMachine, loc + "\\" + sgTextBox1.Text, "icon", exeico);
                ff.imageList_runcommands.Images[imi] = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(exeico);
                ff.listView6.Items[sleectindex].SubItems[1].Text = cmd;
                string leibie = "程序";
                string ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(cmd);
                switch (ext.ToLower())
                {
                    case "lnk":
                        leibie = "快捷方式";
                        break;
                    case "exe":
                        leibie = "程序";
                        break;
                    default:
                        leibie = "文件或未知类型";
                        break;
                }
                ff.listView6.Items[sleectindex].SubItems[2].Text = leibie;
                ff.listView6.Items[sleectindex].SubItems[3].Text = "是";
                this.Dispose();
            }
            else
            {
                string lnk = shelllink;
                //要管理元权限或者有命令行
                //如果编辑之前是LNK就把信息写入LNK 如果是单纯的命令 则替换明琳为LNK新建lnk
                if(islink ==true )
                {
                    if(sgCheckBox1.Checked ==true)
                    {
                        //需要ADMIN 复制新的文件
                            string admin = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("Programs") + "\\admin.lnk.sgo";
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnk);
                            SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(admin, lnk, true);
                            SGFunction.SystemFunctionAndInformation.SetLink(lnk, "PATH", sgTextBox2.Text);
                            SGFunction.SystemFunctionAndInformation.SetLink(lnk, "ICON", sgTextBox2.Text);
                            SGFunction.SystemFunctionAndInformation.SetLink(lnk, "args", sgTextBox3.Text);
                    }
                    else
                    {
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnk);
                        SGFunction.SystemFunctionAndInformation.CreateLink(lnk, sgTextBox2.Text, sgTextBox3.Text, "", sgTextBox2.Text);
                        SGFunction.SystemFunctionAndInformation.SetLink(lnk, "PATH", sgTextBox2.Text);
                        SGFunction.SystemFunctionAndInformation.SetLink(lnk, "ICON", sgTextBox2.Text);
                        SGFunction.SystemFunctionAndInformation.SetLink(lnk, "args", sgTextBox3.Text);
                    }
                }
                else
                {
                    string nn = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("root") + "\\Shortcut\\" + sgTextBox1.Text + ".exe.lnk";
                    //吧原来的命令指向LNK
                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Microsoft.Win32.Registry.LocalMachine, loc + "\\" + sgTextBox1.Text + ".exe", "", nn);
                    if (sgCheckBox1.Checked == true)
                    {
                        //需要ADMIN 复制新的文件
                        string admin = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("Programs") + "\\admin.lnk.sgo";
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(nn);
                        SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(admin, nn, true);
                        SGFunction.SystemFunctionAndInformation.SetLink(nn, "PATH", sgTextBox2.Text);
                        SGFunction.SystemFunctionAndInformation.SetLink(nn, "ICON", sgTextBox2.Text);
                        SGFunction.SystemFunctionAndInformation.SetLink(nn, "args", sgTextBox3.Text);
                    }
                    else
                    {
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(nn);
                        SGFunction.SystemFunctionAndInformation.CreateLink(nn, sgTextBox2.Text, sgTextBox3.Text, "", sgTextBox2.Text);
                        //SGFunction.SystemFunctionAndInformation.SetLink(nn, "PATH", sgTextBox2.Text);
                        //SGFunction.SystemFunctionAndInformation.SetLink(nn, "ICON", sgTextBox2.Text);
                        //SGFunction.SystemFunctionAndInformation.SetLink(nn, "args", sgTextBox3.Text);
                    }
                }
                int imi = ff.listView6.Items[sleectindex].ImageIndex;
                //SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Microsoft.Win32.Registry.LocalMachine, loc + "\\" + sgTextBox1.Text, "icon", exeico);
                ff.imageList_runcommands.Images[imi] = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(sgTextBox2.Text);
                ff.listView6.Items[sleectindex].SubItems[1].Text = sgTextBox2.Text;
                string leibie = "快捷方式";
                ff.listView6.Items[sleectindex].SubItems[2].Text = leibie;
                ff.listView6.Items[sleectindex].SubItems[3].Text = "是";
                this.Dispose();
            }
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            string res;
            string[] arr = SGFunction.CommonDialogs.ShowMoreFunctionDialog("选择常用的操作", out res);
            if(res=="ok")
            {
                string name = arr[0];
                string app = arr[1];
                string arg = arr[2];
                string admin = arr[4];
                if (ty == "create") { sgTextBox1.Text = name; }
                sgTextBox2.Text = app;
                sgTextBox3.Text = arg;
                if (admin.ToUpper() == "TRUE") { sgCheckBox1.Checked = true; } else { sgCheckBox1.Checked = false; }
            }
        }
        private void DrawSkin()
        {
            SGFunction.Skins.DrawAllControlInUserControl(this, SGFunction.Skins.Skins_GetControlColorSetting("dialog_standard", "bk"));
        }
    }
}
