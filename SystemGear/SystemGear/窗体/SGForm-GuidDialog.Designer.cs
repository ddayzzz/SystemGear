namespace SystemGear.窗体
{
    partial class SGForm_GuidDialog
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
            this.MyNormalButton1 = new SystemGear.MyNormalButton();
            this.label_title = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(462, 35);
            this.panel1.TabIndex = 88;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SGForm_GuidDialog_MouseDown);
            // 
            // MyNormalButton1
            // 
            this.MyNormalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MyNormalButton1.FlatAppearance.BorderSize = 0;
            this.MyNormalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton1.ForeColor = System.Drawing.Color.White;
            this.MyNormalButton1.Image = global::SystemGear.Properties.Resources.close;
            this.MyNormalButton1.Location = new System.Drawing.Point(427, 0);
            this.MyNormalButton1.Name = "MyNormalButton1";
            this.MyNormalButton1.Settings_Role = "CLOSEBTN";
            this.MyNormalButton1.Settings_Tags = null;
            this.MyNormalButton1.Size = new System.Drawing.Size(35, 35);
            this.MyNormalButton1.TabIndex = 5;
            this.MyNormalButton1.TabStop = false;
            this.toolTip1.SetToolTip(this.MyNormalButton1, "关闭");
            this.MyNormalButton1.UseVisualStyleBackColor = false;
            this.MyNormalButton1.Click += new System.EventHandler(this.MyNormalButton1_Click);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.BackColor = System.Drawing.Color.Transparent;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.ForeColor = System.Drawing.Color.White;
            this.label_title.Location = new System.Drawing.Point(8, 8);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(38, 19);
            this.label_title.TabIndex = 3;
            this.label_title.Text = "Title";
            // 
            // SGForm_GuidDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 153);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SGForm_GuidDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SGForm_GuidDialog";
            this.SizeChanged += new System.EventHandler(this.SGForm_GuidDialog_SizeChanged);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.SGForm_GuidDialog_ControlAdded);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.SGForm_GuidDialog_ControlRemoved);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SGForm_GuidDialog_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_title;
        private MyNormalButton MyNormalButton1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}