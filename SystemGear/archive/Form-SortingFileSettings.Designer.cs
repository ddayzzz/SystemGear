namespace SystemGear
{
    partial class Form_SortingFileSettings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.myNormalButton2 = new SystemGear.MyNormalButton();
            this.myNormalButton1 = new SystemGear.MyNormalButton();
            this.myNormalButton3 = new SystemGear.MyNormalButton();
            this.myTextBox2 = new SystemGear.MyTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.myNormalButton5 = new SystemGear.MyNormalButton();
            this.myNormalButton4 = new SystemGear.MyNormalButton();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.myNormalButton8 = new SystemGear.MyNormalButton();
            this.myNormalButton7 = new SystemGear.MyNormalButton();
            this.myNormalButton6 = new SystemGear.MyNormalButton();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 60);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "设置文件分拣的条件";
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label158.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label158.Location = new System.Drawing.Point(23, 11);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(99, 19);
            this.label158.TabIndex = 61;
            this.label158.Text = "可使用的条件";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "按照文件名分拣",
            "按照文件类型分拣",
            "按照文件的大小分拣"});
            this.comboBox1.Location = new System.Drawing.Point(26, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(559, 25);
            this.comboBox1.TabIndex = 62;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(23, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 19);
            this.label4.TabIndex = 69;
            this.label4.Text = "指定的文件名";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(26, 105);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(430, 193);
            this.listView1.TabIndex = 76;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "关系";
            this.columnHeader1.Width = 172;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "操作";
            this.columnHeader2.Width = 299;
            // 
            // myNormalButton2
            // 
            this.myNormalButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton2.ButtonBackImage = null;
            this.myNormalButton2.ButtonForceColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myNormalButton2.ButtonTags = null;
            this.myNormalButton2.ButtonText = "确定";
            this.myNormalButton2.ButtonUsingSGDefaultStyle = true;
            this.myNormalButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton2.Location = new System.Drawing.Point(473, 268);
            this.myNormalButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton2.Name = "myNormalButton2";
            this.myNormalButton2.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton2.TabIndex = 79;
            this.myNormalButton2.OnButtonClick += new System.EventHandler(this.myNormalButton2_OnButtonClick);
            // 
            // myNormalButton1
            // 
            this.myNormalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton1.ButtonBackImage = null;
            this.myNormalButton1.ButtonForceColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myNormalButton1.ButtonTags = null;
            this.myNormalButton1.ButtonText = "编辑介于大小";
            this.myNormalButton1.ButtonUsingSGDefaultStyle = true;
            this.myNormalButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton1.Location = new System.Drawing.Point(473, 143);
            this.myNormalButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton1.Name = "myNormalButton1";
            this.myNormalButton1.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton1.TabIndex = 78;
            this.myNormalButton1.Visible = false;
            this.myNormalButton1.OnButtonClick += new System.EventHandler(this.myNormalButton1_OnButtonClick);
            // 
            // myNormalButton3
            // 
            this.myNormalButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton3.ButtonBackImage = null;
            this.myNormalButton3.ButtonForceColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myNormalButton3.ButtonTags = null;
            this.myNormalButton3.ButtonText = "编辑操作";
            this.myNormalButton3.ButtonUsingSGDefaultStyle = true;
            this.myNormalButton3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton3.Location = new System.Drawing.Point(473, 105);
            this.myNormalButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton3.Name = "myNormalButton3";
            this.myNormalButton3.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton3.TabIndex = 77;
            this.myNormalButton3.OnButtonClick += new System.EventHandler(this.myNormalButton3_OnButtonClick);
            // 
            // myTextBox2
            // 
            this.myTextBox2.AllowDrop = true;
            this.myTextBox2.BackColor = System.Drawing.Color.White;
            this.myTextBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myTextBox2.ForeColor = System.Drawing.Color.Black;
            this.myTextBox2.Location = new System.Drawing.Point(148, 72);
            this.myTextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myTextBox2.Name = "myTextBox2";
            this.myTextBox2.Size = new System.Drawing.Size(437, 26);
            this.myTextBox2.TabIndex = 70;
            this.myTextBox2.TextBoxInfoTip = "请指定文件名";
            this.myTextBox2.TextBoxPasswordChar = '\0';
            this.myTextBox2.TextBoxTags = null;
            this.myTextBox2.TextBoxText = "";
            this.myTextBox2.OnTextChange += new SystemGear.MyTextBox.MYEventHandler(this.myTextBox2_OnTextChange);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-18, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 381);
            this.tabControl1.TabIndex = 80;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.myNormalButton2);
            this.tabPage1.Controls.Add(this.label158);
            this.tabPage1.Controls.Add(this.myNormalButton1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.myNormalButton3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.myTextBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(672, 351);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            //this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "MB-兆字节",
            "KB-千字节",
            "B-字节"});
            this.comboBox2.Location = new System.Drawing.Point(488, 72);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(97, 25);
            this.comboBox2.TabIndex = 80;
            this.comboBox2.Visible = false;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.myNormalButton5);
            this.tabPage2.Controls.Add(this.myNormalButton4);
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(672, 351);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // myNormalButton5
            // 
            this.myNormalButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton5.ButtonBackImage = null;
            this.myNormalButton5.ButtonForceColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myNormalButton5.ButtonTags = null;
            this.myNormalButton5.ButtonText = "确定";
            this.myNormalButton5.ButtonUsingSGDefaultStyle = true;
            this.myNormalButton5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton5.Location = new System.Drawing.Point(377, 265);
            this.myNormalButton5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton5.Name = "myNormalButton5";
            this.myNormalButton5.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton5.TabIndex = 81;
            this.myNormalButton5.OnButtonClick += new System.EventHandler(this.myNormalButton5_OnButtonClick);
            // 
            // myNormalButton4
            // 
            this.myNormalButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton4.ButtonBackImage = null;
            this.myNormalButton4.ButtonForceColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myNormalButton4.ButtonTags = null;
            this.myNormalButton4.ButtonText = "立即分拣";
            this.myNormalButton4.ButtonUsingSGDefaultStyle = true;
            this.myNormalButton4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton4.Location = new System.Drawing.Point(505, 265);
            this.myNormalButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton4.Name = "myNormalButton4";
            this.myNormalButton4.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton4.TabIndex = 80;
            this.myNormalButton4.OnButtonClick += new System.EventHandler(this.myNormalButton4_OnButtonClick);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(27, 33);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(588, 221);
            this.listView2.TabIndex = 77;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "文件";
            this.columnHeader3.Width = 211;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "操作";
            this.columnHeader4.Width = 299;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(23, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 62;
            this.label2.Text = "预览文件分拣";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.myNormalButton8);
            this.tabPage3.Controls.Add(this.myNormalButton7);
            this.tabPage3.Controls.Add(this.myNormalButton6);
            this.tabPage3.Controls.Add(this.listView3);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(672, 351);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // myNormalButton8
            // 
            this.myNormalButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton8.ButtonBackImage = null;
            this.myNormalButton8.ButtonForceColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myNormalButton8.ButtonTags = null;
            this.myNormalButton8.ButtonText = "删除";
            this.myNormalButton8.ButtonUsingSGDefaultStyle = true;
            this.myNormalButton8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton8.Location = new System.Drawing.Point(369, 265);
            this.myNormalButton8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton8.Name = "myNormalButton8";
            this.myNormalButton8.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton8.TabIndex = 86;
            this.myNormalButton8.OnButtonClick += new System.EventHandler(this.myNormalButton8_OnButtonClick);
            // 
            // myNormalButton7
            // 
            this.myNormalButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton7.ButtonBackImage = null;
            this.myNormalButton7.ButtonForceColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myNormalButton7.ButtonTags = null;
            this.myNormalButton7.ButtonText = "添加";
            this.myNormalButton7.ButtonUsingSGDefaultStyle = true;
            this.myNormalButton7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton7.Location = new System.Drawing.Point(240, 265);
            this.myNormalButton7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton7.Name = "myNormalButton7";
            this.myNormalButton7.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton7.TabIndex = 85;
            this.myNormalButton7.OnButtonClick += new System.EventHandler(this.myNormalButton7_OnButtonClick);
            // 
            // myNormalButton6
            // 
            this.myNormalButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.myNormalButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myNormalButton6.ButtonBackImage = null;
            this.myNormalButton6.ButtonForceColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.myNormalButton6.ButtonTags = null;
            this.myNormalButton6.ButtonText = "确定";
            this.myNormalButton6.ButtonUsingSGDefaultStyle = true;
            this.myNormalButton6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myNormalButton6.Location = new System.Drawing.Point(501, 265);
            this.myNormalButton6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myNormalButton6.Name = "myNormalButton6";
            this.myNormalButton6.Size = new System.Drawing.Size(110, 30);
            this.myNormalButton6.TabIndex = 84;
            this.myNormalButton6.OnButtonClick += new System.EventHandler(this.myNormalButton6_OnButtonClick);
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.listView3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.listView3.FullRowSelect = true;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(23, 31);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(588, 221);
            this.listView3.TabIndex = 83;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "文件";
            this.columnHeader5.Width = 550;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(19, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 19);
            this.label3.TabIndex = 82;
            this.label3.Text = "已排除的文件";
            // 
            // Form_SortingFileSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 393);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_SortingFileSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_SortingFileSettings";
            this.Load += new System.EventHandler(this.Form_SortingFileSettings_Load);
            this.Shown += new System.EventHandler(this.Form_SortingFileSettings_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label158;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private MyNormalButton myNormalButton3;
        private MyTextBox myTextBox2;
        private MyNormalButton myNormalButton1;
        private MyNormalButton myNormalButton2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private MyNormalButton myNormalButton5;
        private MyNormalButton myNormalButton4;
        private System.Windows.Forms.TabPage tabPage3;
        private MyNormalButton myNormalButton8;
        private MyNormalButton myNormalButton7;
        private MyNormalButton myNormalButton6;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;

    }
}