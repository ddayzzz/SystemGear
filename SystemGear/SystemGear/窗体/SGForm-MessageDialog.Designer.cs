namespace SystemGear
{
    partial class Form_MessageDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.sgRightMenus1 = new SystemGear.控件.SGRightMenus();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MyNormalButton3 = new SystemGear.MyNormalButton();
            this.MyNormalButton2 = new SystemGear.MyNormalButton();
            this.MyNormalButton1 = new SystemGear.MyNormalButton();
            this.panel2.SuspendLayout();
            this.sgRightMenus1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(156)))), ((int)(((byte)(0)))));
            this.checkBox1.Location = new System.Drawing.Point(123, 140);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(500, 49);
            this.label3.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(2, 183);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 64);
            this.panel2.TabIndex = 11;
            this.panel2.Visible = false;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // label2
            // 
            this.label2.ContextMenuStrip = this.sgRightMenus1;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 58);
            this.label2.TabIndex = 9;
            this.label2.Text = "传递的消息";
            this.toolTip1.SetToolTip(this.label2, "单击右键可以复制消息到剪切板");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseClick);
            // 
            // sgRightMenus1
            // 
            this.sgRightMenus1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.sgRightMenus1.Name = "sgRightMenus1";
            this.sgRightMenus1.Size = new System.Drawing.Size(149, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "复制到剪切板";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ContextMenuStrip = this.sgRightMenus1;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "消息的标题";
            this.toolTip1.SetToolTip(this.label1, "单击右键可以复制消息到剪切板");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(156)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 35);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // MyNormalButton3
            // 
            this.MyNormalButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(156)))), ((int)(((byte)(0)))));
            this.MyNormalButton3.FlatAppearance.BorderSize = 0;
            this.MyNormalButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton3.ForeColor = System.Drawing.Color.White;
            this.MyNormalButton3.Location = new System.Drawing.Point(284, 134);
            this.MyNormalButton3.Name = "MyNormalButton3";
            this.MyNormalButton3.Settings_Tags = null;
            this.MyNormalButton3.Size = new System.Drawing.Size(110, 31);
            this.MyNormalButton3.TabIndex = 6;
            this.MyNormalButton3.TabStop = false;
            this.MyNormalButton3.Text = "b1";
            this.MyNormalButton3.UseVisualStyleBackColor = false;
            this.MyNormalButton3.Click += new System.EventHandler(this.MyNormalButton3_Click);
            // 
            // MyNormalButton2
            // 
            this.MyNormalButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.MyNormalButton2.FlatAppearance.BorderSize = 0;
            this.MyNormalButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.MyNormalButton2.Location = new System.Drawing.Point(400, 134);
            this.MyNormalButton2.Name = "MyNormalButton2";
            this.MyNormalButton2.Settings_Tags = null;
            this.MyNormalButton2.Size = new System.Drawing.Size(110, 31);
            this.MyNormalButton2.TabIndex = 5;
            this.MyNormalButton2.TabStop = false;
            this.MyNormalButton2.Text = "b2";
            this.MyNormalButton2.UseVisualStyleBackColor = false;
            this.MyNormalButton2.Click += new System.EventHandler(this.MyNormalButton2_Click);
            // 
            // MyNormalButton1
            // 
            this.MyNormalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.MyNormalButton1.FlatAppearance.BorderSize = 0;
            this.MyNormalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.MyNormalButton1.Location = new System.Drawing.Point(7, 134);
            this.MyNormalButton1.Name = "MyNormalButton1";
            this.MyNormalButton1.Settings_Tags = null;
            this.MyNormalButton1.Size = new System.Drawing.Size(110, 31);
            this.MyNormalButton1.TabIndex = 4;
            this.MyNormalButton1.TabStop = false;
            this.MyNormalButton1.Text = "显示详细信息";
            this.MyNormalButton1.UseVisualStyleBackColor = false;
            this.MyNormalButton1.Click += new System.EventHandler(this.MyNormalButton1_Click);
            // 
            // Form_MessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 211);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MyNormalButton3);
            this.Controls.Add(this.MyNormalButton2);
            this.Controls.Add(this.MyNormalButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_MessageDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_BackDialog";
            this.Load += new System.EventHandler(this.Form_MessageDialog_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_MessageDialog_Paint);
            this.panel2.ResumeLayout(false);
            this.sgRightMenus1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label2;
        public MyNormalButton MyNormalButton1;
        public MyNormalButton MyNormalButton2;
        public MyNormalButton MyNormalButton3;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private 控件.SGRightMenus sgRightMenus1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBox1;



    }
}