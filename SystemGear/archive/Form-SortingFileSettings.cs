using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SystemGear
{
    public partial class Form_SortingFileSettings : Form
    {
        public string _str_01 = "";
        public string type="";
        public string[] tags;
        public string[] flag;
        public Form_SortingFileSettings(string type,string[] tag,string[] flags)
        {
            InitializeComponent();
            this.type = type;
            this.tags = tag;
            this.flag = flags;
            this.listView2.Items.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex )
            {
                case 0:
                    label4.Visible = true;
                    myTextBox2.Visible = true;
                    label4.Text = myTextBox2.TextBoxInfoTip ="指定的字符";
                    listView1.Items.Clear();
                    listView1.Items.Add("文件名中包含指定的文件名时").SubItems.Add("不执行操作");
                    listView1.Items.Add("文件名中不包含指定的文件名时").SubItems.Add("不执行操作");
                    listView1.Items[0].SubItems[1].Tag = "NoOperate";
                    listView1.Items[1].SubItems[1].Tag = "NoOperate";
                    //myTextBox2.Location = new Point(label4.Location.X+label4.Size.Width  +10,label4.Location.Y -5);
                    myTextBox2.Size = new Size(437, 26);
                    myNormalButton1.Visible = false;
                    comboBox2.Visible = false;
                    break;
                case 1:
                    label4.Visible = true;
                    myTextBox2.Visible = true;
                    label4.Text = "指定的文件类型";
                    myTextBox2.TextBoxInfoTip =@"指定的扩展名(多个扩展名请用""|""隔开。例如""DOC|DOCX|PPT"")";
                    listView1.Items.Clear();
                    listView1.Items.Add("文件的类型是指定的类型时").SubItems.Add("不执行操作");
                    listView1.Items.Add("文件的类型不是指定的类型时").SubItems.Add("不执行操作");
                    listView1.Items[0].SubItems[1].Tag = "NoOperate";
                    listView1.Items[1].SubItems[1].Tag = "NoOperate";
                    myNormalButton1.Visible = true;
                    myNormalButton1.ButtonText = "设置文件类型";
                    //myTextBox2.Location = new Point(label4.Location.X+label4.Size.Width  +10,label4.Location.Y -5);
                    myTextBox2.Size = new Size(437, 26);
                    comboBox2.Visible = false;
                    break;
                case 2:
                    label4.Visible = true;
                    myTextBox2.Visible = true;
                    label4.Text = "指定的大小(MB)";
                    myTextBox2.TextBoxInfoTip =@"指定的文件大小, 例如300";
                    listView1.Items.Clear();
                    listView1.Items.Add("文件的大小小于指定大小时").SubItems.Add("不执行操作");
                    listView1.Items.Add("文件的大小等于指定大小时").SubItems.Add("不执行操作");
                    listView1.Items.Add("文件的大小大于指定大小时").SubItems.Add("不执行操作");
                    //listView1.Items.Add("文件的大小介于指定大小之间").SubItems.Add("不执行操作");
                    listView1.Items[0].SubItems[1].Tag = "NoOperate";
                    listView1.Items[1].SubItems[1].Tag = "NoOperate";
                    listView1.Items[2].SubItems[1].Tag = "NoOperate";
                    //listView1.Items[3].SubItems[1].Tag = "NoOperate";
                   // myTextBox2.Size = new Size(360, 26);
                    //myTextBox2.Location = new Point(label4.Location.X+label4.Size.Width  +10,label4.Location.Y -5);
                    myTextBox2.Size = new Size(334, 26);
                    myNormalButton1.Visible = false;
                    //myNormalButton1.ButtonText = "编辑介于大小";
                    comboBox2.Visible = true;
                    break;
            }
            myTextBox2.TextBoxText = ".";
            myTextBox2.TextBoxText = "";
        }

        private void Form_SortingFileSettings_Load(object sender, EventArgs e)
        {
            
        }

        private void myTextBox2_OnTextChange(object sender, MyTextBox.MYEventArgs e)
        {
            /*
            string shi = "MB时";
            switch(comboBox2.SelectedIndex )
            {
                case 0:
                    shi = "MB时";
                    break;
                case 1:
                    shi = "KB时";
                    break;
                case 2:
                    shi = "B时";
                    break;
            }
             */
            switch(comboBox1.SelectedIndex )
            {
                case 2:
                    /*
                    int j;
                    bool p=int.TryParse(e.TextData, out j);
                    if(p==false)
                    {
                        myTextBox2.TextBoxText = "";
                    }
                    else
                    {
                        listView1.Items[0].Text ="文件的大小小于"+j.ToString()+shi;
                        listView1.Items[1].Text = "文件的大小等于" + j.ToString() + shi;
                        listView1.Items[2].Text = "文件的大小大于" + j.ToString() + shi;
                    }
                     */
                    break;
                case 0:

                    listView1.Items[0].Text = "文件名中包含" +e.TextData  + "时";
                    listView1.Items[1].Text = "文件名中不包含" + e.TextData + "时";
                    break;
                case 1:

                    listView1.Items[0].Text = "文件的类型是" + e.TextData + "其中之一时";
                    listView1.Items[1].Text = "文件的类型不是" + e.TextData + "其中之一时";
                    break;
            }
        }

        private void myNormalButton1_OnButtonClick(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex )
            {
                case 2:
                    try
                    {
                        /*
                        string[] RES = MyFunctions.Dialogs.CommonDialog("filesize", "输入介于大小的最大和最小值", "请输入最小文件大小以及最大文件大小", new string[] { "0", "1" });
                        if (RES != null)
                        {
                            if (RES.Length == 2)
                            {
                                string jieyu = "文件的大小介于" + RES[0] + "MB与" + RES[1] + "MB之间时";
                                minsize = Convert.ToInt32(RES[0]);
                                maxsize = Convert.ToInt32(RES[1]);
                                listView1.Items[3].Text = jieyu;
                            }
                        }   
                         */
                    }
                    catch { }
                    break;
                case 1:
                    try
                    {
                        
                        ////////////////
                        string[] RES = MyFunctions.Dialogs.CommonDialog("filetype", "选择文件类型", "请选择一个文件类型, 我们将利用这些信息", new string[] { "0", "1" });
                        if (RES != null)
                        {
                            if (RES.Length == 1)
                            {
                                string ext = RES[0];
                                this.myTextBox2.TextBoxText = ext;
                            }
                        }
                    }
                    catch { }
                    break;
            }
        }

        private void myNormalButton3_OnButtonClick(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                string[] res = MyFunctions.Dialogs.CommonDialog("fileoperate", "请选择如何操作文件", "请选择当被操作文件符合条件时的操作", new string[] { "121" });
                if (res != null && listView1.SelectedItems.Count ==1)
                {
                    switch (res[0])
                    {
                        case "NoOperate":
                            listView1.SelectedItems[0].SubItems[1].Text = "不执行操作";
                            listView1.SelectedItems[0].SubItems[1].Tag = "NoOperate";
                            break;
                        case "Delete":
                            listView1.SelectedItems[0].SubItems[1].Text = "删除文件";
                            listView1.SelectedItems[0].SubItems[1].Tag = "Delete";
                            break;
                        case "Copy":
                            listView1.SelectedItems[0].SubItems[1].Text = @"复制文件到""" + res[1] + @"""";
                            listView1.SelectedItems[0].SubItems[1].Tag = "Copy,"+res[1];
                            break;
                        case "Move":
                            listView1.SelectedItems[0].SubItems[1].Text = @"移动文件到""" + res[1] + @"""";
                            listView1.SelectedItems[0].SubItems[1].Tag = "Move," + res[1];
                            break;
                    }
                }
            }
        }

        private void myNormalButton2_OnButtonClick(object sender, EventArgs e)
        {
            string cfg = Application.StartupPath + @"\Config\SortingFiles\SortingFileConfig.sgcf";
            //int count = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("SortingSettings", "SelectConditionCount", "0", false, cfg), 0);
            string str = "";
            string howdo = "";
            string operate = "";
            switch(comboBox1.SelectedIndex )
            {
                case 0:
                    str = "AccordingName";
                    howdo = myTextBox2.TextBoxText;
                    string op1 = listView1.Items[0].SubItems[1].Tag.ToString();
                    string op2 = listView1.Items[1].SubItems[1].Tag.ToString();
                    string panduan1 = op1.Substring(0, 4);
                    string panduan2 = op2.Substring(0, 4);
                    string[] ops = new string[] { panduan1, panduan2 };
                    string[] opscompelete = new string[] { op1,op2 };
                    string opmain = "";
                    for (int h = 1; h <= 2; h++)
                    {
                        switch(ops[h-1])
                        {
                            case "NoOp":
                                opmain = opmain + "NoOperate|";
                                break;
                            case "Dele":
                                opmain = opmain + "Delete|";
                                break;
                            case "Move":
                                opmain = opmain + opscompelete[h - 1] + "|";
                                break;
                            case "Copy":
                                opmain = opmain + opscompelete[h - 1] + "|";
                                break;
                        }
                    }
                    operate = opmain.Substring(0,opmain.Length -1);
                    //MessageBox.Show(operate);
                        break;
                case 1:
                    str = "AccordingExtension";
                    howdo = myTextBox2.TextBoxText;
                    string op11 = listView1.Items[0].SubItems[1].Tag.ToString();
                    string op21 = listView1.Items[1].SubItems[1].Tag.ToString();
                    string panduan11 = op11.Substring(0, 4);
                    string panduan21 = op21.Substring(0, 4);
                    string[] ops1 = new string[] { panduan11, panduan21 };
                    string[] opscompelete1 = new string[] { op11,op21 };
                    string opmain1 = "";
                    for (int h = 1; h <= 2; h++)
                    {
                        switch(ops1[h-1])
                        {
                            case "NoOp":
                                opmain1 = opmain1 + "NoOperate|";
                                break;
                            case "Dele":
                                opmain1 = opmain1 + "Delete|";
                                break;
                            case "Move":
                                opmain1 = opmain1 + opscompelete1[h - 1] + "|";
                                break;
                            case "Copy":
                                opmain1 = opmain1 + opscompelete1[h - 1] + "|";
                                break;
                        }
                    }
                    operate = opmain1.Substring(0,opmain1.Length -1);
                    //MessageBox.Show(operate);
                    break;
                case 2:
                    str = "AccordingSize";
                    howdo = myTextBox2.TextBoxText;
                    switch(comboBox2.SelectedIndex )
                    {
                        case 0:
                            howdo = howdo + "MB";
                            break;
                        case 1:
                            howdo = howdo + "KB";
                            break;
                        case 2:
                            howdo = howdo + "BY";
                            break;
                    }
                    //if (minsize == -1) { howdo = howdo + "No"; } else { howdo = howdo + minsize.ToString() + "to" + maxsize.ToString(); }
                    string op30 = listView1.Items[0].SubItems[1].Tag.ToString();
                    string op31 = listView1.Items[1].SubItems[1].Tag.ToString();
                    string op32 = listView1.Items[2].SubItems[1].Tag.ToString();
                    //string op33 = listView1.Items[3].SubItems[1].Tag.ToString();
                    string panduan31 = op30.Substring(0, 4);
                    string panduan32 = op31.Substring(0, 4);
                    string panduan33 = op32.Substring(0, 4);
                    //string panduan34 = op33.Substring(0, 4);
                    string[] ops30 = new string[] { panduan31, panduan32, panduan33 };
                    string[] opscompelete2 = new string[] { op30,op31,op32 };
                    string opmain2 = "";
                    for (int h = 1; h <= 3; h++)
                    {
                        switch(ops30[h-1])
                        {
                            case "NoOp":
                                opmain2 = opmain2 + "NoOperate|";
                                break;
                            case "Dele":
                                opmain2 = opmain2 + "Delete|";
                                break;
                            case "Move":
                                opmain2 = opmain2 + opscompelete2[h - 1] + "|";
                                break;
                            case "Copy":
                                opmain2 = opmain2 + opscompelete2[h - 1] + "|";
                                break;
                        }
                    }
                    operate = opmain2.Substring(0,opmain2.Length -1);
                    //MessageBox.Show(operate);
                    break;
            }
            if(str!="" && operate !="" && howdo !="" && myTextBox2.TextBoxText !="")
            {
                //SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("SortingSettings", "SelectConditionCount", (count + 1).ToString(), "Config", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Condition" , "Type", str, "Config", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Condition" , "HowDo", howdo, "Config", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Condition" , "Operate", operate, "Config", false, cfg);
                MyFunctions.Dialogs.MessageDialog("设置成功", "成功设置了文件分拣的条件", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "", "确定");
                this.Close();
            }
            else
            {
                string o = "信息";
                switch(comboBox1.SelectedIndex )
                {
                    case 0:
                        o = "文件名";
                        break;
                    case 1:
                        o = "文件类型";
                        break;
                    case 2:
                        o = "文件大小";
                        break;
                }
                MyFunctions.Dialogs.MessageDialog("请输入完整的信息", "请输入有效的"+o , MyFunctions.Dialogs.MessageDialogIcon.Error, "", "B2", false, true, "", "确定");
            }
        }
        void loadfilesoperate()
        {
            Thread P_thread = new Thread(
                () => //lambda表达式（参数列表）=>{执行语句}  lambda表达式是比匿名方法更加简洁的一种匿名函数语法
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        for (int j = 1;j<= tags.Length; j++)
                        {
                            string nn=flag[j-1];
                            System.IO.FileInfo f = new System.IO.FileInfo(tags[j - 1]);
                            string folder = f.DirectoryName;
                            int douhaoindex = nn.IndexOf(",");
                            if(douhaoindex>0)
                            {
                                string t = nn.Substring(0, douhaoindex);
                                string location=nn.Substring(douhaoindex+1,nn.Length -douhaoindex-1);
                                string truelocation = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocationByZhidingVar(location, "filefolder", folder);
                                switch(t.ToUpper())
                                {
                                    case "MOVE":
                                        nn = @"移动到"""+truelocation +@"""";
                                        break;
                                    case "COPY":
                                        nn = @"复制到""" + truelocation + @"""";
                                        break;
                                }
                            }
                            else
                            {
                                switch (flag[j-1].ToUpper())
                                {
                                    case "DELETE":
                                        nn = @"删除文件";
                                        break;
                                    case "NOOPERATE":
                                        nn = @"不操作该文件";
                                        break;
                                }
                            }
                            listView2.Items.Add(tags[j - 1]).SubItems.Add(nn);
                        }
                    }));
                });//new thread
            P_thread.IsBackground = true;
            P_thread.Start();
        }

        private void Form_SortingFileSettings_Shown(object sender, EventArgs e)
        {
            this.tabControl1.Location = new Point(this.tabControl1.Location.X, this.tabControl1.Location.Y - 5);

            switch (this.type)
            {
                case "CREATE":
                    this.comboBox1.SelectedIndex = 0;
                    this.tabControl1.SelectedIndex = 0;
                    this.Text = label1.Text = "编辑条件";
                    comboBox2.SelectedIndex = 0;
                    break;
                case "PREVIEW":
                    this.tabControl1.SelectedIndex = 1;
                    loadfilesoperate();
                    this.Text = label1.Text = "预览更改";
                    break;
                case "NOOPERATEFILE":
                    this.tabControl1.SelectedIndex = 2;
                    this.Text = label1.Text = "排除的文件";
                    loadnooperatefiles();
                    break;
                case "EDIT":
                    tabControl1.SelectedIndex = 0;
                    this.Text = label1.Text = "编辑条件";
                    string cfg = Application.StartupPath + @"\Config\SortingFiles\SortingFileConfig.sgcf";
                    string tp = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("Condition", "type", "", false, cfg);
                    string hd = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("Condition", "howdo", "", false, cfg);
                    string opt = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("Condition", "operate", "", false, cfg);
                    string[] op = opt.Split('|');
                    switch (tp.ToLower())
                    {
                        case "accordingsize":
                            comboBox1.SelectedIndex = 2;
                            myTextBox2.TextBoxText = hd.Substring(0, hd.Length - 2);
                            string j = hd.Substring(hd.Length - 2, 2);
                            switch (j.ToUpper())
                            {
                                case "MB":
                                    comboBox2.SelectedIndex = 0;
                                    break;
                                case "KB":
                                    comboBox2.SelectedIndex = 1;
                                    break;
                                case "BY":
                                    comboBox2.SelectedIndex = 2;
                                    break;
                            }
                            //operate
                            try
                            {
                                //t1
                                int dhi = op[0].IndexOf(",");
                                if(dhi <0)
                                {
                                    //nooperate delete
                                    if (op[0].ToUpper() == "DELETE")
                                    {
                                        listView1.Items[0].SubItems[1].Text = "删除文件";
                                        listView1.Items[0].SubItems[1].Tag = "Delete";
                                    }
                                    else { listView1.Items[0].SubItems[1].Text = "不执行操作"; listView1.Items[0].SubItems[1].Tag = "NoOperate"; }
                                }
                                else
                                {
                                    //move copy
                                    string fop = op[0].Substring(0, dhi);
                                    string folder = "";
                                    folder = op[0].Substring(dhi+1, op[0].Length - dhi-1);
                                    if (fop.ToUpper() == "MOVE")
                                    {
                                        listView1.Items[0].SubItems[1].Text = @"移动文件到"""+folder+@"""";
                                        listView1.Items[0].SubItems[1].Tag = "Move,"+folder ;
                                    }
                                    else { listView1.Items[0].SubItems[1].Text = @"复制文件到""" + folder + @""""; listView1.Items[0].SubItems[1].Tag = "Copy," + folder; }

                                }
                                //t2
                                int dhi2 = op[1].IndexOf(",");
                                if (dhi2 < 0)
                                {
                                    //nooperate delete
                                    if (op[1].ToUpper() == "DELETE")
                                    {
                                        listView1.Items[1].SubItems[1].Text = "删除文件";
                                        listView1.Items[1].SubItems[1].Tag = "Delete";
                                    }
                                    else { listView1.Items[1].SubItems[1].Text = "不执行操作"; listView1.Items[1].SubItems[1].Tag = "NoOperate"; }

                                }
                                else
                                {
                                    //move copy
                                    string fop2 = op[1].Substring(0, dhi2);
                                    string folder2 = "";
                                    folder2 = op[1].Substring(dhi2 + 1, op[1].Length - dhi2 - 1);
                                    if (fop2.ToUpper() == "MOVE")
                                    {
                                        listView1.Items[1].SubItems[1].Text = @"移动文件到""" + folder2 + @"""";
                                        listView1.Items[1].SubItems[1].Tag = "Move," + folder2;
                                    }
                                    else { listView1.Items[1].SubItems[1].Text = @"复制文件到""" + folder2 + @""""; listView1.Items[1].SubItems[1].Tag = "Copy," + folder2; }
                                }
                                //t3
                                int dhi3 = op[2].IndexOf(",");
                                if (dhi3 < 0)
                                {
                                    //nooperate delete
                                    if (op[2].ToUpper() == "DELETE")
                                    {
                                        listView1.Items[2].SubItems[1].Text = "删除文件";
                                        listView1.Items[2].SubItems[1].Tag = "Delete";
                                    }
                                    else { listView1.Items[2].SubItems[1].Text = "不执行操作"; listView1.Items[2].SubItems[1].Tag = "NoOperate"; }
                                }
                                else
                                {
                                    //move copy
                                    string fop3 = op[2].Substring(0, dhi3);
                                    string folder3 = "";
                                    folder3 = op[2].Substring(dhi3 + 1, op[2].Length - dhi3 - 1);
                                    if (fop3.ToUpper() == "MOVE")
                                    {
                                        listView1.Items[2].SubItems[1].Text = @"移动文件到""" + folder3 + @"""";
                                        listView1.Items[2].SubItems[1].Tag = "Move," + folder3;
                                    }
                                    else { listView1.Items[2].SubItems[1].Text = @"复制文件到""" + folder3 + @""""; }
                                    listView1.Items[2].SubItems[1].Tag = "Copy," + folder3;
                                }
                            }
                            catch { }
                            break;
                        case "accordingextension":
                            comboBox1.SelectedIndex = 1;
                            myTextBox2.TextBoxText = hd;
                            break;
                        case "accordingname":
                            comboBox1.SelectedIndex = 0;
                            myTextBox2.TextBoxText = hd;
                            break;
                    }
                    //OPERATE

                    break;
            }
        }

        private void myNormalButton4_OnButtonClick(object sender, EventArgs e)
        {
            string RES = MyFunctions.Dialogs.MessageDialog("您确定要分拣文件吗?", "开始文件分拣后,请不要关闭程序.文件被操作后可能无法被撤销", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "B1", true, true, "确定", "取消");
            if(RES=="B1")
            {
                string[] flags = new string[tags.Length];
                for (int j = 1; j <= tags.Length; j++)
                {
                    string nn = flag[j - 1];
                    System.IO.FileInfo f = new System.IO.FileInfo(tags[j - 1]);
                    string folder = f.DirectoryName;
                    int douhaoindex = nn.IndexOf(",");
                    if (douhaoindex > 0)
                    {
                        string t = nn.Substring(0, douhaoindex);
                        string location = nn.Substring(douhaoindex + 1, nn.Length - douhaoindex - 1);
                        string truelocation = MyFunctions.StreamAndTextOperate.StrngOperate.ConvertEnviromentStringToTureLocationByZhidingVar(location, "filefolder", folder);
                        switch (t.ToUpper())
                        {
                            case "MOVE":
                                flags[j - 1] = "Move,"+truelocation;
                                break;
                            case "COPY":
                                flags[j - 1] = "Copy," + truelocation;
                                break;
                        }
                    }
                    else
                    {
                        switch (flag[j - 1].ToUpper())
                        {
                            case "DELETE":
                                flags[j - 1] = "Delete";
                                break;
                            case "NOOPERATE":
                                flags[j - 1] = "NoOperate";
                                break;
                        }
                    }
                    //listView2.Items.Add(tags[j - 1]).SubItems.Add(nn);
                }
                MyFunctions.Dialogs.FileOperateDialog(this.tags, flags, "正在分拣文件...");
                string cfg = Application.StartupPath + @"\Config\SortingFiles\SortingFileConfig.sgcf";
                MyFunctions.Dialogs.MessageDialog("成功分拣文件!", "您的文件已经成功分拣", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "确定", "确定");
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("NoOperateFiles", "Count", "0", "Config", false, cfg);
                this.Dispose();
            }
        }

        private void myNormalButton7_OnButtonClick(object sender, EventArgs e)
        {
            string fo = tags[0];
            OpenFileDialog o = new OpenFileDialog();
            o.SupportMultiDottedExtensions = false;
            o.CheckFileExists = true;
            o.Filter = "所有文件(*.*)|*.*";
            o.FileName = "";
            o.Title = "请选择一个要被排除的文件";
            o.InitialDirectory = fo;
            o.DereferenceLinks = false;
            o.ShowDialog();
            string f = o.FileName;
            if (System.IO.File.Exists(f) == true)
            {
                //判断 是否已存在
                string expf="";
                string[] expfs;
                int count;
                string cfg = Application.StartupPath + @"\Config\SortingFiles\SortingFileConfig.sgcf";
                string getcount = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("nooperatefiles", "count", "0", false, cfg);
                int.TryParse(getcount, out count);
                if(count >0)
                {
                    for (int i = 1; i <= count; i++)
                    {
                        string j = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("nooperatefiles", "nooperatefile_" + i.ToString(), "", false, cfg);
                        expf = j + "|";
                    }
                    expf = expf.Substring(0, expf.Length - 1);
                    expfs = expf.Split('|');
                    foreach (string p in expfs)
                    {
                        if (p.ToUpper() == f.ToUpper())
                        {
                            MyFunctions.Dialogs.MessageDialog("已添加", "您所要排除的文件已经被添加", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "确定", "确定");
                            return;
                        }
                    }
                }
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("NoOperateFiles", "Count", (count + 1).ToString(), "Config", false, cfg);
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("NoOperateFiles", "NoOperateFile_" + (count + 1).ToString(), f, "Config", false, cfg);
                MyFunctions.Dialogs.MessageDialog("成功添加了要排除的文件", "您成功添加了要排除的文件", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "确定", "确定");
                loadnooperatefiles();
                //
            }
        }
        void loadnooperatefiles()
        {
            try
            {
                listView3.Items.Clear();
                int count;
                string cfg = Application.StartupPath + @"\Config\SortingFiles\SortingFileConfig.sgcf";
                string getcount = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("nooperatefiles", "count", "0", false, cfg);
                int.TryParse(getcount, out count);
                for(int o=1;o<=count;o++)
                {
                    listView3.Items.Add(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("nooperatefiles", "nooperatefile_"+o.ToString(), "", false, cfg));
                }
            }
            catch { }
        }

        private void myNormalButton5_OnButtonClick(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void myNormalButton6_OnButtonClick(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void myNormalButton8_OnButtonClick(object sender, EventArgs e)
        {
            try
            {
                int count;
                string cfg = Application.StartupPath + @"\Config\SortingFiles\SortingFileConfig.sgcf";
                string getcount = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("nooperatefiles", "count", "0", false, cfg);
                int.TryParse(getcount, out count);
                string[] files = new string[count-1];
                int deleteindex = listView3.SelectedItems[0].Index+1;
                int c = 1;
                for (int y = 1; y <= count; y = y + 1)
                {
                    if (y != deleteindex)
                    {
                        files[y - c] = MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("nooperatefiles", "nooperatefile_"+y.ToString(), "", false, cfg);
                    }
                    else
                    {
                        c = c + 1;
                    }
                }
                SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("NoOperateFiles", "Count", (count - 1).ToString(), "Config", false, cfg);
                for (int g = 1; g <= files.Length; g = g + 1)
                {
                    SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("NoOperateFiles", "NoOperateFile_"+g.ToString(), files[g-1], "Config", false, cfg);
                }
                //MyFunctions.Dialogs.MessageDialog("成功删除了要排除的文件", "您成功删除了要排除的文件", MyFunctions.Dialogs.MessageDialogIcon.Information, "", "B2", false, true, "确定", "确定");
                loadnooperatefiles();

            }
            catch
            {
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox2.SelectedIndex )
            {
                case 0:
                    label4.Text = "指定的大小(MB)";
                    break;
                case 1:
                    label4.Text = "指定的大小(KB)";
                    break;
                case 2:
                    label4.Text = "指定的大小(B)";
                    break;
            }
        }


    }
}
