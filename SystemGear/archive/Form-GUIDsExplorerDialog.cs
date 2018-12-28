using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear
{
    public partial class Form_GUIDsExplorerDialog : Form
    {
        string name="", guid="";
        public string[] return_stringarrr = new string[2];
        public Form_GUIDsExplorerDialog()
        {
            InitializeComponent();
        }
        void LoadGuidInfo()
        {
            try
            {
                string sgcf = Application.StartupPath + @"\Config\SystemGear_GUIDSINFO.SGCF";
                listView1.Items.Clear();
                imageList1.Images.Clear();
                int y = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "count", "0", false, sgcf), 0);
                //MessageBox.Show(y.ToString());
                for (int h = 1; h <= y; h++)
                {
                    string guid = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("guid" + h.ToString(), "guid", "", false, sgcf);
                    string name = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("guid" + h.ToString(), "name", "", false, sgcf);
                    System.Drawing.Bitmap img;
                    if (name == "计算机" && MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion()=="6.3")
                    {
                        name = "这台电脑";
                    }
                    string imgfile = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("guid" + h.ToString(), "icon", @"%SystemRoot%\System32\Imageres.dll,3", false, sgcf);
                    img = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(imgfile,"");
                    imageList1.Images.Add(img);
                    listView1.Items.Add(name).ImageIndex = h - 1;
                    listView1.Items[h-1].Tag = "GUID" + h.ToString();
                    
                    Application.DoEvents();
                }
                if (MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3")
                {
                    this.AddWINBLUEItems();
                }
                else
                {
                    this.AddNoBlueItems();
                }
            }
            catch { }
        }
        public void AddWINBLUEItems()
        {
            string sgcf = Application.StartupPath + @"\Config\SystemGear_GUIDSINFO.SGCF";
            int y = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "count", "0", false, sgcf), 0);
            string DOWN_GUID = "{374DE290-123F-4565-9164-39C4925E467B}";
            string DESK_GUID = "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";
            string MUSI_GUID = "{1CF1260C-4DD0-4ebb-811F-33C572699FDE}";
            string IMAG_GUID = "{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}";
            string VIDE_GUID = "{A0953C92-50DC-43bf-BE83-3742FED03C9C}";
            string DOCE_GUID = "{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}";
            listView1.Items.Add("下载").ImageIndex =y;
            Bitmap img=MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(@"%SystemRoot%\System32\Imageres.dll,175","");
            imageList1.Images.Add(img);
            listView1.Items[y].Tag = DOWN_GUID;
            ///
            listView1.Items.Add("桌面").ImageIndex = y+1;
            Bitmap img1 = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(@"%SystemRoot%\System32\Imageres.dll,174","");
            imageList1.Images.Add(img1);
            listView1.Items[y+1].Tag = DESK_GUID;
            ///
            listView1.Items.Add("音乐").ImageIndex = y+2;
            Bitmap img2 = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(@"%SystemRoot%\System32\Imageres.dll,103","");
            imageList1.Images.Add(img2);
            listView1.Items[y+2].Tag = MUSI_GUID;
            ///
            listView1.Items.Add("图片").ImageIndex = y + 3;
            Bitmap img3 = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(@"%SystemRoot%\System32\Imageres.dll,108","");
            imageList1.Images.Add(img3);
            listView1.Items[y+3].Tag = IMAG_GUID;
            ///
            listView1.Items.Add("视频").ImageIndex = y + 4;
            Bitmap img4 = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(@"%SystemRoot%\System32\Imageres.dll,178","");
            imageList1.Images.Add(img4);
            listView1.Items[y+4].Tag = VIDE_GUID;
            ///
            listView1.Items.Add("文档").ImageIndex = y + 5;
            Bitmap img5 = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(@"%SystemRoot%\System32\Imageres.dll,107","");
            imageList1.Images.Add(img5);
            listView1.Items[y+5].Tag =DOCE_GUID;
            //
            listView1.Items.Add("SkyDrive").ImageIndex =y+6;
            Bitmap img6 = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(@"%SystemRoot%\System32\Imageres.dll,216","");
            imageList1.Images.Add(img6);
            listView1.Items[y+6].Tag = "{8e74d236-7f35-4720-b138-1fed0b85ea75}";
        }
        public void AddNoBlueItems()
        {
            try
            {
                string sgcf = Application.StartupPath + @"\Config\SystemGear_GUIDSINFO.SGCF";
                int y = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("maininfo", "count", "0", false, sgcf), 0);
                listView1.Items.Add("Windows 7文件恢复").ImageIndex = y;
                Bitmap img = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(@"%SystemRoot%\System32\sdcpl.dll,0", "");
                imageList1.Images.Add(img);
                listView1.Items[y].Tag = "{B98A2BEA-7D42-4558-8BD1-832F41BAC6FD}";
                /////////////
                listView1.Items.Add("生物特征设备").ImageIndex = y+1;
                Bitmap img1 = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(@"%SystemRoot%\System32\biocpl.dll,0","");
                imageList1.Images.Add(img1);
                listView1.Items[y+1].Tag = "{0142e4d0-fb7a-11dc-ba4a-000ffe7ab428}";
            }
            catch { }
        }
        private void Form_GUIDsExplorerDialog_Load(object sender, EventArgs e)
        {
            //this.LoadGuidInfo();
        }

        private void Form_GUIDsExplorerDialog_Shown(object sender, EventArgs e)
        {
            this.LoadGuidInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                return_stringarrr[0] = name;
                return_stringarrr[1] = guid;
                this.Close();
            }
            catch { }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count != 0)
                {
                    button3.Enabled = true;
                    string DOWN_GUID = "{374DE290-123F-4565-9164-39C4925E467B}";
                    string DESK_GUID = "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";
                    string MUSI_GUID = "{1CF1260C-4DD0-4ebb-811F-33C572699FDE}";
                    string IMAG_GUID = "{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}";
                    string VIDE_GUID = "{A0953C92-50DC-43bf-BE83-3742FED03C9C}";
                    string DOCE_GUID = "{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}";
                    string sgcf = Application.StartupPath + @"\Config\SystemGear_GUIDSINFO.SGCF";
                    string tag = listView1.SelectedItems[0].Tag.ToString();
                    if (tag.ToUpper() != DOWN_GUID.ToUpper() && tag.ToUpper() != DESK_GUID.ToUpper() && tag.ToUpper() != MUSI_GUID.ToUpper() && tag.ToUpper() != IMAG_GUID.ToUpper() && tag.ToUpper() != VIDE_GUID.ToUpper() && tag.ToUpper() != DOCE_GUID.ToUpper() && tag.ToUpper() != "{B98A2BEA-7D42-4558-8BD1-832F41BAC6FD}".ToUpper() && tag.ToUpper() != "{0142e4d0-fb7a-11dc-ba4a-000ffe7ab428}".ToUpper() && tag.ToUpper() != "{8e74d236-7f35-4720-b138-1fed0b85ea75}".ToUpper())
                    {
                        name = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(tag, "name", "", false, sgcf);
                        if (name == "计算机" && MyFunctions.ApplicationAndEnvironmentInformation.OperatingSystemInfo.GetOSVersion() == "6.3")
                        {
                            name = "这台电脑";
                        }
                        guid = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue(tag, "guid", "", false, sgcf);
                    }
                    else
                    {
                        guid = tag;
                        if (tag.ToUpper() == DOWN_GUID.ToUpper())
                        {
                            name = "下载";
                        }
                        else
                        {
                            if (tag.ToUpper() == DESK_GUID.ToUpper())
                            {
                                name = "桌面";
                            }
                            else
                            {
                                if (tag.ToUpper() == MUSI_GUID.ToUpper())
                                {
                                    name = "音乐";
                                }
                                else
                                {
                                    if (tag.ToUpper() == IMAG_GUID.ToUpper())
                                    {
                                        name = "图片";
                                    }
                                    else
                                    {
                                        if (tag.ToUpper() == VIDE_GUID.ToUpper())
                                        {
                                            name = "视频";
                                        }
                                        else
                                        {
                                            if (tag.ToUpper() == DOCE_GUID.ToUpper())
                                            {
                                                name = "文档";
                                            }
                                            else
                                            {
                                                if (tag.ToUpper() == "{B98A2BEA-7D42-4558-8BD1-832F41BAC6FD}".ToUpper())
                                                {
                                                    name = "Windows 7文件恢复";
                                                }
                                                else
                                                {
                                                    if (tag.ToUpper() == "{0142e4d0-fb7a-11dc-ba4a-000ffe7ab428}".ToUpper())
                                                    {
                                                        name = "生物特征设备";
                                                    }
                                                    else
                                                    {
                                                        if (tag.ToUpper() == "{8e74d236-7f35-4720-b138-1fed0b85ea75}".ToUpper())
                                                        {
                                                            name = "SkyDrive";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
           // button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyFunctions.ProgramAndLinksOperate.ShellPrograms(Environment.GetEnvironmentVariable("windir")+@"\explorer.exe", "Shell:::" + guid, false, false, false, false, false);
        }
    }
}
