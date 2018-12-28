using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear
{
    public partial class Form_FunctionExplorer : Form
    {
        public string[] ret = new string[5];
        public string[] ret_fun = new string[3];
        public Form_FunctionExplorer()
        {
            InitializeComponent();
            this.tabControl1.Location = new Point(-7, 22);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form_FunctionExplorer_Load(object sender, EventArgs e)
        {
            switch (this.Tag.ToString().ToUpper())
            {
                case "OPE":
                    this.Size = new System.Drawing.Size(690, 392);
                    label1.Text = "常用的操作";
                    this.tabControl1.SelectedIndex = 0;
                    this.Text = label1.Text;
                     treeView1.Nodes[0].Expand();
            treeView1.Nodes[1].Expand();
            treeView1.Nodes[2].Expand();
            treeView1.Nodes[3].Expand();
            treeView1.Nodes[4].Expand();
            treeView1.Nodes[5].Expand();
                    //shezhi ico
                    treeView1.Nodes[3].Nodes[1].Tag = @"%windir%\System32\shutdown.exe@"+MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.IconResources,"restart",false)+"$-r -t 0 -f";
                    treeView1.Nodes[3].Nodes[2].Tag = @"%windir%\System32\rundll32.exe@" + MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.IconResources, "lockcomputer", false) + "$user32.dll,LockWorkStation";
                    treeView1.Nodes[3].Nodes[3].Tag = @"%windir%\System32\shutdown.exe@" + MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.IconResources, "logoff", false) + "$-l";
                    treeView1.Nodes[0].Nodes[0].Tag = @"""" + Application.ExecutablePath + @"""@" + Application.ExecutablePath + ",0$";
                    break;
                case "FUN":
                    label1.Text = "浏览功能";
                    this.Size = new System.Drawing.Size(690, 366);
                    this.tabControl1.SelectedIndex = 1;
                    this.Text = label1.Text;
                     treeView2.Nodes[0].Expand();
            treeView2.Nodes[1].Expand();
                    break;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            /*
            if (treeView1.SelectedNode != null)
            {
                string name, icon, cmd;
                if (treeView1.SelectedNode.Text != "系统齿轮相关" && treeView1.SelectedNode.Text != "文件相关" && treeView1.SelectedNode.Text != "网络相关" && treeView1.SelectedNode.Text != "电源相关" && treeView1.SelectedNode.Text != "系统相关" && treeView1.SelectedNode.Text != "资源管理器")
                {
                    if (treeView1.SelectedNode.Tag != null)
                    {
                        if (treeView1.SelectedNode.Tag.ToString() != "N")
                        {
                            textBox2.Text = treeView1.SelectedNode.Text;
                            name = treeView1.SelectedNode.Text;
                            cmd = treeView1.SelectedNode.Tag.ToString().Substring(0, treeView1.SelectedNode.Tag.ToString().IndexOf("@"));
                            icon = treeView1.SelectedNode.Tag.ToString().Substring(treeView1.SelectedNode.Tag.ToString().IndexOf("@"), treeView1.SelectedNode.Tag.ToString().Length - cmd.Length).Replace("@", "");
                            cmd = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(cmd, cmd);
                            icon = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(icon, icon);
                            textBox3.Text = cmd;
                            textBox1.Text = icon.Substring(0,icon.LastIndexOf("$"));
                            textBox_args.Text = icon.Substring(icon.LastIndexOf("$"), icon.Length - icon.LastIndexOf("$")).Replace("$","");
                            switch (treeView1.SelectedNode.Text)
                            {
                                case "命令提示符(管理员)":
                                    checkBox1.Checked = true;
                                    break;
                                case "PowerShell(管理员)":
                                    checkBox1.Checked = true;
                                    break;
                                default:
                                    checkBox1.Checked = false;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (treeView1.SelectedNode.Text)
                        {
                            case"执行程序":
                                string j=MyFunctions.Dialogs.OpenFileDialog("打开文件", "可执行程序(*.exe)|*.exe");
                                if (System.IO.File.Exists(j) == true)
                                {
                                    textBox2.Text = "执行程序";
                                    textBox3.Text = @""""+j+@"""";
                                    textBox1.Text = j + @",0";
                                    textBox_args.Text = "";
                                }
                                break;
                            case "打开文件":
                                string j1 = MyFunctions.Dialogs.OpenFileDialog("打开文件", "所有文件(*.*)|*.*");
                                if (System.IO.File.Exists(j1) == true)
                                {
                                    textBox2.Text = "打开文件";
                                    textBox3.Text =@""""+ j1+@"""";
                                    textBox_args.Text = "";
                                    textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,2";
                                }
                                break;
                            case "执行批处理":
                                string j2 = MyFunctions.Dialogs.OpenFileDialog("打开文件", "批处理文件(*.cmd;*.bat)|*.cmd;*.bat");
                                if (System.IO.File.Exists(j2) == true)
                                {
                                    textBox2.Text = treeView1.SelectedNode.Text;
                                    textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\CMD.EXE";
                                    textBox_args.Text =@"/k """+j2 +@"""";
                                    textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,63";
                                }
                                break;
                            case "执行CMD命令":
                                string j3 = MyFunctions.Dialogs.InputDialog("输入命令", "输入可被命令提示符所执行的命令", false, "", "", "", "");
                                    if (j3 != "")
                                    {
                                        textBox2.Text = treeView1.SelectedNode.Text;
                                        textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\CMD.EXE";
                                        textBox_args.Text = "/c "+j3;
                                        textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,63";
                                    }
                                break;
                            case "执行脚本文件":
                                 string j4 = MyFunctions.Dialogs.OpenFileDialog("打开文件", "脚本文件(*.js;*.vbs)|*.js;*.vbs|所有文件(*.*)|*.*");
                                if (System.IO.File.Exists(j4) == true)
                                {
                                    textBox2.Text = treeView1.SelectedNode.Text;
                                    textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.EXE";
                                    textBox_args.Text = @"""" + j4 + @"""";
                                    textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.exe,2";
                                }
                                break;
                            case @"使用""记事本""打开":
                                string j5 = MyFunctions.Dialogs.OpenFileDialog("打开文件", "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*");
                                if (System.IO.File.Exists(j5) == true)
                                {
                                    textBox2.Text = "打开文档";
                                    textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\notepad.EXE";
                                    textBox_args.Text = @"""" + j5 + @"""";
                                    textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,14";
                                }
                                break;
                            case @"使用""写字板""打开":
                                string j6 = MyFunctions.Dialogs.OpenFileDialog("打开文件", "支持的文件(*.docx;*.odt;*.rtf;*.txt)|*.docx;*.odt;*.rtf;*.txt|所有文件(*.*)|*.*");
                                if (System.IO.File.Exists(j6) == true)
                                {
                                    textBox2.Text = "打开文档";
                                    textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Windows NT\Accessories\wordpad.exe";
                                    textBox_args.Text = @"""" + j6 + @"""";
                                    textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,85";
                                }
                                break;
                            case @"使用""Microsoft Word""打开(需安装)":
                                string j7 = MyFunctions.Dialogs.OpenFileDialog("打开文件", "支持的文件(*.docx;*.odt;*.rtf;*.txt)|*.docx;*.odt;*.rtf;*.txt|所有文件(*.*)|*.*");
                                if (System.IO.File.Exists(j7) == true)
                                {
                                    textBox2.Text = "打开文档";
                                    textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd.EXE";
                                    textBox_args.Text = @"/c winword """+j7+@"""";
                                    textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,85";
                                }
                                break;
                            case @"使用""画图""打开":
                                string j8 = MyFunctions.Dialogs.OpenFileDialog("打开文件", "支持的文件(*.bmp;*.jpg;*.gif;*.png;*.ico)|*.bmp;*.jpg;*.gif;*.png;*.ico|所有文件(*.*)|*.*");
                                if (System.IO.File.Exists(j8) == true)
                                {
                                    textBox2.Text = "打开图像文件" ;
                                    textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\mspaint.EXE";
                                    textBox_args.Text = @"""" + j8 + @"""";
                                    textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,65";
                                }
                                break;
                            case @"使用""Windows 照片查看器""打开":
                                string j9 = MyFunctions.Dialogs.OpenFileDialog("打开文件", "支持的文件(*.bmp;*.jpg;*.gif;*.png;*.ico)|*.bmp;*.jpg;*.gif;*.png;*.ico|所有文件(*.*)|*.*");
                                if (System.IO.File.Exists(j9) == true)
                                {
                                    textBox2.Text = "打开图像文件";
                                    textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\rundll32.EXE";
                                    textBox_args.Text = @"""%ProgramFiles%\Windows Photo Viewer\PhotoViewer.dll"", ImageView_Fullscreen " + j9;
                                    textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,65";
                                }
                                break;
                            case "使用默认的浏览器打开网页":
                                string j10 = MyFunctions.Dialogs.InputDialog("输入网页的地址", "输入网页的地址,例如 : www.54itmi.com", false, "", "", "http://", "输入一个网址");
                                if (j10 != "")
                                {
                                    textBox2.Text = "打开网页";
                                    textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\wscript.EXE";
                                    textBox_args.Text = @""""+Application.StartupPath +@"\Programs\StartURL.VBS"" """+j10 +@"""";
                                    textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\ieframe.dll,22";
                                }
                                break;
                            case "仅使用Internet Explorer 打开网页":
                                string j11 = MyFunctions.Dialogs.InputDialog("输入网页的地址", "输入网页的地址,例如 : www.54itmi.com", false, "", "", "http://", "输入一个网址");
                                if (j11 != "")
                                {
                                    textBox2.Text = "打开网页";
                                    textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Internet Explorer\iexplore.exe";
                                    textBox_args.Text = j11;
                                    textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\ieframe.dll,22";
                                }
                                break;
                            case "关闭计算机":
                                textBox2.Text = "关闭计算机";
                                string cmd1 = "-s -f -t 0";
                                string res = MyFunctions.Dialogs.MessageDialog("是否启用快速启动技术?", "检测到您的操作系统高于Windows 7.可以使用快速启动技术", MyFunctions.Dialogs.MessageDialogIcon.Question , "启用快速启动技术可以提高系统冷启动速度,但会延长系统关机的时间", "b1", true, true, "是", "否");
                                if (res == "B1")
                                {
                                    cmd1="-s -hybrid -t 0 -f";
                                }
                                textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\shutdown.exe";
                                textBox_args.Text = cmd1;
                                textBox1.Text = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.IconResources, "poweroff", false);
                                break;
                            case "打开GUID":
                                string j13 = MyFunctions.Dialogs.InputDialog("输入GUID", "例如 : {922971AB-5597-4B1D-A085-0B8AD6651709}", false, "", "", "", "");
                                if (j13 != "")
                                {
                                    textBox2.Text = "打开GUID";
                                    textBox3.Text = Environment.GetEnvironmentVariable("windir") + @"\explorer.exe";
                                    textBox_args.Text = "/e,::" + j13;
                                    textBox1.Text = Environment.GetEnvironmentVariable("WINDIR") + @"\Explorer.exe,0";
                                }
                                break;
                            case "打开文件夹":
                                string j14 = MyFunctions.Dialogs.OpenFolder("选择一个文件夹");
                                if (j14 != "")
                                {
                                    textBox2.Text = "打开文件夹";
                                    textBox3.Text = Environment.GetEnvimentVariable("windir") + @"\explorer.exe";
                                    textBox_args.Text = j14;
                                    textBox1.Text = Environment.GetEnvironmentVariable("WINDIR") + @"\Explorer.exe,3";
                                }
                                break;
                        } 
                    }
                }
            }
             */
            string tag = treeView1.SelectedNode.Tag.ToString();
            //MessageBox.Show(tag);
            string app = tag.Substring(0, tag.IndexOf("@"));
            string ico = tag.Substring(tag.IndexOf("@") + 1, tag.IndexOf("$") - tag.IndexOf("@") - 1);
            string arg = tag.Substring(tag.IndexOf("$")+1, tag.Length - tag.IndexOf("$") - 1);
            string regname = textBox9.Text;
            string ty = textBox8.Text;
            string name = "NO," + treeView1.SelectedNode.Text;
            //MessageBox.Show(app + "\r\n" + ico + "\r\n" + arg);
            string writ=name+"|"+app+"|"+ico+"|"+arg;
           // MessageBox.Show(writ);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(ty, regname, writ, "config", false, @"F:\系统齿轮\SystemGear\SystemGear\bin\Debug\2.5.0.1004\Config\SystemTools.sgcf");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                label3.Visible = label4.Visible = label6.Visible = false;
                ret[0] = textBox2.Text;
                ret[1] = textBox3.Text;
                ret[2] = textBox1.Text;
                ret[3] = textBox_args.Text;
                if (checkBox1.Checked == true)
                {
                    ret[4] = "T";
                }
                else
                {
                    ret[4] = "F";
                }
                this.Close();
            }
            else
            {
                if (textBox2.Text == "") { label3.Visible = true; } else { label3.Visible = false; }
                if (textBox3.Text == "") { label4.Visible = true; } else { label4.Visible = false; }
                if (textBox1.Text == "") { label6.Visible = true; } else { label6.Visible = false; }
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (treeView2.SelectedNode.Tag.ToString().ToUpper() == "N")
                {
                    textBox4.Text = textBox5.Text = textBox6.Text = "";
                }
                else
                {
                    string name, ico, cmd;
                    name = treeView2.SelectedNode.Text;
                    cmd = treeView2.SelectedNode.Tag.ToString().Substring(0, treeView2.SelectedNode.Tag.ToString().IndexOf("@"));
                    ico = "内置资源\\" + treeView2.SelectedNode.Tag.ToString().Substring(treeView2.SelectedNode.Tag.ToString().IndexOf("@"), treeView2.SelectedNode.Tag.ToString().Length - cmd.Length).Replace("@", "");
                    textBox6.Text = name;
                    textBox5.Text = cmd;
                    textBox4.Text = ico;
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox5.Text != "")
            {
                label10.Visible = label11.Visible = false;
                ret_fun[0] = textBox6.Text;
                ret_fun[1] = textBox5.Text;
                ret_fun[2] = textBox4.Text;
                this.Close();
            }
            else
            {
                if (textBox6.Text == "") { label10.Visible = true; } else { label10.Visible = false; }
                if (textBox5.Text == "") { label11.Visible = true; } else { label11.Visible = false; }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string appinfo = @"F:\系统齿轮\SystemGear\SystemGear\bin\Debug\2.5.0.1004\Config\WinAppInfo.sgcf";
            string conf = @"F:\系统齿轮\SystemGear\SystemGear\bin\Debug\2.5.0.1004\Config\SystemTools.sgcf";
            string c = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("WinAppInfo", "COUNT", "", appinfo, false);
            int cou;
            int.TryParse(c, out cou);
            for(int u=1;u<=cou;u++)
            {
                string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("winappinfo", u.ToString(), "", appinfo, false);
                string[] p=read.Split('|');
                string app = @"%windir%\explorer.exe";
                string arg = @"shell:::{4234d49b-0245-4df3-b780-3893943456e1}\"+p[0];
                string name = p[1];
                string ico = p[2];
                string writ = "NO,"+name + "|" + app + "|" + ico + "|" + arg;
                //MessageBox.Show(writ);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("winappinfo", name, writ, "config", false, conf);
            }
        }
    }
}
