using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemGear.控件
{
    public partial class SGTileMgrPanel : Panel 
    {
        public SGTileMgrPanel()
        {
            InitializeComponent();
        }
        private Point mouseOffset;
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            Control customControl = e.Control;
            customControl.MouseDown += new MouseEventHandler(customControl_MouseDown);
            customControl.MouseMove += new MouseEventHandler(customControl_MouseMove);
            customControl.MouseUp += new MouseEventHandler(customControl_MouseUp);
        }

        void customControl_MouseDown(object sender, MouseEventArgs e)
        {
            mouseOffset = new Point(-e.X, -e.Y);
        }
        void customControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point newPoint = Control.MousePosition;
                newPoint.Offset(mouseOffset.X, mouseOffset.Y);
                Control dragObj = (Control)sender;
                dragObj.Cursor = Cursors.SizeAll;
                dragObj.Location = dragObj.Parent.PointToClient(newPoint);
            }
        }
        void customControl_MouseUp(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Default;
        }

    }
}
