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
    public partial class Form_EditLink : Form
    {
        public string linkfile;
        public Form_EditLink()
        {
            InitializeComponent();
        }

        private void Form_EditLink_Load(object sender, EventArgs e)
        {

            if (System.IO.File.Exists(linkfile) == true)
            {
                this.Text = @"编辑快捷方式 """ + linkfile + @"""";
                textBox1.Text = MyFunctions.ProgramAndLinksOperate.ReadLink(linkfile, "path");
                textBox2.Text = MyFunctions.ProgramAndLinksOperate.ReadLink(linkfile, "args");
                textBox3.Text = MyFunctions.ProgramAndLinksOperate.ReadLink(linkfile, "icon");
                textBox4.Text = MyFunctions.ProgramAndLinksOperate.ReadLink(linkfile, "info");
                textBox5.Text = MyFunctions.ProgramAndLinksOperate.ReadLink(linkfile, "work");
                textBox6.Text = MyFunctions.ProgramAndLinksOperate.ReadLink(linkfile, "hotk");
                string type = MyFunctions.ProgramAndLinksOperate.ReadLink(linkfile, "ruty");
                switch (type)
                {
                    case "1":
                        comboBox1.SelectedIndex = 0;
                        break;
                    case "7":
                        comboBox1.SelectedIndex = 1;
                        break;
                    case "3":
                        comboBox1.SelectedIndex = 2;
                        break;
                }
            }
            else
            {
                MyFunctions.Dialogs.MessageDialog("无法修改快捷方式", "无法找到快捷方式", MyFunctions.Dialogs.MessageDialogIcon.Error, @"无法找到快捷方式""" + linkfile + @"""", "b2", false, true, "", "确定");
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyFunctions.Dialogs.FileAttDialog(linkfile);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] op = MyFunctions.Dialogs.ChooseOperateOrExploreFunctionDialog("ope");
                if (op.Length != null)
                {
                    textBox1.Text = op[1];
                    textBox2.Text = op[3];
                    textBox3.Text = op[2];
                    textBox5.Text = MyFunctions.FileSystemOperate.FileSystemOperate_GetFileLocation(textBox1.Text);
                    string runas = op[4];
                    if (runas == "T") { checkBox1.Checked = true; } else { checkBox1.Checked = false; }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = MyFunctions.Dialogs.OpenFileDialog("选择可执行文件", "可执行文件(*.exe)|*.exe");
            if (System.IO.File.Exists(file) == true)
            {
                textBox1.Text = file;
                textBox5.Text = MyFunctions.FileSystemOperate.FileSystemOperate_GetFileLocation(file);
                textBox3.Text = file;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string folder = MyFunctions.Dialogs.OpenFolder("选择文件夹");
            textBox5.Text = folder;
        }

        private void button190_Click(object sender, EventArgs e)
        {
            string ico = MyFunctions.Dialogs.ChooseIcon("选择图标文件", @"%windir%\system32\imageres.dll,2");
            if (ico != "")
            {
                textBox3.Text = ico;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox1.Text) == true)
            {
                label9.Visible = false;
                if (checkBox1.Checked == false)
                {
                    MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "path", textBox1.Text);
                    MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "args", textBox2.Text);
                    MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "work", textBox5.Text);
                    MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "icon", textBox3.Text);
                    MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "info", textBox4.Text);
                    MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "hotk", textBox6.Text);
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "type", "1");
                            break;
                        case 1:
                            MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "type", "7");
                            break;
                        case 2:
                            MyFunctions.ProgramAndLinksOperate.SetLink(linkfile, "type", "3");
                            break;
                    }
                    MyFunctions.Dialogs.MessageDialog("成功修改了快捷方式", "成功将指定的信息应用至快捷方式", MyFunctions.Dialogs.MessageDialogIcon.Information , @"成功修改了快捷方式""" + linkfile + @"""", "b2", false, true, "", "确定");
                    this.Close();
                }
                else
                {
                    //admin
                    string TEMP = Environment.GetEnvironmentVariable("TMP") + "\\AdminTemp.lnk";
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(Application.StartupPath + @"\programs\DefaultLink_Admin.lnk.sgo",TEMP);
                    MyFunctions.ProgramAndLinksOperate.SetLink(TEMP, "path", textBox1.Text);
                    MyFunctions.ProgramAndLinksOperate.SetLink(TEMP, "args", textBox2.Text);
                    MyFunctions.ProgramAndLinksOperate.SetLink(TEMP, "work", textBox5.Text);
                    MyFunctions.ProgramAndLinksOperate.SetLink(TEMP, "icon", textBox3.Text);
                    MyFunctions.ProgramAndLinksOperate.SetLink(TEMP, "info", textBox4.Text);
                    MyFunctions.ProgramAndLinksOperate.SetLink(TEMP, "hotk", textBox6.Text);
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            MyFunctions.ProgramAndLinksOperate.SetLink(TEMP, "type", "1");
                            break;
                        case 1:
                            MyFunctions.ProgramAndLinksOperate.SetLink(TEMP, "type", "7");
                            break;
                        case 2:
                            MyFunctions.ProgramAndLinksOperate.SetLink(TEMP, "type", "3");
                            break;
                    }
                    MyFunctions.FileSystemOperate.FileSystemOperate_CopyFile(TEMP, linkfile);
                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(TEMP);
                    MyFunctions.Dialogs.MessageDialog("成功修改了快捷方式", "成功将指定的信息应用至快捷方式", MyFunctions.Dialogs.MessageDialogIcon.Information , @"成功修改了快捷方式""" + linkfile + @"""", "b2", false, true, "", "确定");
                    this.Close();
                }
            }
            else
            {
                label9.Visible = true;
            }
        }
    }
}
