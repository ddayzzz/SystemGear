using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinImageTool
{
    public partial class Form1 : Form
    {
        public string FormChoose;
        public string SettingsChoose;
        public string[] Command;
        public Form1(string[] args)
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 2;
            textBox3.Text =textBox4.Text= "Windows 映像";
            Command = args;
        }
        void EXT()
        {
            if (System.IO.File.Exists(textBox12.Text) == true && comboBox6.Enabled == true)
            {
                string cmds = @"/export """ + textBox12.Text + @""" " + (comboBox6.SelectedIndex + 1).ToString() + @" """ + textBox13.Text + @""" """ + textBox14.Text + @"""";
                switch (comboBox6.SelectedIndex)
                {
                    case 0:
                        cmds = cmds + " /compress none";
                        break;
                    case 1:
                        cmds = cmds + " /compress fast";
                        break;
                    case 2:
                        cmds = cmds + " /compress maximum";
                        break;
                }
                //boot
                if (checkBox12.Checked == true) { cmds = cmds + @" /boot"; }
                //check
                if (checkBox12.Checked == true) { cmds = cmds + @" /check"; }
                Form_Progress f = new Form_Progress("EXPORT", cmds, textBox13.Text, false);
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();
            }
        }
        void CMDSplit()
        {
            if (System.IO.File.Exists(textBox15.Text) == true && textBox16.Text != "" && textBox17.Text != "")
            {
                string cmd;
                cmd = @"/split """ + textBox15.Text + @""" """ + textBox17.Text + @""" " + textBox16.Text;
                if (checkBox14.Checked == true) { cmd = cmd + @" /check"; }
                Form_Progress f = new Form_Progress("SPLIT", cmd, textBox15.Text + @"*SAVE", false);
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();
            }
        }
        void CMDAPPEND()
        {
            if (System.IO.File.Exists(textBox18.Text) == true && System.IO.Directory.Exists(textBox19.Text) && textBox20.Text != "")
            {
                string cmd = @"/append """ + textBox19.Text + @""" """ + textBox18.Text + @""" """ + textBox20.Text + @"""";
                //boot
                if (checkBox18.Checked == true) { cmd = cmd + " /boot"; }
                //check
                if (checkBox17.Checked == true) { cmd = cmd + " /check"; }
                //verify
                if (checkBox16.Checked == true) { cmd = cmd + " /verify"; }
                //scroll
                if (checkBox15.Checked == true) { cmd = cmd + " /scroll"; }
                Form_Progress f = new Form_Progress("APPEND", cmd, textBox18.Text, false);
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();
            }
        }
        void CreateWimInCommand()
        {
            if (System.IO.Directory.Exists(textBox1.Text) == true && textBox2.Text != "")
            {
                string cmd = @"/capture """ + textBox1.Text + @""" """ + textBox2.Text + @""" """ + textBox3.Text + @""" """ + textBox4.Text + @"""";
                if (checkBox1.Checked == true) { cmd = cmd + " /Boot"; }
                if (checkBox2.Checked == true) { cmd = cmd + " /Check"; }
                //获取压缩率
                if (comboBox2.SelectedIndex != null)
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            cmd = cmd + @" /compress none";
                            break;
                        case 1:
                            cmd = cmd + @" /compress fast";
                            break;
                        case 2:
                            cmd = cmd + @" /compress maximum";
                            break;
                    }
                }
                //使用的配置文件
                if (System.IO.File.Exists(textBox5.Text) == true) { cmd = cmd + @" /config """ + textBox5.Text + @""""; }
                //设置版本
                if (comboBox1.SelectedIndex >= 0)
                {
                    cmd = cmd + @" /flags """ + comboBox1.Items[comboBox1.SelectedIndex] + @"""";
                }
                //norpfix
                if (checkBox4.Checked == true) { cmd = cmd + @" /norpfix"; }
                //scroll
                if (checkBox5.Checked == true) { cmd = cmd + @" /scroll"; }
                //norpfix
                if (checkBox3.Checked == true) { cmd = cmd + @" /verify"; }
                Form_Progress frm = new Form_Progress("CREATE", cmd, textBox2.Text,false);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }
        void ApplyImageInCommand()
        {
            if (System.IO.File.Exists(textBox7.Text) == true && comboBox3.Enabled == true)
            {

                if (System.IO.Directory.Exists(textBox8.Text) == false) { System.IO.Directory.CreateDirectory(textBox8.Text); }
                string cmd = @"/apply """ + textBox7.Text + @""" " + (1 + comboBox3.SelectedIndex).ToString() + @" """ + textBox8.Text + @"""";
                //norpfix
                if (checkBox9.Checked == true) { cmd = cmd + @" /norpfix"; }
                //scroll
                if (checkBox8.Checked == true) { cmd = cmd + @" /scroll"; }
                //verify
                if (checkBox10.Checked == true) { cmd = cmd + @" /verify"; }
                //check
                if (checkBox11.Checked == true) { cmd = cmd + @" /check"; }
                Form_Progress frm = new Form_Progress("APPLY", cmd, textBox8.Text, false);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show(@"映像 """ + textBox7.Text + @""" 未找到或不是有效的Windows映像文件 , 请检查该文件是否存在", "文件未找到", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void DeleteImageInCommand()
        {
            if (Command.Length == 4)
            {
                string wim = Command[0].Substring(8, Command[0].Length - 8);
                string deleteindex = Command[2].Substring(12, Command[2].Length - 12);
                if (System.IO.File.Exists(wim) == true)
                {
                    panel4.Visible = false;
                    tabControl1.Location = new Point(14, 62);
                    tabControl1.Visible = true;
                    pictureBox1.Visible = true;
                    FormChoose = "SETTINGS";
                    label40.Visible = true;
                    label40.Text = "映像综合编辑";
                    tabControl1.SelectedIndex = 2;
                    this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 10, tabControl1.Location.Y + tabControl1.Size.Height + 15);
                    panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
                    panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
                    tabControl2.SelectedIndex = 0;
                    SettingsChoose = "1";
                    label17.ForeColor = Color.FromArgb(0, 148, 255);
                    label18.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
                    int count;
                    string images;
                    Class1.Public_GetImageItems(wim, out count, out images, false, "");
                    int newdeleteindex;
                    int.TryParse(deleteindex, out newdeleteindex);
                    if (newdeleteindex <= count)
                    {
                        string cmd = @"/delete """+wim+@""" "+newdeleteindex.ToString();
                        string runnow = Command[3].Substring(8+3, Command[3].Length - 11);
                        if (runnow.ToUpper() == "TRUE")
                        {
                            Form_Progress F = new Form_Progress("DELETE", cmd, "", false);
                            F.StartPosition = FormStartPosition.CenterScreen;
                            F.ShowDialog();
                            Application.ExitThread();
                        }
                        else
                        {

                            textBox10.Text = wim;
                            if (count > 0)
                            {
                                comboBox4.Items.Clear();
                                comboBox4.Enabled = true;
                                string[] imgs = images.Split('|');
                                for (int j = 1; j <= count; j++)
                                {

                                    comboBox4.Items.Add(j.ToString() + " " + imgs[j - 1]);
                                }
                                comboBox4.SelectedIndex = 0;
                            }
                            else
                            {
                                comboBox4.Items.Clear();
                                comboBox4.Enabled = false;
                            }
                            if (newdeleteindex <= comboBox4.Items.Count)
                            {
                                comboBox4.SelectedIndex = newdeleteindex - 1;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"无法删除映像卷""" + wim + @""".因为映像卷""" +deleteindex + @"""对于该映像无效", "无法删除映像卷", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("无法识别指定的参数", "启动失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void InfoImageInCommand()
        {
            panel4.Visible = false;
            tabControl1.Location = new Point(14, 62);
            tabControl1.Visible = true;
            pictureBox1.Visible = true;
            FormChoose = "SETTINGS";
            label40.Visible = true;
            label40.Text = "映像综合编辑";
            tabControl1.SelectedIndex = 2;
            this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 10, tabControl1.Location.Y + tabControl1.Size.Height + 15);
            panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
            panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
            tabControl2.SelectedIndex = 1;
            SettingsChoose = "2";
            label18.ForeColor = Color.FromArgb(0, 148, 255);
            label17.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
            if (Command.Length == 2)
            {
                string wim = Command[0].Substring(8, Command[0].Length - 8);
                if (System.IO.File.Exists(wim) == true)
                {
                    string infofull;
                    Class1.Public_GetImageOrgInfo(wim, out infofull, false, "");
                    GetWimInfo_IsFenWim = false;
                    int count;
                    string temp;
                    string[] imgs;
                    Class1.Public_GetImageItems(wim, out count, out temp, false, "");
                    imgs = temp.Split('|');
                    textBox9.Text = wim;
                    if (imgs.Length > 0)
                    {
                        comboBox5.Items.Clear();
                        for (int h = 1; h <= imgs.Length; h++)
                        {
                            comboBox5.Items.Add(h.ToString() + " " + imgs[h - 1]);
                        }
                        comboBox5.SelectedIndex = 0;
                        comboBox5.Enabled = true;
                    }
                    else
                    {
                        label23.Text = "0";
                        comboBox5.Enabled = false;
                    }
                    label23.Text = comboBox5.Items.Count.ToString();
                    label23.Visible = true;
                }
            }
            else
            {   
                if (Command.Length == 3)
                {
                        string wim = Command[0].Substring(8, Command[0].Length - 8);
                        if (System.IO.File.Exists(wim) == true)
                        {
                            string txt = Command[2].Substring(14, Command[2].Length - 14);
                            string newpath = txt;
                            if (newpath.ToUpper() == "SELECTPATH")
                            {
                                newpath = System.IO.Path.GetDirectoryName(wim) + "\\" + System.IO.Path.GetFileName(wim) + @"的详细信息.txt";
                            }
                            string infofull;
                            Class1.Public_GetImageOrgInfo(wim, out infofull, false, "");
                            if (System.IO.File.Exists(newpath) == true) { System.IO.File.Delete(newpath); }
                            System.IO.StreamWriter sw = new System.IO.StreamWriter(newpath, false, Encoding.UTF8);
                            sw.Write(infofull);
                            sw.Close();
                            Application.ExitThread();
                        }
                }
                else
                {
                    MessageBox.Show("指定的参数不完整", "无法识别启动参数", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void ExportImageInCommand()
        {
            if (Command.Length >= 5)
            {
                panel4.Visible = false;
                tabControl1.Location = new Point(14, 62);
                tabControl1.Visible = true;
                pictureBox1.Visible = true;
                FormChoose = "SETTINGS";
                label40.Visible = true;
                label40.Text = "映像综合编辑";
                tabControl1.SelectedIndex = 2;
                this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 10, tabControl1.Location.Y + tabControl1.Size.Height + 15);
                panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
                panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
                tabControl2.SelectedIndex = 2;
                SettingsChoose = "3";
                label19.ForeColor = Color.FromArgb(0, 148, 255);
                label17.ForeColor = label18.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
                string wim = Command[0].Substring(8, Command[0].Length - 8);
                string index = Command[2].Substring(12, Command[2].Length - 12);
                string newwim = Command[3].Substring(12, Command[3].Length - 12);
                if (System.IO.File.Exists(wim) == true)
                {
                    if (Command.Length == 5)
                    {
                        string savewim = newwim;
                        if (newwim.ToUpper() == "SELECTPATH")
                        {
                            savewim = System.IO.Path.GetDirectoryName(wim) + "\\" + System.IO.Path.GetFileName(wim) + "的导出副本.wim";
                        }
                        int count;
                        string names;
                        Class1.Public_GetImageItems(wim, out count, out names, false, "");
                        int newindex;
                        int.TryParse(index, out newindex);
                        if (newindex <= count)
                        {
                            string runnow = Command[4].Substring(8 + 3, Command[4].Length - 11);
                            if (runnow.ToUpper() == "TRUE")
                            {
                                string cmd = @"/export """ + wim + @""" " + newindex.ToString() + @" """ + savewim + @""" ""导出的映像文件""";
                                Form_Progress F = new Form_Progress("EXPORT", cmd, "", false);
                                F.StartPosition = FormStartPosition.CenterScreen;
                                F.ShowDialog();
                                Application.ExitThread();
                            }
                            else
                            {
                                textBox12.Text = wim;
                                string[] imgs;
                                imgs = names.Split('|');
                                comboBox6.Enabled = true;
                                if (imgs.Length > 0)
                                {
                                    comboBox6.Items.Clear();
                                    for (int h = 1; h <= imgs.Length; h++)
                                    {
                                        comboBox6.Items.Add(h.ToString() + " " + imgs[h - 1]);
                                    }
                                    comboBox6.SelectedIndex = newindex - 1;
                                }
                                else
                                {
                                    comboBox6.Enabled = false;
                                }
                                textBox13.Text = savewim;
                                comboBox7.SelectedIndex = 2;
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        for (int s = 5; s <= Command.Length - 1; s++)
                        {
                            string cmdname = Command[s].Substring(1, Command[s].IndexOf("=") - 1);
                            switch (Command[s].Substring(0, Command[s].IndexOf("=")).Length + 1)
                            {
                                case 6:
                                    if (Command[s].Substring(6, Command[s].Length - 6).ToUpper() == "TRUE") { checkBox12.Checked = true; } else { checkBox12.Checked = false; } //boot
                                    break;
                                case 7:
                                    if (Command[s].Substring(7, Command[s].Length - 7).ToUpper() == "TRUE") { checkBox13.Checked = true; } else { checkBox13.Checked = false; } //check
                                    break;
                                case 8:
                                    break;
                                case 10:
                                    switch (Command[s].Substring(10, Command[s].Length - 10).ToLower())
                                    {
                                        case "none":
                                            comboBox7.SelectedIndex = 0;
                                            break;
                                        case "maximum":
                                            comboBox7.SelectedIndex = 2;
                                            break;
                                        case "fast":
                                            comboBox7.SelectedIndex = 1;
                                            break;
                                    }
                                    break;
                                case 11:
                                    if (cmdname.ToUpper() == "IMAGENAME")
                                    {
                                        textBox14.Text = Command[s].Substring(11, Command[s].Length - 11);
                                    }
                                    else
                                    {
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        string savewim = newwim;
                        if (newwim.ToUpper() == "SELECTPATH")
                        {
                            savewim = System.IO.Path.GetDirectoryName(wim) + "\\" + System.IO.Path.GetFileName(wim) + "的导出副本.wim";
                        }
                        textBox13.Text = savewim;
                        textBox12.Text = wim;
                        int count;
                        string names;
                        Class1.Public_GetImageItems(wim, out count, out names, false, "");
                        int newindex;
                        int.TryParse(index, out newindex);
                        string[] imgs;
                        imgs = names.Split('|');
                        comboBox6.Enabled = true;
                        if (imgs.Length > 0)
                        {
                            comboBox6.Items.Clear();
                            for (int h = 1; h <= imgs.Length; h++)
                            {
                                comboBox6.Items.Add(h.ToString() + " " + imgs[h - 1]);
                            }
                            comboBox6.SelectedIndex = newindex - 1;
                        }
                        else
                        {
                            comboBox6.Enabled = false;
                        }
                        if (newindex <= count)
                        {
                            comboBox6.SelectedIndex = newindex - 1;  
                        }
                        string runnow = Command[4].Substring(8 + 3, Command[4].Length - 11);
                        if (runnow.ToUpper() == "TRUE")
                        {
                            this.EXT();
                        }
                    }
                }
                else
                {
                }
            }
        }
        void AppendImageInCommand()
        {
            if (Command.Length >= 4)
            {
                panel4.Visible = false;
                tabControl1.Location = new Point(14, 62);
                tabControl1.Visible = true;
                pictureBox1.Visible = true;
                FormChoose = "SETTINGS";
                label40.Visible = true;
                label40.Text = "映像综合编辑";
                tabControl1.SelectedIndex = 2;
                this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 10, tabControl1.Location.Y + tabControl1.Size.Height + 15);
                panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
                panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
                tabControl2.SelectedIndex = 4;
                SettingsChoose = "5";
                label21.ForeColor = Color.FromArgb(0, 148, 255);
                label17.ForeColor = label18.ForeColor = label20.ForeColor = label19.ForeColor = Color.FromArgb(149, 149, 149);
                string wim = Command[0].Substring(8, Command[0].Length - 8);
                string folder = Command[2].Substring(12, Command[2].Length - 12);
                if (System.IO.File.Exists(wim) == true && System.IO.Directory.Exists(folder)==true)
                {
                    if (Command.Length == 4)
                    {
                            string runnow = Command[3].Substring(8 + 3, Command[3].Length - 11);
                            if (runnow.ToUpper() == "TRUE")
                            {
                                string imagename="附加的映像-"+System.IO.Path.GetRandomFileName().Replace(".","").ToUpper();
                                string cmd = @"/append """ + folder + @""" """ + wim + @""" """ + imagename + @""" /verify";
                                Form_Progress F = new Form_Progress("APPEND", cmd, "", false);
                                F.StartPosition = FormStartPosition.CenterScreen;
                                F.ShowDialog();
                                Application.ExitThread();            
                        }
                        else
                        {
                            textBox18.Text = wim;
                            textBox19.Text = folder;
                        }
                    }
                    else
                    {
                        label21.ForeColor = Color.FromArgb(0, 148, 255);
                        label21.ForeColor = label18.ForeColor = label20.ForeColor = label19.ForeColor = Color.FromArgb(149, 149, 149);
                        for (int s = 4; s <= Command.Length - 1; s++)
                        {
                            string cmdname = Command[s].Substring(1, Command[s].IndexOf("=") - 1);
                            switch (Command[s].Substring(0, Command[s].IndexOf("=")).Length + 1)
                            {
                                case 6:
                                    if (Command[s].Substring(6, Command[s].Length - 6).ToUpper() == "TRUE") { checkBox18.Checked = true; } else { checkBox18.Checked = false; } //boot
                                    break;
                                case 7:
                                    if (Command[s].Substring(7, Command[s].Length - 7).ToUpper() == "TRUE") { checkBox17.Checked = true; } else { checkBox17.Checked = false; } //check
                                    break;
                                case 8:
                                    if (cmdname.ToUpper() == "VERIFY")
                                    {
                                        if (Command[s].Substring(8, Command[s].Length - 8).ToUpper() == "TRUE") { checkBox16.Checked = true; } else { checkBox16.Checked = false; } //VERIFY
                                    }
                                    else
                                    {
                                        if (cmdname.ToUpper() == "SCROLL")
                                        {
                                            if (Command[s].Substring(8, Command[s].Length - 8).ToUpper() == "TRUE") { checkBox15.Checked = true; } else { checkBox15.Checked = false; } //SCROLL
                                        }
                                    }
                                    break;
                                case 11:
                                    if (cmdname.ToUpper() == "IMAGENAME")
                                    {
                                        textBox20.Text = Command[s].Substring(11, Command[s].Length - 11);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        string runnow = Command[3].Substring(8 + 3, Command[3].Length - 11);
                        textBox18.Text = wim;
                        textBox19.Text = folder;
                        if (runnow.ToUpper() == "TRUE")
                        {
                            this.CMDAPPEND();
                            Application.ExitThread();
                        }
                    }
                }
                else
                {
                    textBox18.Text = wim;
                }
            }
        }
        void SplitImageInCommand()
        {
            if (Command.Length >= 5)
            {
                panel4.Visible = false;
                tabControl1.Location = new Point(14, 62);
                tabControl1.Visible = true;
                pictureBox1.Visible = true;
                FormChoose = "SETTINGS";
                label40.Visible = true;
                label40.Text = "映像综合编辑";
                tabControl1.SelectedIndex = 2;
                this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 10, tabControl1.Location.Y + tabControl1.Size.Height + 15);
                panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
                panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
                tabControl2.SelectedIndex = 3;
                SettingsChoose = "4";
                label20.ForeColor = Color.FromArgb(0, 148, 255);
                label17.ForeColor = label18.ForeColor = label19.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
                string wim = Command[0].Substring(8, Command[0].Length - 8);
                string save = Command[3].Substring(10, Command[3].Length - 10);
                string size = Command[2].Substring(6, Command[2].Length - 6);
                if (System.IO.File.Exists(wim) == true)
                {
                    if (Command.Length == 5)
                    {
                        string swm = save;
                        if (swm.ToUpper() == "SELECTPATH")
                        {
                            swm= System.IO.Path.GetDirectoryName(wim) + "\\" + System.IO.Path.GetFileName(wim) + "的拆分文件.swm";
                        }
                        string runnow = Command[4].Substring(10, Command[4].Length - 10);
                        if (runnow.ToUpper() == "TRUE")
                        {
                            string cmd = @"/split """ + wim + @""" """ + swm + @""" " + size;
                            Form_Progress f = new Form_Progress("SPLIT", cmd, wim+"*SAVE", false);
                            f.StartPosition = FormStartPosition.CenterScreen;
                            f.ShowDialog();
                            Application.ExitThread();
                        }
                        else
                        {
                            textBox15.Text = wim;
                            textBox16.Text = size;
                            textBox17.Text = swm;
                        }
                    }
                    else
                    {
                        for (int s = 5; s <= Command.Length - 1; s++)
                        {
                            string cmdname = Command[s].Substring(1, Command[s].IndexOf("=") - 1);
                            switch (Command[s].Substring(0, Command[s].IndexOf("=")).Length + 1)
                            {
                                case 6:
                                    break;
                                case 7:
                                    if (Command[s].Substring(7, Command[s].Length - 7).ToUpper() == "TRUE") { checkBox14.Checked = true; } else { checkBox14.Checked = false; } //check
                                    break;
                                case 8:
                                    break;
                                case 10:
                                    break;
                                case 11:
                                    break;
                                default:
                                    break;
                            }
                        }
                        string swm = save;
                        if (swm.ToUpper() == "SELECTPATH")
                        {
                            swm = System.IO.Path.GetDirectoryName(wim) + "\\" + System.IO.Path.GetFileName(wim) + "的拆分文件.swm";
                        }
                        textBox15.Text = wim;
                        textBox16.Text = size;
                        textBox17.Text = swm;
                        string runnow = Command[4].Substring(8 + 3-1, Command[4].Length - 11+1);
                        if (runnow.ToUpper() == "TRUE")
                        {
                            this.CMDSplit();
                            Application.ExitThread();
                        }
                    }
                }
                else
                {
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            
            //Form_Progress f = new Form_Progress("52","");
            //f.ShowDialog();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                textBox6.Enabled = checkBox7.Enabled = true;
            }
            else
            {
                textBox6.Enabled = checkBox7.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description ="要捕获的目录";
            folderBrowserDialog1.ShowDialog();
            string open = folderBrowserDialog1.SelectedPath;
            if (System.IO.Directory.Exists(open) == true)
            {
                textBox1.Text = open;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "保存映像";
            saveFileDialog1.Filter = "Windows 映像文件(*.wim)|*.wim";
            saveFileDialog1.ShowDialog();
            string f = saveFileDialog1.FileName;
            if (System.IO.File.Exists(f) == true)
            {
                int count;
                string name;
                Class1.Public_GetImageItems(f, out count, out name,false,"");
                if (count > 0)
                {
                    button11.Enabled = true;
                }
                else
                {
                    button11.Enabled = false;
                }
            }
            else
            {
                button11.Enabled = false;
            }
            textBox2.Text = f;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (checkBox6.Checked == false)
            {
                if (System.IO.Directory.Exists(textBox1.Text) == true && textBox2.Text != "")
                {
                    string cmd = @"/capture """ + textBox1.Text + @""" """ + textBox2.Text + @""" """ + textBox3.Text + @""" """ + textBox4.Text + @"""";
                    if (checkBox1.Checked == true) { cmd = cmd + " /Boot"; }
                    if (checkBox2.Checked == true) { cmd = cmd + " /Check"; }
                    //获取压缩率
                    if (comboBox2.SelectedIndex != null)
                    {
                        switch (comboBox2.SelectedIndex)
                        {
                            case 0:
                                cmd = cmd + @" /compress none";
                                break;
                            case 1:
                                cmd = cmd + @" /compress fast";
                                break;
                            case 2:
                                cmd = cmd + @" /compress maximum";
                                break;
                        }
                    }
                    //使用的配置文件
                    if (System.IO.File.Exists(textBox5.Text) == true) { cmd = cmd + @" /config """ + textBox5.Text + @""""; }
                    //设置版本
                    if (comboBox1.SelectedIndex >= 0)
                    {
                        cmd = cmd + @" /flags """ + comboBox1.Items[comboBox1.SelectedIndex] + @"""";
                    }
                    //norpfix
                    if (checkBox4.Checked == true) { cmd = cmd + @" /norpfix"; }
                    //scroll
                    if (checkBox5.Checked == true) { cmd = cmd + @" /scroll"; }
                    //norpfix
                    if (checkBox3.Checked == true) { cmd = cmd + @" /verify"; }
                    Form_Progress frm = new Form_Progress("CREATE", cmd, textBox2.Text,true);
                    frm.ShowDialog();
                }
                else
                {
                    if (System.IO.Directory.Exists(textBox1.Text) == false) { MessageBox.Show("无法找到要捕获的目录", "目录未找到", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    if (textBox2.Text == "") { MessageBox.Show("请指定Windows 映像的保存位置", "无法保存映像", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
            {
                if (System.IO.Directory.Exists(textBox1.Text) == true && textBox2.Text != "")
                {
                    string cmd = @"/capture """ + textBox1.Text + @""" """ + textBox2.Text + @""" """ + textBox3.Text + @""" """ + textBox4.Text + @"""";
                    if (checkBox1.Checked == true) { cmd = cmd + " /Boot"; }
                    if (checkBox2.Checked == true) { cmd = cmd + " /Check"; }
                    //获取压缩率
                    if (comboBox2.SelectedIndex != null)
                    {
                        switch (comboBox2.SelectedIndex)
                        {
                            case 0:
                                cmd = cmd + @" /compress none";
                                break;
                            case 1:
                                cmd = cmd + @" /compress fast";
                                break;
                            case 2:
                                cmd = cmd + @" /compress maximum";
                                break;
                        }
                    }
                    //使用的配置文件
                    if (System.IO.File.Exists(textBox5.Text) == true) { cmd = cmd + @" /config """ + textBox5.Text + @""""; }
                    //设置版本
                    if (comboBox1.SelectedIndex >= 0)
                    {
                        cmd = cmd + @" /flags """ + comboBox1.Items[comboBox1.SelectedIndex] + @"""";
                    }
                    //norpfix
                    if (checkBox4.Checked == true) { cmd = cmd + @" /norpfix"; }
                    //scroll
                    if (checkBox5.Checked == true) { cmd = cmd + @" /scroll"; }
                    //norpfix
                    if (checkBox3.Checked == true) { cmd = cmd + @" /verify"; }
                    Form_Progress frm = new Form_Progress("CREATE", cmd, textBox2.Text, false);
                    frm.ShowDialog();
                    //拆分命令
                    string name = textBox2.Text.Substring(textBox2.Text.LastIndexOf("\\") + 1, textBox2.Text.Length - textBox2.Text.LastIndexOf("\\") - 1);
                    string pathname = textBox2.Text.Substring(0, textBox2.Text.LastIndexOf("\\"));
                    string newname = pathname + "\\拆分的映像" + name+".swm";
                    string size = textBox6.Text;
                    string del;
                    if (checkBox7.Checked == true) { del = "SAVE"; } else { del = "DELE"; }
                    Form_Progress frm1 = new Form_Progress("SPLIT", @"/split """+textBox2.Text +@""" """+newname +@""" "+size ,textBox2.Text +@"*"+del, false);
                    frm1.ShowDialog();
                }
                else
                {
                    if (System.IO.Directory.Exists(textBox1.Text) == false) { MessageBox.Show("无法找到要捕获的目录", "目录未找到", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    if (textBox2.Text == "") { MessageBox.Show("请指定Windows 映像的保存位置", "无法保存映像", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "所有文件(*.*)|*.*";
            openFileDialog1.Title = "打开配置文件";
            openFileDialog1.ShowDialog();
            string j = openFileDialog1.FileName;
            if (System.IO.File.Exists(j) == true)
            {
                textBox5.Text = j;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label13.Text = "映像文件 :";
                textBox7.Text = "";
                comboBox3.Enabled = false;
                comboBox3.Items.Clear();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label13.Text = "第一个分卷的路径 :";
                textBox7.Text = "";
                comboBox3.Enabled = false;
                comboBox3.Items.Clear();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Windows 映像文件(*.wim)|*.wim";
                openFileDialog1.Title = "选择映像文件";
                openFileDialog1.ShowDialog();
                string F = openFileDialog1.FileName;
                if (System.IO.File.Exists(F) == true)
                {
                    textBox7.Text = F;
                    int count;
                    string names;
                    Class1.Public_GetImageItems(F, out count, out names,false,"");
                    if (count > 0)
                    {
                        comboBox3.Items.Clear();
                        comboBox3.Enabled = true;
                        string[] imgs = names.Split('|');
                        for (int j = 1; j <= count; j++)
                        {

                            comboBox3.Items.Add(j.ToString() + " " + imgs[j - 1]);
                        }
                        comboBox3.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBox3.Items.Clear();
                        comboBox3.Enabled = false;
                    }
                }
            }
            else
            {
                comboBox3.Enabled = false;
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Windows 映像分卷文件(*.swm)|*.swm";
                openFileDialog1.Title = "选择映像的第一个分卷文件";
                openFileDialog1.ShowDialog();
                string F = openFileDialog1.FileName;
                if (System.IO.File.Exists(F) == true)
                {
                    textBox7.Text = F;
                    string folder = System.IO.Path.GetDirectoryName(F);
                    int count;
                    string names;
                    Class1.Public_GetImageItems(F, out count, out names, true, folder);

                    if (count > 0)
                    {
                        comboBox3.Items.Clear();
                        comboBox3.Enabled = true;
                        string[] imgs = names.Split('|');
                        for (int j = 1; j <= count; j++)
                        {

                            comboBox3.Items.Add(j.ToString() + " " + imgs[j - 1]);
                        }
                        comboBox3.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBox3.Items.Clear();
                        comboBox3.Enabled = false;
                    }
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = "";
            folderBrowserDialog1.Description = "请选择要应用的目录";
            folderBrowserDialog1.ShowDialog();
            string fol = folderBrowserDialog1.SelectedPath;

            if (System.IO.Directory.Exists(fol) == true)
            {
                textBox8.Text = fol;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (System.IO.File.Exists(textBox7.Text) == true && comboBox3.Enabled == true)
                {
                   
                    if (System.IO.Directory.Exists(textBox8.Text) == false) { System.IO.Directory.CreateDirectory(textBox8.Text); }
                    string cmd = @"/apply """ + textBox7.Text + @""" " + (1 + comboBox3.SelectedIndex).ToString() + @" """ + textBox8.Text + @"""";
                    //norpfix
                    if (checkBox9.Checked == true) { cmd = cmd + @" /norpfix"; }
                    //scroll
                    if (checkBox8.Checked == true) { cmd = cmd + @" /scroll"; }
                    //verify
                    if (checkBox10.Checked == true) { cmd = cmd + @" /verify"; }
                    //check
                    if (checkBox11.Checked == true) { cmd = cmd + @" /check"; }
                    Form_Progress frm = new Form_Progress("APPLY", cmd, textBox8.Text, true);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(@"映像 """ + textBox7.Text + @""" 未找到或不是有效的Windows映像文件 , 请检查该文件是否存在", "文件未找到", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (System.IO.File.Exists(textBox7.Text) == true && comboBox3.Enabled !=false)
                {
                    string folder = System.IO.Path.GetDirectoryName(textBox7.Text);
                    if (System.IO.Directory.Exists(textBox8.Text) == false) { System.IO.Directory.CreateDirectory(textBox8.Text); }
                    string cmd = @"/apply """ + textBox7.Text + @""" /ref """ +folder+@"\*.swm"" "+ (1 + comboBox3.SelectedIndex).ToString() + @" """ + textBox8.Text + @"""";
                    //norpfix
                    if (checkBox9.Checked == true) { cmd = cmd + @" /norpfix"; }
                    //scroll
                    if (checkBox8.Checked == true) { cmd = cmd + @" /scroll"; }
                    //verify
                    if (checkBox10.Checked == true) { cmd = cmd + @" /verify"; }
                    //check
                    if (checkBox11.Checked == true) { cmd = cmd + @" /check"; }
                    Form_Progress frm = new Form_Progress("APPLY", cmd, textBox8.Text, true);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(@"映像 """ + textBox7.Text + @""" 未找到或不是有效的Windows映像文件 , 请检查该文件是否存在", "文件未找到", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button16_Click(object sender, EventArgs e)
        {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Windows 映像文件(*.wim)|*.wim";
                openFileDialog1.Title = "选择映像文件";
                openFileDialog1.ShowDialog();
                string F = openFileDialog1.FileName;
                if (System.IO.File.Exists(F) == true)
                {
                    textBox10.Text = F;
                    int count;
                    string names;
                    Class1.Public_GetImageItems(F, out count, out names, false, "");
                    if (count > 0)
                    {
                        comboBox4.Items.Clear();
                        comboBox4.Enabled = true;
                        string[] imgs = names.Split('|');
                        for (int j = 1; j <= count; j++)
                        {

                            comboBox4.Items.Add(j.ToString() + " " + imgs[j - 1]);
                        }
                        comboBox4.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBox4.Items.Clear();
                        comboBox4.Enabled = false;
                    }
                }
            }
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                    if (comboBox4.SelectedIndex >= 0)
                    {
                        string imgname = comboBox4.Items[comboBox4.SelectedIndex].ToString();
                        DialogResult result = MessageBox.Show(@"确定删除映像卷""" + imgname + @"""吗?", "删除映像卷", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (System.IO.File.Exists(textBox10.Text) == true)
                            {
                                if (comboBox4.Items.Count > 1)
                                {
                                    Form_Progress frm = new Form_Progress("DELETE", @"/delete """ + textBox10.Text + @""" " + (comboBox4.SelectedIndex + 1).ToString(), textBox10.Text, true);
                                    frm.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show(@"无法删除映像卷""" + imgname + @""".因为该映像只存在一个映像卷", "无法删除映像卷", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show(@"找不到映像""" + textBox10.Text + @"""请检查文件是否存在", "文件不存在", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
            }
            catch { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(textBox1.Text) == true && System.IO.File.Exists(textBox2.Text)==true )
            {
                if (Class1.Public_GetImageNameIsHas(textBox2.Text, textBox3.Text) == false)
                {
                    string cmd = @"/append """ + textBox1.Text + @""" """ + textBox2.Text + @""" """ + textBox3.Text + @""" /verify";
                    Form_Progress frm = new Form_Progress("APPEND", cmd, textBox2.Text, true);
                    frm.ShowDialog();
                }
                else
                {
                    string j=@"无法附加映像到"""+textBox2.Text +@""".因为该映像已包含一个名为"""+textBox3.Text +@"""的映像卷.附加的映像卷的名称不能与已存在的映像卷的名称相同.";
                    MessageBox.Show(j, "无法附加映像", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public bool GetWimInfo_IsFenWim;
        private void button18_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "选择映像文件或分卷的第一个文件";
            openFileDialog1.Filter = "Windows 映像文件(*.wim)|*.wim|Windows 映像分卷文件(*.swm)|*.swm";
            openFileDialog1.ShowDialog();
            string f = openFileDialog1.FileName;
            if (System.IO.File.Exists(f) == true)
            {
                textBox9.Text = f;
                radioButton3.Checked = true;
                if (openFileDialog1.FilterIndex == 1+1)
                {
                    GetWimInfo_IsFenWim = true;
                }
                else
                {
                    GetWimInfo_IsFenWim = false;
                }
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox9.Text) == true)
            {
                if (GetWimInfo_IsFenWim == true)
                {
                    int count;
                    string names;
                    string[] imgs;
                    string folder = System.IO.Path.GetDirectoryName(textBox9.Text);
                    Class1.Public_GetImageItems(textBox9.Text, out count, out names, true, folder);
                    imgs =names.Split('|');
                    label23.Visible = true;
                    comboBox5.Enabled = true;
                    label23.Text = count.ToString();
                    if (imgs.Length > 0)
                    {
                        comboBox5.Items.Clear();
                        for (int h = 1; h <= imgs.Length; h++)
                        {
                            comboBox5.Items.Add(h.ToString() + " " + imgs[h - 1]);
                        }
                        comboBox5.SelectedIndex = 0;
                    }
                    else
                    {
                        label23.Text = "0";
                        comboBox5.Enabled = false;
                    }
                }
                else
                {
                    int count;
                    string names;
                    string[] imgs;
                    Class1.Public_GetImageItems(textBox9.Text, out count, out names, false, "");
                    imgs = names.Split('|');
                    label23.Visible = true;
                    comboBox5.Enabled = true;
                    label23.Text = count.ToString();
                    if (imgs.Length > 0)
                    {
                        comboBox5.Items.Clear();
                        for (int h = 1; h <= imgs.Length; h++)
                        {
                            comboBox5.Items.Add(h.ToString() + " " + imgs[h - 1]);
                        }
                        comboBox5.SelectedIndex = 0;
                    }
                    else
                    {
                        label23.Text = "0";
                        comboBox5.Enabled = false;
                    }
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            textBox11.Visible = false;
            panel2.Location = new Point(6, 98);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                panel2.Visible = false;
                textBox11.Visible = true;
                textBox11.Location = new Point(6, 98);
                if (GetWimInfo_IsFenWim == true)
                {
                    if (System.IO.File.Exists(textBox9.Text) == true)
                    {
                        string folder = System.IO.Path.GetDirectoryName(textBox9.Text);
                        string txt;
                        Class1.Public_GetImageOrgInfo(textBox9.Text, out txt, true, folder);
                            textBox11.Text = txt;
                        
                    }
                }
                else
                {
                    string txt;
                    if (System.IO.File.Exists(textBox9.Text) == true)
                    {
                        Class1.Public_GetImageOrgInfo(textBox9.Text, out txt, false, "");
                        textBox11.Text = txt;
                    }
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Windows 映像(*.wim)|*.wim";
            openFileDialog1.Title = "选择映像文件";
            openFileDialog1.ShowDialog();
            string j = openFileDialog1.FileName;
            if (System.IO.File.Exists(j) == true)
            {
                textBox12.Text = j;
                int count;
                string names;
                string[] imgs;
                Class1.Public_GetImageItems(j, out count, out names, false, "");
                imgs = names.Split('|');
                comboBox6.Enabled = true;
                if (imgs.Length > 0)
                {
                    comboBox6.Items.Clear();
                    for (int h = 1; h <= imgs.Length; h++)
                    {
                        comboBox6.Items.Add(h.ToString() + " " + imgs[h - 1]);
                    }
                    comboBox6.SelectedIndex = 0;
                }
                else
                {
                    comboBox6.Enabled = false;
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Windows 映像(*.wim)|*.wim";
            saveFileDialog1.Title = "选择映像文件";
            saveFileDialog1.ShowDialog();
            string j = saveFileDialog1.FileName;
            if (System.IO.File.Exists(j) == false && j != "")
            {
                textBox13.Text = j;
            }
            else
            {
                if (j != "" && System.IO.File.Exists(j)==true)
                {
                    MessageBox.Show(@"不能导出映像至""" + j + @""".因为该文件已存在.", "无法导出映像", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox12.Text) == true && comboBox6.Enabled == true)
            {
                string cmds = @"/export """+textBox12.Text +@""" "+(comboBox6.SelectedIndex +1).ToString()+ @" """+textBox13.Text +@""" """+textBox14.Text +@"""";
                switch (comboBox6.SelectedIndex)
                {
                    case 0:
                        cmds = cmds + " /compress none";
                        break;
                    case 1:
                        cmds = cmds + " /compress fast";
                        break;
                    case 2:
                        cmds = cmds + " /compress maximum";
                        break;
                }
                //boot
                if (checkBox12.Checked == true) { cmds = cmds + @" /boot"; }
                //check
                if (checkBox12.Checked == true) { cmds = cmds + @" /check"; }
                Form_Progress f = new Form_Progress("EXPORT", cmds, textBox13.Text, true);
                f.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string im = Application.StartupPath + @"\tools\imagex.exe";
            if (System.IO.File.Exists(im) == false)
            {
                MessageBox.Show(@"无法找到文件""" + im + @"""", "文件未找到", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
            comboBox7.SelectedIndex = 2;
            tabControl2.Location = new Point(-1, 5);
            FormChoose = "MAIN";
            panel4.Location = new Point(20, 87);
            tabControl1.Visible = false;
            SettingsChoose = "1";
            this.SetCommand();
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Windows 映像(*.wim)|*.wim";
            openFileDialog1.Title = "选择映像文件";
            openFileDialog1.ShowDialog();
            string j = openFileDialog1.FileName;
            if (System.IO.File.Exists(j) == true)
            {
                textBox15.Text = j;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Windows 映像分卷文件(*.swm)|*.swm";
            saveFileDialog1.Title = "选择映像文件";
            saveFileDialog1.ShowDialog();
            string j = saveFileDialog1.FileName;
            if (System.IO.File.Exists(j) == false && j != "")
            {
                textBox17.Text = j;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox15.Text) == true && textBox16.Text !="" && textBox17.Text !="")
            {
                string cmd;
                cmd =@"/split """+textBox15.Text +@""" """+textBox17.Text +@""" "+textBox16.Text;
                if (checkBox14.Checked == true) { cmd = cmd + @" /check"; }
                Form_Progress f = new Form_Progress("SPLIT", cmd, textBox15.Text + @"*SAVE", true);
                f.ShowDialog();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Windows 映像(*.wim)|*.wim";
            openFileDialog1.Title = "选择映像文件";
            openFileDialog1.ShowDialog();
            string j = openFileDialog1.FileName;
            if (System.IO.File.Exists(j) == true)
            {
                textBox18.Text = j;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "要捕获的目录";
            folderBrowserDialog1.ShowDialog();
            string open = folderBrowserDialog1.SelectedPath;
            if (System.IO.Directory.Exists(open) == true)
            {
                textBox19.Text = open;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox18.Text) == true && System.IO.Directory.Exists(textBox19.Text) && textBox20.Text != "")
            {
                string cmd = @"/append """+textBox19.Text +@""" """+textBox18.Text +@""" """+textBox20.Text +@"""";
                //boot
                if (checkBox18.Checked == true) { cmd = cmd + " /boot"; }
                //check
                if (checkBox17.Checked == true) { cmd = cmd + " /check"; }
                //verify
                if (checkBox16.Checked == true) { cmd = cmd + " /verify"; }
                //scroll
                if (checkBox15.Checked == true) { cmd = cmd + " /scroll"; }
                Form_Progress f = new Form_Progress("APPEND", cmd, textBox18.Text, true);
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            tabControl1.Location = new Point(14, 62);
            tabControl1.Visible = true;
            pictureBox1.Visible = true;
            FormChoose = "CREATE";
            label40.Visible = true;
            label40.Text = "创建新的映像文件";
            tabControl1.SelectedIndex = 0;
            this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width+10, tabControl1.Location.Y + tabControl1.Size.Height +15);
            panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
            panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            panel4.Location = new Point(20, 87);
            pictureBox1.Visible = false;
            FormChoose = "MAIN";
            panel4.Visible = true;
            label40.Visible = false;
            this.Size = new Size(671, 410);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            tabControl1.Location = new Point(14, 62);
            tabControl1.Visible = true;
            pictureBox1.Visible = true;
            FormChoose = "AAPLY";
            label40.Visible = true;
            label40.Text = "应用Windows 映像";
            tabControl1.SelectedIndex = 1;
            this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 10, tabControl1.Location.Y + tabControl1.Size.Height + 15);
            panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
            panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            tabControl1.Location = new Point(14, 62);
            tabControl1.Visible = true;
            pictureBox1.Visible = true;
            FormChoose = "SETTINGS";
            label40.Visible = true;
            label40.Text = "映像综合编辑";
            tabControl1.SelectedIndex = 2;
            this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 10, tabControl1.Location.Y + tabControl1.Size.Height + 15);
            panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
            panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            tabControl1.Location = new Point(14, 62);
            tabControl1.Visible = true;
            pictureBox1.Visible = true;
            FormChoose = "HELP";
            label40.Visible = true;
            label40.Text = "帮助与支持";
            tabControl1.SelectedIndex = 3;
            this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 5, tabControl1.Location.Y + tabControl1.Size.Height + 15);
            panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
            panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
        }

        private void label17_MouseMove(object sender, MouseEventArgs e)
        {
            Label h = (Label)sender;
            h.ForeColor = Color.FromArgb(0, 148, 255);
        }

        private void label17_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 0;
            SettingsChoose = "1";
            label17.ForeColor = label18.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
            label17.ForeColor = Color.FromArgb(0, 148, 255);
        }

        private void label18_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 1;
            SettingsChoose = "2";
            label17.ForeColor = label18.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
            label18.ForeColor = Color.FromArgb(0, 148, 255);

        }

        private void label19_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 2;
            SettingsChoose = "3";
            label17.ForeColor = label18.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
            label19.ForeColor = Color.FromArgb(0, 148, 255);
        }

        private void label20_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 3;
            SettingsChoose = "4";
            label17.ForeColor = label18.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
            label20.ForeColor = Color.FromArgb(0, 148, 255);
        }

        private void label21_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 4;
            SettingsChoose = "5";
            label17.ForeColor = label18.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
            label21.ForeColor = Color.FromArgb(0, 148, 255);
        }

        private void label17_MouseLeave(object sender, EventArgs e)
        {
            label17.ForeColor = label18.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
            switch (SettingsChoose)
            {
                case "1":
                    label17.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "2":
                    label18.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "3":
                    label19.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "4":
                    label20.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "5":
                    label21.ForeColor = Color.FromArgb(0, 148, 255);
                    break;

            }
        }

        private void label18_MouseLeave(object sender, EventArgs e)
        {
            label17.ForeColor = label18.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
            switch (SettingsChoose)
            {
                case "1":
                    label17.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "2":
                    label18.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "3":
                    label19.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "4":
                    label20.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "5":
                    label21.ForeColor = Color.FromArgb(0, 148, 255);
                    break;

            }
        }

        private void label19_MouseLeave(object sender, EventArgs e)
        {
            label17.ForeColor = label18.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
            if (SettingsChoose == "3")
            {
                label19.ForeColor = Color.FromArgb(0, 148, 255);
            }
            switch (SettingsChoose)
            {
                case "1":
                    label17.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "2":
                    label18.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "3":
                    label19.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "4":
                    label20.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "5":
                    label21.ForeColor = Color.FromArgb(0, 148, 255);
                    break;

            }
        }

        private void label20_MouseLeave(object sender, EventArgs e)
        {
           label17.ForeColor = label18.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
            if (SettingsChoose == "4")
            {
                label20.ForeColor = Color.FromArgb(0, 148, 255);
            }
            switch (SettingsChoose)
            {
                case "1":
                    label17.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "2":
                    label18.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "3":
                    label19.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "4":
                    label20.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "5":
                    label21.ForeColor = Color.FromArgb(0, 148, 255);
                    break;

            }
        }

        private void label21_MouseLeave(object sender, EventArgs e)
        {
            label17.ForeColor = label18.ForeColor = label19.ForeColor = label20.ForeColor = label21.ForeColor = Color.FromArgb(149, 149, 149);
            if (SettingsChoose == "5")
            {
                label21.ForeColor = Color.FromArgb(0, 148, 255);
            }
            switch (SettingsChoose)
            {
                case "1":
                    label17.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "2":
                    label18.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "3":
                    label19.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "4":
                    label20.ForeColor = Color.FromArgb(0, 148, 255);
                    break;
                case "5":
                    label21.ForeColor = Color.FromArgb(0, 148, 255);
                    break;

            }
        }
        void SetCommand()
        {
            if (Command.Length  > 0)
            {
                //MessageBox.Show(Command[1].Substring(7, Command[1].Length - 7).ToUpper());
                switch (Command[1].Substring(7, Command[1].Length -7).ToUpper())
                {
                    case "CREATE":
                        if (Command.Length >= 4)
                        {
                            if (Command.Length == 4)
                            {
                                string select, wimfile;
                                select = Command[0].Substring(8, Command[0].Length - 8);
                                wimfile = Command[2].Substring(9, Command[2].Length - 9);
                                panel4.Visible = false;
                                tabControl1.Location = new Point(14, 62);
                                tabControl1.Visible = true;
                                pictureBox1.Visible = true;
                                FormChoose = "CREATE";
                                label40.Visible = true;
                                label40.Text = "创建新的映像文件";
                                tabControl1.SelectedIndex = 0;
                                this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 10, tabControl1.Location.Y + tabControl1.Size.Height + 15);
                                panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
                                panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
                                if (System.IO.Directory.Exists(select) == true) { textBox1.Text = select; }
                                textBox2.Text = wimfile;
                                if (Command[3].Substring(11, Command[3].Length - 11).ToUpper() == "TRUE")
                                {
                                    if (System.IO.Directory.Exists(select) == true)
                                    {
                                        if (System.IO.File.Exists(wimfile) == true)
                                        {
                                            DialogResult r;
                                            r = MessageBox.Show(@"指定的Windows 映像文件""" + wimfile + @"""已存在.您是否要替换该文件?", "是否替换文件?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (r == DialogResult.Yes)
                                            {
                                                System.IO.File.Delete(wimfile);
                                                string cmd = @"/capture """ + select + @""" """ + wimfile + @""" ""Windows 映像"" /compress maximum";
                                                Form_Progress frm = new Form_Progress("CREATE", cmd, wimfile, false);
                                                frm.StartPosition = FormStartPosition.CenterScreen;
                                                frm.ShowDialog();
                                                Application.ExitThread();
                                            }
                                        }
                                        else
                                        {
                                            string newfile = wimfile;
                                            if (wimfile.ToUpper() == "SELECTPATH")
                                            {
                                                string foldername = select.Substring(select.LastIndexOf("\\") + 1, select.Length - select.LastIndexOf("\\") - 1);
                                                newfile = select + "\\" + foldername + @"的映像文件-" + System.IO.Path.GetRandomFileName().ToUpper().Replace(".", "") + ".wim";
                                                //MessageBox.Show(newfile);
                                            }
                                            string cmd = @"/capture """ + select + @""" """ + newfile + @""" ""Windows 映像"" /compress maximum";
                                            Form_Progress frm = new Form_Progress("CREATE", cmd, wimfile, false);
                                            frm.StartPosition = FormStartPosition.CenterScreen;
                                            frm.ShowDialog();
                                            Application.ExitThread();
                                        }
                                    }
                                    MessageBox.Show(@"文件夹""" + select + @"""不存在.请检查文件夹是否有效", "文件夹未找到", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    //runnow=false
                                    string newfile = wimfile;
                                    if (wimfile.ToUpper() == "SELECTPATH")
                                    {
                                        string foldername = select.Substring(select.LastIndexOf("\\") + 1, select.Length - select.LastIndexOf("\\") - 1);
                                        newfile = select + "\\" + foldername + @"的映像文件-" + System.IO.Path.GetRandomFileName().ToUpper().Replace(".", "") + ".wim";
                                        //MessageBox.Show(newfile);
                                        textBox2.Text = newfile;
                                    }
                                }
                            }
                            else
                            {
                                string select, wimfile;
                                select = Command[0].Substring(8, Command[0].Length - 8);
                                wimfile = Command[2].Substring(9, Command[2].Length - 9);
                                panel4.Visible = false;
                                tabControl1.Location = new Point(14, 62);
                                tabControl1.Visible = true;
                                pictureBox1.Visible = true;
                                FormChoose = "CREATE";
                                label40.Visible = true;
                                label40.Text = "创建新的映像文件";
                                tabControl1.SelectedIndex = 0;
                                this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 10, tabControl1.Location.Y + tabControl1.Size.Height + 15);
                                panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
                                panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
                                if (System.IO.Directory.Exists(select) == true) { textBox1.Text = select; }
                                textBox2.Text = wimfile;
                                for (int s = 4; s <= Command.Length-1; s++)
                                {
                                    string cmdname=Command[s].Substring(1, Command[s].IndexOf("=")-1);
                                    switch (Command[s].Substring(0,Command[s].IndexOf("=")).Length+1)
                                    {

                                        case 6:
                                            if (Command[s].Substring(6, Command[s].Length - 6).ToUpper() == "TRUE") { checkBox1.Checked = true;} else { checkBox1.Checked = false; } //boot
                                            break;
                                        case 7:
                                            if (Command[s].Substring(7, Command[s].Length - 7).ToUpper() == "TRUE") { checkBox2.Checked = true; } else { checkBox2.Checked = false; } //check
                                            break;
                                        case 8:
                                            if (cmdname.ToUpper() == "VERIFY")
                                            {
                                                if (Command[s].Substring(8, Command[s].Length - 8).ToUpper() == "TRUE") { checkBox3.Checked = true; } else { checkBox3.Checked = false; } //VERIFY
                                            }
                                            else
                                            {
                                                if (cmdname.ToUpper() == "SCROLL")
                                                {
                                                    if (Command[s].Substring(8, Command[s].Length - 8).ToUpper() == "TRUE") { checkBox5.Checked = true; } else { checkBox5.Checked = false; } //SCROLL
                                                }
                                            }
                                            break;
                                        case 9:
                                            if (cmdname.ToUpper() == "NORPFIX")
                                            {
                                                if (Command[s].Substring(9, Command[s].Length - 9).ToUpper() == "TRUE") { checkBox4.Checked = true; } else { checkBox4.Checked = false; } //NORPFIX
                                            }
                                            else
                                            {
                                                if (cmdname.ToUpper() == "VERSION")
                                                {
                                                    switch (Command[s].Substring(9, Command[s].Length - 9).ToLower())
                                                    {
                                                        case "homebasic":
                                                            comboBox1.SelectedIndex = 0;
                                                            break;
                                                        case "homepremium":
                                                            comboBox1.SelectedIndex = 1;
                                                            break;
                                                        case "starter":
                                                            comboBox1.SelectedIndex = 2;
                                                            break;
                                                        case "ultimate":
                                                            comboBox1.SelectedIndex = 3;
                                                            break;
                                                        case "business":
                                                            comboBox1.SelectedIndex = 4;
                                                            break;
                                                        case "enterprise":
                                                            comboBox1.SelectedIndex = 5;
                                                            break;
                                                        case "serverdatacenter":
                                                            comboBox1.SelectedIndex = 6;
                                                            break;
                                                        case "serverenterprise":
                                                            comboBox1.SelectedIndex = 7;
                                                            break;
                                                        case "ServerStandard":
                                                            comboBox1.SelectedIndex = 8;
                                                            break;
                                                    }
                                                }
                                            }
                                            break;
                                        case 10:
                                            switch (Command[s].Substring(10, Command[s].Length - 10).ToLower())
                                            {
                                                case "none":
                                                    comboBox2.SelectedIndex = 0;
                                                    break;
                                                case "maximum":
                                                    comboBox2.SelectedIndex = 2;
                                                    break;
                                                case "fast":
                                                    comboBox2.SelectedIndex = 1;
                                                    break;
                                            }
                                            break;
                                        case 11:
                                            if (cmdname.ToUpper() == "IMAGENAME")
                                            {
                                                textBox3.Text = Command[s].Substring(11, Command[s].Length - 11);
                                            }
                                            else
                                            {
                                                if (cmdname.ToUpper() == "IMAGEINFO")
                                                {
                                                    textBox4.Text = Command[s].Substring(11, Command[s].Length - 11);
                                                }
                                            }
                                            break;
                                        case 16:
                                            if (System.IO.File.Exists(Command[s].Substring(16, Command[s].Length - 16)) == true)
                                            {
                                                textBox5.Text = Command[s].Substring(16, Command[s].Length - 16);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                //继续
                                string newfile = wimfile;
                                if (wimfile.ToUpper() == "SELECTPATH")
                                {
                                    string foldername = select.Substring(select.LastIndexOf("\\") + 1, select.Length - select.LastIndexOf("\\") - 1);
                                    newfile = select + "\\" + foldername + @"的映像文件-" + System.IO.Path.GetRandomFileName().ToUpper().Replace(".", "") + ".wim";
                                }
                                textBox2.Text = newfile;
                                if (Command[3].Substring(11, Command[3].Length - 11).ToUpper() == "TRUE")
                                {
                                    this.CreateWimInCommand();
                                    Application.ExitThread();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("指定的参数不完整", "无法识别启动参数", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "DELETE":
                        this.DeleteImageInCommand();
                        break;
                    case "INFO":
                        this.InfoImageInCommand();
                        break;
                    case "EXPORT":
                        this.ExportImageInCommand();
                        break;
                    case "SPLIT":
                        this.SplitImageInCommand();
                        break;
                    case "APPEND":
                        this.AppendImageInCommand();
                            break;
                    case "APPLY":
                        if (Command.Length >= 5)
                        {
                            if (Command.Length == 5)
                            {
                                string selectfolder, wimfile;
                                selectfolder = Command[2].Substring(12, Command[2].Length - 12);
                                wimfile = Command[0].Substring(8, Command[0].Length - 8);
                                string newfolder = selectfolder;
                                if (System.IO.File.Exists(wimfile) == true)
                                {
                                    if (newfolder.ToUpper() == "SELECTPATH")
                                    {
                                        string wimfilename = System.IO.Path.GetFileName(wimfile);
                                        newfolder = System.IO.Path.GetDirectoryName(wimfile)+"\\应用的映像" + wimfilename;
                                        //MessageBox.Show(newfolder);
                                    }
                                    string index = Command[3].Substring(12, Command[3].Length - 12);
                                    int newindex;
                                    int.TryParse(index, out newindex);
                                    if (newindex == 0)
                                    {
                                        newindex = newindex + 1;
                                    }
                                    string runnow = Command[4].Substring(10, Command[4].Length - 10).ToUpper();
                                    //
                                    panel4.Visible = false;
                                    tabControl1.Location = new Point(14, 62);
                                    tabControl1.Visible = true;
                                    pictureBox1.Visible = true;
                                    FormChoose = "AAPLY";
                                    label40.Visible = true;
                                    label40.Text = "应用Windows 映像";
                                    tabControl1.SelectedIndex = 1;
                                    this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 10, tabControl1.Location.Y + tabControl1.Size.Height + 15);
                                    panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
                                    panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
                                    textBox7.Text = wimfile;
                                    textBox8.Text = newfolder;
                                    radioButton1.Checked = true;
                                    int count;
                                    string names;
                                    Class1.Public_GetImageItems(wimfile, out count, out names, false, "");
                                    if (count > 0)
                                    {
                                        comboBox3.Items.Clear();
                                        comboBox3.Enabled = true;
                                        string[] imgs = names.Split('|');
                                        for (int j = 1; j <= count; j++)
                                        {

                                            comboBox3.Items.Add(j.ToString() + " " + imgs[j - 1]);
                                        }
                                        comboBox3.SelectedIndex = 0;
                                    }
                                    else
                                    {
                                        comboBox3.Items.Clear();
                                        comboBox3.Enabled = false;
                                    }
                                    if (newindex > comboBox3.Items.Count)
                                    {
                                        MessageBox.Show(@"无法应用映像文件""" + wimfile + @""".因为映像卷"""+newindex +@"""对于该映像无效", "无法应用映像文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        comboBox3.SelectedIndex = newindex - 1;
                                        if (runnow == "TRUE")
                                        {
                                            if (System.IO.Directory.Exists(newfolder) == false) { System.IO.Directory.CreateDirectory(newfolder); }
                                            string cmd = @"/apply """ + wimfile + @""" " + newindex.ToString() + @" """ + newfolder + @"""";
                                            Form_Progress frm = new Form_Progress("APPLY", cmd, wimfile+"*SAVE", false);
                                            frm.StartPosition = FormStartPosition.CenterScreen;
                                            frm.ShowDialog();
                                            Application.ExitThread();
                                        }
                                    }
                                    //
                                }
                                else
                                {
                                    MessageBox.Show(@"找不到映像文件""" + wimfile + @"""", "无法应用映像文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                string selectfolder, wimfile;
                                selectfolder = Command[2].Substring(12, Command[2].Length - 12);
                                wimfile = Command[0].Substring(8, Command[0].Length - 8);
                                string newfolder = selectfolder;
                                if (System.IO.File.Exists(wimfile) == true)
                                {
                                    if (newfolder.ToUpper() == "SELECTPATH")
                                    {
                                        string wimfilename = System.IO.Path.GetFileName(wimfile);
                                        newfolder = System.IO.Path.GetDirectoryName(wimfile) + "\\应用的映像" + wimfilename;
                                        //MessageBox.Show(newfolder);
                                    }
                                    if (System.IO.Directory.Exists(newfolder) == false) { System.IO.Directory.CreateDirectory(newfolder); }
                                    string index = Command[3].Substring(12, Command[3].Length - 12);
                                    int newindex;
                                    int.TryParse(index, out newindex);
                                    if (newindex == 0)
                                    {
                                        newindex = newindex + 1;
                                    }
                                    string runnow = Command[4].Substring(10, Command[4].Length - 10).ToUpper();
                                    //
                                    panel4.Visible = false;
                                    tabControl1.Location = new Point(14, 62);
                                    tabControl1.Visible = true;
                                    pictureBox1.Visible = true;
                                    FormChoose = "AAPLY";
                                    label40.Visible = true;
                                    label40.Text = "应用Windows 映像";
                                    tabControl1.SelectedIndex = 1;
                                    this.Size = new Size(tabControl1.Location.X + tabControl1.Size.Width + 10, tabControl1.Location.Y + tabControl1.Size.Height + 15);
                                    panel6.Size = new Size(panel6.Size.Width, this.Size.Height);
                                    panel6.Location = new Point(this.Size.Width - panel6.Size.Width, 0);
                                    textBox7.Text = wimfile;
                                    textBox8.Text = newfolder;
                                    radioButton1.Checked = true;
                                    int count;
                                    string names;
                                    Class1.Public_GetImageItems(wimfile, out count, out names, false, "");
                                    if (count > 0)
                                    {
                                        comboBox3.Items.Clear();
                                        comboBox3.Enabled = true;
                                        string[] imgs = names.Split('|');
                                        for (int j = 1; j <= count; j++)
                                        {

                                            comboBox3.Items.Add(j.ToString() + " " + imgs[j - 1]);
                                        }
                                        comboBox3.SelectedIndex = 0;
                                    }
                                    else
                                    {
                                        comboBox3.Items.Clear();
                                        comboBox3.Enabled = false;
                                    }
                                    if (newindex > comboBox3.Items.Count)
                                    {
                                        MessageBox.Show(@"无法应用映像文件""" + wimfile + @""".因为映像卷""" + newindex + @"""对于该映像无效", "无法应用映像文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        comboBox3.SelectedIndex = newindex - 1;
                                        for (int s = 5; s <= Command.Length - 1; s++)
                                        {
                                            string cmdname = Command[s].Substring(1, Command[s].IndexOf("=") - 1);
                                            switch (Command[s].Substring(0, Command[s].IndexOf("=")).Length + 1)
                                            {
                                                case 6:
                                                    break;
                                                case 7:
                                                    if (Command[s].Substring(7, Command[s].Length - 7).ToUpper() == "TRUE") { checkBox11.Checked = true; } else { checkBox11.Checked = false; } //check
                                                    break;
                                                case 8:
                                                    if (cmdname.ToUpper() == "VERIFY")
                                                    {
                                                        if (Command[s].Substring(8, Command[s].Length - 8).ToUpper() == "TRUE") { checkBox10.Checked = true; } else { checkBox10.Checked = false; } //VERIFY
                                                    }
                                                    else
                                                    {
                                                        if (cmdname.ToUpper() == "SCROLL")
                                                        {
                                                            if (Command[s].Substring(8, Command[s].Length - 8).ToUpper() == "TRUE") { checkBox8.Checked = true; } else { checkBox8.Checked = false; } //SCROLL
                                                        }
                                                    }
                                                    break;
                                                case 9:
                                                  if (Command[s].Substring(9, Command[s].Length - 9).ToUpper() == "TRUE") { checkBox9.Checked = true; } else { checkBox9.Checked = false; } //NORPFIX
                                                  break;
                                            }
                                        }
                                        if (runnow == "TRUE")
                                        {
                                            textBox8.Text = newfolder;
                                            this.ApplyImageInCommand();
                                        }
                                      
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("指定的参数不完整", "无法识别启动参数", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.54itmi.com");
            }
            catch { }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //Class1.Public_RegistryExtName();
            Class1.Public_RegistryExtName();
            MessageBox.Show("成功关联*.wim文件", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Class1.Public_RegistryDir();
            MessageBox.Show("成功关联文件夹", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey Dir = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"Directory\shell\createwim", true);
                if (Dir != null)
                {
                    Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"Directory\shell", true).DeleteSubKeyTree("createwim");
                }
                MessageBox.Show("成功取消关联文件夹", "取消成功",MessageBoxButtons.OK ,MessageBoxIcon.Information );
            }
            catch { }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey Dir = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@".wim", true);
                Microsoft.Win32.RegistryKey Dir2 = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"Systemgear.wim", true);
                if (Dir != null)
                {
                    Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(".wim");
                }
                if (Dir2 != null)
                {
                    Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree("systemgear.wim");
                }
                MessageBox.Show("成功取消关联*.wim文件", "取消成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(WinImageTool.Properties.Resources.Arg,"命令行选项", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form2 f = new Form2();
            f.ShowDialog();
        }
    }
}
