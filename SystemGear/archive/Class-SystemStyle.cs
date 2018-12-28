using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using System.Threading;
using System.Diagnostics;

namespace SystemGear
{
    class Class_SystemStyle
    {
        public static void SystemStyle_LoadDesktopIcon(UserControl_SystemStyle_SystemView usercon)
        {
            Application.DoEvents();
            usercon.pictureBox1.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile , "SystemIcon_UsersFiles", false);
            usercon.pictureBox2.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile , "SystemIcon_MYCOMPUTER", false);
            usercon.pictureBox3.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile , "SystemIcon_NETWORK", false);
            usercon.pictureBox5.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile , "SystemIcon_RECYCLEBIN", false);
            usercon.pictureBox4.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile , "SystemIcon_CONTROLPANEL", false);
            usercon.pictureBox6.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile , "SystemIcon_IE", false);
        }
        public static void SystemStyle_Enter(int FirstIndex, int SecondIndex, int ThirdIndex, Form_SystemStyle frm)
        {
            switch (FirstIndex)
            {
                case 1:
                    frm.chooseuser = "SYSVIE";
                    frm.label1.Text = "系统齿轮 系统美化";
                    frm.label2.Text = " 系统美化";
                    UserControl_SystemStyle_SystemView us = new UserControl_SystemStyle_SystemView(SecondIndex, ThirdIndex);
                    frm.panel2.Controls.Add(us);
                    us.Location = new Point(0, 0);
                    frm.pictureBox1.Visible = true;
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
        public static void SystemStyle_GetDesktopIconShowOrHideMode(Form_SystemStyle frm_load, UserControl_SystemStyle_SystemView user)
        {
            string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
            string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
            string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
            string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
            string IEGUID = "{BDA87F4F-C3AF-4E08-8167-1B10FC09B081}";
            string SubKeys = @"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel";
            //获取UF
            if (MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, SubKeys, UFGUID, "1", false, false) != "1")
            {
                user.button6.Location = new Point(50, 0);
                user.button6.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                user.button6.ForeColor = Color.White;
                //user.label11.Text = "已隐藏";
                user.button6.Text = "隐藏";
            }
            else
            {
                user.button6.Location = new Point(0, 0);
                user.button6.BackColor = Color.FromArgb(205, 205, 205);
                user.button6.ForeColor = Color.Black;
                //user.label11.Text = "已显示";
                user.button6.Text = "显示";
            }
            //获取MC
            if (MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, SubKeys, MCGUID, "1", false, false) != "1")
            {
                user.button7.Location = new Point(50, 0);
                user.button7.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                user.button7.ForeColor = Color.White;
                //user.label12.Text = "已隐藏";
                user.button7.Text = "隐藏";
            }
            else
            {
                user.button7.Location = new Point(0, 0);
                user.button7.BackColor = Color.FromArgb(205, 205, 205);
                user.button7.ForeColor = Color.Black;
                //user.label12.Text = "已显示";
                user.button7.Text = "显示";
            }
            //获取NK
            if (MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, SubKeys, NKGUID, "1", false, false) != "1")
            {
                user.button8.Location = new Point(50, 0);
                user.button8.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                user.button8.ForeColor = Color.White;
                //user.label13.Text = "已隐藏";
                user.button8.Text = "隐藏";
            }
            else
            {
                user.button8.Location = new Point(0, 0);
                user.button8.BackColor = Color.FromArgb(205, 205, 205);
                user.button8.ForeColor = Color.Black;
                //user.label13.Text = "已显示";
                user.button8.Text = "显示";
            }
            //获取CP
            if (MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, SubKeys, CPGUID, "1", false, false) != "1")
            {
                user.button9.Location = new Point(50, 0);
                user.button9.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                user.button9.ForeColor = Color.White;
                //user.label14.Text = "已隐藏";
                user.button9.Text = "隐藏";
            }
            else
            {
                user.button9.Location = new Point(0, 0);
                user.button9.BackColor = Color.FromArgb(205, 205, 205);
                user.button9.ForeColor = Color.Black;
                //user.label14.Text = "已显示";
                user.button9.Text = "显示";
            }
            //获取rb
            if (MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, SubKeys, RBGUID, "1", false, false) != "1")
            {
                user.button10.Location = new Point(50, 0);
                user.button10.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                user.button10.ForeColor = Color.White;
                //user.label15.Text = "已隐藏";
                user.button10.Text = "隐藏";
            }
            else
            {
                user.button10.Location = new Point(0, 0);
                user.button10.BackColor = Color.FromArgb(205, 205, 205);
                user.button10.ForeColor = Color.Black;
                //user.label15.Text = "已隐藏";
                user.button10.Text = "显示";
            }
            //获取ie
            if (null == Registry.ClassesRoot.OpenSubKey(@"clsid\" + IEGUID) || null == Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\" + IEGUID))
            {
                user.button11.Location = new Point(0, 0);
                user.button11.BackColor = Color.FromArgb(205, 205, 205);
                user.button11.ForeColor = Color.Black;
                //user.label16.Text = "已显示";
                user.button11.Text = "显示";
            }
            else
            {
                user.button11.Location = new Point(50, 0);
                user.button11.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                user.button11.ForeColor = Color.White;
                //user.label16.Text = "已隐藏";
                user.button11.Text = "隐藏";
            }
        }
        public static void SystemStyle_GetPowerButtonShowOrHideType(UserControl_SystemStyle_SystemView user)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\关闭计算机.lnk") == false || SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\关闭计算机.lnk") != true)
            {
                user.button27.Location = new Point(0, 0);
                user.button27.Text = "显示";
                user.button27.ForeColor = Color.Black;
                user.button27.BackColor = Color.FromArgb(205, 205, 205);
            }
            else
            {
                user.button27.Location = new Point(50, 0);
                user.button27.Text = "隐藏";
                user.button27.ForeColor = Color.White;
                user.button27.BackColor = Color.FromArgb(0, 148, 255);
            }
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\重启计算机.lnk") != true || SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\重启计算机.lnk") != true)
            {
                user.button26.Location = new Point(0, 0);
                user.button26.Text = "显示";
                user.button26.ForeColor = Color.Black;
                user.button26.BackColor = Color.FromArgb(205, 205, 205);
            }
            else
            {
                user.button26.Location = new Point(50, 0);
                user.button26.Text = "隐藏";
                user.button26.ForeColor = Color.White;
                user.button26.BackColor = Color.FromArgb(0, 148, 255);
            }
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\锁定计算机.lnk") != true || SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\锁定计算机.lnk") != true)
            {
                user.button24.Location = new Point(0, 0);
                user.button24.Text = "显示";
                user.button24.ForeColor = Color.Black;
                user.button24.BackColor = Color.FromArgb(205, 205, 205);
            }
            else
            {
                user.button24.Location = new Point(50, 0);
                user.button24.Text = "隐藏";
                user.button24.ForeColor = Color.White;
                user.button24.BackColor = Color.FromArgb(0, 148, 255);
            }
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\注销登录.lnk") != true || SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\注销登录.lnk") != true)
            {
                user.button23.Location = new Point(0, 0);
                user.button23.Text = "显示";
                user.button23.ForeColor = Color.Black;
                user.button23.BackColor = Color.FromArgb(205, 205, 205);
            }
            else
            {
                user.button23.Location = new Point(50, 0);
                user.button23.Text = "隐藏";
                user.button23.ForeColor = Color.White;
                user.button23.BackColor = Color.FromArgb(0, 148, 255);
            }
        }
        public static void SystemStyle_SetDesktopIcon(Form_SystemStyle obj, UserControl_SystemStyle_SystemView user, string IconType, string SetType) //更改桌面图标的显示状态
        {
            string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
            string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
            string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
            string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
            string IEGUID = "{4B6C7757-AAF6-46AF-A2D2-D31CEE866228}";
            string SubKeys = @"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel";
            string SubKeysIE = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace";
            string Value = "0";
            if (SetType.ToUpper() == "HIDE")
            {
                Value = "1";
            }
            switch (IconType.ToUpper())
            {
                case "IE":
                    if (Value == "0")
                    {
                        RegistryKey RootKey = Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID);
                        if (null == RootKey)
                        {
                            Registry.ClassesRoot.OpenSubKey("CLSID", true).CreateSubKey(IEGUID).SetValue("", "Internet Explorer", RegistryValueKind.String);
                        }
                        else
                        {
                        }
                        Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID, true).CreateSubKey("Shell").CreateSubKey("Open").CreateSubKey("Command").SetValue("", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\IEXPLORE.EXE", RegistryValueKind.String);
                        Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID + @"\Shell", true).CreateSubKey("NoAddNos").CreateSubKey("Command").SetValue("", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\IEXPLORE.EXE -extoff", RegistryValueKind.String);
                        Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID + @"\Shell", true).CreateSubKey("Set").CreateSubKey("Command").SetValue("", Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\RunDll32.exe " + Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Shell32.dll,Control_RunDLL " + Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\inetcpl.cpl", RegistryValueKind.String);
                        //
                        Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID + @"\Shell", true).OpenSubKey("Open", true).SetValue("", "打开主页(&H)", RegistryValueKind.String);
                        Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID + @"\Shell", true).OpenSubKey("NoAddNos", true).SetValue("", "在没有加载项的情况下启动(&N)", RegistryValueKind.String);
                        Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID + @"\Shell", true).OpenSubKey("Set", true).SetValue("", "Internet 属性(&R)", RegistryValueKind.String);
                        //
                        Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID, true).CreateSubKey("DefaultIcon").SetValue("", Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Ieframe.dll,18", RegistryValueKind.String);
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, SubKeysIE, IEGUID, false);
                        Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\" + IEGUID, true).SetValue("", "Internet Explorer", RegistryValueKind.String);
                    }
                    else
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, SubKeysIE, IEGUID, false);
                    }
                    break;
                case "RB":
                    if (Value == "0")
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, SubKeys, RBGUID, "0", RegistryValueKind.DWord, false, false);
                    }
                    else
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, SubKeys, RBGUID, "1", RegistryValueKind.DWord, false, false);
                    }
                    break;
                case "UF":
                    if (Value == "0")
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, SubKeys, UFGUID, "0", RegistryValueKind.DWord, false, false);
                    }
                    else
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, SubKeys, UFGUID, "1", RegistryValueKind.DWord, false, false);
                    }
                    break;
                case "NK":
                    if (Value == "0")
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, SubKeys, NKGUID, "0", RegistryValueKind.DWord, false, false);
                    }
                    else
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, SubKeys, NKGUID, "1", RegistryValueKind.DWord, false, false);
                    }
                    break;
                case "CP":
                    if (Value == "0")
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, SubKeys, CPGUID, "0", RegistryValueKind.DWord, false, false);
                    }
                    else
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, SubKeys, CPGUID, "1", RegistryValueKind.DWord, false, false);
                    }
                    break;
                case "MC":
                    if (Value == "0")
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, SubKeys, MCGUID, "0", RegistryValueKind.DWord, false, false);
                    }
                    else
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, SubKeys, MCGUID, "1", RegistryValueKind.DWord, false, false);
                    }
                    break;
            }
            Class_SystemStyle.SystemStyle_GetDesktopIconShowOrHideMode(obj, user);
            MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
        }
        public static void SystemStyle_SetPowerIcon(string Type, string CreateOrDelete, bool HybridStart, bool CreateStartMenu, UserControl_SystemStyle_SystemView user)
        {
            string LINK_NAME = "";
            string LINK_COMMAND = "";
            string LINK_ARGS = "";
            string INFO = "";
            string icon = "";
            switch (Type.ToUpper())
            {
                case "PO":
                    if (CreateOrDelete.ToUpper() == "CREATE")
                    {
                        LINK_NAME = "关闭计算机.lnk";
                        string newcmd = "-s -f -t 0";
                        string newinfo = "结束所有任务并关闭计算机";
                        if (HybridStart == true)
                        {
                            newcmd = "-s -hybrid -f -t 0";
                            newinfo = "结束所有任务并关闭计算机(启用混合硬盘启动技术)";
                        }
                        LINK_COMMAND = @"%SystemRoot%\System32\Shutdown.exe";
                        LINK_ARGS = newcmd;
                        icon = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.IconResources, "POWEROFF", false);
                        INFO = newinfo;
                    }
                    else
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\关闭计算机.lnk");
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\关闭计算机.lnk");
                    }
                    break;
                case "RE":
                    if (CreateOrDelete.ToUpper() == "CREATE")
                    {
                        LINK_NAME = "重启计算机.lnk";
                        string newcmd = "-r -f -t 0";
                        string newinfo = "结束所有任务并重启计算机";
                        LINK_COMMAND = @"%SystemRoot%\System32\Shutdown.exe";
                        LINK_ARGS = newcmd;
                        INFO = newinfo;
                        icon  = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.IconResources,"restart",false);
                    }
                    else
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\重启计算机.lnk");
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\重启计算机.lnk");
                    }
                    break;
                case "LO":
                    if (CreateOrDelete.ToUpper() == "CREATE")
                    {
                        LINK_NAME = "注销登录.lnk";
                        string newcmd = "-l";
                        string newinfo = "注销当前的用户登录";
                        LINK_COMMAND = @"%SystemRoot%\System32\Shutdown.exe";
                        LINK_ARGS = newcmd;
                        INFO = newinfo;
                        icon = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.IconResources, "logoff", false);
                    }
                    else
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\注销登录.lnk");
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\注销登录.lnk");
                    }
                    break;
                case "LC":
                    if (CreateOrDelete.ToUpper() == "CREATE")
                    {
                        LINK_NAME = "锁定计算机.lnk";
                        string newcmd = "user32.dll,LockWorkStation";
                        string newinfo = "锁定计算机(不会丢失数据)";
                        LINK_COMMAND = @"%SystemRoot%\System32\rundll32.exe";
                        LINK_ARGS = newcmd;
                        INFO = newinfo;
                        icon = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.IconResources, "lockcomputer", false);
                    }
                    else
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\锁定计算机.lnk");
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\锁定计算机.lnk");
                    }
                    break;
            }
            if (CreateOrDelete.ToUpper() == "CREATE")
            {
                MyFunctions.ProgramAndLinksOperate.CreateLink(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + LINK_NAME, LINK_COMMAND, LINK_ARGS, INFO,  icon, user.FindForm());
                if (CreateStartMenu == true)
                {
                    MyFunctions.ProgramAndLinksOperate.CreateLink(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs" + @"\" + LINK_NAME, LINK_COMMAND, LINK_ARGS, INFO, icon, user.FindForm());
                }
            }
            Class_SystemStyle.SystemStyle_GetPowerButtonShowOrHideType(user);
        }
        public static void SystemStyle_LoadGUIDConfigFileToTreeview(string FileName, UserControl_SystemStyle_SystemView user)
        {
            try
            {
                user.treeView1.Nodes.Clear();
                user.imageList1.Images.Clear();
                user.textBox1.Text = "";
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(FileName) == true)
                {
                    user.treeView1.Nodes.Add(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "", false, FileName));
                    user.imageList1.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", "", false, FileName), Application.ExecutablePath+",0"));
                    user.treeView1.Nodes[0].SelectedImageIndex = 0;
                    //user.treeView1.Nodes[0].StateImageIndex = 0;
                    user.treeView1.Nodes[0].ImageIndex = 0;
                    user.treeView1.Nodes[0].Tag = "Main";
                    user.treeView1.Nodes[0].ContextMenuStrip = user.contextMenuStrip1;
                    int cmdcount = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", false, FileName), 0);
                    if (cmdcount > 0)
                    {
                        for (int j = 1; j <= cmdcount; j = j + 1)
                        {
                            user.treeView1.Nodes[0].Nodes.Add(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + j.ToString(), "name", "", false, FileName));
                            user.imageList1.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + j.ToString(), "icon", Application.ExecutablePath+",0", true, FileName), Application.ExecutablePath+",0"));
                            user.treeView1.Nodes[0].Nodes[j - 1].ImageIndex = j;
                            user.treeView1.Nodes[0].Nodes[j - 1].SelectedImageIndex = j;
                            //user.treeView1.Nodes[0].Nodes[j - 1].StateImageIndex = j ;
                            user.treeView1.Nodes[0].Nodes[j - 1].Tag = "Command" + j.ToString();
                            user.treeView1.Nodes[0].Nodes[j - 1].ContextMenuStrip = user.contextMenuStrip1;
                            Application.DoEvents();
                        }
                        user.treeView1.ExpandAll();
                        user.treeView1.Focus();
                        user.textBox1.Text = FileName;
                    }
                    else
                    {
                        user.textBox1.Text = FileName;
                    }
                }
                else
                {
                    if (FileName != "")
                    {
                        MyFunctions.Dialogs.MessageDialog("无法读取配置文件的信息", "无法读取指定的配置文件信息,请检查文件是否存在以及系统对该文件访问权限.", MyFunctions.Dialogs.MessageDialogIcon.Error, "无法读取指定的文件 " + FileName, "b2", false, true, "", "确定");
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "GUIDConfigFile", @"%AppPath%\Config\DefaultGUIDIconConfigFile.sgcf", "Config", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                        Class_SystemStyle.SystemStyle_CreateDefaultGUIDIconConfigFile();
                        Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(Application.StartupPath + @"\Config\DefaultGUIDIconConfigFile.sgcf", user);
                    }
                    else
                    { SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "GUIDConfigFile", @"%AppPath%\Config\DefaultGUIDIconConfigFile.sgcf", "Config", true, Application.StartupPath + @"\Config\MainProgram.sgcf"); Class_SystemStyle.SystemStyle_CreateDefaultGUIDIconConfigFile(); }
                    Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(Application.StartupPath + @"\Config\DefaultGUIDIconConfigFile.sgcf", user);
                }
            }
            catch
            {
                user.treeView1.Nodes.Clear();
                user.imageList1.Images.Clear();
                user.textBox1.Text = "";
                MyFunctions.Dialogs.MessageDialog("无法读取配置文件的信息", "无法读取指定的配置文件信息,请检查文件是否存在以及系统对该文件访问权限.", MyFunctions.Dialogs.MessageDialogIcon.Error, "无法读取指定的文件 " + FileName, "b2", false, true, "", "确定");
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "GUIDConfigFile", @"%AppPath%\Config\DefaultGUIDIconConfigFile.sgcf", "Config", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                Class_SystemStyle.SystemStyle_CreateDefaultGUIDIconConfigFile();
                Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(Application.StartupPath + @"\Config\DefaultGUIDIconConfigFile.sgcf", user);
            }
        }
        public static void SystemStyle_LoadRightMenuGroupToTreeview(string FileName, UserControl_SystemStyle_SystemView user)
        {
            try
            {
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(FileName) == true)
                {
                    user.treeView2.Nodes.Clear();
                    user.imageList3.Images.Clear();
                    user.textBox12.Text = FileName;
                    string mainname = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "", false, FileName);
                    string mainnicon = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", Application.ExecutablePath+",0", true, FileName);
                    user.treeView2.Nodes.Add(mainname);
                    user.imageList3.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(mainnicon, Application.ExecutablePath+@",0"));
                    user.treeView2.Nodes[0].ImageIndex = 0;
                    user.treeView2.Nodes[0].SelectedImageIndex = 0;
                    user.treeView2.Nodes[0].Tag = "MAIN";
                    int cmdcount = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", false, FileName), 0);
                    if (cmdcount > 0)
                    {
                        for (int h = 1; h <= cmdcount; h = h + 1)
                        {
                            string cmdname = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + h.ToString(), "name", "", false, FileName);
                            string cmdicon = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + h.ToString(), "icon", "", false, FileName);
                            cmdicon = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(cmdicon, cmdicon);
                            string isfengefu = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + h.ToString(), "isfengefu", "", false, FileName);
                            if (isfengefu.ToUpper() == "T")
                            {
                                cmdicon = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.IconResources, "RightMenuGroup_Fengefu", false);
                                cmdname = "分隔符";
                            }
                            user.treeView2.Nodes[0].Nodes.Add(cmdname);
                            user.imageList3.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(cmdicon, Application.ExecutablePath+",0"));
                            user.treeView2.Nodes[0].Nodes[h - 1].ImageIndex = h;
                            user.treeView2.Nodes[0].Nodes[h - 1].SelectedImageIndex = h;
                            user.treeView2.Nodes[0].Nodes[h - 1].Tag = "COMMAND" + h.ToString();
                            user.treeView2.Nodes[0].Nodes[h - 1].ContextMenuStrip = user.contextMenuStrip3;
                            Application.DoEvents();
                        }
                        user.treeView2.ExpandAll();
                        user.treeView2.Focus();
                    }
                }
                else
                {
                    if (FileName != "")
                    {
                        user.treeView2.Nodes.Clear();
                        user.imageList3.Images.Clear();
                        user.textBox12.Text = "";
                        MyFunctions.Dialogs.MessageDialog("无法读取配置文件的信息", "无法读取指定的配置文件信息,请检查文件是否存在以及系统对该文件访问权限.", MyFunctions.Dialogs.MessageDialogIcon.Error, "无法读取指定的文件 " + FileName, "b2", false, true, "", "确定");
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "RightMenuGroupConfigFile", @"%AppPath%\Config\DefaultRightMenuGroup.sgcf", "Config", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                        Class_SystemStyle.SystemStyle_CreateDefaultRightMenuConfigFile();
                        Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(Application.StartupPath + @"\Config\DefaultRightMenuGroup.sgcf", user);
                    }
                    else
                    {
                        user.treeView2.Nodes.Clear();
                        user.imageList3.Images.Clear();
                        user.textBox12.Text = "";
                        //MyFunctions.Dialogs.MessageDialog("无法读取配置文件的信息", "无法读取指定的配置文件信息,请检查文件是否存在以及系统对该文件访问权限.", MyFunctions.Dialogs.MessageDialogIcon.Error, "无法读取指定的文件 " + FileName, "b2", false, true, "", "确定", user.FindForm());
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "RightMenuGroupConfigFile", @"%AppPath%\Config\DefaultRightMenuGroup.sgcf", "Config", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                        Class_SystemStyle.SystemStyle_CreateDefaultRightMenuConfigFile();
                        Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(Application.StartupPath + @"\Config\DefaultRightMenuGroup.sgcf", user);
                    }
                }
            }
            catch
            {
                user.treeView2.Nodes.Clear();
                user.imageList3.Images.Clear();
                user.textBox12.Text = "";
                MyFunctions.Dialogs.MessageDialog("无法读取配置文件的信息", "无法读取指定的配置文件信息,请检查文件是否存在以及系统对该文件访问权限.", MyFunctions.Dialogs.MessageDialogIcon.Error, "无法读取指定的文件 " + FileName, "b2", false, true, "", "确定");
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "GUIDConfigFile", @"%AppPath%\Config\DefaultRightMenuGroup.sgcf", "Config", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                Class_SystemStyle.SystemStyle_CreateDefaultRightMenuConfigFile();
                Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(Application.StartupPath + @"\Config\DefaultRightMenuGroup.sgcf", user);
            }
        }
        public static void SystemStyle_CreateDefaultGUIDIconConfigFile()
        {
            try
            {
                MyFunctions.FileSystemOperate.FileSystemOperate_GetFolderExists(Application.StartupPath + @"\Config", true);
                bool old = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(Application.StartupPath + @"\Config\DefaultGUIDIconConfigFile.sgcf");
                if (old == true)
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Application.StartupPath + @"\Config\DefaultGUIDIconConfigFile.sgcf");
                }
                //使用“另存为”对话框中输入的文件名实例化StreamWriter对象
                StreamWriter sw = new StreamWriter(Application.StartupPath + @"\Config\DefaultGUIDIconConfigFile.sgcf", true, Encoding.Unicode);
                //向创建的文件中写入内容
                sw.WriteLine(Properties.Resources.DefaultGUIDIconConfigFile);
                //关闭当前文件写入流
                sw.Close();
                //
                if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.2" || MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3")
                {
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command16", "Command", "Shutdown.exe -s -hybrid -f -t 0", "GUIDIcon", false, Application.StartupPath + @"\Config\DefaultGUIDIconConfigFile.sgcf");
                }
            }
            catch
            {
            }
        }
        public static void SystemStyle_CreateDefaultRightMenuConfigFile()
        {
            try
            {
                MyFunctions.FileSystemOperate.FileSystemOperate_GetFolderExists(Application.StartupPath + @"\Config", true);
                bool old = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(Application.StartupPath + @"\Config\DefaultRightMenuGroup.sgcf");
                if (old == true)
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Application.StartupPath + @"\Config\DefaultRightMenuGroup.sgcf");
                }
                //使用“另存为”对话框中输入的文件名实例化StreamWriter对象
                StreamWriter sw = new StreamWriter(Application.StartupPath + @"\Config\DefaultRightMenuGroup.sgcf", true, Encoding.Unicode);
                //向创建的文件中写入内容
                sw.WriteLine(Properties.Resources.DefaultRightMenuGroup);
                //关闭当前文件写入流
                sw.Close();
                //
                if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.2" || MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3")
                {
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command14", "Command", "Shutdown.exe -s -hybrid -f -t 0", "RightMenuGroup", false, Application.StartupPath + @"\Config\DefaultRightMenuGroup.sgcf");
                }
            }
            catch
            {
            }
        }
        public static void RightMenu_CreateRightMenuGroup(string FileName)
        {
            try
            {
                if (System.IO.File.Exists(FileName) == true)
                {
                    string CommandItems = "";
                    int CommandsNum = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", false, FileName), 0);
                    string MainName = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "regname", "", false, FileName);
                    for (int j = 1; j <= CommandsNum; j = j + 1)
                    {

                        if (MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + j.ToString(), "isfengefu", "F", false, FileName).ToUpper() == "F")
                        {
                            CommandItems = CommandItems + MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + j.ToString(), "REGNAME", "", false, FileName) + @";";
                        }
                        else
                        {
                            CommandItems = CommandItems + "|;";
                        }
                    }
                    ///
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"*\Shell", MainName, false);
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\background\shell", MainName, false);
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\shell", MainName, false);
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"LibraryFolder\background\shell", MainName, false);
                    MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"*\Shell", MainName, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"*\Shell\" + MainName, "Icon", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", Application.ExecutablePath+",0", true, FileName), RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"*\Shell\" + MainName, "MUIVerb", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "系统齿轮右键菜单组", true, FileName), RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"*\Shell\" + MainName, "SubCommands", CommandItems, RegistryValueKind.String, false, false);
                    ///
                    MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"Directory\background\shell\", MainName, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "Icon", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", Application.ExecutablePath+",0", true, FileName), RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "MUIVerb", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "系统齿轮右键菜单组", true, FileName), RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "SubCommands", CommandItems, RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "Position", "Top", RegistryValueKind.String, false, false);
                    ///
                    MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"Directory\shell\", MainName, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\shell\" + MainName, "Icon", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", Application.ExecutablePath+",0", true, FileName), RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\shell\" + MainName, "MUIVerb", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "系统齿轮右键菜单组", true, FileName), RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\shell\" + MainName, "SubCommands", CommandItems, RegistryValueKind.String, false, false);
                    ///
                    MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"LibraryFolder\background\shell\", MainName, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"LibraryFolder\background\shell\" + MainName, "Icon", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", Application.ExecutablePath+",0", true, FileName), RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"LibraryFolder\background\shell\" + MainName, "MUIVerb", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "系统齿轮右键菜单组", true, FileName), RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"LibraryFolder\background\shell\" + MainName, "SubCommands", CommandItems, RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"LibraryFolder\background\shell\" + MainName, "Position", "Top", RegistryValueKind.String, false, false);
                    MyFunctions.StreamAndTextOperate.TextOperate.CreateRunAsAdminVBS();
                    for (int p = 1; p <= CommandsNum; p = p + 1)
                    {
                        string CMDREGName = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "REGNAME", "", false, FileName);
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell", CMDREGName, false);
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\" + CMDREGName, "Command", false);
                        string N_CMD = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "command", "", true, FileName);
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\" + CMDREGName, "", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "name", "", false, FileName), RegistryValueKind.String, false, false);
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\" + CMDREGName, "Icon", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "icon", "", true, FileName), RegistryValueKind.ExpandString, false, false);
                        if (MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "runasadmin", "", false, FileName).ToUpper() == "T")
                        {
                            N_CMD = @"%SystemRoot%\System32\wscript.exe """ + Application.StartupPath + @"\Programs\RunAsAdmin.vbs"" " + MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "command", "", true, FileName);
                        }
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\" + CMDREGName + @"\Command", "", N_CMD, RegistryValueKind.ExpandString, false, false);

                    }
                    //Class_Function.PublicDialog_MessageBox("已成功生成右键菜单", "已成功生成右键菜单。", MyFunctions.Dialogs.MessageDialogIcon.Information, false, true, "", "确定", false, "", Obj.Location.X, Obj.Location.Y, Obj.Size.Width, Obj.Size.Height, true);
                }
                else
                {
                    //Class_Function.PublicDialog_MessageBox("读取配置文件错误", "读取配置文件错误：缺少必要的信息或文件不存在。请选择一个正确的文件。", MyFunctions.Dialogs.MessageDialogIcon.Error, false, true, "", "确定", false, "", Obj.Location.X, Obj.Location.Y, Obj.Size.Width, Obj.Size.Height, true);
                }
            }
            catch
            {
                //Class_Function.PublicDialog_MessageBox("读取配置文件错误", "读取配置文件错误：缺少必要的信息或文件不存在。请选择一个正确的文件。", MyFunctions.Dialogs.MessageDialogIcon.Error, false, true, "", "确定", false, "", Obj.Location.X, Obj.Location.Y, Obj.Size.Width, Obj.Size.Height, true);
            }
        }
        public static void SystemStyle_LoadOEMAndSystemInfo(UserControl_SystemStyle_SystemView user)
        {
            try
            {
                string oemname = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Manufacturer", "", false, false);
                string oemurl = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportURL", "", false, false);
                string oemphone = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Supportphone", "", false, false);
                string oemhour = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportHours", "", false, false);
                string cmpmodel = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "model", "", false, false);
                string oemlog = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "logo", "", false, false);
                //////////////////////////////
                string sys_reguser = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOwner", "", false, false);
                string sys_name = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "", false, false);
                string sys_Installpath = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SourcePath", "", false, false);
                string sys_regcompany = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOrganization", "", false, false);
                string sys_version = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentVersion", "", false, false);
                string sys_id = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductID", "", false, false);
                if (File.Exists(oemlog) == true)
                {
                    user.pictureBox46.Image = Image.FromFile(oemlog);
                }
                else
                {
                    if (System.IO.File.Exists(Environment.GetEnvironmentVariable("systemdrive") + oemlog) == true)
                    {
                        user.pictureBox46.Image = Image.FromFile(Environment.GetEnvironmentVariable("systemdrive") + oemlog);
                    }
                }
                user.textBox9.Text = oemname;
                user.textBox15.Text = oemurl;
                user.textBox10.Text = cmpmodel;
                user.textBox11.Text = oemhour;
                user.textBox13.Text = oemphone;
                user.textBox14.Text = oemlog;
                user.textBox16.Text = sys_reguser;
                user.textBox17.Text = sys_name;
                user.textBox18.Text = sys_Installpath;
                user.textBox19.Text = sys_regcompany;
                user.textBox21.Text = sys_version;
                user.textBox22.Text = sys_id;
            }
            catch
            {
            }
        }
        public static void SystemStyle_SetOEMInfo(string OEMName, string OEMURL, string OEMModel, string OEMHours, string OEMPhone, Image OEMLogo)
        {
            try
            {
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Manufacturer", OEMName, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportURL", OEMURL, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportHours", OEMHours, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Model", OEMModel, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportPhone", OEMPhone, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Logo", @"%SystemRoot%\system32\OEMLogo.BMP", RegistryValueKind.String, true, false);
                if (OEMLogo != null)
                {
                    MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_ConvetImage(OEMLogo, System.Drawing.Imaging.ImageFormat.Bmp, OEMLogo.Width, OEMLogo.Height, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\OEMLogo.bmp");
                }
            }
            catch
            {
            }
        }
        public static void SystemStyle_SetSystemInfo(string UserName, string OSName, string InstallSources, string Company, string OSVer, string OSID)
        {
            try
            {
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOwner", UserName, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", OSName, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SourcePath", InstallSources, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOrganization", Company, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentVersion", OSVer, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductID", OSID, RegistryValueKind.String, false, false);
            }
            catch
            {
            }
        }
        public static void SystemStyle_CreateGUIDIconInDesktop(string FileName, Form frm)
        {
            try
            {
                FileName = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(FileName, FileName);
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(FileName) == true)
                {
                    string LoadGUID = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "guid", "", false, FileName);
                    MyFunctions.StreamAndTextOperate.TextOperate.CreateRunAsAdminVBS();
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, "CLSID", LoadGUID, false);
                    int CommandItems = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "COMMANDCOUNT", "0", false, FileName), 0);
                    MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"CLSID", LoadGUID, false);
                    MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"CLSID", LoadGUID, false);
                    MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"CLSID\" + LoadGUID, "DefaultIcon", false);
                    MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"CLSID\" + LoadGUID, "Shell", false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"CLSID\" + LoadGUID, "", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "name", "0", false, FileName), RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"CLSID\" + LoadGUID + @"\DefaultIcon", "", MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "icon", "", false, FileName), MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "icon", "", false, FileName)), RegistryValueKind.ExpandString, false, false);
                    for (int f = 1; f <= CommandItems; f = f + 1)
                    {
                        string name = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + f.ToString(), "name", "Command" + f.ToString(), false, FileName);
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"CLSID\" + LoadGUID + @"\Shell", name, false);
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"CLSID\" + LoadGUID + @"\Shell\" + name, "Command", false);
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"CLSID\" + LoadGUID + @"\Shell\" + name, "", MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + f.ToString(), "name", "", false, FileName), RegistryValueKind.String, false, false);
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"CLSID\" + LoadGUID + @"\Shell\" + name, "Icon", MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + f.ToString(), "icon", "", false, FileName), MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + f.ToString(), "icon", "", false, FileName)), RegistryValueKind.ExpandString, false, false);
                        string NewCommand = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + f.ToString(), "command", "", false, FileName), MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + f.ToString(), "command", "", false, FileName));
                        if (MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + f.ToString(), "runasadmin", "F", false, FileName).ToUpper() == "T")
                        {
                            NewCommand = @"Wscript.exe """ + Application.StartupPath + @"\Programs\RunAsAdmin.vbs"" " + NewCommand;
                        }
                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"CLSID\" + LoadGUID + @"\Shell\" + name + @"\Command", "", NewCommand, RegistryValueKind.ExpandString, false, false);
                    }
                   
                    ///Class_Function.PublicDialog_MessageBox("创建GUID图标成功", "已成功在桌面上创建GUID图标 ,刷新桌面后生效。", MyFunctions.Dialogs.MessageDialogIcon.Information, false, true, "", "确定", false, "", Obj.Location.X, Obj.Location.Y, Obj.Size.Width, Obj.Size.Height, true);
                }
                else
                {
                    //Class_Function.PublicDialog_MessageBox("读取配置文件错误", "读取配置文件错误：缺少必要的信息或文件不存在。请选择一个正确的文件。", MyFunctions.Dialogs.MessageDialogIcon.Error, false, true, "", "确定", false, "", Obj.Location.X, Obj.Location.Y, Obj.Size.Width, Obj.Size.Height, true);
                }
            }
            catch
            {
                //Class_Function.PublicDialog_MessageBox("读取配置文件错误", "读取配置文件错误：缺少必要的信息或文件不存在。请选择一个正确的文件。", MyFunctions.Dialogs.MessageDialogIcon.Error, false, true, "", "确定", false, "", Obj.Location.X, Obj.Location.Y, Obj.Size.Width, Obj.Size.Height, true);
            }
        }
        public static Icon SystemStyle_GetIconForFolder(Boolean AddLargeIcon, Boolean FolderName)
        {
            SHFILEINFO shellFileInfo = new SHFILEINFO();
            try
            {
                uint flags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES;
                flags |= FolderName ? SHGFI_OPENICON : 0;
                flags |= AddLargeIcon ? SHGFI_LARGEICON : SHGFI_SMALLICON;

                SHGetFileInfo(null,
                    FILE_ATTRIBUTE_DIRECTORY,
                    ref shellFileInfo,
                    (uint)Marshal.SizeOf(shellFileInfo),
                    flags);

                return (Icon)Icon.FromHandle(shellFileInfo.hIcon).Clone();
            }
            finally
            {
                DestroyIcon(shellFileInfo.hIcon);        // Cleanup
            }
        }
        public static Icon SystemStyle_GetIconForFileExtension(String ExtraName, Boolean LoadLargeIcon, Boolean AddLinkIcon)
        {
            if (!ExtraName.StartsWith("."))
                ExtraName = "." + ExtraName;

            SHFILEINFO shellFileInfo = new SHFILEINFO();
            try
            {
                uint flags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES;
                flags |= AddLinkIcon ? SHGFI_LINKOVERLAY : 0;
                flags |= LoadLargeIcon ? SHGFI_LARGEICON : SHGFI_SMALLICON;

                SHGetFileInfo(ExtraName,
                    FILE_ATTRIBUTE_NORMAL,
                    ref shellFileInfo,
                    (uint)Marshal.SizeOf(shellFileInfo),
                    flags);

                return (Icon)Icon.FromHandle(shellFileInfo.hIcon).Clone();
            }
            finally
            {
                DestroyIcon(shellFileInfo.hIcon);
            }
        }
        public static void SystemStyle_LoadExtraName(UserControl_SystemStyle_SystemView user)
        {
            Thread P_thread = new Thread(
                 () => //lambda表达式（参数列表）=>{执行语句}  lambda表达式是比匿名方法更加简洁的一种匿名函数语法
                 {
                     user.Invoke(new MethodInvoker(delegate()
                     {
                         try
                         {
                             user.listView2.Items.Clear();
                             user.imageList4.Images.Clear();
                             string[] SubKeyInHKCR;
                             SubKeyInHKCR = MyFunctions.RegistryOperate.RegistryOperate_GetSubkeys(Registry.ClassesRoot, "");
                             //MessageBox.Show(SubKeyInHKCR.Length.ToString());
                             for (int y = 1; y <= SubKeyInHKCR.Length; y++)
                             {
                                 Application.DoEvents();
                                 if (SubKeyInHKCR[y - 1].Length > 1)
                                 {
                                     if (SubKeyInHKCR[y - 1].Substring(0, 1) == ".")
                                     {
                                         string biaoshifuname = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, SubKeyInHKCR[y - 1].ToString(), "", "", false, false);
                                         if (biaoshifuname != "")
                                         {
                                             string _info = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, biaoshifuname, "", SubKeyInHKCR[y - 1].ToString() + "文件", false, false);
                                             user.imageList4.Images.Add(SystemStyle_GetIconForFileExtension(SubKeyInHKCR[y - 1].ToString(), true, false));
                                             if (user.imageList4.Images.Count > 0)
                                             {
                                                 user.listView2.Items.Add(SubKeyInHKCR[y - 1]).ImageIndex = user.imageList4.Images.Count - 1;
                                                 user.listView2.Items[user.imageList4.Images.Count - 1].SubItems.Add(_info);
                                             }
                                         }
                                     }
                                 }
                             }
                         }
                         catch
                         {
                         }
                     }));
                 });//new thread

            P_thread.IsBackground = true;
            P_thread.Start();
        }
        public static void SystemStyle_SetWin8StartSrceenStyle(string RegValue, UserControl_SystemStyle_SystemView user)
        {
            MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", @"AccentId_v8.00", RegValue, RegistryValueKind.DWord, false, false);
            foreach (Control control in user.flowLayoutPanel1.Controls)
            {
                if (control.GetType() == typeof(Button)) //按类型查找
                {
                    Button pb = control as Button; //转换为具体控件类型
                    //MessageBox.Show(pb.Image.Height.ToString());
                    pb.FlatAppearance.BorderColor = Color.White;
                    if (RegValue == pb.Tag.ToString())
                    {
                        pb.FlatAppearance.BorderColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    }
                }
            }

        }
        public static void SystemStyle_LoadWin8StartSrceenStyle(UserControl_SystemStyle_SystemView user)
        {
            string RegValue = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", "AccentId_v8.00", "100", false, false);
            foreach (Control control in user.flowLayoutPanel1.Controls)
            {
                if (control.GetType() == typeof(Button)) //按类型查找
                {
                    Button pb = control as Button; //转换为具体控件类型
                    //MessageBox.Show(pb.Image.Height.ToString());
                    pb.FlatAppearance.BorderColor = Color.White;
                    if (RegValue == pb.Tag.ToString())
                    {
                        pb.FlatAppearance.BorderColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    }
                }
            }

        }
        public static void SystemStyle_SetWin8StartSrceenColor(string RegValue, UserControl_SystemStyle_SystemView user)
        {
            MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", @"AccentId_v2", RegValue, RegistryValueKind.DWord, false, false);
            MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", @"ColorSet_Version3", RegValue, RegistryValueKind.DWord, false, false);
            MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", @"ColorSet_Version1", RegValue, RegistryValueKind.DWord, false, false);
            foreach (Control control in user.flowLayoutPanel2.Controls)
            {
                if (control.GetType() == typeof(Button)) //按类型查找
                {
                    Button pb = control as Button; //转换为具体控件类型
                    //MessageBox.Show(pb.Image.Height.ToString());
                    pb.FlatAppearance.BorderColor = Color.White;
                    if (RegValue == pb.Tag.ToString())
                    {
                        pb.FlatAppearance.BorderColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    }
                    //user.pictureBox48.Location = new Point(8, 202);
                }
            }
            user.pictureBox48.Location = new Point(9 + 26 * MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(RegValue, 0), 202);
        }
        public static void SystemStyle_LoadWin8StartSrceenColor(UserControl_SystemStyle_SystemView user)
        {
            string RegValue = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", "ColorSet_Version3", "0", false, false);
            foreach (Control control in user.flowLayoutPanel2.Controls)
            {
                if (control.GetType() == typeof(Button)) //按类型查找
                {
                    Button pb = control as Button; //转换为具体控件类型
                    //MessageBox.Show(pb.Image.Height.ToString());
                    pb.FlatAppearance.BorderColor = Color.White;
                    if (RegValue == pb.Tag.ToString())
                    {
                        pb.FlatAppearance.BorderColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    }
                    //user.pictureBox48.Location = new Point(8, 202);
                }
            }
            user.pictureBox48.Location = new Point(9 + 26 * MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(RegValue, 0), 202);
        }
        public static void SystemStyle_LoadSysIconsToListView(UserControl_SystemStyle_SystemView user)
        {
            string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
            string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
            string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
            string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
            string IEGUID = "{4B6C7757-AAF6-46AF-A2D2-D31CEE866228}";
            string cfg = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_ConfigPath() + @"\SystemIcons.sgcf";
            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(cfg);
            string RBICON_NORMAL = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "", "", false, false);
            string RBICON_FULL = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "full", "", false, false);
            string RBICON_NAME = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID, "", "回收站", false, false);
            if (RBICON_NAME == "") { RBICON_NAME = "回收站"; }
            if (RBICON_NORMAL == "") { RBICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,50"; }
            if (RBICON_FULL == "") { RBICON_FULL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,49"; }
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_RB_D", "Org_Name", "回收站", "Config", false, cfg);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_RB_F", "Org_Name", "回收站", "Config", false, cfg);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_RB_D", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,50", "Config", false, cfg);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_RB_F", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,49", "Config", false, cfg);
            ///////////////////////////////////////////////////UF//////////////////////////////////////////////
            string UFICON_NORMAL = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + UFGUID + @"\DefaultIcon", "", "", false, false);
            string UFICON_NAME = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + UFGUID, "", "用户的文件", false, false);
            if (UFICON_NAME == "") { UFICON_NAME = "用户的文件"; }
            if (UFICON_NORMAL == "") { UFICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,117"; }
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_UF", "Org_Name", "UsersFiles", "Config", false, cfg);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_UF", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,117", "Config", false, cfg);
            ///////////////////////////////////////////////////NK//////////////////////////////////////////////
            string NKICON_NORMAL = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + NKGUID + @"\DefaultIcon", "", "", false, false);
            string NKICON_NAME = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + NKGUID, "", "网络", false, false);
            if (NKICON_NAME == "") { NKICON_NAME = "网络"; }
            if (NKICON_NORMAL == "") { NKICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,20"; }
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_NK", "Org_Name", "网络", "Config", false, cfg);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_NK", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,20", "Config", false, cfg);
            ///////////////////////////////////////////////////MC//////////////////////////////////////////////
            string MCICON_NORMAL = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + MCGUID + @"\DefaultIcon", "", "", false, false);
            string MCICON_NAME = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + MCGUID, "", "计算机", false, false);
            if (MCICON_NAME == "") { MCICON_NAME = "计算机"; }
            if (MCICON_NORMAL == "") { MCICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,104"; }
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_MC", "Org_Name", "计算机", "Config", false, cfg);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_MC", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,104", "Config", false, cfg);
            ///////////////////////////////////////////////////CP//////////////////////////////////////////////
            string CPICON_NORMAL = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + CPGUID + @"\DefaultIcon", "", "", false, false);
            string CPICON_NAME = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + CPGUID, "", "控制面板", false, false);
            if (CPICON_NAME == "") { CPICON_NAME = "控制面板"; }
            if (CPICON_NORMAL == "") { CPICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,22"; }
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_CP", "Org_Name", "控制面板", "Config", false, cfg);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_CP", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,22", "Config", false, cfg);
            ///////////////////////////////////////////////////IE//////////////////////////////////////////////
            string IEICON_NORMAL = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + IEGUID + @"\DefaultIcon", "", "", false, false);
            string IEICON_NAME = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + IEGUID, "", "Internet Explorer", false, false);
            if (IEICON_NAME == "") { IEICON_NAME = "Internet Explorer"; }
            if (IEICON_NORMAL == "") { IEICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Ieframe.dll,18"; }
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_IE", "Org_Name", "Internet Explorer", "Config", false, cfg);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_IE", "Org_Icon_Default", "%SystemRoot%\\System32\\Ieframe.dll,18", "Config", false, cfg);
            ////////////////////////////////////////////////START////////////////////////////////////////////
            user.listView3.Items.Clear();
            user.imageList5.Images.Clear();
            //UF
            user.listView3.Items.Add(UFICON_NAME);
            //user.imageList5.Images.Add(MyFunctions.MediaOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(UFICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,117"));
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(UFICON_NORMAL, ""));
            user.listView3.Items[0].ImageIndex = 0;
            user.listView3.Items[0].Group = user.listView3.Groups[0];
            user.listView3.Items[0].Tag = "UF";
            //MC
            user.listView3.Items.Add(MCICON_NAME);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(MCICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,104"));
            user.listView3.Items[1].ImageIndex = 1;
            user.listView3.Items[1].Group = user.listView3.Groups[0];
            user.listView3.Items[1].Tag = "MC";
            //NK
            user.listView3.Items.Add(NKICON_NAME);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(NKICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,20"));
            user.listView3.Items[2].ImageIndex = 2;
            user.listView3.Items[2].Group = user.listView3.Groups[0];
            user.listView3.Items[2].Tag = "NK";
            //CP
            user.listView3.Items.Add(CPICON_NAME);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(CPICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,22"));
            user.listView3.Items[3].ImageIndex = 3;
            user.listView3.Items[3].Group = user.listView3.Groups[0];
            user.listView3.Items[3].Tag = "CP";
            //RB_NORMAL
            user.listView3.Items.Add(RBICON_NAME + "(空)");
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(RBICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,50"));
            user.listView3.Items[4].ImageIndex = 4;
            user.listView3.Items[4].Group = user.listView3.Groups[0];
            user.listView3.Items[4].Tag = "RB_D";
            //RB_FULL
            user.listView3.Items.Add(RBICON_NAME + "(满)");
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(RBICON_FULL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,49"));
            user.listView3.Items[5].ImageIndex = 5;
            user.listView3.Items[5].Group = user.listView3.Groups[0];
            user.listView3.Items[5].Tag = "RB_F";
            //IE
            user.listView3.Items.Add(IEICON_NAME);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(IEICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Ieframe.dll,18"));
            user.listView3.Items[6].ImageIndex = 6;
            user.listView3.Items[6].Group = user.listView3.Groups[0];
            user.listView3.Items[6].Tag = "IE";
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////开始加载驱动器图标/////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //HDD INDEX 6
            string ICONINDEX_6 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "6", "", false, false);
            string ICONNAME_6 = @"3.5""寸软盘";
            if (ICONINDEX_6 == "") { ICONINDEX_6 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,24"; }
            user.listView3.Items.Add(ICONNAME_6);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_6, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,24"));
            user.listView3.Items[7].ImageIndex = 7;
            user.listView3.Items[7].Group = user.listView3.Groups[1];
            user.listView3.Items[7].Tag = "6";
            //HDD INDEX 8
            string ICONINDEX_8 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "8", "", false, false);
            string ICONNAME_8 = @"硬盘";
            if (ICONINDEX_8 == "") { ICONINDEX_8 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,27"; }
            user.listView3.Items.Add(ICONNAME_8);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_8, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,27"));
            user.listView3.Items[8].ImageIndex = 8;
            user.listView3.Items[8].Group = user.listView3.Groups[1];
            user.listView3.Items[8].Tag = "8";
            //HDD INDEX 11
            string ICONINDEX_11 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "11", "", false, false);
            string ICONNAME_11 = @"CD光驱";
            if (ICONINDEX_11 == "") { ICONINDEX_11 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,25"; }
            user.listView3.Items.Add(ICONNAME_11);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_11, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,25"));
            user.listView3.Items[9].ImageIndex = 9;
            user.listView3.Items[9].Group = user.listView3.Groups[1];
            user.listView3.Items[9].Tag = "11";
            //HDD INDEX 59
            string ICONINDEX_59 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "59", "", false, false);
            string ICONNAME_59 = @"DVD光驱";
            if (ICONINDEX_59 == "") { ICONINDEX_59 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,32"; }
            user.listView3.Items.Add(ICONNAME_59);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_59, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,32"));
            user.listView3.Items[10].ImageIndex = 10;
            user.listView3.Items[10].Group = user.listView3.Groups[1];
            user.listView3.Items[10].Tag = "59";
            //HDD INDEX 40
            string ICONINDEX_41 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "41", "", false, false);
            string ICONNAME_41 = @"音频CD";
            if (ICONINDEX_41 == "") { ICONINDEX_41 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Shell32.dll,40"; }
            user.listView3.Items.Add(ICONNAME_41);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_41, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Shell32.dll,40"));
            user.listView3.Items[11].ImageIndex = 11;
            user.listView3.Items[11].Group = user.listView3.Groups[1];
            user.listView3.Items[11].Tag = "41";
            //HDD INDEX 7
            string ICONINDEX_7 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "7", "", false, false);
            string ICONNAME_7 = @"可移动驱动器";
            if (ICONINDEX_7 == "") { ICONINDEX_7 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Shell32.dll,7"; }
            user.listView3.Items.Add(ICONNAME_7);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_7, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Shell32.dll,7"));
            user.listView3.Items[12].ImageIndex = 12;
            user.listView3.Items[12].Group = user.listView3.Groups[1];
            user.listView3.Items[12].Tag = "7";
            //HDD INDEX 9
            string ICONINDEX_9 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "9", "", false, false);
            string ICONNAME_9 = @"网路驱动器(已连接)";
            if (ICONINDEX_9 == "") { ICONINDEX_9 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,28"; }
            user.listView3.Items.Add(ICONNAME_9);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_9, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,28"));
            user.listView3.Items[13].ImageIndex = 13;
            user.listView3.Items[13].Group = user.listView3.Groups[1];
            user.listView3.Items[13].Tag = "9";
            //HDD INDEX 10
            string ICONINDEX_10 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "10", "", false, false);
            string ICONNAME_10 = @"网路驱动器(已断开)";
            if (ICONINDEX_10 == "") { ICONINDEX_10 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,26"; }
            user.listView3.Items.Add(ICONNAME_10);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_10, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,26"));
            user.listView3.Items[14].ImageIndex = 14;
            user.listView3.Items[14].Group = user.listView3.Groups[1];
            user.listView3.Items[14].Tag = "10";
            //HDD INDEX 10
            string ICONINDEX_12 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "12", "", false, false);
            string ICONNAME_12 = @"RAM 驱动器";
            if (ICONINDEX_12 == "") { ICONINDEX_12 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,29"; }
            user.listView3.Items.Add(ICONNAME_12);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_12, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,29"));
            user.listView3.Items[15].ImageIndex = 15;
            user.listView3.Items[15].Group = user.listView3.Groups[1];
            user.listView3.Items[15].Tag = "12";
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////开始加载文件夹图标/////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //FLD INDEX 3
            string ICONINDEX_3 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "3", "", false, false);
            string ICONNAME_3 = @"文件夹(闭合)";
            if (ICONINDEX_3 == "") { ICONINDEX_3 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,3"; }
            user.listView3.Items.Add(ICONNAME_3);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_3, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,3"));
            user.listView3.Items[16].ImageIndex = 16;
            user.listView3.Items[16].Group = user.listView3.Groups[2];
            user.listView3.Items[16].Tag = "S03";
            //FLD INDEX 4
            string ICONINDEX_4 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "4", "", false, false);
            string ICONNAME_4 = @"文件夹(打开)";
            if (ICONINDEX_4 == "") { ICONINDEX_4 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,4"; }
            user.listView3.Items.Add(ICONNAME_4);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_4, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,4"));
            user.listView3.Items[17].ImageIndex = 17;
            user.listView3.Items[17].Group = user.listView3.Groups[2];
            user.listView3.Items[17].Tag = "S04";
            //FLD INDEX 36
            string ICONINDEX_36 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "36", "", false, false);
            string ICONNAME_36 = @"程序组";
            if (ICONINDEX_36 == "") { ICONINDEX_36 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\shell32.dll,36"; }
            user.listView3.Items.Add(ICONNAME_36);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_36, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\shell32.dll,36"));
            user.listView3.Items[18].ImageIndex = 18;
            user.listView3.Items[18].Group = user.listView3.Groups[2];
            user.listView3.Items[18].Tag = "S36";
            //FLD INDEX MGRTOOLS
            string ICONINDEX_MGRTOOLS = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{D20EA4E1-3957-11d2-A40B-0C5020524153}\defaulticon", "", "", false, false);
            string ICONNAME_MGRTOOLS = @"管理工具";
            if (ICONINDEX_MGRTOOLS == "") { ICONINDEX_MGRTOOLS = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\IMAGERES.DLL,109"; }
            user.listView3.Items.Add(ICONNAME_MGRTOOLS);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_MGRTOOLS, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\IMAGERES.DLL,109"));
            user.listView3.Items[19].ImageIndex = 19;
            user.listView3.Items[19].Group = user.listView3.Groups[2];
            user.listView3.Items[19].Tag = "G{D20EA4E1-3957-11d2-A40B-0C5020524153}";
            //FLD INDEX NETGET
            string ICONINDEX_NETGET = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{7007ACC7-3202-11D1-AAD2-00805FC1270E}\defaulticon", "", "", false, false);
            string ICONNAME_NETGET = @"网络连接";
            if (ICONINDEX_NETGET == "") { ICONINDEX_NETGET = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\netshell.dll,0"; }
            user.listView3.Items.Add(ICONNAME_NETGET);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_NETGET, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\netshell.dll,0"));
            user.listView3.Items[20].ImageIndex = 20;
            user.listView3.Items[20].Group = user.listView3.Groups[2];
            user.listView3.Items[20].Tag = "G{7007ACC7-3202-11D1-AAD2-00805FC1270E}";
            //FLD INDEX FONTS
            string ICONINDEX_FONTS = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{D20EA4E1-3957-11d2-A40B-0C5020524152}\defaulticon", "", "", false, false);
            string ICONNAME_FONTS = @"字体";
            if (ICONINDEX_FONTS == "") { ICONINDEX_FONTS = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\main.cpl,6"; }
            user.listView3.Items.Add(ICONNAME_FONTS);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_FONTS, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\main.cpl,6"));
            user.listView3.Items[21].ImageIndex = 21;
            user.listView3.Items[21].Group = user.listView3.Groups[2];
            user.listView3.Items[21].Tag = "G{D20EA4E1-3957-11d2-A40B-0C5020524152}";
            //FLD INDEX XAOMIAO
            string ICONINDEX_XAOMIAO = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{E211B736-43FD-11D1-9EFB-0000F8757FCD}\defaulticon", "", "", false, false);
            string ICONNAME_XAOMIAO = @"扫描仪和照相机";
            if (ICONINDEX_XAOMIAO == "") { ICONINDEX_XAOMIAO = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wiashext.dll,0"; }
            user.listView3.Items.Add(ICONNAME_XAOMIAO);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_XAOMIAO, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\wiashext.dll,0"));
            user.listView3.Items[22].ImageIndex = 22;
            user.listView3.Items[22].Group = user.listView3.Groups[2];
            user.listView3.Items[22].Tag = "G{E211B736-43FD-11D1-9EFB-0000F8757FCD}";
            //FLD INDEX ONLYSAOMIAO
            string ICONINDEX_ONLYSAOMIAO = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{2227A280-3AEA-1069-A2DE-08002B30309D}\defaulticon", "", "", false, false);
            string ICONNAME_ONLYSAOMIAO = @"扫描仪";
            if (ICONINDEX_ONLYSAOMIAO == "") { ICONINDEX_ONLYSAOMIAO = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\IMAGERES.DLL,21"; }
            user.listView3.Items.Add(ICONNAME_ONLYSAOMIAO);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_ONLYSAOMIAO, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\IMAGERES.DLL,21"));
            user.listView3.Items[23].ImageIndex = 23;
            user.listView3.Items[23].Group = user.listView3.Groups[2];
            user.listView3.Items[23].Tag = "G{2227A280-3AEA-1069-A2DE-08002B30309D}";
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////开始加载其他图标/////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //OTHER INDEX LINKICO
            string ICONINDEX_LINKICO = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "29", "", false, false);
            string ICONNAME_LINKICO = @"快捷方式箭头";
            if (ICONINDEX_LINKICO == "") { ICONINDEX_LINKICO = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\IMAGERES.DLL,154"; }
            user.listView3.Items.Add(ICONNAME_LINKICO);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_LINKICO, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\IMAGERES.DLL,154"));
            user.listView3.Items[24].ImageIndex = 24;
            user.listView3.Items[24].Group = user.listView3.Groups[3];
            user.listView3.Items[24].Tag = "29";
            //OTHER INDEX DEFFILE
            string ICONINDEX_DEFFILE = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "0", "", false, false);
            string ICONNAME_DEFFILE = @"默认的文件";
            if (ICONINDEX_DEFFILE == "") { ICONINDEX_DEFFILE = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\IMAGERES.DLL,2"; }
            user.listView3.Items.Add(ICONNAME_DEFFILE);
            user.imageList5.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ICONINDEX_DEFFILE, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\IMAGERES.DLL,2"));
            user.listView3.Items[25].ImageIndex = 25;
            user.listView3.Items[25].Group = user.listView3.Groups[3];
            user.listView3.Items[25].Tag = "0";
            user.listView3.Items[0].Focused = true;
        }
        public static void SystemStyle_LoadMetroLink(UserControl_SystemStyle_SystemView user)
        {
            /*
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\应用商店.lnk") != true) { user.button109.Location = new Point(0, 0); user.button109.BackColor = Color.FromArgb(205, 205, 205); user.button109.ForeColor = Color.Black; user.button109.Text = "显示"; } else { user.button109.Location = new Point(50, 0); user.button109.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button109.ForeColor = Color.White; user.button109.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Bing搜索.lnk") != true) { user.button108.Location = new Point(0, 0); user.button108.BackColor = Color.FromArgb(205, 205, 205); user.button108.ForeColor = Color.Black; user.button108.Text = "显示"; } else { user.button108.Location = new Point(50, 0); user.button108.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button108.ForeColor = Color.White; user.button108.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\财经.lnk") != true) { user.button110.Location = new Point(0, 0); user.button110.BackColor = Color.FromArgb(205, 205, 205); user.button110.ForeColor = Color.Black; user.button110.Text = "显示"; } else { user.button110.Location = new Point(50, 0); user.button110.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button110.ForeColor = Color.White; user.button110.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\地图.lnk") != true) { user.button113.Location = new Point(0, 0); user.button113.BackColor = Color.FromArgb(205, 205, 205); user.button113.ForeColor = Color.Black; user.button113.Text = "显示"; } else { user.button113.Location = new Point(50, 0); user.button113.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button113.ForeColor = Color.White; user.button113.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\旅游.lnk") != true) { user.button112.Location = new Point(0, 0); user.button112.BackColor = Color.FromArgb(205, 205, 205); user.button112.ForeColor = Color.Black; user.button112.Text = "显示"; } else { user.button112.Location = new Point(50, 0); user.button112.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button112.ForeColor = Color.White; user.button112.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\人脉.lnk") != true) { user.button111.Location = new Point(0, 0); user.button111.BackColor = Color.FromArgb(205, 205, 205); user.button111.ForeColor = Color.Black; user.button111.Text = "显示"; } else { user.button111.Location = new Point(50, 0); user.button111.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button111.ForeColor = Color.White; user.button111.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\视频.lnk") != true) { user.button117.Location = new Point(0, 0); user.button117.BackColor = Color.FromArgb(205, 205, 205); user.button117.ForeColor = Color.Black; user.button117.Text = "显示"; } else { user.button117.Location = new Point(50, 0); user.button117.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button117.ForeColor = Color.White; user.button117.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\体育.lnk") != true) { user.button116.Location = new Point(0, 0); user.button116.BackColor = Color.FromArgb(205, 205, 205); user.button116.ForeColor = Color.Black; user.button116.Text = "显示"; } else { user.button116.Location = new Point(50, 0); user.button116.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button116.ForeColor = Color.White; user.button116.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\天气.lnk") != true) { user.button115.Location = new Point(0, 0); user.button115.BackColor = Color.FromArgb(205, 205, 205); user.button115.ForeColor = Color.Black; user.button115.Text = "显示"; } else { user.button115.Location = new Point(50, 0); user.button115.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button115.ForeColor = Color.White; user.button115.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\消息.lnk") != true) { user.button120.Location = new Point(0, 0); user.button120.BackColor = Color.FromArgb(205, 205, 205); user.button120.ForeColor = Color.Black; user.button120.Text = "显示"; } else { user.button120.Location = new Point(50, 0); user.button120.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button120.ForeColor = Color.White; user.button120.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\音乐.lnk") != true) { user.button119.Location = new Point(0, 0); user.button119.BackColor = Color.FromArgb(205, 205, 205); user.button119.ForeColor = Color.Black; user.button119.Text = "显示"; } else { user.button119.Location = new Point(50, 0); user.button119.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button119.ForeColor = Color.White; user.button119.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\邮件.lnk") != true) { user.button118.Location = new Point(0, 0); user.button118.BackColor = Color.FromArgb(205, 205, 205); user.button118.ForeColor = Color.Black; user.button118.Text = "显示"; } else { user.button118.Location = new Point(50, 0); user.button118.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button118.ForeColor = Color.White; user.button118.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\游戏.lnk") != true) { user.button122.Location = new Point(0, 0); user.button122.BackColor = Color.FromArgb(205, 205, 205); user.button122.ForeColor = Color.Black; user.button122.Text = "显示"; } else { user.button122.Location = new Point(50, 0); user.button122.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button122.ForeColor = Color.White; user.button122.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Bing资讯.lnk") != true) { user.button121.Location = new Point(0, 0); user.button121.BackColor = Color.FromArgb(205, 205, 205); user.button121.ForeColor = Color.Black; user.button121.Text = "显示"; } else { user.button121.Location = new Point(50, 0); user.button121.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button121.ForeColor = Color.White; user.button121.Text = "隐藏"; }
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\日历.lnk") != true) { user.button147.Location = new Point(0, 0); user.button147.BackColor = Color.FromArgb(205, 205, 205); user.button147.ForeColor = Color.Black; user.button147.Text = "显示"; } else { user.button147.Location = new Point(50, 0); user.button147.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(); user.button147.ForeColor = Color.White; user.button147.Text = "隐藏"; }
            */
        }
        public static void SystemStyle_SetMetroLink(string Type, string Code)
        {
            string name = "";
            string args = "";
            switch (Code.ToUpper())
            {
                case "STORE":
                    args = @"ms-windows-store:";
                    name = "应用商店";
                    break;
                case "BSEAR":
                    args = @"bingsearch://";
                    name = "Bing搜索";
                    break;
                case "CAIJI":
                    args = @"bingfinance://";
                    name = "财经";
                    break;
                case "WMAPS":
                    args = @"bingmaps://";
                    name = "地图";
                    break;
                case "TRAVE":
                    args = @"bingtravel://";
                    name = "旅游";
                    break;
                case "PEOPL":
                    args = @"wlpeople://";
                    name = "人脉";
                    break;
                case "VIDEO":
                    args = @"microsoftvideo://";
                    name = "视频";
                    break;
                case "SPORT":
                    args = @"bingsports://";
                    name = "体育";
                    break;
                case "WEATH":
                    args = @"bingweather://";
                    name = "天气";
                    break;
                case "MESSA":
                    args = @"mschat://";
                    name = "消息";
                    break;
                case "MUSIC":
                    args = @"microsoftmusic://";
                    name = "音乐";
                    break;
                case "MAILS":
                    args = @"ms-mail://";
                    name = "邮件";
                    break;
                case "GAMES":
                    args = @"xboxgames://";
                    name = "游戏";
                    break;
                case "ZIXUN":
                    args = @"bingnews://";
                    name = "Bing资讯";
                    break;
                case "RILIA":
                    args = @"wlcalendar://";
                    name = "日历";
                    break;
            }
            switch (Type.ToUpper())
            {
                case "NEW":
                    MyFunctions.ProgramAndLinksOperate.CreateLink(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + name + @".lnk", @"%SystemRoot%\System32\cmd.exe", "/c start " + args, name, Application.StartupPath + @"\Images\Win8UIIcon\DefaultIcon.ico", null);
                    break;
                case "DELETE":
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + name + @".lnk");
                    break;
            }
        }
        public static void SystemStyle_LoadBCD(UserControl_SystemStyle_SystemView user)
        {
            try
            {
                MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.BCDOperate.BCDOperate_CreateBCDTempFile();
                string[] bootname = MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.BCDOperate.BCDOperate_GetBootMenu_Name();
                string[] bootlocation = MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.BCDOperate.BCDOperate_GetBootMenu_GetBootLocation();
                string[] boottype = MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.BCDOperate.BCDOperate_GetBootMenu_GetBootType();
                string[] bootguid = MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.BCDOperate.BCDOperate_GetBootMenu_GUID();
                int defaultmenu = MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.BCDOperate.BCDOperate_GetBootMenu_GetDefaultBootMenu();
                string timeout = MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.BCDOperate.BCDOperate_GetBootMenu_TimeOut();
                string[] def = new string[bootname.Length];
                for (int q = 1; q <= bootname.Length; q++)
                {
                    if (q - 1 != defaultmenu)
                    {
                        def[q - 1] = "";
                    }
                    else
                    {
                        def[q - 1] = "是";
                    }
                }
                user.textBox26.Text = timeout;
                if (bootname != null && bootlocation != null && boottype != null && bootguid != null)
                {
                    user.listView4.Items.Clear();
                    //MessageBox.Show(bootname.Length.ToString());
                    for (int h = 1; h <= bootname.Length; h++)
                    {
                        user.listView4.Items.Add(def[h - 1]);
                        user.listView4.Items[h - 1].SubItems.Add(bootname[h - 1]);
                        user.listView4.Items[h - 1].SubItems.Add(bootlocation[h - 1]);
                        user.listView4.Items[h - 1].SubItems.Add(boottype[h - 1]);
                        user.listView4.Items[h - 1].SubItems.Add(bootguid[h - 1]);
                    }
                }
            }
            catch { user.listView4.Items.Clear(); }
        }
        public static void SystemStyle_LoadWinXMenu(UserControl_SystemStyle_SystemView user)
        {
            try
            {
                user.treeView3.Nodes.Clear();
                string LinkPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX";
                if (System.IO.Directory.Exists(LinkPath) == true)
                {
                    string[] GetFolders = MyFunctions.FileSystemOperate.FileSystemOperate_GetFolders(LinkPath, "*.*", SearchOption.TopDirectoryOnly);
                    string[] NewGetFolders = new string[GetFolders.Length];
                    int ui = GetFolders.Length;
                    for (int d = 1; d <= GetFolders.Length; d++)
                    {
                        NewGetFolders[d - 1] = GetFolders[ui - 1];
                        ui = ui - 1;
                    }
                    int GroupCount = GetFolders.Length;
                    int gggg = GroupCount;
                    for (int q = 1; q <= GetFolders.Length; q++)
                    {
                        user.treeView3.Nodes.Add(NewGetFolders[q - 1].ToString().Substring(NewGetFolders[q - 1].LastIndexOf(@"\"), NewGetFolders[q - 1].Length - LinkPath.Length).Replace("\\", "")).Tag = "Mroup" + gggg.ToString();
                        string[] Links = MyFunctions.FileSystemOperate.FileSystemOperate_GetFiles(LinkPath + @"\" + user.treeView3.Nodes[q - 1].Text, "*.lnk", SearchOption.TopDirectoryOnly);
                        int ui1 = Links.Length;
                        string[] NewLinks = new string[ui1];
                        for (int d1 = 1; d1 <= Links.Length; d1++)
                        {
                            NewLinks[d1 - 1] = Links[ui1 - 1];
                            ui1 = ui1 - 1;
                        }
                        for (int lnk = 1; lnk <= Links.Length; lnk++)
                        {
                            string linknamewithoutlocationExt, newlinkname;
                            linknamewithoutlocationExt = NewLinks[lnk - 1].Substring(NewLinks[lnk - 1].LastIndexOf("\\"), NewLinks[lnk - 1].Length - (LinkPath + @"\" + user.treeView3.Nodes[q - 1].Text).Length).Replace("\\", "");
                            string infoname = MyFunctions.ProgramAndLinksOperate.ReadLink(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + user.treeView3.Nodes[q - 1].Text + @"\" + linknamewithoutlocationExt, "info");
                            linknamewithoutlocationExt = linknamewithoutlocationExt.Substring(0, linknamewithoutlocationExt.LastIndexOf("."));
                            switch (linknamewithoutlocationExt)
                            {
                                case "1 - Desktop":
                                    newlinkname = "桌面";
                                    break;
                                case "1 - Run":
                                    newlinkname = "运行";
                                    break;
                                case "4 - Control Panel":
                                    newlinkname = "控制面板";
                                    break;
                                case "5 - Task Manager":
                                    newlinkname = "任务管理器";
                                    break;
                                case "3 - Windows Explorer":
                                    newlinkname = "文件资源管理器";
                                    break;
                                case "2 - Search":
                                    newlinkname = "搜索";
                                    break;
                                case "01 - Command Prompt":
                                    newlinkname = "命令提示符(管理员)";
                                    break;
                                case "08 - Power Options":
                                    newlinkname = "电源选项";
                                    break;
                                case "07 - Event Viewer":
                                    newlinkname = "事件查看器";
                                    break;
                                case "09 - Mobility Center":
                                    newlinkname = "移动中心";
                                    break;
                                case "06 - System":
                                    newlinkname = "系统";
                                    break;
                                case "10 - Programs and Features":
                                    newlinkname = "程序和功能";
                                    break;
                                case "03 - Computer Management":
                                    newlinkname = "计算机管理";
                                    break;
                                case "05 - Device Manager":
                                    newlinkname = "设备管理器";
                                    break;
                                case "02 - Command Prompt":
                                    newlinkname = "命令提示符";
                                    break;
                                case "04 - Disk Management":
                                    newlinkname = "磁盘管理";
                                    break;
                                case "04-1 - Network Connections":
                                    newlinkname = "网络连接";
                                    break;
                                case "02a - Windows PowerShell":
                                    newlinkname = "Windows PowerShell";
                                    break;
                                case "01a - Windows PowerShell":
                                    newlinkname = "Windows PowerShell(管理员)";
                                    break;
                                default:
                                    newlinkname = linknamewithoutlocationExt;
                                    break;
                            }
                            if (infoname != "")
                            {
                                newlinkname = infoname;
                            }
                            /////////////
                            user.treeView3.Nodes[q - 1].Nodes.Add(newlinkname).Tag = "Group" + gggg.ToString() + "*" + linknamewithoutlocationExt + @".LNK";
                            user.treeView3.ExpandAll();
                        }
                        gggg = gggg - 1;
                    }
                }
            }
            catch { }
        }
        public static void SystemStyle_LoadTaskBarIcons(UserControl_SystemStyle_SystemView user)
        {
            try
            {
                string taskbar = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar";
                //SG
                if (System.IO.File.Exists(taskbar + @"\系统齿轮.lnk") != true)
                {
                    user.button153.Location = new Point(0, 0);
                    user.button153.ForeColor = Color.Black;
                    user.button153.BackColor = Color.FromArgb(205, 205, 205);
                    user.button153.Text = "显示";
                }
                else
                {
                    user.button153.Location = new Point(50, 0);
                    user.button153.ForeColor = Color.White;
                    user.button153.BackColor = Color.FromArgb(0, 148, 255);
                    user.button153.Text = "隐藏";
                }
                //ITMI
                if (System.IO.File.Exists(taskbar + @"\IT迷.website") != true)
                {
                    user.button152.Location = new Point(0, 0);
                    user.button152.ForeColor = Color.Black;
                    user.button152.BackColor = Color.FromArgb(205, 205, 205);
                    user.button152.Text = "显示";
                }
                else
                {
                    user.button152.Location = new Point(50, 0);
                    user.button152.ForeColor = Color.White;
                    user.button152.BackColor = Color.FromArgb(0, 148, 255);
                    user.button152.Text = "隐藏";
                }
                //nk
                if (System.IO.File.Exists(taskbar + @"\网络.lnk") != true)
                {
                    user.button157.Location = new Point(0, 0);
                    user.button157.ForeColor = Color.Black;
                    user.button157.BackColor = Color.FromArgb(205, 205, 205);
                    user.button157.Text = "显示";
                }
                else
                {
                    user.button157.Location = new Point(50, 0);
                    user.button157.ForeColor = Color.White;
                    user.button157.BackColor = Color.FromArgb(0, 148, 255);
                    user.button157.Text = "隐藏";
                }
                //UF
                if (System.IO.File.Exists(taskbar + @"\用户的文件.lnk") != true)
                {
                    user.button159.Location = new Point(0, 0);
                    user.button159.ForeColor = Color.Black;
                    user.button159.BackColor = Color.FromArgb(205, 205, 205);
                    user.button159.Text = "显示";
                }
                else
                {
                    user.button159.Location = new Point(50, 0);
                    user.button159.ForeColor = Color.White;
                    user.button159.BackColor = Color.FromArgb(0, 148, 255);
                    user.button159.Text = "隐藏";
                }
                //cp
                if (System.IO.File.Exists(taskbar + @"\控制面板.lnk") != true)
                {
                    user.button156.Location = new Point(0, 0);
                    user.button156.ForeColor = Color.Black;
                    user.button156.BackColor = Color.FromArgb(205, 205, 205);
                    user.button156.Text = "显示";
                }
                else
                {
                    user.button156.Location = new Point(50, 0);
                    user.button156.ForeColor = Color.White;
                    user.button156.BackColor = Color.FromArgb(0, 148, 255);
                    user.button156.Text = "隐藏";
                }
                //rb
                if (System.IO.File.Exists(taskbar + @"\回收站.lnk") != true)
                {
                    user.button161.Location = new Point(0, 0);
                    user.button161.ForeColor = Color.Black;
                    user.button161.BackColor = Color.FromArgb(205, 205, 205);
                    user.button161.Text = "显示";
                }
                else
                {
                    user.button161.Location = new Point(50, 0);
                    user.button161.ForeColor = Color.White;
                    user.button161.BackColor = Color.FromArgb(0, 148, 255);
                    user.button161.Text = "隐藏";
                }
                //ie
                if (System.IO.File.Exists(taskbar + @"\Internet Explorer.lnk") != true)
                {
                    user.button160.Location = new Point(0, 0);
                    user.button160.ForeColor = Color.Black;
                    user.button160.BackColor = Color.FromArgb(205, 205, 205);
                    user.button160.Text = "显示";
                }
                else
                {
                    user.button160.Location = new Point(50, 0);
                    user.button160.ForeColor = Color.White;
                    user.button160.BackColor = Color.FromArgb(0, 148, 255);
                    user.button160.Text = "隐藏";
                }
                //mc
                switch (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion())
                {
                    case "6.3":
                        user.label20.Text = "这台电脑";
                        if (System.IO.File.Exists(taskbar + @"\这台电脑.lnk") != true)
                        {
                            user.button158.Location = new Point(0, 0);
                            user.button158.ForeColor = Color.Black;
                            user.button158.BackColor = Color.FromArgb(205, 205, 205);
                            user.button158.Text = "显示";
                        }
                        else
                        {
                            user.button158.Location = new Point(50, 0);
                            user.button158.ForeColor = Color.White;
                            user.button158.BackColor = Color.FromArgb(0, 148, 255);
                            user.button158.Text = "隐藏";
                        }
                        break;
                    default:
                        user.label20.Text = "计算机";
                        if (System.IO.File.Exists(taskbar + @"\计算机.lnk") != true)
                        {
                            user.button158.Location = new Point(0, 0);
                            user.button158.ForeColor = Color.Black;
                            user.button158.BackColor = Color.FromArgb(205, 205, 205);
                            user.button158.Text = "显示";
                        }
                        else
                        {
                            user.button158.Location = new Point(50, 0);
                            user.button158.ForeColor = Color.White;
                            user.button158.BackColor = Color.FromArgb(0, 148, 255);
                            user.button158.Text = "隐藏";
                        }
                        break;
                }
                //explorer
                switch (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion())
                {
                    case "6.1":
                        if (System.IO.File.Exists(taskbar + @"\Windows Explorer.lnk") != true)
                        {
                            if (System.IO.File.Exists(taskbar + @"\Windows 资源管理器.lnk") == true)
                            {
                                user.button162.Location = new Point(50, 0);
                                user.button162.ForeColor = Color.White;
                                user.button162.BackColor = Color.FromArgb(0, 148, 255);
                                user.button162.Text = "隐藏";
                            }
                            else
                            {
                                user.button162.Location = new Point(0, 0);
                                user.button162.ForeColor = Color.Black;
                                user.button162.BackColor = Color.FromArgb(205, 205, 205);
                                user.button162.Text = "显示";
                            }
                        }
                        else
                        {
                            user.button162.Location = new Point(50, 0);
                            user.button162.ForeColor = Color.White;
                            user.button162.BackColor = Color.FromArgb(0, 148, 255);
                            user.button162.Text = "隐藏";
                        }
                        break;
                    default:
                        if (System.IO.File.Exists(taskbar + @"\File Explorer.lnk") != true)
                        {
                            if (System.IO.File.Exists(taskbar + @"\文件资源管理器.lnk") == true)
                            {
                                user.button162.Location = new Point(50, 0);
                                user.button162.ForeColor = Color.White;
                                user.button162.BackColor = Color.FromArgb(0, 148, 255);
                                user.button162.Text = "隐藏";
                            }
                            else
                            {
                                user.button162.Location = new Point(0, 0);
                                user.button162.ForeColor = Color.Black;
                                user.button162.BackColor = Color.FromArgb(205, 205, 205);
                                user.button162.Text = "显示";
                            }
                        }
                        else
                        {
                            user.button162.Location = new Point(50, 0);
                            user.button162.ForeColor = Color.White;
                            user.button162.BackColor = Color.FromArgb(0, 148, 255);
                            user.button162.Text = "隐藏";
                        }
                        break;
                }
            }
            catch { }
        }
        public static void SystemStyle_SetTaskBarPings(UserControl_SystemStyle_SystemView user, string codename, string type)
        {
            if (type.ToUpper() == "NEW")
            {
                try
                {
                    string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
                    string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
                    string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
                    string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
                    string taskbar = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar";
                    string pingname = "";
                    string path = "";
                    string arg = "";
                    string ico = "";
                    switch (codename.ToUpper())
                    {
                        case "SG":
                            pingname = "系统齿轮";
                            path = Application.ExecutablePath;
                            ico =Application.ExecutablePath+",0";
                            break;
                        case "IT":
                            /*
                            pingname = "IT 迷";
                            string temp_web = Environment.GetEnvironmentVariable("tmp") + @"\IT迷.website";
                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(temp_web);
                            MyFunctions.StreamAndTextOperate.TextOperate.SaveTextFile(temp_web, SystemGear.Properties.Resources.FF_website);
                            MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, temp_web);
                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(temp_web);
                            MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
                             */
                            break;
                        case "DE":
                            pingname = "桌面便利贴";
                            path = Application.StartupPath + @"\Programs\DesktopLabelA.exe";
                            ico = Application.StartupPath + @"\Programs\DesktopLabelA.exe,0";
                            break;
                        case "PC":
                            pingname = "挂机锁屏助手";
                            path = Application.StartupPath + @"\Programs\PCLocker.exe";
                            ico = Application.StartupPath + @"\Programs\PCLocker.exe,0";
                            break;
                        case "UF":
                            pingname = "用户的文件";
                            path = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe";
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,117";
                            arg = "shell:::" + UFGUID;
                            break;
                        case "MC":
                            if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3")
                            {
                                pingname = "这台电脑";
                            }
                            else
                            {
                                pingname = "计算机";
                            }
                            path = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe";
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,104";
                            arg = "shell:::" + MCGUID;
                            break;
                        case "NK":
                            pingname = "网络";
                            path = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe";
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,20";
                            arg = "shell:::" + NKGUID;
                            break;
                        case "CP":
                            pingname = "控制面板";
                            path = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe";
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,22";
                            arg = "shell:::" + CPGUID;
                            break;
                        case "RB":
                            pingname = "回收站";
                            path = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe";
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,50";
                            arg = "shell:::" + RBGUID;
                            break;
                        case "IE":
                            pingname = "Internet Explorer";
                            path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\iexplore.exe";
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\iexplore.exe,0";
                            break;
                        case "EX":
                            if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3" || MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.2")
                            {
                                pingname = "文件资源管理器";
                            }
                            else
                            {
                                pingname = "Windows 资源管理器";
                            }
                            path = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe";
                            ico = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe,0";
                            break;
                    }
                    if (codename.ToUpper() != "IT")
                    {
                        string Temp_link = Environment.GetEnvironmentVariable("tmp") + "\\" + pingname + ".lnk";
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Temp_link);
                        MyFunctions.ProgramAndLinksOperate.CreateLink(Temp_link, path, arg, pingname, ico, null);
                        MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, Temp_link);
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Temp_link);
                        MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
                    }
                    //Class_SystemStyle.SystemStyle_LoadTaskBarIcons(user);
                }
                catch { }
            }
            else
            {
                string pingname = "";
                string _explorer = "";
                switch (codename.ToUpper())
                {
                    case "SG":
                        pingname = "系统齿轮.lnk";
                        break;
                    case "IT":
                        pingname = "IT 迷.website";
                        break;
                    case "DE":
                        pingname = "桌面便利贴.lnk";
                        break;
                    case "PC":
                        pingname = "挂机锁屏助手.lnk";
                        break;
                    case "UF":
                        pingname = "用户的文件.lnk";
                        break;
                    case "MC":
                        if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3")
                        {
                            pingname = "这台电脑.lnk";
                        }
                        else
                        {
                            pingname = "计算机.lnk";
                        }
                        break;
                    case "NK":
                        pingname = "网络.lnk";
                        break;
                    case "CP":
                        pingname = "控制面板.lnk";
                        break;
                    case "RB":
                        pingname = "回收站.lnk";
                        break;
                    case "IE":
                        pingname = "Internet Explorer.lnk";
                        break;
                    case "EX":
                        if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3" || MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.2")
                        {
                            pingname = "文件资源管理器.lnk";
                            _explorer = "File Explorer.lnk";
                            MyFunctions.ProgramAndLinksOperate.SetLink(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + _explorer, "PATH", Environment.GetEnvironmentVariable("WINDIR") + @"\EXPLORER.EXE");
                        }
                        else
                        {
                            pingname = "Windows 资源管理器.lnk";
                            _explorer = "Windows Explorer.lnk";
                            MyFunctions.ProgramAndLinksOperate.SetLink(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + _explorer, "PATH", Environment.GetEnvironmentVariable("WINDIR") + @"\EXPLORER.EXE");
                        }
                        break;
                }
                string linkpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + pingname;
                MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(false, linkpath);
                if (codename.ToUpper() == "EX")
                {
                    string linkpath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + _explorer;
                    MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(false, linkpath2);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(linkpath2);
                }
                MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
            }
        }
        public static void SystemStyle_LoadThisPCShowItems(UserControl_SystemStyle_SystemView user)
        {
            try
            {
                user.listView5.Items.Clear();
                user.imageList5.Images.Clear();
                string reg = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace";
                if (Registry.LocalMachine.OpenSubKey(reg) == null)
                {
                    MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer", "NameSpace", false);
                }
                string[] subnames = Registry.LocalMachine.OpenSubKey(reg).GetSubKeyNames();
                if (subnames.Length > 0)
                {
                    int h = 1;
                    string[] subnames_nodele;// = new string[subnames.Length  - 1];
                    int count = 0; ;
                    for (int p = 1; p <= subnames.Length; p++)
                    {
                        if (subnames[p - 1].ToUpper() != "DelegateFolders".ToUpper() && subnames[p - 1].Length == 38)
                        {
                            count = count + 1;
                        }
                    }
                    subnames_nodele = new string[count];
                    for (int j = 1; j <= subnames.Length; j++)
                    {
                        if (subnames[j - 1].ToUpper() != "DelegateFolders".ToUpper())
                        {
                            if (subnames[j - 1].Length == 38)
                            {
                                subnames_nodele[j - h] = subnames[j - 1];
                            }
                            else
                            {
                                h = h + 1;
                            }
                        }
                        else
                        {
                            h = h + 1;
                        }
                    }
                    for (int o = 1; o <= subnames_nodele.Length; o++)
                    {
                        string ico = MyFunctions.StreamAndTextOperate.TextOperate.GUIDOperate.GUIDOperate_GetGUIDRegistryIcon(subnames_nodele[o - 1]);
                        Bitmap img = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ico, "");
                        user.imageList5.Images.Add(img);
                        user.listView5.Items.Add(MyFunctions.StreamAndTextOperate.TextOperate.GUIDOperate.GUIDOperate_GetGUIDRegistryName(subnames_nodele[o - 1])).ImageIndex = o - 1;
                        user.listView5.Items[o - 1].Group = user.listView5.Groups[0];
                        user.listView5.Items[o - 1].Tag = subnames_nodele[o - 1];
                    }
                }

            }
            catch { }
        }
        public static void SystemStyle_SetLockPicture(string ImageFile)
        {
            if (System.IO.File.Exists(ImageFile) == true)
            {
                string sid = MyFunctions.ApplicationAndEnvironmentInformation.UserInfo.GetUserSID(); //获取SID
                if (sid != "")
                {
                    Size Pixel = MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetSrceenFenBianLv();
                    string TempImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\LockScreen.JPG";
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempImage);
                    MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_ConvetImage(System.Drawing.Image.FromFile(ImageFile), System.Drawing.Imaging.ImageFormat.Jpeg, Pixel.Width, Pixel.Height, TempImage);
                    ////////更改系统原先的图片所有权//////////
                    string Data_path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Microsoft\Windows\SystemData\" + sid + @"\ReadOnly";
                    string LockImage_path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Microsoft\Windows\SystemData\" + sid + @"\ReadOnly\LockScreen_A";
                    MyFunctions.FileSystemOperate.FileSystemOperate_GetAdminWithFolder(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Microsoft\Windows\SystemData");
                    MyFunctions.FileSystemOperate.FileSystemOperate_GetAdminWithFolder(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Microsoft\Windows\SystemData\" + sid);
                    MyFunctions.FileSystemOperate.FileSystemOperate_GetAdminWithFolder(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Microsoft\Windows\SystemData\" + sid + @"\ReadOnly");
                    MyFunctions.FileSystemOperate.FileSystemOperate_GetAdminWithFolder(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Microsoft\Windows\SystemData\" + sid + @"\ReadOnly\LockScreen_A");
                    if (System.IO.Directory.Exists(Data_path + @"\LockScreen_A") == false)
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(Data_path + @"\LockScreen_A");
                    }
                    string[] A_Images = MyFunctions.FileSystemOperate.FileSystemOperate_GetFiles(Data_path + @"\LockScreen_A", "*.JPG", SearchOption.TopDirectoryOnly);
                    for (int a = 1; a <= A_Images.Length; a++) { MyFunctions.FileSystemOperate.FileSystemOperate_GetAdminWithFile(A_Images[a - 1]); MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(A_Images[a - 1]); }
                    /////size
                    string _w, _h;
                    _w = Convert.ToString(Pixel.Width);
                    _h = Convert.ToString(Pixel.Height);
                    if (_w.Length == 3)
                    {
                        _w = "0" + _w;
                    }
                    if (_h.Length == 3)
                    {
                        _h = "0" + _h;
                    }
                    string temp_108 = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\LockScreen___0108_0108.JPG";
                    string temp_151 = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\LockScreen___0151_0151.JPG";
                    string temp_194 = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\LockScreen___0194_0194.JPG";
                    string temp_540 = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\LockScreen___0540_0337.JPG";
                    string temp_display = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\LockScreen___" + _w + "_" + _h + ".JPG";
                    ////convert
                    MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_ConvetImage(Image.FromFile(ImageFile), System.Drawing.Imaging.ImageFormat.Jpeg, 108, 108, temp_108);
                    MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_ConvetImage(Image.FromFile(ImageFile), System.Drawing.Imaging.ImageFormat.Jpeg, 151, 151, temp_151);
                    MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_ConvetImage(Image.FromFile(ImageFile), System.Drawing.Imaging.ImageFormat.Jpeg, 194, 194, temp_108);
                    MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_ConvetImage(Image.FromFile(ImageFile), System.Drawing.Imaging.ImageFormat.Jpeg, 540, 337, temp_540);
                    MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_ConvetImage(Image.FromFile(ImageFile), System.Drawing.Imaging.ImageFormat.Jpeg, Pixel.Width, Pixel.Height, temp_display);
                    ///Copy
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(TempImage, LockImage_path + @"\LockScreen.jpg");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temp_108, LockImage_path + @"\LockScreen___0108_0108.JPG");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temp_151, LockImage_path + @"\LockScreen___0151_0151.JPG");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temp_194, LockImage_path + @"\LockScreen___0194_0194.JPG");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temp_display, LockImage_path + @"\LockScreen___1440_0900.JPG");
                    /////AppData
                    string A_Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\LockScreen_A";
                    string U_Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\LockScreen_U";
                    string V_Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\LockScreen_V";
                    string W_Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\LockScreen_W";
                    string X_Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\LockScreen_X";
                    string Y_Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\LockScreen_Y";
                    string Z_Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\LockScreen_Z";
                    if (System.IO.Directory.Exists(A_Path) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(A_Path); }
                    if (System.IO.Directory.Exists(U_Path) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(U_Path); }
                    if (System.IO.Directory.Exists(V_Path) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(V_Path); }
                    if (System.IO.Directory.Exists(W_Path) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(W_Path); }
                    if (System.IO.Directory.Exists(X_Path) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(X_Path); }
                    if (System.IO.Directory.Exists(Y_Path) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(Y_Path); }
                    if (System.IO.Directory.Exists(Z_Path) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(Z_Path); }
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temp_540, A_Path + @"\LockScreen___0540_0337.jpg");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temp_540, U_Path + @"\LockScreen___0540_0337.jpg");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temp_540, V_Path + @"\LockScreen___0540_0337.jpg");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temp_540, W_Path + @"\LockScreen___0540_0337.jpg");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temp_540, X_Path + @"\LockScreen___0540_0337.jpg");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temp_540, Y_Path + @"\LockScreen___0540_0337.jpg");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temp_540, Z_Path + @"\LockScreen___0540_0337.jpg");
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempImage);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(temp_108);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(temp_151);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(temp_194);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(temp_540);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(temp_display);

                }
            }
        }
        public static void SystemStyle_RunCommands(UserControl_SystemStyle_SystemView user)
        {
            try
            {
                string[] cmds = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths").GetSubKeyNames();
                user.listView6.Items.Clear();
                user.imageList6.Images.Clear();
                for (int h = 1; h <= cmds.Length; h++)
                {
                    user.listView6.Items.Add(cmds[h - 1].Substring(0, cmds[h - 1].LastIndexOf(".")));
                    string program_path = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + cmds[h - 1]).GetValue("", "", RegistryValueOptions.None).ToString().Replace(@"""", "");
                    program_path = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(program_path, program_path);
                    string ico = "";
                    bool isok;
                    string extname = "";
                    if (program_path == "")
                    {
                        ico = Environment.GetEnvironmentVariable("windir") + @"\system32\imageres.dll,11";
                        isok = false;
                    }
                    else
                    {
                        ico = program_path;
                        if (System.IO.File.Exists(program_path) == true) { isok = true; extname = Path.GetExtension(program_path); } else { isok = false; }
                    }
                    if (isok == false)
                    {
                        user.listView6.Items[h - 1].ForeColor = Color.Red;
                    }
                    string ext_info = "";
                    switch (extname.ToUpper())
                    {
                        case ".EXE":
                            ext_info = "程序";
                            break;
                        case ".LNK":
                            ext_info = "快捷方式";
                            break;
                        case "":
                            ext_info = "";
                            break;
                        default:
                            ext_info = "未知";
                            break;
                    }

                    if (ext_info == "快捷方式")
                    {
                        string newico = MyFunctions.ProgramAndLinksOperate.ReadLink(program_path, "icon");
                        if (newico.Substring(0, 1) == ",")
                        {
                            newico = MyFunctions.ProgramAndLinksOperate.ReadLink(program_path, "path") + MyFunctions.ProgramAndLinksOperate.ReadLink(program_path, "icon");
                        }
                        ico = newico;
                    }
                    Bitmap img = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ico, "");
                    user.imageList6.Images.Add(img);
                    user.listView6.Items[h - 1].SubItems.Add(program_path);
                    user.listView6.Items[h - 1].ImageIndex = h - 1;
                    user.listView6.Items[h - 1].SubItems.Add(ext_info);
                    user.listView6.Items[h - 1].Tag = cmds[h - 1];
                    if (isok == true)
                    {
                        user.listView6.Items[h - 1].SubItems.Add("是");
                    }
                    else
                    {
                        user.listView6.Items[h - 1].SubItems.Add("否");
                    }
                    Application.DoEvents();
                }
            }
            catch { }
        }
        public static void SystemGear_GetJIEQIEBAN(UserControl_SystemStyle_SystemView user)
        {
            if (Clipboard.GetDataObject() != null)
            {
                IDataObject data = Clipboard.GetDataObject();
                if (data.GetDataPresent(DataFormats.Bitmap))
                {
                    //MessageBox.Show("图片");
                    user.button183.Text = "保存图片";
                    user.button183.Visible = true;
                    Image image1 = (Image)data.GetData(DataFormats.Bitmap, true);
                    user.label143.Text = "当前剪切板的内容 : 图片";
                    user.pictureBox63.Location = new Point(7, 67);
                    user.pictureBox63.Size = new Size(490, 257);
                    user.pictureBox63.Image = image1;
                    user.pictureBox63.Visible = true;
                    user.panel41.Visible = user.textBox_JQB_TEXT.Visible = false;
                }
                else
                {
                    if (data.GetDataPresent(DataFormats.Text))
                    {
                        // MessageBox.Show("文本");
                        user.button183.Text = "保存文本";
                        user.button183.Visible = true;
                        string txt = (string)data.GetData(DataFormats.Text, true);
                        user.label143.Text = "当前剪切板的内容 : 文本";
                        user.textBox_JQB_TEXT.Text = txt;
                        user.textBox_JQB_TEXT.Location = new Point(7, 67);
                        user.textBox_JQB_TEXT.Size = new Size(490, 257);
                        user.textBox_JQB_TEXT.Visible = true;
                        user.panel41.Visible = user.pictureBox63.Visible = false;
                    }
                    else
                    {
                        if (data.GetDataPresent(DataFormats.FileDrop))
                        {
                            //MessageBox.Show("文件");
                            user.button183.Text = "复制文件(夹)";
                            user.button183.Visible = true;
                            user.label143.Text = "当前剪切板的内容 : 被选中的文件或文件夹";
                            string[] strs = Clipboard.GetData(DataFormats.FileDrop) as string[];
                            user.panel41.Location = new Point(5, 66);
                            user.panel41.Size = new Size(506, 93);
                            user.panel41.Visible = true;
                            string fileitems = "";
                            user.textBox_JQB_TEXT.Visible = user.pictureBox63.Visible = false;
                            for (int o = 1; o <= strs.Length; o++)
                            {
                                if (o < strs.Length)
                                {
                                    fileitems = fileitems + strs[o - 1] + "|";
                                }
                                else
                                {
                                    fileitems = fileitems + strs[o - 1];
                                }
                                Application.DoEvents();
                            }
                            user.textBox_JQB_ORGFILE.Text = fileitems;
                        }
                        else
                        {
                            if (data.GetDataPresent(DataFormats.WaveAudio))
                            {
                                //MessageBox.Show("音乐");
                                user.label143.Text = "当前剪切板的内容 : WAV音频格式（暂不支持）";
                                user.pictureBox63.Visible = user.textBox_JQB_TEXT.Visible = user.panel41.Visible = false;
                                user.button183.Visible = false;
                            }
                            else
                            {
                                if (data.GetDataPresent(DataFormats.Tiff))
                                {
                                    //MessageBox.Show("TIFF图片");
                                    user.label143.Text = "当前剪切板的内容 : TIFF图像格式（暂不支持）";
                                    user.pictureBox63.Visible = user.textBox_JQB_TEXT.Visible = user.panel41.Visible = false;
                                    user.button183.Visible = false;
                                }
                                else
                                {
                                    //MyFunctions.Dialogs.MessageDialog("注意", "当前的剪切板没有内容或该内容无法识别", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定", null);
                                    user.label143.Text = "当前剪切板无内容或内容不被支持";
                                    user.pictureBox63.Visible = user.textBox_JQB_TEXT.Visible = user.panel41.Visible = false;
                                    user.button183.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                //MyFunctions.Dialogs.MessageDialog("注意", "当前的剪切板为空", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定", null);
            }
        }
        public static void SystemStyle_SaveJQBObjectInCommandLineWithOOBEFile(string FolderName, Form_Main frm)
        {
            string date = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            try
            {
                if (FolderName == "")
                {
                    MyFunctions.Dialogs.MessageDialog("错误", "文件名称或路径不能为空", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "是", "确定");
                    return;
                }
                if (FolderName.Length == 3)
                {
                    FolderName = FolderName.Substring(0, 2);
                }
                string sgcf = Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf";
                if (Clipboard.GetDataObject() != null)
                {
                    IDataObject data = Clipboard.GetDataObject();
                    if (data.GetDataPresent(DataFormats.Bitmap))
                    {
                        //MessageBox.Show("图片");
                        Image image1 = (Image)data.GetData(DataFormats.Bitmap, true);
                        string isauto = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("autoanswer", "image", "f", false, sgcf).ToUpper();
                        if (isauto == "T")
                        {
                            int size_w, size_h;
                            if (MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "size_w", "0", false, sgcf).ToUpper() == "") { size_w = image1.Size.Width; } else { size_w = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "size_w", "0", false, sgcf), image1.Size.Width); }
                            if (MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "size_h", "0", false, sgcf).ToUpper() == "") { size_h = image1.Size.Height; } else { size_h = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "size_h", "0", false, sgcf), image1.Size.Height); }
                            string imgtype = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "type", "PNG", false, sgcf).ToUpper();
                            string folder = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "folder", "U", false, sgcf).ToUpper();
                            string savepath;
                            if (folder == "U")
                            {
                                savepath = FolderName;
                            }
                            else
                            {
                                savepath = folder;
                            }
                            string ext;
                            System.Drawing.Imaging.ImageFormat fomt;
                            switch (imgtype.ToUpper())
                            {
                                case "PNG":
                                    fomt = System.Drawing.Imaging.ImageFormat.Png;
                                    ext = ".png";
                                    break;
                                case "BMP":
                                    fomt = System.Drawing.Imaging.ImageFormat.Bmp;
                                    ext = ".bmp";
                                    break;
                                case "GIF":
                                    fomt = System.Drawing.Imaging.ImageFormat.Gif;
                                    ext = ".gif";
                                    break;
                                default:
                                    fomt = System.Drawing.Imaging.ImageFormat.Jpeg;
                                    ext = ".jpg";
                                    break;
                            }
                            if (System.IO.Directory.Exists(savepath) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(savepath); }
                            string filen = savepath + @"\剪切板的图片 " + date + ext;
                            if (System.IO.File.Exists(filen) == true)
                            {
                                string res = MyFunctions.Dialogs.MessageDialog("继续?", "系统齿轮在同一目录下找到了文件名相同的文件,是否要替换旧文件?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                                if (res == "B1")
                                {
                                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(filen);
                                    Image save = new Bitmap(image1, size_w, size_h);
                                    save.Save(filen, fomt);
                                }
                            }
                            else
                            {
                                Image save = new Bitmap(image1, size_w, size_h);
                                save.Save(filen, fomt);
                            }
                            if (System.IO.File.Exists(filen) == true)
                            {
                                MyFunctions.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(filen);
                            }
                        }
                        else
                        {

                            string f = FolderName + @"\剪切板的图片 " + date + ".png";
                            if (System.IO.Directory.Exists(FolderName) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(FolderName); }
                            Image imgnew = new Bitmap(image1, image1.Size.Width, image1.Size.Height);
                            if (System.IO.File.Exists(f) == true)
                            {
                                string res = MyFunctions.Dialogs.MessageDialog("继续?", "系统齿轮在同一目录下找到了文件名相同的文件,是否要替换旧文件?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                                if (res == "B1")
                                {
                                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(f);
                                    imgnew.Save(f, System.Drawing.Imaging.ImageFormat.Png);
                                }
                            }
                            else
                            {
                                //MessageBox.Show(f);
                                imgnew.Save(f, System.Drawing.Imaging.ImageFormat.Png);
                            }
                        }
                    }
                    else
                    {
                        if (data.GetDataPresent(DataFormats.Text))
                        {
                            string text = (string)data.GetData(DataFormats.Text, true);
                            string isauto = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("autoanswer", "text", "f", false, sgcf).ToUpper();
                            if (isauto == "T")
                            {
                                string imgtype = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("text", "type", "txt", false, sgcf).ToUpper();
                                string folder = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("text", "folder", "U", false, sgcf).ToUpper();
                                string savepath = FolderName;
                                if (folder != "U") { savepath = folder; }
                                if (System.IO.Directory.Exists(savepath) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(savepath); }
                                switch (imgtype)
                                {
                                    case "RTF":
                                        string save_rtf = savepath + @"\剪切板的文本 " + date + ".rtf";
                                        if (System.IO.File.Exists(save_rtf) == true)
                                        {
                                            string res = MyFunctions.Dialogs.MessageDialog("继续?", "系统齿轮在同一目录下找到了文件名相同的文件,是否要替换旧文件?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                                            if (res == "B1")
                                            {
                                                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(save_rtf);
                                                RichTextBox rich = new RichTextBox();
                                                frm.Controls.Add(rich);
                                                rich.Text = text;
                                                rich.SaveFile(save_rtf);
                                                rich.Dispose();
                                            }
                                        }
                                        else
                                        {
                                            RichTextBox rich = new RichTextBox();
                                            frm.Controls.Add(rich);
                                            rich.Text = text;
                                            rich.SaveFile(save_rtf);
                                            rich.Dispose();
                                        }
                                        if (System.IO.File.Exists(save_rtf) == true) { MyFunctions.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(save_rtf); }
                                        break;
                                    default:
                                        string txtpath = savepath + @"\剪切板的文本 " + date + ".txt";
                                        if (System.IO.File.Exists(txtpath) == true)
                                        {
                                            string res = MyFunctions.Dialogs.MessageDialog("继续?", "系统齿轮在同一目录下找到了文件名相同的文件,是否要替换旧文件?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                                            if (res == "B1")
                                            {
                                                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(txtpath);
                                                MyFunctions.StreamAndTextOperate.TextOperate.SaveTextFile(txtpath, text);
                                            }
                                        }
                                        else
                                        {
                                            MyFunctions.StreamAndTextOperate.TextOperate.SaveTextFile(txtpath, text);
                                        }
                                        if (System.IO.File.Exists(txtpath) == true) { MyFunctions.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(txtpath); }
                                        break;
                                }
                            }
                            else
                            {
                                if (System.IO.Directory.Exists(FolderName) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(FolderName); }
                                string txtpath = FolderName + @"\剪切板的文本 " + date + ".txt";
                                if (System.IO.File.Exists(txtpath) == true)
                                {
                                    string res = MyFunctions.Dialogs.MessageDialog("继续?", "系统齿轮在同一目录下找到了文件名相同的文件,是否要替换旧文件?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                                    if (res == "B1")
                                    {
                                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(txtpath);
                                        MyFunctions.StreamAndTextOperate.TextOperate.SaveTextFile(txtpath, text);
                                        //if (System.IO.File.Exists(txtpath) == true) { MyFunctions.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(txtpath); }
                                    }
                                }
                                else
                                {
                                    MyFunctions.StreamAndTextOperate.TextOperate.SaveTextFile(txtpath, text);
                                    //if (System.IO.File.Exists(txtpath) == true) { MyFunctions.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(txtpath); }
                                }

                            }
                        }
                        else
                        {
                            if (data.GetDataPresent(DataFormats.FileDrop))
                            {
                                string[] filesandfolders = (string[])data.GetData(DataFormats.FileDrop, true);
                                string isauto = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("autoanswer", "files", "f", false, sgcf).ToUpper();
                                if (isauto == "T")
                                {
                                    string folder = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("files", "folder", "U", false, sgcf).ToUpper();
                                    string copydir = FolderName;
                                    if (folder != "U") { copydir = folder; }
                                    if (System.IO.Directory.Exists(copydir) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(copydir); }
                                    if (filesandfolders.Length == 1)
                                    {
                                        if (System.IO.Directory.Exists(copydir) == true)
                                        {
                                            MyFunctions.Dialogs.CopyFilesWithSystemProcessDialog(filesandfolders, copydir);
                                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("explorer.exe", @"""" + copydir + @"""", false, false, false, false, false);
                                        }
                                    }
                                    else
                                    {
                                        if (filesandfolders.Length != 0)
                                        {
                                            if (System.IO.Directory.Exists(copydir) == true)
                                            {
                                                MyFunctions.Dialogs.CopyFilesWithSystemProcessDialog(filesandfolders, copydir);
                                                MyFunctions.ProgramAndLinksOperate.ShellPrograms("explorer.exe", @"""" + copydir + @"""", false, false, false, false, false);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    string n = FolderName;
                                    n = n.Replace(@"""", "");
                                    if (System.IO.Directory.Exists(FolderName) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(FolderName); }
                                    MyFunctions.Dialogs.CopyFilesWithSystemProcessDialog(filesandfolders, n);
                                    //MyFunctions.ProgramAndLinksOperate.ShellPrograms("explorer.exe", @"""" + FolderName + @"""", false, false, false, false, false, null);
                                }
                            }
                            else
                            {
                                MyFunctions.Dialogs.MessageDialog("注意!", "当前的剪切板的内容可能为空或内容不被系统齿轮所支持", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "是", "确定");
                            }
                        }
                    }
                }
            }
            catch { }
        }
        public static void SystemStyle_SaveJQBObjectInPanelOperate(string ClipText, string ClipFiles, Image ClipImage, string Type, System.Drawing.Imaging.ImageFormat ImageFormat, string FileName, string TXTEXT, UserControl_SystemStyle_SystemView user)
        {
            try
            {
                switch (Type.ToUpper())
                {
                    case "IMAGE":
                        Image image1 = ClipImage;
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(FileName);
                        image1.Save(FileName, ImageFormat);

                        break;
                    case "TEXT":
                        switch (TXTEXT.ToUpper())
                        {
                            case "TXT":
                                string txt = ClipText;
                                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(FileName);
                                MyFunctions.StreamAndTextOperate.TextOperate.SaveTextFile(FileName, txt);
                                break;
                            case "RTF":
                                string rtf = ClipText;
                                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(FileName);
                                RichTextBox rich = new RichTextBox();
                                user.Controls.Add(rich);
                                rich.Text = rtf;
                                rich.SaveFile(FileName);
                                rich.Dispose();
                                break;
                            case "LNK":
                                string text = ClipText;
                                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(FileName);
                                string linkpath = FileName;
                                MyFunctions.ProgramAndLinksOperate.CreateLink(linkpath, text, "", "", "", null);
                                break;
                        }
                        break;
                    case "FILES":
                        string[] files = ClipFiles.Split('|');
                        MyFunctions.Dialogs.CopyFilesWithSystemProcessDialog(files, FileName);
                        break;
                }
            }
            catch { }
        }
        public static void SystemStyle_RegistryClipExt()
        {
            try
            {
                string ico = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.IconResources, "RightMenuGroup_Clipbord", false);
                string MainName = "ClipToFile";
                //MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\background\shell", MainName, false, null);
                //MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\shell", MainName, false, null);
                ///
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"Directory\background\shell\", MainName, false); //DESKTOP
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "Command", false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\background\shell\" + MainName + @"\Command", "", Application.ExecutablePath+@" /C /Folder=""%V""", RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "Icon", ico, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "MUIVerb", "将剪切板内容保存为文件", RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "Position", "Top", RegistryValueKind.String, false, false);
                ///
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"Directory\shell\", MainName, false); //FOLDER
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"Directory\shell\" + MainName, "Command", false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\shell\" + MainName + @"\Command", "", Application.ExecutablePath+@" /C /Folder=""%V""", RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\shell\" + MainName, "Icon", ico, RegistryValueKind.String, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Directory\shell\" + MainName, "MUIVerb", "将剪切板内容保存为文件", RegistryValueKind.String, false, false);
                /*
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"Drive\shell\", MainName, false, null); //DISK ROOT
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"Drive\shell\" + MainName, "Command", false, null);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Drive\shell\" + MainName + @"\Command", "", Application.StartupPath + @"\SystemGear.exe /C /Folder=""%V""", RegistryValueKind.String, false, false, null);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Drive\shell\" + MainName, "Icon", ico, RegistryValueKind.String, false, false, null);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"Drive\shell\" + MainName, "MUIVerb", "将剪切板内容保存为文件", RegistryValueKind.String, false, false, null);
                */
            }
            catch { }
        }
        public static void SystemStyle_ChangeBootImage(string ImageFile)
        {
            try
            {
                if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\bootres.dll") == false)
                {
                    MyFunctions.Dialogs.MessageDialog("缺少文件", "系统中缺少bootres.dll", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                }
                else
                {
                    string backfile = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\Bootres.dll";
                    if (System.IO.File.Exists(backfile) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\bootres.dll", backfile); }
                    MyFunctions.FileSystemOperate.FileSystemOperate_GetAdminWithFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\bootres.dll");
                    string tempfile = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + "\\Temp") + "\\bootres.dll";
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\bootres.dll", tempfile);
                    if (System.IO.File.Exists(tempfile) == true)
                    {
                        string temppath = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp");
                        MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(temppath + @"\BootImage");
                        if (System.IO.Directory.Exists(temppath + @"\bootimage") == true)
                        {
                            MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(ImageFile, temppath + @"\BootImage\activity.bmp");
                            string wimfile = temppath + @"\BootImage.wim";
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\Programs\ImageX.exe", @"/capture """ + temppath + @"\BootImage"" """ + wimfile + @""" ""Boot Resource WIM"" /verify /compress maximum", true, false, true, false, true);
                            if (System.IO.File.Exists(wimfile) == true)
                            {
                                MyFunctions.FileSystemOperate.FileSystemOperate_ChangeFileResources(wimfile, temppath + @"\bootres.dll", "RCDATA", 1, 1033);
                                MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\programs\Makecert.exe", @"-r -ss my -n ""CN=TEST CA""", true, false, true, false, true);
                                MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\programs\Signtool.exe", @"sign -a """ + temppath + @"\bootres.dll""", true, false, true, false, true);
                                //MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\programs\editbin.exe", @"/RELEASE """ + temppath + @"\bootres.dll""", true, false, true, false, true, null);
                                //MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", " /set {current} testsigning on", true, false, true, false, true, null);
                                //MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(temppath + @"\bootres.dll", Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\bootres.dll");
                            }
                        }
                    }
                }
            }
            catch { }
        }
        public static void SystemStyle_LoadSendToMenu(UserControl_SystemStyle_SystemView user)
        {
            //try
            //{
            user.button190.Enabled = user.button191.Enabled = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo";
            string[] menus = MyFunctions.FileSystemOperate.FileSystemOperate_GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
            user.listView7.Items.Clear();
            user.imageList_Public.Images.Clear();
            int u = 1;
            for (int o = 1; o <= menus.Length; o++)
            {
                string file = menus[o - 1];
                string orgfile = file;
                string type = "";
                string ext;
                string cmd;
                file = file.Substring(path.Length, file.Length - path.Length).Replace("\\", "");
                ext = file.Substring(file.LastIndexOf("."), file.Length - file.LastIndexOf("."));
                file = file.Substring(0, file.LastIndexOf("."));
                if (file.ToUpper() != "DESKTOP")
                {
                    switch (ext.ToUpper())
                    {
                        case ".LNK":
                            type = "快捷方式";
                            cmd = orgfile;
                            break;
                        case ".CMD":
                            type = "批处理文件";
                            cmd = orgfile;
                            break;
                        case ".BAT":
                            type = "批处理文件";
                            cmd = orgfile;
                            break;
                        case ".EXE":
                            type = "应用程序";
                            cmd = orgfile;
                            break;
                        case ".MYDOCS":
                            type = "发送到文档";
                            cmd = orgfile;
                            break;
                        case ".ZFSENDTOTARGET":
                            type = "发送到压缩(Zipped)文件夹";
                            cmd = orgfile;
                            break;
                        case ".DESKLINK":
                            type = "发送到桌面快捷方式";
                            cmd = orgfile;
                            break;
                        case ".MAPIMAIL":
                            type = "发送到邮件收件人";
                            cmd = orgfile;
                            break;
                        default:
                            type = "未知";
                            cmd = orgfile;
                            break;
                    }
                    string addname = file;
                    switch (addname.ToUpper())
                    {
                        case "FAX RECIPIENT":
                            addname = "传真收件人";
                            break;
                        case "MAIL RECIPIENT":
                            addname = "邮件收件人";
                            break;
                        case "DESKTOP (CREATE SHORTCUT)":
                            addname = "桌面快捷方式";
                            break;
                        case "COMPRESSED (ZIPPED) FOLDER":
                            addname = "压缩(zipped)文件夹";
                            break;
                        case "DOCUMENTS":
                            addname = "文档";
                            break;
                    }
                    user.imageList_Public.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.GetFileIcon(orgfile).ToBitmap());
                    user.listView7.Items.Add(addname);
                    user.listView7.Items[o - u].ImageIndex = o - u;
                    user.listView7.Items[o - u].SubItems.Add(type);
                    user.listView7.Items[o - u].SubItems.Add(cmd);
                    Application.DoEvents();
                }
                else
                {
                    u = u + 1;
                }
            }
            //}
            //catch { }
        }
        public static Image  SystemStyle_SortingFile_LoadConditionToTile()
        {
            try
            {
                string cfg = Application.StartupPath + @"\config\SortingFileS\SortingFileConfig.sgcf";
                string type = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("Condition", "type", "", false, cfg);
                switch (type.ToLower())
                {
                    case "accordingname":
                        return Properties.Resources.ACCNAME;
                    case "accordingsize":
                        return Properties.Resources.ACCSIZE;
                    case "accordingextension":
                        return Properties.Resources.ACCEXTRANAME;
                    default:
                        return null;
                }
            }
            catch { return null; }
        }
        public static void SystemStyle_SortingFile_LoadCondition(UserControl_SystemStyle_SystemView user)
        {
            try
            {
                string cfg = Application.StartupPath + @"\config\SortingFileS\SortingFileConfig.sgcf";
                string type = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("Condition", "type", "", false, cfg);
                switch (type.ToLower())
                {
                    case "accordingname":
                        user.label160.Text = "根据文件名分拣文件";
                        user.pictureBox78.Image = Properties.Resources.ACCNAME;
                        break;
                    case "accordingsize":
                        user.label160.Text = "根据文件大小分拣文件";
                        user.pictureBox78.Image = Properties.Resources.ACCSIZE;
                        break;
                    case "accordingextension":
                        user.label160.Text = "根据文件类型分拣文件";
                        user.pictureBox78.Image = Properties.Resources.ACCEXTRANAME;
                        break;
                    default:
                        user.pictureBox78.Image = null;
                        user.label160.Text = "请设置一个条件";
                        break;
                }
            }
            catch { }
        }
        public static string SystemStyle_SortingFile_AccordingNameResult(string str, string filename)
        {
            try
            {
                FileInfo fi = new FileInfo(filename);
                if (fi.Exists == true)
                {
                    string name = fi.Name;
                    int k = name.IndexOf(".");
                    if (k > 0)
                    {
                        name = name.Substring(0, name.IndexOf("."));
                    }
                    int j = System.Text.RegularExpressions.Regex.Matches(name.ToUpper(), str.ToUpper()).Count;
                    if (j > 0) { return "True"; } else { return "False"; }
                }
                else { return "Error"; }
            }
            catch { return "Error"; }
        }
        public static string SystemStyle_SortingFile_AccordingExtraNameResult(string exts, string filename)
        {
            try
            {
                FileInfo fi = new FileInfo(filename);
                if (fi.Exists == true)
                {
                    string[] exts_arry = MyFunctions.StreamAndTextOperate.TextOperate.ConvertStringsToStringArry_ByString(exts, "|");
                    string ext = fi.Extension.Replace(".", "");
                    string res = "";
                    foreach (string v in exts_arry)
                    {
                        if (ext.ToUpper() == v.ToUpper()) { res = res + "T"; } else { res = res + "F"; }
                    }
                    res = res.Replace("F", "");
                    if (res.Length > 0)
                    {
                        return "True";
                    }
                    else { return "False"; }
                    //MessageBox.Show(res);
                }
                else { return "Error"; }
            }
            catch { return "Error"; }
        }
        public static string SystemStyle_SortingFile_AccordingFileSizeResult(string size, string tiaojian, string filename,string danwei)
        {
            try
            {
                FileInfo fi = new FileInfo(filename);
                if (fi.Exists == true)
                {
                    const int MB = 1024 * 1024;
                    const int KB = 1024;
                    const int Byte = 1;
                    long filesizebyte = fi.Length;
                    switch (danwei.ToUpper())
                    {
                        case "MB":
                            double filesizemb = filesizebyte / (float)MB;
                            double mbmin = Math.Floor(filesizemb);
                            double mbmax = Math.Ceiling(filesizemb);
                            int temp;
                            int.TryParse(size,out temp);
                            int verysizemb = temp;
                            switch (tiaojian)
                            {
                                case "=":
                                    if (verysizemb >= mbmin && verysizemb < mbmax) { return "True"; } else { return "False"; }
                                case ">":
                                    if (verysizemb > filesizemb) { return "True"; } else { return "False"; }
                                case "<":
                                    if (verysizemb < filesizemb) { return "True"; } else { return "False"; }
                                default:
                                    return "Error";
                            }
                            //break;
                        case "KB":
                            double filesizekb = filesizebyte / (float)KB;
                            double kbmin = Math.Floor(filesizekb);
                            double kbmax = Math.Ceiling(filesizekb);
                            int tempkb;
                            int.TryParse(size,out tempkb);
                            int verysizekb = tempkb;
                            switch (tiaojian)
                            {
                                case "=":
                                    if (verysizekb >= kbmin && verysizekb < kbmax) { return "True"; } else { return "False"; }
                                case ">":
                                    if (verysizekb > filesizekb) { return "True"; } else { return "False"; }
                                case "<":
                                    if (verysizekb < filesizekb) { return "True"; } else { return "False"; }
                                default:
                                    return "Error";
                            }
                            //break;
                        case "BY":
                             int tempbyte;
                            int.TryParse(size,out tempbyte);
                            int verysizebyte = tempbyte;
                            double filesizebyte1 = filesizebyte / (float)Byte;
                            double bytemin = Math.Floor(filesizebyte1);
                            double bytemax = Math.Ceiling(filesizebyte1);
                            switch (tiaojian)
                            {
                                case "=":
                                    if (verysizebyte >= bytemin && verysizebyte < bytemax) { return "True"; } else { return "False"; }
                                case ">":
                                    if (verysizebyte > filesizebyte1) { return "True"; } else { return "False"; }
                                case "<":
                                    if (verysizebyte < filesizebyte1) { return "True"; } else { return "False"; }
                                default:
                                    return "Error";
                            }
                            //break;
                        default:
                            return "Error";
                    }
                }
                else { return "Error"; }
            }
            catch { return "Error"; }
        }
        public static bool SystemStyle_SortingFile_PreviewChange(string folder, bool andsonfolder, string exceptfile)
        {
            try
            {
                if (System.IO.Directory.Exists(folder) == true)
                {
                    SearchOption s = SearchOption.TopDirectoryOnly;
                    if (andsonfolder == true) { s = SearchOption.AllDirectories; }

                    string[] files = MyFunctions.FileSystemOperate.FileSystemOperate_GetFiles(folder, "*.*", s);
                    if (exceptfile != "")
                    {
                        string[] extcepfs = exceptfile.Split('|');
                        var filesList = new List<string>();
                        var expfsList = new List<string>();
                        for (int o = 1; o <= files.Length; o++)
                        {
                            filesList.Add(files[o - 1].ToUpper());
                        }
                        for (int o = 1; o <= extcepfs.Length; o++)
                        {
                            expfsList.Add(extcepfs[o - 1].ToUpper());
                        }
                        //where (from o in oneList select o).Contains(i) 包含
                        //where !(from o in oneList select o).Contains(i) 不包含
                        var searchResult = from i in filesList
                                           where !(from o in expfsList select o).Contains(i) //包含
                                           select i;
                        //打印到屏幕
                        string j = "";
                        foreach (string num in searchResult)
                        {
                            Application.DoEvents();
                           if(j=="")
                           {
                               j = num;
                           }
                           else
                           {
                               j = j + "|" + num;
                           }
                        }
                        string[] nf = j.Split('|');
                        files = nf;
                    }
                    //已创建文件数组
                    string cfg = Application.StartupPath + @"\config\SortingFiles\SortingFileConfig.sgcf";
                    //string tempcfg = Application.StartupPath + @"\config\SortingFiles\SortingFiles.sgcf";
                    //先判断是否满足公共条件
                    string[] files_flags = new string[files.Length];
                    for (int p = 1; p <= files.Length; p++)
                    {
                        /*
                        string publiccnds = SystemStyle_SortingFile_GetFileManzuManytiaojian(files[p - 1]);
                        if (publiccnds.ToUpper() != "NOMANZU")
                        {
                            string po = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("PublicCondition", "operate", "", false, cfg);
                            files_flags[p - 1] = po;
                            //break;
                        }
                        else
                        {
                        */
                        string howdo = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("Condition", "howdo", "", false, cfg);
                        string operate = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("Condition", "operate", "", false, cfg);
                        string acc = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("Condition", "type", "", false, cfg).ToLower();
                        switch (acc)
                        {
                            case "accordingname":
                                string[] ops = operate.Split('|');
                                string v = SystemStyle_SortingFile_AccordingNameResult(howdo, files[p - 1]).ToUpper();
                                if (v.ToUpper() == "TRUE")
                                {
                                    files_flags[p - 1] = ops[0];
                                }
                                else
                                {
                                    if(v.ToUpper()=="FALSE")
                                    {
                                        files_flags[p - 1] = ops[1];
                                    }
                                    else
                                    {
                                        files_flags[p - 1] = "NoOperate";
                                    }
                                }
                                break;
                            case "accordingsize":
                                string[] ops2 = operate.Split('|');
                                string ot = howdo.Substring(howdo.Length - 2, 2);
                                string os = howdo.Substring(0,howdo.Length - 2);
                                string vdayu = SystemStyle_SortingFile_AccordingFileSizeResult(os, "<", files[p - 1],ot).ToUpper();
                                string vxiaoyu = SystemStyle_SortingFile_AccordingFileSizeResult(os, ">", files[p - 1],ot).ToUpper();
                                string vdenyu = SystemStyle_SortingFile_AccordingFileSizeResult(os, "=", files[p - 1],ot).ToUpper();
                                if (vxiaoyu == "TRUE")
                                {
                                    files_flags[p - 1] = ops2[0];
                                }
                                else
                                {
                                    if (vdenyu == "TRUE")
                                    {
                                        files_flags[p - 1] = ops2[1];
                                    }
                                    else
                                    {
                                        if(vdayu =="TRUE")
                                        {
                                            files_flags[p - 1] = ops2[2];
                                        }
                                        else
                                        {
                                            files_flags[p - 1] = "NoOperate";
                                        }
                                    }
                                }
                                break;
                            case "accordingextension":
                                string[] ops3 = operate.Split('|');
                                string v3 = SystemStyle_SortingFile_AccordingExtraNameResult(howdo, files[p - 1]).ToUpper();
                                if (v3.ToUpper() == "TRUE")
                                {
                                    files_flags[p - 1] = ops3[0];
                                }
                                else
                                {
                                    if (v3.ToUpper() == "FALSE")
                                    {
                                        files_flags[p - 1] = ops3[1];
                                    }
                                    else
                                    {
                                        files_flags[p - 1] = "NoOperate";
                                    }
                                }
                                break;

                        }

                    }
                    //开始设置操作的位置和代码
                    Form_SortingFileSettings f = new Form_SortingFileSettings("PREVIEW", files, files_flags);
                    f.ShowDialog();
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
        }
        
        public static void SystemStyle_LoadStartScreenColorSettingsInWin81(UserControl_SystemStyle_SystemView u,int index)
        {
            try
            {
                if(index==1)
                {
                    string reg = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent";
                    string creg = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, reg, "startcolor", "00000000", false, false);
                    int j;
                    int.TryParse(creg, out j);
                    Color c = ColorTranslator.FromWin32(j);
                    u.panel_STARTCOLOR.BackColor = c;
                    u.panel_STARTCOLOR.Tag = c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString();
                    u.radioButton7.Checked = true;
                }
                else
                {
                    if(index ==2)
                    {
                        string reg = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent";
                        string creg = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, reg, "AccentColor", "00000000", false, false);
                        int j;
                        int.TryParse(creg, out j);
                        Color c = ColorTranslator.FromWin32(j);
                        u.panel_STARTCOLOR.BackColor = c;
                        u.panel_STARTCOLOR.Tag = c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString();
                        u.radioButton8.Checked = true;
                    }
                }
            }
            catch { }
        }
        public static void SystemStyle_LoadWin81StartScreenSetting(UserControl_SystemStyle_SystemView user)
        {
            try
            {
                Application.DoEvents();
                string rl = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent";
                string j=MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, rl, "MotionAccentId_v1.00", "221", false, false);
                switch(j)
                {
                    case "221":
                        user.myNormalButton10.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton9.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "215":
                        user.myNormalButton9.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "222":
                        user.myNormalButton11.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton9.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "220":
                        user.myNormalButton12.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "214":
                        user.myNormalButton13.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "216":
                        user.myNormalButton14.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "202":
                        user.myNormalButton15.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "203":
                        user.myNormalButton16.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "210":
                        user.myNormalButton17.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "209":
                        user.myNormalButton18.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "200":
                        user.myNormalButton19.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "213":
                        user.myNormalButton20.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton9.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "205":
                        user.myNormalButton21.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "208":
                        user.myNormalButton22.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "201":
                        user.myNormalButton23.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "204":
                        user.myNormalButton24.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "212":
                        user.myNormalButton25.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "206":
                        user.myNormalButton26.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "217":
                        user.myNormalButton27.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton9.ButtonBorderColor = user.myNormalButton28.ButtonBorderColor = Color.White;
                        break;
                    case "219":
                        user.myNormalButton28.ButtonBorderColor = Color.FromArgb(0, 148, 255);
                        //////////////
                        user.myNormalButton10.ButtonBorderColor = user.myNormalButton11.ButtonBackColor = user.myNormalButton12.ButtonBorderColor = user.myNormalButton13.ButtonBorderColor = user.myNormalButton14.ButtonBorderColor = user.myNormalButton15.ButtonBorderColor = user.myNormalButton16.ButtonBorderColor = user.myNormalButton17.ButtonBorderColor = user.myNormalButton18.ButtonBorderColor = user.myNormalButton19.ButtonBorderColor
                            = user.myNormalButton20.ButtonBorderColor = user.myNormalButton21.ButtonBorderColor = user.myNormalButton22.ButtonBorderColor = user.myNormalButton23.ButtonBorderColor = user.myNormalButton24.ButtonBorderColor = user.myNormalButton25.ButtonBorderColor = user.myNormalButton26.ButtonBorderColor
                            = user.myNormalButton27.ButtonBorderColor = user.myNormalButton9.ButtonBorderColor = Color.White;
                        break;
                }
            }
            catch { }
        }
        
        public static void SystemStyle_LoadWin8Settings(UserControl_SystemStyle_SystemView u)
        {
            try
            {
                //边框大小
                string rl_border = @"Control Panel\Desktop\WindowMetrics";
                string size = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, rl_border, "PaddedBorderWidth", "0", false, false);
                size = size.Replace("-", "");
                int j;
                int.TryParse(size, out j);
                u.numericUpDown2.Value = j;
            }
            catch { }
        }
        public static void SystemStyle_ApplyWin8Settings(UserControl_SystemStyle_SystemView u,string type,string[] args)
        {
            try
            {
                switch(type.ToUpper())
                {
                    case "BORDER":
                        try
                        {
                            string si = args[0];
                            string rl_border = @"Control Panel\Desktop\WindowMetrics";
                            int k;
                            int.TryParse(si, out k);
                            if (k > 0) { si = "-" + k.ToString(); } else { si = k.ToString(); }
                            bool res= MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, rl_border, "PaddedBorderWidth", si, RegistryValueKind.String, false, false);
                            if(res==true)
                            {
                                MyFunctions.Dialogs.MessageDialog("应用成功", "成功更改了窗口边框的大小。注销登录后生效。", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                            }else
                            {
                                MyFunctions.Dialogs.MessageDialog("应用失败", "无法更改窗口边框的大小", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                            }
                        }
                        catch { MyFunctions.Dialogs.MessageDialog("应用失败", "无法更改窗口边框的大小", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定"); }
                        break;
                }
            }
            catch { }
        }
        public static void SystemStyle_LoadOtherSetting(UserControl_SystemStyle_SystemView u,string arg)
        {
            try
            {
                switch(arg.ToUpper())
                {
                    case "PREVIEWSIZE":
                        string l = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband";
                        string size = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.CurrentUser, l, "MinThumbSizePx", "300", false, false);
                        int j;
                        int.TryParse(size, out j);
                        u.numericUpDown3.Value = j;
                        break;
                }
            }
            catch { }
        }
        public static void SystemStyle_ApplyOtherSettings(UserControl_SystemStyle_SystemView u, string type, string[] args)
        {
            try
            {
                switch (type.ToUpper())
                {
                    case "PREVIEWSIZE":
                        try
                        {
                            string si = args[0];
                            string rl_border = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband";
                            int k;
                            int.TryParse(si, out k);
                            bool res = MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, rl_border, "MinThumbSizePx", k.ToString(), RegistryValueKind.DWord, false, false);
                            if (res == true)
                            {
                                MyFunctions.Dialogs.MessageDialog("应用成功", "成功更改了任务栏预览窗口的大小。注销登录后生效。", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                            }
                            else
                            {
                                MyFunctions.Dialogs.MessageDialog("应用失败", "无法更改任务栏预览窗口的大小", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                            }
                        }
                        catch { MyFunctions.Dialogs.MessageDialog("应用失败", "无法更改任务栏预览窗口的大小", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定"); }
                        break;
                }
            }
            catch { }
        }

        public static void SystemStyle_LoadTilesConfig(UserControl_SystemStyle_SystemView u)
        {
            try
            {
                string cfg = Application.StartupPath + @"\config\mytile.sgcf";
                string stand_name = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("StandardInfo", "name", "", false, cfg);
                string stand_shell = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("StandardInfo", "shell", "", false, cfg);
                string stand_backimage = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("StandardInfo", "backimage", "", false, cfg);
                string stand_forcecolor = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("StandardInfo", "forcecolor", "", false, cfg);
            }
            catch { }
        }
        public class RightMenuMgr
        {
            public static void LoadRightMenu(UserControl_SystemStyle_SystemView u,string type)
            {
                //try
               // {
                    switch (type.ToUpper())
                    {
                        case "MC":
                            u.listView8.Items.Clear();
                            u.imageList_Public.Images.Clear();
                            ReadRightMenu_MyComputer(u.listView8,u.imageList_Public);
                                break;
                        case "RB":
                                u.listView8.Items.Clear();
                                u.imageList_Public.Images.Clear();
                                ReadRightMenu_RB(u.listView8, u.imageList_Public);
                                break;
                    }
                //}
                //catch { }
            }
            public static void ReadRightMenu_RB(ListView list, ImageList imglist)
            {
                try
                {
                    string cfg = Application.StartupPath + @"\Config\RightMenuInfo\RM_RB.sgcf";
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(cfg);
                    string reglocation = @"CLSID\{645FF040-5081-101B-9F08-00AA002F954E}";
                    string[] keys = MyFunctions.RegistryOperate.RegistryOperate_GetSubkeys(Registry.ClassesRoot, reglocation + @"\shell");
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "Count", keys.Length.ToString(), "Config", false, cfg);
                    for (int j = 1; j <= keys.Length; j++)
                    {
                        string name, regname, filenameorclsid, publisher, icon;
                        string filename, fileinfo, filepath, registrylocation;
                        filename = fileinfo = filepath = "Unknown";
                        //设置regname
                        regname = keys[j - 1];
                        //读取name
                        string rd_name = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1], "", "Unknown", false, false);
                        if (rd_name == "Unknown")
                        {
                            rd_name = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1], "muiverb", "Unknown", false, false);
                        }
                        if (rd_name == "Unknown")
                        {
                            rd_name = keys[j - 1];
                        }
                        string getname = rd_name;
                        if (rd_name.Length > 0)
                        {
                            switch (rd_name.Substring(0, 1))
                            {
                                case "@":
                                    string fn = rd_name.Substring(1, rd_name.LastIndexOf(",") - 1);
                                    string ix = rd_name.Substring(rd_name.LastIndexOf(",") + 1, rd_name.Length - rd_name.LastIndexOf(",") - 1).Replace("-", "");
                                    fn = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertNoCompeletLocationToTureLocation(fn, fn);
                                    uint ix_uint;
                                    uint.TryParse(ix, out ix_uint);
                                    getname = MyFunctions.MediaAndResourcesOperate.LoadResources.LoadResources_GetMUIString(fn, ix_uint);
                                    break;
                                case "{":
                                    string rrdd = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, "\\clsid\\" + rd_name, "", rd_name, false, false);
                                    getname = rrdd;
                                    break;
                            }
                        }
                        name = getname;
                        //获取filenameorclsid
                        string exe = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1] + @"\command", "", "Unknown", false, false);
                        if(exe=="Unknown")
                        {
                            filenameorclsid = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1] + @"\command", "DelegateExecute", "Unknown", false, false);
                        }
                        else
                        {
                            filenameorclsid = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(exe, exe);
                        }
                        //获取publisher和文件的信息
                        string pub = "Unknown";
                        if (System.IO.File.Exists(filenameorclsid) == true)
                        {
                            FileInfo fin = new FileInfo(filenameorclsid);
                            filename = fin.Name;
                            filepath = filenameorclsid;
                            FileVersionInfo jjj = FileVersionInfo.GetVersionInfo(filenameorclsid);
                            pub = jjj.CompanyName;
                            fileinfo = jjj.FileDescription;
                        }
                        else
                        {
                            if(filenameorclsid.Length >0)
                            {
                                if(filenameorclsid.Substring(0,1)=="{")
                                {
                                    string serverprogram = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, @"clsid\" + filenameorclsid + @"\InProcServer32", "", "Unknown", false, false);
                                    FileInfo fin = new FileInfo(serverprogram);
                                    filename = fin.Name;
                                    filepath = fin.ToString();
                                    FileVersionInfo jjj = FileVersionInfo.GetVersionInfo(serverprogram );
                                    pub = jjj.CompanyName;
                                    fileinfo = jjj.FileDescription;
                                }
                            }
                        }
                        publisher = pub;
                        //获取注册表位置
                        registrylocation = "HKEY_CLASSES_ROOT\\" + reglocation + "\\" + keys[j - 1];
                        //画ico
                        icon = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1], "icon", exe, false, false);
                        icon=MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(icon, icon);
                        if (icon.Length > 0)
                        {
                            if (icon.Substring(0, 1) == "@")
                            {
                                icon = icon.Substring(1, icon.Length - 1);
                            }
                        }
                        Bitmap bmp = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(icon, icon);
                        imglist.Images.Add(bmp);
                        //写入信息
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "RegName", regname, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "Name", name, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "EXEOrCLSIDPath", filenameorclsid, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "Publisher", publisher, "Config", false, cfg);
                        ////////文件信息
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "FileName", filename, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "FileInfo", fileinfo, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "FilePath", filepath, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "Icon", icon, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "RegistryLocation", registrylocation, "Config", false, cfg);
                        list.Items.Add(regname).Tag = "RM_" + j.ToString();
                        list.Items[j - 1].ImageIndex = j - 1;
                        list.Items[j - 1].SubItems.Add(name);
                        list.Items[j - 1].SubItems.Add(filenameorclsid);
                        list.Items[j - 1].SubItems.Add(publisher);
                    }
                }
                catch { }
            }
            public static void ReadRightMenu_MyComputer(ListView list, ImageList imglist)
            {
                try
                {
                    string cfg = Application.StartupPath + @"\Config\RightMenuInfo\RM_MyComputer.sgcf";
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(cfg);
                    string reglocation = @"CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    string[] keys = MyFunctions.RegistryOperate.RegistryOperate_GetSubkeys(Registry.ClassesRoot, reglocation + @"\shell");
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "Count", keys.Length.ToString(), "Config", false, cfg);
                    for (int j = 1; j <= keys.Length; j++)
                    {
                        string name, regname, filenameorclsid, publisher, icon;
                        string filename, fileinfo, filepath, registrylocation;
                        filename = fileinfo = filepath = "Unknown";
                        //设置regname
                        regname = keys[j - 1];
                        //读取name
                        string rd_name = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1], "", "Unknown", false, false);
                        if (rd_name == "Unknown")
                        {
                            rd_name = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1], "muiverb", "Unknown", false, false);
                        }
                        if (rd_name == "Unknown")
                        {
                            rd_name = keys[j - 1];
                        }
                        string getname = rd_name;
                        if (rd_name.Length > 0)
                        {
                            switch (rd_name.Substring(0, 1))
                            {
                                case "@":
                                    string fn = rd_name.Substring(1, rd_name.LastIndexOf(",") - 1);
                                    string ix = rd_name.Substring(rd_name.LastIndexOf(",") + 1, rd_name.Length - rd_name.LastIndexOf(",") - 1).Replace("-", "");
                                    fn = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertNoCompeletLocationToTureLocation(fn, fn);
                                    uint ix_uint;
                                    uint.TryParse(ix, out ix_uint);
                                    getname = MyFunctions.MediaAndResourcesOperate.LoadResources.LoadResources_GetMUIString(fn, ix_uint);
                                    break;
                                case "{":
                                    string rrdd = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, "\\clsid\\" + rd_name, "", rd_name, false, false);
                                    getname = rrdd;
                                    break;
                            }
                        }
                        name = getname;
                        //获取filenameorclsid
                        string exe = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1] + @"\command", "", "Unknown", false, false);
                        if (exe == "Unknown")
                        {
                            filenameorclsid = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1] + @"\command", "DelegateExecute", "Unknown", false, false);
                        }
                        else
                        {
                            filenameorclsid = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(exe, exe);
                        }
                        //获取publisher和文件的信息
                        string pub = "Unknown";
                        if (System.IO.File.Exists(filenameorclsid) == true)
                        {
                            FileInfo fin = new FileInfo(filenameorclsid);
                            filename = fin.Name;
                            filepath = filenameorclsid;
                            FileVersionInfo jjj = FileVersionInfo.GetVersionInfo(filenameorclsid);
                            pub = jjj.CompanyName;
                            fileinfo = jjj.FileDescription;
                        }
                        else
                        {
                            if (filenameorclsid.Length > 0)
                            {
                                if (filenameorclsid.Substring(0, 1) == "{")
                                {
                                    string serverprogram = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, @"clsid\" + filenameorclsid + @"\InProcServer32", "", "Unknown", false, false);
                                    FileInfo fin = new FileInfo(serverprogram);
                                    filename = fin.Name;
                                    filepath = fin.ToString();
                                    FileVersionInfo jjj = FileVersionInfo.GetVersionInfo(serverprogram);
                                    pub = jjj.CompanyName;
                                    fileinfo = jjj.FileDescription;
                                }
                            }
                        }
                        publisher = pub;
                        //获取注册表位置
                        registrylocation = "HKEY_CLASSES_ROOT\\" + reglocation + "\\" + keys[j - 1];
                        //画ico
                        icon = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1], "icon", exe, false, false);
                        icon = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(icon, icon);
                        if (icon.Length > 0)
                        {
                            if (icon.Substring(0, 1) == "@")
                            {
                                icon = icon.Substring(1, icon.Length - 1);
                            }
                        }
                        Bitmap bmp = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(icon, icon);
                        imglist.Images.Add(bmp);
                        //写入信息
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "RegName", regname, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "Name", name, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "EXEOrCLSIDPath", filenameorclsid, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "Publisher", publisher, "Config", false, cfg);
                        ////////文件信息
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "FileName", filename, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "FileInfo", fileinfo, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "FilePath", filepath, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "Icon", icon, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "RegistryLocation", registrylocation, "Config", false, cfg);
                        list.Items.Add(regname).Tag = "RM_" + j.ToString();
                        list.Items[j - 1].ImageIndex = j - 1;
                        list.Items[j - 1].SubItems.Add(name);
                        list.Items[j - 1].SubItems.Add(filenameorclsid);
                        list.Items[j - 1].SubItems.Add(publisher);
                    }
                }
                catch { }
            }
            public static void ReadRightMenu_MusicFolder(ListView list, ImageList imglist)
            {
                try
                {
                    string cfg = Application.StartupPath + @"\Config\RightMenuInfo\RM_MyComputer.sgcf";
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(cfg);
                    string reglocation = @"CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    string[] keys = MyFunctions.RegistryOperate.RegistryOperate_GetSubkeys(Registry.ClassesRoot, reglocation + @"\shell");
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "Count", keys.Length.ToString(), "Config", false, cfg);
                    for (int j = 1; j <= keys.Length; j++)
                    {
                        string name, regname, filenameorclsid, publisher;
                        string filename, fileinfo, filepath, registrylocation;
                        filename = fileinfo = filepath = "Unknown";
                        //设置regname
                        regname = keys[j - 1];
                        //读取name
                        string rd_name = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1], "", "Unknown", false, false);
                        string getname = rd_name;
                        if (rd_name.Length > 0)
                        {
                            switch (rd_name.Substring(0, 1))
                            {
                                case "@":
                                    string fn = rd_name.Substring(1, rd_name.LastIndexOf(",") - 1);
                                    string ix = rd_name.Substring(rd_name.LastIndexOf(",") + 1, rd_name.Length - rd_name.LastIndexOf(",") - 1).Replace("-", "");
                                    uint ix_uint;
                                    uint.TryParse(ix, out ix_uint);
                                    getname = MyFunctions.MediaAndResourcesOperate.LoadResources.LoadResources_GetMUIString(fn, ix_uint);
                                    break;
                                case "{":
                                    string rrdd = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, "\\clsid\\" + rd_name, "", rd_name, false, false);
                                    getname = rrdd;
                                    break;
                            }
                        }
                        name = getname;
                        //获取filenameorclsid
                        string exe = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, reglocation + @"\shell\" + keys[j - 1] + @"\command", "", "Unknown", false, false);
                        filenameorclsid = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(exe, exe);
                        //获取publisher和文件的信息
                        string pub = "Unknown";
                        if (System.IO.File.Exists(filenameorclsid) == true)
                        {
                            FileInfo fin = new FileInfo(filenameorclsid);
                            filename = fin.Name;
                            filepath = filenameorclsid;
                            FileVersionInfo jjj = FileVersionInfo.GetVersionInfo(filenameorclsid);
                            pub = jjj.CompanyName;
                            fileinfo = jjj.FileDescription;
                        }
                        publisher = pub;
                        //获取注册表位置
                        registrylocation = "HKEY_CLASSES_ROOT\\" + reglocation + "\\" + keys[j - 1];
                        //画ico
                        Bitmap bmp = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(filename, filename);
                        imglist.Images.Add(bmp);
                        //写入信息
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "RegName", regname, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "Name", name, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "EXEOrCLSIDPath", filenameorclsid, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "Publisher", publisher, "Config", false, cfg);
                        ////////文件信息
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "FileName", filename, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "FileInfo", fileinfo, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "FilePath", filepath, "Config", false, cfg);
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("RM_" + j.ToString(), "RegistryLocation", registrylocation, "Config", false, cfg);
                        list.Items.Add(regname).Tag = "RM_" + j.ToString();
                        list.Items[j - 1].ImageIndex = j - 1;
                        list.Items[j - 1].SubItems.Add(name);
                        list.Items[j - 1].SubItems.Add(filenameorclsid);
                        list.Items[j - 1].SubItems.Add(publisher);
                    }
                }
                catch { }
            }
        }
        #region 这是函数 不要删
        private const int MAX_PATH = 256;

        private const uint SHGFI_ICON = 0x000000100;
        private const uint SHGFI_LINKOVERLAY = 0x000008000;
        private const uint SHGFI_LARGEICON = 0x000000000;
        private const uint SHGFI_SMALLICON = 0x000000001;
        private const uint SHGFI_OPENICON = 0x000000002;
        private const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;

        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public const int NAMESIZE = 80;
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
            public string szTypeName;
        };

        [DllImport("Shell32.dll")]
        private static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbFileInfo,
            uint uFlags
            );

        [DllImport("User32.dll")]
        private static extern int DestroyIcon(IntPtr hIcon);
        #endregion
    }
}

