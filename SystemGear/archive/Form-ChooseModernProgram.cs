using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SystemGear
{
    
    public partial class Form_ChooseModernProgram : Form
    {
        public string[] rets=new string[]{"","",""};
        public Form_ChooseModernProgram(string title)
        {
            InitializeComponent();
            this.Text = label1.Text = title;
        }

        private void Form_ChooseModernProgram_Load(object sender, EventArgs e)
        {
            Loadwinapp();
        }
        public void Loadwinapp()
        {
            string sgcf = Application.StartupPath + @"\Config\WinAppInfo.sgcf";
            try
            {
                int c;
                string j = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("winappinfo", "count", "0", false, sgcf);
                int.TryParse(j, out c);
                listView1.Items.Clear();
                imageList1.Images.Clear();
                for(int p=1;p<=c;p++)
                {
                    string pp = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("winappinfo","winapp_"+p.ToString(), "", false, sgcf);
                    string[] ke = pp.Split('|');
                    string id = ke[0];
                    string name = ke[1];
                    string ico = ke[2];
                    Bitmap b = MyFunctions.MediaAndResourcesOperate.ImageOperate.ImageOperate_LoadIconsFormResourcesFileIcon(ico + ",0", "%windir%\\system32\\imageres.dll,2");
                    imageList1.Images.Add(b);
                    listView1.Items.Add(name).SubItems.Add(id);
                    listView1.Items[p-1].SubItems.Add(ke[3]);
                    listView1.Items[p - 1].ImageIndex = p - 1;
                    listView1.Items[p - 1].Tag = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocation(ico,ico );
                }
            }
            catch { }
        }

        private void myNormalButton4_OnButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 1)
                {
                    rets = new string[] { listView1.SelectedItems[0].Text , listView1.SelectedItems[0].SubItems[1].Text,listView1.SelectedItems[0].Tag.ToString() };
                }
                else
                {
                    rets = new string[] { "", "","" };
                }
                this.Close();
            }
            catch { }
        }

        private void myNormalButton1_OnButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 1)
                {
                    MyFunctions.ProgramAndLinksOperate.ShellPrograms("EXPLORER.EXE", @"shell:::{4234d49b-0245-4df3-b780-3893943456e1}\" + listView1.SelectedItems[0].SubItems[1].Text, false, false, false, true, false);
                }
                else
                {
                    //rets = new string[] { "", "" };
                }
                //this.Close();
            }
            catch { }
        }

        private void myNormalButton2_OnButtonClick(object sender, EventArgs e)
        {
            rets = new string[] {"","","" };
        }
    }
}
