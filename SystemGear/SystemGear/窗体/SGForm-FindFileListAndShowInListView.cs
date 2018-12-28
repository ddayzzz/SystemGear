using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SystemGear.窗体
{

    public partial class SGForm_FindFileListAndShowInListView : Form
    {
        [DllImport("user32.dll")]//*********************拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        public string ret = "";
        public string btnclick = "exit";
        string pathf = "";
        System.IO.SearchOption operate;
        string extn;
        string iconf = "fromfile";
        public SGForm_FindFileListAndShowInListView(string title, string sectitle, string[] filelist,string path,string ext,System.IO.SearchOption opi, string ico="formfile")
        {
            InitializeComponent();
            //SKIN
            Color mainc = SGFunction.Skins.Skins_GetMainColorSetting("maincolor", "defaultcolor");
            Color o_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "bk");
            Color o_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other", "fr");
            Color o1_bk = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "bk");
            Color o1_fr = SGFunction.Skins.Skins_GetControlColorSetting("btn_other1", "fr");
            Color lab_ma_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_maininfo", "fr");
            Color lab_fu_fr = SGFunction.Skins.Skins_GetControlColorSetting("label_funinfo", "fr");
            Color list_fr = SGFunction.Skins.Skins_GetControlColorSetting("listview", "fr");
            panel1.BackColor = MyNormalButton1.BackColor = mainc;
            sgLabel1.ForeColor  = lab_ma_fr;
            sgListView1.ForeColor = list_fr;
            MyNormalButton2.BackColor = o_bk;
            MyNormalButton2.ForeColor = o_fr;
            MyNormalButton3.BackColor = o1_bk; MyNormalButton3.ForeColor = o1_fr;
            pathf = path;
            operate = opi; extn = ext;
            iconf = ico;
            //LOAD
            this.Text = label_title.Text = title;
            sgLabel1.Text = sectitle;
            string[] files = filelist;
            for (int o = 1; o <= files.Length; o++)
            {
                string filename = files[o - 1];
                string icon = ico;
                System.IO.FileInfo fi = new System.IO.FileInfo(filename);
                DateTime d = fi.LastWriteTime;
                if (icon == "fromfile") { imageList1.Images.Add(SGFunction.ImageAndIconOperate.GetFileIcon(filename, true)); } else { SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(ico, @"%windir%\system32\imageres.dll,2", 16); }
                sgListView1.Items.Add(fi.Name).SubItems.Add(d.Year.ToString() + "年" + d.Month.ToString() + "月" + d.Day.ToString() + "日 " + d.Hour.ToString() + ":" + d.Minute.ToString());
                sgListView1.Items[sgListView1.Items.Count - 1].ImageIndex = imageList1.Images.Count - 1;
                sgListView1.Items[sgListView1.Items.Count - 1].Tag = filename;
            }
        }
        private void SGForm_FindFileListAndShowInListView_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SGFunction.CommonDialogs.SystemGearDialog_DrawBorder(e, this);
        }

        private void MyNormalButton1_MouseMove(object sender, MouseEventArgs e)
        {
            MyNormalButton1.BackColor = SGFunction.Skins.Skins_GetRoleColor(MyNormalButton1.Settings_Role, "MOUSEMOVE");
        }

        private void MyNormalButton1_MouseLeave(object sender, EventArgs e)
        {
            MyNormalButton1.BackColor = SGFunction.Skins.Skins_GetRoleColor(MyNormalButton1.Settings_Role, "");
        }

        private void MyNormalButton1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void sgListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(sgListView1.SelectedItems.Count ==1)
                {
                    ret = sgListView1.SelectedItems[0].Tag.ToString();
                }
            }
            catch { }
        }

        private void MyNormalButton2_Click(object sender, EventArgs e)
        {
            this.btnclick = "ok";
            this.Close();
        }

        private void MyNormalButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if(sgListView1.SelectedItems.Count ==1)
                {
                    object obj = sgListView1.SelectedItems[0].Tag;
                    if(obj !=null)
                    {
                        string file = (string)obj;
                        string res = SGFunction.CommonDialogs.MessageDialog_MustClick("继续？", "您确定要删除该文件吗？", "继续", "取消", "b2", "ques");
                        if(res=="b1")
                        {
                            ret = "";
                            SGFunction.FileSystemOperate.FileSystemOperate_DeleteFile(file);
                            //RELOAD
                            sgListView1.Items.Clear();
                            imageList1.Images.Clear();
                            string[] lis = SGFunction.FileSystemOperate.FileSystemOperate_GetFiles(pathf, extn, operate);
                            if (lis != null)
                            {
                                if (lis.Length > 0)
                                {
                                    for (int o = 1; o <= lis.Length; o++)
                                    {
                                        string filename = lis[o - 1];
                                        string icon = iconf;
                                        System.IO.FileInfo fi = new System.IO.FileInfo(filename);
                                        DateTime d = fi.LastWriteTime;
                                        if (icon == "fromfile") { imageList1.Images.Add(SGFunction.ImageAndIconOperate.GetFileIcon(filename, true)); } else { SGFunction.ImageAndIconOperate.LoadIconsFormResourcesFileIcon(iconf, @"%windir%\system32\imageres.dll,2", 16); }
                                        sgListView1.Items.Add(fi.Name).SubItems.Add(d.Year.ToString() + "年" + d.Month.ToString() + "月" + d.Day.ToString() + "日 " + d.Hour.ToString() + ":" + d.Minute.ToString());
                                        sgListView1.Items[sgListView1.Items.Count - 1].ImageIndex = imageList1.Images.Count - 1;
                                        sgListView1.Items[sgListView1.Items.Count - 1].Tag = filename;
                                    }
                                }
                                else 
                                { 
                                    //SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到可用的文件", 2); 
                                }
                            }
                            else {
                                //SGFunction.CommonDialogs.MessageDialog_ShowInfo("没有找到可用的文件", 2); 
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}
