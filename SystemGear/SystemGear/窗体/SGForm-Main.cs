using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemGear.窗体;
using SystemGear.窗体UI;
using SystemGear.Enums;
using System.Drawing.Drawing2D;
using SystemGear.类或代码;
using SystemGear.功能控件;
using System.Runtime.InteropServices;
namespace SystemGear.窗体
{
    public partial class SGForm_Main : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        string[] StartArgs = null;
        public bool ShellFunctionAfterShown = false;
        public string ShellCommand = "";
        public SGForm_Function_SystemStyle sgstyfrm = null;
        public SGModernButton choosetile = null;
        public string selectfunctionarg = "MA,1,1,1";
        private bool RUNONCE_HELP = false;
        public bool RUNONCE_ALLFUNCTION = false;
        public bool SHOULDBECLOSED = false;
        public SGForm_Main(string[] args)
        {
            InitializeComponent();
            StartArgs = args;
        }

        private void MyNormalButton1_OnButtonClick(object sender, EventArgs e)
        {

        }
        private void DefaultTile_OnButtonClick(object sender, EventArgs e)
        {
            SGModernButton my = (SGModernButton)sender;
            bool k = SGFunction.RunCommand.ShellSGFunction(this, this.sgstyfrm, my.Tag, out this.sgstyfrm);
            if (k == true) { this.Hide(); }
        }
        private void MyNormalButton1_Click_1(object sender, EventArgs e)
        {
            //contextMenuStrip2.Show(button43, new Point(0, button43.Height + 5));
            sgRightMenus_commands.Show(MyNormalButton1, new Point(0, MyNormalButton1.Size.Height + 5));
        }

        private void myModernButton11_OnButtonClick(object sender, EventArgs e)
        {

        }

        private void myModernButton3_OnButtonClick(object sender, EventArgs e)
        {

        }

        private void myModernButton13_OnButtonClick(object sender, EventArgs e)
        {

        }

        private void SGForm_Main_SizeChanged(object sender, EventArgs e)
        {
            this.panel1.Size = new Size(this.Size.Width - 189, this.panel1.Size.Height);
            MyNormalButton5.Location = new Point(this.panel1.Size.Width - MyNormalButton5.Size.Width, 0);
            MyNormalButton3.Location = new Point(MyNormalButton5.Location.X - MyNormalButton3.Size.Width, 0);
            MyNormalButton_moresetting.Location = new Point(MyNormalButton3.Location.X - MyNormalButton3.Size.Width, 0);
            myNormalButton_changeskin.Location = new Point(MyNormalButton_moresetting.Location.X - myNormalButton_changeskin.Size.Width, 0);
        }

        private void MyNormalButton5_Click(object sender, EventArgs e)
        {
            //Application.ExitThread();
            string exe=System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
            exe = exe.Substring(0, exe.LastIndexOf("."));
            //MessageBox.Show(exe);
            SGFunction.SystemFunctionAndInformation.CloseProcess(exe, false, Application.StartupPath);
        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SGForm_Main_Load(object sender, EventArgs e)
        {
            if (SHOULDBECLOSED == true) { Application.ExitThread(); }
            this.Text = "系统齿轮 "+SGFunction.ApplicationSetting.GetSGProgramVersion("MMAIN");
            SGMain.Load.LoadMainDialog(this, StartArgs);
            //this.Show();
            //sgItems1.Size = new Size(187, 480);
            label2.Text = "系统齿轮 " + SGFunction.ApplicationSetting.GetSGProgramVersion("FMAIN");
            //读取上次的位置
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\MainProgram.sgcf";
            string x = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("MAIN", "LOCATION_X", "NO", cfg, false);
            string y = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("MAIN", "LOCATION_y", "NO", cfg, false);
            if (x == "NO" || y == "NO")
            {
                this.Location = SGFunction.Control.SetDialogInCenterScreen(this);
            }
            else
            {
                Point c = SGFunction.Control.SetDialogInCenterScreen(this);
                int lx = c.X;
                int ly = c.Y;
                int.TryParse(x, out lx); int.TryParse(y, out ly);
                //验证是否有效的LOCATION
                bool changelocation = false;
                Size pt=SGFunction.SystemFunctionAndInformation.GetSrceenFenBianLv();
                if (lx < 0 || ly < 0 || ly > pt.Height - 50 || lx > pt.Width - 50)
                {

                }
                else { changelocation = true; }
                if (changelocation == true) { this.Location = new Point(lx, ly); } else { this.Location = SGFunction.Control.SetDialogInCenterScreen(this); }
            }
        }

        private void SGForm_Main_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }

        private void sgItems1_OnChooseItem(object sender, SGItems.ChooseItemEventArgs ce)
        {
            int s = ce.Index;
            this.Start(s, 1);
        }
        public void Start(int findex, int sindex = 1, int thi = 1)
        {
            int def = 0;
            switch (findex)
            {
                case 1:
                    def = 0;
                    if (sindex == 1 && thi == 2) //防止系统工具箱 自动跳转到TAB1
                    {
                        SGFunction.CommonDialogs.ShowSystemToolKit("系统工具箱");
                        return;
                    }
                    this.BestLoad(sindex, thi);
                    selectfunctionarg = "MA,1,1,1";
                    break;
                case 2:
                    def = 1;
                    selectfunctionarg = "MA,2,1,1";
                    if (RUNONCE_ALLFUNCTION == false)
                    {
                        switch (thi)
                        {
                            case 1: //stykle
                                SGMain.Load.LoadClassFunctions("STYLE", this);//解决无法应发SELECTEDINDEX时间的问题
                                break;
                            case 2: //systmem
                                sgTabPageControl_allfunction.SelectedIndex = thi - 1;
                                break;
                            case 3: //adv
                                sgTabPageControl_allfunction.SelectedIndex = thi - 1;
                                break;
                            case 4: //other
                                sgTabPageControl_allfunction.SelectedIndex = thi - 1;
                                break;
                        }
                        RUNONCE_ALLFUNCTION = true;
                    }
                    break;
                case 3:
                    this.SettingLoad(sindex, thi);
                    def = 2;
                    selectfunctionarg = "MA,3,1,1";
                    break;
                case 4:
                    def = 3;
                    this.AboutLoad(sindex, thi);
                    selectfunctionarg = "MA,4,1,1";
                    break;
            }
            sgTabPageControl_submain.SelectedIndex = def;
            sgItems1.Settings_ChooseItemsIndex = def + 1;
        }
        public void AboutLoad(int secindex, int thiindex = 1)
        {
            int def = 0;
            switch (secindex)
            {
                case 1:
                    def = 0;
                    if (RUNONCE_HELP == false)
                    {
                        string ma = SGFunction.ApplicationSetting.GetSGProgramVersion("FMAIN");
                        string pv = SGFunction.ApplicationSetting.GetSGProgramVersion("PMAIN");
                        string fv = SGFunction.ApplicationSetting.GetSGProgramVersion("FULL");
                        RUNONCE_HELP = true;
                        sgLabel1.Text = "系统齿轮 " + ma;
                        sgLabel3.Text = pv;
                        sgLabel4.Text = fv;
                    }
                    switch (thiindex)
                    {
                        case 2: //NEW FUNCTION
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("NEW FUNCTION", 2);
                            break;
                        case 3: //
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("CMD LINE", 2);
                            break;
                        case 4: //NEW FUNCTION
                            SGFunction.RunCommand.ShellURL("UPDATE");
                            break;
                        case 5: //NEW FUNCTION
                            SGFunction.RunCommand.ShellURL("refexon");
                            break;
                        case 6: //NEW FUNCTION
                            SGFunction.RunCommand.ShellURL("MORESOFTWARE");
                            break;
                        case 7: //FEEDBACK
                            SGFunction.RunCommand.ShellURL("joinus");
                            break;
                        case 8: //NEW FUNCTION
                            SGFunction.RunCommand.ShellURL("feedback");
                            break;
                    }
                    break;
                case 2:
                    def = 1;
                    break;
            }
            sgTabPageControl_about.SelectedIndex = def;
        }
        public void SettingLoad(int secindex, int thiindex = 1)
        {
            int def = 0;
            switch (secindex)
            {
                case 1:
                    def = 0;
                    switch (thiindex)
                    {
                        case 2: //备份中心
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"这个功能正在开发。您可以切换至""关于""选项卡并检查软件更新", 2);
                            this.Start(4, 1, 4);
                            break;
                    }
                    break;
            }
            sgTabPageControl_setting.SelectedIndex = def;
        }
        public void BestLoad(int secindex, int thiindex = 1)
        {
            int def = 0;
            switch (secindex)
            {
                case 1:
                    def = 0;
                    switch (thiindex)
                    {
                        case 2: //系统工具箱

                            break;
                    }
                    break;
            }
            sgTabPageControl_main.SelectedIndex = def;
        }

        private void MyNormalButton7_Click(object sender, EventArgs e)
        {
            string res;
            string[] lo = SGFunction.CommonDialogs.ShowMoreFunctionDialog("DFES", out res);
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {

        }

        private void sgRightMenus_commands_Opening(object sender, CancelEventArgs e)
        {
        }

        private void sgRightMenus_commands_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string t;
            bool oo = SGMain.Click.ShellSubCommand_Command(e.ClickedItem.Tag, this, this.sgstyfrm, out t);
            if (t == "SGF" && oo == true)
            {
                this.Hide();
            }
        }

        private void 编辑文字ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SGForm_Main_Shown(object sender, EventArgs e)
        {
            if (ShellFunctionAfterShown == true)
            {
                ShellFunctionAfterShown = false;
                if (ShellCommand != "")
                {
                    //防止MA,1,1,2 工具箱无法找到父系窗体
                    switch (ShellCommand.ToUpper())
                    {
                        case "MA,1,1,2":
                            break;
                        default:
                            this.Visible = false;
                            break;
                    }
                    bool p = SGFunction.RunCommand.ShellSGFunction(this, this.sgstyfrm, ShellCommand, out this.sgstyfrm);
                    if (p == true)
                    {
                        this.Visible = true;
                        this.Hide();
                    }
                    else { this.Visible = true; }
                }
            }
            //this.Visible = true;
            //this.Show();
            //MessageBox.Show("");
        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void MyNormalButton4_Click(object sender, EventArgs e)
        {
            //SGFunction.RunCommand.ShellURL("update");
            SGForm_UpdateProgram u = new SGForm_UpdateProgram();
            u.ShowDialog();
        }

        private void MyNormalButton6_Click(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellURL("moresoftware");
        }

        private void MyNormalButton12_Click(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellURL("refexon");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellURL("refexon");
        }

        private void SGForm_Main_LocationChanged(object sender, EventArgs e)
        {
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\mainprogram.sgcf";
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Main", "location_x", this.Location.X.ToString(), "config", false, cfg);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Main", "location_y", this.Location.Y.ToString(), "config", false, cfg);
        }
        private void DefaultTile_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                choosetile = (SGModernButton)sender;
            }
            catch { }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (choosetile != null)
            {
                bool k = SGFunction.RunCommand.ShellSGFunction(this, this.sgstyfrm, choosetile.Tag, out this.sgstyfrm);
                if (k == true) { this.Hide(); }
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (choosetile != null)
            {
                string[] ob = choosetile.ButtonTags;
                if (ob != null)
                {
                    if (ob.Length >= 3)
                    {
                        SGUserControl_EditMainTile d = new SGUserControl_EditMainTile(ob[1], ob[2], ob[0], choosetile, this);
                        SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("自定义主界面磁贴显示", d);
                    }

                }

            }
        }

        private void sgTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (sgTextBox_searchbox_text.Text != "")
            {
                SGFunction.ApplicationSetting.FindFunction(sgTextBox_searchbox_text.Text, this);
            }
            else
            {
                //this.sgCombobox_searchbox.DroppedDown = false;
            }
        }

        private void sgTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (sgTextBox_searchbox_text.Text != "")
            {
                this.sgCombobox_searchbox.Cursor = System.Windows.Forms.Cursors.Default;
                this.sgCombobox_searchbox.DroppedDown = true;
            }
        }

        private void sgCombobox_searchbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                object o = sgCombobox_searchbox.Tag;
                if (o != null)
                {
                    string[] pp = (string[])o;
                    if (pp != null)
                    {
                        if (pp.Length - 1 >= sgCombobox_searchbox.SelectedIndex)
                        {
                            string shell = pp[sgCombobox_searchbox.SelectedIndex];
                            bool p = SGFunction.RunCommand.ShellSGFunction(this, this.sgstyfrm, shell, out this.sgstyfrm);
                            if (p == true)
                            {
                                sgTextBox_searchbox_text.Text = "";
                                sgCombobox_searchbox.Items.Clear();
                                imageList_imageofsearch.Images.Clear();
                                this.Hide();
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void MyNormalButton13_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MainTile_PinToDesktop();
        }
        void MainTile_PinToDesktop()
        {
            if (choosetile != null)
            {
                try
                {
                    string[] arg = choosetile.ButtonTags;
                    if (arg != null)
                    {
                        if (arg.Length >= 3)
                        {
                            string h = arg[1];
                            string j = arg[2];
                            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\maintile.sgcf";
                            string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(h, j, "", cfg, false);
                            if (read != "")
                            {
                                string[] tt = read.Split('|');
                                if (tt.Length >= 6)
                                {
                                    string exp = Application.ExecutablePath;
                                    string arg1 = @"/S=""" + tt[2] + @"""";
                                    string icopath = tt[4];
                                    //MessageBox.Show(icopath);
                                    string lnkpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + tt[0] + ".LNK";
                                    icopath = SGFunction.PathOperate.ConvertStringToTurePath(icopath, icopath);
                                    switch (arg1.ToUpper())
                                    {
                                        case @"/S=""DESKTOPLABEL""":
                                            exp = SGFunction.RunCommand.GetSGProgramPath("DESKTOPLABEL"); arg1 = "";
                                            break;
                                        case @"/S=""PCLOCKER""":
                                            exp = SGFunction.RunCommand.GetSGProgramPath("PCLOCKER"); arg1 = "";
                                            break;
                                    }
                                    //为了解决访问IT迷 还需要管理员权限的问题
                                    SGFunction.SystemFunctionAndInformation.CreateLink(lnkpath, exp, arg1, tt[1], icopath);
                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }
        void MainTile_PinToTaskBar()
        {
            if (choosetile != null)
            {
                try
                {
                    string[] arg = choosetile.ButtonTags;
                    if (arg != null)
                    {
                        if (arg.Length >= 3)
                        {
                            string h = arg[1];
                            string j = arg[2];
                            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\maintile.sgcf";
                            string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(h, j, "", cfg, false);
                            if (read != "")
                            {
                                string[] tt = read.Split('|');
                                if (tt.Length >= 6)
                                {
                                    string exp = Application.ExecutablePath;
                                    string arg1 = @"/S=""" + tt[2] + @"""";
                                    string icopath = tt[4];
                                    //MessageBox.Show(icopath);
                                    string lnkpath = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("TEMP") + "\\" + tt[0] + ".LNK";
                                    icopath = SGFunction.PathOperate.ConvertStringToTurePath(icopath, icopath);
                                    switch (arg1.ToUpper())
                                    {
                                        case @"/S=""DESKTOPLABEL""":
                                            exp = SGFunction.RunCommand.GetSGProgramPath("DESKTOPLABEL"); arg1 = "";
                                            break;
                                        case @"/S=""PCLOCKER""":
                                            exp = SGFunction.RunCommand.GetSGProgramPath("PCLOCKER"); arg1 = "";
                                            break;
                                    }
                                    //为了解决访问IT迷 还需要管理员权限的问题
                                    SGFunction.SystemFunctionAndInformation.CreateLink(lnkpath, exp, arg1, tt[1], icopath);
                                    SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, lnkpath);
                                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnkpath);
                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }
        void MainTile_PinToStartMenu()
        {
            if (choosetile != null)
            {
                try
                {
                    string[] arg = choosetile.ButtonTags;
                    if (arg != null)
                    {
                        if (arg.Length >= 3)
                        {
                            string h = arg[1];
                            string j = arg[2];
                            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\maintile.sgcf";
                            string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(h, j, "", cfg, false);
                            if (read != "")
                            {
                                string[] tt = read.Split('|');
                                if (tt.Length >= 6)
                                {
                                    string exp = Application.ExecutablePath;
                                    string arg1 = @"/S=""" + tt[2] + @"""";
                                    string icopath = tt[4];
                                    //MessageBox.Show(icopath);
                                    string lnkpath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + tt[0] + ".LNK";
                                    icopath = SGFunction.PathOperate.ConvertStringToTurePath(icopath, icopath);
                                    switch (arg1.ToUpper())
                                    {
                                        case @"/S=""DESKTOPLABEL""":
                                            exp = SGFunction.RunCommand.GetSGProgramPath("DESKTOPLABEL"); arg1 = "";
                                            break;
                                        case @"/S=""PCLOCKER""":
                                            exp = SGFunction.RunCommand.GetSGProgramPath("PCLOCKER"); arg1 = "";
                                            break;
                                    }
                                    //为了解决访问IT迷 还需要管理员权限的问题
                                    SGFunction.SystemFunctionAndInformation.CreateLink(lnkpath, exp, arg1, tt[1], icopath);
                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MainTile_PinToTaskBar();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MainTile_PinToStartMenu();
        }

        private void MyNormalButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void MyNormalButton7_Click_1(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellURL("joinus");
        }

        private void MyNormalButton_moresetting_Click(object sender, EventArgs e)
        {
            sgRightMenus_moresetting.Show(MyNormalButton_moresetting, new Point(0, MyNormalButton_moresetting.Height + 5));
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            string arg = selectfunctionarg;
            string[] get = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, true, false);
            string exe = Application.ExecutablePath;
            string line = @"/S=""" + arg + @"""";
            string infotip = get[1];
            string name = get[0];
            string ico = get[5];
            string lnk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + name + ".lnk";
            SGFunction.SystemFunctionAndInformation.CreateLink(lnk, exe, line, infotip, ico);
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加到桌面。您可以在桌面上直接打开当前的功能。", 2);
        }

        private void toolStripMenuItem42_Click(object sender, EventArgs e)
        {
            string arg = selectfunctionarg;
            string[] get = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, true, false);
            string exe = Application.ExecutablePath;
            string line = @"/S=""" + arg + @"""";
            string infotip = get[1];
            string name = get[0];
            string ico = get[5];
            string lnk = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("TEMP") + "\\" + name + ".lnk";
            SGFunction.SystemFunctionAndInformation.CreateLink(lnk, exe, line, infotip, ico);
            SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, lnk);
            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnk);
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加到任务栏。您可以在任务栏上直接打开当前的功能。", 2);
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            string arg = selectfunctionarg;
            string[] get = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, true, false);
            string exe = Application.ExecutablePath;
            string line = @"/S=""" + arg + @"""";
            string infotip = get[1];
            string name = get[0];
            string ico = get[5];
            string lnk = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + name + ".lnk";
            SGFunction.SystemFunctionAndInformation.CreateLink(lnk, exe, line, infotip, ico);
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加到开始菜单。您可以在开始菜单上直接打开当前的功能。", 2);
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellURL("feedback");
        }
        public void ClassPanelMouseMove(object sender, MouseEventArgs e)
        {
            Panel p = (Panel)sender;
            p.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("OTHER", "classfunsbackcoloR");
        }
        public void ClassPanelMouseLeave(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            p.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("SGTAB", "PC");
        }





        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sgTabPageControl_allfunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = "STYLE";
            switch (sgTabPageControl_allfunction.SelectedIndex)
            {
                case 1:
                    type = "SYSTEM";
                    break;
                case 2:
                    type = "ADV";
                    break;
                case 3:
                    type = "OTHERS";
                    break;
            }
            SGMain.Load.LoadClassFunctions(type, this);
        }

        #region ALL FUNCTION界面
        public void Allfuntionbutton_click(object sender, EventArgs e)
        {
            SGModernButton s = (SGModernButton)sender;
            string cmd = "MA,2,1,1";
            cmd = (string)s.Tag;
            bool k = SGFunction.RunCommand.ShellSGFunction(this, this.sgstyfrm, cmd, out this.sgstyfrm);
            if (k == true) { this.Hide(); }
        }
        #endregion

        private void myNormalButton_changeskin_Click(object sender, EventArgs e)
        {
            UserControl_ChooseThemes UC = new UserControl_ChooseThemes(sgstyfrm,this);
            SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("换肤", UC,true);
        }

        private void myNormalButton2_Click_2(object sender, EventArgs e)
        {
            SGForm_WIN10STYLE f = new SGForm_WIN10STYLE();
            f.ShowDialog();
            int y=11 / 5;
            MessageBox.Show(y.ToString());
            //SGFunction.CommonDialogs.MessageDialog_MustClick("ccvd", "sadfasdf", "f", "fs", "b2", "error", "","dfvdf");
           //.Show(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(@"""E:\程序文件\SSD oolBox\SSDToolBox.exe""").ToString());
            //string arg;
         //   string exe = SGFunction.PathOperate.SplitCommandAndArg("rundll32.exe rgerg", out arg);
          //  MessageBox.Show(exe + "|" + arg);
            //myNormalButton2.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(@"C:\Program Files (x86)\VB精简版\vb6.exe,0", "", 32);
        }

        private void sgTextBox_searchbox_text_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void sgTextBox_searchbox_text_KeyDown(object sender, KeyEventArgs e)
        {
            if(sgCombobox_searchbox.Items.Count >0)
            {
                switch (e.KeyData)
                {
                    case Keys.Down:
                        sgCombobox_searchbox.SelectionStart = 0;
                        break;
                }
            }
        }

        private void myNormalButton4_Click_1(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellURL("feedback");
        }

        private void MyNormalButton_newfunction_Click(object sender, EventArgs e)
        {
            SystemGear.功能控件.SGUserControl_SGInformation sif=new SGUserControl_SGInformation("whatsnew");
            SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("新功能", sif);
        }

        private void MyNormalButton_commandport_Click(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellTextFile("command");
        }
        private void myNormalButton6_Click_1(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellTextFile("eula");
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
                            bool p = SGFunction.RunCommand.ShellSGFunction(this, this.sgstyfrm, args[0], out this.sgstyfrm);
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

    }
}
