using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear.功能控件
{
    public partial class SGUserControl_AddAndEditWinXMenu : UserControl
    {
        string type, gr, lnkn;
        SGForm_Function_SystemStyle ff;
        public SGUserControl_AddAndEditWinXMenu(string ty,string gr,string lnkn,SGForm_Function_SystemStyle S,string name="")
        {
            InitializeComponent();
            SGFunction.Skins.DrawAllControlInUserControl(this, SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "BK"));
            this.type = ty;
            this.ff = S;
            this.gr = gr;
            this.lnkn = lnkn;
            if(ty=="edit")
            {
                //MessageBox.Show(name);
                sgTextBox1.Text = name;
                string cmd = SGFunction.SystemFunctionAndInformation.ReadLink(lnkn, "path");
                string arg = SGFunction.SystemFunctionAndInformation.ReadLink(lnkn, "args");
                sgTextBox2.Text = cmd;
                sgTextBox3.Text = arg;
                sgCheckBox1.Visible = false;
                sgCheckBox1.Checked = false;
            }
        }

        private void MyNormalButton5_Click(object sender, EventArgs e)
        {
            string file = SGFunction.CommonDialogs.OpenFileDialog("选择文件", "所有文件(*.*)|*.*");
            if (file != "")
            {
                sgTextBox2.Text = file;
                System.IO.FileInfo fi = new System.IO.FileInfo(file);
                sgCheckBox1.Visible = true;
            }
        }

        private void SGUserControl_AddAndEditWinXMenu_Load(object sender, EventArgs e)
        {

        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            if (sgTextBox1.Text != "" && sgTextBox2.Text != "")
            {
                if (type == "create")
                {
                    this.createwinxmenu();
                }
                else
                {
                    this.editwinxmenu();
                }
            }
            else { 
                //SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法创建：您没有指定名称或者命令。", 2); 
                if (sgTextBox1.Text == "") { sgTextBox1.DoError("你需要输入这个菜单的完整名称哦"); }
                if (sgTextBox2.Text == "") { sgTextBox2.DoError("你需要输入这个菜单所执行命令哦"); }
            }
        }
        void createwinxmenu()
        {
            string name = sgTextBox1.Text;
            string cmd = sgTextBox2.Text;
            string arg = sgTextBox3.Text;
            string lnkfile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Windows\WinX\"+gr +"\\"+name+".lnk";
            //MessageBox.Show(lnkfile);
            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(lnkfile)==true)
            {
                SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnkfile);
                if (sgCheckBox1.Checked == true)
                {
                    string ado = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + "\\admin.lnk.sgo";
                    SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(ado, lnkfile);
                    SGFunction.SystemFunctionAndInformation.SetLink(lnkfile, "Path", cmd);
                    SGFunction.SystemFunctionAndInformation.SetLink(lnkfile, "args", arg);
                    SGFunction.SystemFunctionAndInformation.HashLinkInWin8(lnkfile);
                }
                else
                {
                    SGFunction.SystemFunctionAndInformation.CreateLink(lnkfile, cmd, arg, "");
                    SGFunction.SystemFunctionAndInformation.HashLinkInWin8(lnkfile);
                }
            }
            else
            {
                if(sgCheckBox1.Checked ==true)
                {
                    string ado = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + "\\admin.lnk.sgo";
                    SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(ado, lnkfile);
                    SGFunction.SystemFunctionAndInformation.SetLink(lnkfile, "Path", cmd);
                    SGFunction.SystemFunctionAndInformation.SetLink(lnkfile,"args", arg);
                    SGFunction.SystemFunctionAndInformation.HashLinkInWin8(lnkfile);
                }
                else
                {
                    SGFunction.SystemFunctionAndInformation.CreateLink(lnkfile, cmd, arg, "");
                    SGFunction.SystemFunctionAndInformation.HashLinkInWin8(lnkfile);
                }
            }
            //RELOAD
            SGFunction.SystemFunctionAndInformation.ReStartExplorer();
            SGSystemStyle.Win8Style.WinXMenu.SystemStyle_LoadWinXMenu(ff);
            this.Dispose();
        }
        void editwinxmenu()
        {
            string name = sgTextBox1.Text;
            string cmd = sgTextBox2.Text;
            string arg = sgTextBox3.Text;
            string lnkfile = lnkn;
            //MessageBox.Show(lnkfile);
            if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(lnkfile) == true)
            {
                //SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnkfile);
                if (sgCheckBox1.Checked == true)
                {
                    string ado = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("programs") + "\\admin.lnk.sgo";
                    SGFunction.FileSystemOperate.FileSystemOperate_CopyFile(ado, lnkfile,true);
                    SGFunction.SystemFunctionAndInformation.SetLink(lnkfile, "Path", cmd);
                    SGFunction.SystemFunctionAndInformation.SetLink(lnkfile, "args", arg);
                    SGFunction.SystemFunctionAndInformation.SetLink(lnkfile, "info", name);
                    SGFunction.SystemFunctionAndInformation.HashLinkInWin8(lnkfile);
                }
                else
                {
                    SGFunction.SystemFunctionAndInformation.SetLink(lnkfile, "path", cmd);
                    SGFunction.SystemFunctionAndInformation.SetLink(lnkfile, "args", arg);
                    SGFunction.SystemFunctionAndInformation.SetLink(lnkfile, "info", name);
                    SGFunction.SystemFunctionAndInformation.HashLinkInWin8(lnkfile);
                }
            }
            //RELOAD
            SGFunction.SystemFunctionAndInformation.ReStartExplorer();
            SGSystemStyle.Win8Style.WinXMenu.SystemStyle_LoadWinXMenu(ff);
            this.Dispose();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sgTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            string res;
            string[] arr = SGFunction.CommonDialogs.ShowMoreFunctionDialog("选择常用的操作", out res);
            if (res == "ok")
            {
                string name = arr[0];
                string app = arr[1];
                string arg = arr[2];
                string admin = arr[4];
                sgTextBox1.Text = name;
                sgTextBox2.Text = app;
                sgTextBox3.Text = arg;
                if (admin.ToUpper() == "TRUE") { sgCheckBox1.Checked = true; } else { sgCheckBox1.Checked = false; }
            }
        }
    }
}
