using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear
{
    public partial class UserControl_CreateOrEditBCDBootMenu : UserControl
    {
        public UserControl_CreateOrEditBCDBootMenu()
        {
            InitializeComponent();
        }

        private void UserControl_CreateOrEditBCDBootMenu_Load(object sender, EventArgs e)
        {
            switch (this.FindForm().Tag.ToString().ToUpper())
            {
                case "NEW":
                    this.loaddisks();
                    label1.Text = "创建新的启动项";
                    comboBox1.SelectedIndex = 0;
                    break;
            }
        }
        void loaddisks()
        {
            string[] drvs = System.IO.Directory.GetLogicalDrives();
            comboBox2.Items.Clear();
            if (drvs != null)
            {
                for (int h = 1; h <= drvs.Length; h++)
                {
                    comboBox2.Items.Add(drvs[h - 1].ToUpper().Replace(@"\", ""));
                }
                comboBox2.Items.Add("[BOOT] 由启动的文件所在的分区确定");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != null)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0: //nt6
                        this.loaddisks();
                        textBox3.Text = "Windows NT6.x 启动项";
                        textBox2.Text = "{" + Guid.NewGuid().ToString().ToUpper() + "}";
                        if (comboBox2.Items.Count >= 1)
                        {
                            comboBox2.SelectedIndex = 1-1;
                        }
                        textBox1.Text = @"\Windows\System32\Winload.exe";
                        break;
                    case 1: //nt5
                        this.loaddisks();
                        textBox3.Text = "Windows NT5.x 启动项";
                        textBox2.Text = "{NTLDR}";
                        if (comboBox2.Items.Count >= 1)
                        {
                            comboBox2.SelectedIndex = 1-1;
                        }
                        textBox1.Text = @"\NTLDR";
                        break;
                    case 2: //grub
                        this.loaddisks();
                        textBox3.Text = "实模式启动项 (Grub4Dos)";
                        textBox2.Text = "{" + Guid.NewGuid().ToString().ToUpper() + "}";
                        if (comboBox2.Items.Count >= 1)
                        {
                            comboBox2.SelectedIndex = 1-1;
                        }
                        textBox1.Text = @"\GRLDR.MBR";
                        break;
                    case 3: //vhd
                        textBox3.Text = "Windows NT6.x 虚拟磁盘启动项";
                        textBox2.Text = "{" + Guid.NewGuid().ToString().ToUpper() + "}";
                        if (comboBox2.Items.Count >= 1)
                        {
                            comboBox2.SelectedIndex = 1-1;
                            comboBox2.Items.RemoveAt(comboBox2.Items.Count - 1);
                        }
                        textBox1.Text = @"\Vdisk.vhd";
                        break;
                    case 4: //ram
                        this.loaddisks();
                        textBox3.Text = "Windows NT6.x 磁盘映像启动项";
                        textBox2.Text = "{" + Guid.NewGuid().ToString().ToUpper() + "}";
                        if (comboBox2.Items.Count >= 1)
                        {
                            comboBox2.SelectedIndex = 1-1;
                        }
                        textBox1.Text = @"\DiskImage.wim";
                        MyFunctions.Dialogs.MessageDialog("注意", @"如果您需要添加RamDisk启动项时,请将BOOT.SDI复制到""引导磁盘目录\Boot""文件夹(可能为隐藏)下.""BOOT.SDI""可以从Windows NT6.x操作系统的安装光盘下的""Boot""文件夹中提取. 文件大小约为3MB左右", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                        string j = MyFunctions.Dialogs.MessageDialog("复制BOOT.SDI", @"您是否需要系统齿轮帮助您复制 BOOT.SDI 到系统盘目录\Boot文件夹", MyFunctions.Dialogs.MessageDialogIcon.Question , "", "b1", true, true, "是", "不,谢谢");
                        if (j == "B1")
                        {
                            string o=MyFunctions.Dialogs.OpenFileDialog("选择文件", "SDI文件(*.SDI)|*.SDI");
                            if (System.IO.File.Exists(o)==true)
                            {
                                COPYBOOT(o);
                            }
                        }
                        break;
                }
            }
        }
        void COPYBOOT(string FileName)
        {
            try
            {
                string bootdisk="";
                string[] insdisk = System.IO.Directory.GetLogicalDrives();
                for (int f = 1; f <= insdisk.Length; f++)
                {
                    if (MyFunctions.FileSystemOperate.FileSystemOperate_FolderOrDriveCanWrites(insdisk[f - 1].Replace(@"\", "")))
                    {
                        if (System.IO.File.Exists(insdisk[f - 1].ToString() + @"\BOOTMGR")==true )
                        {
                            bootdisk = insdisk[f - 1].ToString();
                            break;
                        }
                    }
                }
                if (bootdisk == "")
                {
                    MyFunctions.Dialogs.MessageDialog("无法找到您的启动分区", "请为启动分区(保留分区)分配一个盘符,并确保BOOTMGR存在于启动分区", MyFunctions.Dialogs.MessageDialogIcon.Error , "", "b2", false, true, "", "确定");
                }
                else
                {
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(FileName, bootdisk + @"\Boot\boot.sdi");
                    MyFunctions.Dialogs.MessageDialog("复制完成", @"已成功将BOOT.SDI 文件复制到""" + bootdisk.Replace(@"\", "") + @"\Boot""文件夹下", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                }
            }
            catch
            { }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (comboBox1.SelectedIndex != null)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            textBox1.Text = @"\Windows\System32\Winload.exe";
                            break;
                        case 1:
                            textBox1.Text = @"\NTLDR";
                            break;
                        case 2:
                            textBox1.Text = @"\GRLDR.MBR";
                            break;
                        case 3:
                            textBox1.Text =@"\Vdisk.vhd";
                            break;
                        case 4:
                            textBox1.Text = @"\DiskImage.wim";
                            break;
                    }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (this.FindForm().Tag.ToString().ToUpper())
            {
                case "NEW":
                    if (textBox3.Text != "" && textBox1.Text != "")
                    {
                        this.create(comboBox1.SelectedIndex);
                    }
                    break;
            }

        }
        public void create(int code)
        {
            string name, guid, bootdev, path;
            switch (code)
            {
                case 0:
                    name = textBox3.Text;
                    guid = textBox2.Text;
                    path = textBox1.Text;
                    bootdev = comboBox2.SelectedItem.ToString();
                    bool p1 = MyFunctions.FileSystemOperate.FileSystemOperate_FolderOrDriveCanWrites(bootdev);
                    if (p1 == true || bootdev.ToUpper().Substring(0,4) =="[BOO")
                    {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/create " + guid + @" /d """ + name + @""" /application osloader", true, false, true, false, true);
                    if (bootdev.Length > 5)
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" device BOOT", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" osdevice BOOT", true, false, true, false, true);
                    }
                    else
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" device partition=" + bootdev, true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" osdevice partition=" + bootdev, true, false, true, false, true);
                    }
                    //MessageBox.Show("/create " + guid + @" /d """ + name + @""" /application osloader");
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" path " + path, true, false, true, false, true);
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" locale zh-CN", true, false, true, false, true);
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" systemroot \Windows", true, false, true, false, true);
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" nx Optin", true, false, true, false, true);
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" inherit {bootloadersettings}", true, false, true, false, true);
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addfirst", true, false, true, false, true);
                    MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "b2", false, true, "", "确定");
                    this.Dispose();
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("创建失败", @"""" + bootdev + @"""不可写", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                    }
                    
                    break;
                case 1:
                    name = textBox3.Text;
                    guid = "{NTLDR}";
                    path = textBox1.Text;
                    bootdev = comboBox2.SelectedItem.ToString();
                    if (MyFunctions.FileSystemOperate.FileSystemOperate_FolderOrDriveCanWrites(bootdev) == true || bootdev.ToUpper().Substring(0, 4) == "[BOO")
                    {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/create " + guid + @" /d """ + name + @"""", true, false, true, false, true);
                    if (bootdev.Length > 5)
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" device BOOT", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" osdevice BOOT", true, false, true, false, true);
                    }
                    else
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" device partition=" + bootdev, true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" osdevice partition=" + bootdev, true, false, true, false, true);
                    }
                    //MessageBox.Show("/create " + guid + @" /d """ + name + @""" /application osloader");
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" path " + path, true, false, true, false, true);
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addfirst", true, false, true, false, true);
                    MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
                    this.Dispose();
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("创建失败", @"""" + bootdev + @"""不可写", MyFunctions.Dialogs.MessageDialogIcon.Error , "", "b2", false, true, "", "确定");
                    }
                    
                    break;
                case 2:
                    name = textBox3.Text;
                    guid = textBox2.Text;
                    path = textBox1.Text;
                    bootdev = comboBox2.SelectedItem.ToString();
                    if (MyFunctions.FileSystemOperate.FileSystemOperate_FolderOrDriveCanWrites(bootdev) == true || bootdev.ToUpper().Substring(0, 4) == "[BOO")
                    {
MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/create " + guid + @" /d """ + name + @""" /application bootsector", true, false, true, false, true);
                    if (bootdev.Length > 5)
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" device BOOT", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" osdevice BOOT", true, false, true, false, true);
                    }
                    else
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" device partition=" + bootdev, true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" osdevice partition=" + bootdev, true, false, true, false, true);
                    }
                    //MessageBox.Show("/create " + guid + @" /d """ + name + @""" /application osloader");
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" path " + path, true, false, true, false, true);
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addfirst", true, false, true, false, true);
                    MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
                    this.Dispose();
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("创建失败", @"""" + bootdev + @"""不可写", MyFunctions.Dialogs.MessageDialogIcon.Error , "", "b2", false, true, "", "确定");
                    }
                    
                    break;
                case 3: //vhd
                    name = textBox3.Text;
                    guid = textBox2.Text;
                    path = textBox1.Text;
                    bootdev = comboBox2.SelectedItem.ToString();
                    if (MyFunctions.FileSystemOperate.FileSystemOperate_FolderOrDriveCanWrites(bootdev) == true )
                    {
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/create " + guid + @" /d """ + name + @""" /application osloader", true, false, true, false, true);
                        if (bootdev.Length > 10)
                        {

                        }
                        else
                        {
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" osdevice vhd=[" + bootdev + "]" + path, true, false, true, false, true);
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" device vhd=[" + bootdev + "]" + path, true, false, true, false, true);
                        }
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " locale zh-CN", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addfirst", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " inherit {bootloadersettings}", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" path \Windows\System32\Winload.exe", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" systemroot \windows", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " nx Optin", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " detecthal on", true, false, true, false, true);
                        MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
                        this.Dispose();
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("创建失败", @"""" + bootdev + @"""不可写", MyFunctions.Dialogs.MessageDialogIcon.Error , "", "b2", false, true, "", "确定");
                    }
                    break;
                case 4: //wim
                    name = textBox3.Text;
                    guid = textBox2.Text;
                    path = textBox1.Text;
                    bootdev = comboBox2.SelectedItem.ToString();
                    if (MyFunctions.FileSystemOperate.FileSystemOperate_FolderOrDriveCanWrites(bootdev) == true || bootdev.ToUpper().Substring(0, 4) == "[BOO")
                    {
                        string operacode = "{" + Guid.NewGuid().ToString().ToUpper() + "}";
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/create " + operacode + @" /d """ + name + @""" /device", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/create " + guid + @" /d """ + name + @""" /application OSLOADER", true, false, true, false, true);
                        if (bootdev.Length > 5)
                        {
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + operacode + @" ramdisksdidevice partition=[BOOT]", true, false, true, false, true);
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " device ramdisk=[BOOT]" + path + "," + operacode, true, false, true, false, true);
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " osdevice ramdisk=[BOOT]" + path + "," + operacode, true, false, true, false, true);
                        }
                        else
                        {
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + operacode + @" ramdisksdidevice partition=" + bootdev, true, false, true, false, true);
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " device ramdisk=[" + bootdev + "]" + path + "," + operacode, true, false, true, false, true);
                            MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " osdevice ramdisk=[" + bootdev + "]" + path + "," + operacode, true, false, true, false, true);
                        }
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + operacode + @" ramdisksdipath \boot\boot.sdi", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " locale zh-CN", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/displayorder " + guid + @" /addfirst", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " inherit {bootloadersettings}", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + @" systemroot \windows", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " nx Optin", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " detecthal yes", true, false, true, false, true);
                        MyFunctions.ProgramAndLinksOperate.ShellPrograms("bcdedit.exe", "/set " + guid + " winpe yes", true, false, true, false, true);
                        MyFunctions.Dialogs.MessageDialog("创建成功", @"成功新建了名为""" + name + @"""的启动项", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
                        this.Dispose();
                    }
                    else
                    {
                        MyFunctions.Dialogs.MessageDialog("创建失败", @"""" + bootdev + @"""不可写", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "b2", false, true, "", "确定");
                    }
                    break;

            }
        }
    }
}
