using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SystemGear
{
    public partial class UserControl_CreateNewExtraName : UserControl
    {
        public UserControl_CreateNewExtraName()
        {
            InitializeComponent();
        }
        string TempFile = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_TempPath(Application.StartupPath + @"\Temp") + @"\NewExtraName.sgtmp";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "添加操作")
            {
                textBox3.Text = textBox5.Text = "";
                checkBox1.Checked = false;
                button5.Text = "确定";
                panel1.Visible = true;
            }
            else
            {
                if (textBox4.Text != "" && textBox5.Text != "")
                {
                    button5.Text = "添加操作";
                    panel1.Visible = false;
                    label14.Visible = label15.Visible = false;
                    int cmdcount = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MainInfo", "commandcount", "", false, TempFile), 0);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "Name", textBox4.Text, "ExtraName", false, TempFile);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "Icon", textBox3.Text, "ExtraName", true, TempFile);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "Command", textBox5.Text, "ExtraName", false, TempFile);
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", (cmdcount + 1).ToString(), "ExtraName", false, TempFile);
                    string s = "F";
                    if (checkBox1.Checked == true)
                    {
                        s = "T";
                    }
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + (cmdcount + 1).ToString(), "RunAsAdmin", s, "ExtraName", false, TempFile);
                    this.LoadToTreeview();
                }
                else
                {
                    if (textBox4.Text == "") { label14.Visible = true; } else { label14.Visible = false; }
                    if (textBox5.Text == "") { label15.Visible = true; } else { label15.Visible = false; }
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "ExtraName_Name", textBox1.Text, "ExtraName", false, TempFile);
            this.LoadToTreeview();
        }

        private void UserControl_CreateNewExtraName_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,2";
            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TempFile);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "ExtraName_Icon", textBox2.Text, "ExtraName", false, TempFile);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", "0", "ExtraName", false, TempFile);
            this.LoadToTreeview();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    textBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,2";
                    break;
                case 1:
                    textBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,11";
                    break;
                case 2:
                    textBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,3";
                    break;
                case 3:
                    textBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,14";
                    break;
                case 4:
                    textBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,125";
                    break;
                case 5:
                    textBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,65";
                    break;
            }
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "ExtraName_Icon", textBox2.Text, "ExtraName", false, TempFile);
            this.LoadToTreeview();
        }


        private void button4_Click(object sender, EventArgs e)
        {
        }
        void LoadToTreeview()
        {
            button6.Visible = false;
            treeView1.Nodes.Clear();
            imageList1.Images.Clear();
            treeView1.Nodes.Add(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MainInfo", "ExtraName_Name", "", false, TempFile));
            imageList1.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MainInfo", "ExtraName_icon", "", false, TempFile), Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,2"));
            treeView1.Nodes[0].ImageIndex = 0;
            treeView1.Nodes[0].SelectedImageIndex = 0;
            treeView1.Nodes[0].StateImageIndex = 0;
            treeView1.Nodes[0].Tag = "Main";
            int cmdcount = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MainInfo", "commandcount", "", false, TempFile), 0);
            for (int u = 1; u <= cmdcount; u = u + 1)
            {
                treeView1.Nodes[0].Nodes.Add(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + u.ToString(), "name", "", false, TempFile));
                imageList1.Images.Add(MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + u.ToString(), "icon", "", true, TempFile), Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,2"));
                treeView1.Nodes[0].Nodes[u - 1].ImageIndex = u;
                treeView1.Nodes[0].Nodes[u - 1].SelectedImageIndex = u;
                treeView1.Nodes[0].Nodes[u - 1].StateImageIndex = u;
                treeView1.Nodes[0].Nodes[u - 1].Tag = u.ToString();
            }
            treeView1.ExpandAll();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.textBox3.Text = MyFunctions.Dialogs.ChooseIcon("选择一个图标文件", textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button1, new Point(0, button1.Height + 5));
        }

        private void 使用记事本打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text = "使用记事本打开";
            textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,14";
            textBox5.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\notepad.exe ""%1""";
            checkBox1.Checked = false;
        }

        private void 使用CMD打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text = "使用CMD打开";
            textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,63";
            textBox5.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd.exe /k ""%1""";
            checkBox1.Checked = false;
        }

        private void 使用CMD打开管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text = "使用CMD打开(管理员)";
            textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,63";
            textBox5.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd.exe /k ""%1""";
            checkBox1.Checked = true;
        }

        private void 使用Windows照片查看器打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text = "使用Windows 照片查看器打开";
            textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,65";
            textBox5.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\rundll32.exe ""%ProgramFiles%\Windows Photo Viewer\PhotoViewer.dll"", ImageView_Fullscreen %1";
            checkBox1.Checked = false;
        }

        private void 使用画图打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text = "使用画图打开";
            textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,65";
            textBox5.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\mspaint.exe ""%1""";
            checkBox1.Checked = false;
        }

        private void 使用WindowsMediaPlayer播放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text = "使用Windows Media Player 播放";
            textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\imageres.dll,125";
            textBox5.Text = @"""" + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Windows Media Player\wmplayer.exe"" ""%1""";
            checkBox1.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(TempFile) == true && textBox1.Text != "" && textBox6.Text != "" && textBox2.Text != "")
            {
                label6.Visible = label8.Visible = label12.Visible = false;
                string extname = textBox1.Text;
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Microsoft.Win32.Registry.ClassesRoot, "", "." + extname, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Microsoft.Win32.Registry.ClassesRoot, "." + extname, "", extname + @"File", Microsoft.Win32.RegistryValueKind.String, false, false);
                string locname = extname + @"File";
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, locname + @"\DefaultIcon", "", textBox2.Text, RegistryValueKind.ExpandString, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, locname, "", textBox6.Text, RegistryValueKind.ExpandString, false, false);
                MyFunctions.RegistryOperate.RegistryOperate_CreateSubKey(Registry.ClassesRoot, locname, "Shell", false);
                int y = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("MainInfo", "commandcount", "", false, TempFile), 0);
                for (int d = 1; d <= y; d = d + 1)
                {
                    string name, icon, command;
                    name = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + d.ToString(), "name", "", false, TempFile);
                    icon = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + d.ToString(), "icon", "", false, TempFile);
                    command = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + d.ToString(), "command", "", false, TempFile);
                    //MessageBox.Show(command);
                    string runas = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + d.ToString(), "runasadmin", "F", false, TempFile);
                    if (runas.ToUpper() == "T")
                    {
                        command = @"wscript.exe """ + Application.StartupPath + @"\Programs\RunAsAdmin.vbs"" " + command;
                    }
                    ///////////////////////////////////////////////////
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, locname + @"\Shell\Command" + d.ToString(), "", name, RegistryValueKind.String, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, locname + @"\Shell\Command" + d.ToString(), "Icon", icon, RegistryValueKind.ExpandString, false, false);
                    MyFunctions.RegistryOperate.RegistryOperate_SetValue(Registry.ClassesRoot, locname + @"\Shell\Command" + d.ToString() + @"\Command", "", command, RegistryValueKind.ExpandString, false, false);
                    MyFunctions.Dialogs.MessageDialog("成功", "成功新建了扩展名", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "继续", "确定");
                    this.Dispose();
                }
            }
            else
            {
                if (textBox1.Text == "") { label6.Visible = true; } else { label6.Visible = false; }
                if (textBox6.Text == "") { label12.Visible = true; } else { label12.Visible = false; }
                if (textBox2.Text == "") { label8.Visible = true; } else { label8.Visible = false; }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = MyFunctions.Dialogs.ChooseIcon("选择扩展名的图标", textBox2.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (null != treeView1.SelectedNode)
            {
                string res = MyFunctions.Dialogs.MessageDialog("继续？", "您确定要删除这个操作吗？", MyFunctions.Dialogs.MessageDialogIcon.Question , "", "b2", true, true, "继续", "取消");
                if (res=="B1")
                {
                    if (treeView1.SelectedNode.Tag.ToString().ToUpper() != "MAIN")
                    {
                        int SaveCommandItems = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "commandcount", "0", false, TempFile), 0) - 1;
                        string[] SaveCommand_Name = new string[SaveCommandItems];
                        string[] SaveCommand_Icon = new string[SaveCommandItems];
                        string[] SaveCommand_Command = new string[SaveCommandItems];
                        string[] SaveCommand_RunAsAdmin = new string[SaveCommandItems];
                        int deleteindex = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(treeView1.SelectedNode.Tag.ToString(), 0);
                        int c = 1;
                        for (int y = 1; y <= SaveCommandItems + 1; y = y + 1)
                        {
                            if (y != deleteindex)
                            {
                                SaveCommand_Name[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "name", "", false, TempFile);
                                SaveCommand_Icon[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "icon", "", false, TempFile);
                                SaveCommand_Command[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "command", "", false, TempFile);
                                SaveCommand_RunAsAdmin[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("command" + y.ToString(), "runasadmin", "", false, TempFile);
                            }
                            else
                            {
                                c = c + 1;
                            }
                        }
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("MainInfo", "CommandCount", SaveCommandItems.ToString(), "ExtraName", false, TempFile);
                        for (int g = 1; g <= SaveCommand_Name.Length; g = g + 1)
                        {
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Name", SaveCommand_Name[g - 1].ToString(), "ExtraName", false, TempFile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Icon", SaveCommand_Icon[g - 1].ToString(), "ExtraName", false, TempFile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "Command", SaveCommand_Command[g - 1].ToString(), "ExtraName", false, TempFile);
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Command" + g.ToString(), "RunAsAdmin", SaveCommand_RunAsAdmin[g - 1].ToString(), "ExtraName", false, TempFile);
                        }
                        this.LoadToTreeview();
                    }
                    else
                    {
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeView1.SelectedNode !=null)
            {
                if (treeView1.SelectedNode.Tag.ToString().ToUpper()=="MAIN")
                {
                    button6.Visible = false;
                }
                else
                {
                    button6.Visible = true;
                }
            }
            else
            {
                button6.Visible = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
