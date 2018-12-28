using System.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using SystemGear;


namespace SystemGear
{
    class Class_FormMain
    {
        public static void Main_Enter(int FirstFunctionIndex, int SecondFunctionIndex, Form_Main frm)
        {
            Thread P_thread = new Thread(
                () => //lambda表达式（参数列表）=>{执行语句}  lambda表达式是比匿名方法更加简洁的一种匿名函数语法
                {
                    frm.Invoke(new MethodInvoker(delegate()
                    {
                        try
                        {
                            frm.myNormalButton1.ButtonBackColor = frm.myNormalButton2.ButtonBackColor = frm.myNormalButton3.ButtonBackColor = frm.myNormalButton4.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
                            frm.myNormalButton1.ButtonForceColor = frm.myNormalButton2.ButtonForceColor = frm.myNormalButton3.ButtonForceColor = frm.myNormalButton4.ButtonForceColor = Color.White;
                            frm.myNormalButton1.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "m01", true);
                            frm.myNormalButton2.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "m02", true);
                            frm.myNormalButton3.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "m03", true);
                            frm.myNormalButton4.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "m04", true);
                            frm.tabControl1.SelectedIndex = FirstFunctionIndex - 1;
                            switch (FirstFunctionIndex)
                            {
                                case 4:
                                    frm.ChooseFunction_CommandLine = "/M=04,01";
                                    frm.ChooseFunction_Icon_Ico = @"M04";
                                    frm.ChooseFunction_Icon_Logo = "M04";
                                    frm.ChooseFunction_Info = "系统齿轮的有关信息";
                                    frm.ChooseFunction_Name = frm.myNormalButton4.ButtonText;
                                    //frm.button4.BackColor = Color.White;
                                    frm.label8.Text = Application.ProductVersion;
                                    frm.label7.Text = "系统齿轮 V" + Application.ProductVersion.Substring(0, 3) + " 正式版";
                                    //frm.button4.Image = Properties.Resources.M04_Choose;
                                    frm.myNormalButton4.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetForceColor();
                                    frm.myNormalButton4.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                                    frm.myNormalButton4.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "m04", false);
                                    break;
                                case 2:
                                    frm.myNormalButton2.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetForceColor();
                                    frm.myNormalButton2.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                                    frm.myNormalButton2.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "m02", false);
                                    frm.ChooseFunction_CommandLine = "/M=02,01";
                                    frm.ChooseFunction_Icon_Ico = "M02";
                                    frm.ChooseFunction_Icon_Logo = "M02";
                                    frm.ChooseFunction_Info = "系统齿轮的所有的设置";
                                    frm.ChooseFunction_Name = frm.myNormalButton2.ButtonText;
                                    break;
                                case 3:
                                    frm.myNormalButton3.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetForceColor();
                                    frm.myNormalButton3.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                                    frm.myNormalButton3.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "m03", false);
                                    frm.textBox1.Text = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_StartCommand();
                                    frm.ChooseFunction_CommandLine = "/M=03,01";
                                    frm.ChooseFunction_Icon_Ico = "M03";
                                    frm.ChooseFunction_Icon_Logo = "M03";
                                    frm.ChooseFunction_Info = "系统齿轮的设置";
                                    frm.ChooseFunction_Name = frm.myNormalButton3.ButtonText;

                                    if (MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("mainsettings", "MinBoxChoose", "TaskBar", false, Application.StartupPath + @"\Config\MainProgram.sgcf").ToUpper() == "TASKBAR")
                                    {
                                        frm.radioButton1.Checked = true;
                                    }
                                    else
                                    {
                                        frm.radioButton2.Checked = true;
                                    }
                                    if (MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_ClickCloseBoxToOperate().ToUpper() == "CLOSE")
                                    {
                                        frm.radioButton4.Checked = true;
                                    }
                                    else
                                    {
                                        if (MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_ClickCloseBoxToOperate().ToUpper() == "HIDE")
                                        {
                                            frm.radioButton3.Checked = true;
                                        }
                                    }
                                    break;
                                default:
                                    frm.myNormalButton1.ButtonBackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetForceColor();
                                    frm.myNormalButton1.ButtonForceColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                                    frm.myNormalButton1.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.MainForm, "m01", false);
                                    frm.label2.ForeColor = frm.label3.ForeColor = Color.Black;
                                    switch (SecondFunctionIndex)
                                    {
                                        case 2:
                                            frm.MainPanel_Choose = "TOOLS";
                                            frm.label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                                            frm.label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                                            frm.label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                                            frm.flowLayoutPanel2.Visible = true;
                                            frm.flowLayoutPanel2.Location = new Point(8, 27);
                                            frm.flowLayoutPanel2.Size = new Size(671, 413);
                                            frm.flowLayoutPanel_usepings.Visible = false;
                                            frm.flowLayoutPanel1.Visible = false;
                                            frm.ChooseFunction_CommandLine = "/M=01,02";
                                            Main_LoadUserPing(frm);
                                            frm.ChooseFunction_Icon_Ico = "M01";
                                            frm.ChooseFunction_Icon_Logo = "M01";
                                            frm.ChooseFunction_Info = "系统齿轮所有的实用工具";
                                            frm.ChooseFunction_Name = "所有工具";
                                            break;
                                        case 3:
                                            frm.MainPanel_Choose = "USERPING";
                                            frm.label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                                            frm.label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                                            frm.label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                                            frm.flowLayoutPanel1.Visible = false;
                                            frm.flowLayoutPanel2.Visible = false;
                                            frm.flowLayoutPanel_usepings.Location = new Point(8, 27);
                                            frm.flowLayoutPanel_usepings.Size = new Size(671, 413);
                                            frm.flowLayoutPanel_usepings.Visible = true;
                                            frm.ChooseFunction_CommandLine = "/M=01,03";
                                            Main_LoadUserPing(frm);
                                            frm.ChooseFunction_Icon_Ico = "M01";
                                            frm.ChooseFunction_Icon_Logo = "M01";
                                            frm.ChooseFunction_Info = "系统齿轮用户自定义固定的选项";
                                            frm.ChooseFunction_Name = "用户自定义";
                                            break;
                                        default:
                                            frm.MainPanel_Choose = "SG";
                                            frm.label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Choose();
                                            frm.label23.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                                            frm.label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetM01TitleColor_Normal();
                                            /*
                                                UserControl_FormMain_SGPrograms sg = new UserControl_FormMain_SGPrograms();
                                                frm.tabPage1.Controls.Add(sg);
                                                sg.MouseDown += new MouseEventHandler(frm.Form_Main_MouseDown);
                                                sg.flowLayoutPanel1.MouseDown += new MouseEventHandler(frm.Form_Main_MouseDown);
                                                sg.Location = new Point(8, 27);
                                             * */
                                            frm.flowLayoutPanel1.Visible = true;
                                            frm.flowLayoutPanel1.Location = new Point(8, 27);
                                            frm.flowLayoutPanel1.Size = new Size(671, 413);
                                            frm.flowLayoutPanel_usepings.Visible = false;
                                            frm.flowLayoutPanel2.Visible = false;
                                            frm.ChooseFunction_CommandLine = "/M=01,01";
                                            frm.ChooseFunction_Icon_Ico = "M01";
                                            frm.ChooseFunction_Icon_Logo = "M01";
                                            frm.ChooseFunction_Info = "系统齿轮推荐的设置";
                                            frm.ChooseFunction_Name = "系统齿轮推荐";

                                            break;
                                    }
                                    break;
                            }
                            Main_SetSettings(frm);
                        }
                        catch
                        {
                        }
                    }));
                });//new thread
            P_thread.IsBackground = true;
            P_thread.Start();
            
        }
        public static void Main_GetCommandArgs(Form_Main frm)
        {
            frm.Hide();
            Point loc = frm.Location;
            string FullCommandArgs = "";
            try
            {
                if (frm.CommandArgs.Length > 0)
                {
                    switch (frm.CommandArgs[0].ToString().Substring(0, 2).Replace("-", "").Replace("/", "").Replace(@"\", "").Replace(" ", "").ToUpper())
                    {
                        case "M"://用于进入主界面
                            frm.Show();
                            if (frm.CommandArgs[0].Substring(3, frm.CommandArgs[0].Length - 3).Length != 8)
                            {
                                string SETPONE = frm.CommandArgs[0].Substring(3, frm.CommandArgs[0].Length - 3);
                                int first = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(SETPONE.Substring(0, 2), 1);
                                int second = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(SETPONE.Substring(3, 2), 1);
                                //MessageBox.Show(first.ToString() + "\r\n" + second.ToString());
                                Class_FormMain.Main_Enter(first, second, frm);
                            }
                            else
                            {
                                for (int h = 1; h <= frm.CommandArgs.Length; h = h + 1)
                                {
                                    FullCommandArgs = FullCommandArgs + " " + frm.CommandArgs[h - 1].ToString();
                                }

                                string res = MyFunctions.Dialogs.MessageDialog("启动参数错误", "无法识别指定的启动参数", MyFunctions.Dialogs.MessageDialogIcon.Error, "无效的启动参数:\r\n" + FullCommandArgs, "b1", true, true, "查看帮助", "确定");
                                if (res == "B1")
                                {
                                    MyFunctions.Dialogs.HelpDialog("系统齿轮命令行选项", SystemGear.Properties.Resources.CommandArgs);
                                }
                            }
                            break;
                        case "F": //用于进入各个功能
                            frm.Hide();
                            frm.JShow = "SYSVIE";
                            //MessageBox.Show(frm.CommandArgs.Length.ToString());
                            if (frm.CommandArgs.Length == 4)
                            {
                                string firstindex = frm.CommandArgs[1].ToString().Replace("-", "").Replace("/", "").Replace(@"\", "");
                                int secondindex = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(frm.CommandArgs[2].ToString().Replace("-", "").Replace("/", "").Replace(@"\", ""), 1);
                                int thridindex = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(frm.CommandArgs[3].ToString().Replace("-", "").Replace("/", "").Replace(@"\", ""), 1);
                                //MessageBox.Show(firstindex.ToString());
                                //MessageBox.Show(secondindex.ToString());
                                //MessageBox.Show(thridindex.ToString());
                                if (firstindex.ToUpper() == "SYSVIE")
                                {
                                    Form_SystemStyle sty = new Form_SystemStyle();
                                    sty.Location = loc;
                                    Class_SystemStyle.SystemStyle_Enter(1, secondindex, thridindex, sty);
                                    sty.Show();
                                }
                            }
                            else
                            {
                                frm.Show();
                                for (int h = 1; h <= frm.CommandArgs.Length; h = h + 1)
                                {
                                    FullCommandArgs = FullCommandArgs + " " + frm.CommandArgs[h - 1].ToString();
                                }
                                string res = MyFunctions.Dialogs.MessageDialog("启动参数错误", "无法识别指定的启动参数", MyFunctions.Dialogs.MessageDialogIcon.Error, "无效的启动参数:\r\n" + FullCommandArgs, "b1", true, true, "查看帮助", "确定");
                                if (res == "B1")
                                {
                                    MyFunctions.Dialogs.HelpDialog("系统齿轮命令行选项", SystemGear.Properties.Resources.CommandArgs);
                                }
                            }
                            break;
                        case "L"://用于加载SGCF文件
                            frm.Show();
                            string sgcf = frm.CommandArgs[0].Substring(3, frm.CommandArgs[0].Length - 3);
                            if (System.IO.File.Exists(sgcf) == true)
                            {
                                string writefile = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\LoadSGCF.sgcf";
                                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(writefile);
                                string filetype = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("SystemGear", "FileType", "Config", false, sgcf);
                                string ver = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("SystemGear", "Version", "Config", false, sgcf);
                                if (filetype.ToUpper() != "CONFIG" && filetype.ToUpper() != "")
                                {
                                    if (ver.ToUpper() == Application.ProductVersion)
                                    {
                                        string res = MyFunctions.Dialogs.MessageDialog("是否应用?", "是否将指定的配置文件应用到系统齿轮?", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b1", true, true, "继续", "取消");
                                        //SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Info", "FileName", sgcf, "Config", false, writefile);
                                        //SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Info", "FileType", filetype, "Config", false, writefile);
                                        if (res == "B1")
                                        {
                                            switch (filetype.ToUpper())
                                            {
                                                case "GUIDICON":
                                                    string CFG_GUID = Application.StartupPath + @"\Config\MainProgram.sgcf";
                                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "GUIDConfigFile", sgcf, "Config", false, CFG_GUID);
                                                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.ExecutablePath, "/F /SYSVIE /02 /01", false, false, true, false, false);
                                                    Application.Exit();
                                                    break;
                                                case "RIGHTMENUGROUP":
                                                    string CFG_GUID1 = Application.StartupPath + @"\Config\MainProgram.sgcf";
                                                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "RightMenuGroupConfigFile", sgcf, "Config", false, CFG_GUID1);
                                                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.ExecutablePath, "/F /SYSVIE /04 /01", false, false, true, false, false);
                                                    Application.Exit();
                                                    break;
                                                default:
                                                    MyFunctions.Dialogs.MessageDialog("无法加载指定的文件", "无法加载指定的配置文件.因为该文件的标识信息与目前系统齿轮所支持的配置文件不符", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "继续", "确定");
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {

                                        MyFunctions.Dialogs.MessageDialog("无法加载指定的文件", "无法加载指定的配置文件.因为该文件的版本与当前的系统齿轮的版本不一致", MyFunctions.Dialogs.MessageDialogIcon.Error, @"无法加载""" + sgcf + @""" 因为该文件的版本与当前的系统齿轮的版本不一致." + "\r\n" + "该文件的版本 :" + ver + "\r\n" + "系统齿轮的版本 :" + Application.ProductVersion, "b2", false, true, "", "确定");
                                    }
                                }
                                else
                                {
                                    MyFunctions.Dialogs.MessageDialog("无法加载指定的文件", "无法识别您所指定的文件的必要信息.并且无法加载系统齿轮的配置文件", MyFunctions.Dialogs.MessageDialogIcon.Error, @"无法加载""" + sgcf + @""" 因为无法识别指定的信息.无法加载标识为""Config""的配置文件", "b2", false, true, "", "确定");
                                    //MyFunctions.Dialogs.MessageDialog("无法加载指定的文件", "无法识别您所指定的文件的必要信息.并且无法加载系统齿轮的配置文件", "error", @"无法加载""" + sgcf + @""" 因为无法识别指定的信息.无法加载标识为""Config""的配置文件", "b2", false, true, "", "确定", frm);
                                }
                            }
                            else
                            {
                                MyFunctions.Dialogs.MessageDialog("无法加载指定的文件", "无法识别您所指定的文件的必要信息.因为指定文件不存在", MyFunctions.Dialogs.MessageDialogIcon.Error, @"找不到文件""" + sgcf + @"""", "b2", false, true, "", "确定");
                                //MyFunctions.Dialogs.MessageDialog("无法加载指定的文件", "无法加载指定的文件.因为指定的文件不存在", "error", @"找不到文件""" + sgcf + @"""", "b2", false, true, "是", "确定", frm);
                            }
                            break;
                        case "B"://用于返回
                            frm.Show();
                            break;
                        case "D": //用于清理临时文件
                            break;
                        case "C"://剪切板功能
                            frm.Show();
                            if (frm.CommandArgs.Length == 2)
                            {
                                if (frm.CommandArgs[1].Length >= 8)
                                {
                                    string folder = frm.CommandArgs[1].Substring(8, frm.CommandArgs[1].Length - 8);
                                    Class_SystemStyle.SystemStyle_SaveJQBObjectInCommandLineWithOOBEFile(folder, frm);
                                    System.Environment.Exit(0);
                                }
                                else
                                {
                                    MyFunctions.Dialogs.MessageDialog("无法继续", "参数错误", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "是", "确定");
                                }
                            }
                            else
                            {
                                MyFunctions.Dialogs.MessageDialog("无法继续", "没有指定一个参数", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "是", "确定");
                            }
                            break;
                        case "I": //用于安装时

                            MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\奥威森网络\系统齿轮");
                            MyFunctions.ProgramAndLinksOperate.CreateLink(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\系统齿轮.LNK", Application.ExecutablePath, "", "强大、简单、方便的系统优化软件", Application.ExecutablePath+",0", null);
                            MyFunctions.ProgramAndLinksOperate.CreateLink(Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\奥威森网络\系统齿轮\系统齿轮.LNK", Application.ExecutablePath, "", "强大、简单、方便的系统优化软件", Application.ExecutablePath+",0", null);
                            MyFunctions.ExtraNames.RegistryExtraName("ALL");
                            ////
                            string clipfile = Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf";
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("AutoAnswer", "TEXT", "F", "Config", false, clipfile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("AutoAnswer", "IMAGE", "F", "Config", false, clipfile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("AutoAnswer", "FILES", "F", "Config", false, clipfile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("IMAGE", "Folder", "U", "Config", false, clipfile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("IMAGE", "Type", "PNG", "Config", false, clipfile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("IMAGE", "Size_W", "", "Config", false, clipfile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("IMAGE", "Size_H", "", "Config", false, clipfile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("TEXT", "Folder", "U", "Config", false, clipfile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("TEXT", "Type", "TXT", "Config", false, clipfile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("FILES", "Folder", "U", "Config", false, clipfile);
                            ////
                            string[] FOLDERS = new string[6];
                            FOLDERS[0] = "Backup";
                            FOLDERS[1] = "Config";
                            FOLDERS[2] = "Images";
                            FOLDERS[3] = "Packages";
                            FOLDERS[4] = "Programs";
                            FOLDERS[5] = "Temp";
                            for (int h = 1; h <= FOLDERS.Length; h++)
                            {
                                if (System.IO.Directory.Exists(Application.StartupPath + @"\" + FOLDERS[h - 1]) == false)
                                {
                                    MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(Application.StartupPath + @"\" + FOLDERS[h - 1]);
                                }
                            }
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "GUIDConfigFile", @"%AppPath%\Config\DefaultGUIDIconConfigFile.sgcf", "Config", false, Application.StartupPath + @"\Config\MainProgram.sgcf");
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SystemStyle", "RightMenuGroupConfigFile", @"%AppPath%\Config\DefaultRightMenuGroup.sgcf", "Config", false, Application.StartupPath + @"\Config\MainProgram.sgcf");
                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Application.StartupPath + @"\Config\DefaultGUIDIconConfigFile.sgcf");
                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Application.StartupPath + @"\Config\DefaultRightMenuGroup.sgcf");
                            Class_SystemStyle.SystemStyle_CreateDefaultGUIDIconConfigFile();
                            Class_SystemStyle.SystemStyle_CreateDefaultRightMenuConfigFile();
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "ImagesCount", "0", "Config", false, Application.StartupPath + @"\Config\LogonUIImages.sgcf");
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Info", "Count", "0", "Config", false, Application.StartupPath + @"\Config\Pings.sgcf");
                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Application.StartupPath + @"\Config\SystemIcons.sgcf");
                            if (frm.CommandArgs.Length == 2)
                            {
                                string show = frm.CommandArgs[1].Substring(1, 1).ToUpper();
                                if (show == "F")
                                {
                                    Application.Exit();
                                }
                                else
                                {
                                    frm.Show();
                                }
                            }
                            else
                            {
                                if (frm.CommandArgs.Length == 1)
                                {
                                }
                                else
                                {
                                    for (int h = 1; h <= frm.CommandArgs.Length; h = h + 1)
                                    {
                                        FullCommandArgs = FullCommandArgs + " " + frm.CommandArgs[h - 1].ToString();
                                    }
                                    string res = MyFunctions.Dialogs.MessageDialog("启动参数错误", "无法识别指定的启动参数", MyFunctions.Dialogs.MessageDialogIcon.Error, "无效的启动参数:\r\n" + FullCommandArgs, "b1", true, true, "查看帮助", "确定");
                                    if (res == "B1")
                                    {
                                        MyFunctions.Dialogs.HelpDialog("系统齿轮命令行选项", SystemGear.Properties.Resources.CommandArgs);
                                    }
                                }
                            }
                            break;
                        case "H":
                            frm.Show();
                            MyFunctions.Dialogs.HelpDialog("系统齿轮命令行选项", SystemGear.Properties.Resources.CommandArgs);
                            break;
                        case "?":
                            frm.Show();
                            MyFunctions.Dialogs.HelpDialog("系统齿轮命令行选项", SystemGear.Properties.Resources.CommandArgs);
                            break;
                        case "P": //LOAD PACKAGE
                            frm.Show();
                            string package = frm.CommandArgs[0].Substring(3, frm.CommandArgs[0].Length - 3);
                            if (System.IO.File.Exists(package) == true)
                            {
                                MyFunctions.PackageOperate.SGPAK_ExtactPackage(package, "", true);
                                MyFunctions.Dialogs.MessageDialog("已成功解压压缩包文件", "已成功解压压缩包文件", MyFunctions.Dialogs.MessageDialogIcon.Information, @"已成功解压压缩包文件""" + package + @"""", "b2", false, true, "是", "确定");
                            }
                            else
                            {
                                MyFunctions.Dialogs.MessageDialog("无法解压指定的压缩包", "无法解压指定的压缩包.因为指定的文件不存在", MyFunctions.Dialogs.MessageDialogIcon.Error, @"找不到文件""" + package + @"""", "b2", false, true, "是", "确定");
                            }
                            break;
                        default:
                            for (int h = 1; h <= frm.CommandArgs.Length; h = h + 1)
                            {
                                FullCommandArgs = FullCommandArgs + " " + frm.CommandArgs[h - 1].ToString();
                            }
                            string res1 = MyFunctions.Dialogs.MessageDialog("启动参数错误", "无法识别指定的启动参数", MyFunctions.Dialogs.MessageDialogIcon.Error, "无效的启动参数:\r\n" + FullCommandArgs, "b1", true, true, "查看帮助", "确定");
                            if (res1 == "B1")
                            {
                                MyFunctions.Dialogs.HelpDialog("系统齿轮命令行选项", SystemGear.Properties.Resources.CommandArgs);
                            }
                            frm.Show();
                            break;
                    }
                }
                else
                {
                    frm.Show();
                }
            }
            catch
            {
                frm.Show();
                for (int h = 1; h <= frm.CommandArgs.Length; h = h + 1)
                {
                    FullCommandArgs = FullCommandArgs + " " + frm.CommandArgs[h - 1].ToString();
                }
                string res2 = MyFunctions.Dialogs.MessageDialog("启动参数错误", "无法识别指定的启动参数", MyFunctions.Dialogs.MessageDialogIcon.Error, "无效的启动参数:\r\n" + FullCommandArgs, "b1", true, true, "查看帮助", "确定");
                if (res2 == "B1")
                {
                    MyFunctions.Dialogs.HelpDialog("系统齿轮命令行选项", SystemGear.Properties.Resources.CommandArgs);
                }
            }
        }
        public static void Main_LoadUserPing(Form_Main frm)
        {
            try
            {
                string pingfile = Application.StartupPath + @"\Config\Pings.sgcf";
                if (System.IO.File.Exists(pingfile) == false)
                {
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Info", "Count", "0", "Config", false, pingfile);
                }
                int count = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("info", "count", "0", false, pingfile), 0);
                frm.flowLayoutPanel_usepings.Controls.Clear();
                for (int y = 1; y <= count; y++)
                {
                    string name, image;
                    int color_r, color_g, color_b;
                    name = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "name", "", false, pingfile);
                    image = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "image", "", false, pingfile);
                    color_r = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "colorr", "", false, pingfile), 0);
                    color_g = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "colorg", "", false, pingfile), 0);
                    color_b = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "colorb", "", false, pingfile), 0);
                    //string info = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ping" + y.ToString(), "info", "", false, pingfile);
                    /*
                    Assembly myAssembly;
                    myAssembly = System.Reflection.Assembly.Load("SystemGear");
                    System.Resources.ResourceManager myManager = new System.Resources.ResourceManager("SystemGear.Properties.Resources", myAssembly);
                     */
                    System.Drawing.Image myImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, image, false);
                    //pictureBox1.Image = myImage;
                    /*
                    Button btn = new Button();
                    -btn.FlatStyle = FlatStyle.Flat;
                    -btn.FlatAppearance.BorderSize = 0;
                   - btn.Size = new Size(121, 122);
                    -btn.Margin = new Padding(5, 5, 5, 5);
                    -btn.Image = myImage;
                    -btn.ContextMenuStrip = frm.contextMenuStrip2;
                    -btn.MouseDown += new MouseEventHandler(frm.PingButton_MouseDown);
                    -btn.BackColor = Color.FromArgb(color_r, color_g, color_b);
                    //btn.MouseDown += new MouseEventHandler(frm.button19_MouseDown);
                    -btn.ForeColor = Color.White;
                    -btn.Click += new EventHandler(frm.PingButton_Click);
                    //frm.toolTip1.SetToolTip(btn, info);
                    -btn.ImageAlign = ContentAlignment.MiddleCenter;
                    -btn.TextAlign = ContentAlignment.BottomLeft;
                    -btn.Text = name;
                    --btn.Tag = "Ping" + y.ToString();
                    -btn.Font = new Font("微软雅黑", 10, FontStyle.Bold);
                     */
                    MyModernButton btn = new MyModernButton();
                    btn.ButtonBackColor = Color.FromArgb(color_r, color_g, color_b);
                    btn.ButtonType = MyModernButton.ButtonStyle.NormalWithoutBackPage;
                    btn.Size = new Size(121, 122);
                    btn.Margin = new Padding(5, 5, 5, 5);
                    btn.ButtonBackImage = myImage;
                    btn.ContextMenuStrip = frm.contextMenuStrip2;
                    btn.ButtonForceColor = Color.White;
                    btn.OnButtonClick += new EventHandler(frm.PingButton_Click);
                    btn.OnButtonMouseDown += new MouseEventHandler(frm.PingButton_MouseDown);
                    btn.ButtonText = name;
                    frm.flowLayoutPanel_usepings.Controls.Add(btn);
                    btn.ButtonTags = new string[] { "Ping" + y.ToString() };
                }
            }
            catch { }
        }
        public static bool Main_CheckPathCanWrite()
        {
            try
            {
                string sgcf = Application.StartupPath + @"\InstallFiles.sgcf";
                int filecount = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_GetValue("maininfo", "installfilescount", "0", false, sgcf), 0);
                string very = "";
                for (int h = 1; h <= filecount; h++)
                {
                    if (System.IO.File.Exists(Application.StartupPath + "\\" + MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_GetValue("installfiles", "File_" + h.ToString(), "", false, sgcf)) == true)
                    {
                        very = very + "T";
                    }
                    else
                    {
                        very = very + "F";

                    }
                }
                if (very.Replace("T", "") == "")
                {
                    return true;
                }
                else
                {
                    //MessageBox.Show(very);
                    MyFunctions.Dialogs.MessageDialog("无法启动程序", "一个或多个文件无法被找到。请尝试重新安装本程序。", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                    Application.ExitThread();
                    return false;
                }
                /*
                string path = Application.StartupPath + "\\systemgear.exe"; //获取文件路径
                 FileAttributes att=File.GetAttributes(path );
                 if (att == FileAttributes.ReadOnly)
                 {
                     return false;
                 }
                 else
                 {
                     return true;
                 }
                 * */
            }
            catch { return false; }
        }
        public static void Main_SetSettings(Form_Main frm)
        {
            
            Thread P_thread = new Thread(
                () => //lambda表达式（参数列表）=>{执行语句}  lambda表达式是比匿名方法更加简洁的一种匿名函数语法
                {
                    frm.Invoke(new MethodInvoker(delegate()
                    {
                        ///////////////设置style
                        frm.label1.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
                        frm.panel1.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
                        frm.tabPage1.BackColor = frm.tabPage2.BackColor = frm.tabPage3.BackColor = frm.tabPage4.BackColor = frm.tabPage5.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetPanelColor();
                        frm.flowLayoutPanel_usepings.BackColor = frm.flowLayoutPanel1.BackColor = frm.flowLayoutPanel2.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetPanelColor();
                        frm.panel2.BackColor = frm.panel7.BackColor = frm.panel8.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetPanelColor();
                        frm.BackColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetPanelColor();
                        ///////////////////logo
                        frm.myModernButton2.ButtonSmallLogo = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, "S01", false);
                        frm.myModernButton4.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, "S06", false);
                        frm.myModernButton5.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, "S05", false);
                        frm.myModernButton6.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, "S02", false);
                        //frm.myModernButton7.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.Skins.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.Skins.GetSkin_GetImageType.FunctionLogo, "S03", false);
                        frm.myModernButton8.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, "S01", false);
                        frm.myModernButton12.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, "S03", false);
                        frm.myModernButton9.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, "S08", false);
                        frm.myModernButton10.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, "S04", false);
                        frm.myModernButton11.ButtonBackImage = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, "S07", false);
                        frm.myModernButton1.ButtonSmallLogo = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, "S03", false);
                       // frm.myModernButton1.ButtonBackImage = Class_SystemStyle.SystemStyle_SortingFile_LoadConditionToTile();
                    }));
                });//new thread
            P_thread.IsBackground = true;
            P_thread.Start();
        }
    }
}
