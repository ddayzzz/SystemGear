namespace SystemGear
{
    partial class Form_MessageDialog_2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myNormalButton3 = new SystemGear.MyNormalButton();
            this.myTextBox1 = new SystemGear.MyTextBox();
            this.myNormalButton2 = new SystemGear.MyNormalButton();
            this.myNormalButton1 = new SystemGear.MyNormalButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MessageDialog_2_MouseDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(84, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(595, 55);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MessageDialog_2_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MessageDialog_2_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 34);
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MessageDialog_2_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(1, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(697, 16);
            this.panel2.TabIndex = 13;
            this.panel2.Visible = false;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MessageDialog_2_MouseDown);
            // 
            // myNormalButton3
            // 
            this.myNormalButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.myNormalButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton3.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.myNormalButton3.ButtonBackImage = null;
            this.myNormalButton3.ButtonForceColor = System.Drawing.Color.Black;
            this.myNormalButton3.ButtonTags = null;
            this.myNormalButton3.ButtonText = "显示详细信息";
            this.myNormalButton3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton3.Location = new System.Drawing.Point(16, 123);
            this.myNormalButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton3.Name = "myNormalButton3";
            this.myNormalButton3.Size = new System.Drawing.Size(129, 30);
            this.myNormalButton3.TabIndex = 12;
            this.myNormalButton3.OnButtonClick += new System.EventHandler(this.myNormalButton3_OnButtonClick);
            this.myNormalButton3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MessageDialog_2_MouseDown);
            // 
            // myTextBox1
            // 
            this.myTextBox1.AllowDrop = true;
            this.myTextBox1.BackColor = System.Drawing.Color.White;
            this.myTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myTextBox1.ForeColor = System.Drawing.Color.Black;
            this.myTextBox1.Location = new System.Drawing.Point(15, 177);
            this.myTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.Size = new System.Drawing.Size(664, 134);
            this.myTextBox1.TabIndex = 11;
            this.myTextBox1.TextBoxMultLine = true;
            this.myTextBox1.TextBoxPasswordChar = '\0';
            this.myTextBox1.TextBoxReadOnly = true;
            this.myTextBox1.TextBoxTags = null;
            this.myTextBox1.TextBoxText = "";
            this.myTextBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MessageDialog_2_MouseDown);
            // 
            // myNormalButton2
            // 
            this.myNormalButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.myNormalButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton2.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.myNormalButton2.ButtonBackImage = null;
            this.myNormalButton2.ButtonForceColor = System.Drawing.Color.Black;
            this.myNormalButton2.ButtonTags = null;
            this.myNormalButton2.ButtonText = "b2";
            this.myNormalButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton2.Location = new System.Drawing.Point(569, 123);
            this.myNormalButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton2.Name = "myNormalButton2";
            this.myNormalButton2.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton2.TabIndex = 10;
            this.myNormalButton2.OnButtonClick += new System.EventHandler(this.button2_Click);
            // 
            // myNormalButton1
            // 
            this.myNormalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton1.ButtonBackImage = null;
            this.myNormalButton1.ButtonTags = null;
            this.myNormalButton1.ButtonText = "b1";
            this.myNormalButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton1.Location = new System.Drawing.Point(441, 123);
            this.myNormalButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton1.Name = "myNormalButton1";
            this.myNormalButton1.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton1.TabIndex = 9;
            this.myNormalButton1.OnButtonClick += new System.EventHandler(this.button1_Click);
            // 
            // Form_MessageDialog_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(699, 173);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.myNormalButton3);
            this.Controls.Add(this.myTextBox1);
            this.Controls.Add(this.myNormalButton2);
            this.Controls.Add(this.myNormalButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_MessageDialog_2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_MessageDialog_2";
            this.Load += new System.EventHandler(this.Form_MessageDialog_2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_MessageDialog_2_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MessageDialog_2_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private MyTextBox myTextBox1;
        public MyNormalButton myNormalButton1;
        public MyNormalButton myNormalButton2;
        public MyNormalButton myNormalButton3;
        private System.Windows.Forms.Panel panel2;

    }
}