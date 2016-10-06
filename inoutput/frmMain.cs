using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace inoutput
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            ShowFrmImport();
        }

        private void ShowFrmImport()
        {
            frmImport frm = new frmImport();
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.Height = this.ClientRectangle.Height + 10;
            frm.Width = this.ClientRectangle.Width + 30;
            frm.WindowState=FormWindowState.Maximized;
            frm.Show();
        }

        private void muFtp_Click(object sender, EventArgs e)
        {
            frmFtpConfig frm=new frmFtpConfig();
            frm.MdiParent = this;
            frm.Show();
        }

    }
}
