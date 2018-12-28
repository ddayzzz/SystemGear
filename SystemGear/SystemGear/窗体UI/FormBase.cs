﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear.窗体UI
{
    /// <summary>
    /// 拥有ToolTip属性的Form基类
    /// </summary>
    public class FormBase : Form
    {
        private ToolTip _toolTip;

        public FormBase()
            : base()
        {
            _toolTip = new ToolTip();
        }

        internal ToolTip ToolTip
        {
            get { return _toolTip; }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _toolTip.Dispose();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(290, 267);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormBase";
            this.ResumeLayout(false);

        }
    }
}
