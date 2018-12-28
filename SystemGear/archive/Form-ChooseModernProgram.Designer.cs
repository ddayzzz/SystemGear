namespace SystemGear
{
    partial class Form_ChooseModernProgram
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.myNormalButton1 = new SystemGear.MyNormalButton();
            this.myNormalButton4 = new SystemGear.MyNormalButton();
            this.myNormalButton2 = new SystemGear.MyNormalButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 60);
            this.panel1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "<Text>";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2});
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(12, 67);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(578, 189);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 21;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "图标和名称";
            this.columnHeader1.Width = 171;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "AppId";
            this.columnHeader4.Width = 202;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "支持的操作系统";
            this.columnHeader2.Width = 194;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // myNormalButton1
            // 
            this.myNormalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton1.ButtonBackImage = null;
            this.myNormalButton1.ButtonForceColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myNormalButton1.ButtonTags = null;
            this.myNormalButton1.ButtonText = "运行";
            this.myNormalButton1.ButtonUsingSGDefaultStyle = true;
            this.myNormalButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton1.Location = new System.Drawing.Point(12, 263);
            this.myNormalButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton1.Name = "myNormalButton1";
            this.myNormalButton1.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton1.TabIndex = 86;
            this.myNormalButton1.OnButtonClick += new System.EventHandler(this.myNormalButton1_OnButtonClick);
            // 
            // myNormalButton4
            // 
            this.myNormalButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton4.ButtonBackImage = null;
            this.myNormalButton4.ButtonForceColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myNormalButton4.ButtonTags = null;
            this.myNormalButton4.ButtonText = "确定";
            this.myNormalButton4.ButtonUsingSGDefaultStyle = true;
            this.myNormalButton4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton4.Location = new System.Drawing.Point(480, 263);
            this.myNormalButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton4.Name = "myNormalButton4";
            this.myNormalButton4.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton4.TabIndex = 85;
            this.myNormalButton4.OnButtonClick += new System.EventHandler(this.myNormalButton4_OnButtonClick);
            // 
            // myNormalButton2
            // 
            this.myNormalButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton2.ButtonBackImage = null;
            this.myNormalButton2.ButtonForceColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myNormalButton2.ButtonTags = null;
            this.myNormalButton2.ButtonText = "取消";
            this.myNormalButton2.ButtonUsingSGDefaultStyle = true;
            this.myNormalButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton2.Location = new System.Drawing.Point(350, 263);
            this.myNormalButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton2.Name = "myNormalButton2";
            this.myNormalButton2.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton2.TabIndex = 87;
            this.myNormalButton2.OnButtonClick += new System.EventHandler(this.myNormalButton2_OnButtonClick);
            // 
            // Form_ChooseModernProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(608, 304);
            this.Controls.Add(this.myNormalButton2);
            this.Controls.Add(this.myNormalButton1);
            this.Controls.Add(this.myNormalButton4);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ChooseModernProgram";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_ChooseModernProgram";
            this.Load += new System.EventHandler(this.Form_ChooseModernProgram_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ImageList imageList1;
        private MyNormalButton myNormalButton4;
        private MyNormalButton myNormalButton1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private MyNormalButton myNormalButton2;
    }
}