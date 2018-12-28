using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SystemGear.控件
{
    
    public partial class SGTileContainer : UserControl
    {
        #region 定义常量
        private static int _basic_unit_tileunit = 50; //这个是TILE的基本单位 磁贴的大小参考这个
        private static int _basic_unit_tiledistance = 6; //这是相邻两个磁贴的间隔宽度
        private static  string _basic_configfile = ""; //用于记录磁贴的信息的配置文件
        private static Size _basic_containersize;
        #endregion
        #region 方法
        private static string[] GetTileInfo(string codename)
        {
            string[] r = new string[] {"NAME","DESCRIPTION","sgcommand","" };
            return r;
        }
        /// <summary>
        /// 此方法用于第一次加载主界面磁贴
        /// </summary>
        private static void LoadTile(Size mesize)
        {
            //计算一行、一列能容纳多少个单位
            int line_maxunits = mesize.Width / _basic_unit_tileunit;
            int column_maxunits = mesize.Height / _basic_unit_tileunit;
            //定义已加载到的磁贴的集合
            string[] tilesgroup_wide = new string[] { "W1", "W2", "W3" };
            string[] tilesgroup_small = new string[] { "S1", "S2", "S3", "S4", "S5" };
            string[] tilesgroup_middle = new string[] { "M1", "M2", "M3", "M4" };
            string[] tilesgroup_large = new string[] { "L1", "L2" };
            //定义磁贴的大小
            Size tile_large_size = new System.Drawing.Size(_basic_unit_tileunit * 4 + _basic_unit_tiledistance * 3, _basic_unit_tiledistance * 3 + _basic_unit_tileunit * 4);
            Size tile_middle_size = new System.Drawing.Size(_basic_unit_tileunit * 2 + _basic_unit_tiledistance, _basic_unit_tiledistance + _basic_unit_tileunit * 2);
            Size tile_wide_size = new System.Drawing.Size(_basic_unit_tileunit * 4 + _basic_unit_tiledistance * 3, _basic_unit_tiledistance + _basic_unit_tileunit * 2);
            Size tile_small_size = new System.Drawing.Size(_basic_unit_tileunit, _basic_unit_tileunit);
            //定义程序运行过程中的变量
            Point tile_createdlocation = new System.Drawing.Point(0, 0);
            Point tile_thelasttilelocation = new System.Drawing.Point(0, 0);
            Size tile_thelasttilesize = new System.Drawing.Size(0, 0);
            //磁贴优先级顺序 L>W>M>X
            //确定第一个磁贴
            string thefirsttile_codename = "";
            if (tilesgroup_large != null)
            {
                //不为空集
            }
            else 
            { 

            }


        }
        #endregion
        /// <summary>
        /// 用于初始化控件
        /// </summary>
        public SGTileContainer()
        {
            InitializeComponent();
        }

    }
}
