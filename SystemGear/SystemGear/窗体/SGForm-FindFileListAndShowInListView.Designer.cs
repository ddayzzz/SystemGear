namespace SystemGear.窗体
{
    partial class SGForm_FindFileListAndShowInListView
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
            this.sgLabel1 = new SystemGear.SGLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MyNormalButton1 = new SystemGear.MyNormalButton();
            this.label_title = new System.Windows.Forms.Label();
            this.sgListView1 = new SystemGear.控件.SGListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MyNormalButton2 = new SystemGear.MyNormalButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MyNormalButton3 = new SystemGear.MyNormalButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sgLabel1
            // 
            this.sgLabel1.AutoSize = true;
            this.sgLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgLabel1.Location = new System.Drawing.Point(8, 44);
            this.sgLabel1.Name = "sgLabel1";
            this.sgLabel1.Setting_Role = "";
            this.sgLabel1.Size = new System.Drawing.Size(42, 21);
            this.sgLabel1.TabIndex = 96;
            this.sgLabel1.Text = "标题";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.MyNormalButton1);
            this.panel1.Controls.Add(this.label_title);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 35);
            this.panel1.TabIndex = 93;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SGForm_FindFileListAndShowInListView_MouseDown);
            // 
            // MyNormalButton1
            // 
            this.MyNormalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MyNormalButton1.FlatAppearance.BorderSize = 0;
            this.MyNormalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton1.ForeColor = System.Drawing.Color.White;
            this.MyNormalButton1.Image = global::SystemGear.Properties.Resources.close;
            this.MyNormalButton1.Location = new System.Drawing.Point(575, 0);
            this.MyNormalButton1.Name = "MyNormalButton1";
            this.MyNormalButton1.Settings_Role = "CLOSEBTN";
            this.MyNormalButton1.Settings_Tags = null;
            this.MyNormalButton1.Size = new System.Drawing.Size(35, 35);
            this.MyNormalButton1.TabIndex = 4;
            this.toolTip1.SetToolTip(this.MyNormalButton1, "关闭");
            this.MyNormalButton1.UseVisualStyleBackColor = false;
            this.MyNormalButton1.Click += new System.EventHandler(this.MyNormalButton1_Click);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.ForeColor = System.Drawing.Color.White;
            this.label_title.Location = new System.Drawing.Point(8, 8);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(38, 19);
            this.label_title.TabIndex = 3;
            this.label_title.Text = "Title";
            // 
            // sgListView1
            // 
            this.sgListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.sgListView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgListView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sgListView1.FullRowSelect = true;
            this.sgListView1.HideSelection = false;
            this.sgListView1.Location = new System.Drawing.Point(12, 76);
            this.sgListView1.MultiSelect = false;
            this.sgListView1.Name = "sgListView1";
            this.sgListView1.Size = new System.Drawing.Size(586, 155);
            this.sgListView1.SmallImageList = this.imageList1;
            this.sgListView1.TabIndex = 97;
            this.sgListView1.UseCompatibleStateImageBehavior = false;
            this.sgListView1.View = System.Windows.Forms.View.Details;
            this.sgListView1.SelectedIndexChanged += new System.EventHandler(this.sgListView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名称";
            this.columnHeader1.Width = 258;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "创建日期";
            this.columnHeader2.Width = 289;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
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
            this.MyNormalButton2.Location = new System.Drawing.Point(488, 239);
            this.MyNormalButton2.Name = "MyNormalButton2";
            this.MyNormalButton2.Settings_Tags = null;
            this.MyNormalButton2.Size = new System.Drawing.Size(110, 30);
            this.MyNormalButton2.TabIndex = 145;
            this.MyNormalButton2.Text = "确定";
            this.MyNormalButton2.UseVisualStyleBackColor = false;
            this.MyNormalButton2.Click += new System.EventHandler(this.MyNormalButton2_Click);
            // 
            // MyNormalButton3
            // 
            this.MyNormalButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.MyNormalButton3.FlatAppearance.BorderSize = 0;
            this.MyNormalButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.MyNormalButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MyNormalButton3.Location = new System.Drawing.Point(12, 239);
            this.MyNormalButton3.Name = "MyNormalButton3";
            this.MyNormalButton3.Settings_Tags = null;
            this.MyNormalButton3.Size = new System.Drawing.Size(110, 30);
            this.MyNormalButton3.TabIndex = 146;
            this.MyNormalButton3.Text = "删除";
            this.MyNormalButton3.UseVisualStyleBackColor = false;
            this.MyNormalButton3.Click += new System.EventHandler(this.MyNormalButton3_Click);
            // 
            // SGForm_FindFileListAndShowInListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 280);
            this.Controls.Add(this.MyNormalButton3);
            this.Controls.Add(this.MyNormalButton2);
            this.Controls.Add(this.sgListView1);
            this.Controls.Add(this.sgLabel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SGForm_FindFileListAndShowInListView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SGForm_FindListAndShowInListView";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SGForm_FindFileListAndShowInListView_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGLabel sgLabel1;
        private System.Windows.Forms.Panel panel1;
        private MyNormalButton MyNormalButton1;
        private System.Windows.Forms.Label label_title;
        private 控件.SGListView sgListView1;
        private System.Windows.Forms.ImageList imageList1;
        private MyNormalButton MyNormalButton2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolTip toolTip1;
        private MyNormalButton MyNormalButton3;
    }
}