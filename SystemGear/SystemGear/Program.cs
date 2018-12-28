using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SystemGear
{
    
    static class Program
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]

        private static extern int SendMessage(

        int hWnd,  //  handle  to  destination  window  

        int Msg,  //  message  

        int wParam,  //  first  message  parameter  

        ref  COPYDATASTRUCT lParam  //  second  message  parameter  

        );

        [DllImport("User32.dll", EntryPoint = "FindWindow")]

        private static extern int FindWindow(string lpClassName, string

        lpWindowName);
        public struct COPYDATASTRUCT
        {

            public IntPtr dwData;

            public int cbData;

            [MarshalAs(UnmanagedType.LPStr)]

            public string lpData;

        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SystemGear.窗体.SGForm_Main frm=new SystemGear.窗体.SGForm_Main(args);
            
           // bool res=CheckThread(args);
           // if (res == true) { Application.ExitThread(); frm.SHOULDBECLOSED = true; }
            
            Application.Run(frm);
            
        }
        private static bool CheckThread(string[] arrs)
        {
            //获取欲启动进程名
            string strProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            ////获取版本号 
            //CommonData.VersionNumber = Application.ProductVersion; 
            //检查进程是否已经启动，已经启动则显示报错信息退出程序。 
            bool res = false;
            if (System.Diagnostics.Process.GetProcessesByName(strProcessName).Length > 1)
            {
                //已经启动了
                 if(arrs !=null)
                 {
                     if (arrs.Length > 0)
                     {
                         string ct;
                         string[] args;
                         SGFunction.RunCommand.GetCommandArgsDetails(arrs, out ct, out args);
                         if (ct.ToUpper() == "?" || ct.ToUpper() == "S")
                         {
                             //有参数
                             SendMessegeToTarget(arrs);
                             res = true;
                         }

                     }
                 }
                 
            }
            return res;
        }
        private static void SendMessegeToTarget(string[] arrs)
        {
            //MessageBox.Show("");
            //需要将arrs重新转换为string
            string ars = "";
            for(int y=arrs.Length;y<=arrs.Length;y++)
            {
                if (y == 1) { ars = arrs[0]; } else { ars = ars + " " + arrs[y - 1]; }
            }
            int TARGET_WINDOWS_HANLER = 0;
            int WINDOW_HANDLER_MAIN = FindWindow(null, "系统齿轮 "+SGFunction.ApplicationSetting.GetSGProgramVersion("MMAIN"));

            if (WINDOW_HANDLER_MAIN == 0)
            {
                int WINDOW_HANDLER_SYSTEMSTYLE = FindWindow(null, "系统齿轮 系统外观");
                if (WINDOW_HANDLER_SYSTEMSTYLE != 0) { TARGET_WINDOWS_HANLER = WINDOW_HANDLER_SYSTEMSTYLE; }
            }
            else
            {
                TARGET_WINDOWS_HANLER =WINDOW_HANDLER_MAIN ;
            }
            //SEND
            if(TARGET_WINDOWS_HANLER !=0)
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(ars);

                int len = sarr.Length;



                COPYDATASTRUCT cds;

                cds.dwData = (IntPtr)100;

                cds.lpData = ars;

                cds.cbData = len + 1;

                SendMessage(TARGET_WINDOWS_HANLER, 0x004A, 0, ref  cds);
            }
        }

    }
}
