namespace SystemGear.窗体
{
    partial class SGForm_WIN10STYLE
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
            this.myNormalButton1 = new SystemGear.MyNormalButton();
            this.SuspendLayout();
            // 
            // myNormalButton1
            // 
            this.myNormalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(43)))));
            this.myNormalButton1.FlatAppearance.BorderSize = 0;
            this.myNormalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myNormalButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton1.ForeColor = System.Drawing.Color.White;
            this.myNormalButton1.Location = new System.Drawing.Point(822, 450);
            this.myNormalButton1.Name = "myNormalButton1";
            this.myNormalButton1.Settings_Tags = null;
            this.myNormalButton1.Size = new System.Drawing.Size(78, 36);
            this.myNormalButton1.TabIndex = 110;
            this.myNormalButton1.TabStop = false;
            this.myNormalButton1.Text = "ADD TILE";
            this.myNormalButton1.UseVisualStyleBackColor = false;
            this.myNormalButton1.Click += new System.EventHandler(this.myNormalButton1_Click);
            // 
            // SGForm_WIN10STYLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 498);
            this.Controls.Add(this.myNormalButton1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SGForm_WIN10STYLE";
            this.Text = "SGForm_WIN10STYLE";
            this.ResumeLayout(false);

        }

        #endregion

        private MyNormalButton myNormalButton1;
    }
}