using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SystemGear
{
    
    public partial class UserControl_ClipOperate : UserControl
    {
        public bool IsLoad = true;
        public UserControl_ClipOperate()
        {
            InitializeComponent();
            
        }
        public void LoadSetting()
        {
            IsLoad = true;
            string auto_text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("autoanswer", "text", "f", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf").ToUpper();
            string auto_image = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("autoanswer", "image", "f", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf").ToUpper();
            string auto_file = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("autoanswer", "files", "f", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf").ToUpper();
            ///////folder////////
            string folder_files = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("files", "folder", "U", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf").ToUpper();
            string folder_image = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "folder", "U", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf").ToUpper();
            string folder_text = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("text", "folder", "U", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf").ToUpper();
            ////////////////////
            if (auto_file == "T") { checkBox1.Checked = true; } else { checkBox1.Checked = false; }
            if (auto_image == "T") { checkBox4.Checked = true; } else { checkBox4.Checked = false; }
            if (auto_text == "T") { checkBox12.Checked = true; } else { checkBox12.Checked = false; }
            ////////////////////FILES
            if (auto_file == "T")
            {
                if (folder_files == "U")
                {
                    radioButton4.Checked = true;
                    //radioButton3.Checked = false;
                }
                else
                {
                    radioButton4.Checked = false;
                    //radioButton3.Checked =true;
                }
            }
            ///////////////////IMAGE
            if (auto_image == "T")
            {
                if (folder_image == "U")
                {
                    radioButton7.Checked = true;
                    //radioButton8.Checked = false;
                }
                else
                {
                    radioButton8.Checked = true;
                    //radioButton7.Checked = false;
                }
                ////type
                string get = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "type", "JPG", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf").ToUpper().Replace(" ", "");
                switch (get.ToUpper())
                {
                    case "PNG":
                        comboBox1.SelectedIndex =1;
                        break;
                    case "GIF":
                        comboBox1.SelectedIndex = 2;
                        break;
                    case "BMP":
                        comboBox1.SelectedIndex = 3;
                        break;
                    default :
                        comboBox1.SelectedIndex = 0;
                        break;
                }
                string vw = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "size_w", "0", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf");
                string vh = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "size_h", "0", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf");
               if(vw =="" && vh =="")
               {
                   checkBox6.Checked = false;
               }
               else
               {
                int w = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "size_w", "0", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf"), 0);
                int h = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("image", "size_h", "0", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf"), 0);
                numericUpDown2.Value = w;
                numericUpDown3.Value = h;
                checkBox6.Checked = true;
               }
            }
            ///////////////TEXT
            if (auto_text == "T")
            {
                if (folder_text == "U")
                {
                    radioButton2.Checked = true;
                    //radioButton1.Checked = false;
                }
                else
                {
                    radioButton1.Checked = true;
                   // radioButton2.Checked = false;
                }
                string get = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("text", "type", "TXT", false, Application.StartupPath + @"\config\ClipboardAutoAnswer.sgcf").ToUpper().Replace(" ", "");
                switch (get.ToUpper())
                {
                    case "RTF":
                        comboBox2.SelectedIndex = 1;
                        break;
                    default:
                        comboBox2.SelectedIndex = 0;
                        break;
                }
            }
            IsLoad = false;
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void label147_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                radioButton7.Enabled = radioButton8.Enabled = true;
                checkBox6.Enabled = numericUpDown2.Enabled = numericUpDown3.Enabled = true;
                comboBox1.Enabled = true;
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("AutoAnswer", "Image", "T", "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
            }
            else
            {
                radioButton7.Enabled = radioButton8.Enabled = false;
                checkBox6.Enabled = numericUpDown2.Enabled = numericUpDown3.Enabled =false;
                comboBox1.Enabled = false;
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("AutoAnswer", "Image", "F", "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                radioButton1.Enabled = radioButton2.Enabled = true;
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("AutoAnswer", "Text", "T", "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                comboBox2.Enabled = true;
            }
            else
            {
                radioButton1.Enabled = radioButton2.Enabled = false;
                comboBox2.Enabled = false;
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("AutoAnswer", "Text", "F", "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                radioButton3.Enabled = radioButton4.Enabled = true;
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("AutoAnswer", "Files", "T", "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
            }
            else
            {
                radioButton3.Enabled = radioButton4.Enabled = false;
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("AutoAnswer", "Files", "F", "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
            }
        }

        private void UserControl_ClipOperate_Load(object sender, EventArgs e)
        {
            this.LoadSetting();
        }

        private void radioButton7_Click(object sender, EventArgs e)
        {
            if (IsLoad == false)
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Image", "Folder", "U", "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                this.LoadSetting();
            }
        }

        private void radioButton8_Click(object sender, EventArgs e)
        {
            if (IsLoad == false)
            {
                string folder = MyFunctions.Dialogs.OpenFolder("选择文件夹");
                if (System.IO.Directory.Exists(folder) == true)
                {
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Image", "Folder", folder, "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                    
                }
                this.LoadSetting();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (IsLoad == false)
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Image", "Size_W",numericUpDown2.Value.ToString(), "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                this.LoadSetting();
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (IsLoad == false)
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Image", "Size_H", numericUpDown3.Value.ToString(), "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                this.LoadSetting();
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == false)
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Image", "Size_H", "", "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Image", "Size_W", "", "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
            }
            else
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Image", "Size_W", numericUpDown2.Value.ToString(), "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Image", "Size_H", numericUpDown3.Value.ToString(), "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
            }
            this.LoadSetting();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (IsLoad == false)
            {
                string folder = MyFunctions.Dialogs.OpenFolder("选择文件夹");
                if (System.IO.Directory.Exists(folder) == true)
                {
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Text", "Folder", folder, "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                }
                this.LoadSetting();
            }
        }

        private void radioButton2_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (IsLoad == false)
            {
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Text", "Folder", "U", "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                this.LoadSetting();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsLoad == false)
                {
                    string type = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Image", "Type", type, "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                    this.LoadSetting();
                }
            }
            catch { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsLoad == false)
                {
                    string type = comboBox2.Items[comboBox2.SelectedIndex].ToString();
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Text", "Type", type, "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                    this.LoadSetting();
                }
            }
            catch { }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            if (IsLoad == false)
            {
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Files", "Folder", "U", "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                this.LoadSetting();
            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            if (IsLoad == false)
            {
                string folder = MyFunctions.Dialogs.OpenFolder("选择文件夹");
                if (System.IO.Directory.Exists(folder) == true)
                {
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Files", "Folder", folder, "Config", false, Application.StartupPath + @"\Config\ClipboardAutoAnswer.sgcf");
                }
                this.LoadSetting();
            }
        }
    }
}
