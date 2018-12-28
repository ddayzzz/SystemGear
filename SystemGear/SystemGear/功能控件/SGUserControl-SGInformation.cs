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
    public partial class SGUserControl_SGInformation : UserControl
    {
        /// <summary>
        /// 启动系统详细信息对话框
        /// </summary>
        /// <param name="type">模式 [whatsnew]显示更新信息 [eula]许可协议(不可用) [command]SG命令行(不可用)</param>
        public SGUserControl_SGInformation(string type)
        {
            InitializeComponent();
            SGFunction.Skins.DrawAllControlInTabControl(this.sgTabPageControl1);
            sgTabPageControl1.Location = new Point(-5, -37);
            switch(type.ToLower())
            {
                case "whatsnew":
                    LoadWhatsNew();
                    sgTabPageControl1.SelectedIndex = 0;
                    break;
            }
        }
        void LoadWhatsNew()
        {
            try
            {
                sgClickItems_whatsnew_more.Items.Clear();
                string cfg = SGFunction.SpecialFoldersOrFile.GetSystemGearSpecialFolderOrFile("config") + "\\WhatsNew.sgcf";
                string[] main_keys; string[] main_valus;
                SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("main", out main_keys, out main_valus, cfg, true);
                string[] more_keys; string[] more_valus;
                SGFunction.ConfigFileOperate.CFGOperate_GetAllKeyValues("moreinfo", out more_keys, out more_valus, cfg, true);
                string show_main = "";
                //string show_more = "";
                //mian
                if (main_valus != null)
                {
                    for (int u = 1; u <= main_valus.Length; u++)
                    {
                        if (u == 1)
                        {
                            show_main = main_valus[0];
                        }
                        else { show_main = show_main + "\r\n" + main_valus[u - 1]; }
                    }
                }
                sgLabel_whatsnew_main.Text = show_main;
                //more
                if (more_valus  != null)
                {
                    for (int u = 1; u <= more_valus.Length; u++)
                    {
                        sgClickItems_whatsnew_more.Items.Add(more_valus[u - 1]);
                    }
                }
            }

            catch { }


        }

        private void myNormalButton4_Click(object sender, EventArgs e)
        {
            SGFunction.RunCommand.ShellTextFile("updateinfo");
        }
    }
}
