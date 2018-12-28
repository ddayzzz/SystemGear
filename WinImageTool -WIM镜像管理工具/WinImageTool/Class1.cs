using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace WinImageTool
{
    class Class1
    {
        public static void Public_GetImageItems(string WimFile,out int ImageNumber, out string ImageName,bool IsFenJuan,string FenFolder)
        {
            try
            {
                string cmds;
                if (IsFenJuan == false)
                {
                    cmds = @"/info """ + WimFile + @"""";
                }
                else
                {
                    cmds=@"/info """ + WimFile + @""" /ref """+FenFolder +@"\*.swm""";
                }
                Process process = new Process() ;
                string imagex = Application.StartupPath + @"\tools\imagex.exe";
                process.StartInfo.FileName = imagex;
                process.StartInfo.Arguments = cmds;
                // 必须禁用操作系统外壳程序  
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string txt;
                if (String.IsNullOrEmpty(output) == false)
                {
                    txt = output;
                }
                else { txt = "";  }
                process.WaitForExit();
                process.Close();
                //开始获取
                int count = 0;
                string img="";
                if (txt != "")
                {
                    string[] arr=Class1.Public_StringsOperate_ConvertStringsToStringArry(txt);
                    for (int t = 1; t <= arr.Length; t=t+1)
                    {
                        string readtxt=arr[t-1];
                        if (readtxt.Trim().ToUpper().Length >= 11)
                        {
                            //MessageBox.Show(readtxt.Substring(0, 11).ToUpper());
                            if (readtxt.Substring(0, 11).ToUpper() == "IMAGE COUNT")
                            {
                                string c = readtxt.Substring(readtxt.LastIndexOf(":"), readtxt.Length - readtxt.LastIndexOf(":")).Replace(":", "").Trim();
                                //MessageBox.Show(c);
                                count = Convert.ToInt32(c);
                            }
                            else
                            {

                            }
                            if (readtxt.Trim().Substring(0, 5) == "<NAME")
                            {

                                string readtrim = readtxt.Trim();
                                string nam = readtrim.Substring(readtrim.IndexOf(">"), readtrim.LastIndexOf("<"));
                                nam = nam.Substring(1, nam.LastIndexOf("<") - 1);
                                if (img == "")
                                {
                                    img = nam;
                                }
                                else
                                {
                                    img = img + "|" + nam;
                                }

                            }
                        }
                        else
                        {
                            if (readtxt.Trim().Length >= 5)
                            {
                                //MessageBox.Show(readtxt.Trim().Substring(0, 4));
                                
                            }
                        }
                    }
                }
                ImageNumber = count;
                ImageName = img;
            }
            catch { ImageName = ""; ImageNumber = 0; }
        }
        public static void Public_GetImageOrgInfo(string WimFile, out string ImageInfo, bool IsFenJuan, string FenFolder)
        {
            try
            {
                string cmds;
                if (IsFenJuan == false)
                {
                    cmds = @"/info """ + WimFile + @"""";
                }
                else
                {
                    cmds = @"/info """ + WimFile + @""" /ref """ + FenFolder + @"\*.swm""";
                }
                Process process = new Process();
                string imagex = Application.StartupPath + @"\tools\imagex.exe";
                process.StartInfo.FileName = imagex;
                process.StartInfo.Arguments = cmds;
                // 必须禁用操作系统外壳程序  
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string txt;
                if (String.IsNullOrEmpty(output) == false)
                {
                    txt = output;
                }
                else { txt = ""; }
                ImageInfo = txt;
            }
            catch { ImageInfo = ""; }
        }
        public static string[] Public_StringsOperate_ConvertStringsToStringArry(string String)
        {
            try
            {
                int lines = 0;
                string strContext = String;
                string[] str;
                if (!strContext.Equals(""))
                {
                    str = strContext.Split("\r\n".ToCharArray());
                    return str;
                }
                else { return null; }
            }
            catch { return null; }
        }
        public static string Public_StringsOperate_ReadTextInLine(string FilePath, int Line)
        {
            try
            {
                StreamReader strr = new System.IO.StreamReader(FilePath, System.Text.Encoding.GetEncoding("gb2312"));
                string[] s = strr.ReadToEnd().Split('\n');
                string p = s[Line - 1];
                strr.Close();
                return p;
            }
            catch { return ""; }
        }
        public static bool Public_GetImageNameIsHas(string ImageFile, string ImageName)
        {
            try
            {
                int c;
                string names;
                Class1.Public_GetImageItems(ImageFile, out c, out names, false, "");
                string[] imgs = names.Split('|');
                if (imgs.Length > 0)
                {
                    string ver="";
                    for (int h = 1; h <= imgs.Length; h++)
                    {
                        if (imgs[h - 1].ToUpper() == ImageName.ToUpper())
                        {
                            ver = ver + "H";
                        }
                        else
                        {
                            ver = ver + "N";
                        }
                    }
                    if (ver.Replace("N", "") == "")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        public static void Public_RegistryExtName()
        {
            try
            {
                string exe = Application.ExecutablePath;
                if (Registry.ClassesRoot.OpenSubKey("systemgear.wim") != null) { Registry.ClassesRoot.DeleteSubKeyTree("systemgear.wim"); Registry.ClassesRoot.DeleteSubKey("systemgear.wim", false); }
                if (Registry.ClassesRoot.OpenSubKey(".wim") != null) { Registry.ClassesRoot.DeleteSubKeyTree(".wim"); Registry.ClassesRoot.DeleteSubKey(".wim", false); }
                if (Registry.ClassesRoot.OpenSubKey(".wim") == null) { Registry.ClassesRoot.CreateSubKey(".wim"); }
                if (Registry.ClassesRoot.OpenSubKey("SystemGear.Wim") == null) { Registry.ClassesRoot.CreateSubKey("SystemGear.Wim").SetValue("", "Windows 映像文件"); }
                RegistryKey SubName=Registry.ClassesRoot.OpenSubKey("SystemGear.Wim",true);
                Registry.ClassesRoot.OpenSubKey(".wim", true).SetValue("", "SystemGear.Wim", RegistryValueKind.String);
                if (SubName.OpenSubKey("defaulticon") == null) { SubName.CreateSubKey("DefaultIcon"); }
                if (SubName.OpenSubKey("shell") == null) { SubName.CreateSubKey("Shell"); }
                if (SubName.OpenSubKey("shell\\Apply") == null) { SubName.OpenSubKey("shell",true).CreateSubKey("Apply").SetValue("","应用映像到当前的目录"); }
                if (SubName.OpenSubKey("shell\\delete") == null) { SubName.OpenSubKey("shell", true).CreateSubKey("Delete").SetValue("","删除该映像的映像卷"); }
                if (SubName.OpenSubKey("shell\\info") == null) { SubName.OpenSubKey("shell", true).CreateSubKey("Info").SetValue("","显示该映像的信息"); }
                if (SubName.OpenSubKey("shell\\infoS") == null) { SubName.OpenSubKey("shell", true).CreateSubKey("Infos").SetValue("", "保存该映像的信息至文件"); }
                if (SubName.OpenSubKey("shell\\export") == null) { SubName.OpenSubKey("shell", true).CreateSubKey("Export").SetValue("","导出该映像至新文件"); }
                if (SubName.OpenSubKey("shell\\split") == null) { SubName.OpenSubKey("shell", true).CreateSubKey("Split").SetValue("","拆分该映像"); }
                if (SubName.OpenSubKey("shell\\ZAppend") == null) { SubName.OpenSubKey("shell", true).CreateSubKey("ZAppend").SetValue("", "捕获目录并附加至该映像") ; }
                if (SubName.OpenSubKey("shell\\Apply\\command") == null) { SubName.OpenSubKey("shell\\apply", true).CreateSubKey("Command").SetValue("", exe + @" /Select=""%1"" /Flags=""Apply"" /FolderPath=""SelectPath"" /ImageIndex=""1"" /ApplyNow=""False"""); }
                if (SubName.OpenSubKey("shell\\delete\\command") == null) { SubName.OpenSubKey("shell\\delete", true).CreateSubKey("Command").SetValue("", exe + @" /Select=""%1"" /Flags=""Delete"" /ImageIndex=""1"" /DeleteNow=""False"""); }
                if (SubName.OpenSubKey("shell\\infos\\command") == null) { SubName.OpenSubKey("shell\\infos", true).CreateSubKey("Command").SetValue("", exe + @" /Select=""%1"" /Flags=""Info"" /SaveInfoPath=""SelectPath"""); }
                if (SubName.OpenSubKey("shell\\info\\command") == null) { SubName.OpenSubKey("shell\\info", true).CreateSubKey("Command").SetValue("", exe + @" /Select=""%1"" /Flags=""Info"""); }
                if (SubName.OpenSubKey("shell\\export\\command") == null) { SubName.OpenSubKey("shell\\export", true).CreateSubKey("Command").SetValue("", exe + @" /Select=""%1"" /Flags=""Export"" /ImageIndex=""1"" /NewWimPath="""" /ExportNow=""False"""); }
                if (SubName.OpenSubKey("shell\\split\\command") == null) { SubName.OpenSubKey("shell\\split", true).CreateSubKey("Command").SetValue("", exe + @" /Select=""%1"" /Flags=""Split"" /Size="""" /SavePath="""" /SplitNow=""False"""); }
                if (SubName.OpenSubKey("shell\\Zappend\\command") == null) { SubName.OpenSubKey("shell\\Zappend", true).CreateSubKey("Command").SetValue("", exe +@" /Select=""%1"" /Flags=""Append"" /FolderPath="""" /AppendNow=""False"""); }
                SubName.OpenSubKey("DefaultIcon", true).SetValue("", Application.StartupPath + "\\WimageToolRes.dll,0");

           }
            catch { }
        }
        public static void Public_RegistryDir()
        {
            try
            {
                string exe = Application.ExecutablePath;
                if (Registry.ClassesRoot.OpenSubKey("Directory") == null) { Registry.ClassesRoot.CreateSubKey("Directory"); }
                if (Registry.ClassesRoot.OpenSubKey("Directory\\shell") == null) { Registry.ClassesRoot.CreateSubKey("Directory\\Shell"); }
                if (Registry.ClassesRoot.OpenSubKey("Directory\\shell\\createwim") == null) { Registry.ClassesRoot.CreateSubKey("Directory\\shell\\CreateWim"); }
                if (Registry.ClassesRoot.OpenSubKey("Directory\\shell\\createwim\\command") == null) { Registry.ClassesRoot.CreateSubKey("Directory\\shell\\createwim\\Command"); }
                Registry.ClassesRoot.OpenSubKey("Directory\\shell\\createwim", true).SetValue("", "捕获该目录至映像");
                Registry.ClassesRoot.OpenSubKey("Directory\\shell\\createwim\\command", true).SetValue("", exe + @" /Select=""%1"" /Flags=""Create"" /WimPath=""SelectPath"" /CreatNow=""False""");
            }
            catch { }
        }
    }
}
