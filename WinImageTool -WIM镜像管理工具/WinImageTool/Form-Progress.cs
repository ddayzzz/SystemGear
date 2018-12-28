using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace WinImageTool
{
    public partial class Form_Progress : Form
    {
        public string cmds;
        public string Type;
        public string RunTag;
        public bool autonotexit;
        public Size formsize;
        public Form_Progress(string Type,string cmd,string Tag,bool WaitForUserChoose)
        {
            InitializeComponent();
            this.cmds = cmd;
            this.Type = Type;
            this.RunTag = Tag;
            autonotexit = WaitForUserChoose;
            switch (Type.ToUpper())
            {
                case "CREATE":
                    label1.Text = "正在创建映像文件......";
                    break;
                case "SPLIT":
                    label1.Text = "正在拆分映像......";
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    progressBar1.MarqueeAnimationSpeed = 50;
                    break;
                case "APPLY":
                    label1.Text = "正在应用映像......";
                    break;
                case "DELETE":
                    label1.Text = "正在删除映像卷......";
                     progressBar1.Style = ProgressBarStyle.Marquee;
                     progressBar1.MarqueeAnimationSpeed = 50;
                    break;
                case "APPEND":
                    label1.Text = "正在追加映像卷......";
                    break;
                case "EXPORT":
                    label1.Text = "正在导出映像......";
                    break;
            }
            this.Text = label1.Text;
        }

        private void Form_Progress_Load(object sender, EventArgs e)
        {
            this.Size = new Size(583, 177);
        }
        #region 运行程序并读取信息
        void t_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox1.Text = str;
            if (progressBar1.Value == 100 && Type != "SPLIT" && Type !="DELETE")
            {
                switch (Type.ToUpper())
                {
                    case "CREATE":
                        if (autonotexit == true)
                        {
                            label1.Text = "创建映像成功";
                            this.Text = label1.Text;
                            button1.Visible = button2.Visible = true;
                            button2.Text = "打开映像";
                            button1.Text = "打开映像存放目录";
                        }
                        else
                        {
                            this.Dispose();
                        }
                        break;
                    case "APPLY":
                        if (autonotexit == true)
                        {
                            label1.Text = "应用映像成功";
                            this.Text = label1.Text;
                            button2.Visible = false;
                            button1.Visible = true;
                            button1.Text = "打开应用的目录";
                        }
                        else
                        {
                            this.Dispose();
                        }
                        break;
                    case "APPEND":
                        if (autonotexit == true)
                        {
                            label1.Text = "追加映像卷成功";
                            this.Text = label1.Text;
                            button2.Visible = button1.Visible = true;
                            button2.Text = "打开映像";
                            button1.Text = "打开映像存放目录";
                        }
                        else
                        {
                            this.Dispose();
                        }
                        break;
                    case "EXPORT":
                        if (autonotexit == true)
                        {
                            label1.Text = "导出映像成功";
                            this.Text = label1.Text;
                            button2.Visible = button1.Visible = true;
                            button2.Text = "打开映像";
                            button1.Text = "打开映像存放目录";
                        }
                        else
                        {
                            this.Dispose();
                        }
                        break;
                }
            }
            else
            {
                if (Type == "SPLIT")
                {
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 100;
                    label2.Text = "100%";
                    string[] sd = RunTag.Split('*');
                    if (sd[1] == "DELE") { System.IO.File.Delete(sd[0]); }
                    if (autonotexit == true)
                    {
                        label1.Text = "拆分映像成功";
                        this.Text = label1.Text;
                        //button1.Visible = button2.Visible = true;
                    }
                    else
                    {
                        this.Dispose();
                    }
                }
                //DELETE
                if (Type.ToUpper() == "DELETE")
                {
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 100;
                    label2.Text = "100%";
                    if (autonotexit == true)
                    {
                        label1.Text = "删除映像卷成功";
                        this.Text = label1.Text;
                        button2.Visible = true;
                        button1.Visible = true;
                    }
                    else
                    {
                        this.Dispose();
                    }
                }
            }
        }

        void t_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (str != String.Empty)
                    (sender as BackgroundWorker).ReportProgress(50);
                else break;
                Thread.Sleep(500);
            }
        }

        string str;
        
        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            
            str = str + "\r\n" + (e.Data);
            string GetStr = (e.Data);
            if (GetStr != null)
            {
                if (GetStr.Length >= 5)
                {
                    if (System.Text.RegularExpressions.Regex.Matches(GetStr, "]").Count == 1)
                    {
                        string jindu = GetStr.Substring(0, GetStr.LastIndexOf("]"));
                        jindu = jindu.Replace("[", "").Replace("]", "").Replace(" ", "").Replace("%", "");
                        int progresss;
                        int.TryParse(jindu, out progresss);
                        progressBar1.Value = progresss;
                        label2.Text = progressBar1.Value.ToString() + "%";
                    }
                    else
                    {
                        if (GetStr.Substring(0, 3).ToUpper() == "SUC")
                        {
                            
                            //MessageBox.Show("ok");
                            
                        }
                    }
                }
            }
        }
        void t_end(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
    
        #endregion

        private void Form_Progress_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            string imagex = Application.StartupPath + @"\tools\imagex.exe";
            if (System.IO.File.Exists(imagex) == true)
            {
                Process p;
                p = new Process();
                p.StartInfo = new ProcessStartInfo(imagex, cmds);
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                p.StartInfo.CreateNoWindow = true;
                p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
                p.Start();
                p.BeginOutputReadLine();
                p.WaitForExit();
                BackgroundWorker t = new BackgroundWorker();
                t.WorkerReportsProgress = true;
                t.ProgressChanged += new ProgressChangedEventHandler(t_ProgressChanged);
                t.DoWork += new DoWorkEventHandler(t_DoWork);
                t.RunWorkerCompleted += new RunWorkerCompletedEventHandler(t_end);
                t.RunWorkerAsync();
            }
            else
            {
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "显示详细信息")
            {
                this.formsize = this.Size;
                textBox1.Visible = true;
                this.Size = new Size(583, 311);
                button7.Text = "隐藏详细信息";
            }
            else
            {
                textBox1.Visible = false;
                this.Size = formsize;
                button7.Text = "显示详细信息";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Type.ToUpper())
                {
                    case "CREATE":
                        Process.Start(RunTag);
                        this.Dispose();
                        break;
                    case "APPEND":
                        Process.Start(this.RunTag);
                        this.Dispose();
                        break;
                    case "DELETE":
                        Process.Start(this.RunTag);
                        this.Dispose();
                        break;
                    case "EXPORT":
                        Process.Start(this.RunTag);
                        this.Dispose();
                        break;
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Type.ToUpper())
                {
                    case "CREATE":
                        Process.Start("explorer.exe",@"/e,/select,"+this.RunTag);
                        this.Dispose();
                        break;
                    case "APPLY":
                        Process.Start("explorer.exe", this.RunTag);
                        this.Dispose();
                        break;
                    case "APPEND":
                        Process.Start("explorer.exe", @"/e,/select," + this.RunTag);
                        this.Dispose();
                        break;
                    case "DELETE":
                        Process.Start("explorer.exe",@"/e,/select,"+this.RunTag);
                        this.Dispose();
                        break;
                    case "EXPORT":
                        Process.Start("explorer.exe", @"/e,/select," + this.RunTag);
                        this.Dispose();
                        break;
                }
            }
            catch { }
        }
    }
}
