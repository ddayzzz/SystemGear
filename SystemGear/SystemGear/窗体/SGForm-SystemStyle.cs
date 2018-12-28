using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using SystemGear.窗体;
using SystemGear.控件;
using SystemGear.类或代码;
using SystemGear.功能控件;
using SystemGear.窗体UI;
namespace SystemGear
{

    public partial class SGForm_Function_SystemStyle : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        /// <summary>
        /// 是否已运行的窗体
        /// </summary>
        SGForm_Main mainfrm = null;
        string rmmgr_selectfile = "";
        int rmmgr_beforeselectleftlist = 0; //用来记录SGTREEVIEW2之前的点击节点
        public string selectfunctioncmd = "SY,1,1,1";
        //用于指示功能是否运行过
        private bool _ICONMGR_DESKTOPMGR_RUNONCE = false;
        private bool _ICONMGR_SYSTEMICON_RUNONCE = false;
        private bool _ICONMGR_FILETYPEMGR_RUNONCE = false;
        private bool _ICONMGR_TASKBARMGR_RUNONCE = false;
        private bool _ICONMGR_CLSIDICON_RUNONCE = false;
        //----------------------
        private bool _RIGHTMENUMGR_RIGHTMENUGROUP_RUNONCE = false;
        private bool _RIGHTMENUMGR_CLIPBOARDOPERATE_RUNONCE = false;
        private bool _RIGHTMENUMGR_RIGHTMENUSMGR_RUNONCE = false;
        private bool _RIGHTMENUMGR_RUNCOMMANDS_RUNONCE = false;
        //-----------------------------
        private bool _WIN8STYLE_STARTCOLOR_RUNONCE = false;
        private bool _WIN8STYLE_WINXMENU_RUNONCE = false;
        //-----------------------
        private bool _SYSTEMBOOT_LOCKIMAGE_RUNONCE = false;
        private bool _SYSTEMBOOT_VDISK_RUNONCE = false;
        private bool _SYSTEMBOOT_BOOTMGR_BOOTMENUSMGR_RUNONCE = false;
        //--------------------
        private bool _FILEMGR_FOLDERMGR_RUNONCE = false;
        //--------------------
        private bool _SYSTEMDIALOG_SYSINFO_RUNONCE = false;
        private bool _SYSTEMDIALOG_SYSDISLOG_RUNONCE = false;
        private bool _SYSTEMDIALOG_MYCOMPUTER_RUNONCE = false;
        public void ShellMainDialog()
        {
            if(mainfrm !=null)
            {
                mainfrm.Show();
                mainfrm.Location = this.Location;
                this.Hide();
            }
        }
        public SGForm_Function_SystemStyle(SGForm_Main maindlg,int frindex=1,int secindex=1,int thrindex=1)
        {
            InitializeComponent();
            this.mainfrm = maindlg;
            SGSystemStyle.LoadSkin.LoadColorSetting(this);
            this.Start(frindex, secindex, thrindex);
        }
        public void Start(int mainindex,int secondindex,int thirdindex=1,string tags="")
        {
            int def = 0;
            int select = 1;
            switch(mainindex)
            {
                case 1:
                    IconAndLinkMgr(secondindex,thirdindex);
                    def = 0;
                    select = 1;
                    break;
                case 2:
                    RightMenuMgr(secondindex, thirdindex);
                    def = 1;
                    select = 2;
                    break;
                case 3:
                    Win8Style(secondindex, thirdindex);
                    def = 2;
                    select = 3;
                    break;
                case 4:
                    SystemBoot(secondindex, thirdindex);
                    def = 3;
                    select = 4;
                    break;
                case 5:
                    FileMgr(secondindex, thirdindex);
                    def = 4;
                    select = 5;
                    break;
                case 6:
                    SystemDialog(secondindex, thirdindex);
                    def = 5;
                    select = 6;
                    break;
                case 7:
                    BrowserMgr(secondindex, thirdindex);
                    def = 6;
                    select = 7;
                    break;
            }
            this.sgItems1.Settings_ChooseItemsIndex = select;
            this.sgTabPageControl_main.SelectedIndex = def;
        }
        public void BrowserMgr(int secondindex, int thridindex = 1,string tags="")
        {
            int def = 0;
            switch (secondindex)
            {
                case 1:
                    SGSystemStyle.BrowserMgr.IEMgr.LoadSetting_IE(this.sgClickItems_iemgr_homepages,sgListView_searchproviders,sgTextBox_iemgr_windowstitle,sgTextBox_iemgr_defaultdowloadpath,this);
                    def = 0;
                    break;
            }
            selectfunctioncmd = "SY,7" + "," + secondindex + "," + thridindex;
            this.sgTabPageControl_browsermgr.SelectedIndex = def;
        }
        public void SystemDialog(int secondindex, int thridindex = 1,string tags="")
        {
            int def = 0;
            switch (secondindex)
            {
                case 1:
                    if (_SYSTEMDIALOG_SYSINFO_RUNONCE == false)
                    {
                        _SYSTEMDIALOG_SYSINFO_RUNONCE  = true;
                        SGSystemStyle.SystemDialog.SystemInfo.SystemStyle_LoadOEMAndSystemInfo(this);
                    }
                    else { }
                    def = 0;
                    break;
                case 3:
                    if (_SYSTEMDIALOG_SYSDISLOG_RUNONCE  == false)
                    {
                        _SYSTEMDIALOG_SYSDISLOG_RUNONCE  = true;
                        SGSystemStyle.SystemDialog.Dialogs.LoadDialogSetting(this, "PREVIEWSIZE");
                        if (SGFunction.SystemFunctionAndInformation.GetOSVersion() != "6.1")
                        {
                            sgNumberControl_win8dialog_bordersize.Enabled = true;
                            SGSystemStyle.SystemDialog.Dialogs.LoadDialogSetting(this, "WIN8BORDERSIZE");
                        }
                        else { sgNumberControl_win8dialog_bordersize.Enabled = false; }
                    }
                    else { }
                    def = 2;
                    break;
                case 4:
                    def = 3;
                    break;
                case 5:
                    def = 4;
                    break;
                case 2:
                    if (_SYSTEMDIALOG_MYCOMPUTER_RUNONCE == false)
                    {
                        string osv = SGFunction.SystemFunctionAndInformation.GetOSVersion();
                        SGSystemStyle.SystemDialog.MyComputer.LoadMyComputerShowItems(this);
                        _SYSTEMDIALOG_MYCOMPUTER_RUNONCE = true;
                    }
                    else { }
                    def = 1;
                    break;
            }
            selectfunctioncmd = "SY,6" + "," + secondindex + "," + thridindex;
            this.sgTabPageControl8.SelectedIndex = def;
        }
        public void SystemBoot(int secondindex, int thridindex = 1, string tags = "")
        {
            int def = 0;
            switch (secondindex)
            {
                case 1:
                    if (_SYSTEMBOOT_LOCKIMAGE_RUNONCE == false)
                    {
                        if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.1")
                        {
                            SGSystemStyle.SystemBoot.LockScreenImage.LoadLockScreenImage(this);
                            MyNormalButton97.Visible = MyNormalButton79.Visible = MyNormalButton96.Visible = MyNormalButton98.Visible = MyNormalButton84.Visible = pictureBox15.Visible = true;
                            MyNormalButton107.Visible = false;
                            MyNormalButton108.Visible = true;
                            sgCheckBox7.Visible = true;
                            //sgLabel13.Text = "锁屏界面的图片来自 ：";
                            //获取邮件关联
                            sgCheckBox7.CheckBox_CheckedChangeToEvent = false;
                            bool k = SGSystemStyle.SystemBoot.LockScreenImage.GetRightMenuState();
                            if (k == true) { sgCheckBox7.CheckState = CheckState.Checked; } else { sgCheckBox7.CheckState = CheckState.Unchecked; }
                            sgCheckBox7.CheckBox_CheckedChangeToEvent = true;
                        }
                        else
                        {
                            MyNormalButton97.Visible = MyNormalButton79.Visible = MyNormalButton96.Visible = MyNormalButton98.Visible = MyNormalButton84.Visible = pictureBox15.Visible = false;
                            MyNormalButton107.Location = MyNormalButton97.Location;
                            MyNormalButton108.Visible = false;
                            MyNormalButton107.Visible = true;
                            sgCheckBox7.Visible = false;
                            //sgLabel13.Text = "这个功能仅对Windows 7有效 ，但您可以";
                        }
                        _SYSTEMBOOT_LOCKIMAGE_RUNONCE = true;
                    }
                    else { }
                    def = 0;
                    break;
                case 2:
                    def = 1;
                    break;
                case 3:
                    switch (thridindex)
                    {
                        case 1:
                            if (_SYSTEMBOOT_BOOTMGR_BOOTMENUSMGR_RUNONCE == false)
                            {
                                SGSystemStyle.SystemBoot.BootMenusMgr.SystemStyle_LoadBCD(this);
                                _SYSTEMBOOT_BOOTMGR_BOOTMENUSMGR_RUNONCE = true;
                            }
                            sgTabPageControl_third_bootmgr.SelectedIndex = 0;
                            break;
                        case 2:
                            //判断是否已启动
                            if (sgListView_startupitems_normalitems.Items.Count  == 0 && sgListView_startupitems_servicesitems.Items.Count  == 0 && sgListView_startupitems_shortcutitems.Items.Count  == 0 && sgListView_startupitems_taskitems.Items.Count  == 0)
                            {
                                //_SYSTEMBOOT_BOOTMGR_STARTUPITEMS_RUNONCE = true;
                                this.sgListView_startupitems_normalitems.Visible = true;
                                this.sgListView_startupitems_normalitems.Location = new Point(8, 40);
                                this.sgListView_startupitems_normalitems.Size = new Size(859, 358);
                                SGSystemStyle.SystemBoot.StartupItemsMgr.StartItemfromRegistry.LoadNormalStartupItems(imageList_startupitemsmgr_normalitems, sgListView_startupitems_normalitems);
                                
                                //radioButton_startup_fromreg.Checked = true;
                            }
                            sgTabPageControl_third_bootmgr.SelectedIndex = 1;

                            break;
                    }
                    def = 2;
                    break;
                case 4:
                    if(_SYSTEMBOOT_VDISK_RUNONCE ==false)
                    {
                        sgCombobox2.SelectedIndex = 1;
                        if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.1") { sgRadioButton_vhdx.Enabled = false; sgRadioButton_vhd.Checked = true; }
                        //获取空的盘符
                        string[] lets = SGFunction.FileSystemOperate.FSO_GetEmptyLetter("\\");
                        sgCombobox_letter.Items.Clear();
                        for (int u = 1; u <= lets.Length; u++) { sgCombobox_letter.Items.Add(lets[u - 1]); }
                        if (sgCombobox_letter.Items.Count >= 1) { sgCombobox_letter.SelectedIndex = sgCombobox_letter.Items.Count - 1; }
                        _SYSTEMBOOT_VDISK_RUNONCE = true;
                    }
                    def = 3;
                    break;
            }
            selectfunctioncmd = "SY,4" + "," + secondindex + "," + thridindex;
            this.sgTabPageControl6.SelectedIndex = def;
        }
        public void IconAndLinkMgr(int secondindex, int thridindex = 1, string tags = "")
        {
            int def = 0;
            switch (secondindex)
            {
                case 1:
                    if (_ICONMGR_DESKTOPMGR_RUNONCE == false)
                    {
                        
                        SGSystemStyle.IconAndLinkMgr.DesktopIconsMgr.GetDesktopIconShowType(this);
                        SGSystemStyle.IconAndLinkMgr.DesktopIconsMgr.GetPowerIconType(this);
                        SGSystemStyle.IconAndLinkMgr.DesktopIconsMgr.LoadDesktopIconToImage(this);
                        _ICONMGR_DESKTOPMGR_RUNONCE = true;
                    }
                    else { }
                    def = 0;
                    break;
                case 2:
                    if (_ICONMGR_SYSTEMICON_RUNONCE == false)
                    {
                        SGSystemStyle.IconAndLinkMgr.SystemIconsMgr.LoadSystemIcon_Basic(listView3, imageList_basicicon);
                        _ICONMGR_SYSTEMICON_RUNONCE = true;
                    }
                    else { }
                    def = 1;
                    break;
                case 3:
                    if (_ICONMGR_FILETYPEMGR_RUNONCE == false)
                    {
                        SGSystemStyle.IconAndLinkMgr.FileTypeMgr.LoadExtsIconAndDescription(this);
                        _ICONMGR_FILETYPEMGR_RUNONCE = true;
                    }
                    else { }
                    def = 2;
                    break;
                case 4:
                    if (_ICONMGR_TASKBARMGR_RUNONCE == false)
                    {
                        SGSystemStyle.IconAndLinkMgr.TaskBarMgr.LoadIcon(this);
                        SGSystemStyle.IconAndLinkMgr.TaskBarMgr.LoadTaskBarIconsShowType(this);
                        _ICONMGR_TASKBARMGR_RUNONCE = true;
                    }
                    else { }
                    def = 3;
                    break;
                case 5:
                    if (_ICONMGR_CLSIDICON_RUNONCE  == false)
                    {
                        sgCombobox3.SelectedIndex = 0;
                        _ICONMGR_CLSIDICON_RUNONCE  = true;
                    }
                    else { }
                    def = 4;
                    break;
            }
            this.sgTabPageControl1.SelectedIndex = def;
            selectfunctioncmd = "SY,1"+","+ secondindex +","+ thridindex;
        }
        public void RightMenuMgr(int sec,int thir=1,string tags="")
        {
            int def = 0;
            switch (sec)
            {
                case 1:
                    if (_RIGHTMENUMGR_RIGHTMENUGROUP_RUNONCE  == false)
                    {
                        int sel = 0;
                        string set = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\settings.sgcf";
                        string op=SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("main", "selectindex", "0", set, false);
                        int.TryParse(op, out sel);
                        sgCombobox1.SelectedIndex = sel;
                       _RIGHTMENUMGR_RIGHTMENUGROUP_RUNONCE  = true;
                    }
                    else { }
                    def = 0;
                    break;
                case 2:
                     if (_RIGHTMENUMGR_CLIPBOARDOPERATE_RUNONCE  == false)
                    {
                        sgCheckBox3.CheckBox_CheckedChangeToEvent = false;
                        bool op = SGSystemStyle.RightMenuMgr.ClipBoredOperate.GetClipboardShellIsRegistry();
                        if (op == true) { sgCheckBox3.CheckState = CheckState.Checked; } else { sgCheckBox3.CheckState = CheckState.Unchecked; }
                        sgCheckBox3.CheckBox_CheckedChangeToEvent = true;
                        SGSystemStyle.RightMenuMgr.ClipBoredOperate.LoadToUI(this);
                       _RIGHTMENUMGR_CLIPBOARDOPERATE_RUNONCE   = true;
                     }
                    else { }
                    def = 1;
                    break;
                case 3:
                    if (_RIGHTMENUMGR_RIGHTMENUSMGR_RUNONCE  == false)
                    {
                        _RIGHTMENUMGR_RIGHTMENUSMGR_RUNONCE = true;
                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadMenus(this);
                    }
                    else { }
                    def = 2;
                    break;
                case 4:
                    if (_RIGHTMENUMGR_RUNCOMMANDS_RUNONCE  == false)
                    {
                        _RIGHTMENUMGR_RUNCOMMANDS_RUNONCE= true;
                        // SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadMenus(this);
                        SGSystemStyle.RightMenuMgr.RunCommands.LoadRunCommands(this);
                    }
                    else { }
                    def = 3;
                    break;
                case 5:
                    def = 4;
                    break;
            }
            selectfunctioncmd = "SY,2" + "," + sec + "," + thir;
            this.sgTabPageControl4.SelectedIndex = def;
        }
        public void Win8Style(int sec, int thir = 1, string tags = "")
        {
            int def = 0;
            switch (sec)
            {
                case 1:
                    if (_WIN8STYLE_STARTCOLOR_RUNONCE == false)
                    {
                        string osv = SGFunction.SystemFunctionAndInformation.GetOSVersion();
                        if (osv == "6.2" || osv == "6.3")
                        {
                            if (osv == "6.3")
                            {
                                flowLayoutPanel_startscreenback_win81.Location = new Point(6, 28);
                                flowLayoutPanel_startscreenback_win81.Visible = true;
                                flowLayoutPanel_startscreenback_win8.Visible = false;
                                MyNormalButton72.BackgroundImage = SGFunction.SystemFunctionAndInformation.GetWallpaper();
                                panel42.Location = new Point(7, 168);
                                panel42.Visible = true;
                                pictureBox48.Visible = flowLayoutPanel2.Visible = numericUpDown1.Visible = false;
                                sgCheckBox5.Visible = true;
                                sgLabel13.Visible = false;
                                //sgLabel9.Text = @"""开始""屏幕上的按钮";
                                SGSystemStyle.Win8Style.GetPowerButtonInStartScreen(this);
                                SGSystemStyle.Win8Style.LoadWin81StartBackStyle(this);
                                SGSystemStyle.Win8Style.SystemStyle_LoadStartScreenColorSettingsInWin81(this, 1);
                                SGSystemStyle.Win8Style.SystemStyle_LoadStartScreenColorSettingsInWin81(this, 2);
                            }
                            else
                            {
                                flowLayoutPanel_startscreenback_win8.Location = new Point(6, 28);
                                flowLayoutPanel_startscreenback_win8.Visible = true;
                                flowLayoutPanel_startscreenback_win81.Visible = false;
                                panel42.Visible = false;
                                pictureBox48.Visible = flowLayoutPanel2.Visible = numericUpDown1.Visible = true;
                                sgCheckBox5.Visible = false;
                                sgLabel13.Visible = true;
                                // sgLabel9.Text = @"""开始""屏幕磁贴行数";
                                SGSystemStyle.Win8Style.SystemStyle_LoadWin8StartSrceenColor(this);
                                SGSystemStyle.Win8Style.LoadWin8StartBackStyle(this);

                            }
                        }
                        else 
                        {
                            //windows 7
                            sgLabel5.Text = "抱歉，该功能仅支持Windows 8以上的操作系统";
                            flowLayoutPanel_startscreenback_win8.Enabled = flowLayoutPanel_startscreenback_win81.Enabled = false;
                            sgLabel7.Visible = false;
                            flowLayoutPanel2.Visible = pictureBox48.Visible = panel42.Visible = sgCheckBox5.Visible = sgLabel13.Visible = numericUpDown1.Visible = MyNormalButton73.Visible = false;
                        }
                        _WIN8STYLE_STARTCOLOR_RUNONCE = true;
                    }
                    else { }
                    def = 0;
                    break;
                case 2:
                    def = 1;
                    break;
                case 3:
                    if (_WIN8STYLE_WINXMENU_RUNONCE  == false)
                    {
                        string osv = SGFunction.SystemFunctionAndInformation.GetOSVersion();
                        if (osv == "6.2" || osv == "6.3")
                        {
                            SGSystemStyle.Win8Style.WinXMenu.SystemStyle_LoadWinXMenu(this);
                        }
                        else
                        {
                            //win7
                            sgLabel16.Text = "抱歉，该功能仅支持Windows 8以上的操作系统";
                            treeView3.Visible = MyNormalButton81.Visible = MyNormalButton137.Visible = MyNormalButton80.Visible = MyNormalButton82.Visible = MyNormalButton74.Visible = MyNormalButton77.Visible = MyNormalButton83.Visible = pictureBox16.Visible = false;
                        }
                       _WIN8STYLE_WINXMENU_RUNONCE  = true;
                    }
                    else { }
                    def = 2;
                    break;
            }
            selectfunctioncmd = "SY,3" + "," + sec + "," + thir;
            this.sgTabPageControl5.SelectedIndex = def;
        }
        public void FileMgr(int secondindex, int thridindex = 1, string tags = "")
        {
            int def = 0;
            switch (secondindex)
            {
                case 1:
                    if (_FILEMGR_FOLDERMGR_RUNONCE == false)
                    {
                        sgCombobox_fm_icons.Items[3] = SGFunction.ProgramInfo.GetMyComputerName();
                    }
                    else { _FILEMGR_FOLDERMGR_RUNONCE = true; }
                    def = 0;
                    break;
                case 2:
                    def = 1;
                    break;
                case 3:
                    def = 2;
                    break;
            }
            selectfunctioncmd = "SY,5" + "," + secondindex + "," + thridindex;
            this.sgTabPageControl7.SelectedIndex = def;
        }

        private void sgItems1_OnChooseItem(object sender, SGItems.ChooseItemEventArgs ce)
        {
            this.Start(ce.Index , 1);
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            //MyFunctions.ProgramAndLinksOperate.PinToStartScreen("E:\\SDCASD.XML", @"F:\桌面\所有操作.lnk", "SDDVD");
            

        }
        private void myChooseBox1_OnCheckedChange(object sender, SGChooseBox.MyEventArgs e)
        {
            //Uri ui = new Uri("ms-appx:///images/logo.png");
            //MessageBox.Show(e.CheckedValue.ToString());
            SGChooseBox M = (SGChooseBox)sender;
            int p = e.CheckedValue;
            //MessageBox.Show(p.ToString());
            if(p==2)
            {
                SGSystemStyle.IconAndLinkMgr.DesktopIconsMgr.ChangeDesktopIconShowType(M.Tag.ToString(), "SHOW");
            }
            else
            {
                SGSystemStyle.IconAndLinkMgr.DesktopIconsMgr.ChangeDesktopIconShowType(M.Tag.ToString(), "HIDE");
            }
        }

        private void myChooseBox7_OnCheckedChange(object sender, SGChooseBox.MyEventArgs e)
        {
            SGChooseBox M = (SGChooseBox)sender;
            int p = e.CheckedValue;
            if (p == 1)
            {
                SGSystemStyle.IconAndLinkMgr.DesktopIconsMgr.ChangePowerIcon(M.Tag.ToString(), "DELETE", sgCheckBox2.Checked, sgCheckBox1.Checked,sgCheckBox8.Checked);
            }
            else
            {
                SGSystemStyle.IconAndLinkMgr.DesktopIconsMgr.ChangePowerIcon(M.Tag.ToString(), "CREATE", sgCheckBox2.Checked, sgCheckBox1.Checked,sgCheckBox8.Checked);
                
            }
        }

        private void MyNormalButton8_Click(object sender, EventArgs e)
        {

        }

        private void sgTabPageControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Start(1, sgTabPageControl1.SelectedIndex + 1);
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            try
           {
                string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
                string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
                string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
                string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
                string IEGUID = "{BDA87F4F-C3AF-4E08-8167-1B10FC09B081}";
                if (listView3.SelectedItems != null)
                {
                    string cfg=SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec","002");
                    string res = "";
                    string iconfile = SGFunction.CommonDialogs.SelectIconDialog("选择一个图标", @"%windir%\system32\imageres.dll,2",out res);
                    if (res== "ok")
                    {
                        int imindex = listView3.SelectedItems[0].ImageIndex;
                        switch (listView3.SelectedItems[0].Group.ToString())
                        {
                            case "桌面图标":
                                
                                switch (listView3.SelectedItems[0].Tag.ToString().ToUpper())
                                {
                                    case "UF":
                                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + UFGUID, "DefaultIcon");
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + UFGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.String);
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + UFGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString);
                                        break;
                                    case "MC":
                                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + MCGUID, "DefaultIcon");
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + MCGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString);
                                        break;
                                    case "NK":
                                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + NKGUID, "DefaultIcon");
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + NKGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString);
                                        break;
                                    case "CP":
                                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + CPGUID, "DefaultIcon");
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + CPGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString);
                                        break;
                                    case "IE":
                                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + IEGUID, "DefaultIcon");
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + IEGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString);
                                        break;
                                    case "RB_D":
                                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID, "DefaultIcon");
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString);
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Empty", iconfile, RegistryValueKind.ExpandString);
                                        break;
                                    case "RB_F":
                                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID, "DefaultIcon");
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Full", iconfile, RegistryValueKind.ExpandString);
                                        break;
                                }
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(listView3.SelectedItems[0].Tag.ToString().ToUpper(), "Icon", iconfile, "config", false, cfg);
                                break;
                            case "驱动器":
                                if (iconfile != "")
                                {
                                    string shell_index = listView3.SelectedItems[0].Tag.ToString().ToUpper();
                                    SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer", "Shell Icons");
                                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_index, iconfile, RegistryValueKind.ExpandString);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Drive_" + listView3.SelectedItems[0].Tag.ToString().ToUpper(), "Icon", iconfile, "config", false, cfg);
                                }
                                break;
                            case "文件(夹)":
                                switch (listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(0, 1))
                                {
                                    case "S":
                                        string shell_index = SGFunction.StringOperate.ConvertToInt32(listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(1, 2), 0).ToString();
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_index, iconfile, RegistryValueKind.ExpandString);
                                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Folder_Index_" + shell_index, "Icon", iconfile, "config", false, cfg);
                                        break;
                                    case "G":
                                        string guid = listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(1, listView3.SelectedItems[0].Tag.ToString().Length - 1);
                                        //MessageBox.Show(guid);
                                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + guid, "DefaultIcon");
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + guid + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString);
                                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Folder_GUID_" + guid, "Icon", iconfile, "config", false, cfg);
                                        break;
                                }
                                break;
                            case "其他图标":
                                string shell_indexO = listView3.SelectedItems[0].Tag.ToString().ToUpper();
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_indexO, iconfile, RegistryValueKind.ExpandString);
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Other_" + shell_indexO, "Icon", iconfile, "config", false, cfg);
                                break;
                        }
                        imageList_basicicon.Images[imindex] = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(iconfile, iconfile);
                        SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("修改系统图标成功！" + "\r\n" + "部分图标需要您手动刷新才能生效",5);
                    }
                }
           }
            catch { }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView3.SelectedItems != null)
                {
                    if (listView3.SelectedItems[0].Group.ToString() == "桌面图标")
                    {
                        MyNormalButton3.Enabled = true;
                        sgRightMenus_edit_systemicons.Items[1].Enabled = true;
                    }
                    else
                    {
                        MyNormalButton3.Enabled = false;
                        sgRightMenus_edit_systemicons.Items[1].Enabled = false;
                    }
                    MyNormalButton4.Enabled = false;
                    sgRightMenus_edit_systemicons.Items[2].Enabled = false;
                    if (listView3.SelectedItems[0].Text == "快捷方式箭头")
                    {
                        MyNormalButton4.Enabled = true;
                        sgRightMenus_edit_systemicons.Items[1].Enabled =false;
                        sgRightMenus_edit_systemicons.Items[2].Enabled = true;
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "002");
                string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
                string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
                string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
                string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
                string IEGUID = "{BDA87F4F-C3AF-4E08-8167-1B10FC09B081}";
                if (listView3.SelectedItems != null)
                {
                    
                    string res = "";
                    string name = SGFunction.CommonDialogs.InputDialog("输入图标的名称", "用于标识桌面图标的文字","我的桌面",false,"一个名字",out res);
                    if (res == "ok")
                    {
                        switch (listView3.SelectedItems[0].Tag.ToString().ToUpper())
                        {
                            case "UF":
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID",UFGUID);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + UFGUID, "", name, RegistryValueKind.String);
                                break;
                            case "MC":
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", MCGUID);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + MCGUID, "", name, RegistryValueKind.String);
                                break;
                            case "IE":
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", IEGUID);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + IEGUID, "", name, RegistryValueKind.String);
                                break;
                            case "CP":
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", CPGUID);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + CPGUID, "", name, RegistryValueKind.String);
                                break;
                            case "NK":
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", NKGUID);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + NKGUID, "", name, RegistryValueKind.String);
                                break;
                            default:
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", RBGUID);
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID, "", name, RegistryValueKind.String);
                                break;
                        }
                        
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(listView3.SelectedItems[0].Tag.ToString().ToUpper(), "Text",name, "config", false, cfg);
                        listView3.SelectedItems[0].Text = name;
                        SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("修改系统文字成功！", 5);
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton4_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems != null)
            {
                try
                {
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "002");
                    SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer", "Shell Icons");
                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "29", @"%SystemRoot%\System32\Imageres.dll,196", RegistryValueKind.ExpandString);
                   imageList_basicicon.Images[listView3.Items[24].ImageIndex]=SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(@"%SystemRoot%\System32\Imageres.dll,196",@"%SystemRoot%\System32\Imageres.dll,196");
                   SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Other_" + "29", "Icon", @"%SystemRoot%\System32\Imageres.dll,196", "config", false, cfg);
                   SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("使用空图标成功！", 5);
                    SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                }
                catch { }
            }
        }

        private void MyNormalButton5_Click(object sender, EventArgs e)
        {
            try
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "002");
                string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
                string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
                string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
                string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
                string IEGUID = "{BDA87F4F-C3AF-4E08-8167-1B10FC09B081}";
                if (listView3.SelectedItems != null)
                {
                    string res = SGFunction.CommonDialogs.MessageDialog_MustClick("继续?", "您确定要还原当前图标的设置?", "继续", "取消", "b2", "ques");
                    if (res == "b1")
                    {
                        switch (listView3.SelectedItems[0].Group.ToString())
                        {
                            case "桌面图标":
                                string def_ico = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("DESK_" + listView3.SelectedItems[0].Tag.ToString(), "ORG_ICON_DEFAULT", "", cfg);
                                string def_name = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("DESK_" + listView3.SelectedItems[0].Tag.ToString(), "ORG_name", "", cfg);
                                switch (listView3.SelectedItems[0].Tag.ToString().ToUpper())
                                {
                                    case "UF":
                                        SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", UFGUID);
                                        break;
                                    case "NK":
                                        SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", NKGUID);
                                        break;
                                    case "CP":
                                        SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", CPGUID);
                                        break;
                                    case "IE":
                                        SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", IEGUID);
                                        break;
                                    case "MC":
                                        SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", MCGUID);
                                        break;
                                    case "RB_D":
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "", def_ico, RegistryValueKind.ExpandString);
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Empty", def_ico, RegistryValueKind.ExpandString);
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID, "", @"", RegistryValueKind.ExpandString);
                                        break;
                                    case "RB_F":
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Full", def_ico, RegistryValueKind.ExpandString);
                                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID, "", @"", RegistryValueKind.ExpandString);
                                        break;
                                }
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(listView3.SelectedItems[0].Tag.ToString().ToUpper(), "Icon", "", "config", false, cfg);
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(listView3.SelectedItems[0].Tag.ToString().ToUpper(), "Text", "", "config", false, cfg);
                                break;
                            case "驱动器":
                                string shell_index = listView3.SelectedItems[0].Tag.ToString().ToUpper();
                                SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_index);
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Drive_" + listView3.SelectedItems[0].Tag.ToString().ToUpper(), "Icon", "", "config", false, cfg);
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Drive_" + listView3.SelectedItems[0].Tag.ToString().ToUpper(), "Text", "", "config", false, cfg);
                                break;
                            case "文件(夹)":
                                switch (listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(0, 1))
                                {
                                    case "S":
                                        int p = 0;
                                        int.TryParse(listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(1, 2),out p);
                                        string shell_indexS = p.ToString();
                                        SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_indexS);
                                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Folder_Index_" + shell_indexS, "Icon", "", "config", false, cfg);
                                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Folder_Index_" + shell_indexS, "Text", "", "config", false, cfg);
                                        break;
                                    case "G":
                                        string guid = listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(1, listView3.SelectedItems[0].Tag.ToString().Length - 1);
                                        SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", guid);
                                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Folder_GUID_" + guid, "Icon", "", "config", false, cfg);
                                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Folder_GUID_" + guid, "Text", "", "config", false, cfg);
                                        break;
                                }
                                break;
                            case "其他图标":
                                string shell_indexO = listView3.SelectedItems[0].Tag.ToString().ToUpper();
                                SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_indexO);
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Other_" + shell_indexO, "Icon","", "config", false, cfg);
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Other_" + shell_indexO, "Text", "", "config", false, cfg);
                                break;
                        }
                        //imageList_basicicon.Images[imindex] = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile, iconfile);
                        SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                        SGSystemStyle.IconAndLinkMgr.SystemIconsMgr.LoadSystemIcon_Basic(listView3, imageList_basicicon);
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("还原系统图标成功！", 5);
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton6_Click(object sender, EventArgs e)
        {
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("继续?", "您确定要还原所有的图标的设置?", "继续", "取消", "b2", "ques");
            if (res == "b1")
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "002");
                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(cfg);
                string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
                string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
                string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
                string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
                string IEGUID = "{BDA87F4F-C3AF-4E08-8167-1B10FC09B081}";
                SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", UFGUID);
                SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", NKGUID);
                SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", CPGUID);
                SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", IEGUID);
                SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", MCGUID);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "", @"%SystemRoot%\System32\Imageres.dll,50", RegistryValueKind.ExpandString);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Empty", @"%SystemRoot%\System32\Imageres.dll,50", RegistryValueKind.ExpandString);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Full", @"%SystemRoot%\System32\Imageres.dll,49", RegistryValueKind.ExpandString);
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write",Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID, "", @"", RegistryValueKind.ExpandString);
                for (int a = 7; a <= 15; a = a + 1)
                {
                    string index = listView3.Items[a].Tag.ToString();
                    SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", index);
                }
                for (int b = 16; b <= 23; b = b + 1)
                {
                    switch (listView3.Items[b].Tag.ToString().ToUpper().Substring(0, 1))
                    {
                        case "S":
                            int p=0;
                            int.TryParse(listView3.Items[b].Tag.ToString().ToUpper().Substring(1, 2),out p);
                            string shell_indexS = p.ToString();
                            SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_indexS);
                            break;
                        case "G":
                            string guid = listView3.Items[b].Tag.ToString().ToUpper().Substring(1, listView3.Items[b].Tag.ToString().Length - 1);
                            SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", guid);
                            break;
                    }
                }
                SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "29");
                SGFunction.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "0");
                SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                SGSystemStyle.IconAndLinkMgr.SystemIconsMgr.LoadSystemIcon_Basic(listView3, imageList_basicicon);
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("还原所有系统图标成功！", 5);
            }
            
        }


        private void sgTextBox3_TextChanged(object sender, EventArgs e)
        {
            if(sgTextBox3.Text =="")
            {
                this.listView1.Visible = true;
                this.listView_findinoldlist.Visible = false;
            }
            else
            {
                SGSystemStyle.IconAndLinkMgr.FileTypeMgr.FindExtNames(this, sgTextBox3.Text);
                this.listView_findinoldlist.Location = this.listView1.Location;
                this.listView1.Visible = false;
                this.listView_findinoldlist.Visible = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(listView1.SelectedItems.Count ==1)
                {
                    label19.Text =listView1.SelectedItems[0].Text;
                    label22.Text = listView1.SelectedItems[0].SubItems[1].Text;
                    int imindex = listView1.SelectedItems[0].ImageIndex;
                    pictureBox12.Image = imageList_filetype.Images[imindex];
                }
            }
            catch { }
        }

        private void listView_findinoldlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (listView_findinoldlist.SelectedItems.Count == 1)
                {
                    label19.Text = listView_findinoldlist.SelectedItems[0].Text;
                    label22.Text = listView_findinoldlist.SelectedItems[0].SubItems[1].Text;
                    int imindex = listView_findinoldlist.SelectedItems[0].ImageIndex;
                    pictureBox12.Image = imageList_findlist.Images[imindex];
                }
            }
            catch { }
        }

        private void MyNormalButton13_Click(object sender, EventArgs e)
        {
            if (label19.Text != "选择一个项目以查看。")
            {
                string res;
                string n = SGFunction.CommonDialogs.InputDialog("输入一个新的注释", @"例如""我的文件""", label22.Text, false, @"例如""我的文件""", out res);
                if (res == "ok")
                {
                    string cfg1 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "003");
                    string org = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("editext", "exts", "", cfg1, false);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("EditExt", "exts",org+"|"+ label19.Text, "config", false, cfg1);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(label19.Text, "info", n, "config", false, cfg1);
                    SGSystemStyle.IconAndLinkMgr.FileTypeMgr.ChangeInfo(n, label19.Text);
                    label22.Text = n;
                    if (listView_findinoldlist.Visible == true)
                    {
                        foreach (ListViewItem o in listView_findinoldlist.Items)
                        {
                            if (o.Text == label19.Text)
                            {
                                o.SubItems[1].Text = n;
                            }
                        }
                    }
                    foreach (ListViewItem o in listView1.Items)
                    {
                        if (o.Text == label19.Text)
                        {
                            o.SubItems[1].Text = n;
                        }
                    }
                }
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("请从左边选择一个项目吧!", 1);
            }
        }

        private void MyNormalButton7_Click(object sender, EventArgs e)
        {
            if (label19.Text != "选择一个项目以查看。")
            {
                string res;
                string j = SGFunction.CommonDialogs.SelectIconDialog("请选择一个图标", "%systemroot%\\system32\\imageres.dll,2", out res);
                if (res == "ok")
                {
                    Image r;
                    SGSystemStyle.IconAndLinkMgr.FileTypeMgr.ChangeIcon(j, label19.Text, out r);
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "003");
                    string org = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("editext", "exts", "", cfg, false);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("EditExt", "exts", org+"|"+label19.Text, "config", false, cfg);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(label19.Text, "icon", j, "config", false, cfg);
                    pictureBox12.Image = r;
                    if (listView_findinoldlist.Visible == true)
                    {
                        foreach (ListViewItem o in listView_findinoldlist.Items)
                        {
                            if (o.Text == label19.Text)
                            {
                                listView_findinoldlist.LargeImageList.Images[o.ImageIndex] = r;
                            }
                        }
                    }
                    foreach (ListViewItem o in listView1.Items)
                    {
                        if (o.Text == label19.Text)
                        {
                            listView1.LargeImageList.Images[o.ImageIndex] = r;
                        }
                    }
                }
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("请从左边选择一个项目吧!", 1);
            }
        }

        private void MyNormalButton9_Click(object sender, EventArgs e)
        {
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup", "003") + "\\" + "ExtensionBackup" + ".sgcf";
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == true)
            {
                if (label19.Text != "请从左边选择一个项目吧!")
                {
                    string j = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(label19.Text, "icon", "", cfg);
                    if(j!="")
                    {
                        string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要恢复默认的图标?", "恢复默认的图标有可能会替换您先前的设置", "确定", "取消", "b2", "ques");
                        if (res == "b1")
                        {
                            string cfg1 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "003");
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(label19.Text, "icon", j, "config", false, cfg1);
                            Image r;
                            SGSystemStyle.IconAndLinkMgr.FileTypeMgr.SetDefaultIcon(label19.Text, j, out r);
                            pictureBox12.Image = r;
                            if (listView_findinoldlist.Visible == true)
                            {
                                foreach (ListViewItem o in listView_findinoldlist.Items)
                                {
                                    if (o.Text == label19.Text)
                                    {
                                        listView_findinoldlist.LargeImageList.Images[o.ImageIndex] = r;
                                    }
                                }
                            }
                            foreach (ListViewItem o in listView1.Items)
                            {
                                if (o.Text == label19.Text)
                                {
                                    listView1.LargeImageList.Images[o.ImageIndex] = r;
                                }
                            }
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"成功恢复默认的图标!", 1);
                            SGFunction.SystemFunctionAndInformation.UpdateDesktop();
                        }
                    }
                    else
                    {
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"错误 : 没有找到指定的信息", 1);
                    }
                }
                else
                {
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("请从左边选择一个项目吧!", 1);
                }
            }
            else { SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"错误 : 没有找到备份的文件"+"\r\n"+@""""+cfg +@"""", 1); }
            
        }

        private void MyNormalButton12_Click(object sender, EventArgs e)
        {
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup", "003") + "\\" + "ExtensionBackup" + ".sgcf";
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == true)
            {
                if (label19.Text != "请从左边选择一个项目吧!")
                {
                    string j = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(label19.Text, "info", "", cfg);
                    if (j != "")
                    {
                        string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要恢复默认的文件描述?", "恢复默认的文件描述有可能会替换您先前的设置", "确定", "取消", "b2", "ques");
                        if (res == "b1")
                        {
                            string cfg1 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "003");
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(label19.Text, "info", j, "config", false, cfg1);
                            SGSystemStyle.IconAndLinkMgr.FileTypeMgr.SetDefaultInfo(label19.Text, j);
                            label22.Text = j;
                            if (listView_findinoldlist.Visible == true)
                            {
                                foreach (ListViewItem o in listView_findinoldlist.Items)
                                {
                                    if (o.Text == label19.Text)
                                    {
                                        o.SubItems[1].Text = j;
                                    }
                                }
                            }
                            foreach (ListViewItem o in listView1.Items)
                            {
                                if (o.Text == label19.Text)
                                {
                                    o.SubItems[1].Text = j;
                                }
                            }
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"成功恢复默认的文件描述!", 1);
                            SGFunction.SystemFunctionAndInformation.UpdateDesktop();
                        }
                    }
                    else
                    {
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"错误 : 没有找到指定的信息", 1);
                    }
                }
                else
                {
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("请从左边选择一个项目吧!", 1);
                }
            }
            else { SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"错误 : 没有找到备份的文件" + "\r\n" + @"""" + cfg + @"""", 1); }
        }

        private void sgChooseBox11_OnCheckedChange(object sender, SGChooseBox.MyEventArgs e)
        {
            switch(e.CheckedValue)
            {
                case 1:
                    SGSystemStyle.IconAndLinkMgr.TaskBarMgr.SetTaskBarIconsShowType(((SGChooseBox)sender).Tag.ToString(), "DELETE",sgCheckBox4.Checked );
                    break;
                case 2:
                    SGSystemStyle.IconAndLinkMgr.TaskBarMgr.SetTaskBarIconsShowType(((SGChooseBox)sender).Tag.ToString(), "NEW");
                    break;
            }
        }

        private void MyNormalButton10_Click(object sender, EventArgs e)
        {
            SGSystemStyle.IconAndLinkMgr.TaskBarMgr.SetTaskBarIcons_OpenFile();
        }

        private void MyNormalButton11_Click(object sender, EventArgs e)
        {
            SGSystemStyle.IconAndLinkMgr.TaskBarMgr.SetTaskBarIcons_Folder();
        }

        private void MyNormalButton14_Click(object sender, EventArgs e)
        {
            SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("固定您最喜欢的网站到任务栏", new SGUserControl_PinURLToTaskBar());
        }

        private void MyNormalButton15_Click(object sender, EventArgs e)
        {
            string psv=SGFunction.SystemFunctionAndInformation.GetOSVersion();
            switch (psv)
            {
                case "6.2":
                    string res = "";
                    string[] p = SGFunction.CommonDialogs.ShowChooseModernAppDialog("选择一个Modern程序", out res);
                    if (res == "ok")
                    {
                        string id = p[0];
                        string name = p[1];
                        string ico = p[2];
                        string link = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\" + name + ".lnk";
                        SGFunction.SystemFunctionAndInformation.CreateLink(link, "explorer.exe", "shell:::{4234d49b-0245-4df3-b780-3893943456e1}\\" + id, name, ico);
                        SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, link);
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(link);
                    }
                    break;
                case "6.4":
                case "10.0":
                case "6.3":
                    string fol = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("helper") + "\\HowToPinAppToTaskbar";
                    if(psv=="10.0" || psv=="6.4")
                    {
                        fol = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("helper") + "\\HowToPinAppToTaskbar_win10";
                        bool jj;
                        string tryset = SGFunction.CommonDialogs.ShowHelpUserToDoDialog(fol, out jj, false);
                        switch (tryset.ToLower())
                        {
                            case "b2":
                                string res2 = "";
                                string[] p2 = SGFunction.CommonDialogs.ShowChooseModernAppDialog("选择一个Modern程序", out res2);
                                if (res2 == "ok")
                                {
                                    string id2 = p2[0];
                                    string name2 = p2[1];
                                    string ico2 = p2[2];
                                    string link2 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\" + name2 + ".lnk";
                                    SGFunction.SystemFunctionAndInformation.CreateLink(link2, "explorer.exe", "shell:::{4234d49b-0245-4df3-b780-3893943456e1}\\" + id2, name2, ico2);
                                    SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, link2);
                                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(link2);
                                }
                                break;
                        }
                    }
                    else
                    {
                        string bu = SGFunction.SystemFunctionAndInformation.GetOSBuildVersion();
                        int build;
                        int.TryParse(bu, out build);
                        if (build >= 16610)
                        {
                            bool jj;
                            string tryset = SGFunction.CommonDialogs.ShowHelpUserToDoDialog(fol, out jj, false);
                            switch (tryset.ToLower())
                            {
                                case "b2":
                                    string res2 = "";
                                    string[] p2 = SGFunction.CommonDialogs.ShowChooseModernAppDialog("选择一个Modern程序", out res2);
                                    if (res2 == "ok")
                                    {
                                        string id2 = p2[0];
                                        string name2 = p2[1];
                                        string ico2 = p2[2];
                                        string link2 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\" + name2 + ".lnk";
                                        SGFunction.SystemFunctionAndInformation.CreateLink(link2, "explorer.exe", "shell:::{4234d49b-0245-4df3-b780-3893943456e1}\\" + id2, name2, ico2);
                                        SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, link2);
                                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(link2);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            string res1 = "";
                            string[] p1 = SGFunction.CommonDialogs.ShowChooseModernAppDialog("选择一个Modern程序", out res1);
                            if (res1 == "ok")
                            {
                                string id1 = p1[0];
                                string name1 = p1[1];
                                string ico1 = p1[2];
                                string link1 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("temp") + "\\" + name1 + ".lnk";
                                SGFunction.SystemFunctionAndInformation.CreateLink(link1, "explorer.exe", "shell:::{4234d49b-0245-4df3-b780-3893943456e1}\\" + id1, name1, ico1);
                                SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, link1);
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(link1);
                            }
                        }
                    }
                    
                    break;
            }
        }

        private void SGForm_Function_SystemStyle_SizeChanged(object sender, EventArgs e)
        {
            panel_top.Size = new Size(this.Size.Width, panel_top.Size.Height);
            MyNormalButton_close.Location = new Point(this.panel_top.Size.Width - MyNormalButton_close.Size.Width-189, 0);
            MyNormalButton_min.Location = new Point(MyNormalButton_close.Location.X - MyNormalButton_min.Size.Width, 0);
            MyNormalButton_moresetting.Location = new Point(MyNormalButton_min.Location.X - MyNormalButton_moresetting.Size.Height, 0);
            myNormalButton_changeskin.Location = new Point(MyNormalButton_moresetting.Location.X - myNormalButton_changeskin.Size.Width, 0);
        }

        private void sgCombobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups");
            string txt = Properties.Resources.RightMenuGroup_public;
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_public.sgcf";
            switch(sgCombobox1.SelectedIndex)
            {
                case 0:
                    cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_public.sgcf";
                    break;
                case 1:
                    txt = Properties.Resources.RightMenuGroup_internet;
                    cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_internet.sgcf";
                    break;
                case 2:
                    txt = Properties.Resources.RightMenuGroup_media;
                    cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_media.sgcf";
                    break;
                case 3:
                    txt = Properties.Resources.RightMenuGroup_pro;
                    cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_pro.sgcf";
                    break;
                case 4:
                    txt = Properties.Resources.RightMenuGroup_powermgr;
                    cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_powermgr.sgcf";
                    break;
                case 5:
                    txt = Properties.Resources.RightMenuGroup_win8;
                    cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_win8.sgcf";
                    break;
            }
            string set = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\settings.sgcf";
            //SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(cfg);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("main", "selectindex", sgCombobox1.SelectedIndex.ToString(), "config", false, set);
            if (System.IO.File.Exists(cfg) == false)
            {
                SGFunction.DataOperate.SaveStringToTextFile(cfg, txt);
                if (sgCombobox1.SelectedIndex == 0 || sgCombobox1.SelectedIndex == 4)
                {
                    if (sgCombobox1.SelectedIndex == 0)
                    {
                        string write = "shutdown.exe -s -t 0 -f";
                        if (SGFunction.SystemFunctionAndInformation.GetOSVersion() != "6.1") { write = "shutdown.exe -s -hybrid -t 0 -f"; }
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("COMMAND13", "COMMAND", write, "RightMenuGroup", false, cfg);
                    }
                    else
                    {
                        string write1 = "shutdown.exe -s -t 0 -f";
                        if (SGFunction.SystemFunctionAndInformation.GetOSVersion() != "6.1") { write1 = "shutdown.exe -s -hybrid -t 0 -f"; }
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command3", "Command", write1, "RightMenuGroup", false, cfg);
                    }

                }
            }
            sgCombobox1.Tag = cfg;
            SGSystemStyle.RightMenuMgr.RightMenuGroup.LoadConfigToTreeview(this, cfg);
        }

        private void MyNormalButton18_Click(object sender, EventArgs e)
        {
            try
            {
                if(sgTreeView_rightmenugroup.SelectedNode  !=null)
                {
                    string type = sgTreeView_rightmenugroup.SelectedNode.Tag.ToString();
                    if(type !="MAIN")
                    {
                        string cfg=sgCombobox1.Tag.ToString();
                        string fgf = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + type, "isfengefu", "", cfg, true);
                        string res = "exit";
                        if(fgf.ToUpper() !="T")
                        {
                            string n = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + type, "name", "", cfg, true);
                            string i = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + type, "icon", "", cfg, true);
                            string c = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + type, "command", "", cfg, true);
                            bool ad=false;
                            string A = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + type, "runasadmin", "F", cfg, true);
                            if(A.ToUpper()=="T"){ad =true;}
                            SGUserControl_EditRightMenu d = new SGUserControl_EditRightMenu(n, i, c, type, cfg,ad,false);
                            res=SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑右键菜单", d).ToString();
                        }
                        else
                        {
                            SGUserControl_EditRightMenu d = new SGUserControl_EditRightMenu("", "", "", type, cfg, false, true);
                            res = SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑右键菜单", d).ToString();
                        }
                        //重新加载
                        string newname = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + type, "name", "", cfg, true);
                        string newico = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + type, "icon", "", cfg, true);
                        string newtype = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + type, "isfengefu", "", cfg, true);
                        if(res =="ok")
                        {
                            if (newtype == "T") { newname = "分隔符"; newico = SGFunction.Resources.GetIconPath("fengefu"); }
                            sgTreeView_rightmenugroup.SelectedNode.Text  = newname;
                            Bitmap BM=SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(newico);
                            imageList_rightmenugroup.Images[sgTreeView_rightmenugroup.SelectedNode.ImageIndex] =BM ;
                        }
                    }
                    else
                    {
                        //main
                        string def = sgTreeView_rightmenugroup.Nodes[0].Text;
                        string res="";
                        def=SGFunction.CommonDialogs.InputDialog("新的菜单组名称", "更改菜单组的名称", def, false, "请指定一个新的名称",out res);
                        if(res=="ok")
                        {
                            sgTreeView_rightmenugroup.Nodes[0].Text = def;
                            string cfg = sgCombobox1.Tag.ToString();
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "Name", def, "RightMenuGroup", false, cfg);
                        }
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton16_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgTreeView_rightmenugroup.Nodes.Count == 1)
                {
                    int count = sgTreeView_rightmenugroup.Nodes[0].Nodes.Count;
                    if(count>=16)
                    {
                        SGFunction.CommonDialogs.MessageDialog_MustClick("不能添加菜单哦!", "由于系统的限制，单组右键菜单组中的菜单不能超过16个。但您可以通过删除某些不要的菜单来添加菜单", "", "确定", "b2","error");
                    }
                    else
                    {
                        string cfg=sgCombobox1.Tag.ToString();
                        string res = "exit";
                        string c = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", cfg, false);
                        int cmd_count;
                        int.TryParse(c, out cmd_count);
                        SGUserControl_EditRightMenu d = new SGUserControl_EditRightMenu("我的菜单", @"%windir%\system32\imageres.dll,11", "", (cmd_count + 1).ToString(), cfg, false, false);
                        res = SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("添加右键菜单", d).ToString();
                        //完成         
                        if (res == "ok")
                        {
                            string regname = "SystemGear." + SGFunction.SystemFunctionAndInformation.GetDateAndTime(); ;
                            string type = (cmd_count + 1).ToString();
                            string newname = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + type, "name", "", cfg, true);
                            string newico = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + type, "icon", "", cfg, true);
                            string newtype = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + type, "isfengefu", "", cfg, true);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", (cmd_count + 1).ToString(), "RightMenuGroup", false, cfg);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command"+(cmd_count+1).ToString(), "RegName", regname, "RightMenuGroup", false, cfg);
                            if (newtype == "T") { newname = "分隔符"; newico = SGFunction.Resources.GetIconPath("fengefu"); }
                            Bitmap BM = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(newico);
                            imageList_rightmenugroup.Images.Add(BM);
                            sgTreeView_rightmenugroup.Nodes[0].Nodes.Add(newname).ImageIndex = imageList_rightmenugroup.Images.Count - 1;
                            sgTreeView_rightmenugroup.Nodes[0].Nodes[sgTreeView_rightmenugroup.Nodes[0].Nodes.Count - 1].SelectedImageIndex = imageList_rightmenugroup.Images.Count - 1;
                            sgTreeView_rightmenugroup.Nodes[0].Nodes[sgTreeView_rightmenugroup.Nodes[0].Nodes.Count - 1].Tag = type.ToString();
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void MyNormalButton17_Click(object sender, EventArgs e)
        {
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要删除这个菜单?", "删除这个菜单会使您的部分设置丢失。", "确定", "取消", "b2", "ques");
            if(res=="b1")
            {
               try
              {
                    if (sgTreeView_rightmenugroup.Nodes.Count == 1 && sgTreeView_rightmenugroup.SelectedNode != null)
                    {
                        if (sgTreeView_rightmenugroup.SelectedNode.Tag.ToString() != "MAIN")
                        {
                                string cfg = sgCombobox1.Tag.ToString();
                                string count = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", cfg, false);
                                int SaveCommandItems;
                                int.TryParse(count, out SaveCommandItems);
                                SaveCommandItems = SaveCommandItems - 1;
                                string[] SaveCommand_Name = new string[SaveCommandItems];
                                string[] SaveCommand_Icon = new string[SaveCommandItems];
                                string[] SaveCommand_Command = new string[SaveCommandItems];
                                string[] SaveCommand_RegName = new string[SaveCommandItems];
                                string[] SaveCommand_RunAsAdmin = new string[SaveCommandItems];
                                string[] SaveCommand_IsFenGeFu = new string[SaveCommandItems];
                                int deleteindex = sgTreeView_rightmenugroup.SelectedNode.ImageIndex;
                                int c = 1;
                                for (int y = 1; y <= SaveCommandItems + 1; y = y + 1)
                                {
                                    if (y != deleteindex)
                                    {
                                        SaveCommand_RegName[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "regname", "", cfg, false);
                                        SaveCommand_Name[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "name", "", cfg, false);
                                        SaveCommand_Icon[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "icon", "", cfg, false);
                                        SaveCommand_Command[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "command", "", cfg, false);
                                        SaveCommand_RunAsAdmin[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "runasadmin", "", cfg, false);
                                        SaveCommand_IsFenGeFu[y - c] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "isfengefu", "", cfg, false);
                                    }
                                    else
                                    {
                                        c = c + 1;
                                    }
                                }
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", SaveCommandItems.ToString(), "RightMenuGroup", false, cfg);
                                for (int g = 1; g <= SaveCommand_Name.Length; g = g + 1)
                                {
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "RegName", SaveCommand_RegName[g - 1].ToString(), "RightMenuGroup", false, cfg);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Name", SaveCommand_Name[g - 1].ToString(), "RightMenuGroup", false, cfg);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Icon", SaveCommand_Icon[g - 1].ToString(), "RightMenuGroup", false, cfg);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Command", SaveCommand_Command[g - 1].ToString(), "RightMenuGroup", false, cfg);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "RunAsAdmin", SaveCommand_RunAsAdmin[g - 1].ToString(), "RightMenuGroup", false, cfg);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "IsFenGeFu", SaveCommand_IsFenGeFu[g - 1].ToString(), "RightMenuGroup", false, cfg);
                                }
                                SGSystemStyle.RightMenuMgr.RightMenuGroup.LoadConfigToTreeview(this, cfg);
                        }
                    }
                }
                catch { }
            }
        }

        private void MyNormalButton19_Click(object sender, EventArgs e)
        {
            try
            {
                string cfg = sgCombobox1.Tag.ToString();
                if(System.IO.File.Exists(cfg)==true)
                {
                    SGSystemStyle.RightMenuMgr.RightMenuGroup.CreateRightMenuGroup(cfg);
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功生成了这组菜单", 2);
                }
            }
            catch { }
        }

        private void MyNormalButton92_Click(object sender, EventArgs e)
        {
            string cfg = sgCombobox1.Tag.ToString();
            if (File.Exists(cfg) == true)
            {
                string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要删除这组菜单吗?", "您确定要删除这组菜单吗?删除后，您不能在右键菜单中使用这些命令。", "确定", "取消", "b2", "ques");
                if (res == "b1")
                {
                    string MainName = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "regname", "", cfg, false);
                    string c = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", cfg, false);
                    SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"*\Shell", MainName);
                    SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\background\shell", MainName);
                    SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\shell", MainName);
                    SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"LibraryFolder\background\shell", MainName);
                    int CommandsNum;
                    int.TryParse(c, out CommandsNum);
                    for (int p = 1; p <= CommandsNum; p = p + 1)
                    {
                        string CMDREGName = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "regname", "", cfg, false);
                        SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell", CMDREGName);
                    }
                    string cfg1 = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("srec", "005");
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("configfile", "file", "", "config", false, cfg1);
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功删除这组菜单", 2);
                }
            }
        }

        private void MyNormalButton20_Click(object sender, EventArgs e)
        {
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要还原这组菜单吗?", "您确定要还原这组菜单吗?还原后，您之前的编辑、添加或删除的菜单都将会还原。", "确定", "取消", "b2", "ques");
            if(res=="b1")
            {
                SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups");
                string txt = Properties.Resources.RightMenuGroup_public;
                string cfg = cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_public.sgcf";
                switch(sgCombobox1.SelectedIndex )
                {
                    case 0:
                        txt = Properties.Resources.RightMenuGroup_public;
                        cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_public.sgcf";
                        break;
                    case 1:
                        txt = Properties.Resources.RightMenuGroup_internet;
                        cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_internet.sgcf";
                        break;
                    case 2:
                        txt = Properties.Resources.RightMenuGroup_media;
                        cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_media.sgcf";
                        break;
                    case 3:
                        txt = Properties.Resources.RightMenuGroup_pro;
                        cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_pro.sgcf";
                        break;
                    case 4:
                        txt = Properties.Resources.RightMenuGroup_powermgr;
                        cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_powermgr.sgcf";
                        break;
                    case 5:
                        txt = Properties.Resources.RightMenuGroup_win8;
                        cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_win8.sgcf";
                        break;
                }
                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(cfg);
                SGFunction.DataOperate.SaveStringToTextFile(cfg, txt);
                if (sgCombobox1.SelectedIndex == 0 || sgCombobox1.SelectedIndex == 4)
                {
                    if (sgCombobox1.SelectedIndex == 0)
                    {
                        string write = "shutdown.exe -s -t 0 -f";
                        if (SGFunction.SystemFunctionAndInformation.GetOSVersion() != "6.1") { write = "shutdown.exe -s -hybrid -t 0 -f"; }
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("COMMAND13", "COMMAND", write, "RightMenuGroup", false, cfg);
                    }
                    else
                    {
                        string write1 = "shutdown.exe -s -t 0 -f";
                        if (SGFunction.SystemFunctionAndInformation.GetOSVersion() != "6.1") { write1 = "shutdown.exe -s -hybrid -t 0 -f"; }
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command3", "Command", write1, "RightMenuGroup", false, cfg);
                    }

                }
                SGSystemStyle.RightMenuMgr.RightMenuGroup.LoadConfigToTreeview(this, cfg);
            }
        }

        private void sgTabPageControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Start(2, sgTabPageControl4.SelectedIndex + 1);
        }

        private void MyNormalButton25_Click(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellSGProgram("CLIPMGR", false, false, true, "/se");
        }

        private void MyNormalButton_clipsave_Click(object sender, EventArgs e)
        {
            string filename = "";
            DialogResult res=DialogResult.Cancel;
            System.Drawing.Imaging.ImageFormat imgformt=System.Drawing.Imaging.ImageFormat.Png;
            switch(MyNormalButton_clipsave.Text)
            {
                case "保存为图片":
                    filename=SGFunction.CommonDialogs.SaveFileDialog_OutResult("保存图片的位置", "PNG文件(*.png)|*.png|JPG 文件(*.jpg)|*.jpg|BMP 格式(*.bmp)|*.bmp|GIF 格式(*.gif)|*.gif",".png",out res,"来自剪切板的图片"+SGFunction.SystemFunctionAndInformation.GetDateAndTime());
                    if (res ==DialogResult.OK ) 
                    {
                        string ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(filename);
                        switch(ext.ToUpper())
                        {
                            case "JPG":
                                imgformt = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "BMP":
                                imgformt = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "GIF":
                                imgformt = System.Drawing.Imaging.ImageFormat.Gif;
                                break;
                        }
                        SGFunction.ImageAndIconOperate.SaveImageAsFile(pictureBox_clip.Image, imgformt, pictureBox_clip.Image.Size.Width, pictureBox_clip.Image.Size.Height, filename);
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("保存图片成功", 2); 
                    }
                    break;
                case "保存为文本":
                    filename=SGFunction.CommonDialogs.SaveFileDialog_OutResult("保存文本的位置", "文本文件(*.txt)|*.txt",".txt",out res,"来自剪切板的文本"+SGFunction.SystemFunctionAndInformation.GetDateAndTime());
                    if (res ==DialogResult.OK) { SGFunction.DataOperate.SaveStringToTextFile(filename, sgTextBox_clip.Text); SGFunction.CommonDialogs.MessageDialog_ShowInfo("保存文本成功", 2); }
                    break;
                case "复制到...":
                    string re =SGFunction.CommonDialogs.MessageDialog_MustClick("复制之后", "复制完成后是否删除原文件?", "是", "否", "b2", "ques");
                    if (re == "b1")
                    {
                        string folder;
                        folder = SGFunction.CommonDialogs.OpenFolderDialog("复制到...");
                        if (folder != "")
                        {
                            string[] mo = sgTextBox_clip.Lines;
                            SGFunction.CommonDialogs.MoveFilesWithSystemProcessDialog(mo, folder);
                        }
                    }
                    else
                    {
                        if (re == "b2")
                        {
                            string folder;
                            folder = SGFunction.CommonDialogs.OpenFolderDialog("复制到...");
                            if (folder != "")
                            {
                                string[] mo = sgTextBox_clip.Lines;
                                SGFunction.CommonDialogs.CopyFilesWithSystemProcessDialog(mo, folder);
                            }
                        }
                    }
                    break;
            }
        }

        private void MyNormalButton_cliprefresh_Click(object sender, EventArgs e)
        {
            SGSystemStyle.RightMenuMgr.ClipBoredOperate.LoadToUI(this);
        }

        private void sgTreeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (sgTreeView2.SelectedNode != null)
                {
                    备份ToolStripMenuItem.Enabled = 还原ToolStripMenuItem.Enabled = true;
                    MyNormalButton27.Enabled = MyNormalButton23.Enabled = true;
                    MyNormalButton26.Enabled = true;
                    toolStripMenuItem35.Enabled = true;
                    string j = sgTreeView2.SelectedNode.Tag.ToString();
                    switch (j)
                    {
                        case "DK":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDesktopMenu(this);
                            break;
                        case "MC":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadMyComputer(this);
                            break;
                        case "FL":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFile(this);
                            break;
                        case "FO":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFolder(this);
                            break;
                        case "DI":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllDisk(this);
                            break;
                        case "EX":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadExeFile(this);
                            break;
                        case "LK":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadLnkFile(this);
                            break;
                        case "TX":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadTxtFile(this);
                            break;
                        case "DL":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDLLFile(this);
                            break;
                        case "SD":
                            备份ToolStripMenuItem.Enabled = 还原ToolStripMenuItem.Enabled = false;
                            MyNormalButton27.Enabled = MyNormalButton23.Enabled = false;
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadSendToMenu(this);
                            toolStripMenuItem35.Enabled = false;
                            MyNormalButton26.Enabled = false;
                            break;
                        default:
                            备份ToolStripMenuItem.Enabled = 还原ToolStripMenuItem.Enabled = false;
                            MyNormalButton27.Enabled = MyNormalButton23.Enabled = false;
                            if (rmmgr_selectfile == "")
                            {
                                string sf = SGFunction.CommonDialogs.OpenFileDialog("选择文件，我们将会自动判断文件的类型。", "所有文件(*.*)|*.*", false);
                                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sf) == true)
                                {
                                    string ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(sf);
                                    switch (ext.ToUpper())
                                    {
                                        case "EXE":
                                            sgTreeView2.SelectedNode = sgTreeView2.Nodes[5];
                                            break;
                                        case "LNK":
                                            sgTreeView2.SelectedNode = sgTreeView2.Nodes[6];
                                            break;
                                        case "TXT":
                                            sgTreeView2.SelectedNode = sgTreeView2.Nodes[7];
                                            break;
                                        case "DLL":
                                            sgTreeView2.SelectedNode = sgTreeView2.Nodes[8];
                                            break;
                                        default:
                                            string info = SGFunction.FileSystemOperate.FSO_GetFileTypeInfoFromRegistry("." + ext);
                                            if (info == "") { info = ext + "文件(*." + ext + ")"; } else { info = info + "(*." + ext + ")"; }
                                            imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.GetFileIcon(sf, true));
                                            sgTreeView2.Nodes[10].ImageIndex = sgTreeView2.Nodes[10].SelectedImageIndex = imageList_rmmgr_itemslogo.Images.Count - 1;
                                            sgTreeView2.Nodes[10].Text = info;
                                            sgTreeView2.Nodes[10].Tag = "." + ext;
                                            rmmgr_selectfile = "SELECT";
                                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAnyFile(this, "." + ext);
                                            break;
                                    }
                                }
                                else
                                {
                                    //SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDesktopMenu(this);
                                    sgTreeView2.SelectedNode = sgTreeView2.Nodes[0];
                                }
                            }
                            else { if (sgTreeView2.SelectedNode.Tag != null) { SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAnyFile(this, sgTreeView2.SelectedNode.Tag.ToString()); } }
                            break;
                    }
                }

            }
            catch { }
        }

        private void MyNormalButton21_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgTreeView2.SelectedNode != null)
                {
                    if (sgTreeView2.SelectedNode.Tag.ToString() == "MC")
                    {
                        SGFunction.CommonDialogs.MessageDialog_MustClick("无法添加右键菜单", "无法添加右键菜单 : 因为注册表权限不允许添加任何右键菜单项目。我们会尽快的解决这类的问题。", "", "确定", "b2", "error");
                    }
                    else
                    {
                        if (sgTreeView2.SelectedNode.Tag.ToString() == "SD")
                        {
                            SGUserControl_CreateRightMenu f = new SGUserControl_CreateRightMenu("create_sendto", sgTreeView2.SelectedNode.Tag.ToString(), this, new string[] { "", "" });
                            SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("添加新的右键菜单", f);
                            //发送到菜单一般是文件夹和发送到的程序
                            //string fol = SGFunction.CommonDialogs.OpenFolderDialog("发送到的文件夹");
                        }
                        else
                        {
                            switch (sgTreeView2.SelectedNode.Tag.ToString())
                            {
                                case "DK":
                                case "MC":
                                case "FL":
                                case "FO":
                                case "DI":
                                case "EX":
                                case "LK":
                                case "TX":
                                case "DL":
                                case "SD":
                                    SGUserControl_CreateRightMenu f = new SGUserControl_CreateRightMenu("create", sgTreeView2.SelectedNode.Tag.ToString(), this, new string[] { "", "" });
                                    SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("添加新的右键菜单", f);
                                    break;
                                default:
                                    if (sgTreeView2.SelectedNode.Tag.ToString() != "OF")
                                    {
                                        SGUserControl_CreateRightMenu f1 = new SGUserControl_CreateRightMenu("create_selectext", sgTreeView2.SelectedNode.Tag.ToString(), this, new string[] { "", "" });
                                        SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("添加新的右键菜单", f1);
                                    }
                                    else { SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您目前还没有选择一个文件。您可以在左边的列表中选择""其他文件""项目",2); }
                                    break;
                            }
                        }
                    }
                    
                }

            }
            catch { }
        }

        private void MyNormalButton24_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgTreeView2.SelectedNode != null)
                {
                    if (sgTreeView2.SelectedNode.Tag.ToString() == "MC")
                    {
                        SGFunction.CommonDialogs.MessageDialog_MustClick("无法编辑这个右键菜单", "无法编辑这个右键菜单 : 因为注册表权限不允许编辑其中的任何右键菜单项目。我们会尽快的解决这类的问题。", "", "确定", "b2", "error");
                    }
                    else
                    {
                        if(listView8.SelectedItems.Count ==1)
                        {
                            if(sgTreeView2.SelectedNode.Tag.ToString() !="SD")
                            {
                                string bakcode = "桌面上的右键菜单：";
                                string j = sgTreeView2.SelectedNode.Tag.ToString();
                                //用于区别相同的文件
                                switch (j)
                                {
                                    case "DK":
                                        bakcode = "桌面上的右键菜单：";
                                        break;
                                    case "MC":
                                        bakcode = SGFunction.ProgramInfo.GetMyComputerName() + "上的右键菜单：";
                                        break;
                                    case "FL":
                                        bakcode = "所有文件上的右键菜单：";
                                        break;
                                    case "FO":
                                        bakcode = "所有文件夹上的右键菜单：";
                                        break;
                                    case "DI":
                                        bakcode = "磁盘分区上的右键菜单：";
                                        break;
                                    case "EX":
                                        bakcode = "程序文件上的右键菜单：";
                                        break;
                                    case "LK":
                                        bakcode = "快捷方式上的右键菜单：";
                                        break;
                                    case "TX":
                                        bakcode = "文本文件上的右键菜单：";
                                        break;
                                    case "DL":
                                        bakcode = "动态链接库上的右键菜单：";
                                        break;
                                    default:
                                        //select file
                                        if(sgTreeView2.SelectedNode.Tag.ToString() !="OF")
                                        {
                                            SGUserControl_CreateRightMenu f1 = new SGUserControl_CreateRightMenu("edit", sgTreeView2.SelectedNode.Tag.ToString(), this, (string[])listView8.SelectedItems[0].Tag, listView8.SelectedItems[0].Index);
                                            SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑右键菜单", f1);
                                        }
                                        else
                                        {
                                            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您目前还没有选择一个文件。您可以在左边的列表中选择""其他文件""项目", 2); 
                                        }
                                        return;
                                }
                                string[] tags = (string[])listView8.SelectedItems[0].Tag;
                                string r = tags[1].Substring(0, tags[1].IndexOf(","));
                                string location = tags[1].Substring(tags[1].IndexOf(",") + 1, tags[1].LastIndexOf(",") - tags[1].IndexOf(",") - 1);
                                string subname = tags[1].Substring(tags[1].LastIndexOf(",") + 1, tags[1].Length - tags[1].LastIndexOf(",") - 1);
                                string bak = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus\\" + bakcode + subname + ".reg";
                                if (System.IO.File.Exists(bak) == false)
                                {
                                    string res = SGFunction.CommonDialogs.MessageDialog_MustClick("一个建议", "我们建议您在编辑之前先备份一下注册表，这样您可以在编辑出错后还原正确的设置。", "好", "不，谢谢", "b1", "ques");
                                    if (res == "b1")
                                    {
                                        SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus");
                                        SGFunction.RegistryOperate.RegistryOperate_ExportFile(r + "\\" + location + "\\" + subname, bak);
                                    }
                                }
                                SGUserControl_CreateRightMenu f = new SGUserControl_CreateRightMenu("edit", sgTreeView2.SelectedNode.Tag.ToString(), this, (string[])listView8.SelectedItems[0].Tag, listView8.SelectedItems[0].Index);
                                SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑右键菜单", f);
                            }
                            else
                            {
                                //发送到
                                string lnk = listView8.SelectedItems[0].SubItems[1].Text ;
                                string n = listView8.SelectedItems[0].SubItems[0].Text;
                                SGUserControl_CreateRightMenu f = new SGUserControl_CreateRightMenu("edit_sendto", "", this, new string[] { lnk, n }, listView8.SelectedItems[0].Index);
                                SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑发送到菜单", f);
                            }
                        }
                    }

                }

            }
            catch { }
        }

        private void MyNormalButton27_Click(object sender, EventArgs e)
        {
            try
            {
                if(sgTreeView2.SelectedNode !=null)
                {
                    if(listView8.SelectedItems.Count ==1)
                    {
                        if(sgTreeView2.SelectedNode.Tag.ToString()=="SD")
                        {
                            string lnk = listView8.SelectedItems[0].SubItems[1].Text;
                            string fn = "";
                            FileInfo fi = new FileInfo(lnk);
                            if (fi.Exists == true) { fn = fi.Name; }
                            SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus");
                            string bakfile = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus\\发送到菜单：" + fn;
                            SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(lnk, bakfile, true);
                            SGFunction.CommonDialogs.MessageDialog_MustClick("备份成功", "成功备份了菜单文件，这样您可以在编辑出错后还原正确的设置。", "", "确定", "b2", "info");
                        }
                        else
                        {
                            string bakcode = "桌面上的右键菜单：";
                            string j = sgTreeView2.SelectedNode.Tag.ToString();
                            //用于区别相同的文件
                            switch (j)
                            {
                                case "DK":
                                    bakcode = "桌面上的右键菜单：";
                                    break;
                                case "MC":
                                    bakcode = SGFunction.ProgramInfo.GetMyComputerName() + "上的右键菜单：";
                                    break;
                                case "FL":
                                    bakcode = "所有文件上的右键菜单：";
                                    break;
                                case "FO":
                                    bakcode = "所有文件夹上的右键菜单：";
                                    break;
                                case "DI":
                                    bakcode = "磁盘分区上的右键菜单：";
                                    break;
                                case "EX":
                                    bakcode = "程序文件上的右键菜单：";
                                    break;
                                case "LK":
                                    bakcode = "快捷方式上的右键菜单：";
                                    break;
                                case "TX":
                                    bakcode = "文本文件上的右键菜单：";
                                    break;
                                case "DL":
                                    bakcode = "动态链接库上的右键菜单：";
                                    break;
                            }
                            string[] tags = (string[])listView8.SelectedItems[0].Tag;
                            string r = tags[1].Substring(0, tags[1].IndexOf(","));
                            string location = tags[1].Substring(tags[1].IndexOf(",") + 1, tags[1].LastIndexOf(",") - tags[1].IndexOf(",") - 1);
                            string subname = tags[1].Substring(tags[1].LastIndexOf(",") + 1, tags[1].Length - tags[1].LastIndexOf(",") - 1);
                            string bak = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus\\" + bakcode + subname + ".reg";
                            if (System.IO.File.Exists(bak) == false)
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus");
                                SGFunction.RegistryOperate.RegistryOperate_ExportFile(r + "\\" + location + "\\" + subname, bak);
                                SGFunction.CommonDialogs.MessageDialog_MustClick("备份成功", "成功备份了注册表文件，这样您可以在编辑出错后还原正确的设置。", "", "确定", "b2", "info");
                            }
                            else
                            {
                                string res = SGFunction.CommonDialogs.MessageDialog_MustClick("一个旧的文件", "我们在您备份的位置上找到了就得备份的文件，是否要替换它？", "是", "否", "b2", "ques");
                                if (res == "b1")
                                {
                                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(bak);
                                    //SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus");
                                    SGFunction.RegistryOperate.RegistryOperate_ExportFile(r + "\\" + location + "\\" + subname, bak);
                                    SGFunction.CommonDialogs.MessageDialog_MustClick("备份成功", "成功备份了注册表文件，这样您可以在编辑出错后还原正确的设置。", "", "确定", "b2", "info");
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton23_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgTreeView2.SelectedNode != null)
                {
                    if (listView8.SelectedItems.Count == 1)
                    {
                        if(sgTreeView2.SelectedNode.Tag.ToString()=="SD")
                        {
                            //辈分之后 如果改名字就无法还原了
                            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo";
                            string lnk = listView8.SelectedItems[0].SubItems[1].Text;
                            string fn = "";
                            FileInfo fi = new FileInfo(lnk);
                            if (fi.Exists == true) { fn = fi.Name; }
                            string bakfile = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus\\发送到菜单：" + fn;
                            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakfile )==true)
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(bakfile, folder + "\\" + fn, true);
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadSendToMenu(this);
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原了您之前的设置。", 2);
                            }
                            else
                            {
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法还原您的菜单：文件未找到", 2);
                            }
                        }
                        else
                        {
                            
                        }
                        string[] tags = (string[])listView8.SelectedItems[0].Tag;
                        string subname = tags[1].Substring(tags[1].LastIndexOf(",") + 1, tags[1].Length - tags[1].LastIndexOf(",") - 1);
                        string bakcode = "桌面上的右键菜单：";
                        string j = sgTreeView2.SelectedNode.Tag.ToString();
                        //用于区别相同的文件
                        switch (j)
                        {
                            case "DK":
                                bakcode = "桌面上的右键菜单：";
                                break;
                            case "MC":
                                bakcode = SGFunction.ProgramInfo.GetMyComputerName() + "上的右键菜单：";
                                break;
                            case "FL":
                                bakcode = "所有文件上的右键菜单：";
                                break;
                            case "FO":
                                bakcode = "所有文件夹上的右键菜单：";
                                break;
                            case "DI":
                                bakcode = "磁盘分区上的右键菜单：";
                                break;
                            case "EX":
                                bakcode = "程序文件上的右键菜单：";
                                break;
                            case "LK":
                                bakcode = "快捷方式上的右键菜单：";
                                break;
                            case "TX":
                                bakcode = "文本文件上的右键菜单：";
                                break;
                            case "DL":
                                bakcode = "动态链接库上的右键菜单：";
                                break;
                        }
                        string bak = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus\\" +bakcode + subname + ".reg";
                        if (System.IO.File.Exists(bak) == false)
                        {
                            //SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus");
                            //SGFunction.RegistryOperate.RegistryOperate_ExportFile(r + "\\" + location + "\\" + subname, bak);
                            SGFunction.CommonDialogs.MessageDialog_MustClick("还原失败", "没有找到您备份的注册表文件。", "", "确定", "b2", "error");
                        }
                        else
                        {
                            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("是否要还原菜单？", "您确定要还原菜单设置？这可能会让您的操作丢失", "确定", "取消", "b2", "ques");
                            if (res == "b1")
                            {
                                //SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(bak);
                                //SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus");
                                SGFunction.RegistryOperate.RegistryOperate_ImportFile(bak);
                                //SGFunction.CommonDialogs.MessageDialog_MustClick("还原成功", "成功还原了您之前的设置。", "", "确定", "b2", "info");
                                switch (j)
                                {
                                    case "DK":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDesktopMenu(this);
                                        break;
                                    case "MC":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadMyComputer(this);
                                        break;
                                    case "FL":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFile(this);
                                        break;
                                    case "FO":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFolder(this);
                                        break;
                                    case "DI":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllDisk(this);
                                        break;
                                    case "EX":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadExeFile(this);
                                        break;
                                    case "LK":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadLnkFile(this);
                                        break;
                                    case "TX":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadTxtFile(this);
                                        break;
                                    case "DL":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDLLFile(this);
                                        break;
                                }
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原了您之前的设置。", 2);

                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton22_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgTreeView2.SelectedNode != null)
                {
                    if (sgTreeView2.SelectedNode.Tag.ToString() == "MC")
                    {
                        SGFunction.CommonDialogs.MessageDialog_MustClick("无法删除这个右键菜单", "无法删除这个右键菜单 : 因为注册表权限不允许删除其中的任何右键菜单项目。我们会尽快的解决这类的问题。", "", "确定", "b2", "error");
                    }
                    else
                    {
                        if (listView8.SelectedItems.Count == 1)
                        {
                            string cont = SGFunction.CommonDialogs.MessageDialog_MustClick("继续?", @"您确定要删除这个菜单吗?" , "继续", "取消", "b2", "ques");
                            if (cont != "b1") { return; }
                            if(sgTreeView2.SelectedNode.Tag.ToString()=="SD")
                            {
                                string lnk = listView8.SelectedItems[0].SubItems[1].Text;
                                string fn = "";
                                FileInfo fi = new FileInfo(lnk);
                                if (fi.Exists == true) { fn = fi.Name; }
                                SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus\\DeleteMenus\\SendTo");
                                string bakfile = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus\\DeleteMenus\\SendTo\\" + fn;
                                if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakfile )==false)
                                {
                                    string res = SGFunction.CommonDialogs.MessageDialog_MustClick("一个建议", "我们建议您在删除之前先备份一下注册表，这样您可以在删除出错后点击" + @"""已删除的菜单""按钮" + "还原正确的设置。", "好", "不，谢谢", "b1", "ques");
                                    if (res == "b1") { SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(lnk, bakfile, true); }
                                }
                                //开始删除
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnk);
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadSendToMenu(this);
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功删除了您的指定右键菜单。", 2);
                            }
                            else
                            {
                                if (cont == "b1")
                                {
                                    string bakcode = "桌面上的右键菜单：";
                                    string j = sgTreeView2.SelectedNode.Tag.ToString();
                                    string[] tags = (string[])listView8.SelectedItems[0].Tag;
                                    string r = tags[1].Substring(0, tags[1].IndexOf(","));
                                    string location = tags[1].Substring(tags[1].IndexOf(",") + 1, tags[1].LastIndexOf(",") - tags[1].IndexOf(",") - 1);
                                    string subname = tags[1].Substring(tags[1].LastIndexOf(",") + 1, tags[1].Length - tags[1].LastIndexOf(",") - 1);
                                    //用于区别相同的文件
                                    switch (j)
                                    {
                                        case "DK":
                                            bakcode = "桌面上的右键菜单：";
                                            break;
                                        case "MC":
                                            bakcode = SGFunction.ProgramInfo.GetMyComputerName() + "上的右键菜单：";
                                            break;
                                        case "FL":
                                            bakcode = "所有文件上的右键菜单：";
                                            break;
                                        case "FO":
                                            bakcode = "所有文件夹上的右键菜单：";
                                            break;
                                        case "DI":
                                            bakcode = "磁盘分区上的右键菜单：";
                                            break;
                                        case "EX":
                                            bakcode = "程序文件上的右键菜单：";
                                            break;
                                        case "LK":
                                            bakcode = "快捷方式上的右键菜单：";
                                            break;
                                        case "TX":
                                            bakcode = "文本文件上的右键菜单：";
                                            break;
                                        case "DL":
                                            bakcode = "动态链接库上的右键菜单：";
                                            break;
                                        default:
                                            if (sgTreeView2.SelectedNode.Tag.ToString() != "OF")
                                            {
                                                Microsoft.Win32.RegistryKey rr1 = Microsoft.Win32.Registry.ClassesRoot;
                                                switch (r.ToLower())
                                                {
                                                    case "hklm":
                                                        rr1 = Microsoft.Win32.Registry.LocalMachine;
                                                        break;
                                                }
                                                SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(rr1, location, subname);
                                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAnyFile(this, sgTreeView2.SelectedNode.Tag.ToString());
                                            }
                                            else { SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您目前还没有选择一个文件。您可以在左边的列表中选择""其他文件""项目", 2); }
                                            return;
                                    }
                                    //
                                    string bak = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus\\DeleteMenus\\" + bakcode + subname + ".reg";
                                    if (System.IO.File.Exists(bak) == false)
                                    {
                                        string res = SGFunction.CommonDialogs.MessageDialog_MustClick("一个建议", "我们建议您在删除之前先备份一下注册表，这样您可以在删除出错后点击" + @"""已删除的菜单""按钮" + "还原正确的设置。", "好", "不，谢谢", "b1", "ques");
                                        if (res == "b1")
                                        {
                                            SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus\\DeleteMenus");
                                            SGFunction.RegistryOperate.RegistryOperate_ExportFile(r + "\\" + location + "\\" + subname, bak);
                                        }
                                    }
                                    //删除
                                    Microsoft.Win32.RegistryKey rr = Microsoft.Win32.Registry.ClassesRoot;
                                    switch (r.ToLower())
                                    {
                                        case "hklm":
                                            rr = Microsoft.Win32.Registry.LocalMachine;
                                            break;
                                    }
                                    SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(rr, location, subname);
                                    switch (j)
                                    {
                                        case "DK":
                                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDesktopMenu(this);
                                            break;
                                        case "MC":
                                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadMyComputer(this);
                                            break;
                                        case "FL":
                                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFile(this);
                                            break;
                                        case "FO":
                                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFolder(this);
                                            break;
                                        case "DI":
                                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllDisk(this);
                                            break;
                                        case "EX":
                                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadExeFile(this);
                                            break;
                                        case "LK":
                                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadLnkFile(this);
                                            break;
                                        case "TX":
                                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadTxtFile(this);
                                            break;
                                        case "DL":
                                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDLLFile(this);
                                            break;
                                    }
                                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功删除了您的指定右键菜单。", 2);
                                }
                            }
                            
                        }
                    }

                }

            }
            catch { }
        }

        private void MyNormalButton25_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(sgTreeView2.SelectedNode !=null)
                {
                    string bak = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus\\DeleteMenus";
                    string bak_sd = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RightMenus\\DeleteMenus\\sendto";
                    string final_find = bak;
                    if (sgTreeView2.SelectedNode.Tag.ToString() == "SD") { final_find = bak_sd; }
                    string res;
                    string fi = SGFunction.CommonDialogs.ShowFileListInListView("已删除的菜单", @"选择一个菜单，并点击""确定""按钮",final_find, "*.*", System.IO.SearchOption.TopDirectoryOnly, out res);
                    if (res == "ok")
                    {
                        //tianjia
                        if (System.IO.File.Exists(fi) == true && fi != "")
                        {
                            if(sgTreeView2.SelectedNode.Tag.ToString()=="SD")
                            {
                                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo";
                                FileInfo fin=new FileInfo(fi);
                                string taglnk = folder + "\\" + fin.Name;
                                SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(fi, taglnk, true);
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadSendToMenu(this);
                            }
                            else
                            {
                                SGFunction.RegistryOperate.RegistryOperate_ImportFile(fi);
                                string j = sgTreeView2.SelectedNode.Tag.ToString();
                                switch (j)
                                {
                                    case "DK":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDesktopMenu(this);
                                        break;
                                    case "MC":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadMyComputer(this);
                                        break;
                                    case "FL":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFile(this);
                                        break;
                                    case "FO":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFolder(this);
                                        break;
                                    case "DI":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllDisk(this);
                                        break;
                                    case "EX":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadExeFile(this);
                                        break;
                                    case "LK":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadLnkFile(this);
                                        break;
                                    case "TX":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadTxtFile(this);
                                        break;
                                    case "DL":
                                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDLLFile(this);
                                        break;
                                }
                            }
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(fi);
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原了您指定右键菜单。", 2);
                        }
                        else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("您还没有删除任何右键菜单。", 2); }
                    }
                }
                
            }
            catch { }
        }

        private void MyNormalButton32_Click(object sender, EventArgs e)
        {
            SGSystemStyle.RightMenuMgr.RunCommands.LoadRunCommands(this);
        }

        private void MyNormalButton26_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgTreeView2.SelectedNode != null)
                {
                        if (listView8.SelectedItems.Count == 1)
                        {
                            string cmd = listView8.SelectedItems[0].SubItems[1].Text;
                            cmd = SGFunction.PathOperate.ConvertStringToTurePath(cmd, cmd);
                            if(System.IO.File.Exists(cmd)==true)
                            {
                                SGFunction.CommonDialogs.ShowFileAttDialog(cmd);
                            }
                            else
                            {
                                cmd = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(cmd, cmd);
                                if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cmd)==true)
                                {
                                    SGFunction.CommonDialogs.ShowFileAttDialog(cmd);
                                }
                                else
                                {
                                    //分离命令行
                                    string srg;
                                    string fealpath = SGFunction.PathOperate.SplitCommandAndArg(cmd, out srg);
                                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(fealpath) == true)
                                    {
                                        SGFunction.CommonDialogs.ShowFileAttDialog(fealpath);
                                    }
                                    else
                                    {
                                        string nocm = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(fealpath, fealpath);
                                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(nocm) == true) { SGFunction.CommonDialogs.ShowFileAttDialog(nocm); } else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法显示文件的属性", 2); }
                                    }
                                }
                                
                            }
                        }
                }

            }
            catch { }
        }

        private void MyNormalButton93_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgTreeView2.SelectedNode != null)
                {
                    if (listView8.SelectedItems.Count == 1)
                    {
                        string cmd = listView8.SelectedItems[0].SubItems[1].Text;
                        cmd = SGFunction.PathOperate.ConvertStringToTurePath(cmd, cmd);
                        if (System.IO.File.Exists(cmd) == true)
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(cmd);
                        }
                        else
                        {
                            cmd = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(cmd, cmd);
                            if (System.IO.File.Exists(cmd) == true)
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(cmd);
                            }
                            else
                            {
                                //分离命令行
                                string srg;
                                string fealpath = SGFunction.PathOperate.SplitCommandAndArg(cmd, out srg);
                                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(fealpath) == true)
                                {
                                    SGFunction.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(fealpath);
                                }
                                else
                                {
                                    string nocm = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(fealpath, fealpath);
                                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(nocm) == true) { SGFunction.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(nocm); } else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法打开文件的所在位置。", 2); }
                                }
                            }
                            //SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法打开文件的所在目录", 2);

                        }
                    }
                }

            }
            catch { }
        }

        private void MyNormalButton31_Click(object sender, EventArgs e)
        {
            try
            {
                SGUserControl_AddAndEditRunCommands u = new SGUserControl_AddAndEditRunCommands("create", this);
                SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("添加快捷命令", u);
            }
            catch { }
        }

        private void MyNormalButton94_Click(object sender, EventArgs e)
        {
            try
            {
                if(listView6.SelectedItems.Count ==1)
                {
                    if (listView6.SelectedItems[0].SubItems[3].Text == "是")
                    {
                        string sub = listView6.SelectedItems[0].Tag.ToString();
                        SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RunCommands");
                        string bakfile = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RunCommands\\" + sub + ".reg";
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakfile) == false)
                        {
                            string b = SGFunction.CommonDialogs.MessageDialog_MustClick("一个提示", "我们建议您在编辑之前备份快捷命令的配置文件，这样即使您编辑出现了错误也可以还原正确的设置。", "好", "不，谢谢", "b1", "ques");
                            if (b == "b1")
                            {
                                string loc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
                                SGFunction.RegistryOperate.RegistryOperate_ExportFile("HKLM\\" + loc + "\\" + sub, bakfile);
                                //SGFunction.CommonDialogs.MessageDialog_MustClick("备份成功", "成功备份了注册表文件，这样您可以在编辑出错后还原正确的设置。", "", "确定", "b2", "info");
                            }
                            SGUserControl_AddAndEditRunCommands u = new SGUserControl_AddAndEditRunCommands("edit", this, listView6.SelectedItems[0].Tag.ToString(), this.listView6.SelectedItems[0].Index);
                            SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑快捷命令", u);
                        }
                        else
                        {
                            SGUserControl_AddAndEditRunCommands u = new SGUserControl_AddAndEditRunCommands("edit", this, listView6.SelectedItems[0].Tag.ToString(), this.listView6.SelectedItems[0].Index);
                            SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑快捷命令", u);
                        }
                    }
                    else
                    {
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("这个命令无效，无法编辑。",2);
                    }
                    
                }
            }
            catch { }
        }

        private void MyNormalButton28_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView6.SelectedItems.Count == 1)
                {
                    string res1 = SGFunction.CommonDialogs.MessageDialog_MustClick("确定?", "您确定要删除这个命令?", "确定", "取消", "b2", "ques");
                    if (res1 == "b1")
                    {
                        string loc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
                        string sub = listView6.SelectedItems[0].Tag.ToString();
                        string isb = SGFunction.CommonDialogs.MessageDialog_MustClick("一个提示", @"我们建议您在删除之前备份要删除的快捷命令的配置文件，这样即使您删除后出现了错误也可以点击""已删除的命令""还原正确的设置。", "好", "不，谢谢", "b1", "ques");
                        if (isb == "b1")
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RunCommands\\DeleteCommands");
                            string bakfile = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RunCommands\\DeleteCommands\\" + sub + ".reg";
                            if (System.IO.File.Exists(bakfile) == false)
                            {
                                SGFunction.RegistryOperate.RegistryOperate_ExportFile("HKLM\\" + loc + "\\" + sub, bakfile);
                                SGFunction.CommonDialogs.MessageDialog_MustClick("备份成功", "成功备份了注册表文件，这样您可以在编辑出错后还原正确的设置。", "", "确定", "b2", "info");
                            }
                            else
                            {
                                string res = SGFunction.CommonDialogs.MessageDialog_MustClick("一个旧的文件", "我们在备份的位置上找到了一个旧的文件，其中有可能包含原先的设置，是否继续备份并替换旧文件？", "是", "否", "b2", "ques");
                                if (res == "b1")
                                {
                                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(bakfile);
                                    SGFunction.RegistryOperate.RegistryOperate_ExportFile("HKLM\\" + loc + "\\" + sub, bakfile);
                                    SGFunction.CommonDialogs.MessageDialog_MustClick("备份成功", "成功备份了注册表文件，这样您可以在编辑出错后还原正确的设置。", "", "确定", "b2", "info");
                                }
                            }
                        }
                        //删除
                        SGFunction.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, loc, sub);
                        SGSystemStyle.RightMenuMgr.RunCommands.LoadRunCommands(this);
                    }

                }
            }
            catch { }
        }
        public void FeedBackclick(object sender,EventArgs e)
        {
            SGFunction.RunCommand.ShellURL("feedback");
        }
        private void MyNormalButton29_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView6.SelectedItems.Count == 1)
                {
                    string sub = listView6.SelectedItems[0].Tag.ToString();
                    SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RunCommands");
                    string bakfile = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RunCommands\\" + sub + ".reg";
                    if (System.IO.File.Exists(bakfile) == false)
                    {
                        string loc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
                        SGFunction.RegistryOperate.RegistryOperate_ExportFile("HKLM\\" + loc + "\\" + sub, bakfile);
                        SGFunction.CommonDialogs.MessageDialog_MustClick("备份成功", "成功备份了注册表文件，这样您可以在编辑出错后还原正确的设置。", "", "确定", "b2", "info");
                    }
                    else
                    {
                        string res = SGFunction.CommonDialogs.MessageDialog_MustClick("一个旧的文件", "我们在备份的位置上找到了一个旧的文件，其中有可能包含原先的设置，是否继续备份并替换旧文件？", "是", "否", "b2", "ques");
                        if (res == "b1")
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(bakfile);
                            string loc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
                            SGFunction.RegistryOperate.RegistryOperate_ExportFile("HKLM\\" + loc + "\\" + sub, bakfile);
                            SGFunction.CommonDialogs.MessageDialog_MustClick("备份成功", "成功备份了注册表文件，这样您可以在编辑出错后还原正确的设置。", "", "确定", "b2", "info");
                        }
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton30_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView6.SelectedItems.Count == 1)
                {
                    string sub = listView6.SelectedItems[0].Tag.ToString();
                    SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RunCommands");
                    string bakfile = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RunCommands\\" + sub + ".reg";
                    if (System.IO.File.Exists(bakfile) == false)
                    {
                        //string loc = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
                        //SGFunction.RegistryOperate.RegistryOperate_ExportFile("HKLM\\" + loc + "\\" + sub, bakfile);
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法还原这个快捷命令 : 备份的文件没有找到。", 2);
                    }
                    else
                    {
                        SGFunction.RegistryOperate.RegistryOperate_ImportFile(bakfile);
                        SGSystemStyle.RightMenuMgr.RunCommands.LoadRunCommands(this);
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原这个快捷命令。", 2);
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton95_Click(object sender, EventArgs e)
        {
            try
           {
                string bak = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\RunCommands\\DeleteCommands";
                string j;
                string fi = SGFunction.CommonDialogs.ShowFileListInListView("已删除的快捷命令", @"选择一个备份的文件，并点击""确定""按钮", bak, "*.reg", System.IO.SearchOption.TopDirectoryOnly,out j);
                //tianjia
                if(j=="ok")
                {
                    if (fi != "")
                    {
                        if (System.IO.File.Exists(fi) == true)
                        {
                            SGFunction.RegistryOperate.RegistryOperate_ImportFile(fi);
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(fi);
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原了您指定快捷命令。", 2);
                            SGSystemStyle.RightMenuMgr.RunCommands.LoadRunCommands(this);
                        }
                    }
                    else
                    {
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("您还没有删除任何命令。", 2);
                    }
                }

            }
            catch { }
        }

        private void MyNormalButton33_Click(object sender, EventArgs e)
        {
            MyNormalButton  b = (MyNormalButton)sender;
            string Number = b.Tag.ToString();
            SGSystemStyle.Win8Style.SystemStyle_SetWin8StartBackStyle(Number, this);
            SGFunction.Keyboard.SendStartKey();
        }

        private void MyNormalButton53_Click(object sender, EventArgs e)
        {
            MyNormalButton b = (MyNormalButton)sender;
            string Number = b.Tag.ToString();
            SGSystemStyle.Win8Style.SystemStyle_SetWin81StartBackStyle(Number, this);
            SGFunction.Keyboard.SendStartKey();
        }


        private void MyNormalButton73_Click(object sender, EventArgs e)
        {
            switch (SGFunction.SystemFunctionAndInformation.GetOSVersion())
            {
                case "6.2":
                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\ImmersiveShell\Grid", "Layout_Maximumrowcount", numericUpDown1.Value.ToString(), RegistryValueKind.DWord, false);
                    SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                    break;
                case "6.3":
                    if (sgCheckBox5.Checked == true)
                    {
                        SGSystemStyle.Win8Style.SetPowerButtonInStartScreen(this, "show");
                    }
                    else { SGSystemStyle.Win8Style.SetPowerButtonInStartScreen(this, "hide"); }
                    this.SetWin81Color();
                    SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                    break;
            }
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功应用了设置", 2);
        }

        void SetWin81Color()
        {
            if (panel_STARTCOLOR_ACC.Tag != null || panel_STARTCOLOR_BACK.Tag != null)
            {
                string reg = "StartColor";
                string reg1 = "AccentColor";
                //保存BACK COLOR
                string hex10c = SGFunction.ColorOperate.Convert_ColorRGBtoHTML(panel_STARTCOLOR_BACK.BackColor);
                string regl = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent";
                Int32 tempInt = 0; //预先定义一个有符号32位数
                //unchecked语句块内的转换，不做溢出检查
                unchecked
                {
                    tempInt = Convert.ToInt32(hex10c, 16); //强制转换成有符号32位数
                }
                //此时的tempInt已经是有符号32位数，可以直接写入注册表
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, regl, reg, tempInt.ToString(), RegistryValueKind.DWord);
                //保存ACC COLOR
                string hex10c1 = SGFunction.ColorOperate.Convert_ColorRGBtoHTML(panel_STARTCOLOR_ACC.BackColor);
                Int32 tempInt1 = 0; //预先定义一个有符号32位数
                //unchecked语句块内的转换，不做溢出检查
                unchecked
                {
                    tempInt1 = Convert.ToInt32(hex10c1, 16); //强制转换成有符号32位数
                }
                //此时的tempInt已经是有符号32位数，可以直接写入注册表
                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.CurrentUser, regl, reg1, tempInt1.ToString(), RegistryValueKind.DWord);
               // SGFunction.SystemFunctionAndInformation.ReStartExplorer();
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有选择颜色。", 2);
            }
        }

        private void MyNormalButton75_Click(object sender, EventArgs e)
        {
            SGFunction.SystemFunctionAndInformation.ShellPrograms(Environment.GetEnvironmentVariable("localappdata") + @"\Packages\windows.immersivecontrolpanel_cw5n1h2txyewy\LocalState\Indexed\Settings\zh-cn\SettingsPane_{911DD688-AEBA-4214-8C58-9C8FBC8C0710}.settingcontent-ms", "", false, false, false, false);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            PictureBox b = (PictureBox)sender;
            SGSystemStyle.Win8Style.SystemStyle_SetWin8StartSrceenColor(b.Tag.ToString(), this);
            SGFunction.SystemFunctionAndInformation.ReStartExplorer();
        }

        private void sgChooseBox24_OnCheckedChange(object sender, SGChooseBox.MyEventArgs e)
        {
        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void sgTabPageControl5_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Start(3, sgTabPageControl5.SelectedIndex + 1);
        }

        private void MyNormalButton81_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView3.SelectedNode != null)
                {
                    string tag = treeView3.SelectedNode.Tag.ToString();
                    //MessageBox.Show(tag);
                    if (tag.Length > 1)
                    {
                        string n = tag.Substring(0, 1);
                        if (n.ToUpper() == "M")
                        {
                            //选中的是组
                            string zu = tag.Substring(1,tag.Length -1);
                            zu = "G" + zu;
                            //MessageBox.Show(zu);
                            SGUserControl_AddAndEditWinXMenu n1 = new SGUserControl_AddAndEditWinXMenu("create", zu, "",this);
                            SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("添加Win+X菜单", n1);
                        }
                        else
                        {
                            //选中的是快捷方式
                            //SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎选择的是一个菜单，点击上面的类似""Groupxx""的项目吧！", 2);
                            //获取这个菜单所属的组
                            string zu = tag.Substring(0, tag.IndexOf("*"));
                            //MessageBox.Show(zu);
                            SGUserControl_AddAndEditWinXMenu n1 = new SGUserControl_AddAndEditWinXMenu("create", zu, "",this );
                            SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("添加Win+X菜单", n1);
                        }
                    }
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎没有选中一个组，点击上面的类似""Groupxx""的项目吧！", 2); }
            }
            catch { }
        }

        private void MyNormalButton80_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView3.SelectedNode != null)
                {
                    string tag = treeView3.SelectedNode.Tag.ToString();
                    //MessageBox.Show(tag);
                    if (tag.Length > 1)
                    {
                        string n = tag.Substring(0, 1);
                        if (n.ToUpper() == "M")
                        {
                            //选中的是组
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎选择的是一个组，您应该选择一个菜单。", 2);
                        }
                        else
                        {
                            //选中的是快捷方式.
                            string zu = tag.Substring(0, tag.IndexOf("*"));
                            string lnkname = tag.Substring(tag.IndexOf("*") + 1, tag.Length - tag.IndexOf("*") - 1);
                            //MessageBox.Show(lnkname);
                            string lnkf = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + zu + "\\" + lnkname;
                            //检查是否备份
                            SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("Backup") + "\\WinXMenus\\" + zu);
                            string bakf = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("Backup") + "\\WinXMenus\\" + zu + "\\" + lnkname;
                            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakf )==true)
                            {
                                SGUserControl_AddAndEditWinXMenu s = new SGUserControl_AddAndEditWinXMenu("edit", zu, lnkf, this, treeView3.SelectedNode.Text);
                                SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑Win+X菜单", s);
                            }
                            else
                            {
                                //提示备份
                                string wantto = SGFunction.CommonDialogs.MessageDialog_MustClick("一个提示", "您可以在编辑这个菜单之前，备份一下这个菜单的配置，这样您可以在编辑出错后还原正确的菜单", "好", "不，谢谢", "b1", "ques");
                                if(wantto =="b1")
                                {
                                    SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(lnkf, bakf);
                                }
                                SGUserControl_AddAndEditWinXMenu s = new SGUserControl_AddAndEditWinXMenu("edit", zu, lnkf, this, treeView3.SelectedNode.Text);
                                SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑Win+X菜单", s);
                            }
                        }
                    }
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎没有选中一个菜单，点击上面的一个菜单吧！", 2); }
            }
            catch { }
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void MyNormalButton74_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView3.SelectedNode != null)
                {
                    string tag = treeView3.SelectedNode.Tag.ToString();
                    //MessageBox.Show(tag);
                    if (tag.Length > 1)
                    {
                        string n = tag.Substring(0, 1);
                        if (n.ToUpper() == "M")
                        {
                            //选中的是组
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎选择的是一个组，您应该选择一个菜单。", 2);
                        }
                        else
                        {
                            //选中的是快捷方式.
                            string zu = tag.Substring(0, tag.IndexOf("*"));
                            string lnkname = tag.Substring(tag.IndexOf("*") + 1, tag.Length - tag.IndexOf("*") - 1);
                            //MessageBox.Show(lnkname);
                            string lnkf = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + zu + "\\" + lnkname;
                            //检查是否备份
                            SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("Backup") + "\\WinXMenus\\" + zu);
                            string bakf = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("Backup") + "\\WinXMenus\\" + zu + "\\" + lnkname;
                            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakf) == true)
                            {
                                string j=SGFunction.CommonDialogs.MessageDialog_MustClick("一个旧的文件","我们检测到备份的位置存在一个以前备份的文件，是否要替换这个旧文件？","是","否","b2","ques");
                                if(j=="b1")
                                {
                                    SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(lnkf, bakf,true);
                                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功备份了菜单的文件，这样您可以在编辑出错后还原正确的菜单", 2);
                                }
                            }
                            else
                            {
                                //提示备份
                                SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(lnkf, bakf);
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功备份了菜单的文件，这样您可以在编辑出错后还原正确的菜单", 2);
                            }
                        }
                    }
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎没有选中一个菜单，点击上面的一个菜单吧！", 2); }
            }
            catch { }
        }

        private void MyNormalButton77_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView3.SelectedNode != null)
                {
                    string tag = treeView3.SelectedNode.Tag.ToString();
                    //MessageBox.Show(tag);
                    if (tag.Length > 1)
                    {
                        string n = tag.Substring(0, 1);
                        if (n.ToUpper() == "M")
                        {
                            //选中的是组
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎选择的是一个组，您应该选择一个菜单。", 2);
                        }
                        else
                        {
                            //选中的是快捷方式.
                            string zu = tag.Substring(0, tag.IndexOf("*"));
                            string lnkname = tag.Substring(tag.IndexOf("*") + 1, tag.Length - tag.IndexOf("*") - 1);
                            //MessageBox.Show(lnkname);
                            string lnkf = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + zu + "\\" + lnkname;
                            //检查是否备份
                            SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("Backup") + "\\WinXMenus\\" + zu);
                            string bakf = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("Backup") + "\\WinXMenus\\" + zu + "\\" + lnkname;
                            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bakf) == true)
                            {
                                string j = SGFunction.CommonDialogs.MessageDialog_MustClick("继续还原？", "还原菜单文件可以帮助您修复错误的菜单设置，但也可能导致您的设置丢失。是否继续？", "继续", "取消", "b2", "ques");
                                if (j == "b1")
                                {
                                    SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(bakf,lnkf, true);
                                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(bakf);
                                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原了菜单的文件。", 2);
                                    //SGFunction.
                                    SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                                    SGSystemStyle.Win8Style.WinXMenu.SystemStyle_LoadWinXMenu(this);
                                }
                            }
                            else
                            {
                                //提示备份
                                //SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(lnkf, bakf);
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法还原这个菜单：备份的文件没有找到。", 2);
                            }
                        }
                    }
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎没有选中一个菜单，点击上面的一个菜单吧！", 2); }
            }
            catch { }
        }

        private void MyNormalButton82_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView3.SelectedNode != null)
                {
                    string tag = treeView3.SelectedNode.Tag.ToString();
                    //MessageBox.Show(tag);
                    if (tag.Length > 1)
                    {
                        string n = tag.Substring(0, 1);
                        if (n.ToUpper() == "M")
                        {
                            //选中的是组
                            //SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎选择的是一个组，您应该选择一个命令。", 2);
                            //删除组
                            string j = SGFunction.CommonDialogs.MessageDialog_MustClick("是否要删除？", "是否继续要删除这个组？删除组会导致该组下的所有菜单丢失", "继续", "取消", "b2", "ques");
                            if (j == "b1")
                            {
                                string zu = tag.ToUpper().Replace("MROUP", "");
                                int y;
                                int.TryParse(zu,out y);
                                SGSystemStyle.Win8Style.WinXMenu.SystemStyle_DeleteGroup( y);
                                SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                                SGSystemStyle.Win8Style.WinXMenu.SystemStyle_LoadWinXMenu(this);
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功删除了指定的组", 2);
                            }
                        }
                        else
                        {
                            //选中的是快捷方式.
                            string zu = tag.Substring(0, tag.IndexOf("*"));
                            string lnkname = tag.Substring(tag.IndexOf("*") + 1, tag.Length - tag.IndexOf("*") - 1);
                            //MessageBox.Show(lnkname);
                            string lnkf = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + zu + "\\" + lnkname;
                            //检查是否备份
                            //SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("Backup") + "\\WinXMenus\\" + zu);
                            string j = SGFunction.CommonDialogs.MessageDialog_MustClick("是否要删除？", "是否继续要删除这个菜单？", "继续", "取消", "b2", "ques");
                            if(j=="b1")
                            {
                                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnkf);
                                SGSystemStyle.Win8Style.WinXMenu.SystemStyle_LoadWinXMenu(this);
                            }
                        }
                    }
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎没有选中一个菜单，点击上面的一个菜单吧！", 2); }
            }
            catch { }
        }

        private void MyNormalButton83_Click(object sender, EventArgs e)
        {
            try
            {
                string j = SGFunction.CommonDialogs.MessageDialog_MustClick("是否要还原系统默认？", "还原系统的默认菜单？您所创建的菜单将会被删除，", "是", "否", "b2", "ques");
                if (j == "b1")
                {
                    string lnkf = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX";
                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFolder(lnkf,true);
                    string os = SGFunction.SystemFunctionAndInformation.GetOSVersion();
                    if(os=="6.3")
                    {
                        string pak = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("packages") + "\\WinXMenu_Win81RTM.sgpak";
                        SGFunction.PackageOperate.SGPAK_ExtactPackage(pak, lnkf, false);
                    }
                    else
                    {
                        string pak = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("packages") + "\\WinXMenu_Win8RTM.sgpak";
                        SGFunction.PackageOperate.SGPAK_ExtactPackage(pak, lnkf, false);
                    }
                    SGSystemStyle.Win8Style.WinXMenu.SystemStyle_LoadWinXMenu(this);
                    SGFunction.SystemFunctionAndInformation.ReStartExplorer();
                }
            }
            catch { }
        }

        private void MyNormalButton87_Click(object sender, EventArgs e)
        {
            string[] tsks = new string[] {"添加项目","添加常用操作","添加文件夹","添加文件" };
            string ico = @"%windir%\system32\imageres.dll,156|%windir%\system32\imageres.dll,203|%windir%\system32\imageres.dll,3|%windir%\system32\imageres.dll,2";
            string ctsk = SGFunction.CommonDialogs.ChooseTaskDialog("选择要添加的内容", tsks,ico);
            switch (ctsk)
            {
                case "t1":
                    string res;
                    string[] clsid = SGFunction.CommonDialogs.ShowChooseCLSIDDialog("添加项目", out res);
                    if (res == "ok" && clsid[0] != "")
                    {
                        SGSystemStyle.SystemDialog.MyComputer.AddMyComputerItem(clsid, this);
                    }
                    break;
                case "t2":
                    SGSystemStyle.SystemDialog.MyComputer.AddMoreFunction(this);
                    break;
                case "t3":
                    SGSystemStyle.SystemDialog.MyComputer.AddFolder(this);
                    break;
                case "t4":
                    SGSystemStyle.SystemDialog.MyComputer.AddFile(this);
                    break;
            }
        }

        private void MyNormalButton78_Click(object sender, EventArgs e)
        {
        }

        private void MyNormalButton85_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView5.SelectedItems.Count == 1)
                {
                    ListViewItem lvi = listView5.SelectedItems[0];
                   if(lvi.Tag !=null)
                   {
                       if (lvi.Group == listView5.Groups[0])
                       {
                           SGSystemStyle.SystemDialog.MyComputer.DeleteSelect("CLSID", lvi.Tag.ToString(), this);
                       }
                       else
                       {
                           if (lvi.Group == listView5.Groups[1])
                           {
                               SGSystemStyle.SystemDialog.MyComputer.DeleteSelect("LNK", lvi.Tag.ToString(), this);
                           }
                       }
                   }
                }
                else
                {
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("您好像并没有选中一个项目哦。", 2);
                }
            }
            catch { }
        }

        private void MyNormalButton86_Click(object sender, EventArgs e)
        {
            SGFunction.SystemFunctionAndInformation.ShellMyComputer();
        }

        private void MyNormalButton88_Click(object sender, EventArgs e)
        {
            try
            {
                string[] tsks = new string[] {@"还原"""+SGFunction.ProgramInfo.GetMyComputerName()+@"""中的默认项目" ,@"还原""网络位置""的默认项目"};
                string ico = @"%windir%\system32\imageres.dll,104|%windir%\system32\imageres.dll,146";
                string ct=SGFunction.CommonDialogs.ChooseTaskDialog("选择要还原默认项目的类型", tsks, ico);
                switch(ct)
                {
                    case "t1":
                        string res = SGFunction.CommonDialogs.MessageDialog_MustClick("继续？", @"您确定要还原""" + SGFunction.ProgramInfo.GetMyComputerName() + @"""中的默认项目吗？您创建的文件夹或操作将会被删除。", "继续", "取消", "b2", "ques");
                        if (res == "b1") { SGSystemStyle.SystemDialog.MyComputer.ReConfigMyComputershowItems(this); SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原了默认的项目",2); }
                        break;
                    case "t2":
                        string res1 = SGFunction.CommonDialogs.MessageDialog_MustClick("继续？", @"您确定要还原""" + SGFunction.ProgramInfo.GetMyComputerName() + @"""中的默认项目吗？您创建的文件夹或操作将会被删除。但您以后可以在回收站中再次还原它们", "继续", "取消", "b2", "ques");
                        if (res1 == "b1") { SGSystemStyle.SystemDialog.MyComputer.ReConfigNetworkShortcut(this); SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原了默认的项目", 2); }
                        break;
                }

            }
            catch { }
        }

        private void MyNormalButton97_Click(object sender, EventArgs e)
        {
            try
            {
                Image wall = SGFunction.SystemFunctionAndInformation.GetWallpaper();
                string wallpath = SGFunction.SystemFunctionAndInformation.GetWallpaperPath();
                pictureBox15.Image = wall;
                pictureBox15.Tag = wallpath;
            }
            catch { }
        }

        private void MyNormalButton79_Click(object sender, EventArgs e)
        {
            string wallpath = SGFunction.CommonDialogs.OpenFileDialog("选择图片", "image");
            try
            {
                if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(wallpath )==true)
                {
                    pictureBox15.Image = Image.FromFile(wallpath);
                    pictureBox15.Tag = wallpath;
                }
            }
            catch { }
        }

        private void sgTabPageControl6_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Start(4, sgTabPageControl6.SelectedIndex + 1);
        }

        private void MyNormalButton96_Click(object sender, EventArgs e)
        {
            SGSystemStyle.SystemBoot.LockScreenImage.RegDesktopLink();
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加了快捷方式",2);
        }

        private void MyNormalButton107_Click(object sender, EventArgs e)
        {
            string j = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string file = j+@"\Packages\windows.immersivecontrolpanel_cw5n1h2txyewy\LocalState\Indexed\Settings\zh-CN\AAA_SystemSettings_Personalize_LockScreenBackground.settingcontent-ms";
            SGFunction.SystemFunctionAndInformation.ShellPrograms(file, "", false, false, false, false);
        }

        private void MyNormalButton98_Click(object sender, EventArgs e)
        {
            Image img = pictureBox15.Image;
            try
            {
                if (img !=null)
                {
                    SGSystemStyle.SystemBoot.LockScreenImage.ApplyLockScreenImage(this, img);
                }
                else
                {
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎还没有选择一张图片哦。您可以点击""桌面壁纸""和""图片文件""按钮设置图片",2);
                }
            }
            catch { }
        }

        private void MyNormalButton84_Click(object sender, EventArgs e)
        {

        }

        private void MyNormalButton84_Click_1(object sender, EventArgs e)
        {
            SGSystemStyle.SystemBoot.LockScreenImage.ReConfigLockScreenImage(this);
            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"成功还原了系统的默认设置", 2);
        }

        private void MyNormalButton108_Click(object sender, EventArgs e)
        {
            SGFunction.SystemFunctionAndInformation.LockComputer(true);
        }

        private void MyNormalButton101_Click(object sender, EventArgs e)
        {
            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sgTextBox1.Text )==true)
            {
                SGSystemStyle.SystemBoot.BootAudio.PlayWav(sgTextBox1.Text, false, false);
            }else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("您还没有选择音乐文件，我们将为您播放系统默认的开机音乐", 2);
                SGSystemStyle.SystemBoot.BootAudio.PlayWav("", true, false);
            }
        }

        private void MyNormalButton103_Click(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sgTextBox2.Text) == true)
            {
                SGSystemStyle.SystemBoot.BootAudio.PlayWav(sgTextBox2.Text, false, false);
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("您还没有选择音乐文件，我们将为您播放系统默认的关机音乐", 2);
                SGSystemStyle.SystemBoot.BootAudio.PlayWav("", false, true);
            }
        }

        private void MyNormalButton99_Click(object sender, EventArgs e)
        {
            string j = SGFunction.CommonDialogs.OpenFileDialog("打开音乐文件", "音乐文件(*.wav)|*.wav");
            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(j)==true)
            {
                sgTextBox1.Text = j;
            }
        }

        private void MyNormalButton106_Click(object sender, EventArgs e)
        {
            string j = SGFunction.CommonDialogs.OpenFileDialog("打开音乐文件", "音乐文件(*.wav)|*.wav");
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(j) == true)
            {
                sgTextBox2.Text = j;
            }
        }

        private void MyNormalButton102_Click(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sgTextBox1.Text) == true)
            {
                SGSystemStyle.SystemBoot.BootAudio.ApplyStartAudio(sgTextBox1.Text);
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您还没有选择音乐文件。请点击上面的""...""按钮选择一个音乐文件", 2);
            }
        }

        private void MyNormalButton105_Click(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sgTextBox2.Text) == true)
            {
                SGSystemStyle.SystemBoot.BootAudio.ApplyPowerOffAudio(sgTextBox2.Text);
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您还没有选择音乐文件。请点击上面的""...""按选择一个音乐文件", 2);
            }
        }

        private void MyNormalButton100_Click(object sender, EventArgs e)
        {
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要还原？", "是否要还原关机的音乐文件？还原后，您所做的更改将会丢失。", "继续", "取消", "b2", "ques");
            if(res=="b1")
            {
                SGSystemStyle.SystemBoot.BootAudio.ReConfigPowerOffAudio();
            }
        }

        private void panel_STARTCOLOR_BACK_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_STARTCOLOR_BACK_Click(object sender, EventArgs e)
        {
            Color org = panel_STARTCOLOR_BACK.BackColor;
            Color selecolor = SGFunction.CommonDialogs.ColorDialog(org);
            if(selecolor !=org)
            {
                panel_STARTCOLOR_BACK.BackColor = selecolor;
                panel_STARTCOLOR_BACK.Tag = "1";
            }
        }

        private void panel_STARTCOLOR_ACC_Click(object sender, EventArgs e)
        {
            Color org = panel_STARTCOLOR_ACC.BackColor;
            Color selecolor = SGFunction.CommonDialogs.ColorDialog(org);
            if (selecolor != org)
            {
                panel_STARTCOLOR_ACC.BackColor = selecolor;
                panel_STARTCOLOR_ACC.Tag = "1";
            }
        }

        private void MyNormalButton76_Click(object sender, EventArgs e)
        {
            
        }

        private void MyNormalButton104_Click(object sender, EventArgs e)
        {
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要还原？", "是否要还原开机的音乐文件？还原后，您所做的更改将会丢失。", "继续", "取消", "b2", "ques");
            if (res == "b1")
            {
                SGSystemStyle.SystemBoot.BootAudio.ReConfigStartAudio();
            }
        }

        private void MyNormalButton76_Click_1(object sender, EventArgs e)
        {
            try
            {
                List<string> insidisk = new List<string>();
                for (int q = 1; q <= sgListView1.Items.Count; q++)
                {
                    if (sgListView1.Items[q - 1].SubItems[3].Text == "磁盘分区")
                    {
                        //首先是个系统
                        string bootpath = sgListView1.Items[q - 1].SubItems[2].Text;
                        if (bootpath != "")
                        {
                            string disk = bootpath.Substring(0, bootpath.IndexOf("\\") + 1);
                            insidisk.Add(disk);
                        }
                    }
                }
                //insidisk.Add("D:\\");
                SGUserControl_AddOrEditBootMenu k = new SGUserControl_AddOrEditBootMenu("create", insidisk, this,new string[]{""},0);
                SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("添加启动菜单", k);
            }
            catch { }
        }

        private void MyNormalButton114_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> clsids = new List<string>();
                if (sgListView1.SelectedItems.Count == 0)
                {
                    return;
                }
                sgListView1.BeginUpdate();
                if (sgListView1.SelectedItems[0].Index > 0)
                {
                    foreach (ListViewItem  lvi in sgListView1.SelectedItems)
                    {
                        ListViewItem lviSelectedItem = lvi;
                        int indexSelectedItem = lvi.Index;
                        sgListView1.Items.RemoveAt(indexSelectedItem);
                        sgListView1.Items.Insert(indexSelectedItem - 1, lviSelectedItem);
                    }
                }
                sgListView1.EndUpdate();

                if (sgListView1.Items.Count > 0 && sgListView1.SelectedItems.Count > 0)
                {
                    sgListView1.Focus();
                    sgListView1.SelectedItems[0].Focused = true;
                    sgListView1.SelectedItems[0].EnsureVisible();
                }
                //查找更噶
                for(int p=1;p<=sgListView1.Items.Count;p++)
                {
                    string[] ppp = (string[])sgListView1.Items[p - 1].Tag;
                    clsids.Add(ppp[0]);
                }
                SGFunction.BCDOperate.BCDOperate_ChangeMenuOrder(clsids.ToArray());
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("上移成功", 2);
            }
            catch { }
        }

        private void sgListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(sgListView1.Items.Count ==1)
                {
                    MyNormalButton_bootmenu_down.Enabled = MyNormalButton_bootmenu_up.Enabled = false;
                }
                else
                {
                    if (sgListView1.SelectedItems.Count == 1)
                    {
                        int j = sgListView1.SelectedItems[0].Index;
                        if (j == 0)
                        {
                            MyNormalButton_bootmenu_up.Enabled = false;
                            MyNormalButton_bootmenu_down.Enabled = true;
                        }
                        else
                        {
                            if (j == sgListView1.Items.Count - 1)
                            {
                                MyNormalButton_bootmenu_up.Enabled = true;
                                MyNormalButton_bootmenu_down.Enabled = false;
                            }
                            else
                            {
                                MyNormalButton_bootmenu_up.Enabled = true;
                                MyNormalButton_bootmenu_down.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton_bootmenu_down_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgListView1.SelectedItems.Count == 0)
                {
                    return;
                }

                sgListView1.BeginUpdate();
                int indexMaxSelectedItem = sgListView1.SelectedItems[sgListView1.SelectedItems.Count - 1].Index;

                if (indexMaxSelectedItem < sgListView1.Items.Count - 1)
                {
                    for (int i = sgListView1.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        ListViewItem lviSelectedItem = sgListView1.SelectedItems[i];
                        int indexSelectedItem = lviSelectedItem.Index;
                        sgListView1.Items.RemoveAt(indexSelectedItem);
                        sgListView1.Items.Insert(indexSelectedItem + 1, lviSelectedItem);
                    }
                }
                sgListView1.EndUpdate();
                if (sgListView1.Items.Count > 0 && sgListView1.SelectedItems.Count > 0)
                {
                    sgListView1.Focus();
                    sgListView1.SelectedItems[sgListView1.SelectedItems.Count - 1].Focused = true;
                    sgListView1.SelectedItems[sgListView1.SelectedItems.Count - 1].EnsureVisible();
                }
                //查找更噶
                List<string> clsids = new List<string>();
                for (int p = 1; p <= sgListView1.Items.Count; p++)
                {
                    string[] ppp = (string[])sgListView1.Items[p - 1].Tag;
                    clsids.Add(ppp[0]);
                }
                SGFunction.BCDOperate.BCDOperate_ChangeMenuOrder(clsids.ToArray());
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("下移成功", 2);
            }
            catch { }
        }

        private void MyNormalButton113_Click(object sender, EventArgs e)
        {
            try
            {
                if(sgListView1.SelectedItems.Count >=1 )
                {
                    string[] t = (string[])sgListView1.SelectedItems[0].Tag;
                    List<string> insidisk = new List<string>();
                    SGUserControl_AddOrEditBootMenu k = new SGUserControl_AddOrEditBootMenu("edit", insidisk, this, t,sgListView1.SelectedItems[0].Index);
                    SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑启动菜单", k);
                }
            }
            catch { }
        }

        private void MyNormalButton115_Click(object sender, EventArgs e)
        {
            try
            {
                if(sgListView1.SelectedItems.Count >=1)
                {
                    int count = sgListView1.Items.Count;
                    if(count >1)
                    {
                        string isd = sgListView1.SelectedItems[0].SubItems[0].Text;
                        if (isd == "")
                        {
                            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("继续？", "您是否需要删除这个菜单？删除之后您无法从这个菜单启动系统", "删除", "取消", "b2", "ques");
                            if (res == "b1")
                            {
                                string bak = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("backup") + "\\BootMenusMgr\\BCDBackup.bak";
                                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(bak) == false)
                                {
                                    string resb = SGFunction.CommonDialogs.MessageDialog_MustClick("一个提示", "是否需要在删除这个启动菜单之前，备份一下启动文件。这样即使您在之后出现了错误也可以还原正确的设置。", "好", "不，谢谢", "b1", "ques");
                                    if (resb == "b1") { SGSystemStyle.SystemBoot.BootMenusMgr.ExportBCD(); }
                                }
                                int sele = sgListView1.SelectedItems[0].Index;
                                //删除
                                string clsid = "";
                                string ope = "";
                                clsid = sgListView1.SelectedItems[0].SubItems[4].Text;
                                ope = ((string[])sgListView1.SelectedItems[0].Tag)[5];
                                SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", @"/delete " + clsid + @" /f /cleanup", true, false, true, true);
                                if (ope != "") { SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", @"/delete " + ope + @" /f /cleanup", true, false, true, true); }
                                SGSystemStyle.SystemBoot.BootMenusMgr.SystemStyle_LoadBCD(this);
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功删除了这个启动菜单", 2);
                                sgListView1.Focus();
                                sgListView1.SelectedItems[sele].Focused = true;
                                //sgListView1.SelectedItems[sele].EnsureVisible();
                            }
                        }
                        else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法删除这个启动菜单：因为这是个默认的启动菜单", 2); }
                    }
                    else
                    {
                        //no
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法删除这个启动菜单：因为当前磁盘中只存在一个启动项。删除后，系统可能会无法启动", 2); 
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton114_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (sgListView1.SelectedItems.Count >= 1)
                {
                    string isd = sgListView1.SelectedItems[0].SubItems[0].Text;
                    if (isd == "")
                    {
                        //default
                        string clsid = "";
                        clsid = sgListView1.SelectedItems[0].SubItems[4].Text;
                        SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", @"/default " + clsid, true, false, true, true);
                        string[] orgs = (string[])sgListView1.SelectedItems[0].Tag;
                        orgs[4] = "是";
                        sgListView1.SelectedItems[0].Tag = orgs;
                        sgListView1.SelectedItems[0].SubItems[0].Text = "是";
                        for (int j = 1; j <= sgListView1.Items.Count; j++)
                        {
                            if (j - 1 != sgListView1.SelectedItems[0].Index) { sgListView1.Items[j - 1].SubItems[0].Text = ""; }
                        }
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功设置了这个启动菜单为默认的启动菜单", 2);
                    }
                    else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("这个启动菜单已经是默认的。", 2); }
                }
            }
            catch { }
        }

        private void MyNormalButton111_Click(object sender, EventArgs e)
        {
            if(sgTextBox4.Text !="")
            {
                SGFunction.BCDOperate.SetTimeout(sgTextBox4.Text);
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功应用了系统倒计时时间。", 2);
            }
        }

        private void MyNormalButton112_Click(object sender, EventArgs e)
        {
            SGSystemStyle.SystemBoot.BootMenusMgr.ExportBCD();
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功备份了启动菜单的设置文件。", 2);
        }

        private void MyNormalButton110_Click(object sender, EventArgs e)
        {
            SGSystemStyle.SystemBoot.BootMenusMgr.ImportBCD(this);
            
        }

        private void MyNormalButton123_Click(object sender, EventArgs e)
        {
            string ext = "虚拟磁盘文件(*.vhd)|*.vhd";
            if(SGFunction.SystemFunctionAndInformation.GetOSVersion()=="6.2" || SGFunction.SystemFunctionAndInformation.GetOSVersion()=="6.3")
            {
                ext = "虚拟磁盘文件(*.vhd;*.vhdx)|*.vhd;*.vhdx";
            }
            DialogResult res;
            string file = SGFunction.CommonDialogs.OpenFileDialog_OutResult("您可以选择或者创建一个虚拟磁盘文件，如果您需要创建，请在文件名中输入名称", ext,false, out res, true, "我的虚拟磁盘.vhd");
            if(res ==DialogResult.OK )
            {
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(file) == true)
                {
                    //panel3.Location = new Point(4, 65);
                    sgTextBox6.Text = file;
                    panel3.Visible = false;
                    panel6.Visible = true;
                    panel6.Location = new Point(3, 76);
                }
                else
                {
                    sgTextBox6.Text = file;
                    panel3.Location = new Point(4, 65);
                    panel3.Visible = true;
                    panel6.Visible = false;
                    //ext
                    string extn = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(file);
                    if (extn.ToUpper() == "VHDX") { sgRadioButton_vhdx.Checked = true; } else { sgRadioButton_vhd.Checked = true; }
                }
            }
        }

        private void sgRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(sgRadioButton_vhd.Checked ==true)
            {
                if (sgTextBox6.Text != "")
                {
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(sgTextBox6.Text).ToUpper() != "VHD")
                    {
                        string fw = sgTextBox6.Text.Substring(0, sgTextBox6.Text.LastIndexOf("."));
                        fw = fw + ".vhd";
                        sgTextBox6.Text = fw;
                    }
                }
            }
        }

        private void sgRadioButton_vhdx_CheckedChanged(object sender, EventArgs e)
        {
            if (sgRadioButton_vhdx.Checked == true)
            {
                if (sgTextBox6.Text != "")
                {
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(sgTextBox6.Text).ToUpper() != "VHDX")
                    {
                        string fw = sgTextBox6.Text.Substring(0, sgTextBox6.Text.LastIndexOf("."));
                        fw = fw + ".vhdx";
                        sgTextBox6.Text = fw;
                    }
                }
            }
        }

        private void MyNormalButton116_Click(object sender, EventArgs e)
        {
            if (sgTextBox6.Text != "")
            {
                //获取VHD VHDX
                //获取大小模式
                string VD_S = "expandable";
                if (sgRadioButton_fixedadd.Checked == true) { VD_S = "fixed"; }
                //获取大小
                int size;
                int.TryParse(sgTextBox_vhdsize.Text, out size);
                //判断大小是否正确
                if (size > 0)
                {
                    //转为MB
                    switch(sgCombobox2.SelectedIndex)
                    {
                        case 1:
                            //is gb
                            size = size * 1024;
                            break;
                        case 2: //is tb
                            size = size * 1024 * 1024;
                            break;
                    }
                    //Letter
                    string letter = sgCombobox_letter.Items[sgCombobox_letter.SelectedIndex].ToString();
                    SGSystemStyle.SystemBoot.VHDMgr.CreateNewVHD(sgTextBox6.Text, VD_S, size, sgCheckBox6.Checked, letter);
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("您输入的大小可能存在问题。", 2); }
            }
            else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("您还没有选择保存的磁盘文件", 2); }
        }

        private void sgCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void MyNormalButton117_Click(object sender, EventArgs e)
        {
            SGSystemStyle.SystemBoot.VHDMgr.InstallVHD(sgTextBox6.Text);
        }

        private void MyNormalButton118_Click(object sender, EventArgs e)
        {
            string j = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要卸载这个虚拟磁盘？", "建议您关闭访问这个虚拟磁盘的程序以及打开的窗口，不正确的操作有可能导致数据丢失。", "继续", "取消", "b1", "ques");
            if(j=="b1")
            {
                SGSystemStyle.SystemBoot.VHDMgr.UninstallVHD(sgTextBox6.Text);
            }
        }

        private void MyNormalButton120_Click(object sender, EventArgs e)
        {
            string fl = SGFunction.CommonDialogs.OpenFolderDialog("选择一个要美化的文件夹");
            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(fl,false)==true)
            {
                sgTextBox_mh_folder.Text = fl;
                SGSystemStyle.FileMgr.FolderMgr.LoadFolder(fl,this);
            }
        }

        private void sgTabPageControl7_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Start(5, sgTabPageControl7.SelectedIndex + 1);
        }

        private void sgCombobox_fm_icons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(sgTextBox_mh_folder.Text,false)==true)
            {
                SGSystemStyle.FileMgr.FolderMgr.Combox_ChangeIcon(sgCombobox_fm_icons.SelectedIndex, this);
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到您要美化的文件夹", 2); 
            }
        }

        private void sgTextBox_foldername_TextChanged(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(sgTextBox_mh_folder.Text, false) == true)
            {
SGSystemStyle.FileMgr.FolderMgr.ChangeFolderDisplayName_INTEMPINI(sgTextBox_foldername.Tag.ToString(), sgTextBox_foldername.Text,this);
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到您要美化的文件夹", 2);
            }
            
        }

        private void sgTextBox_foldertip_TextChanged(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(sgTextBox_mh_folder.Text, false) == true)
            {
SGSystemStyle.FileMgr.FolderMgr.ChangeFolderTip_INTEMPINI(sgTextBox_foldertip.Tag.ToString(), sgTextBox_foldertip.Text,this);
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到您要美化的文件夹", 2);
            }
            
        }

        private void sgListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(sgTextBox_mh_folder.Text, false) == true)
            {
                if (sgListView2.SelectedItems.Count == 1)
                {
                    sgTextBox_fm_displayname.Enabled = sgTextBox_fm_filename.Enabled = true;
                    //获取类型
                    //string t = sgListView2.SelectedItems[0].SubItems[2].Text;
                    string s = sgListView2.SelectedItems[0].SubItems[0].Text;
                    sgTextBox_fm_filename.Text = s;
                    string j=SGSystemStyle.FileMgr.FolderMgr.GetFileDisplayName(sgTextBox_mh_folder.Text, s);
                    sgTextBox_fm_displayname.Text = j;
                }
            }
            else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("要美化的文件夹不存在。", 2); }
        }

        private void sgTextBox_fm_displayname_TextChanged_1(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(sgTextBox_mh_folder.Text, false) == true)
            {
string s = sgListView2.SelectedItems[0].SubItems[0].Text;
            SGSystemStyle.FileMgr.FolderMgr.ChangeDisplayName(sgTextBox_mh_folder.Text, s, sgTextBox_fm_displayname.Text);
            }
            else
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到您要美化的文件夹", 2);
            }
            
        }

        private void MyNormalButton121_Click(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(sgTextBox_mh_folder.Text, false) == true)
            {
                SGSystemStyle.FileMgr.FolderMgr.FinishConfig(sgTextBox_mh_folder.Text);
                SGFunction.SystemFunctionAndInformation.UpdateDesktop();
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功美化文件夹。", 2);
            }
            else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到您要美化的文件夹",2); }
        }

        private void MyNormalButton122_Click(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(sgTextBox_mh_folder.Text, false) == true)
            {
                string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要还原默认吗？", "您之前那所做的更改将会丢失。", "继续", "取消", "b2", "ques");
                if (res == "b1")
                {
                    SGSystemStyle.FileMgr.FolderMgr.ReConfig(sgTextBox_mh_folder.Text);
                    SGFunction.SystemFunctionAndInformation.UpdateDesktop();
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原默认。", 2);
                }  
            }
            else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到您要美化的文件夹", 2); }
        }

        private void MyNormalButton124_Click(object sender, EventArgs e)
        {
            string res;
            string[] cd = SGFunction.CommonDialogs.ShowChooseDiskDialog("FIXED", "选择一个要美化的驱动器", out res);
            if (res == "ok")
            {
                string disk = cd[0];
                sgLabel_dm_drive.Text = disk;
                panel7.Visible = true;
                SGSystemStyle.FileMgr.DriveMgr.LoadDriveConfigFile(sgLabel_dm_drive.Text, this);
            }
            else 
            {
                //if (sgLabel_dm_drive.Text != "没有选择") { }
            }
        }

        private void sgTabPageControl8_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Start(6, sgTabPageControl8.SelectedIndex + 1);
        }

        private void MyNormalButton125_Click(object sender, EventArgs e)
        {
            string f = SGFunction.CommonDialogs.OpenFileDialog("选择一个文件", "image");
            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(f)==true)
            {
                sgTextBox_sys_syslogo.Text = f;
                pictureBox_sys_syslogo.Image = Image.FromFile(f);
                pictureBox_sys_syslogo.Tag = "CHOOSE";
                if (pictureBox_sys_syslogo.Image.Size.Width > 336 || pictureBox_sys_syslogo.Image.Size.Height > 137) { pictureBox_sys_syslogo.SizeMode = PictureBoxSizeMode.StretchImage; }
            }
        }

        private void MyNormalButton126_Click(object sender, EventArgs e)
        {
            string f = SGFunction.CommonDialogs.OpenFileDialog("选择一个文件", "image");
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(f) == true)
            {
                sgTextBox_oem_oemlogo.Text = f;
                pictureBox_oem_oemlogo.Image = Image.FromFile(f);
                pictureBox_oem_oemlogo.Tag = "CHOOSE";
                //if (pictureBox_sys_syslogo.Image.Size.Width > 336 || pictureBox_sys_syslogo.Image.Size.Height > 137) { pictureBox_sys_syslogo.SizeMode = PictureBoxSizeMode.StretchImage; }
            }
        }

        private void MyNormalButton128_Click(object sender, EventArgs e)
        {
            //设置OEM
            if (pictureBox_oem_oemlogo.Tag != null)
            {
                Image b = Image.FromFile(sgTextBox_oem_oemlogo.Text);
                SGSystemStyle.SystemDialog.SystemInfo.SystemStyle_SetOEMInfo(sgTextBox_oem_name.Text, sgTextBox_oem_web.Text, sgTextBox_oem_edition.Text, sgTextBox_oem_time.Text, sgTextBox_oem_phone.Text, b);
            }
            else
            {
                SGSystemStyle.SystemDialog.SystemInfo.SystemStyle_SetOEMInfo(sgTextBox_oem_name.Text, sgTextBox_oem_web.Text, sgTextBox_oem_edition.Text, sgTextBox_oem_time.Text, sgTextBox_oem_phone.Text,null);
            }
            //SYS INFO
            SGSystemStyle.SystemDialog.SystemInfo.SystemStyle_SetSystemInfo(sgTextBox_sys_user.Text, sgTextBox_sys_osname.Text, sgTextBox_sys_regcompany.Text, sgTextBox_sys_osversion.Text, sgTextBox_sys_osid.Text,sgTextBox_sys_installpath.Text);
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功修改了系统信息。", 2);
            SGFunction.SystemFunctionAndInformation.ShellPrograms("control.exe", "/name Microsoft.System", false, false, false, false);
        }

        private void MyNormalButton127_Click(object sender, EventArgs e)
        {
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("继续？", "您确定还原默认吗？您的设置将会被更改。", "继续", "取消", "b2", "ques");
            if(res=="b1")
            {
                SGSystemStyle.SystemDialog.SystemInfo.SystemStyle_ReConfigOEMInfo();
                SGSystemStyle.SystemDialog.SystemInfo.SystemStyle_LoadOEMAndSystemInfo(this);
            }
        }

        private void MyNormalButton130_Click(object sender, EventArgs e)
        {
            string f = SGFunction.CommonDialogs.OpenFolderDialog("选择一个文件夹");
            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(f,false)==true)
            {
                sgTextBox_sys_installpath.Text = f;
            }
        }

        private void MyNormalButton131_Click(object sender, EventArgs e)
        {
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("继续？", "您确定清除OEM标识吗？", "继续", "取消", "b2", "ques");
            if (res == "b1")
            {
                SGSystemStyle.SystemDialog.SystemInfo.SystemStyle_ReConfigLogo();
                pictureBox_oem_oemlogo.Image = null;
                pictureBox_oem_oemlogo.Tag = null;
                sgTextBox_oem_oemlogo.Text = "";
            }
        }

        private void MyNormalButton135_Click(object sender, EventArgs e)
        {
            SGFunction.SystemFunctionAndInformation.LogOff();
        }

        private void MyNormalButton133_Click(object sender, EventArgs e)
        {
            if(sgNumberControl_previewdialog_size.Tag !=null && sgNumberControl_win8dialog_bordersize.Tag !=null)
            {
                //都更改了
                //只有WIN8
                SGSystemStyle.SystemDialog.Dialogs.ApplyDialogSettings("WIN8BORDERSIZE", new string[] { sgNumberControl_win8dialog_bordersize.Value.ToString() });
                SGSystemStyle.SystemDialog.Dialogs.ApplyDialogSettings("PREVIEWSIZE", new string[] { sgNumberControl_previewdialog_size.Value.ToString() });
                SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"应用成功，您可以点击""注销登录""按钮以完成更改。", 2);
            }
            else
            {
                if(sgNumberControl_previewdialog_size.Tag ==null)
                {
                    if(sgNumberControl_win8dialog_bordersize.Tag ==null)
                    {
                        //没有修改
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您还没有更改任何项目。", 2);
                    }
                    else
                    {
                        //修改了BORDER
                        SGSystemStyle.SystemDialog.Dialogs.ApplyDialogSettings("WIN8BORDERSIZE", new string[] { sgNumberControl_win8dialog_bordersize.Value.ToString() });
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"应用成功，您可以点击""注销登录""按钮以完成更改。", 2);
                    }
                }
                else
                {
                    if (sgNumberControl_win8dialog_bordersize.Tag == null)
                    {
                        //修改了PREVIEW 没有修改BORDER 哟可能win7 win8
                        if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.1")
                        {
                            //WIN7
                            SGSystemStyle.SystemDialog.Dialogs.ApplyDialogSettings("PREVIEWSIZE", new string[] { sgNumberControl_previewdialog_size.Value.ToString() });
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"应用成功，您可以点击""注销登录""或""重启资源管理器""按钮以完成更改。", 2);
                        }
                        else
                        {
                            //WIN8 8.1
                            SGSystemStyle.SystemDialog.Dialogs.ApplyDialogSettings("PREVIEWSIZE", new string[] { sgNumberControl_previewdialog_size.Value.ToString() });
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"应用成功，您可以点击""注销登录""或""重启资源管理器""按钮以完成更改。", 2);
                            //SGSystemStyle.SystemDialog.Dialogs.ApplyDialogSettings("WIN8BORDERSIZE", new string[] { sgNumberControl_win8dialog_bordersize.Value.ToString() });
                        }
                    }
                }
            }
            sgNumberControl_win8dialog_bordersize.Tag = sgNumberControl_previewdialog_size.Tag = null;
        }

        private void MyNormalButton132_Click(object sender, EventArgs e)
        {
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("继续？", "您确定要还原所有的设置吗？您之前的设置将会丢失。", "继续", "取消", "b2", "ques");
            if(res=="b1")
            {
                SGSystemStyle.SystemDialog.Dialogs.ReConfigDialogSettings("PREVIEWSIZE");
                SGSystemStyle.SystemDialog.Dialogs.ReConfigDialogSettings("WIN8BORDERSIZE");
                sgNumberControl_win8dialog_bordersize.Value = 60;
                sgNumberControl_previewdialog_size.Value = 300;
                sgNumberControl_previewdialog_size.Tag = sgNumberControl_win8dialog_bordersize.Tag = null;
            }
        }

        private void sgNumberControl_previewdialog_size_ValueChanged(object sender, EventArgs e)
        {
            sgNumberControl_previewdialog_size.Tag = "CHANGE";
        }

        private void sgNumberControl_win8dialog_bordersize_ValueChanged(object sender, EventArgs e)
        {
            sgNumberControl_win8dialog_bordersize.Tag = "CHANGE";
        }

        private void MyNormalButton136_Click(object sender, EventArgs e)
        {
            SGFunction.SystemFunctionAndInformation.ReStartExplorer();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView6.SelectedItems.Count == 1)
                {
                    string cmd = listView6.SelectedItems[0].SubItems[1].Text;
                    cmd = SGFunction.PathOperate.ConvertStringToTurePath(cmd, cmd);
                    if (System.IO.File.Exists(cmd) == true)
                    {
                        SGFunction.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(cmd);
                    }
                    else
                    {
                        cmd = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(cmd, cmd);
                        if (System.IO.File.Exists(cmd) == true)
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(cmd);
                        }
                        else
                        {
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法打开文件的所在目录", 2);
                        }
                    }
                }
            }

            catch { }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView6.SelectedItems.Count == 1)
                {
                    string cmd = listView6.SelectedItems[0].SubItems[1].Text;
                    cmd = SGFunction.PathOperate.ConvertStringToTurePath(cmd, cmd);
                    if (System.IO.File.Exists(cmd) == true)
                    {
                        SGFunction.CommonDialogs.ShowFileAttDialog(cmd);
                    }
                    else
                    {
                        cmd = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(cmd, cmd);
                        if (System.IO.File.Exists(cmd) == true)
                        {
                            SGFunction.CommonDialogs.ShowFileAttDialog(cmd);
                        }
                        else
                        {
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法显示文件的属性", 2);
                        }
                    }

                }

            }
            catch { }
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            SGSystemStyle.Win8Style.WinXMenu.SystemStyle_LoadWinXMenu(this);
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView3.SelectedNode != null)
                {
                    string tag = treeView3.SelectedNode.Tag.ToString();
                    //MessageBox.Show(tag);
                    if (tag.Length > 1)
                    {
                        string n = tag.Substring(0, 1);
                        if (n.ToUpper() == "M")
                        {
                            //选中的是组
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎选择的是一个组，您应该选择一个菜单。", 2);
                        }
                        else
                        {
                            //选中的是快捷方式.
                            string zu = tag.Substring(0, tag.IndexOf("*"));
                            string lnkname = tag.Substring(tag.IndexOf("*") + 1, tag.Length - tag.IndexOf("*") - 1);
                            //MessageBox.Show(lnkname);
                            string lnkf = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + zu + "\\" + lnkname;
                            SGFunction.CommonDialogs.ShowFileAttDialog(lnkf);
                        }
                    }
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎没有选中一个菜单。", 2); }
            }
            catch { }
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView3.SelectedNode != null)
                {
                    string tag = treeView3.SelectedNode.Tag.ToString();
                    //MessageBox.Show(tag);
                    if (tag.Length > 1)
                    {
                        string n = tag.Substring(0, 1);
                        if (n.ToUpper() == "M")
                        {
                            //选中的是组
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎选择的是一个组，您应该选择一个菜单。", 2);
                        }
                        else
                        {
                            //选中的是快捷方式.
                            string zu = tag.Substring(0, tag.IndexOf("*"));
                            string lnkname = tag.Substring(tag.IndexOf("*") + 1, tag.Length - tag.IndexOf("*") - 1);
                            //MessageBox.Show(lnkname);
                            string lnkf = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + zu + "\\" + lnkname;
                            SGFunction.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(lnkf);
                        }
                    }
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"您似乎没有选中一个菜单。", 2); }
            }
            catch { }
        }

        private void MyNormalButton137_Click(object sender, EventArgs e)
        {
            try
            {
                int count = treeView3.Nodes.Count;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\Group" + (count + 1).ToString();
                SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(path);
                SGSystemStyle.Win8Style.WinXMenu.SystemStyle_LoadWinXMenu(this);
                SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"成功添加了新的组。", 2); 
                //Class_SystemStyle.SystemStyle_LoadWinXMenu(this);
                //MyFunctions.Dialogs.MessageDialog("新建组成功", @"成功新建了菜单组.重启资源管理器后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                //MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
            }
            catch { }
        }

        private void MyNormalButton_close_Click(object sender, EventArgs e)
        {
            //Application.ExitThread();
            this.ShellMainDialog();
        }

        private void MyNormalButton_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SGForm_Function_SystemStyle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SGForm_Function_SystemStyle_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void MyNormalButton89_Click(object sender, EventArgs e)
        {
            SGSystemStyle.IconAndLinkMgr.TaskBarMgr.SetTaskBarIcons_MoreFunction();
        }

        private void listView8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(sgTreeView2.SelectedNode !=null)
                {
                    if(sgTreeView2.SelectedNode.Tag.ToString()=="SD")
                    {
                        //MyNormalButton23.Enabled = MyNormalButton27.Enabled = false;
                        //备份ToolStripMenuItem.Enabled = 还原ToolStripMenuItem.Enabled = false;
                        if(listView8.SelectedItems.Count ==1)
                        {
                            //获取文件格式
                            string cmd = listView8.SelectedItems[0].SubItems[1].Text;
                            string ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(cmd);
                            if(ext.ToUpper()=="LNK")
                            {
                                MyNormalButton24.Enabled = true;
                                toolStripMenuItem5.Enabled = true;
                            }
                            else
                            {
                                MyNormalButton24.Enabled = false;
                                toolStripMenuItem5.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        //MyNormalButton23.Enabled = MyNormalButton27.Enabled = true;
                        //备份ToolStripMenuItem.Enabled = 还原ToolStripMenuItem.Enabled = true;
                        MyNormalButton24.Enabled = true;
                        toolStripMenuItem5.Enabled = true;
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton90_Click(object sender, EventArgs e)
        {
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("继续？", "您确定要清空剪切板吗？您复制到剪切板的内容都会被删除。", "继续", "取消", "b2", "ques");
            if(res=="b1")
            {
                Clipboard.Clear();
                sgTextBox_clip.Visible = pictureBox_clip.Visible = false;
                MyNormalButton_clipsave.Visible = false;
                sgLabel_noneirong.Visible = true;
            }
        }

        private void sgCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void sgCheckBox8_OnCheckedChange(object sender, SGCheckBox.MyEventArgs e)
        {
            MessageBox.Show(e.CheckedValue.ToString());
        }

        private void sgCheckBox3_CheckedChanged(object sender, SGCheckBox.MyEventArgs e)
        {
            bool res = false;
            string text = "关联到右键菜单";
            if (sgCheckBox3.Checked == true)
            {
                res = SGFunction.RunCommand.ShellSGProgram("clipmgr", true, true, true, @"/RE");
            }
            else
            {
                res = SGFunction.RunCommand.ShellSGProgram("clipmgr", true, true, true, @"/UR");
                text = "取消关联右键菜单";
            }
            if (res == true) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功" + text, 2); } else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法" + text, 2); }
        }

        private void sgCheckBox6_OnCheckedChange(object sender, SGCheckBox.MyEventArgs e)
        {
            sgCombobox_letter.Enabled = sgCheckBox6.Checked;
        }

        private void sgCheckBox7_OnCheckedChange(object sender, SGCheckBox.MyEventArgs e)
        {
            SGSystemStyle.SystemBoot.LockScreenImage.RegRightMenu(sgCheckBox7.Checked);
        }

        private void MyNormalButton26_Click_1(object sender, EventArgs e)
        {
            string res=SGFunction.CommonDialogs.ShowAddRightMenuDialog("添加预设的菜单");
            if(res=="ok")
            {
                try
                {
                    if (sgTreeView2.SelectedNode != null)
                    {
                        string j = sgTreeView2.SelectedNode.Tag.ToString();
                        switch (j)
                        {
                            case "DK":
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDesktopMenu(this);
                                break;
                            case "MC":
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadMyComputer(this);
                                break;
                            case "FL":
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFile(this);
                                break;
                            case "FO":
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFolder(this);
                                break;
                            case "DI":
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllDisk(this);
                                break;
                            case "EX":
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadExeFile(this);
                                break;
                            case "LK":
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadLnkFile(this);
                                break;
                            case "TX":
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadTxtFile(this);
                                break;
                            case "DL":
                                SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDLLFile(this);
                                break;
                        }
                    }
                }
                catch { }
            }
        }

        private void sgCombobox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sgCombobox3.SelectedIndex >= 0) { SGSystemStyle.IconAndLinkMgr.CLSIDIcon.LoadCLSIDConfig(sgCombobox3.SelectedIndex, this); }
            }
            catch { }
        }

        private void MyNormalButton141_Click(object sender, EventArgs e)
        {
            try
            {
                if(sgCombobox3.Tag !=null)
                {
                    string cfg = sgCombobox3.Tag.ToString();
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == false) { return; }
                    SGUserControl_CLSIDMGR k = new SGUserControl_CLSIDMGR("create_menu", cfg, this, 0);
                    SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("添加新的CLSID菜单", k);
                }
            }
            catch { }
        }

        private void MyNormalButton140_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgTreeView_clsidicon.SelectedNode == null && sgCombobox3.Tag ==null) { return; }
                if(sgTreeView_clsidicon.SelectedNode.Tag !=null)
                {
                    string[] tag = (string[])sgTreeView_clsidicon.SelectedNode.Tag;
                    if(tag[0].ToUpper()=="MAIN")
                    {
                        SGUserControl_CLSIDMGR k = new SGUserControl_CLSIDMGR("EDITMAIN", sgCombobox3.Tag.ToString(), this, sgTreeView_clsidicon.SelectedNode.Index, tag);
                        SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑CLSID菜单配置文件", k);
                    }
                    else
                    {
                        SGUserControl_CLSIDMGR k = new SGUserControl_CLSIDMGR("EDIT", sgCombobox3.Tag.ToString(), this, sgTreeView_clsidicon.SelectedNode.Index, tag);
                        SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("编辑CLSID菜单", k);
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton142_Click(object sender, EventArgs e)
        {
            try
            {
                if(sgTreeView_clsidicon.SelectedNode !=null && sgCombobox3.Tag !=null)
                {
                    if(sgTreeView_clsidicon.SelectedNode.Tag !=null)
                    {
                        string[] tags = (string[])sgTreeView_clsidicon.SelectedNode.Tag;
                        if(tags[0].ToUpper()=="MAIN")
                        {
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("您选中的是CLSID图标信息，无法删除。",2);
                        }
                        else
                        {
                            bool o=SGSystemStyle.IconAndLinkMgr.CLSIDIcon.DeleteCLSIDMenu(this, sgCombobox3.Tag.ToString(), sgTreeView_clsidicon.SelectedNode.Index + 1);
                            if (o == true) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功删除了指定的CLSID图标菜单。", 2); }
                        }
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton138_Click(object sender, EventArgs e)
        {
            try
            {
                SGSystemStyle.IconAndLinkMgr.CLSIDIcon.LoadDefaultCLSIDConfig(this, sgCombobox3.SelectedIndex);
            }
            catch { }
        }

        private void MyNormalButton139_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgCombobox3.Tag != null)
                {
                    bool res = SGSystemStyle.IconAndLinkMgr.CLSIDIcon.CreateCLSIDIconInSystem(sgCombobox3.Tag.ToString());
                    if (res == true) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功生成图标", 2); SGFunction.SystemFunctionAndInformation.UpdateDesktop(); }
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到CLSID图标配置文件",2); }
            }
            catch { }
        }

        private void MyNormalButton93_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (sgCombobox3.Tag != null)
                {
                    string jk = SGFunction.CommonDialogs.MessageDialog_MustClick("继续删除？","您确定要从系统中删除这个CLSID图标？","继续","取消","b2","ques");
                    if(jk=="b1")
                    {
                        bool res = SGSystemStyle.IconAndLinkMgr.CLSIDIcon.DeleteCLSIDIconInSystem(sgCombobox3.Tag.ToString());
                        if (res == true) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功删除了CLSID图标", 2); SGFunction.SystemFunctionAndInformation.UpdateDesktop(); }
                    }
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到CLSID图标配置文件", 2); }
            }
            catch { }
        }

        private void MyNormalButton144_Click(object sender, EventArgs e)
        {
            string tt_dqstxt="COS";
            string tt_anyos = "AOS";
            if(sgRadioButton_diskmgr_anysystem.Checked ==true)
            {
                SGSystemStyle.FileMgr.DriveMgr.ApplyDriveInfo(sgLabel_dm_drive.Text, sgTextBox_drive_ico.Text, sgTextBox_drive_label.Text, this,tt_anyos);
            }
            else
            {
                if(sgRadioButton_diskmgr_setcurrsystem.Enabled ==true )
                {
                    SGSystemStyle.FileMgr.DriveMgr.ApplyDriveInfo(sgLabel_dm_drive.Text, sgTextBox_drive_ico.Text, sgTextBox_drive_label.Text, this,tt_dqstxt);
                }
            }
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功美化了您的磁盘",2);
        }

        private void MyNormalButton143_Click(object sender, EventArgs e)
        {
            try
            {
                string[] tsk = new string[] { "使用系统图标(推荐)","自定义的图标(ICO)"};
                string ico = @"%windir%\system32\imageres.dll,62|%windir%\system32\imageres.dll,67";
                string ch = SGFunction.CommonDialogs.ChooseTaskDialog("选择驱动器图标的来源", tsk, ico);
                string targetico = "";
                switch(ch)
                {
                    case "t1":
                        string res="";
                        targetico = SGFunction.CommonDialogs.SelectIconDialog("选择驱动器图标", @"%windir%\system32\imageres.dll,30", out res);
                        if (res != "ok") { targetico = ""; } else { sgRadioButton_diskmgr_anysystem.Enabled = false; sgRadioButton_diskmgr_setcurrsystem.Enabled = true; sgRadioButton_diskmgr_setcurrsystem.Checked = true; }
                        break;
                    case "t2":
                        string f = SGFunction.CommonDialogs.OpenFileDialog("选择图标", "图标(*.ICO)|*.ICO", true, "");
                        targetico = f;
                        if (f != "") { sgRadioButton_diskmgr_setcurrsystem.Enabled = true; sgRadioButton_diskmgr_anysystem.Enabled = true;}
                        break;
                }
                if(targetico !="")
                {
                    sgTextBox_drive_ico.Text = targetico;
                    pictureBox_drive_iconlogo.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(targetico);
                }
                
            }
            catch { }
        }

        private void MyNormalButton145_Click(object sender, EventArgs e)
        {
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("继续还原？", "您确定要还原磁盘的默认设置吗？", "继续", "取消", "b2", "ques");
            if (res == "b1")
            {
                SGSystemStyle.FileMgr.DriveMgr.ReconfigDriveInfo(sgLabel_dm_drive.Text);
                //REG
                SGSystemStyle.FileMgr.DriveMgr.ApplyDriveInfo(sgLabel_dm_drive.Text, "", "", this, "COS");
                pictureBox_drive_iconlogo.Image = SGFunction.ImageAndIconOperate.GetFolderOrDiskIcon(sgLabel_dm_drive.Text).ToBitmap();
                sgTextBox_drive_ico.Text = sgTextBox_drive_label.Text = "";
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原了您的磁盘的默认设置", 2);
            }
        }
        private void SGForm_Function_SystemStyle_Load(object sender, EventArgs e)
        {
            this.Text = "系统齿轮 系统外观";
            this.sgItems1.Size = new Size(189, 491);
            this.panel_top.Size  = new Size(891, 65);
            string mcn = SGFunction.ProgramInfo.GetMyComputerName();
            sgTabPageControl8.TabPages[1].Text = mcn + @"窗口";
            sgLabel17.Text = @"管理" + mcn + @"窗口中显示的项目";
            listView5.Groups[0].Header = mcn;
        }

        private void MyNormalButton78_Click_1(object sender, EventArgs e)
        {
            SGFunction.SystemFunctionAndInformation.ShellMyComputer();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            try
            {
                if(sgTreeView2.SelectedNode !=null)
                {
                    string j = sgTreeView2.SelectedNode.Tag.ToString();
                    switch (j)
                    {
                        case "DK":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDesktopMenu(this);
                            break;
                        case "MC":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadMyComputer(this);
                            break;
                        case "FL":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFile(this);
                            break;
                        case "FO":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllFolder(this);
                            break;
                        case "DI":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAllDisk(this);
                            break;
                        case "EX":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadExeFile(this);
                            break;
                        case "LK":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadLnkFile(this);
                            break;
                        case "TX":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadTxtFile(this);
                            break;
                        case "DL":
                            SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadDLLFile(this);
                            break;
                    }
                }
            }
            catch { }
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            string sf = SGFunction.CommonDialogs.OpenFileDialog("选择文件，我们将会自动判断文件的类型。", "所有文件(*.*)|*.*",false);
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sf) == true)
            {
                string ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(sf);
                switch (ext.ToUpper())
                {
                    case "EXE":
                        sgTreeView2.SelectedNode = sgTreeView2.Nodes[5];
                        break;
                    case "LNK":
                        sgTreeView2.SelectedNode = sgTreeView2.Nodes[6];
                        break;
                    case "TXT":
                        sgTreeView2.SelectedNode = sgTreeView2.Nodes[7];
                        break;
                    case "DLL":
                        sgTreeView2.SelectedNode = sgTreeView2.Nodes[8];
                        break;
                    default:
                        string info = SGFunction.FileSystemOperate.FSO_GetFileTypeInfoFromRegistry("." + ext);
                        if (info == "") { info = ext + "文件(*." + ext + ")"; } else { info = info + "(*." + ext + ")"; }
                        imageList_rmmgr_itemslogo.Images.Add(SGFunction.ImageAndIconOperate.GetFileIcon(sf, true));
                        sgTreeView2.Nodes[10].ImageIndex = sgTreeView2.Nodes[10].SelectedImageIndex = imageList_rmmgr_itemslogo.Images.Count - 1;
                        sgTreeView2.Nodes[10].Text = info;
                        sgTreeView2.Nodes[10].Tag = "." + ext;
                        rmmgr_selectfile = "SELECT";
                        SGSystemStyle.RightMenuMgr.RightMenusGroupMgr.LoadAnyFile(this, "." + ext);
                        break;
                }
            }
            else
            {
                //if (sgTreeView2.SelectedNode.Tag.ToString() == "OF") { sgTreeView2.SelectedNode = sgTreeView2.Nodes[0]; }
            }
        }

        private void sgTreeView2_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if(sgChooseBox6.MyChooseChooseChecked ==1)
            {
                //SGSystemStyle.IconAndLinkMgr.DesktopIconsMgr.ChangeDesktopIconShowType("IE", "SHOW");
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有在桌面上显示IE的图标哦，点击右边的按钮显示IE图标。", 2);
            }
            else
            {
                string res;
                string starturl = SGFunction.CommonDialogs.ShowHomePageURLChoose("选择IE图标启动时打开的网页", out res);
                if (res == "ok")
                {
                    string IEGUID = "{BDA87F4F-C3AF-4E08-8167-1B10FC09B081}";
                    string cmd_ie = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\IEXPLORE.EXE """ + starturl + @"""";
                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, "CLSID\\" + IEGUID + @"\shell\open\command", "", cmd_ie);
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功更改了打开的网页。", 2);
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("操作取消。", 2); }
            }
        }

        private void MyNormalButton_moresetting_Click(object sender, EventArgs e)
        {
            sgRightMenus_moresetting.Show(this.MyNormalButton_moresetting, new Point(0,MyNormalButton_moresetting.Size.Height  + 5));
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            string arg = selectfunctioncmd;
            string[] get = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, true, false);
            string exe = Application.ExecutablePath;
            string line = @"/S="""+arg+@"""";
            string infotip = get[1];
            string name = get[0];
            string ico = get[5];
            string lnk=Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\"+name+".lnk";
            SGFunction.SystemFunctionAndInformation.CreateLink(lnk, exe, line, infotip, ico);
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加到桌面。您可以在桌面上直接打开当前的功能。",2);
        }

        private void toolStripMenuItem42_Click(object sender, EventArgs e)
        {
            string arg = selectfunctioncmd;
            string[] get = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, true, false);
            string exe = Application.ExecutablePath;
            string line = @"/S="""+arg+@"""";
            string infotip = get[1];
            string name = get[0];
            string ico = get[5];
            string lnk=SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("TEMP")+"\\"+name+".lnk";
            SGFunction.SystemFunctionAndInformation.CreateLink(lnk, exe, line, infotip, ico);
            SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, lnk);
            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnk);
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加到任务栏。您可以在任务栏上直接打开当前的功能。", 2);
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            string arg = selectfunctioncmd;
            string[] get = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, true, false);
            string exe = Application.ExecutablePath;
            string line = @"/S="""+arg+@"""";
            string infotip = get[1];
            string name = get[0];
            string ico = get[5];
            string lnk=Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)+"\\"+name+".lnk";
            SGFunction.SystemFunctionAndInformation.CreateLink(lnk, exe, line, infotip, ico);
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加到开始菜单。您可以在开始菜单上直接打开当前的功能。", 2);
        }

        private void sgTextBox_drive_ico_TextChanged(object sender, EventArgs e)
        {

        }

        private void sgRadioButton_diskmgr_setcurrsystem_CheckedChanged(object sender, EventArgs e)
        {
            if(sgRadioButton_diskmgr_setcurrsystem.Checked ==true)
            {
                sgTextBox_drive_label.Enabled = false;
            }
            else
            {
                sgTextBox_drive_label.Enabled = true;
            }
        }

        private void sgRadioButton_diskmgr_anysystem_CheckedChanged(object sender, EventArgs e)
        {
            if(sgRadioButton_diskmgr_anysystem.Checked ==true)
            {
                sgTextBox_drive_label.Enabled = true;
            }
        }

        private void tabPage27_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox75_Click(object sender, EventArgs e)
        {

        }

        private void myNormalButton_changeskin_Click(object sender, EventArgs e)
        {
            UserControl_ChooseThemes UC = new UserControl_ChooseThemes(this,mainfrm );
            SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("换肤", UC, true);
        }

        private void sgTabPageControl_third_bootmgr_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch(sgTabPageControl_third_bootmgr.SelectedIndex)
            {
                case 0:
                    this.Start(4, 3, 1);
                    break;
                case 1:
                    this.Start(4, 3, 2);
                    break;
            }
             
        }

        private void sgListView_startupitems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_startup_fromreg_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_startup_fromreg.Checked ==true)
            {
this.sgListView_startupitems_normalitems.Visible = true;
                if(sgListView_startupitems_normalitems.Items.Count  ==0)
                {
                    
                    this.sgListView_startupitems_normalitems.Location = new Point(8, 40);
                    this.sgListView_startupitems_normalitems.Size = new Size(859, 358);
                    SGSystemStyle.SystemBoot.StartupItemsMgr.StartItemfromRegistry.LoadNormalStartupItems(imageList_startupitemsmgr_normalitems, sgListView_startupitems_normalitems);
                }
                
                
            }
            else
            {
                this.sgListView_startupitems_normalitems.Visible = false;
            }
        }

        private void radioButton_startup_formlink_CheckedChanged(object sender, EventArgs e)
        {
            SGListView l = this.sgListView_startupitems_shortcutitems;
            if (radioButton_startup_formlink.Checked == true)
            {
l.Visible = true;
                if (l.Items.Count  ==0)
                {
                    
                    l.Location = new Point(8, 40);
                    l.Size = new Size(859, 358);
                    SGSystemStyle.SystemBoot.StartupItemsMgr.StartItemsformShortcut.LoadShortcutStartupItems(l.LargeImageList, l);
                }



            }
            else
            {
                l.Visible = false;
            }
        }

        private void radioButton_startup_fromtask_CheckedChanged(object sender, EventArgs e)
        {
            SGListView l = this.sgListView_startupitems_taskitems;
            if (radioButton_startup_fromtask.Checked == true)
            {
 l.Visible = true;
                if(l.Items.Count  ==0)
                {

                   
                    l.Location = new Point(8, 40);
                    l.Size = new Size(859, 358);
                    SGSystemStyle.SystemBoot.StartupItemsMgr.StartItemsfromtasks.Load(l.LargeImageList, l);
                }
               
               
            }
            else
            {
                l.Visible = false;
            }
        }

        private void SGForm_Function_SystemStyle_LocationChanged(object sender, EventArgs e)
        {
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\mainprogram.sgcf";
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Main", "location_x", this.Location.X.ToString(), "config", false, cfg);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Main", "location_y", this.Location.Y.ToString(), "config", false, cfg);
        }
        #region 接受消息
        const int WM_COPYDATA = 0x004A;

        protected override void DefWndProc(ref   System.Windows.Forms.Message m)
        {

            switch (m.Msg)
            {

                case 0x004A://处理消息                    



                    COPYDATASTRUCT mystr = new COPYDATASTRUCT();

                    Type mytype = mystr.GetType();

                    mystr = (COPYDATASTRUCT)m.GetLParam(mytype);

                    //MessageBox.Show(mystr.lpData);
                    string txt_messege = mystr.lpData;
                    string[] txts = SGFunction.DataOperate.ConvertStringsToStringArryBySTR(txt_messege, " ");
                    //MessageBox.Show(txts.Length.ToString());
                    string ct;
                    string[] args;
                    SGFunction.RunCommand.GetCommandArgsDetails(txts, out ct, out args);
                    if (ct.ToUpper() == "?" || ct.ToUpper() == "S")
                    {
                        if (ct.ToUpper() == "S")
                        {
                            bool p = SGFunction.RunCommand.ShellSGFunction(this.mainfrm, this, args[0],out  this.mainfrm.sgstyfrm);
                            if (p == true)
                            {
                                this.Visible = true;
                                this.Hide();
                            }
                            else { this.Visible = true; }
                        }
                        else
                        {
                            SGFunction.RunCommand.ShellTextFile("command");
                        }
                    }
                    break;

                default:

                    base.DefWndProc(ref   m);//调用基类函数处理非自定义消息。 

                    break;

            }

        }
        [StructLayout(LayoutKind.Sequential)]

        public struct COPYDATASTRUCT
        {

            public IntPtr dwData;

            public int cbData;

            [MarshalAs(UnmanagedType.LPStr)]

            public string lpData;

        }
        #endregion

        private void radioButton_startup_services_CheckedChanged(object sender, EventArgs e)
        {
            SGListView l = this.sgListView_startupitems_servicesitems;
            if (radioButton_startup_services.Checked == true)
            {
                l.Visible = true;
                if (l.Items.Count == 0)
                {

                    l.Location = new Point(8, 40);
                    l.Size = new Size(859, 358);
                    SGSystemStyle.SystemBoot.StartupItemsMgr.Startitemsfromservices.LoadServicesStartupItems(this.imageList_startmgr_servicesitems, sgListView_startupitems_servicesitems);
                    
                }



            }
            else
            {
                l.Visible = false;
            }
        }

        private void SGForm_Function_SystemStyle_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            string exe = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
            exe = exe.Substring(0, exe.LastIndexOf("."));
            //MessageBox.Show(exe);
            SGFunction.SystemFunctionAndInformation.CloseProcess(exe, false, Application.StartupPath);
        }
    }
}
