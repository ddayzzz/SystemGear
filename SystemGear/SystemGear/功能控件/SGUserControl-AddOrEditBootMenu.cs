using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SystemGear.功能控件
{
    public partial class SGUserControl_AddOrEditBootMenu : UserControl
    {
        string opco = "";
        string type="create";
        bool ussreach_changename = false;
        List<string> installdisks = new List<string>();
        SGForm_Function_SystemStyle ff;
        string create_retclsid = "";
        bool loadedit = false;
        string[] edit_tags;
        int edit_selectindex = 0;
        public SGUserControl_AddOrEditBootMenu(string type,List<string> instdisk,SGForm_Function_SystemStyle s,string[] tags,int seleindex)
        {
            InitializeComponent();
            SGFunction.Skins.DrawAllControlInTabControl(this.sgTabPageControl1);
            this.panel1.BackColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "light");
            MyNormalButton3.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("BTN_OTHER", "BK");
            MyNormalButton3.ForeColor = SGFunction.Skins.Skins_GetControlColorSetting("BTN_OTHER", "fr");
            this.sgTabPageControl1.Location = new Point(-7, -37);
            this.type = type;
            this.ff = s;
            edit_selectindex = seleindex;
            this.installdisks = instdisk;
            if (type == "create") 
            {
                MyNormalButton3.Text = "添加";
                MyNormalButton3.Image = Properties.Resources.AddButton;
                sgCombobox1.SelectedIndex = 0;
                //if (sgCombobox2.Items.Count >= 1) { sgCombobox2.SelectedIndex = 0; }
            }
            else
            {
                MyNormalButton3.Text = "应用";
                MyNormalButton3.Image = Properties.Resources.OK;
                MyNormalButton2.Visible = false;
                edit_tags = tags;
                this.Edit_Load();
            }
        }
        void Edit_Load()
        {
            string clsid = edit_tags[0];
            string name = edit_tags[1];
            string type = edit_tags[2];
            string path = edit_tags[3];
            string def = edit_tags[4];
            opco = edit_tags[5];
            //MessageBox.Show(opco);
            this.loadedit = true;
            switch(type)
            {
                case "Windows 虚拟磁盘文件":
                    sgCombobox1.SelectedIndex = 3;
                    break;
                case "Windows 磁盘映像文件":
                    sgCombobox1.SelectedIndex = 4;
                    break;
                case "磁盘分区":
                    //还要判断系统版本
                    if (clsid.ToLower() == "{ntldr}") { sgCombobox1.SelectedIndex = 0; } else { sgCombobox1.SelectedIndex = 1; }
                    break;
            }
            //设置名字
            sgCombobox1.Enabled = false;
            sgTextBox1.Text = name;
            //获取启动文件
            string letter="";
            if(path !="")
            {
                string let = path.Substring(0, 3).ToLower();
                switch (let)
                {
                    case "[启动":
                        //还有看是不是
                        letter = "启动的分区";
                        sgTextBox2.Text = path.Substring(path.IndexOf("]") + 1, path.Length - path.IndexOf("]") - 1);
                        break;
                    case "[自动":
                        //这个没办法
                        if (sgCombobox2.Items.Count > 0) { sgCombobox2.SelectedIndex = 0; }
                        break;
                    default:
                        //磁盘
                        //看看是省么版本
                        string le;
                        string bf = path.Substring(path.IndexOf("\\"), path.Length - path.IndexOf("\\"));
                        le = path.Substring(0, 3);
                        letter = le;
                        sgTextBox2.Text = bf;
                        break;
                }
                if(letter !="")
                {
                    List<string > po=new List<string> ();
                     for(int p=1;p<=sgCombobox2.Items.Count;p++){po.Add(sgCombobox2.Items[p-1].ToString());}
                     int inde = SGFunction.DataOperate.FindSamestringIndexInArray(letter.ToUpper(), po.ToArray());
                     if (inde >= 0) { sgCombobox2.SelectedIndex = inde; }
                }
            }
        }
        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            string ico = SGFunction.Resources.GetIconPath("search");
            string[] op = new string[] { "搜索一个系统","搜索Windows 安装文件"};
            string res = SGFunction.CommonDialogs.ChooseTaskDialog("您需要搜索磁盘上的那些可以添加的启动菜单呢?", op, ico);
            switch(res)
            {
                case "t1":
                    this.SearchDisk_OS();
                    break;
                case "t2":
                    this.SearchDisk_OSSETUP_INDISK();
                    break;
            }
        }
        void SearchDisk_OS()
        {
            try
            {
                string ico = SGFunction.Resources.GetIconPath("winlogo");
                //查找系统
                List<string> os_type = new List<string>(); List<string> os_bit;
                List<string> os_disk=SGSystemStyle.SystemBoot.BootMenusMgr.FindBootMenu_OS(installdisks.ToArray(),out os_type,out os_bit);
                string[] find_os = os_disk.ToArray();
                string[] find_type = os_type.ToArray();
                string[] tskchooses = new string[find_type.Length ];
                if (find_os.Length > 0)
                {
                    string bootpath = "";
                    for(int j=1;j<=find_os.Length;j++)
                    {
                        string osbit = os_bit[j - 1];
                        string type = find_type[j - 1];
                        switch(type)
                        {
                            case "NT5.1":
                                type = "Windows XP";
                                bootpath = "\\NTLDR";
                                break;
                            case "NT5.2":
                                type = "Windows XP(x64)/Server 2003(R2)";
                                bootpath = "\\NTLDR";
                                break;
                            case "NT6.0":
                                if (osbit == "64") { type = "Windows Vista x64/Server 2008 x64" ; } else { type = "Windows Vista/Server 2008"; }
                                bootpath = @"\Windows\System32\Winload.exe";
                                break;
                            case "NT6.1":
                                if (osbit == "64") { type = "Windows 7 x64/Server 2008 R2"; } else { type = "Windows 7"; }
                                bootpath = @"\Windows\System32\Winload.exe";
                                break;
                            case "NT6.2":
                                if (osbit == "64") { type = "Windows 8 x64/Server 2012"; } else { type = "Windows 8"; }
                                bootpath = @"\Windows\System32\Winload.exe";
                                break;
                            case "NT6.3":
                                if (osbit == "64") { type = "Windows 8.1 x64/Server 2012 R2"; } else { type = "Windows 8.1"; }
                                bootpath = @"\Windows\System32\Winload.exe";
                                break;
                            case "NT10.0":
                            case "NT6.4":
                                if (osbit == "64") { type = "Windows 10 x64"; } else { type = "Windows 10"; }
                                bootpath = @"\Windows\System32\Winload.exe";
                                break;
                        }
                        tskchooses[j - 1] = find_os[j-1].Replace(":","").Replace("\\","")+"盘上的"+type;
                    }
                    //显示CHOOSE TASKS
                    string choose=SGFunction.CommonDialogs.ChooseTaskDialog("以下是我们找到的一些尚未添加到启动菜单的操作系统，点击它们即可添加。", tskchooses,ico);
                    if(choose !="")
                    {
                        choose = choose.Replace("t", "");
                        int k;
                        int.TryParse(choose, out k);
                        string select_disk = find_os[k - 1];
                        string select_type = find_type[k - 1];
                        string select_bit = os_bit.ToArray()[k - 1];
                        //MessageBox.Show(select_disk + "\r\n" + select_type);
                        if(select_disk !="")
                        {
                            List<string> po=new List<string>();
                            for(int p=1;p<=sgCombobox2.Items.Count;p++){po.Add(sgCombobox2.Items[p-1].ToString());}
                            int sei = SGFunction.DataOperate.FindSamestringIndexInArray(select_disk, po.ToArray());
                            if (sei >= 0)
                            {
                                ussreach_changename = true;
                                sgTextBox2.Text = bootpath;
                                switch (select_type)
                                {
                                    case "NT5.1":
                                        sgCombobox1.SelectedIndex = 0;
                                        sgTextBox1.Text = "启动 Windows XP";
                                        break;
                                    case "NT5.2":
                                        sgCombobox1.SelectedIndex = 0;
                                        sgTextBox1.Text = "启动 Windows XP/Server 2003(R2)";
                                        break;
                                    case "NT6.0":
                                        sgCombobox1.SelectedIndex = 1;
                                        if (select_bit == "64") { select_type = "Windows Vista x64/Server 2008 x64"; } else { select_type = "Windows Vista/Server 2008"; }
                                        sgTextBox1.Text = "启动" + select_type;
                                        break;
                                    case "NT6.1":
                                        sgCombobox1.SelectedIndex = 1;
                                        if (select_bit == "64") { select_type = "Windows 7 x64/Server 2008  R2"; } else { select_type = "Windows 7"; }
                                        sgTextBox1.Text = "启动" + select_type;
                                        break;
                                    case "NT6.2":
                                        sgCombobox1.SelectedIndex = 1;
                                        if (select_bit == "64") { select_type = "Windows 8 x64/Server 2012"; } else { select_type = "Windows 8"; }
                                        sgTextBox1.Text = "启动" + select_type;
                                        break;
                                    case "NT6.3":
                                        sgCombobox1.SelectedIndex = 1;
                                        if (select_bit == "64") { select_type = "Windows 8.1 x64/Server 2012 R2"; } else { select_type = "Windows 8.1"; }
                                        sgTextBox1.Text = "启动" + select_type;
                                        break;
                                    case "NT10.0":
                                    case "NT6.4":
                                        sgCombobox1.SelectedIndex = 1;
                                        if (select_bit == "64") { select_type = "Windows 10 x64"; } else { select_type = "Windows 10"; }
                                        sgTextBox1.Text = "启动" + select_type;
                                        break;
                                }
                                sgCombobox2.SelectedIndex = sei;
                            }
                            else
                            {
                                if (sgCombobox2.Items.Count >= 1) { sgCombobox1.SelectedIndex = 0; }
                                //sgCombobox1.SelectedIndex = 0; 
                            }
                        }
                    }
                }
                else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们没有找到任何一个新的脱机的系统。", 2); }
            }
            catch { }
        }
        void SearchDisk_OSSETUP_INDISK()
        {
            try
            {
                List<string> os_ver;
                string ico = SGFunction.Resources.GetIconPath("winlogo");
                string ico_dvd = SGFunction.Resources.GetIconPath("disc");
                //查找系统安装盘(硬盘中的)
                List<string> os_disk = SGSystemStyle.SystemBoot.BootMenusMgr.FindBootMenu_OSSETUP_INDISK(out os_ver);
                string[] find_os = os_disk.ToArray();
                string[] find_ver = os_ver.ToArray();
                if (find_os != null && find_os.Length >=1)
                {
                    string[] tskchooses = new string[find_os.Length];
                    for (int j = 1; j <= find_os.Length; j++)
                    {
                        string type = find_ver[j - 1];
                        switch (type)
                        {
                            case "6.0":
                                type = "Windows Vista 安装文件";
                                break;
                            case "6.1":
                                type = "Windows 7 安装文件";
                                break;
                            case "6.2":
                                type = "Windows 8 安装文件";
                                break;
                            case "6.3":
                                type = "Windows 8.1 安装文件";
                                break;
                            case "10.0":
                            case "6.4":
                                type = "Windows 10 安装文件";
                                break;
                        }
                        tskchooses[j - 1] = find_os[j-1].Replace(":","").Replace("\\","").Replace("//","")+"盘上的"+type;
                    }
                    string choose = SGFunction.CommonDialogs.ChooseTaskDialog("以下是我们在硬盘上找到的系统安装文件。", tskchooses, ico);
                    if (choose != "")
                    {
                        choose = choose.Replace("t", "");
                        int k;
                        int.TryParse(choose, out k);
                        string select_disk = find_os[k - 1];
                        string select_type = find_ver[k - 1];
                        //MessageBox.Show(select_disk + "\r\n" + select_type);
                        //已复制到硬盘
                        List<string> po = new List<string>();
                        for (int p = 1; p <= sgCombobox2.Items.Count; p++) { po.Add(sgCombobox2.Items[p - 1].ToString()); }
                        int ind = SGFunction.DataOperate.FindSamestringIndexInArray(select_disk, po.ToArray());
                        if (ind >= 0)
                        {
                            switch (select_type)
                            {
                                case "6.0":
                                    select_type = "Windows Vista/Server 2008";
                                    break;
                                case "6.1":
                                    select_type = "Windows 7/Server 2008 R2";
                                    break;
                                case "6.2":
                                    select_type = "Windows 8/Server 2012";
                                    break;
                                case "6.3":
                                    select_type = "Windows 8.1/Server 2012 R2";
                                    break;
                                case "10.0":
                                case "6.4":
                                    select_type = "Windows 10";
                                    break;
                            }
                            ussreach_changename = true;
                            sgCombobox1.SelectedIndex = 2;
                            sgCombobox2.SelectedIndex = ind;
                            sgTextBox1.Text = "安装" + select_type;
                            sgTextBox2.Text = "\\sources\\boot.wim";
                        }
                    }
                }
                else
                {
                    //在搜索光盘
                    List<string> dvd_ver;
                    List<string> dvd_disk = SGSystemStyle.SystemBoot.BootMenusMgr.FindBootMenu_OSSETUP_DVDDRIVE(out dvd_ver);
                    if (dvd_disk.Count >= 1)
                    {
                        //有文件
                        string[] tskchooses_dvd = new string[dvd_ver.Count];
                        for (int j = 1; j <= dvd_disk.Count; j++)
                        {
                            string type = dvd_ver[j - 1];
                            switch (type)
                            {
                                case "6.0":
                                    type = "Windows Vista 安装文件";
                                    break;
                                case "6.1":
                                    type = "Windows 7 安装文件";
                                    break;
                                case "6.2":
                                    type = "Windows 8 安装光文件";
                                    break;
                                case "6.3":
                                    type = "Windows 8.1 安装文件";
                                    break;
                                case "10.0":
                                case "6.4":
                                    type = "Windows 10 安装文件";
                                    break;
                            }
                            tskchooses_dvd[j - 1] = dvd_disk[j - 1].Replace(":", "").Replace("\\", "").Replace("//", "") + "盘上的" + type;
                        }
                        string choose_dvd = SGFunction.CommonDialogs.ChooseTaskDialog("以下是我们找到的系统安装光盘，点击它们即可复制到硬盘", tskchooses_dvd, ico_dvd);
                        if (choose_dvd != "")
                        {
                            choose_dvd = choose_dvd.Replace("t", "");
                            int k;
                            int.TryParse(choose_dvd, out k);
                            string select_disk = dvd_disk[k - 1];
                            string select_type = dvd_ver[k - 1];
                           // MessageBox.Show(select_disk + "\r\n" + select_type);
                            switch (select_type)
                            {
                                case "6.0":
                                    select_type = "Windows Vista/Server 2008";
                                    break;
                                case "6.1":
                                    select_type = "Windows 7/Server 2008 R2";
                                    break;
                                case "6.2":
                                    select_type = "Windows 8/Server 2012";
                                    break;
                                case "6.3":
                                    select_type = "Windows 8.1/Server 2012 R2";
                                    break;
                                case "10.0":
                                case "6.4":
                                    select_type = "Windows 10";
                                    break;
                            }
                            CopyWindowsSetupFile(select_disk, select_type);
                        }
                    }
                    else { SGFunction.CommonDialogs.MessageDialog_ShowInfo("抱歉，我们没有找到任何一个系统的安装文件。", 2); }
                }
                
            }
            catch { }
        }
        void CopyWindowsSetupFile(string selectdirroot,string osname)
        {
            string tagroot = "";
            string res = SGFunction.CommonDialogs.MessageDialog_MustClick("您需要帮助吗？", @"您需要我们帮您复制安装文件吗？点击""复制""即可复制到一个较大的硬盘中。", "复制", "不，谢谢", "b1", "ques");
            switch(res)
            {
                case "b1":
                    long size_b;
                    string letter = SGFunction.FileSystemOperate.FSO_GetTheMaxFreeSpaceDriveLetter(DriveType.Fixed, out size_b);
                    string[] fs = new string[] { selectdirroot + "sources", selectdirroot + "boot", selectdirroot + "support", selectdirroot + "bootmgr", selectdirroot + "bootmgr.efi", selectdirroot + "efi" };
                    int size_mb;
                    string i=SGFunction.DataOperate.ByteOperate(size_b, "tomb", false);
                    int.TryParse(i.Replace(".",""), out size_mb);
                    if (size_mb >= 2048)
                    {
                        SGFunction.CommonDialogs.CopyFilesWithSystemProcessDialog(fs, letter);
                        //复制成功后
                        string wim = letter + "sources\\boot.wim";
                        if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(wim)==true)
                        {
                            List<string> po = new List<string>();
                            for (int p = 1; p <= sgCombobox2.Items.Count; p++) { po.Add(sgCombobox2.Items[p - 1].ToString()); }
                            int ind = SGFunction.DataOperate.FindSamestringIndexInArray(letter, po.ToArray());
                            if (ind >= 0)
                            {
                                ussreach_changename = true;
                                sgCombobox1.SelectedIndex = 2;
                                sgCombobox2.SelectedIndex = ind;
                                sgTextBox1.Text = "安装"+osname;
                                sgTextBox2.Text = "\\sources\\boot.wim";
                            }
                        }
                    }
                    else 
                    { 
                        //ERROR NO FREE
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("出错了，您似乎没有足够的空间从硬盘上安装Windows，我们建议您从光驱启动。", 2); 
                    }
                    break;
                case "":
                    break;
            }
        }

        private void sgCombobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sgCombobox2.Items.Clear();
            string[] dds = SGFunction.FileSystemOperate.FSO_GetLocalDiskDrives(DriveType.Fixed);
            for (int u = 1; u <= dds.Length; u++)
            {
                sgCombobox2.Items.Add(dds[u - 1]);
            }
            if (sgCombobox1.SelectedIndex != 3)
            {
                sgCombobox2.Items.Add("启动的分区");
            }
            switch (sgCombobox1.SelectedIndex)
            {
                case 0:
                    if (loadedit == true)
                    {
                        loadedit = false;
                    }
                    else { if (ussreach_changename == false) { sgTextBox1.Text = "Windows XP 启动菜单"; sgTextBox2.Text = "\\ntldr"; sgCombobox2.SelectedIndex = 0; } else { ussreach_changename = false; } }
                    break;
                case 1:
                    if (loadedit == true)
                    {
                        loadedit = false;
                    }
                    else { if (ussreach_changename == false) { sgTextBox1.Text = "Windows NT6.x 启动菜单"; sgTextBox2.Text = @"\Windows\System32\Winload.exe"; sgCombobox2.SelectedIndex = 0; } else { ussreach_changename = false; } }
                    break;
                case 2:
                    if(loadedit ==true)
                    {
                        loadedit = false;
                    }
                    else
                    {
                        if (ussreach_changename == false)
                        {
                            sgTextBox1.Text = "安装新的操作系统";
                            sgTextBox2.Text = "\\sources\\boot.wim";
                            sgCombobox2.SelectedIndex = 0;
                            string fw3 = SGFunction.CommonDialogs.OpenFileDialog("选择虚拟磁盘文件", "RamDisk文件(*.wim)|*.wim",false,"boot.wim");
                            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(fw3) == true)
                            {
                                //分割文件盒根目录
                                string root13;
                                string file32 = SGFunction.FileSystemOperate.FSO_GetFilePathWithoutDrive(fw3, out root13);
                                if (root13 != "")
                                {
                                    List<string> po13 = new List<string>();
                                    for (int p = 1; p <= sgCombobox2.Items.Count; p++) { po13.Add(sgCombobox2.Items[p - 1].ToString()); }
                                    int ind13 = SGFunction.DataOperate.FindSamestringIndexInArray(root13, po13.ToArray());
                                    if (ind13 >= 0)
                                    {
                                        sgCombobox2.SelectedIndex = ind13;
                                        sgTextBox2.Text = file32;
                                    }
                                    else
                                    {
                                        //error
                                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有选择一个在有效磁盘中的RamDisk文件", 2);
                                    }
                                }
                                else
                                {
                                    //error 
                                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有选择一个在有效磁盘中的RamDisk文件", 2);
                                }
                            }
                        }
                        else { ussreach_changename = false; }
                    }
                    //打开文件DIALOD

                    break;
                case 3:
                    if(loadedit ==true)
                    {
                        loadedit = false;
                    }
                    else
                    {
                        if (ussreach_changename == false) { sgTextBox1.Text = "从VHD启动"; } else { ussreach_changename = false; }
                        //打开文件DIALOD
                        string fv = SGFunction.CommonDialogs.OpenFileDialog("选择虚拟磁盘文件", "虚拟磁盘文件(*.vhd;*.vhdx)|*.vhd;*.vhdx");
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(fv) == true)
                        {
                            //分割文件盒根目录
                            string root;
                            string file1 = SGFunction.FileSystemOperate.FSO_GetFilePathWithoutDrive(fv, out root);
                            if (root != "")
                            {
                                List<string> po = new List<string>();
                                for (int p = 1; p <= sgCombobox2.Items.Count; p++) { po.Add(sgCombobox2.Items[p - 1].ToString()); }
                                int ind = SGFunction.DataOperate.FindSamestringIndexInArray(root, po.ToArray());
                                if (ind >= 0)
                                {
                                    sgCombobox2.SelectedIndex = ind;
                                    sgTextBox2.Text = file1;
                                }
                                else
                                {
                                    //error
                                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有选择一个在有效磁盘中的虚拟磁盘文件", 2);
                                    if (sgCombobox2.Items.Count > 0) { sgCombobox2.SelectedIndex = 0; }
                                }
                            }
                            else
                            {
                                //error 
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有选择一个在有效磁盘中的虚拟磁盘文件", 2);
                                if (sgCombobox2.Items.Count > 0) { sgCombobox2.SelectedIndex = 0; }
                            }
                        }
                    }
                    break;
                case 4:
                    if(loadedit ==true)
                    {
                        loadedit = false;
                    }
                    else
                    {
                        if (ussreach_changename == false) { sgTextBox1.Text = "从RamDisk 启动"; } else { ussreach_changename = false; }
                        //打开文件DIALOD
                        string fw = SGFunction.CommonDialogs.OpenFileDialog("选择虚拟磁盘文件", "RamDisk文件(*.wim)|*.wim");
                        if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(fw) == true)
                        {
                            //分割文件盒根目录
                            string root1;
                            string file2 = SGFunction.FileSystemOperate.FSO_GetFilePathWithoutDrive(fw, out root1);
                            if (root1 != "")
                            {
                                List<string> po1 = new List<string>();
                                for (int p = 1; p <= sgCombobox2.Items.Count; p++) { po1.Add(sgCombobox2.Items[p - 1].ToString()); }
                                int ind1 = SGFunction.DataOperate.FindSamestringIndexInArray(root1, po1.ToArray());
                                if (ind1 >= 0)
                                {
                                    sgCombobox2.SelectedIndex = ind1;
                                    sgTextBox2.Text = file2;
                                }
                                else
                                {
                                    //error
                                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有选择一个在有效磁盘中的RamDisk文件", 2);
                                    sgCombobox2.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                //error 
                                SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有选择一个在有效磁盘中的RamDisk文件", 2);
                                sgCombobox2.SelectedIndex = 0;
                            }
                        }
                    }
                    break;
            }

        }
        void FinishEdit()
        {
            switch(sgCombobox1.SelectedIndex)
            {
                case 0:
                    break;
            }
        }
        
        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            string tt = "";
            string ext = "";
            string otitle = "";
            switch (sgCombobox1.SelectedIndex)
            {
                case 3:
                    tt = "虚拟磁盘";
                    ext = "虚拟磁盘文件(*.vhd;*.vhdx)|*.vhd;*.vhdx";
                    otitle = "选择虚拟磁盘文件";
                    break;
                case 4:
                    tt = "RamDisk";
                    ext = "虚拟磁盘文件(*.vhd)|*.vhd";
                    if (SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.2" || SGFunction.SystemFunctionAndInformation.GetOSVersion() == "6.3")
                    {
                        ext = "虚拟磁盘文件(*.vhd;*.vhdx)|*.vhd;*.vhdx";
                    }
                    otitle = "选择RamDisk文件";
                    break;
                case 2:
                    tt = "RamDisk";
                    ext = "RamDisk文件(*.wim)|*.wim";
                    otitle = "选择RamDisk文件";
                    break;
                default:
                    tt = "启动文件";
                    ext = "所有文件(*.*)|*.*";
                    otitle = "选择启动的文件";
                    break;
            }
            //打开文件DIALOD
            string fv = SGFunction.CommonDialogs.OpenFileDialog(otitle, ext);
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(fv) == true)
            {
                //分割文件盒根目录
                string root;
                string file1 = SGFunction.FileSystemOperate.FSO_GetFilePathWithoutDrive(fv, out root);
                if (root != "")
                {
                    List<string> po = new List<string>();
                    for (int p = 1; p <= sgCombobox2.Items.Count; p++) { po.Add(sgCombobox2.Items[p - 1].ToString()); }
                    int ind = SGFunction.DataOperate.FindSamestringIndexInArray(root, po.ToArray());
                    if (ind >= 0)
                    {
                        sgCombobox2.SelectedIndex = ind;
                        sgTextBox2.Text = file1;
                    }
                    else
                    {
                        //error
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有选择一个在有效磁盘中的"+tt+"文件", 2);
                    }
                }
                else
                {
                    //error 
                    SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有选择一个在有效磁盘中的" + tt + "文件", 2);
                }
            }
        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (sgTextBox1.Text != "" && sgTextBox2.Text != "" && sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString() != "")
                {
                   if(type =="create")
                   {
                       string bootpath = "";
                       if (sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString() == "启动的分区")
                       {
                           bootpath = "[启动的分区]" + sgTextBox2.Text;
                       }
                       else { bootpath = sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString().Replace("\\", "") + sgTextBox2.Text; }
                       string code = "OS";
                       string jt = "磁盘分区";
                       switch (sgCombobox1.SelectedIndex)
                       {
                           case 0:
                               code = "XP";
                               jt = "磁盘分区";
                               break;
                           case 2:
                               code = "RAM";
                               jt = "Windows 磁盘映像文件";
                               break;
                           case 3:
                               code = "VHD";
                               jt = "Windows 虚拟磁盘文件";
                               break;
                           case 4:
                               code = "RAM";
                               jt = "Windows 磁盘映像文件";
                               break;
                       }
                       this.create(code);
                       string clsid = create_retclsid;
                       string name = sgTextBox1.Text;
                       string type1 = jt;
                       string path = bootpath;
                       string def = "";
                       string[] tag = new string[] { clsid, name, type1, path, def, this.opco };
                       ff.sgListView1.Items.Add("").SubItems.Add(name);
                       ff.sgListView1.Items[ff.sgListView1.Items.Count - 1].SubItems.Add(path);
                       ff.sgListView1.Items[ff.sgListView1.Items.Count - 1].SubItems.Add(type1);
                       ff.sgListView1.Items[ff.sgListView1.Items.Count - 1].SubItems.Add(clsid);
                       ff.sgListView1.Items[ff.sgListView1.Items.Count - 1].Tag = tag;
                       this.Dispose();
                   }else
                   {
                       //edit
                       string bootpath = "";
                       if (sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString() == "启动的分区")
                       {
                           bootpath = "[启动的分区]" + sgTextBox2.Text;
                       }
                       else { bootpath = sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString().Replace("\\", "") + sgTextBox2.Text; }
                       string code = "OS";
                       string jt = "磁盘分区";
                       switch (sgCombobox1.SelectedIndex)
                       {
                           case 0:
                               code = "XP";
                               jt = "磁盘分区";
                               break;
                           case 2:
                               code = "RAM";
                               jt = "Windows 磁盘映像文件";
                               break;
                           case 3:
                               code = "VHD";
                               jt = "Windows 虚拟磁盘文件";
                               break;
                           case 4:
                               code = "RAM";
                               jt = "Windows 磁盘映像文件";
                               break;
                       }
                       this.edit(code);
                       string clsid = edit_tags[0];
                       string name = sgTextBox1.Text;
                       string type2 = jt;
                       string path = bootpath;
                       string def = edit_tags[4];
                       string[] tag = new string[] { clsid, name, type2, path, def, this.opco};
                       //ff.sgListView1.Items.Add(def).SubItems.Add(name);
                       //ff.sgListView1.Items[ff.sgListView1.Items.Count - 1].SubItems.Add(path);
                       //ff.sgListView1.Items[ff.sgListView1.Items.Count - 1].SubItems.Add(type);
                      // ff.sgListView1.Items[ff.sgListView1.Items.Count - 1].SubItems.Add(clsid);
                       //ff.sgListView1.Items[ff.sgListView1.Items.Count - 1].Tag = tag;
                       ff.sgListView1.Items[edit_selectindex].Tag = tag;
                       ff.sgListView1.Items[edit_selectindex].SubItems[0].Text = def;
                       ff.sgListView1.Items[edit_selectindex].SubItems[1].Text = name;
                       ff.sgListView1.Items[edit_selectindex].SubItems[2].Text = path;
                       ff.sgListView1.Items[edit_selectindex].SubItems[3].Text = type2;
                       ff.sgListView1.Items[edit_selectindex].SubItems[4].Text = clsid;
                       this.Dispose();
                   }
                }
                else
                {
                   if(sgTextBox1.Text !="" && sgTextBox2.Text !="")
                   {
                       SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有选择启动项的启动磁盘哦，点击左侧的下拉菜单，你就可以选择启动的磁盘分区哦。", 2);
                   }
                   else
                   {
                       if (sgTextBox1.Text == "") { sgTextBox1.DoError("您需要输入启动项的名称哦"); }
                       if (sgTextBox2.Text == "") { sgTextBox2.DoError("您需要选择启动项的启动文件哦"); }
                   }

                    //SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有输入完整的信息，请检查这些信息是否完整：菜单名称、启动的磁盘和启动的文件", 2);
                }
            }
            catch { }
        }
        public void create(string code)
        {

            string name, guid, bootdev,path;
            switch (code)
            {
                case "OS":
                    name = sgTextBox1.Text;
                    guid =create_retclsid= SGFunction.DataOperate.GetCLSID();
                    path = sgTextBox2.Text;
                    bootdev = sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString().Replace("\\", "");
                    //OS XP
                    string arg_device_os_1 = @"/set " + guid + @" device partition=" + bootdev;
                    string arg_device_os_2 = @"/set " + guid + @" osdevice partition=" + bootdev;
                    //判断是不是BOOT
                    if(bootdev.Length >=4)
                    {
                        arg_device_os_1 = @"/set " + guid + @" device partition BOOT";
                        arg_device_os_2 = @"/set " + guid + @" osdevice partition BOOT";
                    }
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/create " + guid + @" /d """ + name + @""" /application osloader", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_os_1, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_os_2, true, false, true, true);
                    //MessageBox.Show("/create " + guid + @" /d """ + name + @""" /application osloader");
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" path " + path, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" locale zh-CN", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" systemroot \Windows", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" nx Optin", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" inherit {bootloadersettings}", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addlast", true, false, true, true);
                    //MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    break;
                case "XP":
                    name = sgTextBox1.Text;
                    guid =create_retclsid = "{NTLDR}";
                    path = sgTextBox2.Text;
                    bootdev = sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString().Replace("\\", "");
                    //OS XP
                    string arg_device_xp_1 = @"/set " + guid + @" device partition=" + bootdev;
                    string arg_device_xp_2 = @"/set " + guid + @" osdevice partition=" + bootdev;
                    //判断是不是BOOT
                    if (bootdev.Length >= 4)
                    {
                        arg_device_xp_1 = @"/set " + guid + @" device partition BOOT";
                        arg_device_xp_2 = @"/set " + guid + @" osdevice partition BOOT";
                    }
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/create " + guid + @" /d """ + name + @"""", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" device partition=" + bootdev, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" osdevice partition=" + bootdev, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" path " + path, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addlast", true, false, true, true);
                    //MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    break;
                case "VHD": //vhd
                    name = sgTextBox1.Text;
                    guid =create_retclsid = SGFunction.DataOperate.GetCLSID();
                    path = sgTextBox2.Text;
                    bootdev = sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString().Replace("\\", "");
                    //vhd
                    string arg_device_vhd_1 = @"/set " + guid + @" osdevice vhd=[" + bootdev + "]" + path ;
                    string arg_device_vhd_2 = @"/set " + guid + @" device vhd=[" + bootdev + "]" + path ;
                    //判断是不是BOOT
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/create " + guid + @" /d """ + name + @""" /application osloader", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_vhd_1 , true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_vhd_2 , true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " locale zh-CN", true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " inherit {bootloadersettings}", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" path \Windows\System32\Winload.exe", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" systemroot \windows", true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " nx Optin", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " detecthal on", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addlast", true, false, true, true);
                    //MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    break;
                case "RAM": //wim
                    name = sgTextBox1.Text;
                    guid =create_retclsid = SGFunction.DataOperate.GetCLSID();
                    path = sgTextBox2.Text;
                    bootdev = sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString().Replace("\\", "");
                    string operacode =opco = SGFunction.DataOperate.GetCLSID();
                    //wim
                    string arg_device_wim_1 = @"/set " + guid + " device ramdisk=[" + bootdev + "]" + path + "," + operacode;
                    string arg_device_wim_2 = @"/set " + guid + " osdevice ramdisk=[" + bootdev + "]" + path + "," + operacode;
                    string arg_device_wim_3 = @"/set " + operacode + @" ramdisksdidevice partition=" + bootdev;
                    //判断是不是BOOT
                    if (bootdev.Length >= 4)
                    {
                        arg_device_wim_1 = @"/set " + guid + " device ramdisk=[BOOT]" + path + "," + operacode;
                        arg_device_wim_2 = @"/set " + guid + " osdevice ramdisk=[BOOT]" + path + "," + operacode;
                        string sysdisk = SGFunction.SystemFunctionAndInformation.FindSystemDrive().Replace("\\", "");
                        arg_device_wim_3 = @"/set " + operacode + @" ramdisksdidevice partition="+sysdisk;
                        bootdev = sysdisk;
                    }
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/create " + operacode + @" /d """ + name + @""" /device", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/create " + guid + @" /d """ + name + @""" /application OSLOADER", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_wim_1 , true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_wim_2 , true, false, true, true);

                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_wim_3 , true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + operacode + @" ramdisksdipath \boot\boot.sdi", true, false, true, true);
                    //复制SYSTEM32\BOOT.SDI 到[DRIVE]\BOOT\BOOT.SDI
                    string tagsdi = bootdev + "\\boot\\boot.sdi";
                    string tagsdifolder = bootdev + "\\boot";
                    SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(tagsdifolder);
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(tagsdi) == false)
                    {
                        string orgsdi = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\boot.sdi";
                        SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(orgsdi, tagsdi);
                    }
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " locale zh-CN", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" path \Windows\System32\Winload.exe", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " inherit {bootloadersettings}", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" systemroot \windows", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " nx Optin", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " detecthal yes", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " winpe yes", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addlast", true, false, true, true);
                    //MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    break;

            }
        }
        public void edit(string code)
        {

            string name, guid, bootdev, path;
            switch (code)
            {
                case "OS":
                    name = sgTextBox1.Text;
                    guid = create_retclsid = edit_tags[0];
                    path = sgTextBox2.Text;
                    bootdev = sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString().Replace("\\", "");
                    //OS XP
                    string arg_device_os_1 = @"/set " + guid + @" device partition=" + bootdev;
                    string arg_device_os_2 = @"/set " + guid + @" osdevice partition=" + bootdev;
                    //判断是不是BOOT
                    if (bootdev.Length >= 4)
                    {
                        arg_device_os_1 = @"/set " + guid + @" device partition BOOT";
                        arg_device_os_2 = @"/set " + guid + @" osdevice partition BOOT";
                    }
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/create " + guid + @" /d """ + name + @""" /application osloader", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_os_1, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_os_2, true, false, true, true);
                    //MessageBox.Show("/create " + guid + @" /d """ + name + @""" /application osloader");
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" path " + path, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" description """ + name+@"""", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" locale zh-CN", true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" systemroot \Windows", true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" nx Optin", true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" inherit {bootloadersettings}", true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addlast", true, false, true, true);
                    //MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    break;
                case "XP":
                    name = sgTextBox1.Text;
                    guid = create_retclsid = edit_tags[0];
                    path = sgTextBox2.Text;
                    bootdev = sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString().Replace("\\", "");
                    //OS XP
                    string arg_device_xp_1 = @"/set " + guid + @" device partition=" + bootdev;
                    string arg_device_xp_2 = @"/set " + guid + @" osdevice partition=" + bootdev;
                    //判断是不是BOOT
                    if (bootdev.Length >= 4)
                    {
                        arg_device_xp_1 = @"/set " + guid + @" device partition BOOT";
                        arg_device_xp_2 = @"/set " + guid + @" osdevice partition BOOT";
                    }
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" description """ + name + @"""", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" device partition=" + bootdev, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" osdevice partition=" + bootdev, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" path " + path, true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addlast", true, false, true, true);
                    //MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    break;
                case "VHD": //vhd
                    name = sgTextBox1.Text;
                    guid = create_retclsid = edit_tags[0];
                    path = sgTextBox2.Text;
                    bootdev = sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString().Replace("\\", "");
                    //vhd
                    string arg_device_vhd_1 = @"/set " + guid + @" osdevice vhd=[" + bootdev + "]" + path;
                    string arg_device_vhd_2 = @"/set " + guid + @" device vhd=[" + bootdev + "]" + path;
                    //判断是不是BOOT
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" description """ + name + @"""", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_vhd_1, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_vhd_2, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " locale zh-CN", true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " inherit {bootloadersettings}", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" path \Windows\System32\Winload.exe", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" systemroot \windows", true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " nx Optin", true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " detecthal on", true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addlast", true, false, true, true);
                    //MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    break;
                case "RAM": //wim
                    name = sgTextBox1.Text;
                    guid = create_retclsid = edit_tags[0];
                    path = sgTextBox2.Text;
                    bootdev = sgCombobox2.Items[sgCombobox2.SelectedIndex].ToString().Replace("\\", "");
                    string operacode = this.opco;
                    //wim
                    string arg_device_wim_1 = @"/set " + guid + " device ramdisk=[" + bootdev + "]" + path + "," + operacode;
                    string arg_device_wim_2 = @"/set " + guid + " osdevice ramdisk=[" + bootdev + "]" + path + "," + operacode;
                    string arg_device_wim_3 = @"/set " + operacode + @" ramdisksdidevice partition=" + bootdev;
                    //判断是不是BOOT
                    if (bootdev.Length >= 4)
                    {
                        arg_device_wim_1 = @"/set " + guid + " device ramdisk=[BOOT]" + path + "," + operacode;
                        arg_device_wim_2 = @"/set " + guid + " osdevice ramdisk=[BOOT]" + path + "," + operacode;
                        string sysdisk = SGFunction.SystemFunctionAndInformation.FindSystemDrive().Replace("\\", "");
                        arg_device_wim_3 = @"/set " + operacode + @" ramdisksdidevice partition=" + sysdisk;
                        bootdev = sysdisk;
                    }
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + operacode  + @" description """ + name + @"""", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" description """ + name + @"""", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_wim_1, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_wim_2, true, false, true, true);

                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", arg_device_wim_3, true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + operacode + @" ramdisksdipath \boot\boot.sdi", true, false, true, true);
                    //复制SYSTEM32\BOOT.SDI 到[DRIVE]\BOOT\BOOT.SDI 如果是BOOT 复制到系统目录
                    string tagsdi = bootdev + "\\boot\\boot.sdi";
                    string tagsdifolder = bootdev + "\\boot";
                    SGFunction.FileSystemOperate.FileSystemOperate_CreateNewFolder(tagsdifolder);
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(tagsdi) == false)
                    {
                        string orgsdi = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\boot.sdi";
                        SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(orgsdi, tagsdi);
                    }
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " locale zh-CN", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" path \Windows\System32\Winload.exe", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " inherit {bootloadersettings}", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + @" systemroot \windows", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " nx Optin", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " detecthal yes", true, false, true, true);
                    SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/set " + guid + " winpe yes", true, false, true, true);
                    //SGFunction.SystemFunctionAndInformation.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addlast", true, false, true, true);
                    //MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    break;

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
