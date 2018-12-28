using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SystemGear.窗体
{
    public partial class SGForm_MoreFunctions : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private string adddefaultmenu = "exit";
        List<string> dfmenu_addvalue = new List<string>();
        public string program = "";
        public string programarg = "";
        public string programicon = "";
        public string programname = "";
        public bool runasadmin = false;
        public string choosetype = "";
        public string buttonclick = "exit";
        public string tiptext = "点击以下的按钮选择一个操作";
        private int tagindex = 0; //当前的TabControl的值
        private string frmtype;
        private bool hasrunasadmin = false;
        //
        public string f_chooseread = "";
        public string f_choosebelong = "";
        public string f_choosesystemstyle_head = "";
        //
        public string[] choosesgfunction;
        public SGForm_MoreFunctions(string frmflagr,string title,bool runas,string type,bool hasdev=false)
        {
            InitializeComponent();
            sgTabPageControl1.Location = new Point(2, 32);
            //SKIN
            Color dialog_stand_title_fr = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "title_fr");
            Color dialog_stand_title_bk = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "TITLE_BK");
            Color dialog_stand_bd = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "bd");
           // Color mainc = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
            Color o_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "bk");
            Color o_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "fr");
            Color o1_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "bk");
            Color o1_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "fr");
            Color lab_ma_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_maininfo", "fr");
            Color lab_fu_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_funinfo", "fr");
            Color list_fr = SGFunction.Skins.Skins_GetControlColorSetting("listview", "fr");
            this.BackColor = dialog_stand_bd;
            label_title.ForeColor = dialog_stand_title_fr;
            panel1.BackColor = MyNormalButton1.BackColor = dialog_stand_title_bk;
            panel3.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "pc");
            sgLabel1.ForeColor = lab_ma_fr;
            label1.ForeColor = lab_ma_fr;
            SGFunction.Skins.DrawAllControlInTabControl(sgTabPageControl1);
            SGFunction.Skins.DrawAllControlInTabControl(sgTabPageControl2);
            SGFunction.Skins.DrawAllControlInTabControl(sgTabPageControl_openfile);
            //LOAD
            this.label_title.Text = this.Text = title;
            frmtype = type;
            hasrunasadmin = runas;
            switch(frmflagr.ToUpper())
            {
                case "NORMAL":
                    if (runas == false)
                    {
                        sgCheckBox1.Checked = sgCheckBox2.Checked = false;
                        sgCheckBox2.Visible = sgCheckBox1.Visible = false;
                    }
                    else
                    {
                        sgCheckBox2.Visible = sgCheckBox1.Visible = true;
                    }
                    if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.1") { sgCheckBox3.Checked = false; sgCheckBox3.Visible = false; } else { sgCheckBox3.Checked = true; sgCheckBox3.Visible = true; }
                    sgTabPageControl1.SelectedIndex = 0;
                    break;
                case "SGFUNCTION":
                    sgTabPageControl1.SelectedIndex = 5;
                    label1.Text = "请在以下的下拉列表中选择您常用的功能";
                    //this.LoadSGFunction(hasdev);
                    sgCombobox_main.SelectedIndex = 1;
                    break;
                case "ADDRM":
                    sgTabPageControl1.SelectedIndex = 6;
                    label1.Text = "添加一些右键菜单";
                    this.LoadDefaultRightMenu();
                    break;
            }
        }

        private void sgRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(sgRadioButton_file.Checked ==true)
            {
                tagindex = 1;
                sgTabPageControl1.SelectedIndex = tagindex;
                sgRadioButton_file_openfile.Checked = true;
                label1.Text = "如何操作文件？";
            }
        }

        private void sgRadioButton_file_openfile_CheckedChanged(object sender, EventArgs e)
        {
            if (sgRadioButton_file_openfile.Checked == true)
            {
                panel2.Enabled = false;
                panel_file_openfilebyexe.Enabled = false;
                panel_file_onlyopenfile.Enabled = true;
            }
        }

        private void SGForm_MoreFunctions_Load(object sender, EventArgs e)
        {
            //影藏
            sgTabPageControl_openfile.Location = new Point(0, -35);
            sgTabPageControl2.Location = sgTabPageControl_openfile.Location;
            //SELECT
            sgCombobox_programlist.SelectedIndex  = 0;
            if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.1")
            {
                sgCheckBox5.Visible = false;
                sgCheckBox5.Checked = false;
                sgCheckBox3.Checked = sgCheckBox3.Visible = false;
            }
        }

        private void sgRadioButton_file_openfilebyexe_CheckedChanged(object sender, EventArgs e)
        {
            if (sgRadioButton_file_openfilebyexe.Checked == true)
            {
                panel2.Enabled = false;
                panel_file_openfilebyexe.Enabled = true;
                panel_file_onlyopenfile.Enabled = false;
            }
        }

        private void sgRadioButton_file_openfolder_CheckedChanged(object sender, EventArgs e)
        {
            if (sgRadioButton_file_openfolder.Checked == true)
            {
                panel2.Enabled = true;
                panel_file_openfilebyexe.Enabled = false;
                panel_file_onlyopenfile.Enabled = false;
            }
        }

        private void MyNormalButton99_Click(object sender, EventArgs e)
        {
            string j = SGFunction.CommonDialogs.OpenFileDialog("打开文件", "所有文件(*.*)|*.*");
            if(j !="")
            {
                sgTextBox_file_openfile.Text = j;
            }
        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            string j = SGFunction.CommonDialogs.OpenFileDialog("打开文件", "所有文件(*.*)|*.*");
            if (j != "")
            {
                sgTextBox2.Text = j;
            }
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            string j = SGFunction.CommonDialogs.OpenFileDialog("打开程序", "可执行程序文件(*.exe)|*.exe");
            if (j != "")
            {
                sgTextBox1.Text = j;
                sgCombobox_programlist.SelectedIndex = 0;
            }
        }

        private void MyNormalButton4_Click(object sender, EventArgs e)
        {
            string j = SGFunction.CommonDialogs.OpenFolderDialog("选择一个文件夹");
            if (j != "")
            {
                sgTextBox3.Text = j;
            }
        }
        private void OpenFile_ReadProgram(string file)
        {
            switch (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(file).ToUpper())
            {
                case "EXE":
                    //选择的文件是个EXE 直接执行
                    sgTextBox_openfile_name.Text = "打开程序";
                    sgTextBox_openfile_program.Text = sgTextBox_openfile_ico.Text = file; sgTextBox_openfile_arg.Text = "";
                    break;
                case "TIF":
                case "TIFF":
                case "JFIF":
                case "JPE":
                case "DIB":
                case "GIF":
                case "PNG":
                case "BMP":
                case "JPEG":
                case "JPG":
                case "ICO":
                    //图片
                    //选择图片打开程序
                    string[] opinions = new string[] { "使用照片查看器打开", "使用画图打开" };
                    string choosetsk = SGFunction.CommonDialogs.ChooseTaskDialog("您希望使用哪个程序打开这个图片？", opinions, "%windir%\\system32\\imageres.dll,78");
                    switch (choosetsk)
                    {
                        case "t1":
                            sgTextBox_openfile_name.Text = "使用照片查看器打开图片";
                            sgTextBox_openfile_program.Text = Environment.GetEnvironmentVariable("windir") + "\\system32\\rundll32.exe";
                            sgTextBox_openfile_ico.Text =SGFunction.ExtensionOperate.GetExtensionIcon(file);
                            sgTextBox_openfile_arg.Text = @"""%ProgramFiles%\Windows Photo Viewer\PhotoViewer.dll"",ImageView_Fullscreen " + sgTextBox_file_openfile.Text;
                            break;
                        case "t2":
                            sgTextBox_openfile_name.Text = "使用画图打开图片";
                            sgTextBox_openfile_program.Text = Environment.GetEnvironmentVariable("windir") + "\\system32\\mspaint.exe";
                            sgTextBox_openfile_ico.Text =SGFunction.ExtensionOperate.GetExtensionIcon(file);
                            sgTextBox_openfile_arg.Text = @"""" + sgTextBox_file_openfile.Text + @"""";
                            break;
                        default:
                            sgTabPageControl_openfile.SelectedIndex = 0;
                            break;
                    }
                    break;
                case "CMD":
                case "BAT":
                    sgTextBox_openfile_name.Text = "打开批处理文件";
                    sgTextBox_openfile_program.Text = Environment.GetEnvironmentVariable("windir") + "\\system32\\cmd.exe";
                    sgTextBox_openfile_ico.Text = SGFunction.ExtensionOperate.GetExtensionIcon(file);
                    sgTextBox_openfile_arg.Text = @"/k """ + sgTextBox_file_openfile.Text + @"""";
                    break;
                case "VBS":
                case "JS":
                    sgTextBox_openfile_name.Text = "打开脚本文件";
                    sgTextBox_openfile_program.Text = Environment.GetEnvironmentVariable("windir") + "\\system32\\wscript.exe";
                    sgTextBox_openfile_ico.Text = SGFunction.ExtensionOperate.GetExtensionIcon(file);
                    sgTextBox_openfile_arg.Text = @"""" + sgTextBox_file_openfile.Text + @"""";
                    break;
                case "3GP":
                case "MP4":
                case "WMV":
                    sgTextBox_openfile_name.Text = "播放视频文件";
                    sgTextBox_openfile_program.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Windows Media Player\\wmplayer.exe";
                    sgTextBox_openfile_ico.Text = SGFunction.ExtensionOperate.GetExtensionIcon(file);
                    sgTextBox_openfile_arg.Text = @"""" + sgTextBox_file_openfile.Text + @"""";
                    break;
                case "MP3":
                case "WMA":
                    sgTextBox_openfile_name.Text = "播放音乐";
                    sgTextBox_openfile_program.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Windows Media Player\\wmplayer.exe";
                    sgTextBox_openfile_ico.Text = SGFunction.ExtensionOperate.GetExtensionIcon(file);
                    sgTextBox_openfile_arg.Text = @"""" + sgTextBox_file_openfile.Text + @"""";
                    break;
                case "RTF":
                    sgTextBox_openfile_name.Text = "打开文档";
                    sgTextBox_openfile_program.Text = Environment.GetEnvironmentVariable("windir") + "\\system32\\write.exe";
                    sgTextBox_openfile_ico.Text = SGFunction.ExtensionOperate.GetExtensionIcon(file);
                    sgTextBox_openfile_arg.Text = @"""" + sgTextBox_file_openfile.Text + @"""";
                    break;
                case "TXT":
                    sgTextBox_openfile_name.Text = "打开文本";
                    sgTextBox_openfile_program.Text = Environment.GetEnvironmentVariable("windir") + "\\system32\\notepad.exe";
                    sgTextBox_openfile_ico.Text = SGFunction.ExtensionOperate.GetExtensionIcon(file);
                    sgTextBox_openfile_arg.Text = @"""" + sgTextBox_file_openfile.Text + @"""";
                    break;
                case "XLSX":
                case "XLS":
                    sgTextBox_openfile_name.Text = "打开表格";
                    sgTextBox_openfile_program.Text = SGFunction.ProgramInfo.GetExcelPath();
                    sgTextBox_openfile_ico.Text = SGFunction.ExtensionOperate.GetExtensionIcon(file);
                    sgTextBox_openfile_arg.Text = @"""" + sgTextBox_file_openfile.Text + @"""";
                    break;
                case "DOCX":
                case "DOC":
                    sgTextBox_openfile_name.Text = "打开文档";
                    sgTextBox_openfile_program.Text = SGFunction.ProgramInfo.GetWordPath();
                    sgTextBox_openfile_ico.Text = SGFunction.ExtensionOperate.GetExtensionIcon(file);
                    sgTextBox_openfile_arg.Text = @"""" + sgTextBox_file_openfile.Text + @"""";
                    break;
                case "PPTX":
                case "PPT":
                    sgTextBox_openfile_name.Text = "打开PPT";
                    sgTextBox_openfile_program.Text = SGFunction.ProgramInfo.GetPowerPointPath();
                    sgTextBox_openfile_ico.Text = SGFunction.ExtensionOperate.GetExtensionIcon(file);
                    sgTextBox_openfile_arg.Text = @"""" + sgTextBox_file_openfile.Text + @"""";
                    break;
                default:
                    sgTextBox_openfile_name.Text = "打开文件";
                    sgTextBox_openfile_program.Text = Environment.GetEnvironmentVariable("windir") + "\\explorer.exe";
                    sgTextBox_openfile_ico.Text = SGFunction.ExtensionOperate.GetExtensionIcon(file);
                    sgTextBox_openfile_arg.Text = @"""" + sgTextBox_file_openfile.Text + @"""";
                    break;
            }
            if (sgTextBox_openfile_ico.Text != "") { pictureBox2.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(sgTextBox_openfile_ico.Text); }
        }

        private void MyNormalButton5_Click(object sender, EventArgs e)
        {
            //label1.Text = "确认您的操作";
            if(sgRadioButton_file_openfile.Checked ==true)
            {
                //OPEN FILE
                if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sgTextBox_file_openfile.Text)==true)
                {
                    sgTabPageControl_openfile.SelectedIndex = 1;
                    //
                    this.OpenFile_ReadProgram(sgTextBox_file_openfile.Text);
                    label1.Text = "确认您的操作";
                }
                else
                {
                    //NO EXISIS
                    //SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们没有找到您选择的文件。", 2);
                    sgTextBox_file_openfile.DoError("错误，您需要选择一个文件。");
                }
            }
            else
            {
                if(sgRadioButton_file_openfilebyexe.Checked==true)
                {
                    //OPEN EXE
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sgTextBox1.Text) == true && sgTextBox2.Text !="")
                    {
                        sgTabPageControl_openfile.SelectedIndex = 1;
                        if(sgCombobox_programlist.Tag ==null)
                        {
                            sgTextBox_openfile_program.Text = sgTextBox1.Text;
                            sgTextBox_openfile_ico.Text = SGFunction.ExtensionOperate.GetExtensionIcon(sgTextBox2.Text);
                            sgTextBox_openfile_arg.Text = @"""" + sgTextBox2.Text + @"""";
                            sgTextBox_openfile_name.Text = "打开文件";
                            pictureBox2.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(sgTextBox_openfile_ico.Text);
                            label1.Text = "确认您的操作";
                        }
                        else
                        {
                            this.ReadToProgramList();
                            label1.Text = "确认您的操作";
                        }
                    }
                    else
                    {
                        //NO EXISIS
                        //SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们没有找到您选择的文件或者打开的程序。", 2);
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sgTextBox1.Text) == false) { sgTextBox1.DoError("错误，您需要选择一个程序。"); }
                        if (sgTextBox2.Text == "") { sgTextBox2.DoError("错误，您需要选择一个文件。"); }
                    }
                }
                else
                {
                    //FOLDER
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(sgTextBox3.Text,false)==true)
                    {
                        sgTabPageControl_openfile.SelectedIndex = 1;
                        sgTextBox_openfile_program.Text = Environment.GetEnvironmentVariable("windir") + "\\explorer.exe";
                        sgTextBox_openfile_ico.Text = Environment.GetEnvironmentVariable("windir") + "\\system32\\imageres.dll,3";
                        sgTextBox_openfile_arg.Text = sgTextBox3.Text;
                        sgTextBox_openfile_name.Text = "打开文件夹";
                        pictureBox2.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(sgTextBox_openfile_ico.Text);
                        label1.Text = "确认您的操作";
                    }
                    else
                    {
                        //NO EXISIS
                       // SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们没有找到您选择的文件夹。", 2);
                        sgTextBox3.DoError("错误，您需要选择一个文件夹。");
                    }
                }
            }
        }

        private void sgCombobox_programlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string app = "";
            string arg = "";
            string ico = "";
            string name = "";
            switch (sgCombobox_programlist.SelectedIndex)
            {
                case 0:
                    sgCombobox_programlist.Tag = null;
                    break;
                case 1:
                    //PHOTO
                    string photo = SGFunction.CommonDialogs.OpenFileDialog("选择图片", "Image");
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(photo) == true)
                    {
                        app = "%windir%\\system32\\rundll32.exe";
                        arg = @"""%ProgramFiles%\Windows Photo Viewer\PhotoViewer.dll"",ImageView_Fullscreen " + photo;
                        ico = SGFunction.ExtensionOperate.GetExtensionIcon(photo);
                        name = "使用Windows 照片查看器打开";
                    }
                    break;
                case 2:
                    //IMAGE
                    string photo1 = SGFunction.CommonDialogs.OpenFileDialog("选择图片", "Image");
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(photo1) == true)
                    {
                        app = "%windir%\\system32\\mspaint.exe";
                        arg = @"""" + photo1 + @"""";
                        ico = SGFunction.ExtensionOperate.GetExtensionIcon(photo1);
                        name = "使用画图打开";
                    }
                    break;
                case 3:
                    //XIEZIBAN
                    string doc1 = SGFunction.CommonDialogs.OpenFileDialog("选择文档", "支持的格式(*.docx;*.rtf;*.odt;*.txt)|*.docx;*.rtf;*.odt;*.txt|所有文件(*.*)|*.*");
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(doc1) == true)
                    {
                        app = "%windir%\\system32\\write.exe";
                        arg = @"""" + doc1 + @"""";
                        ico = SGFunction.ExtensionOperate.GetExtensionIcon(doc1);
                        name = "使用写字板打开";
                    }
                    break;
                case 4:
                    //JISHIBEN
                    string doc2 = SGFunction.CommonDialogs.OpenFileDialog("选择文档", "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*");
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(doc2) == true)
                    {
                        app = "%windir%\\system32\\notepad.exe";
                        arg = @"""" + doc2 + @"""";
                        ico = SGFunction.ExtensionOperate.GetExtensionIcon(doc2);
                        name = "使用记事本打开";
                    }
                    break;
                case 5:
                    //WORD 
                    string doc3 = SGFunction.CommonDialogs.OpenFileDialog("选择文档", "所有文件(*.*)|*.*");
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(doc3) == true)
                    {
                        app = SGFunction.ProgramInfo.GetWordPath();
                        arg = @"""" + doc3 + @"""";
                        ico = SGFunction.ExtensionOperate.GetExtensionIcon(doc3);
                        if (ico == "%1") { ico = SGFunction.ProgramInfo.GetWordPath() + ",1"; }
                        name = "使用Word打开";
                    }
                    break;
                case 6:
                    //EXCEL
                    string doc4 = SGFunction.CommonDialogs.OpenFileDialog("选择Excel文件", "所有文件(*.*)|*.*");
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(doc4) == true)
                    {
                        app = SGFunction.ProgramInfo.GetExcelPath();
                        arg = @"""" + doc4 + @"""";
                        ico = SGFunction.ExtensionOperate.GetExtensionIcon(doc4);
                        if (ico == "%1") { ico = SGFunction.ProgramInfo.GetExcelPath() + ",1"; }
                        name = "使用Excel打开";
                    }
                    break;
                case 7:
                    //PPT
                    string doc5 = SGFunction.CommonDialogs.OpenFileDialog("选择PowerPoint文件", "所有文件(*.*)|*.*");
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(doc5) == true)
                    {
                        app = SGFunction.ProgramInfo.GetPowerPointPath();
                        arg = @"""" + doc5 + @"""";
                        ico = SGFunction.ExtensionOperate.GetExtensionIcon(doc5);
                        if (ico == "%1") { ico = SGFunction.ProgramInfo.GetPowerPointPath() + ",1"; }
                        name = "使用PowerPoint打开";
                    }
                    break;
            }
           if(sgCombobox_programlist.SelectedIndex  !=0)
           {
               this.sgTextBox1.Text = app;
               sgTextBox2.Text = arg;
               sgCombobox_programlist.Tag = new string[] { app, arg, ico, name };
           }
        }
        private void ReadToProgramList()
        {
            string[] p = (string[])sgCombobox_programlist.Tag;
            sgTextBox_openfile_program.Text = p[0];
            sgTextBox_openfile_arg.Text = p[1];
            sgTextBox_openfile_ico.Text = p[2];
            sgTextBox_openfile_name.Text = p[3];
            pictureBox2.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(sgTextBox_openfile_ico.Text);
        }

        private void MyNormalButton10_Click(object sender, EventArgs e)
        {
           
        }

        private void MyNormalButton11_Click(object sender, EventArgs e)
        {
            if(sgRadioButton1.Checked ==true)
            {
                if (sgTextBox4.Text != "")
                {
                    choosetype = "NET";
                    this.programname = "使用" + SGFunction.ProgramInfo.GetDefaultBrowserName() + "打开网页";
                    this.program = SGFunction.ProgramInfo.GetDefaultBrowserEXE();
                    this.programarg = @"""" + sgTextBox4.Text + @"""";
                    this.programicon = "%windir%\\system32\\ieframe.dll,9";
                    this.buttonclick = "ok";
                    this.Close();
                }
                else { sgTextBox4.DoError("您需要输入一个正确的网址。"); }
            }
            else
            {
                if(sgRadioButton2.Checked ==true)
                {
                    if (sgTextBox4.Text != "")
                    {
                        this.programname = "使用" + SGFunction.ProgramInfo.GetDefaultBrowserName() + "打开网页";
                        this.program = SGFunction.ProgramInfo.GetDefaultBrowserEXE();
                        this.programarg = @"""" + sgTextBox4.Text + @"""";
                        this.programicon = "%windir%\\system32\\ieframe.dll,9";
                    }
                    else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("请您检查要打开的网页是否填好。", 2); }
                }
            }
        }

        private void MyNormalButton6_Click(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sgTextBox_openfile_program.Text) == true && sgTextBox_openfile_name.Text != "")
            {
                choosetype = "FILE";
                this.program = sgTextBox_openfile_program.Text;
                this.programarg = sgTextBox_openfile_arg.Text;
                this.programname = sgTextBox_openfile_name.Text;
                this.programicon = sgTextBox_openfile_ico.Text;
                this.buttonclick = "ok";
                if (sgCheckBox1.Checked == true) { runasadmin = true; }
                this.Close();
            }
            else
            {
                if (sgTextBox_openfile_name.Text == "") { sgTextBox_openfile_name.DoError("错误，您需要输入一个名称。"); }
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sgTextBox_openfile_program.Text)==false) { sgTextBox_openfile_program.DoError("错误，您需要选择一个程序。"); }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void sgRadioButton_network_CheckedChanged(object sender, EventArgs e)
        {
            if(sgRadioButton_network.Checked ==true)
            {
                sgTabPageControl1.SelectedIndex = 2;
                sgRadioButton1.Checked = true;
                label1.Text = "打开网页";
            }
        }

        private void MyNormalButton12_Click(object sender, EventArgs e)
        {
            sgTabPageControl1.SelectedIndex = 0;
        }

        private void MyNormalButton13_Click(object sender, EventArgs e)
        {
            this.sgTabPageControl_openfile.SelectedIndex = 0;
            label1.Text = "如何操作文件？";
        }

        private void MyNormalButton10_Click_1(object sender, EventArgs e)
        {

            if(sgRadioButton3.Checked ==true)
            {
                //GJ
                if(sgCheckBox5.Checked ==false)
                {
                    program = "%windir%\\system32\\shutdown.exe";
                    programarg = @"-s -t 0 -f";
                    if (sgCheckBox3.Checked == true) { programarg = "-s -hybrid -t 0 -f"; }
                    programicon = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "PO");
                    programname = "关闭计算机";
                }
                else
                {
                    program = "%windir%\\system32\\SlideToShutDown.exe";
                    programarg = @"";
                    programicon = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "PO");
                    programname = "滑动关机";
                }
            }
            else
            {
                if(sgRadioButton4.Checked ==true)
                {
                    program = "%windir%\\system32\\shutdown.exe";
                    programarg = @"-r -t 00 -f";
                    programicon = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico","RE");
                    programname = "重启计算机";
                }
                else
                {
                    if (sgRadioButton5.Checked == true)
                    {
                        program = "%windir%\\system32\\rundll32.exe";
                        programarg = @"user32.dll,LockWorkStation";
                        programicon = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "LC");
                        programname = "锁定计算机";
                    }
                    else
                    {
                        if (sgRadioButton6.Checked == true)
                        {
                            program = "%windir%\\system32\\rundll32.exe";
                            programarg = @"powrprof.dll,SetSuspendState";
                            programicon = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("images") + @"\PowerMgrIcons\DKMGR_DeepSleep.ico";
                            programname = "休眠计算机";
                        }
                        else
                        {
                            if (sgRadioButton7.Checked == true)
                            {
                                program = "%windir%\\system32\\rundll32.exe";
                                programarg = @"powrprof.dll,SetSuspendState 0,1,0";
                                programicon = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("images") + @"\PowerMgrIcons\DKMGR_Sleep.ico";
                                programname = "睡眠计算机";
                            }
                            else
                            {
                                if (sgRadioButton7.Checked == true)
                                {
                                    program = "%windir%\\system32\\shutdown.exe";
                                    programarg = @"-l -t 00 -f";
                                    programicon = SGFunction.Resources.GetIconPath("desktopiconsmgr", "powerico", "Lo");
                                    programname = "注销登录";
                                }
                            }
                        }
                    }
                }
            }
            this.choosetype = "POWER";
            this.buttonclick = "ok";
            this.Close();
        }

        private void sgRadioButton_power_CheckedChanged(object sender, EventArgs e)
        {
            if(sgRadioButton_power.Checked ==true)
            {
                sgTabPageControl1.SelectedIndex = 3;
                sgRadioButton3.Checked = true;
                label1.Text = "操作系统的电源";
            }
        }

        private void MyNormalButton14_Click(object sender, EventArgs e)
        {
            sgTabPageControl1.SelectedIndex = 0;
        }

        private void sgRadioButton_system_CheckedChanged(object sender, EventArgs e)
        {
            if(sgRadioButton_system.Checked ==true)
            {
                sgTabPageControl1.SelectedIndex = 4;
                sgRadioButton9.Checked = true;
                label1.Text = "打开系统自带程序";
                this.LoadSystemTool();
            }
        }
        private void LoadSystemTool()
        {
            string sgcf = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\SystemTools.sgcf";
            //判断系统版本
            string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("main", "NT" + SGFunction.SystemFunctionAndInformation.GetOSVersion(), "", sgcf, false);
            string[] mkeys = read.Split('|');
            sgCombobox3.Items.Clear();
            sgCombobox4.Items.Clear();
            sgCombobox3.Items.Add("选择一个类型的系统工具");
            if(mkeys !=null)
            {
                for(int u=1;u<=mkeys.Length;u++)
                {
                    string rn=SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(mkeys[u-1],"mainname","",sgcf,false);
                    sgCombobox3.Items.Add(u.ToString() + ". " + rn);
                    if (u == 1) { sgCombobox3.Tag = mkeys[u - 1]; } else { sgCombobox3.Tag = sgCombobox3.Tag.ToString() + "|" + mkeys[u - 1]; }
                }
                sgCombobox3.SelectedIndex = 0;
            }
        }

        private void sgCombobox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sgcf = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\SystemTools.sgcf";
            string[] arr = null;
            string j = "";
            object obj = sgCombobox3.Tag;
            if (obj != null) { j = obj.ToString(); arr = j.Split('|'); }
            string mkey = "";
            switch(sgCombobox3.SelectedIndex)
            {
                case 0:
                    //mkey = arr[0];
                    sgCombobox4.Enabled = false;
                    break;
                default:
                    mkey = arr[sgCombobox3.SelectedIndex -1];
                    sgCombobox4.Enabled = true;
                    break;
            }
            if(mkey !="")
            {
                sgCombobox4.Items.Clear();
                sgCombobox4.Tag = null;
                //MessageBox.Show(mkey);
                string[] sonkeys;
                string[] sonvalues;
                SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues(mkey, out sonkeys, out sonvalues, sgcf, true);
                if(sonkeys  !=null)
                {
                    for(int p=1;p<=sonkeys.Length ;p++)
                    {
                        string[] res = sonvalues[p - 1].Split('|');
                        if(sonkeys[p-1].ToLower() !="mainname")
                        {
                            string name = res[0];
                            if (name != "") { name = name.Substring(name.IndexOf(",") + 1, name.Length - name.IndexOf(",") - 1); name = SGFunction.PathOperate.ConvertStringToTurePath(name, name); }
                            sgCombobox4.Items.Add(name);
                            if (sgCombobox4.Tag ==null) { sgCombobox4.Tag = sonkeys[p-1]; } else { sgCombobox4.Tag = sgCombobox4.Tag.ToString() + "|" + sonkeys[p - 1]; }
                        }
                    }
                    if (sgCombobox4.Items.Count >= 1) { sgCombobox4.SelectedIndex = 0; }
                }
            }
        }

        private void MyNormalButton15_Click(object sender, EventArgs e)
        {
            this.sgTabPageControl1.SelectedIndex = 0;
        }

        private void MyNormalButton22_Click(object sender, EventArgs e)
        {
            sgTabPageControl2.SelectedIndex = 0;
            label1.Text = "打开系统自带程序";
        }

        private void MyNormalButton17_Click(object sender, EventArgs e)
        {
            string sgcf = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\SystemTools.sgcf";
            if (sgCombobox3.SelectedIndex >= 1)
            {
                if(sgCombobox4.SelectedIndex >=0)
                {
                    //获取regname
                    object obj = sgCombobox4.Tag;
                    object obj1 = sgCombobox3.Tag;
                    if (obj != null && obj1 !=null)
                    {
                        string[] op = obj.ToString().Split('|');
                        string[] op1 = obj1.ToString().Split('|');
                        string rn = op[sgCombobox4.SelectedIndex];
                        string ma = op1[sgCombobox3.SelectedIndex-1];
                        //MessageBox.Show(ma+"\r\n"+rn);
                        string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(ma, rn, "", sgcf, false);
                        string[] res=read.Split('|');
                        if (res.Length >= 3)
                        {
                            string r_name = res[0];
                            string r_exe = res[1];
                            string r_ico = res[2];
                            string r_arg = "";
                            if (res.Length > 3) { r_arg = res[3]; }
                            sgCheckBox2.Checked = false;
                            if (r_name != "")
                            {
                                string ui = r_name.Substring(0, r_name.IndexOf(",")).ToUpper();
                                if (ui == "AD") { sgCheckBox2.Checked = true; }
                                r_name = r_name.Substring(r_name.IndexOf(",") + 1, r_name.Length - r_name.IndexOf(",") - 1); r_name = SGFunction.PathOperate.ConvertStringToTurePath(r_name, r_name);
                            }
                            label1.Text = "确认您的操作";
                            sgTextBox10.Text = r_name;
                            sgTextBox13.Text = r_exe;
                            sgTextBox11.Text = r_arg;
                            sgTextBox12.Text = r_ico;
                            sgTabPageControl2.SelectedIndex = 1;
                            pictureBox1.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(r_ico);
                        }
                    }
                    else { this.Close(); }
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("您好像没有选择一个程序哦。", 2); }
            }
            else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("您好像没有选择一个程序哦。", 2); }
        }

        private void MyNormalButton9_Click(object sender, EventArgs e)
        {
            string res;
            string ico = SGFunction.CommonDialogs.SelectIconDialog("选择图标", sgTextBox_openfile_ico.Text, out res);
            if(res=="ok" && ico !="")
            {
                sgTextBox_openfile_ico.Text = ico;
                pictureBox2.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico);
            }
        }

        private void MyNormalButton23_Click(object sender, EventArgs e)
        {
            string res;
            string ico = SGFunction.CommonDialogs.SelectIconDialog("选择图标", sgTextBox12.Text, out res);
            if (res == "ok" && ico != "")
            {
                sgTextBox12.Text = ico;
                pictureBox1.Image = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico);
            }
        }

        private void MyNormalButton18_Click(object sender, EventArgs e)
        {
            string app = sgTextBox13.Text;
            string arg = sgTextBox11.Text;
            arg = SGFunction.PathOperate.ConvertStringToTurePath(arg, arg);
            SGFunction.SystemFunctionAndInformation.ShellPrograms(app, arg, false, true, sgCheckBox2.Checked, false);
        }

        private void MyNormalButton19_Click(object sender, EventArgs e)
        {
            string app = sgTextBox_openfile_program.Text;
            string arg = sgTextBox_openfile_arg.Text;
            arg = SGFunction.PathOperate.ConvertStringToTurePath(arg, arg);
            SGFunction.SystemFunctionAndInformation.ShellPrograms(app, arg, false, true, sgCheckBox1.Checked, false);
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            switch (frmtype)
            {
                case "ADDRM":
                    this.buttonclick = adddefaultmenu;
                    this.Close();
                    break;
                default:
                    this.buttonclick = "exit";
                    this.Close();
                    break;
            }
        }

        private void SGForm_MoreFunctions_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.sgTabPageControl1.Location.X+ sgTabPageControl1.Size.Width + 2, sgTabPageControl1.Size.Height + sgTabPageControl1.Location.Y + 2);
            this.panel1.Size = new Size(this.Size.Width, panel1.Size.Height);
            this.MyNormalButton1.Location = new Point(panel1.Size.Width - MyNormalButton1.Size.Width, 0);
            panel3.Size = new Size(this.Width -4, panel3.Size.Height);
        }
        private void MyNormalButton24_Click(object sender, EventArgs e)
        {
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sgTextBox13.Text) == true && sgTextBox10.Text != "")
            {
                this.programname = sgTextBox10.Text;
                this.program = sgTextBox13.Text;
                this.programicon = sgTextBox12.Text;
                this.programarg = sgTextBox11.Text;
                this.buttonclick = "ok";
                this.runasadmin = sgCheckBox2.Checked;
                this.choosetype = "SYS";
                this.Close();
            }
            else
            {
                if (sgTextBox10.Text == "") { sgTextBox10.DoError("错误，您需要输入一个名称。"); }
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(sgTextBox13.Text) == false) { sgTextBox13.DoError("错误，您需要选择一个程序。"); }
            }

        }

        private void sgTextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void SGForm_MoreFunctions_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }

        private void sgTabPageControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sgTabPageControl1.SelectedIndex ==0)
            {
                label1.Text = tiptext;
            }
            else
            {
            }
        }
       

        private void sgCombobox_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (sgCombobox_main.SelectedIndex)
                {
                    case 0:
                        this.LOADSGFUNCTIONS_MAINFRM();
                        break;
                    case 1:
                        this.LOADSGFUNCTIONS_STYLETOOL();
                        break;
                    case 2:
                        this.LOADSGFUNCTIONS_SYSTEMTOOL();
                        break;
                    case 3:
                        this.LOADSGFUNCTIONS_ADVTOOL();
                        break;
                    case 4:
                        this.LOADSGFUNCTIONS_SGTOOLS();
                        break;
                }
            }
            catch { }
        }

        private void sgCombobox_m_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(sgCombobox_m.SelectedIndex >=0)
                {
                    object obj = sgCombobox_m.Tag;
                    if (obj != null)
                    {
                        string[] arr = (string[])obj;
                        string arg = arr[sgCombobox_m.SelectedIndex];
                        string[] rs = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, false, false);
                        string info = rs[1]; 
                        info=SGFunction.PathOperate.ConvertStringToTurePath(info, info);
                        label22.Text = info;
                        choosesgfunction = rs;
                    }
                }
            }
            catch { }
        }


        private void MyNormalButton20_Click(object sender, EventArgs e)
        {
            this.buttonclick = "ok";
            this.Close();
        }
        void LoadDefaultRightMenu()
        {
            try
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\MoreFunction_Special.SGCF";
                string[] keys, values;
                SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("RIGHTMENU_ADD", out keys, out values, cfg, true);
                if (keys != null)
                {
                    for (int o = 1; o <= keys.Length; o++)
                    {
                        if(values[o-1] !=null)
                        {
                            string[] args = values[o - 1].Split('|');
                            if (args != null)
                            {
                                if (args.Length == 8)
                                {
                                    string name = args[0]; name = SGFunction.PathOperate.ConvertStringToTurePath(name, name);
                                    sgCombobox_dfmenu.Items.Add(name);
                                    dfmenu_addvalue.Add(values[o - 1]);
                                }
                            }
                        }
                    }
                    //START SCREEN
                    if(SGFunction.SystemFunctionAndInformation.GetOSVersion() =="6.1")
                    {
                        sgRightMenus1.Items[0].Enabled = false;
                        //string regfile = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("ADD_PINTOSTARTSCREEN", "nt" + SGFunction.SystemFunctionAndInformation.GetOSVersion(), "", cfg, true);
                        //if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(regfile) == true) { sgCombobox_dfmenu.Items.Add(@"固定到""开始""屏幕"); dfmenu_addvalue.Add(regfile); }
                    }
                    if (sgCombobox_dfmenu.Items.Count > 0) { sgCombobox_dfmenu_addtagrget.Enabled = true; sgCombobox_dfmenu.SelectedIndex = 0; }
                }
            }
            catch { sgCombobox_dfmenu.Items.Clear(); }
        }
        void LoadSelectRightMenu(int selectindex)
        {
            //string[] adds_full = new string[] {"所有文件右键","所有文件夹右键","所有文件对象右键","桌面右键","驱动器右键" };
            List<string> wanttoadd = new List<string>();
            string value = dfmenu_addvalue[selectindex];
            if(value !="")
            {
                string[] args = value.Split('|');
                if(args.Length ==8)
                {
                    string addfolder = args[2];
                    if(addfolder !="")
                    {
                        sgCombobox_dfmenu_addtagrget.Items.Clear();
                        string[] adds = addfolder.Split(',');
                        for(int u=1;u<=adds.Length;u++)
                        {
                            switch (adds[u - 1].ToUpper())
                            {
                                case "ALL":
                                    wanttoadd.Add("所有文件、文件夹和图标右键");
                                    break;
                                case "FOLDER":
                                    wanttoadd.Add("所有文件夹右键");
                                    break;
                                case "FILESYSTEM":
                                    wanttoadd.Add("所有文件对象右键");
                                    break;
                                case "DESKTOP":
                                    wanttoadd.Add("桌面右键");
                                    break;
                                case "DRIVE":
                                    wanttoadd.Add("磁盘分区右键");
                                    break;
                                default:
                                    if (adds[u - 1] != "")
                                    {
                                        wanttoadd.Add(adds[u-1].ToUpper()+"文件");
                                    }
                                    break;
                            }
                        }
                        string[] arr = wanttoadd.ToArray();
                        foreach(string op in arr)
                        {
                            sgCombobox_dfmenu_addtagrget.Items.Add(op);
                        }
                        if (sgCombobox_dfmenu_addtagrget.Items.Count >= 1) { sgCombobox_dfmenu_addtagrget.SelectedIndex = 0; }
                        //判断RUNASADMIN
                        string shelltype = args[7];
                        sgCheckBox4.Enabled = true;
                        if (shelltype.ToUpper() == "SHELLEX") 
                        { 
                            sgCheckBox4.Checked = false; sgCheckBox4.Enabled = false; 
                        }
                        else
                        {
                            string runas = args[6].ToUpper(); if (runas == "TRUE") { sgCheckBox4.Checked = true; }
                        }

                    }
                }
                else
                { 
                    //MAY BE REG
                    if(args.Length ==1)
                    {
                        string names = args[0];
                        if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(names)==true)
                        {
                            string exts = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(names).ToUpper();
                            switch(exts)
                            {
                                case "REG":
                                    sgCombobox_dfmenu_addtagrget.Items.Clear(); sgCombobox_dfmenu_addtagrget.Items.Add("由导入的注册表文件决定"); sgCombobox_dfmenu_addtagrget.SelectedIndex =0;sgCheckBox4.Enabled =false;sgCheckBox4.Checked =false;
                                    break;
                            }
                        }
                    }
                }
            }
        }
        void AddDefaultMenuToSystem(int selectmune,string target)
        {
            string readstr = dfmenu_addvalue[selectmune];
            string[] args = readstr.Split('|');
            if (args.Length != 8) { return; }
            //格式 名称|REGNAME|SUPPORT|EXE/CLSID|ARG|图标|是否以管理员BOOL|SHELL/SHELLEX 8格式 名称|REGNAME|SUPPORT|EXE/CLSID|ARG|图标|是否以管理员BOOL|SHELL/SHELLEX 8格式 名称|REGNAME|SUPPORT|EXE/CLSID|ARG|图标|是否以管理员BOOL|SHELL/SHELLEX 8
            //桌面
            string REG_DK_SHELL = @"DesktopBackground\Shell"; //HKCR
            string REG_DK_SHELLEX= @"DesktopBackground\shellex\ContextMenuHandlers"; //HKCR
            string REG_ALL_SHELL = @"*\shell";//HKCR
            string REG_ALL_SHELLEX = @"*\shellex\ContextMenuHandlers"; //HKCR
            string REG_FOLDER_SHELL = @"SOFTWARE\Classes\Folder\shell"; //hklm
            string REG_FOLDER_SHELLEX = @"SOFTWARE\Classes\Folder\shellex\ContextMenuHandlers";//HKLM
            string REG_FOLDER_BACK_SHELL = @"Directory\background\shell"; //HKCR
            string REG_FOLDER_BACK_SHELLEX = @"Directory\background\shellex\ContextMenuHandlers"; //HKCR
            string REG_FS_SHELL = @"SOFTWARE\Classes\AllFilesystemObjects\shell";//HKLM
            string REG_FS_SHELLEX = @"SOFTWARE\Classes\AllFilesystemObjects\shellex\ContextMenuHandlers";
            string REG_DRIVE_SHELL = @"SOFTWARE\Classes\Drive\shell";//hklm
            string REG_DRIVE_SHELLEX = @"SOFTWARE\Classes\Drive\shellex\ContextMenuHandlers";
            string regname = ""; string displayname = ""; string exeorclsid = ""; string arg = ""; string ico = ""; string runas = ""; string writetype = "";
            string runasvbs = SGFunction.Resources.GetResourcePath("RUNASADMINVBS");
            regname = args[1];
            displayname = args[0];
            exeorclsid = args[3];
            arg = args[4];
            ico = args[5];
            runas = args[6];
            writetype = args[7];
            runas = sgCheckBox4.Checked.ToString().ToUpper();
            displayname = SGFunction.PathOperate.ConvertStringToTurePath(displayname, displayname);
            ico = SGFunction.PathOperate.ConvertStringToTurePath(ico, ico);
            exeorclsid = SGFunction.PathOperate.ConvertStringToTurePath(exeorclsid, exeorclsid);
            SGFunction.ScriptOperate.CreateRunAsAdminVBS();
            string target_location = ""; RegistryKey target_reg = Registry.ClassesRoot;
            switch(target)
            {
                case "所有文件、文件夹和图标右键"://ALL
                    if (writetype.ToUpper() == "SHELL")
                    {
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, REG_ALL_SHELL, regname); SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, REG_ALL_SHELL + "\\" + regname, "Command");
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, REG_ALL_SHELL + "\\" + regname, "", displayname);
                        if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, REG_ALL_SHELL + "\\" + regname, "icon", ico, RegistryValueKind.ExpandString); }
                        string writeshell = exeorclsid + " " + arg;
                        if (runas.ToUpper() == "TRUE") { writeshell = @"%windir%\system32\wscript.exe """ + runasvbs + @""" " + exeorclsid + " " + arg; }
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, REG_ALL_SHELL + "\\" + regname + "\\command", "", writeshell,RegistryValueKind.ExpandString);
                    }
                    else
                    {
                        if (writetype.ToUpper() == "SHELLEX")
                        {
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, REG_ALL_SHELLEX, regname);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, REG_ALL_SHELLEX + "\\" + regname, "", exeorclsid);
                        }
                    }
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加了右键菜单",2);
                    adddefaultmenu = "ok";
                    break;
                case "所有文件夹右键"://FOLDER
                    if (writetype.ToUpper() == "SHELL")
                    {
                        target_location = REG_FOLDER_SHELL; target_reg = Registry.LocalMachine;
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location, regname); SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location+ "\\" + regname, "Command");
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg , target_location + "\\" + regname, "", displayname);
                        if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg , target_location + "\\" + regname, "icon", ico, RegistryValueKind.ExpandString); }
                        string writeshell = exeorclsid + " " + arg;
                        if (runas.ToUpper() == "TRUE") { writeshell = @"%windir%\system32\wscript.exe """ + runasvbs + @""" " + exeorclsid + " " + arg; }
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location+ "\\" + regname + "\\command", "", writeshell,RegistryValueKind.ExpandString);
                        //BG
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, REG_FOLDER_BACK_SHELL, regname); SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, REG_FOLDER_BACK_SHELL + "\\" + regname, "Command");
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE",Registry.ClassesRoot, REG_FOLDER_BACK_SHELL + "\\" + regname, "", displayname);
                        if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, REG_FOLDER_BACK_SHELL + "\\" + regname, "icon", ico, RegistryValueKind.ExpandString); }
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, REG_FOLDER_BACK_SHELL + "\\" + regname + "\\command", "", writeshell, RegistryValueKind.ExpandString);
                    }
                    else
                    {
                        if (writetype.ToUpper() == "SHELLEX")
                        {
                            target_location = REG_FOLDER_SHELLEX; target_reg = Registry.LocalMachine;
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location , regname);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "", exeorclsid);
                            //back
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, REG_FOLDER_BACK_SHELLEX, regname);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", Registry.ClassesRoot, REG_FOLDER_BACK_SHELLEX + "\\" + regname, "", exeorclsid);
                        }
                    }
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加了右键菜单", 2);
                    adddefaultmenu = "ok";
                    break;
                case "所有文件对象右键"://fs
                    if (writetype.ToUpper() == "SHELL")
                    {
                        target_location = REG_FS_SHELL; target_reg = Registry.LocalMachine;
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location, regname); SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location + "\\" + regname, "Command");
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "", displayname);
                        if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "icon", ico, RegistryValueKind.ExpandString); }
                        string writeshell = exeorclsid + " " + arg;
                        if (runas.ToUpper() == "TRUE") { writeshell = @"%windir%\system32\wscript.exe """ + runasvbs + @""" " + exeorclsid + " " + arg; }
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname + "\\command", "", writeshell,RegistryValueKind.ExpandString);
                    }
                    else
                    {
                        if (writetype.ToUpper() == "SHELLEX")
                        {
                            target_location = REG_FS_SHELLEX; target_reg = Registry.LocalMachine;
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location, regname);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "", exeorclsid);
                        }
                    }
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加了右键菜单", 2);
                    adddefaultmenu = "ok";
                    break;
                case "桌面右键"://desktop
                    if (writetype.ToUpper() == "SHELL")
                    {
                        target_location = REG_DK_SHELL; target_reg = Registry.ClassesRoot;
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location, regname); SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location + "\\" + regname, "Command");
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "", displayname);
                        if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "icon", ico, RegistryValueKind.ExpandString); }
                        string writeshell = exeorclsid + " " + arg;
                        if (runas.ToUpper() == "TRUE") { writeshell = @"%windir%\system32\wscript.exe """ + runasvbs + @""" " + exeorclsid + " " + arg; }
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname + "\\command", "", writeshell,RegistryValueKind.ExpandString );
                    }
                    else
                    {
                        if (writetype.ToUpper() == "SHELLEX")
                        {
                            target_location = REG_DK_SHELLEX; target_reg = Registry.ClassesRoot;
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location, regname);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "", exeorclsid);
                        }
                    }
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加了右键菜单", 2);
                    adddefaultmenu = "ok";
                    break;
                case "磁盘分区右键"://drive
                    if (writetype.ToUpper() == "SHELL")
                    {
                        target_location = REG_DRIVE_SHELL; target_reg = Registry.LocalMachine;
                        SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location, regname); SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location + "\\" + regname, "Command");
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "", displayname);
                        if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "icon", ico, RegistryValueKind.ExpandString); }
                        string writeshell = exeorclsid + " " + arg;
                        if (runas.ToUpper() == "TRUE") { writeshell = @"%windir%\system32\wscript.exe """ + runasvbs + @""" " + exeorclsid + " " + arg; }
                        SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname + "\\command", "", writeshell,RegistryValueKind.ExpandString);
                    }
                    else
                    {
                        if (writetype.ToUpper() == "SHELLEX")
                        {
                            target_location = REG_DRIVE_SHELLEX; target_reg = Registry.LocalMachine;
                            SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location, regname);
                            SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "", exeorclsid);
                        }
                    }
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加了右键菜单", 2);
                    adddefaultmenu = "ok";
                    break;
                default: //file
                    if (target != "")
                    {
                        string exts = target.Substring(0, target.LastIndexOf("文"));
                        if(exts !="")
                        {
                            string regextsub = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.ClassesRoot, "." + exts, "", "noreg");
                            if(regextsub =="noreg")
                            {
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, "", "." + exts);
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, exts +"file", "shell");
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, exts + "file", "shellex");
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, exts + @"file\shellex", "ContextMenuHandlers");
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, "." + exts, "", exts + "file");
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("write", Registry.ClassesRoot, exts + "file", "", exts + "文件");
                                regextsub = exts + "file";
                            }
                            //REGS
                            if (writetype.ToUpper() == "SHELL")
                            {
                                target_location = regextsub +@"\shell"; target_reg = Registry.ClassesRoot;
                                SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location, regname); SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location + "\\" + regname, "Command");
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "", displayname);
                                if (ico != "") { SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "icon", ico, RegistryValueKind.ExpandString); }
                                string writeshell = exeorclsid + " " + arg;
                                if (runas.ToUpper() == "TRUE") { writeshell = @"%windir%\system32\wscript.exe """ + runasvbs + @""" " + exeorclsid + " " + arg; }
                                SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname + "\\command", "", writeshell,RegistryValueKind.ExpandString);
                            }
                            else
                            {
                                if (writetype.ToUpper() == "SHELLEX")
                                {
                                    target_location = regextsub + @"\shellex\ContextMenuHandlers"; target_reg = Registry.ClassesRoot;
                                    SGFunction.RegistryOperate.RegistryOperate_CreateSubKey(target_reg, target_location, regname);
                                    SGFunction.RegistryOperate.RegistryOperate_ValueOperate("WRITE", target_reg, target_location + "\\" + regname, "", exeorclsid);
                                }
                            }
                            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功添加了右键菜单", 2);
                            adddefaultmenu = "ok";
                        }
                    }
                    break;
            }
        }

        private void sgCombobox_dfmenu_addtagrget_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sgCombobox_dfmenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sgCombobox_dfmenu.SelectedIndex >=0)
            {
                LoadSelectRightMenu(sgCombobox_dfmenu.SelectedIndex);
            }
        }

        private void MyNormalButton21_Click(object sender, EventArgs e)
        {
            if(sgCombobox_dfmenu.SelectedIndex >=0 && sgCombobox_dfmenu_addtagrget.SelectedIndex >=0)
            {
                AddDefaultMenuToSystem(sgCombobox_dfmenu.SelectedIndex, sgCombobox_dfmenu_addtagrget.Items[sgCombobox_dfmenu_addtagrget.SelectedIndex].ToString());
            }
        }

        private void 所有文件支持固定到开始屏幕ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\MoreFunction_Special.SGCF";
            string regfile = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("ADD_PINTOSTARTSCREEN", "nt" + SGFunction.SystemFunctionAndInformation.GetOSVersion(), "", cfg, true);
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(regfile) == true) 
            {
                SGFunction.RegistryOperate.RegistryOperate_ImportFile(regfile);
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("添加菜单成功",2);
            }
        }

        private void MyNormalButton86_Click(object sender, EventArgs e)
        {
           sgRightMenus1.Show(MyNormalButton86, new Point(0, MyNormalButton86.Size.Height + 5));
        }

        private void 添加电源头管理组ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePowerMgr();
        }
        void CreatePowerMgr()
        {
            string cfgdir = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups";
            SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(cfgdir);
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\RightMenuGroups\\RightMenuGroup_powermgr.sgcf";
            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg )==false)
            {
                SGFunction.DataOperate.SaveStringToTextFile(cfg, SystemGear.Properties.Resources.RightMenuGroup_powermgr);
            }
            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg)==true)
            {
                string cmd = @"%windir%\system32\shutdown.exe -s -t 0 -f";
                if (SGFunction.SystemFunctionAndInformation.GetOSVersion() != "6.1") { cmd = @"%windir%\system32\shutdown.exe -s -hybrid -t 0 -f"; }
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("command3", "command", cmd, "RightMenuGroup", false, cfg);
                SGSystemStyle.RightMenuMgr.RightMenuGroup.CreateRightMenuGroup(cfg);
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("添加电源管理组成功", 2);
            }
        }

        private void 添加清空回收站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\MoreFunction_Special.SGCF";
            string regfile = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("ADD_emptyrb", "nt" + SGFunction.SystemFunctionAndInformation.GetOSVersion(), "", cfg, true);
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(regfile) == true)
            {
                SGFunction.RegistryOperate.RegistryOperate_ImportFile(regfile);
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("添加菜单成功", 2);
            }
        }
        private void LOADSGFUNCTIONS_STYLETOOL()
        {
            try
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\SGFunctionsClassify.SGCF";
                string[] styletool_h; string[] styletool_value;
                SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("Belong_Style", out styletool_h, out styletool_value, cfg, true);
                sgCombobox_m.Items.Clear();
                List<string> list = new List<string>();
                for (int u = 1; u <= styletool_h.Length; u++)
                {
                    string arg = styletool_value[u - 1];
                    string[] rs = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, true, false);
                    string name = rs[0];
                    sgCombobox_m.Items.Add(name);
                    list.Add(arg);
                }
                sgCombobox_m.Tag = list.ToArray();
                if (sgCombobox_m.Items.Count > 0) { sgCombobox_m.SelectedIndex = 0; }
            }
            catch { }
        }
        private void LOADSGFUNCTIONS_SYSTEMTOOL()
        {
            try
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\SGFunctionsClassify.SGCF";
                string[] styletool_h; string[] styletool_value;
                SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("Belong_SYSTEMTOOL", out styletool_h, out styletool_value, cfg, true);
                sgCombobox_m.Items.Clear();
                List<string> list = new List<string>();
                for (int u = 1; u <= styletool_h.Length; u++)
                {
                    string arg = styletool_value[u - 1];
                    string[] rs = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, true, false);
                    string name = rs[0];
                    sgCombobox_m.Items.Add(name);
                    list.Add(arg);
                }
                sgCombobox_m.Tag = list.ToArray();
                if (sgCombobox_m.Items.Count > 0) { sgCombobox_m.SelectedIndex = 0; }
            }
            catch { }
        }
        private void LOADSGFUNCTIONS_ADVTOOL()
        {
            try
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\SGFunctionsClassify.SGCF";
                string[] styletool_h; string[] styletool_value;
                SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("Belong_ADV", out styletool_h, out styletool_value, cfg, true);
                sgCombobox_m.Items.Clear();
                List<string> list = new List<string>();
                for (int u = 1; u <= styletool_h.Length; u++)
                {
                    string arg = styletool_value[u - 1];
                    string[] rs = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, true, false);
                    string name = rs[0];
                    sgCombobox_m.Items.Add(name);
                    list.Add(arg);
                }
                sgCombobox_m.Tag = list.ToArray();
                if (sgCombobox_m.Items.Count > 0) { sgCombobox_m.SelectedIndex = 0; }
            }
            catch { }
        }
        private void LOADSGFUNCTIONS_MAINFRM()
        {
            try
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\SGFunctionsClassify.SGCF";
                string[] styletool_h; string[] styletool_value;
                SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("Belong_MAIN", out styletool_h, out styletool_value, cfg, true);
                sgCombobox_m.Items.Clear();
                List<string> list = new List<string>();
                for (int u = 1; u <= styletool_h.Length; u++)
                {
                    string arg = styletool_value[u - 1];
                    string[] rs = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, true, false);
                    string name = rs[0];
                    sgCombobox_m.Items.Add(name);
                    list.Add(arg);
                }
                sgCombobox_m.Tag = list.ToArray();
                if (sgCombobox_m.Items.Count > 0) { sgCombobox_m.SelectedIndex = 0; }
            }
            catch { }
        }
        private void LOADSGFUNCTIONS_SGTOOLS()
        {
            try
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\SGFunctionsClassify.SGCF";
                string[] styletool_h; string[] styletool_value;
                SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("Belong_SGTOOLS", out styletool_h, out styletool_value, cfg, true);
                sgCombobox_m.Items.Clear();
                List<string> list = new List<string>();
                for (int u = 1; u <= styletool_h.Length; u++)
                {
                    string arg = styletool_value[u - 1];
                    string[] rs = SGFunction.ApplicationSetting.GetSGFunctionInfo(arg, true, false);
                    string name = rs[0];
                    sgCombobox_m.Items.Add(name);
                    list.Add(arg);
                }
                sgCombobox_m.Tag = list.ToArray();
                if (sgCombobox_m.Items.Count > 0) { sgCombobox_m.SelectedIndex = 0; }
            }
            catch { }
        }

        private void sgCheckBox5_OnCheckedChange(object sender, SGCheckBox.MyEventArgs e)
        {
            if(sgCheckBox5.Checked ==true)
            {
                sgCheckBox3.Enabled = false;
            }
            else
            {
                sgCheckBox3.Enabled = true;
            }
        }
    }
}
