using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.AccessControl;

namespace SystemGear.功能控件
{
    public partial class SGUserControl_CreateRightMenu : UserControl
    {
        string ext = "";
        string type;
        string code;
        SGForm_Function_SystemStyle ff;
        string[] tags;
        bool ishandler = false;
        int select = 0;
        Color warr = Color.FromArgb(239, 156, 0);
        bool shortcutisadmin = false;
        public SGUserControl_CreateRightMenu(string ty,string code,SGForm_Function_SystemStyle f,string[] tags,int se=0)
        {
            InitializeComponent();
            //SKINS
            SGFunction.Skins.DrawAllControlInUserControl(this, SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "BK"));
            this.panel1.BackColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "light");
            MyNormalButton2.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("BTN_OTHER", "BK");
            MyNormalButton2.ForeColor = SGFunction.Skins.Skins_GetControlColorSetting("BTN_OTHER", "fr");
            //CODE
            type = ty;
            this.code = code;
            ff=f;
            select = se;
            this.tags = tags;
            switch(ty)
            {
                case "edit":
                    this.LoadMenu();
                    bool h=this.GetMenuType_IsSystem();
                    sgTextBox2.Size = new Size(358, 23);
                    sgTextBox_arg.Visible = false;
                    sgTextBox_arg.Text = "";
                    if(h)
                    {
                        panel1.BackColor = warr; pictureBox1.Visible = sgLabel1.Visible = true; pictureBox1.BackColor = warr;
                    }
                    break;
                case "create":
                    sgTextBox2.Size = new Size(358, 23);
                    sgTextBox_arg.Visible = false;
                    sgTextBox_arg.Text = "";
                    break;
                case "edit_sendto":
                    sgTextBox2.Size = new Size(247, 23);
                    sgTextBox_arg.Visible = true;
                    this.LoadSendToMenu(tags[0],tags[1]); //0是LNK 1是名称
                    break;
                case "create_sendto":
                    sgTextBox2.Size = new Size(247, 23);
                    sgTextBox_arg.Visible = true;
                    break;
                case "create_selectext":
                    sgTextBox2.Size = new Size(358, 23);
                    sgTextBox_arg.Visible = false;
                    sgTextBox_arg.Text = "";
                    ext = code; //.exe
                    //MessageBox.Show(ext);
                    break;
            }
        }
        private void LoadSendToMenu(string lnk,string n)
        {
            try
            {
                //通过INFO 来判断是否是管理员
                string app=SGFunction.SystemFunctionAndInformation.ReadLink(lnk,"path");
                string arg=SGFunction.SystemFunctionAndInformation.ReadLink(lnk,"args");
                string ico=SGFunction.SystemFunctionAndInformation.ReadLink(lnk,"icon");
                string info = SGFunction.SystemFunctionAndInformation.ReadLink(lnk, "info");
                sgTextBox1.Text = n;
                sgTextBox2.Text = app;
                sgTextBox_arg.Text = arg;
                sgTextBox3.Text = ico;
                if(info.ToUpper()=="RUNASADMIN")
                {
                    sgCheckBox1.Checked  = true;
                    shortcutisadmin = true;
                }
            }
            catch { }
        }
        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            if (sgTextBox1.Text != "" && sgTextBox2.Text != "")
            {
                string vbs = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + "\\RunAsAdmin.vbs";
                if (System.IO.File.Exists(vbs) == false) { SGFunction.ScriptOperate.CreateRunAsAdminVBS(); }
                switch (type)
                {
                    case "create":
                        switch (code)
                        {
                            case "DK":
                                Create_Desktop();
                                break;
                            case "MC":
                                Create_MyComputer();
                                break;
                            case "FL":
                                Create_AllFile();
                                break;
                            case "FO":
                                Create_AllFolder();
                                break;
                            case "DI":
                                Create_AllDisk();
                                break;
                            case "EX":
                                Create_EXE();
                                break;
                            case "LK":
                                Create_LNK();
                                break;
                            case "TX":
                                Create_TXT();
                                break;
                            case "DL":
                                Create_DLL();
                                break;
                        }
                        this.FindForm().Tag = "ok";
                        this.Dispose();
                        break;
                    case "edit":
                        EditMenu();
                        this.FindForm().Tag = "ok";
                        this.Dispose();
                        break;
                    case "create_sendto":
                        this.Create_SendTo();
                        this.FindForm().Tag = "ok";
                        this.Dispose();
                        break;
                    case "edit_sendto":
                        this.EditSendTo(tags[0], shortcutisadmin, sgTextBox1.Text, sgTextBox2.Text, sgTextBox_arg.Text, sgTextBox3.Text, sgCheckBox1.Checked);
                        this.FindForm().Tag = "ok";
                        this.Dispose();
                        break;
                    case "create_selectext":
                        this.Create_Anyfile(ext);
                        this.FindForm().Tag = "ok";
                        this.Dispose();
                        break;
                }
            }
            else { 
               // SGFunction.CommonDialogs.MessageDialog_ShowInfo("请您检查一下这些信息是否完整 : 菜单名称和执行的命令", 2);
                if (sgTextBox2.Text == "") { sgTextBox2.DoError("您似乎没有输入这个菜单的命令哦"); }
                if (sgTextBox1.Text == "") { sgTextBox1.DoError("您似乎没有输入这个菜单的名称哦"); }
            }
        }
        void EditSendTo(string orglnk,bool orgisadmin,string name,string app,string arg,string ico,bool runasadmin)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo";
            if(orgisadmin ==true)
            {
                if(runasadmin  ==false)
                {
                    //由ADMIN转换为标准
                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(orglnk);
                    SGFunction.SystemFunctionAndInformation.CreateLink(folder + "\\" + name + ".lnk", app, arg, "", ico);
                }
                else
                {
                    //还是原来的模式
                    SGFunction.SystemFunctionAndInformation.SetLink(orglnk, "path", app);
                    SGFunction.SystemFunctionAndInformation.SetLink(orglnk, "args",arg);
                    SGFunction.SystemFunctionAndInformation.SetLink(orglnk, "icon", ico);
                    SGFunction.SystemFunctionAndInformation.SetLink(orglnk, "info", "RUNASADMIN");
                    //改名字
                    SGFunction.FileSystemOperate.FSO_RenameFile(orglnk, folder + "\\" + name + ".lnk");
                }
            }
            else
            {
                if(runasadmin==false)
                {
                    //本来就是标准模式
                    SGFunction.SystemFunctionAndInformation.SetLink(orglnk, "path", app);
                    SGFunction.SystemFunctionAndInformation.SetLink(orglnk, "args", arg);
                    SGFunction.SystemFunctionAndInformation.SetLink(orglnk, "icon", ico);
                    SGFunction.SystemFunctionAndInformation.SetLink(orglnk, "info", "");
                    //改名字
                    SGFunction.FileSystemOperate.FSO_RenameFile(orglnk, folder + "\\" + name + ".lnk");
                }
                else
                {
                    //变成了ADMIN
                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(orglnk);
                    SGFunction.SystemFunctionAndInformation.CreateLink_StartAdminType(folder + "\\" + name + ".lnk", app, arg, "RUNASADMIN", ico);
                }
            }
            //修改TAG
            ff.listView8.Items[select].SubItems[0].Text = name;
            ff.listView8.Items[select].SubItems[1].Text = folder + "\\" + name + ".lnk";
            ff.listView8.Items[select].Tag = folder + "\\" + name + ".lnk";
            Bitmap  o = SGFunction.ImageAndIconOperate.GetFileIcon(folder + "\\" + name + ".lnk");
            ff.imageList_rmmgr_listimage.Images[ff.listView8.Items[select].ImageIndex] = o;
        }
        void Create_Anyfile(string ext)
        {
            string key = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, ext, "", "");
            if (key == "")
            {
                key = ext + "file";
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shell");
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shellex");
                //SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key + @"\shellex", "ContextMenuHandlers");
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, key + "\\defaulticon", "", @"%windir%\system32\imageres.dll,2", RegistryValueKind.ExpandString);
            }
            string loc = key + @"\shell";
            RegistryKey root = Registry.ClassesRoot;
            if (ishandler == false)
            {
                string name = sgTextBox1.Text;
                string cmd = sgTextBox2.Text;
                string ico = sgTextBox3.Text;
                bool admin = sgCheckBox1.Checked;
                string arg = sgTextBox_arg.Text;
                cmd = cmd + arg;
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc, name);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "", name);
                if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "icon", ico); }
                if (admin == true) { cmd = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + @"\runasadmin.vbs"" " + cmd; }
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc + "\\" + name, "command");
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name + "\\command", "", cmd);
                ff.listView8.Items.Add(name).SubItems.Add(cmd);
                ff.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                ff.listView8.Items[ff.listView8.Items.Count - 1].ImageIndex = ff.imageList_rmmgr_listimage.Images.Count - 1;
                ff.listView8.Items[ff.listView8.Items.Count - 1].Tag = new string[] { name, "HKCR," + loc + "," + name };
            }
        }
        void Create_Desktop()
        {
            string loc = @"SOFTWARE\Classes\Directory\background\shell";
            if(ishandler ==false)
            {
                string name = sgTextBox1.Text;
                string cmd = sgTextBox2.Text;
                string ico = sgTextBox3.Text;
                bool admin = sgCheckBox1.Checked;
                string arg = sgTextBox_arg.Text;
                cmd = cmd + arg;
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Microsoft.Win32.Registry.LocalMachine, loc, name);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Microsoft.Win32.Registry.LocalMachine, loc+"\\"+name, "", name);
                if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Microsoft.Win32.Registry.LocalMachine, loc+"\\"+name, "icon",ico); }
                if (admin == true) { cmd = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + @"\runasadmin.vbs"" " + cmd +arg ; }
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Microsoft.Win32.Registry.LocalMachine, loc+"\\"+name, "command");
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Microsoft.Win32.Registry.LocalMachine, loc+"\\"+name+"\\command", "", cmd);
                ff.listView8.Items.Add(name).SubItems.Add(cmd);
                ff.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                ff.listView8.Items[ff.listView8.Items.Count - 1].ImageIndex = ff.imageList_rmmgr_listimage.Images.Count - 1;
                ff.listView8.Items[ff.listView8.Items.Count - 1].Tag = new string[] { name, "HKLM," + loc + "," + name };
            }
        }
        void Create_MyComputer()
        {
            string loc = @"CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            if (ishandler == false)
            {
                string name = sgTextBox1.Text;
                string cmd = sgTextBox2.Text;
                string ico = sgTextBox3.Text;
                bool admin = sgCheckBox1.Checked;
                string arg = sgTextBox_arg.Text;
                cmd = cmd + arg;
                if (admin == true) { cmd = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + @"\runasadmin.vbs"" " + cmd + arg; }
                //reg
                SGFunction.RegistryOperate.RegistryOperate_AddRegistrySecurity("everyone", "", RegistryRights.TakeOwnership, AccessControlType.Allow);
                RegistryKey ke=Registry.ClassesRoot.OpenSubKey(loc, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                if (ke.OpenSubKey("shell") == null) { ke.CreateSubKey("shell", RegistryKeyPermissionCheck.ReadWriteSubTree); }
                if (ke.OpenSubKey("shell") == null) { SGFunction.CommonDialogs.MessageDialog_MustClick("添加右键菜单失败", "无法添加右键菜单失败 : 因为注册表权限不允许添加任何右键菜单项目。我们会尽快的解决这类的问题。", "", "确定", "b2", "error"); }
                else
                {
                    ke.OpenSubKey("shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).CreateSubKey(name);
                    if (ke.OpenSubKey("shell\\"+name ) == null) { SGFunction.CommonDialogs.MessageDialog_MustClick("添加右键菜单失败", "无法添加右键菜单失败 : 因为注册表权限不允许添加任何右键菜单项目。我们会尽快的解决这类的问题。", "", "确定", "b2", "error"); }
                    else
                    {
                        ke.OpenSubKey("shell", true).CreateSubKey(name);
                        if (ico != "") { }
                        //
                        ff.listView8.Items.Add(name).SubItems.Add(cmd);
                        ff.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                        ff.listView8.Items[ff.listView8.Items.Count - 1].ImageIndex = ff.imageList_rmmgr_listimage.Images.Count - 1;
                        ff.listView8.Items[ff.listView8.Items.Count - 1].Tag = new string[] { name, "HKLM," + loc + "," + name };
                    }
                }
                
            }
        }
        void Create_SendTo()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo";
            string lnk = folder + "\\"+sgTextBox1.Text + ".lnk";
            string adminlnk = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + "\\Admin.lnk.sgo";
            if(sgCheckBox1.Checked ==true)
            {
                SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(adminlnk, lnk);
                SGFunction.SystemFunctionAndInformation.SetLink(lnk, "PATH", sgTextBox2.Text);
                SGFunction.SystemFunctionAndInformation.SetLink(lnk,"args", sgTextBox_arg.Text);
                SGFunction.SystemFunctionAndInformation.SetLink(lnk,"icon", sgTextBox3.Text);
                SGFunction.SystemFunctionAndInformation.SetLink(lnk, "info", "RUNASADMIN");
            }
            else
            {

                SGFunction.SystemFunctionAndInformation.CreateLink(lnk,sgTextBox2.Text,sgTextBox_arg.Text,"",sgTextBox3.Text);
            }
            ff.listView8.Items.Add(sgTextBox1.Text).SubItems.Add(lnk);
            ff.listView8.Items[ff.listView8.Items.Count - 1].Tag = lnk;
            Bitmap  fic = SGFunction.ImageAndIconOperate.GetFileIcon(lnk);
            ff.imageList_rmmgr_listimage.Images.Add(fic);
            ff.listView8.Items[ff.listView8.Items.Count - 1].ImageIndex = ff.imageList_rmmgr_listimage.Images.Count - 1;
        }

        void Create_AllFile()
        {
            string loc = @"*\shell";
            RegistryKey root = Registry.ClassesRoot;
            if (ishandler == false)
            {
                string name = sgTextBox1.Text;
                string cmd = sgTextBox2.Text;
                string ico = sgTextBox3.Text;
                bool admin = sgCheckBox1.Checked;
                string arg = sgTextBox_arg.Text;
                cmd = cmd + arg;
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc, name);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "", name);
                if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "icon", ico); }
                if (admin == true) { cmd = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + @"\runasadmin.vbs"" " + cmd + arg; }
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc + "\\" + name, "command");
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name + "\\command", "", cmd);
                ff.listView8.Items.Add(name).SubItems.Add(cmd);
                ff.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                ff.listView8.Items[ff.listView8.Items.Count - 1].ImageIndex = ff.imageList_rmmgr_listimage.Images.Count - 1;
                ff.listView8.Items[ff.listView8.Items.Count - 1].Tag = new string[] { name, "HKCR," + loc + "," + name };
            }
        }
        void Create_AllFolder()
        {
            string loc = @"SOFTWARE\Classes\Folder\shell";
            RegistryKey root = Registry.LocalMachine;
            if (ishandler == false)
            {
                string name = sgTextBox1.Text;
                string cmd = sgTextBox2.Text;
                string ico = sgTextBox3.Text;
                bool admin = sgCheckBox1.Checked;
                string arg = sgTextBox_arg.Text;
                cmd = cmd + arg;
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc, name);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "", name);
                if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "icon", ico); }
                if (admin == true) { cmd = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + @"\runasadmin.vbs"" " + cmd +arg; }
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc + "\\" + name, "command");
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name + "\\command", "", cmd);
                ff.listView8.Items.Add(name).SubItems.Add(cmd);
                ff.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                ff.listView8.Items[ff.listView8.Items.Count - 1].ImageIndex = ff.imageList_rmmgr_listimage.Images.Count - 1;
                ff.listView8.Items[ff.listView8.Items.Count - 1].Tag = new string[] { name, "HKLM," + loc + "," + name };
            }
        }
        void Create_AllDisk()
        {
            string loc = @"SOFTWARE\Classes\Drive\shell";
            RegistryKey root = Registry.LocalMachine;
            if (ishandler == false)
            {
                string name = sgTextBox1.Text;
                string cmd = sgTextBox2.Text;
                string ico = sgTextBox3.Text;
                bool admin = sgCheckBox1.Checked;
                string arg = sgTextBox_arg.Text;
                cmd = cmd + arg;
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc, name);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "", name);
                if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "icon", ico); }
                if (admin == true) { cmd = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + @"\runasadmin.vbs"" " + cmd; }
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc + "\\" + name, "command");
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name + "\\command", "", cmd);
                ff.listView8.Items.Add(name).SubItems.Add(cmd);
                ff.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                ff.listView8.Items[ff.listView8.Items.Count - 1].ImageIndex = ff.imageList_rmmgr_listimage.Images.Count - 1;
                ff.listView8.Items[ff.listView8.Items.Count - 1].Tag = new string[] { name, "HKLM," + loc + "," + name };
            }
        }
        void Create_EXE()
        {
            string loc = @"exefile\shell";
            RegistryKey root = Registry.ClassesRoot;
            if (ishandler == false)
            {
                string name = sgTextBox1.Text;
                string cmd = sgTextBox2.Text;
                string ico = sgTextBox3.Text;
                bool admin = sgCheckBox1.Checked;
                string arg = sgTextBox_arg.Text;
                cmd = cmd + arg;
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc, name);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "", name);
                if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "icon", ico); }
                if (admin == true) { cmd = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + @"\runasadmin.vbs"" " + cmd; }
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc + "\\" + name, "command");
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name + "\\command", "", cmd);
                ff.listView8.Items.Add(name).SubItems.Add(cmd);
                ff.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                ff.listView8.Items[ff.listView8.Items.Count - 1].ImageIndex = ff.imageList_rmmgr_listimage.Images.Count - 1;
                ff.listView8.Items[ff.listView8.Items.Count - 1].Tag = new string[]{name,"HKCR," + loc + "," + name};
            }
        }
        void Create_LNK()
        {
            string loc = @"lnkfile\shell";
            RegistryKey root = Registry.ClassesRoot;
            if (ishandler == false)
            {
                string name = sgTextBox1.Text;
                string cmd = sgTextBox2.Text;
                string ico = sgTextBox3.Text;
                bool admin = sgCheckBox1.Checked;
                string arg = sgTextBox_arg.Text;
                cmd = cmd + arg;
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc, name);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "", name);
                if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "icon", ico); }
                if (admin == true) { cmd = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + @"\runasadmin.vbs"" " + cmd; }
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc + "\\" + name, "command");
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name + "\\command", "", cmd);
                ff.listView8.Items.Add(name).SubItems.Add(cmd);
                ff.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                ff.listView8.Items[ff.listView8.Items.Count - 1].ImageIndex = ff.imageList_rmmgr_listimage.Images.Count - 1;
                ff.listView8.Items[ff.listView8.Items.Count - 1].Tag =new string[]{name,"HKCR," + loc + "," + name} ;
            }
        }
        void Create_TXT()
        {
            string loc = @"txtfile\shell";
            RegistryKey root = Registry.ClassesRoot;
            if (ishandler == false)
            {
                string name = sgTextBox1.Text;
                string cmd = sgTextBox2.Text;
                string ico = sgTextBox3.Text;
                bool admin = sgCheckBox1.Checked;
                string arg = sgTextBox_arg.Text;
                cmd = cmd + arg;
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc, name);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "", name);
                if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "icon", ico); }
                if (admin == true) { cmd = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + @"\runasadmin.vbs"" " + cmd; }
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc + "\\" + name, "command");
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name + "\\command", "", cmd);
                ff.listView8.Items.Add(name).SubItems.Add(cmd);
                ff.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                ff.listView8.Items[ff.listView8.Items.Count - 1].ImageIndex = ff.imageList_rmmgr_listimage.Images.Count - 1;
                ff.listView8.Items[ff.listView8.Items.Count - 1].Tag = new string[]{name,"HKCR," + loc + "," + name};
            }
        }
        void Create_DLL()
        {
            string loc = @"dllfile\shell";
            RegistryKey root = Registry.ClassesRoot;
            if (ishandler == false)
            {
                string name = sgTextBox1.Text;
                string cmd = sgTextBox2.Text;
                string ico = sgTextBox3.Text;
                bool admin = sgCheckBox1.Checked;
                string arg = sgTextBox_arg.Text;
                cmd = cmd + arg;
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc, name);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "", name);
                if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name, "icon", ico); }
                if (admin == true) { cmd = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + @"\runasadmin.vbs"" " + cmd; }
                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(root, loc + "\\" + name, "command");
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", root, loc + "\\" + name + "\\command", "", cmd);
                ff.listView8.Items.Add(name).SubItems.Add(cmd);
                ff.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                ff.listView8.Items[ff.listView8.Items.Count - 1].ImageIndex = ff.imageList_rmmgr_listimage.Images.Count - 1;
                ff.listView8.Items[ff.listView8.Items.Count - 1].Tag = new string[]{name,"HKCR," + loc + "," + name};
            }
        }
        void LoadMenu()
        {
            string name = ff.listView8.Items[select].Text;
            string cmd = ff.listView8.Items[select].SubItems[1].Text;
            string ico = tags[0];
            //check is exe without commandline
            cmd = SGFunction.PathOperate.ConvertStringToTurePath(cmd, cmd);
            sgTextBox2.Text = cmd;
            sgCheckBox1.Checked = false; sgCheckBox1.Visible = false;
            sgTextBox1.Text = name;
            sgTextBox3.Text = ico;
        }
        void EditMenu()
        {
            RegistryKey root=Registry.ClassesRoot;
            //分解数据
            string r = tags[1].Substring(0, tags[1].IndexOf(","));
            string location = tags[1].Substring(tags[1].IndexOf(",")+1, tags[1].LastIndexOf(",") - tags[1].IndexOf(",")-1);
            string subname= tags[1].Substring(tags[1].LastIndexOf(",")+1, tags[1].Length - tags[1].LastIndexOf(",")-1);
            switch(r.ToLower())
            {
                case"hkcr":
                    root = Registry.ClassesRoot;
                    break;
                case "hklm":
                    root = Registry.LocalMachine;
                    break;
            }
            //分析这个项目是句柄操作或者项目
            //判断是否有command
            RegistryKey cmd = root.OpenSubKey(location + "\\" + subname + "\\command");
            RegistryKey drop = root.OpenSubKey(location + "\\" + subname + "\\DropTarget");
            string writelocation = "";
            string writekeyname="";
            bool issystem = true;
            if(cmd !=null)
            {
                //string j=root.OpenSubKey(location + "\\" + subname + "\\command").GetValue("","").ToString();
                writelocation = location + "\\" + subname;
                writekeyname = "";
                issystem = false;
            }
                
            else
            {
                /*
                //可能是CLSID 右键菜单 DropTarget
                if(drop !=null)
                {
                    //dropta
                    //string j = drop.GetValue("CLSID", "").ToString();
                    writelocation = location + "\\" + subname + "\\DropTarget";
                    writekeyname = "CLSID";
                }
                else
                {
                   if(root.OpenSubKey(location+"\\"+subname).GetValue("muiverb","none").ToString() !="none" && root.OpenSubKey(location+"\\"+subname).GetValue("subcommands","none").ToString() !="none")
                   {
                       //右键菜单
                       //string j = root.OpenSubKey(location + "\\" + subname).GetValue("subcommands", "").ToString();
                       //MessageBox.Show(j);
                       writelocation = location + "\\" + subname;
                       writekeyname = "SubCommands";
                   }
                   else
                   {
                       //CLSID
                       string j = root.OpenSubKey(location + "\\" + subname).GetValue("", "").ToString();
                       //MessageBox.Show(j);
                       if(j!="")
                       {
                           writelocation = location + "\\" + subname;
                           writekeyname = "";
                       }
                       else
                       {
                           if(subname.Substring(0,1)=="{")
                           {
                               writelocation = location + "\\" + subname;
                               writekeyname = "";
                           }
                       }
                   }

                }
                */
            } 
            //写入cmd
            //只能编辑普通的命令
            if(issystem ==false)
            {
                int imi = ff.listView8.Items[select].ImageIndex;
                string ico = sgTextBox3.Text;
                string command = sgTextBox2.Text;
                if(sgCheckBox1.Visible ==true && sgCheckBox1.Checked ==true)
                {
                    command = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + @"\runasadmin.vbs"" " + command; 
                }
                if(sgTextBox3.Text == "") 
                { 
                    ico=Environment.GetFolderPath(Environment.SpecialFolder.System)+ @"\imageres.dll,2"; 
                }
                root.OpenSubKey(writelocation + "\\command", true).SetValue(writekeyname, command);
                root.OpenSubKey(writelocation, true).SetValue("", sgTextBox1.Text);
                root.OpenSubKey(writelocation, true).SetValue("icon", ico);
                ff.imageList_rmmgr_listimage.Images[imi] = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico);
                ff.listView8.Items[select].Text = sgTextBox1.Text;
                ff.listView8.Items[select].SubItems[1].Text = command;
                string[] gg = (string[])ff.listView8.Items[select].Tag;
                gg = new string[] { ico, gg[1] };
                ff.listView8.Items[select].Tag = gg;
            }
            else
            {

            }
        }
        bool GetMenuType_IsSystem()
        {
            RegistryKey root = Registry.ClassesRoot;
            //分解数据
            string r = tags[1].Substring(0, tags[1].IndexOf(","));
            string location = tags[1].Substring(tags[1].IndexOf(",") + 1, tags[1].LastIndexOf(",") - tags[1].IndexOf(",") - 1);
            string subname = tags[1].Substring(tags[1].LastIndexOf(",") + 1, tags[1].Length - tags[1].LastIndexOf(",") - 1);
            switch (r.ToLower())
            {
                case "hkcr":
                    root = Registry.ClassesRoot;
                    break;
                case "hklm":
                    root = Registry.LocalMachine;
                    break;
            }
            //分析这个项目是句柄操作或者项目
            //判断是否有command
            RegistryKey cmd = root.OpenSubKey(location + "\\" + subname + "\\command");
            RegistryKey drop = root.OpenSubKey(location + "\\" + subname + "\\DropTarget");
            string writelocation = "";
            string writekeyname = "";
            bool issystem = true;
            Color warr = Color.FromArgb(239, 156, 0);
            if (cmd != null)
            {
                //string j=root.OpenSubKey(location + "\\" + subname + "\\command").GetValue("","").ToString();
                writelocation = location + "\\" + subname + "\\command";
                writekeyname = "";
                issystem = false;
            }
            else
            {
                //可能是CLSID 右键菜单 DropTarget
                if (drop != null)
                {
                    //dropta
                    //string j = drop.GetValue("CLSID", "").ToString();
                    writelocation = location + "\\" + subname + "\\DropTarget";
                    writekeyname = "CLSID";
                }
                else
                {
                    if (root.OpenSubKey(location + "\\" + subname).GetValue("muiverb", "none").ToString() != "none" && root.OpenSubKey(location + "\\" + subname).GetValue("subcommands", "none").ToString() != "none")
                    {
                        //右键菜单
                        //string j = root.OpenSubKey(location + "\\" + subname).GetValue("subcommands", "").ToString();
                        //MessageBox.Show(j);
                        writelocation = location + "\\" + subname;
                        writekeyname = "SubCommands";
                    }
                    else
                    {
                        //CLSID
                        string j = root.OpenSubKey(location + "\\" + subname).GetValue("", "").ToString();
                        //MessageBox.Show(j);
                        if (j != "")
                        {
                            writelocation = location + "\\" + subname;
                            writekeyname = "";
                        }
                        else
                        {
                            if (subname.Substring(0, 1) == "{")
                            {
                                writelocation = location + "\\" + subname;
                                writekeyname = "";
                            }
                        }
                    }

                }
            }
            //判断是否是系统自带的
            return issystem;
        }

        private void MyNormalButton5_Click(object sender, EventArgs e)
        {
            string file = SGFunction.CommonDialogs.OpenFileDialog("选择文件", "所有文件(*.*)|*.*");
            if (file != "")
            {
                sgTextBox2.Text = @""""+file+@"""";
                sgCheckBox1.Visible = true;
                string ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(file).ToLower();
                if (ext == "exe")
                {
                    sgTextBox3.Text = file + ",0";
                }
            }
        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            string res;
            string file = SGFunction.CommonDialogs.SelectIconDialog("选择菜单的图标", sgTextBox3.Text, out res);
            if (res == "ok")
            {
                sgTextBox3.Text = file;
            }
        }

        private void SGUserControl_CreateRightMenu_Load(object sender, EventArgs e)
        {

        }

        private void MyNormalButton4_Click(object sender, EventArgs e)
        {
            string res;
            bool hasrun=true;
            //if (type == "edit") { hasrun = false; }
            string[] arr = SGFunction.CommonDialogs.ShowMoreFunctionDialog("选择常用的操作", out res,"normal",hasrun);
            if (res == "ok")
            {
                string name = arr[0];
                string app = arr[1];
                string arg = arr[2];
                string admin = arr[4];
                string ico = arr[3];
                switch (type)
                {
                    case "create":
                        sgTextBox1.Text = name;
                        sgTextBox2.Text = @"""" + app + @""" " + arg;
                        sgTextBox3.Text = ico;
                        if (admin.ToUpper() == "TRUE") { sgCheckBox1.Checked = true; } else { sgCheckBox1.Checked = false; }
                        break;
                    case "edit":
                        sgTextBox1.Text = name;
                        sgTextBox2.Text = @"""" + app + @""" " + arg;
                        sgTextBox3.Text = ico;
                        if(admin.ToUpper()=="TRUE")
                        {
                            SGFunction.ScriptOperate.CreateRunAsAdminVBS();
                            string vbs = SGFunction.Resources.GetResourcePath("runasadminvbs");
                            sgTextBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + vbs + @""" " + sgTextBox2.Text;
                        }
                        break;
                    case "create_sendto":
                        sgTextBox1.Text = name;
                        sgTextBox2.Text = app;
                        sgTextBox3.Text = ico;
                        sgTextBox_arg.Text = arg;
                        if (admin.ToUpper() == "TRUE") { sgCheckBox1.Checked = true; } else { sgCheckBox1.Checked = false; }
                        break;
                    case "edit_sendto":
                        sgTextBox1.Text = name;
                        sgTextBox2.Text = app;
                        sgTextBox3.Text = ico;
                        sgTextBox_arg.Text = arg;
                        if (admin.ToUpper() == "TRUE") { sgCheckBox1.Checked = true; } else { sgCheckBox1.Checked = false; }
                        break;
                    case "create_selectext":
                        sgTextBox1.Text = name;
                        sgTextBox2.Text = @"""" + app + @""" " + arg;
                        sgTextBox3.Text = ico;
                        if (admin.ToUpper() == "TRUE") { sgCheckBox1.Checked = true; } else { sgCheckBox1.Checked = false; }
                        break;
                    case "edit_selectext":
                        sgTextBox1.Text = name;
                        sgTextBox2.Text = @"""" + app + @""" " + arg;
                        sgTextBox3.Text = ico;
                        if (admin.ToUpper() == "TRUE") { sgCheckBox1.Checked = true; } else { sgCheckBox1.Checked = false; }
                        break;
                }
            }
        }
    }
}
