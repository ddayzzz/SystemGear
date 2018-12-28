namespace SystemGear.功能控件
{
    partial class SGUserControl_HomePageChoose
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.sgCombobox_allpages = new SystemGear.控件.SGCombobox();
            this.myNormalButton1 = new SystemGear.MyNormalButton();
            this.MyNormalButton2 = new SystemGear.MyNormalButton();
            this.sgCombobox_defaulturls = new SystemGear.控件.SGCombobox();
            this.sgRadioButton3 = new SystemGear.SGRadioButton();
            this.sgTextBox_userurl = new SystemGear.SGTextBox();
            this.sgRadioButton2 = new SystemGear.SGRadioButton();
            this.sgRadioButton1 = new SystemGear.SGRadioButton();
            this.sgLabel1 = new SystemGear.SGLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.myNormalButton1);
            this.panel1.Controls.Add(this.MyNormalButton2);
            this.panel1.Location = new System.Drawing.Point(0, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 50);
            this.panel1.TabIndex = 169;
            this.panel1.Tag = "DRAW_LIGHTCOLOR";
            // 
            // sgCombobox_allpages
            // 
            this.sgCombobox_allpages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sgCombobox_allpages.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgCombobox_allpages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgCombobox_allpages.FormattingEnabled = true;
            this.sgCombobox_allpages.Items.AddRange(new object[] {
            "添加一个Windows XP启动菜单",
            "添加一个Windows Vista/7/8/8.1的启动菜单",
            "添加一个新的系统的启动菜单"});
            this.sgCombobox_allpages.Location = new System.Drawing.Point(133, 31);
            this.sgCombobox_allpages.Name = "sgCombobox_allpages";
            this.sgCombobox_allpages.Settings_ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
            this.sgCombobox_allpages.Settings_ItemImages = null;
            this.sgCombobox_allpages.Size = new System.Drawing.Size(345, 25);
            this.sgCombobox_allpages.TabIndex = 170;
            // 
            // myNormalButton1
            // 
            this.myNormalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton1.FlatAppearance.BorderSize = 0;
            this.myNormalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myNormalButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton1.ForeColor = System.Drawing.Color.White;
            this.myNormalButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.myNormalButton1.Location = new System.Drawing.Point(252, 10);
            this.myNormalButton1.Name = "myNormalButton1";
            this.myNormalButton1.Settings_Role = "OTHER1";
            this.myNormalButton1.Settings_Tags = null;
            this.myNormalButton1.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton1.TabIndex = 145;
            this.myNormalButton1.TabStop = false;
            this.myNormalButton1.Text = "跳过";
            this.myNormalButton1.UseVisualStyleBackColor = false;
            this.myNormalButton1.Click += new System.EventHandler(this.myNormalButton1_Click);
            // 
            // MyNormalButton2
            // 
            this.MyNormalButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MyNormalButton2.FlatAppearance.BorderSize = 0;
            this.MyNormalButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton2.ForeColor = System.Drawing.Color.White;
            this.MyNormalButton2.Image = global::SystemGear.Properties.Resources.OK;
            this.MyNormalButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MyNormalButton2.Location = new System.Drawing.Point(368, 10);
            this.MyNormalButton2.Name = "MyNormalButton2";
            this.MyNormalButton2.Settings_Tags = null;
            this.MyNormalButton2.Size = new System.Drawing.Size(110, 30);
            this.MyNormalButton2.TabIndex = 144;
            this.MyNormalButton2.TabStop = false;
            this.MyNormalButton2.Text = "确定";
            this.MyNormalButton2.UseVisualStyleBackColor = false;
            this.MyNormalButton2.Click += new System.EventHandler(this.MyNormalButton2_Click);
            // 
            // sgCombobox_defaulturls
            // 
            this.sgCombobox_defaulturls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sgCombobox_defaulturls.Enabled = false;
            this.sgCombobox_defaulturls.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgCombobox_defaulturls.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgCombobox_defaulturls.FormattingEnabled = true;
            this.sgCombobox_defaulturls.Items.AddRange(new object[] {
            "空白页",
            "InPrivate 浏览",
            "无加载项"});
            this.sgCombobox_defaulturls.Location = new System.Drawing.Point(133, 111);
            this.sgCombobox_defaulturls.Name = "sgCombobox_defaulturls";
            this.sgCombobox_defaulturls.Settings_ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
            this.sgCombobox_defaulturls.Settings_ItemImages = null;
            this.sgCombobox_defaulturls.Size = new System.Drawing.Size(345, 25);
            this.sgCombobox_defaulturls.TabIndex = 6;
            // 
            // sgRadioButton3
            // 
            this.sgRadioButton3.AutoSize = true;
            this.sgRadioButton3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgRadioButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgRadioButton3.Location = new System.Drawing.Point(5, 112);
            this.sgRadioButton3.Name = "sgRadioButton3";
            this.sgRadioButton3.Size = new System.Drawing.Size(110, 21);
            this.sgRadioButton3.TabIndex = 5;
            this.sgRadioButton3.Text = "使用其他页面：";
            this.sgRadioButton3.UseVisualStyleBackColor = true;
            this.sgRadioButton3.CheckedChanged += new System.EventHandler(this.sgRadioButton3_CheckedChanged);
            // 
            // sgTextBox_userurl
            // 
            this.sgTextBox_userurl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sgTextBox_userurl.Enabled = false;
            this.sgTextBox_userurl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgTextBox_userurl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgTextBox_userurl.Location = new System.Drawing.Point(133, 73);
            this.sgTextBox_userurl.Name = "sgTextBox_userurl";
            this.sgTextBox_userurl.Size = new System.Drawing.Size(345, 23);
            this.sgTextBox_userurl.TabIndex = 4;
            this.sgTextBox_userurl.Text = "http://www.";
            this.sgTextBox_userurl.TextBoxErrorMessageColor = System.Drawing.Color.Red;
            this.sgTextBox_userurl.TextBoxInfoBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgTextBox_userurl.TextBoxInfoTip = "输入一个网页地址";
            this.sgTextBox_userurl.TextBoxInfoTipColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.sgTextBox_userurl.TextBoxLoseFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            // 
            // sgRadioButton2
            // 
            this.sgRadioButton2.AutoSize = true;
            this.sgRadioButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgRadioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgRadioButton2.Location = new System.Drawing.Point(5, 73);
            this.sgRadioButton2.Name = "sgRadioButton2";
            this.sgRadioButton2.Size = new System.Drawing.Size(110, 21);
            this.sgRadioButton2.TabIndex = 2;
            this.sgRadioButton2.Text = "使用这个网页：";
            this.sgRadioButton2.UseVisualStyleBackColor = true;
            this.sgRadioButton2.CheckedChanged += new System.EventHandler(this.sgRadioButton2_CheckedChanged);
            // 
            // sgRadioButton1
            // 
            this.sgRadioButton1.AutoSize = true;
            this.sgRadioButton1.Checked = true;
            this.sgRadioButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgRadioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgRadioButton1.Location = new System.Drawing.Point(5, 32);
            this.sgRadioButton1.Name = "sgRadioButton1";
            this.sgRadioButton1.Size = new System.Drawing.Size(122, 21);
            this.sgRadioButton1.TabIndex = 1;
            this.sgRadioButton1.TabStop = true;
            this.sgRadioButton1.Text = "使用当前的主页：";
            this.sgRadioButton1.UseVisualStyleBackColor = true;
            this.sgRadioButton1.CheckedChanged += new System.EventHandler(this.sgRadioButton1_CheckedChanged);
            // 
            // sgLabel1
            // 
            this.sgLabel1.AutoSize = true;
            this.sgLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgLabel1.Location = new System.Drawing.Point(2, 2);
            this.sgLabel1.Name = "sgLabel1";
            this.sgLabel1.Setting_Role = "FUN";
            this.sgLabel1.Size = new System.Drawing.Size(103, 17);
            this.sgLabel1.TabIndex = 0;
            this.sgLabel1.Text = "如何打开IE图标？";
            // 
            // SGUserControl_HomePageChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.sgCombobox_allpages);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sgCombobox_defaulturls);
            this.Controls.Add(this.sgRadioButton3);
            this.Controls.Add(this.sgTextBox_userurl);
            this.Controls.Add(this.sgRadioButton2);
            this.Controls.Add(this.sgRadioButton1);
            this.Controls.Add(this.sgLabel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SGUserControl_HomePageChoose";
            this.Size = new System.Drawing.Size(501, 212);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGLabel sgLabel1;
        private SGRadioButton sgRadioButton1;
        private SGRadioButton sgRadioButton2;
        private SGTextBox sgTextBox_userurl;
        private SGRadioButton sgRadioButton3;
        private 控件.SGCombobox sgCombobox_defaulturls;
        private System.Windows.Forms.Panel panel1;
        private MyNormalButton MyNormalButton2;
        private 控件.SGCombobox sgCombobox_allpages;
        private MyNormalButton myNormalButton1;
    }
}
