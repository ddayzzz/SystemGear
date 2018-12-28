using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;


namespace SystemGear
{

    public partial class Form_PingApp : Form
    {
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr whnd, int dwtime, int dwflag);
        //dwflag的取值如下
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        //从左到右显示
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        //从右到左显示
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        //从上到下显示
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        //从下到上显示
        public const Int32 AW_CENTER = 0x00000010;
        //若使用了AW_HIDE标志，则使窗口向内重叠，即收缩窗口；否则使窗口向外扩展，即展开窗口
        public const Int32 AW_HIDE = 0x00010000;
        //隐藏窗口，缺省则显示窗口
        public const Int32 AW_ACTIVATE = 0x00020000;
        //激活窗口。在使用了AW_HIDE标志后不能使用这个标志
        public const Int32 AW_SLIDE = 0x00040000;
        //使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略
        public const Int32 AW_BLEND = 0x00080000;
        //透明度从高到低
        public string ProgramArgs, ProgramName, LogoLocation, Info;
        public Point Loc;
        public string appicon;
        public Form_PingApp(string ProgramArgs, string ProgramName, string LogoLocation, string Info,string Icon, Point Location)
        {
            InitializeComponent();
            this.ProgramArgs = ProgramArgs;
            this.ProgramName = ProgramName.Replace(@"""","");
            this.LogoLocation = LogoLocation;
            this.Info = Info;
            this.Loc = Location;
            this.Location = Location;
            this.appicon = Icon;
        }

        private void Form_PingApp_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 130, AW_BLEND | AW_ACTIVATE);
            this.Location = this.Loc;
            textBox1.Text = "系统齿轮 - " + ProgramName;
            textBox2.Text = Info;
            try
            {
                /*
                Assembly myAssembly;
                myAssembly = System.Reflection.Assembly.Load("SystemGear");
                System.Resources.ResourceManager myManager = new System.Resources.ResourceManager("SystemGear.Properties.Resources", myAssembly);
                 */
                //System.Drawing.Image myImage = (System.Drawing.Image)myManager.GetObject(this.LogoLocation);  //HW.BMP
                System.Drawing.Image IMG = MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithPicture(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionLogo, LogoLocation, false);
                pictureBox1.Image = IMG;
            }
            catch { }
        }

        private void Form_PingApp_Deactivate(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 130, AW_HOR_NEGATIVE | AW_HIDE);
            this.Close();
        }

        private void Form_PingApp_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.GetApplicationSetting_MainColor(), 2.0f), new Rectangle(0, 0, this.Width, this.Height));
        }

        private void button1_Click(object sender, EventArgs e)       
        {
            MyFunctions.ProgramAndLinksOperate.CreateLink(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + textBox1.Text + ".lnk", Application.ExecutablePath, this.ProgramArgs, textBox2.Text, MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionIco, this.LogoLocation, false), null);
            AnimateWindow(this.Handle, 130, AW_HOR_NEGATIVE | AW_HIDE);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string startpath = Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\奥威森网络\系统齿轮";
            if (System.IO.Directory.Exists(startpath) == false)
            {
                MyFunctions.FileSystemOperate.FileSystemOperate_CreateNewFolder(startpath);
            }
            MyFunctions.ProgramAndLinksOperate.CreateLink(startpath + @"\" + textBox1.Text + ".lnk", Application.ExecutablePath, this.ProgramArgs, textBox2.Text, MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionIco, this.LogoLocation, false), null);
            AnimateWindow(this.Handle, 130, AW_HOR_NEGATIVE | AW_HIDE);
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string ll = Application.StartupPath + @"\config\pings.sgcf";
            int j = MyFunctions.StreamAndTextOperate.ConvertData.StringsToInt(MyFunctions.StreamAndTextOperate.ConfigFileOperate.SGCFFileOperate_GetValue("info", "count", "0", false, Application.StartupPath + @"\config\pings.sgcf"), 0);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + (j + 1).ToString(), "Name", this.ProgramName, "Config", false, ll);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + (j + 1).ToString(), "ColorR", pictureBox1.BackColor.R.ToString(), "Config", false, ll);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + (j + 1).ToString(), "ColorG", pictureBox1.BackColor.G.ToString(), "Config", false, ll);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + (j + 1).ToString(), "ColorB", pictureBox1.BackColor.B.ToString(), "Config", false, ll);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + (j + 1).ToString(), "Image", this.LogoLocation, "Config", false, ll);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + (j + 1).ToString(), "Command", Application.ExecutablePath, "Config", false, ll);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + (j + 1).ToString(), "CommandArgs", this.ProgramArgs, "Config", false, ll);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Ping" + (j + 1).ToString(), "Info", textBox2.Text, "Config", false, ll);
            SGFunction.ConfigFileOperate.SGCFFileOperate_WriteValue("Info", "Count", (j+1).ToString(), "Config", false, ll);
            AnimateWindow(this.Handle, 130, AW_HOR_NEGATIVE | AW_HIDE);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string templink = Environment.GetEnvironmentVariable("tmp") + @"\" + textBox1.Text + ".lnk";
            MyFunctions.ProgramAndLinksOperate.CreateLink(templink, Application.ExecutablePath, this.ProgramArgs, textBox2.Text, MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageLocationWithString(MyFunctions.ApplicationAndEnvironmentInformation.ApplicationSettings.SkinsAndResources.GetSkin_GetImageType.FunctionIco, this.LogoLocation, false), null);
            MyFunctions.ProgramAndLinksOperate.PingProgramInTaskBar(true, templink);
            MyFunctions.FileSystemOperate.FileSystemOperate_DeleteFile(templink);
            AnimateWindow(this.Handle, 130, AW_HOR_NEGATIVE | AW_HIDE);
            this.Close();
        }
    }
}
