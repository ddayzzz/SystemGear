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
using System.Diagnostics;
using System.Security.Principal;
using System.Xml;
using SystemGear;


namespace SystemGear
{
    public partial class Form_Main : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SystemParametersInfo(uint uAction, uint uParam, StringBuilder lpvParam, uint init);
        const uint SPI_GETDESKWALLPAPER = 0x0073;
        #region 窗体边框阴影效果变量申明

        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        #endregion
        public string ChooseFunction_Name = "";
        public string ChooseFunction_Info = "";
        public string ChooseFunction_Icon_Logo = "";
        public string ChooseFunction_Icon_Ico = "";
        public string ChooseFunction_CommandLine = "";
        public string JShow = "";
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        [DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        public string[] CommandArgs;
        public string PingName = "";
        public string MainPanel_Choose;
        public bool IsRunOnce=false;
        public Form_Main(string[] args)
        {
            InitializeComponent();
            CommandArgs = args;
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果
        }
        
        private void Form_Main_Deactivate(object sender, EventArgs e)
        {

        }
        private void Form_Main_Activated(object sender, EventArgs e)
        {
            
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            myNormalButton5.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.SystemStyle, "S01", true);
            myNormalButton6.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.SystemStyle, "S02", true);
            myNormalButton7.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.SystemStyle, "S03", true);
            myNormalButton8.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.SystemStyle, "S04", true);
            myNormalButton9.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.SystemStyle, "S05", true);
            myNormalButton10.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.SystemStyle, "S06", true);
            myNormalButton11.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.SystemStyle, "S07", true);
            myNormalButton12.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.SystemStyle, "S08", true);
            myNormalButton13.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.SystemStyle, "S09", true);
            //button10.BackgroundImage = MyFunctions.MediaOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon("c:\\windows\\explorer.exe,2","");
            //this.DrawLine();
            switch (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion())
            {
                case "6.3":
                    break;
                case "6.2":
                    break;
                case "6.1":
                    break;
                default:
                    string res = MyFunctions.Dialogs.MessageDialog("不支持您当前的操作系统版本", "系统齿轮(版本:" + Application.ProductVersion + ") 无法支持您的操作系统.", MyFunctions.Dialogs.MessageDialogIcon.Error , "系统齿轮(版本:" + Application.ProductVersion + ") 所支持的操作系统版本:\r\n[1].Windows 7 32位和64位\r\n[2].Windows 8(或8.1) 32位和64位\r\n \r\n您目前所使用的操作系统版本:\r\n" + MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSName(), "b1", true, true, "检查更新", "关闭");
                    if (res == "B1")
                    {
                        MyFunctions.ProgramAndLinksOperate.StartURL("http://www.54itmi.com/?page_id=76");
                    }
                    Application.Exit();
                    break;
            }
            System.Threading.Thread P_thread = new System.Threading.Thread(
                () => //lambda表达式（参数列表）=>{执行语句}  lambda表达式是比匿名方法更加简洁的一种匿名函数语法
                {
                   this.Invoke(new MethodInvoker(delegate()
                    {
                        StringBuilder wallPaperPath = new StringBuilder(200);

                        if (SystemParametersInfo(SPI_GETDESKWALLPAPER, 200, wallPaperPath, 0))
                        {
                            //MessageBox.Show(wallPaperPath.ToString());
                            try
                            {
                                myModernButton2.ButtonBackImage = Image.FromFile(wallPaperPath.ToString());
                            }
                            catch { }
                        }
                    }));
                });//new thread
            P_thread.IsBackground = true;
            P_thread.Start();
            //////////////
            panel2.Location = new Point(210, 32);
            panel2.Size = new Size(668, 26);
            /*
            Pen p = new Pen(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(), 2);//设置笔的粗细为,颜色为蓝色
            Graphics g = this.CreateGraphics();
            g.DrawRectangle(p, 0, 0, this.Size.Width, this.Size.Height);//在画板上画矩形,起始坐标为(10,10),宽为,高为
            //
             */
                Class_FormMain.Main_CheckPathCanWrite();
                Class_FormMain.Main_Enter(1, 1, this);
                MainPanel_Choose = "SG";
                if (CommandArgs.Length > 0)
                {
                    this.Hide();
                    Class_FormMain.Main_GetCommandArgs(this);
                }
                else
                {
                    if (MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_StartCommand() != "")
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.ExecutablePath, MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_StartCommand(), false, false, true, false, false);
                        Application.ExitThread();
                    }
                }
                
        }

        public void Form_Main_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class_FormMain.Main_Enter(1, 1, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class_FormMain.Main_Enter(2, 1, this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class_FormMain.Main_Enter(3, 1, this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class_FormMain.Main_Enter(4, 1, this);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            Label L = (Label)sender;
            L.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            switch (MainPanel_Choose)
            {
                case "SG":
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
                case "TOOLS":
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
                case "USERPING":
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
            }
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            switch (MainPanel_Choose)
            {
                case "SG":
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
                case "TOOLS":
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
                case "USERPING":
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Class_FormMain.Main_Enter(1, 1,this);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Class_FormMain.Main_Enter(1, 3, this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            switch (MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_ClickCloseBoxToOperate())
            {
                case "ASK":
                    string[] j = new string[2];
                    j[0] = "最小化到托盘，并不再询问(推荐)";
                    j[1] = "直接关闭程序，并不再询问";
                    string res=MyFunctions.Dialogs.TasksChooseDialog("关闭按钮选项", j);
                    if (res == "T1")
                    {
                        this.Hide_ToTuoPan();
                        MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SetApplicationSetting_ClickCloseBoxToOperate("HIDE");
                    }
                    else
                    {
                        if (res == "T2")
                        {
                            MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SetApplicationSetting_ClickCloseBoxToOperate("CLOSE");
                            Application.Exit();
                        }
                    }
                    break;
                case "HIDE":
                    this.Hide_ToTuoPan();
                    break;
                case "CLOSE":
                    Application.Exit();
                    break;
            }
        }
        public void Hide_ToTuoPan()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(1000, "系统齿轮", "系统齿轮正在系统后台运行", ToolTipIcon.Info);
        }
        public void ShowForm()
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_IsClickMinBoxInTaskBar() == true)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.Hide_ToTuoPan();
            }
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button11.Image 
                = Properties.Resources.CloseButton_MouseMove;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button11.Image  = Properties.Resources.CloseButton_Normal;
        }
        public void button8_Click(object sender, EventArgs e)
        {
            //MyFunctions.Dialogs.NotifyDialog("haoa", "ok", "close", true, true, new Point(50, 50), "b2");
            //Bitmap n = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(@"F:\我的图片\素材库\系统的图标\Windows 7 Imageres.dll shell32.dll 图标提取\imageres\imageres.dll(34).ico,0", "",32);
            //button8.Image = n;
            //string h = "j%dff".IndexOf("%").ToString();
            //Class_SystemStyle.SystemStyle_SortingFile_PreviewChange(@"D:\DF", true, @"F:\迅雷下载\9600.ALLIN1.20130922.ISO|F:\迅雷下载\Baofeng5-5.32.1227.exe");
            //string j = Class_SystemStyle.SystemStyle_SortingFile_AccordingNameResult("c", @"C:\Users\Wang\Desktop\SettingContent.regW");
            //Class_PublicDialogs.Public_ShowSmallTools("激活管理", new UserControl_SLMGR());
            //bool l = Class_SystemStyle.SystemStyle_SortingFile_CreateTempFile(@"F:\Desktop", true, @"F:\Desktop\迅雷白金会员获取器2013-11-15更新.exe|F:\Desktop\TextHand.exe|F:\Desktop\ppt 解释.docx");
            //MyFunctions.ShellExecute(NULL, "startpin", "C:\Users\王彬\Desktop\腾讯QQ.lnk", NULL, NULL, 0)
            //MyFunctions.Dialogs.EditLinkDialog(@"C:\Users\Wang\Desktop\HAHA.lnk");
            //myNormalButton9.ButtonBorderColor = Color.FromArgb(255, 255, 25);
            //button2.Image = MyFunctions.MediaOperate.LoadResources.LoadResources_GetBitmap(@"F:\迅雷下载\imageres.dll", 10002, "png");
            //MyFunctions.ShellExecute(IntPtr.Zero, new StringBuilder("taskbarpin"), new StringBuilder(@"windows.immersivecontrolpanel_cw5n1h2txyewy!microsoft.windows.immersivecontrolpanel"), new StringBuilder(""), new StringBuilder(""), 0);
            //MyFunctions.Dialogs.CommonDialog("filesize", "x", "更广泛", new string[] { "2555", "333" });
            //Class_ShuZiQianMing.GenerateADigitalSignatureFile(@"C:\Users\Wang\Desktop\1.cer", @"G:\系统齿轮\SystemGear\SystemGear\bin\Debug\Backup\Bootres - 副本.dll.rsa");
            
        }
        
        private void button35_Click(object sender, EventArgs e)
        {
         // MyFunctions.ProgramAndLinksOperate.StartURL("http://www.54itmi.com/?page_id=76");
            //Class_PublicDialogs.PublicDialog_SpecialDialog("系统齿轮更新日志", "NEW", new UserControl_CommandArgs(), this);
            MyFunctions.Dialogs.HelpDialog("系统齿轮更新日志", SystemGear.Properties.Resources.WhatIsNew);
           // MyFunctions.ProgramAndLinksOperate.ShellPrograms("notepad.exe", @"""" + Application.StartupPath + @"\系统齿轮更新日志.txt""", false, false, false, false, false, this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MyFunctions.ProgramAndLinksOperate.StartURL("http://refexon.54itmi.com/");
        }

        private void 显示系统齿轮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //MyFunctions.ProgramAndLinksOperate.ShellPrograms("notepad.exe", @"""" + Application.StartupPath + @"\CommandLines.txt""", false, false, false, false, false, null);
            //Class_PublicDialogs.PublicDialog_SpecialDialog("系统齿轮命令行选项", "ARG", new UserControl_CommandArgs(), this);
            MyFunctions.Dialogs.HelpDialog("系统齿轮命令行选项", SystemGear.Properties.Resources.CommandArgs);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //mini button
            if (radioButton1.Checked == true)
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainSettings", "MinBoxChoose", "TaskBar", "Config", false, Application.StartupPath + @"\Config\MainProgram.sgcf");
            }
            else
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainSettings", "MinBoxChoose", "Hide", "Config", false, Application.StartupPath + @"\Config\MainProgram.sgcf");
            }
            //CLOSE Button
            if (radioButton3.Checked == true)
            {
                MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SetApplicationSetting_ClickCloseBoxToOperate("HIDE");
            }
            else
            {
                if (radioButton4.Checked == true)
                {
                    MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SetApplicationSetting_ClickCloseBoxToOperate("CLOSE");
                }
            }
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainSettings", "StartCommand", textBox1.Text, "Config", false, Application.StartupPath + @"\Config\MainProgram.sgcf");
            MyFunctions.Dialogs.MessageDialog("应用成功", "已成功应用了您的设置", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string[] p =MyFunctions.Dialogs.ChooseOperateOrExploreFunctionDialog("fun");
                if (p != null)
                {
                    string cmd = p[1].ToString();
                    textBox1.Text = cmd;
                }
            }
            catch
            { }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int x = this.Location.X + button7.Location.X;
                int y = this.Location.Y + button7.Location.Y-1;
                Point xy = new Point(x, y);
                MyFunctions.Dialogs.PingProgram(this.ChooseFunction_CommandLine, this.ChooseFunction_Name, this.ChooseFunction_Icon_Logo, this.ChooseFunction_Info, this.ChooseFunction_Icon_Ico, xy);
            }
            catch { }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 2, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 1, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 3, 3, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 1, 2, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 8, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.FindForm().Hide();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 4, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.FindForm().Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {

                Form_SystemStyle fg = new Form_SystemStyle();
                Class_SystemStyle.SystemStyle_Enter(1, 6, 1, fg);
                fg.Location = this.FindForm().Location;
                fg.Show();
                this.FindForm().Hide();
            
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 3, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.FindForm().Hide();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 7, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.FindForm().Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string gh = MyFunctions.Dialogs.MessageDialog("无法打开这个功能", "该功能正在设计并调试之中,目前无法使用这个功能", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b1", true, true, "访问官网", "确定");
            if (gh == "B1")
            {
                MyFunctions.ProgramAndLinksOperate.StartURL("http://refexon.54itmi.com/team/index.htm");
            }
        }
        public  void PingButton_Click(object sender, EventArgs e)
        {
            MyModernButton btn = (MyModernButton)sender;
            string pingname = btn.ButtonTags[0].ToString();
            string cmd = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "command", Application.ExecutablePath, false, Application.StartupPath + @"\Config\Pings.sgcf");
            string cmdargs = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "commandargs", @"/M=01,01", false, Application.StartupPath + @"\Config\Pings.sgcf");
            MyFunctions.ProgramAndLinksOperate.ShellPrograms(cmd, cmdargs, false, false, true, false, false);
            Application.Exit();
        }
        public void PingButton_MouseDown(object sender, MouseEventArgs e)
        {
            MyModernButton btn = (MyModernButton)sender;
            this.PingName = btn.ButtonTags[0].ToString();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Ping_Open_Click(object sender, MouseEventArgs e)
        {
            try
            {
                string pingname = this.PingName;
                if (PingName != "")
                {
                    string cmd = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "command", Application.ExecutablePath, false, Application.StartupPath + @"\Config\Pings.sgcf");
                    string cmdargs = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "commandargs", @"/M=01,01", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(cmd, cmdargs, false, false, true, false, false);
                    Application.Exit();
                }
            }
            catch { }
        }
        public void Ping_EditColor_Click(object sender, MouseEventArgs e)
        {
            try
            {
                Color hj = MyFunctions.Dialogs.ColorDialog(Color.FromArgb(0, 159, 44));
                if (this.PingName != "")
                {
                    string pingname = this.PingName;
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "ColorR", hj.R.ToString(), "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "ColorG", hj.G.ToString(), "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "ColorB", hj.B.ToString(), "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    Class_FormMain.Main_LoadUserPing(this);
                }
            }
            catch { }
        }
        private void Ping_EditInfo_Click(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.PingName != "")
                {
                    string pingname = this.PingName;
                    string[] jj =MyFunctions.Dialogs.ChooseOperateOrExploreFunctionDialog("fun");
                    string def_cmd = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "CommandArgs", "", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    string def_pic = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "image", "", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    string def_name = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "Name", "", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    if (jj != null)
                    {
                        if (jj[0] != "") { def_name = jj[0]; }
                        if (jj[1] != "") { def_cmd = jj[1]; }
                        if (jj[2] != "") { def_pic = jj[2].Substring(5, jj[2].Length - 5); }
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "CommandArgs", def_cmd, "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "Image", def_pic, "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "Name", def_name, "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                        MyFunctions.Dialogs.MessageDialog("应用成功", "成功更改了命令", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "访问官网", "确定");
                        Class_FormMain.Main_LoadUserPing(this);
                    }
                }
            }
            catch { }
        }
        private void Ping_DeleteThis_Click(object sender, MouseEventArgs e)
        {
            try
            {
                string res = MyFunctions.Dialogs.MessageDialog("继续?", "您确定要删除指定的项目?", MyFunctions.Dialogs.MessageDialogIcon.Question , "", "b2", true, true, "继续", "取消");
                if (res == "B1")
                {
                    if (this.PingName != "")
                    {
                        string sgcf = Application.StartupPath + @"\Config\Pings.sgcf";
                        int SaveCommandItems =MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("info", "count", "0", false, sgcf), 1) - 1;
                        string[] SaveCommand_Name = new string[SaveCommandItems];
                        string[] SaveCommand_Icon = new string[SaveCommandItems];
                        string[] SaveCommand_Command = new string[SaveCommandItems];
                        string[] SaveCommand_CommandLine = new string[SaveCommandItems];
                        string[] SaveCommand_R = new string[SaveCommandItems];
                        string[] SaveCommand_G = new string[SaveCommandItems];
                        string[] SaveCommand_B = new string[SaveCommandItems];
                        int deleteindex =MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(this.PingName.Substring(4, this.PingName.Length - 4), 1);
                        int c = 1;
                        for (int y = 1; y <= SaveCommandItems + 1; y = y + 1)
                        {
                            if (y != deleteindex)
                            {
                                SaveCommand_Name[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "name", "", false, sgcf);
                                SaveCommand_Icon[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "image", "", false, sgcf);
                                SaveCommand_Command[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "command", "", false, sgcf);
                                SaveCommand_R[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "colorr", "", false, sgcf);
                                SaveCommand_G[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "colorG", "", false, sgcf);
                                SaveCommand_B[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "colorB", "", false, sgcf);
                                SaveCommand_CommandLine[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "commandargs", "", false, sgcf);
                            }
                            else
                            {
                                c = c + 1;
                            }
                        }
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Info", "Count", SaveCommandItems.ToString(), "Config", false, sgcf);
                        for (int g = 1; g <= SaveCommand_Name.Length; g = g + 1)
                        {
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "Name", SaveCommand_Name[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "Image", SaveCommand_Icon[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "Command", SaveCommand_Command[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "CommandArgs", SaveCommand_CommandLine[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "ColorR", SaveCommand_R[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "ColorG", SaveCommand_G[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "ColorB", SaveCommand_B[g - 1].ToString(), "Config", false, sgcf);
                        }
                        Class_FormMain.Main_LoadUserPing(this);
                        MyFunctions.Dialogs.MessageDialog("删除成功", "成功删除了指定的项目", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "访问官网", "确定");
                    }
                }
            }
            catch { }
        }
        private void Ping_DeleteAll_Click(object sender, MouseEventArgs e)
        {
            try
            {
                string res = MyFunctions.Dialogs.MessageDialog("继续?", "您确定要删除所有的项目?", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", true, true, "继续", "取消");
                if (res == "B1")
                {
                    if (this.PingName != "")
                    {
                        string sgcf = Application.StartupPath + @"\Config\Pings.sgcf";
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Info", "Count", "0", "Config", false, sgcf);
                        Class_FormMain.Main_LoadUserPing(this);
                        MyFunctions.Dialogs.MessageDialog("删除成功", "成功删除了所有的项目", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "访问官网", "确定");
                    }
                }
            }
            catch { }
        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pingname = this.PingName;
                if (PingName != "")
                {
                    string cmd = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "command", Application.ExecutablePath, false, Application.StartupPath + @"\Config\Pings.sgcf");
                    string cmdargs = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "commandargs", @"/M=01,01", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(cmd, cmdargs, false, false, true, false, false);
                    Application.Exit();
                }
            }
            catch { }
        }

        private void 调整颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Color hj=MyFunctions.Dialogs.ColorDialog(Color.FromArgb(0,159,44));
                if (this.PingName != "")
                {
                    string pingname = this.PingName;
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "ColorR", hj.R.ToString(), "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "ColorG", hj.G.ToString(), "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "ColorB", hj.B.ToString(), "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    Class_FormMain.Main_LoadUserPing(this);
                }
            }
            catch { }
                
        }

        private void 调整命令ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PingName != "")
                {
                    string pingname = this.PingName;
                    string[] jj = MyFunctions.Dialogs.ChooseOperateOrExploreFunctionDialog("fun");
                    string def_cmd = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "CommandArgs", "", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    string def_pic = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "image", "", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    string def_name = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(pingname, "Name", "", false, Application.StartupPath + @"\Config\Pings.sgcf");
                    if (jj != null)
                    {
                        if (jj[0] != "") { def_name = jj[0]; }
                        if (jj[1] != "") { def_cmd = jj[1]; }
                        if (jj[2] != "") { def_pic = jj[2].Substring(5,jj[2].Length -5); }
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "CommandArgs",def_cmd , "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "Image",def_pic, "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(pingname, "Name",def_name, "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                        MyFunctions.Dialogs.MessageDialog("应用成功", "成功更改了命令", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "访问官网", "确定");
                        Class_FormMain.Main_LoadUserPing(this);
                    }
                }
            }
            catch { }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 删除这个ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string res = MyFunctions.Dialogs.MessageDialog("继续?", "您确定要删除指定的项目?", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", true, true, "继续", "取消");
                if (res == "B1")
                {
                    if (this.PingName != "")
                    {
                        string sgcf = Application.StartupPath + @"\Config\Pings.sgcf";
                        int SaveCommandItems = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("info", "count", "0", false, sgcf), 1) - 1;
                        string[] SaveCommand_Name = new string[SaveCommandItems];
                        string[] SaveCommand_Icon = new string[SaveCommandItems];
                        string[] SaveCommand_Command = new string[SaveCommandItems];
                        string[] SaveCommand_CommandLine = new string[SaveCommandItems];
                        string[] SaveCommand_R = new string[SaveCommandItems];
                        string[] SaveCommand_G = new string[SaveCommandItems];
                        string[] SaveCommand_B = new string[SaveCommandItems];
                        int deleteindex = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(this.PingName.Substring(4, this.PingName.Length - 4), 1);
                        int c = 1;
                        for (int y = 1; y <= SaveCommandItems + 1; y = y + 1)
                        {
                            if (y != deleteindex)
                            {
                                SaveCommand_Name[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "name", "", false, sgcf);
                                SaveCommand_Icon[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "image", "", false, sgcf);
                                SaveCommand_Command[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "command", "", false, sgcf);
                                SaveCommand_R[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "colorr", "", false, sgcf);
                                SaveCommand_G[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "colorG", "", false, sgcf);
                                SaveCommand_B[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "colorB", "", false, sgcf);
                                SaveCommand_CommandLine[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "commandargs", "", false, sgcf);
                            }
                            else
                            {
                                c = c + 1;
                            }
                        }
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Info", "Count", SaveCommandItems.ToString(), "Config", false, sgcf);
                        for (int g = 1; g <= SaveCommand_Name.Length; g = g + 1)
                        {
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "Name", SaveCommand_Name[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "Image", SaveCommand_Icon[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "Command", SaveCommand_Command[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "CommandArgs", SaveCommand_CommandLine[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "ColorR", SaveCommand_R[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "ColorG", SaveCommand_G[g - 1].ToString(), "Config", false, sgcf);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + g.ToString(), "ColorB", SaveCommand_B[g - 1].ToString(), "Config", false, sgcf);
                        }
                        Class_FormMain.Main_LoadUserPing(this);
                        MyFunctions.Dialogs.MessageDialog("删除成功", "成功删除了指定的项目", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "访问官网", "确定");
                    }
                }
            }
            catch { }
        }

        private void 删除所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string res = MyFunctions.Dialogs.MessageDialog("继续?", "您确定要删除所有的项目?", MyFunctions.Dialogs.MessageDialogIcon.Question , "", "b2", true, true, "继续", "取消");
                if (res == "B1")
                {
                    if (this.PingName != "")
                    {
                        string sgcf = Application.StartupPath + @"\Config\Pings.sgcf";
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Info", "Count", "0", "Config", false, sgcf);
                        Class_FormMain.Main_LoadUserPing(this);
                        MyFunctions.Dialogs.MessageDialog("删除成功", "成功删除了所有的项目", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "访问官网", "确定");
                    }
                }
            }
            catch { }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            MouseEventHandler[] MEV = new MouseEventHandler[4];
            string[] cmds = new string[4];
            cmds[0] = "桌面图标";
            cmds[1] = "系统图标";
            cmds[2] = "扩展名管理";
            cmds[3] = "任务栏图标";
            MEV[0] = SYSVIE_01;
            MEV[1] = SYSVIE_01;
            MEV[2] = SYSVIE_01;
            MEV[3] = SYSVIE_01;
            MyFunctions.Controls.FormType.PublicControls_ContextMenu(cmds, Color.FromArgb(0, 148, 255), MEV, this.Location.X + myNormalButton5.Location.X + tabControl1.Location.X + 5, this.Location.Y + myNormalButton5.Location.Y + myNormalButton5.Size.Height + 30 + tabControl1.Location.Y);
        }
        public void SYSVIE_01(object sender, MouseEventArgs e)
        {
            try
            {
                Button BTN = (Button)sender;
                string j = BTN.Tag.ToString();
                Form_SystemStyle fg = new Form_SystemStyle();
                Class_SystemStyle.SystemStyle_Enter(1, 1, Convert.ToInt32(j.Substring(1, j.Length - 1)), fg);
                fg.Location = this.FindForm().Location;
                fg.Show();
                this.FindForm().Hide();
            }
            catch { }
        }
        public void SYSVIE_02(object sender, MouseEventArgs e)
        {
            try
            {
                Button BTN = (Button)sender;
                string j = BTN.Tag.ToString();
                Form_SystemStyle fg = new Form_SystemStyle();
                Class_SystemStyle.SystemStyle_Enter(1, 2, Convert.ToInt32(j.Substring(1, j.Length - 1)), fg);
                fg.Location = this.FindForm().Location;
                fg.Show();
                this.FindForm().Hide();
            }
            catch { }
        }
        public void SYSVIE_03(object sender, MouseEventArgs e)
        {
            try
            {
                Button BTN = (Button)sender;
                string j = BTN.Tag.ToString();
                Form_SystemStyle fg = new Form_SystemStyle();
                Class_SystemStyle.SystemStyle_Enter(1, 3, Convert.ToInt32(j.Substring(1, j.Length - 1)), fg);
                fg.Location = this.FindForm().Location;
                fg.Show();
                this.FindForm().Hide();
            }
            catch { }
        }
        public void SYSVIE_04(object sender, MouseEventArgs e)
        {
            try
            {
                Button BTN = (Button)sender;
                string j = BTN.Tag.ToString();
                Form_SystemStyle fg = new Form_SystemStyle();
                Class_SystemStyle.SystemStyle_Enter(1, 4, Convert.ToInt32(j.Substring(1, j.Length - 1)), fg);
                fg.Location = this.FindForm().Location;
                fg.Show();
                this.FindForm().Hide();
            }
            catch { }
        }
        public void SYSVIE_05(object sender, MouseEventArgs e)
        {
            try
            {
                Button BTN = (Button)sender;
                string j = BTN.Tag.ToString();
                Form_SystemStyle fg = new Form_SystemStyle();
                Class_SystemStyle.SystemStyle_Enter(1, 5, Convert.ToInt32(j.Substring(1, j.Length - 1)), fg);
                fg.Location = this.FindForm().Location;
                fg.Show();
                this.FindForm().Hide();
            }
            catch { }
        }
        public void SYSVIE_06(object sender, MouseEventArgs e)
        {
            try
            {
                Button BTN = (Button)sender;
                string j = BTN.Tag.ToString();
                Form_SystemStyle fg = new Form_SystemStyle();
                Class_SystemStyle.SystemStyle_Enter(1, 6, Convert.ToInt32(j.Substring(1, j.Length - 1)), fg);
                fg.Location = this.FindForm().Location;
                fg.Show();
                this.FindForm().Hide();
            }
            catch { }
        }
        public void SYSVIE_07(object sender, MouseEventArgs e)
        {
            try
            {
                Button BTN = (Button)sender;
                string j = BTN.Tag.ToString();
                Form_SystemStyle fg = new Form_SystemStyle();
                Class_SystemStyle.SystemStyle_Enter(1, 7, Convert.ToInt32(j.Substring(1, j.Length - 1)), fg);
                fg.Location = this.FindForm().Location;
                fg.Show();
                this.FindForm().Hide();
            }
            catch { }
        }
        public void SYSVIE_08(object sender, MouseEventArgs e)
        {
            try
            {
                Button BTN = (Button)sender;
                string j = BTN.Tag.ToString();
                Form_SystemStyle fg = new Form_SystemStyle();
                Class_SystemStyle.SystemStyle_Enter(1, 8, Convert.ToInt32(j.Substring(1, j.Length - 1)), fg);
                fg.Location = this.FindForm().Location;
                fg.Show();
                this.FindForm().Hide();
            }
            catch { }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            MouseEventHandler[] MEV = new MouseEventHandler[2];
            string[] cmds = new string[2];
            cmds[0] = "新建GUID图标";
            cmds[1] = "GUID程序";
            MEV[0] = SYSVIE_02;
            MEV[1] = SYSVIE_02;
            MyFunctions.Controls.FormType.PublicControls_ContextMenu(cmds, Color.FromArgb(0, 148, 255), MEV, this.Location.X + myNormalButton6.Location.X + tabControl1.Location.X + 5, this.Location.Y + myNormalButton6.Location.Y + myNormalButton6.Size.Height + 30 + tabControl1.Location.Y);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            MouseEventHandler[] MEV = new MouseEventHandler[2];
            string[] cmds = new string[2];
            cmds[0] = "文件夹美化";
            cmds[1] = "驱动器美化";
            MEV[0] = SYSVIE_03;
            MEV[1] = SYSVIE_03;
            MyFunctions.Controls.FormType.PublicControls_ContextMenu(cmds, Color.FromArgb(0, 148, 255), MEV, this.Location.X + myNormalButton7.Location.X + tabControl1.Location.X + 5, this.Location.Y + myNormalButton7.Location.Y + myNormalButton7.Size.Height + 30 + tabControl1.Location.Y);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            MouseEventHandler[] MEV = new MouseEventHandler[3];
            string[] cmds = new string[3];
            cmds[0] = "右键菜单组";
            cmds[1] = "快捷命令";
            cmds[2] = "剪切板";
            MEV[0] = SYSVIE_04;
            MEV[1] = SYSVIE_04;
            MEV[2] = SYSVIE_04;
            MyFunctions.Controls.FormType.PublicControls_ContextMenu(cmds, Color.FromArgb(0, 148, 255), MEV, this.Location.X + myNormalButton8.Location.X + tabControl1.Location.X + 5, this.Location.Y + myNormalButton8.Location.Y + myNormalButton8.Size.Height + 30 + tabControl1.Location.Y);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            string[] cmds = new string[4];
            cmds[0] = @"""开始""屏幕";
            cmds[1] = "锁屏壁纸";
            cmds[2] = "Win+X菜单";
            cmds[3] = "This PC";
            MouseEventHandler[] MEV = new MouseEventHandler[4];
            MEV[0] = SYSVIE_05;
            MEV[1] = SYSVIE_05;
            MEV[2] = SYSVIE_05;
            MEV[3] = SYSVIE_05;
            MyFunctions.Controls.FormType.PublicControls_ContextMenu(cmds, Color.FromArgb(0, 148, 255), MEV, this.Location.X + myNormalButton9.Location.X + tabControl1.Location.X + 5, this.Location.Y + myNormalButton9.Location.Y + myNormalButton9.Size.Height + 30 + tabControl1.Location.Y);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 7, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.FindForm().Hide();
        }
        private void button32_Click(object sender, EventArgs e)
        {
            string[] cmds = new string[2];
            cmds[0] = "登录界面";
            cmds[1] = "开(关)机音乐";
            MouseEventHandler[] MEV = new MouseEventHandler[2];
            MEV[0] = SYSVIE_06;
            MEV[1] = SYSVIE_06;
            MyFunctions.Controls.FormType.PublicControls_ContextMenu(cmds, Color.FromArgb(0, 148, 255), MEV, this.Location.X + myNormalButton10.Location.X + tabControl1.Location.X + 5, this.Location.Y + myNormalButton10.Location.Y + myNormalButton10.Size.Height + 30 + tabControl1.Location.Y);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            string[] cmds = new string[2];
            cmds[0] = "虚拟磁盘";
            cmds[1] = "系统启动菜单";
            MouseEventHandler[] MEV = new MouseEventHandler[2];
            MEV[0] = SYSVIE_08;
            MEV[1] = SYSVIE_08;
            MyFunctions.Controls.FormType.PublicControls_ContextMenu(cmds, Color.FromArgb(0, 148, 255), MEV, this.Location.X + myNormalButton12.Location.X + tabControl1.Location.X + 5, this.Location.Y + myNormalButton12.Location.Y + myNormalButton12.Size.Height + 30 + tabControl1.Location.Y);
        }

        public void button19_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                string[] cmds = new string[6];
                cmds[0] = "打开";
                cmds[1] = "编辑颜色";
                cmds[2] = "编辑信息";
                cmds[3] = "|";
                cmds[4] = "删除这个";
                cmds[5] = "删除所有";
                MouseEventHandler[] ev = new MouseEventHandler[5];
                ev[0] = Ping_Open_Click;
                ev[1] = Ping_EditColor_Click;
                ev[2] = Ping_EditInfo_Click;
                ev[3] = Ping_DeleteThis_Click;
                ev[4] = Ping_DeleteAll_Click;
                //MessageBox.Show(e.Location.X.ToString());
                Button btn = (Button)sender;
                MyFunctions.Controls.FormType.PublicControls_ContextMenu(cmds, Color.FromArgb(0, 148, 255), ev, this.Location.X + tabControl1.Location.X + btn.Location.X + e.Location.X, this.Location.Y + tabControl1.Location.Y + btn.Location.Y + e.Location.Y);
            }
            catch { }
        }

        private void label23_MouseMove(object sender, MouseEventArgs e)
        {
            //if (MainPanel_Choose == "TOOLS")
            //{
                label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
            //}
        }

        private void label23_MouseLeave(object sender, EventArgs e)
        {
            switch (MainPanel_Choose)
            {
                case "SG":
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
                case "TOOLS":
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
                case "USERPING":
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {
            Class_FormMain.Main_Enter(1, 2, this);
        }

        private void Tools_Click(object sender, EventArgs e)
        {
            MyModernButton btn=(MyModernButton)sender;
            string tag = btn.ButtonTags[0].ToString();
            string args = btn.ButtonTags[1].ToString();
            MyFunctions.ProgramAndLinksOperate.ShellTool(tag, args);
        }
        private void Form_Main_Shown_1(object sender, EventArgs e)
        {
            
            //this.Hide();
            switch (JShow.ToUpper())
            {
                case "SYSVIE":
                    this.Hide();
                    break;
            }
        }

        private void Form_Main_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetBorderColor(), 2.0f);//设置笔的粗细为,颜色为蓝色
            Graphics g = this.CreateGraphics();
            Point f, l;
            f = new Point(panel1.Size.Width, 0);
            l = new Point(this.Size.Width, 0);
            g.DrawLine(p, f, l);
            //label1.Location = new Point(label1.Location.X, this.label1.Location.Y + 2);
            //this.button7.Location = new Point(this.button7.Location.X, this.button7.Location.Y + 3+1);
            //this.button6.Location = new Point(this.button6.Location.X, this.button6.Location.Y + 3+1);
            //this.button11.Location = new Point(this.button11.Location.X, this.button11.Location.Y + 3+1);
            IsRunOnce = true;
            //drawrights
            Point rf, rl;
            rf = new Point(this.Width, 0);
            rl = new Point(this.Width, this.Height);
            Pen p1 = new Pen(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(), 2.0f);//设置笔的粗细为,颜色为蓝色
            Graphics g1 = this.CreateGraphics();
            g1.DrawLine(p1, rf, rl);
            //drawdown
            Point df, dl;
            df = new Point(this.panel1.Size.Width, this.Height);
            dl = new Point(this.Width, this.Height);
            Pen p2 = new Pen(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(), 2.0f);//设置笔的粗细为,颜色为蓝色
            Graphics g2 = this.CreateGraphics();
            g2.DrawLine(p2, df, dl);


        }

        private void myModernButton5_OnButtonClick(object sender, EventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 5, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void myNormalButton1_OnButtonClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("5");
        }

        private void button17_Click(object sender, MouseEventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 1, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button22_Click(object sender, MouseEventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 6, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void myModernButton5_OnButtonClick(object sender, MouseEventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 5, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button15_Click(object sender, MouseEventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 2, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button16_Click(object sender, MouseEventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 3, 2, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button18_Click(object sender, MouseEventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 1, 2, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button14_Click(object sender, MouseEventArgs e)
        {
            string res=MyFunctions.Dialogs.MessageDialog("无法启动功能", "该功能正在调试之中", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b1", true, true, "检查更新", "确定");
            if (res == "B1")
            {
                MyFunctions.ProgramAndLinksOperate.StartURL("http://www.54itmi.com");
            }
        }

        private void button25_Click(object sender, MouseEventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 3, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button20_Click(object sender, MouseEventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 8, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button21_Click(object sender, MouseEventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 4, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button26_Click(object sender, MouseEventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 7, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MyFunctions.ProgramAndLinksOperate.StartURL("http://refexon.54itmi.com/team/index.htm");
        }
        private void Title_MouseLeave(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            switch(MainPanel_Choose )
            {
                case "SG":
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
                case "TOOLS":
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
                case "USERPING":
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
            }
        }
        private void Title_Click(object sender, EventArgs e)
        {
            Label  btn = (Label )sender;
            switch (btn.Tag.ToString())
            {
                case "1":
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
                case "2":
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
                case "3":
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                    label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                    break;
            }
            int j=Convert.ToInt32(btn.Tag );
            Class_FormMain.Main_Enter(1, j, this);
        }
        public void SYSVIE_09(object sender, MouseEventArgs e)
        {
            try
            {
                Button BTN = (Button)sender;
                string j = BTN.Tag.ToString();
                Form_SystemStyle fg = new Form_SystemStyle();
                Class_SystemStyle.SystemStyle_Enter(1, 9, Convert.ToInt32(j.Substring(1, j.Length - 1)), fg);
                fg.Location = this.FindForm().Location;
                fg.Show();
                this.FindForm().Hide();
            }
            catch { }
        }
        private void myNormalButton13_OnButtonClick(object sender, System.EventArgs e)
        {
            Form_SystemStyle fg = new Form_SystemStyle();
            Class_SystemStyle.SystemStyle_Enter(1, 9, 1, fg);
            fg.Location = this.FindForm().Location;
            fg.Show();
            this.FindForm().Hide();
        }

        private void mySlidingDrawer1_OnChooseSecond(object sender, EventArgs e)
        {
            
        }

        private void mySlidingDrawer1_OnChooseSecond(object sender, SGSlidingDrawer.ChooseSecondEventArgs ce)
        {
            MessageBox.Show(ce.MainIndex.ToString()+","+ce.SecondIndex .ToString()+","+ce.Tag);
        }

    }
}
