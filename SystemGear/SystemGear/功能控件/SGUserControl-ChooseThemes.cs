using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear.窗体UI
{
    public partial class UserControl_ChooseThemes : UserControl
    {
        List<string> skins_files = new List<string>();
        int currentindex = 0;
        SGForm_Function_SystemStyle sgfrm; SystemGear.窗体.SGForm_Main mainfrm;
        public UserControl_ChooseThemes(SGForm_Function_SystemStyle sgfrm,SystemGear.窗体.SGForm_Main mainfrm)
        {
            InitializeComponent();
            this.loadinstalledskins();
            this.sgfrm =sgfrm;
            this.mainfrm =mainfrm;
            this.DrawSkin();
        }
        public void DrawSkin()
        {
            SGFunction.Skins.DrawAllControlInTabControl(this.sgTabPageControl_allfunction);
            //SGFunction.Skins.DrawAllControlInUserControl(this, SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "BK"));
            sgTabPageControl_allfunction.Refresh();
        }
        private void myNormalButton1_Click(object sender, EventArgs e)
        {
            
        }
        private void loadinstalledskins()
        {
            
            flowLayoutPanel_installedskins.Controls.Clear();
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\skins.sgcf";
            string[] values;
            string[] keys;
            int count = SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("installedskins", out keys, out values, cfg, true);
            //获取当前的主题文件
            string currentskinfile_file = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("main", "select_skin", "", cfg, true);
            string currentskinfile_name = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", "name", "", currentskinfile_file, false);
            if(count >=1)
            {
                for(int o=1;o<=count;o++)
                {
                    string skincfg=values[o - 1];
                    string skincfg_old = skincfg;
                    skincfg = SGFunction.PathOperate.ConvertStringToTurePath(skincfg, skincfg);
                    string skin_name = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", "name", "", skincfg, true);
                    string skin_color_str = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", "color_default", "", skincfg, true);
                    Color skin_color_rgb = SGFunction.ColorOperate.GetColorFromStr(skin_color_str);
                    Image skin_selectimg_image = null;
                    string skin_selectimg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("skins")+"\\"+SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("info", "select_showimages", "", skincfg, false);
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(skin_selectimg) == true) 
                    {
                        try
                        {
                            skin_selectimg_image = Image.FromFile(skin_selectimg);
                        }
                        catch { skin_selectimg_image = null; }
                    }
                    Panel pan = new Panel();
                    MyNormalButton my = new MyNormalButton();
                    SGLabel lab = new SGLabel();
                    /////
                    pan.Size = new Size(189, 135);
                    ////
                    lab.AutoSize = false;
                    lab.TextAlign = ContentAlignment.MiddleCenter;
                    lab.ForeColor = skin_color_rgb;
                    lab.Text = skin_name;
                    lab.Font = new System.Drawing.Font("微软雅黑", 9f, FontStyle.Bold);
                    /////
                    pan.Controls.Add(lab);
                    /////
                    lab.Dock = DockStyle.Bottom;
                    ///////////
                    my.Size = new System.Drawing.Size(189, 115);
                    my.Location = new Point(0, 0);
                    my.BackgroundImage = skin_selectimg_image;

                    pan.Controls.Add(my);
                    flowLayoutPanel_installedskins.Controls.Add(pan);
                    //eent
                    pan.MouseMove += new MouseEventHandler(this.Panel_MouseMove);
                    pan.MouseLeave += new EventHandler(this.Panel_MouseLeave);
                    lab.MouseLeave += new EventHandler(SGLabel_MouseLeave);
                    lab.MouseMove += new MouseEventHandler(SGLabel_MouseMove);
                    //my.MouseMove +=new MouseEventHandler(this.Button_MouseMove );
                   // my.MouseLeave +=new EventHandler(this.Button_MouseLeave );
                    my.Click += new EventHandler(this.Button_MouseClick);
                    lab.Click += new EventHandler(this.SgLabel_MouseClick);
                    int panindex = flowLayoutPanel_installedskins.Controls.Count - 1;
                    //is current
                    if (skin_name.ToUpper() == currentskinfile_name.ToUpper())
                    {
                        my.Image = SystemGear.Properties.Resources.SkinSelected;
                        //top tip
                        this.toolTip1.SetToolTip(my, @"您已经选择该主题：""" + skin_name + @"""");
                        this.toolTip1.SetToolTip(pan, @"您已经选择该主题：""" + skin_name + @"""");
                        this.toolTip1.SetToolTip(lab, @"您已经选择该主题：""" + skin_name + @"""");
                        currentindex = panindex;
                    }
                    else { 
                        my.Image = null;
                        //top tip
                        this.toolTip1.SetToolTip(my, @"单击左键选择该主题：""" + skin_name + @"""");
                        this.toolTip1.SetToolTip(pan, @"单击左键选择该主题：""" + skin_name + @"""");
                        this.toolTip1.SetToolTip(lab, @"单击左键选择该主题：""" + skin_name + @"""");
                    }
                    my.Cursor = Cursors.Hand;
                    pan.Cursor = Cursors.Hand;
                    lab.Cursor = Cursors.Hand;
                    //TAG
                    
                    my.Tag = panindex;
                     lab.Tag = panindex;
                    skins_files.Add(skincfg_old);
                }
            }
            else
            {
                //no installed
            }
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            Panel pan = (Panel)sender;
            pan.BackColor = Color.FromArgb(240, 240, 240);
        }
        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel pan = (Panel)sender;
            pan.BackColor = Color.White;
        }
        private void SGLabel_MouseMove(object sender, MouseEventArgs e)
        {
            SGLabel pan = (SGLabel)sender;
            pan.BackColor = Color.FromArgb(240,240,240);
        }
        private void SGLabel_MouseLeave(object sender, EventArgs e)
        {
            SGLabel  pan = (SGLabel)sender;
            pan.BackColor = Color.White;
        }
        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            MyNormalButton pan = (MyNormalButton)sender;
            object g = pan.Tag;
            if(g !=null)
            {
                int hj = (int)g;
                Control oo = flowLayoutPanel_installedskins.Controls[hj];
                Panel ooo = (Panel)oo;
                ooo.BackColor = Color.FromArgb(240, 240, 240);
            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            MyNormalButton pan = (MyNormalButton)sender;
            object g = pan.Tag;
            if (g != null)
            {
                int hj = (int)g;
                Control oo = flowLayoutPanel_installedskins.Controls[hj];
                Panel ooo = (Panel)oo;
                ooo.BackColor = Color.White;
            }
        }
        private void Button_MouseClick(object sender, EventArgs e)
        {
            MyNormalButton pan = (MyNormalButton)sender;
            if (pan.Image != null) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("您已经选择该主题了哦",2); return; }
            object g = pan.Tag;
            if (g != null)
            {
                int hj = (int)g;
                
                string skfile = skins_files[hj];
                string skfile_old = skfile;
                skfile = SGFunction.PathOperate.ConvertStringToTurePath(skfile, skfile);
                SGFunction.Skins._SKINSCONFIG = skfile;
                //MessageBox.Show(skfile);
                if (sgfrm != null)
                {
                    if(mainfrm ==null)
                    {
                        SGSystemStyle.LoadSkin.LoadColorSetting(sgfrm);
                        sgfrm.sgItems1.Settings_ChooseItemsIndex = sgfrm.sgItems1.Settings_ChooseItemsIndex;
                    }
                    else
                    {
                        SGSystemStyle.LoadSkin.LoadColorSetting(sgfrm);
                        SystemGear.类或代码.SGMain.Skins.LoadSkins(mainfrm);
                        mainfrm.sgItems1.Settings_ChooseItemsIndex = mainfrm.sgItems1.Settings_ChooseItemsIndex;
                        sgfrm.sgItems1.Settings_ChooseItemsIndex = sgfrm.sgItems1.Settings_ChooseItemsIndex;
                        //绘制ALLFUNCTION 防止颜色出错
                        SystemGear.类或代码.SGMain.Skins.DrawAllClassFunctionsTile(mainfrm);

                    }
                    //绘制颜色 重新修改配置
                    Form ff = this.FindForm();
                    SystemGear.窗体.SGForm_GuidDialog gg = (SystemGear.窗体.SGForm_GuidDialog)ff;
                    //MessageBox.Show(gg.Text);
                    gg.DrawSkin();
                    this.DrawSkin();
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\skins.sgcf";
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("main", "select_skin", skfile_old, "Config", false, cfg);
                    this.loadinstalledskins();
                }
                else
                {
                    if (sgfrm == null)
                    {
                        if (mainfrm == null)
                        {
                            //SGSystemStyle.LoadSkin.LoadColorSetting(sgfrm);
                            ///SystemGear.类或代码.SGMain.Skins.LoadSkins(mainfrm);
                        }
                        else
                        {
                            //SGSystemStyle.LoadSkin.LoadColorSetting(sgfrm);
                            SystemGear.类或代码.SGMain.Skins.LoadSkins(mainfrm);
                            mainfrm.sgItems1.Settings_ChooseItemsIndex = mainfrm.sgItems1.Settings_ChooseItemsIndex;
                            //mainfrm.sgTabPageControl_allfunction.SelectedIndex = 0;
                            //mainfrm.RUNONCE_ALLFUNCTION = false;
                            //绘制ALLFUNCTION 防止颜色出错
                            SystemGear.类或代码.SGMain.Skins.DrawAllClassFunctionsTile(mainfrm);
                            //绘制颜色 重新修改配置
                            Form ff=this.FindForm();
                            SystemGear.窗体.SGForm_GuidDialog gg = (SystemGear.窗体.SGForm_GuidDialog)ff;
                            //MessageBox.Show(gg.Text);
                            gg.DrawSkin();
                            this.DrawSkin();
                            string cfg=SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\skins.sgcf";
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("main", "select_skin", skfile_old, "Config", false, cfg);
                            this.loadinstalledskins();
                        }
                    }
                }
            }
        }
        private void SgLabel_MouseClick(object sender, EventArgs e)
        {
            SGLabel  pan = (SGLabel)sender;
            
            object g = pan.Tag;
            if (g != null)
            {
                int hj = (int)g;
                if (hj==currentindex ) { SGFunction.CommonDialogs.MessageDialog_ShowInfo("您已经选择该主题了哦", 2); return; }
                string skfile = skins_files[hj];
                string skfile_old = skfile;
                skfile = SGFunction.PathOperate.ConvertStringToTurePath(skfile, skfile);
                SGFunction.Skins._SKINSCONFIG = skfile;
                //MessageBox.Show(skfile);
                if (sgfrm != null)
                {
                    if (mainfrm == null)
                    {
                        SGSystemStyle.LoadSkin.LoadColorSetting(sgfrm);
                        sgfrm.sgItems1.Settings_ChooseItemsIndex = sgfrm.sgItems1.Settings_ChooseItemsIndex;
                    }
                    else
                    {
                        SGSystemStyle.LoadSkin.LoadColorSetting(sgfrm);
                        SystemGear.类或代码.SGMain.Skins.LoadSkins(mainfrm);
                        mainfrm.sgItems1.Settings_ChooseItemsIndex = mainfrm.sgItems1.Settings_ChooseItemsIndex;
                        sgfrm.sgItems1.Settings_ChooseItemsIndex = sgfrm.sgItems1.Settings_ChooseItemsIndex;
                        //绘制ALLFUNCTION 防止颜色出错
                        SystemGear.类或代码.SGMain.Skins.DrawAllClassFunctionsTile(mainfrm);

                    }
                    //绘制颜色 重新修改配置
                    Form ff = this.FindForm();
                    SystemGear.窗体.SGForm_GuidDialog gg = (SystemGear.窗体.SGForm_GuidDialog)ff;
                    //MessageBox.Show(gg.Text);
                    gg.DrawSkin();
                    this.DrawSkin();
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\skins.sgcf";
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("main", "select_skin", skfile_old, "Config", false, cfg);
                    this.loadinstalledskins();
                }
                else
                {
                    if (sgfrm == null)
                    {
                        if (mainfrm == null)
                        {
                            //SGSystemStyle.LoadSkin.LoadColorSetting(sgfrm);
                            ///SystemGear.类或代码.SGMain.Skins.LoadSkins(mainfrm);
                        }
                        else
                        {
                            //SGSystemStyle.LoadSkin.LoadColorSetting(sgfrm);
                            SystemGear.类或代码.SGMain.Skins.LoadSkins(mainfrm);
                            mainfrm.sgItems1.Settings_ChooseItemsIndex = mainfrm.sgItems1.Settings_ChooseItemsIndex;
                            //mainfrm.sgTabPageControl_allfunction.SelectedIndex = 0;
                            //mainfrm.RUNONCE_ALLFUNCTION = false;
                            //绘制ALLFUNCTION 防止颜色出错
                            SystemGear.类或代码.SGMain.Skins.DrawAllClassFunctionsTile(mainfrm);
                            //绘制颜色 重新修改配置
                            Form ff = this.FindForm();
                            SystemGear.窗体.SGForm_GuidDialog gg = (SystemGear.窗体.SGForm_GuidDialog)ff;
                            //MessageBox.Show(gg.Text);
                            gg.DrawSkin();
                            this.DrawSkin();
                            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\skins.sgcf";
                            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("main", "select_skin", skfile_old, "Config", false, cfg);
                            this.loadinstalledskins();
                        }
                    }
                }
            }
        }

        private void UserControl_ChooseThemes_Load(object sender, EventArgs e)
        {

        }
    }
}
