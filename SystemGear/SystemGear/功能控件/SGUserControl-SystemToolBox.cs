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
    public partial class SGUserControl_SystemToolBox : UserControl
    {
        MyNormalButton se=null;
        public SGUserControl_SystemToolBox()
        {
            InitializeComponent();
            LoadTools();
        }
        void LoadTools()
        {
            //COLOR
            Color sgtab_af_fr = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "fr");
            Color sgtab_af_bk = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "bk");
            Color sgtab_af_sb = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "sb");
            Color sgtab_af_sf = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "sf");
            Color sgtab_af_uc = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "uc");
            Color sgtab_af_suc = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "suc");
            Color sgtab_af_bd = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "bd");
            this.sgTabPageControl1.SGCS_Style = "light";
            this.sgTabPageControl1.SGCS_Light_FontColor = sgtab_af_fr;
            this.sgTabPageControl1.SGCS_Light_BackColor = sgtab_af_bk;
            this.sgTabPageControl1.SGCS_Light_SelectFontColor = sgtab_af_sf;
            this.sgTabPageControl1.SGCS_Light_SelectUnderLineColor = sgtab_af_suc;
            this.sgTabPageControl1.SGCS_Light_UnderLineColor = sgtab_af_uc;
            //
            sgTabPageControl1.TabPages.Clear();
            string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\SystemTools.SGCF";
            string readjie = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("systemtoolbox", "NT" + SGFunction.SystemFunctionAndInformation.GetOSVersion(), "", cfg, false);
            if (readjie != "")
            {
                try
                {
                    string[] jies = readjie.Split('|');
                    int jj = jies.Length;
                    //MessageBox.Show(jj.ToString());
                    int size_w = sgTabPageControl1.ItemSize.Width * jj;
                    this.Size = new Size(size_w, this.Size.Height);
                    //MessageBox.Show(size_w.ToString());
                    sgTabPageControl1.Size = new Size(size_w+100+2, sgTabPageControl1.Height);
                    //MessageBox.Show(sgTabPageControl1.Size.Width .ToString());
                    for (int u = 1; u <= jies.Length; u++)
                    {
                        string jiename = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(jies[u - 1], "mainname", "", cfg, false);
                        TabPage newpage = new TabPage(jiename);
                        newpage.BackColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab","pc");
                        newpage.AutoScroll = true;
                        //MessageBox.Show(newpage.Size.Width.ToString());
                        sgTabPageControl1.TabPages.Add(newpage);
                        //添加FL
                        //tagpage.AutoScroll = true;
                        FlowLayoutPanel fl = new FlowLayoutPanel();
                        fl.AutoScroll = true;
                        newpage.Controls.Add(fl);
                        fl.Size = new System.Drawing.Size(newpage.Size.Width -75 ,newpage.Size.Height);
                        fl.Location = new Point(0, 0);
                        string[] keys, valus;
                        SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues(jies[u - 1], out keys, out valus, cfg,true);
                        for (int j = 1; j <= keys.Length; j++)
                        {
                            if(keys[j-1].ToUpper() !="MAINNAME")
                            {
                                MyNormalButton btn = new MyNormalButton();
                                fl.Controls.Add(btn);
                                btn.Margin = new Padding(0,0,0,0);
                                btn.Size = new Size(70,100);
                                btn.ImageAlign = ContentAlignment.TopCenter;
                                btn.BackColor = Color.White;
                                btn.TextAlign = ContentAlignment.BottomCenter;
                                btn.Font = new System.Drawing.Font("微软雅黑", 8f, FontStyle.Bold);
                                btn.ForeColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
                                string cmdread = valus[j - 1];
                                string ico = "%windir%\\system32\\imageres.dll,11";
                                string cmd = "", arg = "";
                                string name = "";
                                string runtype = "NO";
                                if (cmdread != "")
                                {
                                    string[] rs = cmdread.Split('|');
                                    if (rs != null)
                                    {
                                        if (rs.Length == 4)
                                        {
                                            name = rs[0]; cmd = rs[1]; ico = rs[2]; arg = rs[3];
                                            if (name.Length > 3) { runtype = name.Substring(0,name.IndexOf(",")); name = name.Substring(name.IndexOf(",") + 1, name.Length - name.IndexOf(",") - 1); }
                                        }
                                    }
                                }
                                //显示图标
                                //变量
                                name = SGFunction.PathOperate.ConvertStringToTurePath(name, name);
                                ico = SGFunction.PathOperate.ConvertStringToTurePath(ico, ico);
                                cmd = SGFunction.PathOperate.ConvertStringToTurePath(cmd,cmd);
                                //DISPLAY
                                btn.Text = name;
                                btn.Image   = SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico,"%SYSTEMROOT%\\SYSTEM32\\IMAGERES.DLL,11");
                                string[] iu = new string[] { cmd, arg,ico,runtype };
                                btn.Tag = iu;
                                btn.Click += new EventHandler(this.ClickBtn);
                                btn.ContextMenuStrip = this.sgRightMenus1;
                                btn.MouseDown += new MouseEventHandler(this.MouseDownBtn);
                            }
                        }
                    }
                    //MessageBox.Show(sgTabPageControl1.TabPages[0].Size.Width.ToString());
                }
                catch { sgTabPageControl1.TabPages.Clear(); }
            }
        }
        private void ClickBtn(object sender,EventArgs e)
        {
            MyNormalButton n = (MyNormalButton)sender;
            object jp = n.Tag;
            try
            {
                if(jp !=null)
                {
                    string[] pp = (string[])jp;
                    string cmd = pp[0];
                    string arg = pp[1];
                    if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cmd)==true)
                    {
                        SGFunction.SystemFunctionAndInformation.ShellPrograms(cmd, arg, false, false, true, false);
                    }
                    else
                    {
                        SGFunction.CommonDialogs.MessageDialog_ShowInfo("无法启动这个工具，因为该工具不存在",2);
                    }
                }
            }
            catch { }
        }
        private void MouseDownBtn(object sender, MouseEventArgs e)
        {
            se = (MyNormalButton)sender;
        }
        void MainTile_PinToDesktop()
        {
            if (se != null)
            {
                try
                {
                    if (se.Tag == null) { return; }
                    string[] arg = (string[])se.Tag;
                    if (arg != null)
                    {
                        if (arg.Length >= 4)
                        {
                            string cmd = arg[0];
                            string lin = arg[1];
                            string ico = arg[2];
                            string runtype = arg[3];
                            //MessageBox.Show(icopath);
                            string lnkpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + se.Text + ".LNK";
                            if(runtype =="AD")
                            {
                                SGFunction.SystemFunctionAndInformation.CreateLink_StartAdminType(lnkpath, cmd, lin, "", ico);
                            }
                            else
                            {
                                SGFunction.SystemFunctionAndInformation.CreateLink(lnkpath, cmd, lin, "", ico);
                            }
                        }
                    }
                }
                catch { }
            }
        }
        void MainTile_PinToTaskBar()
        {
            if (se != null)
            {
                try
                {
                    if (se.Tag == null) { return; }
                    string[] arg = (string[])se.Tag;
                    if (arg != null)
                    {
                        if (arg.Length >= 4)
                        {
                            string cmd = arg[0];
                            string lin = arg[1];
                            string ico = arg[2];
                            string runtype = arg[3];
                            //MessageBox.Show(icopath);
                            string lnkpath =SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\" + se.Text + ".LNK";
                            if (runtype == "AD")
                            {
                                SGFunction.SystemFunctionAndInformation.CreateLink_StartAdminType(lnkpath, cmd, lin, "", ico);
                            }
                            else
                            {
                                SGFunction.SystemFunctionAndInformation.CreateLink(lnkpath, cmd, lin, "", ico);
                            }
                            SGFunction.SystemFunctionAndInformation.PingProgramInTaskBar(true, lnkpath);
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(lnkpath);
                        }
                    }
                }
                catch { }
            }
        }
        void MainTile_PinToStartMenu()
        {
            if (se != null)
            {
                try
                {
                    if (se.Tag == null) { return; }
                    string[] arg = (string[])se.Tag;
                    if (arg != null)
                    {
                        if (arg.Length >= 4)
                        {
                            string cmd = arg[0];
                            string lin = arg[1];
                            string ico = arg[2];
                            string runtype = arg[3];
                            //MessageBox.Show(icopath);
                            string lnkpath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + se.Text + ".LNK";
                            if (runtype == "AD")
                            {
                                SGFunction.SystemFunctionAndInformation.CreateLink_StartAdminType(lnkpath, cmd, lin, "", ico);
                            }
                            else
                            {
                                SGFunction.SystemFunctionAndInformation.CreateLink(lnkpath, cmd, lin, "", ico);
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void 添加到桌面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTile_PinToDesktop();
        }

        private void 添加到任务栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTile_PinToTaskBar();
        }

        private void 添加到开始菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTile_PinToStartMenu();
        }
    }
}
