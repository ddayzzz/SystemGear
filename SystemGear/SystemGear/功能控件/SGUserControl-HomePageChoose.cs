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
    
    public partial class SGUserControl_HomePageChoose : UserControl
    {
        public string retutnurl = "about:blank";
        public SGUserControl_HomePageChoose(string tile)
        {
            InitializeComponent();
            //skin
            SGFunction.Skins.DrawAllControlInUserControl(this, SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "BK"));
            //coide
            sgLabel1.Text = tile;
            //获取当前的主页
            sgRadioButton2.Checked  = sgRadioButton3.Checked  = false;
            sgRadioButton1.Checked  = true;
            sgCombobox_defaulturls.SelectedIndex = 0;
            string[] url = SGFunction.InternetExplorerMgr.GetInternetExplorer_HomePages();
            sgCombobox_allpages.Items.Clear();
            for(int u=1;u<=url.Length;u++)
            {
                sgCombobox_allpages.Items.Add(url[u - 1]);
            }
            if(sgCombobox_allpages.Items.Count >=1)
            {
                sgCombobox_allpages.SelectedIndex = 0;
            }
        }

        private void sgRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (sgRadioButton1.Checked == true) {sgCombobox_allpages.Enabled  = true; sgTextBox_userurl.Enabled = sgCombobox_defaulturls.Enabled = false; }
        }

        private void sgRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (sgRadioButton2.Checked == true) { sgCombobox_allpages.Enabled = false; sgTextBox_userurl.Enabled = true; sgCombobox_defaulturls.Enabled = false; }
        }

        private void sgRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (sgRadioButton3.Checked == true) { sgCombobox_allpages.Enabled = false; sgTextBox_userurl.Enabled = false; sgCombobox_defaulturls.Enabled = true; }
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            
            //判断选择
            if (sgRadioButton1.Checked == true)
            {
                if (sgCombobox_allpages.SelectedIndex != null)
                {
                    try
                    {
                        retutnurl = sgCombobox_allpages.Items[sgCombobox_allpages.SelectedIndex].ToString();
                        this.FindForm().Tag = "ok";
                    }
                    catch
                    {
                        //no select  skip this step
                        //SGFunction.CommonDialogs.MessageDialog_ShowInfo("您似乎没有选择一个可用的网址", 2);
                        this.FindForm().Tag = "exit";
                    }
                }
            }
            else
            {
                if (sgRadioButton2.Checked == true)
                {
                    if (sgTextBox_userurl.Text == "")
                    {
                        this.FindForm().Tag = "exit";
                    }
                    else
                    {
                        retutnurl = sgTextBox_userurl.Text;
                        this.FindForm().Tag = "ok";
                    }

                }
                else
                {
                    if (sgRadioButton3.Checked == true)
                    {
                        this.FindForm().Tag = "ok";
                        switch (sgCombobox_defaulturls.SelectedIndex)
                        {
                            case 0:
                                retutnurl = "about:blank";
                                break;
                            case 1:
                                retutnurl = "about:InPrivate";
                                break;
                            case 2:
                                retutnurl = "about:NoAdd-ons";
                                break;
                        }
                    }
                }
            }
            this.Dispose();
        }

        private void myNormalButton1_Click(object sender, EventArgs e)
        {
            this.FindForm().Tag = "exit";
            this.Dispose();
        }
    }
}
