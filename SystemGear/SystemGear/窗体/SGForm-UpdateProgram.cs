using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace SystemGear.窗体
{
    public partial class SGForm_UpdateProgram : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        /// <summary>
        /// 更新的模式 ISNEW 当前最新 IMPORT 重大更新  FIX 问题修复
        /// </summary>
        string updatetype = "ISNEW";
        string downloadlink = "";
        string downloadlink_yundisk = "";
        string infocfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("TEMP") + "\\UpdateInfo.sgcf";
        public SGForm_UpdateProgram()
        {
            InitializeComponent();
            DrawSkin();
        }
        
        HttpWebRequest httpReq;
        HttpWebResponse httpResp;

        string strBuff = "";
        char[] cbuffer = new char[256];
        int byteRead = 0;
        ///定义写入流操作 
        public bool DownloadUpdateInfo(string cfgfile)
        {
            Uri httpURL = new Uri("http://refexon.com/soft/UpdateInfo.sgcf");

            try
            {
                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(cfgfile);
                ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换 
                httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
                ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换

                httpResp = (HttpWebResponse)httpReq.GetResponse();
                ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容

                ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理 
                Stream respStream = httpResp.GetResponseStream();

                ///返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以

                //StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：gb2312） 
                StreamReader respStreamReader = new StreamReader(respStream, Encoding.GetEncoding("gb2312"));

                byteRead = respStreamReader.Read(cbuffer, 0, 256);
                while (byteRead != 0)
                {
                    string strResp = new string(cbuffer, 0, byteRead);
                    strBuff = strBuff + strResp;
                    byteRead = respStreamReader.Read(cbuffer, 0, 256);
                }
                string[] lines = strBuff.Split('\n');
                respStream.Close();
                string ss = "";
                for (int j = 1; j <= lines.Length; j++)
                {
                    ss = ss + "\r\n" + lines[j - 1];
                }
                
                SGFunction.DataOperate.SaveStringToTextFile(cfgfile, ss);
                return SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfgfile);
            }
            catch { return false; }
        }
        public void ReadUpdateInfo()
        {
            string version = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("main", "version", SGFunction.ApplicationSetting.GetSGProgramVersion("full"), infocfg, false);
            string edit = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("main", "edition", SGFunction.ApplicationSetting.GetSGProgramVersion("edit"), infocfg, false);
            string filesize = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("main", "filesize", "未知", infocfg, false);
            string download = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("main", "download", "", infocfg, false);
            string download_yun = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("main", "download_yun", "", infocfg, false);
            string[] keys; string[] whatsnew; int newcount = SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("WHATNEW", out keys, out whatsnew, infocfg, true);
            string detail_txt="";
            for(int y=1;y<=whatsnew.Length;y++)
            {
                if(y==1)
                {
                    detail_txt ="1."+whatsnew [y-1];
                }
                else { detail_txt = detail_txt + "\r\n" + y.ToString() + "." + whatsnew[y - 1]; }
            }
            //版本的判断
            string[] version_args = version.Split('.');
            if(version_args.Length ==4)
            {
                panel_updateinfo.Visible = true;
                sgLabel_isnewandotherinfo.Visible = false;
                //OK 获取当前的版本后
                string current_version = SGFunction.ApplicationSetting.GetSGProgramVersion("full"); string current_edition = SGFunction.ApplicationSetting.GetSGProgramVersion("edit"); string[] current_args = current_version.Split('.');
                sgLabel_versionandedition.Text = current_version + " " + current_edition;
                //分解版本号
                int new_1 = 0; int new_2 = 0; int new_3 = 0; int new_4 = 0; int.TryParse(version_args[0], out new_1); int.TryParse(version_args[1], out new_2); int.TryParse(version_args[2], out new_3); int.TryParse(version_args[3], out new_4);
                int current_1 = 0; int current_2 = 0; int current_3 = 0; int current_4 = 0; int.TryParse(current_args[0], out current_1); int.TryParse(current_args[1], out current_2); int.TryParse(current_args[2], out current_3); int.TryParse(current_args[3], out current_4);
                if(new_1>current_1)
                {
                    //重大更新 不用管后面的啦
                    updatetype = "IMPORT";
                    sgLabel_newvesionedition.Text = version + " " + edit;
                    sgLabel_detail.Text = detail_txt;
                    sgLabel_filesize.Text = filesize;
                    sgLabel_push.Text = "此次更新意义非凡，强烈推荐您更新。";
                }
                else
                {
                    //主版本号 一致 看看次版本号
                    if(new_2 >current_2 )
                    {
                        //压实重大更新 不管后面的啦
                        updatetype = "IMPORT";
                        sgLabel_newvesionedition.Text = version + " " + edit;
                        sgLabel_detail.Text = detail_txt;
                        sgLabel_filesize.Text = filesize;
                        sgLabel_push.Text = "此次更新意义非凡，强烈推荐您更新。";
                    }
                    else
                    {
                        //后面都是小更新啦
                        if(new_3 >current_3 )
                        {
                            //FIX
                            updatetype = "FIX";
                            sgLabel_newvesionedition.Text = version + " " + edit;
                            sgLabel_detail.Text = detail_txt;
                            sgLabel_filesize.Text = filesize;
                            sgLabel_push.Text = "多数问题修复、界面调整，期待您的下载。";
                        }
                        else
                        {
                            if(new_4 >current_4 )
                            {
                                updatetype = "FIX";
                                //fix
                                sgLabel_newvesionedition.Text = version + " " + edit;
                                sgLabel_detail.Text = detail_txt;
                                sgLabel_filesize.Text = filesize;
                                sgLabel_push.Text = "问题修复，期待您的下载。";
                            }
                            else
                            {
                                updatetype = "ISNEW";
                                //完全一样 已是最新
                                sgLabel_isnewandotherinfo.Text = "恭喜，你的系统齿轮版本已是最新。尽情享用系统齿轮的众多功能吧。"+"\n"+"\n"+"当前版本的特性："+"\n"+"\n"+detail_txt ;
                                panel_updateinfo.Visible = false;
                                sgLabel_isnewandotherinfo.Visible = true;
                                sgLabel_versionandedition.Text = SGFunction.ApplicationSetting.GetSGProgramVersion("pmain");
                            }
                        }
                    }
                }
                //处理连接
                downloadlink = download;
                downloadlink_yundisk = download_yun;
                if (downloadlink_yundisk == "") { myNormalButton_downloadfromyun.Visible = false; } else { myNormalButton_downloadfromyun.Visible = true; }
            }
            else
            {
                //无效的版本 直接退出
                sgLabel_isnewandotherinfo.Text = @"抱歉，我们在处理配置文件时候发生了一些问题，请您稍后重试。您也可以尝试点击下面的""手动检查""按钮";
                myNormalButton_feedback.Visible = myNormalButton_startuppdatelink.Visible = true;
                panel_updateinfo.Visible = false;
                sgLabel_isnewandotherinfo.Visible = true;
                sgLabel_versionandedition.Text = SGFunction.ApplicationSetting.GetSGProgramVersion("pmain");
            }
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SGForm_UpdateProgram_Shown(object sender, EventArgs e)
        {
            sgLabel_badnetwork.Visible = false;
            bool result = DownloadUpdateInfo(this.infocfg);
            if (result == true)
            {
                panel2.Visible = true;
                ReadUpdateInfo();
            }
            else
            {
                //panel2.Visible = false;
                sgLabel_badnetwork.Visible = true;
                //this.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_standard", "bk");
                this.panel_updateinfo.Visible = false;
                // sgLabel_versionandedition.Visible = pictureBox_currentversion.Visible = sgLabel_versionandedition.Visible = sgLabel1.Visible = false;
                sgLabel_badnetwork.Visible = false;
                sgLabel_isnewandotherinfo.Visible = true;
                sgLabel_isnewandotherinfo.Text = @"抱歉，我们无法为您连接到更新服务器，请您稍后再试。或者您也可以尝试点击下面的""手动检查""按钮";
                sgLabel_versionandedition.Text = SGFunction.ApplicationSetting.GetSGProgramVersion("pmain");
                myNormalButton_feedback.Visible = myNormalButton_startuppdatelink.Visible = true;
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void myNormalButton_downloadfromyun_Click(object sender, EventArgs e)
        {
            if (downloadlink_yundisk == "")
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("当前的新版本系统齿轮安装包不提供从云网盘下载的链接，抱歉。", 2);
            }
            else { SGFunction.SystemFunctionAndInformation.StartURL(downloadlink_yundisk); }
        }

        private void MyNormalButton_download_Click(object sender, EventArgs e)
        {
            if (downloadlink == "")
            {
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("当前的新版本系统齿轮安装包不提供下载的链接，抱歉。", 2);
            }
            else { SGFunction.SystemFunctionAndInformation.StartURL(downloadlink); }
        }
        public void DrawSkin()
        {
            Color dialog_stand_bd = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_standard", "bd");
            Color dialog_stand_bk = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_standard", "bk");
            Color dialog_stand_title_bk = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "TITLE_BK");
            Color dialog_stand_title_fr = SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "title_fr");
            Color o_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "bk");
            Color o_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "fr");
            Color lab_ma_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_maininfo", "fr");
            Color lab_fu_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_funinfo", "fr");
            Color dialog_setting_lightcolor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "light");
            //DIALOG
            panel1.BackColor = dialog_stand_title_bk;
            label_title.ForeColor = dialog_stand_title_fr;
            this.BackColor = dialog_stand_bd;
            panel2.BackColor = panel_updateinfo.BackColor = panel4.BackColor = dialog_stand_bk;
            panel4.BackColor = dialog_setting_lightcolor;
            //FUNLABEL
            sgLabel1.ForeColor = sgLabel4.ForeColor = sgLabel6.ForeColor = sgLabel7.ForeColor = lab_fu_fr;
            sgLabel_badnetwork.ForeColor = lab_fu_fr;
            //MAIN LABEL
            sgLabel_isnewandotherinfo.ForeColor = lab_ma_fr;
            sgLabel_detail.ForeColor = sgLabel_filesize.ForeColor = sgLabel_newvesionedition.ForeColor = sgLabel_push.ForeColor = sgLabel_versionandedition.ForeColor = lab_ma_fr;
            //BTN
            MyNormalButton_download.BackColor = myNormalButton_downloadfromyun.BackColor =myNormalButton_startuppdatelink.BackColor =myNormalButton_feedback.BackColor = o_bk;
            myNormalButton_downloadfromyun.ForeColor = MyNormalButton_download.ForeColor =myNormalButton_feedback.ForeColor =myNormalButton_startuppdatelink.ForeColor = o_fr;
        }

        private void SGForm_UpdateProgram_SizeChanged(object sender, EventArgs e)
        {
            MyNormalButton1.Location = new Point (this.panel1.Size.Width - MyNormalButton1.Size.Width,0);
        }

        private void myNormalButton2_Click(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellURL("update");
        }

        private void myNormalButton_feedback_Click(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellURL("feedback");
        }

        private void SGForm_UpdateProgram_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }
    }
}
