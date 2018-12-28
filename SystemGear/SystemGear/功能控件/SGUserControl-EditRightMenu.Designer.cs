namespace SystemGear.功能控件
{
    partial class SGUserControl_EditRightMenu
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
            this.sgLabel3 = new SystemGear.SGLabel();
            this.sgLabel4 = new SystemGear.SGLabel();
            this.sgLabel2 = new SystemGear.SGLabel();
            this.sgCheckBox1 = new SystemGear.SGCheckBox();
            this.MyNormalButton5 = new SystemGear.MyNormalButton();
            this.MyNormalButton4 = new SystemGear.MyNormalButton();
            this.sgTextBox3 = new SystemGear.SGTextBox();
            this.sgTextBox2 = new SystemGear.SGTextBox();
            this.sgTextBox1 = new SystemGear.SGTextBox();
            this.MyNormalButton3 = new SystemGear.MyNormalButton();
            this.MyNormalButton1 = new SystemGear.MyNormalButton();
            this.MyNormalButton2 = new SystemGear.MyNormalButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.MyNormalButton1);
            this.panel1.Controls.Add(this.MyNormalButton2);
            this.panel1.Location = new System.Drawing.Point(-1, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 50);
            this.panel1.TabIndex = 157;
            this.panel1.Tag = "DRAW_LIGHTCOLOR";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // sgLabel3
            // 
            this.sgLabel3.AutoSize = true;
            this.sgLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(43)))));
            this.sgLabel3.Location = new System.Drawing.Point(7, 105);
            this.sgLabel3.Name = "sgLabel3";
            this.sgLabel3.Setting_Role = "main";
            this.sgLabel3.Size = new System.Drawing.Size(140, 17);
            this.sgLabel3.TabIndex = 206;
            this.sgLabel3.Text = "菜单的图标（可不填）：";
            // 
            // sgLabel4
            // 
            this.sgLabel4.AutoSize = true;
            this.sgLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(43)))));
            this.sgLabel4.Location = new System.Drawing.Point(7, 60);
            this.sgLabel4.Name = "sgLabel4";
            this.sgLabel4.Setting_Role = "main";
            this.sgLabel4.Size = new System.Drawing.Size(80, 17);
            this.sgLabel4.TabIndex = 205;
            this.sgLabel4.Text = "执行的命令：";
            // 
            // sgLabel2
            // 
            this.sgLabel2.AutoSize = true;
            this.sgLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(43)))));
            this.sgLabel2.Location = new System.Drawing.Point(7, 15);
            this.sgLabel2.Name = "sgLabel2";
            this.sgLabel2.Setting_Role = "main";
            this.sgLabel2.Size = new System.Drawing.Size(80, 17);
            this.sgLabel2.TabIndex = 204;
            this.sgLabel2.Text = "菜单的名称：";
            // 
            // sgCheckBox1
            // 
            this.sgCheckBox1.AutoSize = true;
            this.sgCheckBox1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgCheckBox1.CheckBox_CheckedChangeToEvent = true;
            this.sgCheckBox1.CheckBoxBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgCheckBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgCheckBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgCheckBox1.Location = new System.Drawing.Point(10, 146);
            this.sgCheckBox1.Name = "sgCheckBox1";
            this.sgCheckBox1.Size = new System.Drawing.Size(147, 21);
            this.sgCheckBox1.TabIndex = 164;
            this.sgCheckBox1.Text = "以管理员身份执行命令";
            this.sgCheckBox1.UseVisualStyleBackColor = true;
            // 
            // MyNormalButton5
            // 
            this.MyNormalButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MyNormalButton5.FlatAppearance.BorderSize = 0;
            this.MyNormalButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton5.ForeColor = System.Drawing.Color.White;
            this.MyNormalButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MyNormalButton5.Location = new System.Drawing.Point(445, 53);
            this.MyNormalButton5.Name = "MyNormalButton5";
            this.MyNormalButton5.Settings_Tags = null;
            this.MyNormalButton5.Size = new System.Drawing.Size(30, 30);
            this.MyNormalButton5.TabIndex = 163;
            this.MyNormalButton5.TabStop = false;
            this.MyNormalButton5.Text = "...";
            this.MyNormalButton5.UseVisualStyleBackColor = false;
            this.MyNormalButton5.Click += new System.EventHandler(this.MyNormalButton5_Click);
            // 
            // MyNormalButton4
            // 
            this.MyNormalButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MyNormalButton4.FlatAppearance.BorderSize = 0;
            this.MyNormalButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton4.ForeColor = System.Drawing.Color.White;
            this.MyNormalButton4.Location = new System.Drawing.Point(481, 53);
            this.MyNormalButton4.Name = "MyNormalButton4";
            this.MyNormalButton4.Settings_Tags = null;
            this.MyNormalButton4.Size = new System.Drawing.Size(110, 30);
            this.MyNormalButton4.TabIndex = 162;
            this.MyNormalButton4.TabStop = false;
            this.MyNormalButton4.Text = "常用操作";
            this.MyNormalButton4.UseVisualStyleBackColor = false;
            this.MyNormalButton4.Click += new System.EventHandler(this.MyNormalButton4_Click);
            // 
            // sgTextBox3
            // 
            this.sgTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sgTextBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgTextBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgTextBox3.Location = new System.Drawing.Point(149, 103);
            this.sgTextBox3.Name = "sgTextBox3";
            this.sgTextBox3.Size = new System.Drawing.Size(326, 23);
            this.sgTextBox3.TabIndex = 161;
            this.sgTextBox3.Text = "%windir%\\system32\\imageres.dll,11";
            this.sgTextBox3.TextBoxErrorMessageColor = System.Drawing.Color.Red;
            this.sgTextBox3.TextBoxInfoBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgTextBox3.TextBoxInfoTip = "图标";
            this.sgTextBox3.TextBoxInfoTipColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.sgTextBox3.TextBoxLoseFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            // 
            // sgTextBox2
            // 
            this.sgTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sgTextBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgTextBox2.Location = new System.Drawing.Point(93, 58);
            this.sgTextBox2.Name = "sgTextBox2";
            this.sgTextBox2.Size = new System.Drawing.Size(346, 23);
            this.sgTextBox2.TabIndex = 160;
            this.sgTextBox2.TextBoxErrorMessageColor = System.Drawing.Color.Red;
            this.sgTextBox2.TextBoxInfoBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgTextBox2.TextBoxInfoTip = "执行的命令";
            this.sgTextBox2.TextBoxInfoTipColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.sgTextBox2.TextBoxLoseFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            // 
            // sgTextBox1
            // 
            this.sgTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sgTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgTextBox1.Location = new System.Drawing.Point(93, 13);
            this.sgTextBox1.Name = "sgTextBox1";
            this.sgTextBox1.Size = new System.Drawing.Size(475, 23);
            this.sgTextBox1.TabIndex = 159;
            this.sgTextBox1.Text = "我的菜单";
            this.sgTextBox1.TextBoxErrorMessageColor = System.Drawing.Color.Red;
            this.sgTextBox1.TextBoxInfoBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgTextBox1.TextBoxInfoTip = "您想新建的菜单名称";
            this.sgTextBox1.TextBoxInfoTipColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.sgTextBox1.TextBoxLoseFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            // 
            // MyNormalButton3
            // 
            this.MyNormalButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MyNormalButton3.FlatAppearance.BorderSize = 0;
            this.MyNormalButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton3.ForeColor = System.Drawing.Color.White;
            this.MyNormalButton3.Location = new System.Drawing.Point(481, 98);
            this.MyNormalButton3.Name = "MyNormalButton3";
            this.MyNormalButton3.Settings_Tags = null;
            this.MyNormalButton3.Size = new System.Drawing.Size(110, 30);
            this.MyNormalButton3.TabIndex = 158;
            this.MyNormalButton3.TabStop = false;
            this.MyNormalButton3.Text = "选择图标";
            this.MyNormalButton3.UseVisualStyleBackColor = false;
            this.MyNormalButton3.Click += new System.EventHandler(this.MyNormalButton3_Click);
            // 
            // MyNormalButton1
            // 
            this.MyNormalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.MyNormalButton1.FlatAppearance.BorderSize = 0;
            this.MyNormalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.MyNormalButton1.Location = new System.Drawing.Point(277, 10);
            this.MyNormalButton1.Name = "MyNormalButton1";
            this.MyNormalButton1.Settings_Role = "OTHER1";
            this.MyNormalButton1.Settings_Tags = null;
            this.MyNormalButton1.Size = new System.Drawing.Size(199, 30);
            this.MyNormalButton1.TabIndex = 145;
            this.MyNormalButton1.TabStop = false;
            this.MyNormalButton1.Text = "把这个菜单转换为分隔符";
            this.MyNormalButton1.UseVisualStyleBackColor = false;
            this.MyNormalButton1.Click += new System.EventHandler(this.MyNormalButton1_Click);
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
            this.MyNormalButton2.Location = new System.Drawing.Point(482, 10);
            this.MyNormalButton2.Name = "MyNormalButton2";
            this.MyNormalButton2.Settings_Tags = null;
            this.MyNormalButton2.Size = new System.Drawing.Size(110, 30);
            this.MyNormalButton2.TabIndex = 144;
            this.MyNormalButton2.TabStop = false;
            this.MyNormalButton2.Text = "确定";
            this.MyNormalButton2.UseVisualStyleBackColor = false;
            this.MyNormalButton2.Click += new System.EventHandler(this.MyNormalButton2_Click);
            // 
            // SGUserControl_EditRightMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.sgLabel3);
            this.Controls.Add(this.sgLabel4);
            this.Controls.Add(this.sgLabel2);
            this.Controls.Add(this.sgCheckBox1);
            this.Controls.Add(this.MyNormalButton5);
            this.Controls.Add(this.MyNormalButton4);
            this.Controls.Add(this.sgTextBox3);
            this.Controls.Add(this.sgTextBox2);
            this.Controls.Add(this.sgTextBox1);
            this.Controls.Add(this.MyNormalButton3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SGUserControl_EditRightMenu";
            this.Size = new System.Drawing.Size(599, 222);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGTextBox sgTextBox3;
        private SGTextBox sgTextBox2;
        private SGTextBox sgTextBox1;
        private MyNormalButton MyNormalButton3;
        private System.Windows.Forms.Panel panel1;
        private MyNormalButton MyNormalButton2;
        private MyNormalButton MyNormalButton4;
        private MyNormalButton MyNormalButton5;
        private SGCheckBox sgCheckBox1;
        private MyNormalButton MyNormalButton1;
        private SGLabel sgLabel3;
        private SGLabel sgLabel4;
        private SGLabel sgLabel2;
    }
}
