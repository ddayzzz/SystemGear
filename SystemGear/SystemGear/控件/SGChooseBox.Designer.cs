namespace SystemGear
{
    partial class SGChooseBox
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
            this.MyNormalButton2 = new SystemGear.MyNormalButton();
            this.MyNormalButton1 = new SystemGear.MyNormalButton();
            this.SuspendLayout();
            // 
            // MyNormalButton2
            // 
            this.MyNormalButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MyNormalButton2.FlatAppearance.BorderSize = 0;
            this.MyNormalButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton2.ForeColor = System.Drawing.Color.White;
            this.MyNormalButton2.Location = new System.Drawing.Point(100, 0);
            this.MyNormalButton2.Name = "MyNormalButton2";
            this.MyNormalButton2.Settings_Tags = null;
            this.MyNormalButton2.Size = new System.Drawing.Size(50, 25);
            this.MyNormalButton2.TabIndex = 0;
            this.MyNormalButton2.Text = "2";
            this.MyNormalButton2.UseVisualStyleBackColor = false;
            this.MyNormalButton2.Click += new System.EventHandler(this.MyNormalButton1_MouseClick);
            // 
            // MyNormalButton1
            // 
            this.MyNormalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MyNormalButton1.FlatAppearance.BorderSize = 0;
            this.MyNormalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNormalButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyNormalButton1.ForeColor = System.Drawing.Color.White;
            this.MyNormalButton1.Location = new System.Drawing.Point(0, 0);
            this.MyNormalButton1.Name = "MyNormalButton1";
            this.MyNormalButton1.Settings_Tags = null;
            this.MyNormalButton1.Size = new System.Drawing.Size(50, 25);
            this.MyNormalButton1.TabIndex = 2;
            this.MyNormalButton1.Text = "1";
            this.MyNormalButton1.UseVisualStyleBackColor = false;
            this.MyNormalButton1.Click += new System.EventHandler(this.MyNormalButton1_MouseClick);
            // 
            // SGChooseBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MyNormalButton1);
            this.Controls.Add(this.MyNormalButton2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SGChooseBox";
            this.Size = new System.Drawing.Size(150, 25);
            this.FontChanged += new System.EventHandler(this.SGChooseBox_FontChanged);
            this.SizeChanged += new System.EventHandler(this.MyChooseBox_SizeChanged);
            this.Click += new System.EventHandler(this.MyNormalButton1_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private MyNormalButton MyNormalButton2;
        private MyNormalButton MyNormalButton1;

    }
}
