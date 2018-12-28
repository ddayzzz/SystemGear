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
    public partial class Form_CommondDialogsItems : Form
    {
        private string[] _Args;
        private string[] _ReturnStrings;
        private string _Type;
        private string ext_img = "bmp|jpg|jpeg|jpe|jfif|tif|tiff|gif|png|dib|wmf|emf|psd|pdd|psb|3ds|rle|dib|crw|nef|raf|orf|mrw|dcr|mos|raw|pef|srf|dng|x3f|cr2|erf|sr2|kdc|mfw|mef|arw|nrw|rw2|rwl|iiq|3fr|fff|srw|cin|sdpx|dpx|fido|dae|dcm|dc3|dic|eps|fl3|kmz|iff|tdi|jpf|jpx|jp2|j2c|j2k|jpc|jps|exr|pcx|pdp|pct|pict|pxr|pns|pbm|pgm|ppm|pnm|pfm|pam|hdr|rgbe|xyze|sct|stl|tga|vda|icb|vst|obj|mpo|ai3|ai4|ai5|ai6|ai7|ai8|ps|ai|epsf|epsp|wbm|wbmp";
        private string ext_doc = "docx|docm|doc|dotx|dotm|dot|pdf|xps|mht|mhtml|htm|html|rtf|txt|xml|odt|pptx|pptm|ppt|potx|potm|pot|ppsx|ppsm|pps|ppam|ppa|odp|xlsx|xlsm|xlsb|xls|xltx|xltm|xlt|csv|prn|dif|slk|xlam|xla|ods";
        private string ext_video = "avi|wmv|wmp|asf|rm|ram|rmvb|ra|rp|smi|mpg|mpeg|dat|mp4|ta|mpa|acc|m2ts|evo|vob|ifo|ac3|dts|cda|mov|qt|3gp|3gpp|flv|f4v|swf|smpl|asx|m3u|srt|ass|ssa|kmv|pmp|divx|vp6|csf";
        private string ext_music = "aac|aa|ac3|a52|aif|aifc|aiff|ape|au|snd|cue|cda|dts|dstwav|flac|fla|kgm|mid|midi|rmi|mp3|m4a|mpc|mp+|ogg|wav|wma";
        private string ext_data = "accdb|mdb|accdt|xsn|xsf|xtp|xtp2";
        private string ext_compressfile = "zip|7z|tar.gz|tgz|tpz|tar.bz2|tar.bz|tbz|tbz2|tar.xz|txz|gz|gzip|bz2|bz|bzip2|xz|lzh|lha|wim|iso|isz|bin|nrg|mdf|mds|img|ccd|sub";
        private string ext_link = "lnk|website";
        private string ext_exe = "exe|com|bat|cmd|ps1|psm1|psd1|ps1xml|pssc|cdxml";
        private string[] exts=new string[]{};
        [Browsable(true), Category("Return"), Description("返回的数据")]
        public string[]  ReturnStrings
        {
            get
            {
                return _ReturnStrings;
            }
            set
            {
                _ReturnStrings = value;
            }
        }
        public Form_CommondDialogsItems(string  type,string[] arg)
        {
            _Args = arg;
            _Type = type;
            InitializeComponent();
            try
            {
                panel2.Location = new Point(0, panel2.Location.Y);
                switch (type.ToLower())
                {
                    case "filesize":
                        if(arg.Length ==2)
                        {
                            int l, b;
                            int.TryParse(arg[0], out l);
                            int.TryParse(arg[1], out b);
                            numericUpDown2.Value = b;
                            numericUpDown1.Value = l;
                            tabControl1.SelectedIndex = 0;
                        }
                        break;
                    case "fileoperate":
                        tabControl1.SelectedIndex = 1;
                        comboBox1.SelectedIndex = 0;
                        break;
                    case "filetype":
                        exts = new string[] { ext_img, ext_doc, ext_video, ext_music, ext_data, ext_compressfile, ext_link, ext_exe };
                        tabControl1.SelectedIndex = 2;
                        comboBox2.SelectedIndex = 0;
                        break;
                    case "inputbox":
                        tabControl1.SelectedIndex = 3;
                        label1.Text =this.Text = arg[0];
                        label11.Text = arg[1];
                        myTextBox4.TextBoxInfoTip = arg[2];
                        myTextBox4.TextBoxText =arg[3];
                        _ReturnStrings = new string[1];
                        _ReturnStrings[0] = arg[3];
                        string p = arg[4].ToLower();
                        myNormalButton6.Visible = true;
                        switch(p)
                        {
                            case "iconchoose":
                                myNormalButton6.ButtonText = "浏览";
                                break;
                            case "filechoose":
                                myNormalButton6.ButtonText = "浏览";
                                break;
                            case "folderchoose":
                                myNormalButton6.ButtonText = "浏览";
                                break;
                            default :
                                myNormalButton6.Visible = false;
                                break;
                        }
                        break;
                }
            }
            catch { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if(numericUpDown1.Value >=numericUpDown2.Value )
                {
                    MyFunctions.Dialogs.MessageDialog("不合逻辑的值", "最大的大小的值大于或等于最小大小的值", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "B2", false, true, "", "确定");
                }
                else
                {
                    this._ReturnStrings = new string[] { numericUpDown1.Value.ToString(), numericUpDown2.Value.ToString() };
                    this.Close();
                }
            }
            catch { }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(numericUpDown2.Value <=numericUpDown1.Value )
                {
                    numericUpDown2.Value = numericUpDown1.Value + 1;
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string f = MyFunctions.Dialogs.OpenFolder("选择文件夹目录");
            if(f!="")
            {
                try
                {
                    string p = f.Substring(f.LastIndexOf("\\"), f.Length - f.LastIndexOf("\\"));
                    myTextBox1.TextBoxText = "%FileFolder%"+p;
                }
                catch { }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string f = MyFunctions.Dialogs.OpenFolder("选择文件夹目录");
            if (f != "")
            {
                myTextBox2.TextBoxText = f;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex )
            {
                case 0:
                    label8.Text = "没有操作";
                    myTextBox1.Visible = myTextBox2.Visible = false;
                    myNormalButton2.Visible = myNormalButton3.Visible = false;
                    radioButton1.Visible = radioButton2.Visible = false;
                    break;
                case 1:
                    label8.Text = "将被操作的文件复制到";
                    myTextBox1.Visible = myTextBox2.Visible =myNormalButton2.Visible = myNormalButton3.Visible =radioButton1.Visible = radioButton2.Visible= true;
                    break;
                case 2:
                    label8.Text = "将被操作的文件移动到";
                    myTextBox1.Visible = myTextBox2.Visible = myNormalButton2.Visible = myNormalButton3.Visible = radioButton1.Visible = radioButton2.Visible = true;
                    break;
                case 3:
                    label8.Text = "将被操作的文件删除";
                    myTextBox1.Visible = myTextBox2.Visible = myNormalButton2.Visible = myNormalButton3.Visible = radioButton1.Visible = radioButton2.Visible = false;
                    break;
            }
        }

        private void myNormalButton1_OnButtonClick(object sender, EventArgs e)
        {
           if(comboBox1.SelectedIndex ==1 || comboBox1.SelectedIndex ==2)
           {
               if (radioButton1.Checked == true)
               {
                   if (myTextBox1.TextBoxText == "")
                   {
                       MyFunctions.Dialogs.MessageDialog("请输一入个文件夹", "请选择一个正确的文件夹", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "B2", false, true, "", "确定");
                       return;
                   }
               }
               else
               {
                   if (myTextBox2.TextBoxText == "")
                   {
                       MyFunctions.Dialogs.MessageDialog("请输一入个文件夹", "请选择一个正确的文件夹", MyFunctions.Dialogs.MessageDialogIcon.Error, "", "B2", false, true, "", "确定");
                       return;
                   }
               }
           }
            string[] ret=new string[]{"NoOperate",""};
            switch(comboBox1.SelectedIndex )
            {
                case 0:
                    ret = new string[] { "NoOperate", "" };
                    break;
                case 3:
                    ret = new string[] { "Delete", "" };
                    break;
                case 1:
                    if (radioButton1.Checked == true)
                    {
                        ret = new string[] { "Copy", myTextBox1.TextBoxText };
                    }
                    else { ret = new string[] { "Copy", myTextBox2.TextBoxText }; }
                    break;
                case 2:
                    if (radioButton1.Checked == true)
                    {
                        ret = new string[] { "Move", myTextBox1.TextBoxText };
                    }
                    else { ret = new string[] { "Move", myTextBox2.TextBoxText }; }
                    break;
            }
            this._ReturnStrings = ret;
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { myTextBox3.TextBoxText = exts[comboBox2.SelectedIndex]; }
            catch { }
        }

        private void myNormalButton5_OnButtonClick(object sender, EventArgs e)
        {
            string ext = myTextBox3.TextBoxText;
            this._ReturnStrings = new string[] { ext };
            this.Close();
        }

        private void myNormalButton6_OnButtonClick(object sender, EventArgs e)
        {
            switch (_Args[4].ToLower())
            {
                case "iconchoose":
                    string j=MyFunctions.Dialogs.ChooseIcon("选择图标", @"%windir%\system32\imageres.dll,2");
                    if (j != "")
                    {
                        myTextBox4.TextBoxText = j;
                    }
                    break;
                case "filechoose":
                    string j1 = MyFunctions.Dialogs.OpenFileDialog("选择文件", _Args[5]);
                    if (System.IO.File.Exists(j1)==true)
                    {
                        myTextBox4.TextBoxText = j1;
                    }
                    break;
                case "folderchoose":
                    string j2 = MyFunctions.Dialogs.OpenFolder("选择文件夹");
                    if (System.IO.File.Exists(j2)==true)
                    {
                        myTextBox4.TextBoxText = j2;
                    }
                    break;
                default:
                    //myNormalButton6.Visible = false;
                    break;
            }
        }

        private void myNormalButton7_OnButtonClick(object sender, EventArgs e)
        {
            if (_Args[6] == "MUST" && myTextBox4.TextBoxText == "")
            {
                label12.Visible = true;
            }
            else
            {
                label12.Visible = false;
                this._ReturnStrings = new string[] { myTextBox4.TextBoxText };
                this.Close();
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (_Type.ToLower() == "inputbox")
            {
                if (_Args[6] == "MUST" && myTextBox4.TextBoxText == "")
                {
                    label12.Visible = false;
                    this._ReturnStrings = new string[] { myTextBox4.TextBoxText };
                    e.Cancel = false;
                }
                else
                {
                    label12.Visible = false;
                    this._ReturnStrings = new string[] { myTextBox4.TextBoxText };
                    e.Cancel = false;
                    //this.Close();
                }
            }
        }
        private void Form_CommondDialogsItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

    }
}
