using System;
using System.Collections.Generic;
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
using System.Threading;
using System.Security.Principal;

namespace SystemGear
{
    public partial class UserControl_SystemStyle_SystemView : UserControl
    {
        public static string ChooseFunction_Name = "";
        public static string ChooseFunction_Info = "";
        public static string ChooseFunction_Icon_Logo = "";
        public static string ChooseFunction_Icon_Ico = "";
        public static string ChooseFunction_CommandLine = "";
        public object WAVEFormCilp = null;
        [DllImport("User32.dll")]
        public static extern void keybd_event(Byte bVk, Byte bScan, Int32 dwFlags, Int32 dwExtraInfo);
        public string FolderStyle_IconFile;
        public int FirstIndex, SecondIndex;
        public UserControl_SystemStyle_SystemView(int FirstIndex, int SecondIndex)
        {
            InitializeComponent();
            this.FirstIndex = FirstIndex;
            this.SecondIndex = SecondIndex;
        }

        private void UserControl_SystemStyle_SystemView_Load(object sender, EventArgs e)
        {
            tabControl1.Location = new Point(tabControl1.Location.X, -27);
            this.Start(FirstIndex, SecondIndex);
        }
        public void Start(int FirstIndex, int SecondIndex)
        {
            Thread P_thread = new Thread(
                () => //lambda表达式（参数列表）=>{执行语句}  lambda表达式是比匿名方法更加简洁的一种匿名函数语法
                {
                   this.Invoke(new MethodInvoker(delegate()
                    {
                        try
                        {
                            switch (FirstIndex)
                            {
                                default :
                                    tabControl1.SelectedIndex = 0;
                                    Enter_Function01(SecondIndex);
                                    break;
                                case 2:
                                    tabControl1.SelectedIndex = FirstIndex - 1;
                                    Enter_Function02(SecondIndex);
                                    break;
                                case 3:
                                    tabControl1.SelectedIndex = FirstIndex - 1;
                                    Enter_Function03(SecondIndex);
                                    break;
                                case 4:
                                    tabControl1.SelectedIndex = FirstIndex - 1;
                                    Enter_Function04(SecondIndex);
                                    break;
                                case 5:
                                    tabControl1.SelectedIndex = FirstIndex - 1;
                                    Enter_Function05(SecondIndex);
                                    break;
                                case 6:
                                    tabControl1.SelectedIndex = FirstIndex - 1;
                                    Enter_Function06(SecondIndex);
                                    break;
                                case 7:
                                    tabControl1.SelectedIndex = FirstIndex - 1;
                                    Enter_Function07(SecondIndex);
                                    break;
                                case 8:
                                    tabControl1.SelectedIndex = FirstIndex - 1;
                                    Enter_Function08(SecondIndex);
                                    break;
                                case 9:
                                    tabControl1.SelectedIndex = FirstIndex - 1;
                                    Enter_Function09(SecondIndex);
                                    break;
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
        public void Enter_Function01(int SecondIndex)
        {
            //绘制左侧栏的样式
            myNormalButton33.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton33.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
            myNormalButton34.ButtonBackColor = myNormalButton35.ButtonBackColor = myNormalButton36.ButtonBackColor = myNormalButton37.ButtonBackColor = myNormalButton38.ButtonBackColor = myNormalButton39.ButtonBackColor =myNormalButton82.ButtonBackColor = myNormalButton40.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
            myNormalButton34.ButtonForceColor = myNormalButton35.ButtonForceColor = myNormalButton36.ButtonForceColor = myNormalButton37.ButtonForceColor = myNormalButton38.ButtonForceColor = myNormalButton39.ButtonForceColor =myNormalButton82.ButtonForceColor = myNormalButton40.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton33.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S01", false);
            ////////////////
            myNormalButton34.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S02", true);
            myNormalButton35.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S03", true);
            myNormalButton36.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S04", true);
            myNormalButton37.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S05", true);
            myNormalButton38.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S06", true);
            myNormalButton39.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S07", true);
            myNormalButton40.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S08", true);
            myNormalButton82.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S09", true);
            //绘制子选项卡
            switch (SecondIndex)
            {
                case 2:
                    myNormalButton42.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton42.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton41.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton41.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton43.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton43.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton44.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton44.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton75.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton75.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /01 /02";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,0";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于设置系统图标的样式";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "系统图标";
                    tabControl2.SelectedIndex = 1;
                    Class_SystemStyle.SystemStyle_LoadSysIconsToListView(this);
                    break;
                case 5:
                    myNormalButton75.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton75.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton41.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton41.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton43.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton43.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton44.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton44.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton42.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton42.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /01 /05";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,0";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = @"将您最常用的程序锁定到""开始""屏幕";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "Win8 磁贴";
                    tabControl2.SelectedIndex = 4;
                    break;
                case 3:
                    myNormalButton43.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton43.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton41.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton41.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton42.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton42.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton44.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton44.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton75.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton75.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    tabControl2.SelectedIndex = 2;
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /01 /03";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,0";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于编辑或创建扩展名";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "扩展名管理";
                    Class_SystemStyle.SystemStyle_LoadExtraName(this);
                    break;
                case 4:
                    myNormalButton44.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton44.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton41.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton41.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton43.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton43.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton42.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton42.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton75.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton75.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    tabControl2.SelectedIndex = 3;
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /01 /04";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,0";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于管理任务栏上的图标";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "任务栏图标";
                    Class_SystemStyle.SystemStyle_LoadTaskBarIcons(this);
                    if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3" || MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.2")
                    {
                        label132.Text = "文件资源管理器";
                    }
                    else
                    {
                        label132.Text = "资源管理器";
                    }
                    pictureBox71.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile, "SystemIcon_UsersFiles", false);
                    pictureBox72.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile, "SystemIcon_MYCOMPUTER", false);
                    pictureBox70.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile, "SystemIcon_NETWORK", false);
                    pictureBox74.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile, "SystemIcon_RECYCLEBIN", false);
                    pictureBox69.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile, "SystemIcon_CONTROLPANEL", false);
                    pictureBox73.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile, "SystemIcon_IE", false);
                    pictureBox75.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.BitmapResourcesWithResFile, "SystemIcon_explorer", false);
                    if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.1") { myNormalButton32.Visible  = false; } else { myNormalButton32.Visible = true; }
                    break;
                default:
                    myNormalButton41.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton41.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton44.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton44.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton43.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton43.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton42.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton42.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton75.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton75.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    pictureBox17.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetResources_GetPowerOperateImage("PowerOperate_PowerOff");
                    pictureBox14.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetResources_GetPowerOperateImage("PowerOperate_lock");
                    pictureBox16.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetResources_GetPowerOperateImage("PowerOperate_restart");
                    pictureBox13.Image = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetResources_GetPowerOperateImage("PowerOperate_logoff");
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /01 /01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,0";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于设置桌面图标的显示状态以及创建电源等实用图标";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "桌面图标";
                    tabControl2.SelectedIndex = 0;
                    Class_SystemStyle.SystemStyle_LoadDesktopIcon(this);
                    Class_SystemStyle.SystemStyle_GetDesktopIconShowOrHideMode(new Form_SystemStyle(), this);
                    Class_SystemStyle.SystemStyle_GetPowerButtonShowOrHideType(this);
                    checkBox1.Enabled = false;
                    if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3")
                    {
                        label6.Text = "这台电脑";
                    }
                    else
                    {
                        label6.Text = "计算机";
                    }
                    if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.2" || MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3")
                    {
                        checkBox1.Enabled = true;
                        panel11.Visible = true;
                    }
                    else
                    {
                        panel11.Visible = false;
                    }
                    break;
            }
        }
        public void Enter_Function02(int SecondIndex)
        {
            //绘制左侧栏的样式
            myNormalButton34.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton34.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
            myNormalButton34.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S02", false);
            ////////////////
            myNormalButton33.ButtonBackColor = myNormalButton35.ButtonBackColor = myNormalButton36.ButtonBackColor = myNormalButton37.ButtonBackColor = myNormalButton38.ButtonBackColor = myNormalButton39.ButtonBackColor = myNormalButton40.ButtonBackColor =myNormalButton82.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
            myNormalButton33.ButtonForceColor = myNormalButton35.ButtonForceColor = myNormalButton36.ButtonForceColor = myNormalButton37.ButtonForceColor = myNormalButton38.ButtonForceColor = myNormalButton39.ButtonForceColor = myNormalButton40.ButtonForceColor =myNormalButton82.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton33.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S01", true);
            myNormalButton35.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S03", true);
            myNormalButton36.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S04", true);
            myNormalButton37.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S05", true);
            myNormalButton38.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S06", true);
            myNormalButton39.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S07", true);
            myNormalButton40.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S08", true);
            myNormalButton82.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S09", true);
            //绘制子选项卡
            switch (SecondIndex)
            {
                case 2:
                    myNormalButton45.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton45.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton46.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton46.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /02 /02";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,1";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S02";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "将一个GUID与一个可执行文件相关联";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "GUID程序";
                    tabControl3.SelectedIndex = 1;
                    textBox29.Text = "{" + Guid.NewGuid().ToString().ToUpper() + "}";
                    break;
                default:
                    myNormalButton46.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton46.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton45.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton45.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /02 /01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,1";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S02";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于新建GUID图标";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "新建GUID图标";
                    tabControl3.SelectedIndex = 0;
                    Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "guidconfigfile", "", true, Application.StartupPath + @"\config\mainprogram.sgcf"), this);
                    break;
            }
        }
        public void Enter_Function03(int SecondIndex)
        {
            //绘制左侧栏的样式
            myNormalButton35.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton35.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
            myNormalButton35.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S03", false);
            ////////////////
            myNormalButton33.ButtonBackColor = myNormalButton34.ButtonBackColor = myNormalButton36.ButtonBackColor = myNormalButton37.ButtonBackColor = myNormalButton38.ButtonBackColor = myNormalButton39.ButtonBackColor = myNormalButton40.ButtonBackColor =myNormalButton82.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
            myNormalButton33.ButtonForceColor = myNormalButton34.ButtonForceColor = myNormalButton36.ButtonForceColor = myNormalButton37.ButtonForceColor = myNormalButton38.ButtonForceColor = myNormalButton39.ButtonForceColor = myNormalButton40.ButtonForceColor =myNormalButton82.ButtonForceColor =MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton34.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S02", true);
            myNormalButton33.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S01", true);
            myNormalButton36.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S04", true);
            myNormalButton37.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S05", true);
            myNormalButton38.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S06", true);
            myNormalButton39.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S07", true);
            myNormalButton40.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S08", true);
            myNormalButton82.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S09", true);
            //绘制子选项卡
            switch (SecondIndex)
            {
                case 2:
                    myNormalButton48.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton48.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton49.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton49.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton47.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton47.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /03 /02";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,2";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S03";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于美化一个或多个驱动器";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "驱动器美化";
                    tabControl4.SelectedIndex = 1;
                    break;
                case 3:
                    myNormalButton47.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton47.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton49.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton49.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton48.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton48.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /03 /03";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,2";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S03";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于对多个种类的文件执行分类处理的操作";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "文件分拣";
                    tabControl4.SelectedIndex = 2;
                    Class_SystemStyle.SystemStyle_SortingFile_LoadCondition(this);
                    break;
                default:
                    myNormalButton49.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton49.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton48.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton48.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton47.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton47.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /03 /01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,2";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S03";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于美化一个或多个文件夹";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "文件夹美化";
                    tabControl4.SelectedIndex = 0;
                    break;
            }
        }
        public void Enter_Function04(int SecondIndex)
        {
            //绘制左侧栏的样式
            myNormalButton36.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton36.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
            myNormalButton36.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S04", false);
            ////////////////
            myNormalButton33.ButtonBackColor = myNormalButton35.ButtonBackColor = myNormalButton34.ButtonBackColor = myNormalButton37.ButtonBackColor = myNormalButton38.ButtonBackColor = myNormalButton39.ButtonBackColor = myNormalButton40.ButtonBackColor =myNormalButton82.ButtonBackColor =MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
            myNormalButton33.ButtonForceColor = myNormalButton35.ButtonForceColor = myNormalButton34.ButtonForceColor = myNormalButton37.ButtonForceColor = myNormalButton38.ButtonForceColor = myNormalButton39.ButtonForceColor = myNormalButton40.ButtonForceColor =myNormalButton82.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton34.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S02", true);
            myNormalButton35.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S03", true);
            myNormalButton33.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S01", true);
            myNormalButton37.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S05", true);
            myNormalButton38.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S06", true);
            myNormalButton39.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S07", true);
            myNormalButton40.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S08", true);
            myNormalButton82.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S09", true);
            //绘制子选项卡
            switch (SecondIndex)
            {
                case 2:
                    myNormalButton52.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton52.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton51.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton51.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton54.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton54.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton50.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton50.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton53.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton53.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /04 /02";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,3";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S04";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "可以添加、删除或编辑一组或多组快捷命令";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "快捷命令";
                    tabControl5.SelectedIndex = 1;
                    Class_SystemStyle.SystemStyle_RunCommands(this);
                    break;
                case 5:
                    myNormalButton54.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton54.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton51.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton51.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton52.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton52.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton50.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton50.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton53.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton53.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /04 /05";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,3";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S04";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = @"可以更改右键菜单的背景图片";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = @"右键菜单背景";
                    tabControl5.SelectedIndex = 4;
                    break;
                case 3:
                    myNormalButton51.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton51.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton52.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton52.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton54.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton54.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton50.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton50.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton53.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton53.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    tabControl5.SelectedIndex = 2;
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /04 /03";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,3";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S04";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "可以将剪切板的内容保存为文件";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "剪切板";
                    
                    Class_SystemStyle.SystemGear_GetJIEQIEBAN(this);
                    break;
                case 4:
                    myNormalButton50.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton50.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton52.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton52.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton54.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton54.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton51.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton51.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton53.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton53.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    tabControl5.SelectedIndex = 3;
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /04 /04";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,3";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S04";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = @"可以管理""发送到""菜单中的项目";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = @"""发送到""菜单";
                    Class_SystemStyle.RightMenuMgr.LoadRightMenu(this, "mc");
                    //Class_SystemStyle.SystemStyle_LoadSendToMenu(this);
                    break;
                default:
                    myNormalButton53.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton53.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton52.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton52.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton54.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton54.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton51.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton51.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton50.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton50.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    tabControl5.SelectedIndex = 0;
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /04 /01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,3";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S04";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于新建多组右键菜单";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "右键菜单组";
                    
                    string sgcf = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "rightmenugroupconfigfile", "", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                    Class_SystemStyle.SystemStyle_LoadRightMenuGroupToTreeview(sgcf, this);
                    break;
            }
        }
        public void Enter_Function05(int SecondIndex)
        {
            //绘制左侧栏的样式
            myNormalButton37.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton37.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
            myNormalButton37.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S05", false);
            ////////////////
            myNormalButton33.ButtonBackColor = myNormalButton35.ButtonBackColor = myNormalButton36.ButtonBackColor = myNormalButton34.ButtonBackColor = myNormalButton38.ButtonBackColor = myNormalButton39.ButtonBackColor = myNormalButton40.ButtonBackColor =myNormalButton82.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
            myNormalButton33.ButtonForceColor = myNormalButton35.ButtonForceColor = myNormalButton36.ButtonForceColor = myNormalButton34.ButtonForceColor = myNormalButton38.ButtonForceColor = myNormalButton39.ButtonForceColor = myNormalButton40.ButtonForceColor =myNormalButton82.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton34.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S02", true);
            myNormalButton35.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S03", true);
            myNormalButton36.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S04", true);
            myNormalButton33.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S01", true);
            myNormalButton38.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S06", true);
            myNormalButton39.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S07", true);
            myNormalButton40.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S08", true);
            myNormalButton82.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S09", true);
            //绘制子选项卡
            switch (SecondIndex)
            {
                case 5:
                    myNormalButton76.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton76.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton58.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton58.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton56.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton56.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton55.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton55.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton57.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton57.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    //this.FIRE_DRAW();
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /05 /05";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,4";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S05";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于更改系统的各项设置";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "Win8 综合设置";
                    tabControl6.SelectedIndex = 4;
                    if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.2" || MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3")
                    {
                        label100.Text = label100.Tag.ToString();
                        label99.Text = label99.Tag.ToString();
                        numericUpDown2.Enabled = myNormalButton81.Enabled = myNormalButton87.Enabled = true;
                        Class_SystemStyle.SystemStyle_LoadWin8Settings(this);
                    }
                    else
                    {
                        label100.Text = "该功能已被禁用";
                        label99.Text = @"不支持您当前所使用的操作系统，该功能仅支持Windows 8以及以上的操作系统。";
                        numericUpDown2.Enabled = myNormalButton87.Enabled = myNormalButton81.Enabled = false;
                    }
                    break;
                case 2:
                    myNormalButton57.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton57.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton58.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton58.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton56.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton56.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton55.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton55.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton76.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton76.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    //this.FIRE_DRAW();
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /05 /02";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,4";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S05";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于更改系统锁屏时的背景";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "锁屏壁纸";
                    tabControl6.SelectedIndex = 1;
                    if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.2")
                    {
                        label70.Text = label70.Tag.ToString();
                        label69.Text = label69.Tag.ToString();
                        textBox32.Enabled = pictureBox76.Enabled = button173.Enabled = button174.Enabled = button175.Enabled = true;
                    }
                    else
                    {
                        label70.Text = "该功能已被禁用";
                        label69.Text = @"不支持您当前所使用的操作系统，该功能仅支持Windows 8/Windows Server 2012。";
                        textBox32.Enabled = pictureBox76.Enabled = button173.Enabled = button174.Enabled = button175.Enabled = false;
                    }
                    break;
                case 3:
                    myNormalButton56.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton56.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton57.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton57.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton58.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton58.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton55.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton55.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton76.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton76.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    tabControl6.SelectedIndex = 2;
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /05 /03";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,4";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S05";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于管理Windows 8操作系统中左下角的Win+X菜单";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "Win+X菜单";
                    if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.1")
                    {
                        label121.Text = "该功能已禁用";
                        label120.Text = "该功能仅支持Windows 8以及以上的操作系统";
                        treeView3.Enabled = false;
                        myNormalButton65.Enabled = myNormalButton66.Enabled = myNormalButton67.Enabled = myNormalButton68.Enabled = myNormalButton69.Enabled = false;
                        myNormalButton70.Enabled = false;
                    }
                    else
                    {
                        myNormalButton66.Enabled = myNormalButton68.Enabled = myNormalButton69.Enabled = false;
                        //myNormalButton70.Enabled = false;
                        
                        Class_SystemStyle.SystemStyle_LoadWinXMenu(this); label120.Text = label120.Tag.ToString(); label121.Text = label121.Tag.ToString();
                    }
                    break;
                case 4:
                    myNormalButton55.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton55.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton57.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton57.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton58.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton58.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton56.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton56.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton76.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton76.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /05 /04";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,4";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S05";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = @"用于管理""这台电脑""的项目";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "This PC";
                    tabControl6.SelectedIndex = 3;
                    if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.2")
                    {
                        label134.Text = "该功能已被禁用";
                        label133.Text = "不支持您当前所使用的操作系统，该功能仅支持Windows 8.1/Windows Server 2012 R2。";
                        listView5.Enabled = false;
                        button164.Enabled = button165.Enabled = button166.Enabled = false;
                    }
                    else
                    {
                        if(MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion()=="6.1")
                        {
                            label134.Text = "该功能已被禁用";
                            label133.Text = "不支持您当前所使用的操作系统，该功能仅支持Windows 8.1/Windows Server 2012 R2。";
                            listView5.Enabled = false;
                            button164.Enabled = button165.Enabled = button166.Enabled = false;
                        }else
                        {
                            Class_SystemStyle.SystemStyle_LoadThisPCShowItems(this);
                            label134.Text = "This PC";
                            label133.Text = @"用于管理Windows 8.1 操作系统中""这台电脑(This PC)""的显示项目";
                            listView5.Enabled = true;
                            button164.Enabled = button165.Enabled = button166.Enabled = true;
                        }
                    }
                    break;
                default:
                    myNormalButton58.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton58.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton57.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton57.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton55.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton55.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton56.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton56.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton76.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton76.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    tabControl6.SelectedIndex = 0;
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /05 /01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,4";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S05";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = @"用于更改Windows 8""开始""的样式以及磁帖的行数";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = @"""开始""屏幕";
                    if(MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion()=="6.1")
                    {
                        label64.Text = @"该功能已禁用";
                        label63.Text = @"该功能仅支持Windows 8以及以上的系统";
                        label47.Text = @"该功能已禁用";
                        label48.Text = @"该功能仅支持Windows 8以及以上的系统";
                        label94.Text = "该功能已禁用";
                        flowLayoutPanel1.Enabled = false;
                        flowLayoutPanel2.Enabled = false;
                        pictureBox48.Enabled = false;
                        panel42.Visible = flowLayoutPanel4.Visible = false;
                        myNormalButton71.Enabled = myNormalButton72.Enabled = myNormalButton73.Enabled = myNormalButton74.Enabled = false;
                    }
                    else
                    {
                        if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.2")
                        {
                            Class_SystemStyle.SystemStyle_LoadWin8StartSrceenColor(this);
                            Class_SystemStyle.SystemStyle_LoadWin8StartSrceenStyle(this);
                            label64.Text = @"""开始""屏幕背景";
                            label63.Text = @"更改""开始""屏幕布局";
                            label47.Text = @"""开始""屏幕个性化";
                            label48.Text = @"更改""开始""屏幕个性色以及背景色";
                            panel42.Visible = false;
                            label94.Text = label94.Tag.ToString();
                            panel42.Visible = flowLayoutPanel4.Visible = false;
                            flowLayoutPanel1.Enabled = true;
                            flowLayoutPanel2.Enabled = true;
                            pictureBox48.Enabled = true;
                            myNormalButton71.Enabled = myNormalButton72.Enabled = myNormalButton73.Enabled = myNormalButton74.Enabled = true;
                        }
                        else
                        {
                            Class_SystemStyle.SystemStyle_LoadStartScreenColorSettingsInWin81(this, 1);
                            panel42.Location = new Point(9, 202);
                            panel42.Visible = true;
                            label64.Text = @"""开始""屏幕背景";
                            label63.Text = @"更改""开始""屏幕背景花纹";
                            label47.Text = @"""开始""屏幕个性化";
                            label48.Text = @"更改""开始""屏幕个性色以及背景色";
                            label94.Text = "该功能已禁用";
                            panel42.Visible = flowLayoutPanel4.Visible = true;
                            flowLayoutPanel1.Visible = false;
                            flowLayoutPanel2.Visible = false;
                            pictureBox48.Visible = false;
                            myNormalButton71.Visible = myNormalButton72.Visible = myNormalButton73.Enabled = myNormalButton74.Enabled = false;
                            flowLayoutPanel4.Location = flowLayoutPanel1.Location;
                            Class_SystemStyle.SystemStyle_LoadWin81StartScreenSetting(this);
                            myNormalButton28.BackgroundImage = MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetWallpaper();
                        }
                    }
                    break;
            }
        }
        public void Enter_Function06(int SecondIndex)
        {
            //绘制左侧栏的样式
            myNormalButton38.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton38.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
            myNormalButton38.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S06", false);
            ////////////////
            myNormalButton33.ButtonBackColor = myNormalButton35.ButtonBackColor = myNormalButton36.ButtonBackColor = myNormalButton37.ButtonBackColor =myNormalButton82.ButtonBackColor = myNormalButton34.ButtonBackColor = myNormalButton39.ButtonBackColor = myNormalButton40.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
            myNormalButton33.ButtonForceColor = myNormalButton35.ButtonForceColor = myNormalButton36.ButtonForceColor = myNormalButton37.ButtonForceColor =myNormalButton82.ButtonForceColor = myNormalButton34.ButtonForceColor = myNormalButton39.ButtonForceColor = myNormalButton40.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton34.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S02", true);
            myNormalButton35.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S03", true);
            myNormalButton36.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S04", true);
            myNormalButton37.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S05", true);
            myNormalButton33.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S01", true);
            myNormalButton39.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S07", true);
            myNormalButton40.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S08", true);
            myNormalButton82.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S09", true);
            //绘制子选项卡
            switch (SecondIndex)
            {
                case 2:
                    myNormalButton59.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton59.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton60.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton60.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /06 /02";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,6";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S06";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于修改系统启动或关机时所播放的音乐";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "开(关)机音乐";
                    tabControl7.SelectedIndex = 1;
                    break;
                default:
                    myNormalButton60.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton60.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton59.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton59.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /06 /01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,6";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S06";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于修改Windows 7操作系统登录时的背景";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "登录背景";
                    if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.1")
                    {
                        tabControl7.SelectedIndex = 0;
                        this.LoadLogonUIImg();
                        label58.Text = label58.Tag.ToString();
                        label57.Text = label57.Tag.ToString();
                        pictureBox19.Enabled = flowLayoutPanel3.Enabled = button66.Enabled = button48.Enabled = button81.Enabled = true;
                    }
                    else
                    {
                        tabControl7.SelectedIndex = 0;
                        label58.Text = "该功能已被禁用";
                        label57.Text = "不支持您当前所使用的操作系统，该功能仅支持Windows 7/Windows Server 2008 R2。";
                        pictureBox19.Enabled = flowLayoutPanel3.Enabled = button66.Enabled = button48.Enabled = button81.Enabled = false;
                    }
                    break;
            }
        }
        public void Enter_Function07(int SecondIndex)
        {
            //绘制左侧栏的样式
            myNormalButton39.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton39.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
            myNormalButton39.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S07", false);
            ////////////////
            myNormalButton33.ButtonBackColor = myNormalButton35.ButtonBackColor = myNormalButton36.ButtonBackColor =myNormalButton82.ButtonBackColor = myNormalButton37.ButtonBackColor = myNormalButton38.ButtonBackColor = myNormalButton34.ButtonBackColor = myNormalButton40.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
            myNormalButton33.ButtonForceColor = myNormalButton35.ButtonForceColor = myNormalButton36.ButtonForceColor =myNormalButton82.ButtonForceColor = myNormalButton37.ButtonForceColor = myNormalButton38.ButtonForceColor = myNormalButton34.ButtonForceColor = myNormalButton40.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton34.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S02", true);
            myNormalButton35.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S03", true);
            myNormalButton36.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S04", true);
            myNormalButton37.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S05", true);
            myNormalButton38.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S06", true);
            myNormalButton33.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S01", true);
            myNormalButton40.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S08", true);
            myNormalButton82.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S09", true);
            //绘制子选项卡
            switch (SecondIndex)
            {

                default:
                    myNormalButton61.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton61.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /07 /01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,5";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S07";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于修改系统的OEM信息以及版本信息";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "自定义信息";
                    Class_SystemStyle.SystemStyle_LoadOEMAndSystemInfo(this);
                    break;
            }
        }
        public void Enter_Function08(int SecondIndex)
        {
            //绘制左侧栏的样式
            myNormalButton40.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton40.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
            myNormalButton40.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S08", false);
            ////////////////
            myNormalButton33.ButtonBackColor = myNormalButton35.ButtonBackColor = myNormalButton36.ButtonBackColor = myNormalButton37.ButtonBackColor = myNormalButton38.ButtonBackColor = myNormalButton39.ButtonBackColor =myNormalButton82.ButtonBackColor = myNormalButton34.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
            myNormalButton33.ButtonForceColor = myNormalButton35.ButtonForceColor = myNormalButton36.ButtonForceColor = myNormalButton37.ButtonForceColor = myNormalButton38.ButtonForceColor = myNormalButton39.ButtonForceColor =myNormalButton82.ButtonForceColor = myNormalButton34.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton34.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S02", true);
            myNormalButton35.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S03", true);
            myNormalButton36.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S04", true);
            myNormalButton37.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S05", true);
            myNormalButton38.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S06", true);
            myNormalButton39.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S07", true);
            myNormalButton82.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S09", true);
            myNormalButton33.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S01", true);
            //绘制子选项卡
            switch (SecondIndex)
            {
                case 2:
                    myNormalButton62.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton62.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton63.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton63.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton64.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton64.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置

                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /08 /02";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,7";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S08";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于修改系统的启动项";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "系统启动菜单";

                    tabControl9.SelectedIndex = 1;
                    Class_SystemStyle.SystemStyle_LoadBCD(this);
                    break;
                case 3:
                    myNormalButton64.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton64.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton63.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton63.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton62.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton62.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /08 /03";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,7";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S08";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于修改开机的动画以及文字";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "启动界面";

                    tabControl9.SelectedIndex = 2;

                    label148.Text = "该功能已被禁用";
                    label147.Text = "该功能目前仍在调试之中";
                    textBox28.Enabled = false;
                    button188.Enabled = button187.Enabled = false;
                    break;
                default:
                    myNormalButton63.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton63.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    ///////////////////////
                    myNormalButton62.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton62.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    myNormalButton64.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
                    myNormalButton64.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /08 /01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,7";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S08";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "用于管理虚拟磁盘";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "虚拟磁盘";
                    comboBox3.SelectedIndex = 0;
                    if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.1")
                    {
                        radioButton4.Enabled = false;
                    }
                    else { radioButton4.Enabled = true; }
                    tabControl9.SelectedIndex = 0;
                    break;
            }
        }
        public void Enter_Function09(int SecondIndex)
        {
            //绘制左侧栏的样式
            myNormalButton82.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton82.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
            myNormalButton82.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S09", false);
            ////////////////
            myNormalButton33.ButtonBackColor = myNormalButton35.ButtonBackColor = myNormalButton36.ButtonBackColor = myNormalButton39.ButtonBackColor = myNormalButton37.ButtonBackColor = myNormalButton38.ButtonBackColor = myNormalButton34.ButtonBackColor = myNormalButton40.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_BackColor();
            myNormalButton33.ButtonForceColor = myNormalButton35.ButtonForceColor = myNormalButton36.ButtonForceColor = myNormalButton39.ButtonForceColor = myNormalButton37.ButtonForceColor = myNormalButton38.ButtonForceColor = myNormalButton34.ButtonForceColor = myNormalButton40.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.ControlStyle.GetLeftSelectControlButton_ForceColor();
            myNormalButton34.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S02", true);
            myNormalButton35.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S03", true);
            myNormalButton36.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S04", true);
            myNormalButton37.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S05", true);
            myNormalButton38.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S06", true);
            myNormalButton33.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S01", true);
            myNormalButton40.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S08", true);
            myNormalButton39.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "S07", true);
            //绘制子选项卡
            switch (SecondIndex)
            {
                default:
                    tabControl11.SelectedIndex = 0;
                    //////////////////////外观按设置完毕 加载功能自定义设置
                    UserControl_SystemStyle_SystemView.ChooseFunction_CommandLine = "/F /SYSVIE /09 /01";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Ico = Application.StartupPath + @"\SFL.DLL,5";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Icon_Logo = "S09";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Info = "调整系统窗口的设置";
                    UserControl_SystemStyle_SystemView.ChooseFunction_Name = "系统窗口";
                    Class_SystemStyle.SystemStyle_LoadOtherSetting(this, "PREVIEWSIZE");
                    break;
            }
        }
        public void LoadLogonUIImg()
        {
            try
            {
                if (MyFunctions.FileSystemOperate.FileSystemOperate_GetFolderExists(Application.StartupPath + @"\Config", true) == true)
                {
                    if (File.Exists(Application.StartupPath + @"\config\logonuiimages.sgcf") == true)
                    {
                        flowLayoutPanel3.Controls.Clear();
                        int imagescount = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "imagescount", "0", false, Application.StartupPath + @"\config\logonuiimages.sgcf"), 0);
                        if (imagescount > 0)
                        {
                            for (int p = 1; p <= imagescount; p++)
                            {
                                PictureBox pic = new PictureBox();
                                flowLayoutPanel3.Controls.Add(pic);
                                pic.Margin = new Padding(0, 0, 0, 0);
                                pic.Size = new Size(141, 80);
                                pic.Tag = p.ToString();
                                pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                string img = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image" + p.ToString(), "image", "", false, Application.StartupPath + @"\config\logonuiimages.sgcf");
                                if (System.IO.File.Exists(img) != false)
                                {
                                    pic.Image = System.Drawing.Image.FromFile(img);
                                }
                                pic.ContextMenuStrip = this.contextMenuStrip4;
                                pic.MouseDown += new MouseEventHandler(this.PublicChooseLogonUI_Click);
                            }
                        }
                    }
                    else
                    {
                        pictureBox19.Image = null;
                        flowLayoutPanel3.Controls.Clear();
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "ImagesCount", "0", "Config", false, Application.StartupPath + @"\Config\LogonUIImages.sgcf");
                    }
                }
            }
            catch
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Start(1, 1);
        }
        private void EnterPublic_Click(object sender, EventArgs e)
        {
            try
            {
                MyNormalButton j = (MyNormalButton)sender;
                int F, S;
                int.TryParse(j.ButtonTags[0], out F);
                int.TryParse(j.ButtonTags[1], out S);
                this.Start(F, S);
            }
            catch { }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Start(2, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Start(3, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Start(4, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Start(5, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button b1 = (Button)sender;//将触发此事件的对象转换为该Button对象
            Form_SystemStyle fg = new Form_SystemStyle();
            switch (b1.Text)
            {
                case "隐藏":
                    Class_SystemStyle.SystemStyle_SetDesktopIcon(fg, this, b1.Tag.ToString().ToUpper(), "HIDE");
                    break;
                case "显示":
                    Class_SystemStyle.SystemStyle_SetDesktopIcon(fg, this, b1.Tag.ToString().ToUpper(), "SHOW");
                    break;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Button B1 = (Button)sender;
            switch (B1.Text)
            {
                case "隐藏":
                    Class_SystemStyle.SystemStyle_SetPowerIcon(B1.Tag.ToString(), "delete", checkBox1.Checked, checkBox2.Checked, this);
                    break;
                case "显示":
                    Class_SystemStyle.SystemStyle_SetPowerIcon(B1.Tag.ToString(), "create", checkBox1.Checked, checkBox2.Checked, this);
                    break;
            }
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            //treeView1.Focus();
        }

        private void button30_MouseDown(object sender, MouseEventArgs e)
        {
            //contextMenuStrip2.Show(button30, new Point(0,button30.Height +5));
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(textBox1.Text) == true)
            {
                int Num = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", false, textBox1.Text), 0);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (Num + 1).ToString(), "Name", "新建子菜单", "GUIDIcon", false, textBox1.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (Num + 1).ToString(), "Icon", Application.ExecutablePath+",0", "GUIDIcon", false, textBox1.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (Num + 1).ToString(), "Command", @"", "GUIDIcon", false, textBox1.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (Num + 1).ToString(), "RunAsAdmin", @"F", "GUIDIcon", false, textBox1.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", (Num + 1).ToString(), "GUIDIcon", false, textBox1.Text);
                Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "guidconfigfile", "None", true, Application.StartupPath + @"\config\mainprogram.sgcf"), this);
                string res = MyFunctions.Dialogs.MessageDialog("新建子菜单成功", "已成功新建一个子菜单,是否进行编辑?", MyFunctions.Dialogs.MessageDialogIcon.Question , "", "b1", true, true, "是", "否");
                if (res == "B1")
                {
                    MyFunctions.Dialogs.SpecialDialog("编辑子菜单", "Command" + (Num + 1).ToString(), new UserControl_CreateOrEditGUIDCommand());
                    Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "guidconfigfile", "None", true, Application.StartupPath + @"\config\mainprogram.sgcf"), this);
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string res = MyFunctions.Dialogs.SpecialDialog("创建新的GUID图标的配置文件", "create", new UserControl_CreateOrEditionGUIDMainInfo());
            Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "GUIDConfigFile", "None", true, Application.StartupPath + @"\config\mainprogram.sgcf"), this);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "GUIDConfigFile", @"%AppPath%\Config\DefaultGUIDIconConfigFile.sgcf", "Config", false, Application.StartupPath + @"\Config\MainProgram.sgcf");
            Class_SystemStyle.SystemStyle_CreateDefaultGUIDIconConfigFile();
            Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(Application.StartupPath + @"\Config\DefaultGUIDIconConfigFile.sgcf", this);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(textBox1.Text) == true)
            {
                string res = MyFunctions.Dialogs.MessageDialog("确定要删除这个配置文件吗?", "删除配置文件可能会导致您的配置信息的丢失,确认继续?", MyFunctions.Dialogs.MessageDialogIcon.Question , "", "b2", true, true, "删除", "取消");
                //MessageBox.Show(res);
                if (res == "B1")
                {
                    treeView1.Nodes.Clear();
                    imageList1.Images.Clear();
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(textBox1.Text);
                    textBox1.Text = "";
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "GUIDConfigFile", Application.StartupPath + @"\Config\DefaultGUIDIconConfigFile.sgcf", "Config", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                    Class_SystemStyle.SystemStyle_CreateDefaultGUIDIconConfigFile();
                    Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(Application.StartupPath + @"\Config\DefaultGUIDIconConfigFile.sgcf", this);
                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(textBox1.Text) == true)
            {
                string res = MyFunctions.Dialogs.SpecialDialog("编辑GUID图标的配置文件", textBox1.Text, new UserControl_CreateOrEditionGUIDMainInfo());
                Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "guidconfigfile", "None", true, Application.StartupPath + @"\config\mainprogram.sgcf"), this);
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != treeView1.SelectedNode.Tag.ToString())
                {
                    if (treeView1.SelectedNode.Tag.ToString().ToUpper() != "MAIN")
                    {
                        MyFunctions.Dialogs.SpecialDialog("编辑子菜单", treeView1.SelectedNode.Tag.ToString(), new UserControl_CreateOrEditGUIDCommand());
                        Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "guidconfigfile", "None", true, Application.StartupPath + @"\config\mainprogram.sgcf"), this);
                    }
                }
            }
            catch { }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            string sgcf = MyFunctions.Dialogs.OpenFileDialog("浏览一个配置文件", "系统齿轮通用配置文件(*.SGCF)|*.SGCF");
            if (sgcf != "")
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "GUIDConfigFile", sgcf, "Config", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(sgcf, this);
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != treeView1.SelectedNode.Tag.ToString().ToUpper())
                {
                    if (treeView1.SelectedNode.Tag.ToString().ToUpper() != "MAIN")
                    {
                        string res = MyFunctions.Dialogs.MessageDialog("删除?", @"是否要删除从GUID图标中删除名为""" + treeView1.SelectedNode.Text + @"""的子菜单", MyFunctions.Dialogs.MessageDialogIcon.Question , "", "b2", true, true, "确定", "取消");
                        if (res == "B1")
                        {
                            try
                            {
                                int SaveCommandItems = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", false, textBox1.Text), 0) - 1;
                                string[] SaveCommand_Name = new string[SaveCommandItems];
                                string[] SaveCommand_Icon = new string[SaveCommandItems];
                                string[] SaveCommand_Command = new string[SaveCommandItems];
                                string[] SaveCommand_CommandLine = new string[SaveCommandItems];
                                string[] SaveCommand_RunAsAdmin = new string[SaveCommandItems];
                                int deleteindex = treeView1.SelectedNode.ImageIndex;

                                int c = 1;
                                for (int y = 1; y <= SaveCommandItems + 1; y = y + 1)
                                {
                                    if (y != deleteindex)
                                    {
                                        SaveCommand_Name[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "name", "", false, textBox1.Text);
                                        SaveCommand_Icon[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "icon", "", false, textBox1.Text);
                                        SaveCommand_Command[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "command", "", false, textBox1.Text);
                                        SaveCommand_RunAsAdmin[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "runasadmin", "", false, textBox1.Text);
                                    }
                                    else
                                    {
                                        c = c + 1;
                                    }
                                }
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", SaveCommandItems.ToString(), "GUIDIcon", false, textBox1.Text);
                                for (int g = 1; g <= SaveCommand_Name.Length; g = g + 1)
                                {
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Name", SaveCommand_Name[g - 1].ToString(), "GUIDIcon", false, textBox1.Text);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Icon", SaveCommand_Icon[g - 1].ToString(), "GUIDIcon", false, textBox1.Text);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Command", SaveCommand_Command[g - 1].ToString(), "GUIDIcon", false, textBox1.Text);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "RunAsAdmin", SaveCommand_RunAsAdmin[g - 1].ToString(), "GUIDIcon", false, textBox1.Text);
                                }
                                Class_SystemStyle.SystemStyle_LoadGUIDConfigFileToTreeview(textBox1.Text, this);
                            }
                            catch
                            {
                            }
                        }
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("不能删除", "不能删除GUID图标的主项目", MyFunctions.Dialogs.MessageDialogIcon.Error , "不能删除GUID图标的主项目", "b2", false, true, "", "确定");
                    }
                }
            }
            catch { }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(textBox1.Text) == true)
            {
                Class_SystemStyle.SystemStyle_CreateGUIDIconInDesktop(textBox1.Text, this.FindForm());
                MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
                MyFunctions.Dialogs.MessageDialog("成功", "成功创建了GUID图标", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            try
            {
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(textBox1.Text) == true)
                {
                    string LoadGUID = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "guid", "", false, textBox1.Text);
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Microsoft.Win32.Registry.ClassesRoot, "CLSID", LoadGUID, false);
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Microsoft.Win32.Registry.LocalMachine, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace", LoadGUID, false);
                    MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
                    MyFunctions.Dialogs.MessageDialog("移除成功", "成功移除了GUID图标!", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
                }
            }
            catch
            {
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            try
            {
                imageList2.Images.Clear();
                listView1.Items.Clear();
                textBox4.Text = textBox5.Text = textBox3.Text = "";
                pictureBox12.Image = null;
                textBox2.Text = MyFunctions.Dialogs.OpenFolder("选择要美化的文件夹或驱动器目录");
                if (MyFunctions.FileSystemOperate.FileSystemOperate_GetFolderExists(textBox2.Text, false) == true)
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\Desktop.ini.sgtmp");
                    FolderStyle_IconFile = "";
                    if (textBox2.Text.Length <= 3)
                    {
                        //label29.Text = "该驱动器目录图标";
                        listView1.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = false;
                        comboBox1.Enabled = false;
                        button36.Visible = button37.Visible = false;
                        button38.Visible = false;
                    }
                    else
                    {
                        label29.Text = "该文件夹的图标";
                        listView1.Enabled = comboBox1.Enabled = button36.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = true;
                        comboBox1.Enabled = true;
                        button36.Visible = button37.Visible = true;
                        button38.Visible = true;
                        MyFunctions.FileSystemOperate.FileSystemOperate_GetFilesAndFoldersToTreeview(textBox2.Text, imageList2, listView1);
                    }
                }
            }
            catch (Exception rrr)
            {
                MyFunctions.Dialogs.MessageDialog("无法美化这个文件夹", "无法美化这个文件夹\r\n" + rrr.Message, MyFunctions.Dialogs.MessageDialogIcon.Error , "无法美化这个文件夹\r\n" + rrr.Message, "b2", false, true, "", "确定");
                textBox2.Text = "";
                listView1.Items.Clear();
                imageList2.Images.Clear();
            }
        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                if (listView1.SelectedItems.Count != 0)
                {
                    textBox4.Text = listView1.SelectedItems[0].SubItems[0].Text;
                }
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (MyFunctions.FileSystemOperate.FileSystemOperate_GetFolderExists(textBox2.Text, false) == true)
            {
                string iconf = MyFunctions.Dialogs.ChooseIcon("选择图标","%windir%\\system32\\imageres.dll,4");
                if (iconf != "")
                {
                    string temppath = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp");
                    string ico = iconf.Substring(0, iconf.LastIndexOf(","));
                    string index = iconf.Substring(iconf.LastIndexOf(",")+1, iconf.Length - iconf.LastIndexOf(",")-1);
                    pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconf, Application.ExecutablePath);
                    MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", ico, false, temppath + @"\Desktop.ini.sgtmp");
                    MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", index, false, temppath + @"\Desktop.ini.sgtmp");
                }
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

        }

        private void button38_Click(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (MyFunctions.FileSystemOperate.FileSystemOperate_GetFolderExists(textBox2.Text, false) == true)
            {
                string temppath = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp");
                MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("LocalizedFileNames", textBox4.Text, textBox5.Text, false, temppath + @"\Desktop.ini.sgtmp");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MyFunctions.FileSystemOperate.FileSystemOperate_GetFolderExists(textBox2.Text, false) == true)
            {
                string temppath = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp");
                string iconfile;
                int IconIndex;
                //MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Application.StartupPath + @"\Temp\desktop.ini.sgtmp");
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        iconfile = Application.ExecutablePath;
                        IconIndex = 0;
                        pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @"," + IconIndex, Application.ExecutablePath);
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", iconfile, false, temppath + @"\Desktop.ini.sgtmp");
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", IconIndex.ToString(), false, temppath + @"\Desktop.ini.sgtmp");
                        break;
                    case 1:
                        iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll";
                        IconIndex = 117;
                        pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @"," + IconIndex, Application.ExecutablePath);
                        FolderStyle_IconFile = iconfile;
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", iconfile, false, temppath + @"\Desktop.ini.sgtmp");
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", IconIndex.ToString(), false, temppath + @"\Desktop.ini.sgtmp");
                        break;
                    case 2:

                        iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll";
                        IconIndex = 104;
                        pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @"," + IconIndex, Application.ExecutablePath);
                        FolderStyle_IconFile = iconfile;
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", iconfile, false, temppath + @"\Desktop.ini.sgtmp");
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", IconIndex.ToString(), false, temppath + @"\Desktop.ini.sgtmp");
                        break;
                    case 3:
                        iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll";
                        IconIndex = 22;
                        pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @"," + IconIndex, Application.ExecutablePath);
                        FolderStyle_IconFile = iconfile;
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", iconfile, false, temppath + @"\Desktop.ini.sgtmp");
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", IconIndex.ToString(), false, temppath + @"\Desktop.ini.sgtmp");
                        break;
                    case 4:
                        iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll";
                        IconIndex = 50;
                        pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @"," + IconIndex, Application.ExecutablePath);
                        FolderStyle_IconFile = iconfile;
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", iconfile, false, temppath + @"\Desktop.ini.sgtmp");
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", IconIndex.ToString(), false, temppath + @"\Desktop.ini.sgtmp");
                        break;
                    case 5:
                        iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll";
                        IconIndex = 20;
                        pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @"," + IconIndex, Application.ExecutablePath);
                        FolderStyle_IconFile = iconfile;
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", IconIndex.ToString(), false, temppath + @"\Desktop.ini.sgtmp");
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", iconfile, false, temppath + @"\Desktop.ini.sgtmp");
                        break;
                    case 6:
                        iconfile = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\Iexplore.exe";
                        IconIndex = 0;
                        pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @"," + IconIndex, Application.ExecutablePath);
                        FolderStyle_IconFile = iconfile;
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", iconfile, false, temppath + @"\Desktop.ini.sgtmp");
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", IconIndex.ToString(), false, temppath + @"\Desktop.ini.sgtmp");
                        break;
                    case 7:
                        iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll";
                        IconIndex = 108;
                        pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @"," + IconIndex, Application.ExecutablePath);
                        FolderStyle_IconFile = iconfile;
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", iconfile, false, temppath + @"\Desktop.ini.sgtmp");
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", IconIndex.ToString(), false, temppath + @"\Desktop.ini.sgtmp");
                        break;
                    case 8:
                        iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll";
                        IconIndex = 107;
                        pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @"," + IconIndex, Application.ExecutablePath);
                        FolderStyle_IconFile = iconfile;
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", iconfile, false, temppath + @"\Desktop.ini.sgtmp");
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", IconIndex.ToString(), false, temppath + @"\Desktop.ini.sgtmp");
                        break;
                    case 9:
                        iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll";
                        IconIndex = 103;
                        pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @"," + IconIndex, Application.ExecutablePath);
                        FolderStyle_IconFile = iconfile;
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", iconfile, false, temppath + @"\Desktop.ini.sgtmp");
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", IconIndex.ToString(), false, temppath + @"\Desktop.ini.sgtmp");
                        break;
                    case 10:
                        iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll";
                        IconIndex = 178;
                        pictureBox12.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @"," + IconIndex, Application.ExecutablePath);
                        FolderStyle_IconFile = iconfile;
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconFile", iconfile, false, temppath + @"\Desktop.ini.sgtmp");
                        MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "IconIndex", IconIndex.ToString(), false, temppath + @"\Desktop.ini.sgtmp");
                        break;
                }
            }
            else
            {
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (MyFunctions.FileSystemOperate.FileSystemOperate_GetFolderExists(textBox2.Text, false) == true)
            {
                string temppath = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp");
                MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue(".ShellClassInfo", "InfoTip", textBox3.Text, false, temppath + @"\Desktop.ini.sgtmp");
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0)
            {
                if (MyFunctions.FileSystemOperate.FileSystemOperate_GetFolderExists(textBox2.Text, false) == true)
                {
                    if (textBox2.Text.Length <= 3)
                    {
                    }
                    else
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_SetFileAttribute(textBox2.Text + @"\Desktop.ini", System.IO.FileAttributes.Normal);
                        if (MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\Desktop.ini.sgtmp", textBox2.Text + @"\Desktop.ini") == true)
                        {
                            MyFunctions.FileSystemOperate.FileSystemOperate_SetFileAttribute(textBox2.Text + @"\Desktop.ini", System.IO.FileAttributes.Hidden);
                            MyFunctions.Dialogs.MessageDialog("美化文件夹成功", @"已成功美化""" + textBox2.Text + @"""", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
                        }
                    }
                }
                //Class_PublicFunctions.Public_ReBuildIconsCache();
                MyFunctions.ProgramAndLinksOperate.ShellPrograms("explorer.exe", "explorer /select," + textBox2.Text, false, false, false, false, false);
            }
        }

        private void button38_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0 && textBox2.Text.Length > 3)
            {
                if (MyFunctions.FileSystemOperate.FileSystemOperate_GetFolderExists(textBox2.Text, false) == true)
                {
                    string res = MyFunctions.Dialogs.MessageDialog("是否要还原?", "还原设置可能会导致您的配置丢失,继续?", MyFunctions.Dialogs.MessageDialogIcon.Question , "", "b2", true, true, "继续", "取消");
                    if (res == "B1")
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_SetFileAttribute(textBox2.Text + @"\Desktop.ini", System.IO.FileAttributes.Normal);
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(textBox2.Text + @"\Desktop.ini");
                        imageList2.Images.Clear();
                        listView1.Items.Clear();
                        textBox4.Text = textBox5.Text = textBox3.Text = "";
                        pictureBox12.Image = null;
                        MyFunctions.Dialogs.MessageDialog("已成功还原设置", "已成功将您的文件夹的信息还原至初始状态", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "取消");
                    }
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Start(1, 1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Start(1, 2);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Start(2, 1);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Start(2, 2);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Start(3, 1);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Start(3, 2);
        }

        private void button39_Click(object sender, EventArgs e)
        {

        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button55_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string Number = b.Tag.ToString();
            Class_SystemStyle.SystemStyle_SetWin8StartSrceenStyle(Number, this);

            keybd_event(0x5b, 0, 0, 0); //0x5b是left win的代码，这一句使key按下，下一句使key释放。
            keybd_event(0x5b, 0, 0x2, 0);
        }

        private void tabPage13_Click(object sender, EventArgs e)
        {

        }

        private void button49_Click(object sender, EventArgs e)
        {

        }

        private void button47_Click(object sender, EventArgs e)
        {

        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (label155.Text != "未选择驱动器")
            {
                if (radioButton1.Checked == true)
                {
                    string exefile = MyFunctions.Dialogs.OpenFileDialog("选择一个可执行文件", "可执行文件(*.exe;*.bat;*.cmd;*.com)|*.exe;*.bat;*.cmd;*.com");
                    if (exefile != "")
                    {
                        textBox8.Text = exefile;
                    }
                }
                else
                {
                    string exefile = MyFunctions.Dialogs.OpenFileDialog("选择一个文件", "所有文件(*.*)|*.*");
                    if (exefile != "")
                    {
                        textBox8.Text = exefile;
                    }
                }
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (label155.Text != "未选择驱动器")
            {
                string iconfile = MyFunctions.Dialogs.InputDialog("请选择驱动器的图标文件", "请选择驱动器的图标文件", false, "filechoose", "图标文件(*.ico)|*.ico", "", "");
                if (iconfile != "")
                {
                    textBox6.Text = iconfile;
                    pictureBox15.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(iconfile + @",0", Application.ExecutablePath +@",0");
                }
                else
                {
                    textBox6.Text = "";
                    pictureBox15.Image = null;
                }
            }
        }

        private void button39_Click_1(object sender, EventArgs e)
        {
            if (label155.Text  != "未选择驱动器")
            {
                try
                {
                        //MessageBox.Show(comboBox2.SelectedItem.ToString());
                        if (textBox6.Text != "")
                        {
                            //string noloa = textBox6.Text.Substring(textBox6.Text.LastIndexOf("\\"), textBox6.Text.Length - textBox6.Text.LastIndexOf("\\")).Replace("\\","");
                            //MessageBox.Show(noloa);
                            MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("Autorun", "Icon", "Icon.ico", false, label155.Text  + @"\Autorun.inf");
                            MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(textBox6.Text, label155.Text + @"\Icon.ico");
                            //MyFunctions.FileSystemOperate.FileSystemOperate_SetFileAttribute(label155.Text + @"\Icon.ico", FileAttributes.Hidden);
                            //MyFunctions.FileSystemOperate.FileSystemOperate_SetFileAttribute(label155.Text + @"\Icon.ico", FileAttributes.System);
                        }
                        if (textBox7.Text != "")
                        {
                            MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_WriteValue("Autorun", "Label", textBox7.Text, false, label155.Text + @"\Autorun.inf");
                        }
                        if (textBox8.Text != "")
                        {
                            if (radioButton1.Checked == true)
                            {
                            }
                        }
                        //MyFunctions.FileSystemOperate.FileSystemOperate_SetFileAttribute(label155.Text + @"\Autorun.inf", FileAttributes.Hidden);
                        //MyFunctions.FileSystemOperate.FileSystemOperate_SetFileAttribute(label155.Text + @"\autorun.inf", FileAttributes.System);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("attrib.exe", @"""" + label155.Text + @"\Autorun.inf"" +a +r +s +h", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("attrib.exe", @"""" + label155.Text + @"\Icon.ico"" +a +r +s +h", true, false, true, false, true);
                        MyFunctions.Dialogs.MessageDialog("成功", @"成功美化驱动器 """ + label155.Text + @"""", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
                        MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
                }
                catch (Exception err)
                {
                }
            }
        }

        private void button65_Click(object sender, EventArgs e)
        {

        }

        private void button64_Click_1(object sender, EventArgs e)
        {
            if (label155.Text != "未选择驱动器")
            {
                string res = MyFunctions.Dialogs.MessageDialog("您确定要还原吗?", "您确定由还原驱动器的图标吗?", MyFunctions.Dialogs.MessageDialogIcon.Question , "", "B2", true, true, "是", "否");
                if (res == "B1")
                {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("attrib.exe", @"""" + label155.Text + @"\autorun.inf"+" -a -r -h -s", true, false, true,false,true);
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("attrib.exe", @"""" + label155.Text + @"\icon.ico"+" -a -r -h -s", true, false, true,false,true);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(label155.Text + @"\autorun.inf");
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(label155.Text + @"\Icon.ico");
                    MyFunctions.Dialogs.MessageDialog("还原成功", "成功还原驱动器的图标", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "B2", false, true, "是", "确定");
                }
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            string sgcf = MyFunctions.Dialogs.OpenFileDialog("选择一个右键菜单组的图标", "系统齿轮通用配置文件(*.SGCF)|*.SGCF");
            if (File.Exists(sgcf) == true)
            {
                textBox12.Text = sgcf;
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "RightMenuGroupConfigFile", sgcf, "Config", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                Class_SystemStyle.SystemStyle_LoadRightMenuGroupToTreeview(sgcf, this);
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (MyFunctions.Dialogs.MessageDialog("继续?", "您是否要载入默认的配置文件?可能会丢失已经设置好的信息", MyFunctions.Dialogs.MessageDialogIcon.Question , "", "b2", true, true, "继续", "取消") == "B1")
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "RightMenuGroupConfigFile", @"%AppPath%\Config\DefaultRightMenuGroup.sgcf", "Config", false, Application.StartupPath + @"\Config\MainProgram.sgcf");
                Class_SystemStyle.SystemStyle_CreateDefaultRightMenuConfigFile();
                Class_SystemStyle.SystemStyle_LoadRightMenuGroupToTreeview(Application.StartupPath + @"\Config\DefaultRightMenuGroup.sgcf", this);
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            try
            {
                if (MyFunctions.Dialogs.MessageDialog("继续?", "删除现有的配置文件会丢失已经设置好的信息", MyFunctions.Dialogs.MessageDialogIcon.Question , "", "b2", true, true, "继续", "取消") == "B1")
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(textBox12.Text);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "RightMenuGroupConfigFile", @"%AppPath%\Config\DefaultRightMenuGroup.sgcf", "Config", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                    Class_SystemStyle.SystemStyle_CreateDefaultRightMenuConfigFile();
                    Class_SystemStyle.SystemStyle_LoadRightMenuGroupToTreeview(Application.StartupPath + @"\Config\DefaultRightMenuGroup.sgcf", this);
                }
            }
            catch
            {
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Start(4, 1);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Start(4, 2);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox12.Text) == true)
            {
                if (treeView2.Nodes.Count > 0)
                {
                    MyFunctions.Dialogs.SpecialDialog("编辑右键菜单的配置文件", textBox12.Text, new UserControl_CreateOrEditRightMenuGroupConfigFile());
                    string sgcf = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "rightmenugroupconfigfile", "", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                    Class_SystemStyle.SystemStyle_LoadRightMenuGroupToTreeview(sgcf, this);
                }
            }
        }

        private void button65_Click_1(object sender, EventArgs e)
        {
            MyFunctions.Dialogs.SpecialDialog("新建右键菜单的配置文件", "CREATE", new UserControl_CreateOrEditRightMenuGroupConfigFile());
            string sgcf = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "rightmenugroupconfigfile", "", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
            Class_SystemStyle.SystemStyle_LoadRightMenuGroupToTreeview(sgcf, this);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(textBox12.Text) == true)
                {
                    if (treeView2.SelectedNode != null)
                    {
                        if (treeView2.SelectedNode.Text != "分隔符" && treeView2.SelectedNode.Tag.ToString().ToUpper() != "MAIN")
                        {
                            MyFunctions.Dialogs.SpecialDialog("编辑右键菜单中的子菜单", treeView2.SelectedNode.Tag.ToString().ToUpper(), new UserControl_EditCommandInRightMenuGroup());
                            string sgcf = textBox12.Text;
                            Class_SystemStyle.SystemStyle_LoadRightMenuGroupToTreeview(sgcf, this);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox12.Text) == true)
            {
                contextMenuStrip2.Show(button43, new Point(0, button43.Height + 5));
            }
        }

        private void 子菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cmdcount = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", false, textBox12.Text), 0);
            if (cmdcount < 15)
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", (cmdcount + 1).ToString(), "RightMenuGroup", false, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "RegName", "SystemGear.Command" + (cmdcount + 1).ToString(), "RightMenuGroup", false, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "Name", "新建的菜单(" + (cmdcount + 1).ToString() + ")", "RightMenuGroup", false, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "Icon", Application.ExecutablePath+",0", "RightMenuGroup", true, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "Command", Application.ExecutablePath, "RightMenuGroup", true, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "RunAsAdmin", "F", "RightMenuGroup", false, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "IsFenGeFu", "F", "RightMenuGroup", false, textBox12.Text);
                MyFunctions.Dialogs.SpecialDialog("编辑右键菜单中的子菜单", "Command" + (cmdcount + 1).ToString(), new UserControl_EditCommandInRightMenuGroup());
                string sgcf = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "rightmenugroupconfigfile", "", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                Class_SystemStyle.SystemStyle_LoadRightMenuGroupToTreeview(sgcf, this);
            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("提示", "由于Windows 操作系统的限制,右键菜单的数目不能超过十六项.请删除一些多余的子菜单以解决这个问题", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
            }
        }

        private void 分隔符ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cmdcount = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", false, textBox12.Text), 0);
            if (cmdcount < 15)
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", (cmdcount + 1).ToString(), "RightMenuGroup", false, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "RegName", "", "RightMenuGroup", false, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "Name", "", "RightMenuGroup", false, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "Icon", "", "RightMenuGroup", true, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "Command", "", "RightMenuGroup", true, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "RunAsAdmin", "", "RightMenuGroup", false, textBox12.Text);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "IsFenGeFu", "T", "RightMenuGroup", false, textBox12.Text);
                string sgcf = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("systemstyle", "rightmenugroupconfigfile", "", true, Application.StartupPath + @"\Config\MainProgram.sgcf");
                Class_SystemStyle.SystemStyle_LoadRightMenuGroupToTreeview(sgcf, this);
            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("提示", "由于Windows 操作系统的限制,右键菜单的数目不能超过十六项.请删除一些多余的子菜单以解决这个问题", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox12.Text) == true)
            {
                if (null != treeView2.SelectedNode.Tag.ToString().ToUpper())
                {
                    if (treeView2.SelectedNode.Tag.ToString().ToUpper() != "MAIN")
                    {
                        string res = MyFunctions.Dialogs.MessageDialog("删除?", @"是否要删除从GUID图标中删除名为""" + treeView2.SelectedNode.Text + @"""的子菜单", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "确定", "取消");
                        if (res == "B1")
                        {
                            try
                            {
                                int SaveCommandItems = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", false, textBox12.Text), 0) - 1;
                                string[] SaveCommand_Name = new string[SaveCommandItems];
                                string[] SaveCommand_Icon = new string[SaveCommandItems];
                                string[] SaveCommand_Command = new string[SaveCommandItems];
                                string[] SaveCommand_RegName = new string[SaveCommandItems];
                                string[] SaveCommand_RunAsAdmin = new string[SaveCommandItems];
                                string[] SaveCommand_IsFenGeFu = new string[SaveCommandItems];
                                int deleteindex = treeView2.SelectedNode.ImageIndex;
                                int c = 1;
                                for (int y = 1; y <= SaveCommandItems + 1; y = y + 1)
                                {
                                    if (y != deleteindex)
                                    {
                                        SaveCommand_RegName[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "regname", "", false, textBox12.Text);
                                        SaveCommand_Name[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "name", "", false, textBox12.Text);
                                        SaveCommand_Icon[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "icon", "", false, textBox12.Text);
                                        SaveCommand_Command[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "command", "", false, textBox12.Text);
                                        SaveCommand_RunAsAdmin[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "runasadmin", "", false, textBox12.Text);
                                        SaveCommand_IsFenGeFu[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "isfengefu", "", false, textBox12.Text);
                                    }
                                    else
                                    {
                                        c = c + 1;
                                    }
                                }
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", SaveCommandItems.ToString(), "RightMenuGroup", false, textBox12.Text);
                                for (int g = 1; g <= SaveCommand_Name.Length; g = g + 1)
                                {
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "RegName", SaveCommand_RegName[g - 1].ToString(), "RightMenuGroup", false, textBox12.Text);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Name", SaveCommand_Name[g - 1].ToString(), "RightMenuGroup", false, textBox12.Text);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Icon", SaveCommand_Icon[g - 1].ToString(), "RightMenuGroup", false, textBox12.Text);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Command", SaveCommand_Command[g - 1].ToString(), "RightMenuGroup", false, textBox12.Text);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "RunAsAdmin", SaveCommand_RunAsAdmin[g - 1].ToString(), "RightMenuGroup", false, textBox12.Text);
                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "IsFenGeFu", SaveCommand_IsFenGeFu[g - 1].ToString(), "RightMenuGroup", false, textBox12.Text);
                                }
                                Class_SystemStyle.SystemStyle_LoadRightMenuGroupToTreeview(textBox12.Text, this);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox12.Text) == true)
            {
                Class_SystemStyle.RightMenu_CreateRightMenuGroup(textBox12.Text);
                MyFunctions.Dialogs.MessageDialog("成功", "成功创建了右键菜单组!", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox12.Text) == true)
            {
                string res = MyFunctions.Dialogs.MessageDialog("继续?", "您确定要删除这一组的右键菜单?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "继续", "取消");
                if (res == "B1")
                {
                    string MainName = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "regname", "", false, textBox12.Text);
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"*\Shell", MainName, false);
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\background\shell", MainName, false);
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\shell", MainName, false);
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"LibraryFolder\background\shell", MainName, false);
                    int CommandsNum = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", false, textBox12.Text), 0);
                    for (int p = 1; p <= CommandsNum; p = p + 1)
                    {
                        string CMDREGName = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + p.ToString(), "regname", "", false, textBox12.Text);
                        MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell", CMDREGName, false);
                    }
                    MyFunctions.Dialogs.MessageDialog("移除成功", "成功移除了右键菜单组!", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                }
            }
        }

        private void button47_Click_1(object sender, EventArgs e)
        {
            this.Start(6, 1);
        }

        private void button80_Click(object sender, EventArgs e)
        {
            this.Start(7, 1);
        }
        private void PublicChooseLogonUI_Click(object sender, MouseEventArgs e)
        {
            PictureBox p1 = (PictureBox)sender;//将触发此事件的对象转换为该Button对象
            if (p1.Image != null)
            {
                pictureBox19.Image = p1.Image;
                pictureBox19.Tag = p1.Tag;
            }
        }

        private void button66_Click(object sender, EventArgs e)
        {
            string img = MyFunctions.Dialogs.OpenFileDialog("选择一个图片", "图像文件(*.JPG;*.BMP;*.JIF;*.PNG)|*.JPG;*.BMP;*.JIF;*.PNG");
            if (img != "")
            {
                pictureBox19.Image = System.Drawing.Image.FromFile(img);
                int old = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MainInfo", "ImagesCount", "0", false, Application.StartupPath + @"\Config\LogonUIImages.sgcf"), 0);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "ImagesCount", (old + 1).ToString(), "Config", false, Application.StartupPath + @"\Config\LogonUIImages.sgcf");
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Image" + (old + 1).ToString(), "Image", img, "Config", false, Application.StartupPath + @"\Config\LogonUIImages.sgcf");
                this.LoadLogonUIImg();
            }
        }

        private void button48_Click_1(object sender, EventArgs e)
        {
            if (pictureBox19.Image != null)
            {
                Rectangle rect = new Rectangle();
                rect = Screen.GetBounds(this);
                int wd = rect.Width;//屏幕宽
                int he = rect.Height;//屏幕高
               MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_SaveImageAsFile(pictureBox19.Image, System.Drawing.Imaging.ImageFormat.Jpeg, wd, he, MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\LogonUIImage.sgtmp");
                MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(@"%windir%\system32\oobe\info\backgrounds");
                MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\LogonUIImage.sgtmp", @"%windir%\system32\oobe\info\backgrounds\backgroundDefault.jpg");
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Background", "OEMBackground", "1", RegistryValueKind.DWord, false, false);
                string res = MyFunctions.Dialogs.MessageDialog("应用成功", "已成功修改您的登录界面,是否立即查看效果?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                if (res == "B1")
                {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("rundll32.exe", "user32.dll,LockWorkStation", false, false, false, false, false);
                }
            }
        }

        private void button81_Click(object sender, EventArgs e)
        {
            string res = MyFunctions.Dialogs.MessageDialog("是否继续?", "是否要继续还原为系统默认?这会导致您丢失已设置好的信息", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
            if (res == "B1")
            {
                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Application.StartupPath + @"\config\logonuiimages.sgcf");
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Background", "OEMBackground", "0", RegistryValueKind.DWord, false, false);
                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(@"%windir%\system32\oobe\info\backgrounds\backgroundDefault.jpg");
                this.LoadLogonUIImg();
            }
        }

        private void 删除这个图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string kj = MyFunctions.Dialogs.MessageDialog("是否要删除?", "是否要删除这个历史记录?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                if (kj == "B1")
                {
                    int old = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MainInfo", "ImagesCount", "0", false, Application.StartupPath + @"\Config\LogonUIImages.sgcf"), 0);
                    if (old > 1)
                    {
                        pictureBox19.Image = null;
                        string[] SaveImagefilename = new string[old - 1];
                        int deleteindex = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(pictureBox19.Tag.ToString(), 1);
                        //MessageBox.Show(deleteindex.ToString());
                        int c = 1;
                        for (int y = 1; y <= old; y = y + 1)
                        {
                            if (y != deleteindex)
                            {

                                SaveImagefilename[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image" + y.ToString(), "Image", "", false, Application.StartupPath + @"\Config\LogonUIImages.sgcf");
                            }
                            else
                            {
                                c = c + 1;
                            }
                        }
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "ImagesCount", (old - 1).ToString(), "Config", false, Application.StartupPath + @"\Config\LogonUIImages.sgcf");
                        for (int d = 1; d <= SaveImagefilename.Length; d++)
                        {
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Image" + d.ToString(), "Image", SaveImagefilename[d - 1].ToString(), "Config", false, Application.StartupPath + @"\config\logonuiimages.sgcf");
                        }
                        this.LoadLogonUIImg();
                    }
                    else
                    {
                        if (old == 1)
                        {
                            pictureBox19.Image = null;
                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Application.StartupPath + @"\config\logonuiimages.sgcf");
                            this.LoadLogonUIImg();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void 删除所有记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Application.StartupPath + @"\config\logonuiimages.sgcf");
            this.LoadLogonUIImg();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Start(5, 1);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Start(5, 2);
        }

        private void button83_Click(object sender, EventArgs e)
        {
            string img = MyFunctions.Dialogs.OpenFileDialog("选择一个图片", "图像文件(*.JPG;*.BMP;*.JIF;*.PNG)|*.JPG;*.BMP;*.JIF;*.PNG");
            if (File.Exists(img) == true)
            {
                textBox14.Text = img;
                pictureBox46.Image = System.Drawing.Image.FromFile(img);
            }
        }

        private void button84_Click(object sender, EventArgs e)
        {
            Class_SystemStyle.SystemStyle_SetOEMInfo(textBox9.Text, textBox15.Text, textBox10.Text, textBox11.Text, textBox13.Text, pictureBox46.Image);
            MyFunctions.Dialogs.MessageDialog("应用成功", "已成功修改您的OEM信息", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "是", "确定");
            MyFunctions.ProgramAndLinksOperate.ShellPrograms("control.exe", "/name Microsoft.System", false, false, false, false, false);
        }

        private void button85_Click(object sender, EventArgs e)
        {
            string res = MyFunctions.Dialogs.MessageDialog("继续?", "您确定要还原您的OEM信息设置?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "是", "否");
            if (res == "B1")
            {
                Class_SystemStyle.SystemStyle_SetOEMInfo("", "", "", "", "", null);
                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\OEMLogo.bmp");
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", "Logo", "", RegistryValueKind.ExpandString, false, false);
                pictureBox46.Image = null;
                Class_SystemStyle.SystemStyle_LoadOEMAndSystemInfo(this);
                MyFunctions.Dialogs.MessageDialog("还原成功", "已还原您的OEM信息", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "是", "确定");
                MyFunctions.ProgramAndLinksOperate.ShellPrograms("control.exe", "/name Microsoft.System", false, false, false, false, false);
            }
        }

        private void button89_Click(object sender, EventArgs e)
        {
            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\SystemInfo.reg");
            MyFunctions.ProgramAndLinksOperate.ShellPrograms("reg.exe", @"export ""HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion"" """ + MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\SystemInfo.reg""", true, false, true, false, true);
            MyFunctions.Dialogs.MessageDialog("备份成功", "已备份您的信息", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
        }

        private void button86_Click(object sender, EventArgs e)
        {
            string fol = MyFunctions.Dialogs.OpenFolder("选择文件夹");
            if (Directory.Exists(fol) == true)
            {
                textBox18.Text = fol;
            }
        }

        private void button87_Click(object sender, EventArgs e)
        {
            if (File.Exists(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\SystemInfo.reg") == true)
            {
                Class_SystemStyle.SystemStyle_SetSystemInfo(textBox16.Text, textBox17.Text, textBox18.Text, textBox19.Text, textBox21.Text, textBox22.Text);
                MyFunctions.Dialogs.MessageDialog("应用成功", "已成功修改了系统信息.部分设置需要重启后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
            }
            else
            {
                string res = MyFunctions.Dialogs.MessageDialog("提示", @"我们建议您在应用之前备份您的注册表点击""是""备份并应用设置,点击""否""直接应用", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                if (res == "B1")
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\SystemInfo.reg");
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("reg.exe", @"export ""HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion"" """ + MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\SystemInfo.reg""", true, false, true, false, true);
                    Class_SystemStyle.SystemStyle_SetSystemInfo(textBox16.Text, textBox17.Text, textBox18.Text, textBox19.Text, textBox21.Text, textBox22.Text);
                    MyFunctions.Dialogs.MessageDialog("应用成功", "已成功修改了系统信息.部分设置需要重启后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                }
                else
                {
                    if (res == "B2")
                    {
                        Class_SystemStyle.SystemStyle_SetSystemInfo(textBox16.Text, textBox17.Text, textBox18.Text, textBox19.Text, textBox21.Text, textBox22.Text);
                        MyFunctions.Dialogs.MessageDialog("应用成功", "已成功修改了系统信息.部分设置需要重启后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    }
                }
            }
            Class_SystemStyle.SystemStyle_LoadOEMAndSystemInfo(this);
        }

        private void button88_Click(object sender, EventArgs e)
        {
            string res = MyFunctions.Dialogs.MessageDialog("继续?", @"是否要还原默认设置?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "继续", "取消");
            if (res == "B1")
            {
                if (File.Exists(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\SystemInfo.reg") == true)
                {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("REGEDIT.EXE", @"/s """ + MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\SystemInfo.reg""", true, false, true, false, true);
                    MyFunctions.Dialogs.MessageDialog("还原成功", "已成功还原了系统信息.部分设置需要重启后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                }
                else
                {
                    MyFunctions.Dialogs.MessageDialog("错误", "无法找到备份的文件", MyFunctions.Dialogs.MessageDialogIcon.Error, @"找不到指定的文件""" + MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\SystemInfo.reg""", "b2", false, true, "", "确定");
                }
                Class_SystemStyle.SystemStyle_LoadOEMAndSystemInfo(this);
            }
        }

        private void button49_Click_1(object sender, EventArgs e)
        {
            this.Start(6, 1);
        }

        private void button90_Click(object sender, EventArgs e)
        {
            this.Start(6, 2);
        }

        private void button91_Click(object sender, EventArgs e)
        {
            string f = MyFunctions.Dialogs.OpenFileDialog("选择一个文件", "Windows 音频文件(*.wav)|*.wav");
            if (File.Exists(f) == true)
            {
                textBox20.Text = f;
            }
        }

        private void button98_Click(object sender, EventArgs e)
        {
            string f = MyFunctions.Dialogs.OpenFileDialog("选择一个文件", "Windows 音频文件(*.wav)|*.wav");
            if (File.Exists(f) == true)
            {
                textBox23.Text = f;
            }
        }

        private void button93_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox20.Text) == true)
            {
                MyFunctions.MediaAndResourcesOperate.AudioOperate.PlaySound(textBox20.Text);
            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("错误", "无法播放指定的文件", MyFunctions.Dialogs.MessageDialogIcon.Error, @"找不到指定的文件""" + textBox20.Text + @"""", "b2", false, true, "", "确定");
            }
        }

        private void button94_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox20.Text) == true)
            {
                string orgfile = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\Imageres.dll";
                string bakfile = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\Imageres.dll.sgbak";
                MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll", bakfile);
                if (File.Exists(orgfile) == true)
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(orgfile);
                }
                MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll", orgfile);
                MyFunctions.FileSystemOperate.FileSystemOperate_ChangeFileResources(textBox20.Text, orgfile, "WAVE", 5080, 1033);
                MyFunctions.FileSystemOperate.FileSystemOperate_GetAdminWithFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll");
                MyFunctions.Dialogs.MessageDialog("即将完成", "程序已准备好文件,需要重启两次资源管理器.请先结束有关的程序!否则替换会失败", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                bool re = MyFunctions.ProgramAndLinksOperate.CloseProcess("explorer");
                if (re == false)
                {
                    MyFunctions.Dialogs.MessageDialog("错误", "无法终止Windows Explorer的进程.操作失败", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                }
                else
                {
                    //MyFunctions.ProgramAndLinksOperate.ShellPrograms("taskkill.exe", "/im explorer.exe /f", true, false, true, false, true, null);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(orgfile, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll");
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", "/c explorer && tskill explorer", true, false, false, false, false);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(orgfile);
                    MyFunctions.Dialogs.MessageDialog("操作成功", "已成功修改系统的开机音乐", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                }
            }
        }

        private void button95_Click(object sender, EventArgs e)
        {
            string res = MyFunctions.Dialogs.MessageDialog("继续?", @"您确定要还原设置吗?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "确定", "取消");
            if (res == "B1")
            {
                if (File.Exists(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\Imageres.dll.sgbak") == true)
                {
                    MyFunctions.Dialogs.MessageDialog("即将完成", "程序已准备好文件,需要重启两次资源管理器", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    bool re = MyFunctions.ProgramAndLinksOperate.CloseProcess("explorer");
                    if (re == false)
                    {
                        MyFunctions.Dialogs.MessageDialog("错误", "无法终止Windows Explorer的进程.操作失败", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                    }
                    else
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\Imageres.dll.sgbak", Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll");
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", "/c explorer && tskill explorer", true, false, false, false, true);
                        MyFunctions.Dialogs.MessageDialog("操作成功", "已成功还原系统的开机音乐", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    }
                }
                else
                {
                    MyFunctions.Dialogs.MessageDialog("错误", "无法找到备份的文件", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                }
            }
        }

        private void button97_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox23.Text) == true)
            {
                MyFunctions.MediaAndResourcesOperate.AudioOperate.PlaySound(textBox20.Text);
            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("错误", "无法播放指定的文件", MyFunctions.Dialogs.MessageDialogIcon.Error, @"找不到指定的文件""" + textBox23.Text + @"""", "b2", false, true, "", "确定");
            }
        }

        private void button96_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox23.Text) == true)
            {
                string res = MyFunctions.Dialogs.MessageDialog("继续", @"是否继续修改关机的音乐", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                if (res == "B1")
                {
                    string media = Environment.GetEnvironmentVariable("windir") + @"\Media\Windows Shutdown.wav";
                    MyFunctions.FileSystemOperate.FileSystemOperate_GetAdminWithFile(media);
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(media, MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"Windows Shutdown.wav.sgbak");
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(textBox23.Text, media);
                    MyFunctions.Dialogs.MessageDialog("操作成功", "已成功修改系统的关机音乐", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                }
            }
        }

        private void button92_Click(object sender, EventArgs e)
        {
            string res = MyFunctions.Dialogs.MessageDialog("继续", @"是否继续还原关机的音乐", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "是", "否");
            if (res == "B1")
            {
                string media = Environment.GetEnvironmentVariable("windir") + @"\Media\Windows Shutdown.wav";
                string bakfile = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"Windows Shutdown.wav.sgbak";
                if (System.IO.File.Exists(bakfile) == true)
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(bakfile, media);
                    MyFunctions.Dialogs.MessageDialog("操作成功", "已成功还原系统的关机音乐", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                }
                else
                {
                    MyFunctions.Dialogs.MessageDialog("错误", "无法找到备份的文件", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                }
            }
        }

        private void tabPage23_Click(object sender, EventArgs e)
        {

        }

        private void button99_Click(object sender, EventArgs e)
        {
            this.Start(8, 1);
        }

        private void button104_Click(object sender, EventArgs e)
        {
            this.Start(1, 3);
        }

        private void button106_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems != null)
            {
                try
                {
                    string extra_name = listView2.SelectedItems[0].SubItems[0].Text;
                    string iconf = MyFunctions.Dialogs.ChooseIcon("选择一个图标文件", @"%windir%\system32\imageres.dll,2");
                    string extra_NoPointName = extra_name.Replace(".", "");
                    string extra_BiaoShiName = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, extra_name, "", "", false, false); ;
                    if (iconf != "")
                    {
                        string res = MyFunctions.Dialogs.MessageDialog("提示", @"我们建议您在应用之前备份注册表.点击""是""备份并应用设置,点击""否""直接应用", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                        if (res == "B1")
                        {
                            MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\ExtraNames");
                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\ExtraNames\" + extra_NoPointName + @".reg");
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("reg.exe", @"export ""HKCR\" + extra_BiaoShiName + @""" """ + MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\ExtraNames\" + extra_name.Replace(".", "") + @".reg""", true, false, true, false, true);
                            //MyFunctions.Dialogs.MessageDialog("备份成功", "已备份您的信息", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定", null);
                        }
                        bool p = MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, extra_BiaoShiName + @"\DefaultIcon", "", iconf, RegistryValueKind.String, false, false);
                        if (p == true)
                        {
                            string g = MyFunctions.Dialogs.MessageDialog("修改成功", "已成功修改您的扩展名的图标,但需要重新启动Windows 资源管理器,是否重启资源管理器?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                            if (g == "B1")
                            {
                                MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void button107_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems != null)
                {
                    string extra_name = listView2.SelectedItems[0].SubItems[0].Text;
                    string extra_NoPointName = extra_name.Replace(".", "");
                    string extra_BiaoShiName = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, extra_name, "", "", false, false);
                    string res = MyFunctions.Dialogs.MessageDialog("继续?", @"您确定要还原这个扩展名的图标吗?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "是", "否");
                    if (res == "B1")
                    {
                        string back = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\ExtraNames\" + extra_NoPointName + ".reg";
                        if (File.Exists(back) == true)
                        {
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("Regedit.exe", @"/s """ + back + @"""", true, false, true, false, true);
                            string k = MyFunctions.Dialogs.MessageDialog("还原成功", @"已成功还原指定的扩展名的图标.是否重启Windows 资源管理器以生效?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                            if (k == "B1")
                            {
                                MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                            }
                        }
                        else
                        {
                            MyFunctions.Dialogs.MessageDialog("错误", @"无法还原您的设置,备份的文件不存在", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "是", "确定");
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void button105_Click(object sender, EventArgs e)
        {
            MyFunctions.Dialogs.SpecialDialog("创建新的扩展名", "", new UserControl_CreateNewExtraName());
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            PictureBox b = (PictureBox)sender;
            Class_SystemStyle.SystemStyle_SetWin8StartSrceenColor(b.Tag.ToString(), this);
            MyFunctions.Dialogs.MessageDialog("修改成功!", "修改成功,重启资源管理器或注销登录后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
        }

        private void button79_Click(object sender, EventArgs e)
        {
            string res = MyFunctions.Dialogs.MessageDialog("继续?", "您确定要注销登录吗?在注销之前请保存您的文档,以及关闭正在运行的程序.", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "继续", "取消");
            if (res == "B1")
            {
                MyFunctions.ProgramAndLinksOperate.ShellPrograms("shutdown.exe", "/l", true, false, false, false, false);
            }
        }


        private void pictureBox52_Click(object sender, EventArgs e)
        {
        }

        private void button101_Click(object sender, EventArgs e)
        {
            if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.1")
            {
                openFileDialog1.Filter = "虚拟磁盘文件(*.vhd)|*.vhd";
                openFileDialog1.ShowDialog();
                textBox24.Text = openFileDialog1.FileName;
            }
            else
            {
                openFileDialog1.Filter = "虚拟磁盘文件(*.vhd;*.vhdx)|*.vhd;*.vhdx";
                openFileDialog1.ShowDialog();
                textBox24.Text = openFileDialog1.FileName;
                string exname = Path.GetExtension(textBox24.Text);
                if (exname.ToUpper().Replace(".", "") == "VHDX")
                {
                    radioButton4.Checked = true;
                }
                else
                {
                    radioButton3.Checked = true;
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox27.Enabled = true;
            }
            else
            {
                textBox27.Enabled = false;
            }
        }

        private void button102_Click(object sender, EventArgs e)
        {
            if (textBox24.Text != "" && MyFunctions.StreamAndTextOperate.IntOperate.VeifyIntIsNotStrings(textBox25.Text) == true)
            {
                if (MyFunctions.FileSystemOperate.FileSystemOperate_GetFileExtraName(textBox24.Text).ToUpper() == "VHDX" || MyFunctions.FileSystemOperate.FileSystemOperate_GetFileExtraName(textBox24.Text).ToUpper() == "VHD")
                {
                    if (MyFunctions.FileSystemOperate.FileSystemOperate_GetFileExtraName(textBox24.Text).ToUpper() == "VHDX" && MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.1")
                    {
                        MyFunctions.Dialogs.MessageDialog("无法创建虚拟磁盘文件", "无法创建虚拟磁盘文件,因为您目前的操作系统不支持VHDX格式的虚拟磁盘文件", MyFunctions.Dialogs.MessageDialogIcon.Exclamatory , "", "b2", false, true, "", "确定");
                    }
                    else
                    {
                        int VD_Size;
                        string VD_File = textBox24.Text;
                        string VD_Letter = textBox27.Text;
                        switch (comboBox3.SelectedIndex)
                        {
                            case 0:
                                VD_Size = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(textBox25.Text, 0);
                                break;
                            case 1:
                                VD_Size = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(textBox25.Text, 0) * 1024;
                                break;
                            default:
                                VD_Size = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(textBox25.Text, 0) * 1024 * 1024;
                                break;
                        }
                        if (System.IO.File.Exists(VD_File) == true)
                        {
                            MyFunctions.Dialogs.MessageDialog("虚拟磁盘文件已存在", "无法创建虚拟磁盘文件,因为文件已存在", MyFunctions.Dialogs.MessageDialogIcon.Exclamatory , @"已存在的文件""" + VD_File + @"""", "b2", false, true, "", "确定");
                        }
                        else
                        {
                            string createtext = "fixed";
                            if (radioButton6.Checked == true)
                            {
                                createtext = "expandable";
                            }
                            MyFunctions.Dialogs.MessageDialog("即将开始", "即将开始创建虚拟磁盘,这个过程可能需要花费几分钟甚至更多", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "开始");
                            if (checkBox3.Checked == true)
                            {
                                //MessageBox.Show(@"/CL /""" + VD_File + @""" /" + VD_Size.ToString() + @" /" + createtext + " /" + VD_Letter);
                                MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\Programs\VDiskMgr.exe", @"/CL /""" + VD_File + @""" /" + VD_Size.ToString() + @" /" + createtext + " /" + VD_Letter, false, false, true, false, true);
                            }
                            else
                            {
                                MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\Programs\VDiskMgr.exe", @"/OC /""" + VD_File + @""" /" + VD_Size.ToString() + @" /" + createtext, false, false, true, false, true);
                            }
                            MyFunctions.Dialogs.MessageDialog("创建成功", "已成功创建虚拟磁盘文件", MyFunctions.Dialogs.MessageDialogIcon.Information, @"已成功创建了 """ + VD_File + @"""", "b2", false, true, "", "确定");
                        }
                    }
                }
                else
                {
                    MyFunctions.Dialogs.MessageDialog("虚拟磁盘文件扩展名无效", "无法创建虚拟磁盘文件,因为虚拟磁盘的文件的扩展名无效",MyFunctions.Dialogs.MessageDialogIcon.Exclamatory , "", "b2", false, true, "", "确定");
                }
            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("无法创建虚拟磁盘", "无法创建虚拟磁盘文件,因为您所输入的一个或多个参数无效", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
            }
        }

        private void textBox25_Leave(object sender, EventArgs e)
        {
            if (textBox25.Text != "")
            {
                if (MyFunctions.StreamAndTextOperate.IntOperate.VeifyIntIsNotStrings(textBox25.Text) == false)
                {
                    MyFunctions.Dialogs.MessageDialog("输入非法", @"""" + textBox25.Text + @"""不是有效的整数", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                    textBox25.Text = "";
                    textBox25.Focus();
                }

            }
        }

        private void button114_Click(object sender, EventArgs e)
        {
            try
            {
                string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
                string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
                string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
                string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
                string IEGUID = "{4B6C7757-AAF6-46AF-A2D2-D31CEE866228}";
                if (listView3.SelectedItems != null)
                {
                    string iconfile = MyFunctions.Dialogs.ChooseIcon("选择一个图标", @"%windir%\system32\imageres.dll,2");
                    if (iconfile != "")
                    {
                        switch (listView3.SelectedItems[0].Group.ToString())
                        {
                            case "桌面图标":
                                switch (listView3.SelectedItems[0].Tag.ToString().ToUpper())
                                {
                                    case "UF":
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + UFGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString, false, false);
                                        break;
                                    case "MC":
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + MCGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString, false, false);
                                        break;
                                    case "NK":
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + NKGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString, false, false);
                                        break;
                                    case "CP":
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + CPGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString, false, false);
                                        break;
                                    case "IE":
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + IEGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString, false, false);
                                        break;
                                    case "RB_D":
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString, false, false);
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Empty", iconfile, RegistryValueKind.ExpandString, false, false);
                                        break;
                                    case "RB_F":
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Full", iconfile, RegistryValueKind.ExpandString, false, false);
                                        break;
                                }
                                break;
                            case "驱动器":
                                if (iconfile != "")
                                {
                                    string shell_index = listView3.SelectedItems[0].Tag.ToString().ToUpper();
                                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_index, iconfile, RegistryValueKind.ExpandString, false, false);
                                }
                                break;
                            case "文件(夹)":
                                switch (listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(0, 1))
                                {
                                    case "S":
                                        string shell_index = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(1, 2), 0).ToString();
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_index, iconfile, RegistryValueKind.ExpandString, false, false);
                                        break;
                                    case "G":
                                        string guid = listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(1, listView3.SelectedItems[0].Tag.ToString().Length - 1);
                                        //MessageBox.Show(guid);
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + guid + @"\DefaultIcon", "", iconfile, RegistryValueKind.ExpandString, false, false);
                                        break;
                                }
                                break;
                            case "其他图标":
                                string shell_indexO = listView3.SelectedItems[0].Tag.ToString().ToUpper();
                                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_indexO, iconfile, RegistryValueKind.ExpandString, false, false);
                                break;
                        }
                        ;
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
                        button123.Enabled = true;
                    }
                    else
                    {
                        button123.Enabled = false;
                    }
                    button126.Enabled = false;
                    if (listView3.SelectedItems[0].Text == "快捷方式箭头")
                    {
                        button126.Enabled = true;
                    }
                }
            }
            catch { }
        }

        private void button125_Click(object sender, EventArgs e)
        {
            try
            {
                string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
                string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
                string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
                string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
                string IEGUID = "{4B6C7757-AAF6-46AF-A2D2-D31CEE866228}";
                if (listView3.SelectedItems != null)
                {
                    string res = MyFunctions.Dialogs.MessageDialog("继续?", "您确定有恢复默认的设置?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "继续", "取消");
                    if (res == "B1")
                    {
                        switch (listView3.SelectedItems[0].Group.ToString())
                        {
                            case "桌面图标":
                                string cfg = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_ConfigPath() + @"\SystemIcons.sgcf";
                                string def_ico = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("DESK_" + listView3.SelectedItems[0].Tag.ToString(), "ORG_ICON_DEFAULT", "", false, cfg);
                                string def_name = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("DESK_" + listView3.SelectedItems[0].Tag.ToString(), "ORG_name", "", false, cfg);
                                switch (listView3.SelectedItems[0].Tag.ToString().ToUpper())
                                {
                                    case "UF":
                                        MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", UFGUID, false);
                                        break;
                                    case "NK":
                                        MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", NKGUID, false);
                                        break;
                                    case "CP":
                                        MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", CPGUID, false);
                                        break;
                                    case "IE":
                                        MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", IEGUID, false);
                                        break;
                                    case "MC":
                                        MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", MCGUID, false);
                                        break;
                                    case "RB_D":
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "", def_ico, RegistryValueKind.ExpandString, false, false);
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Empty", def_ico, RegistryValueKind.ExpandString, false, false);
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID, "", @"", RegistryValueKind.ExpandString, false, false);
                                        break;
                                    case "RB_F":
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Full", def_ico, RegistryValueKind.ExpandString, false, false);
                                        MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID, "", @"", RegistryValueKind.ExpandString, false, false);
                                        break;
                                }
                                break;
                            case "驱动器":
                                string shell_index = listView3.SelectedItems[0].Tag.ToString().ToUpper();
                                MyFunctions.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_index);
                                break;
                            case "文件(夹)":
                                switch (listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(0, 1))
                                {
                                    case "S":
                                        string shell_indexS = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(1, 2), 0).ToString();
                                        MyFunctions.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_indexS);
                                        break;
                                    case "G":
                                        string guid = listView3.SelectedItems[0].Tag.ToString().ToUpper().Substring(1, listView3.SelectedItems[0].Tag.ToString().Length - 1);
                                        MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", guid, false);
                                        break;
                                }
                                break;
                            case "其他图标":
                                string shell_indexO = listView3.SelectedItems[0].Tag.ToString().ToUpper();
                                MyFunctions.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_indexO);
                                break;
                        }
                        MyFunctions.Dialogs.MessageDialog("还原成功", "还原图标成功!", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        string res1 = MyFunctions.Dialogs.MessageDialog("立即生效?", "是否重启Windows 资源管理器来完成设置?这可能会导致您所打开的文件夹的窗口被关闭", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "继续", "取消");
                        if (res1 == "B1")
                        {
                            MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                        }
                        Class_SystemStyle.SystemStyle_LoadSysIconsToListView(this);
                    }
                }
            }
            catch { }
        }

        private void button124_Click(object sender, EventArgs e)
        {
            string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
            string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
            string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
            string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
            string IEGUID = "{4B6C7757-AAF6-46AF-A2D2-D31CEE866228}";
            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", UFGUID, false);
            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", NKGUID, false);
            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", CPGUID, false);
            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", IEGUID, false);
            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", MCGUID, false);
            MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "", @"%SystemRoot%\System32\Imageres.dll,50", RegistryValueKind.ExpandString, false, false);
            MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Empty", @"%SystemRoot%\System32\Imageres.dll,50", RegistryValueKind.ExpandString, false, false);
            MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID + @"\DefaultIcon", "Full", @"%SystemRoot%\System32\Imageres.dll,49", RegistryValueKind.ExpandString, false, false);
            MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID, "", @"", RegistryValueKind.ExpandString, false, false);
            for (int a = 7; a <= 15; a = a + 1)
            {
                string index = listView3.Items[a].Tag.ToString();
                MyFunctions.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", index);
            }
            for (int b = 16; b <= 23; b = b + 1)
            {
                switch (listView3.Items[b].Tag.ToString().ToUpper().Substring(0, 1))
                {
                    case "S":
                        string shell_indexS = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(listView3.Items[b].Tag.ToString().ToUpper().Substring(1, 2), 0).ToString();
                        MyFunctions.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", shell_indexS);
                        break;
                    case "G":
                        string guid = listView3.Items[b].Tag.ToString().ToUpper().Substring(1, listView3.Items[b].Tag.ToString().Length - 1);
                        MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID", guid, false);
                        break;
                }
            }
            MyFunctions.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "29");
            MyFunctions.RegistryOperate.RegistryOperate_DeleteValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "0");
            MyFunctions.Dialogs.MessageDialog("还原成功", "还原图标成功!", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
            string res1 = MyFunctions.Dialogs.MessageDialog("立即生效?", "是否重启Windows 资源管理器来完成设置?这可能会导致您所打开的文件夹的窗口被关闭", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "继续", "取消");
            if (res1 == "B1")
            {
                MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
            }
            Class_SystemStyle.SystemStyle_LoadSysIconsToListView(this);
        }

        private void button126_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems != null)
            {
                try
                {
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons", "29", @"%SystemRoot%\System32\Imageres.dll,196", RegistryValueKind.ExpandString, false, false);
                    string res1 = MyFunctions.Dialogs.MessageDialog("立即生效?", "是否重启Windows 资源管理器来完成设置?这可能会导致您所打开的文件夹的窗口被关闭", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "继续", "取消");
                    if (res1 == "B1")
                    {
                        MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                    }
                    Class_SystemStyle.SystemStyle_LoadSysIconsToListView(this);
                }
                catch { }
            }
        }

        private void button123_Click(object sender, EventArgs e)
        {
            try
            {
                string RBGUID = "{645FF040-5081-101B-9F08-00AA002F954E}";
                string UFGUID = "{59031a47-3f72-44a7-89c5-5595fe6b30ee}";
                string NKGUID = "{F02C1A0D-BE21-4350-88B0-7367FC96EF3C}";
                string MCGUID = "{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                string CPGUID = "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}";
                string IEGUID = "{4B6C7757-AAF6-46AF-A2D2-D31CEE866228}";
                if (listView3.SelectedItems != null)
                {
                    string name = MyFunctions.Dialogs.InputDialog("输入图标的名称", "用于标识桌面图标的文字", true, "", "", "我的桌面", "");
                    if (name != "")
                    {
                        switch (listView3.SelectedItems[0].Tag.ToString().ToUpper())
                        {
                            case "UF":
                                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + UFGUID, "", name, RegistryValueKind.String, false, false);
                                break;
                            case "MC":
                                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + MCGUID, "", name, RegistryValueKind.String, false, false);
                                break;
                            case "IE":
                                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + IEGUID, "", name, RegistryValueKind.String, false, false);
                                break;
                            case "CP":
                                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + CPGUID, "", name, RegistryValueKind.String, false, false);
                                break;
                            case "NK":
                                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + NKGUID, "", name, RegistryValueKind.String, false, false);
                                break;
                            default:
                                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\" + RBGUID, "", name, RegistryValueKind.String, false, false);
                                break;
                        }
                        string res1 = MyFunctions.Dialogs.MessageDialog("立即生效?", "是否重启Windows 资源管理器来完成设置?这可能会导致您所打开的文件夹的窗口被关闭", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "继续", "取消");
                        if (res1 == "B1")
                        {
                            MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                        }
                        Class_SystemStyle.SystemStyle_LoadSysIconsToListView(this);
                    }
                }
            }
            catch { }
        }

        private void button100_Click(object sender, EventArgs e)
        {
            this.Start(8, 1);
        }

        private void button128_Click(object sender, EventArgs e)
        {
            this.Start(8, 2);
        }

        private void button103_Click(object sender, EventArgs e)
        {
            string vhdfile;
            if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.1")
            {
                vhdfile = MyFunctions.Dialogs.OpenFileDialog("选择虚拟磁盘文件", "虚拟磁盘文件(*.VHD)|*.VHD");
            }
            else
            {
                vhdfile = MyFunctions.Dialogs.OpenFileDialog("选择虚拟磁盘文件", "虚拟磁盘文件(*.VHD;*.VHDX)|*.VHD;*.VHDX");
            }
            if (vhdfile != "")
            {
                string[] f = new string[3];
                f[0] = "从系统中移除虚拟磁盘,但不删除虚拟磁盘源文件(推荐)";
                f[1] = "从系统中移除虚拟磁盘并删除虚拟磁盘源文件";
                f[2] = "取消操作";
                string RES = MyFunctions.Dialogs.TasksChooseDialog("选择移除虚拟磁盘的方式", f);
                switch (RES)
                {
                    case "T1":
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\Programs\VDISKMGR.EXE", @"/UL /""" + vhdfile + @"""", false, false, true, false, true);
                        MyFunctions.Dialogs.MessageDialog("移除成功", "已成功移除虚拟磁盘文件", MyFunctions.Dialogs.MessageDialogIcon.Information, @"已成功移除了 """ + vhdfile + @"""", "b2", false, true, "", "确定");
                        break;
                    case "T2":
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\Programs\VDISKMGR.EXE", @"/UD /""" + vhdfile + @"""", false, false, true, false, true);
                        MyFunctions.Dialogs.MessageDialog("移除并删除成功", "已成功移除并删除了虚拟磁盘文件", MyFunctions.Dialogs.MessageDialogIcon.Information, @"已成功移除并删除了 """ + vhdfile + @"""", "b2", false, true, "", "确定");
                        break;
                    default:
                        break;
                }
            }
        }

        private void button129_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox26.Text != "")
                {
                    if (MyFunctions.StreamAndTextOperate.IntOperate.VeifyIntIsNotStrings(textBox26.Text) == true)
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/timeout " + textBox26.Text, true, false, true, false, true);
                        MyFunctions.Dialogs.MessageDialog("修改系统超时时间成功", "成功修改系统超时时间!", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("无法修改系统超时时间", "无法修改系统超时时间,因为参数不是有效的整数", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                    }
                }
                else
                {
                    MyFunctions.Dialogs.MessageDialog("无法修改系统超时时间", "无法修改系统超时时间,因为参数无效", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                }
            }
            catch { }
        }

        private void button130_Click(object sender, EventArgs e)
        {
            MyFunctions.Dialogs.SpecialDialog("添加新的启动项", "new", new UserControl_CreateOrEditBCDBootMenu());
            Class_SystemStyle.SystemStyle_LoadBCD(this);
        }

        private void button131_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView4.SelectedItems != null)
                {
                    string name, guid, def;
                    name = listView4.SelectedItems[0].SubItems[1].Text;
                    def = listView4.SelectedItems[0].SubItems[0].Text;
                    if (def == "是")
                    {
                        MyFunctions.Dialogs.MessageDialog("无法删除启动项", "无法删除默认的启动项目,删除后会导致系统无法启动", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                    }
                    else
                    {
                        string res = MyFunctions.Dialogs.MessageDialog("继续?", @"您确定要删除名为""" + name + @"""的启动项?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "继续", "取消");
                        if (res == "B1")
                        {
                            guid = listView4.SelectedItems[0].SubItems[4].Text;
                            if (guid.ToUpper() == "{NTLDR}")
                            {
                                MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/delete {NTLDR}" + " /F", true, false, false, false, true);
                                MyFunctions.Dialogs.MessageDialog("成功删除启动项", "已成功删除指定的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                                Class_SystemStyle.SystemStyle_LoadBCD(this);
                            }
                            else
                            {
                                MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/delete " + guid + " /cleanup", true, false, false, false, true);
                                MyFunctions.Dialogs.MessageDialog("成功删除启动项", "已成功删除指定的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                                Class_SystemStyle.SystemStyle_LoadBCD(this);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void button132_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView4.SelectedItems != null)
                {
                    string guid = listView4.SelectedItems[0].SubItems[4].Text;
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/default " + guid, true, false, false, false, true);
                    MyFunctions.Dialogs.MessageDialog("成功设置默认的启动项", @"已成功将""" + listView4.SelectedItems[0].SubItems[1].Text + @"""设为默认的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    Class_SystemStyle.SystemStyle_LoadBCD(this);
                }
            }
            catch { }
        }

        private void button134_Click(object sender, EventArgs e)
        {
            contextMenuStrip5.Show(button134, new Point(0, button134.Height + 5));
        }

        private void 备份到系统齿轮的目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string bak = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\BCDBackup.sgbak";
                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(bak);
                MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", @"/export """ + bak + @"""", true, false, true, false, true);
                MyFunctions.Dialogs.MessageDialog("成功备份了您的数据", @"已成功将启动项的数据备份至系统齿轮的默认备份目录", MyFunctions.Dialogs.MessageDialogIcon.Information, @"已成功将文件备份至""" + bak + @"""", "b2", false, true, "", "确定");
            }
            catch { }
        }

        private void 备份到指定的位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string bak = MyFunctions.Dialogs.SaveFileDialog("保存启动数据", "所有文件(*.*)|*.*", "");
                if (bak != "")
                {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", @"/export """ + bak + @"""", true, false, true, false, true);
                    MyFunctions.Dialogs.MessageDialog("成功备份了您的数据", @"已成功将启动项的数据备份至您所指定的文件", MyFunctions.Dialogs.MessageDialogIcon.Information, @"已成功将文件备份至""" + bak + @"""", "b2", false, true, "", "确定");
                }
            }
            catch { }
        }

        private void button133_Click(object sender, EventArgs e)
        {
            contextMenuStrip6.Show(button133, new Point(0, button133.Height + 5));
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                string res = MyFunctions.Dialogs.MessageDialog("您确定要还原吗?", "请在还原之前确认文件是否有效", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "继续", "取消");
                if (res == "B1")
                {
                    string bak = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_BackupPath() + @"\BCDBackup.sgbak";
                    if (System.IO.File.Exists(bak) == true)
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", @"/import """ + bak + @"""", true, false, true, false, true);
                        MyFunctions.Dialogs.MessageDialog("成功还原了您的启动数据", @"已成功将启动项的数据还原到系统", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        Class_SystemStyle.SystemStyle_LoadBCD(this);
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("无法还原您的启动数据", @"无法将启动项的数据还原到系统,因为文件不存在", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                    }
                }
            }
            catch { }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                string res = MyFunctions.Dialogs.MessageDialog("您确定要还原吗?", "请在还原之前确认文件是否有效", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "继续", "取消");
                if (res == "B1")
                {
                    string bak = MyFunctions.Dialogs.OpenFileDialog("选择备份的文件", "所有文件(*.*)|*.*");
                    if (System.IO.File.Exists(bak) == true)
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", @"/import """ + bak + @"""", true, false, true, false, true);
                        MyFunctions.Dialogs.MessageDialog("成功还原了您的启动数据", @"已成功将启动项的数据还原到系统", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        Class_SystemStyle.SystemStyle_LoadBCD(this);
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("无法还原您的启动数据", @"无法将启动项的数据还原到系统,因为文件不存在", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                    }
                }
            }
            catch { }
        }

        private void button136_Click(object sender, EventArgs e)
        {
            try
            {
                string codename = listView6.SelectedItems[0].Tag.ToString();
                string program = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + codename, "", "", false, false).Replace(@"""", "");
                program = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(program, program);
                string ext = Path.GetExtension(program);
                if (System.IO.File.Exists(program) == true)
                {
                    switch (ext.ToUpper())
                    {
                        case ".EXE":
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms(program, "", false, false, false, false, false);
                            break;
                        case ".LNK":
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetEnvironmentVariable("windir") + @"\explorer.exe", @"""" + program + @"""", false, false, false, false, false);
                            break;
                        default:
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetEnvironmentVariable("windir") + @"\explorer.exe", @"""" + program + @"""", false, false, false, false, false);
                            break;
                    }
                }
                else
                {
                    MyFunctions.Dialogs.MessageDialog("无法运行指定的快捷命令", @"无法运行指定的快捷命令,因为关联的程序或快捷方式不存在", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                }
            }
            catch { }
        }

        private void button135_Click(object sender, EventArgs e)
        {
            string[] pp = new string[3];
            pp[0] = "常用操作(推荐)";
            pp[1] = "现有的快捷方式";
            pp[2] = "取消操作";
            string res=MyFunctions.Dialogs.TasksChooseDialog("快捷命令的执行方式", pp);
            switch (res.ToUpper())
            {
                case "T1":
                    string reg_name = MyFunctions.Dialogs.InputDialog("输入快捷命令的名称", "输入快捷命令的名称 ,例如 MyProgram", false, "", "", "MyProgram", "");
                    if (reg_name != "")
                    {
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths", reg_name + ".exe", false);
                        string[] ope = MyFunctions.Dialogs.ChooseOperateOrExploreFunctionDialog("ope");
                        string runas = ope[4];
                        string app = ope[1];
                        string args = ope[3];
                         string ico = ope[2];
                        if (args != "")
                        {
                            //Link
                            if (runas == "F")
                            {
                                if (System.IO.Directory.Exists(Application.StartupPath + @"\Shortcuts") == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(Application.StartupPath + @"\Shortcuts"); }
                                string linkfile = Application.StartupPath + @"\Shortcuts\" + reg_name + ".exe.lnk";
                                 MyFunctions.ProgramAndLinksOperate.CreateLink(linkfile, app, args, "", ico, null);
                                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + reg_name + ".exe", "", linkfile, RegistryValueKind.String, false, false);
                                Class_SystemStyle.SystemStyle_RunCommands(this);
                                MyFunctions.Dialogs.MessageDialog("成功新建快捷命令", @"成功新建快捷命令", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                                string res1 = MyFunctions.Dialogs.MessageDialog("是否查看效果?", @"是否运行快捷命令?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1",true, true, "是", "否");
                                if (res1 == "B1")
                                {
                                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetEnvironmentVariable("WINDIR") + @"\Explorer.exe", @"""" + linkfile + @"""", false, false, false, false, false);
                                }
                            }
                            else
                            {
                                //MessageBox.Show("");
                                if (System.IO.Directory.Exists(Application.StartupPath + @"\Shortcuts") == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(Application.StartupPath + @"\Shortcuts"); }
                                string linkfile = Application.StartupPath + @"\Shortcuts\" + reg_name + ".exe.lnk";
                                string def_link = Application.StartupPath + @"\Programs\DefaultLink_Admin.lnk.sgo";
                                MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(def_link, linkfile);
                                MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "path", app);
                                MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "args",args);
                                MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "icon", ico);
                                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + reg_name + ".exe", "", linkfile, RegistryValueKind.String, false, false);
                                Class_SystemStyle.SystemStyle_RunCommands(this);
                                MyFunctions.Dialogs.MessageDialog("成功新建快捷命令", @"成功新建快捷命令", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                                string res1 = MyFunctions.Dialogs.MessageDialog("是否查看效果?", @"是否运行快捷命令?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                                if (res1 == "B1")
                                {
                                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetEnvironmentVariable("WINDIR") + @"\Explorer.exe", @"""" + linkfile + @"""", false, false, false, false, false);
                                }
                            }
                        }
                        else
                        {
                            //Not Link
                            if (runas == "F")
                            {
                                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + reg_name + ".exe", "", app, RegistryValueKind.String, false, false);
                                Class_SystemStyle.SystemStyle_RunCommands(this);
                                MyFunctions.Dialogs.MessageDialog("成功新建快捷命令", @"成功新建快捷命令", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                                string res1 = MyFunctions.Dialogs.MessageDialog("是否查看效果?", @"是否运行快捷命令?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                                if (res1 == "B1")
                                {
                                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(app, "", false, false, false, false, false);
                                }
                            }
                            else
                            {
                                if (System.IO.Directory.Exists(Application.StartupPath + @"\Shortcuts") == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(Application.StartupPath + @"\Shortcuts"); }
                                string linkfile = Application.StartupPath + @"\Shortcuts\" + reg_name + ".exe.lnk";
                                string def_link = Application.StartupPath + @"\Programs\DefaultLink_Admin.lnk.sgo";
                                MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(def_link, linkfile);
                                MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "path", app);
                                MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "icon", ico);
                                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + reg_name + ".exe", "", linkfile, RegistryValueKind.String, false, false);
                                Class_SystemStyle.SystemStyle_RunCommands(this);
                                MyFunctions.Dialogs.MessageDialog("成功新建快捷命令", @"成功新建快捷命令", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                                string res1 = MyFunctions.Dialogs.MessageDialog("是否查看效果?", @"是否运行快捷命令?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                                if (res1 == "B1")
                                {
                                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetEnvironmentVariable("WINDIR") + @"\Explorer.exe", @"""" + linkfile + @"""", false, false, false, false, false);
                                }
                            }
                        }
                    }
                    break;
                case "T2":
                    string reg_name1 = MyFunctions.Dialogs.InputDialog("输入快捷命令的名称", "输入快捷命令的名称 ,例如 MyProgram", false, "", "", "MyProgram", "");
                    if (reg_name1 != "")
                    {
                        string linkfile1 = MyFunctions.Dialogs.OpenFileDialog("选择快捷方式", "快捷方式(*.lnk)|*.lnk");
                        if (System.IO.File.Exists(linkfile1) == true)
                        {
                            MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths", reg_name1 + ".exe", false);
                            MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + reg_name1 + ".exe", "", linkfile1, RegistryValueKind.String, false, false);
                            Class_SystemStyle.SystemStyle_RunCommands(this);
                            MyFunctions.Dialogs.MessageDialog("成功新建快捷命令", @"成功新建快捷命令", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                            string res11 = MyFunctions.Dialogs.MessageDialog("是否查看效果?", @"是否运行快捷命令?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                            if (res11 == "B1")
                            {
                                MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetEnvironmentVariable("WINDIR") + @"\Explorer.exe", @"""" + linkfile1 + @"""", false, false, false, false, false);
                            }
                        }
                    }
                    break;
            }
        }

        private void button57_Click(object sender, EventArgs e)
        {
            MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\ImmersiveShell\Grid", "Layout_Maximumrowcount", numericUpDown1.Value.ToString(), RegistryValueKind.DWord, false, false);
            MyFunctions.Dialogs.MessageDialog("应用成功", @"重启资源管理器或注销后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
        }

        private void button137_Click(object sender, EventArgs e)
        {
            MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
            keybd_event(0x5b, 0, 0, 0); //0x5b是left win的代码，这一句使key按下，下一句使key释放。
            keybd_event(0x5b, 0, 0x2, 0);
        }

        private void button138_Click(object sender, EventArgs e)
        {
            this.Start(5, 3);
        }

        private void button139_Click(object sender, EventArgs e)
        {
            if (treeView3.SelectedNode != null)
            {
                if (treeView3.SelectedNode.Tag != null)
                {
                    if (treeView3.SelectedNode.Tag.ToString().ToUpper().Length == 6)
                    {
                        if (treeView3.SelectedNode.Tag.ToString().ToUpper().Substring(0, 5) == "MROUP")
                        {
                            string groupname = "Group" + treeView3.SelectedNode.Tag.ToString().Substring(5, treeView3.SelectedNode.Tag.ToString().Length - 5);
                            string[] op = new string[3];
                            op[0] = "选择程序";
                            op[1] = "选择已存在的快捷方式(*.LNK)";
                            op[2] = "常用操作";
                            string res =MyFunctions.Dialogs.TasksChooseDialog("新建菜单", op);
                            switch (res)
                            {
                                case "T1":
                                    string app = MyFunctions.Dialogs.OpenFileDialog("选择程序", "可执行文件(*.exe)|*.exe");
                                    if (System.IO.File.Exists(app) == true)
                                    {
                                        string name = MyFunctions.Dialogs.InputDialog("输入菜单的名称", "输入菜单的名称", false, "", "", "我的菜单", "");
                                        if (name != "")
                                        {
                                            string arg = MyFunctions.Dialogs.InputDialog("输入程序的命令行(可选)", "输入程序的命令行(可选)", true, "", "", "", "");
                                            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + groupname;
                                            if (System.IO.Directory.Exists(path) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(path); }
                                             MyFunctions.ProgramAndLinksOperate.CreateLink(path + "\\" + name + @".LNK", app, arg, "", app + @",0", null);
                                            MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\Programs\HashLnk.exe", @"""" + path + "\\" + name + @".LNK""", true, false, true, false, true);
                                            Class_SystemStyle.SystemStyle_LoadWinXMenu(this);
                                            MyFunctions.Dialogs.MessageDialog("新建成功", @"成功新建了新的菜单.重启资源管理器后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                                            MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                                        }
                                        else
                                        {
                                            MyFunctions.Dialogs.MessageDialog("新建错误", @"没有新的菜单指定名称", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                                        }
                                    }
                                    break;
                                case "T2":
                                    OpenFileDialog open = new OpenFileDialog();
                                    open.Title = "选择快捷方式";
                                    open.FileName = "";
                                    open.Filter = "快捷方式(*.lnk)|*.lnk";
                                    open.Multiselect = false;
                                    open.DereferenceLinks = true;
                                    open.ShowDialog();
                                    string filename = open.FileName;
                                    string filename_withoutlocation = open.SafeFileName;
                                    if (System.IO.File.Exists(filename) == true)
                                    {
                                        string path1 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + groupname;
                                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(filename, path1 + "\\" + filename_withoutlocation);
                                        MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\Programs\HashLnk.exe", @"""" + path1 + "\\" + filename_withoutlocation + @"""", true, false, true, false, true);
                                        Class_SystemStyle.SystemStyle_LoadWinXMenu(this);
                                        MyFunctions.Dialogs.MessageDialog("新建成功", @"成功新建了新的菜单.重启资源管理器后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                                        MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                                    }
                                    break;
                                case "T3":
                                    string[] ope = MyFunctions.Dialogs.ChooseOperateOrExploreFunctionDialog("OPE");
                                    if (ope != null)
                                    {
                                        string name = ope[0];
                                        string cmd = ope[1];
                                        string icon = ope[2];
                                        string arg = ope[3];
                                        string runas = ope[4];
                                        if (runas == "T")
                                        {
                                            string path2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + groupname;
                                             MyFunctions.ProgramAndLinksOperate.CreateLink(path2 + "\\" + name + ".lnk", "%windir%\\System32\\wscript.exe", @"""" + Application.StartupPath + @"\Programs\RunAsAdmin.vbs"" " + cmd +" "+arg, "", icon, null);
                                            MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\Programs\HashLnk.exe", @"""" + path2 + "\\" + name + ".lnk" + @"""", true, false, true, false, true);
                                        }
                                        else
                                        {
                                            string path2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + groupname;
                                             MyFunctions.ProgramAndLinksOperate.CreateLink(path2 + "\\" + name + ".lnk", cmd, arg, "", icon, null);
                                            MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\Programs\HashLnk.exe", @"""" + path2 + "\\" + name + ".lnk" + @"""", true, false, true, false, true);
                                        }
                                        Class_SystemStyle.SystemStyle_LoadWinXMenu(this);
                                        MyFunctions.Dialogs.MessageDialog("新建成功", @"成功新建了新的菜单.重启资源管理器后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                                        MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                                    }
                                    break;
                            }
                        }
                    }
                    else { MyFunctions.Dialogs.MessageDialog("新建错误", @"没有选中又添加菜单的组", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定"); }
                }
                else { MyFunctions.Dialogs.MessageDialog("新建错误", @"没有选中又添加菜单的组", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定"); }
            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("新建错误", @"没有选中又添加菜单的组", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
            }
        }

        private void button145_Click(object sender, EventArgs e)
        {
            MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
            //keybd_event(0x5b, 0, 0, 0); //0x5b是left win的代码，这一句使key按下，下一句使key释放。
            //keybd_event(0x5b, 0, 0x2, 0); 
        }

        private void button141_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView3.SelectedNode != null)
                {
                    if (treeView3.SelectedNode.Tag.ToString().Length == 6)
                    {
                        if (treeView3.SelectedNode.Tag.ToString().Substring(0, 5).ToUpper() == "MROUP")
                        {
                        }
                        else
                        {
                            string newname = MyFunctions.Dialogs.InputDialog("为菜单指定新的名称", "指定的新的菜单名称", false, "", "", "新的菜单", "");
                            string groupname = treeView3.SelectedNode.Tag.ToString().Substring(0, treeView3.SelectedNode.Tag.ToString().IndexOf("*"));
                            string LinkName = treeView3.SelectedNode.Tag.ToString().Substring(treeView3.SelectedNode.Tag.ToString().IndexOf("*"), treeView3.SelectedNode.Tag.ToString().Length - groupname.Length).Replace("*", "");
                            string LINKFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + groupname + @"\" + LinkName;
                            MyFunctions.ProgramAndLinksOperate.SetLink(LINKFile, "INFO", newname);
                            Class_SystemStyle.SystemStyle_LoadWinXMenu(this);
                            MyFunctions.Dialogs.MessageDialog("编辑成功", @"成功编辑了菜单.重启资源管理器后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                            MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                        }
                    }
                    else
                    {
                        string newname1 = MyFunctions.Dialogs.InputDialog("为菜单指定新的名称", "指定的新的菜单名称", false, "", "", "新的菜单", "");
                        string groupname = treeView3.SelectedNode.Tag.ToString().Substring(0, treeView3.SelectedNode.Tag.ToString().IndexOf("*"));
                        string LinkName = treeView3.SelectedNode.Tag.ToString().Substring(treeView3.SelectedNode.Tag.ToString().IndexOf("*"), treeView3.SelectedNode.Tag.ToString().Length - groupname.Length).Replace("*", "");
                        string LINKFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + groupname + @"\" + LinkName;
                        MyFunctions.ProgramAndLinksOperate.SetLink(LINKFile, "INFO", newname1);
                        Class_SystemStyle.SystemStyle_LoadWinXMenu(this);
                        MyFunctions.Dialogs.MessageDialog("编辑成功", @"成功编辑了菜单.重启资源管理器后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                    }
                }
            }
            catch { }
        }

        private void button142_Click(object sender, EventArgs e)
        {
            try
            {
                string groupname = treeView3.SelectedNode.Tag.ToString().Substring(0, treeView3.SelectedNode.Tag.ToString().IndexOf("*"));
                string LinkName = treeView3.SelectedNode.Tag.ToString().Substring(treeView3.SelectedNode.Tag.ToString().IndexOf("*"), treeView3.SelectedNode.Tag.ToString().Length - groupname.Length).Replace("*", "");
                string LINKFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + groupname + @"\" + LinkName;
                string res = MyFunctions.Dialogs.MessageDialog("继续?", "您确定要删除这个菜单吗?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "继续", "取消");
                if (res == "B1")
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(LINKFile);
                    Class_SystemStyle.SystemStyle_LoadWinXMenu(this);
                    MyFunctions.Dialogs.MessageDialog("删除成功", @"成功删除了菜单.重启资源管理器后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                }
            }
            catch { }
        }

        private void button146_Click(object sender, EventArgs e)
        {
            try
            {
                string res = MyFunctions.Dialogs.MessageDialog("继续?", "您确定要删除这个组吗?这会删除这个目录下的所有文件", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "继续", "取消");
                if (res == "B1")
                {
                    string groupname = "Group" + treeView3.SelectedNode.Tag.ToString().Substring(5, treeView3.SelectedNode.Tag.ToString().Length - 5);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFolder(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\" + groupname, true);
                    Class_SystemStyle.SystemStyle_LoadWinXMenu(this);
                    MyFunctions.Dialogs.MessageDialog("删除成功", @"成功删除了菜单组.重启资源管理器后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                }
            }
            catch { }
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (treeView3.SelectedNode != null)
                {
                    string group = treeView3.SelectedNode.Tag.ToString().ToUpper();
                    if (group.Length == 6)
                    {
                        if (group.Substring(0, 5) == "MROUP")
                        {
                            myNormalButton65.Enabled = true;
                            myNormalButton66.Enabled = false;
                            myNormalButton68.Enabled = false;
                            myNormalButton69.Enabled = true;
                        }
                        else
                        {
                            myNormalButton65.Enabled = false;
                            myNormalButton66.Enabled = true;
                            myNormalButton68.Enabled = true;
                            myNormalButton69.Enabled = false;
                        }
                    }
                    else
                    {
                        myNormalButton65.Enabled = false;
                        myNormalButton66.Enabled = true;
                        myNormalButton68.Enabled = true;
                        myNormalButton69.Enabled = false;
                    }
                }
            }
            catch { }
        }

        private void button140_Click(object sender, EventArgs e)
        {
            try
            {
                int count = treeView3.Nodes.Count;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\Group" + (count + 1).ToString();
                MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(path);
                Class_SystemStyle.SystemStyle_LoadWinXMenu(this);
                MyFunctions.Dialogs.MessageDialog("新建组成功", @"成功新建了菜单组.重启资源管理器后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
            }
            catch { }
        }

        private void button143_Click(object sender, EventArgs e)
        {
            try
            {
                string res = MyFunctions.Dialogs.MessageDialog("继续?", "您确定要将您当前的设置还原成系统默认.这会导致您的设置丢失", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "继续", "取消");
                if (res == "B1")
                {
                    if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.2")
                    {
                        //MessageBox.Show("");
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX";
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFolder(path, true);
                        //Class_PublicFunctions.Public_CABOperate_ExtractionPackage(Application.StartupPath + @"\Packages\WinXMenus.cab", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX");
                        MyFunctions.PackageOperate.SGPAK_ExtactPackage(Application.StartupPath + @"\Packages\WinXMenus.sgpak", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX",false);
                        //Class_PublicFunctions.Public_ZIPOperate_StanardMode_ExtractionPackage(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX", Application.StartupPath + @"\Packages\WinXMenus.sgpak", true);
                        Class_SystemStyle.SystemStyle_LoadWinXMenu(this);
                        MyFunctions.Dialogs.MessageDialog("还原成功", @"成功还原了Win+X菜单组.重启资源管理器后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                    }
                    else
                    {
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX";
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFolder(path, true);
                        MyFunctions.PackageOperate.SGPAK_ExtactPackage(Application.StartupPath + @"\Packages\WinXMenusblue.sgpak", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX", false);
                        //Class_PublicFunctions.Public_ZIPOperate_StanardMode_ExtractionPackage(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX", Application.StartupPath + @"\Packages\WinXMenusBLUE.sgpak", true);
                        Class_SystemStyle.SystemStyle_LoadWinXMenu(this);
                        MyFunctions.Dialogs.MessageDialog("还原成功", @"成功还原了Win+X菜单组.重启资源管理器后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
                    }
                }
            }
            catch { }
        }

        private void button144_Click(object sender, EventArgs e)
        {
            string vdiskfile = "";
            if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.1")
            {
                vdiskfile = MyFunctions.Dialogs.OpenFileDialog("选择虚拟磁盘文件", "虚拟磁盘文件(*.vhd)|*.vhd");
            }
            else
            {
                vdiskfile = MyFunctions.Dialogs.OpenFileDialog("选择虚拟磁盘文件", "虚拟磁盘文件(*.vhd;*.vhdx)|*.vhd;*.vhdx");
            }
            if (File.Exists(vdiskfile) == true)
            {
                string j = "T1";
                switch (j)
                {
                    case "T1":
                        string panf = MyFunctions.Dialogs.InputDialog("输入盘符", "请输入为虚拟磁盘指派的盘符 例如: Z ,不能与已指派的盘符相同", false, "", "", "", "");
                        if (panf != "")
                        {
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\Programs\VDISKMGR.EXE", @"/LL """ + vdiskfile + @""" /" + panf, false, false, false, false, true);
                            MyFunctions.Dialogs.MessageDialog("挂载成功", @"成功挂载了指定的虚拟磁盘", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        }
                        else
                        {
                            MyFunctions.Dialogs.MessageDialog("操作失败", @"没有为其指派一个盘符,已取消操作", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                        }
                        break;
                }
            }
        }

        public void button147_Click(object sender, EventArgs e)
        {
        }

        private void button148_Click(object sender, EventArgs e)
        {
            this.Start(1, 4);
        }

        private void button149_Click(object sender, EventArgs e)
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
                if (System.IO.File.Exists(filename) == true)
                {
                    open.Dispose();
                    string filename_nolocationorext = Path.GetFileNameWithoutExtension(filename);
                    switch (Path.GetExtension(filename).ToUpper())
                    {
                        case ".LNK":
                            MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, filename);
                            break;
                        case ".EXE":
                            string templinkpath = Environment.GetEnvironmentVariable("TMP") + @"\" + filename_nolocationorext + ".lnk";
                             MyFunctions.ProgramAndLinksOperate.CreateLink(templinkpath, filename, "", "", filename + ",0", null);
                            MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, templinkpath);
                            templinkpath = "";
                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templinkpath);
                            break;
                        default:
                            string templinkpath1 = Environment.GetEnvironmentVariable("TMP") + @"\" + filename_nolocationorext + ".lnk";
                             MyFunctions.ProgramAndLinksOperate.CreateLink(templinkpath1, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd.exe", "", "", "", null);
                            MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, templinkpath1);
                            string ping_linkname = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + filename_nolocationorext + ".lnk";
                            MyFunctions.ProgramAndLinksOperate.SetLink(ping_linkname, "Path", filename);
                            MyFunctions.ProgramAndLinksOperate.SetLink(ping_linkname, "icon", "");
                            MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, ping_linkname);
                            templinkpath1 = "";
                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templinkpath1);
                            break;
                    }
                    MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
                }
            }
            catch { }
        }

        private void button150_Click(object sender, EventArgs e)
        {
            try
            {
                string folder = MyFunctions.Dialogs.OpenFolder("选择一个目录");
                if (System.IO.Directory.Exists(folder) == true)
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
                     MyFunctions.ProgramAndLinksOperate.CreateLink(ping_temp, Environment.GetEnvironmentVariable("windir") + @"\explorer.exe", "", "", "", null);
                    MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, ping_temp);
                    string ping_linkname = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\" + folder_nolocation + ".lnk";
                    MyFunctions.ProgramAndLinksOperate.SetLink(ping_linkname, "PATH", folder);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(ping_temp);
                    MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
                }
            }
            catch { }
        }

        private void button151_Click(object sender, EventArgs e)
        {
            UserControl_PinWebSite g = new UserControl_PinWebSite();
            MyFunctions.Dialogs.SpecialDialog("固定网站", "", g);
        }


        private void pictureBox74_Click(object sender, EventArgs e)
        {

        }

        private void button153_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string code = btn.Tag.ToString();
                if (btn.Text == "显示")
                {
                    Class_SystemStyle.SystemStyle_SetTaskBarPings(this, code, "NEW");
                }
                else
                {
                    Class_SystemStyle.SystemStyle_SetTaskBarPings(this, code, "DEL");
                }
                Class_SystemStyle.SystemStyle_LoadTaskBarIcons(this);
            }
            catch { }
        }

        private void button163_Click(object sender, EventArgs e)
        {
            this.Start(5, 4);
        }

        private void button167_Click(object sender, EventArgs e)
        {
            textBox29.Text = "{" + Guid.NewGuid().ToString().ToUpper() + "}";
        }

        private void button168_Click(object sender, EventArgs e)
        {
            try
            {
                string[] ret =MyFunctions.Dialogs.ChooseOperateOrExploreFunctionDialog("OPE");
                if (ret[1] != "") { textBox30.Text = ret[1]; }
                if (ret[3].ToUpper() == "T")
                {
                    checkBox5.Checked = true;
                }
                else
                {
                    checkBox5.Checked = false;
                }
                if (ret[2] != "")
                {
                    textBox31.Text = ret[2];
                }
            }
            catch { }
        }

        private void button169_Click(object sender, EventArgs e)
        {
            string pro = MyFunctions.Dialogs.OpenFileDialog("选择可执行文件", "可执行文件(*.exe)|*.exe");
            if (pro != "")
            {
                textBox30.Text = pro;
            }
        }

        private void button171_Click(object sender, EventArgs e)
        {
            if (textBox30.Text != "")
            {
                MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, "clsid", textBox29.Text, false);
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, "CLSID", textBox29.Text, false);
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, "CLSID\\" + textBox29.Text, "Shell", false);
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, "CLSID\\" + textBox29.Text+"\\Shell", "Open", false);
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, "CLSID\\" + textBox29.Text + "\\Shell\\Open", "Command", false);
                string cmd = textBox30.Text;
                if (checkBox5.Checked == true)
                {
                    cmd = @"%windir%\System32\wscript.exe """ + Application.StartupPath + @"\Programs\RunAsAdmin.VBS"" " + textBox30.Text;
                }
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, @"CLSID\" + textBox29.Text + @"\Shell\Open\Command", "", cmd , RegistryValueKind.ExpandString, false, false);
                MyFunctions.Dialogs.MessageDialog("成功关联GUID", @"成功将程序关联至"""+textBox29.Text+@"""" , MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                string logo = Environment.GetEnvironmentVariable("windir") + @"\Explorer.exe,0";
                if (textBox31.Text != "")
                {
                    logo = textBox31.Text;
                }
                string[] t = new string[6];
                t[0] = "创建快捷方式到桌面";
                t[1] = "创建快捷方式到开始菜单";
                t[2] = "固定到任务栏";
                t[3] = "将快捷方式的文件保存到指定目录";
                t[4] = "全部，除将快捷方式的文件保存到指定目录";
                t[5] = "继续但什么也不做";
                string res = MyFunctions.Dialogs.TasksChooseDialog("选择操作", t);
                string templink = Environment.GetEnvironmentVariable("tmp") + "\\"+textBox29.Text +@".lnk";
                 MyFunctions.ProgramAndLinksOperate.CreateLink(templink, Environment.GetEnvironmentVariable("WINDIR") + @"\Explorer.exe", "Shell:::" + textBox29.Text, "", logo, null);
                switch (res.ToUpper())
                {
                    case "T1":
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(templink,Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\关联"+textBox29.Text +@"的程序.LNK");
                        break;
                    case "T2":
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(templink, Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\关联" + textBox29.Text + @"的程序.LNK");
                        break;
                    case "T3":
                        MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, templink);
                        break;
                    case "T4":
                        string FILE = MyFunctions.Dialogs.SaveFileDialog("保存文件", "快捷方式文件(*.LNK)|*.LNK", ".LNK");
                        if (FILE != "")
                        {
                            MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(templink, FILE);
                        }
                        break;
                    case "T5":
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(templink, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\关联" + textBox29.Text + @"的程序.LNK");
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(templink, Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\关联" + textBox29.Text + @"的程序.LNK");
                        MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, templink);
                        break;
                }
                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
                MyFunctions.Dialogs.MessageDialog("成功", "成功保存了快捷方式文件", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
                textBox31.Text = textBox30.Text = "";
                textBox29.Text = "{" + Guid.NewGuid().ToString().ToUpper() + "}";
                checkBox5.Checked = false;
            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("无法新建GUID", "无法新建GUID.因为缺少必要的信息", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "B2", false, true, "", "确定");
            }
        }

        private void button170_Click(object sender, EventArgs e)
        {
            string ico = MyFunctions.Dialogs.ChooseIcon("选择图标", @"%windir%\system32\imageres.dll,2");
            if (ico != "")
            {
                textBox31.Text = ico;
            }
        }

        private void button172_Click(object sender, EventArgs e)
        {
            string guid = MyFunctions.Dialogs.InputDialog("输入GUID", "输入您所关联到命令的GUID", false, "", "", "", "");
            if (guid != "")
            {
                if (guid.Length == 38 && guid.Substring(0, 1) == "{")
                {
                    string res = MyFunctions.Dialogs.MessageDialog("继续?", @"您确定要删除""" + guid + @"""请确定这不是系统的GUID以免系统出现问题", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "B2", true, true, "继续", "取消");
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"CLSID", guid, false);
                    MyFunctions.Dialogs.MessageDialog("成功", "成功删除了指定的GUID", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                    MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
                }
                else
                {
                    MyFunctions.Dialogs.MessageDialog("错误", "没有指定有效的GUID", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "B2", false, true, "", "确定");
                }
            }
        }

        private void button165_Click(object sender, EventArgs e)
        {
            string[] k = MyFunctions.Dialogs.ChooseGUIDIconDialog();
            try
            {
                if (k[1] != null)
                {
                    string guid = k[1];
                    string reg = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace";
                    MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, guid,false);
                    Class_SystemStyle.SystemStyle_LoadThisPCShowItems(this);
                    MyFunctions.Dialogs.MessageDialog("添加成功", @"成功添加了名为"""+MyFunctions.StreamAndTextOperate.TextOperate.GUIDOperate.GUIDOperate_GetGUIDRegistryName(guid)+@"""的项目", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetEnvironmentVariable("windir") + @"\explorer.exe", "shell:::{20d04fe0-3aea-1069-a2d8-08002b30309d}", false, false, false, false, false);
                }
            }
            catch { }
        }

        private void button166_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView5.SelectedItems[0].Text != null)
                {
                    string name, guid;
                    name = listView5.SelectedItems[0].Text;
                    guid = listView5.SelectedItems[0].Tag.ToString();
                    string res = MyFunctions.Dialogs.MessageDialog("继续?", @"您确定要删除名为""" + name + @"""的项目吗?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "继续", "取消");
                    if (res == "B1")
                    {
                        string reg = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace";
                        MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, reg, guid, false);
                        Class_SystemStyle.SystemStyle_LoadThisPCShowItems(this);
                        MyFunctions.Dialogs.MessageDialog("删除成功", @"成功删除了名为""" + name + @"""的项目", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetEnvironmentVariable("windir") + @"\explorer.exe", "shell:::{20d04fe0-3aea-1069-a2d8-08002b30309d}", false, false, false, false, false);
                    }
                }
            }
            catch { }
        }

        private void button164_Click(object sender, EventArgs e)
        {
            try
            {
                
                    string res = MyFunctions.Dialogs.MessageDialog("继续?", @"您确定要还原为默认吗?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "继续", "取消");
                    if (res == "B1")
                    {
                        string reg = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace";
                        string[] delete_subs = Registry.LocalMachine.OpenSubKey(reg).GetSubKeyNames();
                        for (int h = 1; h <= delete_subs.Length; h++)
                        {
                            if (delete_subs[h - 1].ToUpper() != "DelegateFolders".ToUpper())
                            {
                                MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, reg, delete_subs[h - 1], false);
                            }
                        }
                        string DOWN_GUID = "{374DE290-123F-4565-9164-39C4925E467B}";
                        string DESK_GUID = "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";
                        string MUSI_GUID = "{1CF1260C-4DD0-4ebb-811F-33C572699FDE}";
                        string IMAG_GUID = "{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}";
                        string VIDE_GUID = "{A0953C92-50DC-43bf-BE83-3742FED03C9C}";
                        string DOCE_GUID = "{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}";
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, DOWN_GUID, false);
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, DESK_GUID, false);
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, MUSI_GUID, false);
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, IMAG_GUID, false);
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, VIDE_GUID, false);
                        MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, reg, DOCE_GUID, false);
                        Class_SystemStyle.SystemStyle_LoadThisPCShowItems(this);
                        MyFunctions.Dialogs.MessageDialog("还原成功", @"成功还原为默认", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetEnvironmentVariable("windir") + @"\explorer.exe", "shell:::{20d04fe0-3aea-1069-a2d8-08002b30309d}", false, false, false, false, false);
                }
            }
            catch { }
        }

        private void button173_Click(object sender, EventArgs e)
        {
            try
            {
                string img = MyFunctions.Dialogs.OpenFileDialog("选择图片", "支持的图片格式(*.JPG;*.GIF;*.BMP;*.PNG)|*.JPG;*.GIF;*.BMP;*.PNG");
                if (System.IO.File.Exists(img) == true)
                {
                    textBox32.Text = img;
                    pictureBox76.Image = System.Drawing.Bitmap.FromFile(img);
                }
            }
            catch { }
        }

        private void button174_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox32.Text) == true)
            {
                Class_SystemStyle.SystemStyle_SetLockPicture(textBox32.Text);
                MyFunctions.Dialogs.MessageDialog("更改成功", @"成功将指定的图片作为锁屏壁纸", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                string res = MyFunctions.Dialogs.MessageDialog("是否查看修改的效果?", @"是否查看修改的效果?程序将会锁定您的计算机", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "B1", true, true, "确定", "取消");
                if (res == "B1")
                {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("Rundll32.exe", "user32.dll,LockWorkStation", false, false, false, false, false);
                }
            }
        }

        private void button175_Click(object sender, EventArgs e)
        {
            string res = MyFunctions.Dialogs.MessageDialog("您确定要还原系统默认?", @"您确定要还原系统默认?此操作会使您的设置丢失", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "B2", true, true, "确定", "取消");
            if (res == "B1")
            {
                string defaultImag = Environment.GetEnvironmentVariable("windir") + @"\Web\Screen\img100.png";
                MyFunctions.FileSystemOperate.FileSystemOperate_GetAdminWithFile(defaultImag);
                //MessageBox.Show(defaultImag);
                Class_SystemStyle.SystemStyle_SetLockPicture(defaultImag);
                MyFunctions.Dialogs.MessageDialog("还原默认成功", @"成功将默认的图片作为锁屏壁纸", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                string res1 = MyFunctions.Dialogs.MessageDialog("是否查看还原的效果?", @"是否查看还原的效果?程序将会锁定您的计算机", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "B1", true, true, "确定", "取消");
                if (res1 == "B1")
                {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("Rundll32.exe", "user32.dll,LockWorkStation", false, false, false, false, false);
                }
            }
        }

        private void button176_Click(object sender, EventArgs e)
        {
            string res1 = MyFunctions.Dialogs.MessageDialog("继续?", @"您确定要删除这个快捷命令?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "确定", "取消");
            if (res1 == "B1")
            {
                try
                {
                    string reg = listView6.SelectedItems[0].Tag.ToString();
                    string type = listView6.SelectedItems[0].SubItems[2].Text;
                    if (type == "快捷方式")
                    {
                        string link = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + reg, "", "", false, false);
                        link = link.Replace(@"""", "");
                        string res11 = MyFunctions.Dialogs.MessageDialog("是否同时删除快捷方式?", @"是否同时删除关联的快捷方式?", MyFunctions.Dialogs.MessageDialogIcon.Question, @"是否要删除"""+link+@"""", "B1", true, true, "确定", "取消");
                        if (res11 == "B1")
                        {
                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(link);
                        }
                    }
                    MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths", reg, false);
                    MyFunctions.Dialogs.MessageDialog("删除成功", @"成功将快捷命令"""+reg+@"""删除", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                    Class_SystemStyle.SystemStyle_RunCommands(this);
                }
                catch { }
            }
        }

        private void button178_Click(object sender, EventArgs e)
        {
            this.Start(4, 3);
        }

        private void button177_Click(object sender, EventArgs e)
        {
            MyFunctions.Dialogs.SettingsDialog("剪切板内容自动保存选项", Color.FromArgb(0, 148, 255), new UserControl_ClipOperate());
        }

        private void button179_Click(object sender, EventArgs e)
        {
            try
            {
                string codename = listView6.SelectedItems[0].Tag.ToString();
                string program = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + codename, "", "", false, false).Replace(@"""", "");
                program = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(program, program);
                if (System.IO.File.Exists(program) == true)
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_OpenFileLocationWithExplorer(program);
                }
            }
            catch { }
        }

        private void button180_Click(object sender, EventArgs e)
        {
            string codename = listView6.SelectedItems[0].Tag.ToString();
            string program = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + codename, "", "", false, false).Replace(@"""", "");
            program = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(program, program);
            if (System.IO.File.Exists(program) == true)
            {
                MyFunctions.Dialogs.FileAttDialog(program);
            }
        }

        private void button181_Click(object sender, EventArgs e)
        {
            Class_SystemStyle.SystemStyle_RegistryClipExt();
            MyFunctions.Dialogs.MessageDialog("关联成功", @"成功关联到系统右键菜单", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
        }

        private void button182_Click(object sender, EventArgs e)
        {
            try
            {
                string MainName = "ClipToFile";
                MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\background\shell", MainName, false);
                MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, @"Directory\shell", MainName, false);
                MyFunctions.Dialogs.MessageDialog("取消关联成功", @"成功取消关联", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
            }
            catch { }
        }

        private void button184_Click(object sender, EventArgs e)
        {
            Class_SystemStyle.SystemGear_GetJIEQIEBAN(this);
        }

        private void button185_Click(object sender, EventArgs e)
        {
            string j = MyFunctions.Dialogs.MessageDialog("继续?", @"您是否要清空剪切板?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "B2", true, true, "是", "否");
            if (j == "B1")
            {
                Clipboard.Clear();
                Class_SystemStyle.SystemGear_GetJIEQIEBAN(this);
            }
        }

        private void button183_Click(object sender, EventArgs e)
        {
            try
            {
                switch (button183.Text)
                {
                    case "复制文件(夹)":
                        string copydir = MyFunctions.Dialogs.OpenFolder("选择要复制到的文件夹");
                        if (System.IO.Directory.Exists(copydir) == true)
                        {
                            Class_SystemStyle.SystemStyle_SaveJQBObjectInPanelOperate("", textBox_JQB_ORGFILE.Text, null, "FILES", null, copydir, "", this);
                            MyFunctions.Dialogs.MessageDialog("复制成功", @"成功复制了文件", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                        }
                        break;
                    case "保存图片":
                        string[] a = new string[4];
                        a[0] = "保存为JPG格式图片";
                        a[1] = "保存为PNG格式图片";
                        a[2] = "保存为GIF格式图片";
                        a[3] = "保存为BMP格式图片";
                        string jk = MyFunctions.Dialogs.TasksChooseDialog("要保存的图片格式", a);
                        switch (jk.ToUpper())
                        {
                            case "T1":
                                string filename = MyFunctions.Dialogs.SaveFileDialog("保存图片", "JPEG格式(*.jpg)|*.jpg", ".JPG");
                                Class_SystemStyle.SystemStyle_SaveJQBObjectInPanelOperate("", "", pictureBox63.Image, "IMAGE", System.Drawing.Imaging.ImageFormat.Jpeg, filename, "", this);
                                MyFunctions.Dialogs.MessageDialog("保存成功", @"成功保存剪切板文件", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                                break;
                            case "T2":
                                string filename1 = MyFunctions.Dialogs.SaveFileDialog("保存图片", "PNG格式(*.png)|*.png", ".png");
                                Class_SystemStyle.SystemStyle_SaveJQBObjectInPanelOperate("", "", pictureBox63.Image, "IMAGE", System.Drawing.Imaging.ImageFormat.Png, filename1, "", this);
                                MyFunctions.Dialogs.MessageDialog("保存成功", @"成功保存剪切板文件", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                                break;
                            case "T3":
                                string filename2 = MyFunctions.Dialogs.SaveFileDialog("保存图片", "GIF格式(*.gif)|*.gif", ".gif");
                                Class_SystemStyle.SystemStyle_SaveJQBObjectInPanelOperate("", "", pictureBox63.Image, "IMAGE", System.Drawing.Imaging.ImageFormat.Gif, filename2, "", this);
                                MyFunctions.Dialogs.MessageDialog("保存成功", @"成功保存剪切板文件", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                                break;
                            case "T4":
                                string filename3 = MyFunctions.Dialogs.SaveFileDialog("保存图片", "BMP格式(*.bmp)|*.bmp", ".bmp");
                                Class_SystemStyle.SystemStyle_SaveJQBObjectInPanelOperate("", "", pictureBox63.Image, "IMAGE", System.Drawing.Imaging.ImageFormat.Bmp, filename3, "", this);
                                MyFunctions.Dialogs.MessageDialog("保存成功", @"成功保存剪切板文件", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                                break;
                        }
                        break;
                    case "保存文本":
                        string[] a1 = new string[3];
                        a1[0] = "保存为TXT格式的文档";
                        a1[1] = "保存为RTF格式的文档";
                        a1[2] = "保存为快捷方式(指定的的格式)";
                        string jk1 = MyFunctions.Dialogs.TasksChooseDialog("要保存的文档格式", a1);
                        switch (jk1.ToUpper())
                        {
                            case "T1":
                                string filename = MyFunctions.Dialogs.SaveFileDialog("保存文档", "TXT格式(*.TXT)|*.TXT", ".TXT");
                                Class_SystemStyle.SystemStyle_SaveJQBObjectInPanelOperate(textBox_JQB_TEXT.Text, "", null, "TEXT", null, filename, "TXT", this);
                                MyFunctions.Dialogs.MessageDialog("保存成功", @"成功保存剪切板为文件", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                                break;
                            case "T2":
                                string filename1 = MyFunctions.Dialogs.SaveFileDialog("保存文档", "RTF格式(*.RTF)|*.RTF", ".RTF");
                                Class_SystemStyle.SystemStyle_SaveJQBObjectInPanelOperate(textBox_JQB_TEXT.Text, "", null, "TEXT", null, filename1, "RTF", this);
                                MyFunctions.Dialogs.MessageDialog("保存成功", @"成功保存剪切板为文件", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                                break;
                            case "T3":
                                string filename2 = MyFunctions.Dialogs.SaveFileDialog("保存快捷方式", "快捷方式(*.lnk)|*.LNK", ".LNK");
                                Class_SystemStyle.SystemStyle_SaveJQBObjectInPanelOperate(textBox_JQB_TEXT.Text, "", null, "TEXT", null, filename2, "LNK", this);
                                MyFunctions.Dialogs.MessageDialog("保存成功", @"成功将剪切板内容保存为快捷方式", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                                break;

                        }
                        break;
                }
            }
            catch { }
        }

        private void label103_Click(object sender, EventArgs e)
        {

        }

        private void label102_Click(object sender, EventArgs e)
        {

        }

        private void label88_Click(object sender, EventArgs e)
        {

        }

        private void tabPage30_Click(object sender, EventArgs e)
        {

        }

        private void button187_Click(object sender, EventArgs e)
        {
            string file = MyFunctions.Dialogs.OpenFileDialog("浏览图片", "Windows 位图(*.bmp)|*.bmp");
            if (System.IO.File.Exists(file) == true)
            {
                textBox28.Text = file;
            }
        }

        private void button188_Click(object sender, EventArgs e)
        {
            Class_SystemStyle.SystemStyle_ChangeBootImage(textBox28.Text);
        }

        private void button186_Click(object sender, EventArgs e)
        {
            this.Start(8, 3);
        }

        private void button189_Click(object sender, EventArgs e)
        {
            this.Start(4, 4);
        }

        private void button190_Click(object sender, EventArgs e)
        {
            try
            {
                string codename = listView7.SelectedItems[0].Text;
                string file = listView7.SelectedItems[0].SubItems[2].Text;
                string res = MyFunctions.Dialogs.MessageDialog("您确定要删除菜单吗?", @"您确定要删除名为 """ + codename + @"""", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "B2", true, true, "继续", "取消");
                if (res == "B1")
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(file);
                    Class_SystemStyle.SystemStyle_LoadSendToMenu(this);
                }
            }
            catch { }
        }

        private void listView7_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                button190.Enabled = true;
                string file = listView7.SelectedItems[0].SubItems[1].Text;
                if (file == "快捷方式")
                {
                    button191.Enabled = true;
                }
                else
                {
                    button191.Enabled = false;
                }
            }
            catch { }
        }

        private void button191_Click(object sender, EventArgs e)
        {
            try
            {
                string file = listView7.SelectedItems[0].SubItems[2].Text;
                MyFunctions.Dialogs.EditLinkDialog(file);
                Class_SystemStyle.SystemStyle_LoadSendToMenu(this);
            }
            catch { }
        }

        private void listView7_Leave(object sender, EventArgs e)
        {
            //button191.Enabled = button190.Enabled = false;
        }

        private void button192_Click(object sender, EventArgs e)
        {
            string[] cmds = new string[4];
            cmds[0] = "添加新的菜单";
            cmds[1] = "添加现有的快捷方式";
            cmds[2] = "添加现有的批处理";
            cmds[3] = "添加现有的可执行文件";
            string res =MyFunctions.Dialogs.TasksChooseDialog("添加菜单", cmds);
            switch (res)
            {
                case "T1":
                    MyFunctions.Dialogs.SpecialDialog("添加新的菜单", "", new UserControl_AddSendToMenu());
                    break;
                case "T2":
                    string link = MyFunctions.Dialogs.OpenFileDialog("选择快捷方式", "快捷方式(*.lnk)|*.lnk");
                    if (System.IO.File.Exists(link) == true)
                    {
                        string linkpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo\" + System.IO.Path.GetFileName(link);
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(link, linkpath);
                        MyFunctions.Dialogs.MessageDialog("成功新建菜单", @"成功新建了的菜单", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    }
                    break;
                case "T3":
                    string BAT= MyFunctions.Dialogs.OpenFileDialog("选择批处理", "批处理文件(*.cmd;*.bat)|*.cmd;*.bat");
                    if (System.IO.File.Exists(BAT) == true)
                    {
                        string linkpath1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo\" + System.IO.Path.GetFileNameWithoutExtension(BAT)+@".lnk";
                        string args = MyFunctions.Dialogs.InputDialog("输入批处理的启动参数", "输入批处理的启动参数(可选)", true, "", "", "", "");
                        string res1 = MyFunctions.Dialogs.MessageDialog("是否使用管理员权限执行?", "是否使用管理员权限执行该批处理?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                        if (res1 == "B1")
                        {
                            MyFunctions.ProgramAndLinksOperate.CreateLink_StartAdminType(linkpath1, BAT, args, "", Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,63");
                        }
                        else
                        {
                             MyFunctions.ProgramAndLinksOperate.CreateLink(linkpath1, BAT, args, "", Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,63", null);
                        }
                        MyFunctions.Dialogs.MessageDialog("成功新建菜单", @"成功新建了的菜单", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    }
                    break;
                case "T4":
                    string EXE = MyFunctions.Dialogs.OpenFileDialog("选择批处理", "可执行文件(*.exe)|*.exe");
                    if (System.IO.File.Exists(EXE) == true)
                    {
                        string linkpath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo\" + System.IO.Path.GetFileNameWithoutExtension(EXE) + @".lnk";
                        string args1 = MyFunctions.Dialogs.InputDialog("输入可执行文件的启动参数", "输入可执行文件的启动参数(可选)", true, "", "", "", "");
                        string res2 = MyFunctions.Dialogs.MessageDialog("是否使用管理员权限执行?", "是否使用管理员权限执行该程序?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "是", "否");
                        if (res2 == "B1")
                        {
                            MyFunctions.ProgramAndLinksOperate.CreateLink_StartAdminType(linkpath2, EXE, args1, "", EXE);
                        }
                        else
                        {
                             MyFunctions.ProgramAndLinksOperate.CreateLink(linkpath2, EXE, args1, "",EXE, null);
                        }
                        MyFunctions.Dialogs.MessageDialog("成功新建菜单", @"成功新建了的菜单", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    }
                    break;
            }
            Class_SystemStyle.SystemStyle_LoadSendToMenu(this);
        }

        private void button193_Click(object sender, EventArgs e)
        {
            string r = MyFunctions.Dialogs.MessageDialog("是否还原系统默认?", "是否要还原系统默认?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "是", "否");
            if (r == "B1")
            {
                string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo";
                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFolder(PATH,true);
                MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(PATH);
                MyFunctions.PackageOperate.SGPAK_ExtactPackage(Application.StartupPath + @"\packages\sendto.sgpak", PATH,false);
                //Class_PublicFunctions.Public_CABOperate_ExtractionPackage(Application.StartupPath + @"\packages\sendto.cab", PATH);
                //Class_PublicFunctions.Public_ZIPOperate_StanardMode_ExtractionPackage(PATH, Application.StartupPath + @"\packages\sendto.sgpak", true);
                MyFunctions.Dialogs.MessageDialog("成功还原了菜单", @"成功还原了的菜单", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                Class_SystemStyle.SystemStyle_LoadSendToMenu(this);
            }
        }

        private void button194_Click(object sender, EventArgs e)
        {
            this.Start(4, 5);
        }

        private void button195_Click(object sender, EventArgs e)
        {
            string img = MyFunctions.Dialogs.OpenFileDialog("选择图片", "支持的图像文件(*.jpg;*.png;*.bmp;*.gif)|*.jpg;*.png;*.bmp;*.gif");
            if (System.IO.File.Exists(img) == true)
            {
                textBox33.Text = img;
                pictureBox77.Image = System.Drawing.Image.FromFile(img);
            }
        }

        private void button196_Click(object sender, EventArgs e)
        {
            string r = MyFunctions.Dialogs.MessageDialog("是否应用到系统?", "是否要将图片应用到系统?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "是", "否");
            if (r == "B1")
            {
                try
                {
                    if (pictureBox77.Image != null)
                    {
                        string tmpimg = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\temp") + @"\BackImage.bmp";
                        MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_ConvetImage(pictureBox77.Image, System.Drawing.Imaging.ImageFormat.Bmp, 300, 400, tmpimg);
                        string tempdll=MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\temp")+@"\ContextBG.dll";
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(Application.StartupPath +@"\programs\ContextBG.dll",tempdll);
                        MyFunctions.FileSystemOperate.FileSystemOperate_ChangeFileResources(tmpimg, tempdll, "BITMAP", 129, 2057);
                        MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(tempdll, Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\ContextBG.dll");
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetFolderPath(Environment.SpecialFolder.System)+"\\regsvr32.exe", @"/s """ + Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\ContextBG.dll""", true, false, true, false, true);
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(tempdll);
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(tmpimg);
                        MyFunctions.Dialogs.MessageDialog("成功更改了右键菜单背景", @"成功更改了右键菜单背景", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    }
                }
                catch { }
            }
        }

        private void button198_Click(object sender, EventArgs e)
        {
            string[] dr = MyFunctions.Dialogs.ShowChooseDiskDialog("fixed", "浏览驱动器");
            string use = dr[2];
            if (use == "FIXED")
            {
                string pan = dr[0];
                label155.Text = pan;
            }
            else
            {
                //MyFunctions.Dialogs.MessageDialog("您当前选择的驱动器不可用", @"您所选择的磁盘驱动器当前未就绪", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
            }
        }

        private void button199_Click(object sender, EventArgs e)
        {
            this.Start(3, 3);
        }

        private void myNormalButton1_OnButtonClick(object sender, EventArgs e)
        {
            myTextBox1.TextBoxText =MyFunctions.Dialogs.OpenFolder("选择要分拣的文件夹");
        }

        private void myNormalButton2_OnButtonClick(object sender, EventArgs e)
        {
            string RES = MyFunctions.Dialogs.MessageDialog("您确定要创建新的条件吗?", "如果您继续创建新的条件, 您可能会丢失原来的条件的配置", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "B2", true, true, "确定", "取消");
            if(RES=="B1")
            {
                Form_SortingFileSettings f = new Form_SortingFileSettings("CREATE", new string[] { "cf" }, new string[] { "cf" });
                f.ShowDialog();
                Class_SystemStyle.SystemStyle_SortingFile_LoadCondition(this);
            }
        }

        private void myNormalButton5_OnButtonClick(object sender, EventArgs e)
        {
            if(System.IO.Directory.Exists(myTextBox1.TextBoxText )==true)
            {
                string expf="";
                int count;
                string cfg = Application.StartupPath + @"\Config\SortingFiles\SortingFileConfig.sgcf";
                string getcount = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("nooperatefiles", "count", "0", false, cfg);
                int.TryParse(getcount, out count);
                for (int o = 1; o <= count; o++)
                {
                    string j = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("nooperatefiles", "nooperatefile_" + o.ToString(), "", false, cfg);
                    expf = expf + j + "|";
                }
                if(expf.Length >=1)
                {
                    expf.Substring(0, expf.Length - 1);
                }
                Class_SystemStyle.SystemStyle_SortingFile_PreviewChange(myTextBox1.TextBoxText, checkBox4.Checked, expf);
            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("文件夹不可用", @"请选择一个正确的文件夹", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
            }
        }

        private void myNormalButton3_OnButtonClick(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(myTextBox1.TextBoxText) == true)
            {
                Form_SortingFileSettings f = new Form_SortingFileSettings("NOOPERATEFILE", new string[] { myTextBox1.TextBoxText }, new string[] { "11" });
                f.ShowDialog();
            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("文件夹不可用", @"请选择一个正确的文件夹", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
            }
        }

        private void myNormalButton4_OnButtonClick(object sender, EventArgs e)
        {
            string reg = "";
             if(radioButton7.Checked ==true)
             {
                 reg = "StartColor";
             }
             else
             {
                 reg = "AccentColor";
             }
             Color c = MyFunctions.Dialogs.ColorDialog(Color.FromArgb(0, 0, 0));
             string hex10c = MyFunctions.MediaAndResourcesOperate.ColorOperate.Convert_ColorRGBtoHx16(c);
             panel_STARTCOLOR.BackColor = c;
             panel_STARTCOLOR.Tag = c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString();
             string regl = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent";
             Int32 tempInt = 0; //预先定义一个有符号32位数
             //unchecked语句块内的转换，不做溢出检查
             unchecked
             {
                 tempInt = Convert.ToInt32(hex10c, 16); //强制转换成有符号32位数
             }
             //此时的tempInt已经是有符号32位数，可以直接写入注册表
             MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, regl, reg, tempInt.ToString(), RegistryValueKind.DWord, false, true);
             MyFunctions.Dialogs.MessageDialog("应用成功", @"重启资源管理器或注销后生效", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
        }

        private void myNormalButton6_OnButtonClick(object sender, EventArgs e)
        {
            MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetEnvironmentVariable("localappdata") + @"\Packages\windows.immersivecontrolpanel_cw5n1h2txyewy\LocalState\Indexed\Settings\zh-cn\SettingsPane_{911DD688-AEBA-4214-8C58-9C8FBC8C0710}.settingcontent-ms", "", false, false, false, false, false);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton7.Checked ==true)
            {
                Class_SystemStyle.SystemStyle_LoadStartScreenColorSettingsInWin81(this, 1);
            }
            else
            {
                Class_SystemStyle.SystemStyle_LoadStartScreenColorSettingsInWin81(this, 2);
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                Class_SystemStyle.SystemStyle_LoadStartScreenColorSettingsInWin81(this, 1);
            }
            else
            {
                Class_SystemStyle.SystemStyle_LoadStartScreenColorSettingsInWin81(this, 2);
            }
        }

        private void myNormalButton7_OnButtonClick(object sender, EventArgs e)
        {
            Form_SortingFileSettings f = new Form_SortingFileSettings("EDIT", new string[] { "cf" }, new string[] { "cf" });
            f.ShowDialog();
            Class_SystemStyle.SystemStyle_SortingFile_LoadCondition(this);
        }

        private void myNormalButton8_OnButtonClick(object sender, EventArgs e)
        {
            MyFunctions.ProgramAndLinksOperate.ReStartExplorer();
        }

        private void myNormalButton10_OnButtonClick(object sender, EventArgs e)
        {
            MyNormalButton  b = (MyNormalButton)sender;
            string Number = b.Tag.ToString();
            string rl = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent";
            MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.CurrentUser, rl, "MotionAccentId_v1.00", Number, RegistryValueKind.DWord, false, true);
            Class_SystemStyle.SystemStyle_LoadWin81StartScreenSetting(this);
            keybd_event(0x5b, 0, 0, 0); //0x5b是left win的代码，这一句使key按下，下一句使key释放。
            keybd_event(0x5b, 0, 0x2, 0);
        }

        private void myNormalButton31_OnButtonClick(object sender, EventArgs e)
        {
            string[] kl = MyFunctions.Dialogs.ChooseWinApp("选择Modern应用");
            if(kl[0] !="")
            {
                label109.Text = kl[0];
                pictureBox52.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(kl[2] + ",0", @"%windir%\system32\imageres.dll,2");
                pictureBox52.Tag = kl[2];
                label109.Tag = kl[1];
            }
        }

        private void myNormalButton29_OnButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (label109.Tag != null)
                {
                    if (label109.Tag.ToString() != "NOCHOOSE")
                    {
                        string lnk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + label109.Text + ".lnk";
                        MyFunctions.ProgramAndLinksOperate.CreateLink(lnk, "%systemroot%\\explorer.exe", @"shell:::{4234d49b-0245-4df3-b780-3893943456e1}\" + label109.Tag.ToString(), "", pictureBox52.Tag.ToString(), null);
                        MyFunctions.Dialogs.MessageDialog("创建成功", @"成功创建了程序""" + label109.Text + @"""的桌面图标", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("创建失败", @"您似乎并没有选择一个程序哦! 请点击""选择应用""", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                    }
                }
                else { MyFunctions.Dialogs.MessageDialog("创建失败", @"您似乎并没有选择一个程序哦! 请点击""选择应用""", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定"); }
            }
            catch { }
        }

        private void myNormalButton30_OnButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (label109.Tag != null)
                {
                    if (label109.Tag.ToString() != "NOCHOOSE")
                    {
                        string lnk = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath +"\temp") + "\\" + label109.Text + ".lnk";
                        MyFunctions.ProgramAndLinksOperate.CreateLink(lnk, "%systemroot%\\explorer.exe", @"shell:::{4234d49b-0245-4df3-b780-3893943456e1}\" + label109.Tag.ToString(), "", pictureBox52.Tag.ToString(), null);
                        MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, lnk);
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(lnk);
                        MyFunctions.Dialogs.MessageDialog("创建成功", @"成功创建了程序""" + label109.Text + @"""的任务栏图标", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("创建失败", @"您似乎并没有选择一个程序哦! 请点击""选择应用""", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                    }
                }
                else { MyFunctions.Dialogs.MessageDialog("创建失败", @"您似乎并没有选择一个程序哦! 请点击""选择应用""", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定"); }
            }
            catch { }
        }

        private void myNormalButton32_OnButtonClick(object sender, EventArgs e)
        {
            this.Start(1, 1);
            Point newPoint = new Point(0, this.tabPage6.Height - this.tabPage6.AutoScrollPosition.Y);
            this.tabPage6.AutoScrollPosition = newPoint;
        }

        private void myNormalButton81_OnButtonClick(object sender, EventArgs e)
        {
            Class_SystemStyle.SystemStyle_ApplyWin8Settings(this, "BORDER", new string[] { numericUpDown2.Value.ToString() });
        }

        private void myNormalButton84_OnButtonClick(object sender, EventArgs e)
        {
            Class_SystemStyle.SystemStyle_ApplyOtherSettings(this, "PREVIEWSIZE", new string[] { numericUpDown3.Value.ToString()});
        }

        private void myNormalButton86_OnButtonClick(object sender, EventArgs e)
        {
            MyFunctions.ProgramAndLinksOperate.LogOff();
        }

        private void myNormalButton87_OnButtonClick(object sender, EventArgs e)
        {
            MyFunctions.ProgramAndLinksOperate.LogOff();
        }

        private void treeView4_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string tag = e.Node.Tag.ToString();
                Class_SystemStyle.RightMenuMgr.LoadRightMenu(this, tag);
            }
            catch { }
        }

        private void listView8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(treeView4.SelectedNode !=null)
                {
                    string tag = treeView4.SelectedNode.Tag.ToString();
                    switch(tag.ToUpper())
                    {
                        case "MC":
                            if(listView8.SelectedItems.Count ==1)
                            {
                                string selecttag=listView8.SelectedItems[0].Tag.ToString();
                                string cfg = Application.StartupPath + @"\Config\RightMenuInfo\RM_MyComputer.sgcf";
                                string fn = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(selecttag, "FileName", "Unknown", false, cfg);
                                string fi = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(selecttag, "Fileinfo", "Unknown", false, cfg);
                                string fl = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(selecttag, "Filepath", "Unknown", false, cfg);
                                string rl = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(selecttag, "registrylocation", "Unknown", false, cfg);
                                string ico = fl;// MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(selecttag, "icon", "Unknown", false, cfg);
                                label112.Text = fn;
                                label113.Text = fi;
                                label115.Text = fl;
                                label117.Text = rl;
                                pictureBox50.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.GetFileIcon(ico).ToBitmap();
                            }
                            break;
                        case "RB":
                            if (listView8.SelectedItems.Count == 1)
                            {
                                string selecttag = listView8.SelectedItems[0].Tag.ToString();
                                string cfg = Application.StartupPath + @"\Config\RightMenuInfo\RM_RB.sgcf";
                                string fn = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(selecttag, "FileName", "Unknown", false, cfg);
                                string fi = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(selecttag, "Fileinfo", "Unknown", false, cfg);
                                string fl = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(selecttag, "Filepath", "Unknown", false, cfg);
                                string rl = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(selecttag, "registrylocation", "Unknown", false, cfg);
                                string ico = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(selecttag, "icon", "Unknown", false, cfg);
                                label112.Text = fn;
                                label113.Text = fi;
                                label115.Text = fl;
                                label117.Text = rl;
                                pictureBox50.Image = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ico, ico);
                            }
                            break;
                    }
                }
            }
            catch { }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
