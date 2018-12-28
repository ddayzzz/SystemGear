using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SystemGear
{
    public partial class Form_FileOperate : Form
    {
        /*
         * operateflags 格式
         * Copy,<folder>
         * Move,<folder>
         * Delete
         */
        private string OPFILE_FILEPATH,OPFILE_NEWFILE;
        private System.Threading.Thread thdAddFile; //创建一个线程
        FileStream FormerOpen;//实例化FileStream类
        private int indexoflistview;
        FileStream ToFileOpen;//实例化FileStream类
        string[] files, operateflag;
        #region 用于加载
        public delegate void LoadSetting();//定度委托
        /// <summary>
        /// 在线程上执行委托
        /// </summary>
        public void LoadWT()
        {
            this.Invoke(new LoadSetting(LoadSettingFF));//在线程上执行指定的委托
        }

        /// <summary>
        /// 对文件进行复制，并在复制完成后关闭线程
        /// </summary>
        public void LoadSettingFF()
        {
            this.LoadToListview();
            thdAddFile.Abort();//关闭线程
        }
        #endregion
        #region 用于kaishi
        public delegate void StartOperate();//定度委托
        /// <summary>
        /// 在线程上执行委托
        /// </summary>
        public void LoadWT1()
        {
            this.BeginInvoke(new LoadSetting(START));//在线程上执行指定的委托
        }

        /// <summary>
        /// 对文件进行复制，并在复制完成后关闭线程
        /// </summary>
        public void START()
        {
            this.MainOperateFile();
            thdAddFile.Abort();//关闭线程
        }
        #endregion
        public Form_FileOperate(string[] files,string[] operateflags,string title)
        {
            InitializeComponent();
            this.Text = this.label1.Text = title;
            this.files = files;
            this.operateflag = operateflags;
            this.imageList1.Images.Clear();
            this.listView2.Items.Clear();
        }

        private void Form_FileOperate_Shown(object sender, EventArgs e)
        {
            thdAddFile  = new Thread(new ThreadStart(LoadWT));//创建一个线程
            thdAddFile.Start();//执行当前线程
        }
        void LoadToListview()
        {
            try
            {
                for (int h = 1; h <= files.Length; h++)
                {
                    //将文件激flags加载到listview
                    //判断flags
                    int dhindex = operateflag[h - 1].IndexOf(",");
                    string flag = "";
                    string folder = "";
                    if (dhindex > 0)
                    {
                        //可能为copy和move
                        string dir = operateflag[h - 1].Substring(dhindex + 1, operateflag[h - 1].Length - dhindex - 1);
                        string flg = operateflag[h - 1].Substring(0, dhindex);
                        switch (flg.ToUpper())
                        {
                            case "COPY":
                                flag = "复制文件到";
                                break;
                            case "MOVE":
                                flag = "移动文件到";
                                break;
                        }
                        folder = dir;
                    }
                    else
                    {
                        //是delete或nooperate
                        string flg = operateflag[h - 1].ToUpper();
                        if(flg=="DELETE")
                        {
                            flag = "删除文件";
                            folder = "";
                        }
                        else
                        {
                            flag = "不操作文件";
                            folder = "";
                        }
                    }
                    //添加item
                    listView2.Items.Add(files[h - 1]).SubItems.Add(flag);
                    listView2.Items[h - 1].SubItems.Add(folder);
                    listView2.Items[h - 1].SubItems.Add("等待操作");
                    if (h == 1)
                    {
                        imageList1.Images.Add(Properties.Resources.OperatingFileOperate);
                    }
                    else
                    {
                        imageList1.Images.Add(Properties.Resources.WaitFileOperate);
                    }
                    listView2.Items[h - 1].ImageIndex = h - 1;
                }
                //this.MainOperateFile();
            }
            catch { }
        }
        /// <summary>
        /// 文件的复制
        /// </summary>
        /// <param FormerFile="string">源文件路径</param>
        /// <param toFile="string">目的文件路径</param> 
        /// <param SectSize="int">传输大小</param> 
        /// <param progressBar="ProgressBar">ProgressBar控件</param> 
        public void CopyFile(string FormerFile, string toFile, int SectSize, ProgressBar progressBar1)
        {
            progressBar1.Value = 0;//设置进度栏的当前位置为0
            progressBar1.Minimum = 0;//设置进度栏的最小值为0
            FileStream fileToCreate = new FileStream(toFile, FileMode.Create);//创建目的文件，如果已存在将被覆盖
            fileToCreate.Close();//关闭所有资源
            fileToCreate.Dispose();//释放所有资源
            FormerOpen = new FileStream(FormerFile, FileMode.Open, FileAccess.Read);//以只读方式打开源文件
            ToFileOpen = new FileStream(toFile, FileMode.Append, FileAccess.Write);//以写方式打开目的文件
            int max = Convert.ToInt32(Math.Ceiling((double)FormerOpen.Length / (double)SectSize));//根据一次传输的大小，计算传输的个数
            progressBar1.Maximum = max;//设置进度栏的最大值
            int FileSize;//要拷贝的文件的大小
            if (SectSize < FormerOpen.Length)//如果分段拷贝，即每次拷贝内容小于文件总长度
            {

                byte[] buffer = new byte[SectSize];//根据传输的大小，定义一个字节数组
                int copied = 0;//记录传输的大小
                int tem_n = 1;//设置进度栏中进度块的增加个数
                while (copied <= ((int)FormerOpen.Length - SectSize))//拷贝主体部分
                {
                    Application.DoEvents();
                    FileSize = FormerOpen.Read(buffer, 0, SectSize);//从0开始读，每次最大读SectSize
                    FormerOpen.Flush();//清空缓存
                    ToFileOpen.Write(buffer, 0, SectSize);//向目的文件写入字节
                    ToFileOpen.Flush();//清空缓存
                    ToFileOpen.Position = FormerOpen.Position;//使源文件和目的文件流的位置相同
                    copied += FileSize;//记录已拷贝的大小
                    progressBar1.Value = progressBar1.Value + tem_n;//增加进度栏的进度块
                }
                int left = (int)FormerOpen.Length - copied;//获取剩余大小
                FileSize = FormerOpen.Read(buffer, 0, left);//读取剩余的字节
                FormerOpen.Flush();//清空缓存
                ToFileOpen.Write(buffer, 0, left);//写入剩余的部分
                ToFileOpen.Flush();//清空缓存
            }
            else//如果整体拷贝，即每次拷贝内容大于文件总长度
            {
                byte[] buffer = new byte[FormerOpen.Length];//获取文件的大小
                FormerOpen.Read(buffer, 0, (int)FormerOpen.Length);//读取源文件的字节
                FormerOpen.Flush();//清空缓存
                ToFileOpen.Write(buffer, 0, (int)FormerOpen.Length);//写放字节
                ToFileOpen.Flush();//清空缓存
            }
            FormerOpen.Close();//释放所有资源
            ToFileOpen.Close();//释放所有资源
            //复制完成
        }
        public void MoveFile(string FormerFile, string toFile, int SectSize, ProgressBar progressBar1)
        {
            progressBar1.Value = 0;//设置进度栏的当前位置为0
            progressBar1.Minimum = 0;//设置进度栏的最小值为0
            FileStream fileToCreate = new FileStream(toFile, FileMode.Create);//创建目的文件，如果已存在将被覆盖
            fileToCreate.Close();//关闭所有资源
            fileToCreate.Dispose();//释放所有资源
            FormerOpen = new FileStream(FormerFile, FileMode.Open, FileAccess.Read);//以只读方式打开源文件
            ToFileOpen = new FileStream(toFile, FileMode.Append, FileAccess.Write);//以写方式打开目的文件
            int max = Convert.ToInt32(Math.Ceiling((double)FormerOpen.Length / (double)SectSize));//根据一次传输的大小，计算传输的个数
            progressBar1.Maximum = max;//设置进度栏的最大值
            int FileSize;//要拷贝的文件的大小
            if (SectSize < FormerOpen.Length)//如果分段拷贝，即每次拷贝内容小于文件总长度
            {
                byte[] buffer = new byte[SectSize];//根据传输的大小，定义一个字节数组
                int copied = 0;//记录传输的大小
                int tem_n = 1;//设置进度栏中进度块的增加个数
                while (copied <= ((int)FormerOpen.Length - SectSize))//拷贝主体部分
                {
                    Application.DoEvents();
                    FileSize = FormerOpen.Read(buffer, 0, SectSize);//从0开始读，每次最大读SectSize
                    FormerOpen.Flush();//清空缓存
                    ToFileOpen.Write(buffer, 0, SectSize);//向目的文件写入字节
                    ToFileOpen.Flush();//清空缓存
                    ToFileOpen.Position = FormerOpen.Position;//使源文件和目的文件流的位置相同
                    copied += FileSize;//记录已拷贝的大小
                    progressBar1.Value = progressBar1.Value + tem_n;//增加进度栏的进度块
                    //label3.Text = "已完成" + ((progressBar1.Value/progressBar1.Maximum) * 100) + "%";
                }
                int left = (int)FormerOpen.Length - copied;//获取剩余大小
                FileSize = FormerOpen.Read(buffer, 0, left);//读取剩余的字节
                FormerOpen.Flush();//清空缓存
                ToFileOpen.Write(buffer, 0, left);//写入剩余的部分
                ToFileOpen.Flush();//清空缓存
            }
            else//如果整体拷贝，即每次拷贝内容大于文件总长度
            {
                byte[] buffer = new byte[FormerOpen.Length];//获取文件的大小
                FormerOpen.Read(buffer, 0, (int)FormerOpen.Length);//读取源文件的字节
                FormerOpen.Flush();//清空缓存
                ToFileOpen.Write(buffer, 0, (int)FormerOpen.Length);//写放字节
                ToFileOpen.Flush();//清空缓存
            }
            FormerOpen.Close();//释放所有资源
            ToFileOpen.Close();//释放所有资源
            //复制完成
        }
        void MainOperateFile()
        {
            try
            {
                for (int j = 1; j <= files.Length; j++)
                {
                    string type = listView2.Items[j - 1].SubItems[1].Text.ToUpper();
                    string folder = listView2.Items[j - 1].SubItems[2].Text;
                    if (System.IO.Directory.Exists(folder) == false) { MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(folder); }
                    string file = listView2.Items[j - 1].Text;
                    imageList1.Images[j - 1] = Properties.Resources.OperatingFileOperate;
                    listView2.Items[j - 1].SubItems[3].Text = "操作中";
                    if (System.IO.File.Exists(file) == true)
                    {
                        switch (type)
                        {
                            case "删除文件":
                                label3.Text = "正在删除文件...";
                                label2.Text = "正在删除文件...";
                                MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(file);
                                imageList1.Images[j - 1] = Properties.Resources.FinishFileOperate;
                                label3.Text = "已成功删除文件";
                                label2.Text = "删除文件成功";
                                listView2.Items[j - 1].SubItems[3].Text = "删除成功";
                                break;
                            case "不操作文件":
                                imageList1.Images[j - 1] = Properties.Resources.FinishFileOperate;
                                break;
                            case "复制文件到":
                                this.indexoflistview = j - 1;
                                OPFILE_FILEPATH = file;
                                FileInfo f = new FileInfo(file);
                                DirectoryInfo dir=new DirectoryInfo(folder);
                                string filename = f.Name;
                                OPFILE_NEWFILE = folder + "\\" + filename;
                                //thdAddFile = new Thread(new ThreadStart(SetAddFile));//创建一个线程
                                //thdAddFile.Start();//执行当前线程
                                label3.Text = "正在复制文件...";
                                DirectoryInfo od = f.Directory;
                                label2.Text = @"从"""+od.Name  +@"""复制到"""+dir.Name+@"""";
                                if (System.IO.File.Exists(OPFILE_NEWFILE) == true)
                                {
                                    string[] ops = new string[] { "保留原文件", "替换旧文件", "保留两个文件" };
                                    string cn = MyFunctions.Dialogs.TasksChooseDialog(@"已在新的目录下找到了同名文件""" + filename + @"""", ops);
                                    switch (cn)
                                    {
                                        case "T1":
                                            break;
                                        case "T2":
                                            CopyFile(file, OPFILE_NEWFILE, 1024, progressBar1);
                                            break;
                                        case "T3":
                                            if (f.Extension != "")
                                            {
                                                OPFILE_NEWFILE = folder + "\\" + filename.Substring(0, filename.IndexOf(".")) + " (新)" + f.Extension;
                                            }
                                            else { OPFILE_NEWFILE = folder + "\\" + filename + " (新)" + f.Extension; }
                                            CopyFile(file, OPFILE_NEWFILE, 1024, progressBar1);
                                            break;
                                    }
                                }
                                else
                                {
                                    CopyFile(file, OPFILE_NEWFILE, 1024, progressBar1);
                                }
                                imageList1.Images[j - 1] = Properties.Resources.FinishFileOperate;
                                label3.Text = "已成功复制文件";
                                label2.Text = "复制文件成功";
                                listView2.Items[j - 1].SubItems[3].Text = "复制成功";
                                break;
                            case "移动文件到":
                                this.indexoflistview = j - 1;
                                OPFILE_FILEPATH = file;
                                FileInfo f1 = new FileInfo(file);
                                OPFILE_NEWFILE = folder + "\\" + f1.Name;
                                //thdAddFile = new Thread(new ThreadStart(SetAddFile1));//创建一个线程
                                //thdAddFile.Start();//执行当前线程
                                label3.Text = "正在移动文件...";
                                DirectoryInfo dir1 = new DirectoryInfo(folder);
                                DirectoryInfo od1 = f1.Directory;
                                label2.Text = @"从""" + od1.Name  + @"""移动到""" + dir1.Name + @"""";
                                if (System.IO.File.Exists(OPFILE_NEWFILE) == true)
                                {
                                    string[] ops1 = new string[] { "保留原文件", "替换旧文件", "保留两个文件" };
                                    string cn1 = MyFunctions.Dialogs.TasksChooseDialog(@"已在新的目录下找到了同名文件""" + f1.Name  + @"""", ops1);
                                    switch (cn1)
                                    {
                                        case "T1":
                                            break;
                                        case "T2":
                                            MoveFile(file, OPFILE_NEWFILE, 1024, progressBar1);
                                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(OPFILE_FILEPATH);
                                            break;
                                        case "T3":
                                            if (f1.Extension != "")
                                            {
                                                OPFILE_NEWFILE = folder + "\\" + f1.Name.Substring(0, f1.Name.IndexOf(".")) + " (新)" + f1.Extension;
                                            }
                                            else { OPFILE_NEWFILE = folder + "\\" + f1.Name  + " (新)" + f1.Extension; }
                                            MoveFile(file, OPFILE_NEWFILE, 1024, progressBar1);
                                            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(OPFILE_FILEPATH);
                                            break;
                                    }
                                }
                                else
                                {
                                    MoveFile(file, OPFILE_NEWFILE, 1024, progressBar1);
                                    MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(OPFILE_FILEPATH);
                                }
                                imageList1.Images[j - 1] = Properties.Resources.FinishFileOperate;
                                label3.Text = "已成功移动文件";
                                label2.Text = "移动文件成功";
                                listView2.Items[j - 1].SubItems[3].Text = "移动成功";
                                break;
                        }
                        listView2.Refresh();
                        progressBar1.Maximum = 100;
                        progressBar1.Value = 100;
                    }
                    else
                    {
                        imageList1.Images[j - 1] = Properties.Resources.ErrorFileOperate;
                        listView2.Items[j - 1].SubItems[3].Text = "操作失败";
                        listView2.Refresh();
                    }
                    if(j==files.Length )
                    {
                        label3.Text = "已成功完成您的操作";
                        label3.Location = new Point(label3.Location.X - 27, label3.Location.Y);
                        label2.Text = "操作文件成功";
                        myNormalButton5.ButtonText = "完成并退出";
                    }
                }
            }
            catch(Exception er)
            {
                MessageBox.Show("操作文件出错\r\n" + er.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }

        private void myNormalButton5_OnButtonClick(object sender, EventArgs e)
        {
           if(myNormalButton5.ButtonText =="开始")
           {
               string RES = MyFunctions.Dialogs.MessageDialog("确定开始？", "您确定要开始操作文件吗?我们在操作文件时可能会创建新的文件夹，请提前做好备份。本操作可能不可逆。操作文件对话框的性能可能会受到操作系统、硬件系统的等其他因素的影响，敬请谅解。", MyFunctions.Dialogs.MessageDialogIcon.Question, "", "B1", true, true, "确定", "取消");
               if(RES=="B1")
               {
               thdAddFile = new Thread(new ThreadStart(LoadWT1));//创建一个线程
               thdAddFile.Start();//执行当前线程
               }
               
           }
           else
           {
               this.Dispose();
           }
        }


    }
}
