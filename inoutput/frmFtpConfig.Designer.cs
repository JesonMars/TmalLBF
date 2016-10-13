namespace inoutput
{
    partial class frmFtpConfig
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtFtpUserName = new System.Windows.Forms.TextBox();
            this.txtFtpPassword = new System.Windows.Forms.TextBox();
            this.txtFtpHost = new System.Windows.Forms.TextBox();
            this.btnFtpUpdate = new System.Windows.Forms.Button();
            this.chkIsShowPw = new System.Windows.Forms.CheckBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(45, 46);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(53, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户名：";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(47, 94);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 12);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "密  码：";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(47, 136);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(53, 12);
            this.lblHost.TabIndex = 2;
            this.lblHost.Text = "主机IP：";
            // 
            // txtFtpUserName
            // 
            this.txtFtpUserName.Location = new System.Drawing.Point(104, 42);
            this.txtFtpUserName.Name = "txtFtpUserName";
            this.txtFtpUserName.Size = new System.Drawing.Size(205, 21);
            this.txtFtpUserName.TabIndex = 3;
            // 
            // txtFtpPassword
            // 
            this.txtFtpPassword.Location = new System.Drawing.Point(104, 91);
            this.txtFtpPassword.Name = "txtFtpPassword";
            this.txtFtpPassword.Size = new System.Drawing.Size(205, 21);
            this.txtFtpPassword.TabIndex = 4;
            // 
            // txtFtpHost
            // 
            this.txtFtpHost.Location = new System.Drawing.Point(104, 133);
            this.txtFtpHost.Name = "txtFtpHost";
            this.txtFtpHost.Size = new System.Drawing.Size(205, 21);
            this.txtFtpHost.TabIndex = 5;
            // 
            // btnFtpUpdate
            // 
            this.btnFtpUpdate.Location = new System.Drawing.Point(139, 251);
            this.btnFtpUpdate.Name = "btnFtpUpdate";
            this.btnFtpUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnFtpUpdate.TabIndex = 6;
            this.btnFtpUpdate.Text = "更新";
            this.btnFtpUpdate.UseVisualStyleBackColor = true;
            // 
            // chkIsShowPw
            // 
            this.chkIsShowPw.AutoSize = true;
            this.chkIsShowPw.Location = new System.Drawing.Point(47, 218);
            this.chkIsShowPw.Name = "chkIsShowPw";
            this.chkIsShowPw.Size = new System.Drawing.Size(72, 16);
            this.chkIsShowPw.TabIndex = 7;
            this.chkIsShowPw.Text = "显示密码";
            this.chkIsShowPw.UseVisualStyleBackColor = true;
            this.chkIsShowPw.CheckedChanged += new System.EventHandler(this.chkIsShowPw_CheckedChanged);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(104, 177);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(205, 21);
            this.txtFilePath.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "保存路径：";
            // 
            // frmFtpConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 302);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkIsShowPw);
            this.Controls.Add(this.btnFtpUpdate);
            this.Controls.Add(this.txtFtpHost);
            this.Controls.Add(this.txtFtpPassword);
            this.Controls.Add(this.txtFtpUserName);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Name = "frmFtpConfig";
            this.Text = "ftp配置";
            this.Load += new System.EventHandler(this.frmFtpConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtFtpUserName;
        private System.Windows.Forms.TextBox txtFtpPassword;
        private System.Windows.Forms.TextBox txtFtpHost;
        private System.Windows.Forms.Button btnFtpUpdate;
        private System.Windows.Forms.CheckBox chkIsShowPw;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
    }
}