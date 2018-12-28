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
using SystemGear;
using IWshRuntimeLibrary;
using SystemGear.窗体;
using SystemGear.控件;
using SystemGear.功能控件;
using System.Security.AccessControl;
using System.Media;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Net.NetworkInformation;
using Microsoft.Win32.TaskScheduler;
using System.ServiceProcess;


namespace SystemGear
{
    /// <summary>
    /// 系统齿轮各个功能库
    /// </summary>
    class SGFunction
    {

        #region RESOURCE IPTYPE
        private const uint RT_CURSOR = 0x00000001;
        private const uint RT_BITMAP = 0x00000002;
        private const uint RT_ICON = 0x00000003;
        private const uint RT_MENU = 0x00000004;
        private const uint RT_DIALOG = 0x00000005;
        private const uint RT_STRING = 0x00000006;
        private const uint RT_FONTDIR = 0x00000007;
        private const uint RT_FONT = 0x00000008;
        private const uint RT_ACCELERATOR = 0x00000009;
        private const int RT_RCDATA = 0x00000010;
        private const uint RT_MESSAGETABLE = 0x00000011;
        //private const uint LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
        #endregion
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
        public static extern IntPtr FindResource(IntPtr hModule, int lpID, uint lpType);

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
        #region 引用的API
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果
        #endregion
        #region 文件复制移动对话框API
        [DllImport("shell32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool SHFileOperation([In, Out]  SHFILEOPSTRUCT str);
        /// <summary>
        /// 移动文件(夹)
        /// </summary>
        private const int FO_MOVE = 0x1;
        /// <summary>
        /// 复制文件(夹)
        /// </summary>
        private const int FO_COPY = 0x2;
        /// <summary>
        /// 删除文件(夹)
        /// </summary>
        private const int FO_DELETE = 0x3;
        /// <summary>
        /// 不出现任何对话框
        /// </summary>
        private const ushort FOF_NOCONFIRMATION = 0x10;
        /// <summary>
        /// 允许撤销
        /// </summary>
        private const ushort FOF_ALLOWUNDO = 0x40;
        /// <summary>
        /// 没有错误对话框
        /// </summary>
        private const ushort FOF_NOERRORUI = 0x0400;
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
        #region 获取当前活动窗体的API
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT  lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left; //最左坐标
            public int Top; //最上坐标
            public int Right; //最右坐标
            public int Bottom; //最下坐标
        }

        #endregion
        public class TaskSchedulerMgr
        {
            public class Taskinfo
            {
                /// <summary>
                /// 任务计划名称
                /// </summary>
                public string TaskName { get; set; }
                /// <summary>
                /// 创建者
                /// </summary>
                public string Auth { get; set; }
                /// <summary>
                /// 状态
                /// </summary>
                public string Status { get; set; }
                /// <summary>
                /// 上次运行的时间
                /// </summary>
                public string LastTime { get; set; }
                /// <summary>
                /// 任务计划的触发条件
                /// </summary>
                public string Tigger { get; set; }
                /// <summary>
                /// 任务计划启动程序的路径和命令行 如果有多个程序 默认选择最后一个
                /// </summary>
                public string Path { get; set; }
                /// <summary>
                /// 任务计划启动程序的模式(与Paths 对应 相应的值其参考ActionType的枚举值 )
                /// </summary>
                public string ExecutionType { get; set; }
                /// <summary>
                /// 上次运行的结果 [Abnormal]不成功 [Success]成功
                /// </summary>
                public string LastResult { get; set; }
                /// <summary>
                /// 该任务计划的描述
                /// </summary>
                public string Description { get; set; }
            }
            /// <summary>
            /// 获取任务计划的内容
            /// </summary>
            /// <returns></returns>
            public static List<Taskinfo> GetTaskInfo()
            {
                List<Taskinfo> oInfo = new List<Taskinfo>();

                using (TaskService pp = new TaskService())
                {
                    Version ver = pp.HighestSupportedVersion;
                    TaskFolder tf = pp.RootFolder;
                    Taskinfo ot;
                    foreach (Microsoft.Win32.TaskScheduler.Task t in pp.RootFolder.AllTasks)
                    {
                        ot = new Taskinfo();
                        try
                        {

                            ot.Auth = t.Definition.RegistrationInfo.Author;
                            ot.Status = t.State.ToString();
                            ot.LastResult = t.LastTaskResult > 0 == true ? "Abnormal" : "Success";
                            ot.TaskName = t.Name;
                            ot.LastTime = t.LastRunTime.ToString("yyyy-MM-dd HH:mm:ss");
                            ot.Description = t.Definition.RegistrationInfo.Description;
                            foreach (Trigger trg in t.Definition.Triggers)
                            {
                                ot.Tigger = trg.ToString();
                            }
                            ActionCollection acts = t.Definition.Actions;
                            if (acts.Count == 1)
                            {
                                ot.Path = acts[0].ToString();
                                ot.ExecutionType = acts[0].ActionType.ToString();
                            }
                            else
                            {
                                if (acts.Count > 1)
                                {
                                    //MessageBox.Show(acts[acts.Count - 1].ToString());
                                    ot.Path = acts[acts.Count - 1].ToString();
                                    ot.ExecutionType = acts[acts.Count - 1].ActionType.ToString();
                                }
                            }
                            /*
                        foreach (Microsoft.Win32.TaskScheduler.Action act in t.Definition.Actions)
                        {
                            ot.ExecutionType = act.ActionType;
                             ot.Path = act.ToString();
                            //ot.Path.Add(act.ActionType.ToString() +","+act.ToString());
                        }
                             */
                        }
                        catch { }
                        if (!string.IsNullOrEmpty(ot.TaskName))
                        {
                            oInfo.Add(ot);
                        }
                    }
                    ot = null;
                    ver = null;
                    tf = null;
                }

                return oInfo;
            }
        }
        /// <summary>
        /// 操作系统齿轮程序信息
        /// </summary>
        public class ApplicationSetting
        {
            /// <summary>
            /// 对于系统齿轮全局设置的全局操作
            /// </summary>
            /// <param name="code">操作类型 [simplymode]简易模式(对应值ON OFF)</param>
            /// <param name="value">值(用于设置值)</param>
            /// <returns></returns>
            public static string Operate_SystemGearApplicationSettings(string code,string value="")
            {
                string r = "";
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\MainProgram.sgcf";
                string sectionkey = "";
                switch (code.ToLower())
                {
                    case "simplemode":
                        sectionkey = "Simplymode";
                        break;
                }
                if(value !="")
                {

                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("mainsettings", sectionkey, value, "Config", false, cfg); return "";
                }
                else
                {
                    return SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("mainsettings", sectionkey, "", cfg, false);
                }
            }
            /// <summary>
            /// 获取当前窗体的位置 大小信息
            /// </summary>
            /// <returns></returns>
            public static Rectangle   GetCurrentActivedForRectagle()
            {
                IntPtr awin = GetForegroundWindow(); //获取当前窗口句柄
                RECT rc = new RECT();
                GetWindowRect(awin, ref rc);
                int width = rc.Right - rc.Left; //窗口的宽度
                int height = rc.Bottom - rc.Top; //窗口的高度
                int x = rc.Left;
                int y = rc.Top;
                Rectangle newrect = new Rectangle(x, y, width, height);
                return newrect;
            }
            /// <summary>
            /// 获取有关于当前产品的信息
            /// </summary>
            /// <param name="type">模式 [exename]获取EXE文件名(无路径 后面不加.exe)</param>
            /// <returns></returns>
            public static string GetProductInfo(string type)
            {
                string j = "";
                switch (type.ToLower())
                {
                    case "exename":
                        j = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
                        j = j.Substring(0, j.LastIndexOf("."));
                        break;
                }
                return j;
            }
            public static string LoadLanguage_String()
            {
                return "";
            }
            /// <summary>
            /// 通过系统齿轮内部命令行 返回有关的程序信息 [0]名称 [1]InfoTip [2]命令行 [3]Logo36 [4]Logo72 [5]ICON图标 [6]SGFunctionRecoder功能的备份文件(SGCF) 以上只支持现有的功能 不包含未开发的功能
            /// </summary>
            /// <param name="startarg">启动的参数</param>
            /// <param name="convertvar">是否转换变量</param>
            /// <param name="createsrecfolder">是否创建用于SREC功能的文件夹</param>
            /// <returns></returns>
            public static string[] GetSGFunctionInfo(string startarg, bool convertvar, bool createsrecfolder)
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\SystemGearFunction.SGCF";
                string[] arr = new string[7];
                string[] args = startarg.Split(',');
                string read_head = "";
                string read_jie = "";
                if (args.Length == 4)
                {
                    switch (args[0].ToUpper())
                    {
                        case "SY":
                            read_head = "SYSTEMSTYLE_FUNCTION_" + args[1];
                            read_jie = args[2] + "," + args[3];
                            break;
                        case "MA":
                            read_head = "MAIN_" + args[1];
                            read_jie = args[2] + "," + args[3];
                            break;

                    }
                    string readfrm = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(read_head, read_jie, "", cfg, false);
                    if (readfrm != "")
                    {
                        string[] rs = readfrm.Split('|');
                        string name = rs[0];
                        string info = rs[1]; string cmd = rs[2]; string logo36 = rs[3]; string logo72 = rs[4]; string ico = rs[5];
                        if (convertvar == true)
                        {
                            name = SGFunction.PathOperate.ConvertStringToTurePath(name, name);
                            info = SGFunction.PathOperate.ConvertStringToTurePath(info, info);
                            ico = SGFunction.PathOperate.ConvertStringToTurePath(ico, ico);
                        }
                        string back = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("SREC") + "\\" + cmd;
                        if (createsrecfolder == true) { SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(back); }
                        back = back + "\\Setting.sgcf";
                        arr = new string[] { name, info, cmd, logo36, logo72, ico, back };
                    }

                }
                else
                {
                    //IE ITMI命令行
                    if (args.Length == 1)
                    {
                        switch (args[0].ToUpper())
                        {
                            case "IE":
                                read_head = "DEVELOP_FUNCTION"; read_jie = "IE";
                                break;
                            case "DESKTOPLABEL":
                                read_head = "SGTOOLS"; read_jie = "DESKTOPLABEL";
                                break;
                            case "PCLOCKER":
                                read_head = "SGTOOLS"; read_jie = "PCLOCKER";
                                break;
                        }
                        string readfrm = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(read_head, read_jie, "", cfg, false);
                        if (readfrm != "")
                        {
                            string[] rs = readfrm.Split('|');
                            string name = rs[0];
                            string info = rs[1]; string cmd = rs[2]; string logo36 = rs[3]; string logo72 = rs[4]; string ico = rs[5];
                            if (convertvar == true)
                            {
                                name = SGFunction.PathOperate.ConvertStringToTurePath(name, name);
                                info = SGFunction.PathOperate.ConvertStringToTurePath(info, info);
                                ico = SGFunction.PathOperate.ConvertStringToTurePath(ico, ico);
                            }
                            string back = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("SREC") + "\\" + cmd;
                            if (createsrecfolder == true) { SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(back); }
                            back = back + "\\Setting.sgcf";
                            arr = new string[] { name, info, cmd, logo36, logo72, ico, back };
                        }
                    }
                }
                return arr;
            }
            /// <summary>
            /// 获取程序版本信息
            /// </summary>
            /// <param name="type">例如 2.5.2.1004 Beta1 [EDIT]返回发行号 例如Beta1  [FMAIN]主程序版本返回2 [MMAIN]主版本+次版本号(2.5) [FULL] 完整的版本返回2.5.2.1004 [PMAIN]程序版本代号返回2.5.2.1004 Beta 1</param>
            /// <returns></returns>
            public static string GetSGProgramVersion(string type)
            {
                string ver = Application.ProductVersion;
                string[] dd = ver.Split('.');
                if (dd.Length == 4)
                {
                    switch (type.ToUpper())
                    {
                        case "FMAIN":
                            return dd[0];
                        case "FULL":
                            return ver;
                        case "PMAIN":
                            return ver + " Preview";
                        case "MMAIN":
                            return dd[0] + "." + dd[1];
                        case "EDIT":
                            return "Beta 2";
                        default:
                            return ver;
                    }
                }
                else { return ver; }
            }
            public static void FindFunction(string findstr, SGForm_Main m)
            {
                try
                {
                    List<string> op = new List<string>();
                    List<string> shell = new List<string>();
                    List<string> imge = new List<string>();
                    //m.sgCombobox_searchbox.DroppedDown = false;
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\searchinfo.sgcf";
                    string[] keys, values;
                    SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("ALL", out keys, out values, cfg, true);
                    for (int h = 1; h <= values.Length; h++)
                    {
                        string[] arr = values[h - 1].Split('|');
                        if (arr.Length >= 3)
                        {
                            string readname = arr[0];
                            readname = SGFunction.PathOperate.ConvertStringToTurePath(readname, readname);
                            int orglen = readname.Length;
                            int newlen = readname.ToUpper().Replace(findstr.ToUpper(), "").Length;
                            if (newlen - orglen < 0)
                            {
                                op.Add(readname);
                                shell.Add(arr[1]);
                                imge.Add(arr[2]);
                            }
                        }
                    }
                    if (op.Count > 0)
                    {
                        m.imageList_imageofsearch.Images.Clear();
                        m.sgCombobox_searchbox.Items.Clear();
                        //有结果
                        for (int u = 1; u <= op.Count; u++)
                        {
                            m.sgCombobox_searchbox.Items.Add(op[u - 1]);
                            m.imageList_imageofsearch.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(imge[u - 1]));
                        }
                        //MessageBox.Show("");
                        m.sgCombobox_searchbox.Tag = shell.ToArray();
                        m.sgCombobox_searchbox.DroppedDown = true;
                        m.Cursor = System.Windows.Forms.Cursors.Default;
                    }
                    else
                    {
                        //没有结果
                        m.imageList_imageofsearch.Images.Clear();
                        m.sgCombobox_searchbox.Items.Clear();
                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// 提供对系统扩展名的操作
        /// </summary>
        public class ExtensionOperate
        {
            /// <summary>
            /// 获取文件的关联图标
            /// </summary>
            /// <param name="input">文件路径或者扩展名(.txt)</param>
            /// <param name="defico">默认的图标</param>
            /// <returns></returns>
            public static string GetExtensionIcon(string input, string defico = "%windir%\\system32\\imageres.dll,2")
            {
                try
                {
                    //获取关联
                    string ext = input;
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(input) == true)
                    {
                        //文件
                        ext = "." + SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(input);
                    }
                    string re = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, ext, "", "");
                    if (re != "")
                    {
                        string ico = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, re + "\\defaulticon", "", defico);
                        if (ico == "%1") { ico = "%windir%\\system32\\imageres.dll,2"; }
                        return ico;
                    }
                    else { return defico; };
                }
                catch { return defico; }
            }
        }
        /// <summary>
        /// 显示或自定义系统齿轮提供的各种通用窗体、系统窗体
        /// </summary>
        public class CommonDialogs
        {
            /// <summary>
            /// 显示URL选择对话框
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="res">返回的窗体点击结果</param>
            /// <returns></returns>
            public static string ShowHomePageURLChoose(string title, out string res)
            {
                SGUserControl_HomePageChoose hp = new SGUserControl_HomePageChoose(title);
                string res1 = SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("选择IE浏览器的起始页面", hp).ToString();
                res = res1;
                return hp.retutnurl;
            }
            /// <summary>
            /// 显示添加右键菜单功能 返回窗口点击信息(OK EXIT)
            /// </summary>
            /// <param name="title">标题</param>
            /// <returns></returns>
            public static string ShowAddRightMenuDialog(string title)
            {
                SGForm_MoreFunctions f = new SGForm_MoreFunctions("ADDRM", title, false, "ADDRM");
                f.ShowDialog();
                string h = f.buttonclick;
                f.Dispose();
                return h;
            }
            /// <summary>
            /// 显示系统工具箱
            /// </summary>
            /// <param name="title">标题</param>
            public static void ShowSystemToolKit(string title)
            {
                SGUserControl_SystemToolBox b = new SGUserControl_SystemToolBox();
                SGFunction.CommonDialogs.ShowSpecialAndGuideDialog(title, b, true);
            }
            /// <summary>
            /// 显示选择系统齿轮内部功能 返回数组 [0]名称 [1] 提示信息 [2]内部命令 [3]Logo36x36 [4]Logo72x72 [5]图标
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="hasmain">是否显示开发中的功能</param>
            /// <param name="res">按钮结果 [exit] [ok]</param>
            /// <param name="autoconvertvar">是否自动转换ICON路径和INFO ITP NAME的真实名称</param>
            /// <returns></returns>
            public static string[] ChooseSGFunction(string title, bool hasmain, out string res, bool autoconvertvar = true)
            {
                SGForm_MoreFunctions f = new SGForm_MoreFunctions("SGFUNCTION", title, false, "", hasmain);
                f.ShowDialog();
                string[] r = new string[6];
                if (f.buttonclick == "ok")
                {
                    string[] po = f.choosesgfunction;
                    if (po.Length == 7)
                    {
                        string n = po[0];
                        string tip = po[1];
                        string shell = po[2];
                        string logo36 = po[3];
                        string logo72 = po[4];
                        string ico = po[5];
                        if (autoconvertvar == true)
                        {
                            ico = SGFunction.PathOperate.ConvertStringToTurePath(ico, ico); n = SGFunction.PathOperate.ConvertStringToTurePath(n, n);
                            tip = SGFunction.PathOperate.ConvertStringToTurePath(tip, tip);
                        }
                        r = new string[] { n, tip, shell, logo36, logo72, ico };
                    }

                }
                res = f.buttonclick;
                f.Dispose();
                return r;
            }
            /// <summary>
            /// 显示常用操作对话框 返回数组 没有点击null,完成了[0] 名称 [1]程序 [2]参数 [3]图标 [4]是否以管理员身份运行True False [5]用户选择的功能模式[FILE]文件操作 [NET]网络操作 [POWER]电源操作 [SYS]系统工具 [RM]右键菜单
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="res">窗体点击事件 [ok]完成 [exit]取消了</param>
            /// <param name="type">模式 [normal]正常模式 [ext]包含打开文件的选项(用于扩展名和其他的) [sgfunction]选择系统齿轮内部功能 [addrm]添加右键菜单功能</param>
            /// <param name="hasadmin">是否显示"以管理员身份运行"复选框</param>
            /// <returns></returns>
            public static string[] ShowMoreFunctionDialog(string title, out string res, string type = "normal", bool hasadmin = true)
            {
                SGForm_MoreFunctions f = new SGForm_MoreFunctions(type, title, hasadmin, type);
                f.ShowDialog();
                string[] r = new string[6];
                if (f.buttonclick == "ok")
                {
                    string app = f.program;
                    string arg = f.programarg;
                    string ico = f.programicon;
                    bool runas = f.runasadmin;
                    string gnam = f.programname;
                    string ct = f.choosetype;
                    app = SGFunction.PathOperate.ConvertStringToTurePath(app, app);
                    arg = SGFunction.PathOperate.ConvertStringToTurePath(arg, arg);
                    ico = SGFunction.PathOperate.ConvertStringToTurePath(ico, ico);
                    r = new string[] { gnam, app, arg, ico, runas.ToString(), ct };
                }
                res = f.buttonclick;
                f.Dispose();
                return r;
            }
            /// <summary>
            /// 选择驱动器 
            /// 返回数组 [0] 选择的磁盘盘符 [1] 卷标 [2] 类型(与Type 参数一致 FIXED 磁盘 CDROM 光盘 CANNOTUSE 不可用) [3] 总大小(GB) [4] 可用大小(GB)
            /// </summary>
            /// <param name="Type">模式 [FIXED] 只显示固定磁盘 [CDROM] 只显示光盘 [ALL] 显示所有</param>
            /// <param name="title"></param>
            /// <param name="click">输出的窗体点击 [ok]确定 [exit]取消 没选择</param>
            /// <returns></returns>
            public static string[] ShowChooseDiskDialog(string Type, string title, out string click)
            {
                string[] rets;
                SGForm_CommonDialogs s = new SGForm_CommonDialogs("diskchoose", title, new string[] { Type });
                s.ShowDialog();
                rets = s.Returns;
                click = s.ButtonClick;
                return rets;
            }
            /// <summary>
            /// 显示选择颜色对话框
            /// </summary>
            /// <param name="DefaultColor">默认颜色</param>
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
            /// 显示文件属性对话框
            /// </summary>
            /// <param name="FilePath">文件的路径</param>
            public static void ShowFileAttDialog(string FilePath)
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
            /// 显示从指定的文件夹中读取ext扩展名类型的文件 , 并加载到ListView 返回文件的路径或者是空(未选择)
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="sectitle">副标题</param>
            /// <param name="folder">文件夹</param>
            /// <param name="ext">扩展名(*.exe)</param>
            /// <param name="option">搜索操作</param>
            /// <param name="res">窗体点击 [ok]确认 [exit]取消</param>
            /// <param name="ico">文件的图标([fromfile]文件的图标 [...]指定的DLL ICO文件)</param>
            /// <returns></returns>
            public static string ShowFileListInListView(string title, string sectitle, string folder, string ext, System.IO.SearchOption option, out string res, string ico = "fromfile")
            {
                string cf = "";
                string btnclick = "exit";
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(folder, false) == true)
                {
                    string[] lis = SGFunction.FileSystemOperate.FileSystemOperate_GetFiles(folder, ext, option);
                    if (lis != null)
                    {
                        if (lis.Length > 0)
                        {
                            SGForm_FindFileListAndShowInListView f = new SGForm_FindFileListAndShowInListView(title, sectitle, lis, folder, ext, option, ico);
                            f.ShowDialog();
                            btnclick = f.btnclick;
                            cf = f.ret;
                        }
                        else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到可用的文件", 2); }
                    }
                    else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到可用的文件", 2); }
                    res = btnclick;
                    return cf;
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到可用的文件", 2); res = "exit"; return ""; }
            }
            /// <summary>
            /// 调用系统复制文件窗体并复制文件
            /// </summary>
            /// <param name="FilesAndFolderPath">文件(夹)路径的数组</param>
            /// <param name="CopyToFolderPath">复制的位置</param>
            /// <returns></returns>
            public static bool CopyFilesWithSystemProcessDialog(string[] FilesAndFolderPath, string CopyToFolderPath)
            {
                SHFILEOPSTRUCT pm = new SHFILEOPSTRUCT();
                pm.wFunc = FO_COPY;
                //pm.pFrom = FileOrFolderPath;
                if (System.IO.Directory.Exists(CopyToFolderPath) == false) { SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(CopyToFolderPath); }
                string path = "";
                for (int k = 1; k <= FilesAndFolderPath.Length; k++)
                {
                    path = path + FilesAndFolderPath[k - 1] + "\0";
                }
                pm.pFrom = path;
                pm.pTo = CopyToFolderPath;
                pm.fFlags = FOF_ALLOWUNDO;
                pm.lpszProgressTitle = "复制文件...";
                return !SHFileOperation(pm);

            }
            /// <summary>
            /// 调用系统移动文件对话框并移动文件
            /// </summary>
            /// <param name="FilesAndFolderPath">文件(夹)路径的数组</param>
            /// <param name="MoveToFolderPath">移动到的目录</param>
            /// <returns></returns>
            public static bool MoveFilesWithSystemProcessDialog(string[] FilesAndFolderPath, string MoveToFolderPath)
            {
                SHFILEOPSTRUCT pm = new SHFILEOPSTRUCT();
                pm.wFunc = FO_MOVE;
                if (System.IO.Directory.Exists(MoveToFolderPath) == false) { SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(MoveToFolderPath); }
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
            /// <summary>
            /// 保存文件对话框
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="ext">扩展名</param>
            /// <param name="defaultext">默认的扩展名</param>
            /// <param name="filename">默认的文件名</param>
            /// <param name="path">初始路径</param>
            /// <returns></returns>
            public static string SaveFileDialog(string title, string ext, string defaultext, string filename = "", string path = "")
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Title = title;
                d.FileName = filename;
                d.Filter = ext;
                d.SupportMultiDottedExtensions = false;
                d.DefaultExt = defaultext;
                d.AddExtension = true;
                d.InitialDirectory = path;
                d.ShowDialog();
                return d.FileName;
            }
            /// <summary>
            /// 保存文件对话框
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="ext">扩展名</param>
            /// <param name="defaultext">默认的扩展名</param>
            /// <param name="res">返回的窗体点击结果</param>
            /// <param name="filename">默认的文件名</param>
            /// <param name="path">初始路径</param>
            /// <returns></returns>
            public static string SaveFileDialog_OutResult(string title, string ext, string defaultext, out  DialogResult res, string filename = "", string path = "")
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Title = title;
                d.FileName = filename;
                d.Filter = ext;
                d.SupportMultiDottedExtensions = false;
                d.DefaultExt = defaultext;
                d.AddExtension = true;
                d.InitialDirectory = path;
                DialogResult res1 = d.ShowDialog();
                res = res1;
                return d.FileName;
            }
            /// <summary>
            /// 显示帮助对话框 返回[exit]用户点击了取消或者出现了错误 [b1]左按钮 [b2]右按钮 [b3]记住了左按钮 [b4]记住了有=右按钮
            /// </summary>
            /// <param name="folder">帮助文件夹 包含必要的星系文件config.sgcf</param>
            /// <param name="isauto">返回的值是否是“记住了选择”</param>
            /// <param name="shownotagain">是否允许显示“记住选择”选项</param>
            /// <returns></returns>
            public static string ShowHelpUserToDoDialog(string folder, out bool isauto, bool shownotagain = true)
            {
                string cfg = folder + "\\config.sgcf";
                string auto = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("auto", "click", "", cfg, false);
                string c = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("main", "count", "", cfg, false);
                int count; int.TryParse(c, out count);
                if (auto.ToLower() == "")
                {
                    if (count > 0)
                    {
                        string title = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("main", "title", "", cfg, false);
                        string[] imagespath = new string[count];
                        string[] texts = new string[count];
                        string btnleft = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("buttons", "left", "", cfg, false);
                        string btnright = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("buttons", "right", "", cfg, false);
                        for (int j = 1; j <= count; j++)
                        {
                            imagespath[j - 1] = folder + "\\" + SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("images", j.ToString(), "", cfg, false);
                            texts[j - 1] = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("texts", j.ToString(), "", cfg, false);
                        }
                        SGUserControl_HelpUserToDo f = new SGUserControl_HelpUserToDo(imagespath, texts, title, cfg, btnleft, btnright, shownotagain);
                        string j1 = ShowSpecialAndGuideDialog(title, f).ToString();
                        switch (j1.ToLower())
                        {
                            case "b3":
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("auto", "click", "b3", "Config", false, cfg);
                                isauto = true;
                                return "b1";
                            case "exit":
                                isauto = false;
                                return "exit";
                            case "b4":
                                isauto = true;
                                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("auto", "click", "b4", "Config", false, cfg);
                                return "b2";
                            default:
                                isauto = false;
                                return j1;
                        }
                    }
                    else
                    {
                        isauto = false;
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法显示帮助，因为无法加载必要的信息。", 2);
                        return "exit";
                    }
                }
                else
                {
                    isauto = true;
                    return auto;
                }
            }
            /// <summary>
            /// 显示选择Modern程序的对话框 返回数组[0]AppId [1]名称 [2]图标
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="res">窗体点击结果 [ok]选择了 [exit]点击了取消</param>
            /// <returns></returns>
            public static string[] ShowChooseModernAppDialog(string title, out string res)
            {
                SGForm_CommonDialogs d = new SGForm_CommonDialogs("modern", title, new string[] { });
                d.ShowDialog();
                res = d.ButtonClick;
                return d.Returns;
            }
            /// <summary>
            /// 显示选择CLSID对话框 返回数组[0]CLSID [1]名字 [2]图标
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="res">窗体点击结果 [exit]退出 [ok]点击了确认</param>
            /// <returns></returns>
            public static string[] ShowChooseCLSIDDialog(string title, out string res)
            {
                SGForm_CommonDialogs d = new SGForm_CommonDialogs("clsid", title, new string[] { });
                d.ShowDialog();
                res = d.ButtonClick;
                return d.Returns;
            }
            /// <summary>
            /// 显示特殊窗体和向导式窗体 [ok]确认 [exit]退出 [...]也可自定义,在用户控件FindForm()的Tag 如果isshowdialog为false 则窗体不反悔任何结果(null)
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="u">用户控件</param>
            /// <param name="isshowdialog">是否Show Dialog一般在没有父系窗体下使用</param>
            /// <returns></returns>
            public static object ShowSpecialAndGuideDialog(string title, UserControl u, bool isshowdialog = true)
            {
                if (isshowdialog == true)
                {
                    SGForm_GuidDialog f = new SGForm_GuidDialog(title, u);
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.ShowDialog();
                    object o = f.Returns;
                    f.Dispose();
                    return o;
                }
                else
                {
                    SGForm_GuidDialog f = new SGForm_GuidDialog(title, u);
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.Show();
                    return null;
                }
            }
            /// <summary>
            /// 显示多任务选择窗体 [t(任务号)] 或者空
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="tasks">数组标题</param>
            /// <param name="ico">左侧图标 如果你让所有的TASK为一个图标 直接输入图标即可 如果你想让不同的TASK有不同的图标,请将图标用[|]隔开</param>
            /// <returns></returns>
            public static string ChooseTaskDialog(string title, string[] tasks, string ico = "%windir%\\system32\\imageres.dll,11")
            {
                SGForm_TasksChoose f = new SGForm_TasksChoose(title, tasks, ico);
                f.ShowDialog();
                return f.Returns;
            }
            /// <summary>
            /// 显示选择图标对话框
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="defaulticon">默认的图标</param>
            /// <param name="formresult">窗体的按钮点击结果 [exit]点击了取消 [ok]点击了确定</param>
            /// <param name="defaultselectindex">默认选中的Index</param>
            /// <returns></returns>
            public static string SelectIconDialog(string title, string defaulticon, out string formresult)
            {
                string[] n = new string[] { defaulticon };
                SGForm_CommonDialogs d = new SGForm_CommonDialogs("icon", title, n);
                d.ShowDialog();
                string f = "", i = "";
                if (d.Returns.Length == 2)
                {
                    f = d.Returns[0];
                    i = d.Returns[1];
                }
                formresult = d.ButtonClick;
                return f + "," + i;
            }
            /// <summary>
            /// 显示用于遮挡后面内容的窗体
            /// </summary>
            /// <param name="bf">遮挡窗体的函数 摄影完之后需要手动关闭 bf.close</param>
            public static void ShowBackgroudForm(SGForm_BackgroundForm bf)
            {
                int locaition_x, location_y; int sizex, sizey;
                System.Drawing.Rectangle rect = SGFunction.ApplicationSetting.GetCurrentActivedForRectagle();
                locaition_x = rect.X; location_y = rect.Y; sizex = rect.Size.Width; sizey = rect.Size.Height;
                bf.Location = new Point(locaition_x, location_y);
                bf.Size = new Size(sizex, sizey);
                bf.Show();
            }
            /// <summary>
            /// 显示一个必须等待用户确认的消息框(返回点击的按钮的值 [b1]=B1 [b2]=B2 [b1+复选框打了勾]=B3 [b2+复选框打了勾]=B4 [未点击任何按钮]=空)
            /// </summary>
            /// <param name="title">消息标题</param>
            /// <param name="message">消息</param>
            /// <param name="button1">按钮1(左边的按钮) 如果值为空 , 则不显示该按钮</param>
            /// <param name="button2">按钮2(左边的按钮) 如果值为空 , 则不显示该按钮</param>
            /// <param name="defaultbutton">默认选中的按钮 [b1] [b2]</param>
            /// <param name="messagetype">消息的类型 [info] 普通消息 [ques] 询问用户 [error]错误 默认为[info]</param>
            /// <param name="moreinfo">更多的信息</param>
            /// <param name="hasclick">指定消息框上的复选框的标题 如果值为空则不显示复选框</param>
            /// <returns></returns>
            public static string MessageDialog_MustClick(string title, string message, string button1, string button2, string defaultbutton, string messagetype = "info", string moreinfo = "", string hasclick = "")
            {
                SGForm_BackgroundForm bf = new SGForm_BackgroundForm(Color.FromArgb(185,185,185), false, 0.7);
                SGFunction.CommonDialogs.ShowBackgroudForm(bf);
                Form_MessageDialog m = new Form_MessageDialog(messagetype);

                Color defaultbtnbackcolor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
                
                switch (messagetype.ToLower())
                {
                    case "info":
                        m.pictureBox1.Image = Properties.Resources.Message_OK;
                        break;
                    case "error":
                        m.pictureBox1.Image = Properties.Resources.Message_Error;
                        break;
                    case "ques":
                        m.pictureBox1.Image = Properties.Resources.Message_Question;
                        break;
                    default:
                        m.pictureBox1.Image = Properties.Resources.Message_OK;
                        break;
                }
                 
                if (hasclick != "") { m.checkBox1.Visible = true; m.checkBox1.Text = hasclick; m.checkBox1.ForeColor = defaultbtnbackcolor; } else { m.checkBox1.Text = ""; m.checkBox1.Visible = false; }
                m.bordercolor = defaultbtnbackcolor;
                m.panel1.BackColor = defaultbtnbackcolor;
                m.label1.Text = m.Text = title;
                m.label2.Text = message;
                m.label3.Text = moreinfo;
                if (moreinfo != "")
                {
                    m.label3.Visible = true;
                    m.ForeColor = defaultbtnbackcolor;
                    m.MyNormalButton1.Visible = true;
                    m.panel2.Visible = false;
                }
                else { m.label3.Visible = false; m.MyNormalButton1.Visible = false; m.panel2.Visible = false; }
                //按钮设置
                Color o_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "bk");
                Color o_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "fr");
                Color o1_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "bk");
                Color o1_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "fr");
                if (button1 != "") { m.MyNormalButton3.Visible = true; m.MyNormalButton3.Text = button1; } else { m.MyNormalButton3.Visible = false; }
                if (button2 != "") { m.MyNormalButton2.Visible = true; m.MyNormalButton2.Text = button2; } else { m.MyNormalButton2.Visible = false; }
                if (defaultbutton != "")
                {
                    if (defaultbutton.ToLower() == "b1")
                    {
                        m.MyNormalButton3.BackColor = o_bk;
                        m.MyNormalButton3.ForeColor = o_fr ;
                        m.MyNormalButton2.BackColor = o1_bk;
                        m.MyNormalButton2.ForeColor = o1_fr;
                        m.AcceptButton = m.MyNormalButton3;
                    }
                    else
                    {
                        m.MyNormalButton2.BackColor = o_bk;
                        m.MyNormalButton2.ForeColor = o_fr;
                        m.MyNormalButton3.BackColor = o1_bk;
                        m.MyNormalButton3.ForeColor = o1_fr;
                        m.AcceptButton = m.MyNormalButton2;
                    }
                }
                //设定大小
                if (hasclick == "" && moreinfo == "")
                {
                    //什么都没有
                    m.Size = new Size(m.Size.Width, m.MyNormalButton1.Location.Y + 20 + m.MyNormalButton1.Size.Height);
                }
                if (hasclick == "" && moreinfo != "")
                {
                    //有信息但没有复选框
                    m.Size = new Size(m.Size.Width, m.MyNormalButton1.Location.Y + 20 + m.MyNormalButton1.Size.Height);
                }
                if (hasclick != "" && moreinfo != "")
                {
                    //什么都有
                    m.checkBox1.Location = new Point(123, 140);
                    m.Size = new Size(m.Size.Width, m.MyNormalButton1.Location.Y + 20 + m.MyNormalButton1.Size.Height);
                }
                if (hasclick != "" && moreinfo == "")
                {
                    m.checkBox1.Location = new Point(13,140);
                    //只有复选框
                    m.Size = new Size(m.Size.Width, m.MyNormalButton1.Location.Y + 20 + m.MyNormalButton1.Size.Height);
                }
                //bf.ShowDialog();
                m.ShowDialog();
                
                bf.Close();
                string ret = m.clickret;
                return ret.ToLower();
            }
            /// <summary>
            /// 显示一个只显示消息的消息框(用户只能看消息)
            /// </summary>
            /// <param name="title">提示文字</param>
            /// <param name="count">现实的事件(秒)</param>
            /// <param name="hostfrm">控件的父系窗体</param>
            /// <param name="host">控件</param>
            /// <param name="showtype">显示模式 [up]显示在控件上面 [down]显示在空间下面 [normal]显示在鼠标点击的位置</param>
            /// <param name="jiange">显示位置与控件的间隔</param>
            /// <param name="ismouseevent">如果[true]则显示在鼠标点击的位置 [false]默认</param>
            public static void MessageDialog_ShowInfo(string title, int count)
            {
                Point n = SGFunction.SystemFunctionAndInformation.GetMouseLocation();
                Form_MessageDialog_Info m = new Form_MessageDialog_Info(title, count, n);
                m.timer1.Interval = count * 1000;
                m.Show();
            }
            /// <summary>
            /// 为系统齿轮提供的通用窗体添加边框
            /// </summary>
            /// <param name="e">PaintEventArgs 事件参数</param>
            /// <param name="frm">窗体</param>
            /// <param name="r">R</param>
            /// <param name="g">G</param>
            /// <param name="b">B</param>
            public static void SystemGearDialog_DrawBorder(PaintEventArgs e, Form frm)
            {
                Color ma = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
                Color bordercolor = Color.FromArgb(ma.R, ma.G, ma.B);
                Pen p = new Pen(bordercolor, 3);//设置笔的粗细为,颜色为蓝色
                Graphics g3 = e.Graphics;
                Point f, l;
                f = new Point(0, 0);
                l = new Point(0, frm.Size.Height);
                g3.DrawLine(p, f, l);
                Point rf, rl;
                rf = new Point(frm.Width - 1, 0);
                rl = new Point(frm.Width - 1, frm.Height);
                Graphics g1 = e.Graphics;
                g1.DrawLine(p, rf, rl);
                //drawdown
                Point df, dl;
                df = new Point(0, frm.Height - 1);
                dl = new Point(frm.Width, frm.Height - 1);
                Graphics g2 = e.Graphics;
                g2.DrawLine(p, df, dl);
            }
            /// <summary>
            /// 为系统齿轮提供的通用窗体添加加载动画
            /// </summary>
            /// <param name="e">EventArgs 事件参数</param>
            /// <param name="frm">窗体</param>
            public static void SystemGearDialog_LoadingFlash(EventArgs e, Form frm)
            {

                //AnimateWindow(this.Handle, 1000, 0x20010);   // 居中逐渐显示。
                AnimateWindow(frm.Handle, 110, 0xA0000); // 淡入淡出效果。
                //AnimateWindow(this.Handle, 1000, 0x60004); // 自上向下。
                //AnimateWindow(this.Handle, 1000, 0x20004); // 自上向下。
            }
            /// <summary>
            /// 为系统齿轮提供的通用窗体添加关闭动画
            /// </summary>
            /// <param name="e">EventArgs 事件参数</param>
            /// <param name="frm">窗体</param>
            public static void SystemGearDialog_ClosingFlash(EventArgs e, Form frm)
            {
                AnimateWindow(frm.Handle, 110, 0x90000); // 淡入淡出效果。
            }
            /// <summary>
            /// 提供一个需要用户输入信息的对话框
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="secondtitle">副标题</param>
            /// <param name="defaultvalue">默认值</param>
            /// <param name="allowemptystring">是否允许空字符</param>
            /// <param name="texttip">提示文字</param>
            /// <param name="formresult">窗体点击结果 [exit]取消 [ok]确定</param>
            /// <returns></returns>
            public static string InputDialog(string title, string secondtitle, string defaultvalue, bool allowemptystring, string texttip, out string formresult)
            {
                SGForm_CommonDialogs f = new SGForm_CommonDialogs("input", title, new string[] { secondtitle, defaultvalue, allowemptystring.ToString(), texttip });
                f.ShowDialog();
                formresult = f.ButtonClick;
                return f.Returns[0];
            }
            /// <summary>
            /// 显示文件打开对话框
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="exts">扩展名 [Image]支持的图像文件</param>
            /// <param name="readlink">是否解析LNK的位置</param>
            /// <param name="defaultfilename">默认的文件名</param>
            /// <param name="checkFileExists">是否检查问文件存在</param>
            /// <param name="selectpath">默认的打开路径</param>
            /// <returns></returns>
            public static string OpenFileDialog(string title, string exts, bool readlink = true, string defaultfilename = "", bool checkFileExists = true, string selectpath = "")
            {
                OpenFileDialog f = new OpenFileDialog();
                f.CheckFileExists = checkFileExists;
                f.CheckPathExists = checkFileExists;
                f.Title = title;
                f.DereferenceLinks = readlink;
                switch (exts.ToLower())
                {
                    case "image":
                        f.Filter = "图像文件(*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                        break;
                    default:
                        f.Filter = exts;
                        break;
                }
                f.FileName = defaultfilename;
                f.InitialDirectory = selectpath;
                f.ShowDialog();
                string j = f.FileName;
                return j;
            }
            /// <summary>
            /// 打开文件对话框 返回窗体点击结果
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="exts">扩展名</param>
            /// <param name="checkex">是否检查文件是否存在</param>
            /// <param name="diares">输出的点击结果</param>
            /// <param name="readlink">是否解析LNK</param>
            /// <param name="defaultfilename">默认的名称</param>
            /// <returns></returns>
            public static string OpenFileDialog_OutResult(string title, string exts, bool checkex, out DialogResult diares, bool readlink = true, string defaultfilename = "")
            {
                OpenFileDialog f = new OpenFileDialog();
                f.Title = title;
                f.DereferenceLinks = readlink;
                f.CheckFileExists = f.CheckPathExists = checkex;
                switch (exts.ToLower())
                {
                    case "image":
                        f.Filter = "图像文件(*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                        break;
                    default:
                        f.Filter = exts;
                        break;
                }
                f.FileName = defaultfilename;
                DialogResult res = f.ShowDialog();
                string j = f.FileName;
                diares = res;
                return j;
            }
            /// <summary>
            /// 显示打开文件夹对话框
            /// </summary>
            /// <param name="title">标题</param>
            /// <returns></returns>
            public static string OpenFolderDialog(string title)
            {
                try
                {
                    FolderBrowserDialog f = new FolderBrowserDialog();
                    f.Description = title;
                    f.ShowDialog();
                    string j = f.SelectedPath;
                    return j;
                }
                catch { return ""; }
            }
        }
        /// <summary>
        /// 提供对系统注册表的访问功能
        /// </summary>
        public class RegistryOperate
        {
            /// <summary>
            /// 将指定location导出为文件
            /// </summary>
            /// <param name="location">路径 + 键的名称 例如"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Directory\background\shell\我的右键菜单"</param>
            /// <param name="file">导出的文件</param>
            public static void RegistryOperate_ExportFile(string location, string file)
            {
                string app = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\reg.exe";
                string cmd = @"export """ + location + @""" """ + file + @"""";
                SGFunction.SystemFunctionAndInformation.ShellPrograms(app, cmd, true, false, true, true);
            }
            /// <summary>
            /// 从指定的文件中导入到注册表
            /// </summary>
            /// <param name="file">*.REG文件</param>
            public static void RegistryOperate_ImportFile(string file)
            {
                string app = Environment.GetEnvironmentVariable("windir") + "\\regedit.exe";
                string cmd = @"/s """ + file + @"""";
                SGFunction.SystemFunctionAndInformation.ShellPrograms(app, cmd, true, false, true, true);
            }
            public static void RegistryOperate_AddRegistrySecurity(string Str_FileName, string Account, RegistryRights Rights, AccessControlType ControlType)
            {
                RegistryKey RegKey = Registry.ClassesRoot.OpenSubKey(@"CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}");
                RegistrySecurity RegkeyAcl = RegKey.GetAccessControl();
                RegistryAccessRule AccessRule = new RegistryAccessRule(Account, Rights, ControlType);
                RegkeyAcl.AddAccessRule(AccessRule);
                RegKey.SetAccessControl(RegkeyAcl);
                RegKey.Close();
            }

            /// <summary>
            /// 在注册表路径location中遍历所有键, 并查找该键下名为name的值是否满足等于veystr, 若满足则返回对应的键的名称 否则返回空值
            /// </summary>
            /// <param name="root">主键</param>
            /// <param name="location">路径</param>
            /// <param name="name">键值的名称</param>
            /// <param name="veystr">判断的字符</param>
            /// <param name="keyname">返回的键的名称</param>
            /// <param name="mustmatch">是否完全匹配</param>
            public static void RegistryOperate_FindValueInAllSubKeys(RegistryKey root, string location, string name, string veystr, out string keyname, bool mustmatch = true)
            {
                try
                {
                    string ret = "";
                    if (root.OpenSubKey(location) != null)
                    {
                        string[] o = root.OpenSubKey(location).GetSubKeyNames();
                        for (int j = 1; j <= o.Length; j++)
                        {
                            string na = root.OpenSubKey(location).OpenSubKey(o[j - 1]).GetValue(name, "").ToString();
                            if (mustmatch == true)
                            {
                                if (na.ToLower() == veystr.ToLower())
                                {
                                    ret = o[j - 1];
                                    break;
                                }
                                else { ret = ""; }
                            }
                            else
                            {
                                int orl = na.Length;
                                na = na.ToLower().Replace(veystr.ToLower(), "");
                                int nl = na.Length;
                                if (nl < orl) { ret = o[j - 1]; break; } else { ret = ""; }
                            }
                        }
                        keyname = ret;
                    }
                    else { keyname = ""; }
                }
                catch { keyname = ""; }
            }
            /// <summary>
            /// 对注册表的值进项操作(不可以返回OBJECT类型的值)
            /// </summary>
            /// <param name="operatetype">操作代号 [get] 读取一个值 [write]写入一个新的值 [delete]删除值</param>
            /// <param name="rootkey">注册表路径的主键</param>
            /// <param name="location">键的路径</param>
            /// <param name="valuename">值的名称</param>
            /// <param name="defaultvalueornewvlaue">对于[get] [delete]为可选参数 : 当vlauename不存在时返回的默认值 ; 对于[write]为必选的参数 : 新的值</param>
            /// <param name="kind">确定写入新的值的类型</param>
            /// <param name="hasvar">是否包含系统齿轮支持的变量</param>
            /// <returns></returns>
            public static string RegistryOperate_ValueOperate(string operatetype, RegistryKey rootkey, string location, string valuename, string defaultvalueornewvlaue = "", RegistryValueKind kind = RegistryValueKind.String, bool hasvar = false)
            {
                try
                {
                    switch (operatetype.ToLower())
                    {
                        case "get":
                            string o = rootkey.OpenSubKey(location).GetValue(valuename, defaultvalueornewvlaue).ToString();
                            if (hasvar == true) { o = SGFunction.PathOperate.ConvertStringToTurePath(o); }
                            return o;
                        case "write":
                            if (rootkey.OpenSubKey(location) != null)
                            {
                                string j = defaultvalueornewvlaue;
                                if (hasvar == true) { j = SGFunction.PathOperate.ConvertStringToTurePath(j); }
                                rootkey.OpenSubKey(location, true).SetValue(valuename, j, kind);
                            }
                            else
                            {
                                rootkey.CreateSubKey(location);
                                string j2 = defaultvalueornewvlaue;
                                if (hasvar == true) { j2 = SGFunction.PathOperate.ConvertStringToTurePath(j2); }
                                rootkey.OpenSubKey(location, true).SetValue(valuename, j2, kind);
                            }
                            break;
                        case "delete":
                            rootkey.OpenSubKey(location, true).DeleteValue(valuename, false);
                            break;
                    }
                    return "";
                }
                catch { return defaultvalueornewvlaue; }
            }
            /// <summary>
            /// 对注册表的值进项操作(可以返回OBJECT类型的值)
            /// </summary>
            /// <param name="operatetype">操作代号 [get] 读取一个值 [write]写入一个新的值 [delete]删除值</param>
            /// <param name="rootkey">注册表路径的主键</param>
            /// <param name="location">键的路径</param>
            /// <param name="valuename">值的名称</param>
            /// <param name="defaultvalueornewvlaue">对于[get] [delete]为可选参数 : 当vlauename不存在时返回的默认值 ; 对于[write]为必选的参数 : 新的值</param>
            /// <param name="kind">确定写入新的值的类型</param>
            /// <returns></returns>
            public static object RegistryOperate_ValueOperate_GetObject(string operatetype, RegistryKey rootkey, string location, string valuename, string defaultvalueornewvlaue = "", RegistryValueKind kind = RegistryValueKind.String)
            {
                try
                {
                    switch (operatetype.ToLower())
                    {
                        case "get":
                            object o = rootkey.OpenSubKey(location).GetValue(valuename, defaultvalueornewvlaue);
                            return o;
                        case "write":
                            if (rootkey.OpenSubKey(location) != null)
                            {
                                string j = defaultvalueornewvlaue;
                                rootkey.OpenSubKey(location, true).SetValue(valuename, j, kind);
                            }
                            else
                            {
                                rootkey.CreateSubKey(location);
                                string j2 = defaultvalueornewvlaue;
                                rootkey.OpenSubKey(location, true).SetValue(valuename, j2, kind);
                            }
                            break;
                        case "delete":
                            rootkey.OpenSubKey(location, true).DeleteValue(valuename, false);
                            break;
                    }
                    return "";
                }
                catch { return defaultvalueornewvlaue; }
            }
            /// <summary>
            /// 删除注册闹钟一个名为ValueName的值
            /// </summary>
            /// <param name="RootKey">主键</param>
            /// <param name="Location">位置</param>
            /// <param name="ValueName">值的名称</param>
            /// <returns></returns>
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
            /// <summary>
            /// 创建一个新的键
            /// </summary>
            /// <param name="RootKey">主键</param>
            /// <param name="Location">位置</param>
            /// <param name="NewSubKeyName">键的名称</param>
            /// <returns></returns>
            public static bool RegistryOperate_CreateSubKey(RegistryKey RootKey, string Location, string NewSubKeyName)
            {
                try
                {
                    if (Location == "")
                    {
                        RootKey.CreateSubKey(NewSubKeyName);
                    }
                    else
                    {
                        if (null == RootKey.OpenSubKey(Location))
                        {
                            RootKey.CreateSubKey(Location);
                        }
                        RootKey.CreateSubKey(Location + "\\" + NewSubKeyName);
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            /// <summary>
            /// 删除一个键
            /// </summary>
            /// <param name="RootKey">主键</param>
            /// <param name="Location">见得位置</param>
            /// <param name="SubKeyName">简明</param>
            /// <returns></returns>
            public static bool RegistryOperate_DeleteSubKey(RegistryKey RootKey, string Location, string SubKeyName)
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
                catch
                {
                    return false;
                }
            }
            /// <summary>
            /// 获取Location下的所有键的名称
            /// </summary>
            /// <param name="RootKey">主键</param>
            /// <param name="Location">位置</param>
            /// <returns></returns>
            public static string[] RegistryOperate_GetSubkeys(RegistryKey RootKey, string Location)
            {
                try
                {
                    string[] h = new string[0]; h = RootKey.OpenSubKey(Location).GetSubKeyNames();
                    return h;
                }
                catch
                {
                    string[] g = new string[0];
                    return g;
                }
            }
            /// <summary>
            /// 获取某个注册表项下的所有键值得名称
            /// </summary>
            /// <param name="RootKey">主键</param>
            /// <param name="Location">路径</param>
            /// <returns></returns>
            public static string[] RegistryOperate_GetKeys(RegistryKey RootKey, string Location)
            {
                try
                {
                    string[] h = new string[0]; h = RootKey.OpenSubKey(Location).GetValueNames();
                    return h;
                }
                catch
                {
                    string[] g = new string[0];
                    return g;
                }
            }
            /// <summary>
            /// 判断注册表项是否存在
            /// </summary>
            /// <param name="root">主键</param>
            /// <param name="loc">路径</param>
            /// <param name="name">名称</param>
            /// <returns></returns>
            public static bool RegostryOperate_FindSubKeyIsExists(RegistryKey root, string loc, string name)
            {
                try
                {
                    bool vla = false;
                    string[] gh = root.OpenSubKey(loc).GetSubKeyNames();
                    foreach (string v in gh)
                    {
                        if (v.ToLower() == name.ToLower())
                        {
                            vla = true;
                        }
                        else { vla = false; }
                    }
                    return vla;
                }
                catch { return false; }
            }
        }
        /// <summary>
        /// 提供对字符串类型数据的处理功能
        /// </summary>
        public class StringOperate
        {
            /// <summary>
            /// 转换为INT整数
            /// </summary>
            /// <param name="str">字符</param>
            /// <param name="def">返回的默认值字符</param>
            /// <returns></returns>
            public static int ConvertToInt32(string str, int def = 0)
            {
                int j = def;
                bool k = int.TryParse(str, out j);
                if (k = true)
                {
                    return j;
                }
                else
                {
                    return def;
                }
            }
            /// <summary>
            /// 随机产生字符
            /// </summary>
            /// <param name="Length">字符长度</param>
            /// <returns></returns>
            public static string GetRadamString(int Length)
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

            /// <summary>
            /// 在str中须寻找指定的字符串findstr [true]存在 [false]不存在
            /// </summary>
            /// <param name="str">字符串</param>
            /// <param name="findstr">查找的字符串</param>
            /// <returns></returns>
            public static bool FindString(string str, string findstr)
            {
                try
                {
                    Regex r = new Regex(findstr); // 定义一个Regex对象实例  
                    Match m = r.Match(str); // 在字符串中匹配  
                    if (m.Success) { return true; } else { return false; }
                }
                catch { return false; }
            }
        }
        /// <summary>
        /// 提供对路径的字符串的转换方法
        /// </summary>
        public class PathOperate
        {
            /// <summary>
            /// 路径合法化
            /// </summary>
            /// <param name="path">路径</param>
            /// <returns></returns>
            public static string IMPORTANT_PathUseful(string path)
            {
                path = SGFunction.PathOperate.ConvertStringToTurePath(path, path);
                path = SGFunction.PathOperate.DeletePathYinHao(path);
                if (System.IO.File.Exists(path) == true)
                {
                    return path;
                }
                else
                {
                    //no comp
                    path = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(path, path);
                    if (System.IO.File.Exists(path) == true)
                    {
                        return path;
                    }
                    else
                    {
                        //i dont know
                        return path;
                    }
                }
            }
            /// <summary>
            /// 删除路径纸张包含的引号
            /// </summary>
            /// <param name="FileName">路径</param>
            /// <returns></returns>
            public static string DeletePathYinHao(string FileName)
            {
                if (System.IO.File.Exists(FileName) == true)
                {
                    return FileName;
                }
                else
                {
                    if (FileName.Length >= 5)
                    {
                        FileName = FileName.Trim();
                        if (FileName.Substring(0, 1) == @"""" && FileName.Substring(FileName.Length - 1, 1) == @"""")
                        {
                            //路径存在引号
                            //去掉引号
                            string nf = FileName.Substring(1, FileName.Length - 1); nf = nf.Substring(0, nf.Length - 1);
                            if (System.IO.File.Exists(nf) == true)
                            {
                                return nf;
                            }
                            else { return FileName; }
                        }
                        else { return FileName; }
                    }
                    else { return FileName; }
                }
            }

            /// <summary>
            /// 用于分离程序的路径和启动参数 返回的路径中不包含引号 如果方法出现了错误 , 返回的值为str arg为空
            /// </summary>
            /// <param name="str">指定的路径和参数</param>
            /// <param name="arg">输出的参数(消除了前后的空格)</param>
            /// <returns></returns>
            public static string SplitCommandAndArg(string str, out string arg)
            {
                /*有两种格式
                 * c:\1.exe 没有命令行
                 * c:\1.exe -f 有命令行 没引号
                 * "c:\1.exe" -f 有命令行 有引号
                 * "c:\1.exe" -f "" 有命令行 后面也有引号
                 * c:\1.exe -f ""有命令行 前面没引号 后面也有引号
                 *  C:\ 1.EXE -T 有命令行 但是路径之中也有空格
                */
                string path = str;
                string argr = "";
                try
                {
                    str = str.Trim();
                    if (str.Length > 0)
                    {
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(str) == true)
                        {
                            //没有参数
                            argr = "";
                        }
                        else
                        {
                            string firststr = str.Substring(0, 1);
                            if (firststr == @"""")
                            {
                                //路径中有引号 路劲终不能有引号
                                int secyhindex = str.IndexOf(@"""", 1);
                                path = str.Substring(1, secyhindex - 1); argr = str.Substring(secyhindex + 1, str.Length - secyhindex - 1);
                            }
                            else
                            {
                                //路径中没有引号 正常情况下 路径是没有空格的
                                //path = str.Substring(0, str.IndexOf(" "));
                                //argr = str.Substring(str.IndexOf(" ") + 1, str.Length - str.IndexOf(" ") - 1);
                                //如果路径后面有命令行 那么后面一覅能有一个 -或者反斜线
                                string[] kongs = path.Split(' ');
                                if (kongs.Length == 0)
                                {
                                    //没有任何空格 应该没有参数
                                    argr = "";
                                }
                                else
                                {
                                    string previous_string = "";
                                    //有一个空格
                                    for (int y = 1; y <= kongs.Length; y++)
                                    {
                                        if (y == 1) { previous_string = kongs[0]; } else { previous_string = previous_string + " " + kongs[y - 1]; }
                                        string newstr = kongs[y].Substring(0, 1);
                                        if (newstr == "-" || newstr == @"/" || SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(previous_string) == true)
                                        {
                                            //还要判断是不是最后一个
                                            if (y == kongs.Length)
                                            {
                                                //是最后一位
                                                argr = kongs[y]; path = previous_string;
                                            }
                                            else
                                            {
                                                //后面还是参数的范围
                                                string lastargs = "";
                                                for (int r = y; r < kongs.Length; r++)
                                                {
                                                    if (r == y)
                                                    {
                                                        //这是第一个
                                                        lastargs = kongs[y];
                                                    }
                                                    else
                                                    {
                                                        lastargs = lastargs + " " + kongs[r];
                                                    }
                                                }
                                                argr = lastargs; path = previous_string;
                                                //退出循环
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(previous_string) == true)
                                            {
                                                //文件存在 那后面的就是参数啦
                                                if (y == kongs.Length)
                                                {
                                                    //是最后一位
                                                    argr = kongs[y]; path = previous_string;
                                                }
                                                else
                                                {
                                                    //后面还是参数的范围
                                                    string lastargs = "";
                                                    for (int r = y; r < kongs.Length; r++)
                                                    {
                                                        if (r == y)
                                                        {
                                                            //这是第一个
                                                            lastargs = kongs[y];
                                                        }
                                                        else
                                                        {
                                                            lastargs = lastargs + " " + kongs[r];
                                                        }
                                                    }
                                                    argr = lastargs; path = previous_string;
                                                    //退出循环
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //空字符 
                    }
                    arg = argr.Trim();
                    return path;
                }
                catch
                {
                    arg = argr;
                    return path;
                }

            }
            /// <summary>
            /// 用于将不完整的字符串转换成绝对路径
            /// </summary>
            /// <param name="Strings">字符串</param>
            /// <param name="DefaultStrings">默认值</param>
            /// <returns></returns>
            public static string ConvertNoCompeletLocationToTurePath(string Strings, string DefaultStrings)
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
            /// <summary>
            /// 将指定的包含系统环境变量字符串转换为路径 注意 : 对于有多个变量可能存在着问题!
            /// </summary>
            /// <param name="Strings">字符串</param>
            /// <param name="DefaultStrings">默认的字符串</param>
            /// <returns></returns>
            public static string ConvertStringToTurePath(string Strings, string DefaultStrings = "")
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
                        string NewEnviron = "";
                        switch (NewString.ToUpper())
                        {
                            case "APPPATH":
                                NewEnviron = Application.StartupPath;
                                break;
                            case "APPEXE":
                                NewEnviron = Application.ExecutablePath;
                                break;
                            case "RESOURCES":
                                NewEnviron = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("ROOT");
                                break;
                            case "MYCOMPUTER_NAME":
                                NewEnviron = SGFunction.ProgramInfo.GetMyComputerName();
                                break;
                            case "EXPLORER_NAME":
                                NewEnviron = SGFunction.ProgramInfo.GetExplorerName();
                                break;
                            case "QQ_PATH":
                                NewEnviron = SGFunction.ProgramInfo.GetQQInstallPath();
                                break;
                            case "THUNDER_PATH":
                                NewEnviron = SGFunction.ProgramInfo.GetThunderInstallPath();
                                break;
                            case "WORD_PATH":
                                NewEnviron = SGFunction.ProgramInfo.GetWordPath();
                                break;
                            case "OUTLOOK_EXE":
                                NewEnviron = SGFunction.ProgramInfo.GetOutlookPath();
                                break;
                            case "STARTMENU_NAME":
                                NewEnviron = SGFunction.ProgramInfo.GetStartMenuName();
                                break;
                            case "DEFAULTBROWSER_NAME": //默认的浏览器名称
                                NewEnviron = SGFunction.ProgramInfo.GetDefaultBrowserName();
                                break;
                            case "DEFAULTBROWSER_EXE": //默认的浏览器EXE文件
                                NewEnviron = SGFunction.ProgramInfo.GetDefaultBrowserEXE();
                                break;
                            case "NT6SETTING_NAME": //WINDOWS NT6设置的名称
                                switch (SGFunction.SystemFunctionAndInformation.GetOSVersion())
                                {
                                    case "6.2":
                                        NewEnviron = "Win8 美化设置";
                                        break;
                                    case "6.3":
                                        NewEnviron = "Win8.1 美化设置";
                                        break;
                                    case "6.4":
                                        NewEnviron = "Win10 美化设置";
                                        break;
                                    case "10.0":
                                        NewEnviron = "Win10 美化设置";
                                        break;
                                }
                                break;
                            default:
                                NewEnviron = Environment.GetEnvironmentVariable(NewString);
                                break;
                        }
                        if (NewEnviron == "")
                        {
                            return DefaultStrings;
                        }
                        else
                        {
                            NewString = Strings.Replace(Strings.Substring(BAIFENHAOLocation, LastBAIFENHAOLocation - (BAIFENHAOLocation - 1)), NewEnviron);
                            return NewString;
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
            public static string ConvertStringToTurePathByZhidingVar(string Strings, string var, string truelocation)
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
                            return Fir + NewString;
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
        }
        /// <summary>
        /// 提供对系统启动菜单的操作
        /// </summary>
        public class BCDOperate
        {
            /// <summary>
            /// 设置系统启动超时时间
            /// </summary>
            /// <param name="time"></param>
            public static void SetTimeout(string time)
            {
                SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", @"/timeout " + time, true, false, true, true);
            }
            /// <summary>
            /// 导出BCD文件
            /// </summary>
            /// <param name="file">导出的文件</param>
            public static void ExpoertBCDToFile(string file)
            {
                string arg = @"/export """ + file + @"""";
                SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg, true, false, true, true);
            }
            /// <summary>
            /// 导入BCD
            /// </summary>
            /// <param name="file">导入的BCD备份文件</param>
            public static void ImporttBCDToFile(string file)
            {
                string arg = @"/import """ + file + @"""";
                SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg, true, false, true, true);
            }
            /// <summary>
            /// 修改启动菜单的顺序
            /// </summary>
            /// <param name="clsids">标识符的顺序 数组</param>
            public static void BCDOperate_ChangeMenuOrder(string[] clsids)
            {
                try
                {
                    string cll = "";
                    for (int o = 1; o <= clsids.Length; o++)
                    {
                        if (o == 1)
                        {
                            cll = clsids[o - 1];
                        }
                        else { cll = cll + " " + clsids[o - 1]; }
                    }
                    //MessageBox.Show(cll);
                    string arg = @"/displayorder " + cll;
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg, true, false, true, true);
                }
                catch { }
            }
            /// <summary>
            /// 创建BCD的临时文件 是以下BCD操作函数的必须的临时文件
            /// </summary>
            /// <returns></returns>
            public static bool BCDOperate_CreateBCDTempFile()
            {
                try
                {
                    string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, true);
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
            /// <summary>
            /// 获取BCD菜单的启动项名称
            /// </summary>
            /// <returns></returns>
            public static string[] BCDOperate_GetBootMenu_Name()
            {
                try
                {
                    string BootMenuItems = "";
                    string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                    int TempFile_LineCount = SGFunction.DataOperate.GetLineCount(TempFile);
                    if (TempFile_LineCount > 15)
                    {
                        for (int k = 1; k <= TempFile_LineCount; k = k + 1)
                        {
                            string ReadOrgTextFromLine = SGFunction.DataOperate.ReadTextInLine(TempFile, k);
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
                        return SGFunction.DataOperate.ConvertStringsToStringArry(BootMenuItems);
                    }
                    else { return null; }
                }
                catch { return null; }
            }
            /// <summary>
            /// 获取BCD菜单的倒计时时间
            /// </summary>
            /// <returns></returns>
            public static string BCDOperate_GetBootMenu_TimeOut()
            {
                try
                {
                    string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                    //MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                    //MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, false, true, null);
                    int TempFile_LineCount = SGFunction.DataOperate.GetLineCount(TempFile);
                    string TimeOut = "";
                    if (TempFile_LineCount > 15)
                    {
                        for (int k = 1; k <= TempFile_LineCount; k = k + 1)
                        {
                            string ReadOrgTextFromLine = SGFunction.DataOperate.ReadTextInLine(TempFile, k);
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
            /// <summary>
            /// 获取BCD菜单对应的CLSID
            /// </summary>
            /// <returns></returns>
            public static string[] BCDOperate_GetBootMenu_GUID()
            {
                try
                {
                    string BootMenuBiaoShiFu = "";
                    string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                    //MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                    //MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, false, true, null);
                    int TempFile_LineCount = SGFunction.DataOperate.GetLineCount(TempFile);
                    if (TempFile_LineCount > 15)
                    {
                        for (int g = 1; g <= TempFile_LineCount; g++)
                        {
                            string ReadLineText = SGFunction.DataOperate.ReadTextInLine(TempFile, g);
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
                            string[] h = SGFunction.DataOperate.ConvertStringsToStringArry(BootMenuBiaoShiFu);
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
            /// <summary>
            /// 获取BCD中默认的菜单
            /// </summary>
            /// <returns></returns>
            public static int BCDOperate_GetBootMenu_GetDefaultBootMenu()
            {
                try
                {
                    int DefaultMenu = 0;
                    string defaultmenu = "";
                    string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                    // MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                    //MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, false, true, null);
                    int TempFile_LineCount = SGFunction.DataOperate.GetLineCount(TempFile);
                    if (TempFile_LineCount > 15)
                    {
                        for (int g = 1; g <= TempFile_LineCount; g++)
                        {
                            string ReadLineText = SGFunction.DataOperate.ReadTextInLine(TempFile, g);
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
                            string[] menugroupguid = SGFunction.BCDOperate.BCDOperate_GetBootMenu_GUID();
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

            /// <summary>
            /// 获取BCD启动项的启动位置
            /// </summary>
            /// <param name="operatecode">输出的Operate代码 除开RAMDISK启动项外 都返回空 RAMDISK返回[SDI的操作代码]</param>
            /// <returns></returns>
            public static string[] BCDOperate_GetBootMenu_GetBootLocation(out string[] operatecode)
            {
                try
                {
                    List<string> ope = new List<string>();
                    string BootDisk = "";
                    string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                    //MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                    //MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, false, true, null);
                    int TempFile_LineCount = SGFunction.DataOperate.GetLineCount(TempFile);
                    if (TempFile_LineCount > 15)
                    {
                        for (int g = 1; g <= TempFile_LineCount; g++)
                        {
                            string ReadLineText = SGFunction.DataOperate.ReadTextInLine(TempFile, g);
                            if (ReadLineText.Length > 6 && g > 5)
                            {
                                if (ReadLineText.Substring(0, 6).ToUpper() == "device".ToUpper())
                                {
                                    string addope = "";
                                    switch (ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim().Substring(0, 3))
                                    {
                                        case "PAR":
                                            string disk = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim().Replace("partition=".ToUpper(), "");
                                            string files = SGFunction.DataOperate.ReadTextInLine(TempFile, g + 1).ToUpper().Replace("PATH", "").Trim().ToUpper();
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
                                            string full = ReadLineText.ToUpper().Replace("device".ToUpper(), "").Trim();
                                            addope = full.Substring(full.LastIndexOf(",") + 1, full.Length - full.LastIndexOf(",") - 1);
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
                                                string files1 = SGFunction.DataOperate.ReadTextInLine(TempFile, g + 1).ToUpper().Replace("PATH", "").Trim().ToUpper();
                                                diskbot = "[启动的分区]" + files1;
                                            }
                                            if (BootDisk != "") { BootDisk = BootDisk + "\n" + diskbot; } else { BootDisk = diskbot; }
                                            break;
                                        case "LOC":
                                            string diskbotv = "[自动搜索位于启动分区下的虚拟磁盘文件]";
                                            if (BootDisk != "") { BootDisk = BootDisk + "\n" + diskbotv; } else { BootDisk = diskbotv; }
                                            break;
                                    }
                                    ope.Add(addope);
                                }
                            }
                        }
                        if (BootDisk != "") { string[] j = SGFunction.DataOperate.ConvertStringsToStringArry(BootDisk); operatecode = ope.ToArray(); return j; } else { operatecode = ope.ToArray(); return null; }
                    }
                    else
                    {
                        operatecode = null;
                        return null;
                    }
                }
                catch { operatecode = null; return null; }
            }
            /// <summary>
            /// 获取BCD的菜单的启动项的类型
            /// </summary>
            /// <returns></returns>
            public static string[] BCDOperate_GetBootMenu_GetBootType()
            {
                try
                {
                    string BootDisk = "";
                    string TempFile = Environment.GetEnvironmentVariable("windir") + @"\Temp\BootMenu.txt";
                    //MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
                    //MyFunctions.ProgramAndLinksOperate.ShellPrograms("cmd.exe", @"/c bcdedit.exe /enum>>%windir%\Temp\BootMenu.txt", true, false, true, false, true, null);
                    int TempFile_LineCount = SGFunction.DataOperate.GetLineCount(TempFile);
                    if (TempFile_LineCount > 15)
                    {
                        for (int g = 1; g <= TempFile_LineCount; g++)
                        {
                            string ReadLineText = SGFunction.DataOperate.ReadTextInLine(TempFile, g);
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
                        if (BootDisk != "") { string[] j = SGFunction.DataOperate.ConvertStringsToStringArry(BootDisk); return j; } else { return null; }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch { return null; }
            }
        }
        /// <summary>
        /// 提供对系统音乐的操作
        /// </summary>
        public class AudioOperate
        {
            #region 播放资源文件WAVE
            [DllImport("winmm.dll")]
            private static extern int sndPlaySoundA(byte[] lpszSoundName, int uFlags);
            private const int SND_ASYNC = 0x1;
            private const int SND_MEMORY = 0x4;
            #endregion
            /// <summary>
            /// 播放音乐
            /// </summary>
            /// <param name="SoundFile">音乐文件 WAV格式</param>
            public static void PlaySound(string SoundFile)
            {
                try
                {
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(SoundFile) == true)
                    {
                        System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                        sp.SoundLocation = SoundFile;
                        sp.Play();
                    }
                }
                catch
                {
                }
            }
            [DllImport("kernel32.dll", EntryPoint = "FindResourceW", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr FindResourceSTR(IntPtr hModule, int lpID, string lpType);
            /// <summary>
            /// 播放资源文件中的的WAVE格式资源
            /// </summary>
            /// <param name="resfile">资源文件</param>
            /// <param name="id">资源编号</param>
            /// <param name="restype">资源的模式 [WAVE]</param>
            public static void PlaySound_InResources(string resfile, int id, string restype = "WAVE")
            {
                try
                {
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(resfile) == true)
                    {
                        string path = resfile;
                        IntPtr hMod = LoadLibraryEx(path, IntPtr.Zero, LOAD_LIBRARY_AS_DATAFILE);
                        IntPtr hRes = FindResourceSTR(hMod, id, restype);
                        uint size = SizeofResource(hMod, hRes);
                        IntPtr pt = LoadResource(hMod, hRes);
                        byte[] bPtr = new byte[size];
                        Marshal.Copy(pt, bPtr, 0, (int)size);
                        //using (System.IO.MemoryStream m = new System.IO.MemoryStream(bPtr))
                        //{
                        //SoundPlayer p = new SoundPlayer(m);
                        //p.Play();
                        sndPlaySoundA(bPtr, SND_MEMORY | SND_ASYNC);
                        // }
                        //p.Stream=m;
                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// 提供图像以及图标的功能
        /// </summary>
        public class ImageAndIconOperate
        {
            /// <summary>
            /// get a certain rectangle part of a known graphic
            /// </summary>
            /// <param name="bitmapPathAndName">path and name of the source graphic</param>
            /// <param name="width">width of the part graphic</param>
            /// <param name="height">height of the part graphic</param>
            /// <param name="offsetX">the width offset in the source graphic</param>
            /// <param name="offsetY">the height offset in the source graphic</param>
            /// <returns>wanted graphic</returns>
            public Bitmap GetPartOfImage(string bitmapPathAndName, int width, int height, int offsetX, int offsetY)
            {
                Bitmap sourceBitmap = new Bitmap(bitmapPathAndName);
                Bitmap resultBitmap = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(resultBitmap))
                {
                    Rectangle resultRectangle = new Rectangle(0, 0, width, height);
                    Rectangle sourceRectangle = new Rectangle(0 + offsetX, 0 + offsetY, width, height);
                    g.DrawImage(sourceBitmap, resultRectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                return resultBitmap;
            }
            /// <summary>
            /// 获取指定文件在Windows 中显示的图标
            /// </summary>
            /// <param name="FilePath">文件名</param>
            /// <param name="retsmall">是否返回小图标</param>
            /// <returns></returns>
            public static Bitmap GetFileIcon(string FilePath, bool retsmall = false)
            {
                try
                {
                    //SHFILEINFO shfi = new SHFILEINFO();//实例化SHFILEINFO类
                    //SHGetFileInfo(files[i], (uint)0x80, ref shfi, (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi), (uint)(0x100 | 0x400)); //获取文件的图标及类型
                    FilePath = PathOperate.IMPORTANT_PathUseful(FilePath);
                    if (System.IO.File.Exists(FilePath) == true)
                    {
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(FilePath).ToUpper() == "EXE")
                        {
                            if (retsmall == false) { return SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(FilePath + ",0"); }
                            else { return SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(FilePath + ",0", "%windir%\\system32\\imageres.dll,2", 16); }
                        }
                        else
                        {
                            if (retsmall == false)
                            {
                                SHFILEINFO shfi = new SHFILEINFO();//实例化SHFILEINFO类
                                SHGetFileInfo(FilePath, (uint)0x80, ref shfi, (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi), (uint)(0x100 | 0x400)); //获取文件的图标及类型
                                //SHFILEINFO _SHFILEINFO = new SHFILEINFO();
                                //IntPtr _IconIntPtr = SHGetFileInfo(FilePath, 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), (uint)(SHGFI.SHGFI_ICON | SHGFI.SHGFI_LARGEICON | SHGFI.SHGFI_USEFILEATTRIBUTES));
                                if (shfi.Equals(IntPtr.Zero)) return null;
                                Icon _Icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();//System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
                                DestroyIcon(shfi.hIcon);
                                return _Icon.ToBitmap();
                            }
                            else
                            {
                                /*
                                SHFILEINFO _SHFILEINFO = new SHFILEINFO();
                                IntPtr _IconIntPtr = SHGetFileInfo(FilePath, 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), (uint)(SHGFI.SHGFI_ICON | SHGFI.SHGFI_LARGEICON | SHGFI.SHGFI_SMALLICON  | SHGFI.SHGFI_USEFILEATTRIBUTES));
                                if (_IconIntPtr.Equals(IntPtr.Zero)) return null;
                                Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
                                return _Icon.ToBitmap();
                                 */
                                SHFILEINFO shfi = new SHFILEINFO();//实例化SHFILEINFO类
                                SHGetFileInfo(FilePath, (uint)0x80, ref shfi, (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi), (uint)(0x100 | 0x400 | 0x1)); //获取文件的图标及类型
                                //SHFILEINFO _SHFILEINFO = new SHFILEINFO();
                                //IntPtr _IconIntPtr = SHGetFileInfo(FilePath, 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), (uint)(SHGFI.SHGFI_ICON | SHGFI.SHGFI_LARGEICON | SHGFI.SHGFI_USEFILEATTRIBUTES));
                                if (shfi.Equals(IntPtr.Zero)) return null;
                                Icon _Icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();//System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
                                DestroyIcon(shfi.hIcon);
                                return _Icon.ToBitmap();
                            }

                        }
                    }
                    else
                    {
                        Icon i;
                        Icon s;
                        SGFunction.ImageAndIconOperate.GetDI(out i, out s);
                        if (retsmall == false)
                        {
                            return i.ToBitmap();
                        }
                        else { return s.ToBitmap(); }
                    }
                }
                catch
                {
                    Icon i;
                    Icon s;
                    SGFunction.ImageAndIconOperate.GetDI(out i, out s);
                    return i.ToBitmap();
                }
            }
            /// <summary>
            /// 获取文件夹或驱动器的额图标
            /// </summary>
            /// <param name="Folder">文件夹</param>
            /// <param name="small">是否返回小图标(32x32)</param>
            /// <returns></returns>
            public static Icon GetFolderOrDiskIcon(string Folder, bool small = false)
            {
                if (small == false)
                {
                    SHFILEINFO _SHFILEINFO = new SHFILEINFO();
                    IntPtr _IconIntPtr = SHGetFileInfo(Folder, 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), (uint)(SHGFI.SHGFI_ICON | SHGFI.SHGFI_LARGEICON));
                    if (_IconIntPtr.Equals(IntPtr.Zero)) return null;
                    Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
                    return _Icon;
                }
                else
                {
                    SHFILEINFO _SHFILEINFO = new SHFILEINFO();
                    IntPtr _IconIntPtr = SHGetFileInfo(Folder, 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), (uint)(SHGFI.SHGFI_ICON | SHGFI.SHGFI_SMALLICON));
                    if (_IconIntPtr.Equals(IntPtr.Zero)) return null;
                    Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
                    return _Icon;
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
                SHGFI_USEFILEATTRIBUTES = 0x10,
                SHGFI_SMALLICON = 0x1,
                SHGFI_TYPENAME = 0x400
            }


            [DllImportAttribute("shell32.dll", EntryPoint = "ExtractIconExW", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
            private static extern uint ExtractIconExW([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(UnmanagedType.LPWStr)] string lpszFile, int nIconIndex, ref IntPtr phiconLarge, ref IntPtr phiconSmall, uint nIcons);
            private static void GetDefaultIcon(out Icon largeIcon, out Icon smallIcon)
            {
                largeIcon = smallIcon = null;
                System.IntPtr phiconLarge = new IntPtr();
                System.IntPtr phiconSmall = new IntPtr();
                ExtractIconExW(Path.Combine(Environment.SystemDirectory, "imageres.dll"), 2, ref phiconLarge, ref phiconSmall, 1);
                if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
                if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
            }
            #endregion
            /// <summary>
            /// 将图片保存为图片文件
            /// </summary>
            /// <param name="OrgImage">原图像</param>
            /// <param name="ImageExtraName">图像的保存类型</param>
            /// <param name="ImageW">图像的宽</param>
            /// <param name="ImageH">图像的高</param>
            /// <param name="FileName">文件名</param>
            /// <returns></returns>
            public static bool SaveImageAsFile(System.Drawing.Image OrgImage, System.Drawing.Imaging.ImageFormat ImageExtraName, int ImageW, int ImageH, string FileName)
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
            /// <summary>
            /// 将标准的图标分解为图标和图标索引
            /// </summary>
            /// <param name="str">路径和索引</param>
            /// <param name="index">返回的索引值</param>
            /// <returns>返回路径</returns>
            public static string GetStrToImageLocationAndIndex(string str, out int index)
            {
                try
                {
                    string fullstr = str;
                    string filename;
                    string fullindex;
                    fullstr = SGFunction.PathOperate.ConvertStringToTurePath(fullstr, fullstr);
                    if (fullstr.Length > 1)
                    {
                        if (fullstr.Substring(0, 1) == "@")
                        { fullstr = fullstr.Substring(1, fullstr.Length - 1); }
                    }
                    if (fullstr.LastIndexOf(",") < 0 && fullstr.Length == 0)
                    {
                        filename = str;
                        fullindex = "0";
                    }
                    else
                    {
                        if (fullstr.LastIndexOf(",") < 0 && fullstr != "")
                        {
                            filename = fullstr;
                            filename = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(filename, filename);
                            fullindex = "0";
                        }
                        else
                        {
                            filename = fullstr.Substring(0, fullstr.LastIndexOf(","));
                            filename = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(filename, filename);
                            fullindex = fullstr.Substring(fullstr.LastIndexOf(",") + 1, fullstr.Length - fullstr.LastIndexOf(",") - 1);
                        }
                    }
                    int p;
                    int.TryParse(fullindex, out p);
                    index = p;
                    return filename;
                }
                catch { index = 0; return str; }
            }
            private static void GetWithGan(string IconWithIndexAllowWithGanHao, out Icon largeIcon, out Icon smallIcon)
            {
                System.IntPtr phiconLarge = new IntPtr();
                System.IntPtr phiconSmall = new IntPtr();
                try
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
                    //获取图标的数目
                    string iconfile = iconstringArray[0].Trim('"');
                    uint IconCount = ExtractIconEx(iconfile, -1, null, null, 0);
                    if (IconCount == 0)
                    {
                        //这没有图标
                        string extf = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(iconfile).ToUpper();
                        if (extf == "EXE") { iconfile = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll"; nIconIndex = 11; }
                    }
                    //
                    ExtractIconExW(iconfile, nIconIndex, ref phiconLarge, ref phiconSmall, 1);
                    if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
                    if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
                }
                finally
                {
                    //DestroyIcon(phiconLarge);
                    //(phiconSmall);
                    //MessageBox.Show("");
                }
            }
            /// <summary>
            /// 将ICO保存为文件
            /// </summary>
            /// <param name="IconWithIndexAllowWithGanHao">图标及索引</param>
            /// <param name="icofile">图标文件</param>
            /// <param name="imgsize">图标大小</param>
            public static void SaveIcon(string IconWithIndexAllowWithGanHao, string icofile, int imgsize = 32)
            {
                try
                {
                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(icofile);
                    Bitmap b = LoadIconsFormResourcesFileIcon(IconWithIndexAllowWithGanHao, "%windir%\\system32\\imageres.dll,2", imgsize);
                    b.Save(icofile, System.Drawing.Imaging.ImageFormat.Icon);
                    b.Dispose();
                }
                catch { }
            }
            /// <summary>
            /// 载入图标
            /// </summary>
            /// <param name="FileLocationWithIndex">图标以及索引</param>
            /// <param name="DefaultIcon">默认图标</param>
            /// <param name="iconsize">图标大小 如果您指定为16则返回小图标 32为默认图标</param>
            /// <returns></returns>
            public static System.Drawing.Bitmap LoadIconsFormResourcesFileIcon(string FileLocationWithIndex, string DefaultIcon = "%systemroot%\\system32\\imageres.dll,2", int iconsize = 32)
            {
                Bitmap retbmp = null;
                //获取文件的路径
                try
                {
                    DefaultIcon = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(DefaultIcon, DefaultIcon);
                    DefaultIcon = SGFunction.PathOperate.ConvertStringToTurePath(DefaultIcon, DefaultIcon);
                    string fullstr = FileLocationWithIndex;
                    string filename;
                    string fullindex;
                    fullstr = SGFunction.PathOperate.ConvertStringToTurePath(fullstr, fullstr);
                    if (fullstr.Length > 1)
                    {
                        if (fullstr.Substring(0, 1) == "@")
                        { fullstr = fullstr.Substring(1, fullstr.Length - 1); }
                    }
                    if (fullstr.LastIndexOf(",") < 0 && fullstr.Length == 0)
                    {
                        filename = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll";
                        fullindex = "2";
                    }
                    else
                    {
                        if (fullstr.LastIndexOf(",") < 0 && fullstr != "")
                        {
                            filename = fullstr;
                            filename = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(filename, filename);
                            fullindex = "0";
                        }
                        else
                        {
                            filename = fullstr.Substring(0, fullstr.LastIndexOf(","));
                            filename = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(filename, filename);
                            fullindex = fullstr.Substring(fullstr.LastIndexOf(",") + 1, fullstr.Length - fullstr.LastIndexOf(",") - 1);
                        }
                    }
                    if (fullindex.Substring(0, 1) == "-")
                    {
                        int index;
                        int.TryParse(fullindex.Replace("-", ""), out index);
                        //从资源读取
                        filename = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(filename, filename);
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(filename) == false)
                        {
                            Icon la1, lk;
                            SGFunction.ImageAndIconOperate.GetWithGan(DefaultIcon, out la1, out lk);
                            if (iconsize == 32)
                            {
                                retbmp = la1.ToBitmap();
                            }
                            else
                            {
                                if (iconsize == 16) { retbmp = lk.ToBitmap(); }
                            }
                        }
                        else
                        {
                            Icon b = SGFunction.ImageAndIconOperate.LoadResources_GetIcon(filename, "#" + index.ToString(), iconsize);
                            retbmp = b.ToBitmap();
                            //retbmp = b.ToBitmap();
                            //b.Dispose();
                        }
                    }
                    else
                    {
                        //普通读取
                        filename = SGFunction.PathOperate.ConvertNoCompeletLocationToTurePath(filename, filename);
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(filename) == false)
                        {
                            Icon la1, lk;
                            SGFunction.ImageAndIconOperate.GetWithGan(DefaultIcon, out la1, out lk);
                            retbmp = la1.ToBitmap();
                            if (iconsize == 32)
                            {
                                retbmp = la1.ToBitmap();
                            }
                            else
                            {
                                if (iconsize == 16) { retbmp = lk.ToBitmap(); }
                            }
                        }
                        else
                        {
                            Icon la11, lk1;
                            SGFunction.ImageAndIconOperate.GetWithGan(filename + "," + fullindex, out la11, out lk1);
                            retbmp = la11.ToBitmap();
                            if (iconsize == 32)
                            {
                                retbmp = la11.ToBitmap();
                            }
                            else
                            {
                                if (iconsize == 16) { retbmp = lk1.ToBitmap(); }
                            }
                            //la1.Dispose();
                            //lk.Dispose();
                        }
                    }
                    return retbmp;
                }
                catch
                {
                    Icon la1, lk;
                    SGFunction.ImageAndIconOperate.GetWithGan(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,2", out la1, out lk);
                    retbmp = la1.ToBitmap();
                    //la1.Dispose();
                    //lk.Dispose();
                    return retbmp;
                }
                finally
                {
                    //retbmp.Dispose();
                }
            }
            [DllImport("kernel32.dll", EntryPoint = "FindResourceW", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr FindResourceSTR(IntPtr hModule, int lpID, string lpType);
            /// <summary>
            /// 加载资源中的位图
            /// </summary>
            /// <param name="file">资源文件</param>
            /// <param name="resourcesid">资源ID</param>
            /// <param name="resourcestype">资源模式[Bitmap]</param>
            /// <returns></returns>
            public static Bitmap LoadResources_GetBitmap(string file, int resourcesid, string resourcestype)
            {
                try
                {
                    bool useuint = true;
                    uint ty = RT_BITMAP;
                    switch (resourcestype.ToUpper())
                    {
                        case "BITMAP":
                            ty = RT_BITMAP;
                            break;
                        default:
                            useuint = false;
                            break;
                    }
                    if (useuint == true)
                    {
                        string path = file;
                        IntPtr hMod = LoadLibraryEx(path, IntPtr.Zero, LOAD_LIBRARY_AS_DATAFILE);
                        IntPtr hRes = FindResource(hMod, resourcesid, ty);
                        uint size = SizeofResource(hMod, hRes);
                        IntPtr pt = LoadResource(hMod, hRes);
                        byte[] bPtr = new byte[size];
                        Marshal.Copy(pt, bPtr, 0, (int)size);
                        Bitmap bmp;
                        using (System.IO.MemoryStream m = new System.IO.MemoryStream(bPtr))
                        {
                            //m.Seek(0, SeekOrigin.Begin);
                            bmp = (Bitmap)Bitmap.FromStream((Stream)m);
                        }
                        Bitmap n = new Bitmap(bmp);
                        bmp.Dispose();
                        return n;
                    }
                    else
                    {
                        string path = file;
                        IntPtr hMod = LoadLibraryEx(path, IntPtr.Zero, LOAD_LIBRARY_AS_DATAFILE);
                        IntPtr hRes = FindResourceSTR(hMod, resourcesid, resourcestype);
                        uint size = SizeofResource(hMod, hRes);
                        IntPtr pt = LoadResource(hMod, hRes);
                        byte[] bPtr = new byte[size];
                        Marshal.Copy(pt, bPtr, 0, (int)size);
                        Bitmap bmp;
                        using (System.IO.MemoryStream m = new System.IO.MemoryStream(bPtr))
                            bmp = (Bitmap)Bitmap.FromStream(m);
                        Bitmap n = new Bitmap(bmp);
                        bmp.Dispose();
                        return n;
                    }
                }
                catch { return null; }

            }
            /// <summary>
            /// 获取资源中的大图标
            /// </summary>
            /// <param name="path">图标文件</param>
            /// <param name="resId">索引</param>
            /// <param name="size">图标大小</param>
            /// <returns></returns>
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
        }
        public class SpecialFoldersOrFile
        {
            /// <summary>
            /// 获取系统齿轮指定功能的特殊目录或文件
            /// </summary>
            /// <param name="foldercode">主项目 [root]获取系统齿轮当前版本的配置主要目录 [skins]皮肤文件夹 [config] 配置文件目录[backup]备份的文件的目录 [programs]自带的程序的目录 [Temp]系统齿轮临时文件目录 [helper]获取帮助目录 [images]图像文件的保存位置 [srec]系统齿轮功能记录器对应的文件</param>
            /// <param name="functioncode">子功能代码 [001] 图标管理 [002]系统图标 003]文件类型功能 [004]任务栏管理 [005]右键菜单组 [006剪切板 [007]右键菜单管理</param>
            /// <returns></returns>
            public static string GetSystemGearSpecialFolderOrFile(string foldercode, string functioncode = "")
            {
                string rootfolder = "", subfolder = "";
                switch (foldercode.ToLower())
                {
                    case "backup":
                        rootfolder = Application.StartupPath + @"\bin" + "\\Backup";
                        switch (functioncode.ToUpper())
                        {
                            case "003":
                                subfolder = "\\FileTypeMgr";
                                break;
                        }
                        break;
                    case "srec":
                        rootfolder = Application.StartupPath + @"\bin" + "\\Config\\SGFunctionRecorder";
                        break;
                    case "programs":
                        rootfolder = Application.StartupPath + @"\bin" + "\\Programs";
                        break;
                    case "temp":
                        rootfolder = Application.StartupPath + @"\bin" + "\\Temp";
                        break;
                    case "config":
                        rootfolder = Application.StartupPath + @"\bin" + "\\Config";
                        break;
                    case "helper":
                        rootfolder = Application.StartupPath + @"\bin" + "\\Helper";
                        break;
                    case "packages":
                        rootfolder = Application.StartupPath + @"\bin" + "\\Packages";
                        break;
                    case "images":
                        rootfolder = Application.StartupPath + @"\bin" + "\\Images";
                        break;
                    case "skins":
                        rootfolder = Application.StartupPath + @"\bin" + "\\Skins";
                        break;
                    case "root":
                        rootfolder = Application.StartupPath + @"\bin";
                        break;
                }
                SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(rootfolder + subfolder);
                return rootfolder + subfolder;
            }
        }
        /// <summary>
        /// 提供对控件的方法
        /// </summary>
        public class Control
        {
            /// <summary>
            /// 获取一个坐标使窗体居中显示
            /// </summary>
            /// <param name="frm">窗体</param>
            /// <returns></returns>
            public static Point SetDialogInCenterScreen(System.Windows.Forms.Form frm)
            {
                int x = 0;
                int y = 0;
                Size fbl = SGFunction.SystemFunctionAndInformation.GetSrceenFenBianLv();
                x = (fbl.Width - frm.Size.Width) / 2;
                y = (fbl.Height - frm.Size.Height) / 2;
                return new Point(x, y);
            }
            /// <summary>
            /// 列表控件选中行上移方法
            /// </summary>
            /// <param name="listView"></param>
            public static void ListViewUpMove(SGListView listView)
            {
                if (listView.SelectedItems.Count == 0)
                {
                    return;
                }

                listView.BeginUpdate();
                if (listView.SelectedItems[0].Index > 0)
                {
                    foreach (ListViewItem lvi in listView.SelectedItems)
                    {
                        ListViewItem lviSelectedItem = lvi;
                        int indexSelectedItem = lvi.Index;
                        listView.Items.RemoveAt(indexSelectedItem);
                        listView.Items.Insert(indexSelectedItem - 1, lviSelectedItem);
                    }
                }
                listView.EndUpdate();

                if (listView.Items.Count > 0 && listView.SelectedItems.Count > 0)
                {
                    listView.Focus();
                    listView.SelectedItems[0].Focused = true;
                    listView.SelectedItems[0].EnsureVisible();
                }
            }
            /// <summary>
            /// 列表控件下移方法
            /// </summary>
            /// <param name="listView"></param>
            public static void ListViewDownMove(SGListView listView)
            {
                if (listView.SelectedItems.Count == 0)
                {
                    return;
                }

                listView.BeginUpdate();
                int indexMaxSelectedItem = listView.SelectedItems[listView.SelectedItems.Count - 1].Index;

                if (indexMaxSelectedItem < listView.Items.Count - 1)
                {
                    for (int i = listView.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        ListViewItem lviSelectedItem = listView.SelectedItems[i];
                        int indexSelectedItem = lviSelectedItem.Index;
                        listView.Items.RemoveAt(indexSelectedItem);
                        listView.Items.Insert(indexSelectedItem + 1, lviSelectedItem);
                    }
                }
                listView.EndUpdate();
                if (listView.Items.Count > 0 && listView.SelectedItems.Count > 0)
                {
                    listView.Focus();
                    listView.SelectedItems[listView.SelectedItems.Count - 1].Focused = true;
                    listView.SelectedItems[listView.SelectedItems.Count - 1].EnsureVisible();
                }
            }
        }
        /// <summary>
        /// 提供对各种数据文件的计算
        /// </summary>
        public class DataOperate
        {
            /// <summary>
            /// 在指定的数字前添加指定的数字 例如  在int32的前面添加number 但限定字符只能有ge个位 例如 2  返回002 12 返回 012
            /// </summary>
            /// <param name="number">要添加的数字</param>
            /// <param name="int32">被添加的数字</param>
            /// <param name="ge">限制返回字符串的位数</param>
            /// <returns></returns>
            public static string AddNumberInFirstInt32(int number, int int32, int ge)
            {
                try
                {
                    int len = int32.ToString().Length;
                    if (len >= ge) { return int32.ToString(); }
                    string j = int32.ToString();
                    string res = j;
                    for (int u = 1; u <= ge - int32.ToString().Length; u = u + 1)
                    {
                        res = number.ToString() + res;
                    }
                    return res;
                }
                catch { return ""; }
            }
            /// <summary>
            /// 将STRING数据类型转换为INT32位整数
            /// </summary>
            /// <param name="OldString">要转换的字符</param>
            /// <param name="DefaultInt32">默认的INT值</param>
            /// <returns></returns>
            public static int StringsToInt(string OldString, int DefaultInt32 = 0)
            {
                try
                {
                    int y = DefaultInt32;
                    int.TryParse(OldString, out y);
                    return y;
                }
                catch
                {
                    return DefaultInt32;
                }
            }
            /// <summary>
            /// 创建CLSID
            /// </summary>
            /// <returns></returns>
            public static string GetCLSID()
            {
                return "{" + Guid.NewGuid().ToString().ToUpper() + "}";
            }
            /// <summary>
            /// 查找一个数组中与str匹配的一项 , 并返回其在arr的索引 没有找到则返回-1
            /// </summary>
            /// <param name="str">字符</param>
            /// <param name="arr">数组</param>
            /// <returns></returns>
            public static int FindSamestringIndexInArray(string str, string[] arr)
            {
                try
                {
                    if (arr.Length > 0)
                    {
                        for (int j = 1; j <= arr.Length; j++)
                        {
                            if (str.ToLower() == arr[j - 1].ToLower())
                            {
                                return j - 1;
                            }
                        }
                        return -1;
                    }
                    else { return -1; }
                }
                catch { return -1; }
            }
            /// <summary>
            /// 将字节(B)转换为KB MB GB
            /// </summary>
            /// <param name="WantToConvert">字节</param>
            /// <param name="type">模式 [空]默认 [ToMb]只会转换为MB [ToKb]只会转换为KB [ToGb]只会转换为GB</param>
            /// <param name="adddw">是否添加单位</param>
            /// <returns></returns>
            public static string ByteOperate(Int64 WantToConvert, string type = "", bool adddw = true)
            {
                try
                {
                    string dw_gb = "GB";
                    string dw_kb = "KB";
                    string dw_mb = "MB";
                    if (adddw == false)
                    {
                        dw_gb = dw_kb = dw_mb = "";
                    }
                    const int GB = 1024 * 1024 * 1024;//定义GB的计算常量
                    const int MB = 1024 * 1024;//定义MB的计算常量
                    const int KB = 1024;//定义KB的计算常量
                    if (type == "")
                    {
                        if (WantToConvert / GB >= 1)//如果当前Byte的值大于等于1GB
                            return (Math.Round(WantToConvert / (float)GB, 2)).ToString() + dw_gb;//将其转换成GB
                        else if (WantToConvert / MB >= 1)//如果当前Byte的值大于等于1MB
                            return (Math.Round(WantToConvert / (float)MB, 2)).ToString() + dw_mb;//将其转换成MB
                        else if (WantToConvert / KB >= 1)//如果当前Byte的值大于等于1KB
                            return (Math.Round(WantToConvert / (float)KB, 2)).ToString() + dw_kb;//将其转换成KB
                        else
                            return WantToConvert.ToString() + "B";//显示Byte值
                    }
                    else
                    {
                        switch (type.ToLower())
                        {
                            case "tokb":
                                return (Math.Round(WantToConvert / (float)KB, 2)).ToString() + dw_kb;//将其转换成KGB
                            case "tomb":
                                return (Math.Round(WantToConvert / (float)MB, 2)).ToString() + dw_mb;//将其转换成MB
                            case "togb":
                                return (Math.Round(WantToConvert / (float)GB, 2)).ToString() + dw_gb;//将其转换成GB
                        }
                        return WantToConvert.ToString() + "B";
                    }
                }
                catch
                {
                    return WantToConvert.ToString() + "B";
                }
            }
            /// <summary>
            /// 获取文件中有多少行
            /// </summary>
            /// <param name="FilePath">文件</param>
            /// <returns></returns>
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
            /// <summary>
            /// 将每一行转换为数组
            /// </summary>
            /// <param name="String">文本字符</param>
            /// <returns></returns>
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
            /// 将指定的字符转换为以这个字符为分割行标准的数组
            /// </summary>
            /// <param name="String">原始字符</param>
            /// <param name="STR">分隔符(例如 空格)</param>
            /// <returns></returns>
            public static string[] ConvertStringsToStringArryBySTR(string String, string STR)
            {
                try
                {
                    string strContext = String;
                    string[] str;
                    if (!strContext.Equals(""))
                    {
                        str = strContext.Split(STR.ToCharArray());
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
            public static string[] ConvertStringsToStringArry_ByString(string String, string fenge)
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
            /// <summary>
            /// 督促指定行
            /// </summary>
            /// <param name="FilePath">文件</param>
            /// <param name="Line">行</param>
            /// <returns></returns>
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
            /// <summary>
            /// 产生随机数列
            /// </summary>
            /// <param name="Length">随机数的位数</param>
            /// <returns></returns>
            public static string GetRandomString(int Length)
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
            /// <summary>
            /// 把字符串保存为文本文件
            /// </summary>
            /// <param name="FileName">文本文件</param>
            /// <param name="Strings">字符</param>
            /// <returns></returns>
            public static bool SaveStringToTextFile(string FileName, string Strings)
            {
                try
                {
                    //使用“另存为”对话框中输入的文件名实例化StreamWriter对象
                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(FileName);
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
            /// <summary>
            /// 剪切板中的HTML格式保存为Html文件并获取复制的来源
            /// </summary>
            /// <param name="html">保存的HTML文件路径</param>
            /// <param name="copyinfo">复制来源保存的位置(.sgcf) 请读取[htmlinfo]\copyfrom值</param>
            /// <returns></returns>
            public static void SaveHTMLFromClipBoardToHtmlFileWithCopyFrom(string html, string copyinfo)
            {
                try
                {
                    MemoryStream vMemoryStream = Clipboard.GetData("Html Format") as MemoryStream;
                    vMemoryStream.Position = 0;
                    byte[] vBytes = new byte[vMemoryStream.Length];
                    vMemoryStream.Read(vBytes, 0, (int)vMemoryStream.Length);
                    //////////
                    string filename = html;

                    FileInfo f = new FileInfo(filename);
                    FileStream outputfile = null;
                    outputfile = new FileStream(filename, FileMode.Create, FileAccess.Write);


                    BinaryWriter writer = new BinaryWriter(outputfile);
                    byte[] RecvBuffer = new byte[10240];
                    RecvBuffer = vBytes;//tbox.text换成你获取网页代码的方法
                    writer.Write(RecvBuffer);
                    vMemoryStream.Close();
                    writer.Close();
                    //获取信息
                    if (System.IO.File.Exists(html) == true)
                    {
                        string[] lines = System.IO.File.ReadAllLines(html, Encoding.UTF8);
                        //读取信息
                        if (lines.Length > 8)
                        {
                            string url = lines[7];
                            if (url != "") { url = url.Substring(url.IndexOf(':') + 1, url.Length - url.IndexOf(':') - 1); }
                            int n = 8;//要删掉的行数
                            System.IO.File.WriteAllText(html, string.Join(Environment.NewLine, lines, n, lines.Length - n));
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("HtmlInfo", "CopyFrom", url, "Config", false, copyinfo);
                        }
                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// 提供对系统已注册的COM(CLSID)以及ContextMenu的操作 
        /// </summary>
        public class CLSIDAndHanderOperate
        {
            /// <summary>
            /// 对已注册在系统中的右键菜单句柄进行信息检测 返回数组[0]名称 [1]图标 [2]可执行文件
            /// </summary>
            /// <param name="rootkey">根路径</param>
            /// <param name="location">位置</param>
            /// <param name="subname">Hander名称</param>
            /// <returns></returns>
            public static string[] GetContextHanderInfo(RegistryKey rootkey, string location, string subname)
            {
                try
                {
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\clsidinfo.sgcf";
                    string read = "";
                    read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("ForRightMenuMgr", subname, "", cfg, false);
                    if (read != "")
                    {
                        string clsid = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", rootkey, location + "\\" + subname, "", "");
                        string[] keys = read.Split('|');
                        if (keys.Length == 3)
                        {
                            string name = keys[0];
                            string ico = keys[1];
                            string shell = keys[2];
                            if (name == "") { name = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "CLSID\\" + clsid, "", subname); }
                            if (ico == "") { ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,62"; }
                            if (shell == "") { shell = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "CLSID\\" + clsid + "\\InProcServer32", "", "未知"); }
                            return new string[] { name, ico, shell };
                        }
                        else { return new string[] { "", "", "" }; }
                    }
                    else
                    {
                        string clsid = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", rootkey, location + "\\" + subname, "", "");
                        string name = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "CLSID\\" + clsid, "", subname);
                        string ico = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\imageres.dll,62";
                        string shell = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "CLSID\\" + clsid + "\\InProcServer32", "", "未知");
                        return new string[] { name, ico, shell };
                    }
                }
                catch { return new string[] { "", "", "" }; }
            }
            /// <summary>
            /// 检测不含Hander的右键菜单 返回[0]名称 [1]ICO [2]命令
            /// </summary>
            /// <param name="rootkey"></param>
            /// <param name="location"></param>
            /// <param name="subname"></param>
            /// <returns></returns>
            public static string[] GetRightMenuInfoFormRegistry(RegistryKey rootkey, string location, string subname)
            {
                try
                {
                    string name = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", rootkey, location + "\\" + subname, "");
                    string cmd, ico;
                    RegistryKey ky = rootkey.OpenSubKey(location).OpenSubKey(subname);
                    if (SGFunction.RegistryOperate.RegostryOperate_FindSubKeyIsExists(rootkey, location + "\\" + subname, "command") == false && ky.GetValue("SubCommands", "none").ToString() != "none")
                    {
                        //可能是菜单组
                        ico = ky.GetValue("icon", Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\Imageres.dll,2").ToString();
                        cmd = ky.GetValue("SubCommands", "").ToString();
                        name = ky.GetValue("MUIVerb", "").ToString();
                    }
                    else
                    {
                        //MessageBox.Show(SGFunction.RegistryOperate.RegostryOperate_FindSubKeyIsExists(rootkey, location + "\\" + subname, "command").ToString());
                        if (SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", rootkey, location + "\\" + subname + "\\Command", "", "") != "")
                        {
                            cmd = ky.OpenSubKey("command").GetValue("", "").ToString();
                            ico = ky.GetValue("icon", Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\Imageres.dll,2").ToString();
                            if (cmd == "") { cmd = ky.OpenSubKey("command").GetValue("DelegateExecute", cmd).ToString(); }
                            if (name == "") { name = ky.GetValue("muiverb", name).ToString(); }
                        }
                        else
                        {
                            cmd = ""; ico = ky.GetValue("icon", Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\Imageres.dll,2").ToString();
                            if (cmd == "")
                            {
                                cmd = ky.GetValue("Commandstatehandler", cmd).ToString();
                            }
                        }
                        //检查cmd
                        string clsid = "";
                        if (ky.OpenSubKey("command") != null) { clsid = ky.OpenSubKey("command").GetValue("DelegateExecute", cmd).ToString(); cmd = clsid; }
                    }
                    //转换变量
                    if (name != "")
                    {
                        switch (name.Substring(0, 1))
                        {
                            case "@":
                                name = SGFunction.MUIOperate.GetMUIString(name);
                                break;
                            default:
                                break;
                        }
                    }
                    string icof;
                    int icoindex;
                    icof = SGFunction.ImageAndIconOperate.GetStrToImageLocationAndIndex(ico, out icoindex);
                    ico = icof + "," + icoindex.ToString();
                    //最后判断
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\clsidinfo.sgcf";
                    string read = "";
                    read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("ForRightMenuMgr", subname, "", cfg, false);
                    if (read != "")
                    {
                        string[] keys = read.Split('|');
                        if (keys.Length == 3)
                        {
                            if (name == "") { name = keys[0]; }
                            if (ico == Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\Imageres.dll,2" || ico == "") { ico = keys[1]; }
                            if (cmd == "") { cmd = keys[2]; }
                        }
                    }
                    //检查是否还有信息
                    if (name == "")
                    {
                        string clid = ky.OpenSubKey("command").GetValue("DelegateExecute", cmd).ToString();
                        if (clid != "")
                        {
                            string fidstr = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "clsid\\" + clid, "", name); //有可能是一些通用的名字 例如CLSID_ExecuteFolder 那么加载语言资源LocalizedString
                            string localstr = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "clsid\\" + clid, "LocalizedString", fidstr);
                            if (localstr != fidstr)
                            {
                                fidstr = SGFunction.MUIOperate.GetMUIString(localstr);
                            }
                            name = fidstr;
                        }
                    }
                    return new string[] { name, ico, cmd };
                }
                catch { return new string[] { "", "", "" }; }
            }
            /// <summary>
            /// 读取CLSID的名称 (如果不存在则返回配置文件中的值)
            /// </summary>
            /// <param name="GUID">CLSDI</param>
            /// <returns></returns>
            public static string CLSIDOperate_GetGUIDRegistryName(string GUID)
            {
                try
                {
                    ///
                    string sgcf = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\CLSIDInfo.sgcf";
                    string retstr = "";
                    //先从注册表中加载
                    string read = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "CLSID\\" + GUID, "", "");
                    //判断是否要加载LOCAL资源
                    string local = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "CLSID\\" + GUID, "LocalizedString", "");
                    if (local != "")
                    {
                        //优先加载LOCAL
                        string mui = SGFunction.MUIOperate.GetMUIString(local);
                        if (mui != "")
                        {
                            //不为空 有内容
                            retstr = mui;
                        }
                        else
                        {
                            //是空的 那就加载预设值 如果预设值也是空的 就返回read
                            retstr = "";
                        }
                    }
                    else
                    {
                        retstr = "";
                    }
                    //预设值
                    if (retstr == "")
                    {
                        string rn = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("SYSTEMCLSID", GUID, "", sgcf, false);
                        if (rn.Length > 5)
                        {
                            //读取不为空
                            string nnn = rn.Substring(0, rn.IndexOf("|"));
                            if (nnn != "")
                            {
                                retstr = nnn;
                            }
                            else
                            {
                                //返回read
                                retstr = read;
                            }
                        }
                        else
                        {
                            retstr = read;
                        }
                    }
                    return retstr;
                }
                catch { return ""; }
            }
            /// <summary>
            /// 读取CLSID的图标 (如果不存在则返回配置文件中的值)
            /// </summary>
            /// <param name="GUID">CLSID</param>
            /// <returns></returns>
            public static string CLSIDOperate_GetGUIDRegistryIcon(string GUID)
            {
                try
                {
                    ///
                    string sgcf = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\CLSIDInfo.sgcf";
                    string retstr = "";
                    //先从注册表中加载
                    string read = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, "CLSID\\" + GUID + "\\defaulticon", "", "");
                    if (read != "")
                    {
                        retstr = read;
                    }
                    else
                    {
                        retstr = "";
                    }
                    //预设值
                    if (retstr == "")
                    {
                        string rn = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("SYSTEMCLSID", GUID, "", sgcf, false);
                        if (rn.Length > 5)
                        {
                            //读取不为空
                            string nnn = rn.Substring(rn.IndexOf("|") + 1, rn.Length - rn.IndexOf("|") - 1);
                            if (nnn != "")
                            {
                                retstr = nnn;
                            }
                            else
                            {
                                //返回read
                                retstr = read;
                            }
                        }
                        else
                        {
                            retstr = read;
                        }
                    }
                    return retstr;
                }
                catch { return ""; }
            }
        }
        /// <summary>
        /// 提供对语言资源文件MUI的操作
        /// </summary>
        public class MUIOperate
        {
            #region 读取MUI的API

            [DllImport("kernel32.dll")]
            static extern uint GetThreadLocale();
            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern IntPtr LoadLibrary(string lpFileName);

            [DllImport("kernel32.dll", EntryPoint = "SetDllDirectoryW", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
            internal static extern bool SetDllDirectoryW(string lpPathName);

            [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
            internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
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
            /// <summary>
            /// 读取MUI
            /// </summary>
            /// <param name="ExeOrDllfile">MUI位置和资源号(可以直接回去注册表中固有的)</param>
            /// <param name="defaultreturn">默认返回的值 []则返回exeordllfile的值</param>
            /// <returns></returns>
            public static string GetMUIString(string ExeOrDllfile, string defaultreturn = "")
            {
                try
                {
                    string resfile = ExeOrDllfile;
                    if (resfile.Length > 0)
                    {
                        if (resfile.Substring(0, 1) == "@") { resfile = resfile.Substring(1, resfile.Length - 1); }
                        string file = resfile.Substring(0, resfile.LastIndexOf(","));
                        string rid = resfile.Substring(resfile.LastIndexOf(",") + 2, resfile.Length - resfile.LastIndexOf(",") - 2);
                        uint id;
                        uint.TryParse(rid, out id);
                        file = SGFunction.PathOperate.IMPORTANT_PathUseful(file);
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(file) == true)
                        {

                            long x;
                            System.IntPtr hInst;
                            string sLcid;
                            uint LCID;
                            string folder = SGFunction.FileSystemOperate.FSO_GetFileFatherFolder(file);
                            StringBuilder resString = new StringBuilder(255);
                            StringBuilder sCodePage = new StringBuilder(255);
                            sCodePage.Append("16");
                            //sCodePage ="16";
                            LCID = GetThreadLocale(); //Get Current locale
                            sLcid = Convert.ToString(LCID, 16);
                            x = GetLocaleInfo(LCID, LOCALE_IDEFAULTANSICODEPAGE, sCodePage, sCodePage.Length);  //Get code page
                            sCodePage = StripNullTerminator(sCodePage.ToString());
                            //MessageBox.Show(file);
                            //hInst = LoadLibrary(file);
                            if (SetDllDirectoryW(folder) == false) // <-- Exception thrown here.
                            {
                                //throw new FileNotFoundException(folder);
                            }
                            hInst = LoadLibrary(file);
                            //_fptr = UnsafeNativeMethods.GetProcAddress(_dllHandle, _procName);
                            /* Yet even more code. */
                            if (hInst != IntPtr.Zero)
                            {
                                hInst = LoadString(hInst, id, resString, 255);
                                return resString.ToString();
                            }
                            else
                            {
                                //MessageBox.Show(file);
                                if (defaultreturn == "")
                                {
                                    return ExeOrDllfile;
                                }
                                else
                                {
                                    return defaultreturn;
                                }
                            }
                        }
                        else
                        {
                            if (defaultreturn == "")
                            {
                                return ExeOrDllfile;
                            }
                            else
                            {
                                return defaultreturn;
                            }
                        }
                    }
                    else
                    {
                        if (defaultreturn == "")
                        {
                            return ExeOrDllfile;
                        }
                        else
                        {
                            return defaultreturn;
                        }
                    }
                }
                catch
                {
                    if (defaultreturn == "")
                    {
                        return ExeOrDllfile;
                    }
                    else
                    {
                        return defaultreturn;
                    }
                }
            }
        }
        /// <summary>
        /// 对配置文件的操作
        /// </summary>
        public class ConfigFileOperate
        {
            [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString", CharSet = CharSet.Ansi)]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString", CharSet = CharSet.Ansi)]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

            [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileSectionNames", CharSet = CharSet.Ansi)]
            private static extern int GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, int nSize, string filePath);

            [DllImport("KERNEL32.DLL ", EntryPoint = "GetPrivateProfileSection", CharSet = CharSet.Ansi)]
            private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpReturnedString, int nSize, string filePath);
            /// <summary>
            /// 删除某一节点下的名为key的键
            /// </summary>
            /// <param name="section">节点</param>
            /// <param name="key">键</param>
            /// <param name="cfg">SGCF CFG文件</param>
            /// <returns></returns>
            public static bool CFGOperate_DeleteIniKey(string section, string key, string cfg)
            {
                bool flag;
                try
                {
                    if (section.Trim().Length <= 0 || key.Trim().Length <= 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        if (WritePrivateProfileString(section, key, null, cfg) == 0)
                        {
                            flag = false;
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    return flag;
                }
                catch
                {
                    flag = false;
                    return flag;
                }
            }
            /// <summary>
            /// 得到某个节点下面所有的key和value组合  注意 VALUE中不能存在其他的等号
            /// </summary>
            /// <param name="section">指定的节</param>
            /// <param name="keys">输出的键的名称</param>
            /// <param name="values">输出的键的值</param>
            /// <param name="path">SGCF/INI路径</param>
            /// <param name="issgcf">INI是否是SGCF</param>
            /// <returns>返回0表示结束</returns>
            public static int CFGOperate_GetAllKeyValues(string section, out string[] keys, out string[] values, string path, bool issgcf = true)
            {
                byte[] b = new byte[65535];
                int ret = 0;
                GetPrivateProfileSection(section, b, b.Length, path);
                string s = System.Text.Encoding.Default.GetString(b);
                string[] tmp = s.Split((char)0);
                ArrayList result = new ArrayList();
                foreach (string r in tmp)
                {
                    if (r != string.Empty)
                        result.Add(r);
                }
                keys = new string[result.Count];
                values = new string[result.Count];
                for (int i = 0; i < result.Count; i++)
                {
                    string[] item = result[i].ToString().Split(new char[] { '=' });
                    if (item.Length == 2)
                    {
                        keys[i] = item[0].Trim();
                        string jff = item[1].Trim();
                        if (issgcf == true)
                        {
                            values[i] = jff.Substring(1, jff.Length - 1);
                        }
                        else { values[i] = jff; }
                        //ret = values.Length;
                    }
                    else if (item.Length == 1)
                    {
                        keys[i] = item[0].Trim();
                        values[i] = "";
                    }
                    else if (item.Length == 0)
                    {
                        keys[i] = "";
                        values[i] = "";
                    }
                }
                ret = values.Length;
                return ret;
            }
            /// <summary>
            /// 提供对SGCF配置文件的操作
            /// </summary>
            /// <param name="Section">头</param>
            /// <param name="Key">键</param>
            /// <param name="DefaultValue">默认值</param>
            /// <param name="file">SGCF文件</param>
            /// <param name="hasvar">是否在读取完字符后将其转换为绝对路径 注意对于有多个变量可能存在着问题 , 建议遇到%windir%\%xxx%等字符串时指定值为false</param>
            /// <returns></returns>
            public static string SGCFFileOperate_GetValue(string Section, string Key, string DefaultValue, string file, bool hasvar = true)
            {
                if (System.IO.File.Exists(file) == true)
                {
                    StringBuilder temp = new StringBuilder(500);
                    int i = GetPrivateProfileString(Section, Key, "#" + DefaultValue, temp, 500, file);
                    string STR = temp.ToString();
                    if (STR.Length > 0)
                    {
                        STR = STR.Substring(1, STR.Length - 1);
                        if (hasvar == true)
                        { STR = SGFunction.PathOperate.ConvertStringToTurePath(STR, STR); }
                    }
                    return STR;
                }
                else
                {
                    return DefaultValue;
                }
            }
            /// <summary>
            /// 提供对SGCF配置文件的写入操作
            /// </summary>
            /// <param name="Section">头</param>
            /// <param name="Key">键</param>
            /// <param name="Value">写入的值</param>
            /// <param name="FileType">SGCF得类型</param>
            /// <param name="ConvertSystemVarToTrueLocation">是否把Value转换为绝对路径</param>
            /// <param name="MCFFile">SGCF文件</param>
            public static void SGCFFileOperate_WriteValue(string Section, string Key, string Value, string FileType, bool ConvertSystemVarToTrueLocation, string MCFFile)
            {
                //string newmcf = SGFunction.PathOperate.ConvertStringToTurePath(MCFFile, MCFFile);
                WritePrivateProfileString("SystemGear", "Version", "#" + SGFunction.ApplicationSetting.GetSGProgramVersion("MMAIN"), MCFFile);
                WritePrivateProfileString("SystemGear", "FileType", "#" + FileType, MCFFile);
                string Keyf = Value;
                if (ConvertSystemVarToTrueLocation == true)
                {
                    Keyf = SGFunction.PathOperate.ConvertStringToTurePath(Keyf, Keyf);
                }
                WritePrivateProfileString(Section, Key, "#" + Keyf, MCFFile);
            }
            /// <summary>
            /// 提供对普通配置文件的写入功能(.ini)
            /// </summary>
            /// <param name="Section">头</param>
            /// <param name="Key">键</param>
            /// <param name="Value">值</param>
            /// <param name="FileName">INI文件</param>
            /// <param name="ConvertSystemVarToTrueLocation">是否转换为绝对路径</param>
            public static void ConfigFileOperate_WriteValue(string Section, string Key, string Value, string FileName, bool ConvertSystemVarToTrueLocation = true)
            {
                //string newmcf = SGFunction.PathOperate.ConvertStringToTurePath(MCFFile, MCFFile);;
                string Keyf = Value;
                if (ConvertSystemVarToTrueLocation == true)
                {
                    Keyf = SGFunction.PathOperate.ConvertStringToTurePath(Keyf, Keyf);
                }
                WritePrivateProfileString(Section, Key, Keyf, FileName);
            }
            /// <summary>
            /// 提供对普通配置文件的读取功能
            /// </summary>
            /// <param name="Section">头</param>
            /// <param name="Key">键</param>
            /// <param name="DefaultValue">默认值</param>
            /// <param name="MCFFile">文件</param>
            /// <param name="ConvertSystemVar">是否转换为绝对路径</param>
            /// <returns></returns>
            public static string ConfigFileOperate_GetValue(string Section, string Key, string DefaultValue, string MCFFile, bool ConvertSystemVar = true)
            {
                if (System.IO.File.Exists(MCFFile) == true)
                {
                    StringBuilder temp = new StringBuilder(500);
                    int i = GetPrivateProfileString(Section, Key, DefaultValue, temp, 500, MCFFile);
                    string STR = temp.ToString();
                    if (ConvertSystemVar == true)
                    {
                        STR = SGFunction.PathOperate.ConvertStringToTurePath(STR, temp.ToString());
                    }
                    return STR;
                }
                else
                {
                    return DefaultValue;
                }
            }
        }
        /// <summary>
        /// 提供对系统齿轮皮肤和UI的访问或设置
        /// </summary>
        public class Skins
        {

            public static string _SKINSCONFIG = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("skins") + "\\default.sgcf";
            public static string _SKINSCONFIG_FOLDER = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("skins");
            public static void LoadUserSkin()
            {

            }
            /// <summary>
            /// 读取系统齿轮皮肤图片设置
            /// </summary>
            /// <param name="code">模式 [top_left]坐左上处的图片 [top]顶出图片 [top_zhe] 遮图片（范围1-6）</param>
            /// <returns></returns>
            public static Image GetSkinPictures(string code)
            {
                try
                {
                    Image r = null;
                    string readcfg = "";
                    switch (code.ToLower())
                    {
                        case "top_left":
                            readcfg = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", code, "", _SKINSCONFIG, false);
                            if (readcfg != "") { readcfg = _SKINSCONFIG_FOLDER + @"\\" + readcfg; }
                            break;
                        case "top":
                            readcfg = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", code, "", _SKINSCONFIG, false);
                            if (readcfg != "") { readcfg = _SKINSCONFIG_FOLDER + @"\\" + readcfg; }
                            break;
                        case "top_zhe1":
                            readcfg = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", code, "", _SKINSCONFIG, false);
                            if (readcfg != "") { readcfg = _SKINSCONFIG_FOLDER + @"\\" + readcfg; }
                            break;
                        case "top_zhe2":
                            readcfg = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", code, "", _SKINSCONFIG, false);
                            if (readcfg != "") { readcfg = _SKINSCONFIG_FOLDER + @"\\" + readcfg; }
                            break;
                        case "top_zhe3":
                            readcfg = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", code, "", _SKINSCONFIG, false);
                            if (readcfg != "") { readcfg = _SKINSCONFIG_FOLDER + @"\\" + readcfg; }
                            break;
                        case "top_zhe4":
                            readcfg = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", code, "", _SKINSCONFIG, false);
                            if (readcfg != "") { readcfg = _SKINSCONFIG_FOLDER + @"\\" + readcfg; }
                            break;
                        case "top_zhe5":
                            readcfg = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", code, "", _SKINSCONFIG, false);
                            if (readcfg != "") { readcfg = _SKINSCONFIG_FOLDER + @"\\" + readcfg; }
                            break;
                        case "top_zhe6":
                            readcfg = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", code, "", _SKINSCONFIG, false);
                            if (readcfg != "") { readcfg = _SKINSCONFIG_FOLDER + @"\\" + readcfg; }
                            break;
                    }
                    if (readcfg != "" && SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(readcfg) == true)
                    {
                        r = Image.FromFile(readcfg);
                    }
                    return r;
                }
                catch { return null; }
            }
            /// <summary>
            /// 设置摸个TabControl下所有TabPage中的控件的颜色样式 (不会绘制不可见的空间的颜色 比如右键菜单) 可以绘制TabPage中的Panel中的Panel 如果控件的TAG值或者ROLE的值(只有BTN和LABEL)为NODRAW则不会绘制控件
            /// </summary>
            /// <param name="tab">SGTabPageControl</param>
            public static void DrawAllControlInTabControl(SGTabPageControl tab)
            {
                try
                {
                    Color tab_bak = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "PC");
                    if(tab.SGCS_Style !="light")
                    {
                        tab.SGCS_ItemTitleButtomBorderColor = tab_bak;
                        tab.SGCS_BorderColor = SGFunction.Skins.Skins_GetControlColorSetting("SGTAB", "BD");
                        tab.SGCS_SelectTitleBackColor = SGFunction.Skins.Skins_GetControlColorSetting("SGTAB", "SB");
                        tab.SGCS_SelectTitleTextColor = SGFunction.Skins.Skins_GetControlColorSetting("SGTAB", "SF");
                        tab.SGCS_TitleBackColor = SGFunction.Skins.Skins_GetControlColorSetting("SGTAB", "BK");
                        tab.SGCS_TitleTextColor = SGFunction.Skins.Skins_GetControlColorSetting("sgTAB", "FR");
                    }
                    else
                    {
                        Color sgtab_af_fr = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "fr");
                        Color sgtab_af_bk = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "bk");
                        Color sgtab_af_sb = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "sb");
                        Color sgtab_af_sf = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "sf");
                        Color sgtab_af_uc = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "uc");
                        Color sgtab_af_suc = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "suc");
                        Color sgtab_af_bd = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "bd");
                        tab.SGCS_BorderColor = sgtab_af_bd;
                        tab.SGCS_TitleBackColor = sgtab_af_bk;
                        tab.SGCS_TitleTextColor = sgtab_af_fr;
                        tab.SGCS_Light_UnderLineColor = sgtab_af_uc;
                        tab.SGCS_Light_SelectUnderLineColor = sgtab_af_suc;
                        tab.SGCS_Light_SelectFontColor = sgtab_af_sf;
                    }
                    //首先绘制TAB
                    foreach (TabPage ttt in tab.TabPages)
                    {
                        ttt.BackColor = tab_bak;
                    }
                    //子控件
                    foreach (TabPage tp in tab.TabPages)
                    {
                        foreach (System.Windows.Forms.Control con in tp.Controls)
                        {
                            if (con is Panel)
                            {
                                Panel pp = (Panel)con;
                                foreach (System.Windows.Forms.Control pan in pp.Controls)
                                {
                                    if (pan is Panel)
                                    {
                                        Panel p1 = (Panel)pan;
                                        foreach (System.Windows.Forms.Control pan1 in p1.Controls)
                                        {
                                            DrawControlColorSkin(pan1, tab_bak);
                                        }
                                    }
                                    else
                                    {
                                        DrawControlColorSkin(pan, tab_bak);
                                    }
                                }
                            }
                            else
                            {
                                DrawControlColorSkin(con, tab_bak);
                            }
                        }
                    }
                }
                catch { }
            }
            /// <summary>
            /// 将USERCONTROL中的所有空控件进行绘制 (这个功能仅仅用于绘制需要加载到DIALOG的控件 其他控件请勿尝试)
            /// </summary>
            /// <param name="tab">USERCONTROL 控件</param>
            /// <param name="default_bk">默认的空间的背景色（一般为DIALOG_STANDARD的BK）</param>
            public static void DrawAllControlInUserControl(UserControl tab, Color default_bk)
            {
                try
                {

                    //子控件
                    foreach (System.Windows.Forms.Control con in tab.Controls)
                    {
                        if (con is Panel)
                        {
                            Panel pp = (Panel)con;
                            object tag_pp = pp.Tag;
                            if (tag_pp != null)
                            {
                                string tags = (string)tag_pp;
                                switch (tags.ToUpper())
                                {
                                    case "DRAW_LIGHTCOLOR":
                                        pp.BackColor = SGFunction.Skins.Skins_GetMainColorSetting("MAINCOLOR", "LIGHT");
                                        break;
                                }
                            }
                            foreach (System.Windows.Forms.Control pan in pp.Controls)
                            {
                                if (pan is Panel)
                                {
                                    Panel p1 = (Panel)pan;
                                    foreach (System.Windows.Forms.Control pan1 in p1.Controls)
                                    {
                                        DrawControlColorSkin(pan1, default_bk);
                                    }
                                }
                                else
                                {
                                    DrawControlColorSkin(pan, default_bk);
                                }
                            }
                        }
                        else
                        {
                            DrawControlColorSkin(con, default_bk);
                        }
                    }

                }
                catch { }
            }
            /// <summary>
            /// 绘制某个控件中的颜色样式
            /// </summary>
            /// <param name="con"></param>
            /// <param name="tagbackcolor">非必要的控件的指定的背景色</param>
            public static void DrawControlColorSkin(System.Windows.Forms.Control con, Color tagbackcolor)
            {

                try
                {

                    Color lf_sbk = SGFunction.Skins.Skins_GetControlColorSetting("leftmenu", "sb");
                    Color lf_sfr = SGFunction.Skins.Skins_GetControlColorSetting("leftmenu", "sf");
                    Color o_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "bk");
                    Color o_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "fr");
                    Color o1_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "bk");
                    Color o1_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "fr");
                    Color lab_ma_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_maininfo", "fr");
                    Color lab_fu_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_funinfo", "fr");
                    Color com_bk = SGFunction.Skins.Skins_GetControlColorSetting("combox", "bk");
                    Color com_fr = SGFunction.Skins.Skins_GetControlColorSetting("combox", "fr");
                    Color cb_bk = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "bk");
                    Color cb_bk_1 = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "bk_c1");
                    Color cb_bk_2 = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "bk_c2");
                    Color cb_fr_1 = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "fr_c1");
                    Color cb_fr_2 = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "fr_c2");
                    Color ra_fr = SGFunction.Skins.Skins_GetControlColorSetting("radio", "fr");
                    Color tree_fr = SGFunction.Skins.Skins_GetControlColorSetting("treeview", "fr");
                    Color list_fr = SGFunction.Skins.Skins_GetControlColorSetting("listview", "fr");
                    Color rightmenu_fr = SGFunction.Skins.Skins_GetControlColorSetting("rightmenu", "fr");
                    Color tree_line = SGFunction.Skins.Skins_GetControlColorSetting("treeview", "lc");
                    Color ck_bd = SGFunction.Skins.Skins_GetControlColorSetting("checkbox", "bd");
                    Color ck_fr = SGFunction.Skins.Skins_GetControlColorSetting("checkbox", "fr");
                    Color tb_bd = SGFunction.Skins.Skins_GetControlColorSetting("textbox", "bd");
                    Color tb_nobd = SGFunction.Skins.Skins_GetControlColorSetting("textbox", "nommbd");
                    Color tb_fr = SGFunction.Skins.Skins_GetControlColorSetting("textbox", "fr");
                    Color tb_tip = SGFunction.Skins.Skins_GetControlColorSetting("textbox", "tip");
                    Color tb_error_fr = SGFunction.Skins.Skins_GetControlColorSetting("textbox", "er_tb_fr");
                    Color sgclickitems_fr = SGFunction.Skins.Skins_GetControlColorSetting("sgclick", "fr");
                    Color sgtab_af_fr = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "fr");
                    Color sgtab_af_bk = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "bk");
                    Color sgtab_af_sb = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "sb");
                    Color sgtab_af_sf = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "sf");
                    Color sgtab_af_uc = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "uc");
                    Color sgtab_af_suc = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "suc");
                    Color sgtab_af_bd = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "bd");
                    if (con is MyNormalButton)
                    {
                        MyNormalButton no = (MyNormalButton)con;
                        switch (no.Settings_Role.ToUpper())
                        {
                            case "OTHER":
                                no.BackColor = o_bk; no.ForeColor = o_fr;
                                break;
                            case "OTHER1":
                                no.BackColor = o1_bk; no.ForeColor = o1_fr;
                                break;
                            case "NODRAW":
                                //no.BackColor = o1_bk; no.ForeColor = o1_fr;
                                break;
                        }
                    }
                    else
                    {
                        if (con is SGLabel)
                        {
                            SGLabel no = (SGLabel)con;
                            switch (no.Setting_Role.ToUpper())
                            {
                                case "MAIN":
                                    no.ForeColor = lab_ma_fr;
                                    break;
                                case "FUN":
                                    no.ForeColor = lab_fu_fr;
                                    break;
                            }
                        }
                        else
                        {
                            if (con is SGCombobox || con is ComboBox)
                            {
                                SGCombobox no = (SGCombobox)con; no.BackColor = com_bk; no.ForeColor = com_fr;
                            }
                            else
                            {
                                if (con is SGChooseBox)
                                {
                                    SGChooseBox no = (SGChooseBox)con; no.MyChooseBackColor = cb_bk; no.MyChooseChoose1BackColor = cb_bk_1; no.MyChooseChoose1ForceColor = cb_fr_1; no.MyChooseChoose2BackColor = cb_bk_2; no.MyChooseChoose2ForceColor = cb_fr_2;
                                }
                                else
                                {
                                    if (con is SGRadioButton || con is RadioButton)
                                    {
                                        if (con is SGRadioButton) { SGRadioButton no = (SGRadioButton)con; no.ForeColor = ra_fr; no.BackColor = tagbackcolor; } else { { RadioButton no = (RadioButton)con; no.ForeColor = ra_fr; no.BackColor = tagbackcolor; } }
                                    }
                                    else
                                    {

                                        if (con is SGTreeView || con is TreeView)
                                        {
                                            if (con is SGTreeView) { SGTreeView no = (SGTreeView)con; no.ForeColor = tree_fr; no.LineColor = tree_line; no.BackColor = tagbackcolor; } else { TreeView no = (TreeView)con; no.ForeColor = tree_fr; no.LineColor = tree_line; no.BackColor = tagbackcolor; }
                                        }
                                        else
                                        {
                                            if (con is SGListView || con is ListView)
                                            {
                                                if (con is SGListView)
                                                {
                                                    SGListView no = (SGListView)con;
                                                    no.ForeColor = list_fr;
                                                    no.BackColor = tagbackcolor;
                                                }
                                                else
                                                {
                                                    ListView no = (ListView)con;
                                                    no.ForeColor = list_fr;
                                                    no.BackColor = tagbackcolor;
                                                }
                                            }
                                            else
                                            {
                                                if (con is SGTextBox)
                                                {
                                                    SGTextBox tb = (SGTextBox)con; tb.ForeColor = tb_fr; tb.TextBoxInfoBorderColor = tb_bd; tb.TextBoxInfoTipColor = tb_tip; tb.TextBoxLoseFocusColor = tb_nobd; con.BackColor = tagbackcolor; tb.TextBoxErrorMessageColor = tb_error_fr;
                                                }
                                                else
                                                {
                                                    if (con is PictureBox)
                                                    {
                                                        PictureBox pic = (PictureBox)con;
                                                        try
                                                        {
                                                            if (pic.Tag != null)
                                                            {
                                                                string arr = pic.Tag.ToString();
                                                                if (arr.ToUpper() == "NODRAW") { }
                                                                else
                                                                {
                                                                    if (arr.ToUpper() == "DRAW_DEFAULTCOLOR")
                                                                    {
                                                                        pic.BackColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
                                                                    }
                                                                    else
                                                                    {
                                                                        pic.BackColor = tagbackcolor;
                                                                    }
                                                                }

                                                            }
                                                            else { pic.BackColor = tagbackcolor; }
                                                        }
                                                        catch { }
                                                    }
                                                    else
                                                    {
                                                        if (con is SGCheckBox)
                                                        {
                                                            SGCheckBox cgc = (SGCheckBox)con; cgc.BaseColor = ck_bd; con.ForeColor = ck_fr; cgc.BackColor = tagbackcolor;
                                                        }
                                                        else
                                                        {
                                                            if (con is SystemGear.控件.SGClickItems)
                                                            {
                                                                SystemGear.控件.SGClickItems cgc = (SystemGear.控件.SGClickItems)con; con.ForeColor = sgclickitems_fr;
                                                            }
                                                            else
                                                            {
                                                                if (con is SGTabPageControl)
                                                                {
                                                                    //LIGHT 亮色的TAB
                                                                    SystemGear.SGTabPageControl m = (SystemGear.SGTabPageControl)con;
                                                                    if (m.SGCS_Style.ToLower() == "light")
                                                                    {
                                                                        m.SGCS_BorderColor = sgtab_af_bd;
                                                                        m.SGCS_TitleBackColor = sgtab_af_bk;
                                                                        m.SGCS_TitleTextColor = sgtab_af_fr;
                                                                        m.SGCS_Light_UnderLineColor = sgtab_af_uc;
                                                                        m.SGCS_Light_SelectUnderLineColor = sgtab_af_suc;
                                                                        m.SGCS_Light_SelectFontColor = sgtab_af_sf;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
            }
            /// <summary>
            /// 返回针对rolecode的控件在colortype状态下的颜色
            /// </summary>
            /// <param name="rolecode">控件的角色标识 [OTHER]默认的颜色 [CLOSEBTN]关闭按钮 [OTHER1]次级按钮 [LAB]标签</param>
            /// <param name="colortype">获取颜色状态 []正常情况下 [MOUSEMOVE]鼠标移动到控件上时的颜色 [BACK]背景色 [FORE]字体颜色 [LAB_INFO]介绍主功能的颜色 [LAB_FUNINFO]介绍分功能的颜色</param>
            /// <returns></returns>
            public static Color Skins_GetRoleColor(string rolecode, string colortype = "")
            {
                Color ret = Color.FromArgb(0, 107, 43);
                switch (rolecode.ToUpper())
                {
                    case "OTHER":
                        ret = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "bk");
                        break;
                    case "CLOSEBTN":
                        switch (colortype.ToUpper())
                        {
                            case "":
                                ret = Color.Transparent;
                                break;
                            case "MOUSEMOVE":
                                ret = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "cb_mm");
                                break;
                        }
                        break;
                }
                return ret;
            }
            /// <summary>
            /// 获取系统齿轮非控件的颜色设置
            /// </summary>
            /// <param name="type">模式 [maincolor]主颜色设置</param>
            /// <param name="code">[defaultcolor]默认的主颜色 [light] 亮色</param>
            /// <returns></returns>
            public static Color Skins_GetMainColorSetting(string type, string code)
            {
                Color tt = Color.FromArgb(7, 107, 43);
                string str = "7,107,43";
                try
                {
                    switch (type.ToLower())
                    {
                        case "maincolor":
                            switch (code.ToLower())
                            {
                                case "defaultcolor":
                                    str = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", "color_default", "7,107,43", _SKINSCONFIG, false);
                                    tt = SGFunction.ColorOperate.GetColorFromStr(str);
                                    break;
                                case "light":
                                    str = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", "color_light", "12,184,72", _SKINSCONFIG, false);
                                    tt = SGFunction.ColorOperate.GetColorFromStr(str);
                                    break;
                            }
                            break;
                    }
                    return tt;
                }
                catch { return tt; }
            }
            /// <summary>
            /// 获取系统齿轮内部控件或窗体的颜色设置
            /// </summary>
            /// <param name="control">控件或窗体的代码 [other]定义的其他颜色 [textbox]文本框 [sgclick] 系统齿轮点击控件 [sgtab]选项卡控件 [leftmenu]左菜单 [dialog_main]主页窗体(MAIN和SYSTEMSTYLE) [dialog_standard] 标准窗体 [btn_other]默认的按钮 [btn_ohter1]次级按钮 [label_maininfo]主功能介绍标签 [label_funinfo]分功能介绍标签 [searchbox]搜索按钮 [combox]下拉菜单 [choosebox]2选择按钮 [checkbox]复选框按钮 [radio]单选框按钮 [treeview]树状图 [listview]列表视图 [rightmenu]右键菜单 [sgtab_allfunctions]主界面上的所有舍子SGTAB颜色样式</param>
            /// <param name="type">控件代码 [bk]背景颜色 [fr]字体颜色 [sb]选中项目后的背景色 [sf]选中项目后的字体颜色 [tile_bk]所有设置中的按钮背景色 [tile_fr]所有设置中的按钮字体色 [title_bk] 标准窗体的标题栏颜色 [title_fr]标准窗体的任务栏字体颜色 [pc]选项卡的容器内的背景色 [bd]边框颜色 [lc]TreeView控件中节的线条颜色 [bk_c1]选项1背景色 [bk_c2]选项2背景色 [fr_c1]选项1字体色 [fr_c2]选项2字体色 [cb_mm]关闭按钮被鼠标移动到现实的颜色 [tip]提示文字颜色 [er_tb_fr] 文本框中出错颜色 [nommbd]失去焦点的文本框的边框颜色 [pt_tit_fc]主窗口产品名称标题的字体颜色 [UC]下划线颜色，适用于SGTAB [suc]选中后的喜爱划线的颜色适用于SGTAB</param>
            /// <returns></returns>
            public static Color Skins_GetControlColorSetting(string control, string type)
            {
                Color tt = Color.FromArgb(7, 107, 43);
                string read = "7,107,43";
                switch (control.ToLower())
                {
                    case "sgtab":
                        switch (type.ToLower())
                        {
                            case "bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("SGTAB", "title_backcolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("SGTAB", "title_forcecolor", "0,55,58", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "sb":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("SGTAB", "title_selectbackcolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "sf":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("SGTAB", "title_selectforcecolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "pc":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("SGTAB", "panelcolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "bd":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("SGTAB", "bordercolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "sgtab_allfunctions":
                        switch (type.ToLower())
                        {
                            case "bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "title_backcolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "title_forcecolor", "185,185,185", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "sb":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "title_selectbackcolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "sf":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "title_selectforcecolor", "0,55,58", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "uc":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "underlinecolor", "185,185,185", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "suc":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "select_underlinecolor", "0,55,58", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "bd":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "bordercolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "tile_bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "tile_backcolor", "0,55,58", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "tile_fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "tile_backcolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "leftmenu":
                        switch (type.ToLower())
                        {
                            case "bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "backcolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "forcecolor", "0,55,58", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "sb":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "selectbackcolor", "0,55,58", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "sf":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "selectforcecolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "dialog_main":
                        switch (type.ToLower())
                        {
                            case "bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "backcolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "bd":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "bordercolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "pt_tit_fc":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "product_title_forcecolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "dialog_standard":
                        switch (type.ToLower())
                        {
                            case "bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "backcolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "bd":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "bordercolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "pt_tit_fc":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "product_title_forcecolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "title_bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "title_backcolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "title_fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "title_forcecolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "btn_other":
                        switch (type.ToLower())
                        {
                            case "bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "backcolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "forcecolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "cb_mm":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "closebtn_mousemovecolor", "212,64,39", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "btn_other1":
                        switch (type.ToLower())
                        {
                            case "bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "backcolor", "185,185,185", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "forcecolor", "34,34,34", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "label_maininfo":
                        switch (type.ToLower())
                        {
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("lab_maininfo", "forcecolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "label_funinfo":
                        switch (type.ToLower())
                        {
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("lab_funinfo", "forcecolor", "34,34,34", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "searchbox":
                        switch (type.ToLower())
                        {
                            case "bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "backcolor", "0,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "forcecolor", "0,55,58", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "combox":
                        switch (type.ToLower())
                        {
                            case "bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "backcolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "forcecolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "choosebox":
                        switch (type.ToLower())
                        {
                            case "bk":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "backcolor", "185,185,185", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "bk_c1":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "choose1_backcolor", "100,100,100", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "bk_c2":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "choose2_backcolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "fr_c1":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "choose1_forcecolor", "255,255,255", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "fr_c2":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "choose2_forcecolor", "34,34,34", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "checkbox":
                        switch (type.ToLower())
                        {
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "forcecolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "bd":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "bordercolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "radio":
                        switch (type.ToLower())
                        {
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "forcecolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "listview":
                        switch (type.ToLower())
                        {
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "forcecolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "treeview":
                        switch (type.ToLower())
                        {
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "forcecolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "lc":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "linecolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "rightmenu":
                        switch (type.ToLower())
                        {
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "forcecolor", "34,34,34", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "sgclick":
                        switch (type.ToLower())
                        {
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("sgclickitems", "forcecolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                    case "textbox":
                        switch (type.ToLower())
                        {
                            case "fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "forcecolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "bd":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "bordercolor", "7,107,43", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "tip":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "tipcolor", "185,185,185", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "nommbd":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "nomousemovebordercolor", "34,34,34", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                            case "er_tb_fr":
                                read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(control, "error_forcecolor", "255,0,0", _SKINSCONFIG, false);
                                tt = SGFunction.ColorOperate.GetColorFromStr(read);
                                break;
                        }
                        break;
                }
                return tt;
            }
        }
        /// <summary>
        /// 提供对IE的管理
        /// </summary>
        public class InternetExplorerMgr
        {
            /// <summary>
            /// 获取IE的主页 (IE的主页可以是多个)
            /// </summary>
            /// <returns></returns>
            public static string[] GetInternetExplorer_HomePages()
            {
                List<string> result = new List<string>();
                string[] secondpages = null;
                string page1 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.CurrentUser, @"SOFTWARE\Microsoft\Internet Explorer\Main", "start page", "");
                if (page1 != "") { result.Add(page1); }
                object pages = SGFunction.RegistryOperate.RegistryOperate_ValueOperate_GetObject("GET", Registry.CurrentUser, @"SOFTWARE\Microsoft\Internet Explorer\Main", "Secondary Start Pages", "");
                if (pages != null)
                {
                    if (pages != "") { secondpages = (string[])pages; }
                }
                if (secondpages != null)
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
        }
        /// <summary>
        /// 提供对系统的功能进行访问
        /// </summary>
        public class SystemFunctionAndInformation
        {

            /// <summary>
            /// 打开文件
            /// </summary>
            /// <param name="file">文件</param>
            /// <returns></returns>
            public static void ShellFile(string file)
            {
                ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder(file), null, null, 1);
            }
            /// <summary>
            /// 获取本机于REFEXON.COM的连接状态 TRUE成功 FALSE 失败
            /// </summary>
            /// <returns></returns>
            public static bool CheckComputerNetwork()
            {
                try
                {
                    Ping p = new Ping();//创建Ping对象p
                    PingReply pr = p.Send("refexon.com");//向指定IP或者主机名的计算机发送ICMP协议的ping数据包

                    if (pr.Status == IPStatus.Success)//如果ping成功
                    {
                        // MessageBox.Show("网络连接成功, 执行下面任务...");
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                catch { return false; }
            }

            /// <summary>
            /// 获取文件类型在系统中显示的名称
            /// </summary>
            /// <param name="ext">扩展名</param>
            /// <returns></returns>
            public static string GetFileTypeDescription(string ext)
            {
                string setfileinfo = ext + "文件";
                try
                {
                    string biaoshifuname = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, ext, "", "");
                    if (biaoshifuname != "")
                    {
                        string _info = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.ClassesRoot, biaoshifuname, "", "");
                        if (_info != "" && SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.ClassesRoot, biaoshifuname, "FriendlyTypeName", "none") == "none")
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
                                string read = SGFunction.MUIOperate.GetMUIString(loc, "none");
                                if (read != "none") { setfileinfo = read; }
                            }
                        }
                    }
                    return setfileinfo;
                }
                catch
                {
                    return setfileinfo;
                }
            }
            /// <summary>
            /// 获取系统的驱动器目录 [F:\]
            /// </summary>
            /// <returns></returns>
            public static string FindSystemDrive()
            {
                try
                {
                    string dd = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    DirectoryInfo di = new DirectoryInfo(dd);
                    return di.Root.ToString();
                }
                catch { return ""; }
            }
            /// <summary>
            /// 查找系统启动分区 (未完工 不可用)
            /// </summary>
            /// <returns></returns>
            public static string FindSystemBootDrive()
            {
                try
                {
                    string[] files = new string[] { "bootmgr", "boot\\bcd" };
                    string[] dirs = new string[] { "boot" };
                    string[] exp_dirs = new string[] { "sources", "support" };
                    string[] exp_files = new string[] { "sources\\setup.exe", "sources\\boot.wim", "sources\\install.wim" };
                    string[] lets = SGFunction.FileSystemOperate.FSO_GetLocalDiskDrives(DriveType.Fixed);
                    return "";
                }
                catch { return ""; }
            }
            /// <summary>
            /// 判断当前的用户是否是管理员
            /// </summary>
            /// <returns></returns>
            public static bool IsAdministrator()
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            /// <summary>
            /// 锁定计算机
            /// </summary>
            /// <param name="q">是否询问用户</param>
            public static void LockComputer(bool q = false)
            {
                try
                {
                    string app = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\rundll32.exe";
                    string arg = "user32.dll LockWorkStation";
                    if (q == false)
                    {
                        SGFunction.SystemFunctionAndInformation.ShellPrograms(app, arg, false, false, false, false);
                    }
                    else
                    {
                        string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您确定要锁定计算机？", "锁定计算机后，您可能需要输入登录的密码。", "继续", "取消", "b2", "ques");
                        if (res == "b1")
                        {
                            SGFunction.SystemFunctionAndInformation.ShellPrograms(app, arg, false, false, false, false);
                        }
                    }
                }
                catch { }
            }
            /// <summary>
            /// 获取系统屏幕的分辨率
            /// </summary>
            /// <returns></returns>
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
            /// 打开“计算机”
            /// </summary>
            public static void ShellMyComputer()
            {
                string app = "explorer.exe";
                string arg = "shell:::{20d04fe0-3aea-1069-a2d8-08002b30309d}";
                SGFunction.SystemFunctionAndInformation.ShellPrograms(app, arg, false, false, false, false);
            }
            /// <summary>
            /// 对于windows 8中的LNK文件 调用此函数可以添加winx菜单
            /// </summary>
            /// <param name="lnkfile">LNK文件</param>
            public static void HashLinkInWin8(string lnkfile)
            {
                string app = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + "\\hashlnk.exe";
                string args = @"""" + lnkfile + @"""";
                SGFunction.SystemFunctionAndInformation.ShellPrograms(app, args, true, false, true, true);
            }
            #region 系统壁纸api
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern bool SystemParametersInfo(uint uAction, uint uParam, StringBuilder lpvParam, uint init);
            const uint SPI_GETDESKWALLPAPER = 0x0073;
            public const uint LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
            #endregion
            /// <summary>
            /// 获取系统当前的壁纸
            /// </summary>
            /// <returns></returns>
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
            /// <summary>
            /// 获取壁纸的路径
            /// </summary>
            /// <returns></returns>
            public static string GetWallpaperPath()
            {
                StringBuilder wallPaperPath = new StringBuilder(200);
                if (SystemParametersInfo(SPI_GETDESKWALLPAPER, 200, wallPaperPath, 0))
                {
                    //MessageBox.Show(wallPaperPath.ToString());
                    try
                    {
                        return wallPaperPath.ToString();
                    }
                    catch { return ""; }
                }
                else { return ""; }
            }
            /// <summary>
            /// 获取日期和时间代码 年+月+日+小时+分钟+秒钟+毫秒 例:2014622143710
            /// </summary>
            /// <returns></returns>
            public static string GetDateAndTime()
            {
                DateTime n = DateTime.Now;
                string j = n.Year.ToString() + n.Month.ToString() + n.Day.ToString() + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString() + n.Millisecond.ToString();
                return j;
            }
            /// <summary>
            /// 从指定的DateTime类中获取日期和时间代码 年+月+日+小时+分钟+秒钟+毫秒 例:2014622143710
            /// </summary>
            /// <param name="dt">DateTime 类</param>
            /// <returns></returns>
            public static string GetDateAndTime_FromDateTimeClass(DateTime dt)
            {
                DateTime n = dt;
                string j = n.Year.ToString() + n.Month.ToString() + n.Day.ToString() + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString() + n.Millisecond.ToString();
                return j;
            }
            /// <summary>
            /// 获取系统位数 [32]32位系统 [64]64位系统
            /// </summary>
            /// <returns></returns>
            public static string GetOSBit()
            {
                string folder = Environment.GetEnvironmentVariable("windir") + "\\syswow64";
                if (System.IO.Directory.Exists(folder) == true) { return "64"; } else { return "32"; }
            }
            /// <summary>
            /// 获取Windows的NT版本号
            /// </summary>
            /// <returns></returns>
            public static string GetOSVersion()
            {
                //// "10.0";
                string j1 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentVersion");
                try
                {

                    string j = SGFunction.FileSystemOperate.FSO_GetEXEFileVersionInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\winver.exe");
                    string[] vers = j.Split('.');
                    if (vers.Length == 4)
                    {
                        return vers[0] + "." + vers[1];
                    }
                    else { return j1; }
                }
                catch
                {
                    return j1;
                }
            }
            /// <summary>
            /// 获取系统的Build号 例如6.3.9600.17041 则获取的是17041
            /// </summary>
            /// <returns></returns>
            public static string GetOSBuildVersion()
            {
                string j1 = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "BuildLabEx");
                string[] j1v = j1.Split('.'); string bl = "";
                if (j1v.Length == 4)
                {
                    bl = j1v[3];
                }
                try
                {
                    string j = SGFunction.FileSystemOperate.FSO_GetEXEFileVersionInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\winver.exe");
                    string[] vers = j.Split('.');
                    if (vers.Length == 4)
                    {
                        return vers[3];
                    }
                    else { return bl; }

                }
                catch
                {
                    return bl;
                }
            }
            [DllImport("user32.dll")]
            public static extern bool GetCursorPos(out Point pt);
            /// <summary>
            /// 获取鼠标的位置
            /// </summary>
            /// <returns></returns>
            public static Point GetMouseLocation()
            {
                Point p;
                GetCursorPos(out p);
                return p;
            }
            /// <summary>
            /// 更新桌面图标
            /// </summary>
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
            /// <summary>
            /// 注销系统(有提示)
            /// </summary>
            public static void LogOff()
            {
                string j = SGFunction.CommonDialogs.MessageDialog_MustClick("是否重注销系统?", "注销系统有可能会导致未保存的数据、文档或图像丢失。.", "是", "否", "b1", "ques");
                if (j == "b1")
                {
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("shutdown.exe", "/l", true, false, false, false);
                }
            }
            /// <summary>
            /// 关闭进程
            /// </summary>
            /// <param name="ProcessName">进程名(notepad explorer) 自动加EXE</param>
            /// <param name="useexe">是否使用系统自带的taskkill结束进程</param>
            /// <param name="verifypath">(目前不可用)是否验证指定的路径与被结束的程序的路径是否相等(只用于userexe为false时 并且指定了路劲时才可使用)</param>
            /// <returns></returns>
            public static bool CloseProcess(string ProcessName, bool useexe = true, string verifypath = "")
            {
                try
                {

                    if (useexe == false)
                    {
                        // 获取系统当前运行的所有进程
                        Process[] allProcess = Process.GetProcesses();
                        foreach (Process p in allProcess)
                        {
                            System.Console.WriteLine(p.ToString());
                        }
                        // 结束指定进程名称的进程
                        Process[] killprocess = Process.GetProcessesByName(ProcessName);
                        foreach (System.Diagnostics.Process p in killprocess)
                        {
                            //bool gt=Equals(p.StartInfo. verifypath.ToUpper());
                            //if(p.StartInfo.FileName e)
                            p.Kill();
                        }

                    }
                    else
                    {
                        string app = "taskkill.exe";
                        string arg = @"/im """ + ProcessName + ".exe" + @""" /f";
                        SGFunction.SystemFunctionAndInformation.ShellPrograms(app, arg, true, false, false, true);
                    }
                }
                catch
                {
                    return false;                         //失败
                }
                return true;                             //成功
            }
            /// <summary>
            /// 运行URL链接
            /// </summary>
            /// <param name="URL"></param>
            /// <returns></returns>
            public static bool StartURL(string URL)
            {
                try
                {
                    //int j=SGFunction.ShellExecute(IntPtr.Zero, new StringBuilder("open"), new StringBuilder("http://www.baidu.com"), new StringBuilder(""), new StringBuilder(""), 5);
                    //System.Diagnostics.Process.Start(URL);
                    int res = SGFunction.ShellExecute(IntPtr.Zero, new StringBuilder("open"), new StringBuilder(URL), new StringBuilder(""), new StringBuilder(""), 5);
                    if (res == 31)
                    {
                        //没有打开网页
                        //没有关联http协议
                        //using cmd
                        SGFunction.SystemFunctionAndInformation.ShellPrograms("cmd.exe", @"/c explorer """ + URL + @"""", true, false, false, true);
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            /// <summary>
            /// 重启资源管理器(有提示)
            /// </summary>
            public static void ReStartExplorer()
            {
                string red = SGFunction.CommonDialogs.MessageDialog_MustClick("是否重启资源管理器?", "重启管理器可以帮助您应用这个设置 , 但会导致您所打开的文件夹的窗口遭到关闭.", "是", "否", "b1", "ques");
                if (red == "b1")
                {
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("tskill.exe", "explorer", true, false, false, false);
                }
            }
            /// <summary>
            /// 运行程序
            /// </summary>
            /// <param name="AppPath">程序路径</param>
            /// <param name="AppArgs">程序启动参数</param>
            /// <param name="IsHidden">是否隐藏</param>
            /// <param name="HasEnvironmetVars">是否包含变量</param>
            /// <param name="IsRunAsAdmin">是否以管理员权限运行</param>
            /// <param name="WaitForExit">等待执行结束</param>
            /// <param name="workdir">程序工作路径</param>
            /// <returns></returns>
            public static bool ShellPrograms(string AppPath, string AppArgs, bool IsHidden, bool HasEnvironmetVars, bool IsRunAsAdmin, bool WaitForExit, string workdir = "")
            {
                try
                {
                    string VERB = "";
                    if (IsRunAsAdmin == true) { VERB = "runas"; }
                    string NewAppPath = AppPath;
                    if (HasEnvironmetVars == true || System.IO.File.Exists(AppPath) == false)
                    {
                        NewAppPath = SGFunction.PathOperate.ConvertStringToTurePath(NewAppPath, NewAppPath);
                    }
                    System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    if (VERB != "") { start.Verb = VERB; }
                    start.Arguments = AppArgs;
                    start.FileName = NewAppPath;
                    if (IsHidden == true)
                    {
                        start.WindowStyle = ProcessWindowStyle.Hidden;
                    }
                    if (workdir != "") { start.WorkingDirectory = workdir; }
                    if (WaitForExit == true)
                    {
                        p = System.Diagnostics.Process.Start(start);
                        p.WaitForExit();
                    }
                    else
                    {
                        p = System.Diagnostics.Process.Start(start);
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            } //运行程序
            /// <summary>
            /// 创建快捷方式
            /// </summary>
            /// <param name="ShortcutPath">LNK文件路径</param>
            /// <param name="TargetPath">目标的路径</param>
            /// <param name="ProgramArgs">程序启动参数</param>
            /// <param name="Info">提示信息</param>
            /// <param name="Icon">图标</param>
            /// <returns></returns>
            public static bool CreateLink(string ShortcutPath, string TargetPath, string ProgramArgs, string Info, string Icon = "")
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
            /// <summary>
            /// 创建快捷方式(拥有管理员权限)
            /// </summary>
            /// <param name="ShortcutPath">lnk文件位置</param>
            /// <param name="TargetPath">目标</param>
            /// <param name="ProgramArgs">启动参数</param>
            /// <param name="Info">注释</param>
            /// <param name="Icon">图表</param>
            /// <returns></returns>
            public static bool CreateLink_StartAdminType(string ShortcutPath, string TargetPath, string ProgramArgs, string Info, string Icon = "")
            {
                try
                {
                    string a = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs", "") + "\\Admin.lnk.sgo";
                    SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(a, ShortcutPath);
                    IWshShortcut _shortcut = null;
                    IWshShell_Class shell = new IWshShell_Class();
                    _shortcut = shell.CreateShortcut(ShortcutPath) as IWshShortcut;
                    _shortcut.TargetPath = TargetPath;
                    _shortcut.Arguments = ProgramArgs;
                    _shortcut.Description = Info;
                    _shortcut.WorkingDirectory = SGFunction.FileSystemOperate.FileSystemOperate_GetFileLocation(TargetPath);
                    if (Icon != "")
                    {
                        _shortcut.IconLocation = Icon;
                    }
                    _shortcut.Save();
                    return true;
                }
                catch { return false; }
            }
            /// <summary>
            /// 固定程序到任务栏
            /// </summary>
            /// <param name="LockOrUnLock">true为固定;false为取消固定</param>
            /// <param name="LinkPath">LNK文件位置</param>
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
                            _shortcut.WindowStyle = SGFunction.StringOperate.ConvertToInt32(TiHuanStrings, 1);
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
                                    ret = SGFunction.SystemFunctionAndInformation.ReadLink(LinkPath, "path") + path2;
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
        }
        /// <summary>
        /// 提供对颜色的操作
        /// </summary>
        public class ColorOperate
        {
            /// <summary>
            /// 用于获取指定颜色缩小或增大deep个单位的之后的颜色
            /// </summary>
            /// <param name="color">指定的颜色</param>
            /// <param name="deep">深度</param>
            /// <returns></returns>
            public static Color GetColorInDeep(Color color, int deep)
            {
                try
                {
                    int r, g, b;
                    //r
                    if (color.R + deep > 255)
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

            /// <summary>
            /// 从标准的RGB字符中读取颜色
            /// </summary>
            /// <param name="s">字符(R,G,B)</param>
            /// <returns></returns>
            public static Color GetColorFromStr(string s)
            {
                try
                {
                    int rr = 0;
                    int gg = 148;
                    int bb = 255;
                    Color def;
                    string[] arg = s.Split(',');
                    if (arg.Length == 3)
                    {
                        string r = arg[0].Trim();
                        string g = arg[1].Trim();
                        string b = arg[2].Trim();
                        int.TryParse(r, out rr); int.TryParse(g, out gg); int.TryParse(b, out bb);
                    }
                    def = Color.FromArgb(rr, gg, bb);
                    return def;

                }
                catch { return Color.FromArgb(0, 148, 255); }
            }
            /// <summary>
            /// 将RGB格式的颜色转换为HTML格式
            /// </summary>
            /// <param name="ColorFromRGB">RGB颜色</param>
            /// <returns></returns>
            public static string Convert_ColorRGBtoHTML(Color ColorFromRGB)
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
        }
        /// <summary>
        /// 提供对SGPAK文件的操作
        /// </summary>
        public class PackageOperate
        {
            /// <summary>
            /// 解压SGPAK文件
            /// </summary>
            /// <param name="SGPAK">SGPAK文件路径</param>
            /// <param name="FolderPath">解压的文件夹 如果为空则读取[压缩包]\packageinfo.sgpakinfo的节点[main]\expath [main]\shell [main]\args</param>
            /// <param name="IsRunByExplorer">解压的命令是否有资源管理器引发 [true]则读取[压缩包]\packageinfo.sgpakinfo的节点[main]\expath [main]\shell [main]\args</param>
            public static void SGPAK_ExtactPackage(string SGPAK, string FolderPath, bool IsRunByExplorer)
            {
                try
                {
                    string cab = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Expand.exe";
                    string n = SGFunction.FileSystemOperate.FSO_GetFileNameWithoutExt(SGPAK);
                    string temppath = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("TEMP") + "\\" + n;
                    SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(temppath);
                    string packinfo = temppath + @"\packageinfo.sgpakinfo";
                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(packinfo);
                    string excart_path = FolderPath;
                    if (IsRunByExplorer == true || excart_path == "")
                    {
                        SGFunction.SystemFunctionAndInformation.ShellPrograms(cab, @"""" + SGPAK + @""" """ + temppath + @""" -f:*.sgpakinfo", true, false, true, true);
                        string exl = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue("main", "expath", "", packinfo, true);
                        string shell = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue("main", "shell", "", packinfo, true);
                        string arg = SGFunction.ConfigFileOperate.ConfigFileOperate_GetValue("main", "args", "", packinfo, true);
                        SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(exl);
                        SGFunction.SystemFunctionAndInformation.ShellPrograms(cab, @"""" + SGPAK + @""" """ + exl + @""" -f:*.*", true, false, true, true);
                        string extsginfo = exl + "\\packageinfo.sgpakinfo";
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(extsginfo);
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(packinfo);
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFolder(temppath, true);
                        if (shell != "")
                        {
                            SGFunction.SystemFunctionAndInformation.ShellPrograms(shell, arg, false, false, true, false);
                        }
                    }
                    else
                    {
                        string extsginfo = excart_path + "\\packageinfo.sgpakinfo";
                        SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(excart_path);
                        SGFunction.SystemFunctionAndInformation.ShellPrograms(cab, @"""" + SGPAK + @""" """ + excart_path + @""" -f:*.*", true, false, true, true);
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(packinfo);
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(extsginfo);
                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// 提供对文件系统访问
        /// </summary>
        public class FileSystemOperate
        {
            /// <summary>
            /// 获取某个扩展名的详细描述信息
            /// </summary>
            /// <param name="ext">扩展名 .dll</param>
            /// <returns></returns>
            public static string FSO_GetFileTypeInfoFromRegistry(string ext)
            {
                string biaoshifuname = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.ClassesRoot, ext, "", "");
                if (biaoshifuname == "") { return ""; }
                string _info = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.ClassesRoot, biaoshifuname, "", "");
                string setfileinfo = "";
                if (_info != "" && SGFunction.RegistryOperate.RegistryOperate_ValueOperate("GET", Registry.ClassesRoot, biaoshifuname, "FriendlyTypeName", "none") == "none")
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
                        string read = SGFunction.MUIOperate.GetMUIString(loc, "none");
                        if (read != "none") { setfileinfo = read; }
                    }
                }
                return setfileinfo;
            }
            /// <summary>
            /// 通过系统API删除文件或文件夹 可以将文件夹连根拔除
            /// </summary>
            /// <param name="fof">文件或文件夹</param>
            /// <param name="allowrec">是否允许回复</param>
            /// <returns>true false</returns>
            public static bool DeleteFileFolderAndSendToReclyBin(string fof, bool allowrec = true)
            {
                SHFILEOPSTRUCT pm = new SHFILEOPSTRUCT();
                pm.wFunc = FO_DELETE;
                pm.pFrom = fof + "\0";
                //pm.pTo = @"c:\a.exe";
                ushort g = FOF_NOCONFIRMATION | FOF_NOERRORUI;
                if (allowrec == true)
                {
                    g = FOF_ALLOWUNDO | FOF_NOCONFIRMATION | FOF_NOERRORUI;
                }
                pm.fFlags = g;
                pm.lpszProgressTitle = "";
                return !SHFileOperation(pm);

            }

            /// <summary>
            /// 获取系统中没有分配的盘符 数组 [F:\]
            /// </summary>
            /// <param name="resplacestr">移除的字符 [空]不移除</param>
            /// <returns></returns>
            public static string[] FSO_GetEmptyLetter(string resplacestr = "")
            {
                try
                {
                    string[] drs = System.IO.Directory.GetLogicalDrives();
                    //区补集
                    string[] all = new string[] { "A", "B", "C", "D", "E", "F", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                    List<string> ret = new List<string>();
                    List<string> DRS = new List<string>();
                    List<string> ALL = new List<string>();
                    for (int y = 1; y <= drs.Length; y++) { DRS.Add(drs[y - 1].ToUpper()); }
                    for (int y = 1; y <= all.Length; y++) { ALL.Add(all[y - 1] + ":\\"); }
                    //where(from o in ALL select o).Contains(i); ///包含
                    //where !(from o in oneList select o).Contains(i) 不包含
                    var searchResult = from i in ALL
                                       where !(from o in DRS select o).Contains(i)
                                       select i;
                    //打印到屏幕
                    foreach (string num in searchResult)
                    {
                        if (resplacestr != "") { ret.Add(num.Replace(resplacestr, "")); } else { ret.Add(num); }
                    }
                    return ret.ToArray();
                }
                catch { return null; }
            }
            /// <summary>
            /// 获取文件目录 不要磁盘目录 例如[\WINDOWS\SYSTEM32]
            /// </summary>
            /// <param name="p">文件</param>
            /// <param name="root">输出的磁盘目录 [T:\]</param>
            /// <returns></returns>
            public static string FSO_GetFilePathWithoutDrive(string p, out string root)
            {
                try
                {
                    if (FileSystemOperate_GetFileExists(p) == true)
                    {
                        string r = p.Substring(0, 3);
                        string ff = p.Substring(2, p.Length - 2);
                        root = r;
                        return ff;
                    }
                    else { root = ""; return ""; }
                }
                catch { root = ""; return ""; }
            }
            /// <summary>
            /// 获取这个电脑中拥有最大空闲空间的驱动器的卷标 [R:\]
            /// </summary>
            /// <param name="drt">驱动器类型</param>
            /// <param name="freespace">空闲的空间 单位 : Byte</param>
            /// <returns></returns>
            public static string FSO_GetTheMaxFreeSpaceDriveLetter(DriveType drt, out long freespace)
            {
                try
                {
                    long temp_max = 0;
                    string temp_disk = "";
                    string[] drives = Directory.GetLogicalDrives();
                    for (int p = 1; p <= drives.Length; p++)
                    {
                        DriveInfo dr = new DriveInfo(drives[p - 1]);
                        //首先判断他是不是准备好了
                        if (dr.IsReady == true)
                        {
                            DriveType dt = dr.DriveType;
                            if (dt == drt)
                            {
                                if (dr.AvailableFreeSpace >= temp_max)
                                {
                                    temp_max = dr.AvailableFreeSpace;
                                    temp_disk = drives[p - 1];
                                }
                            }
                        }
                        else
                        {
                            //没准备好
                            //不管
                        }
                    }
                    //判断大小
                    freespace = temp_max;
                    return temp_disk;
                }
                catch { freespace = 0; return ""; }
            }
            /// <summary>
            /// 获取文件的相关信息 好用~~
            /// </summary>
            /// <param name="path">路径</param>
            /// <returns></returns>
            public static FileVersionInfo FSO_GetFileDetailInfo_Best(string path)
            {
                path = SGFunction.PathOperate.IMPORTANT_PathUseful(path);
                try
                {
                    FileVersionInfo file1 = System.Diagnostics.FileVersionInfo.GetVersionInfo(path);
                    return file1;
                }
                catch { return null; }
            }
            /// <summary>
            /// 获取EXE文件的版本号 版本号显示为“主版本号.次版本号.内部版本号.专用部件号”。
            /// </summary>
            /// <param name="exe"></param>
            /// <returns></returns>
            public static string FSO_GetEXEFileVersionInfo(string exe)
            {
                try
                {
                    if (FileSystemOperate_GetFileExists(exe) == true)
                    {
                        FileVersionInfo file1 = System.Diagnostics.FileVersionInfo.GetVersionInfo(exe);
                        string j = String.Format("{0}.{1}.{2}.{3}", file1.FileMajorPart, file1.FileMinorPart, file1.FileBuildPart, file1.FilePrivatePart);
                        return j;
                    }
                    else { return ""; }
                }
                catch { return ""; }
            }
            /// <summary>
            /// 获取这个计算机中指定drt类型的驱动器
            /// </summary>
            /// <param name="drt">驱动器类型</param>
            /// <returns></returns>
            public static string[] FSO_GetLocalDiskDrives(DriveType drt)
            {
                try
                {
                    string[] rets = null;
                    string[] drives = Directory.GetLogicalDrives();
                    string disks = "";
                    for (int p = 1; p <= drives.Length; p++)
                    {
                        DriveInfo dr = new DriveInfo(drives[p - 1]);
                        //首先判断他是不是准备好了
                        if (dr.IsReady == true)
                        {
                            DriveType dt = dr.DriveType;
                            if (dt == drt)
                            {
                                if (disks == "") { disks = drives[p - 1]; } else { disks = disks + "|" + drives[p - 1]; }
                            }
                        }
                        else
                        {
                            //没准备好
                            //不管
                        }
                    }
                    if (disks == "")
                    {
                        return null;
                    }
                    else
                    {
                        return disks.Split('|');
                    }
                }
                catch { return null; }
            }
            /// <summary>
            /// 判断一个目录中是否存在包含在dirs中的所有元素的文件夹
            /// </summary>
            /// <param name="disk">磁盘目录 [F:\]</param>
            /// <param name="dirs"> 文件夹 [windows\system]</param>
            /// <returns></returns>
            public static bool FSO_FindDirsExistsInDir(string disk, string[] dirs)
            {
                try
                {
                    for (int o = 1; o <= dirs.Length; o++)
                    {
                        bool ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFolderExists(disk + dirs[o - 1], false);
                        if (ext == false) { return false; }
                    }
                    return true;
                }
                catch { return false; }
            }
            /// <summary>
            /// 判断一个目录中是否存在包含在files中的所有元素的文件
            /// </summary>
            /// <param name="disk">磁盘目录 例如[D:\]</param>
            /// <param name="files">文件列表 元素的形式[windows\system32\winver.exe]</param>
            /// <returns></returns>
            public static bool FSO_FindFileExistsInDir(string disk, string[] files)
            {
                try
                {
                    for (int o = 1; o <= files.Length; o++)
                    {
                        bool ext = SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(disk + files[o - 1]);
                        if (ext == false) { return false; }
                    }
                    return true;
                }
                catch { return false; }
            }
            /// <summary>
            /// 修改文件的文件名
            /// </summary>
            /// <param name="f">源文件</param>
            /// <param name="newnamewithpath">路径(f的所在目录) + 新的文件名</param>
            /// <returns></returns>
            public static bool FSO_RenameFile(string f, string newnamewithpath)
            {
                try
                {
                    System.IO.FileInfo fi = new FileInfo(f);
                    if (fi.Exists == true)
                    {
                        fi.MoveTo(newnamewithpath);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch { return false; }
            }
            /// <summary>
            /// 修改文件夹的名称 注意 不能新的文件夹名不能有同名的文件夹名称
            /// </summary>
            /// <param name="f">原文件夹</param>
            /// <param name="newnamewithpath">路径(f的所在目录) + 新的文件夹名称</param>
            /// <returns></returns>
            public static bool FSO_RenameFolder(string f, string newnamewithpath)
            {
                try
                {
                    System.IO.DirectoryInfo fi = new DirectoryInfo(f);
                    if (fi.Exists == true)
                    {
                        fi.MoveTo(newnamewithpath);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch { return false; }
            }
            /// <summary>
            /// 获取文件所属的复父系目录
            /// </summary>
            /// <param name="f">文件</param>
            /// <returns></returns>
            public static string FSO_GetFileFatherFolder(string f)
            {
                try
                {
                    FileInfo fi = new FileInfo(f);
                    if (fi.Exists == true)
                    {
                        string h = fi.DirectoryName;
                        return h;
                    }
                    else { return ""; }
                }
                catch { return ""; }
            }
            /// <summary>
            /// 获取文件的文件名 不要扩展名
            /// </summary>
            /// <param name="f"></param>
            /// <returns></returns>
            public static string FSO_GetFileNameWithoutExt(string f)
            {
                System.IO.FileInfo fi = new FileInfo(f);
                if (fi.Exists == true)
                {
                    string fwe = fi.Name;
                    string ext = fi.Extension;
                    if (ext != "")
                    {
                        int exl = fwe.LastIndexOf(".");
                        string n = fwe.Substring(0, exl);
                        return n;
                    }
                    else
                    {
                        return fwe;
                    }
                }
                else { return ""; }
            }
            /// <summary>
            /// 获取文件夹的名称
            /// </summary>
            /// <param name="f"></param>
            /// <returns></returns>
            public static string FSO_GetFolderName(string f)
            {
                System.IO.DirectoryInfo fi = new DirectoryInfo(f);
                if (fi.Exists == true)
                {
                    string j = fi.Name;
                    return j;
                }
                else { return ""; }
            }
            /// <summary>
            /// 删除文件夹
            /// </summary>
            /// <param name="FolderPath">文件夹路径</param>
            /// <param name="DeleteAllFilesAndFolders">是否删除该目录下的所有文件以及文件夹</param>
            /// <returns></returns>
            public static bool FileSystemOperate_DeleteFolder(string FolderPath, bool DeleteAllFilesAndFolders)
            {
                try
                {
                    string fol = FolderPath;
                    if (System.IO.Directory.Exists(fol) == false)
                    {
                        fol = SGFunction.PathOperate.ConvertStringToTurePath(fol, fol);
                    }
                    System.IO.Directory.Delete(fol, DeleteAllFilesAndFolders);
                    return true;
                }
                catch { return false; }
            }
            /// <summary>
            /// 判断文件是否存在
            /// </summary>
            /// <param name="FileName">文件</param>
            /// <returns></returns>
            public static bool FileSystemOperate_GetFileExists(string FileName)
            {
                FileName = SGFunction.PathOperate.IMPORTANT_PathUseful(FileName);
                if (FileName == "")
                {
                    return false;
                }
                else
                {
                    if (System.IO.File.Exists(FileName) == true)
                    {
                        return true;
                    }
                    else
                    {
                        if (System.IO.File.Exists(SGFunction.PathOperate.ConvertStringToTurePath(FileName, FileName)) == true)
                        {
                            return true;
                        }
                        else
                        {
                            //有可能是有引号
                            if (FileName.Length >= 5)
                            {
                                if (FileName.Substring(0, 1) == @"""" && FileName.Substring(FileName.Length - 1, 1) == @"""")
                                {
                                    //路径存在引号
                                    //去掉引号
                                    string nf = FileName.Substring(1, FileName.Length - 1); nf = nf.Substring(0, nf.Length - 1);
                                    return System.IO.File.Exists(nf);
                                }
                                else { return false; }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            /// <summary>
            /// 删除文件
            /// </summary>
            /// <param name="FileName">文件</param>
            /// <returns></returns>
            public static bool FileSystemOperate_DeleteFile(string FileName)
            {
                try
                {
                    if (System.IO.File.Exists(FileName) == true)
                    {
                        SGFunction.FileSystemOperate.FileSystemOperate_SetFileAttribute(FileName, FileAttributes.Normal);
                        System.IO.File.Delete(FileName);
                        return true;
                    }
                    else
                    {
                        if (System.IO.File.Exists(SGFunction.PathOperate.ConvertStringToTurePath(FileName, "")) == true)
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_SetFileAttribute(SGFunction.PathOperate.ConvertStringToTurePath(FileName, ""), FileAttributes.Normal);
                            System.IO.File.Delete(SGFunction.PathOperate.ConvertStringToTurePath(FileName, ""));
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
            /// <summary>
            /// 判断一个驱动器 文件夹是否可写
            /// </summary>
            /// <param name="Path">路径</param>
            /// <returns></returns>
            public static bool FileSystemOperate_FolderOrDriveCanWrites(string Path)
            {
                try
                {
                    bool p = SGFunction.DataOperate.SaveStringToTextFile(Path + @"\Temp.txt", "temp");
                    SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(Path + @"\Temp.txt");
                    return p;
                }
                catch { return false; }
            }
            /// <summary>
            /// 在资源管理器打开文件的位置
            /// </summary>
            /// <param name="FilePath">文件的位置</param>
            public static void FileSystemOperate_OpenFileLocationWithExplorer(string FilePath)
            {
                try
                {
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("explorer.exe", @"/e,/select,""" + FilePath + @"""", false, false, false, false);
                }
                catch { }
            }
            /// <summary>
            /// 获取一个目录下所有的目录以及文件
            /// </summary>
            /// <param name="OrgFolderPath">读取的目录</param>
            /// <param name="Filter">扩展名</param>
            /// <param name="GetType">读取的模式</param>
            /// <returns></returns>
            public static string[] FileSystemOperate_GetFilesAndFolders(string OrgFolderPath, string Filter, System.IO.SearchOption GetType)
            {
                try
                {
                    string[] files = System.IO.Directory.GetFiles(OrgFolderPath, Filter, GetType);
                    string[] folders = System.IO.Directory.GetDirectories(OrgFolderPath, Filter, GetType);
                    string[] result = new string[files.Length + folders.Length];
                    files.CopyTo(result, 0);
                    folders.CopyTo(result, files.Length);
                    return result;
                }
                catch { return null; }
            }
            /// <summary>
            /// 获取一个目录下的所有文件
            /// </summary>
            /// <param name="OrgFolderPath">目录</param>
            /// <param name="Filter">文件的扩展名 格式 [*.*]所有文件 [*.xxx]扩展名</param>
            /// <param name="GetType">搜索选项</param>
            /// <returns></returns>
            public static string[] FileSystemOperate_GetFiles(string OrgFolderPath, string Filter, System.IO.SearchOption GetType)
            {
                try
                {
                    string[] files = System.IO.Directory.GetFiles(OrgFolderPath, Filter, GetType);
                    return files;
                }
                catch { return null; }
            }
            /// <summary>
            /// 获取一个目录下的所有文件夹
            /// </summary>
            /// <param name="OrgFolderPath">目录</param>
            /// <param name="GetType">搜索模式</param>
            /// <param name="Filter">扩展名</param>
            /// <returns></returns>
            public static string[] FileSystemOperate_GetFolders(string OrgFolderPath, System.IO.SearchOption GetType, string Filter = "*.*")
            {
                string[] files = System.IO.Directory.GetDirectories(OrgFolderPath, Filter, GetType);
                return files;
            }
            /// <summary>
            /// 创建一个新的文件夹
            /// </summary>
            /// <param name="FolderPath">新的文件夹目录</param>
            /// <returns></returns>
            public static bool FileSystemOperate_CreateNewFolder(string FolderPath)
            {
                try
                {
                    if (System.IO.Directory.Exists(SGFunction.PathOperate.ConvertStringToTurePath(FolderPath, FolderPath)) != true)
                    {
                        System.IO.Directory.CreateDirectory(SGFunction.PathOperate.ConvertStringToTurePath(FolderPath, FolderPath));
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
            /// <summary>
            /// 设置文件访问属性
            /// </summary>
            /// <param name="FileName">文件名</param>
            /// <param name="FileAttributeType">文件属性</param>
            /// <returns></returns>
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
            /// <summary>
            /// 获取文件的权限(可访问被系统锁定 的文件)
            /// </summary>
            /// <param name="FileName">文件</param>
            public static void FileSystemOperate_GetAdminWithFile(string FileName)
            {
                try
                {
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(FileName) == true)
                    {
                        SGFunction.SystemFunctionAndInformation.ShellPrograms("takeown.exe", @"/f """ + FileName + @""" /a", true, false, true, true);
                        SGFunction.SystemFunctionAndInformation.ShellPrograms("icacls.exe", @"""" + FileName + @""" /grant:r everyone:f", true, false, true, false);
                    }
                }
                catch
                {
                }
            }
            /// <summary>
            /// 获取文件及的访问权限(可以访问被系统锁定的文件夹)
            /// </summary>
            /// <param name="FolderName"></param>
            public static void FileSystemOperate_GetAdminWithFolder(string FolderName)
            {
                try
                {
                    if (System.IO.Directory.Exists(FolderName) == true)
                    {
                        SGFunction.SystemFunctionAndInformation.ShellPrograms("takeown.exe", @"/f """ + FolderName + @""" /a /r /d y", true, false, true, false);
                        SGFunction.SystemFunctionAndInformation.ShellPrograms("icacls.exe", @"""" + FolderName + @""" /grant administrators:F /t", true, false, true, false);
                    }
                }
                catch
                {
                }
            }
            /// <summary>
            /// 改变资源文件中的资源
            /// </summary>
            /// <param name="ResourcesFile">新的资源文件</param>
            /// <param name="DLLOrEXEFile">要修改的资源文件</param>
            /// <param name="ResourcesType">资源的模式</param>
            /// <param name="ResourcesID">资源ID号</param>
            /// <param name="ResourcesLanguage">资源的语言ID</param>
            public static void FileSystemOperate_ChangeFileResources(string ResourcesFile, string DLLOrEXEFile, string ResourcesType, int ResourcesID, int ResourcesLanguage)
            {
                try
                {
                    //MessageBox.Show(@"/" + ResourcesFile + @" /" + DLLOrEXEFile + @" /" + ResourcesType + @" /" + ResourcesID.ToString() + @" /" + ResourcesLanguage.ToString());
                    SGFunction.SystemFunctionAndInformation.ShellPrograms(Application.StartupPath + @"\Programs\UpdateResources.exe", @"/""" + ResourcesFile + @""" /""" + DLLOrEXEFile + @""" /" + ResourcesType + @" /" + ResourcesID.ToString() + @" /" + ResourcesLanguage.ToString(), false, false, true, false);
                }
                catch
                {
                }
            }
            /// <summary>
            /// 获取知道那个目录下的所有文件以及文件夹的信息并加载到Treeview控件
            /// </summary>
            /// <param name="path">目录</param>
            /// <param name="imglist">Treeview所关联的ImageList</param>
            /// <param name="lv">Treeview控件</param>
            public static void FileSystemOperate_GetFilesAndFoldersToListView(string path, ImageList imglist, SGListView lv)
            {
                lv.Items.Clear();
                SHFILEINFO shfi = new SHFILEINFO();//实例化SHFILEINFO类
                try
                {
                    imglist.Images.Clear();
                    lv.Items.Clear();
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
                            //info[3] = dir.LastWriteTime.ToString();//获取更改时间
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
                            string size = SGFunction.DataOperate.ByteOperate(fi.Length);
                            info[1] = size;//获取文件的大小
                            info[2] = SGFunction.SystemFunctionAndInformation.GetFileTypeDescription(fi.Extension.ToString());//获取文件的类型
                            //info[3] = fi.LastWriteTime.ToString();//获取文件的更改时间
                            ListViewItem item = new ListViewItem(info, fi.Name);//实例化ListViewItem类
                            lv.Items.Add(item);//添加当前文件的基本信息
                            DestroyIcon(shfi.hIcon);//销毁图标
                        }
                    }
                }
                catch { }
            }
            /// <summary>
            /// 获取文件的扩展名 例如exe jpg
            /// </summary>
            /// <param name="FileName">文件</param>
            /// <returns></returns>
            public static string FileSystemOperate_GetFileExtraName(string FileName)
            {
                try
                {
                    FileInfo fi = new FileInfo(FileName);
                    if (fi.Exists == true)
                    {
                        string r = fi.Extension;
                        if (r != "") { r = r.Substring(1, r.Length - 1); }
                        return r;
                    }
                    else
                    {
                        string aLastName = FileName.Substring(FileName.LastIndexOf(".") + 1, (FileName.Length - FileName.LastIndexOf(".") - 1));   //扩展名
                        return aLastName;
                    }
                }
                catch
                {
                    return "";
                }
            }
            /// <summary>
            /// 判断文件夹是否存在
            /// </summary>
            /// <param name="FolderPath">目录</param>
            /// <param name="IfNotExistsFolderThenCreateNewFolder">如果未找到则创建它</param>
            /// <returns></returns>
            public static bool FileSystemOperate_GetFolderExists(string FolderPath, bool IfNotExistsFolderThenCreateNewFolder = false)
            {
                try
                {
                    if (FolderPath == "") { return false; }
                    string newfolder = SGFunction.PathOperate.ConvertStringToTurePath(FolderPath, FolderPath);
                    if (System.IO.Directory.Exists(newfolder) == true)
                    {
                        return true;
                    }
                    else
                    {
                        if (IfNotExistsFolderThenCreateNewFolder == true)
                        {
                            SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(newfolder);
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
            /// <summary>
            /// 获取文件的所在目录
            /// </summary>
            /// <param name="FilePath">文件</param>
            /// <returns></returns>
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
            public static bool FileSystemOperate_IsFile(string FileOrFolderPath)
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
            /// <summary>
            /// 复制文件
            /// </summary>
            /// <param name="OrgFile">源文件</param>
            /// <param name="NewFile">目标文件</param>
            /// <param name="cover">是否覆盖已有的文件</param>
            /// <returns></returns>
            public static bool FileSystemOperate_CopyFile(string OrgFile, string NewFile, bool cover = true)
            {
                try
                {
                    string nf, nn;
                    nf = OrgFile;
                    nn = SGFunction.PathOperate.ConvertStringToTurePath(NewFile, NewFile);
                    if (System.IO.File.Exists(nf) == false)
                    {
                        nf = SGFunction.PathOperate.ConvertStringToTurePath(nf, nf);
                    }
                    if (System.IO.File.Exists(nf) == false)
                    {
                        return false;
                    }
                    else
                    {
                        SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(nn);
                        System.IO.File.Copy(nf, nn, cover);
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 提供运行命令的操作
        /// </summary>
        public class RunCommand
        {
            /// <summary>
            /// 获取系统齿轮启动参数的详细信息
            /// </summary>
            /// <param name="args">启动参数</param>
            /// <param name="cmdtype">模式 [S]启动功能 [Y]一键设置 [?]帮助 [空]失败</param>
            /// <param name="reralargs"> 参数 当cmdtype为[S 参数为启动代号 例如MA,2,2,2] [Y 一键设置 参数为启动参数] [? 无]</param>
            public static void GetCommandArgsDetails(string[] args, out string cmdtype, out string[] reralargs)
            {
                string ctype = "";
                string[] cargs = null;
                try
                {
                    if (args != null)
                    {
                        if (args.Length > 0)
                        {
                            string flag = args[0].ToUpper(); //读取命令行标志 只有可能是/S /Y
                            if (flag.Length >= 3) { flag = flag.Substring(0, 3); flag = flag.Replace(@"/", "").Replace(@"\", "").Replace("-", "").Replace("=", ""); }
                            //MessageBox.Show(flag);
                            //判断参数的行数
                            switch (flag)
                            {
                                case "S":
                                    //S 该参数接受一个参数
                                    string read = args[0];
                                    string starttype = read.Substring(read.IndexOf("=") + 1, read.Length - read.IndexOf("=") - 1);
                                    //MessageBox.Show(starttype);
                                    if (starttype != "")
                                    {
                                        ctype = "S";
                                        cargs = new string[] { starttype };
                                    }
                                    break;
                                case "Y":
                                    //这个命令用于一键设置之类的或者关联了又右键菜单的操作 这个命令一般需要窗体隐藏
                                    ctype = "Y";
                                    cargs = args;
                                    break;
                                case "-?":
                                case "/?":
                                    ctype = "?";
                                    cargs = null;
                                    break;
                            }
                        }
                        else
                        {
                            //没有命令 进入默认界面
                            //m.sgItems1.Settings_ChooseItemsIndex = 1;
                        }

                    }
                    else
                    {
                        //没有命令 进入默认界面
                        //m.sgItems1.Settings_ChooseItemsIndex = 1;
                    }
                    cmdtype = ctype; reralargs = cargs;
                }
                catch { cmdtype = ctype; reralargs = cargs; }

            }
            /// <summary>
            /// 一键设置命令参数的选项
            /// </summary>
            /// <param name="type">一键设置参数的模式</param>
            /// <param name="args">参数</param>
            public static void ShellCommand_Y(string type, string[] args)
            {
                try
                {
                    switch (type.ToUpper())
                    {
                        case "LOCKSCREEN":
                            //该功能需 args有元素 2个
                            if (args.Length == 2)
                            {
                                string imgfile = args[1];
                                if (imgfile.Length > 6) { imgfile = imgfile.Substring(imgfile.IndexOf("=") + 1, imgfile.Length - imgfile.IndexOf("=") - 1); }
                                if (imgfile != "") { SGSystemStyle.SystemBoot.LockScreenImage.ApplyLockScreenImage_FromImageFile(imgfile, false, true); }
                            }
                            else { return; }
                            Application.ExitThread();
                            break;
                    }
                }
                catch { }
            }
            /// <summary>
            /// 启动REFEXON内部的URL
            /// </summary>
            /// <param name="type">[ITMI] 54ITMI.COM [UPDATE]更新系统齿轮程序 [MORESOFTWARE]更多程序 [REFEXON]REFEXON官网 [JOINUS]加入我们 [FEEDBACK]反馈</param>
            public static void ShellURL(string type)
            {
                string url = "http://refexon.com/soft/systemgear.htm";
                switch (type.ToUpper())
                {
                    case "UPDATE":
                        url = "http://refexon.com/soft/systemgear.htm";
                        SGFunction.SystemFunctionAndInformation.StartURL(url);
                        break;
                    case "MORESOFTWARE":
                        url = "http://refexon.com/soft/";
                        SGFunction.SystemFunctionAndInformation.StartURL(url);
                        break;
                    case "REFEXON":
                        url = "http://refexon.com";
                        SGFunction.SystemFunctionAndInformation.StartURL(url);
                        break;
                    case "JOINUS":
                        url = "http://refexon.com/join.htm";
                        SGFunction.SystemFunctionAndInformation.StartURL(url);
                        break;
                    case "ITMI":
                        url = "http://54itmi.com";
                        SGFunction.SystemFunctionAndInformation.StartURL(url);
                        break;
                    case "FEEDBACK":
                        //url = "http://refexon.com/soft/feedback.htm";
                        SGUserControl_Feedbackpage fd = new SGUserControl_Feedbackpage();
                        SGFunction.CommonDialogs.ShowSpecialAndGuideDialog("反馈与交流", fd);
                        break;
                }

            }
            /// <summary>
            /// 显示系统齿轮内部的功能 返回BOOL值 用于指示STYLE窗体是否显示了
            /// </summary>
            /// <param name="main">主窗体实例</param>
            /// <param name="style">系统外观设置 实例</param>
            /// <param name="code">代码 格式: [MA,1,1,1] [SY,1,1,1] [字符]用于显示"正在调试"</param>
            /// <param name="outsty"></param>
            public static bool ShellSGFunction(SGForm_Main main, SGForm_Function_SystemStyle style, object code, out SGForm_Function_SystemStyle outsty)
            {
                bool res = false;
                try
                {
                    //格式 SY,0,0,0 
                    //     MA,0,0,0
                    //如果检测到是其他的就显示正在开发
                    if (code != null)
                    {
                        string dd = (string)code;
                        string[] args = dd.Split(',');
                        int firsti = 1;
                        int seci = 1;
                        int thiri = 1;
                        if (args.Length == 4)
                        {
                            string h = args[0];
                            int.TryParse(args[1], out firsti); int.TryParse(args[2], out seci); int.TryParse(args[3], out thiri);
                            switch (h.ToUpper())
                            {
                                case "MA":
                                    if (main != null) { main.Start(firsti, seci, thiri); }
                                    break;
                                case "SY":
                                    if (style == null && main != null)
                                    {
                                        style = new SGForm_Function_SystemStyle(main, firsti, seci, thiri);
                                        style.Location = main.Location;
                                        res = true;
                                        style.Show();
                                    }
                                    else
                                    {
                                        style.Start(firsti, seci, thiri);
                                        style.Location = main.Location;
                                        res = true;
                                        style.Show();
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (code.ToString().ToUpper())
                            {
                                case "FEEDBACK":
                                    SGFunction.RunCommand.ShellURL("feedback");
                                    break;
                                case "PCLOCKER":
                                    SGFunction.RunCommand.ShellSGProgram("pclocker", false, false, false, "");
                                    break;
                                case "DESKTOPLABEL":
                                    SGFunction.RunCommand.ShellSGProgram("desktoplabel", false, false, false, "");
                                    break;
                                case "IESETTING":
                                case "BACKUP":
                                default:
                                    SGFunction.CommonDialogs.MessageDialog_ShowInfo(@"这个功能正在开发。您可以切换至""关于""选项卡并检查软件更新", 2);
                                    //SGFunction.RunCommand.ShellURL("update");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("命令无效。", 2);
                    }
                    outsty = style;
                    return res;
                }
                catch { outsty = style; return res; }
            }
            /// <summary>
            /// 运行系统齿轮内部程序 返回是否运行成功
            /// </summary>
            /// <param name="type">模式 [clipmgr]剪切板管理工具 [pclocker]挂机锁屏助手 [desktoplabel]桌面便利贴</param>
            /// <param name="hidden">是否隐藏</param>
            /// <param name="waitforexit">是否等待结束</param>
            /// <param name="runas">是否以管理员身份运行</param>
            /// <param name="arg">指定的参数</param>
            public static bool ShellSGProgram(string type, bool hidden = false, bool waitforexit = false, bool runas = true, string arg = "")
            {
                try
                {
                    bool res = false;
                    res = SGFunction.SystemFunctionAndInformation.ShellPrograms(GetSGProgramPath(type), arg, hidden, false, runas, waitforexit);
                    return res;
                }
                catch { return false; }
            }
            /// <summary>
            /// 获取系统齿轮组件的路径
            /// </summary>
            /// <param name="type">模式 [clipmgr]剪切板管理工具 [pclocker]挂机锁屏助手 [desktoplabel]桌面便利贴</param>
            /// <returns></returns>
            public static string GetSGProgramPath(string type)
            {
                try
                {
                    string path = "";
                    string clipmgr = Application.StartupPath + "\\sgclipmgr.exe";
                    string pclocker = Application.StartupPath + "\\PCLocker.exe";
                    string dklabel = Application.StartupPath + "\\DesktopLabelA.exe";
                    switch (type.ToLower())
                    {
                        case "clipmgr":
                            path = clipmgr;
                            break;
                        case "pclocker":
                            path = pclocker;
                            break;
                        case "desktoplabel":
                            path = dklabel;
                            break;
                    }
                    return path;
                }
                catch { return ""; }
            }
            /// <summary>
            /// 运行由系统齿轮指定的运行命令的格式
            /// </summary>
            /// <param name="str">字符 格式  App|Arg|Admin|Hidden|WaitForExit 注意:指定的ARG最后不要包含符号"|" </param>
            public static bool ShellCommand(string str)
            {
                if (str == "") { return false; }
                string[] aa = str.Split('|');
                if (aa.Length == 5)
                {
                    //正常情况下是5个元素
                    string app = aa[0];
                    string arg = aa[1];
                    string r_admin = aa[2];
                    string r_hidden = aa[3];
                    string r_wait = aa[4];
                    bool runas = true;
                    bool hidden = false;
                    bool wait = false;
                    bool.TryParse(r_admin, out runas);
                    bool.TryParse(r_hidden, out hidden);
                    bool.TryParse(r_wait, out wait);
                    app = SGFunction.PathOperate.ConvertStringToTurePath(app, app);
                    return SGFunction.SystemFunctionAndInformation.ShellPrograms(app, arg, hidden, false, runas, wait);
                }
                else
                {
                    //其他的错误
                    return false;
                }
            }
            /// <summary>
            /// 打开文本文件
            /// </summary>
            /// <param name="type">文件类型 [eula]打开EULA许可协议 [updateinfo] 更新信息[command]命令行选项</param>
            public static void ShellTextFile(string type)
            {
                try
                {
                    string txt = "";
                    switch (type.ToLower())
                    {
                        case "eula":
                            txt = Application.StartupPath + "\\系统齿轮用户使用许可协议.txt";
                            break;
                        case "updateinfo":
                            txt = Application.StartupPath + "\\系统齿轮更新日志.txt";
                            break;
                        case "command":
                            txt = Application.StartupPath + "\\系统齿轮命令行选项.txt";
                            break;
                    }
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(txt) == true)
                    {
                        SGFunction.SystemFunctionAndInformation.ShellFile(txt);
                    }
                }
                catch { }
            }
        }
        /// <summary>
        /// 提供对键盘的操作
        /// </summary>
        public class Keyboard
        {
            [DllImport("User32.dll")]
            public static extern void keybd_event(Byte bVk, Byte bScan, Int32 dwFlags, Int32 dwExtraInfo);
            /// <summary>
            /// 发送win键
            /// </summary>
            public static void SendStartKey()
            {
                keybd_event(0x5b, 0, 0, 0); //0x5b是left win的代码，这一句使key按下，下一句使key释放。
                keybd_event(0x5b, 0, 0x2, 0);
            }
        }
        /// <summary>
        /// 提供对系统齿轮内部资源的访问功能
        /// </summary>
        public class Resources
        {
            /// <summary>
            /// 返回内嵌在系统中的资源或者路径的图片
            /// </summary>
            /// <param name="codeorpath">路径胡资源代号[不要扩展名]</param>
            /// <returns></returns>
            public static Image GetImageFromResourcesCode(string codeorpath)
            {
                try
                {
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(codeorpath) == true)
                    {
                        //这是图片路径
                        Image r = Image.FromFile(codeorpath);
                        return r;
                    }
                    else
                    {
                        string im = SGFunction.PathOperate.ConvertStringToTurePath(codeorpath);
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(im) == true)
                        {
                            //path
                            Image r = Image.FromFile(im);
                            return r;
                        }
                        else
                        {
                            if (codeorpath != "")
                            {
                                if (codeorpath.ToLower() == "desktopwallpaper")
                                {
                                    return SGFunction.SystemFunctionAndInformation.GetWallpaper();
                                }
                                else
                                {
                                    //CODE
                                    Assembly myAssembly;
                                    myAssembly = System.Reflection.Assembly.Load(Assembly.GetExecutingAssembly().GetName().Name);
                                    System.Resources.ResourceManager myManager = new System.Resources.ResourceManager(Assembly.GetExecutingAssembly().GetName().Name + ".Properties.Resources", myAssembly);
                                    //myAssembly = System.Reflection.Assembly.Load("SystemGear2");
                                    //System.Resources.ResourceManager myManager = new System.Resources.ResourceManager("SystemGear2" + ".Properties.Resources", myAssembly);
                                    Image r = (Image)myManager.GetObject(codeorpath);
                                    return r;
                                }
                            }
                            else { return null; }
                        }
                    }
                }
                catch { return null; }
            }
            #region 更新资源API
            //加载资源的API
            [DllImport("kernel32", SetLastError = true)]
            static extern IntPtr LoadLibrary(string lpFileName);

            [DllImport("kernel32.dll", EntryPoint = "FindResourceW", CharSet = CharSet.Unicode, SetLastError = true)]
            static extern IntPtr FindResource(IntPtr hModule, string lpName, IntPtr lpType);

            [DllImport("Kernel32.dll", EntryPoint = "SizeofResource", SetLastError = true)]
            private static extern uint SizeofResource(IntPtr hModule, IntPtr hResource);

            [DllImport("Kernel32.dll", EntryPoint = "LoadResource", SetLastError = true)]
            private static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResource);

            //替换资源的API
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr BeginUpdateResource(string pFileName, [MarshalAs(UnmanagedType.Bool)]bool bDeleteExistingResources);

            [DllImport("kernel32.dll", EntryPoint = "UpdateResourceA", SetLastError = true)]
            static extern bool UpdateResource(IntPtr hUpdate, object lpType, string lpName, ushort wLanguage, IntPtr lpData, uint cbData);

            [DllImport("kernel32.dll", EntryPoint = "EndUpdateResourceA", SetLastError = true)]
            static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern IntPtr LockResource(IntPtr hResData);
            internal static int TestReplaceResource(string srcFilename, string destFilename)
            {


                //加载 文件 获取文件句柄
                IntPtr hExe = LoadLibrary(srcFilename);

                if (hExe.ToInt32() == 0)
                {
                    throw new ApplicationException("Cannot open " + srcFilename);
                }

                //通过文件句柄 在文件里边找资源
                IntPtr resH1 = FindResource(hExe, "#1", (IntPtr)RT_RCDATA);

                if (IntPtr.Zero == resH1)
                {
                    throw new System.ComponentModel.Win32Exception();
                }
                // IntPtr hMod = LoadLibraryEx(srcFilename, IntPtr.Zero, LOAD_LIBRARY_AS_DATAFILE);
                //将资源加载内存
                IntPtr resH2 = LoadResource(hExe, resH1);
                if (IntPtr.Zero == resH2)
                {
                    throw new System.ComponentModel.Win32Exception();
                }

                //锁定资源
                IntPtr resH3 = LockResource(resH2);

                if (IntPtr.Zero == resH3)
                {
                    throw new Exception("Lock failed");
                }

                //拷贝资源
                uint resSize = SizeofResource(hExe, resH1);

                byte[] y = new byte[resSize];

                Marshal.Copy(resH2, y, 0, (int)resSize);
                //这里的字节数组估计就是资源二进制数据了吧

                //接下来调用替换资源API

                //开始替换资源 获取句柄
                IntPtr hResource = BeginUpdateResource(srcFilename, false);
                if (hResource.ToInt32() == 0)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                //打开写入的文件
                //替换资源              这里是语言编号吧,中文记得是2052↓     ↓这里的句柄应该是资源句柄吧
                bool resu = UpdateResource(hResource, "WAVE", "5080", 1033, resH2, (uint)y.GetUpperBound(0));
                if (resu == false) //剩下的0不懂
                {//                                     ↑文件名不知道是什么,姑且对应一下上面的
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }


                //结束替换资源
                bool succes = EndUpdateResource(hResource, false);
                if (succes == false)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                return 0;
            }
            #endregion
            /// <summary>
            /// 更新Win32 的资源
            /// </summary>
            /// <param name="resfile">要更新的资源文件</param>
            /// <param name="dllexefile">被更新的Win32 文件</param>
            /// <param name="langid">语言ID [1033]</param>
            /// <param name="restype">资源类型 [Bitmap] [RCData]</param>
            /// <param name="resid">资源的内部ID [5088]</param>
            public static void UpdateResources(string resfile, string dllexefile, int langid, string restype, int resid)
            {
                try
                {
                    string arg = @"/""" + resfile + @""" /""" + dllexefile + @""" /" + restype + @" /" + resid.ToString() + @" /" + langid.ToString();
                    string app = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + "\\sgupres.exe";
                    // MessageBox.Show(app +" "+arg);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms(app, arg, true, false, true, true);
                }
                catch { }
            }
            /// <summary>
            /// 返回指定图标的路径
            /// </summary>
            /// <param name="type">主功能代号 [desktopiconsmgr]桌面图标 [fengefu]分隔符图标 [winlogo]Win图标 [search]搜索图标 [disc]光盘图标</param>
            /// <param name="code">分功能代号 [powerico]电源图标</param>
            /// <param name="tag">参数 powerico=[po,re,lc,lo]</param>
            /// <returns></returns>
            public static string GetIconPath(string type, string code = "", string tag = "")
            {
                string imgpath = "";
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\resourceslocation.sgcf";
                switch (type.ToLower())
                {
                    case "desktopiconsmgr":
                        switch (code.ToLower())
                        {
                            case "powerico":
                                switch (tag.ToLower())
                                {
                                    case "po":
                                        imgpath = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("desktopiconsmgr", "po", "%systemroot%\\system32\\imageres.dll,2", cfg, true);
                                        break;
                                    case "re":
                                        imgpath = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("desktopiconsmgr", "re", "%systemroot%\\system32\\imageres.dll,2", cfg, true);
                                        break;
                                    case "lc":
                                        imgpath = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("desktopiconsmgr", "lc", "%systemroot%\\system32\\imageres.dll,2", cfg, true);
                                        break;
                                    case "lo":
                                        imgpath = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("desktopiconsmgr", "lo", "%systemroot%\\system32\\imageres.dll,2", cfg, true);
                                        break;
                                }
                                break;
                        }
                        break;
                    case "fengefu":
                        imgpath = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("images") + "\\res\\001.ico";
                        break;
                    case "winlogo":
                        imgpath = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("images") + "\\res\\004.ico";
                        break;
                    case "search":
                        imgpath = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("images") + "\\res\\005.ico";
                        break;
                    case "disc":
                        imgpath = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("images") + "\\res\\006.ico";
                        break;
                }
                return imgpath;
            }
            /// <summary>
            /// 获取指定资源路径
            /// </summary>
            /// <param name="type">[runasadminvbs]以管理员身份运行脚本</param>
            /// <returns></returns>
            public static string GetResourcePath(string type)
            {
                string f = "";
                switch (type.ToLower())
                {
                    case "runasadminvbs":
                        f = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + "\\RunAsAdmin.vbs";
                        break;
                }
                return f;
            }
        }
        /// <summary>
        /// 获取程序的信息
        /// </summary>
        public class ProgramInfo
        {
            /// <summary>
            /// 获取开始菜单在WIN8 WIN7中的名称
            /// </summary>
            /// <returns></returns>
            public static string GetStartMenuName()
            {
                string name = @"开始屏幕";
                if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.1") { name = "开始菜单"; }
                return name;
            }
            /// <summary>
            /// 获取默认浏览器的名称
            /// </summary>
            /// <returns></returns>
            public static string GetDefaultBrowserName()
            {
                return "Internet Explorer";
            }
            /// <summary>
            /// 获取默认浏览器的可执行文件
            /// </summary>
            /// <returns></returns>
            public static string GetDefaultBrowserEXE()
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Internet Explorer\\iexplore.exe";
            }
            /// <summary>
            /// 获取PowerPoint路径
            /// </summary>
            /// <returns></returns>
            public static string GetPowerPointPath()
            {

                RegistryKey key = Registry.LocalMachine;

                RegistryKey key2 = key.OpenSubKey("SOFTWARE");

                RegistryKey key3 = key2.OpenSubKey("Microsoft");

                RegistryKey key4 = key3.OpenSubKey("Windows");

                RegistryKey key5 = key4.OpenSubKey("CurrentVersion");

                RegistryKey key6 = key5.OpenSubKey("App Paths");

                RegistryKey key7 = key6.OpenSubKey("Winword.exe");

                return key7.GetValue("Path").ToString() + "POWERPNT.EXE";

            }
            /// <summary>
            /// 获取EXCEL的路径
            /// </summary>
            /// <returns></returns>
            public static string GetExcelPath()
            {

                RegistryKey key = Registry.LocalMachine;

                RegistryKey key2 = key.OpenSubKey("SOFTWARE");

                RegistryKey key3 = key2.OpenSubKey("Microsoft");

                RegistryKey key4 = key3.OpenSubKey("Windows");

                RegistryKey key5 = key4.OpenSubKey("CurrentVersion");

                RegistryKey key6 = key5.OpenSubKey("App Paths");

                RegistryKey key7 = key6.OpenSubKey("Winword.exe");

                return key7.GetValue("Path").ToString() + "excel.EXE";

            }
            /// <summary>
            /// 获取Word安装位置
            /// </summary>
            /// <returns></returns>
            public static string GetWordPath()
            {

                RegistryKey key = Registry.LocalMachine;

                RegistryKey key2 = key.OpenSubKey("SOFTWARE");

                RegistryKey key3 = key2.OpenSubKey("Microsoft");

                RegistryKey key4 = key3.OpenSubKey("Windows");

                RegistryKey key5 = key4.OpenSubKey("CurrentVersion");

                RegistryKey key6 = key5.OpenSubKey("App Paths");

                RegistryKey key7 = key6.OpenSubKey("Winword.exe");

                return key7.GetValue("Path").ToString() + "WINWORD.EXE";

            }
            /// <summary>
            /// 获取Outlook安装位置
            /// </summary>
            /// <returns></returns>
            public static string GetOutlookPath()
            {

                RegistryKey key = Registry.LocalMachine;

                RegistryKey key2 = key.OpenSubKey("SOFTWARE");

                RegistryKey key3 = key2.OpenSubKey("Microsoft");

                RegistryKey key4 = key3.OpenSubKey("Windows");

                RegistryKey key5 = key4.OpenSubKey("CurrentVersion");

                RegistryKey key6 = key5.OpenSubKey("App Paths");

                RegistryKey key7 = key6.OpenSubKey("outlook.exe");

                return key7.GetValue("Path").ToString() + "outlook.EXE";

            }
            /// <summary>
            /// 获取资源管理器在不同系统中的名称
            /// </summary>
            /// <returns></returns>
            public static string GetExplorerName()
            {
                string r = "资源管理器";
                switch (SGFunction.SystemFunctionAndInformation.GetOSVersion())
                {
                    case "6.2":
                    case "10.0":
                    case "6.4":
                    case "6.3":
                        r = "文件资源管理器";
                        break;
                }
                return r;
            }
            /// <summary>
            /// 获取计算机在不同系统中的名称
            /// </summary>
            /// <returns></returns>
            public static string GetMyComputerName()
            {

                string r = "计算机";
                /*
                switch(SGFunction.SystemFunctionAndInformation.GetOSVersion())
                {
                    case "10.0":
                    case "6.4":
                    case "6.3":
                        r = "这台电脑";
                        break;
                }
                 */
                r = SGFunction.CLSIDAndHanderOperate.CLSIDOperate_GetGUIDRegistryName("{20D04FE0-3AEA-1069-A2D8-08002B30309D}");
                return r;
            }
            /// <summary>
            /// 获取QQ安装位置
            /// </summary>
            /// <returns></returns>
            public static string GetQQInstallPath()
            {
                string r = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\tencent\\qq";
                string loca = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Products\97BFC25026D93E24A851ED662C9CC7E3\InstallProperties";
                string path = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, loca, "installlocation", r);
                return path;
            }
            /// <summary>
            /// 获取迅雷安装位置
            /// </summary>
            /// <returns></returns>
            public static string GetThunderInstallPath()
            {
                string r = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Thunder Network\\thunder";
                string loc_x86 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                string loc_x64 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
                string path = r;
                if (SGFunction.SystemFunctionAndInformation.GetOSBit() == "32")
                {
                    string keyn = "";
                    SGFunction.RegistryOperate.RegistryOperate_FindValueInAllSubKeys(Registry.LocalMachine, loc_x86, "DisplayName", "迅雷", out keyn, false);
                    if (keyn != "") { path = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, loc_x86 + "\\" + keyn, "InstallLocation", r); }
                }
                else
                {
                    string keyn = "";
                    SGFunction.RegistryOperate.RegistryOperate_FindValueInAllSubKeys(Registry.LocalMachine, loc_x64, "DisplayName", "迅雷", out keyn, false);
                    if (keyn != "") { path = SGFunction.RegistryOperate.RegistryOperate_ValueOperate("get", Registry.LocalMachine, loc_x64 + "\\" + keyn, "InstallLocation", r); }
                }
                try
                {
                    if (path.Length > 3)
                    {
                        path = path.Substring(0, path.LastIndexOf('\\'));
                        return path;
                    }
                    else { return path; }
                }
                catch { return path; }
            }
        }
        /// <summary>
        /// 脚本选项
        /// </summary>
        public class ScriptOperate
        {
            /// <summary>
            /// 创建RunAsAdmin脚本
            /// </summary>
            public static void CreateRunAsAdminVBS() //创建RunAsAdmin.vbs
            {
                try
                {
                    string f = SGFunction.Resources.GetResourcePath("runasadminvbs");
                    string TXT = Properties.Resources.RunAsAdmin;
                    System.IO.File.Delete(f);
                    StreamWriter sw = new StreamWriter(f, true, Encoding.Unicode);
                    sw.Write(TXT); sw.Flush(); sw.Close();
                }
                catch
                {
                }
            }
        }
        // <summary>
        /// ICON 控制类
        /// zgke@Sina.com
        /// </summary>
        public class IconDir
        {
            /*
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    IconDir T = new IconDir(openFileDialog1.FileName);
                    T.GetImage(0); //获取一个ICO图形
                    int Temp =T.ImageCount; //ICO数量
                    T.DelImage(0);   //删除
                    T.SaveData(@"C:/1.ico"); //保存成文件
                }


                //添加一个ICO AddImage参数Rectangle 宽高不能超过255
                IconDir MyIcon = new IconDir();
                Image TempImage =Image.FromFile(@"c:/bfx/T5.BMP");
                MyIcon.AddImage(TempImage,new Rectangle(0,0,32,32));
                MyIcon.SaveData(@"C:/1.ico");

             */
            private ushort _IdReserved = 0;
            private ushort _IdType = 1;
            private ushort _IdCount = 1;
            private IList<IconDirentry> _Identries = new List<IconDirentry>();

            public IconDir()
            {

            }
            public IconDir(string IconFile)
            {
                System.IO.FileStream _FileStream = new System.IO.FileStream(IconFile, System.IO.FileMode.Open);
                byte[] IconData = new byte[_FileStream.Length];
                _FileStream.Read(IconData, 0, IconData.Length);
                _FileStream.Close();

                LoadData(IconData);
            }

            /// <summary>
            /// 读取ICO
            /// </summary>
            /// <param name="IconData"></param>
            private void LoadData(byte[] IconData)
            {
                _IdReserved = BitConverter.ToUInt16(IconData, 0);
                _IdType = BitConverter.ToUInt16(IconData, 2);
                _IdCount = BitConverter.ToUInt16(IconData, 4);
                if (_IdType != 1 || _IdReserved != 0) return;
                int ReadIndex = 6;
                for (ushort i = 0; i != _IdCount; i++)
                {
                    _Identries.Add(new IconDirentry(IconData, ref ReadIndex));
                }


            }
            /// <summary>
            /// 保存ICO
            /// </summary>
            /// <param name="FileName"></param>
            public void SaveData(string FileName)
            {
                if (ImageCount == 0) return;
                System.IO.FileStream _FileStream = new System.IO.FileStream(FileName, System.IO.FileMode.Create);

                byte[] Temp = BitConverter.GetBytes(_IdReserved);
                _FileStream.Write(Temp, 0, Temp.Length);

                Temp = BitConverter.GetBytes(_IdType);
                _FileStream.Write(Temp, 0, Temp.Length);

                Temp = BitConverter.GetBytes((ushort)ImageCount);
                _FileStream.Write(Temp, 0, Temp.Length);

                for (int i = 0; i != ImageCount; i++)
                {
                    _FileStream.WriteByte(_Identries[i].Width);
                    _FileStream.WriteByte(_Identries[i].Height);
                    _FileStream.WriteByte(_Identries[i].ColorCount);
                    _FileStream.WriteByte(_Identries[i].Breserved);
                    Temp = BitConverter.GetBytes(_Identries[i].Planes);
                    _FileStream.Write(Temp, 0, Temp.Length);
                    Temp = BitConverter.GetBytes(_Identries[i].Bitcount);
                    _FileStream.Write(Temp, 0, Temp.Length);
                    Temp = BitConverter.GetBytes(_Identries[i].ImageSize);
                    _FileStream.Write(Temp, 0, Temp.Length);
                    Temp = BitConverter.GetBytes(_Identries[i].ImageRVA);
                    _FileStream.Write(Temp, 0, Temp.Length);

                }

                for (int i = 0; i != ImageCount; i++)
                {
                    _FileStream.Write(_Identries[i].ImageData, 0, _Identries[i].ImageData.Length);

                }
                _FileStream.Close();
            }

            /// <summary>
            /// 根据索引返回图形
            /// </summary>
            /// <param name="Index"></param>
            /// <returns></returns>
            public Bitmap GetImage(int Index)
            {
                int ReadIndex = 0;
                BitmapInfo MyBitmap = new BitmapInfo(_Identries[Index].ImageData, ref ReadIndex);
                return MyBitmap.IconBmp;
            }

            public void AddImage(Image SetBitmap, Rectangle SetRectangle)
            {

                if (SetRectangle.Width > 255 || SetRectangle.Height > 255) return;



                Bitmap IconBitmap = new Bitmap(SetRectangle.Width, SetRectangle.Height);
                Graphics g = Graphics.FromImage(IconBitmap);
                g.DrawImage(SetBitmap, new Rectangle(0, 0, IconBitmap.Width, IconBitmap.Height), SetRectangle, GraphicsUnit.Pixel);
                g.Dispose();

                System.IO.MemoryStream BmpMemory = new System.IO.MemoryStream();
                IconBitmap.Save(BmpMemory, System.Drawing.Imaging.ImageFormat.Bmp);


                IconDirentry NewIconDirentry = new IconDirentry();

                BmpMemory.Position = 14;        //只使用13位后的数字 40开头
                NewIconDirentry.ImageData = new byte[BmpMemory.Length - 14 + 128];
                BmpMemory.Read(NewIconDirentry.ImageData, 0, NewIconDirentry.ImageData.Length);


                NewIconDirentry.Width = (byte)SetRectangle.Width;
                NewIconDirentry.Height = (byte)SetRectangle.Height;

                //BMP图形和ICO的高不一样  ICO的高是BMP的2倍
                byte[] Height = BitConverter.GetBytes((uint)NewIconDirentry.Height * 2);

                NewIconDirentry.ImageData[8] = Height[0];
                NewIconDirentry.ImageData[9] = Height[1];
                NewIconDirentry.ImageData[10] = Height[2];
                NewIconDirentry.ImageData[11] = Height[3];



                NewIconDirentry.ImageSize = (uint)NewIconDirentry.ImageData.Length;
                _Identries.Add(NewIconDirentry);

                uint RvaIndex = 6 + (uint)(_Identries.Count * 16);
                for (int i = 0; i != _Identries.Count; i++)
                {
                    _Identries[i].ImageRVA = RvaIndex;
                    RvaIndex += _Identries[i].ImageSize;
                }
            }

            public void DelImage(int Index)
            {

                _Identries.RemoveAt(Index);
                uint RvaIndex = 6 + (uint)(_Identries.Count * 16);
                for (int i = 0; i != _Identries.Count; i++)
                {
                    _Identries[i].ImageRVA = RvaIndex;
                    RvaIndex += _Identries[i].ImageSize;
                }
            }


            /// <summary>
            /// 返回图形数量
            /// </summary>
            public int ImageCount { get { return _Identries.Count; } }


            private class IconDirentry
            {
                public IconDirentry()
                {

                }
                public IconDirentry(byte[] IconDate, ref int ReadIndex)
                {
                    bWidth = IconDate[ReadIndex];
                    ReadIndex++;
                    bHeight = IconDate[ReadIndex];
                    ReadIndex++;
                    bColorCount = IconDate[ReadIndex];
                    ReadIndex++;
                    breserved = IconDate[ReadIndex];
                    ReadIndex++;
                    wplanes = BitConverter.ToUInt16(IconDate, ReadIndex);
                    ReadIndex += 2;
                    wbitcount = BitConverter.ToUInt16(IconDate, ReadIndex);
                    ReadIndex += 2;

                    dwbytesinres = BitConverter.ToUInt32(IconDate, ReadIndex);
                    ReadIndex += 4;
                    dwimageoffset = BitConverter.ToUInt32(IconDate, ReadIndex);
                    ReadIndex += 4;

                    System.IO.MemoryStream MemoryData = new System.IO.MemoryStream(IconDate, (int)dwimageoffset, (int)dwbytesinres);
                    _ImageData = new byte[dwbytesinres];
                    MemoryData.Read(_ImageData, 0, _ImageData.Length);

                }
                private byte bWidth = 16;
                private byte bHeight = 16;
                private byte bColorCount = 0;
                private byte breserved = 0;        //4
                private ushort wplanes = 1;
                private ushort wbitcount = 32;      //8
                private uint dwbytesinres = 0;
                private uint dwimageoffset = 0;         //16
                private byte[] _ImageData;

                /// <summary>
                /// 图像宽度，以象素为单位。一个字节
                /// </summary>
                public byte Width { get { return bWidth; } set { bWidth = value; } }
                /// <summary>
                /// 图像高度，以象素为单位。一个字节
                /// </summary>
                public byte Height { get { return bHeight; } set { bHeight = value; } }
                /// <summary>
                /// 图像中的颜色数（如果是>=8bpp的位图则为0）
                /// </summary>
                public byte ColorCount { get { return bColorCount; } set { bColorCount = value; } }
                /// <summary>
                /// 保留字必须是0
                /// </summary>
                public byte Breserved { get { return breserved; } set { breserved = value; } }
                /// <summary>
                /// 为目标设备说明位面数，其值将总是被设为1
                /// </summary>
                public ushort Planes { get { return wplanes; } set { wplanes = value; } }
                /// <summary>
                /// 每象素所占位数。
                /// </summary>
                public ushort Bitcount { get { return wbitcount; } set { wbitcount = value; } }
                /// <summary>
                /// 字节大小。
                /// </summary>
                public uint ImageSize { get { return dwbytesinres; } set { dwbytesinres = value; } }
                /// <summary>
                /// 起点偏移位置。
                /// </summary>
                public uint ImageRVA { get { return dwimageoffset; } set { dwimageoffset = value; } }
                /// <summary>
                /// 图形数据
                /// </summary>
                public byte[] ImageData { get { return _ImageData; } set { _ImageData = value; } }

            }

            private class BitmapInfo
            {
                private uint biSize = 40;
                private uint biWidth;
                private uint biHeight;
                private ushort biPlanes = 1;
                private ushort biBitCount;
                private uint biCompression = 0;
                private uint biSizeImage;
                private uint biXPelsPerMeter;
                private uint biYPelsPerMeter;
                private uint biClrUsed;
                private uint biClrImportant;

                public IList<Color> ColorTable = new List<Color>();

                /// <summary>
                /// 占4位，位图信息头(Bitmap Info Header)的长度,一般为$28
                /// </summary>
                public uint InfoSize { get { return biSize; } set { biSize = value; } }
                /// <summary>
                /// 占4位，位图的宽度，以象素为单位
                /// </summary>
                public uint Width { get { return biWidth; } set { biWidth = value; } }
                /// <summary>
                /// 占4位，位图的高度，以象素为单位
                /// </summary>
                public uint Height { get { return biHeight; } set { biHeight = value; } }
                /// <summary>
                /// 占2位，位图的位面数（注：该值将总是1）
                /// </summary>
                public ushort Planes { get { return biPlanes; } set { biPlanes = value; } }
                /// <summary>
                /// 占2位，每个象素的位数，设为32(32Bit位图)
                /// </summary>
                public ushort BitCount { get { return biBitCount; } set { biBitCount = value; } }
                /// <summary>
                /// 占4位，压缩说明，设为0(不压缩)
                /// </summary>
                public uint Compression { get { return biCompression; } set { biCompression = value; } }
                /// <summary>
                /// 占4位，用字节数表示的位图数据的大小。该数必须是4的倍数
                /// </summary>
                public uint SizeImage { get { return biSizeImage; } set { biSizeImage = value; } }
                /// <summary>
                ///  占4位，用象素/米表示的水平分辨率
                /// </summary>
                public uint XPelsPerMeter { get { return biXPelsPerMeter; } set { biXPelsPerMeter = value; } }
                /// <summary>
                /// 占4位，用象素/米表示的垂直分辨率
                /// </summary>
                public uint YPelsPerMeter { get { return biYPelsPerMeter; } set { biYPelsPerMeter = value; } }
                /// <summary>
                /// 占4位，位图使用的颜色数
                /// </summary>
                public uint ClrUsed { get { return biClrUsed; } set { biClrUsed = value; } }
                /// <summary>
                /// 占4位，指定重要的颜色数(到此处刚好40个字节，$28)
                /// </summary>
                public uint ClrImportant { get { return biClrImportant; } set { biClrImportant = value; } }

                private Bitmap _IconBitMap;
                /// <summary>
                /// 图形
                /// </summary>
                public Bitmap IconBmp { get { return _IconBitMap; } set { _IconBitMap = value; } }

                public BitmapInfo(byte[] ImageData, ref int ReadIndex)
                {
                    #region 基本数据
                    biSize = BitConverter.ToUInt32(ImageData, ReadIndex);
                    if (biSize != 40) return;
                    ReadIndex += 4;
                    biWidth = BitConverter.ToUInt32(ImageData, ReadIndex);
                    ReadIndex += 4;
                    biHeight = BitConverter.ToUInt32(ImageData, ReadIndex);
                    ReadIndex += 4;
                    biPlanes = BitConverter.ToUInt16(ImageData, ReadIndex);
                    ReadIndex += 2;
                    biBitCount = BitConverter.ToUInt16(ImageData, ReadIndex);
                    ReadIndex += 2;
                    biCompression = BitConverter.ToUInt32(ImageData, ReadIndex);
                    ReadIndex += 4;
                    biSizeImage = BitConverter.ToUInt32(ImageData, ReadIndex);
                    ReadIndex += 4;
                    biXPelsPerMeter = BitConverter.ToUInt32(ImageData, ReadIndex);
                    ReadIndex += 4;
                    biYPelsPerMeter = BitConverter.ToUInt32(ImageData, ReadIndex);
                    ReadIndex += 4;
                    biClrUsed = BitConverter.ToUInt32(ImageData, ReadIndex);
                    ReadIndex += 4;
                    biClrImportant = BitConverter.ToUInt32(ImageData, ReadIndex);
                    ReadIndex += 4;
                    #endregion

                    int ColorCount = RgbCount();
                    if (ColorCount == -1) return;
                    for (int i = 0; i != ColorCount; i++)
                    {
                        byte Blue = ImageData[ReadIndex];
                        byte Green = ImageData[ReadIndex + 1];
                        byte Red = ImageData[ReadIndex + 2];
                        byte Reserved = ImageData[ReadIndex + 3];

                        ColorTable.Add(Color.FromArgb((int)Reserved, (int)Red, (int)Green, (int)Blue));

                        ReadIndex += 4;
                    }

                    int Size = (int)(biBitCount * biWidth) / 8;       // 象素的大小*象素数 /字节数
                    if ((double)Size < biBitCount * biWidth / 8) Size++;       //如果是 宽19*4（16色）/8 =9.5 就+1;
                    if (Size < 4) Size = 4;

                    byte[] WidthByte = new byte[Size];

                    _IconBitMap = new Bitmap((int)biWidth, (int)(biHeight / 2));
                    for (int i = (int)(biHeight / 2); i != 0; i--)
                    {
                        for (int z = 0; z != Size; z++)
                        {
                            WidthByte[z] = ImageData[ReadIndex + z];
                        }
                        ReadIndex += Size;

                        IconSet(_IconBitMap, i - 1, WidthByte);
                    }


                    //取掩码
                    int MaskSize = (int)(biWidth / 8);
                    if ((double)MaskSize < biWidth / 8) MaskSize++;       //如果是 宽19*4（16色）/8 =9.5 就+1;
                    if (MaskSize < 4) MaskSize = 4;
                    byte[] MashByte = new byte[MaskSize];
                    for (int i = (int)(biHeight / 2); i != 0; i--)
                    {
                        for (int z = 0; z != MaskSize; z++)
                        {
                            MashByte[z] = ImageData[ReadIndex + z];
                        }
                        ReadIndex += MaskSize;
                        IconMask(_IconBitMap, i - 1, MashByte);
                    }

                }

                private int RgbCount()
                {
                    switch (biBitCount)
                    {
                        case 1:
                            return 2;
                        case 4:
                            return 16;
                        case 8:
                            return 256;
                        case 24:
                            return 0;
                        case 32:
                            return 0;
                        default:
                            return -1;
                    }
                }

                private void IconSet(Bitmap IconImage, int RowIndex, byte[] ImageByte)
                {
                    int Index = 0;

                    switch (biBitCount)
                    {
                        case 1:
                            #region 一次读8位 绘制8个点
                            for (int i = 0; i != ImageByte.Length; i++)
                            {
                                System.Collections.BitArray MyArray = new System.Collections.BitArray(new byte[] { ImageByte[i] });

                                if (Index >= IconImage.Width) return;
                                IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[7])]);
                                Index++;

                                if (Index >= IconImage.Width) return;
                                IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[6])]);
                                Index++;

                                if (Index >= IconImage.Width) return;
                                IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[5])]);
                                Index++;

                                if (Index >= IconImage.Width) return;
                                IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[4])]);
                                Index++;

                                if (Index >= IconImage.Width) return;
                                IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[3])]);
                                Index++;

                                if (Index >= IconImage.Width) return;
                                IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[2])]);
                                Index++;

                                if (Index >= IconImage.Width) return;
                                IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[1])]);
                                Index++;

                                if (Index >= IconImage.Width) return;
                                IconImage.SetPixel(Index, RowIndex, ColorTable[GetBitNumb(MyArray[0])]);
                                Index++;
                            }
                            #endregion
                            break;
                        case 4:
                            #region 一次读8位 绘制2个点
                            for (int i = 0; i != ImageByte.Length; i++)
                            {
                                int High = ImageByte[i] >> 4;  //取高4位
                                int Low = ImageByte[i] - (High << 4); //取低4位
                                if (Index >= IconImage.Width) return;
                                IconImage.SetPixel(Index, RowIndex, ColorTable[High]);
                                Index++;

                                if (Index >= IconImage.Width) return;
                                IconImage.SetPixel(Index, RowIndex, ColorTable[Low]);
                                Index++;
                            }
                            #endregion
                            break;
                        case 8:
                            #region 一次读8位 绘制一个点
                            for (int i = 0; i != ImageByte.Length; i++)
                            {
                                if (Index >= IconImage.Width) return;
                                IconImage.SetPixel(Index, RowIndex, ColorTable[ImageByte[i]]);
                                Index++;
                            }
                            #endregion
                            break;
                        case 24:
                            #region 一次读24位 绘制一个点

                            for (int i = 0; i != ImageByte.Length / 3; i++)
                            {
                                if (i >= IconImage.Width) return;

                                IconImage.SetPixel(i, RowIndex, Color.FromArgb(ImageByte[Index + 2], ImageByte[Index + 1], ImageByte[Index]));
                                Index += 3;
                            }
                            #endregion
                            break;
                        case 32:
                            #region 一次读32位 绘制一个点

                            for (int i = 0; i != ImageByte.Length / 4; i++)
                            {
                                if (i >= IconImage.Width) return;

                                IconImage.SetPixel(i, RowIndex, Color.FromArgb(ImageByte[Index + 2], ImageByte[Index + 1], ImageByte[Index]));
                                Index += 4;
                            }
                            #endregion
                            break;
                        default:
                            break;

                    }
                }

                private void IconMask(Bitmap IconImage, int RowIndex, byte[] MaskByte)
                {

                    System.Collections.BitArray Set = new System.Collections.BitArray(MaskByte);
                    int ReadIndex = 0;
                    for (int i = Set.Count; i != 0; i--)
                    {
                        if (ReadIndex >= IconImage.Width) return;
                        Color SetColor = IconImage.GetPixel(ReadIndex, RowIndex);
                        if (!Set[i - 1]) IconImage.SetPixel(ReadIndex, RowIndex, Color.FromArgb(255, SetColor.R, SetColor.G, SetColor.B));
                        ReadIndex++;

                    }

                }

                private int GetBitNumb(bool BitArray)
                {
                    if (BitArray) return 1;
                    return 0;
                }

            }
        }
    }

}
