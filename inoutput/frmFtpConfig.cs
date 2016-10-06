using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessInterface;
using Component;
using Entity;

namespace inoutput
{
    public partial class frmFtpConfig : Form
    {
        public frmFtpConfig()
        {
            InitializeComponent();
            chkIsShowPw.Checked = true;
            this.btnFtpUpdate.Click+=new EventHandler(btnFtpUpdate_Click);
        }

        private void btnFtpUpdate_Click(object sender, EventArgs e)
        {
            var txt = (TextBox) sender;
            var txtUserName = txt.Parent.Controls.Find("txtFtpUserName", false).FirstOrDefault();
            var txtPassWord = txt.Parent.Controls.Find("txtFtpPassword", false).FirstOrDefault();
            var txtHost=txt.Parent.Controls.Find("txtFtpHost",false).FirstOrDefault();
            
            var entity = new FtpConfigEntity();
            entity.FtpUserName = ((TextBox)txtUserName).Text;
            entity.FtpPassword = ((TextBox)txtPassWord).Text;
            entity.FtpHost = ((TextBox)txtHost).Text;

            var business = Factory.Instance().GetService<IFtpBusiness>();
            var result=business.AddNew(entity);
            if (result)
            {
                MessageBox.Show("更新成功！");
            }
            else
            {
                MessageBox.Show("更新失败！");
            }
        }

        private void frmFtpConfig_Load(object sender, EventArgs e)
        {
            var business = Factory.Instance().GetService<IFtpBusiness>();
            var entity=business.GetLast();
            if (entity != null)
            {
                this.txtFtpUserName.Text = entity.FtpUserName;
                this.txtFtpPassword.Text = entity.FtpPassword;
                this.txtFtpHost.Text = entity.FtpHost;
            }
        }

        private void chkIsShowPw_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsShowPw.Checked)
            {
                txtFtpPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtFtpPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
