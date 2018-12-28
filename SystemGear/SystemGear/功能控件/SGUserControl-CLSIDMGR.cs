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
    public partial class SGUserControl_CLSIDMGR : UserControl
    {
        string type;
        SGForm_Function_SystemStyle ss;
        int selecindex;
        string cfg;
        string keyname;
        public SGUserControl_CLSIDMGR(string type,string cfg,SGForm_Function_SystemStyle s, int seleindex=0,string[] editinfo=null)
        {
            InitializeComponent();
            //SKIN
            SGFunction.Skins.DrawAllControlInTabControl(this.sgTabPageControl1);
            //this.panel1.BackColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "light");
            MyNormalButton2.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("BTN_OTHER", "BK");
            MyNormalButton2.ForeColor = SGFunction.Skins.Skins_GetControlColorSetting("BTN_OTHER", "fr");
            this.panel1.BackColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "light");
            //CODE
            this.type = type;
            ss = s;
            selecindex = seleindex;
            sgTabPageControl1.Location = new Point(-4,-39);
            this.cfg = cfg;
            switch(type.ToUpper())
            {
                case "CREATE_MENU":
                    sgTabPageControl1.SelectedIndex = 0;
                    break;
                case "EDIT":
                    sgTabPageControl1.SelectedIndex = 0;
                    if (editinfo != null) { if (editinfo.Length > 0) { keyname = editinfo[0]; } }
                    this.Load_EditCLSIDMenu(editinfo);
                    break;
                case "EDITMAIN":
                    sgTabPageControl1.SelectedIndex = 1;
                    this.Load_EditCLSIDMainMenu(editinfo);
                    break;
            }
        }

        private void MyNormalButton4_Click(object sender, EventArgs e)
        {
            string res;
            string[] c = SGFunction.CommonDialogs.ShowMoreFunctionDialog("选择要添加到菜单的操作", out res);
            if(res=="ok")
            {
                string name = c[0];
                string exe = c[1];
                string arg = c[2];
                string ico = c[3];
                bool adm=false;
                bool.TryParse(c[4], out adm);
                sgCheckBox_runas.Checked = adm;
                sgTextBox_name.Text = name;
                sgTextBox_cmd.Text = @""""+exe+@"""";
                sgTextBox_arg.Text = arg;
                sgTextBox_ico.Text = ico;
            }
        }

        private void MyNormalButton5_Click(object sender, EventArgs e)
        {
            string op = SGFunction.CommonDialogs.OpenFileDialog("选择文件", "所有文件(*.*)|*.*");
            if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(op )==true)
            {
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExtraName(op).ToUpper() == "EXE") { sgTextBox_ico.Text = op; }
                sgTextBox_cmd.Text = @""""+op+@"""";
            }
        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            string res;
            string ico = SGFunction.CommonDialogs.SelectIconDialog("选择菜单的图标", sgTextBox_ico.Text, out res);
            if (res == "ok" && ico != "")
            {
                sgTextBox_ico.Text = ico;
            }
        }
        void CreateNewCLSIDMenu(string cfg,string name,string ico,string cmd,string arg,bool runas)
        {
            try
            {
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == false) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("您的配置文件似乎不存在了，我们会尽快的解决问题。", 2); return; }
                int count;
                string rcou = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("MAININFO", "COUNT", "0", cfg, false);
                count = SGFunction.DataOperate.StringsToInt(rcou, 0);
                count = count + 1;
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(count.ToString(), "name", name, "CLSIDIcon_V1", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(count.ToString(), "icon", ico, "CLSIDIcon_V1", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(count.ToString(), "command", cmd, "CLSIDIcon_V1", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(count.ToString(), "arg", arg, "CLSIDIcon_V1", false, cfg);
                string R = "F"; if (runas == true) { R = "T"; }
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(count.ToString(), "runasadmin", R, "CLSIDIcon_V1", false, cfg);
                string reg = SGFunction.DataOperate.AddNumberInFirstInt32(0, count, 7);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(count.ToString(), "regname", reg, "CLSIDIcon_V1", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("maininfo", "count", count.ToString(), "CLSIDIcon_V1", false, cfg);
                string[] tag = new string[] { count.ToString(), reg, name, ico, cmd, arg, R };
                ss.sgTreeView_clsidicon.Nodes[0].Nodes.Add(name);
                ss.imageList_clsidicon.Images.Add(SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico));
                int ui = ss.sgTreeView_clsidicon.Nodes[0].Nodes.Count - 1;
                ss.sgTreeView_clsidicon.Nodes[0].Nodes[ui].ImageIndex = ss.sgTreeView_clsidicon.Nodes[0].Nodes[ui].SelectedImageIndex = ss.imageList_clsidicon.Images.Count - 1;
                ss.sgTreeView_clsidicon.Nodes[0].Nodes[ui].Tag = tag;
                this.FindForm().Tag = "ok";
            }
            catch {  }
        }
        void Load_EditCLSIDMenu(string[] tag)
        {
            try
            {
               if(tag.Length ==7)
               {
                   string rindex = tag[0];
                   string regname = tag[1];
                   string name = tag[2];
                   string ico = tag[3];
                   string cmd = tag[4];
                   string arg = tag[5];
                   string rua = tag[6];
                   sgTextBox_name.Text = name;
                   sgTextBox_arg.Text = arg;
                   sgTextBox_cmd.Text = cmd;
                   sgTextBox_ico.Text = ico;
                   if (rua.ToUpper() == "T") { sgCheckBox_runas.Checked = true; } else { sgCheckBox_runas.Checked = false; }
                   keyname = rindex;
               }
            }
            catch { }
        }
        void Load_EditCLSIDMainMenu(string[] tag)
        {
            try
            {
                if (tag.Length == 3)
                {
                    string name = tag[1];
                    string ico = tag[2];
                    sgTextBox_main_icon.Text = ico;
                    sgTextBox_main_name.Text = name;
                }
            }
            catch { }
        }
        void FinishEditCLSIDMenu(string cfg, string rname,string name, string ico, string cmd, string arg, bool runas,int selectindex)
        {
            try
            {
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == false) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("您的配置文件似乎不存在了，我们会尽快的解决问题。", 2); return; }
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(rname, "name", name, "CLSIDIcon_V1", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(rname, "icon", ico, "CLSIDIcon_V1", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(rname, "command", cmd, "CLSIDIcon_V1", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(rname, "arg", arg, "CLSIDIcon_V1", false, cfg);
                string reg = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(rname, "regname", "", cfg, false);
                string R = "F"; if (runas == true) { R = "T"; }
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(rname, "runasadmin", R, "CLSIDIcon_V1", false, cfg);
                string[] tag = new string[] { rname, reg, name, ico, cmd, arg, R };
                ss.sgTreeView_clsidicon.Nodes[0].Nodes[selecindex].Text = name;
                ss.imageList_clsidicon.Images[ss.sgTreeView_clsidicon.Nodes[0].Nodes[selecindex].ImageIndex] = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico);
                ss.sgTreeView_clsidicon.Nodes[0].Nodes[selecindex].Tag = tag;
                this.FindForm().Tag = "ok";
            }
            catch { }
        }
        void FinishEditCLSIDMainMenu(string cfg, string name, string ico)
        {
            try
            {
                if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg) == false) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("您的配置文件似乎不存在了，我们会尽快的解决问题。", 2); return; }
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("maininfo", "name", name, "CLSIDIcon_V1", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("maininfo", "icon", ico, "CLSIDIcon_V1", false, cfg);
                ss.sgTreeView_clsidicon.Nodes[0].Text = name;
                ss.imageList_clsidicon.Images[ss.sgTreeView_clsidicon.Nodes[0].ImageIndex] = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico);
                string[] tag = new string[] {"MAIN",name,ico };
                ss.sgTreeView_clsidicon.Nodes[0].Tag = tag;
                this.FindForm().Tag = "ok";
            }
            catch { }
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            if(type.ToUpper()=="EDITMAIN")
            {
                if (sgTextBox_main_icon.Text  != "" && sgTextBox_main_name.Text!= "")
                {
                    this.FinishEditCLSIDMainMenu(cfg, sgTextBox_main_name.Text, sgTextBox_main_icon.Text);
                    this.Dispose();
                }
                else { 
                    //SGFunction.CommonDialogs.MessageDialog_ShowInfo("您的填写的信息似乎不完整。请检查一下是否填写了名称或者图标。", 2); 
                    if (sgTextBox_cmd.Text == "") { sgTextBox_cmd.DoError("您似乎没有输入这个菜单的命令哦"); }
                    if (sgTextBox_name.Text == "") { sgTextBox_name.DoError("您似乎没有输入这个菜单的名称哦"); }
                }
            }
            else
            {
                if (sgTextBox_name.Text != "" && sgTextBox_cmd.Text != "")
                {
                    switch (type.ToLower())
                    {
                        case "create_menu":
                            this.CreateNewCLSIDMenu(cfg, sgTextBox_name.Text, sgTextBox_ico.Text, sgTextBox_cmd.Text, sgTextBox_arg.Text, sgCheckBox_runas.Checked);
                            this.Dispose();
                            break;
                        case "edit":
                            this.FinishEditCLSIDMenu(cfg, keyname, sgTextBox_name.Text, sgTextBox_ico.Text, sgTextBox_cmd.Text, sgTextBox_arg.Text, sgCheckBox_runas.Checked, selecindex);
                            this.Dispose();
                            break;
                    }
                }
                else { 
                   // SGFunction.CommonDialogs.MessageDialog_ShowInfo("您的填写的信息似乎不完整。请检查一下是否填写了名称或者命令。", 2);
                    if (sgTextBox_cmd.Text == "") { sgTextBox_cmd.DoError("您似乎没有输入这个菜单的命令哦"); }
                    if (sgTextBox_name.Text == "") { sgTextBox_name.DoError("您似乎没有输入这个菜单的名称哦"); }
                }

            }
            
        }

        private void SGUserControl_CLSIDMGR_Load(object sender, EventArgs e)
        {

        }

        private void MyNormalButton6_Click(object sender, EventArgs e)
        {
            string res;
            string ico = SGFunction.CommonDialogs.SelectIconDialog("选择菜单的图标", sgTextBox_main_icon.Text, out res);
            if (res == "ok" && ico != "")
            {
                sgTextBox_main_icon.Text = ico;
            }
        }
    }
}
