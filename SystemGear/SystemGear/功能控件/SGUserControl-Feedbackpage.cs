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
    public partial class SGUserControl_Feedbackpage : UserControl
    {
        public SGUserControl_Feedbackpage()
        {
            InitializeComponent();
            SGFunction.Skins.DrawAllControlInUserControl(this, SGFunction.Skins.Skins_GetControlColorSetting("DIALOG_STANDARD", "BK"));

        }

        private void sgLabel5_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, sgLabel_qq_group.Text);
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功复制了账号",2);
        }

        private void sgLabel6_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, sgLabel_qq_publisher.Text );
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功复制了账号", 2);
        }

        private void sgLabel10_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, sgLabel_qq_group.Text);
            SGFunction.CommonDialogs.MessageDialog_ShowInfo("成功复制了电子邮件地址", 2);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SGFunction.SystemFunctionAndInformation.StartURL("http://wpa.qq.com/msgrd?v=3&uin=2419940233&site=qq&menu=yes");
        }

        private void sgLabel_bbs_refexonurl_Click(object sender, EventArgs e)
        {
            SGFunction.SystemFunctionAndInformation.StartURL(sgLabel_bbs_refexonurl.Text);
        }

        private void sgLabel_email_publisher_Click(object sender, EventArgs e)
        {
            SGFunction.SystemFunctionAndInformation.StartURL("mailto:" + sgLabel_email_publisher.Text);
        }

        private void sgLabel_fb_systemgearpage_Click(object sender, EventArgs e)
        {
            SGFunction.SystemFunctionAndInformation.StartURL(sgLabel_fb_systemgearpage.Text);
        }

        private void sgLabel_publisherpage_Click(object sender, EventArgs e)
        {
            SGFunction.SystemFunctionAndInformation.StartURL(sgLabel_publisherpage.Text);
        }
    }
}
