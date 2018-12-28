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
using IWshRuntimeLibrary;

namespace SystemGear
{
    public class MyFunctions
    {
        #region APIS
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType,
            int cxDesired, int cyDesired, uint fuLoad);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, LoadLibraryFlags dwFlags);

        private enum LoadLibraryFlags : uint
        {
            DONT_RESOLVE_DLL_REFERENCES = 0x00000001,
            LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,
            LOAD_LIBRARY_AS_DATAFILE = 0x00000002,
            LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,
            LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,
            LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SystemParametersInfo(uint uAction, uint uParam, StringBuilder lpvParam, uint init);
        const uint SPI_GETDESKWALLPAPER = 0x0073;
        public const uint LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);

        [DllImport("kernel32.dll")]
        public static extern IntPtr FindResource(IntPtr hModule, int lpID, string lpType);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SizeofResource(IntPtr hModule, IntPtr hResInfo);

        [DllImport("shell32.dll", EntryPoint = "SHGetFileInfo")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribute, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint Flags);
        [DllImport("shell32.dll")]
        public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, int[] phiconLarge, int[] phiconSmall, uint nIcons);
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }
        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        private static extern int ExtractIconEx(string lpszFile, int niconIndex, ref IntPtr phiconLarge, ref IntPtr phiconSmall, int nIcons);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public static string CreateNewLinkInTaskbar = "";
        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);
        [DllImport("shell32.dll")]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        #endregion
        public class Dialogs
        {
            #region API
            [DllImport("shell32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern bool SHFileOperation([In, Out]  SHFILEOPSTRUCT str);
            private const int FO_MOVE = 0x1;
            private const int FO_COPY = 0x2;
            private const int FO_DELETE = 0x3;
            private const ushort FOF_NOCONFIRMATION = 0x10;
            private const ushort FOF_ALLOWUNDO = 0x40;
            private const string FILE_SPLITER = "\0";
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            public class SHFILEOPSTRUCT
            {
                public IntPtr hwnd;
                /// <summary> 
                /// 设置操作方式，移动：FO_MOVE，复制：FO_COPY，删除：FO_DELETE 
                /// </summary> 
                public UInt32 wFunc;
                /// <summary> 
                /// 源文件路径 
                /// </summary> 
                public string pFrom;
                /// <summary> 
                /// 目标文件路径 
                /// </summary> 
                public string pTo;
                /// <summary> 
                /// 允许恢复 
                /// </summary> 
                public UInt16 fFlags;
                /// <summary> 
                /// 监测有无中止 
                /// </summary> 
                public Int32 fAnyOperationsAborted;
                public IntPtr hNameMappings;
                /// <summary> 
                /// 设置标题 
                /// </summary> 
                public string lpszProgressTitle;
            }
            #endregion
            #region 文件属性Dialog API
            [StructLayout(LayoutKind.Sequential)]
            public struct SHELLEXECUTEINFO
            {
                public int cbSize;
                public uint fMask;
                public IntPtr hwnd;
                [MarshalAs(UnmanagedType.LPStr)]
                public string lpVerb;
                [MarshalAs(UnmanagedType.LPStr)]
                public string lpFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string lpParameters;
                [MarshalAs(UnmanagedType.LPStr)]
                public string lpDirectory;
                public int nShow;
                public IntPtr hInstApp;
                public IntPtr lpIDList;
                [MarshalAs(UnmanagedType.LPStr)]
                public string lpClass;
                public IntPtr hkeyClass;
                public uint dwHotKey;
                public IntPtr hIcon;
                public IntPtr hProcess;
            }
            private const int SW_SHOW = 5;
            private const uint SEE_MASK_INVOKEIDLIST = 12;

            [DllImport("shell32.dll")]
            static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

            #endregion
            /// <summary>
            /// MessageBox的图标模式
            /// </summary>
            public enum MessageDialogIcon { Question, Error, Information, Exclamatory }
            /// <summary>
            /// 显示通用对话框的集合
            /// </summary>
            /// <param name="Type">模式 [filesize] 文件大小选择(返回数组 : 文件的最小值MB , 文件的最大值MB</param>
            /// <param name="Title">标题</param>
            /// <param name="SecondTitle">副标题</param>
            /// <param name="args">参数</param>
            /// <returns></returns>
            public static string[] CommonDialog(string Type,string Title,string SecondTitle,string[] args)
            {
                Form_CommondDialogsItems f = new Form_CommondDialogsItems(Type,args);
                f.label2.Text = SecondTitle;
                f.label1.Text = f.Text = Title;
                f.ShowDialog();
                string[] r = f.ReturnStrings;
                f.Dispose();
                return r;
            }
            
            /// <summary>
            /// 系统齿轮消息框
            /// </summary>
            /// <param name="MessageTitle">消息框标题</param>
            /// <param name="Message">消息</param>
            /// <param name="MessageType">消息的图标模式</param>
            /// <param name="InfoText">详细的信息</param>
            /// <param name="DefaultButton">默认的按钮(B1,B2)</param>
            /// <param name="Button1Visual">按钮1是否可见</param>
            /// <param name="Button2Visual">按钮2是否可见</param>
            /// <param name="Button1Text">按钮1的文字</param>
            /// <param name="Button2Text">按钮2的文字</param>
            /// <returns>返回String类型的值(B1,B2)</returns>
            public static string MessageDialog(string MessageTitle, string Message, MessageDialogIcon MessageType, string InfoText, string DefaultButton, bool Button1Visual, bool Button2Visual, string Button1Text, string Button2Text)
            {
                try
                {
                    Form_MessageDialog_2 frm = new Form_MessageDialog_2();
                    frm.label1.Text = MessageTitle;
                    frm.label2.Text = Message;
                    switch (MessageType)
                    {
                        case MessageDialogIcon.Error:
                            frm.pictureBox1.Image = Properties.Resources.MSG_ERROR;
                            System.Media.SystemSounds.Hand.Play();
                            break;
                        case MessageDialogIcon.Information:
                            frm.pictureBox1.Image = Properties.Resources.MSG_INFO;
                            System.Media.SystemSounds.Exclamation.Play();
                            break;
                        case MessageDialogIcon.Question:
                            frm.pictureBox1.Image = Properties.Resources.MSG_QUES;
                            System.Media.SystemSounds.Question.Play();
                            break;
                        case MessageDialogIcon.Exclamatory:
                            frm.pictureBox1.Image = Properties.Resources.MSG_INFO;
                            System.Media.SystemSounds.Asterisk.Play();
                            break;
                    }
                    frm.ErrorInfo = InfoText;
                    frm.defaultbt = DefaultButton;
                    frm.myNormalButton1.Visible = Button1Visual;
                    frm.myNormalButton2.Visible = Button2Visual;
                    frm.myNormalButton1.ButtonText = Button1Text;
                    frm.myNormalButton2.ButtonText = Button2Text;
                    frm.Text = MessageTitle;
                    frm.ShowDialog();
                    string cb = frm.ChooseButton;
                    frm.Dispose();
                    return cb;
                }
                catch
                {
                    return DefaultButton.ToUpper();
                }
            }
            /// <summary>
            /// 用于显示特殊控件的对话框
            /// </summary>
            /// <param name="Title">标题</param>
            /// <param name="StartArgs">启动参数(将会传递到控件的Tag属性内)</param>
            /// <param name="UserControls">控件</param>
            /// <returns>返回(用户控件的Tag)</returns>
            public static string SpecialDialog(string Title, string StartArgs, System.Windows.Forms.UserControl UserControls)
            {
                try
                {
                    Form_SpecialDialog jk = new Form_SpecialDialog();
                    jk.Controls.Add(UserControls);
                    UserControls.Location = new Point(8, 55);
                    jk.Tag = StartArgs;
                    jk.Text = Title;
                    jk.label1.Text = Title;
                    jk.ShowDialog();
                    string jkj = "";
                    if (jk.Tag != null)
                    {
                        jkj = jk.Tag.ToString();
                    }
                    jk.Dispose();
                    return jkj;
                }
                catch
                {
                    return "";
                }
            }
            /// <summary>
            /// 选择颜色对话框
            /// </summary>
            /// <param name="DefaultColor">默认的颜色</param>
            /// <returns></returns>
            public static Color ColorDialog(Color DefaultColor)
            {
                try
                {
                    ColorDialog cl = new ColorDialog();
                    cl.AllowFullOpen = true;
                    cl.Color = DefaultColor;
                    cl.ShowDialog();
                    return cl.Color;
                }
                catch { return Color.FromArgb(0, 0, 0); }
            }
            /// <summary>
            /// 选择Windows 8 8.1的Windows UI样式的程序 返回数组 [0] 名称 [1] APPID [2] ICO位置
            /// </summary>
            /// <param name="title">标题</param>
            /// <returns></returns>
            public static  string[] ChooseWinApp(string title)
            {
                Form_ChooseModernProgram g = new Form_ChooseModernProgram(title);
                g.ShowDialog();
                string[] k = g.rets;
                g.Dispose();
                return k;
            }
            /// <summary>
            /// 固定到对话框
            /// </summary>
            /// <param name="ProgramArgs">程序的启动参数</param>
            /// <param name="ProgramName">名称</param>
            /// <param name="LogoLocation">png的标识符</param>
            /// <param name="Info">详细信息</param>
            /// <param name="Icon">图标</param>
            /// <param name="Location">按钮的对于桌面的位置</param>
            public static void PingProgram(string ProgramArgs, string ProgramName, string LogoLocation, string Info, string Icon, Point Location)
            {
                Form_PingApp frm = new Form_PingApp(ProgramArgs, ProgramName, LogoLocation, Info, Icon, Location);
                frm.Show();
            }
            /// <summary>
            /// 选择图标对话框
            /// </summary>
            /// <param name="Title">标题</param>
            /// <param name="DefaultIcon">默认的图标</param>
            /// <returns></returns>
            public static string ChooseIcon(string Title, string DefaultIcon)
            {
                try
                {
                    Form_ChooseIcon fg = new Form_ChooseIcon(DefaultIcon );
                    fg.label1.Text = fg.Text = Title;
                    fg.ShowDialog();
                    string k;
                    if (fg.IconFile == "")
                    {
                        return DefaultIcon;
                    }
                    else
                    {
                        k = fg.IconFile + "," + fg.IconIndex;
                        return k;
                    }
                }
                catch
                {
                    return "";
                }
            }
            /// <summary>
            /// 用于选择GUID图标 
            /// </summary>
            /// <returns>返回数组 [0] 名称 [1] GUID</returns>
            public static string[] ChooseGUIDIconDialog()
            {
                try
                {
                    Form_GUIDsExplorerDialog frm = new Form_GUIDsExplorerDialog();
                    frm.ShowDialog();
                    string[] r = frm.return_stringarrr;
                    frm.Dispose();
                    return r;
                }
                catch { return null; }
            }
            /// <summary>
            /// 保存文件对话框
            /// </summary>
            /// <param name="Title">标题</param>
            /// <param name="Filter">文件扩展名</param>
            /// <param name="DefaultExtraName">默认的扩展名</param>
            /// <returns></returns>
            public static string SaveFileDialog(string Title, string Filter, string DefaultExtraName)
            {
                System.Windows.Forms.SaveFileDialog SF = new System.Windows.Forms.SaveFileDialog();
                try
                {
                    SF.Title = Title;
                    SF.Filter = Filter;
                    SF.CheckPathExists = false;
                    SF.AddExtension = true;
                    SF.DefaultExt = DefaultExtraName;
                    SF.ShowDialog();
                    return SF.FileName;
                }
                catch
                {
                    return "";
                }
            }
            /// <summary>
            /// 打开文件对话框
            /// </summary>
            /// <param name="Title">标题</param>
            /// <param name="Filter">扩展名</param>
            /// <returns></returns>
            public static string OpenFileDialog(string Title, string Filter)
            {
                try
                {
                    OpenFileDialog OP = new OpenFileDialog();
                    OP.Title = Title;
                    OP.Filter = Filter;
                    OP.CheckFileExists = true;
                    OP.CheckPathExists = true;
                    OP.Multiselect = false;
                    OP.ValidateNames = true;
                    OP.DereferenceLinks = true;
                    OP.ShowDialog();
                    return OP.FileName;
                }
                catch
                {
                    return "";
                }
            }
            public static string OpenFolder(string Title)
            {
                try
                {
                    FolderBrowserDialog fg = new FolderBrowserDialog();
                    fg.Description = Title;
                    fg.ShowDialog();
                    string f = fg.SelectedPath;
                    if (f != "")
                    {
                        if (f.Length == 3)
                        {
                            f = f.Replace("\\", "");
                        }
                    }
                    return f;
                }
                catch
                {
                    return "";
                }
            }
            /// <summary>
            /// 输入对话框
            /// </summary>
            /// <param name="MainTitle">主标题</param>
            /// <param name="FuTitle">副标题</param>
            /// <param name="AlloweHasEmptyStrings">是否允许输入空的字符</param>
            /// <param name="ClickButtonDialog">点击按钮后的对话框 [filechoose] 选择文件对话框,必须指定Filter参数 [folderchoose] 选择文件夹对话框 [iconchoose] 选择图标对话框</param>
            /// <param name="Filter">文件类型</param>
            /// <param name="defaultstring">默认的数据</param>
            /// <param name="texttip">文本框的清空后显示的信息</param>
            /// <returns></returns>
            public static string InputDialog(string MainTitle, string FuTitle, bool AlloweHasEmptyStrings, string ClickButtonDialog, string Filter,string defaultstring,string texttip)
            {
                try
                {
                    string[] o=new string[7];
                    o[0] = MainTitle;
                    o[1] = FuTitle;
                    o[2] = texttip;
                    o[3] = defaultstring;
                    o[4] = ClickButtonDialog;
                    o[5] = Filter;
                    if (AlloweHasEmptyStrings == true)
                    {
                        o[6] = "";
                    }
                    else { o[6] = "MUST"; }
                    string[] p=MyFunctions.Dialogs.CommonDialog("inputbox", MainTitle, "请按照以下要求输入一些文字", o);
                    return p[0];
                }
                catch
                {
                    return defaultstring;
                }
            }

            public static string TasksChooseDialog(string Title, string[] Tasks_Name)
            {
                try
                {
                    Form_TasksChooseDialog t = new Form_TasksChooseDialog();
                    t.label1.Text = Title;
                    t.flowLayoutPanel1.Controls.Clear();
                    t.Text = Title;
                    for (int j = 1; j <= Tasks_Name.Length; j = j + 1)
                    {
                        if (j == 1)
                        {
                            Button btn = new Button();
                            btn.TextAlign = ContentAlignment.MiddleLeft;
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderSize = 0;
                            btn.ForeColor = Color.White;
                            btn.BackColor = Color.FromArgb(0, 148, 255);
                            float fontSize = 12.5f;
                            btn.Font = new Font("微软雅黑", fontSize, FontStyle.Bold);
                            btn.Margin = new Padding(3, 3, 3, 3);
                            btn.Size = new Size(530, 46);
                            //选择图像
                            btn.ImageAlign = ContentAlignment.MiddleLeft;
                            btn.Image = Properties.Resources.TasksChoose;
                            btn.Text = "        " + Tasks_Name[j - 1].ToString();
                            btn.Click += new EventHandler(t.button1_Click);
                            btn.Tag = "T" + j.ToString();
                            t.flowLayoutPanel1.Controls.Add(btn);
                        }
                        else
                        {
                            Button btn = new Button();
                            btn.TextAlign = ContentAlignment.MiddleLeft;
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderSize = 0;
                            btn.Size = new Size(530, 46);
                            btn.FlatAppearance.BorderColor = Color.White;
                            btn.ForeColor = Color.FromArgb(0, 148, 255);
                            btn.BackColor = Color.White;
                            btn.Image = Properties.Resources.TasksChoose_Blue;
                            btn.ImageAlign = ContentAlignment.MiddleLeft;
                            float fontSize = 12.5f;
                            btn.Font = new Font("微软雅黑", fontSize, FontStyle.Bold);
                            btn.Margin = new Padding(3, 3, 3, 3);
                            //选择图像
                            btn.Text = "       " + Tasks_Name[j - 1].ToString();
                            btn.Click += new EventHandler(t.button1_Click);
                            btn.Tag = "T" + j.ToString();
                            t.flowLayoutPanel1.Controls.Add(btn);
                        }
                    }
                    t.ShowDialog();
                    string p = t.ChooseTask;
                    t.Dispose();
                    return p;
                }
                catch
                {
                    return "";
                }
            }
            /// <summary>
            /// 用于浏览系统齿轮中的功能 OPE:返回数组0 名称 1 命令 2 图标 3 命令行 4是否管理员 T or F
            ///                                         FUN:返回数组0 名称 1 命令 2 图标 
            /// </summary>
            /// <param name="Type">模式([OPE] 用于选择常用操作 [FUN] 浏览功能)</param>
            /// <returns></returns>
            public static string[] ChooseOperateOrExploreFunctionDialog(string Type)
            {
                try
                {
                    Form_FunctionExplorer frm = new Form_FunctionExplorer();
                    frm.Tag = Type;
                    frm.ShowDialog();
                    string[] fg;
                    if (Type.ToUpper() == "OPE")
                    {
                        fg = frm.ret;
                    }
                    else
                    {
                        fg = frm.ret_fun;
                    }
                    frm.Dispose();
                    return fg;
                }
                catch
                {
                    return null;
                }
            }
            public static void SettingsDialog(string Title, Color ForceColor, UserControl SettingsPanel)
            {
                try
                {
                    Form_PublicSettingsDialog frm = new Form_PublicSettingsDialog(Title, ForceColor, SettingsPanel);
                    frm.ShowDialog();
                }
                catch { }
            }
            //////////////////////
            public static void FileAttDialog(string FilePath)
            {
                try
                {
                    SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
                    info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
                    info.lpVerb = "properties";
                    info.lpFile = FilePath;
                    info.nShow = SW_SHOW;
                    info.fMask = SEE_MASK_INVOKEIDLIST;
                    ShellExecuteEx(ref info);
                }
                catch { }
            }
            /// <summary>
            /// 系统齿轮文件操作对话框
            /// </summary>
            /// <param name="files">文件数组</param>
            /// <param name="flags">操作代码数组 [Copy,C:\123] 复制 [Move,C:\123] 移动 [Delete] 删除 [NoOperate] 不操作文件</param>
            /// <param name="title"></param>
            public static void FileOperateDialog(string[] files,string[] flags,string title)
            {
                Form_FileOperate o = new Form_FileOperate(files, flags, title);
                o.ShowDialog();
            }
        public static bool CopyFilesWithSystemProcessDialog(string[] FilesAndFolderPath, string CopyToFolderPath)
        {
            SHFILEOPSTRUCT pm = new SHFILEOPSTRUCT();
            pm.wFunc = FO_COPY;
            //pm.pFrom = FileOrFolderPath;
            if (System.IO.Directory.Exists(CopyToFolderPath) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(CopyToFolderPath); }
            string path = "";
            for (int k = 1; k <= FilesAndFolderPath.Length; k++)
            {
                path = path +FilesAndFolderPath[k-1]+"\0";
            }
            pm.pFrom = path;
            pm.pTo = CopyToFolderPath;
            pm.fFlags = FOF_ALLOWUNDO;
            pm.lpszProgressTitle = "复制文件...";
            return !SHFileOperation(pm);

        }
        public static bool MoveFilesWithSystemProcessDialog(string[] FilesAndFolderPath, string MoveToFolderPath)
        {
            SHFILEOPSTRUCT pm = new SHFILEOPSTRUCT();
            pm.wFunc = FO_MOVE;
            if (System.IO.Directory.Exists(MoveToFolderPath) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(MoveToFolderPath); }
            string path = "";
            for (int k = 1; k <= FilesAndFolderPath.Length; k++)
            {
                path = path + FilesAndFolderPath[k - 1] + "\0";
            }
            pm.pFrom = path;
            pm.pTo = MoveToFolderPath;
            pm.fFlags = FOF_ALLOWUNDO;
            pm.lpszProgressTitle = "移动文件...";
            return !SHFileOperation(pm);

        }
        public static string ShowSmallTools(string Title, UserControl FunctionPanel)
        {
            try
            {
                Form_FunctionTools frm = new Form_FunctionTools(Title, FunctionPanel);
                frm.Text = frm.label1.Text = Title;
                frm.ShowDialog();
                string t = frm.ret;
                frm.Dispose();
                return t;
            }
            catch { return ""; }
        }
        public static void EditLinkDialog(string LinkPath)
        {
            Form_EditLink frm = new Form_EditLink();
            frm.linkfile = LinkPath;
            frm.ShowDialog();
        }
        public static void HelpDialog(string Title,string HelpText)
        {
            Form_HelpDialog h = new Form_HelpDialog();
            h.textBox1.Text= HelpText;
            h.label1.Text = h.Text = Title;
            h.ShowDialog();
        }
        /// <summary>
        /// 选择驱动器 
        /// 返回数组 [0] 选择的磁盘盘符 [1] 卷标 [2] 类型(与Type 参数一致 FIXED 磁盘 CDROM 光盘 CANNOTUSE 不可用) [3] 总大小(GB) [4] 可用大小(GB)
        /// </summary>
        /// <param name="Type">模式 [FIXED] 只显示固定磁盘 [CDROM] 只显示光盘 [ALL] 显示所有</param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string[] ShowChooseDiskDialog(string Type, string title)
        {
            SGForm_DiskChoose df = new SGForm_DiskChoose(Type.ToUpper());
            df.Text = title;
            df.label1.Text = title;
            df.ShowDialog();
            string[] r = df.return_disk_info;
            df.Dispose();
            return r;
        }
        }
        public class ApplicationAndEnvironmentInformation
        {
            public class ApplicationSettings
            {
                public static System.Drawing.Color GetApplicationSetting_MainColor()
                {
                    return MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetMainColor();
                }
                public static string GetApplicationSetting_TempPath(string DefaultPath)
                {

                    return Application.StartupPath + @"\Temp";
                }
                public static string GetApplicationSetting_BackupPath()
                {
                    try
                    {
                        if (MyFunctions.FileSystemOperate.FileSystemOperate_GetFolderExists(Application.StartupPath + @"\Backup", true) == true)
                        {
                            return Application.StartupPath + @"\Backup";
                        }
                        else
                        {
                            return "";
                        }
                    }
                    catch
                    {
                        return "";
                    }
                }
                public static string GetApplicationSetting_ConfigPath()
                {
                    if (System.IO.Directory.Exists(Application.StartupPath + @"\Config") == false)
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(Application.StartupPath + @"\Config");
                    }
                    return Application.StartupPath + @"\Config";
                }
                public static bool GetApplicationSetting_IsClickMinBoxInTaskBar()
                {
                    try
                    {
                        string res = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MainSettings", "MinBoxChoose", "TaskBar", false, Application.StartupPath + @"\Config\MainProgram.sgcf").ToUpper();
                        if (res == "TaskBar".ToUpper())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return true;
                    }
                }
                public static string GetApplicationSetting_ClickCloseBoxToOperate()
                {
                    string P = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("Mainsettings", "ClickCloseBox_operate", "ASK", false, Application.StartupPath + @"\Config\MainProgram.sgcf").ToUpper();
                    if (P == "")
                    {
                        P = "ASK";
                    }
                    return P;
                }
                public static string GetApplicationSetting_StartCommand()
                {
                    try
                    {
                        string ret = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MainSettings", "StartCommand", "", false, Application.StartupPath + @"\Config\MainProgram.sgcf");
                        return ret;
                    }
                    catch { return ""; }
                }
                public static void SetApplicationSetting_ClickCloseBoxToOperate(string OperateCode)
                {
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainSettings", "ClickCloseBox_Operate", OperateCode, "Config", false, Application.StartupPath + @"\Config\MainProgram.sgcf");
                }
                public class SkinsAndResources
                {
                    /// <summary>
                    /// 用于获取当前皮肤的配置文件
                    /// </summary>
                    /// <returns></returns>
                    public static string GetSkin_SkinConfigFile()
                    {
                        string main = Application.StartupPath + @"\config\mainprogram.sgcf";
                        string file111 = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("mainsettings", "selectSkin", "", false, main);
                        file111 = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(file111, file111);
                        return file111;
                    }
                    public static Color GetSkin_GetMainColor()
                    {
                        try
                        {
                            string f = GetSkin_SkinConfigFile();
                            string c = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "maincolor", "0,148,255", false, f);
                            string[] co = c.Split(',');
                            if(co.Length ==3)
                            {
                                return Color.FromArgb(Convert.ToInt32(co[0]), Convert.ToInt32(co[1]), Convert.ToInt32(co[2]));
                            }
                            else
                            {
                                return Color.FromArgb(0, 148, 255);
                            }
                        }
                        catch { return Color.FromArgb(0, 148, 255); }
                    }
                    public static Color GetSkin_GetForceColor()
                    {
                        try
                        {
                            string f = GetSkin_SkinConfigFile();
                            string c = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "forcecolor", "255,255,255", false, f);
                            string[] co = c.Split(',');
                            if (co.Length == 3)
                            {
                                return Color.FromArgb(Convert.ToInt32(co[0]), Convert.ToInt32(co[1]), Convert.ToInt32(co[2]));
                            }
                            else
                            {
                                return Color.FromArgb(255, 255, 255);
                            }
                        }
                        catch { return Color.FromArgb(255, 255, 255); }
                    }
                    public static Color GetSkin_GetM01TitleColor_Normal()
                    {
                        try
                        {
                            string f = GetSkin_SkinConfigFile();
                            string c = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "MainM01TitleColor_normal", "0,0,0", false, f);
                            string[] co = c.Split(',');
                            if (co.Length == 3)
                            {
                                return Color.FromArgb(Convert.ToInt32(co[0]), Convert.ToInt32(co[1]), Convert.ToInt32(co[2]));
                            }
                            else
                            {
                                return Color.FromArgb(0, 0, 0);
                            }
                        }
                        catch { return Color.FromArgb(0, 0, 0); }
                    }
                    public static Color GetSkin_GetM01TitleColor_Choose()
                    {
                        try
                        {
                            string f = GetSkin_SkinConfigFile();
                            string c = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "MainM01TitleColor_choose", "0,148,55", false, f);
                            string[] co = c.Split(',');
                            if (co.Length == 3)
                            {
                                return Color.FromArgb(Convert.ToInt32(co[0]), Convert.ToInt32(co[1]), Convert.ToInt32(co[2]));
                            }
                            else
                            {
                                return Color.FromArgb(0, 148, 255);
                            }
                        }
                        catch { return Color.FromArgb(0, 148,255); }
                    }
                    public static Color GetSkin_GetBorderColor()
                    {
                        try
                        {
                            string f = GetSkin_SkinConfigFile();
                            string c = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "bordercolor", "0,148,255", false, f);
                            string[] co = c.Split(',');
                            if (co.Length == 3)
                            {
                                return Color.FromArgb(Convert.ToInt32(co[0]), Convert.ToInt32(co[1]), Convert.ToInt32(co[2]));
                            }
                            else
                            {
                                return Color.FromArgb(0, 148, 255);
                            }
                        }
                        catch { return Color.FromArgb(0, 148, 255); }
                    }
                    public static Color GetSkin_GetPanelColor()
                    {
                        try
                        {
                            string f = GetSkin_SkinConfigFile();
                            string c = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "panelcolor", "255,255,255", false, f);
                            string[] co = c.Split(',');
                            if (co.Length == 3)
                            {
                                return Color.FromArgb(Convert.ToInt32(co[0]), Convert.ToInt32(co[1]), Convert.ToInt32(co[2]));
                            }
                            else
                            {
                                return Color.FromArgb(255, 255, 255);
                            }
                        }
                        catch { return Color.FromArgb(255, 255, 255); }
                    }
                    public static Color GetSkin_GetFunctionInfoColor()
                    {
                        try
                        {
                            string f = GetSkin_SkinConfigFile();
                            string c = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "FUNCTIONcolor", "0,0,0", false, f);
                            string[] co = c.Split(',');
                            if (co.Length == 3)
                            {
                                return Color.FromArgb(Convert.ToInt32(co[0]), Convert.ToInt32(co[1]), Convert.ToInt32(co[2]));
                            }
                            else
                            {
                                return Color.FromArgb(0,0,0);
                            }
                        }
                        catch { return Color.FromArgb(0,0,0); }
                    }
                    public static Color GetSkin_GetTiShiTextColor()
                    {
                        try
                        {
                            string f = GetSkin_SkinConfigFile();
                            string c = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "TISHITEXTcolor", "28,98,96", false, f);
                            string[] co = c.Split(',');
                            if (co.Length == 3)
                            {
                                return Color.FromArgb(Convert.ToInt32(co[0]), Convert.ToInt32(co[1]), Convert.ToInt32(co[2]));
                            }
                            else
                            {
                                return Color.FromArgb(28, 98, 96);
                            }
                        }
                        catch { return Color.FromArgb(28, 98, 96); }
                    }
                    public static Image  GetResources_GetPowerOperateImage(string str)
                    {
                        try
                        {
                            Image i = GetSkin_GetImageLocationWithPicture(GetSkin_GetImageType.BitmapResources, str, false);
                            return i;
                        }
                        catch { return Properties.Resources.ErrorLoadImage; }
                    }
                    public enum GetSkin_GetImageType{MainForm,SystemStyle,FunctionIco,FunctionLogo,BitmapResources,BitmapResourcesWithResFile,IconResources}
                    public static string GetSkin_GetImageLocationWithString(GetSkin_GetImageType ImageType,string Code,bool IsNormalChoose)
                    {
                        try
                        {
                            string imgfile = "";
                            switch (ImageType)
                            {
                                case GetSkin_GetImageType.MainForm:
                                    string f = GetSkin_SkinConfigFile();
                                    string c = "";
                                    if (IsNormalChoose == true)
                                    {
                                        c = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ButtonChooseImage_Normal", Code, "", false, f);
                                        c = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(c, c);
                                    }
                                    else
                                    {
                                        c = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ButtonChooseImage_choose", Code, "", false, f);
                                        c = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(c, c);
                                    }
                                    imgfile = c;
                                    break;
                                case GetSkin_GetImageType.IconResources :
                                    string fF = GetSkin_SkinConfigFile();
                                    string Fc = "";
                                    Fc = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("iconresources", Code, "", false, fF);
                                    Fc = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(Fc, Fc);
                                    imgfile = Fc;
                                    break;
                                case GetSkin_GetImageType.SystemStyle:
                                    string f1 = GetSkin_SkinConfigFile();
                                    string c1 = "";
                                    if (IsNormalChoose == true)
                                    {
                                        c1 = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ButtonChooseImage_Normal", Code, "", false, f1);
                                        c1 = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(c1, c1);
                                    }
                                    else
                                    {
                                        c1 = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("ButtonChooseImage_choose", Code, "", false, f1);
                                        c1 = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(c1, c1);
                                    }
                                    imgfile = c1;
                                    break;
                                case GetSkin_GetImageType.FunctionIco:
                                    string f2 = GetSkin_SkinConfigFile();
                                    string c2 = "";
                                    c2 = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("icon", Code, "", false, f2);
                                    c2 = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(c2, c2);
                                    imgfile = c2;
                                    break;
                                case GetSkin_GetImageType.FunctionLogo:
                                    string f3 = GetSkin_SkinConfigFile();
                                    string c3 = "";
                                    c3 = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("logo", Code, "", false, f3);
                                    c3 = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(c3, c3);
                                    imgfile = c3;
                                    break;
                                case GetSkin_GetImageType.BitmapResources:
                                    string f31 = GetSkin_SkinConfigFile();
                                    string c31 = "";
                                    c31 = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("bitmapresources", Code, "", false, f31);
                                    c31 = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(c31, c31);
                                    imgfile = c31;
                                    break;
                                case GetSkin_GetImageType.BitmapResourcesWithResFile:
                                    string f32 = GetSkin_SkinConfigFile();
                                    string c32 = "";
                                    c32 = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("bitmapresources", Code, "", false, f32);
                                    c32 = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(c32, c32);
                                    imgfile = c32;
                                    break;
                            }
                            return imgfile;
                        }
                        catch { return ""; }
                    }
                    public static Image  GetSkin_GetImageLocationWithPicture(GetSkin_GetImageType ImageType, string Code, bool IsNormalChoose)
                    {
                        try
                        {
                            string imgfile = "";
                            imgfile=GetSkin_GetImageLocationWithString(ImageType, Code, IsNormalChoose);
                            if(ImageType ==GetSkin_GetImageType.BitmapResourcesWithResFile )
                            {
                                Image h = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(imgfile, Application.ExecutablePath+",0");
                                return h;
                            }
                            else
                            {
                                if (System.IO.File.Exists(imgfile) == true)
                                {
                                    return System.Drawing.Image.FromFile(imgfile);
                                }
                                else
                                {
                                    return Properties.Resources.ErrorLoadImage;
                                }
                            }
                        }
                        catch { return Properties.Resources.ErrorLoadImage; }
                    }
                    public class ControlStyle
                    {
                        /// <summary>
                        /// 获取左侧按钮的背景颜色
                        /// </summary>
                        /// <returns></returns>
                        public static Color GetLeftSelectControlButton_BackColor()
                        {
                            return SkinsAndResources.GetSkin_GetMainColor();
                        }
                        /// <summary>
                        /// 获取左侧按钮的字体颜色
                        /// </summary>
                        /// <returns></returns>
                        public static Color GetLeftSelectControlButton_ForceColor()
                        {
                            return Color.White;
                        }
                    }
                }
            }
            public class OperatingSystemInfo
            {
                public static Image GetWallpaper()
                {
                    StringBuilder wallPaperPath = new StringBuilder(200);

                    if (SystemParametersInfo(SPI_GETDESKWALLPAPER, 200, wallPaperPath, 0))
                    {
                        //MessageBox.Show(wallPaperPath.ToString());
                        try
                        {
                            return Image.FromFile(wallPaperPath.ToString());
                        }
                        catch { return null; }
                    }
                    else { return null; }
                }
                public static string GetOSVersion()
                {
                    try
                    {
                        string j = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentVersion", "", false, false);
                        //return "6.3";
                        return j;
                    }
                    catch
                    {
                        return "";
                    }
                }
                public static string GetOSName()
                {
                    try
                    {
                        string test = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentVersion", "", false, false);
                        string name = "";
                        //MessageBox.Show(test);
                        switch (test)
                        {
                            case "6.3":
                                name = "Windows 8.1/Windows Server 2012 R2";
                                break;
                            case "6.2":
                                name = "Windows 8/Windows Server 2012";
                                break;
                            case "6.1":
                                name = "Windows 7/Windows Server 2008 R2";
                                break;
                            case "6.0":
                                name = "Windows Vista/Windows Server 2008";
                                break;
                            case "5.2":
                                name = "Windows Server 2003/Windows Server 2003 R2";
                                break;
                            case "5.1":
                                name = "Windows XP";
                                break;
                            case "5.0":
                                name = "Windows 2000";
                                break;
                            default:
                                name = "未知";
                                break;
                        }
                        return name;
                    }
                    catch
                    {
                        return "未知";
                    }
                }
                public class BCDOperate 
                {
                    public static bool BCDOperate_CreateBCDTempFile()
                    {
                        try
                        {
                            string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, false, true);
                            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(TempFile) == true)
                            {
                                return true;
                            }
                            else { return false; }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    public static string[] BCDOperate_GetBootMenu_Name()
                    {
                        try
                        {
                            string BootMenuItems = "";
                            string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                            int TempFile_LineCount = MyFunctions.StreamAndTextOperate.TextOperate.GetLineCount(TempFile);
                            if (TempFile_LineCount > 15)
                            {
                                for (int k = 1; k <= TempFile_LineCount; k = k + 1)
                                {
                                    string ReadOrgTextFromLine = MyFunctions.StreamAndTextOperate.TextOperate.ReadTextInLine(TempFile, k);
                                    if (ReadOrgTextFromLine.Length > 11)
                                    {
                                        if (ReadOrgTextFromLine.Substring(0, 11).ToUpper() == "description".ToUpper())
                                        {
                                            string jk = ReadOrgTextFromLine.Replace("description", "").Trim();
                                            if (jk.ToUpper() != "Windows Boot Manager".ToUpper())
                                            {
                                                if (BootMenuItems != "")
                                                {
                                                    BootMenuItems = BootMenuItems + "\n" + jk;
                                                }
                                                else
                                                {
                                                    BootMenuItems = jk;
                                                }
                                            }
                                        }
                                    }
                                }
                                return MyFunctions.StreamAndTextOperate.TextOperate.ConvertStringsToStringArry(BootMenuItems);
                            }
                            else { return null; }
                        }
                        catch { return null; }
                    }
                    public static string BCDOperate_GetBootMenu_TimeOut()
                    {
                        try
                        {
                            string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                            //MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                            //MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, false, true, null);
                            int TempFile_LineCount = MyFunctions.StreamAndTextOperate.TextOperate.GetLineCount(TempFile);
                            string TimeOut = "";
                            if (TempFile_LineCount > 15)
                            {
                                for (int k = 1; k <= TempFile_LineCount; k = k + 1)
                                {
                                    string ReadOrgTextFromLine = MyFunctions.StreamAndTextOperate.TextOperate.ReadTextInLine(TempFile, k);
                                    if (ReadOrgTextFromLine.Length >= 7)
                                    {
                                        if (ReadOrgTextFromLine.ToUpper().Substring(0, 7) == "TIMEOUT")
                                        {
                                            TimeOut = ReadOrgTextFromLine.ToUpper().Replace("TIMEOUT", "").Trim();
                                        }
                                    }
                                }
                                return TimeOut;
                            }
                            else
                            {
                                return "";
                            }
                        }
                        catch { return ""; }
                    }
                    public static string[] BCDOperate_GetBootMenu_GUID()
                    {
                        try
                        {
                            string BootMenuBiaoShiFu = "";
                            string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                            //MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                            //MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, false, true, null);
                            int TempFile_LineCount = MyFunctions.StreamAndTextOperate.TextOperate.GetLineCount(TempFile);
                            if (TempFile_LineCount > 15)
                            {
                                for (int g = 1; g <= TempFile_LineCount; g++)
                                {
                                    string ReadLineText = MyFunctions.StreamAndTextOperate.TextOperate.ReadTextInLine(TempFile, g);
                                    if (ReadLineText.Length > 3)
                                    {
                                        if (ReadLineText.Substring(0, 3).ToUpper() == "标识符".ToUpper())
                                        {
                                            if (ReadLineText.Replace("标识符", "").Trim().ToUpper() != "{BOOTMGR}")
                                            {
                                                if (BootMenuBiaoShiFu == "")
                                                {
                                                    BootMenuBiaoShiFu = ReadLineText.Replace("标识符", "").Trim();
                                                }
                                                else
                                                {
                                                    BootMenuBiaoShiFu = BootMenuBiaoShiFu + "\n" + ReadLineText.Replace("标识符", "").Trim();
                                                }
                                            }
                                        }
                                    }
                                }
                                if (BootMenuBiaoShiFu != "")
                                {
                                    string[] h = MyFunctions.StreamAndTextOperate.TextOperate.ConvertStringsToStringArry(BootMenuBiaoShiFu);
                                    return h;
                                }
                                else { return null; }
                            }
                            else
                            {
                                return null;
                            }
                        }
                        catch { return null; }
                    }
                    public static int BCDOperate_GetBootMenu_GetDefaultBootMenu()
                    {
                        try
                        {
                            int DefaultMenu = 0;
                            string defaultmenu = "";
                            string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                            // MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                            //MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, false, true, null);
                            int TempFile_LineCount = MyFunctions.StreamAndTextOperate.TextOperate.GetLineCount(TempFile);
                            if (TempFile_LineCount > 15)
                            {
                                for (int g = 1; g <= TempFile_LineCount; g++)
                                {
                                    string ReadLineText = MyFunctions.StreamAndTextOperate.TextOperate.ReadTextInLine(TempFile, g);
                                    if (ReadLineText.Length > 7)
                                    {
                                        if (ReadLineText.Substring(0, 7).ToUpper() == "default".ToUpper())
                                        {
                                            defaultmenu = ReadLineText.ToUpper().Substring(7, ReadLineText.Length - 7).Trim();
                                        }
                                    }
                                }
                                if (defaultmenu != "")
                                {
                                    string[] menugroupguid = MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.BCDOperate.BCDOperate_GetBootMenu_GUID();
                                    if (menugroupguid != null)
                                    {
                                        for (int y = 1; y <= menugroupguid.Length; y++)
                                        {
                                            if (menugroupguid[y - 1].ToUpper() == defaultmenu.ToUpper())
                                            {
                                                DefaultMenu = y - 1;
                                                break;
                                            }
                                        }
                                    }
                                }
                                return DefaultMenu;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        catch { return 0; }
                    }
                    public static string[] BCDOperate_GetBootMenu_GetBootLocation()
                    {
                        try
                        {
                            string BootDisk = "";
                            string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                            //MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                            //MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, false, true, null);
                            int TempFile_LineCount = MyFunctions.StreamAndTextOperate.TextOperate.GetLineCount(TempFile);
                            if (TempFile_LineCount > 15)
                            {
                                for (int g = 1; g <= TempFile_LineCount; g++)
                                {
                                    string ReadLineText = MyFunctions.StreamAndTextOperate.TextOperate.ReadTextInLine(TempFile, g);
                                    if (ReadLineText.Length > 6 && g > 5)
                                    {
                                        if (ReadLineText.Substring(0, 6).ToUpper() == "device".ToUpper())
                                        {
                                            switch (ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim().Substring(0, 3))
                                            {
                                                case "PAR":
                                                    string disk = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim().Replace("partition=".ToUpper(), "");
                                                    string files = MyFunctions.StreamAndTextOperate.TextOperate.ReadTextInLine(TempFile, g + 1).ToUpper().Replace("PATH", "").Trim().ToUpper();
                                                    disk = disk + files;
                                                    if (BootDisk != "") { BootDisk = BootDisk + "\n" + disk; } else { BootDisk = disk; }
                                                    break;
                                                case "VHD":
                                                    string pan = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim().Replace("vhd=[".ToUpper(), "").Substring(0, 2);
                                                    int ganhao = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim().IndexOf("\\");
                                                    string vhdfile = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim();
                                                    vhdfile = vhdfile.Substring(ganhao, vhdfile.Length - ganhao);
                                                    string botfile = pan + vhdfile;
                                                    if (BootDisk != "") { BootDisk = BootDisk + "\n" + botfile; } else { BootDisk = botfile; }
                                                    break;
                                                case "RAM":
                                                    string pan1 = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim().Replace("ramdisk=[".ToUpper(), "").Substring(0, 2);
                                                    if (pan1.ToUpper() == "BO")
                                                    {
                                                        int ganhao1 = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim().IndexOf("\\");
                                                        string ramfile = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim();
                                                        ramfile = ramfile.Substring(ganhao1, ramfile.Length - ganhao1);
                                                        string botfile1 = "[启动的分区]" + ramfile;
                                                        int douhao = botfile1.LastIndexOf(",");
                                                        botfile1 = botfile1.Substring(0, douhao);
                                                        if (BootDisk != "") { BootDisk = BootDisk + "\n" + botfile1; } else { BootDisk = botfile1; }
                                                    }
                                                    else
                                                    {
                                                        int ganhao1 = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim().IndexOf("\\");
                                                        string ramfile = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim();
                                                        ramfile = ramfile.Substring(ganhao1, ramfile.Length - ganhao1);
                                                        string botfile1 = pan1 + ramfile;
                                                        int douhao = botfile1.LastIndexOf(",");
                                                        botfile1 = botfile1.Substring(0, douhao);
                                                        if (BootDisk != "") { BootDisk = BootDisk + "\n" + botfile1; } else { BootDisk = botfile1; }
                                                    }
                                                    break;
                                                case "BOO":
                                                    string diskbot = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim().Replace("partition=".ToUpper(), "");
                                                    if (diskbot.ToUpper() == "BOOT")
                                                    {
                                                        string files1 = MyFunctions.StreamAndTextOperate.TextOperate.ReadTextInLine(TempFile, g + 1).ToUpper().Replace("PATH", "").Trim().ToUpper();
                                                        diskbot = "[启动的分区]" + files1;
                                                    }
                                                    if (BootDisk != "") { BootDisk = BootDisk + "\n" + diskbot; } else { BootDisk = diskbot; }
                                                    break;
                                                case "LOC":
                                                    string diskbotv = "[自动搜索位于启动分区下的虚拟磁盘文件]";
                                                    if (BootDisk != "") { BootDisk = BootDisk + "\n" + diskbotv; } else { BootDisk = diskbotv; }
                                                    break;
                                            }
                                        }
                                    }
                                }
                                if (BootDisk != "") { string[] j = MyFunctions.StreamAndTextOperate.TextOperate.ConvertStringsToStringArry(BootDisk); return j; } else { return null; }
                            }
                            else
                            {
                                return null;
                            }
                        }
                        catch { return null; }
                    }
                    public static string[] BCDOperate_GetBootMenu_GetBootType()
                    {
                        try
                        {
                            string BootDisk = "";
                            string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                            //MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                            //MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, false, true, null);
                            int TempFile_LineCount = MyFunctions.StreamAndTextOperate.TextOperate.GetLineCount(TempFile);
                            if (TempFile_LineCount > 15)
                            {
                                for (int g = 1; g <= TempFile_LineCount; g++)
                                {
                                    string ReadLineText = MyFunctions.StreamAndTextOperate.TextOperate.ReadTextInLine(TempFile, g);
                                    if (ReadLineText.Length > 6 && g > 5)
                                    {
                                        if (ReadLineText.Substring(0, 6).ToUpper() == "device".ToUpper())
                                        {
                                            switch (ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim().Substring(0, 3))
                                            {
                                                case "PAR":
                                                    string disk = "磁盘分区";
                                                    if (BootDisk != "") { BootDisk = BootDisk + "\n" + disk; } else { BootDisk = disk; }
                                                    break;
                                                case "VHD":
                                                    string botfile = "Windows 虚拟磁盘文件";
                                                    if (BootDisk != "") { BootDisk = BootDisk + "\n" + botfile; } else { BootDisk = botfile; }
                                                    break;
                                                case "RAM":
                                                    string botfile1 = "Windows 磁盘映像文件";
                                                    if (BootDisk != "") { BootDisk = BootDisk + "\n" + botfile1; } else { BootDisk = botfile1; }
                                                    break;
                                                case "BOO":
                                                    string disk1 = "磁盘分区";
                                                    if (BootDisk != "") { BootDisk = BootDisk + "\n" + disk1; } else { BootDisk = disk1; }
                                                    break;
                                                case "LOC":
                                                    string botfileV = "Windows 虚拟磁盘文件";
                                                    if (BootDisk != "") { BootDisk = BootDisk + "\n" + botfileV; } else { BootDisk = botfileV; }
                                                    break;
                                            }
                                        }
                                    }
                                }
                                if (BootDisk != "") { string[] j = MyFunctions.StreamAndTextOperate.TextOperate.ConvertStringsToStringArry(BootDisk); return j; } else { return null; }
                            }
                            else
                            {
                                return null;
                            }
                        }
                        catch { return null; }
                    }
                }
                public static Size GetSrceenFenBianLv()
                {
                    Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;
                    int width = rect.Width;
                    int height = rect.Height;
                    System.Drawing.Size t = new Size();
                    t = new Size(width, height);
                    return t;
                }
                /// <summary>
                /// 获取或设置桌面图标的显示状态
                /// </summary>
                /// <param name="icontype">图标模式 [uf]用户的文件 [mc] 计算机 [cp]控制面板 [ie]ie浏览器 [rb]回收站 [nk网络]</param>
                /// <param name="changeshowmode">是否更改图标的显示状态</param>
                /// <param name="showtype">显示的模式 [show]显示 [hide]隐藏</param>
                /// <returns></returns>
                public static bool DesktopIconShowModeMgr(string icontype,bool changeshowmode=false,string showtype="")
                {
                    //获取图标的显示模式
                    return false;
                }
            }
            public class UserInfo
            {
                public static string GetUserSID()
                {
                    try
                    {
                        WindowsIdentity wi = WindowsIdentity.GetCurrent();
                        string sid = wi.User.Value;
                        return sid;
                    }
                    catch { return ""; }
                }
                public static bool GetIsAdministrator()
                {
                    try
                    {
                        WindowsIdentity id = WindowsIdentity.GetCurrent();
                        WindowsPrincipal principal = new WindowsPrincipal(id);
                        return principal.IsInRole(WindowsBuiltInRole.Administrator);
                    }
                    catch { return false; }
                }
            }
            public static void UpdateDesktop()
            {
                try
                {
                    SHChangeNotify(0x8000000, 0, IntPtr.Zero, IntPtr.Zero);
                }
                catch
                {
                }
            }
        }
        public class StreamAndTextOperate
        {
            public class ConvertData
            {
                public static int StringsToInt(string OldString, int DefaultInt32)
                {
                    try
                    {
                        int y = Convert.ToInt32(OldString);
                        return y;
                    }
                    catch
                    {
                        return DefaultInt32;
                    }
                }

            }
            public class StrngOperate
            {
                public static string SuiJiShengChengString(int Length)
                {
                    bool Sleep = false;
                    if (Sleep)
                        System.Threading.Thread.Sleep(3);
                    char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                    string result = "";
                    int n = Pattern.Length;
                    System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
                    for (int i = 0; i < Length; i++)
                    {
                        int rnd = random.Next(0, n);
                        result += Pattern[rnd];
                    }
                    return result;
                }
                public static string ByteOperate(Int64 WantToConvert, string DefaultString)
                {
                    try
                    {
                        const int GB = 1024 * 1024 * 1024;//定义GB的计算常量
                        const int MB = 1024 * 1024;//定义MB的计算常量
                        const int KB = 1024;//定义KB的计算常量
                        if (WantToConvert / GB >= 1)//如果当前Byte的值大于等于1GB
                            return (Math.Round(WantToConvert / (float)GB, 2)).ToString() + "GB";//将其转换成GB
                        else if (WantToConvert / MB >= 1)//如果当前Byte的值大于等于1MB
                            return (Math.Round(WantToConvert / (float)MB, 2)).ToString() + "MB";//将其转换成MB
                        else if (WantToConvert / KB >= 1)//如果当前Byte的值大于等于1KB
                            return (Math.Round(WantToConvert / (float)KB, 2)).ToString() + "KB";//将其转换成KGB
                        else
                            return WantToConvert.ToString() + "Byte";//显示Byte值
                    }
                    catch
                    {
                        return DefaultString;
                    }
                }
                public static string ConvertNoCompeletLocationToTureLocation(string Strings, string DefaultStrings)
                {
                    try
                    {
                        string re = Strings;
                        if (System.IO.File.Exists(Strings) == true)
                        {
                        }
                        else
                        {
                            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + Strings) == true)
                            {
                                re = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\" + Strings;
                            }
                            else
                            {
                                if (System.IO.File.Exists(Environment.GetEnvironmentVariable("windir") + @"\" + Strings) == true)
                                {
                                    re = Environment.GetEnvironmentVariable("windir") + @"\" + Strings;
                                }
                                else
                                {
                                    if (System.IO.File.Exists(Environment.GetEnvironmentVariable("windir") + @"\SysWow64\" + Strings) == true)
                                    {
                                        re = Environment.GetEnvironmentVariable("windir") + @"\SysWow64\" + Strings;
                                    }
                                }
                            }
                        }
                        return re;
                    }
                    catch
                    {
                        return DefaultStrings;
                    }
                }
                //用于将不完整的字符转换为绝对路径,例如将explorer.exe 转为x:\windows\explorer.exe  用法（含有变量的字符，默认的字符）
                public static string ConvertEnviromentStringToTureLocation(string Strings, string DefaultStrings)
                {
                    try
                    {
                        int BAIFENHAO = System.Text.RegularExpressions.Regex.Matches(Strings, "%").Count; //获取字符中百分号的个数
                        if (BAIFENHAO == 2 && System.IO.File.Exists(Strings) != true)
                        {
                            int BAIFENHAOLocation = Strings.IndexOf("%"); //获取第一个%的位置
                            int LastBAIFENHAOLocation = Strings.LastIndexOf("%"); //获取第最后%的位置
                            string Fir = "";
                            if (BAIFENHAOLocation > 0) 
                            { 
                                Fir = Strings.Substring(0, BAIFENHAOLocation); 
                            }
                            string NewString = Strings.Substring(BAIFENHAOLocation, LastBAIFENHAOLocation - (BAIFENHAOLocation - 1));
                            NewString = NewString.Replace("%", "");
                            string NewEnviron;
                            if (NewString.ToUpper() == "APPPATH" || NewString.ToUpper() == "APPEXE")
                            {
                                if (NewString.ToUpper() == "APPPATH")
                                {
                                    NewEnviron = Application.StartupPath;
                                }
                                else
                                {
                                    NewEnviron = Application.ExecutablePath;
                                }
                            }
                            else
                            {
                                NewEnviron = Environment.GetEnvironmentVariable(NewString);
                            }
                            if (NewEnviron == "")
                            {
                                return DefaultStrings;
                            }
                            else
                            {
                                NewString = Strings.Replace(Strings.Substring(BAIFENHAOLocation, LastBAIFENHAOLocation - (BAIFENHAOLocation - 1)), NewEnviron);
                                return Fir+NewString;
                            }
                        }
                        else
                        {
                            return DefaultStrings;
                        }
                    }
                    catch
                    {
                        return DefaultStrings;
                    }
                }
                /// <summary>
                /// 将路径中包含%var%的部分转换为truelocation
                /// </summary>
                /// <param name="Strings">路径 例如"%h%\23.exe"</param>
                /// <param name="var">变量 例如 : h</param>
                /// <param name="truelocation">实际路径 C:\23</param>
                /// <returns></returns>
                public static string ConvertEnviromentStringToTureLocationByZhidingVar(string Strings, string var,string truelocation)
                {
                    try
                    {
                        int BAIFENHAO = System.Text.RegularExpressions.Regex.Matches(Strings, "%").Count; //获取字符中百分号的个数
                        if (BAIFENHAO == 2 && System.IO.File.Exists(Strings) != true)
                        {
                            int BAIFENHAOLocation = Strings.IndexOf("%"); //获取第一个%的位置
                            int LastBAIFENHAOLocation = Strings.LastIndexOf("%"); //获取第最后%的位置
                            string Fir = "";
                            if (BAIFENHAOLocation > 0)
                            {
                                Fir = Strings.Substring(0, BAIFENHAOLocation);
                            }
                            string NewString = Strings.Substring(BAIFENHAOLocation, LastBAIFENHAOLocation - (BAIFENHAOLocation - 1));
                            NewString = NewString.Replace("%", "");
                            string NewEnviron;
                            if (NewString.ToUpper() == "APPPATH")
                            {
                                NewEnviron = Application.StartupPath;
                            }
                            else
                            {
                                if (NewString.ToUpper() == var.ToUpper())
                                {
                                    NewEnviron = truelocation;
                                }
                                else
                                {
                                    NewEnviron = Environment.GetEnvironmentVariable(NewString).ToUpper();
                                }
                            }
                            if (NewEnviron == "")
                            {
                                return Strings;
                            }
                            else
                            {
                                NewString = Strings.Replace(Strings.Substring(BAIFENHAOLocation, LastBAIFENHAOLocation - (BAIFENHAOLocation - 1)), NewEnviron);
                                return Fir+NewString;
                            }
                        }
                        else
                        {
                            return Strings;
                        }
                    }
                    catch
                    {
                        return Strings;
                    }
                } 
                /// <summary>
                /// 用于返回指定字符的个数
                /// </summary>
                /// <param name="Str">查找的字符串</param>
                /// <param name="Sign">指定的字符</param>
                /// <returns></returns>
                public static int GetSignCountInString(string Str,string Sign)
                {
                    int g = System.Text.RegularExpressions.Regex.Matches(Str , Sign ).Count;
                    return g;
                }
            }
            public class TextOperate
            {
                public static int GetLineCount(string FilePath) //获取文本的行数
                {
                    try
                    {
                        string[] rows = System.IO.File.ReadAllLines(FilePath);
                        int h = rows.Length;
                        return h;
                    }
                    catch
                    {
                        return 0;
                    }
                }
                public static string[] ConvertStringsToStringArry(string String)
                {
                    try
                    {
                        string strContext = String;
                        string[] str;
                        if (!strContext.Equals(""))
                        {
                            str = strContext.Split("\r\n".ToCharArray());
                            return str;
                        }
                        else { return null; }
                    }
                    catch { return null; }
                } //将文本转为数组
                /// <summary>
                /// 根据fenge的内容将以fenge为分隔符的字符串转换为数组
                /// </summary>
                /// <param name="String">包含fenge的字符</param>
                /// <param name="fenge">分割字符的内容</param>
                /// <returns></returns>
                public static string[] ConvertStringsToStringArry_ByString(string String,string fenge)
                {
                    try
                    {
                        string strContext = String;
                        string[] str;
                        if (!strContext.Equals(""))
                        {
                            str = strContext.Split(fenge.ToCharArray());
                            return str;
                        }
                        else { return null; }
                    }
                    catch { return null; }
                } //将文本转为数组
                public static string ReadTextInLine(string FilePath, int Line) //读取制定行
                {
                    try
                    {
                        StreamReader strr = new System.IO.StreamReader(FilePath, System.Text.Encoding.GetEncoding("gb2312"));
                        string[] s = strr.ReadToEnd().Split('\n');
                        string p = s[Line - 1];
                        strr.Close();
                        return p;
                    }
                    catch { return ""; }
                }
                public static void CreateRunAsAdminVBS() //创建RunAsAdmin.vbs
                {
                    try
                    {
                        string TXT = Properties.Resources.RunAsAdmin;
                        if (System.IO.Directory.Exists(Application.StartupPath + @"\Programs") == false)
                        {
                            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Programs");
                        }
                        System.IO.File.Delete(Application.StartupPath + @"\Programs\RunAsAdmin.vbs");
                        StreamWriter sw = new StreamWriter(Application.StartupPath + @"\Programs\RunAsAdmin.vbs", true, Encoding.Unicode);
                        sw.Write(TXT); sw.Flush(); sw.Close();
                    }
                    catch
                    {
                    }
                }
                public static bool SaveTextFile(string FileName, string Strings)
                {
                    try
                    {
                        //使用“另存为”对话框中输入的文件名实例化StreamWriter对象
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(FileName);
                        StreamWriter sw = new StreamWriter(FileName, true, Encoding.Unicode);
                        //向创建的文件中写入内容
                        sw.WriteLine(Strings);
                        //关闭当前文件写入流
                        sw.Close();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                public class GUIDOperate
                {
                    public static string GUIDOperate_GetGUIDRegistryName(string GUID)
                    {
                        try
                        {
                            ///
                            string DOWN_GUID = "{374DE290-123F-4565-9164-39C4925E467B}";
                            string DESK_GUID = "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";
                            string MUSI_GUID = "{1CF1260C-4DD0-4ebb-811F-33C572699FDE}";
                            string IMAG_GUID = "{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}";
                            string VIDE_GUID = "{A0953C92-50DC-43bf-BE83-3742FED03C9C}";
                            string DOCE_GUID = "{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}";
                            string SKYD_GUID = "{8e74d236-7f35-4720-b138-1fed0b85ea75}";
                            string HUIF_GUID = "{B98A2BEA-7D42-4558-8BD1-832F41BAC6FD}";
                            string SHEN_GUID = "{0142e4d0-fb7a-11dc-ba4a-000ffe7ab428}";
                            if (GUID.ToUpper() == DOWN_GUID.ToUpper()) { return "下载"; }
                            if (GUID.ToUpper() == DESK_GUID.ToUpper()) { return "桌面"; }
                            if (GUID.ToUpper() == MUSI_GUID.ToUpper()) { return "音乐"; }
                            if (GUID.ToUpper() == IMAG_GUID.ToUpper()) { return "图片"; }
                            if (GUID.ToUpper() == VIDE_GUID.ToUpper()) { return "视频"; }
                            if (GUID.ToUpper() == DOCE_GUID.ToUpper()) { return "文档"; }
                            if (GUID.ToUpper() == SKYD_GUID.ToUpper()) { return "SkyDrive"; }
                            if (GUID.ToUpper() == HUIF_GUID.ToUpper()) { return "Windows 7 文件恢复"; }
                            if (GUID.ToUpper() == SHEN_GUID.ToUpper()) { return "生物特征设备"; }
                            ///
                            string sgcf = Application.StartupPath + @"\config\systemgear_guidsinfo.sgcf";
                            int count = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "count", "0", false, sgcf), 0);
                            for (int h = 1; h < count; h++)
                            {
                                string guid = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("guid" + h.ToString(), "guid", "", false, sgcf);
                                if (guid.ToUpper() == GUID.ToUpper())
                                {
                                    string NAME = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("GUID" + h.ToString(), "name", "", false, sgcf);
                                    if (GUID.ToUpper() == "{20d04fe0-3aea-1069-a2d8-08002b30309d}".ToUpper() && MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3")
                                    {
                                        NAME = "这台电脑";
                                    }
                                    return NAME;
                                }
                            }
                            string NAME1 = "";
                            NAME1 = MyFunctions.RegistryOperate.RegistryOperate_GetValue(Registry.ClassesRoot, @"clsid\" + GUID, "", "", false, false);
                            return NAME1;
                        }
                        catch { return ""; }
                    }
                    public static string GUIDOperate_GetGUIDRegistryIcon(string GUID)
                    {
                        try
                        {
                            string DOWN_GUID = "{374DE290-123F-4565-9164-39C4925E467B}";
                            string DESK_GUID = "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";
                            string MUSI_GUID = "{1CF1260C-4DD0-4ebb-811F-33C572699FDE}";
                            string IMAG_GUID = "{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}";
                            string VIDE_GUID = "{A0953C92-50DC-43bf-BE83-3742FED03C9C}";
                            string DOCE_GUID = "{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}";
                            string SKYD_GUID = "{8e74d236-7f35-4720-b138-1fed0b85ea75}";
                            string HUIF_GUID = "{B98A2BEA-7D42-4558-8BD1-832F41BAC6FD}";
                            string SHEN_GUID = "{0142e4d0-fb7a-11dc-ba4a-000ffe7ab428}";
                            if (GUID.ToUpper() == DOWN_GUID.ToUpper()) { return @"%SystemRoot%\System32\Imageres.dll,175"; }
                            if (GUID.ToUpper() == DESK_GUID.ToUpper()) { return @"%SystemRoot%\System32\Imageres.dll,174"; }
                            if (GUID.ToUpper() == MUSI_GUID.ToUpper()) { return @"%SystemRoot%\System32\Imageres.dll,103"; }
                            if (GUID.ToUpper() == IMAG_GUID.ToUpper()) { return @"%SystemRoot%\System32\Imageres.dll,108"; }
                            if (GUID.ToUpper() == VIDE_GUID.ToUpper()) { return @"%SystemRoot%\System32\Imageres.dll,178"; }
                            if (GUID.ToUpper() == DOCE_GUID.ToUpper()) { return @"%SystemRoot%\System32\Imageres.dll,107"; }
                            if (GUID.ToUpper() == SKYD_GUID.ToUpper()) { return @"%SystemRoot%\System32\Imageres.dll,216"; }
                            if (GUID.ToUpper() == HUIF_GUID.ToUpper()) { return @"%SystemRoot%\System32\sdcpl.dll,0"; }
                            if (GUID.ToUpper() == SHEN_GUID.ToUpper()) { return @"%SystemRoot%\System32\biocpl.dll,0"; }
                            string sgcf = Application.StartupPath + @"\config\systemgear_guidsinfo.sgcf";
                            int count = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "count", "0", false, sgcf), 0);
                            for (int h = 1; h < count; h++)
                            {
                                string guid = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("guid" + h.ToString(), "guid", "", false, sgcf);
                                if (guid.ToUpper() == GUID.ToUpper())
                                {
                                    string icon = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("GUID" + h.ToString(), "icon", "", false, sgcf);
                                    return icon;
                                }
                            }
                            return "";
                        }
                        catch { return ""; }
                    }
                }
            }
            public class IntOperate
            {
                public static bool VeifyIntIsNotStrings(string Strings) //判断是否是数字
                {
                    try
                    {
                        int k = Convert.ToInt32(Strings);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            public class ConfigFileOperate
            {
                public static string SGCFFileOperate_GetValue(string Section, string Key, string DefaultValue, bool ConvertSystemVar, string MCFFile)
                {
                    if (System.IO.File.Exists(MCFFile) == true)
                    {
                        StringBuilder temp = new StringBuilder(500);
                        int i = GetPrivateProfileString(Section, Key, DefaultValue, temp, 500, MCFFile);
                        string STR = temp.ToString();
                        if (STR.Length > 0)
                        {
                            STR= STR.Substring(1, STR.Length - 1);
                            STR = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(STR, STR);
                        }
                        return STR;
                    }
                    else
                    {
                        return DefaultValue;
                    }
                }//读取MCF配置文件

                public static void SGCFFileOperate_WriteValue(string Section, string Key, string Value, string FileType, bool ConvertSystemVarToTrueLocation, string MCFFile)
                {
                    //string newmcf = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(MCFFile, MCFFile);
                    WritePrivateProfileString("SystemGear", "Version", "#" + Application.ProductVersion.ToString(), MCFFile);
                    WritePrivateProfileString("SystemGear", "FileType", "#" + FileType, MCFFile);
                    string Keyf = Value;
                    if (ConvertSystemVarToTrueLocation == true)
                    {
                        Keyf = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(Keyf, Keyf);
                    }
                    WritePrivateProfileString(Section, Key, "#" + Keyf, MCFFile);
                } //写入MCFFile
                public static void ConfigFileOperate_WriteValue(string Section, string Key, string Value, bool ConvertSystemVarToTrueLocation, string FileName)
                {
                    //string newmcf = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(MCFFile, MCFFile);;
                    string Keyf = Value;
                    if (ConvertSystemVarToTrueLocation == true)
                    {
                        Keyf = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(Keyf, Keyf);
                    }
                    WritePrivateProfileString(Section, Key, Keyf, FileName);
                } //写入MCFFile
                public static string ConfigFileOperate_GetValue(string Section, string Key, string DefaultValue, bool ConvertSystemVar, string MCFFile)
                {
                    if (System.IO.File.Exists(MCFFile) == true)
                    {
                        StringBuilder temp = new StringBuilder(500);
                        int i = GetPrivateProfileString(Section, Key, DefaultValue, temp, 500, MCFFile);
                        string STR = temp.ToString();
                        if (ConvertSystemVar == true)
                        {
                            STR = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(STR, temp.ToString());
                        }
                        return STR;
                    }
                    else
                    {
                        return DefaultValue;
                    }
                } //读取MCF配置文件
            }
        }
        public class MediaAndResourcesOperate
        {
            #region 读取MUI的API
            [DllImport("kernel32.dll")]
            static extern uint GetThreadLocale();
            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern IntPtr LoadLibrary(string lpFileName);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern IntPtr LoadString(IntPtr hInstance, uint uID, StringBuilder lpBuffer, int nBufferMax);
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern int GetLocaleInfo(uint Locale, uint LCType,
               [Out] StringBuilder lpLCData, int cchData);
            public const int LOCALE_IDEFAULTANSICODEPAGE = 0x00001004;
            public const int LOCALE_SENGCOUNTRY = 0x00001002;
            public const int LOCALE_SNATIVECTRYNAME = 0x00000008;
            public const int LOCALE_SCOUNTRY = 0x00000006;
            public static int GetCharSet(string sCdpg)
            {
                int sd = 0;
                switch (sCdpg)
                {
                    case "936": // Simplified Chinese
                        sd = 134;
                        break;
                    case "950":// Traditional Chinese
                        sd = 136;
                        break;
                    default:
                        sd = 0;
                        break;
                }
                return sd;
            }
            public static StringBuilder StripNullTerminator(string sCP)
            {
                StringBuilder s = new StringBuilder(255);
                int posNull = sCP.Length;
                //posNull = sCP.IndexOf(null);
                return s.Append(sCP.Substring(0, posNull - 1));
            }
            #endregion
            public class LoadResources
            {
                public static Bitmap LoadResources_GetBitmap(string file, int resourcesid, string resourcestype)
                {
                    try
                    {
                        string path = file;
                        IntPtr hMod = LoadLibraryEx(path, IntPtr.Zero, LOAD_LIBRARY_AS_DATAFILE);
                        IntPtr hRes = FindResource(hMod, resourcesid, resourcestype);
                        uint size = SizeofResource(hMod, hRes);
                        IntPtr pt = LoadResource(hMod, hRes);
                        byte[] bPtr = new byte[size];
                        Marshal.Copy(pt, bPtr, 0, (int)size);
                        Bitmap  bmp;
                        using (System.IO.MemoryStream m = new System.IO.MemoryStream(bPtr))
                            bmp = (Bitmap)Bitmap.FromStream(m);
                        Bitmap n = new Bitmap(bmp);
                        bmp.Dispose();
                        return n;
                    }
                    catch { return null; }
                
                }
                /// <summary>
                /// Returns an icon of given size.
                /// </summary>
                /// <param name="path">文件的路径.
                ///        跳过这个步骤则返回当前程序的图标</param>
                /// <param name="resId">资源的ID 例如 "#109"
                ///        Skip it to use the default <c>#32512</c> (value of <c>IDI_APPLICATION</c>) to use
                ///        the application's icon.</param>
                /// <param name="size">图标的大小 例如 32 64 128 256都可以
                ///        sized-icon is scaled.</param>
                /// <returns>List of all icons.</returns>
                public static Icon LoadResources_GetIcon(string path = null, string resId = "#32512", int size = 32)
                {
                    // load module
                    IntPtr h;
                    if (path == null)
                        h = Marshal.GetHINSTANCE(System.Reflection.Assembly.GetEntryAssembly().GetModules()[0]);
                    else
                    {
                        h = LoadLibraryEx(path, IntPtr.Zero, LoadLibraryFlags.LOAD_LIBRARY_AS_DATAFILE);
                        if (h == IntPtr.Zero)
                            return null;
                    }

                    // 1 is IMAGE_ICON
                    IntPtr ptr = LoadImage(h, resId, 1, size, size, 0);
                    if (ptr != IntPtr.Zero)
                    {
                        try
                        {
                            Icon icon = (Icon)Icon.FromHandle(ptr).Clone();
                            return icon;
                        }
                        finally
                        {
                            DestroyIcon(ptr);
                        }
                    }
                    return null;
                }
                /// <summary>
                /// 读取EXE DLL的语言
                /// </summary>
                /// <param name="ExeOrDllfile">文件路径 例如"C:\MY.DLL" 自动查找MUI文件</param>
                /// <param name="ID">语言ID 例如 400</param>
                /// <returns></returns>
                public static string LoadResources_GetMUIString(string ExeOrDllfile,uint ID)
                {
                    try
                    {

                        string ReturnString = "";
                        string resfile;
                        resfile = GetDLLOrExeMUIFilePath(ExeOrDllfile);
                        uint id = ID;
                        long x;
                        System.IntPtr hInst;
                        string sLcid;
                        uint LCID;
                        StringBuilder resString = new StringBuilder(255);
                        StringBuilder sCodePage = new StringBuilder(255);
                        sCodePage.Append("16");
                        //sCodePage ="16";
                        LCID = GetThreadLocale(); //Get Current locale
                        sLcid = Convert.ToString(LCID, 16);
                        x = GetLocaleInfo(LCID, LOCALE_IDEFAULTANSICODEPAGE, sCodePage, sCodePage.Length);  //Get code page
                        sCodePage = StripNullTerminator(sCodePage.ToString());
                        hInst = LoadLibrary(resfile);
                        hInst = LoadString(hInst, id, resString, 255);
                        ReturnString = resString.ToString();
                        return ReturnString;
                    }
                    catch { return ExeOrDllfile; }
                }
                private  static string GetDLLOrExeMUIFilePath(string path)
                {
                    try
                    {
                        string f = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(path, path);
                        if(System.IO.File.Exists(f)==true)
                        {
                            FileInfo fi = new FileInfo(f);
                            string filename = fi.Name;
                            string folder = fi.DirectoryName;
                            string f1 = folder +"\\"+ filename + ".mui";
                            string f2 = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\zh-cn\\"+filename  +".mui";
                            if (System.IO.File.Exists(f1) == true) { return f1; }
                            if (System.IO.File.Exists(f2) == true) { return f2; }
                            return path;
                        }
                        else
                        {
                            return path;
                        }
                    }
                    catch { return path; }
                }
            }
            #region 这是预置函数
            private static void GetDI(out Icon largeIcon, out Icon smallIcon)
            {
                largeIcon = smallIcon = null;
                System.IntPtr phiconLarge = new IntPtr();
                System.IntPtr phiconSmall = new IntPtr();
                ExtractIconExW(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 0, ref phiconLarge, ref phiconSmall, 1);
                if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
                if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct SHFILEINFO
            {
                public IntPtr hIcon;
                public IntPtr iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                public string szTypeName;
            }
            /// <summary>   
            /// 返回系统设置的图标   
            /// </summary>   
            /// <param name="pszPath">文件路径 如果为"" 返回文件夹的</param>   
            /// <param name="dwFileAttributes">0</param>   
            /// <param name="psfi">结构体</param>   
            /// <param name="cbSizeFileInfo">结构体大小</param>   
            /// <param name="uFlags">枚举类型</param>   
            /// <returns>-1失败</returns>   
            [DllImport("shell32.dll")]
            private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref   SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

            public enum SHGFI
            {
                SHGFI_ICON = 0x100,
                SHGFI_LARGEICON = 0x0,
                SHGFI_USEFILEATTRIBUTES = 0x10
            }


            [DllImportAttribute("shell32.dll", EntryPoint = "ExtractIconExW", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            private static extern uint ExtractIconExW([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(UnmanagedType.LPWStr)] string lpszFile, int nIconIndex, ref IntPtr phiconLarge, ref IntPtr phiconSmall, uint nIcons);
            private static void GetWithGan(string IconWithIndexAllowWithGanHao, out Icon largeIcon, out Icon smallIcon)
            {
                GetDefaultIcon(out largeIcon, out smallIcon);   //得到缺省图标  
                string defaulticon = IconWithIndexAllowWithGanHao;
                if (defaulticon == null) return;
                string[] iconstringArray = defaulticon.Split(',');
                int nIconIndex = 0; //声明并初始化图标索引  
                if (iconstringArray.Length > 1)
                    if (!int.TryParse(iconstringArray[1], out nIconIndex))
                        nIconIndex = 0;     //int.TryParse转换失败，返回0  

                //得到图标  
                System.IntPtr phiconLarge = new IntPtr();
                System.IntPtr phiconSmall = new IntPtr();
                ExtractIconExW(iconstringArray[0].Trim('"'), nIconIndex, ref phiconLarge, ref phiconSmall, 1);
                if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
                if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
            }
            private static void GetDefaultIcon(out Icon largeIcon, out Icon smallIcon)
            {
                largeIcon = smallIcon = null;
                System.IntPtr phiconLarge = new IntPtr();
                System.IntPtr phiconSmall = new IntPtr();
                ExtractIconExW(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 0, ref phiconLarge, ref phiconSmall, 1);
                if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
                if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
            }
            private static void GetGUIDIcon(string GUID, out Icon largeIcon, out Icon smallIcon)
            {
                GetDefaultIcon(out largeIcon, out smallIcon);   //得到缺省图标  
                RegistryKey extsubkey = Registry.ClassesRoot.OpenSubKey("clsid\\" + GUID);  //从注册表中读取扩展名相应的子键  
                if (extsubkey == null) return;
                string defaulticon;
                //得到图标来源字符串  
                defaulticon = extsubkey.OpenSubKey("defaulticon").GetValue("") as string;
                if (defaulticon == null) return;
                string[] iconstringArray = defaulticon.Split(',');
                int nIconIndex = 0; //声明并初始化图标索引  
                if (iconstringArray.Length > 1)
                    if (!int.TryParse(iconstringArray[1], out nIconIndex))
                        nIconIndex = 0;     //int.TryParse转换失败，返回0  

                //得到图标  
                System.IntPtr phiconLarge = new IntPtr();
                System.IntPtr phiconSmall = new IntPtr();
                ExtractIconExW(iconstringArray[0].Trim('"'), nIconIndex, ref phiconLarge, ref phiconSmall, 1);
                if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
                if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
            }
            private static void GetExtsIconAndDescription(string ext, out Icon largeIcon, out Icon smallIcon, out string description)
            {
                GetDefaultIcon(out largeIcon, out smallIcon);   //得到缺省图标  
                description = "";                               //缺省类型描述  
                RegistryKey extsubkey = Registry.ClassesRoot.OpenSubKey(ext);   //从注册表中读取扩展名相应的子键  
                if (extsubkey == null) return;

                string extdefaultvalue = extsubkey.GetValue(null) as string;     //取出扩展名对应的文件类型名称  
                if (extdefaultvalue == null) return;

                if (extdefaultvalue.Equals("exefile", StringComparison.OrdinalIgnoreCase))  //扩展名类型是可执行文件  
                {
                    RegistryKey exefilesubkey = Registry.ClassesRoot.OpenSubKey(extdefaultvalue);  //从注册表中读取文件类型名称的相应子键  
                    if (exefilesubkey != null)
                    {
                        string exefiledescription = exefilesubkey.GetValue(null) as string;   //得到exefile描述字符串  
                        if (exefiledescription != null) description = exefiledescription;
                    }
                    System.IntPtr exefilePhiconLarge = new IntPtr();
                    System.IntPtr exefilePhiconSmall = new IntPtr();
                    ExtractIconExW(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 2, ref exefilePhiconLarge, ref exefilePhiconSmall, 1);
                    if (exefilePhiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(exefilePhiconLarge);
                    if (exefilePhiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(exefilePhiconSmall);
                    return;
                }

                RegistryKey typesubkey = Registry.ClassesRoot.OpenSubKey(extdefaultvalue);  //从注册表中读取文件类型名称的相应子键  
                if (typesubkey == null) return;

                string typedescription = typesubkey.GetValue(null) as string;   //得到类型描述字符串  
                if (typedescription != null) description = typedescription;

                RegistryKey defaulticonsubkey = typesubkey.OpenSubKey("DefaultIcon");  //取默认图标子键  
                if (defaulticonsubkey == null) return;

                //得到图标来源字符串  
                string defaulticon = defaulticonsubkey.GetValue(null) as string; //取出默认图标来源字符串  
                if (defaulticon == null) return;
                string[] iconstringArray = defaulticon.Split(',');
                int nIconIndex = 0; //声明并初始化图标索引  
                if (iconstringArray.Length > 1)
                    if (!int.TryParse(iconstringArray[1], out nIconIndex))
                        nIconIndex = 0;     //int.TryParse转换失败，返回0  

                //得到图标  
                System.IntPtr phiconLarge = new IntPtr();
                System.IntPtr phiconSmall = new IntPtr();
                ExtractIconExW(iconstringArray[0].Trim('"'), nIconIndex, ref phiconLarge, ref phiconSmall, 1);
                if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
                if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
            }
            #endregion
            public class ImageOperate
            {
              
                public static Icon GetFileIcon(string FilePath)
                {
                    try
                    {
                        if (System.IO.File.Exists(FilePath) == true)
                        {
                            SHFILEINFO _SHFILEINFO = new SHFILEINFO();
                            IntPtr _IconIntPtr = SHGetFileInfo(FilePath, 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), (uint)(SHGFI.SHGFI_ICON | SHGFI.SHGFI_LARGEICON | SHGFI.SHGFI_USEFILEATTRIBUTES));
                            if (_IconIntPtr.Equals(IntPtr.Zero)) return null;
                            Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
                            return _Icon;
                        }
                        else
                        {
                            Icon i;
                            Icon s;
                            MyFunctions.MediaAndResourcesOperate.GetDI(out i, out s);
                            return i;
                        }
                    }
                    catch
                    {
                        Icon i;
                        Icon s;
                        MyFunctions.MediaAndResourcesOperate.GetDI(out i, out s);
                        return i;
                    }
                }
                public static Icon GetFolderOrDiskIcon(string Folder)
                {
                    SHFILEINFO _SHFILEINFO = new SHFILEINFO();
                    IntPtr _IconIntPtr = SHGetFileInfo(Folder, 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), (uint)(SHGFI.SHGFI_ICON | SHGFI.SHGFI_LARGEICON));
                    if (_IconIntPtr.Equals(IntPtr.Zero)) return null;
                    Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
                    return _Icon;
                }
                /// <summary>
                /// 读取图标
                /// </summary>
                /// <param name="FileLocationWithIndex">图标位置以及索引号 例如"C:\WIN.DLL,2"或 "c:\3.dll,-5"</param>
                /// <param name="DefaultIcon">默认的图标</param>
                /// <param name="iconsize">图标大小 (仅支持从资源读取的图标 例如"c:\2.exe,-5") 大小 32(缺省) 64 72 96 128 256 </param>
                /// <returns></returns>
                public static System.Drawing.Bitmap ImageOperate_LoadIconsFormResourcesFileIcon(string FileLocationWithIndex, string DefaultIcon,int iconsize=32)
                {
                    //获取文件的路径
                    try
                    {
                        string fullstr = FileLocationWithIndex;
                        string filename;
                        string fullindex;
                        fullstr = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(fullstr, fullstr);
                        if (fullstr.LastIndexOf(",") < 0 && fullstr.Length ==0)
                        {
                            filename = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll";
                            fullindex = "2";
                        }
                        else
                        {
                            if(fullstr.LastIndexOf(",") <0 && fullstr !="")
                            {
                                filename = fullstr;
                                filename = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertNoCompeletLocationToTureLocation(filename, filename);
                                fullindex = "0";
                            }
                            else
                            {
                                filename = fullstr.Substring(0, fullstr.LastIndexOf(","));
                                filename = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertNoCompeletLocationToTureLocation(filename, filename);
                                fullindex = fullstr.Substring(fullstr.LastIndexOf(",") + 1, fullstr.Length - fullstr.LastIndexOf(",") - 1);
                            }
                        }
                        if (fullindex.Substring(0, 1) == "-")
                        {
                            int index;
                            int.TryParse(fullindex.Replace("-",""),out index);
                            //从资源读取
                            filename = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertNoCompeletLocationToTureLocation(filename, filename);
                            Icon b = MyFunctions.MediaAndResourcesOperate.LoadResources.LoadResources_GetIcon(filename, "#" + index,iconsize);
                            return b.ToBitmap();
                        }
                        else
                        {
                            //普通读取
                            Icon la1, lk;
                            MyFunctions.MediaAndResourcesOperate.GetWithGan(filename +","+fullindex, out la1, out lk);
                            return la1.ToBitmap();
                        }
                    }
                    catch
                    {
                        Icon la1, lk;
                        MyFunctions.MediaAndResourcesOperate.GetWithGan(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageresdll,2", out la1, out lk);
                        return la1.ToBitmap();
                    }
                } //加载资源中的图标
                public static bool ImageOperate_SaveImageAsFile(System.Drawing.Image OrgImage, System.Drawing.Imaging.ImageFormat ImageExtraName, int ImageW, int ImageH, string FileName)
                {
                    try
                    {
                        System.Drawing.Bitmap g2 = new Bitmap(OrgImage, ImageW, ImageH);
                        g2.Save(FileName, ImageExtraName);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                public static bool ImageOperate_ConvetImage(System.Drawing.Image OrgImage, System.Drawing.Imaging.ImageFormat ImageExtraName, int ImageW, int ImageH, string FileName)
                {
                    try
                    {
                        System.Drawing.Bitmap g2 = new Bitmap(OrgImage, ImageW, ImageH);
                        g2.Save(FileName, ImageExtraName);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            public class AudioOperate
            {
                public static void PlaySound(string SoundFile)
                {
                    try
                    {
                        System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                        sp.SoundLocation = SoundFile;
                        sp.Play();
                    }
                    catch
                    {
                    }
                }
            }
            public class ColorOperate
            {
                /// <summary>
                /// 将RGB颜色转为16进制颜色 例如ff000000
                /// </summary>
                /// <param name="ColorFromRGB">RGB颜色</param>
                /// <returns></returns>
                public static string  Convert_ColorRGBtoHx16(Color ColorFromRGB)
                {
                    try
                    {
                        /*
                        Color color = ColorFromRGB;
                        string R = Convert.ToString(color.R, 16);
                        if (R == "0")
                            R = "00";
                        string G = Convert.ToString(color.G, 16);
                        if (G == "0")
                            G = "00";
                        string B = Convert.ToString(color.B, 16);
                        if (B == "0")
                            B = "00";
                        string HexColor =  R + G + B;
                        //uint u = (uint)(((uint)color.B << 16) | (ushort)(((ushort)color.G << 8) | color.R));
                        //return "0xff"+u.ToString();
                        */
                        Color RGB = Color.FromArgb(255, ColorFromRGB);
                        int g = ColorTranslator.ToWin32(RGB);
                        string j = Convert.ToString(g, 16);
                        return j;
                    }
                    catch
                    {
                        return "ff000000";
                    }
                }
                /// <summary>
                /// 用于获取指定颜色缩小或增大deep个单位的之后的颜色
                /// </summary>
                /// <param name="color">指定的颜色</param>
                /// <param name="deep">深度</param>
                /// <returns></returns>
                public static Color  GetColorInDeep(Color color,int deep)
                {
                    try
                    {
                        int r, g, b;
                        //r
                        if(color.R +deep >255)
                        {
                            r = color.R - deep;
                        }
                        else
                        {
                            r = color.R + deep;
                        }
                        //g
                        if (color.G + deep > 255)
                        {
                            g = color.G - deep;
                        }
                        else
                        {
                            g = color.G + deep;
                        }
                        //b
                        if (color.B + deep > 255)
                        {
                            b = color.B - deep;
                        }
                        else
                        {
                            b = color.B + deep;
                        }
                        return Color.FromArgb(r, g, b);
                    }
                    catch { return color; }
                }
            }
        }
        public class RegistryOperate
        {
            public static bool RegistryOperate_SetValue(RegistryKey RootKey, string Location, string NewValueName, string Value, RegistryValueKind ValueKind, bool HasVar, bool HasErrorDialog)
            {
                try
                {
                    if (null == RootKey.OpenSubKey(Location, true))
                    {
                        RootKey.CreateSubKey(Location);
                    }
                    string Newv = Value;
                    if (HasVar == true)
                    {
                        Newv = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(Value, "");
                    }
                    RootKey.OpenSubKey(Location, true).SetValue(NewValueName, Newv, ValueKind);
                    return true;
                }
                catch (Exception rr)
                {
                    if (HasErrorDialog == true)
                    {
                        MyFunctions.Dialogs.MessageDialog("访问系统注册表错误", "无法在 " + RootKey.ToString() + @"\" + Location + "创建  " + NewValueName + "的注册表数值.请检查您的操作系统或以管理员的权限运行本程序", MyFunctions.Dialogs.MessageDialogIcon.Error, rr.Message.ToString(), "b2", false, true, "", "确定");
                    }
                    return false;
                }
            }
            public static bool RegistryOperate_DeleteValue(RegistryKey RootKey, string Location, string ValueName)
            {
                try
                {
                    RootKey.OpenSubKey(Location, true).DeleteValue(ValueName, false);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            public static bool RegistryOperate_CreateSubKey(RegistryKey RootKey, string Location, string NewSubKeyName, bool HasErrorDialog)
            {
                try
                {
                    if (null == RootKey.OpenSubKey(Location, true))
                    {
                        RootKey.CreateSubKey(Location);
                    }
                    RootKey.OpenSubKey(Location, true).CreateSubKey(NewSubKeyName);
                    return true;
                }
                catch (Exception rr)
                {
                    if (HasErrorDialog == true)
                    {
                        MyFunctions.Dialogs.MessageDialog("访问系统注册表错误", "无法在 " + RootKey.ToString() + @"\" + Location + "创建名为" + NewSubKeyName + "的注册表项.请检查您的操作系统或以管理员的权限运行本程序", MyFunctions.Dialogs.MessageDialogIcon.Error, rr.Message.ToString(), "b2", false, true, "", "确定");
                    }
                    return false;
                }
            }
            public static bool RegistryOperate_DeleteSubKey(RegistryKey RootKey, string Location, string SubKeyName, bool HasErrorDialog)
            {
                try
                {
                    if (null == RootKey.OpenSubKey(Location, true))
                    {
                        RootKey.CreateSubKey(Location);
                    }
                    RootKey.OpenSubKey(Location, true).DeleteSubKeyTree(SubKeyName);
                    return true;
                }
                catch (Exception rr)
                {
                    if (HasErrorDialog == true)
                    {
                        MyFunctions.Dialogs.MessageDialog("访问系统注册表错误", "无法在 " + RootKey.ToString() + @"\" + Location + "删除名为" + SubKeyName + "的注册表项.请检查您的操作系统或以管理员的权限运行本程序", MyFunctions.Dialogs.MessageDialogIcon.Error, rr.Message.ToString(), "b2", false, true, "", "确定");
                    }
                    return false;
                }
            }
            public static string RegistryOperate_GetValue(RegistryKey RootKey, string Location, string ValueName, string DefaultValue, bool HasVar, bool HasErrorDialog)
            {
                try
                {
                    if (null == RootKey.OpenSubKey(Location))
                    {
                        RootKey.CreateSubKey(Location);
                    }
                    string getval = RootKey.OpenSubKey(Location).GetValue(ValueName, DefaultValue).ToString();
                    if (HasVar == true)
                    {
                        getval = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(getval, "");
                    }
                    return getval;
                }
                catch (Exception rr)
                {
                   // MessageBox.Show("");
                    if (HasErrorDialog == true)
                    {
                        MyFunctions.Dialogs.MessageDialog("访问系统注册表错误", "无法读取 " + RootKey.ToString() + @"\" + Location + "下的名为 " + ValueName + "的注册表数值.请检查您的操作系统或以管理员的权限运行本程序", MyFunctions.Dialogs.MessageDialogIcon.Error, rr.Message.ToString(), "b2", false, true, "", "确定");
                    }
                    string getval1 = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(DefaultValue, "");
                    return getval1;
                }
            }
            public static string[] RegistryOperate_GetSubkeys(RegistryKey RootKey, string Location)
            {
                try
                {
                    string[] h = RootKey.OpenSubKey(Location).GetSubKeyNames();
                    return h;
                }
                catch
                {
                    string[] g = new string[1];
                    g[0] = "";
                    return g;
                }
            }
        }
        public class FileSystemOperate
        {
            public static bool FileSystemOperate_DeleteFolder(string FolderPath, bool DeleteAllFilesAndFolders)
            {
                try
                {
                    string fol = FolderPath;
                    if (System.IO.Directory.Exists(fol) == false)
                    {
                        fol = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(fol, fol);
                    }
                    if (DeleteAllFilesAndFolders == true)
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c rd /s /q """ + FolderPath + @"""", true, false, true, false, true);
                    }
                    else { MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c rd /q """ + FolderPath + @"""", true, false, true, false, true); }
                    return true;
                }
                catch { return false; }
            }
            public static bool FileSystemOperate_GetFileExists(string FileName)
            {
                if (System.IO.File.Exists(FileName) == true)
                {
                    return true;
                }
                else
                {
                    if (System.IO.File.Exists(MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(FileName, "")) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            public static bool FileSystemOperate_DeleteFile(string FileName)
            {
                try
                {
                    if (System.IO.File.Exists(FileName) == true)
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_SetFileAttribute(FileName, FileAttributes.Normal);
                        System.IO.File.Delete(FileName);
                        return true;
                    }
                    else
                    {
                        if (System.IO.File.Exists(MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(FileName, "")) == true)
                        {
                            MyFunctions.FileSystemOperate.FileSystemOperate_SetFileAttribute(MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(FileName, ""), FileAttributes.Normal);
                            System.IO.File.Delete(MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(FileName, ""));
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
            public static bool FileSystemOperate_FolderOrDriveCanWrites(string Path)
            {
                try
                {
                    bool p = MyFunctions.StreamAndTextOperate.TextOperate.SaveTextFile(Path + @"\Temp.txt", "temp");
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(Path + @"\Temp.txt");
                    return p;
                }
                catch { return false; }
            }
            public static void FileSystemOperate_OpenFileLocationWithExplorer(string FilePath)
            {
                try
                {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("explorer.exe", @"/e,/select,""" + FilePath + @"""", false, false, false, false, false);
                }
                catch { }
            }
            public static string[] FileSystemOperate_GetFiles(string OrgFolderPath, string Filter, System.IO.SearchOption GetType)
            {
                string[] files = System.IO.Directory.GetFiles(OrgFolderPath, Filter, GetType);
                return files;
            }
            public static string[] FileSystemOperate_GetFolders(string OrgFolderPath, string Filter, System.IO.SearchOption GetType)
            {
                string[] files = System.IO.Directory.GetDirectories(OrgFolderPath, Filter, GetType);
                return files;
            }
            public static bool FileSystemOperate_CreateNewFolder(string FolderPath)
            {
                try
                {
                    if (System.IO.Directory.Exists(MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(FolderPath, FolderPath)) != true)
                    {
                        System.IO.Directory.CreateDirectory(MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(FolderPath, FolderPath));
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            public static bool FileSystemOperate_SetFileAttribute(string FileName, FileAttributes FileAttributeType)
            {
                try
                {
                    if (System.IO.File.Exists(FileName) == true)
                    {
                        System.IO.File.SetAttributes(FileName, FileAttributeType);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch { return false; }
            }
            public static void FileSystemOperate_GetAdminWithFile(string FileName)
            {
                try
                {
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(FileName) == true)
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("takeown.exe", @"/f """ + FileName + @""" /a", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("icacls.exe", @"""" + FileName + @""" /grant:r everyone:f", true, false, true, false, true);
                    }
                }
                catch
                {
                }
            }
            public static void FileSystemOperate_GetAdminWithFolder(string FolderName)
            {
                try
                {
                    if (System.IO.Directory.Exists(FolderName) == true)
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("takeown.exe", @"/f """ + FolderName + @""" /a /r /d y", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("icacls.exe", @"""" + FolderName + @""" /grant administrators:F /t", true, false, true, false, true);
                    }
                }
                catch
                {
                }
            }
            public static void FileSystemOperate_ChangeFileResources(string ResourcesFile, string DLLOrEXEFile, string ResourcesType, int ResourcesID, int ResourcesLanguage)
            {
                try
                {
                    //MessageBox.Show(@"/" + ResourcesFile + @" /" + DLLOrEXEFile + @" /" + ResourcesType + @" /" + ResourcesID.ToString() + @" /" + ResourcesLanguage.ToString());
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\Programs\UpdateResources.exe", @"/""" + ResourcesFile + @""" /""" + DLLOrEXEFile + @""" /" + ResourcesType + @" /" + ResourcesID.ToString() + @" /" + ResourcesLanguage.ToString(), false, false, true, false, true);
                }
                catch
                {
                }
            }
            public static void FileSystemOperate_GetFilesAndFoldersToTreeview(string path, ImageList imglist, ListView lv)
            {
                lv.Items.Clear();
                SHFILEINFO shfi = new SHFILEINFO();//实例化SHFILEINFO类
                try
                {
                    string[] dirs = Directory.GetDirectories(path);//获取指定目录中子目录的名称
                    string[] files = Directory.GetFiles(path);//获取目录中文件的名称
                    for (int i = 0; i < dirs.Length; i++)//遍历子文件夹
                    {
                        string[] info = new string[4];//定义一个数组
                        DirectoryInfo dir = new DirectoryInfo(dirs[i]);//根据文件夹的路径实例化DirectoryInfo类
                        if (!(dir.Name == "RECYCLER" || dir.Name == "RECYCLED" || dir.Name == "Recycled" || dir.Name == "System Volume Information"))
                        {
                            SHGetFileInfo(dirs[i], (uint)0x80, ref shfi, (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi), (uint)(0x100 | 0x400)); //获取文件夹的图标及类型
                            imglist.Images.Add(dir.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());//添加图标
                            info[0] = dir.Name;//获取文件夹的名称
                            info[1] = "";//获取文件夹的大小
                            info[2] = "文件夹";//获取类型
                            info[3] = dir.LastWriteTime.ToString();//获取更改时间
                            ListViewItem item = new ListViewItem(info, dir.Name);//实例化ListViewItem类
                            lv.Items.Add(item);//添加当前文件夹的基本信息
                            DestroyIcon(shfi.hIcon);//销毁图标
                        }
                    }
                    for (int i = 0; i < files.Length; i++)//遍历文件
                    {
                        string[] info = new string[4];//定义一个数组
                        FileInfo fi = new FileInfo(files[i]);//根据文件的路径实例化FileInfo类
                        string Filetype = fi.Name.Substring(fi.Name.LastIndexOf(".") + 1, fi.Name.Length - fi.Name.LastIndexOf(".") - 1);//获取文件的类型
                        string newtype = Filetype.ToLower();//将文件类型转换为小写
                        if (!(newtype == "sys" || newtype == "ini" || newtype == "bin" || newtype == "log" || newtype == "com" || newtype == "bat" || newtype == "db"))
                        {
                            SHGetFileInfo(files[i], (uint)0x80, ref shfi, (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi), (uint)(0x100 | 0x400)); //获取文件的图标及类型
                            imglist.Images.Add(fi.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());//添加图标
                            info[0] = fi.Name;//获取文件的名称
                            info[1] = fi.Length.ToString();//获取文件的大小
                            info[2] = fi.Extension.ToString();//获取文件的类型
                            info[3] = fi.LastWriteTime.ToString();//获取文件的更改时间
                            ListViewItem item = new ListViewItem(info, fi.Name);//实例化ListViewItem类
                            lv.Items.Add(item);//添加当前文件的基本信息
                            DestroyIcon(shfi.hIcon);//销毁图标
                        }
                    }
                }
                catch { }
            }
            public static string FileSystemOperate_GetFileExtraName(string FileName)
            {
                try
                {
                    string aLastName = FileName.Substring(FileName.LastIndexOf(".") + 1, (FileName.Length - FileName.LastIndexOf(".") - 1));   //扩展名
                    return aLastName;
                }
                catch
                {
                    return "";
                }
            }
            public static bool FileSystemOperate_GetFolderExists(string FolderPath, bool IfNotExistsFolderThenCreateNewFolder)
            {
                try
                {
                    string newfolder = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(FolderPath, FolderPath);
                    if (System.IO.Directory.Exists(newfolder) == true)
                    {
                        return true;
                    }
                    else
                    {
                        if (IfNotExistsFolderThenCreateNewFolder == true)
                        {
                            System.IO.Directory.CreateDirectory(newfolder);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
            public static string FileSystemOperate_GetFileLocation(string FilePath)
            {
                try
                {
                    string P = Path.GetDirectoryName(FilePath);
                    return P;
                }
                catch { return ""; }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="FileOrFolderPath">True 是文件 False 是文件夹或者这个文件不存在</param>
            /// <returns></returns>
            public static bool FileSystemOperate_IsFileOrFolder(string FileOrFolderPath)
            {
                try
                {
                    string path = FileOrFolderPath;
                    if (System.IO.File.Exists(path))
                    {
                        return true; // 是文件
                    }
                    else if (Directory.Exists(path))
                    {
                        return false;// 是文件夹
                    }
                    else
                    {
                        return false;// 都不是
                    }
                }
                catch { return false; }
            }
            public static bool FileSystemOperate_CopyFile(string OrgFile, string NewFile)
            {
                try
                {
                    string nf, nn;
                    nf = OrgFile;
                    nn = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(NewFile, NewFile);
                    if (System.IO.File.Exists(nf) == false)
                    {
                        nf = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(nf, nf);
                    }
                    if (System.IO.File.Exists(nf) == false)
                    {
                        return false;
                    }
                    else
                    {
                        MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(nn);
                        System.IO.File.Copy(nf, nn, true);
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
        public class ProgramAndLinksOperate
        {
            public static void LogOff()
            {
                string j = MyFunctions.Dialogs.MessageDialog("您确定要注销系统?", "如需要注销登录，请保存您的文档并结束部分操作。", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "b2", true, true, "确定", "取消");
                if(j=="B1")
                {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("shutdown.exe", "/l", true, false, false, false, false);
                }
            }
            public static bool PinToStartScreen(string xmlpath,string linkpath,string programname)
            {
                try
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(xmlpath);
                    string powershelll_path = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\WindowsPowerShell\v1.0\powershell.exe";
                    //保存XML文件
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(powershelll_path, @"Export-StartLayout -Path """ + xmlpath + @""" -As XML", true, false, true, false, true);
                    if (System.IO.File.Exists(xmlpath) == true)
                    {
                        string apppath = MyFunctions.ProgramAndLinksOperate.ReadLink(linkpath, "PATH");
                        XmlDocument xdocument = new XmlDocument();
                        //获取xml文件
                        xdocument.Load(xmlpath );
                        //获取第一个子节点
                        XmlNode xgnode = xdocument.ChildNodes[0];
                        XmlNode xgnode2 = xgnode.ChildNodes[0];
                        XmlNode xgnode3 = xgnode2.LastChild;
                        //创建一个子节点
                        XmlNode xn = xdocument.CreateNode(XmlNodeType.Element, "tile", null);
                        //属性key的设置
                        XmlAttribute xa = xdocument.CreateAttribute("FencePost");
                        xa.Value = "0";

                        //属性title的设置
                        XmlAttribute xa2 = xdocument.CreateAttribute("size");
                        xa2.Value = "square150x150";

                        //属性title的设置
                        XmlAttribute xa3 = xdocument.CreateAttribute("AppID");
                        xa3.Value = apppath;

                        //添加属性到指定节点中
                        xn.Attributes.Append(xa);
                        xn.Attributes.Append(xa2);
                        xn.Attributes.Append(xa3);
                        //将设置好的节点添加到指定父级节点中
                        xgnode3.AppendChild(xn);

                        //保存xml
                        xdocument.Save(xmlpath );
                        //锁定开始屏幕布局
                        //MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.LocalMachine, @"SOFTWARE\Policies\Microsoft\Windows", "Explorer", false);
                        //MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Group Policy Objects\{EA36CB46-AA2E-458A-A95F-A937F71DDBBD}User\Software\Policies\Microsoft\Windows", "Explorer", false);
                        //MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Policies\Microsoft\Windows\Explorer", "LockedStartLayout", "1", RegistryValueKind.DWord, false, false);
                        //MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"SOFTWARE\Policies\Microsoft\Windows\Explorer", "StartLayoutFile ", @""""+xmlpath +@"""", RegistryValueKind.String , false, false);
                        //MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.LocalMachine, @"Software\Microsoft\Windows\CurrentVersion\Group Policy Objects\{EA36CB46-AA2E-458A-A95F-A937F71DDBBD}User\Software\Policies\Microsoft\Windows\Explorer", "StartLayoutFile ", @"""" + xmlpath + @"""", RegistryValueKind.String, false, false);
                        return true;
                    }
                    else { return false; }
                }
                catch { return false; }
            }

            public static bool CloseProcess(string ProcessName)
            {
                try
                {
                    Process[] ps = Process.GetProcessesByName(ProcessName);//根据进程名称,获取该进程信息
                    foreach (Process p in ps)
                    {
                        p.Kill();
                        p.WaitForExit();
                        p.Close();                         //关闭
                    }
                }
                catch (Exception ex)
                {
                    return false;                         //失败
                }
                return true;                             //成功
            }
            public static bool StartURL(string URL)
            {
                try
                {
                    System.Diagnostics.Process.Start(URL);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            public static void ReStartExplorer()
            {
                string red = SGFunction.CommonDialogs.MessageDialog_MustClick("是否重启资源管理器?", "重启管理器可以帮助您应用某些设置 , 但会导致您所打开的文件夹的窗口遭到关闭.", "是", "否", "b1", "ques");
                if(red=="B1")
                {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(Application.StartupPath + @"\programs\tskill\tskill.exe", "explorer", true, false, false, false, false);
                }
            }
            public static bool ShellPrograms(string AppPath, string AppArgs, bool IsHidden, bool HasEnvironmetVars, bool IsRunAsAdmin, bool HasErrorBox, bool WaitForExit)
            {
                try
                {
                    string NewAppPath = AppPath;
                    if (HasEnvironmetVars == true || System.IO.File.Exists(AppPath)==false)
                    {
                        NewAppPath = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(NewAppPath, NewAppPath);
                    }
                    switch (IsRunAsAdmin)
                    {
                        case true:
                            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
                            System.Diagnostics.Process p = new System.Diagnostics.Process();
                            start.Verb = "runas";
                            start.Arguments = AppArgs;
                            start.FileName = NewAppPath;
                            if (IsHidden == true)
                            {
                                start.WindowStyle = ProcessWindowStyle.Hidden;
                            }
                            if (WaitForExit == true)
                            {
                                p = System.Diagnostics.Process.Start(start);
                                p.WaitForExit();
                                break;
                            }
                            else
                            {
                                p = System.Diagnostics.Process.Start(start);
                                break;
                            }
                        case false:
                            System.Diagnostics.ProcessStartInfo start1 = new System.Diagnostics.ProcessStartInfo();
                            System.Diagnostics.Process p1 = new System.Diagnostics.Process();
                            //start1.Verb = "open";
                            start1.Arguments = AppArgs;
                            start1.FileName = NewAppPath;
                            if (IsHidden == true)
                            {
                                start1.WindowStyle = ProcessWindowStyle.Hidden;
                            }
                            //p1 = System.Diagnostics.Process.Start(start1);
                            if (WaitForExit == true)
                            {
                                p1 = System.Diagnostics.Process.Start(start1);
                                p1.WaitForExit();
                                break;
                            }
                            else
                            {
                                p1 = System.Diagnostics.Process.Start(start1);
                                break;
                            }
                    }
                    return true;
                }
                catch (Exception hj)
                {
                    if (HasErrorBox == true)
                    {
                        MyFunctions.Dialogs.MessageDialog("运行程序错误", "无法运行指定的程序或用户取消程序运行的操作", MyFunctions.Dialogs.MessageDialogIcon.Error, hj.Message.ToString(), "b2", false, true, "", "确定");
                    }
                    return false;
                }
            } //运行程序
            public static bool CreateLink(string ShortcutPath, string TargetPath, string ProgramArgs, string Info, string Icon, Form frm)
            {
                try
                {
                    //MyFunctions.ProgramAndLinksOperate.ShellPrograms("wscript.exe", @"""" + Application.StartupPath + @"\Programs\CreateLink.vbs"" /L=""" + ShortcutPath + @""" /P=""" + TargetPath + @""" /A=""" + ProgramArgs + @""" /I=""" + Icon + @""" /D=""" + Info + @"""", true, false, true, false, true, null);
                    IWshShortcut _shortcut = null;
                    IWshShell_Class shell = new IWshShell_Class();
                    _shortcut = shell.CreateShortcut(ShortcutPath) as IWshShortcut;
                    _shortcut.TargetPath = TargetPath;
                    _shortcut.Arguments = ProgramArgs;
                    _shortcut.Description = Info;
                    if (Icon != "")
                    {
                        _shortcut.IconLocation = Icon;
                    }
                    _shortcut.Save();
                    return true;
                }
                catch { return false; }
            }
            public static bool CreateLink_StartAdminType(string ShortcutPath, string TargetPath, string ProgramArgs, string Info, string Icon)
            {
                try
                {
                    string a = Application.StartupPath + @"\programs\DefaultLink_Admin.lnk.sgo";
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(a, ShortcutPath);
                    IWshShortcut _shortcut = null;
                    IWshShell_Class shell = new IWshShell_Class();
                    _shortcut = shell.CreateShortcut(ShortcutPath) as IWshShortcut;
                    _shortcut.TargetPath = TargetPath;
                    _shortcut.Arguments = ProgramArgs;
                    _shortcut.Description = Info;
                    _shortcut.WorkingDirectory = MyFunctions.FileSystemOperate.FileSystemOperate_GetFileLocation(TargetPath);
                    if (Icon != "")
                    {
                        _shortcut.IconLocation = Icon;
                    }
                    _shortcut.Save();
                    return true;
                }
                catch { return false; }
            }
            public static void PingProgramInTaskBar(bool LockOrUnLock, string LinkPath)
            {
                try
                {
                    if (LockOrUnLock == true)
                    {
                        ShellExecute(IntPtr.Zero, new StringBuilder("taskbarpin"), new StringBuilder(LinkPath), new StringBuilder(""), new StringBuilder(""), 0);
                    }
                    else
                    {
                        ShellExecute(IntPtr.Zero, new StringBuilder("taskbarunpin"), new StringBuilder(LinkPath), new StringBuilder(""), new StringBuilder(""), 0);
                    }
                }
                catch { }
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="ShortcutPath">路径</param>
            /// <param name="Type">设置的模式( [Path] 程序的路径 [Icon] 图标的路径及编号 [Args] 命令行 [Info] 提示信息 [Type] 运行模式 [WORK] 快捷方式的工作目录 [HOTK] 快捷键)</param>
            /// <param name="TiHuanStrings">要替换的文字 注意如果要替换运行模式 [1] 正常 [3] 最大化 [7] 最小化</param>
            /// <returns></returns>
            public static bool SetLink(string ShortcutPath, string Type, string TiHuanStrings)
            {
                try
                {
                    IWshShortcut _shortcut = null;
                    IWshShell_Class shell = new IWshShell_Class();
                    _shortcut = shell.CreateShortcut(ShortcutPath) as IWshShortcut;
                    switch (Type.ToUpper())
                    {
                        case "PATH":
                            _shortcut.TargetPath = TiHuanStrings;
                            break;
                        case "ICON":
                            _shortcut.IconLocation = TiHuanStrings;
                            break;
                        case "INFO":
                            _shortcut.Description = TiHuanStrings;
                            break;
                        case "ARGS":
                            _shortcut.Arguments = TiHuanStrings;
                            break;
                        case "TYPE":
                            _shortcut.WindowStyle = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(TiHuanStrings, 1);
                            break;
                        case "HOTK":
                            _shortcut.Hotkey = TiHuanStrings;
                            break;
                        case "WORK":
                            _shortcut.WorkingDirectory = TiHuanStrings;
                            break;
                    }
                    _shortcut.Save();
                    return true;
                }
                catch { return false; }
            }
            /// <summary>
            /// 用于读取快捷方式的信息
            /// </summary>
            /// <param name="LinkPath">快捷方式的路径</param>
            /// <param name="ReturnType">获取的模式( [Path] 程序的路径 [Icon] 图标的路径及编号 [Args] 命令行 [Info] 提示信息) [RUTY] 读取窗口运行的状态("1" 常规 "7" 最小化 "3" 最大化) [WORK] 读取工作的目录 [HOTK] 快捷方式的快捷键</param>
            /// <returns></returns>
            public static string ReadLink(string LinkPath, string ReturnType)
            {
                try
                {
                    IWshShortcut _shortcut = null;
                    IWshShell_Class shell = new IWshShell_Class();
                    _shortcut = shell.CreateShortcut(LinkPath) as IWshShortcut;//在vs2010中CreateShortcut返回dynamic 类型
                    string ret = "";
                    switch (ReturnType.ToUpper())
                    {
                        case "PATH":
                            if (System.IO.File.Exists(LinkPath) == true)
                            {
                                string path1 = _shortcut.TargetPath;
                                ret = path1;
                            }
                            break;
                        case "ICON":
                            if (System.IO.File.Exists(LinkPath) == true)
                            {
                                string path2 = _shortcut.IconLocation;
                                if (path2.Length <= 3)
                                {
                                    ret = MyFunctions.ProgramAndLinksOperate.ReadLink(LinkPath, "path") + path2;
                                }
                                else
                                {
                                    ret = path2;
                                }
                            }
                            break;
                        case "ARGS":
                            if (System.IO.File.Exists(LinkPath) == true)
                            {
                                string path3 = _shortcut.Arguments;
                                ret = path3;
                            }
                            break;
                        case "INFO":
                            if (System.IO.File.Exists(LinkPath) == true)
                            {
                                string path4 = _shortcut.Description;
                                ret = path4;
                            }
                            break;
                        case "RUTY":
                            if (System.IO.File.Exists(LinkPath) == true)
                            {
                                int path5 = _shortcut.WindowStyle;
                                ret = path5.ToString();
                            }
                            break;
                        case "WORK":
                            if (System.IO.File.Exists(LinkPath) == true)
                            {
                                string path7 = _shortcut.WorkingDirectory;
                                ret = path7;
                            }
                            break;
                        case "HOTK":
                            if (System.IO.File.Exists(LinkPath) == true)
                            {
                                string path8 = _shortcut.Hotkey;
                                ret = path8;
                            }
                            break;
                    }
                    return ret;
                }
                catch
                {
                    return "";
                }
            }
            public static void ShellTool(string ToolName,string Args)
            {
                try
                {
                    string sgcf = Application.StartupPath + @"\config\toolsinfo.sgcf";
                    if (System.IO.File.Exists(sgcf) == true)
                    {
                        string os = MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion().Replace(".", "");
                        string program = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(ToolName, "NT" + os, "", false, sgcf);
                        program = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(program, program);
                        //MessageBox.Show(program);
                        if (System.IO.File.Exists(program) == true)
                        {
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms(program,Args, false, false, true, false, false);
                        }
                        else
                        {
                            MyFunctions.Dialogs.MessageDialog("文件未找到", @"无法启动""" + ToolName + @"""", MyFunctions.Dialogs.MessageDialogIcon.Error, @"无法找到文件""" + program + @"""", "b2", false, true, "", "确定");
                        }
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("文件未找到", @"无法加载配置文件", MyFunctions.Dialogs.MessageDialogIcon.Error, @"无法找到文件""" + sgcf + @"""", "b2", false, true, "", "确定");
                    }
                }
                catch { }
            }
        }
        public class PackageOperate
        {
            public static void SGPAK_ExtactPackage(string SGPAK, string FolderPath, bool IsRunByExplorer)
            {
                try
                {
                    string cab = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Expand.exe";
                    string temppath = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp");
                    string packinfo = temppath + @"\PackageInfo.sgpakinfo";
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(packinfo);
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(cab, @"""" + SGPAK + @""" """ + temppath + @""" -f:*.sgpakinfo", true, false, true, false, true);
                    string FF = FolderPath;
                    if (FF == "" && IsRunByExplorer == true)
                    {
                        FF = MyFunctions.StreamAndTextOperate.ConfigFileOperate.ConfigFileOperate_GetValue("Main", "location", "", false, packinfo);
                        FF = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(FF, FF);
                    }
                    MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(FF);
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms(cab, @"""" + SGPAK + @""" """ + FF + @""" -f:*.*", true, false, true, false, true);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(FF + @"\PACKAGEINFO.SGPAKINFO");
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(packinfo);
                }
                catch { }
            }
        }
        public class ExtraNames
        {
            public static void RegistryExtraName(string ExtraName)
            {
                try
                {
                    switch (ExtraName.ToUpper())
                    {
                        case "SGCF":
                            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, "", ".SGCF", false);
                            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, "", "SystemGear.SGCF", false);
                            Registry.ClassesRoot.CreateSubKey(".SGCF");
                            Registry.ClassesRoot.OpenSubKey(".SGCF", true).SetValue("", "SystemGear.SGCF");
                            Registry.ClassesRoot.CreateSubKey("SystemGear.SGCF");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF", true).SetValue("", "系统齿轮 通用配置文件", RegistryValueKind.String);
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF", true).CreateSubKey("DefaultIcon").SetValue("", Application.StartupPath + @"\SGRes.dll,1");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF", true).CreateSubKey("Shell").CreateSubKey("Open");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF", true).CreateSubKey("Shell").CreateSubKey("Zdit");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF\\Shell\\Open", true).CreateSubKey("Command");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF\\Shell\\Zdit", true).CreateSubKey("Command");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF\\Shell\\Open", true).SetValue("", @"使用系统齿轮加载(&L)");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF\\Shell\\Zdit", true).SetValue("", @"使用记事本编辑(&E)");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF\\Shell\\Zdit", true).SetValue("Icon", @"%SystemRoot%\System32\Notepad.exe,0", RegistryValueKind.ExpandString);
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF\\Shell\\Open", true).SetValue("Icon", Application.ExecutablePath+",0");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF\\Shell\\Zdit\\Command", true).SetValue("", @"%SystemRoot%\System32\Notepad.exe ""%1""", RegistryValueKind.ExpandString);
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGCF\\Shell\\Open\\Command", true).SetValue("", Application.ExecutablePath+@" /L=""%1""", RegistryValueKind.String);
                            break;
                        case "SGPAK":
                            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, "", ".SGPAK", false);
                            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, "", "SystemGear.SGPAK", false);
                            Registry.ClassesRoot.CreateSubKey(".SGPAK");
                            Registry.ClassesRoot.OpenSubKey(".SGPAK", true).SetValue("", "SystemGear.SGPAK");
                            Registry.ClassesRoot.CreateSubKey("SystemGear.SGPAK");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGPAK", true).SetValue("", "系统齿轮 压缩包", RegistryValueKind.String);
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGPAK", true).CreateSubKey("DefaultIcon").SetValue("", Application.StartupPath + @"\SGRes.dll,9");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGPAK", true).CreateSubKey("Shell").CreateSubKey("Open").CreateSubKey("Command"); ;
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGPAK", true).OpenSubKey("Shell\\Open", true).SetValue("", "使用系统齿轮解压");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGPAK", true).OpenSubKey("Shell\\Open", true).SetValue("Icon", Application.ExecutablePath+@",0");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGPAK", true).OpenSubKey("Shell\\Open\\Command", true).SetValue("", Application.ExecutablePath+@" /P=""%1""");

                            break;
                        case "SGBAK":
                            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, "", ".SGBAK", false);
                            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, "", "SystemGear.SGBAK", false);
                            Registry.ClassesRoot.CreateSubKey(".SGBAK");
                            Registry.ClassesRoot.OpenSubKey(".SGBAK", true).SetValue("", "SystemGear.SGBAK");
                            Registry.ClassesRoot.CreateSubKey("SystemGear.SGBAK");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGBAK", true).SetValue("", "系统齿轮 备份文件", RegistryValueKind.String);
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGBAK", true).CreateSubKey("DefaultIcon").SetValue("", Application.StartupPath + @"\SGRes.dll,8");
                            break;
                        case "SGTMP":
                            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, "", ".SGTMP", false);
                            MyFunctions.RegistryOperate.RegistryOperate_DeleteSubKey(Registry.ClassesRoot, "", "SystemGear.SGTMP", false);
                            Registry.ClassesRoot.CreateSubKey(".SGTMP");
                            Registry.ClassesRoot.OpenSubKey(".SGTMP", true).SetValue("", "SystemGear.SGTMP");
                            Registry.ClassesRoot.CreateSubKey("SystemGear.SGTMP");
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGTMP", true).SetValue("", "系统齿轮 临时文件", RegistryValueKind.String);
                            Registry.ClassesRoot.OpenSubKey("SystemGear.SGTMP", true).CreateSubKey("DefaultIcon").SetValue("", Application.StartupPath + @"\SGRes.dll,13");
                            break;
                        case "ALL":
                            MyFunctions.ExtraNames.RegistryExtraName("sgcf");
                            MyFunctions.ExtraNames.RegistryExtraName("sgtmp");
                            MyFunctions.ExtraNames.RegistryExtraName("sgpak");
                            MyFunctions.ExtraNames.RegistryExtraName("sgbak");
                            break;
                    }
                    MyFunctions.ApplicationAndEnvironmentInformation.UpdateDesktop();
                }
                catch { }
            }
        }
        public class Controls
        {
            public class FormType
            {
                public static void PublicControls_ContextMenu(string[] Commands, System.Drawing.Color BorderColor, MouseEventHandler[] MouseEvents, int MouseX, int MouseY)
                {
                    try
                    {
                        Form_ContextMenuStrip frm = new Form_ContextMenuStrip(BorderColor, Commands, MouseEvents);
                        frm.Location = new System.Drawing.Point(MouseX, MouseY);
                        frm.Show();
                        //string j = frm.ret;
                        //frm.Dispose();
                        //return j;
                    }
                    catch { }
                }
            }
        }
        public class SGURL
        {
            public class SGURLInfo
            {

            }
            public static object SGURLGeter()
            {
                try
                {
                    return Properties.Resources.BackupSettings_Logo;
                }
                catch { return null; }
            }
        }
    }
}
