using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Threading;
using System.IO;

namespace SystemGear
{
    public partial class SGForm_CommonDialogs : Form
    {
        [DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        #region 选择ICON图标的Var和API
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);
        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        private static extern int ExtractIconEx(string lpszFile, int niconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, int nIcons);
        private IntPtr[] largeIcons, smallIcons;  //存放大/小图标的指针数组  
        Thread th_loadicon;
        ParameterizedThreadStart p;
        private object file_sg = @"G:\系统齿轮\SystemGear\SystemGear\bin\Debug\SystemGear.exe";
        private bool FinishLoad =true;
        private object  file_sysicon = "%systemroot%\\system32\\imageres.dll";
        private object  file_sysshell32 = "%systemroot%\\system32\\shell32.dll";
        private object file_ie = "%systemroot%\\system32\\ieframe.dll";
        private object file_selectimg;
        private int file_selectindex = 0;
        #endregion
        #region 选择ICON的方法
        private void LoadIcon(object file)
        {
            string resfile = file.ToString();
            resfile = SGFunction.PathOperate.ConvertStringToTurePath(resfile, resfile);
            sgTextBox2.Text = resfile;
            file_selectimg = resfile;
            //加载图标到列表
            if (System.IO.File.Exists(resfile ) == true)
            {
                //label3.Visible = false;
                int IconCount = ExtractIconEx(resfile, -1, null, null, 0);
                largeIcons = new IntPtr[IconCount];
                smallIcons = new IntPtr[IconCount];
                ExtractIconEx(resfile, 0, largeIcons, smallIcons, IconCount);
                for (int i = 0; i < IconCount; i++)
                {
                    this.imageList1.Images.Add(Icon.FromHandle(largeIcons[i])); //图标添加进imageList中  
                    DestroyIcon(largeIcons[i]);
                    DestroyIcon(smallIcons[i]);
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = i;  //listview子项图标索引项  
                    this.sgListView1.Items.Add(lvi);
                }
                FinishLoad = true;
            }
            else
            {
                FinishLoad = true;
            }
        }
        #endregion
        private string title,type;
        private string[] tags;
        private string alloweempty;
        public string ButtonClick="exit";
        public string[] Returns;
        private Size inputbox_size = new Size(487, 168);
        private Size selecticon_size = new Size(430,385);
        private Size choosemodern_size = new Size(519,286);
        private Size chooseclsid_size = new Size(519, 280);
        private Size choosedisk_size = new Size(599,297);
        private Size currentdialogsize;
        //DISK CHOOSE VAR
        public string disk_type = "ALL";
        public string[] return_disk_info = new string[5];
        /// <summary>
        /// 系统齿轮通用窗体
        /// </summary>
        /// <param name="type">模式 [input] [modern] [diskchoose] [clsid] [icon]</param>
        /// <param name="title">标题</param>
        /// <param name="tags">参数</param>
        public SGForm_CommonDialogs(string type,string title,string[] tags)
        {
            InitializeComponent();
            SGFunction.Skins.DrawAllControlInTabControl(sgTabPageControl1);
            this.BackColor =panel1.BackColor =MyNormalButton5.BackColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
            this.title = title;
            this.type = type;
            this.tags = tags;
            this.Text = this.label_title.Text = title;
            this.sgTabPageControl1.Location = new Point(2,0);
            switch (type.ToLower())
            {
                case "input":
                    sgTabPageControl1.SelectedIndex = 0;
                    sgTabPageControl1.Size =currentdialogsize = inputbox_size;
                    sgLabel1.Text = tags[0];
                    alloweempty = tags[2];
                    sgTextBox1.TextBoxInfoTip = tags[3];
                    sgTextBox1.Text = tags[1];
                    break;
                case "modern":
                    sgTabPageControl1.SelectedIndex = 2;
                    sgTabPageControl1.Size =currentdialogsize = choosemodern_size;
                    this.LoadModernProgram();
                    break;
                case "diskchoose":
                    sgTabPageControl1.SelectedIndex = 4;
                    sgTabPageControl1.Size = currentdialogsize = choosedisk_size;
                    this.LoadDisk();
                    break;
                case "clsid":
                    sgTabPageControl1.SelectedIndex = 3;
                    sgTabPageControl1.Size =currentdialogsize = chooseclsid_size;
                    this.LoadCLSID();
                    break;
                case "icon":
                    int inde;
                    string icol = SGFunction.ImageAndIconOperate.GetStrToImageLocationAndIndex(tags[0], out inde);
                    file_selectindex = inde;
                    this.sgTabPageControl1.Size =currentdialogsize = selecticon_size;
                    sgListView1.Items.Clear();
                    imageList1.Images.Clear();
                    sgTabPageControl1.SelectedIndex = 1;
                    file_sg = icol;
                    sgRadioButton1.Checked = true;
                    break;
            }
        }
        private void LoadDisk()
        {
            disk_type = tags[0];
            switch (disk_type)
            {
                case "FIXED":
                    LoadFixedDisk();
                    break;
                case "CDROM":
                    LoadCDROM();
                    break;
                default:
                    LoadFixedDisk();
                    LoadCDROM();
                    break;
            }
        }
        #region DISK CHOOSE FUNCTION
        public void LoadFixedDisk()
        {
            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (DriveInfo driver in drivers)
            {
                string name = driver.Name.Substring(0, driver.Name.IndexOf(":") + 1);
                if (driver.DriveType == DriveType.Fixed)
                {
                    Image img = SGFunction.ImageAndIconOperate.GetFolderOrDiskIcon(name).ToBitmap();
                    imageList1.Images.Add(img);
                    listView1.Items.Add(name).ImageIndex = imageList1.Images.Count - 1;
                    if (driver.IsReady == true)
                    {
                        string dr = driver.VolumeLabel;
                        if (dr == "") { dr = "本地磁盘(" + name + ")"; }
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("固定的磁盘");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add((driver.TotalSize / 1024 / 1024 / 1024).ToString() + " GB");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add((driver.TotalFreeSpace / 1024 / 1024 / 1024).ToString() + " GB");
                    }
                    else
                    {
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("本地磁盘(不可用)");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("固定的磁盘(不可用)");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("不可用");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("不可用");
                    }
                }
            }
        }
        public void LoadCDROM()
        {
            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (DriveInfo driver in drivers)
            {
                string name = driver.Name.Substring(0, driver.Name.IndexOf(":") + 1);
                if (driver.DriveType == DriveType.CDRom)
                {
                    Image img = SGFunction.ImageAndIconOperate.GetFolderOrDiskIcon(name).ToBitmap();
                    imageList1.Images.Add(img);
                    listView1.Items.Add(name).ImageIndex = imageList1.Images.Count - 1;
                    if (driver.IsReady == true)
                    {
                        string dr = driver.VolumeLabel;
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("CD或DVD驱动器");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add((driver.TotalSize / 1024 / 1024 / 1024).ToString() + " GB");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add((driver.TotalFreeSpace / 1024 / 1024 / 1024).ToString() + " GB");
                    }
                    else
                    {
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("CD或DVD驱动器(不可用)");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("不可用");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("不可用");
                    }
                }
            }
        }
        #endregion
        private void MyNormalButton4_Click(object sender, EventArgs e)
        {
            if(sgTextBox1.Text =="")
            {
                if (alloweempty == "True")
                {
                    //sgLabel2.Visible = false;
                    this.ButtonClick = "ok";
                    this.Returns = new string[] { sgTextBox1.Text };
                    this.Close();
                }
                else
                {
                    //sgLabel2.Visible = true;
                    sgTextBox1.DoError("不能为空哦。");
                }
            }
            else
            {
                //sgLabel2.Visible = false;
                this.ButtonClick = "ok";
                this.Returns = new string[] { sgTextBox1.Text };
                this.Close();
            }
        }

        private void MyNormalButton5_Click(object sender, EventArgs e)
        {
            this.ButtonClick = "exit";
            this.Returns = new string[] { sgTextBox1.Text };
            this.Close();
        }

        private void SGForm_CommonDialogs_SizeChanged(object sender, EventArgs e)
        {
           // Size p = currentdialogsize;
            this.Size = new Size(sgTabPageControl1.Width + 2+sgTabPageControl1.Location.X ,sgTabPageControl1.Location.Y +sgTabPageControl1.Size.Height+2);
            this.panel1.Size = new Size(this.Size.Width, panel1.Size.Height);
            MyNormalButton5.Location =new Point(panel1.Size.Width -MyNormalButton5.Size.Width,0);
        }

        private void SGForm_CommonDialogs_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                switch(type.ToLower())
                {
                    case "icon":
                        th_loadicon.Abort();
                        break;
                }
            }
            catch { }
        }

        private void SGForm_CommonDialogs_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }

        private void sgRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if(IsLoading ==false)
            //{
                if (FinishLoad == true)
                {
                    if(sgRadioButton1.Checked ==true)
                    {
                        FinishLoad = false;
                        sgListView1.Items.Clear();
                        imageList1.Images.Clear();
                        LoadIcon(file_sg);
                    }
                //}
            }
        }

        private void sgRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
           // if (IsLoading == false)
           // {
                if (FinishLoad == true)
                {
                    if (sgRadioButton4.Checked == true)
                    {
                        FinishLoad = false;
                        sgListView1.Items.Clear();
                        imageList1.Images.Clear();
                        LoadIcon(file_ie);
                    }
              //  }
            }
        }

        private void sgRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (FinishLoad == true)
            {
                if (sgRadioButton2.Checked == true)
                {
                    FinishLoad = false;
                    sgListView1.Items.Clear();
                    imageList1.Images.Clear();
                    LoadIcon(file_sysicon);
                }
            }
        }

        private void sgRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (FinishLoad == true)
            {
                if (sgRadioButton3.Checked == true)
                {
                    FinishLoad = false;
                    sgListView1.Items.Clear();
                    imageList1.Images.Clear();
                    LoadIcon(file_sysshell32);
                }
            }
        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            if(System.IO.File.Exists(sgTextBox2.Text)==false)
            {
               // sgLabel4.Visible = true;
                sgTextBox2.DoError("您似乎没有选择有效的图标文件");
            }
            else
            {
            //    sgLabel4.Visible = false;
                this.Returns = new string[] { file_selectimg.ToString(), file_selectindex.ToString() };
                this.ButtonClick ="ok";
                this.Close();
            }
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            this.Returns = new string[] { file_selectimg.ToString(), file_selectindex.ToString() };
            this.ButtonClick = "exit";
            this.Close();
        }

        private void sgListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sgListView1.SelectedItems.Count ==1)
            {
                file_selectindex = sgListView1.SelectedItems[0].Index;
            }
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            string j = SGFunction.CommonDialogs.OpenFileDialog("选择一个图标文件", "资源文件(*.exe;*.dll)|*.exe;*.dll");
            if(j !="")
            {
                FinishLoad = false;
                sgListView1.Items.Clear();
                imageList1.Images.Clear();
                LoadIcon(j);
            }
        }
        private void LoadModernProgram()
        {
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\WinAppInfo.sgcf";
            int j;
            int.TryParse(SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("winappinfo", "count", "0", cfg), out j);
            sgListView2.Items.Clear();
            imageList1.Images.Clear();
            for(int o=1;o<=j;o++)
            {
                string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("winappinfo", o.ToString(), "", cfg,false);
                string[] keys = read.Split('|');
                string J = SGFunction.PathOperate.ConvertStringToTurePath(keys[2].ToString(), keys[2].ToString());
                Bitmap log=SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(J);
                imageList1.Images.Add(log);
                sgListView2.Items.Add(keys[1]).ImageIndex =imageList1.Images.Count -1;
                sgListView2.Items[sgListView2.Items.Count - 1].SubItems.Add(keys[3]);
            }
        }

        private void MyNormalButton8_Click(object sender, EventArgs e)
        {
            this.ButtonClick = "exit";
            this.Returns = new string[] { "", "", "" };
            this.Close();
        }

        private void MyNormalButton6_Click(object sender, EventArgs e)
        {
            if (sgListView2.SelectedItems.Count == 1)
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\WinAppInfo.sgcf";
                string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("winappinfo", (sgListView2.SelectedItems[0].Index +1).ToString(), "1", cfg, false);
                string[] keys = read.Split('|');
                string id = keys[0];
                SGFunction.SystemFunctionAndInformation.ShellPrograms("Explorer.exe", "shell:::{4234d49b-0245-4df3-b780-3893943456e1}\\" + id, false, false, false, false);
            }
        }

        private void MyNormalButton7_Click(object sender, EventArgs e)
        {
            if (sgListView2.SelectedItems.Count == 1)
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\WinAppInfo.sgcf";
                string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("winappinfo", (sgListView2.SelectedItems[0].Index + 1).ToString(), "1", cfg, false);
                string[] keys = read.Split('|');
                string id = keys[0];
                string name = keys[1];
                string ico = SGFunction.PathOperate.ConvertStringToTurePath(keys[2], keys[2]);
                this.Returns = new string[] { id, name, ico };
                this.ButtonClick = "ok";
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MyNormalButton5_Click_1(object sender, EventArgs e)
        {
            switch (type.ToLower())
            {
                case "input":
                    this.ButtonClick = "exit";
                    this.Returns = new string[] { sgTextBox1.Text };
                    this.Close();
                    break;
                case "icon":
                    this.Returns = new string[] { file_selectimg.ToString(), file_selectindex.ToString() };
                    this.ButtonClick = "exit";
                    this.Close();
                    break;
                case "modern":
                    this.ButtonClick = "exit";
                    this.Returns = new string[] { "", "", "" };
                    this.Close();
                    break;
                case "clsid":
                    this.ButtonClick = "exit";
                    this.Returns = new string[] { "", "", "" };
                    this.Close();
                    break;
                case "diskchoose":
                    this.ButtonClick = "exit";
                    this.Returns = return_disk_info;
                    this.Close();
                    break;
                default:
                    this.ButtonClick = "exit";
                    this.Close();
                    break;
            }
        }

        private void sgTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private  void LoadCLSID()
        {
            try
            {
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\clsidinfo.sgcf";
                string[] keys, values;
                sgListView3.Items.Clear();
                imageList1.Images.Clear();
                SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("SYSTEMCLSID", out keys, out values, cfg);
                for (int j = 1; j <= keys.Length; j++)
                {
                    string clsid = keys[j - 1];
                   //判断CLSID是否注册
                    if(Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("clsid\\"+clsid) !=null)
                    {
                        string read = values[j - 1];
                        string name = "", icon = "";
                        if (read.Length > 0)
                        {
                            name = read.Substring(0, read.IndexOf("|"));
                            icon = read.Substring(read.IndexOf("|") + 1, read.Length - read.IndexOf("|") - 1);
                        }
                        icon = SGFunction.PathOperate.ConvertStringToTurePath(icon, icon);
                        imageList1.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(icon));
                        sgListView3.Items.Add(name).SubItems.Add(clsid);
                        sgListView3.Items[sgListView3.Items.Count - 1].ImageIndex = imageList1.Images.Count - 1;
                        sgListView3.Items[sgListView3.Items.Count - 1].Tag = icon;
                    }
                    Application.DoEvents();
                }
            }
            catch { }
        }

        private void MyNormalButton10_Click(object sender, EventArgs e)
        {
            try
            {
                if(sgListView3.SelectedItems.Count ==1)
                {
                    string clsid = sgListView3.SelectedItems[0].SubItems[1].Text;
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("Explorer.exe", "shell:::"+clsid, false, false, false, false);
                }
            }
            catch { }
        }

        private void MyNormalButton5_MouseMove(object sender, MouseEventArgs e)
        {
            Color cf = SGFunction.Skins.Skins_GetRoleColor("CLOSEBTN", "MOUSEMOVE");
            MyNormalButton5.BackColor = cf;
        }

        private void MyNormalButton5_MouseLeave(object sender, EventArgs e)
        {
            Color cf = SGFunction.Skins.Skins_GetRoleColor("CLOSEBTN", "");
            MyNormalButton5.BackColor = cf;
        }

        private void MyNormalButton11_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgListView3.SelectedItems.Count == 1)
                {
                    string clsid = sgListView3.SelectedItems[0].SubItems[1].Text;
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("Explorer.exe", "shell:::" + clsid, false, false, false, false);
                    string name=sgListView3.SelectedItems[0].SubItems[0].Text;
                    string icon=sgListView3.SelectedItems[0].Tag.ToString();
                    this.Returns = new string[] { clsid, name, icon };
                    this.ButtonClick = "ok";
                    this.Close();
                }
            }
            catch { }
        }

        private void MyNormalButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(listView1.SelectedItems.Count ==1)
                {
                    string panfu = listView1.SelectedItems[0].SubItems[0].Text;
                    string label = listView1.SelectedItems[0].SubItems[1].Text;
                    string type = listView1.SelectedItems[0].SubItems[2].Text;
                    string all_size = listView1.SelectedItems[0].SubItems[3].Text;
                    string all_freesize = listView1.SelectedItems[0].SubItems[4].Text;
                    switch (type)
                    {
                        case "CD或DVD驱动器":
                            type = "CDROM";
                            break;
                        case "固定的磁盘":
                            type = "FIXED";
                            break;
                        case "CD或DVD驱动器(不可用)":
                            type = "CANNOTUSE";
                            break;
                        case "固定的磁盘(不可用)":
                            type = "CANNOTUSE";
                            break;
                    }
                    if (all_size == "不可用") { all_size = "0 GB"; }
                    if (all_freesize == "不可用") { all_freesize = "0 GB"; }
                    all_freesize = all_freesize.Replace(" ", "").Replace("G", "").Replace("B", "");
                    all_size = all_size.Replace(" ", "").Replace("G", "").Replace("B", "");
                    return_disk_info[0] = panfu;
                    return_disk_info[1] = label;
                    return_disk_info[2] = type;
                    return_disk_info[3] = all_size;
                    return_disk_info[4] = all_freesize;
                    this.ButtonClick = "ok";
                    this.Returns = return_disk_info;
                    this.Close();
                }
                else
                {
                    this.ButtonClick = "exit";
                    this.Returns = return_disk_info;
                    this.Close();
                }
            }
            catch { }
        }

        private void SGForm_CommonDialogs_Load(object sender, EventArgs e)
        {
        
        }
    }
}
