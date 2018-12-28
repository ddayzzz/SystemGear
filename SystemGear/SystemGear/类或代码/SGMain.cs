using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGear.窗体;
using System.Drawing;
using System.Windows.Forms;

namespace SystemGear.类或代码
{
    class SGMain
    {
        /// <summary>
        /// 主窗体Load类
        /// </summary>
        public class Load
        {
            /// <summary>
            /// 加载主界面
            /// </summary>
            /// <param name="m"></param>
            public static void LoadMainDialog(SGForm_Main m, string[] args)
            {
                try
                {
                    //设置主题
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\Skins.sgcf"; string mainskinfile = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("SKINS") + "\\default.sgcf"; ;
                    if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(cfg)==false)
                    {
                        //use default sgcf 
                        SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Main","Select_Skin", "%RESOURCES%\\skins\\default.sgcf", "Config", false, cfg);
                    }
                    else
                    {
                        string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("main", "select_skin", mainskinfile, cfg,true);
                        if(SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(read)==true)
                        {
                            mainskinfile = read;
                        }
                    }
                    if (SGFunction.FileSystemOperate.FileSystemOperate_GetFileExists(mainskinfile) == true)
                    {
                        SGFunction.Skins._SKINSCONFIG = mainskinfile;
                    }
                    else
                    {
                        //ERROR FILE NOT FOUND
                    }
                    //设置大小
                    m.sgItems1.Size = new Size(189, 491);
                    m.panel1.Size = new Size(891, 65);
                    //SUBCOMMAND
                    SGMain.Skins.LoadSkins(m);
                    SGMain.Load.LoadSubCommand_DefaultMain(m);
                    SGMain.Load.LoadUserPin_MainTile(m);
                    //Image wallp = SGFunction.SystemFunctionAndInformation.GetWallpaper();
                    //m.myModernButton2.ButtonBackImage = wallp;
                    //处理命令行
                    SetCommand(m, args);
                }
                catch { }
            }
            public static void SetCommand(SGForm_Main m, string[] args)
            {
                try
                {
                    if (args != null)
                    {
                        if (args.Length > 0)
                        {
                            string flag = args[0].ToUpper(); //读取命令行标志 只有可能是/S /Y
                            if (flag.Length >= 3) { flag = flag.Substring(0, 3); flag = flag.Replace(@"/","").Replace(@"\","").Replace("-","").Replace("=",""); }
                            //MessageBox.Show(flag);
                            //判断参数的行数
                            switch (flag)
                            {
                                case "S":
                                    //S 该参数接受一个参数
                                    string read = args[0];
                                    string starttype = read.Substring(read.IndexOf("=") + 1, read.Length - read.IndexOf("=") - 1);
                                    //MessageBox.Show(starttype);
                                    if (starttype != "")
                                    {
                                        //bool res=SGFunction.RunCommand.ShellSGFunction(m, m.sgstyfrm, starttype, out m.sgstyfrm);
                                        //MessageBox.Show(res.ToString());
                                        //if (res == true) { m.Hide(); }
                                        m.ShellFunctionAfterShown = true;
                                        m.ShellCommand = starttype;
                                    }
                                    break;
                                case "Y":
                                    //这个命令用于一键设置之类的或者关联了又右键菜单的操作 这个命令一般需要窗体隐藏
                                    string read1 = args[0];
                                    string starttype1 = read1.Substring(read1.IndexOf("=") + 1, read1.Length - read1.IndexOf("=") - 1);
                                    m.ShowInTaskbar =false;m.Visible = false;m.Hide();
                                    SGFunction.RunCommand.ShellCommand_Y(starttype1, args);
                                    break;
                                case "-?":
                                case "/?":
                                    SGFunction.RunCommand.ShellTextFile("command");
                                    m.sgItems1.Settings_ChooseItemsIndex = 1;
                                    break;
                            }
                        }
                        else
                        {
                            //没有命令 进入默认界面
                            m.sgItems1.Settings_ChooseItemsIndex = 1;
                        }

                    }
                    else
                    {
                        //没有命令 进入默认界面
                        m.sgItems1.Settings_ChooseItemsIndex = 1;
                    }
                }
                catch { }

            }
            public static void LoadSubCommand_DefaultMain(SGForm_Main m)
            {
                try
                {
                    m.sgRightMenus_commands.Items.Clear();
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\SGSubCommands.sgcf";
                    string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("shells", "default_main", "", cfg, false);
                    if(read !="")
                    {
                        string[] keys=read.Split('|');
                        for(int j=1;j<=keys.Length;j++)
                        {
                            string name = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(keys[j - 1], "name", "", cfg, true);
                            m.sgRightMenus_commands.Items.Add(name).Tag =keys[j-1];
                        }
                    }
                }
                catch { }
            }
            /// <summary>
            /// 加载主界面磁铁设置
            /// </summary>
            /// <param name="m">按钮实例</param>
            /// <param name="type">磁铁的样式 [L]大 [K]宽 [Z]中 [X]小</param>
            /// <param name="read">从注册表中读取的文字</param>
            /// <param name="ma">主界面实例</param>
            public static void LoadMainTile(SGModernButton m, string type, string read, SGForm_Main ma)
            {
                try
                {
                    string[] re = read.Split('|');
                    string name = "";
                    string infotip = "";
                    string shellindex = "";
                    string backcolor = "0,148,255";
                    string logo72 = "";
                    string logo36 = "";
                    string backimage ="";
                    //读取
                    switch(type.ToUpper())
                    {
                        case"L":
                            if (re.Length == 7)
                            {
                                name = re[0];
                                infotip = re[1];
                                shellindex = re[2];
                                backcolor = re[3];
                                logo36 = re[5];
                                backimage = re[6];
                                name = SGFunction.PathOperate.ConvertStringToTurePath(name,name);
                                infotip = SGFunction.PathOperate.ConvertStringToTurePath(infotip, infotip);
                                if (name != "") {m.ButtonText = name; }
                                if (infotip != "") { ma.toolTip1.SetToolTip(m, infotip); }
                                if (shellindex != "") { m.Tag = shellindex; }
                                if (backcolor != "") { m.ButtonBackColor = m.ButtonBackPageColor=SGFunction.ColorOperate.GetColorFromStr(backcolor); }
                                if (logo36 != "") { m.ButtonSmallLogo = SGFunction.Resources.GetImageFromResourcesCode(logo36); }
                                m.ButtonType = SGModernButton.ButtonStyle.NormalWithLogo;
                                if (backimage != "") { m.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode(backimage); m.BackgroundImageLayout = ImageLayout.Stretch; }
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
                                logo72 = re[5];
                                name = SGFunction.PathOperate.ConvertStringToTurePath(name, name);
                                infotip = SGFunction.PathOperate.ConvertStringToTurePath(infotip, infotip);
                                if (name != "") { m.ButtonText = name; }
                                if (infotip != "") { ma.toolTip1.SetToolTip(m, infotip); }
                                if (shellindex != "") { m.Tag = shellindex; }
                                if (backcolor != "") { m.ButtonBackColor = SGFunction.ColorOperate.GetColorFromStr(backcolor); }
                                //bMessageBox.Show(m.ButtonBackColor.ToString());
                                //if (backimage != "") { m.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode(backimage); m.BackgroundImageLayout = ImageLayout.Stretch; } else { m.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode("IconAndLinkMgr_72x72"); m.BackgroundImageLayout = ImageLayout.Center; }
                                if (logo72 != "") { m.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode(logo72); m.BackgroundImageLayout = ImageLayout.Center; }
                            }
                            break;
                        case "X":
                            if (re.Length == 6)
                            {
                                name = re[0];
                                infotip = re[1];
                                shellindex = re[2];
                                backcolor = re[3];
                                logo36 = re[5];
                                //name = SGFunction.PathOperate.ConvertStringToTurePath(name, name);
                                infotip = SGFunction.PathOperate.ConvertStringToTurePath(infotip, infotip);
                                //if (name != "") { m.ButtonText = name; }
                                if (infotip != "") { ma.toolTip1.SetToolTip(m, infotip); }
                                if (shellindex != "") { m.Tag = shellindex; }
                                if (backcolor != "") { m.ButtonBackColor = m.ButtonBackPageColor = SGFunction.ColorOperate.GetColorFromStr(backcolor); }
                                //if (logo36 != "") { m.ButtonSmallLogo = SGFunction.Resources.GetImageFromResourcesCode(logo36); }
                                m.ButtonType = SGModernButton.ButtonStyle.NormalWithoutBackPage;
                                if (logo36 != "") { m.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode(logo36); m.BackgroundImageLayout = ImageLayout.Center; }
                            }
                            break;
                    }
                }
                catch { }
            }
            public static void LoadUserPin_MainTile(SGForm_Main m)
            {
                try
                {
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("CONFIG") + "\\MainTile.SGCF";
                    //GROUP 1
                    string R1_1 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group1", "TILE1", "", cfg, false);
                    string R1_2 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group1", "TILE2", "", cfg, false);
                    SGMain.Load.LoadMainTile(m.myModernButton2, "L", R1_1, m);
                    SGMain.Load.LoadMainTile(m.myModernButton17, "K", R1_2, m);
                    //GROUP 2
                    string R2_1 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group2", "TILE1", "", cfg, false);
                    string R2_2 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group2", "TILE2", "", cfg, false);
                    SGMain.Load.LoadMainTile(m.myModernButton4, "K", R2_1, m);
                    SGMain.Load.LoadMainTile(m.myModernButton3, "Z", R2_2, m);
                    string R2_3 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group2", "TILE3", "", cfg, false);
                    string R2_4 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group2", "TILE4", "", cfg, false);
                    SGMain.Load.LoadMainTile(m.myModernButton12, "Z", R2_3, m);
                    SGMain.Load.LoadMainTile(m.myModernButton1, "Z", R2_4, m);
                    //x
                    string R2_5 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group2", "TILE5", "", cfg, false);
                    string R2_6 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group2", "TILE6", "", cfg, false);
                    string R2_7 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group2", "TILE7", "", cfg, false);
                    string R2_8 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group2", "TILE8", "", cfg, false);
                    SGMain.Load.LoadMainTile(m.myModernButton13, "X", R2_5, m);
                    SGMain.Load.LoadMainTile(m.myModernButton14, "X", R2_6, m);
                    SGMain.Load.LoadMainTile(m.myModernButton15, "X", R2_7, m);
                    SGMain.Load.LoadMainTile(m.myModernButton16, "X", R2_8, m);
                    //GROUP 3
                    string R3_1 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group3", "TILE1", "", cfg, false);
                    string R3_2 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group3", "TILE2", "", cfg, false);
                    SGMain.Load.LoadMainTile(m.myModernButton18, "Z", R3_1, m);
                    SGMain.Load.LoadMainTile(m.myModernButton11, "Z", R3_2, m);
                    string R3_3 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group3", "TILE3", "", cfg, false);
                    string R3_4 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group3", "TILE4", "", cfg, false);
                    string R3_5 = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue("maintile_group3", "TILE5", "", cfg, false);
                    SGMain.Load.LoadMainTile(m.myModernButton5, "K", R3_3, m);
                    SGMain.Load.LoadMainTile(m.myModernButton6, "Z", R3_4, m);
                    SGMain.Load.LoadMainTile(m.myModernButton7, "Z", R3_5, m);
                }
                catch { }
            }
            private static bool _ISLOADALLFUNCTION_STYLE = false; //用于记录STYLE是否已被加载
            private static bool _ISLOADALLFUNCTION_SYSTEM = false; //用于记录SYSTEM是否已被加载
            private static bool _ISLOADALLFUNCTION_ADV = false; //用于记录ADV是否已被加载
            private static bool _ISLOADALLFUNCTION_OTHERS = false; //用于记录OTHERS是否已被加载
            public static void LoadClassFunctions(string type,SGForm_Main m)
            {
                
                try
                {
                    FlowLayoutPanel flo;
                    string[] keys, values;
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\SGFunctionsClassify.sgcf";
                    Color backcolor;
                    switch (type.ToUpper())
                    {
                        case "STYLE":
                            if (_ISLOADALLFUNCTION_STYLE == false)
                            {
                                _ISLOADALLFUNCTION_STYLE = true;
                            }
                            else { return; }
                            flo = m.flowLayoutPanel_allfunction_style;
                            SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("belong_style", out keys, out values, cfg, true);
                            backcolor = Color.FromArgb(255, 128, 0);

                            break;
                        case "SYSTEM":
                            if (_ISLOADALLFUNCTION_SYSTEM == false)
                            {
                                _ISLOADALLFUNCTION_SYSTEM = true;
                            }
                            else { return; }
                            flo = m.flowLayoutPanel_allfuction_system;
                            SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("Belong_SystemTool", out keys, out values, cfg, true);
                            backcolor = Color.FromArgb(241, 196, 15);

                            break;
                        case "OTHERS":
                            if (_ISLOADALLFUNCTION_OTHERS == false)
                            {
                                _ISLOADALLFUNCTION_OTHERS = true;
                            }
                            else { return; }
                            flo = m.flowLayoutPanel_allfunction_others;
                            SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("Belong_SGTools", out keys, out values, cfg, true);
                            backcolor = Color.Green;

                            break;
                        default:
                            if (_ISLOADALLFUNCTION_ADV == false)
                            {
                                _ISLOADALLFUNCTION_ADV = true;
                            }
                            else { return; }
                            flo = m.flowLayoutPanel_allfunction_adv;
                            SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("belong_ADV", out keys, out values, cfg, true);
                            backcolor = Color.FromArgb(195, 57, 37);

                            break;
                    }
                    for(int j=1;j<=keys.Length;j++)
                    {
                        
                        //GET INFO
                        string readcode = values[j - 1];
                        string[] args = SGFunction.ApplicationSetting.GetSGFunctionInfo(readcode, true, false);
                        string name = args[0]; string infotip = args[1]; string cmd = args[2]; string logo36 = args[3];
                        //控件
                        SGModernButton my = new SGModernButton();
                        my.ButtonType = SGModernButton.ButtonStyle.NormalWithoutBackPage;
                        my.ButtonText = name;
                        my.ButtonBackImage = SGFunction.Resources.GetImageFromResourcesCode(logo36);
                        my.ButtonTextAlignment = ContentAlignment.MiddleCenter;
                        my.Size = new Size(100, 75);
                        my.Tag = cmd;
                        my.OnButtonClick += new EventHandler(m.Allfuntionbutton_click);
                        m.toolTip1.SetToolTip(my, infotip);
                        my.ButtonBackColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "tile_bk");
                        my.ButtonForceColor= SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "tile_fr");
                        flo.Controls.Add(my);
                    }
                }
                catch { }
                 
            }
            
        }
        /// <summary>
        /// 点击事件
        /// </summary>
        public  class Click
        {
            /// <summary>
            /// 运行主界面的SubCommand 当命令为SG|INDEX 会返回BOOL 其余返回命令执行结果
            /// </summary>
            /// <param name="tag">自定的命令的节</param>
            /// <param name="m">主窗体</param>
            /// <param name="ss">系统外观设置</param>
            /// <param name="shelltype">输出执行命令的模式 [NORMAL] 正常命令或执行失败的命令 [SGF] SG|INDEX 返回BOOL 用于窗体隐藏</param>
            public static bool ShellSubCommand_Command(object tag,SGForm_Main m,SGForm_Function_SystemStyle ss,out string shelltype)
            {
                try
                {
                    if (tag == null) { shelltype = "NORMAL"; return false; }
                    string ret_t = "NORMAL";
                    bool ret_res = false;
                    string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\SGSubCommands.sgcf";
                    string read = SGFunction.ConfigFileOperate.SGCFFileOperate_GetValue(tag.ToString(), "command", "", cfg, false);
                    bool res=SGFunction.RunCommand.ShellCommand(read);
                    if(res==false)
                    {
                        //看看是不是SG|INDEX
                        string[] pp = read.Split('|');
                        if(pp !=null)
                        {
                            if(pp.Length ==2)
                            {
                                //也许是
                                if (pp[0].ToUpper() == "SG")
                                {
                                    //50%是
                                    string cmd = pp[1];
                                    bool p = SGFunction.RunCommand.ShellSGFunction(m, ss, cmd, out m.sgstyfrm);
                                    ret_res = p;
                                    ret_t = "SGF";
                                }
                                else { ret_res = false; ret_t = "SGF"; }
                            }
                            else
                            {
                                ret_res = false; ret_t = "NORMAL";
                            }
                        }
                        else
                        {
                            ret_res = false; ret_t = "NORMAL";
                        }
                    }
                    else
                    {
                        ret_t = "NORMAL"; ret_res = true;
                    }
                    shelltype = ret_t;
                    return ret_res;
                }
                catch 
                {
                    shelltype = "NORMAL";
                    return false;
                }
            }
        }
        public class Skins
        {
            public static void DrawAllClassFunctionsTile(SGForm_Main m)
            {
                //O
                foreach (Control con in m.flowLayoutPanel_allfuction_system.Controls)
                {
                    if (con is SGModernButton )
                    {
                        SGModernButton my = (SGModernButton)con;
                        my.ButtonBackColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "tile_bk");
                        my.ButtonForceColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "tile_fr");
                    }
                }
                //O
                foreach (Control con in m.flowLayoutPanel_allfunction_adv.Controls)
                {
                    if (con is SGModernButton )
                    {
                        SGModernButton my = (SGModernButton)con;
                        my.ButtonBackColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "tile_bk");
                        my.ButtonForceColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "tile_fr");
                    }
                }
                //O
                foreach (Control con in m.flowLayoutPanel_allfunction_others.Controls)
                {
                    if (con is SGModernButton )
                    {
                        SGModernButton my = (SGModernButton)con;
                        my.ButtonBackColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "tile_bk");
                        my.ButtonForceColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "tile_fr");
                    }
                }
                //O
                foreach (Control con in m.flowLayoutPanel_allfunction_style.Controls)
                {
                    if (con is SGModernButton )
                    {
                        SGModernButton my = (SGModernButton)con;
                        my.ButtonBackColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "tile_bk");
                        my.ButtonForceColor = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "tile_fr");
                    }
                }
            }
            public static void LoadSkins(SGForm_Main m)
            {
                //MAK THE SIMPLYMODE ENABLE?
                string v = SGFunction.ApplicationSetting.Operate_SystemGearApplicationSettings("simplymode").ToLower();
                if (v == "on")
                {
                    return;
                }
                try
                {
                    Color dialog_mian_back = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_main", "bk");
                    Color dialog_mian_bd = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_main", "bd");
                    Color dialog_mian_ptfr = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_main", "pt_tit_fc");
                    Color dialog_stand_bd= SGFunction.Skins.Skins_GetControlColorSetting("Dialog_standard", "bd");
                    Color dialog_stand_bk = SGFunction.Skins.Skins_GetControlColorSetting("Dialog_standard", "bk");
                    Color sgtab_bak = SGFunction.Skins.Skins_GetControlColorSetting("SGTAB", "BK");
                    Color sgtab_fr = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "fr");
                    Color sgtab_sbak = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "sb");
                    Color sgtab_sfr = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "sf");
                    Color sgtab_panelc = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "pc");
                    Color sgtab_bd = SGFunction.Skins.Skins_GetControlColorSetting("sgtab", "bd");
                    Color lf_bk = SGFunction.Skins.Skins_GetControlColorSetting("leftmenu", "bk");
                    Color lf_fr = SGFunction.Skins.Skins_GetControlColorSetting("leftmenu", "fr");
                    Color lf_sbk = SGFunction.Skins.Skins_GetControlColorSetting("leftmenu", "sb");
                    Color lf_sfr = SGFunction.Skins.Skins_GetControlColorSetting("leftmenu", "sf");
                    Color o_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "bk");
                    Color o_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "fr");
                    Color o1_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "bk");
                    Color o1_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "fr");
                    Color lab_ma_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_maininfo", "fr");
                    Color lab_fu_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_funinfo", "fr");
                    Color sea_bk = SGFunction.Skins.Skins_GetControlColorSetting("searchbox", "bk");
                    Color sea_fr = SGFunction.Skins.Skins_GetControlColorSetting("searchbox", "fr");
                    Color com_bk = SGFunction.Skins.Skins_GetControlColorSetting("combox", "bk");
                    Color com_fr = SGFunction.Skins.Skins_GetControlColorSetting("combox", "fr");
                    Color cb_bk = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "bk");
                    Color cb_bk_1 = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "bk_c1");
                    Color cb_bk_2 = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "bk_c2");
                    Color cb_fr_1 = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "fr_c1");
                    Color cb_fr_2 = SGFunction.Skins.Skins_GetControlColorSetting("choosebox", "fr_c2");
                    Color ra_fr = SGFunction.Skins.Skins_GetControlColorSetting("radio", "fr");
                    Color tree_fr = SGFunction.Skins.Skins_GetControlColorSetting("treeview", "fr");
                    Color list_fr = SGFunction.Skins.Skins_GetControlColorSetting("listview", "fr");
                    Color rightmenu_fr = SGFunction.Skins.Skins_GetControlColorSetting("rightmenu", "fr");
                    Color tree_line = SGFunction.Skins.Skins_GetControlColorSetting("treeview", "lc");
                    Color ck_bd = SGFunction.Skins.Skins_GetControlColorSetting("checkbox", "bd");
                    Color ck_fr = SGFunction.Skins.Skins_GetControlColorSetting("checkbox", "fr");
                    Color tb_bd = SGFunction.Skins.Skins_GetControlColorSetting("textbox", "bd");
                    Color tb_nobd = SGFunction.Skins.Skins_GetControlColorSetting("textbox", "nommbd");
                    Color tb_fr = SGFunction.Skins.Skins_GetControlColorSetting("textbox", "fr");
                    Color tb_tip = SGFunction.Skins.Skins_GetControlColorSetting("textbox", "tip");
                    Color tb_error_fr = SGFunction.Skins.Skins_GetControlColorSetting("textbox", "er_tb_fr");
                    //Color sgtab_af_fr = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "fr");
                    //Color sgtab_af_bk = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "bk");
                    //Color sgtab_af_sb = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "sb");
                    //Color sgtab_af_sf= SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "sf");
                    //Color sgtab_af_uc = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "uc");
                    //Color sgtab_af_suc = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "suc");
                    //Color sgtab_af_bd = SGFunction.Skins.Skins_GetControlColorSetting("sgtab_allfunctions", "bd");
                    Image p_top_left = SGFunction.Skins.GetSkinPictures("top_left");
                    Image p_top= SGFunction.Skins.GetSkinPictures("top");
                    Image p_zhe1 = SGFunction.Skins.GetSkinPictures("top_zhe1");
                    Image p_zhe2= SGFunction.Skins.GetSkinPictures("top_zhe2");
                    //dialog
                    m.BackColor = m.panel4.BackColor = dialog_mian_back;
                    m.label2.ForeColor = dialog_mian_ptfr;
                    m.myNormalButton_changeskin.FlatAppearance.MouseDownBackColor = m.MyNormalButton_moresetting.FlatAppearance.MouseDownBackColor = m.MyNormalButton3.FlatAppearance.MouseDownBackColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "light");
                    m.myNormalButton_changeskin.FlatAppearance.MouseOverBackColor = m.MyNormalButton_moresetting.FlatAppearance.MouseOverBackColor = m.MyNormalButton3.FlatAppearance.MouseOverBackColor = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
                    //searchbox
                    m.sgCombobox_searchbox.Settings_ItemBackColor = sea_bk;
                    m.sgCombobox_searchbox.ForeColor = sea_fr;
                    m.sgTextBox_searchbox_text.TextBoxInfoTipColor = tb_tip;
                    m.sgTextBox_searchbox_text.TextBoxLoseFocusColor = Color.White;
                    m.sgTextBox_searchbox_text.TextBoxInfoBorderColor = Color.White;
                    m.sgTextBox_searchbox_text.ForeColor = tb_fr;
                    //LEFT
                    m.sgItems1.Settings_DefaultColor = lf_bk;
                    m.sgItems1.Settings_DefaultFontColor = lf_fr;
                    m.sgItems1.Settings_SelectColor = lf_sbk;
                    m.sgItems1.Settings_SelectFontColor = lf_sfr;
                    m.sgItems1.BackColor = lf_bk;
                    m.sgItems1.Settings_ChooseItemsIndex = m.sgItems1.Settings_ChooseItemsIndex;
                    //tab
                    m.sgTabPageControl_about.SGCS_BorderColor = m.sgTabPageControl_main.SGCS_BorderColor = m.sgTabPageControl_setting.SGCS_BorderColor = m.sgTabPageControl2.SGCS_BorderColor = sgtab_bd;
                    m.sgTabPageControl_about.SGCS_SelectTitleBackColor = m.sgTabPageControl_main.SGCS_SelectTitleBackColor = m.sgTabPageControl_setting.SGCS_SelectTitleBackColor = m.sgTabPageControl2.SGCS_SelectTitleBackColor = sgtab_sbak;
                    m.sgTabPageControl_about.SGCS_SelectTitleTextColor = m.sgTabPageControl_main.SGCS_SelectTitleTextColor = m.sgTabPageControl_setting.SGCS_SelectTitleTextColor = m.sgTabPageControl2.SGCS_SelectTitleTextColor = sgtab_sfr;
                    m.sgTabPageControl_about.SGCS_TitleBackColor = m.sgTabPageControl_main.SGCS_TitleBackColor = m.sgTabPageControl_setting.SGCS_TitleBackColor = m.sgTabPageControl2.SGCS_TitleBackColor = sgtab_bak;
                    m.sgTabPageControl_about.SGCS_TitleTextColor = m.sgTabPageControl_main.SGCS_TitleTextColor = m.sgTabPageControl_setting.SGCS_TitleTextColor = m.sgTabPageControl2.SGCS_TitleTextColor = sgtab_fr;
                    //tabpag
                    SGFunction.Skins.DrawAllControlInTabControl(m.sgTabPageControl_about);
                    SGFunction.Skins.DrawAllControlInTabControl(m.sgTabPageControl_main);
                    SGFunction.Skins.DrawAllControlInTabControl(m.sgTabPageControl_setting);
                    //SGFunction.Skins.DrawAllControlInTabControl(m.sgTabPageControl_submain);
                    SGFunction.Skins.DrawAllControlInTabControl(m.sgTabPageControl2);
                    foreach (TabPage tp1 in m.sgTabPageControl_submain.TabPages) { tp1.BackColor = dialog_mian_back; }
                    //foreach (TabPage tp1 in m.sgTabPageControl_about.TabPages) { tp1.BackColor = sgtab_panelc; }
                    //foreach (TabPage tp1 in m.sgTabPageControl_main.TabPages) { tp1.BackColor = sgtab_panelc; }
                    //foreach (TabPage tp1 in m.sgTabPageControl_setting.TabPages) { tp1.BackColor = sgtab_panelc; }
                    //foreach (TabPage tp1 in m.sgTabPageControl2.TabPages) { tp1.BackColor = sgtab_panelc; }
                    //label maininfo
                    m.sgLabel_about_programedit_main.ForeColor = m.sgLabel_baksetting_main.ForeColor = lab_ma_fr;

                    //all function
                    //m.sgTabPageControl_allfunction.SGCS_BorderColor = sgtab_af_bd;
                    //m.sgTabPageControl_allfunction.SGCS_SelectTitleBackColor = sgtab_af_sb;
                    //m.sgTabPageControl_allfunction.SGCS_SelectTitleTextColor = sgtab_af_sf;
                    //m.sgTabPageControl_allfunction.SGCS_TitleBackColor = sgtab_af_bk;
                    //m.sgTabPageControl_allfunction.SGCS_TitleTextColor = sgtab_af_fr;
                    //m.sgTabPageControl_allfunction.SGCS_Light_UnderLineColor = sgtab_af_uc;
                    //m.sgTabPageControl_allfunction.SGCS_Light_SelectUnderLineColor = sgtab_af_suc;
                   // m.sgTabPageControl_allfunction.SGCS_Light_SelectFontColor = sgtab_af_sf;
                    //m.sgTabPageControl_allfunction.
                    //皮肤图片
                    m.panel_zhe1.BackgroundImage = m.panel_zhe2.BackgroundImage = m.panel_zhe3.BackgroundImage = p_zhe1;
                    m.panel_zhe4.BackgroundImage = p_zhe2;
                    m.panel4.BackgroundImage = p_top_left;
                    m.panel1.BackgroundImage = p_top;
                }
                catch { }
                 
            }
        }
    }
}
