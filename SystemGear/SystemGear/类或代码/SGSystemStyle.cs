using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using Microsoft;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Security.Principal;
using System.Xml;
using SystemGear.控件;
using System.Threading;
using System.Linq;
using System.ServiceProcess;

namespace SystemGear
{
    class SGSystemStyle
    {
        
        public class LoadSkin
        {
            public static void LoadColorSetting(SGForm_Function_SystemStyle s)
            {
                try
                {
                    Color dialog_mian_back = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_main", "bk");
                    Color dialog_mian_bd = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_main", "bd");
                    Color dialog_mian_ptfr = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_main", "pt_tit_fc");
                    Color dialog_stand_bd = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_standard", "bd");
                    Color dialog_stand_bk = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_standard", "bk");
                    Color sgtab_bak = SGFunction.Skins.Skins_GetControlColorSetting("SGTAB", "BK");
                    Color sgtab_fr = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "fr");
                    Color sgtab_sbak = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "sb");
                    Color sgtab_sfr = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "sf");
                    Color sgtab_panelc = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "pc");
                    Color sgtab_bd = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "bd");
                    Color lf_bk = SGFunction.Skins.Skins_GetControlColorSetting("leftmenu", "bk");
                    Color lf_fr = SGFunction.Skins.Skins_GetControlColorSetting("leftmenu", "fr");
                    Color lf_sbk = SGFunction.Skins.Skins_GetControlColorSetting("leftmenu", "sb");
                    Color lf_sfr = SGFunction.Skins.Skins_GetControlColorSetting("leftmenu", "sf");
                    Color tree_line = SGFunction.Skins.Skins_GetControlColorSetting("treeview", "lc");

                    //皮肤
                    Image p_top_left = SGFunction.Skins.GetSkinPictures("top_left");
                    Image p_top = SGFunction.Skins.GetSkinPictures("top");
                    Image p_zhe1 = SGFunction.Skins.GetSkinPictures("top_zhe1");
                    Image p_zhe2 = SGFunction.Skins.GetSkinPictures("top_zhe2");
                    Image p_zhe3 = SGFunction.Skins.GetSkinPictures("top_zhe3");
                    Image p_zhe4 = SGFunction.Skins.GetSkinPictures("top_zhe4");
                    Image p_zhe5 = SGFunction.Skins.GetSkinPictures("top_zhe5");
                    s.myNormalButton_changeskin.FlatAppearance.MouseDownBackColor = s.MyNormalButton_moresetting.FlatAppearance.MouseDownBackColor = s.MyNormalButton_min.FlatAppearance.MouseDownBackColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "light");
                    s.myNormalButton_changeskin.FlatAppearance.MouseOverBackColor = s.MyNormalButton_moresetting.FlatAppearance.MouseOverBackColor = s.MyNormalButton_min.FlatAppearance.MouseOverBackColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
                    s.BackColor = s.panel_topleft.BackColor = s.panel_top.BackColor = dialog_mian_back; s.label2.ForeColor = dialog_mian_ptfr;
                    //s.MyNormalButton_min.BackColor = s.MyNormalButton_close.BackColor =s.MyNormalButton_moresetting.BackColor = zhe_back;
                    //sgitems
                    s.sgItems1.Settings_DefaultColor = lf_bk;
                    s.sgItems1.Settings_DefaultFontColor = lf_fr;
                    s.sgItems1.Settings_SelectColor = lf_sbk;
                    s.sgItems1.Settings_SelectFontColor = lf_sfr;
                    s.sgItems1.BackColor = lf_bk;
                    //s.Refresh();
                    //tab
                   // s.sgTabPageControl1.SGCS_BorderColor = s.sgTabPageControl4.SGCS_BorderColor = s.sgTabPageControl5.SGCS_BorderColor = s.sgTabPageControl6.SGCS_BorderColor = s.sgTabPageControl7.SGCS_BorderColor = s.sgTabPageControl8.SGCS_BorderColor = sgtab_bd;
                    //s.sgTabPageControl1.SGCS_SelectTitleBackColor = s.sgTabPageControl4.SGCS_SelectTitleBackColor = s.sgTabPageControl5.SGCS_SelectTitleBackColor = s.sgTabPageControl6.SGCS_SelectTitleBackColor = s.sgTabPageControl7.SGCS_SelectTitleBackColor = s.sgTabPageControl8.SGCS_SelectTitleBackColor = sgtab_sbak;
                    //s.sgTabPageControl1.SGCS_SelectTitleTextColor = s.sgTabPageControl4.SGCS_SelectTitleTextColor = s.sgTabPageControl5.SGCS_SelectTitleTextColor = s.sgTabPageControl6.SGCS_SelectTitleTextColor = s.sgTabPageControl7.SGCS_SelectTitleTextColor = s.sgTabPageControl8.SGCS_SelectTitleTextColor =sgtab_sfr;
                    //s.sgTabPageControl1.SGCS_TitleBackColor = s.sgTabPageControl4.SGCS_TitleBackColor = s.sgTabPageControl5.SGCS_TitleBackColor = s.sgTabPageControl7.SGCS_TitleBackColor = s.sgTabPageControl8.SGCS_TitleBackColor = sgtab_bak;
                    //s.sgTabPageControl1.SGCS_TitleTextColor = s.sgTabPageControl4.SGCS_TitleTextColor = s.sgTabPageControl5.SGCS_TitleTextColor = s.sgTabPageControl6.SGCS_TitleTextColor = s.sgTabPageControl7.SGCS_TitleTextColor = s.sgTabPageControl8.SGCS_TitleTextColor = sgtab_fr;
                    //zhe
                    s.panel_zhe1.BackColor = s.panel_zhe2.BackColor = s.panel_zhe3.BackColor = s.panel_zhe4.BackColor = s.panel_zhe5.BackColor = s.panel_zhe6.BackColor = dialog_mian_back;
                    //TAB CONTROL
                    //foreach (TabPage t in s.sgTabPageControl1.TabPages) { t.BackColor = sgtab_panelc; }
                    //foreach (TabPage t in s.sgTabPageControl4.TabPages) { t.BackColor = sgtab_panelc; }
                    //foreach (TabPage t in s.sgTabPageControl5.TabPages) { t.BackColor = sgtab_panelc; }
                    //foreach (TabPage t in s.sgTabPageControl6.TabPages) { t.BackColor = sgtab_panelc; }
                    //foreach (TabPage t in s.sgTabPageControl7.TabPages) { t.BackColor = sgtab_panelc; }
                    //foreach (TabPage t in s.sgTabPageControl8.TabPages) { t.BackColor = sgtab_panelc; }
                    //foreach (TabPage t in s.sgTabPageControl_main.TabPages) { t.BackColor = dialog_back; }
                    #region 绘制二级的SGTAB
                    foreach (TabPage tp1 in s.sgTabPageControl_main.TabPages) { tp1.BackColor = dialog_mian_back; }
                    SGFunction.Skins.DrawAllControlInTabControl(s.sgTabPageControl1);
                    SGFunction.Skins.DrawAllControlInTabControl(s.sgTabPageControl4);
                    SGFunction.Skins.DrawAllControlInTabControl(s.sgTabPageControl5);
                    SGFunction.Skins.DrawAllControlInTabControl(s.sgTabPageControl6);
                    SGFunction.Skins.DrawAllControlInTabControl(s.sgTabPageControl7);
                    SGFunction.Skins.DrawAllControlInTabControl(s.sgTabPageControl8);
                    //left
                   
                    #endregion
                    //pictures
                    s.panel_top.BackgroundImage = p_top;
                    s.panel_topleft.BackgroundImage = p_top_left;
                    s.panel_zhe1.BackgroundImage = s.panel_zhe2.BackgroundImage =s.panel_zhe6.BackgroundImage =p_zhe5;
                    s.panel_zhe4.BackgroundImage = p_zhe4;
                    s.panel_zhe3.BackgroundImage =s.panel_zhe5.BackgroundImage = p_zhe3;
                    s.panel_zhe7.BackgroundImage = p_zhe1;
                    //绘制BOOTMGR的SGTAB
                    SGFunction.Skins.DrawAllControlInTabControl(s.sgTabPageControl_third_bootmgr);
                    SGFunction.Skins.DrawAllControlInTabControl(s.sgTabPageControl_browsermgr );
                }
                catch { }
            }
        }
        #region 这是API函数 不要删
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
        public class IconAndLinkMgr
        {
            public class CLSIDIcon
            {
                public static void LoadCLSIDConfig(int selectndex,SGForm_Function_SystemStyle s)
                {
                    if(selectndex >=0)
                    {
                        try
                        {
                            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\CLSIDIcons\\CLSIDIcon_public.sgcf";
                            string folder = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\CLSIDIcons";
                            SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(folder);
                            //载入最后选择的CFG 目前不需要用到 因为只有一个配置文件
                            switch(selectndex)
                            {
                                case 0:
                                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == false) { SGFunction.DataOperate.SaveStringToTextFile(cfg, Properties.Resources.CLSIDIcon_public); }
                                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == false) { return; }
                                    string parg=@"/s /hybrid /t 0 /f";
                                    if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.1") { parg = @"/s /t 0 /f"; }
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("17", "arg", parg, "CLSIDIcon_V1", false, cfg);
                                    LoadCLSIDIcon(s, cfg);
                                    break;
                            }
                            s.sgCombobox3.Tag = cfg;
                        }
                        catch { }
                    }
                }
                public static void LoadCLSIDIcon(SGForm_Function_SystemStyle s,string cfg)
                {
                    try
                    {
                        //谈价TAG STRING[]
                        // MAIN,NAME,ICO
                        // REGNAME,REGNAME,NAME,ICO,CMD,ARG,RUNAS
                        s.sgTreeView_clsidicon.Nodes.Clear();
                        s.imageList_clsidicon.Images.Clear();
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == false) { return; }
                        int count=0;
                        string rc = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "COUNT", "0", cfg, false);
                        string mainname = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "name", "", cfg, false);
                        string mainicon = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "icon", "", cfg, false);
                        s.imageList_clsidicon.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(mainicon)); s.sgTreeView_clsidicon.Nodes.Add(mainname); s.sgTreeView_clsidicon.Nodes[0].SelectedImageIndex = 0; s.sgTreeView_clsidicon.Nodes[0].ImageIndex = 0; s.sgTreeView_clsidicon.Nodes[0].Tag = new string[] { "MAIN",mainname,mainicon};
                        int.TryParse(rc, out count);
                        for(int u=1;u<=count;u++)
                        {
                            string name = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(u.ToString(), "name", "", cfg, true);
                            string icon = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(u.ToString(), "icon", "", cfg, true);
                            string regname = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(u.ToString(), "regname", "", cfg, true);
                            string cmd = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(u.ToString(), "command", "", cfg, true);
                            string arg = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(u.ToString(), "arg", "", cfg, true);
                            string runas = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(u.ToString(), "runasadmin", "", cfg, true);
                            s.sgTreeView_clsidicon.Nodes[0].Nodes.Add(name);
                            s.imageList_clsidicon.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(icon));
                            int jindex=s.sgTreeView_clsidicon.Nodes[0].Nodes.Count - 1;
                            s.sgTreeView_clsidicon.Nodes[0].Nodes[jindex].ImageIndex =s.sgTreeView_clsidicon.Nodes[0].Nodes[jindex].SelectedImageIndex= s.imageList_clsidicon.Images.Count - 1;
                            s.sgTreeView_clsidicon.Nodes[0].Nodes[jindex].Tag = new string[] {(u).ToString(),regname,name,icon,cmd,arg,runas };
                        }
                        s.sgTreeView_clsidicon.ExpandAll();
                    }
                    catch { }
                }
                public static bool DeleteCLSIDMenu(SGForm_Function_SystemStyle f,string cfg,int index)
                {
                    try
                    {
                        string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要删除这个菜单?", "删除这个菜单会使您的部分设置丢失。", "确定", "取消", "b2", "ques");
                        if (res == "b1")
                        {
                            try
                            {
                                string count = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "count", "0", cfg, false);
                                int SaveCommandItems;
                                int.TryParse(count, out SaveCommandItems);
                                SaveCommandItems = SaveCommandItems - 1;
                                string[] SaveCommand_Name = new string[SaveCommandItems];
                                string[] SaveCommand_Icon = new string[SaveCommandItems];
                                string[] SaveCommand_Command = new string[SaveCommandItems];
                                string[] SaveCommand_RegName = new string[SaveCommandItems];
                                string[] SaveCommand_RunAsAdmin = new string[SaveCommandItems];
                                string[] SaveCommand_ARG = new string[SaveCommandItems];
                                int deleteindex = index;
                                int c = 1;
                                for (int y = 1; y <= SaveCommandItems + 1; y = y + 1)
                                {
                                    if (y != deleteindex)
                                    {
                                        SaveCommand_RegName[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(y.ToString(), "regname", "", cfg, false);
                                        SaveCommand_Name[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(y.ToString(), "name", "", cfg, false);
                                        SaveCommand_Icon[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(y.ToString(), "icon", "", cfg, false);
                                        SaveCommand_Command[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(y.ToString(), "command", "", cfg, false);
                                        SaveCommand_RunAsAdmin[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(y.ToString(), "runasadmin", "", cfg, false);
                                        SaveCommand_ARG[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(y.ToString(), "ARG", "", cfg, false);
                                    }
                                    else
                                    {
                                        c = c + 1;
                                    }
                                }
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "Count", SaveCommandItems.ToString(), "CLSIDIcon_V1", false, cfg);
                                for (int g = 1; g <= SaveCommand_Name.Length; g = g + 1)
                                {
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(g.ToString(), "RegName", SaveCommand_RegName[g - 1].ToString(), "CLSIDIcon_V1", false, cfg);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(g.ToString(), "Name", SaveCommand_Name[g - 1].ToString(), "CLSIDIcon_V1", false, cfg);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(g.ToString(), "Icon", SaveCommand_Icon[g - 1].ToString(), "CLSIDIcon_V1", false, cfg);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(g.ToString(), "Command", SaveCommand_Command[g - 1].ToString(), "CLSIDIcon_V1", false, cfg);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(g.ToString(), "RunAsAdmin", SaveCommand_RunAsAdmin[g - 1].ToString(), "CLSIDIcon_V1", false, cfg);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(g.ToString(), "arg", SaveCommand_ARG[g - 1].ToString(), "CLSIDIcon_V1", false, cfg);
                                }
                                SGSystemStyle.IconAndLinkMgr.CLSIDIcon.LoadCLSIDIcon(f, cfg);
                                return true;
                            }
                            catch { return false; }
                        }
                        else { return false; }
                    }
                    catch { return false; }
                }
                public static void LoadDefaultCLSIDConfig(SGForm_Function_SystemStyle f, int selectindex)
                {
                    try
                    {
                        string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要还原这个CLSID图标配置文件?", "还原这个CLSID图标会使您的部分设置丢失。", "确定", "取消", "b2", "ques");
                        if (res != "b1") { return; }
                        string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\CLSIDIcons\\CLSIDIcon_public.sgcf";
                        string folder = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\CLSIDIcons";
                        SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(folder);
                        //载入最后选择的CFG 目前不需要用到 因为只有一个配置文件
                        switch (selectindex)
                        {
                            case 0:
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(cfg);
                                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == false) { SGFunction.DataOperate.SaveStringToTextFile(cfg, Properties.Resources.CLSIDIcon_public); }
                                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == false) { return; }
                                string parg = @"/s /hybrid /t 0 /f";
                                if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.1") { parg = @"/s /t 0 /f"; }
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("17", "arg", parg, "CLSIDIcon_V1", false, cfg);
                                LoadCLSIDIcon(f, cfg);
                                break;
                        }
                        f.sgCombobox3.Tag = cfg;
                    }
                    catch { }
                }
                public static bool CreateCLSIDIconInSystem(string cfg)
                {
                    bool res = false;
                    try
                    {
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == false) { return false; }
                        int count = SGFunction.DataOperate.StringsToInt(SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "count", "0", cfg, false), 0);
                        string mainname = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "", cfg, true);
                        string clsid = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "clsid", "", cfg, true);
                        string mainicon = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", "", cfg, true);
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"CLSID", clsid);
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"CLSID\"+clsid, "shell");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"CLSID\" + clsid, "DefaultIcon");
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, "CLSID\\" + clsid, "", mainname);
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, "CLSID\\" + clsid+"\\DefaultIcon", "",mainicon);
                        SGFunction.ScriptOperate.CreateRunAsAdminVBS();
                        for(int j=1;j<=count;j++)
                        {
                            if(Registry.ClassesRoot.OpenSubKey("CLSID\\"+clsid+"\\shell") !=null)
                            {
                                string regname = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(j.ToString(), "regname", "", cfg, true);
                                string name = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(j.ToString(), "name", "", cfg, true);
                                string cmd = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(j.ToString(), "command", "", cfg, true);
                                string arg = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(j.ToString(), "arg", "", cfg, true);
                                string ico = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(j.ToString(), "icon", "", cfg, true);
                                string r = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(j.ToString(), "runasadmin", "", cfg, true);
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, "CLSID\\" + clsid + "\\shell", regname);
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, "CLSID\\" + clsid + "\\shell\\"+regname, "command");
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, "clsid\\" + clsid + "\\shell\\" + regname, "", name);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, "clsid\\" + clsid + "\\shell\\" + regname, "icon", ico);
                                if (r.ToUpper() == "T")
                                {
                                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, "clsid\\" + clsid + "\\shell\\" + regname + "\\command", "", Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe """ + SGFunction.Resources.GetResourcePath("runasadminvbs") + @""" " + cmd + " " + arg);
                                }
                                else { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, "clsid\\" + clsid + "\\shell\\" + regname + "\\command", "", cmd + " " + arg); }
                            }
                        }
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace", clsid);
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.LocalMachine,@"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\"+clsid,"",mainname);
                        res = true;
                        return res;
                    }
                    catch { return res; }
                }
                public static bool DeleteCLSIDIconInSystem( string cfg)
                {
                    bool res = false;
                    try
                    {
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == false) { return false; }
                        string clsid = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "clsid", "", cfg, true);
                        SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, "clsid", clsid);
                        SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, @"software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace", clsid);
                        res = true;
                        return res;
                    }
                    catch { return res; }
                }
            }
            public class DesktopIconsMgr
            {
                public static void LoadDesktopIconToImage(SGForm_Function_SystemStyle f)
                {
                    Icon mc = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", "#109", 32);
                    Icon nk = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", "#25", 32);
                    Icon cp = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", "#27", 32);
                    Icon uf = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", "#123", 32);
                    Icon rb = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", "#55", 32);
                    Icon ie = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\ieframe.dll", "#190", 32);
                    f.pictureBox2.Image = uf.ToBitmap();
                    f.pictureBox3.Image = mc.ToBitmap();
                    f.pictureBox4.Image = rb.ToBitmap();
                    f.pictureBox5.Image = nk.ToBitmap();
                    f.pictureBox6.Image = cp.ToBitmap();
                    f.pictureBox7.Image = ie.ToBitmap();
                    if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.1")
                    {
                        f.sgCheckBox2.Enabled = f.sgCheckBox2.Checked =false;
                    }
                    else
                    {
                        f.sgCheckBox2.Enabled = f.sgCheckBox2.Checked = true;
                    }
                    //
                    f.label5.Text = SGFunction.ProgramInfo.GetMyComputerName();
                }
                public static void GetDesktopIconShowType(SGForm_Function_SystemStyle f)
                {
                    try
                    {
                        string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
                        string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
                        string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
                        string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                        string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
                        string IEGUID = "{BDA87F4F-C3AF-4E08-8167-1B10FC09B081}";
                        string SubKeys = @"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel";
                        string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "001");
                        //获取UF
                        if (SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, SubKeys, UFGUID,"1") == "0")
                        {
                            f.sgChooseBox1.MyChooseChooseChecked = 2;
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "UF","SHOW", "config", false, cfg);
                        }
                        else
                        {
                            f.sgChooseBox1.MyChooseChooseChecked = 1;
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "UF", "HIDE", "config", false, cfg);
                        }
                        //获取MC
                        if (SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, SubKeys, MCGUID,"1") == "0")
                        {
                            f.sgChooseBox2.MyChooseChooseChecked = 2;
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "MC", "SHOW", "config", false, cfg);
                        }
                        else
                        {
                            f.sgChooseBox2.MyChooseChooseChecked = 1;
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "MC", "HIDE", "config", false, cfg);
                        }
                        //获取NK
                        if (SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, SubKeys, NKGUID,"1") == "0")
                        {
                            f.sgChooseBox4.MyChooseChooseChecked = 2;
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "NK", "SHOW", "config", false, cfg);
                        }
                        else
                        {
                            f.sgChooseBox4.MyChooseChooseChecked = 1;
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "NK", "HIDE", "config", false, cfg);
                        }
                        //获取CP
                        if (SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, SubKeys, CPGUID,"1") == "0")
                        {
                            f.sgChooseBox5.MyChooseChooseChecked = 2;
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "CP", "SHOW", "config", false, cfg);
                        }
                        else
                        {
                            f.sgChooseBox5.MyChooseChooseChecked = 1;
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "CP", "HIDE", "config", false, cfg);
                        }
                        //获取rb
                        string d = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, SubKeys, RBGUID, "0").ToString(); //如果键下不存在RBGUID 就表示RB图标显示了
                        if (d== "0")
                        {
                            f.sgChooseBox3.MyChooseChooseChecked = 2;
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "RB", "SHOW", "config", false, cfg);
                        }
                        else
                        {
                            if(d=="1")
                            {
                                f.sgChooseBox3.MyChooseChooseChecked = 1;
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "RB", "HIDE", "config", false, cfg);
                            }
                            else
                            {
                                f.sgChooseBox3.MyChooseChooseChecked = 2;
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "RB", "SHOW", "config", false, cfg);
                            }
                        }
                        //获取ie
                        if (Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\" + IEGUID) != null || Registry.ClassesRoot.OpenSubKey(@"clsid\\" + IEGUID) != null)
                        {
                            f.sgChooseBox6.MyChooseChooseChecked = 2;
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "IE", "SHOW", "config", false, cfg);
                        }
                        else
                        {
                            f.sgChooseBox6.MyChooseChooseChecked = 1;
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", "IE", "HIDE", "config", false, cfg);
                        }
                    }
                    catch { }
                }
                public static void ChangeDesktopIconShowType(string code,string type)
                {
                    string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
                    string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
                    string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
                    string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
                    string IEGUID = "{BDA87F4F-C3AF-4E08-8167-1B10FC09B081}";
                    string SubKeysIE = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace";
                    string SubKeys = @"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel";
                    string V = "1";
                    string wair = "HIDE";
                    if (type == "SHOW") { V = "0"; wair = "SHOW"; }
                    //获取UF
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "001");
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("desktopicon", code, wair, "config", false, cfg);
                    switch (code)
                    {
                        case "UF":
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, SubKeys, UFGUID, V, RegistryValueKind.DWord);
                            
                            break;
                        case "RB":
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, SubKeys, RBGUID, V, RegistryValueKind.DWord);
                            break;
                        case "MC":
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, SubKeys, MCGUID, V, RegistryValueKind.DWord);
                            break;
                        case "CP":
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, SubKeys, CPGUID, V, RegistryValueKind.DWord);
                            break;
                        case "NK":
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, SubKeys, NKGUID, V, RegistryValueKind.DWord);
                            break;
                        case "IE":
                            if (V == "0")
                            {
                                RegistryKey RootKey = Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID);
                                if (null == RootKey)
                                {
                                    Registry.ClassesRoot.OpenSubKey("CLSID", true).CreateSubKey(IEGUID).SetValue("", "Internet Explorer", RegistryValueKind.String);
                                    Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID, true).CreateSubKey("Shell").CreateSubKey("Open").CreateSubKey("Command").SetValue("", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\IEXPLORE.EXE", RegistryValueKind.String);
                                    Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID + @"\Shell", true).CreateSubKey("NoAddNos").CreateSubKey("Command").SetValue("", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\IEXPLORE.EXE -extoff", RegistryValueKind.String);
                                    Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID + @"\Shell", true).CreateSubKey("Set").CreateSubKey("Command").SetValue("", Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\RunDll32.exe " + Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Shell32.dll,Control_RunDLL " + Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\inetcpl.cpl", RegistryValueKind.String);
                                    //
                                    Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID + @"\Shell", true).OpenSubKey("Open", true).SetValue("", "打开主页(&H)", RegistryValueKind.String);
                                    Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID + @"\Shell", true).OpenSubKey("NoAddNos", true).SetValue("", "在没有加载项的情况下启动(&N)", RegistryValueKind.String);
                                    Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID + @"\Shell", true).OpenSubKey("Set", true).SetValue("", "Internet 属性(&R)", RegistryValueKind.String);
                                    //
                                    Registry.ClassesRoot.OpenSubKey(@"CLSID\" + IEGUID, true).CreateSubKey("DefaultIcon").SetValue("", Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Ieframe.dll,18", RegistryValueKind.String);
                                }
                                //URL点击
                                string res;
                                string starturl = SGFunction.CommonDialogs.ShowHomePageURLChoose("选择IE图标启动时打开的网页", out res);
                                if (res == "ok")
                                {
                                    string cmd_ie = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\IEXPLORE.EXE """ + starturl + @"""";
                                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, "CLSID\\" + IEGUID + @"\shell\open\command", "", cmd_ie);
                                }
                                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("该操作已取消",2); }
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, SubKeysIE, IEGUID);
                                Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\" + IEGUID, true).SetValue("", "Internet Explorer", RegistryValueKind.String);
                            }
                            else
                            {
                                SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, SubKeysIE, IEGUID);
                                SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot , "clsid", IEGUID);
                            }
                            break;
                    }
                    SGFunction.SystemFunctionAndInformation.UpdateDesktop();
                }
                public static void GetPowerIconType(SGForm_Function_SystemStyle f)
                {
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\关闭计算机.lnk") == true)
                    {
                        f.sgChooseBox9.MyChooseChooseChecked = 2;
                    }
                    else
                    {
                        f.sgChooseBox9.MyChooseChooseChecked = 1;
                    }
                    if ( SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\重启计算机.lnk") == true)
                    {
                        f.sgChooseBox8.MyChooseChooseChecked = 2;
                    }
                    else
                    {
                        f.sgChooseBox8.MyChooseChooseChecked = 1;
                    }
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\锁定计算机.lnk") == true)
                    {
                        f.sgChooseBox7.MyChooseChooseChecked = 2;
                    }
                    else
                    {
                        f.sgChooseBox7.MyChooseChooseChecked = 1;
                    }
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\注销登录.lnk") == true)
                    {
                        f.sgChooseBox10.MyChooseChooseChecked = 2;
                    }
                    else
                    {
                        f.sgChooseBox10.MyChooseChooseChecked = 1;
                    }
                }
                public static void ChangePowerIcon(string Type, string CreateOrDelete, bool HybridStart, bool CreateStartMenu,bool pintotaskbar)
                {
                    string LINK_NAME = "";
                    string LINK_COMMAND = "";
                    string LINK_ARGS = "";
                    string INFO = "";
                    string icon = "";
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "001");
                    string set = "HIDE";
                    string sta = ",ONLYDESKTOP";
                    if (CreateStartMenu == true) { sta = ",BOTH"; }
                    if (CreateOrDelete.ToUpper() == "CREATE") { set = "SHOW"; }
                    switch (Type.ToUpper())
                    {
                        case "PO":
                            LINK_NAME = "关闭计算机.lnk";
                            if (CreateOrDelete.ToUpper() == "CREATE")
                            {
                                
                                string newcmd = "-s -f -t 0";
                                string newinfo = "结束所有任务并关闭计算机";
                                string writ = "SHOW,NORMAL";
                                if (HybridStart == true)
                                {
                                    newcmd = "-s -hybrid -f -t 0";
                                    newinfo = "结束所有任务并关闭计算机(启用混合启动技术)";
                                    writ = "SHOW,HYBRID";
                                }
                                INFO = newinfo;
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("powericons", "PO", writ+sta, "config", false, cfg);
                                LINK_COMMAND = @"%SystemRoot%\System32\Shutdown.exe";
                                LINK_ARGS = newcmd;
                                icon = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "po");
                            }
                            else
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\关闭计算机.lnk");
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\关闭计算机.lnk");
                                string file = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + LINK_NAME;
                                SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(false, file);
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("powericons", "PO", "HIDE", "config", false, cfg);
                            }
                            break;
                        case "RE":
                            LINK_NAME = "重启计算机.lnk";
                            if (CreateOrDelete.ToUpper() == "CREATE")
                            {
                                
                                string newcmd = "-r -f -t 0";
                                string newinfo = "结束所有任务并重启计算机";
                                LINK_COMMAND = @"%SystemRoot%\System32\Shutdown.exe";
                                LINK_ARGS = newcmd;
                                INFO = newinfo;
                                icon = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "re");
                            }
                            else
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\重启计算机.lnk");
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\重启计算机.lnk");
                                string file = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + LINK_NAME;
                                SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(false, file);
                            }
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("powericons", "RE", set+sta, "config", false, cfg);
                            break;
                        case "LO":
                            LINK_NAME = "注销登录.lnk";
                            if (CreateOrDelete.ToUpper() == "CREATE")
                            {
                                
                                string newcmd = "-l";
                                string newinfo = "注销当前的用户登录";
                                LINK_COMMAND = @"%SystemRoot%\System32\Shutdown.exe";
                                LINK_ARGS = newcmd;
                                INFO = newinfo;
                                icon = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "lo");
                            }
                            else
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\注销登录.lnk");
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\注销登录.lnk");
                                string file = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + LINK_NAME;
                                SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(false, file);
                            }
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("powericons", "LO", set+sta, "config", false, cfg);
                            break;
                        case "LC":
                            LINK_NAME = "锁定计算机.lnk";
                            if (CreateOrDelete.ToUpper() == "CREATE")
                            {
                                
                                string newcmd = "user32.dll,LockWorkStation";
                                string newinfo = "锁定计算机(不会丢失数据)";
                                LINK_COMMAND = @"%SystemRoot%\System32\rundll32.exe";
                                LINK_ARGS = newcmd;
                                INFO = newinfo;
                                icon = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "lc");
                            }
                            else
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(@"%appdata%\\Microsoft\Windows\Start Menu\Programs\锁定计算机.lnk");
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\锁定计算机.lnk");
                                string file = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + LINK_NAME;
                                SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(false, file);
                            }
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("powericons", "LC", set+sta, "config", false, cfg);
                            break;
                    }
                    if (CreateOrDelete.ToUpper() == "CREATE")
                    {
                        SGFunction.SystemFunctionAndInformation.CreateLink(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + LINK_NAME, LINK_COMMAND, LINK_ARGS, INFO, icon);
                        if (CreateStartMenu == true)
                        {
                            SGFunction.SystemFunctionAndInformation.CreateLink(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ @"\Microsoft\Windows\Start Menu\Programs" + @"\" + LINK_NAME, LINK_COMMAND, LINK_ARGS, INFO, icon);
                        }
                        if (pintotaskbar == true) { SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + LINK_NAME); }
                    }
                }
            }
            public class SystemIconsMgr
            {
                public  static void LoadSystemIcon_Basic(ListView user,ImageList im)
                {
                    string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
                    string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
                    string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
                    string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
                    string IEGUID = "{BDA87F4F-C3AF-4E08-8167-1B10FC09B081}";
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + @"\SystemIcons.sgcf";
                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(cfg);

                    string RBICON_NORMAL = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "");
                    string RBICON_FULL = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "full");
                    string RBICON_NAME = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID,"","回收站",RegistryValueKind.String);
                    if (RBICON_NAME == "") { RBICON_NAME = "回收站"; }
                    if (RBICON_NORMAL == "") { RBICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,50"; }
                    if (RBICON_FULL == "") { RBICON_FULL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,49"; }
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_RB_D", "Org_Name", "回收站", "Config", false, cfg);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_RB_F", "Org_Name", "回收站", "Config", false, cfg);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_RB_D", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,50", "Config", false, cfg);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_RB_F", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,49", "Config", false, cfg);
                    ///////////////////////////////////////////////////UF//////////////////////////////////////////////
                    string UFICON_NORMAL = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + UFGUID + @"\DefaultIcon", "");
                    string UFICON_NAME = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + UFGUID, "", "用户的文件",RegistryValueKind.String);
                    if (UFICON_NAME == "") { UFICON_NAME = "用户的文件"; }
                    if (UFICON_NORMAL == "") { UFICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,117"; }
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_UF", "Org_Name", "UsersFiles", "Config", false, cfg);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_UF", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,117", "Config", false, cfg);
                    ///////////////////////////////////////////////////NK//////////////////////////////////////////////
                    string NKICON_NORMAL = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + NKGUID + @"\DefaultIcon", "");
                    string NKICON_NAME = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + NKGUID, "","网络", RegistryValueKind.String);
                    if (NKICON_NAME == "") { NKICON_NAME = "网络"; }
                    if (NKICON_NORMAL == "") { NKICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,20"; }
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_NK", "Org_Name", "网络", "Config", false, cfg);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_NK", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,20", "Config", false, cfg);
                    ///////////////////////////////////////////////////MC//////////////////////////////////////////////
                    string MCICON_NORMAL = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + MCGUID + @"\DefaultIcon", "");
                    string MCICON_NAME = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + MCGUID, "",SGFunction.ProgramInfo.GetMyComputerName(), RegistryValueKind.String);
                    if (MCICON_NAME == "") { MCICON_NAME = SGFunction.ProgramInfo.GetMyComputerName(); }
                    if (MCICON_NORMAL == "") { MCICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,104"; }
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_MC", "Org_Name", SGFunction.ProgramInfo.GetMyComputerName(), "Config", false, cfg);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_MC", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,104", "Config", false, cfg);
                    ///////////////////////////////////////////////////CP//////////////////////////////////////////////
                    string CPICON_NORMAL = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + CPGUID + @"\DefaultIcon", "");
                    string CPICON_NAME = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + CPGUID, "","控制面板", RegistryValueKind.String);
                    if (CPICON_NAME == "") { CPICON_NAME = "控制面板"; }
                    if (CPICON_NORMAL == "") { CPICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,22"; }
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_CP", "Org_Name", "控制面板", "Config", false, cfg);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_CP", "Org_Icon_Default", "%SystemRoot%\\System32\\Imageres.dll,22", "Config", false, cfg);
                    ///////////////////////////////////////////////////IE//////////////////////////////////////////////
                    string IEICON_NORMAL = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + IEGUID + @"\DefaultIcon", "");
                    string IEICON_NAME = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + IEGUID, "","Internet Explorer", RegistryValueKind.String);
                    if (IEICON_NAME == "") { IEICON_NAME = "Internet Explorer"; }
                    if (IEICON_NORMAL == "") { IEICON_NORMAL = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Ieframe.dll,18"; }
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_IE", "Org_Name", "Internet Explorer", "Config", false, cfg);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("DESK_IE", "Org_Icon_Default", "%SystemRoot%\\System32\\Ieframe.dll,18", "Config", false, cfg);
                    ////////////////////////////////////////////////START////////////////////////////////////////////
                    user.Items.Clear();
                    im.Images.Clear();
                    //UF
                    user.Items.Add(UFICON_NAME);
                    Bitmap  bmp = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(UFICON_NORMAL);
                    //im.Images.Add(MyFunctions.MediaOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(UFICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,117"));
                    im.Images.Add(bmp);
                    user.Items[0].ImageIndex = 0;
                    user.Items[0].Group = user.Groups[0];
                    user.Items[0].Tag = "UF";
                    //MC
                    user.Items.Add(MCICON_NAME);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(MCICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,104"));
                    user.Items[1].ImageIndex = 1;
                    user.Items[1].Group = user.Groups[0];
                    user.Items[1].Tag = "MC";
                    //NK
                    user.Items.Add(NKICON_NAME);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(NKICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,20"));
                    user.Items[2].ImageIndex = 2;
                    user.Items[2].Group = user.Groups[0];
                    user.Items[2].Tag = "NK";
                    //CP
                    user.Items.Add(CPICON_NAME);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(CPICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,22"));
                    user.Items[3].ImageIndex = 3;
                    user.Items[3].Group = user.Groups[0];
                    user.Items[3].Tag = "CP";
                    //RB_NORMAL
                    user.Items.Add(RBICON_NAME + "(空)");
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(RBICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,50"));
                    user.Items[4].ImageIndex = 4;
                    user.Items[4].Group = user.Groups[0];
                    user.Items[4].Tag = "RB_D";
                    //RB_FULL
                    user.Items.Add(RBICON_NAME + "(满)");
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(RBICON_FULL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,49"));
                    user.Items[5].ImageIndex = 5;
                    user.Items[5].Group = user.Groups[0];
                    user.Items[5].Tag = "RB_F";
                    //IE
                    user.Items.Add(IEICON_NAME);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(IEICON_NORMAL, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Ieframe.dll,18"));
                    user.Items[6].ImageIndex = 6;
                    user.Items[6].Group = user.Groups[0];
                    user.Items[6].Tag = "IE";
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////开始加载驱动器图标/////////////////////////////////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //HDD INDEX 6
                    string ICONINDEX_6 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "6");
                    string ICONNAME_6 = @"3.5""寸软盘";
                    if (ICONINDEX_6 == "") { ICONINDEX_6 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,24"; }
                    user.Items.Add(ICONNAME_6);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_6, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,24"));
                    user.Items[7].ImageIndex = 7;
                    user.Items[7].Group = user.Groups[1];
                    user.Items[7].Tag = "6";
                    //HDD INDEX 8
                    string ICONINDEX_8 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "8");
                    string ICONNAME_8 = @"硬盘";
                    if (ICONINDEX_8 == "") { ICONINDEX_8 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,27"; }
                    user.Items.Add(ICONNAME_8);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_8, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,27"));
                    user.Items[8].ImageIndex = 8;
                    user.Items[8].Group = user.Groups[1];
                    user.Items[8].Tag = "8";
                    //HDD INDEX 11
                    string ICONINDEX_11 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "11");
                    string ICONNAME_11 = @"CD光驱";
                    if (ICONINDEX_11 == "") { ICONINDEX_11 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,25"; }
                    user.Items.Add(ICONNAME_11);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_11, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,25"));
                    user.Items[9].ImageIndex = 9;
                    user.Items[9].Group = user.Groups[1];
                    user.Items[9].Tag = "11";
                    //HDD INDEX 59
                    string ICONINDEX_59 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "59");
                    string ICONNAME_59 = @"DVD光驱";
                    if (ICONINDEX_59 == "") { ICONINDEX_59 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,32"; }
                    user.Items.Add(ICONNAME_59);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_59, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,32"));
                    user.Items[10].ImageIndex = 10;
                    user.Items[10].Group = user.Groups[1];
                    user.Items[10].Tag = "59";
                    //HDD INDEX 40
                    string ICONINDEX_41 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "41");
                    string ICONNAME_41 = @"音频CD";
                    if (ICONINDEX_41 == "") { ICONINDEX_41 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Shell32.dll,40"; }
                    user.Items.Add(ICONNAME_41);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_41, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Shell32.dll,40"));
                    user.Items[11].ImageIndex = 11;
                    user.Items[11].Group = user.Groups[1];
                    user.Items[11].Tag = "41";
                    //HDD INDEX 7
                    string ICONINDEX_7 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "7");
                    string ICONNAME_7 = @"可移动驱动器";
                    if (ICONINDEX_7 == "") { ICONINDEX_7 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Shell32.dll,7"; }
                    user.Items.Add(ICONNAME_7);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_7, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Shell32.dll,7"));
                    user.Items[12].ImageIndex = 12;
                    user.Items[12].Group = user.Groups[1];
                    user.Items[12].Tag = "7";
                    //HDD INDEX 9
                    string ICONINDEX_9 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "9");
                    string ICONNAME_9 = @"网路驱动器(已连接)";
                    if (ICONINDEX_9 == "") { ICONINDEX_9 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,28"; }
                    user.Items.Add(ICONNAME_9);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_9, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,28"));
                    user.Items[13].ImageIndex = 13;
                    user.Items[13].Group = user.Groups[1];
                    user.Items[13].Tag = "9";
                    //HDD INDEX 10
                    string ICONINDEX_10 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "10");
                    string ICONNAME_10 = @"网路驱动器(已断开)";
                    if (ICONINDEX_10 == "") { ICONINDEX_10 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,26"; }
                    user.Items.Add(ICONNAME_10);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_10, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,26"));
                    user.Items[14].ImageIndex = 14;
                    user.Items[14].Group = user.Groups[1];
                    user.Items[14].Tag = "10";
                    //HDD INDEX 10
                    string ICONINDEX_12 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "12");
                    string ICONNAME_12 = @"RAM 驱动器";
                    if (ICONINDEX_12 == "") { ICONINDEX_12 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,29"; }
                    user.Items.Add(ICONNAME_12);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_12, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\Imageres.dll,29"));
                    user.Items[15].ImageIndex = 15;
                    user.Items[15].Group = user.Groups[1];
                    user.Items[15].Tag = "12";
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////开始加载文件夹图标/////////////////////////////////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //FLD INDEX 3
                    string ICONINDEX_3 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "3");
                    string ICONNAME_3 = @"文件夹(闭合)";
                    if (ICONINDEX_3 == "") { ICONINDEX_3 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,3"; }
                    user.Items.Add(ICONNAME_3);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_3, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,3"));
                    user.Items[16].ImageIndex = 16;
                    user.Items[16].Group = user.Groups[2];
                    user.Items[16].Tag = "S03";
                    //FLD INDEX 4
                    string ICONINDEX_4 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "4");
                    string ICONNAME_4 = @"文件夹(打开)";
                    if (ICONINDEX_4 == "") { ICONINDEX_4 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,4"; }
                    user.Items.Add(ICONNAME_4);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_4, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\imageres.dll,4"));
                    user.Items[17].ImageIndex = 17;
                    user.Items[17].Group = user.Groups[2];
                    user.Items[17].Tag = "S04";
                    //FLD INDEX 36
                    string ICONINDEX_36 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "36");
                    string ICONNAME_36 = @"程序组";
                    if (ICONINDEX_36 == "") { ICONINDEX_36 = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\shell32.dll,36"; }
                    user.Items.Add(ICONNAME_36);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_36, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\shell32.dll,36"));
                    user.Items[18].ImageIndex = 18;
                    user.Items[18].Group = user.Groups[2];
                    user.Items[18].Tag = "S36";
                    //FLD INDEX MGRTOOLS
                    string ICONINDEX_MGRTOOLS = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{D20EA4E1-3957-11d2-A40B-0C5020524153}\defaulticon", "");
                    string ICONNAME_MGRTOOLS = @"管理工具";
                    if (ICONINDEX_MGRTOOLS == "") { ICONINDEX_MGRTOOLS = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\IMAGERES.DLL,109"; }
                    user.Items.Add(ICONNAME_MGRTOOLS);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_MGRTOOLS, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\IMAGERES.DLL,109"));
                    user.Items[19].ImageIndex = 19;
                    user.Items[19].Group = user.Groups[2];
                    user.Items[19].Tag = "G{D20EA4E1-3957-11d2-A40B-0C5020524153}";
                    //FLD INDEX NETGET
                    string ICONINDEX_NETGET = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{7007ACC7-3202-11D1-AAD2-00805FC1270E}\defaulticon", "");
                    string ICONNAME_NETGET = @"网络连接";
                    if (ICONINDEX_NETGET == "") { ICONINDEX_NETGET = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\netshell.dll,0"; }
                    user.Items.Add(ICONNAME_NETGET);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_NETGET, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\netshell.dll,0"));
                    user.Items[20].ImageIndex = 20;
                    user.Items[20].Group = user.Groups[2];
                    user.Items[20].Tag = "G{7007ACC7-3202-11D1-AAD2-00805FC1270E}";
                    //FLD INDEX FONTS
                    string ICONINDEX_FONTS = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{D20EA4E1-3957-11d2-A40B-0C5020524152}\defaulticon", "");
                    string ICONNAME_FONTS = @"字体";
                    if (ICONINDEX_FONTS == "") { ICONINDEX_FONTS = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\main.cpl,6"; }
                    user.Items.Add(ICONNAME_FONTS);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_FONTS, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\main.cpl,6"));
                    user.Items[21].ImageIndex = 21;
                    user.Items[21].Group = user.Groups[2];
                    user.Items[21].Tag = "G{D20EA4E1-3957-11d2-A40B-0C5020524152}";
                    //FLD INDEX XAOMIAO
                    string ICONINDEX_XAOMIAO = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{E211B736-43FD-11D1-9EFB-0000F8757FCD}\defaulticon", "");
                    string ICONNAME_XAOMIAO = @"扫描仪和照相机";
                    if (ICONINDEX_XAOMIAO == "") { ICONINDEX_XAOMIAO = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wiashext.dll,0"; }
                    user.Items.Add(ICONNAME_XAOMIAO);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_XAOMIAO, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\wiashext.dll,0"));
                    user.Items[22].ImageIndex = 22;
                    user.Items[22].Group = user.Groups[2];
                    user.Items[22].Tag = "G{E211B736-43FD-11D1-9EFB-0000F8757FCD}";
                    //FLD INDEX ONLYSAOMIAO
                    string ICONINDEX_ONLYSAOMIAO = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{2227A280-3AEA-1069-A2DE-08002B30309D}\defaulticon", "");
                    string ICONNAME_ONLYSAOMIAO = @"扫描仪";
                    if (ICONINDEX_ONLYSAOMIAO == "") { ICONINDEX_ONLYSAOMIAO = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\IMAGERES.DLL,21"; }
                    user.Items.Add(ICONNAME_ONLYSAOMIAO);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_ONLYSAOMIAO, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\IMAGERES.DLL,21"));
                    user.Items[23].ImageIndex = 23;
                    user.Items[23].Group = user.Groups[2];
                    user.Items[23].Tag = "G{2227A280-3AEA-1069-A2DE-08002B30309D}";
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////开始加载其他图标/////////////////////////////////////////////////////////////////////////////////////////
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //OTHER INDEX LINKICO
                    string ICONINDEX_LINKICO = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "29");
                    string ICONNAME_LINKICO = @"快捷方式箭头";
                    if (ICONINDEX_LINKICO == "") { ICONINDEX_LINKICO = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\IMAGERES.DLL,154"; }
                    user.Items.Add(ICONNAME_LINKICO);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_LINKICO, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\IMAGERES.DLL,154"));
                    user.Items[24].ImageIndex = 24;
                    user.Items[24].Group = user.Groups[3];
                    user.Items[24].Tag = "29";
                    //OTHER INDEX DEFFILE
                    string ICONINDEX_DEFFILE = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "0");
                    string ICONNAME_DEFFILE = @"默认的文件";
                    if (ICONINDEX_DEFFILE == "") { ICONINDEX_DEFFILE = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\IMAGERES.DLL,2"; }
                    user.Items.Add(ICONNAME_DEFFILE);
                    im.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ICONINDEX_DEFFILE, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\\IMAGERES.DLL,2"));
                    user.Items[25].ImageIndex = 25;
                    user.Items[25].Group = user.Groups[3];
                    user.Items[25].Tag = "0";
                    user.Items[0].Focused = true;
                }
                
            }
            public class FileTypeMgr
            {
                private  static Icon GetIconForFileExtensionFromReg(String ExtraName, Boolean LoadLargeIcon, Boolean AddLinkIcon)
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
                public static void LoadExtsIconAndDescription(SGForm_Function_SystemStyle  user)
                {
                    try
                    {
                        Thread P_thread = new Thread(
                 () => //lambda表达式（参数列表）=>{执行语句}  lambda表达式是比匿名方法更加简洁的一种匿名函数语法
                 {
                     user.Invoke(new MethodInvoker(delegate()
                     {
                         user.listView1.Items.Clear();
                         user.imageList_filetype.Images.Clear();
                         string[] SubKeyInHKCR;
                         SubKeyInHKCR = SGFunction.RegistryOperate.RegistryOperate_GetSubkeys(Registry.ClassesRoot, "");
                         //MessageBox.Show(SubKeyInHKCR.Length.ToString());
                         for (int y = 1; y <= SubKeyInHKCR.Length; y++)
                         {
                             if (SubKeyInHKCR[y - 1].Length > 1)
                             {
                                 if (SubKeyInHKCR[y - 1].Substring(0, 1) == ".")
                                 {
                                     string setfileinfo=SubKeyInHKCR[y - 1].ToString()+"文件";
                                     string biaoshifuname = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, SubKeyInHKCR[y - 1].ToString(), "", "");
                                     if (biaoshifuname != "")
                                     {
                                         string _info = SGFunction.RegistryOperate.RegistryOperate_ValueOperate ("GET",Registry.ClassesRoot, biaoshifuname, "", "");
                                         if (_info != "" && SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.ClassesRoot, biaoshifuname, "FriendlyTypeName", "none") =="none") 
                                         {
                                             setfileinfo = _info;
                                         }
                                         else
                                         {
                                             //如果是NULL
                                             //读取FriendlyTypeName
                                             string loc = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.ClassesRoot, biaoshifuname, "FriendlyTypeName", "");
                                             if (loc != "")
                                             {
                                                 string read = SGFunction.MUIOperate.GetMUIString(loc,"none");
                                                 if (read != "none") { setfileinfo = read; }
                                             }
                                         }
                                         user.imageList_filetype.Images.Add(GetIconForFileExtensionFromReg(SubKeyInHKCR[y - 1].ToString(), true, false));
                                         if (user.imageList_filetype.Images.Count > 0)
                                         {
                                             user.listView1.Items.Add(SubKeyInHKCR[y - 1]).ImageIndex = user.imageList_filetype.Images.Count - 1;
                                             user.listView1.Items[user.imageList_filetype.Images.Count - 1].SubItems.Add(setfileinfo);
                                         }
                                     }
                                 }
                             }
                             Application.DoEvents();
                         }
                     }));
                 });//new thread

                        P_thread.IsBackground = true;
                        P_thread.Start();
                    }
                    catch { }
                }
                public static void FindExtNames(SGForm_Function_SystemStyle user,string findstring)
                {
                    ListView.ListViewItemCollection find;
                    find=user.listView1.Items;
                    user.imageList_findlist.Images.Clear();
                    user.listView_findinoldlist.Items.Clear();
                    for(int p=1;p<=find.Count;p++)
                    {
                        string panduan=find[p-1].Text.ToUpper();
                        bool cha=SGFunction.StringOperate.FindString(panduan,findstring.ToUpper());
                        if (cha ==true)
                        {
                            user.imageList_findlist.Images.Add(find[p - 1].ImageList.Images[find[p - 1].ImageIndex]);
                            user.listView_findinoldlist.Items.Add(find[p - 1].Text).ImageIndex = user.imageList_findlist.Images.Count-1;
                            user.listView_findinoldlist.Items[user.listView_findinoldlist.Items.Count - 1].SubItems.Add(find[p-1].SubItems[1].Text );
                        }
                        Application.DoEvents();
                    }
                }
                public static void ChangeIcon(string icon,string ext,out Image icotolistview)
                {
                    //先备份一次
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup", "003") + "\\" + "ExtensionBackup"+ ".sgcf";
                    string subname=SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, ext,"");
                    string defico = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, subname + "\\defaulticon", "");
                    string orgbak = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(ext, "icon", "", cfg);
                    if (orgbak == "") { SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(ext, "icon", defico, "Config", false, cfg); }
                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, subname + "\\defaulticon","",icon,RegistryValueKind.String);
                    icotolistview = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(icon);
                    SGFunction.SystemFunctionAndInformation.UpdateDesktop();
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功修改了文件图标", 1);
                }
                public static void ChangeInfo(string info,string ext)
                {
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup", "003") + "\\" + "ExtensionBackup" + ".sgcf";
                    string subname = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, ext, "");
                    string defico = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, subname, "");
                    string orgbak = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(ext, "info", "", cfg);
                    if (orgbak == "") { SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(ext, "info", defico, "Config", false, cfg); }
                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, subname, "", info, RegistryValueKind.String);
                    SGFunction.SystemFunctionAndInformation.UpdateDesktop();
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功修改了文件的描述信息", 1);
                }
                public static void SetDefaultIcon(string ext,string defaulticon,out Image im)
                {
                    string subname = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, ext, "");
                    string defico = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.ClassesRoot,subname+"\\defaulticon","",defaulticon,RegistryValueKind.String);
                    im = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(defaulticon);
                }
                public static void SetDefaultInfo(string ext, string defaultinfo)
                {
                    string subname = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, ext, "");
                    string defico = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, subname , "", defaultinfo, RegistryValueKind.String);
                }
            }
            public class TaskBarMgr
            {
                public static void  LoadIcon(SGForm_Function_SystemStyle f)
                {
                    Icon mc = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", "#109", 32);
                    Icon nk = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", "#25", 32);
                    Icon cp = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", "#27", 32);
                    Icon uf = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", "#123", 32);
                    Icon rb = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", "#55", 32);
                    Icon ie = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\ieframe.dll", "#190", 32);
                    Bitmap  ex = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon("%windir%\\explorer.exe,0");
                    Bitmap dk = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(SGFunction.RunCommand.GetSGProgramPath("desktoplabel"));
                    f.pictureBox71.Image = uf.ToBitmap();
                    f.pictureBox70.Image = nk.ToBitmap();
                    f.pictureBox72.Image = mc.ToBitmap();
                    f.pictureBox69.Image = cp.ToBitmap();
                    f.pictureBox74.Image = rb.ToBitmap();
                    f.pictureBox73.Image = ie.ToBitmap();
                    f.pictureBox75.Image = ex;
                    f.pictureBox65.Image = dk;
                    //检测显示
                    if(SGFunction.SystemFunctionAndInformation.GetOSVersion()=="6.1")
                    {
                        f.MyNormalButton15.Visible =false;
                        //f.label30.Text ="计算机";
                        //f.label132.Text = "资源管理器";
                        f.sgCheckBox4.Enabled = false;
                    }
                    else
                    {
                        f.MyNormalButton15.Visible = true;
                        f.sgCheckBox4.Enabled = true;
                    }
                    f.label30.Text = SGFunction.ProgramInfo.GetMyComputerName();
                    f.label132.Text = SGFunction.ProgramInfo.GetExplorerName();
                }
                public static void LoadTaskBarIconsShowType(SGForm_Function_SystemStyle user)
                {
                    try
                    {
                        string taskbar = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar";
                        //SG
                        if (System.IO.File.Exists(taskbar + @"\系统齿轮.lnk") == true)
                        {
                            user.sgChooseBox11.MyChooseChooseChecked = 2;
                        }
                        else
                        {
                            user.sgChooseBox11.MyChooseChooseChecked = 1;
                        }
                        //DL
                        if (System.IO.File.Exists(taskbar + @"\桌面便利贴.lnk") == true)
                        {
                            user.sgChooseBox12.MyChooseChooseChecked = 2;
                        }
                        else
                        {
                            user.sgChooseBox12.MyChooseChooseChecked = 1;
                        }
                        //nk
                        if (System.IO.File.Exists(taskbar + @"\网络.lnk") == true)
                        {
                            user.sgChooseBox14.MyChooseChooseChecked = 2;
                        }
                        else
                        {
                            user.sgChooseBox14.MyChooseChooseChecked = 1;
                        }
                        //UF
                        if (System.IO.File.Exists(taskbar + @"\用户的文件.lnk") == true)
                        {
                            user.sgChooseBox13.MyChooseChooseChecked = 2;
                        }
                        else
                        {
                            user.sgChooseBox13.MyChooseChooseChecked = 1;
                        }
                        //cp
                        if (System.IO.File.Exists(taskbar + @"\控制面板.lnk") == true)
                        {
                            user.sgChooseBox16.MyChooseChooseChecked = 2;
                        }
                        else
                        {
                            user.sgChooseBox16.MyChooseChooseChecked = 1;
                        }
                        //rb
                        if (System.IO.File.Exists(taskbar + @"\回收站.lnk") == true)
                        {
                            user.sgChooseBox17.MyChooseChooseChecked = 2;
                        }
                        else
                        {
                            user.sgChooseBox17.MyChooseChooseChecked = 1;
                        }
                        //ie
                        if (System.IO.File.Exists(taskbar + @"\Internet Explorer.lnk") == true)
                        {
                            user.sgChooseBox18.MyChooseChooseChecked = 2;
                        }
                        else
                        {
                            user.sgChooseBox18.MyChooseChooseChecked = 1;
                        }
                        //po
                        if (System.IO.File.Exists(taskbar + @"\关闭计算机.lnk") == true)
                        {
                            user.sgChooseBox23.MyChooseChooseChecked = 2;
                        }
                        else
                        {
                            user.sgChooseBox23.MyChooseChooseChecked = 1;
                        }
                        //re
                        if (System.IO.File.Exists(taskbar + @"\重启计算机.lnk") == true)
                        {
                            user.sgChooseBox22.MyChooseChooseChecked = 2;
                        }
                        else
                        {
                            user.sgChooseBox22.MyChooseChooseChecked = 1;
                        }
                        //lc
                        if (System.IO.File.Exists(taskbar + @"\锁定计算机.lnk") == true)
                        {
                            user.sgChooseBox21.MyChooseChooseChecked = 2;
                        }
                        else
                        {
                            user.sgChooseBox21.MyChooseChooseChecked = 1;
                        }
                        //lo
                        if (System.IO.File.Exists(taskbar + @"\注销计算机.lnk") == true)
                        {
                            user.sgChooseBox20.MyChooseChooseChecked = 2;
                        }
                        else
                        {
                            user.sgChooseBox20.MyChooseChooseChecked = 1;
                        }
                        //mc
                        switch (SGFunction.SystemFunctionAndInformation.GetOSVersion() )
                        {
                            case "6.3":
                                if (System.IO.File.Exists(taskbar + @"\这台电脑.lnk") == true)
                                {
                                    user.sgChooseBox15.MyChooseChooseChecked = 2;
                                }
                                else
                                {
                                    user.sgChooseBox15.MyChooseChooseChecked = 1;
                                }
                                break;
                            default:
                                if (System.IO.File.Exists(taskbar + @"\计算机.lnk") == true)
                                {
                                    user.sgChooseBox15.MyChooseChooseChecked = 2;
                                }
                                else
                                {
                                    user.sgChooseBox15.MyChooseChooseChecked = 1;
                                }
                                break;
                        }
                        //explorer
                        switch (SGFunction.SystemFunctionAndInformation.GetOSVersion() )
                        {
                            case "6.1":
                                if (System.IO.File.Exists(taskbar + @"\Windows Explorer.lnk") == false)
                                {
                                    if (System.IO.File.Exists(taskbar + @"\Windows 资源管理器.lnk") == true)
                                    {
                                        user.sgChooseBox19.MyChooseChooseChecked = 2;
                                    }
                                    else
                                    {
                                        user.sgChooseBox19.MyChooseChooseChecked = 1;
                                    }
                                }
                                else
                                {
                                    user.sgChooseBox19.MyChooseChooseChecked = 2;
                                }
                                break;
                            default:
                                if (System.IO.File.Exists(taskbar + @"\File Explorer.lnk") == false)
                                {
                                    if (System.IO.File.Exists(taskbar + @"\文件资源管理器.lnk") == true)
                                    {
                                        user.sgChooseBox19.MyChooseChooseChecked = 2;
                                    }
                                    else
                                    {
                                        user.sgChooseBox19.MyChooseChooseChecked = 1;
                                    }
                                }
                                else
                                {
                                    user.sgChooseBox19.MyChooseChooseChecked = 2;
                                }
                                break;
                        }
                    }
                    catch { }
                }
                public static void SetTaskBarIconsShowType( string codename, string type,bool hybridstart=true)
                {
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "004");
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
                                    ico = Application.ExecutablePath + ",0";
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                                case "DL":
                                    string temp_web = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("TEMP") + "\\桌面便利贴.LNK";
                                    string dkexe = SGFunction.RunCommand.GetSGProgramPath("DESKTOPLABEL");
                                    SGFunction.SystemFunctionAndInformation.CreateLink(temp_web, dkexe, "", "启动桌面便利贴个性版", dkexe);
                                    SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, temp_web);
                                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(temp_web);
                                    SGFunction.SystemFunctionAndInformation.UpdateDesktop();
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                                case "UF":
                                    pingname = "用户的文件";
                                    path = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe";
                                    ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,117";
                                    arg = "shell:::" + UFGUID;
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                                case "MC":
                                    if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.3")
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
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                                case "NK":
                                    pingname = "网络";
                                    path = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe";
                                    ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,20";
                                    arg = "shell:::" + NKGUID;
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                                case "CP":
                                    pingname = "控制面板";
                                    path = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe";
                                    ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,22";
                                    arg = "shell:::" + CPGUID;
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                                case "RB":
                                    pingname = "回收站";
                                    path = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe";
                                    ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,50";
                                    arg = "shell:::" + RBGUID;
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                                case "IE":
                                    pingname = "Internet Explorer";
                                    path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\iexplore.exe";
                                    ico = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\iexplore.exe,0";
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                                case "PO":
                                    pingname = "关闭计算机";
                                    path = @"%systemroot%\\system32\\shutdown.exe";
                                    arg = "-s -t 0";
                                    string fu = ",NORMAL";
                                    if (hybridstart == true) { arg = "-s -hybrid -t 0"; fu = ",HYBRID"; }
                                    ico = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "po");
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW"+fu, "config", false, cfg);
                                    break;
                                case "RE":
                                    pingname = "重启计算机";
                                    path = @"%systemroot%\\system32\\shutdown.exe";
                                    arg = "-r -t 0";
                                    ico = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "re");
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                                case "LO":
                                    pingname = "注销登录";
                                    path = @"%systemroot%\\system32\\shutdown.exe";
                                    arg = "-l";
                                    ico = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "lo");
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                                case "LC":
                                    pingname = "锁定计算机";
                                    path = @"%systemroot%\\system32\\rundll32.exe";
                                    arg = "user32.dll,LockWorkStation";
                                    ico = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "lc");
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                                case "EX":
                                    if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.3" || SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.2")
                                    {
                                        pingname = "文件资源管理器";
                                    }
                                    else
                                    {
                                        pingname = "Windows 资源管理器";
                                    }
                                    path = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe";
                                    ico = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe,0";
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "SHOW", "config", false, cfg);
                                    break;
                            }
                            if (codename.ToUpper() != "IT")
                            {
                                string Temp_link = Environment.GetEnvironmentVariable("tmp") + "\\" + pingname + ".lnk";
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(Temp_link);
                                SGFunction.SystemFunctionAndInformation.CreateLink(Temp_link, path, arg, pingname, ico);
                                SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, Temp_link);
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(Temp_link);
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
                            case "DL":
                                pingname = "桌面便利贴.LNK";
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
                                if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.3")
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
                            case "LO":
                                pingname = "注销登录.lnk";
                                break;
                            case "LC":
                                pingname = "锁定计算机.lnk";
                                break;
                            case "PO":
                                pingname = "关闭计算机.lnk";
                                break;
                            case "RE":
                                pingname = "重启计算机.lnk";
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
                                if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.3" || SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.2")
                                {
                                    pingname = "文件资源管理器.lnk";
                                    _explorer = "File Explorer.lnk";
                                    SGFunction.SystemFunctionAndInformation.SetLink(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + _explorer, "PATH", Environment.GetEnvironmentVariable("WINDIR") + @"\EXPLORER.EXE");
                                }
                                else
                                {
                                    pingname = "Windows 资源管理器.lnk";
                                    _explorer = "Windows Explorer.lnk";
                                    SGFunction.SystemFunctionAndInformation.SetLink(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + _explorer, "PATH", Environment.GetEnvironmentVariable("WINDIR") + @"\EXPLORER.EXE");
                                }
                                break;
                        }
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("taskbaricons", codename.ToLower(), "HIDE", "config", false, cfg);
                        string linkpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + pingname;
                        SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(false, linkpath);
                        if (codename.ToUpper() == "EX")
                        {
                            string linkpath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + _explorer;
                            SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(false, linkpath2);
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(linkpath2);
                        }
                        SGFunction.SystemFunctionAndInformation.UpdateDesktop();
                    }
                }
                public static void SetTaskBarIcons_OpenFile()
                {
                    try
                    {
                        OpenFileDialog open = new OpenFileDialog();
                        open.CheckFileExists = true;
                        open.DereferenceLinks = false;
                        open.FileName = "";
                        open.Filter = "所有文件(*.*)|*.*";
                        open.Multiselect = false;
                        open.Title = "选择文件";
                        open.ShowDialog();
                        string filename = open.FileName;
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(filename )==true)
                        {
                            open.Dispose();
                            string filename_nolocationorext = Path.GetFileNameWithoutExtension(filename);
                            switch (Path.GetExtension(filename).ToUpper())
                            {
                                case ".LNK":
                                    SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, filename);
                                    break;
                                case ".EXE":
                                    string templinkpath = Environment.GetEnvironmentVariable("TMP") + @"\" + filename_nolocationorext + ".lnk";
                                    SGFunction.SystemFunctionAndInformation.CreateLink(templinkpath, filename, "", "", filename + ",0");
                                    SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, templinkpath);
                                    templinkpath = "";
                                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(templinkpath);
                                    break;
                                default:
                                    string templinkpath1 = Environment.GetEnvironmentVariable("TMP") + @"\" + filename_nolocationorext + ".lnk";
                                    SGFunction.SystemFunctionAndInformation.CreateLink(templinkpath1, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd.exe", "", "", "");
                                    SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, templinkpath1);
                                    string ping_linkname = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + filename_nolocationorext + ".lnk";
                                    SGFunction.SystemFunctionAndInformation.SetLink(ping_linkname, "Path", filename);
                                    SGFunction.SystemFunctionAndInformation.SetLink(ping_linkname, "icon", "");
                                    SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, ping_linkname);
                                    templinkpath1 = "";
                                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(templinkpath1);
                                    break;
                            }
                            SGFunction.SystemFunctionAndInformation.UpdateDesktop();
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功固定了文件到任务栏", 1);
                        }
                    }
                    catch { }
                }
                public static void SetTaskBarIcons_Folder()
                {
                    try
                    {
                        string folder = SGFunction.CommonDialogs.OpenFolderDialog("选择一个目录");
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(folder,false)==true)
                        {
                            string folder_nolocation;
                            if (folder.Length > 3)
                            {
                                folder_nolocation = folder.Substring(folder.LastIndexOf("\\"), folder.Length - folder.LastIndexOf("\\")).Replace("\\", "");
                            }
                            else
                            {
                                folder_nolocation = "Folder";
                            }
                            string ping_temp = Environment.GetEnvironmentVariable("tmp") + "\\" + folder_nolocation + ".lnk";
                            SGFunction.SystemFunctionAndInformation.CreateLink(ping_temp, Environment.GetEnvironmentVariable("windir") + @"\explorer.exe", "", "", "");
                            SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, ping_temp);
                            string ping_linkname = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + folder_nolocation + ".lnk";
                            SGFunction.SystemFunctionAndInformation.SetLink(ping_linkname, "PATH", folder);
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(ping_temp);
                            SGFunction.SystemFunctionAndInformation.UpdateDesktop();
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功固定了文件夹到任务栏", 1);
                        }
                    }
                    catch { }
                }
                public static void SetTaskBarIcons_MoreFunction()
                {
                    try
                    {
                        string res;
                        string[] arrs = SGFunction.CommonDialogs.ShowMoreFunctionDialog("选择一个操作并将其固定到任务栏", out res);
                        if (res=="ok" && arrs !=null)
                        {
                            string lnkname = arrs[0];
                            string ping_temp = Environment.GetEnvironmentVariable("tmp") + "\\" + arrs[0] + ".lnk";
                            if(arrs[4].ToUpper() =="TRUE")
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + "\\Admin.lnk.sgo", ping_temp);
                                SGFunction.SystemFunctionAndInformation.SetLink(ping_temp, "path", arrs[1]);
                                SGFunction.SystemFunctionAndInformation.SetLink(ping_temp, "args", arrs[2]);
                                SGFunction.SystemFunctionAndInformation.SetLink(ping_temp, "icon", arrs[3]);
                            }
                            else
                            {
                                SGFunction.SystemFunctionAndInformation.CreateLink(ping_temp, arrs[1], arrs[2], "", arrs[3]);
                            }
                            SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, ping_temp);
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(ping_temp);
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功将您的操作固定夹到任务栏", 1);
                        }
                    }
                    catch { }
                }
            }
        }
        public class RightMenuMgr
        {
            public class RightMenuGroup
            {
                public static void LoadConfigToTreeview(SGForm_Function_SystemStyle u,string cfg)
                {
                    try
                    {
                        SGTreeView s = u.sgTreeView_rightmenugroup;
                        ImageList o = u.imageList_rightmenugroup;
                        s.Nodes.Clear();
                        o.Images.Clear();
                        //读取基本信息
                        string main_name = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "NAME", "", cfg, false);
                        string main_ico = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "icon", "", cfg);
                        string c = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "commandcount", "0", cfg, false);
                        int main_count;
                        int.TryParse(c, out main_count);
                        o.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(main_ico));
                        s.Nodes.Add(main_name).ImageIndex =0;
                        s.Nodes[0].Tag = "MAIN";
                        //开始读取子菜单
                        for(int k=1;k<=main_count ;k++)
                        {
                            string name = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + k.ToString(), "name", "", cfg);
                            string icon = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + k.ToString(), "icon", "", cfg);
                            string isfenge = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + k.ToString(), "ISfengefu", "", cfg);
                            if(isfenge.ToUpper()=="T")
                            {
                                o.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(SGFunction.Resources.GetIconPath("FENGEFU")));
                                s.Nodes[0].Nodes.Add("分隔符").ImageIndex = o.Images.Count - 1;
                                s.Nodes[0].Nodes[s.Nodes[0].Nodes.Count - 1].SelectedImageIndex = o.Images.Count - 1;
                                s.Nodes[0].Nodes[s.Nodes[0].Nodes.Count - 1].Tag = k.ToString();
                            }
                            else
                            {
                                o.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(icon));
                                s.Nodes[0].Nodes.Add(name).ImageIndex = o.Images.Count - 1;
                                s.Nodes[0].Nodes[s.Nodes[0].Nodes.Count - 1].SelectedImageIndex = o.Images.Count - 1;
                                s.Nodes[0].Nodes[s.Nodes[0].Nodes.Count - 1].Tag = k.ToString();
                            }
                        }
                        s.ExpandAll();
                    }
                    catch { }
                }
                public static void CreateRightMenuGroup(string FileName)
                {
                    try
                  {
                        if (System.IO.File.Exists(FileName) == true)
                        {
                            string cnd=SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo","commandcount","0",FileName,false);
                            string CommandItems = "";
                            int CommandsNum;
                            int.TryParse(cnd, out CommandsNum);
                            string MainName = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "regname", "", FileName,false);
                            for (int j = 1; j <= CommandsNum; j = j + 1)
                            {

                                if (SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + j.ToString(), "isfengefu", "F",FileName,false).ToUpper() == "F")
                                {
                                    CommandItems = CommandItems + SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + j.ToString(), "REGNAME", "", FileName,false ) + @";";
                                }
                                else
                                {
                                    CommandItems = CommandItems + "|;";
                                }
                            }
                            string Position = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "POSITION", "TOP", FileName, false);
                            ///
                            SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"*\Shell", MainName);
                            SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\background\shell", MainName);
                            SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\shell", MainName);
                            SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"LibraryFolder\background\shell", MainName);
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"*\Shell", MainName);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.ClassesRoot, @"*\Shell\" + MainName, "Icon", SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", Application.ExecutablePath + ",0", FileName), RegistryValueKind.String);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.ClassesRoot, @"*\Shell\" + MainName, "MUIVerb", SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "系统齿轮右键菜单组",  FileName), RegistryValueKind.String);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.ClassesRoot, @"*\Shell\" + MainName, "SubCommands", CommandItems, RegistryValueKind.String);
                            ///
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"Directory\background\shell\", MainName);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "Icon", SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", Application.ExecutablePath + ",0",FileName), RegistryValueKind.String);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "MUIVerb", SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "系统齿轮右键菜单组",FileName), RegistryValueKind.String);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "SubCommands", CommandItems, RegistryValueKind.String);
                            if (Position != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, @"Directory\background\shell\" + MainName, "Position", Position, RegistryValueKind.String); }
                            ///
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"Directory\shell\", MainName);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.ClassesRoot, @"Directory\shell\" + MainName, "Icon", SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", Application.ExecutablePath + ",0", FileName), RegistryValueKind.String);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, @"Directory\shell\" + MainName, "MUIVerb", SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "系统齿轮右键菜单组", FileName), RegistryValueKind.String);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, @"Directory\shell\" + MainName, "SubCommands", CommandItems, RegistryValueKind.String);
                            ///
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, @"LibraryFolder\background\shell\", MainName);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, @"LibraryFolder\background\shell\" + MainName, "Icon", SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "icon", Application.ExecutablePath + ",0", FileName), RegistryValueKind.String);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, @"LibraryFolder\background\shell\" + MainName, "MUIVerb", SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "name", "系统齿轮右键菜单组", FileName), RegistryValueKind.String);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, @"LibraryFolder\background\shell\" + MainName, "SubCommands", CommandItems, RegistryValueKind.String);
                            if (Position != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, @"LibraryFolder\background\shell\" + MainName, "Position", Position, RegistryValueKind.String); }
                            string scr = SGFunction.Resources.GetResourcePath("runasadminvbs");
                            for (int p = 1; p <= CommandsNum; p = p + 1)
                            {

                                string CMDREGName = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "REGNAME", "", FileName,false );
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell", CMDREGName);
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\" + CMDREGName, "Command");
                                string N_CMD = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "command", "", FileName);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\" + CMDREGName, "", SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "name", "", FileName), RegistryValueKind.String);
                                string ico=SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "icon", "", FileName);;;
                                if (ico != "") {SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\" + CMDREGName, "Icon", ico, RegistryValueKind.ExpandString); }
                                if (SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "runasadmin", "", FileName,false).ToUpper() == "T")
                                {
                                    N_CMD = @"%SystemRoot%\System32\wscript.exe """ + scr+@""" "+SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "command", "",FileName);
                                }
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell\" + CMDREGName + @"\Command", "", N_CMD, RegistryValueKind.ExpandString);
                            }
                            if (System.IO.File.Exists(scr) == false) { SGFunction.ScriptOperate.CreateRunAsAdminVBS(); }
                            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "005");
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("configfile", "file", FileName, "config", false, cfg);
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
            }
            public class ClipBoredOperate
            {
                /// <summary>
                /// 获取剪切板工具是否注册了右键菜单
                /// </summary>
                /// <returns></returns>
                public static bool GetClipboardShellIsRegistry()
                {
                    try
                    {
                        string read = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, @"Directory\shell\SaveClipboardAsFile", "muiverb", "no");
                        if (read == "no") { return false; } else { return true; }
                    }
                    catch { return false; }
                }
                /// <summary>
                /// 获取当前剪切板的格式 [text]文本 [image]图像 [file]文件 [unknown]未知
                /// </summary>
                /// <returns></returns>
                public static string GetClipBoredType()
                {
                    string ret = "unknown";
                    try
                    {
                        IDataObject iData = Clipboard.GetDataObject();
                        if(iData.GetDataPresent(DataFormats.Text)==true)
                        {
                            //wenben
                            ret = "text";
                        }
                        else
                        {
                            if (iData.GetDataPresent(DataFormats.Bitmap) == true)
                            {
                                //weitu
                                ret = "image";
                            }
                            else
                            {
                                if (iData.GetDataPresent(DataFormats.Rtf) == true)
                                {
                                    //rtf
                                    ret = "rtf";
                                }
                                else
                                {
                                    if (iData.GetDataPresent(DataFormats.FileDrop) == true)
                                    {
                                        //file
                                        ret = "file";
                                    }
                                    else { ret = "unknown"; }
                                }
                            }
                        }
                        return ret;
                    }
                    catch { return ret; }
                }
                public static object GetClipBoredRead()
                {
                    string temp_html = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\temp_fromclip.html";
                    string temp_info = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\temp_fromclip_info.sgcf";
                    object b = null;
                    try
                    {
                        IDataObject iData = Clipboard.GetDataObject();
                        if (iData.GetDataPresent(DataFormats.Text)==true)
                        {
                            //wenben
                            b = (string)iData.GetData(DataFormats.Text);
                        }
                        else
                        {
                            if (iData.GetDataPresent(DataFormats.Bitmap) == true)
                            {
                                //weitu
                                b = (Image)iData.GetData(DataFormats.Bitmap);
                            }
                            else
                            {
                                if (iData.GetDataPresent(DataFormats.FileDrop))
                                {
                                    //file
                                    b = (string[])iData.GetData(DataFormats.FileDrop);
                                }
                                else { b = null; }
                            }
                        }
                        return b;
                    }
                    catch { return b; }
                }
                public static void LoadToUI(SGForm_Function_SystemStyle s)
                {
                    string f = GetClipBoredType();
                    object obj=GetClipBoredRead();
                    string t = "不支持当前剪切板中的内容";
                    bool btnvis = false;
                    s.sgLabel_noneirong.Visible = false;
                    switch(f)
                    {
                        case "image":
                            //s.sgLabel11.Text = "剪切板的内容 : 图像";
                            s.pictureBox_clip.Image = new Bitmap((Bitmap)obj);
                            s.pictureBox_clip.Visible = true;
                            s.sgTextBox_clip.Visible = false;
                            btnvis = true;
                            s.MyNormalButton_clipsave.Text = "保存为图片";
                            break;
                        case "text":
                           // s.sgLabel11.Text = "剪切板的内容 : 文本";
                            s.pictureBox_clip.Visible = false;
                            s.sgTextBox_clip.Visible = true;
                            s.sgTextBox_clip.Text = (string)obj;
                            s.MyNormalButton_clipsave.Text = "保存为文本";
                            btnvis = true;
                            break;
                        case "file":
                           // s.sgLabel11.Text = "剪切板的内容 : 文件(夹)";
                            s.pictureBox_clip.Visible = false;
                            s.sgTextBox_clip.Visible = true;
                            s.sgTextBox_clip.Lines  = (string[])obj;
                            s.MyNormalButton_clipsave.Text = "复制到...";
                            btnvis = true;
                            break;
                        case "unknown":
                         //   s.sgLabel11.Text = "剪切板的内容 : 未知或不支持的类型";
                            s.pictureBox_clip.Visible = false;
                            s.sgTextBox_clip.Visible = false;
                            btnvis = false;
                            s.sgLabel_noneirong.Visible = true;
                            break;
                    }
                    s.MyNormalButton_clipsave.Visible = btnvis;
                }
            }
            public class RightMenusGroupMgr
            {
                public static void LoadSendToMenu(SGForm_Function_SystemStyle f)
                {
                    f.listView8.Items.Clear(); f.imageList_rmmgr_listimage.Images.Clear();
                    string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo";
                    string desktop = folder + @"\desktop.ini";
                    string[] files = SGFunction.FileSystemOperate.FileSystemOperate_GetFiles(folder, "*.*", SearchOption.TopDirectoryOnly);
                    try
                    {
                        for (int u = 1; u <= files.Length; u++)
                        {
                            FileInfo fi = new FileInfo(files[u - 1]);
                            if(fi.Name.ToUpper() !="DESKTOP.INI")
                            {
                                string name = fi.Name;
                                if (fi.Extension != "") { name = name.Substring(0, name.LastIndexOf(".")); }
                                string read_mui = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue("LocalizedFileNames", fi.Name, "", desktop, false);
                                if (read_mui != "") { name = SGFunction.MUIOperate.GetMUIString(read_mui, name); }
                                Bitmap ico;
                                string cmd = "";
                                //判断ICO
                                //获取CMD的格式
                                ico = SGFunction.ImageAndIconOperate.GetFileIcon(files[u - 1]);
                                //PANDUAN CMD
                                cmd = files[u - 1];
                                f.listView8.Items.Add(name).Tag = new string[] { files[u - 1] };
                                f.imageList_rmmgr_listimage.Images.Add(ico);
                                f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                                f.listView8.Items[f.listView8.Items.Count - 1].SubItems.Add(cmd);
                            }
                        }
                    }
                    catch { }
                }
                public static void LoadDesktopMenu(SGForm_Function_SystemStyle f)
                {
                    f.listView8.Items.Clear(); f.imageList_rmmgr_listimage.Images.Clear();
                    string location1_1 = @"SOFTWARE\Classes\Directory\background\shellex\ContextMenuHandlers"; //HKLM
                    string location1_2 = @"SOFTWARE\Classes\Directory\background\shell"; //HKLM
                    string location2_1 = @"DesktopBackground\Shell"; //HKCR
                    string location2_2 = @"DesktopBackground\shellex\ContextMenuHandlers"; //HKCR
                    string location3_1 = @"Directory\Background\shellex\ContextMenuHandlers";//HKCR
                    string location3_2 = @"Directory\Background\shell";//HKCR
                    if (System.IO.Directory.Exists(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenus") == false) { SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenus"); }
                    //检测1_2
                    if (Registry.LocalMachine.OpenSubKey(location1_2) != null)
                    {
                        string[] regs = Registry.LocalMachine.OpenSubKey(location1_2).GetSubKeyNames();
                        for (int h = 1; h <= regs.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.LocalMachine, location1_2, regs[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKLM," + location1_2 + ","+regs[h-1]};
                        }
                    }
                    //检测2_1
                    if (Registry.ClassesRoot.OpenSubKey(location2_1) != null)
                    {
                        string[] regs_1 = Registry.ClassesRoot.OpenSubKey(location2_1).GetSubKeyNames();
                        for (int h = 1; h <= regs_1.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.ClassesRoot, location2_1, regs_1[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag =new string[]{gh[1], "HKCR," + location2_1 + "," + regs_1[h - 1]};
                        }
                    }
                    //检测3_2
                    if (Registry.ClassesRoot.OpenSubKey(location3_2) != null)
                    {
                        string[] regs_1 = Registry.ClassesRoot.OpenSubKey(location3_2).GetSubKeyNames();
                        for (int h = 1; h <= regs_1.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.ClassesRoot, location3_2, regs_1[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[] { gh[1], "HKCR," + location3_2 + "," + regs_1[h - 1] };
                        }
                    }
                    //检测1_1
                    if (Registry.LocalMachine.OpenSubKey(location1_1) != null)
                    {
                        string[] regs_2 = Registry.LocalMachine.OpenSubKey(location1_1).GetSubKeyNames();
                        for (int h = 1; h <= regs_2.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetContextHanderInfo(Registry.LocalMachine, location1_1, regs_2[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKLM," + location1_1 + "," + regs_2[h - 1]};
                        }
                    }
                    //检测3_1
                    if (Registry.ClassesRoot.OpenSubKey(location3_1) != null)
                    {
                        string[] regs_2 = Registry.ClassesRoot.OpenSubKey(location3_1).GetSubKeyNames();
                        for (int h = 1; h <= regs_2.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetContextHanderInfo(Registry.ClassesRoot, location3_1, regs_2[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[] { gh[1], "HKCR," + location3_1 + "," + regs_2[h - 1] };
                        }
                    }
                    //检测2_2
                    if (Registry.ClassesRoot.OpenSubKey(location2_2) != null)
                    {
                        string[] regs_3 = Registry.ClassesRoot.OpenSubKey(location2_2).GetSubKeyNames();
                        for (int h = 1; h <= regs_3.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetContextHanderInfo(Registry.ClassesRoot, location2_2, regs_3[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag =new string[]{gh[1], "HKCR," + location2_2 + "," + regs_3[h - 1]};
                        }
                    }
                }
                public static void LoadMyComputer(SGForm_Function_SystemStyle f)
                {
                    f.listView8.Items.Clear(); f.imageList_rmmgr_listimage.Images.Clear();
                    string loc =@"CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}\shell";
                    if (Registry.ClassesRoot.OpenSubKey(loc) != null)
                    {
                        string[] regs = Registry.ClassesRoot.OpenSubKey(loc).GetSubKeyNames();
                        for (int h = 1; h <= regs.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.ClassesRoot, loc, regs[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKCR," + loc + "," + regs[h - 1]};
                        }
                    }
                    
                }
                public static void LoadAllFile(SGForm_Function_SystemStyle f)
                {
                    f.listView8.Items.Clear(); f.imageList_rmmgr_listimage.Images.Clear();
                    string cfg_d = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenus\\AllFile.sgcf";
                    string loc_1 = @"*\shell";
                    string loc_2 = @"*\shellex\ContextMenuHandlers";
                    //1
                    if (Registry.ClassesRoot.OpenSubKey(loc_1) != null)
                    {
                        string[] regs = Registry.ClassesRoot.OpenSubKey(loc_1).GetSubKeyNames();
                        for (int h = 1; h <= regs.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.ClassesRoot, loc_1, regs[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKCR," + loc_1 + "," + regs[h - 1]};
                        }
                    }

                    //2
                    if (Registry.ClassesRoot.OpenSubKey(loc_2) != null)
                    {
                        string[] regs_1 = Registry.ClassesRoot.OpenSubKey(loc_2).GetSubKeyNames();
                        for (int h = 1; h <= regs_1.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetContextHanderInfo(Registry.ClassesRoot, loc_2, regs_1[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKCR," + loc_2 + "," + regs_1[h - 1]};
                        }
                    }

                }
                public static void LoadAllFolder(SGForm_Function_SystemStyle f)
                {
                    f.listView8.Items.Clear(); f.imageList_rmmgr_listimage.Images.Clear();
                    string cfg_d = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenus\\AllFolder.sgcf";
                    string loc_1 = @"SOFTWARE\Classes\Folder\shell"; //hklm
                    string loc_2 = @"SOFTWARE\Classes\Folder\shellex\ContextMenuHandlers";
                    //1
                    if (Registry.LocalMachine.OpenSubKey(loc_1) != null)
                    {
                        string[] regs = Registry.LocalMachine.OpenSubKey(loc_1).GetSubKeyNames();
                        for (int h = 1; h <= regs.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.LocalMachine, loc_1, regs[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag =new string[]{gh[1],"HKlm," + loc_1 + "," + regs[h - 1]};
                        }
                    }

                    //2
                    if (Registry.LocalMachine.OpenSubKey(loc_2) != null)
                    {
                        string[] regs_1 = Registry.LocalMachine.OpenSubKey(loc_2).GetSubKeyNames();
                        for (int h = 1; h <= regs_1.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetContextHanderInfo(Registry.LocalMachine, loc_2, regs_1[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKlm," + loc_2 + "," + regs_1[h - 1]};
                        }
                    }
                }
                public static void LoadAllDisk(SGForm_Function_SystemStyle f)
                {
                    f.listView8.Items.Clear(); f.imageList_rmmgr_listimage.Images.Clear();
                    string cfg_d = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenus\\AllDisk.sgcf";
                    string loc_1 = @"SOFTWARE\Classes\Drive\shell"; //hklm
                    string loc_2 = @"SOFTWARE\Classes\Drive\shellex\ContextMenuHandlers";
                    //1
                    if (Registry.LocalMachine.OpenSubKey(loc_1) != null)
                    {
                        string[] regs = Registry.LocalMachine.OpenSubKey(loc_1).GetSubKeyNames();
                        for (int h = 1; h <= regs.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.LocalMachine, loc_1, regs[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKlm," + loc_1 + "," + regs[h - 1]};
                        }
                    }

                    //2
                    if (Registry.LocalMachine.OpenSubKey(loc_2) != null)
                    {
                        string[] regs_1 = Registry.LocalMachine.OpenSubKey(loc_2).GetSubKeyNames();
                        for (int h = 1; h <= regs_1.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetContextHanderInfo(Registry.LocalMachine, loc_2, regs_1[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKlm," + loc_2 + "," + regs_1[h - 1]};
                        }
                    }

                }
                public static void LoadExeFile(SGForm_Function_SystemStyle f)
                {
                    f.listView8.Items.Clear(); f.imageList_rmmgr_listimage.Images.Clear();
                    string ext = "exe";
                    string key = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "." + ext, "", "");
                    if (key == "")
                    {
                        key = ext + "file";
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shell");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "DefaultIcon");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shellex");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key + @"\shellex", "ContextMenuHandlers");
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, key + "\\defaulticon", "", "%1", RegistryValueKind.String);
                    }
                    string loc_2 = key + @"\shellex\ContextMenuHandlers";
                    string loc_1 = key + @"\shell";
                    //1
                    if (Registry.ClassesRoot.OpenSubKey(loc_1) != null)
                    {
                        string[] regs = Registry.ClassesRoot.OpenSubKey(loc_1).GetSubKeyNames();
                        for (int h = 1; h <= regs.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.ClassesRoot, loc_1, regs[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKcr," + loc_1 + "," + regs[h - 1]};
                        }
                    }
                    if (Registry.ClassesRoot.OpenSubKey(loc_2) != null)
                    {
                        //2
                        string[] regs_1 = Registry.ClassesRoot.OpenSubKey(loc_2).GetSubKeyNames();
                        for (int h = 1; h <= regs_1.Length; h++)
                        {
                            string[] gh = SGFunction.CLSIDAndHanderOperate.GetContextHanderInfo(Registry.ClassesRoot, loc_2, regs_1[h - 1]);
                            f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                            f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                            f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                            f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKcr," + loc_2 + "," + regs_1[h - 1]};
                        }
                    }


                }
                public static void LoadLnkFile(SGForm_Function_SystemStyle f)
                {
                    f.listView8.Items.Clear(); f.imageList_rmmgr_listimage.Images.Clear();
                    string ext = "lnk";
                    string key = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "." + ext, "", "");
                    if (key == "")
                    {
                        key = ext + "file";
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shell");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shellex");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key + @"\shellex", "ContextMenuHandlers");
                        //SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, key + "\\defaulticon", "", @"%windir%\system32\imageres.dll,2", RegistryValueKind.ExpandString);
                    }
                    string loc_2 = key + @"\shellex\ContextMenuHandlers";
                    string loc_1 = key + @"\shell";
                    if (Registry.ClassesRoot.OpenSubKey(loc_1) != null)
                    {
                        //1
                        if (Registry.ClassesRoot.OpenSubKey(loc_1) != null)
                        {
                            string[] regs = Registry.ClassesRoot.OpenSubKey(loc_1).GetSubKeyNames();
                            for (int h = 1; h <= regs.Length; h++)
                            {
                                string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.ClassesRoot, loc_1, regs[h - 1]);
                                f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                                f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                                f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                                f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKcr," + loc_1 + "," + regs[h - 1]};
                            }
                        }
                    }
                    if (Registry.ClassesRoot.OpenSubKey(loc_2) != null)
                    {
                        //2
                        if (Registry.ClassesRoot.OpenSubKey(loc_2) != null)
                        {
                            string[] regs_1 = Registry.ClassesRoot.OpenSubKey(loc_2).GetSubKeyNames();
                            for (int h = 1; h <= regs_1.Length; h++)
                            {
                                string[] gh = SGFunction.CLSIDAndHanderOperate.GetContextHanderInfo(Registry.ClassesRoot, loc_2, regs_1[h - 1]);
                                f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                                f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                                f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                                f.listView8.Items[f.listView8.Items.Count - 1].Tag =new string[]{gh[1], "HKcr," + loc_2 + "," + regs_1[h - 1]};
                            }
                        }
                    }



                }
                public static void LoadTxtFile(SGForm_Function_SystemStyle f)
                {
                    f.listView8.Items.Clear(); f.imageList_rmmgr_listimage.Images.Clear();
                    string ext = "txt";
                    string key = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "."+ext, "", "");
                    if (key == "")
                    {
                        key = ext + "file";
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shell");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "DefaultIcon");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shellex");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key + @"\shellex", "ContextMenuHandlers");
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, key + "\\defaulticon", "", @"%windir%\system32\imageres.dll,97", RegistryValueKind.ExpandString);
                    }
                    string loc_2 = key + @"\shellex\ContextMenuHandlers";
                    string loc_1 = key + @"\shell";
                    if (Registry.ClassesRoot.OpenSubKey(loc_1) != null)
                    {
                        //1
                        if (Registry.ClassesRoot.OpenSubKey(loc_1) != null)
                        {
                            string[] regs = Registry.ClassesRoot.OpenSubKey(loc_1).GetSubKeyNames();
                            for (int h = 1; h <= regs.Length; h++)
                            {
                                string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.ClassesRoot, loc_1, regs[h - 1]);
                                f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                                f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                                f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                                f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKcr," + loc_1 + "," + regs[h - 1]};

                            }
                        }
                    }
                    if (Registry.ClassesRoot.OpenSubKey(loc_2) != null)
                    {
                        //2
                        if (Registry.ClassesRoot.OpenSubKey(loc_2) != null)
                        {
                            string[] regs_1 = Registry.ClassesRoot.OpenSubKey(loc_2).GetSubKeyNames();
                            for (int h = 1; h <= regs_1.Length; h++)
                            {
                                string[] gh = SGFunction.CLSIDAndHanderOperate.GetContextHanderInfo(Registry.ClassesRoot, loc_2, regs_1[h - 1]);
                                f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                                f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                                f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                                f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKcr," + loc_2 + "," + regs_1[h - 1]};
                            }
                        }
                    }



                }
                public static void LoadDLLFile(SGForm_Function_SystemStyle f)
                {
                    f.listView8.Items.Clear(); f.imageList_rmmgr_listimage.Images.Clear();
                    string ext = "dll";
                    string key = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "." + ext, "", "");
                    if (key == "")
                    {
                        key = ext+ "file";
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shell");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "DefaultIcon");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shellex");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key + @"\shellex", "ContextMenuHandlers");
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, key + "\\defaulticon", "", @"%windir%\system32\imageres.dll,62", RegistryValueKind.ExpandString);
                    }
                    string loc_2 = key + @"\shellex\ContextMenuHandlers";
                    string loc_1 = key + @"\shell";
                    if (Registry.ClassesRoot.OpenSubKey(loc_1) != null)
                    {
                        //1
                        if (Registry.ClassesRoot.OpenSubKey(loc_1) != null)
                        {
                            string[] regs = Registry.ClassesRoot.OpenSubKey(loc_1).GetSubKeyNames();
                            for (int h = 1; h <= regs.Length; h++)
                            {
                                string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.ClassesRoot, loc_1, regs[h - 1]);
                                f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                                f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                                f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                                f.listView8.Items[f.listView8.Items.Count - 1].Tag =new string[]{gh[1], "HKcr," + loc_1 + "," + regs[h - 1]};
                            }
                        }
                    }
                    if (Registry.ClassesRoot.OpenSubKey(loc_2) != null)
                    {
                        //2
                        if (Registry.ClassesRoot.OpenSubKey(loc_2) != null)
                        {
                            string[] regs_1 = Registry.ClassesRoot.OpenSubKey(loc_2).GetSubKeyNames();
                            for (int h = 1; h <= regs_1.Length; h++)
                            {
                                string[] gh = SGFunction.CLSIDAndHanderOperate.GetContextHanderInfo(Registry.ClassesRoot, loc_2, regs_1[h - 1]);
                                f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                                f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                                f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                                f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[]{gh[1],"HKcr," + loc_2 + "," + regs_1[h - 1]};
                            }
                        }
                    }



                }
                public static void LoadMenus(SGForm_Function_SystemStyle f)
                {
                    string def=Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-2";
                    f.imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(Environment.GetFolderPath(Environment.SpecialFolder.System )+"\\imageres.dll,-110",def,16));
                    f.imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-109", def, 16));
                    f.imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-2", def, 16));
                    f.imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-3", def, 16));
                    f.imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-32", def, 16));
                    f.imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-15", def, 16));
                    f.imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-163", def, 16));
                    f.imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-19", def, 16));
                    f.imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-67", def, 16));
                    f.imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-5303", def, 16));
                    f.sgTreeView2.Nodes[0].ImageIndex = 0;
                    f.sgTreeView2.Nodes[1].ImageIndex = 1;
                    f.sgTreeView2.Nodes[2].ImageIndex = 2;
                    f.sgTreeView2.Nodes[3].ImageIndex = 3;
                    f.sgTreeView2.Nodes[4].ImageIndex = 4;
                    f.sgTreeView2.Nodes[5].ImageIndex = 5;
                    f.sgTreeView2.Nodes[6].ImageIndex = 6;
                    f.sgTreeView2.Nodes[7].ImageIndex = 7;
                    f.sgTreeView2.Nodes[8].ImageIndex = 8;
                    f.sgTreeView2.Nodes[9].ImageIndex = 9;
                    f.sgTreeView2.Nodes[10].ImageIndex = 2;
                    f.sgTreeView2.Nodes[0].SelectedImageIndex  = 0;
                    f.sgTreeView2.Nodes[1].SelectedImageIndex = 1;
                    f.sgTreeView2.Nodes[2].SelectedImageIndex = 2;
                    f.sgTreeView2.Nodes[3].SelectedImageIndex = 3;
                    f.sgTreeView2.Nodes[4].SelectedImageIndex = 4;
                    f.sgTreeView2.Nodes[5].SelectedImageIndex = 5;
                    f.sgTreeView2.Nodes[6].SelectedImageIndex = 6;
                    f.sgTreeView2.Nodes[7].SelectedImageIndex = 7;
                    f.sgTreeView2.Nodes[8].SelectedImageIndex = 8;
                    f.sgTreeView2.Nodes[9].SelectedImageIndex = 9;
                    f.sgTreeView2.Nodes[10].SelectedImageIndex = 2;
                    f.sgTreeView2.Nodes[1].Text = SGFunction.ProgramInfo.GetMyComputerName();
                    //if (System.IO.Directory.Exists(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenus") == false) { SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenus"); }
                    //LoadTxtFile(f);
                    f.sgTreeView2.SelectedNode = f.sgTreeView2.Nodes[0];
                }
                public static void LoadAnyFile(SGForm_Function_SystemStyle f,string ext)
                {
                    f.listView8.Items.Clear(); f.imageList_rmmgr_listimage.Images.Clear();
                    string key = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, ext, "", "");
                    if(key =="")
                    {
                        key =ext.Replace(".","")+ "file";
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shell");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "DefaultIcon");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key, "shellex");
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, key + @"\shellex", "ContextMenuHandlers");
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, key + "\\defaulticon", "", @"%windir%\system32\imageres.dll,2", RegistryValueKind.ExpandString);
                    }
                    string loc_2 = key+@"\shellex\ContextMenuHandlers";
                    string loc_1 = key+@"\shell";
                    if (Registry.ClassesRoot.OpenSubKey(loc_1) != null)
                    {
                        //1
                        if (Registry.ClassesRoot.OpenSubKey(loc_1) != null)
                        {
                            string[] regs = Registry.ClassesRoot.OpenSubKey(loc_1).GetSubKeyNames();
                            for (int h = 1; h <= regs.Length; h++)
                            {
                                string[] gh = SGFunction.CLSIDAndHanderOperate.GetRightMenuInfoFormRegistry(Registry.ClassesRoot, loc_1, regs[h - 1]);
                                f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                                f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                                f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                                f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[] { gh[1], "HKcr," + loc_1 + "," + regs[h - 1] };
                            }
                        }
                    }
                    if (Registry.ClassesRoot.OpenSubKey(loc_2) != null)
                    {
                        //2
                        if (Registry.ClassesRoot.OpenSubKey(loc_2) != null)
                        {
                            string[] regs_1 = Registry.ClassesRoot.OpenSubKey(loc_2).GetSubKeyNames();
                            for (int h = 1; h <= regs_1.Length; h++)
                            {
                                string[] gh = SGFunction.CLSIDAndHanderOperate.GetContextHanderInfo(Registry.ClassesRoot, loc_2, regs_1[h - 1]);
                                f.listView8.Items.Add(gh[0]).SubItems.Add(gh[2]);
                                f.imageList_rmmgr_listimage.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(gh[1]));
                                f.listView8.Items[f.listView8.Items.Count - 1].ImageIndex = f.imageList_rmmgr_listimage.Images.Count - 1;
                                f.listView8.Items[f.listView8.Items.Count - 1].Tag = new string[] { gh[1], "HKcr," + loc_2 + "," + regs_1[h - 1] };
                            }
                        }
                    }



                }
            }
            public class RunCommands
            {
                public static void LoadRunCommands(SGForm_Function_SystemStyle user)
                {
                    try
                    {
                        string[] cmds = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths").GetSubKeyNames();
                        user.listView6.Items.Clear();
                        user.imageList_runcommands.Images.Clear();
                        for (int h = 1; h <= cmds.Length; h++)
                        {
                            user.listView6.Items.Add(cmds[h - 1].Substring(0, cmds[h - 1].LastIndexOf(".")));
                            string program_path = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + cmds[h - 1]).GetValue("", "", RegistryValueOptions.None).ToString().Replace(@"""", "");
                            program_path = SGFunction.PathOperate.ConvertStringToTurePath(program_path, program_path);
                            string ico = program_path;
                            bool isok;
                            string extname = "";
                            if (program_path == "")
                            {
                                ico = Environment.GetEnvironmentVariable("windir") + @"\system32\imageres.dll,11";
                                isok = false;
                            }
                            else
                            {
                               if(ico!="")
                               {
                                   isok = true;
                               }
                               else
                               {
                                   ico = program_path;
                                   isok = true;
                               }

                                //if (System.IO.File.Exists(program_path) == true) { isok = true; extname = Path.GetExtension(program_path); } else { isok = false; }
                            }
                            if (isok == false)
                            {
                                user.listView6.Items[h - 1].ForeColor = Color.Red;
                            }
                            extname = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(program_path);
                            string ext_info = "";
                            switch (extname.ToUpper())
                            {
                                case "EXE":
                                    ext_info = "程序";
                                    break;
                                case "LNK":
                                    ext_info = "快捷方式";
                                    break;
                                case "":
                                    ext_info = "";
                                    break;
                                default:
                                    ext_info = "文件或未知类型";
                                    break;
                            }

                            if (ext_info == "快捷方式")
                            {
                                string newico = SGFunction.SystemFunctionAndInformation.ReadLink(program_path, "icon");
                                if (newico.Substring(0, 1) == ",")
                                {
                                    newico = SGFunction.SystemFunctionAndInformation.ReadLink(program_path, "path") + SGFunction.SystemFunctionAndInformation.ReadLink(program_path, "icon");
                                }
                                ico = newico;
                                program_path = SGFunction.SystemFunctionAndInformation.ReadLink(program_path, "path");
                            }
                            Bitmap img = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico, "");
                            user.imageList_runcommands.Images.Add(img);
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
            }
        }
        public class Win8Style
        {
            public static void LoadWin8StartBackStyle(SGForm_Function_SystemStyle user)
            {
                string RegValue = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", "AccentId_v8.00", "100");
                foreach (Control control in user.flowLayoutPanel_startscreenback_win8.Controls)
                {
                    if (control.GetType() == typeof(MyNormalButton)) //按类型查找
                    {
                        MyNormalButton pb = control as MyNormalButton; //转换为具体控件类型
                        //MessageBox.Show(pb.Image.Height.ToString());
                        pb.FlatAppearance.BorderColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "pc");
                        if (RegValue == pb.Tag.ToString())
                        {
                            pb.FlatAppearance.BorderColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
                        }
                    }
                }
            }
            public static void LoadWin81StartBackStyle(SGForm_Function_SystemStyle user)
            {
                string RegValue = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", "MotionAccentId_v1.00", "221");
                foreach (Control control in user.flowLayoutPanel_startscreenback_win81.Controls)
                {
                    if (control.GetType() == typeof(MyNormalButton)) //按类型查找
                    {
                        MyNormalButton pb = control as MyNormalButton; //转换为具体控件类型
                        //MessageBox.Show(pb.Image.Height.ToString());
                        pb.FlatAppearance.BorderColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "pc");
                        if (RegValue == pb.Tag.ToString())
                        {
                            pb.FlatAppearance.BorderColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
                        }
                    }
                }
            }
            public static void SystemStyle_SetWin8StartBackStyle(string RegValue, SGForm_Function_SystemStyle user)
            {
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", @"AccentId_v8.00", RegValue, RegistryValueKind.DWord);
                foreach (Control control in user.flowLayoutPanel_startscreenback_win8.Controls)
                {
                    if (control.GetType() == typeof(MyNormalButton)) //按类型查找
                    {
                        MyNormalButton  pb = control as MyNormalButton; //转换为具体控件类型
                        //MessageBox.Show(pb.Image.Height.ToString());
                        pb.FlatAppearance.BorderColor = SGFunction.Skins.Skins_GetMainColorSetting("SGTAB", "PC");
                        if (RegValue == pb.Tag.ToString())
                        {
                            pb.FlatAppearance.BorderColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
                        }
                    }
                }

            }
            public static void SystemStyle_SetWin81StartBackStyle(string RegValue, SGForm_Function_SystemStyle user)
            {
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", @"MotionAccentId_v1.00", RegValue, RegistryValueKind.DWord);
                foreach (Control control in user.flowLayoutPanel_startscreenback_win81.Controls)
                {
                    if (control.GetType() == typeof(MyNormalButton)) //按类型查找
                    {
                        MyNormalButton pb = control as MyNormalButton; //转换为具体控件类型
                        //MessageBox.Show(pb.Image.Height.ToString());
                        pb.FlatAppearance.BorderColor = SGFunction.Skins.Skins_GetControlColorSetting("SGTAB", "PC");
                        if (RegValue == pb.Tag.ToString())
                        {
                            pb.FlatAppearance.BorderColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
                        }
                    }
                }

            }
            public static void SystemStyle_SetWin8StartSrceenColor(string RegValue,SGForm_Function_SystemStyle user)
            {
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", @"AccentId_v2", RegValue, RegistryValueKind.DWord);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", @"ColorSet_Version3", RegValue, RegistryValueKind.DWord);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", @"ColorSet_Version1", RegValue, RegistryValueKind.DWord);
                int ll = 0;
                int.TryParse(RegValue, out ll);
                user.pictureBox48.Location = new Point(6 + 26 * ll, 168);
            }
            public static void SystemStyle_LoadWin8StartSrceenColor(SGForm_Function_SystemStyle  user)
            {
                string RegValue = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent", "ColorSet_Version3", "0");
                int j;
                int.TryParse(RegValue, out j);
                user.pictureBox48.Location = new Point(6 + 26 * j, 168);
            }
            /// <summary>
            /// 加载Win8.1的开始屏幕颜色
            /// </summary>
            /// <param name="u">窗体</param>
            /// <param name="index">代号 [1]背景色 [2]个性色</param>
            public static void SystemStyle_LoadStartScreenColorSettingsInWin81(SGForm_Function_SystemStyle  u, int index)
            {
                try
                {
                    if (index == 1)
                    {
                        string reg = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent";
                        string creg = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, reg, "startcolor", "00000000");
                        int j;
                        int.TryParse(creg, out j);
                        Color c = ColorTranslator.FromWin32(j);
                        u.panel_STARTCOLOR_BACK.BackColor = c;
                        u.panel_STARTCOLOR_BACK.Tag = c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString();
                    }
                    else
                    {
                        if (index == 2)
                        {
                            string reg = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent";
                            string creg = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, reg, "AccentColor", "00000000");
                            int j;
                            int.TryParse(creg, out j);
                            Color c = ColorTranslator.FromWin32(j);
                            u.panel_STARTCOLOR_ACC.BackColor = c;
                            u.panel_STARTCOLOR_ACC.Tag = c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString();
                        }
                    }
                }
                catch { }
            }
            public static void GetPowerButtonInStartScreen(SGForm_Function_SystemStyle u)
            {
                try
                {
                    string loc = @"Software\Microsoft\Windows\CurrentVersion\ImmersiveShell\Launcher";
                    RegistryKey ke = Registry.CurrentUser.OpenSubKey(loc);
                    if(ke==null)
                    {
                        u.sgCheckBox5.Checked = true;
                    }
                    else
                    {
                        string v = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, loc, "Launcher_ShowPowerButtonOnStartScreen", "1");
                        if(v=="0")
                        {
                            u.sgCheckBox5.Checked = false;
                        }
                        else
                        {
                            u.sgCheckBox5.Checked = false;
                        }
                    }
                }
                catch { }
            }
            public static void SetPowerButtonInStartScreen(SGForm_Function_SystemStyle u,string type)
            {
                try
                {
                    string v1="1";
                    if(type=="hide"){v1="0";}
                    string loc = @"Software\Microsoft\Windows\CurrentVersion\ImmersiveShell\Launcher";
                    RegistryKey ke = Registry.CurrentUser.OpenSubKey(loc);
                    if (ke == null)
                    {
                        Registry.CurrentUser.CreateSubKey(loc);
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, loc, "Launcher_ShowPowerButtonOnStartScreen", v1, RegistryValueKind.DWord, false);
                    }
                    else
                    {
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, loc, "Launcher_ShowPowerButtonOnStartScreen", v1, RegistryValueKind.DWord, false);
                    }
                }
                catch { }
            }
            public class WinXMenu
            {
                public static void SystemStyle_DeleteGroup(int groupcount)
                {
                    string deletedir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\Group" + groupcount.ToString();
                    //IS EXISIS
                    if(SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(deletedir,false)==true)
                    {
                        string orgpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX";
                        string[] finddirs = SGFunction.FileSystemOperate.FileSystemOperate_GetFolders(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX", SearchOption.TopDirectoryOnly);
                        if(finddirs !=null)
                        {
                            if(finddirs.Length >0)
                            {
                                int tt = groupcount;
                                int temp=0;
                                int times = finddirs.Length - groupcount;
                                if (times > 0)
                                {
                                    SGFunction.FileSystemOperate.DeleteFileFolderAndSendToReclyBin(orgpath + "\\Group" + groupcount.ToString(), false);
                                    for (int j = 1; j <= times; j++)
                                    {
                                        string foldername = SGFunction.FileSystemOperate.FSO_GetFolderName(finddirs[groupcount + temp]);
                                        int fg;
                                        string df = foldername.ToUpper().Replace("GROUP", "");
                                        int.TryParse(df, out fg);
                                        temp = temp + 1;
                                        //DELETE ORG
                                        //MessageBox.Show(orgpath + "\\" + foldername +"\r\n"+orgpath + "\\Group" + (fg - 1).ToString());
                                        SGFunction.FileSystemOperate.FSO_RenameFolder(orgpath + "\\" + foldername, orgpath + "\\Group" + (fg - 1).ToString());
                                    }
                                }
                                else
                                {
                                    //之间删掉
                                    SGFunction.FileSystemOperate.DeleteFileFolderAndSendToReclyBin(orgpath + "\\Group" + groupcount.ToString(), false);
                                }
                            }
                            else
                            {
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到要删除的组。", 2);
                            }
                        }
                        else
                        {
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到要删除的组。", 2);
                        }
                    }
                    else
                    {
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到要删除的组。", 2);
                    }
                }
                public static void SystemStyle_LoadWinXMenu(SGForm_Function_SystemStyle user)
                {
                    try
                    {
                        user.treeView3.Nodes.Clear();
                        string LinkPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX";
                        if (System.IO.Directory.Exists(LinkPath) == true)
                        {
                            string[] GetFolders = SGFunction.FileSystemOperate.FileSystemOperate_GetFolders(LinkPath, SearchOption.TopDirectoryOnly, "*.*");
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
                                string[] Links = SGFunction.FileSystemOperate.FileSystemOperate_GetFiles(LinkPath + @"\" + user.treeView3.Nodes[q - 1].Text, "*.lnk", SearchOption.TopDirectoryOnly);
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
                                    string infoname = SGFunction.SystemFunctionAndInformation.ReadLink(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + user.treeView3.Nodes[q - 1].Text + @"\" + linknamewithoutlocationExt, "info");
                                    //linknamewithoutlocationExt = linknamewithoutlocationExt.Substring(0, linknamewithoutlocationExt.LastIndexOf("."));
                                    /*
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
                                    */
                                    if(linknamewithoutlocationExt.ToLower()=="01a - windows powershell.lnk" || linknamewithoutlocationExt.ToLower()=="01 - command prompt.lnk")
                                    {
                                        if (linknamewithoutlocationExt.ToLower() == "01a - windows powershell.lnk")
                                        {
                                            newlinkname = "Windows PowerShell(管理员)";
                                        }
                                        else { newlinkname = "命令提示符(管理员)"; }
                                    }
                                    else
                                    {
                                        string desktopini = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\Group" + gggg.ToString() + "\\desktop.ini";
                                        string get = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue("LocalizedFileNames", linknamewithoutlocationExt, "", desktopini, false);
                                        if (get == "")
                                        {
                                            //载入lnk备注信息
                                            //载入预设值
                                            newlinkname = GetDefaultName(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\Group" + gggg.ToString() + "\\" + linknamewithoutlocationExt);
                                        }
                                        else
                                        {
                                            newlinkname = SGFunction.MUIOperate.GetMUIString(get);
                                            if (newlinkname == "")
                                            {
                                                newlinkname = GetDefaultName(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\Group" + gggg.ToString() + "\\" + linknamewithoutlocationExt);
                                            }
                                        }
                                    }
                                    if (infoname != "")
                                    {
                                        newlinkname = infoname;
                                    }
                                    /////////////
                                    user.treeView3.Nodes[q - 1].Nodes.Add(newlinkname).Tag = "Group" + gggg.ToString() + "*" + linknamewithoutlocationExt;
                                    user.treeView3.ExpandAll();
                                }
                                gggg = gggg - 1;
                            }
                        }
                    }
                    catch { }
                }
                public static string GetDefaultName(string link)
                {
                    string newlinkname="";
                    string v = SGFunction.FileSystemOperate.FSO_GetFileNameWithoutExt(link);
                    switch (v)
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
                            newlinkname = SGFunction.FileSystemOperate.FSO_GetFileNameWithoutExt(link);
                            string info = SGFunction.SystemFunctionAndInformation.ReadLink(link, "INFO");
                            if (info != "") { newlinkname = info; }
                            break;
                    }
                    return newlinkname;
                }
                //public string Get
            }
            
        }
        public class SystemBoot
        {
            public class StartupItemsMgr
            {
                public class StartItemfromRegistry
                {
                    private static void GetInfo_StartupItem(string[] keys, RegistryKey root, string location, SGListView listview, ImageList icons, string type)
                    {
                        //TAG 格式 REG|ROOTKEY|LOCATION|VALUENAME
                        for (int u = 1; u <= keys.Length; u++)
                        {
                            string read_name = keys[u - 1];
                            string read_exe = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", root, location, read_name, "");
                            if (read_exe != "")
                            {
                                string tag_rootkey = "";
                                //分解为EXE和arg
                                string read_args;
                                string read_1_exe = SGFunction.PathOperate.SplitCommandAndArg(read_exe, out read_args);
                                //读取文件信息
                                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(read_1_exe) == true)
                                {
                                    if (root == Registry.LocalMachine)
                                    {
                                        tag_rootkey = "HKLM";
                                    }
                                    else { tag_rootkey = "HKCU"; }
                                    //文件存在
                                    FileVersionInfo fi = SGFunction.FileSystemOperate.FSO_GetFileDetailInfo_Best(read_1_exe);
                                    ListViewItem it = new ListViewItem();
                                    it.Text = read_name;
                                    it.SubItems.Add(read_exe);
                                    it.SubItems.Add(fi.CompanyName);
                                    it.SubItems.Add(fi.FileDescription);
                                    it.SubItems.Add(type);
                                    it.Tag = "REG," + tag_rootkey + "," + location + "," + read_name;
                                    Image ic = SGFunction.ImageAndIconOperate.GetFileIcon(read_1_exe);
                                    icons.Images.Add(ic);
                                    it.ImageIndex = icons.Images.Count - 1;
                                    listview.Items.Add(it); Application.DoEvents();
                                }
                                else
                                {
                                    //不存在
                                }
                            }

                        }
                    }

                    public static void LoadNormalStartupItems(ImageList icons, SGListView listview)
                    {

                        listview.Items.Clear(); icons.Images.Clear();
                        listview.Columns.Clear();
                        listview.Columns.Add("名称").Width = 127;
                        listview.Columns.Add("启动程序路径").Width = 134;
                        listview.Columns.Add("开发商").Width = 126;
                        listview.Columns.Add("说明").Width = 292;
                        listview.Columns.Add("启动类型").Width = 175;
                        try
                        {
                            //listview.LargeImageList = icons;
                            string reg_alluser_run = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"; //HKLM
                            string reg_alluser_runonce = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Runonce"; //HKLM
                            string reg_currentuser_run = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"; //HKcu
                            string reg_currentuser_runonce = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Runonce"; //HKcu
                            //X64模式
                            //32位程序创建的
                            string reg_alluser_run_x86 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run"; //HKLM
                            string reg_alluser_runonce_x86 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Runonce"; //HKLM
                            string reg_currentuser_run_x86 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run"; //HKcu
                            string reg_currentuser_runonce_x86 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Runonce"; //HKcu

                            //ALL USER RUN
                            string[] allusers_run = SGFunction.RegistryOperate.RegistryOperate_GetKeys(Registry.LocalMachine, reg_alluser_run);
                            string[] allusers_runonce = SGFunction.RegistryOperate.RegistryOperate_GetKeys(Registry.LocalMachine, reg_alluser_runonce);
                            string[] allusers_run_x86 = SGFunction.RegistryOperate.RegistryOperate_GetKeys(Registry.LocalMachine, reg_alluser_run_x86);
                            string[] allusers_runonce_x86 = SGFunction.RegistryOperate.RegistryOperate_GetKeys(Registry.LocalMachine, reg_alluser_runonce_x86);
                            string[] currentuser_run = SGFunction.RegistryOperate.RegistryOperate_GetKeys(Registry.CurrentUser, reg_currentuser_run);
                            string[] currentuser_runonce = SGFunction.RegistryOperate.RegistryOperate_GetKeys(Registry.CurrentUser, reg_currentuser_runonce);
                            string[] currentuser_run_x86 = SGFunction.RegistryOperate.RegistryOperate_GetKeys(Registry.CurrentUser, reg_currentuser_run_x86);
                            string[] currentuser_runonce_x86 = SGFunction.RegistryOperate.RegistryOperate_GetKeys(Registry.CurrentUser, reg_currentuser_runonce_x86);
                            for (int z = 1; z <= 4; z++)
                            {
                                string[] finall_arrs = null; string finall_location = null; string finall_type = "";
                                switch (z)
                                {
                                    case 1: finall_arrs = allusers_run; finall_location = reg_alluser_run; finall_type = "所有用户\\启动时始终运行"; break;
                                    case 2: finall_arrs = allusers_runonce; finall_location = reg_alluser_runonce; finall_type = "所有用户\\下次启动时运行一次"; break;
                                    case 3: finall_arrs = allusers_run_x86; finall_location = reg_alluser_run_x86; finall_type = "所有用户\\启动时始终运行(兼容模式)"; break;
                                    case 4: finall_arrs = allusers_runonce_x86; finall_location = reg_alluser_runonce_x86; finall_type = "所有用户\\下次启动时运行一次(兼容模式)"; break;
                                }
                                GetInfo_StartupItem(finall_arrs, Registry.LocalMachine, finall_location, listview, icons, finall_type);
                            }
                            for (int z = 1; z <= 4; z++)
                            {
                                string[] finall_arrs = null; string finall_location = null; string finall_type = "";
                                switch (z)
                                {
                                    case 1: finall_arrs = currentuser_run; finall_location = reg_currentuser_run; finall_type = "仅当前用户\\启动时始终运行"; break;
                                    case 2: finall_arrs = currentuser_runonce; finall_location = reg_currentuser_runonce; finall_type = "仅当前用户\\下次启动时运行一次"; break;
                                    case 3: finall_arrs = currentuser_run_x86; finall_location = reg_currentuser_run_x86; finall_type = "仅当前用户\\启动时始终运行(兼容模式)"; break;
                                    case 4: finall_arrs = currentuser_runonce_x86; finall_location = reg_currentuser_runonce_x86; finall_type = "仅当前用户\\下次启动时运行一次(兼容模式)"; break;
                                }
                                GetInfo_StartupItem(finall_arrs, Registry.CurrentUser, finall_location, listview, icons, finall_type);
                            }
                        }
                        catch { }
                    }

                }
                public class StartItemsformShortcut
                {
                    private static void GetInfo_ShortcutStartupItems(string[] lnks, string location, SGListView listview, ImageList icons, string type)
                    {
                        //TAG 格式 LNK|LNKFile
                        for (int u = 1; u <= lnks.Length; u++)
                        {
                            string shortcutlnk = lnks[u - 1];
                            //读取文件信息
                            //读取LINK
                            string exepath = ""; string args = ""; exepath = SGFunction.SystemFunctionAndInformation.ReadLink(shortcutlnk, "path"); args = SGFunction.SystemFunctionAndInformation.ReadLink(shortcutlnk, "args");
                            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(shortcutlnk) == true)
                            {
                                string lnkfilename = SGFunction.FileSystemOperate.FSO_GetFileNameWithoutExt(shortcutlnk);
                                //文件存在
                                FileVersionInfo fi = SGFunction.FileSystemOperate.FSO_GetFileDetailInfo_Best(exepath);
                                ListViewItem it = new ListViewItem();
                                it.Text = lnkfilename;
                                it.SubItems.Add(exepath + " " + args);
                                it.SubItems.Add(fi.CompanyName); string des = SGFunction.SystemFunctionAndInformation.ReadLink(shortcutlnk, "info");
                                if (des != "")
                                {
                                    it.SubItems.Add(des);
                                }
                                else
                                {
                                    it.SubItems.Add(fi.FileDescription);
                                }
                                it.SubItems.Add(type);
                                Image ic = SGFunction.ImageAndIconOperate.GetFileIcon(exepath);
                                icons.Images.Add(ic);
                                it.ImageIndex = icons.Images.Count - 1;
                                listview.Items.Add(it);
                                Application.DoEvents();
                            }
                            else
                            {
                                //I DONT KNOW
                            }


                        }
                    }
                    public static void LoadShortcutStartupItems(ImageList icons, SGListView listview)
                    {
                        icons.Images.Clear(); listview.Items.Clear();
                        listview.Columns.Clear();
                        listview.Columns.Add("名称").Width = 127;
                        listview.Columns.Add("启动程序").Width = 134;
                        listview.Columns.Add("开发商").Width = 126;
                        listview.Columns.Add("说明").Width = 292;
                        listview.Columns.Add("启动类型").Width = 175;
                        //LINK STARTUP
                        string reg_currentuser_folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup";
                        string reg_alluser_folder = Environment.GetEnvironmentVariable("programdata") + @"\Microsoft\Windows\Start Menu\Programs\Startup";//注意权限的替换
                        string[] links_current = SGFunction.FileSystemOperate.FileSystemOperate_GetFiles(reg_currentuser_folder, "*.lnk", SearchOption.TopDirectoryOnly);
                        string[] links_alluser = SGFunction.FileSystemOperate.FileSystemOperate_GetFiles(reg_alluser_folder, "*.lnk", SearchOption.TopDirectoryOnly);
                        GetInfo_ShortcutStartupItems(links_alluser, reg_alluser_folder, listview, icons, "所有用户\\启动时始终运行");
                        GetInfo_ShortcutStartupItems(links_current, reg_currentuser_folder, listview, icons, "仅当前用户\\启动时始终运行");
                    }
                }
                public class Startitemsfromservices
                {
                    public static void LoadServicesStartupItems(ImageList icons, SGListView listview)
                    {
                        //TAG TASKSERVICENAME //服务的标示名称而非显示的名称
                        listview.Items.Clear(); icons.Images.Clear();
                        listview.Columns.Clear();
                        listview.Columns.Add("名称").Width = 127;
                        listview.Columns.Add("启动程序路径").Width = 134;
                        listview.Columns.Add("开发商").Width = 126;
                        listview.Columns.Add("说明").Width = 320;
                        icons.Images.Clear(); listview.Items.Clear();
                        //LINK STARTUP
                        ServiceController[] MyServices = ServiceController.GetServices();
                        foreach (ServiceController s in MyServices)
                        {
                            //遍历所有服务
                            ListViewItem it = new ListViewItem();
                            string des = "";
                            string exepathandarg = "";
                            Image exeico;
                            string pub = "";
                            GetServicesInfo(s.ServiceName,out des ,out exepathandarg,out exeico,out pub);
                            it.Text = s.DisplayName;
                            it.SubItems.Add(exepathandarg);
                            it.SubItems.Add(pub);
                            it.SubItems.Add(des);
                            icons.Images.Add(exeico);
                            listview.Items.Add(it);
                            listview.Items[listview.Items.Count - 1].ImageIndex = icons.Images.Count - 1;
                            Application.DoEvents();
                        }

                    }
                    /// <summary>
                    /// 获取系统服务的描述信息
                    /// </summary>
                    /// <param name="servicesname">服务名(不是有好的名称 而是标志名)</param>
                    /// <param name="description">输出描述</param>
                    /// <param name="exepathandcmd">输出程序的执行路径和命令行</param>
                    /// <param name="exeicon">输出程序的图标文件</param>
                    /// <param name="publisher">输出程序的发行商</param>
                    public static void GetServicesInfo(string servicesname,out string description,out string exepathandcmd,out Image exeicon,out string publisher)
                    {
                        //注意mui语言文件
                        string reg=@"SYSTEM\ControlSet001\Services";
                        string des = "";string execmd = "";

                        string rev_exe = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, reg+"\\"+servicesname , "imagepath");
                        string rev_des = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, reg + "\\" + servicesname, "Description");
                        des = rev_des;
                        execmd = rev_exe;
                        if(rev_des.Length >0)
                        {
                            if(rev_des.Substring(0,1)=="@")
                            {
                                //MUI
                                rev_des = SGFunction.MUIOperate.GetMUIString(rev_des, rev_des);
                                des = rev_des;
                            }
                        }
                        //
                        string icofile = "%windir%\\system32\\imageres.dll,11";
                        string pub = "未知";
                        if(rev_exe !="")
                        {
                            string cmd = ""; string exepath=SGFunction.PathOperate.SplitCommandAndArg(rev_exe, out cmd);
                            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(exepath)==true)
                            {
                                icofile = exepath;
                                FileVersionInfo fi = SGFunction.FileSystemOperate.FSO_GetFileDetailInfo_Best(exepath );
                                if (fi != null) 
                                { 
                                    pub = fi.CompanyName;
                                    //如果没哟DES 就是用EXE的DES
                                    if(des=="")
                                    {
                                        des = fi.FileDescription;
                                    }
                                }

                            }
                        }
                        publisher = pub;
                        exeicon = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(icofile, "%windir%\\system32\\imageres.dll,11");
                        description = des;
                        exepathandcmd = execmd;
                    }
                }
                public class StartItemsfromtasks
                {
                    public static void Load(ImageList icons, SGListView listview)
                    {
                        // TAG TASKNAME
                        icons.Images.Clear(); listview.Items.Clear();
                        listview.Columns.Clear();
                        listview.Columns.Add("名称").Width = 127;
                        listview.Columns.Add("启动程序").Width = 134;
                        listview.Columns.Add("创建者").Width = 126;
                        listview.Columns.Add("说明").Width = 292;
                        listview.Columns.Add("启动触发条件").Width = 175;
                        List<SGFunction.TaskSchedulerMgr.Taskinfo> tasks = new List<SGFunction.TaskSchedulerMgr.Taskinfo>();
                        tasks = SGFunction.TaskSchedulerMgr.GetTaskInfo();
                        //TAG 格式 TSK|
                        for (int u = 1; u <= tasks.Count; u++)
                        {

                            //读取文件信息
                            string task_current_creater = tasks[u - 1].Auth;
                            string task_current_des = tasks[u - 1].Description;
                            string task_current_exetype = tasks[u - 1].ExecutionType;
                            string task_current_path = tasks[u - 1].Path;
                            string task_current_taskname = tasks[u - 1].TaskName;
                            string task_current_state = tasks[u - 1].Status;
                            string task_current_tigger = tasks[u - 1].Tigger;
                            if (task_current_exetype.ToUpper() == Microsoft.Win32.TaskScheduler.TaskActionType.Execute.ToString().ToUpper())
                            {

                                //EXE
                                string exepath = ""; string exearg = "";
                                exepath = SGFunction.PathOperate.SplitCommandAndArg(task_current_path, out exearg);
                                exepath = SGFunction.PathOperate.IMPORTANT_PathUseful(exepath);
                                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(exepath) == true)
                                {
                                    //文件存在
                                    FileVersionInfo fi = SGFunction.FileSystemOperate.FSO_GetFileDetailInfo_Best(exepath);
                                    ListViewItem it = new ListViewItem();
                                    it.Text = task_current_taskname;
                                    it.SubItems.Add(task_current_path);
                                    if (task_current_creater == null) { it.SubItems.Add(fi.CompanyName); } else { it.SubItems.Add(task_current_creater); }
                                    if (task_current_des ==null) { it.SubItems.Add(fi.FileDescription); } else { it.SubItems.Add(task_current_des); }
                                    it.SubItems.Add(task_current_tigger);
                                    //it.Tag = task_current_taskname;
                                    Image ic = SGFunction.ImageAndIconOperate.GetFileIcon(exepath);
                                    icons.Images.Add(ic);
                                    it.ImageIndex = icons.Images.Count - 1;
                                    listview.Items.Add(it);
                                }
                                
                            }


                            Application.DoEvents();
                        }
                    }
                }
            }
            public class VHDMgr
            {
                /// <summary>
                /// 创建虚拟磁盘
                /// </summary>
                /// <param name="file">文件名</param>
                /// <param name="sizetype">磁盘大小模式 [fixed]固定格式 [expandable]动态扩展</param>
                /// <param name="sizemb">大小 MB</param>
                /// <param name="afterload">创建后是否加载到系统</param>
                /// <param name="loadletter">加载的盘符</param>
                public static void CreateNewVHD(string file, string sizetype, int sizemb, bool afterload, string loadletter = "")
                {
                    int VD_Size;
                    string VD_File = file;
                    string VD_Letter = loadletter;
                    VD_Size = sizemb;
                    if (System.IO.File.Exists(VD_File) == true)
                    {
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法创建：因为创建的位置已存在一个现有的虚拟磁盘文件。", 2);
                        //MyFunctions.Dialogs.MessageDialog("虚拟磁盘文件已存在", "无法创建虚拟磁盘文件,因为文件已存在", MyFunctions.Dialogs.MessageDialogIcon.Exclamatory , @"已存在的文件""" + VD_File + @"""", "b2", false, true, "", "确定");
                    }
                    else
                    {
                        string prog = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("PROGRAMS") + "\\sgvdmgr.exe";
                        string cmd_sta = @"/OC /"""+VD_File +@""" /"+VD_Size.ToString()+@" /"+sizetype;
                        string cmd_sl = @"/CL /""" + VD_File + @""" /" + VD_Size.ToString() + @" /" + sizetype+@" /"+loadletter;
                        //MyFunctions.Dialogs.MessageDialog("即将开始", "即将开始创建虚拟磁盘,这个过程可能需要花费几分钟甚至更多", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "开始");
                        //string temptxt = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\CreateVdisk.txt";
                        //SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(temptxt);
                        //string writetxt = @"create vdisk file=""" + VD_File + @""" maximum=" + VD_Size.ToString() + " type=" + sizetype;
                        //writetxt = writetxt + "\r\n" + @"select vdisk file=""" + VD_File + @"""";
                        //writetxt = writetxt + "\r\n" + @"attach vdisk";
                        //writetxt = writetxt + "\r\n" + "create partition primary";
                        //writetxt = writetxt + "\r\n" + @"format fs=ntfs quick label=""我的虚拟磁盘""";
                        if(afterload ==true && loadletter !="")
                        {
                            //writetxt = writetxt + "\r\n" + "assign letter=" + VD_Letter.Replace(":","");
                            SGFunction.SystemFunctionAndInformation.ShellPrograms(prog, cmd_sl, true, false, true, true);
                        }
                        else
                        {
                            SGFunction.SystemFunctionAndInformation.ShellPrograms(prog, cmd_sta, true, false, true, true);
                        }
                        //SGFunction.DataOperate.SaveStringToTextFile(temptxt, writetxt);
                        //SGFunction.SystemFunctionAndInformation.ShellPrograms("diskpart.exe", @"/s """ + temptxt + @"""", true, false, true, true,Environment.GetFolderPath(Environment.SpecialFolder.System));
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功创建了虚拟磁盘文件。程序正在后台为您创建虚拟磁盘...", 2);
                    }
                }
                /// <summary>
                /// 卸载虚拟磁盘
                /// </summary>
                /// <param name="file">文件</param>
                public static void UninstallVHD(string file)
                {
                    string VD_File = file;
                    if (System.IO.File.Exists(VD_File) == false)
                    {
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法卸载虚拟磁盘：因为没有找到虚拟磁盘文件。", 2);
                        //MyFunctions.Dialogs.MessageDialog("虚拟磁盘文件已存在", "无法创建虚拟磁盘文件,因为文件已存在", MyFunctions.Dialogs.MessageDialogIcon.Exclamatory , @"已存在的文件""" + VD_File + @"""", "b2", false, true, "", "确定");
                    }
                    else
                    {
                        string prog = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("PROGRAMS") + "\\sgvdmgr.exe";
                        string cmd_sta = @"/UL /""" + VD_File + @"""";
                        //MyFunctions.Dialogs.MessageDialog("即将开始", "即将开始创建虚拟磁盘,这个过程可能需要花费几分钟甚至更多", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "开始");
                        //string temptxt = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\CreateVdisk.txt";
                        //SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(temptxt);
                        //string writetxt = @"create vdisk file=""" + VD_File + @""" maximum=" + VD_Size.ToString() + " type=" + sizetype;
                        //writetxt = writetxt + "\r\n" + @"select vdisk file=""" + VD_File + @"""";
                        //writetxt = writetxt + "\r\n" + @"attach vdisk";
                        //writetxt = writetxt + "\r\n" + "create partition primary";
                        //writetxt = writetxt + "\r\n" + @"format fs=ntfs quick label=""我的虚拟磁盘""";
                        //writetxt = writetxt + "\r\n" + "assign letter=" + VD_Letter.Replace(":","");
                        SGFunction.SystemFunctionAndInformation.ShellPrograms(prog, cmd_sta, true, false, true, true);
                        //SGFunction.DataOperate.SaveStringToTextFile(temptxt, writetxt);
                        //SGFunction.SystemFunctionAndInformation.ShellPrograms("diskpart.exe", @"/s """ + temptxt + @"""", true, false, true, true,Environment.GetFolderPath(Environment.SpecialFolder.System));
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功卸载了虚拟磁盘文件。程序正在后台为您卸载虚拟磁盘...", 2);
                    }
                }
                /// <summary>
                /// 加载虚拟磁盘
                /// </summary>
                /// <param name="file">文件</param>
                public static void InstallVHD(string file)
                {
                    string VD_File = file;
                    if (System.IO.File.Exists(VD_File) == false)
                    {
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法卸载虚拟磁盘：因为没有找到虚拟磁盘文件。", 2);
                        //MyFunctions.Dialogs.MessageDialog("虚拟磁盘文件已存在", "无法创建虚拟磁盘文件,因为文件已存在", MyFunctions.Dialogs.MessageDialogIcon.Exclamatory , @"已存在的文件""" + VD_File + @"""", "b2", false, true, "", "确定");
                    }
                    else
                    {
                        string pf = "Z";
                        //随机获取盘符
                        //获取空的盘符
                        string[] lets = SGFunction.FileSystemOperate.FSO_GetEmptyLetter(":\\");
                        if (lets.Length > 0) { pf = lets[lets.Length - 1]; }
                        string prog = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("PROGRAMS") + "\\sgvdmgr.exe";
                        string cmd_sta = @"/LL /""" + VD_File + @""" /"+pf;
                        //MyFunctions.Dialogs.MessageDialog("即将开始", "即将开始创建虚拟磁盘,这个过程可能需要花费几分钟甚至更多", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "开始");
                        //string temptxt = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\CreateVdisk.txt";
                        //SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(temptxt);
                        //string writetxt = @"create vdisk file=""" + VD_File + @""" maximum=" + VD_Size.ToString() + " type=" + sizetype;
                        //writetxt = writetxt + "\r\n" + @"select vdisk file=""" + VD_File + @"""";
                        //writetxt = writetxt + "\r\n" + @"attach vdisk";
                        //writetxt = writetxt + "\r\n" + "create partition primary";
                        //writetxt = writetxt + "\r\n" + @"format fs=ntfs quick label=""我的虚拟磁盘""";
                        //writetxt = writetxt + "\r\n" + "assign letter=" + VD_Letter.Replace(":","");
                        SGFunction.SystemFunctionAndInformation.ShellPrograms(prog, cmd_sta, true, false, true, true);
                        //SGFunction.DataOperate.SaveStringToTextFile(temptxt, writetxt);
                        //SGFunction.SystemFunctionAndInformation.ShellPrograms("diskpart.exe", @"/s """ + temptxt + @"""", true, false, true, true,Environment.GetFolderPath(Environment.SpecialFolder.System));
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功挂载了虚拟磁盘文件。程序正在后台为您挂载虚拟磁盘...", 2);
                    }
                }
            }
            public class LockScreenImage
            {
                public static void LoadLockScreenImage(SGForm_Function_SystemStyle s)
                {
                    try
                    {
                        string res = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll";
                        //string res = @"F:\迅雷下载\imageres\imageres.dll";
                        string read = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Background", "OEMBackground", "none");
                        if (read == "1")
                        {
                            string imagefile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\oobe\info\backgrounds\backgroundDefault.jpg";
                            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(imagefile )==true)
                            {
                                s.pictureBox15.Image = Image.FromFile(imagefile);
                            }
                            else
                            {
                                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(res) == true) 
                                {
                                    Image bmpres = SGFunction.ImageAndIconOperate.LoadResources_GetBitmap(res, 5033, "image");
                                    s.pictureBox15.Image = bmpres;
                                } else { s.pictureBox15.Image = null; }
                            }
                        }
                        else
                        {
                            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(res) == true)
                            {
                                Image bmpres = SGFunction.ImageAndIconOperate.LoadResources_GetBitmap(res, 5033, "image");
                                s.pictureBox15.Image = bmpres;
                            }
                            else { s.pictureBox15.Image = null; }
                        }
                    }
                    catch { }
                }
                public static void ApplyLockScreenImage(SGForm_Function_SystemStyle s, Image img)
                {
                    string tagimage = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\oobe\info\backgrounds\backgroundDefault.jpg";
                    string tagfolder = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\oobe\info\backgrounds";
                    try
                    {
                        SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(tagfolder);
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(tagimage);
                        string tempimg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\Temp_LockScreenImage.jpg";
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(tempimg);
                        Size fenbianl = SGFunction.SystemFunctionAndInformation.GetSrceenFenBianLv();
                        SGFunction.ImageAndIconOperate.SaveImageAsFile(img, System.Drawing.Imaging.ImageFormat.Jpeg, fenbianl.Width, fenbianl.Height, tempimg);
                        if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(tempimg )==true)
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(tempimg, tagimage, true);
                            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(tagimage)==true)
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(tempimg);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Background", "OEMBackground", "1", RegistryValueKind.DWord);
                                SGFunction.SystemFunctionAndInformation.LockComputer(false);
                                //SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们无法设置这张图片作为锁屏界面的图片。我们会尽快解决这个问题。", 2);
                            }
                            else
                            {
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们无法设置这张图片作为锁屏界面的图片。我们会尽快解决这个问题。", 2);
                            }
                        }
                        else
                        {
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们无法设置这张图片作为锁屏界面的图片。我们会尽快解决这个问题。", 2);
                        }
                    }
                    catch { }
                }
                public static void ReConfigLockScreenImage(SGForm_Function_SystemStyle s)
                {
                    string tagfolder = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\oobe\info\backgrounds";
                    try
                    {
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFolder(tagfolder, true);
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Background", "OEMBackground", "0", RegistryValueKind.DWord);
                        //SGFunction.SystemFunctionAndInformation.LockComputer(false);
                        LoadLockScreenImage(s);
                        //SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们无法设置这张图片作为锁屏界面的图片。我们会尽快解决这个问题。", 2);
                    }
                    catch { }
                }

                /// <summary>
                /// 设置锁屏界面
                /// </summary>
                /// <param name="imgfile">图片文件 [wallpaper]使用桌面壁纸</param>
                /// <param name="locklog">是否完成后锁屏</param>
                /// <param name="showsuccess">显示成功消息</param>
                public static void ApplyLockScreenImage_FromImageFile(string imgfile,bool locklog=true,bool showsuccess=true)
                {
                    string tagimage = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\oobe\info\backgrounds\backgroundDefault.jpg";
                    string tagfolder = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\oobe\info\backgrounds";
                    try
                    {
                        SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(tagfolder);
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(tagimage);
                        string tempimg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\Temp_LockScreenImage_Command.jpg";
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(tempimg);
                        Size fenbianl = SGFunction.SystemFunctionAndInformation.GetSrceenFenBianLv();
                        Image img = null;
                        string inftext = "您选择的图片文件";
                        if (imgfile.ToUpper() == "WALLPAPER")
                        { 
                            img = SGFunction.SystemFunctionAndInformation.GetWallpaper();
                            inftext = "桌面壁纸";
                        }
                        else
                        {
                            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(imgfile) == true) { img = Image.FromFile(imgfile); } else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们找不到您选择的图片文件。", 2); return; }
                        }
                        if (img == null) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们无法设置" + inftext + "为锁屏界面的图片。我们会尽快解决这个问题。", 2); return; }
                        SGFunction.ImageAndIconOperate.SaveImageAsFile(img, System.Drawing.Imaging.ImageFormat.Jpeg, fenbianl.Width, fenbianl.Height, tempimg);
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(tempimg) == true)
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(tempimg, tagimage, true);
                            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(tagimage) == true)
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(tempimg);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Background", "OEMBackground", "1", RegistryValueKind.DWord);
                                if (locklog == true) { SGFunction.SystemFunctionAndInformation.LockComputer(false); }
                                if (showsuccess == true) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("设置成功，我们成功设置" + inftext + "为锁屏界面的图片。", 3); }
                            }
                            else
                            {
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们无法设置"+inftext+"为锁屏界面的图片。我们会尽快解决这个问题。", 2);
                            }
                        }
                        else
                        {
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们无法设置" + inftext + "为锁屏界面的图片。我们会尽快解决这个问题。", 2);
                        }
                    }
                    catch { }
                }
                public static void RegRightMenu(bool ope)
                {
                    try
                    {
                        string keyname = "settolockimage";
                        string dispalyname = "设置为锁屏界面图片";
                        string ico = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("images") + "\\FunctionLogo\\lock.ico,0";
                        string exe = Application.ExecutablePath;
                        string cmd = @"/Y=""LOCKSCREEN"" /FROM=""%1""";
                        string[] exts = new string[] { ".jpg",".gif",".png",".bmp"};
                        for(int j=1;j<=exts.Length;j++)
                        {
                            string rkey = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, exts[j - 1], "", "");
                            if (rkey == "") { break; }
                            if (ope == true)
                            {
                                if (Registry.ClassesRoot.OpenSubKey(rkey +"\\shell") == null) { SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, rkey, "shell"); } else { SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, rkey+"\\shell", keyname); }
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, rkey + "\\shell\\" + keyname, "command");
                                //写入值
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, rkey + "\\shell\\" + keyname, "", dispalyname);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, rkey + "\\shell\\" + keyname, "icon", ico);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, rkey + "\\shell\\" + keyname + "\\command", "", exe + " " + cmd);
                            }
                            else
                            {
                                SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, rkey + "\\shell\\", keyname);
                            }
                        }
                        if (ope == true) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功关联到右键菜单", 2); } else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功取消关联右键菜单", 2); }
                    }
                    catch { }
                }
                public static bool GetRightMenuState()
                {
                    try
                    {
                        try
                        {
                            string keyname = "settolockimage";
                            string[] exts = new string[] { ".jpg", ".gif", ".png", ".bmp" };
                            bool hasone = false;
                            for (int j = 1; j <= exts.Length; j++)
                            {
                                string rkey = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, exts[j - 1], "", "");
                                if (rkey != "")
                                {
                                    RegistryKey ky = Registry.ClassesRoot.OpenSubKey(rkey + "\\SHELL\\" + keyname);
                                    if (ky != null) { hasone = true; break; }
                                }
                            }
                            return hasone;
                        }
                        catch { return false; }
                    }
                    catch { return false; }
                }
                public static void RegDesktopLink()
                {
                    try
                    {
                        string dispalyname = "一键设置桌面壁纸为锁屏图片";
                        string infotip = "您可以在桌面上一键使用当前桌面壁纸作为您的锁屏图片";
                        string lnk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\"+dispalyname +".lnk";
                        string ico = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("images") + "\\FunctionLogo\\lock.ico,0";
                        string exe = Application.ExecutablePath;
                        string cmd = @"/Y=""LOCKSCREEN"" /FROM=""WALLPAPER""";
                        SGFunction.SystemFunctionAndInformation.CreateLink(lnk, exe, cmd, infotip, ico);
                    }
                    catch { }
                }
            }
            public class BootAudio
            {
                public static void PlayWav(string wavfile,bool playstart,bool playoff)
                {
                    try
                    {
                        string poweroff = Environment.GetEnvironmentVariable("WINDIR") + @"\Media\Windows Shutdown.wav";
                        string res = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll";
                        //res = @"F:\迅雷下载\imageres\imageres.dll";
                        if(playstart ==true)
                        {
                            SGFunction.AudioOperate.PlaySound_InResources(res,5080,"WAVE");
                        }
                        else
                        {
                            if(playoff ==true)
                            {
                                SGFunction.AudioOperate.PlaySound(poweroff);
                            }
                            else
                            {
                                //播放文件
                                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(wavfile) == true)
                                {
                                    SGFunction.AudioOperate.PlaySound(wavfile);
                                }
                                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("呀，文件没有找到。", 2); }
                            }
                        }
                    }
                    catch { }
                }
                public static void ApplyStartAudio(string f)
                {
                    string bakfolder = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    string bakaud = bakfolder + "\\Imageres.dll.bakfile";
                    string tempfile = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\imagerestemp.dll";
                    try
                    {
                        //清理环境
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(bakfolder + "\\imageres.dll.old");
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(tempfile);
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakfolder + "\\imageres.dll.old") == false)
                        {
                            //接触文件的权限
                            SGFunction.FileSystemOperate.FileSystemOperate_GetAdminWithFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll");
                            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakaud) == false)
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", bakaud, true);
                            }
                            //复制临时文件
                            SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll", tempfile, true);
                            //替换资源
                            SGFunction.Resources.UpdateResources(f, tempfile, 1033, "WAVE", 5080);
                            //结束EXPLORER
                            //SGFunction.SystemFunctionAndInformation.CloseProcess("explorer.exe");
                            //修改为OLD
                            SGFunction.FileSystemOperate.FSO_RenameFile(bakfolder + "\\imageres.dll", bakfolder + "\\imageres.dll.old");
                            //复制文件cmd
                            string arg = @"/c copy """ + tempfile + @""" ""%windir%\system32\imageres.dll"" /y";
                            SGFunction.SystemFunctionAndInformation.ShellPrograms("CMD.EXE", arg, true, false, true, true);
                            //启动Explorer
                            SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(bakfolder + "\\imageres.dll.old");
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(tempfile);
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功更改了开机的音乐文件", 2);
                        }
                        else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("我们无法修改开机的音乐文件，因为系统文件正在使用。我们会尽快的解决此类问题，谢谢。", 2); }
                        
                    }
                    catch { }
                }
                public static void ApplyPowerOffAudio(string f)
                {
                    string poweroff = Environment.GetEnvironmentVariable("WINDIR") + @"\Media\Windows Shutdown.wav";
                    string bakfolder = Environment.GetEnvironmentVariable("WINDIR") + @"\Media";
                    string bakaud = bakfolder + "\\Windows Shutdown.wav.bakfile";
                    try
                    {
                        //清理环境
                        //接触文件的权限
                        SGFunction.FileSystemOperate.FileSystemOperate_GetAdminWithFile(poweroff);
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakaud) == false)
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(poweroff, bakaud, true);
                        }
                        //替换资源
                        SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(f, poweroff, true);
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功更改了关机的音乐文件", 2);

                    }
                    catch { }
                }
                public static void ReConfigPowerOffAudio()
                {
                    string bakfolder = Environment.GetEnvironmentVariable("WINDIR") + @"\Media";
                    string bakaud = bakfolder + "\\Windows Shutdown.wav.bakfile";
                    string orgfile = bakfolder + "\\Windows Shutdown.wav";
                    try
                    {
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakaud) == true)
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(bakaud, orgfile);
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原了关机的音乐文件", 2);
                        }
                        else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("呵呵，没有找到您备份的文件。您也许并没有设置关机的音乐。", 2); }
                    }
                    catch { }
                }
                public static void ReConfigStartAudio()
                {
                    string bakfolder = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    string bakaud = bakfolder + "\\Imageres.dll.bakfile";
                    string orgfile = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\imageres.dll";
                    try
                    {
                        //清理环境
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(bakfolder + "\\imageres.dll.old");
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakfolder + "\\imageres.dll.old") == false)
                        {
                            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakaud )==true)
                            {
                                //重命名使用的文件
                                SGFunction.FileSystemOperate.FSO_RenameFile(bakfolder + "\\imageres.dll", bakfolder + "\\imageres.dll.old");
                                string arg = @"/c copy """ + bakaud + @""" ""%windir%\system32\imageres.dll"" /y";
                                SGFunction.SystemFunctionAndInformation.ShellPrograms("CMD.EXE", arg, true, false, true, true);
                                SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(bakfolder + "\\imageres.dll.old");
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原了开机的音乐文件", 2);
                            }
                            else
                            {
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("我们无法还原开机的音乐文件，因为无法找到您备份的文件。", 2);
                            }
                        }
                        else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("我们无法还原开机的音乐文件，因为系统文件正在使用。我们会尽快的解决此类问题，谢谢。", 2); }

                    }
                    catch { }
                }
            }
            public class BootMenusMgr
            {
                public static void SystemStyle_LoadBCD(SGForm_Function_SystemStyle  user)
                {
                    try
                    {
                        string[] opecode;
                        bool res=SGFunction.BCDOperate.BCDOperate_CreateBCDTempFile();
                        if (res == true)
                        {
                            string[] bootname = SGFunction.BCDOperate.BCDOperate_GetBootMenu_Name();
                            string[] bootlocation = SGFunction.BCDOperate.BCDOperate_GetBootMenu_GetBootLocation(out opecode);
                            string[] boottype = SGFunction.BCDOperate.BCDOperate_GetBootMenu_GetBootType();
                            string[] bootguid = SGFunction.BCDOperate.BCDOperate_GetBootMenu_GUID();
                            int defaultmenu = SGFunction.BCDOperate.BCDOperate_GetBootMenu_GetDefaultBootMenu();
                            string timeout = SGFunction.BCDOperate.BCDOperate_GetBootMenu_TimeOut();
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
                            user.sgTextBox4.Text = timeout;
                            if (bootname != null && bootlocation != null && boottype != null && bootguid != null)
                            {
                                user.sgListView1.Items.Clear();
                                //MessageBox.Show(bootname.Length.ToString());
                                for (int h = 1; h <= bootname.Length; h++)
                                {
                                    string name = bootname[h - 1];
                                    string path = bootlocation[h - 1];
                                    string type = boottype[h - 1];
                                    string clsid = bootguid[h - 1];
                                    string defau = def[h - 1];
                                    string opecode_ram = opecode[h - 1];
                                    user.sgListView1.Items.Add(defau).Tag = new string[] { clsid, name, type, path, defau, opecode_ram };
                                    user.sgListView1.Items[h - 1].SubItems.Add(name);
                                    user.sgListView1.Items[h - 1].SubItems.Add(path);
                                    user.sgListView1.Items[h - 1].SubItems.Add(type);
                                    user.sgListView1.Items[h - 1].SubItems.Add(clsid);
                                }
                            }
                        }
                        else { user.sgListView1.Items.Clear(); SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，无法读取您的启动菜单。", 2); }
                    }
                    catch {  user.sgListView1.Items.Clear(); }
                }
                /// <summary>
                /// 查找硬盘中脱机的Windows
                /// </summary>
                /// <param name="installdisks">已经被检测到的Windows安装盘 [F:\]</param>
                /// <param name="findostype">输出的脱机Windows 版本 [NT5.2|NT5.1] 多个类型用|隔开</param>
                /// <returns></returns>
                public static List<string> FindBootMenu_OS(string[] installdisks,out List<string> findostype,out List<string> osbit)
                {
                    List<string> ret_disk = new List<string>();
                    List<string> ret_type = new List<string>();
                    List<string> ret_osbit = new List<string>();
                    try
                    {
                        string[] files_nt = new string[] { "windows", "Program Files", "windows\\system32" }; //WIN NT 应该有的
                        string[] files_x64 = new string[] { "windows\\syswow64", "Program Files (x86)" }; //WIN 64要有的
                        string[] parts = SGFunction.FileSystemOperate.FSO_GetLocalDiskDrives(DriveType.Fixed);
                        //string currentdisk = System.Environment.GetEnvironmentVariable("systemdrive") + "\\";
                        for (int o = 1; o <= parts.Length; o++)
                        {
                            string retdisk = "", rettype = ""; string osbitr = "32";
                            //检查空的盘符
                            bool isnt = SGFunction.FileSystemOperate.FSO_FindDirsExistsInDir(parts[o - 1], files_nt);
                            bool isnt64 = SGFunction.FileSystemOperate.FSO_FindDirsExistsInDir(parts[o - 1], files_x64);
                            if (isnt64 == true) { osbitr = "64"; }

                            if (isnt == true)
                            {
                                //这是个NT系统
                                string explorerversion = SGFunction.FileSystemOperate.FSO_GetFileDetailInfo_Best(parts[o - 1] + "windows\\explorer.exe").ProductVersion;
                                string[] vers = explorerversion.Split('.');
                                if (vers.Length == 4)
                                {
                                        rettype = "NT" + vers[0] + "." + vers[1];
                                        retdisk = parts[o - 1];
                                    
                                }
                                else
                                {
                                    //no
                                    retdisk = "";
                                }
                                //可以更新ret了
                                if (retdisk != "")
                                {
                                    ret_disk.Add(retdisk);
                                    ret_type.Add(rettype);
                                    ret_osbit.Add(osbitr);
                                }
                            }
                        }
                        osbit = ret_osbit; findostype = ret_type; return ret_disk;
                    }
                    catch { osbit =ret_osbit; findostype = ret_type; return ret_disk; }
                }
                /// <summary>
                /// 查找磁盘根目录下的WINDOWS 安装文件
                /// </summary>
                /// <param name="setupversion">返回的SETUP版本 [6.0]VISTA 安装盘 [6.1] WIN7 [6.2]WIN8 [6.3]WIN8.1</param>
                /// <returns></returns>
                public static List<string> FindBootMenu_OSSETUP_INDISK(out List<string> setupversion)
                {
                    List<string> ret_disk = new List<string>();
                    List<string> ret_ver = new List<string>();
                    try
                    {
                        string[] install_dirs = new string[] { "boot","efi","sources","support" };
                        string[] install_files = new string[] { "boot\\boot.sdi", "boot\\bcd", "sources\\install.wim", "sources\\boot.wim" ,"sources\\setup.exe"};
                        string[] parts = SGFunction.FileSystemOperate.FSO_GetLocalDiskDrives(DriveType.Fixed);
                        //读取盘符
                        for (int o = 1; o <= parts.Length; o++)
                        {
                            //安装文件是否完整
                            bool compelete_dirs = SGFunction.FileSystemOperate.FSO_FindDirsExistsInDir(parts[o - 1], install_dirs);
                            if(compelete_dirs ==true)
                            {
                                bool compelete_files = SGFunction.FileSystemOperate.FSO_FindFileExistsInDir(parts[o - 1], install_files);
                                if(compelete_files ==true)
                                {
                                    string exe = parts[o - 1] + "sources\\setup.exe";
                                    string ver = "";
                                    string[] vv = SGFunction.FileSystemOperate.FSO_GetEXEFileVersionInfo(exe).Split('.');
                                    if(vv.Length ==4)
                                    {
                                        ver = vv[0]+"."+vv[1];
                                    }
                                    ret_disk.Add(parts[o - 1]);
                                    ret_ver.Add(ver);
                                }
                            }
                        }
                        setupversion = ret_ver;
                        return ret_disk;
                    }
                    catch { setupversion = ret_ver; return ret_disk; }
                }
                /// <summary>
                /// 查找DVD/CD驱动器根目录下的WINDOWS 安装文件
                /// </summary>
                /// <param name="setupversion">返回的SETUP版本 [6.0]VISTA 安装盘 [6.1] WIN7 [6.2]WIN8 [6.3]WIN8.1</param>
                /// <returns></returns>
                public static List<string> FindBootMenu_OSSETUP_DVDDRIVE(out List<string> setupversion)
                {
                    List<string> ret_disk = new List<string>();
                    List<string> ret_ver = new List<string>();
                    try
                    {
                        string[] install_dirs = new string[] { "boot", "efi", "sources", "support" };
                        string[] install_files = new string[] { "boot\\boot.sdi", "boot\\bcd", "sources\\install.wim", "sources\\boot.wim", "sources\\setup.exe" };
                        string[] parts = SGFunction.FileSystemOperate.FSO_GetLocalDiskDrives(DriveType.CDRom);
                        //读取盘符
                        for (int o = 1; o <= parts.Length; o++)
                        {
                            //安装文件是否完整
                            bool compelete_dirs = SGFunction.FileSystemOperate.FSO_FindDirsExistsInDir(parts[o - 1], install_dirs);
                            if (compelete_dirs == true)
                            {
                                bool compelete_files = SGFunction.FileSystemOperate.FSO_FindFileExistsInDir(parts[o - 1], install_files);
                                if (compelete_files == true)
                                {
                                    string exe = parts[o - 1] + "sources\\setup.exe";
                                    string ver = "";
                                    string[] vv = SGFunction.FileSystemOperate.FSO_GetEXEFileVersionInfo(exe).Split('.');
                                    if (vv.Length == 4)
                                    {
                                        ver = vv[0] + "." + vv[1];
                                    }
                                    ret_disk.Add(parts[o - 1]);
                                    ret_ver.Add(ver);
                                }
                            }
                        }
                        setupversion = ret_ver;
                        return ret_disk;
                    }
                    catch { setupversion = ret_ver; return ret_disk; }
                }
                public static void ExportBCD()
                {
                    string bak = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\BootMenusMgr\\BCDBackup.bak";
                    string dir = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\BootMenusMgr";
                    SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(dir);
                    if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bak)==false)
                    {
                        SGFunction.BCDOperate.ExpoertBCDToFile(bak);
                    }
                    else
                    {
                        string res = SGFunction.CommonDialogs.MessageDialog_MustClick("找到一个旧的文件", "我们在备份的位置找到了旧的备份的文件，是否要替换它？", "是", "否", "b1", "ques");
                        if(res =="b1")
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(bak);
                            SGFunction.BCDOperate.ExpoertBCDToFile(bak);
                        }
                    }
                }
                public static void ImportBCD(SGForm_Function_SystemStyle s)
                {
                    string bak = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\BootMenusMgr\\BCDBackup.bak";
                    string dir = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\BootMenusMgr";
                    SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(dir);
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bak) == false)
                    {
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，没有找到备份的启动菜单的备份文件。无法还原设置。", 2);
                    }
                    else
                    {
                        string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定需要还原？", "还原设置文件可以替换正确的设置，但您之后所做的更改将会丢失。是否继续？", "是", "否", "b1", "ques");
                        if (res == "b1")
                        {
                            SGFunction.BCDOperate.ImporttBCDToFile(bak);
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFolder(dir,true);
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原您的启动菜单设置。", 2);
                            SGSystemStyle.SystemBoot.BootMenusMgr.SystemStyle_LoadBCD(s);
                        }
                    }
                }
            }
        }
        public class FileMgr
        {
            public class FolderMgr
            {
                public static string _TEMP_CONFIGFILE = "";
                public static string _SYS_ICO = "";
                public static bool _HASDESKTOPINI = false; //是否有默认的配置文件
                public static string _ORGDESKTOPINI = ""; //自带的DESKTOP.INI
                public static string _ORG_FOLDERNAME = "";
                public static void LoadFolder(string folder, SGForm_Function_SystemStyle f)
                {
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(folder, false) == true)
                    {
                        f.sgTextBox_foldertip.Text = f.sgTextBox_foldername.Text = "";
                        f.pictureBox_folderlogo.Image = null;
                        f.sgTextBox_foldername.Tag = "ISLOAD";
                        f.sgTextBox_foldertip.Tag = "ISLOAD";
                        f.pictureBox_folderlogo.Tag = null;
                        f.panel_filemgr_controls.Visible = true;
                        f.sgTextBox_fm_displayname.Tag = "ISLOAD";
                        f.sgCombobox_fm_icons.SelectedIndex = -1;
                        f.sgTextBox_fm_displayname.Text = f.sgTextBox_fm_filename.Text = "";
                        //初始化变量
                        _HASDESKTOPINI = false;
                        _SYS_ICO = ""; _TEMP_CONFIGFILE = ""; _ORGDESKTOPINI = ""; _ORG_FOLDERNAME = "";
                        //加载LISTVIEW
                        SGFunction.FileSystemOperate.FileSystemOperate_GetFilesAndFoldersToListView(folder, f.imageList_filemge_foldermgr, f.sgListView2);
                        //创建临时的配置文件
                        _TEMP_CONFIGFILE = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\desktop.ini.tmp";
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(_TEMP_CONFIGFILE);
                        //读取是否有DESKTOP.INI
                        string dekini = folder + "\\desktop.ini";
                        //先加系统默认
                        //没有图标 系统自带的
                        _ORGDESKTOPINI = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\org_desktop.ini.tmp";
                        SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(dekini, _ORGDESKTOPINI, true);
                        //后看看有无文件
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(dekini) == true)
                        {
                            _HASDESKTOPINI = true;
                            string ico = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "iconfile", "no", dekini, true);
                            string index = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "iconindex", "0", dekini, false);
                            string lores = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "IconResource", "no", dekini, true);
                            int ind;
                            string lores_img = SGFunction.ImageAndIconOperate.GetStrToImageLocationAndIndex(lores, out ind);
                            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(lores_img) == true)
                            {
                                //优先RES
                                f.pictureBox_folderlogo.Tag = new string[] { "SYS", lores };
                                _SYS_ICO = lores;
                                f.pictureBox_folderlogo.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(lores);
                                f.sgCombobox_fm_icons.SelectedIndex = 0;
                            }
                            else
                            {
                                string ico_fullpath = folder + "\\" + ico;
                                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(ico_fullpath) == true)
                                {
                                    //有图标 那就加载 但这是系统默认 应用时不用修改
                                    _SYS_ICO =ico_fullpath  + "," + index;
                                    f.pictureBox_folderlogo.Tag = new string[] { "SYS", ico_fullpath + "," + index };
                                    f.pictureBox_folderlogo.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico_fullpath+ "," + index);
                                    f.sgCombobox_fm_icons.SelectedIndex = 0;
                                }
                                else
                                {
                                    //no
                                    _SYS_ICO = "%windir%\\system32\\imageres.dll,-3";
                                    f.pictureBox_folderlogo.Tag = new string[] { "SYS", _SYS_ICO };
                                    f.pictureBox_folderlogo.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(_SYS_ICO);
                                    f.sgCombobox_fm_icons.SelectedIndex = 0;
                                }
                            }
                            //读取名
                            string orgname = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "LocalizedResourceName", "", dekini, false);
                            string orgtip = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "InfoTip", "", dekini, false);
                            if (orgname != "")
                            {
                                //看看有无MUI
                                if (orgname.Substring(0, 1) == "@") { orgname = SGFunction.MUIOperate.GetMUIString(orgname); }

                                f.sgTextBox_foldername.Text = orgname;
                            }
                            if (orgtip != "")
                            {
                                if (orgtip.Substring(0, 1) == "@") { orgtip = SGFunction.MUIOperate.GetMUIString(orgtip); }
                                f.sgTextBox_foldertip.Text = orgtip;
                            }
                        }
                        else
                        {
                            _HASDESKTOPINI = false;
                            f.pictureBox_folderlogo.Tag = new string[] { "SYS", "%windir%\\system32\\imageres.dll,3" };
                            _SYS_ICO = "%windir%\\system32\\imageres.dll,3";
                            f.pictureBox_folderlogo.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon("%windir%\\system32\\imageres.dll,3");
                            f.sgCombobox_fm_icons.SelectedIndex = 0;
                            //
                            DirectoryInfo di = new DirectoryInfo(folder);
                            string fon =
                            f.sgTextBox_foldername.Text = di.Name;
                            //tip
                            f.sgTextBox_foldertip.Text = "";
                        }
                        _ORG_FOLDERNAME = f.sgTextBox_foldername.Text;
                    }
                    else { }
                }
                public static void Combox_ChangeIcon(int selectindex, SGForm_Function_SystemStyle f)
                {
                    string ico = "";
                    string tag = "USER";
                    switch (selectindex)
                    {
                        case 0:
                            ico = _SYS_ICO;
                            tag = "SYS";
                            break;
                        case 1:
                            //选择文件
                            string res;
                            string sel = SGFunction.CommonDialogs.SelectIconDialog("选择文件夹图标", "%windir%\\system32\\imageres.dll,-3", out res);
                            if (res == "ok" && sel != "") { ico = sel; tag = "USER"; }
                            break;
                        case 2:
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-123"; tag = "USER";
                            break;
                        case 3:
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-109"; tag = "USER";
                            break;
                        case 4:
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-27"; tag = "USER";
                            break;
                        case 5:
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-55"; tag = "USER";
                            break;
                        case 6:
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-25"; tag = "USER";
                            break;
                        case 7:
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\ieframe.dll,-190"; tag = "USER";
                            break;
                        case 8:
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-113"; tag = "USER";
                            break;
                        case 9:
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-112"; tag = "USER";
                            break;
                        case 10:
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-108"; tag = "USER";
                            break;
                        case 11:
                            ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,-189"; tag = "USER";
                            break;
                    }
                    if (selectindex >= 0)
                    {
                        f.pictureBox_folderlogo.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico);
                        f.pictureBox_folderlogo.Tag = new string[] { tag, ico };
                        ChangeIcon_INTEMPINI(new string[] { tag, ico });
                    }
                }
                //修改部分
                public static void ChangeIcon_INTEMPINI(string[] tag)
                {
                    string type = tag[0];
                    string file = tag[1];
                    //如果type是FROMSYS 就删除键
                    if (type.ToUpper() == "SYS")
                    {
                        //写入自带的ICON
                        if (_HASDESKTOPINI == true)
                        {
                            string ico_f = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "ICONFILE", "", _ORGDESKTOPINI, false);
                            string ico_i = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "ICONindex", "", _ORGDESKTOPINI, false);
                            string ico_res = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "iconresource", "", _ORGDESKTOPINI, false);
                            if (ico_res == "")
                            {
                                if (ico_f != "")
                                {
                                    //删除RES 写入ICO
                                    SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "IconResource", _TEMP_CONFIGFILE);
                                    SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", ico_f, _TEMP_CONFIGFILE, false);
                                    SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", ico_i, _TEMP_CONFIGFILE, false);
                                }
                                else
                                {
                                    //没有ICO 信息 删除ICO RES
                                    SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "IconFile", _TEMP_CONFIGFILE);
                                    SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "IconIndex", _TEMP_CONFIGFILE);
                                    SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "IconResource", _TEMP_CONFIGFILE);
                                }
                            }
                            else
                            {
                                if (ico_f == "")
                                {
                                    //保存RES 删除ICO
                                    SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "IconIndex", _TEMP_CONFIGFILE);
                                    SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "IconFile", _TEMP_CONFIGFILE);
                                    SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconResource", ico_res, _TEMP_CONFIGFILE, false);
                                }
                                else
                                {
                                    //都写入
                                    SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconResource", ico_res, _TEMP_CONFIGFILE, false);
                                    SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", ico_f, _TEMP_CONFIGFILE, false);
                                    SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", ico_i, _TEMP_CONFIGFILE, false);
                                }
                            }
                        }
                        else
                        {
                            //先删除ICONFILE
                            SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "IconFile", _TEMP_CONFIGFILE);
                            SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "IconIndex", _TEMP_CONFIGFILE);
                            //DELETE RES
                            SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "IconResource", _TEMP_CONFIGFILE);
                        }
                    }
                    else
                    {
                        //ADD
                        //IS FENGEFU
                        int ind;
                        string icf = SGFunction.ImageAndIconOperate.GetStrToImageLocationAndIndex(file, out ind);
                        SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", icf, _TEMP_CONFIGFILE, false);
                        SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", ind.ToString(), _TEMP_CONFIGFILE, false);
                    }
                }
                public static void ChangeFolderTip_INTEMPINI(string tag, string txt, SGForm_Function_SystemStyle f)
                {
                    if (tag != "ISLOAD")
                    {
                        if (txt == "")
                        {
                            //查找原来的信息
                            if (_HASDESKTOPINI == true)
                            {
                                //看看有无文件MUI
                                string read = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "InfoTip", "", _ORGDESKTOPINI, false);
                                if (read == "")
                                {
                                    //没有就删除写入的
                                    SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "InfoTip", _TEMP_CONFIGFILE);
                                }
                                else
                                {
                                    //写入读取的
                                    SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "InfoTip", read, _TEMP_CONFIGFILE, false);
                                }
                            }
                            else
                            {
                                //没有RES文件
                                SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "InfoTip", _TEMP_CONFIGFILE);
                            }
                        }
                        else
                        {
                            string writ = txt;
                            SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "InfoTip", writ, _TEMP_CONFIGFILE, false);
                        }
                    }
                    else
                    {
                        //吧原先的NAME 写入新文件
                        f.sgTextBox_foldertip.Tag = "CHANGE";
                        if (_HASDESKTOPINI == true)
                        {
                            //看看有无文件MUI
                            string read = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "InfoTip", "", _ORGDESKTOPINI, false);
                            if (read == "")
                            {
                                //没有就删除写入的
                                SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "InfoTip", _TEMP_CONFIGFILE);
                            }
                            else
                            {
                                //写入读取的
                                SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "InfoTip", read, _TEMP_CONFIGFILE, false);
                            }
                        }
                    }
                }
                public static void ChangeFolderDisplayName_INTEMPINI(string tag, string txt, SGForm_Function_SystemStyle f)
                {
                    if (tag != "ISLOAD")
                    {
                        if (txt == "")
                        {
                            //查找原来的信息
                            if (_HASDESKTOPINI == true)
                            {
                                //看看有无文件MUI
                                string read = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "LocalizedResourceName", "", _ORGDESKTOPINI, false);
                                if (read == "")
                                {
                                    //没有就删除写入的
                                    SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "LocalizedResourceName", _TEMP_CONFIGFILE);
                                }
                                else
                                {
                                    //写入读取的
                                    SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "LocalizedResourceName", read, _TEMP_CONFIGFILE, false);
                                }
                            }
                            else
                            {
                                //没有RES文件
                                SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "LocalizedResourceName", _TEMP_CONFIGFILE);
                            }
                        }
                        else
                        {
                            string writ = txt;
                            SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "LocalizedResourceName", writ, _TEMP_CONFIGFILE, false);
                        }
                    }
                    else
                    {
                        //吧原先的NAME 写入新文件
                        f.sgTextBox_foldername.Tag = "CHANGE";
                        if (_HASDESKTOPINI == true)
                        {
                            //看看有无文件MUI
                            string read = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue(".ShellClassInfo", "LocalizedResourceName", "", _ORGDESKTOPINI, false);
                            if (read == "")
                            {
                                //没有就删除写入的
                                SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey(".ShellClassInfo", "LocalizedResourceName", _TEMP_CONFIGFILE);
                            }
                            else
                            {
                                //写入读取的
                                SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "LocalizedResourceName", read, _TEMP_CONFIGFILE, false);
                            }
                        }
                    }

                }
                public static string GetFileDisplayName(string folder, string filename)
                {
                    string ret = "";
                    //首先读取是否已修改
                    string re = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue("LocalizedFileNames", filename, "", _TEMP_CONFIGFILE, false);
                    if (re == "")
                    {
                        //没有改革过
                        if (_HASDESKTOPINI == true)
                        {
                            //看看 有没有资源
                            string read = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue("LocalizedFileNames", filename, "", _ORGDESKTOPINI, false);
                            if (read != "")
                            {
                                string n = read;
                                if (read.Substring(0, 1) == "@") { n = SGFunction.MUIOperate.GetMUIString(n); }
                                ret = n;
                            }
                            else
                            {
                                //没有
                                ret = "";
                            }
                        }
                    }
                    else
                    {
                        //读取
                        ret = re;
                    }
                    return ret;
                }
                public static void ChangeDisplayName(string folder, string filename, string text)
                {
                    if (text == "")
                    {
                        //写入默认
                        if (_HASDESKTOPINI == true)
                        {
                            string read = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue("LocalizedFileNames", filename, "", _ORGDESKTOPINI, false);
                            if (read == "")
                            {
                                //没有信息 删除
                                SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey("LocalizedFileNames", filename, _TEMP_CONFIGFILE);
                            }
                            else
                            {
                                SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("LocalizedFileNames", filename, read, _TEMP_CONFIGFILE, false);
                            }
                        }
                        else
                        {
                            //没有信息 删除
                            SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey("LocalizedFileNames", filename, _TEMP_CONFIGFILE);
                        }
                    }
                    else
                    {
                        SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("LocalizedFileNames", filename, text, _TEMP_CONFIGFILE, false);
                    }
                }
                public static void FinishConfig(string dir)
                {
                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(dir + "\\desktop.ini");
                    SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(_TEMP_CONFIGFILE, dir + "\\desktop.ini");
                    string arg = @"+h """ + dir + @"\\desktop.ini""";
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("attrib.exe", arg, true, false, false, true);
                }
                public static void ReConfig(string dir)
                {
                    string arg = @"-a -r -s -h """ + dir + @"\\desktop.ini""";
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("attrib.exe", arg, true, false, false, true);
                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(dir + "\\desktop.ini");
                }
                //复制前删除空的节点
                //创建前 若LocalizedResourceName与文件夹名称相同 删除LocalizedResourceName
            }
            public class DriveMgr
            {
                public static void LoadDriveConfigFile(string drive, SGForm_Function_SystemStyle f)
                {
                    f.sgTextBox_drive_label.Text = f.sgTextBox_drive_ico.Text = "";
                    //f.pictureBox_drive_iconlogo.Image = null;
                    try
                    {
                        string cfg = drive + @"\" + "autorun.inf";
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == true)
                        {
                            string label = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue("autorun", "label", "", cfg, false);
                            string icon = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue("autorun", "icon", "", cfg, false);
                            if (icon != "")
                            {
                                icon = drive + @"\" + icon;
                            }
                            f.sgTextBox_drive_label.Text = label;
                            f.sgTextBox_drive_ico.Text = icon;
                            //f.pictureBox_drive_iconlogo.Image = SGFunction.ImageAndIconOperate.GetFolderOrDiskIcon(drive, false).ToBitmap();
                        }
                        else
                        {
                            string icoreg = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\DriveIcons\" + drive.Replace(":", "") + "\\Defaulticon", "", "");
                            if (icoreg != "")
                            {
                                f.sgTextBox_drive_ico.Text = icoreg;
                                //f.pictureBox_drive_iconlogo.Image = SGFunction.ImageAndIconOperate.GetFolderOrDiskIcon(drive, false).ToBitmap();
                            }

                        }
                        f.pictureBox_drive_iconlogo.Image = SGFunction.ImageAndIconOperate.GetFolderOrDiskIcon(drive, false).ToBitmap();
                    }
                    catch { }
                }
                public static void ApplyDriveInfo(string drive,string icon,string label, SGForm_Function_SystemStyle f,string type)
                {
                    string cfg = drive + @"\" + "autorun.inf";
                    try
                    {
                        if(type =="AOS")
                        {
                            SGFunction.SystemFunctionAndInformation.ShellPrograms("attrib.exe", @"-a -r -s -h """ + cfg + @"""", true, false, false, true);
                            if (icon != "") { SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("autorun", "icon", "drivelogo.ico", cfg, false); SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(icon, drive + "\\drivelogo.ico", true); } else { SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey("autorun", "icon", cfg); }
                            if (label != "") { SGFunction.ConfigFileOperate.ConfigFileOperate_WriteValue("autorun", "label", label, cfg, false); } else { SGFunction.ConfigFileOperate.CFGOperate_DeleteIniKey("autorun", "label", cfg); }
                            SGFunction.SystemFunctionAndInformation.ShellPrograms("attrib.exe", @"+h """ + cfg + @"""", true, false, false, true);
                        }
                        else
                        {
                            if(type =="COS")
                            {
                                if(icon =="")
                                {
                                    string loo = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer";
                                    loo = loo + "\\DriveIcons";
                                    SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, loo, drive.Replace(":", ""));
                                }
                                else
                                {
                                    string loo = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer";
                                    loo = loo + "\\DriveIcons\\" + drive.Replace(":", "");
                                    SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, loo, "DefaultIcon");
                                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, loo + "\\DefaultIcon", "", icon);
                                }
                            }
                        }
                    }
                    catch { }
                }
                public static void ReconfigDriveInfo(string drive)
                {
                    string cfg = drive + @"\" + "autorun.inf";
                    try
                    {
                       if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg)==true)
                       {
                           SGFunction.SystemFunctionAndInformation.ShellPrograms("attrib.exe",@"-a -r -s -h """+cfg+@"""",true,false,false,true);
                           SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(cfg);
                       }
                    }
                    catch { }
                }
            }
        }
        public class SystemDialog
        {
            public class MyComputer
            {
                public static void LoadNetworkShortcut(SGForm_Function_SystemStyle f)
                {
                    try
                    {
                        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Network Shortcuts";
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(folder, true) == false) { return; }
                        //MessageBox.Show(folder);
                        string[] lnks = SGFunction.FileSystemOperate.FileSystemOperate_GetFiles(folder, "*.lnk", SearchOption.TopDirectoryOnly);
                        for (int u = 1; u <= lnks.Length; u++)
                        {
                            FileInfo fi = new FileInfo(lnks[u - 1]);
                            string dspname = fi.Name;
                            if (fi.Exists == true)
                            {
                                if (fi.Extension != "" && fi.Name != "")
                                {
                                    dspname = dspname.Substring(0, dspname.LastIndexOf("."));
                                }
                                f.imageList_thispcitems.Images.Add(SGFunction.ImageAndIconOperate.GetFileIcon(lnks[u - 1]));
                                ListViewItem lvi = f.listView5.Items.Add(dspname);
                                lvi.Group = f.listView5.Groups[1];
                                lvi.ImageIndex = f.imageList_thispcitems.Images.Count - 1;
                                lvi.Tag = lnks[u - 1];
                            }
                        }
                    }
                    catch { }
                }
                public static void LoadMyComputerShowItems(SGForm_Function_SystemStyle user)
                {
                    try
                    {
                        user.listView5.Items.Clear();
                        user.imageList_thispcitems.Images.Clear();
                        string reg = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace";
                        if (Registry.LocalMachine.OpenSubKey(reg) == null)
                        {
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer", "NameSpace");
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
                                string ico = SGFunction.CLSIDAndHanderOperate.CLSIDOperate_GetGUIDRegistryIcon(subnames_nodele[o - 1]);
                                Bitmap img = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico, "");
                                user.imageList_thispcitems.Images.Add(img);
                                user.listView5.Items.Add(SGFunction.CLSIDAndHanderOperate.CLSIDOperate_GetGUIDRegistryName(subnames_nodele[o - 1])).ImageIndex = o - 1;
                                user.listView5.Items[o - 1].Group = user.listView5.Groups[0];
                                user.listView5.Items[o - 1].Tag = subnames_nodele[o - 1];
                            }
                        }
                        LoadNetworkShortcut(user);
                    }
                    catch { }
                }
                public static void ReConfigMyComputershowItems(SGForm_Function_SystemStyle user)
                {
                    try
                    {
                        user.listView5.Items.Clear();
                        user.imageList_thispcitems.Images.Clear();
                        string reg = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace";
                        if (Registry.LocalMachine.OpenSubKey(reg) == null)
                        {
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer", "NameSpace");
                        }
                        string[] subnames = Registry.LocalMachine.OpenSubKey(reg).GetSubKeyNames();
                        if (subnames.Length > 0)
                        {
                            for (int p = 1; p <= subnames.Length; p++)
                            {
                                if (subnames[p - 1].ToUpper() != "DelegateFolders".ToUpper() && subnames[p - 1].Length == 38)
                                {
                                    //删除制定项目
                                    SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, reg, subnames[p - 1]);
                                }
                            }
                            //重新建立
                            if(SGFunction.SystemFunctionAndInformation.GetOSVersion()=="6.3")
                            {
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, "{374DE290-123F-4565-9164-39C4925E467B}");
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, "{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, "{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, "{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, "{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
                            }
                            LoadMyComputerShowItems(user);
                        }

                    }
                    catch { }
                }
                public static void ReConfigNetworkShortcut(SGForm_Function_SystemStyle f)
                {
                    try
                    {
                        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Network Shortcuts";
                        SGFunction.FileSystemOperate.DeleteFileFolderAndSendToReclyBin(folder, true);
                        LoadMyComputerShowItems(f);
                    }
                    catch { }
                }
                public static void AddMyComputerItem(string[] cclsid,SGForm_Function_SystemStyle f)
                {
                    try
                    {
                        string loc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace";
                        if (Registry.LocalMachine.OpenSubKey(loc) == null) { SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"OFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer", "NameSpace"); }
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, loc, cclsid[0]);
                        string ico = cclsid[2];
                        string name = cclsid[1];
                        //
                        ListViewItem lvi = f.listView5.Items.Add(name);
                        f.imageList_thispcitems.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                        lvi.Tag = cclsid[0];
                        lvi.ImageIndex = f.imageList_thispcitems.Images.Count - 1;
                        lvi.Group = f.listView5.Groups[0];
                    }
                    catch { }
                }
                public static void AddMoreFunction(SGForm_Function_SystemStyle f)
                {
                    try
                    {
                        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Network Shortcuts";
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(folder, true) == false) { return; }
                        string res;
                        string[] op = SGFunction.CommonDialogs.ShowMoreFunctionDialog("选择常用的操作", out res, "normal", true);
                        if(res =="ok")
                        {
                            string name = op[0];
                            string exe = op[1];
                            string arg = op[2];
                            string ico = op[3];
                            string admin=op[4];
                            string lnkf = folder + "\\" + name + ".lnk";
                            if (admin.ToUpper() == "TRUE")
                            {
                                SGFunction.SystemFunctionAndInformation.CreateLink_StartAdminType(lnkf, exe, arg, "", ico);
                            }
                            else { SGFunction.SystemFunctionAndInformation.CreateLink(lnkf, exe, arg, "", ico); }
                            ListViewItem lvi = f.listView5.Items.Add(name);
                            f.imageList_thispcitems.Images.Add(SGFunction.ImageAndIconOperate.GetFileIcon(lnkf));
                            lvi.Tag = lnkf;
                            lvi.ImageIndex = f.imageList_thispcitems.Images.Count - 1;
                            lvi.Group = f.listView5.Groups[1];
                        }
                    }
                    catch { }
                }
                public static void AddFolder(SGForm_Function_SystemStyle f)
                {
                    try
                    {
                        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Network Shortcuts";
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(folder, true) == false) { return; }
                        string k = SGFunction.CommonDialogs.OpenFolderDialog("选择文件夹");
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(k, false) == true)
                        {
                            DirectoryInfo di = new DirectoryInfo(k);
                            string name = di.Name;
                            string lnkf = folder + "\\" + name + ".lnk";
                            SGFunction.SystemFunctionAndInformation.CreateLink(lnkf, k, "", "");
                            ListViewItem lvi = f.listView5.Items.Add(name);
                            f.imageList_thispcitems.Images.Add(SGFunction.ImageAndIconOperate.GetFileIcon(lnkf));
                            lvi.Tag = lnkf;
                            lvi.ImageIndex = f.imageList_thispcitems.Images.Count - 1;
                            lvi.Group = f.listView5.Groups[1];
                        }
                        
                    }
                    catch { }
                }
                public static void AddFile(SGForm_Function_SystemStyle f)
                {
                    try
                    {
                        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Network Shortcuts";
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(folder, true) == false) { return; }
                        string k = SGFunction.CommonDialogs.OpenFileDialog("添加文件","所有文件(*.*)|*.*",false);
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(k)  == true)
                        {
                            FileInfo di = new FileInfo(k);
                            string name = di.Name;
                            if (name != "" && di.Extension != "") { name = name.Substring(0, name.LastIndexOf(".")); }
                            string lnkf = folder + "\\" + name + ".lnk";
                            SGFunction.SystemFunctionAndInformation.CreateLink(lnkf, k, "", "");
                            ListViewItem lvi = f.listView5.Items.Add(name);
                            f.imageList_thispcitems.Images.Add(SGFunction.ImageAndIconOperate.GetFileIcon(lnkf));
                            lvi.Tag = lnkf;
                            lvi.ImageIndex = f.imageList_thispcitems.Images.Count - 1;
                            lvi.Group = f.listView5.Groups[1];
                        }

                    }
                    catch { }
                }
                public static void DeleteSelect(string type,string tag,SGForm_Function_SystemStyle f)
                {
                    try
                    {
                        if(type.ToUpper()=="CLSID")
                        {
                            string loc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace";
                            SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, loc, tag);
                            //SGFunction.SystemFunctionAndInformation.ShellMyComputer();
                            SGSystemStyle.SystemDialog.MyComputer.LoadMyComputerShowItems(f);
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功删除了这个项目。", 2);
                        }
                        else
                        {
                            if(type.ToUpper()=="LNK")
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(tag);
                                SGSystemStyle.SystemDialog.MyComputer.LoadMyComputerShowItems(f);
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功删除了这个项目。", 2);
                            }
                        }
                    }
                    catch { }
                }
            }
            public class SystemInfo
            {
                public static void SystemStyle_LoadOEMAndSystemInfo(SGForm_Function_SystemStyle user)
                {
                   try
                  {
                        string oemname = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Manufacturer", "");
                        string oemurl = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportURL", "");
                        string oemphone = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Supportphone", "");
                        string oemhour = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportHours", "");
                        string cmpmodel = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "model", "");
                        string oemlog = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "logo", "");
                        //////////////////////////////
                        string sys_reguser = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOwner", "");
                        string sys_name = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "");
                        string sys_Installpath = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SourcePath", "");
                        string sys_regcompany = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOrganization", "");
                        string sys_version = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentVersion", "");
                        string sys_id = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductID", "");
                        //LOAD OEM LOGO
                        if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(oemlog)==true)
                        {
                            //现在如
                            user.pictureBox_oem_oemlogo.Image =Image.FromFile(oemlog);
                            user.sgTextBox_oem_oemlogo.Text =oemlog;
                        }
                        else
                        {
                            //没有 XITONGPAN
                            string sysdisk=SGFunction.SystemFunctionAndInformation.FindSystemDrive().Replace("\\","");
                            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sysdisk +oemlog )==true)
                            {
                                user.sgTextBox_oem_oemlogo.Text =sysdisk +oemlog;
                                user.pictureBox_oem_oemlogo.Image =Image.FromFile(sysdisk +oemlog);
                            }else{user.pictureBox_oem_oemlogo.Image =null;user.sgTextBox_oem_oemlogo.Text =oemlog ;}
                        }
                        //
                        user.sgTextBox_oem_name.Text =oemname;user.sgTextBox_oem_edition.Text =cmpmodel;user.sgTextBox_oem_phone.Text =oemphone;user.sgTextBox_oem_time.Text =oemhour;user.sgTextBox_oem_web.Text =oemurl;
                        user.sgTextBox_sys_osid.Text =sys_id;user.sgTextBox_sys_osname.Text =sys_name;user.sgTextBox_sys_osversion.Text =sys_version;user.sgTextBox_sys_regcompany.Text =sys_regcompany;user.sgTextBox_sys_user.Text =sys_reguser;
                       /*
                        string syslogodll = Environment.GetEnvironmentVariable("windir") + @"\Branding\ShellBrd\shellbrd.dll";
                        if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(syslogodll)==true)
                        {
                            Image m = SGFunction.ImageAndIconOperate.LoadResources_GetBitmap(syslogodll, 2050, "Bitmap");
                            user.sgTextBox_sys_syslogo.Text  = "";
                            user.pictureBox_sys_syslogo.Image = m;
                            //无法加载系统的Image
                            string logo_7 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("images") + "\\SystemLogo_Win7.bmp";
                            string logo_8 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("images") + "\\SystemLogo_Win8.bmp";
                            if(user.pictureBox_sys_syslogo.Image ==null)
                            {
                                if(SGFunction.SystemFunctionAndInformation.GetOSVersion()=="6.1")
                                {
                                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(logo_7) == true) { user.pictureBox_sys_syslogo.Image = Image.FromFile(logo_7); }
                                }
                                else
                                {
                                    if(SGFunction.SystemFunctionAndInformation.GetOSVersion()=="6.2" || SGFunction.SystemFunctionAndInformation.GetOSVersion()=="6.3")
                                    {
                                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(logo_8) == true) { user.pictureBox_sys_syslogo.Image = Image.FromFile(logo_8); }
                                    }
                                }
                            }
                        }
                       */
                    }
                   catch
                   {
                   }
                }
                public static void SystemStyle_SetOEMInfo(string OEMName, string OEMURL, string OEMModel, string OEMHours, string OEMPhone, Image OEMLogo)
                {
                    try
                    {
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Manufacturer", OEMName, RegistryValueKind.String);
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportURL", OEMURL, RegistryValueKind.String);
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportHours", OEMHours, RegistryValueKind.String);
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Model", OEMModel, RegistryValueKind.String);
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "SupportPhone", OEMPhone, RegistryValueKind.String);
                        if (OEMLogo != null)
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\OEMLogo.bmp");
                            SGFunction.ImageAndIconOperate.SaveImageAsFile(OEMLogo, System.Drawing.Imaging.ImageFormat.Bmp, OEMLogo.Width, OEMLogo.Height, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\OEMLogo.bmp");
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Logo", @"%SystemRoot%\system32\OEMLogo.BMP", RegistryValueKind.ExpandString);
                        }
                        else
                        {
                            //SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "logo");
                        }
                    }
                    catch
                    {
                    }
                }
                public static void SystemStyle_SetSystemInfo(string UserName, string OSName, string Company, string OSVer, string OSID,string path)
                {
                    try
                    {
                         SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOwner", UserName, RegistryValueKind.String);
                         SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", OSName, RegistryValueKind.String);
                         SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SourcePath", path, RegistryValueKind.String);
                         SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOrganization", Company, RegistryValueKind.String);
                         SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentVersion", OSVer, RegistryValueKind.String);
                         SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductID", OSID, RegistryValueKind.String);
                    }
                    catch
                    {
                    }
                }
                public static void SetSystemLogo(string bmpfile)
                {
                    Size win8_1050 = new Size(348,58);
                    Size win8_2050 = new Size(435, 72);
                    Size win8_3050 = new Size(522,87);
                    string bakfile = Environment.GetEnvironmentVariable("windir") + @"\Branding\ShellBrd\shellbrd.dll.sgbak";
                    string dll = Environment.GetEnvironmentVariable("windir") + @"\Branding\ShellBrd\shellbrd.dll";
                    string temp = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\shellbrd.dll";
                    string cb = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\systemlogo.bmp";
                    SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(dll, temp, true);
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bmpfile) == true)
                    {
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(temp) == true)
                        {
                            string ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(bmpfile);
                            Image li=Image.FromFile(bmpfile);
                            if (ext.ToUpper() != "BMP") { SGFunction.ImageAndIconOperate.SaveImageAsFile(li, System.Drawing.Imaging.ImageFormat.Bmp, li.Size.Width, li.Size.Height, cb); }else{SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(bmpfile,cb);}
                            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cb)==true)
                            {
                                Image lt = Image.FromFile(cb);
                                //转换带下
                                string bmp_1050 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\systemlogo_1050.bmp";
                                string bmp_2050 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\systemlogo_2050.bmp";
                                string bmp_3050 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\systemlogo_3050.bmp";
                                if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.1")
                                {

                                }
                                else
                                {
                                    SGFunction.ImageAndIconOperate.SaveImageAsFile(lt, System.Drawing.Imaging.ImageFormat.Bmp, win8_1050.Width, win8_1050.Height, bmp_1050);
                                    SGFunction.ImageAndIconOperate.SaveImageAsFile(lt, System.Drawing.Imaging.ImageFormat.Bmp, win8_1050.Width, win8_2050.Height, bmp_2050);
                                    SGFunction.ImageAndIconOperate.SaveImageAsFile(lt, System.Drawing.Imaging.ImageFormat.Bmp, win8_1050.Width, win8_3050.Height, bmp_3050);
                                }
                                //修改资源
                                //SGFunction.Resources.UpdateResources(bmpfile, temp, 1033, 1050, "BITMAP");
                                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cb) == true)
                                {
                                    //检查备份
                                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakfile) == false)
                                    {
                                        SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(dll, bakfile);
                                    }
                                    SGFunction.Resources.UpdateResources(bmp_1050, temp, 1033, "BITMAP", 1050);
                                    SGFunction.Resources.UpdateResources(bmp_2050, temp, 1033, "BITMAP", 2050);
                                    SGFunction.Resources.UpdateResources(bmp_3050, temp, 1033, "BITMAP", 3050);
                                    //去掉文件保护
                                    SGFunction.FileSystemOperate.FileSystemOperate_GetAdminWithFile(dll);
                                    //OLD
                                    SGFunction.FileSystemOperate.FSO_RenameFile(dll, dll + ".old");
                                    //复制并替换
                                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(dll);
                                    //CMD复制
                                    string arg = @"/c copy /y """+temp+@"""";
                                    SGFunction.SystemFunctionAndInformation.ShellPrograms("CMD.EXE", arg, true, false, true, true);
                                    //OK
                                }
                            }
                            
                            else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们无法创建临时文件。", 2); }
                        }
                        else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们无法创建临时文件。", 2); }
                    }
                    else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们没有找到您选择的图片文件。", 2); }
                }
                public static void SystemStyle_ReConfigOEMInfo()
                {
                    try
                    {
                        SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Manufacturer");
                        SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "supporturl");
                        SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "supporthours");
                        SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "model");
                        SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "supportphone");
                        SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "logo");
                    }
                    catch
                    {
                    }
                }
                public static void SystemStyle_ReConfigLogo()
                {
                    try
                    {
                        SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "logo");
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.System )+"\\oemlogo.bmp");
                    }
                    catch
                    {
                    }
                }
            }
            public class Dialogs
            {
                /// <summary>
                /// 加载系统窗体
                /// </summary>
                /// <param name="u">SGFORM SYSTEM STYLE</param>
                /// <param name="arg">代号[PREVIEWSIZE] 预览窗体大小 [WIN8BORDERSIZE] WIN8窗体边框大小</param>
                public static void LoadDialogSetting(SGForm_Function_SystemStyle u, string arg)
                {
                    try
                    {
                        switch (arg.ToUpper())
                        {
                            case "PREVIEWSIZE":
                                string l = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband";
                                string size = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, l, "MinThumbSizePx", "300");
                                int j;
                                int.TryParse(size, out j);
                                //u.numericUpDown3.Value = j;
                                u.sgNumberControl_previewdialog_size.Value = j;
                                break;
                            case "WIN8BORDERSIZE":
                                string rl_border = @"Control Panel\Desktop\WindowMetrics";
                                string size_wb = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, rl_border, "PaddedBorderWidth", "-60");
                                size_wb = size_wb.Replace("-", "");
                                int j1;
                                int.TryParse(size_wb, out j1);
                                u.sgNumberControl_win8dialog_bordersize.Value = j1;
                                break;
                        }
                    }
                    catch { }
                }
                /// <summary>
                /// 应用系统窗体设置
                /// </summary>
                /// <param name="type">代号[PREVIEWSIZE] 预览窗体大小 [WIN8BORDERSIZE] WIN8窗体边框大小</param>
                /// <param name="args">参数 [0]值</param>
                public static void ApplyDialogSettings(string type, string[] args)
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
                                     SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, rl_border, "MinThumbSizePx", k.ToString(), RegistryValueKind.DWord,false);
                                     //SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"应用成功，注销登录后设置生效。您也可以点击""注销登录""按钮注销系统", 3);
                                     //SGFunction.SystemFunctionAndInformation.LogOff();
                                }
                                catch { SGFunction.CommonDialogs.MessageDialog_ShowInfo("应用失败。", 3); }
                                break;
                            case "WIN8BORDERSIZE":
                                try
                                {
                                    string si = args[0];
                                    string rl_border = @"Control Panel\Desktop\WindowMetrics";
                                    int k;
                                    int.TryParse(si, out k);
                                    if (k > 0) { si = "-" + k.ToString(); } else { si = k.ToString(); }
                                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, rl_border, "PaddedBorderWidth", si, RegistryValueKind.String,false);
                                    //SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"应用成功，注销登录后设置生效。您也可以点击""注销登录""按钮注销系统", 3);
                                    //SGFunction.SystemFunctionAndInformation.LogOff();
                                }
                                catch { SGFunction.CommonDialogs.MessageDialog_ShowInfo("应用失败。", 3); }
                                break;
                        }
                    }
                    catch { }
                }
                /// <summary>
                /// 还原默认的设置
                /// </summary>
                /// <param name="type">代号[PREVIEWSIZE] 预览窗体大小 [WIN8BORDERSIZE] WIN8窗体边框大小</param>
                public static void ReConfigDialogSettings(string type)
                {
                    try
                    {
                        switch (type.ToUpper())
                        {
                            case "PREVIEWSIZE":
                                try
                                {
                                    string rl_border = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband";
                                    SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.CurrentUser, rl_border, "MinThumbSizePx");
                                    SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"还原设置成功，注销登录后设置生效。您也可以点击""注销登录""按钮注销系统", 3);
                                   // SGFunction.SystemFunctionAndInformation.LogOff();
                                }
                                catch { SGFunction.CommonDialogs.MessageDialog_ShowInfo("还原设置失败。", 3); }
                                break;
                            case "WIN8BORDERSIZE":
                                try
                                {
                                    string rl_border = @"Control Panel\Desktop\WindowMetrics";
                                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, rl_border, "PaddedBorderWidth", "-60", RegistryValueKind.String, false);
                                    SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"还原设置成功，注销登录后设置生效。您也可以点击""注销登录""按钮注销系统", 3);
                                    //SGFunction.SystemFunctionAndInformation.LogOff();
                                }
                                catch { SGFunction.CommonDialogs.MessageDialog_ShowInfo("还原设置失败。", 3); }
                                break;
                        }
                    }
                    catch { }
                }
            }
        }
        public class BrowserMgr
        {
            public class IEMgr
            {
                const string IESETTINGREG = @"SOFTWARE\Microsoft\Internet Explorer\Main";//HKCU
                /// <summary>
                /// 获取IE的主页设置
                /// </summary>
                /// <returns></returns>
                public static string[] LoadIEStartPages()
                {
                    List<string> result = new List<string>();
                    string[] secondpages = null;
                    string page1 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get",Registry.CurrentUser , @"SOFTWARE\Microsoft\Internet Explorer\Main", "start page", "");
                    if (page1 != "") { result.Add(page1); }
                    object pages = SGFunction.RegistryOperate.RegistryOperate_ValueOperate_GetObject("GET", Registry.CurrentUser , @"SOFTWARE\Microsoft\Internet Explorer\Main", "Secondary Start Pages", "");
                    if(pages !=null)
                    {
                        if (pages != "") { secondpages = (string[])pages; }
                    }
                    if(secondpages !=null)
                    {
                        if (secondpages.Length > 0)
                        {
                            for (int j = 1; j <= secondpages.Length; j++)
                            {
                                result.Add(secondpages[j - 1]);
                            }
                        }
                    }
                    return result.ToArray();
                }
                /// <summary>
                /// 获取搜索提供商（返回名称）
                /// </summary>
                /// <param name="clsids">返回CLSID</param>
                /// <param name="isedefault">是否默认</param>
                /// <param name="logopath">输出LOGO图标路径</param>
                /// <returns></returns>
                
                public static string[] LoadSearchProviders(out string[] clsids,out string[] isedefault,out string[] logopath)
                {
                    List<string> names = new List<string>();
                    List<string> clsidsret = new List<string>();
                    List<string> defaultret = new List<string>();
                    List<string> logo = new List<string>();
                    string[] subkeys = SGFunction.RegistryOperate.RegistryOperate_GetSubkeys(Registry.CurrentUser, @"Software\Microsoft\Internet Explorer\SearchScopes");
                    string defaultclsid = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.CurrentUser, @"Software\Microsoft\Internet Explorer\SearchScopes", "DefaultScope", "");
                    for(int j=1;j<=subkeys.Length;j++)
                    {
                        clsidsret.Add(subkeys[j - 1]);
                        //name
                        string n = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.CurrentUser, @"Software\Microsoft\Internet Explorer\SearchScopes\" + subkeys[j - 1], "displayname", "");
                        string n1 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.CurrentUser, @"Software\Microsoft\Internet Explorer\SearchScopes\" + subkeys[j - 1], "FaviconPath", "");
                        names.Add(n);
                        logo.Add(n1);
                        if(subkeys[j-1].ToUpper() ==defaultclsid.ToUpper())
                        {
                            defaultret.Add("是");
                        }
                        else
                        {
                            defaultret.Add("");
                        }
                    }
                    clsids = clsidsret.ToArray(); isedefault = defaultret.ToArray(); logopath = logo.ToArray();
                    return names.ToArray();
                }
                /// <summary>
                /// 获取IE的窗体标题
                /// </summary>
                /// <returns></returns>
                public static string LoadIEWindowTitle()
                {
                    string title = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, IESETTINGREG, "WINDOW TITLE", "");
                    return title;
                }
                /// <summary>
                /// 获取IE默认的下载路径
                /// </summary>
                /// <returns></returns>
                public static string LoadIEDefaultDownloadPath()
                {
                    string title = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, IESETTINGREG, "Default Download Directory", "");
                    return title;
                }
                /// <summary>
                /// 获取IE的外观设置
                /// </summary>
                public static void LoadIEStyleConfig(SGForm_Function_SystemStyle frm)
                {
                    //读取公共栏和菜单栏设置
                    string regpath_commontool = @"Software\Policies\Microsoft\Internet Explorer\Toolbars\Restrictions"; //hkcu
                    string value_commontool = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.CurrentUser, regpath_commontool, "NoCommandBar","0");
                    string value_menutool = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.CurrentUser, regpath_commontool, "NoNavBar", "0");
                    if (value_commontool == "0") { frm.sgChooseBox_iemgr_commontool.MyChooseChooseChecked = 2; } else { frm.sgChooseBox_iemgr_commontool.MyChooseChooseChecked = 1; }
                    if (value_menutool == "0") { frm.sgChooseBox_iemgr_menubar.MyChooseChooseChecked = 2; } else { frm.sgChooseBox_iemgr_menubar.MyChooseChooseChecked = 1; }
                    //搜索栏
                    string regpath_searchbar = @"Software\Policies\Microsoft\Internet Explorer\Infodelivery\Restrictions"; //hkcu 好像用不了


                }
                public static void LoadSetting_IE(SGClickItems con_homepags,SGListView con_sps,SGTextBox con_titlebox,SGTextBox con_downloadpath,SGForm_Function_SystemStyle frm)
                {
                    //加载IE主页设置
                    string[] homepags = LoadIEStartPages();
                    con_homepags.Items.Clear();
                    foreach(string j in homepags )
                    {
                        con_homepags.Items.Add(j);
                    }
                    //搜索提供商
                    string[] sp_clsid; string[] sp_displaynames; string[] sp_default; string[] sp_logos;
                    sp_displaynames = LoadSearchProviders(out sp_clsid, out sp_default,out sp_logos);
                    con_sps.Items.Clear(); con_sps.SmallImageList.Images.Clear();
                    for(int u=1;u<=sp_displaynames.Length;u++)
                    {
                        con_sps.Items.Add(sp_default[u - 1]).SubItems.Add(sp_displaynames[u - 1]);
                        con_sps.Items[con_sps.Items.Count - 1].Tag = sp_clsid[u - 1]; //TAG放上CLSID
                        con_sps.SmallImageList.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(sp_logos[u - 1], @"%windir%\system32\ieframe.dll,10", 16));
                        con_sps.Items[con_sps.Items.Count - 1].ImageIndex = con_sps.SmallImageList.Images.Count - 1;
                    }
                    //标题
                    con_titlebox.Text = LoadIEWindowTitle();
                    //默认下载链接
                    con_downloadpath.Text = LoadIEDefaultDownloadPath();
                    //读取外观设置
                    LoadIEStyleConfig(frm);
                }
            }
        }
    }
}
