namespace SystemGear.功能控件
{
    partial class SGUserControl_SystemToolBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.sgTabPageControl1 = new SystemGear.SGTabPageControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.sgRightMenus1 = new SystemGear.控件.SGRightMenus();
            this.添加到桌面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加到任务栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加到开始菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sgTabPageControl1.SuspendLayout();
            this.sgRightMenus1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sgTabPageControl1
            // 
            this.sgTabPageControl1.Controls.Add(this.tabPage1);
            this.sgTabPageControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgTabPageControl1.ItemSize = new System.Drawing.Size(100, 33);
            this.sgTabPageControl1.Location = new System.Drawing.Point(-2, 3);
            this.sgTabPageControl1.Name = "sgTabPageControl1";
            this.sgTabPageControl1.SelectedIndex = 0;
            this.sgTabPageControl1.SGCS_BorderColor = System.Drawing.Color.White;
            this.sgTabPageControl1.SGCS_ItemTitleButtomBorderColor = System.Drawing.Color.White;
            this.sgTabPageControl1.SGCS_Light_BackColor = System.Drawing.Color.White;
            this.sgTabPageControl1.SGCS_Light_FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.sgTabPageControl1.SGCS_Light_SelectFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.sgTabPageControl1.SGCS_Light_SelectUnderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.sgTabPageControl1.SGCS_Light_UnderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.sgTabPageControl1.SGCS_SelectTitleBackColor = System.Drawing.Color.White;
            this.sgTabPageControl1.SGCS_SelectTitleTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgTabPageControl1.SGCS_ShowTip = true;
            this.sgTabPageControl1.SGCS_Style = "light";
            this.sgTabPageControl1.SGCS_TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
            this.sgTabPageControl1.SGCS_TitleTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgTabPageControl1.Size = new System.Drawing.Size(737, 362);
            this.sgTabPageControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.sgTabPageControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(729, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // sgRightMenus1
            // 
            this.sgRightMenus1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加到桌面ToolStripMenuItem,
            this.添加到任务栏ToolStripMenuItem,
            this.添加到开始菜单ToolStripMenuItem});
            this.sgRightMenus1.Name = "sgRightMenus1";
            this.sgRightMenus1.Size = new System.Drawing.Size(161, 70);
            // 
            // 添加到桌面ToolStripMenuItem
            // 
            this.添加到桌面ToolStripMenuItem.Name = "添加到桌面ToolStripMenuItem";
            this.添加到桌面ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.添加到桌面ToolStripMenuItem.Text = "添加到桌面";
            this.添加到桌面ToolStripMenuItem.Click += new System.EventHandler(this.添加到桌面ToolStripMenuItem_Click);
            // 
            // 添加到任务栏ToolStripMenuItem
            // 
            this.添加到任务栏ToolStripMenuItem.Name = "添加到任务栏ToolStripMenuItem";
            this.添加到任务栏ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.添加到任务栏ToolStripMenuItem.Text = "添加到任务栏";
            this.添加到任务栏ToolStripMenuItem.Click += new System.EventHandler(this.添加到任务栏ToolStripMenuItem_Click);
            // 
            // 添加到开始菜单ToolStripMenuItem
            // 
            this.添加到开始菜单ToolStripMenuItem.Name = "添加到开始菜单ToolStripMenuItem";
            this.添加到开始菜单ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.添加到开始菜单ToolStripMenuItem.Text = "添加到开始菜单";
            this.添加到开始菜单ToolStripMenuItem.Click += new System.EventHandler(this.添加到开始菜单ToolStripMenuItem_Click);
            // 
            // SGUserControl_SystemToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.sgTabPageControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SGUserControl_SystemToolBox";
            this.Size = new System.Drawing.Size(806, 363);
            this.sgTabPageControl1.ResumeLayout(false);
            this.sgRightMenus1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SGTabPageControl sgTabPageControl1;
        private 控件.SGRightMenus sgRightMenus1;
        private System.Windows.Forms.ToolStripMenuItem 添加到桌面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加到任务栏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加到开始菜单ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
    }
}
