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
    public partial class SGUserControl_EditMainTile : UserControl
    {
        string h;
        string jie;
        string tiletype;
        SGModernButton btn;
        SGModernButton selectbtn;
        SystemGear.窗体.SGForm_Main main;
        string _orgico = "";
        public SGUserControl_EditMainTile(string h,string jie,string tiletype,SGModernButton b,SystemGear.窗体.SGForm_Main m)
        {
            InitializeComponent();
            //SKIN
            SGFunction.Skins.DrawAllControlInUserControl(this, SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "BK"));
            //MyNormalButton2.ForeColor = MyNormalButton3.ForeColor = MyNormalButton4.ForeColor = MyNormalButton5.ForeColor = MyNormalButton6.ForeColor = MyNormalButton1.ForeColor = MyNormalButton11.ForeColor = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "fr");
            //MyNormalButton2.BackColor = MyNormalButton3.BackColor = MyNormalButton4.BackColor = MyNormalButton5.BackColor = MyNormalButton6.BackColor =MyNormalButton1.BackColor =MyNormalButton11.BackColor =SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "bk");
           // this.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("dialog_standard", "bk");
           // sgLabel2.ForeColor = sgLabel3.ForeColor = sgLabel4.ForeColor = sgLabel4.ForeColor  = sgLabel5.ForeColor = sgLabel6.ForeColor = sgLabel7.ForeColor = sgLabel8.ForeColor = sgLabel9.ForeColor = SGFunction.Skins.Skins_GetControlColorSetting("LAB_MAININFO", "FR");
           // sgLabel1.ForeColor = SGFunction.Skins.Skins_GetControlColorSetting("LABEL_FUNINFO", "FR");
           // MyNormalButton132.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "bk");
           // sgTextBox_bakcimge.ForeColor = sgTextBox_infotip.ForeColor = sgTextBox_logo36.ForeColor = sgTextBox_logo36_x.ForeColor = sgTextBox_logo72.ForeColor = sgTextBox_name.ForeColor = sgTextBox_shell.ForeColor = SGFunction.Skins.Skins_GetControlColorSetting("TEXTBOX", "FR");
            //COIDE
            this.h = h;
            this.jie = jie;
            this.tiletype = tiletype;
            btn = b;
            main = m;
            //读取信息
            //定义样式
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\MainTile.sgcf";
            string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(h, jie, "", cfg, false);
            /////
            switch(tiletype )
            {
                case "L":
                    myModernButton_L.Visible = true;
                    myModernButton_L.Location = new Point(7,29);
                    panel_L.Visible = true;
                    panel_L.Location = panel_usu.Location;
                    panel_usu.Visible = false;
                    LoadMainTile(myModernButton_L, tiletype, read);
                    selectbtn = myModernButton_L;
                    break;
                case "K":
                    myModernButton_K.Visible = true;
                    myModernButton_K.Location = new Point(7, 29);
                    panel_usu.Visible = true;
                    panel_L.Visible = false;
                    LoadMainTile(myModernButton_K, tiletype, read);
                    selectbtn = myModernButton_K;
                    break;
                case "Z":
                    myModernButton_Z.Visible = true;
                    myModernButton_Z.Location = new Point(7, 29);
                    panel_usu.Visible = true;
                    panel_L.Visible = false;
                    LoadMainTile(myModernButton_Z, tiletype, read);
                    selectbtn = myModernButton_Z;
                    break;
                case "X":
                    myModernButton_X.Visible = true;
                    myModernButton_X.Location = new Point(7, 29);
                    panel_usu.Visible = false;panel_X.Visible =true;
                    panel_X.Location = panel_usu.Location;
                    panel_L.Visible = false;
                    LoadMainTile(myModernButton_X, tiletype, read);
                    selectbtn = myModernButton_X;
                    break;
            }
        }
        public  void LoadMainTile(SGModernButton m, string type, string read)
        {
            try
            {
                string[] re = read.Split('|');
                string name = "";
                string infotip = "";
                string shellindex = "";
                string backcolor = "0,148,255";
                string ico = "";
                string logo72 = "";
                string logo36 = "";
                string backimage = "";
                //读取
                switch (type.ToUpper())
                {
                    case "X":
                        if (re.Length == 6)
                        {
                            name = re[0];
                            infotip = re[1];
                            shellindex = re[2];
                            backcolor = re[3];
                            ico = re[4];
                            logo36 = re[5];
                            //name = SGFunction.PathOperate.ConvertStringToTurePath(name, name);
                            infotip = SGFunction.PathOperate.ConvertStringToTurePath(infotip, infotip);
                            //if (name != "") { m.ButtonText = name; }
                            if (infotip != "") { this.toolTip1.SetToolTip(m, infotip); }
                            if (shellindex != "") { m.Tag = shellindex; }
                            if (backcolor != "") { m.ButtonBackColor = m.ButtonBackPageColor = SGFunction.ColorOperate.GetColorFromStr(backcolor); }
                            if (logo36 != "") { m.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode(logo36); }
                            m.ButtonType = SGModernButton.ButtonStyle.NormalWithoutBackPage;
                            m.BackgroundImageLayout = ImageLayout.Center; 
                            //样式
                            sgTextBox_name.Text = name;
                            sgTextBox_infotip.Text = infotip;
                            sgTextBox_shell.Text = shellindex;
                            MyNormalButton_backcolor.BackColor = SGFunction.ColorOperate.GetColorFromStr(backcolor);
                            sgTextBox_logo36_x.Text = logo36;
                        }
                        break;
                    case "L":
                        if (re.Length == 7)
                        {
                            name = re[0];
                            infotip = re[1];
                            shellindex = re[2];
                            backcolor = re[3];
                            ico = re[4];
                            logo36 = re[5];
                            backimage = re[6];
                            name = SGFunction.PathOperate.ConvertStringToTurePath(name, name);
                            infotip = SGFunction.PathOperate.ConvertStringToTurePath(infotip, infotip);
                            if (name != "") { m.ButtonText = name; }
                            if (infotip != "") { this.toolTip1.SetToolTip(m, infotip); }
                            if (shellindex != "") { m.Tag = shellindex; }
                            if (backcolor != "") { m.ButtonBackColor =m.ButtonBackPageColor = SGFunction.ColorOperate.GetColorFromStr(backcolor); }
                            if (logo36 != "") { m.ButtonSmallLogo = SGFunction.Resources.GetImageFromResourcesCode(logo36); }
                            m.ButtonType = SGModernButton.ButtonStyle.NormalWithLogo;
                            if (backimage != "") { m.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode(backimage); m.BackgroundImageLayout = ImageLayout.Stretch; }
                            //样式
                            sgTextBox_name.Text = name;
                            sgTextBox_infotip.Text = infotip;
                            sgTextBox_shell.Text = shellindex;
                            MyNormalButton_backcolor.BackColor = SGFunction.ColorOperate.GetColorFromStr(backcolor);
                            sgTextBox_logo36.Text = logo36;
                            sgTextBox_bakcimge.Text = backimage;
                        }
                        break;
                    case "Z":
                    case "K":
                        if (re.Length == 6)
                        {
                            name = re[0];
                            infotip = re[1];
                            shellindex = re[2];
                            backcolor = re[3];
                            ico = re[4];
                            logo72 = re[5];
                            name = SGFunction.PathOperate.ConvertStringToTurePath(name, name);
                            infotip = SGFunction.PathOperate.ConvertStringToTurePath(infotip, infotip);
                            if (name != "") { m.ButtonText = name; }
                            if (infotip != "") { this.toolTip1.SetToolTip(m, infotip); }
                            if (shellindex != "") { m.Tag = shellindex; }
                            if (backcolor != "") { m.ButtonBackColor = SGFunction.ColorOperate.GetColorFromStr(backcolor); }
                            //bMessageBox.Show(m.ButtonBackColor.ToString());
                            //if (backimage != "") { m.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode(backimage); m.BackgroundImageLayout = ImageLayout.Stretch; } else { m.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode("IconAndLinkMgr_72x72"); m.BackgroundImageLayout = ImageLayout.Center; }
                            if (logo72 != "") { m.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode(logo72); m.BackgroundImageLayout = ImageLayout.Center; }
                            //样式
                            sgTextBox_name.Text = name;
                            sgTextBox_infotip.Text = infotip;
                            sgTextBox_shell.Text = shellindex;
                            MyNormalButton_backcolor.BackColor = SGFunction.ColorOperate.GetColorFromStr(backcolor);
                            sgTextBox_logo72.Text = logo72;
                        }
                        break;
                }
                this._orgico = ico;
            }
            catch { }
        }
        private void SGUserControl_EditMainTile_Load(object sender, EventArgs e)
        {
            //this.Size = new Size(659, 305);
        }

        private void MyNormalButton4_Click(object sender, EventArgs e)
        {
            string res;
            string[] pp=SGFunction.CommonDialogs.ChooseSGFunction("选择您常用的功能并固定到主界面上", true,out res,false);
            if(res=="ok")
            {
                sgTextBox_infotip.Text = SGFunction.PathOperate.ConvertStringToTurePath(pp[1], pp[1]);
                sgTextBox_name.Text  = SGFunction.PathOperate.ConvertStringToTurePath(pp[0], pp[0]);
                //ChangeInfo_Name(pp[0]);
                //ChangeInfo_InfoTip(pp[1]);
                ChangeInfo_Command(pp[2]);
                ChangeInfo_Logo36(pp[3]);
                ChangeInfo_Logo72(pp[4]);
                _orgico = pp[5];
                if (tiletype == "L") { selectbtn.ButtonType = SGModernButton.ButtonStyle.NormalWithLogo; }
                if (tiletype == "X") { selectbtn.ButtonType = SGModernButton.ButtonStyle.NormalWithoutBackPage; }
            }
        }
        void ChangeInfo_Name(string str)
        {
            //sgTextBox_name.Text = str;
            if(tiletype !="X")
            {
                selectbtn.ButtonText = str;
            }
        }
        void ChangeInfo_InfoTip(string str)
        {
           // sgTextBox_infotip.Text = str;
            toolTip1.SetToolTip(selectbtn, str);
        }
        void ChangeInfo_Command(string str)
        {
            sgTextBox_shell.Text = str;
        }
        void ChangeInfo_Logo36(string str)
        {
           switch(tiletype )
           {
               case "L":
                   selectbtn.ButtonSmallLogo = SGFunction.Resources.GetImageFromResourcesCode(str);
                   sgTextBox_logo36.Text = str;
                   break;
               case "X":
                   selectbtn.BackgroundImageLayout = ImageLayout.Center;
                   selectbtn.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode(str);
                   sgTextBox_logo36_x.Text = str;
                   break;
           }
        }
        void ChangeInfo_Logo72(string str)
        {
            switch (tiletype)
            {
                case "Z":
                case "K":
                    selectbtn.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode(str);
                    sgTextBox_logo72.Text = str;
                    break;
            }
        }
        void ChangeInfo_BackImage(string codeorfile)
        {
            selectbtn.BackgroundImage = SGFunction.Resources.GetImageFromResourcesCode(codeorfile);
            sgTextBox_bakcimge.Text = codeorfile;
        }
        void ChangeInfo_BackColor(Color back)
        {
            switch (tiletype)
            {
                case "L":
                    selectbtn.ButtonBackPageColor = back;
                    selectbtn.ButtonBackColor = back;
                    break;
                case "X":
                case "K":
                case "Z":
                    selectbtn.ButtonBackColor = back;
                    break;
            }
        }

        private void MyNormalButton5_Click(object sender, EventArgs e)
        {
            string d = SGFunction.CommonDialogs.OpenFileDialog("选择图片文件", "image");
            if(d!="")
            {
                ChangeInfo_Logo72(d);
            }
        }

        private void MyNormalButton6_Click(object sender, EventArgs e)
        {
            string d = SGFunction.CommonDialogs.OpenFileDialog("选择图片文件", "image");
            if (d != "")
            {
                ChangeInfo_Logo36(d);
            }
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {
            string d = SGFunction.CommonDialogs.OpenFileDialog("选择图片文件", "image");
            if (d != "")
            {
                ChangeInfo_BackImage(d);
            }
        }

        private void MyNormalButton11_Click(object sender, EventArgs e)
        {
            ChangeInfo_BackImage("Desktopwallpaper");
        }

        private void MyNormalButton_backcolor_Click(object sender, EventArgs e)
        {
            Color c = SGFunction.CommonDialogs.ColorDialog(MyNormalButton_backcolor.BackColor);
            if(c!=MyNormalButton_backcolor.BackColor)
            {
                MyNormalButton_backcolor.BackColor = c;
                ChangeInfo_BackColor(c);
            }
        }

        private void sgTextBox_name_TextChanged(object sender, EventArgs e)
        {
            if(selectbtn !=null)
            {
                ChangeInfo_Name(sgTextBox_name.Text);
                //MessageBox.Show("");
            }
        }

        private void sgTextBox_infotip_TextChanged(object sender, EventArgs e)
        {
            if(selectbtn !=null)
            {
                ChangeInfo_InfoTip(sgTextBox_infotip.Text);
            }
        }

        private void sgTextBox_shell_TextChanged(object sender, EventArgs e)
        {

        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(h + "\r\n" + jie);
            if (sgTextBox_name.Text != "")
            {
                this.WriteSetting(sgTextBox_name.Text, sgTextBox_infotip.Text, sgTextBox_shell.Text, MyNormalButton_backcolor.BackColor, sgTextBox_logo36.Text, sgTextBox_logo72.Text, _orgico,sgTextBox_logo36_x.Text, sgTextBox_bakcimge.Text);
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功自定义了您常用的磁贴", 2);
                this.Dispose();
            }
            else { 
                //SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法自定义您常用的磁贴，因为您没有输入正确的名称。", 2); 
                sgTextBox_name.DoError("您似乎没有输入您常用磁贴的名称哦");
            }
            
        }
        private void WriteSetting(string name, string infotip, string shell, Color backcolor, string logo36, string logo72, string ico, string x_logo36="",string backimg = "desktopwallpaper")
        {
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\MAINTILE.SGCF";
            string wr = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(h, jie, "", cfg, false);
            switch (tiletype)
            {
                case "L":
                    string bc = backcolor.R.ToString() + "," + backcolor.G.ToString() + "," + backcolor.B.ToString();
                    wr = name + "|" + infotip + "|" + shell + "|" + bc + "|" + ico + "|" + logo36 + "|" + backimg;
                    break;
                case "K":
                case "Z":
                    string bc1 = backcolor.R.ToString() + "," + backcolor.G.ToString() + "," + backcolor.B.ToString();
                    wr = name + "|" + infotip + "|" + shell + "|" + bc1 + "|" + ico + "|" + logo72;
                    break;
                case "X":
                    string bc2 = backcolor.R.ToString() + "," + backcolor.G.ToString() + "," + backcolor.B.ToString();
                    wr = name + "|" + infotip + "|" + shell + "|" + bc2 + "|" + ico + "|" + x_logo36;
                    break;
            }
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue(h, jie, wr, "config", false, cfg);
            SystemGear.类或代码.SGMain.Load.LoadMainTile(btn, tiletype, wr, main);
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            string d = SGFunction.CommonDialogs.OpenFileDialog("选择图片文件", "image");
            if (d != "")
            {
                ChangeInfo_Logo36(d);
            }
        }

        private void MyNormalButton132_Click(object sender, EventArgs e)
        {
            if(sgTextBox_shell.Text !="")
            {
                string[] rs = SGFunction.ApplicationSetting.GetSGFunctionInfo(sgTextBox_shell.Text, true, false);
                string name = rs[0];
                string info = rs[1];
                string logo36 = rs[3];
                string logo72 = rs[4];
                switch(tiletype.ToUpper())
                {
                    case "L":
                        sgTextBox_infotip.Text = info;
                        sgTextBox_name.Text = name;
                        ChangeInfo_Logo36(logo36);
                        ChangeInfo_BackImage("DesktopWallpaper");
                        break;
                    case "K":
                    case "Z":
                        sgTextBox_infotip.Text = info;
                        sgTextBox_name.Text = name;
                        ChangeInfo_Logo72(logo72);
                        break;
                    case "X":
                        sgTextBox_infotip.Text = info;
                        ChangeInfo_Logo36(logo36);
                        break;
                }
                SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功还原了默认的设置。",2);
            }
        }
    }
}
