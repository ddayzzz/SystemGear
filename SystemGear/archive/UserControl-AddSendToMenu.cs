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
    public partial class UserControl_AddSendToMenu : UserControl
    {
        public int SetType;
        public UserControl_AddSendToMenu()
        {
            InitializeComponent();
        }
        void settype(int settypeint)
        {
            label7.Visible = label10.Visible = label14.Visible = false;
            switch (settypeint)
            {
                case 1:
                    SetType =1;
                    label3.ForeColor = label6.ForeColor = Color.FromArgb(105, 105, 105);
                    label2.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    textBox_name.Text = textBox_folder.Text = textBox_cmd.Text = textBox_arg.Text = "";
                    checkBox1.Enabled = false;
                    button1.Enabled = textBox_arg.Enabled =textBox_cmd.Enabled = false;
                    button4.Enabled = textBox_folder.Enabled = true;
                    break;
                case 2:
                    SetType = 2;
                    label6.ForeColor = label2.ForeColor = Color.FromArgb(105, 105, 105);
                    label3.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    textBox_name.Text = textBox_folder.Text = textBox_cmd.Text = textBox_arg.Text = "";
                    checkBox1.Enabled = true;
                    button1.Enabled = textBox_arg.Enabled = textBox_cmd.Enabled = true;
                    button4.Enabled = textBox_folder.Enabled = false;
                    break;
                case 3:
                    SetType = 3;
                    label3.ForeColor = label2.ForeColor = Color.FromArgb(105, 105, 105);
                    label6.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
                    textBox_name.Text = textBox_folder.Text = textBox_cmd.Text = textBox_arg.Text = "";
                    checkBox1.Enabled = true;
                    button1.Enabled = textBox_arg.Enabled = textBox_cmd.Enabled = true;
                    button4.Enabled = textBox_folder.Enabled = false;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyFunctions.Dialogs.HelpDialog("创建菜单帮助", label15.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.settype(1);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.settype(2);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.settype(3);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            l.ForeColor = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            switch (SetType)
            {
                case 1:
                    label3.ForeColor=label6.ForeColor  = Color.FromArgb(105, 105, 105);
                    break;
                case 2:
                    label2.ForeColor = label6.ForeColor = Color.FromArgb(105, 105, 105);
                    break;
                case 3:
                    label3.ForeColor = label2.ForeColor = Color.FromArgb(105, 105, 105);
                    break;
            }
        }

        private void UserControl_AddSendToMenu_Load(object sender, EventArgs e)
        {
            this.settype(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fodler = MyFunctions.Dialogs.OpenFolder("选择文件夹");
            if (System.IO.Directory.Exists(fodler) == true)
            {
                textBox_folder.Text = fodler;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = MyFunctions.Dialogs.OpenFileDialog("选择可执行文件", "支持的项目(*.exe;*.cmd;*.bat)|*.exe;*.cmd;*.bat");
            if (System.IO.File.Exists(file) == true)
            {
              textBox_cmd.Text = file;
            }
        }
        void SendTo_Folder(string name,string folder)
        {
            string linkpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo\"+name+".lnk";
             MyFunctions.ProgramAndLinksOperate.CreateLink(linkpath, folder, "", "", "", null);
        }
        void SendTo_OpenByProgram(string program, string args, string name,bool runasadmin,string ico)
        {
            if (runasadmin == false)
            {
                string linkpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo\" + name + ".lnk";
                 MyFunctions.ProgramAndLinksOperate.CreateLink(linkpath, program, args, "", "", null);
            }
            else
            {
                string linkpath1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\SendTo\" + name + ".lnk";
                MyFunctions.ProgramAndLinksOperate.CreateLink_StartAdminType(linkpath1, program, args, "", ico);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            switch (SetType)
            {
                case 1:
                    if (textBox_name.Text != "" && System.IO.Directory.Exists(textBox_folder.Text)==true)
                    {
                        label7.Visible = false;
                        label10.Visible = false;
                        SendTo_Folder(textBox_name.Text, textBox_folder.Text);
                        MyFunctions.Dialogs.MessageDialog("成功新建菜单", @"成功新建了""" + textBox_name.Text + @"""的菜单", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
                        this.Dispose();
                    }
                    else
                    {
                        if (textBox_name.Text == "") { label7.Visible = true; } else { label7.Visible = false; }
                        if (System.IO.Directory.Exists(textBox_folder.Text) == false) { label10.Visible = true; } else { label10.Visible = false; }
                    }
                    break;
                default:
                    if (textBox_name.Text != "" && System.IO.File.Exists(textBox_cmd.Text) == true || System.IO.Path.GetExtension(textBox_cmd.Text).ToUpper() == ".EXE" || System.IO.Path.GetExtension(textBox_cmd.Text).ToUpper() == ".CMD" || System.IO.Path.GetExtension(textBox_cmd.Text).ToUpper() == ".BAT")
                    {
                        label7.Visible = label14.Visible = false;
                        string i;
                        switch (System.IO.Path.GetExtension(textBox_cmd.Text).ToUpper())
                        {
                            case ".EXE":
                                i = textBox_cmd.Text;
                                break;
                            default:
                                i = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\Imageres.dll,63";
                                break;
                        }
                        SendTo_OpenByProgram(textBox_cmd.Text, textBox_arg.Text, textBox_name.Text, checkBox1.Checked,i);
                        MyFunctions.Dialogs.MessageDialog("成功新建菜单", @"成功新建了""" + textBox_name.Text + @"""的菜单", MyFunctions.Dialogs.MessageDialogIcon.Information , "", "b2", false, true, "", "确定");
                        this.Dispose();
                    }
                    else
                    {
                        if (textBox_name.Text == "") { label7.Visible = true; } else { label7.Visible = false; }
                        if (System.IO.File.Exists(textBox_cmd.Text) == true) { label14.Visible = false; } else { label14.Visible = true; }
                        if (System.IO.Path.GetExtension(textBox_cmd.Text).ToUpper() == ".EXE") { label14.Visible = false; } else { label14.Visible = true; }
                        if (System.IO.Path.GetExtension(textBox_cmd.Text).ToUpper() == ".BAT") { label14.Visible = false; } else { label14.Visible = true; }
                        if (System.IO.Path.GetExtension(textBox_cmd.Text).ToUpper() == ".CMD") { label14.Visible = false; } else { label14.Visible = true; }
                    }
                    break;
            }
        }
    }
}
