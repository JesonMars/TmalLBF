using System.Windows.Forms.VisualStyles;

namespace inoutput
{
    partial class frmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tsmlFunc = new System.Windows.Forms.ToolStripMenuItem();
            this.muMakeDestinationFile = new System.Windows.Forms.ToolStripMenuItem();
            this.muFtp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmlAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fbDialogMain = new System.Windows.Forms.OpenFileDialog();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmlFunc
            // 
            this.tsmlFunc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muMakeDestinationFile,
            this.muFtp});
            this.tsmlFunc.Name = "tsmlFunc";
            this.tsmlFunc.Size = new System.Drawing.Size(44, 21);
            this.tsmlFunc.Text = "功能";
            // 
            // muMakeDestinationFile
            // 
            this.muMakeDestinationFile.Name = "muMakeDestinationFile";
            this.muMakeDestinationFile.Size = new System.Drawing.Size(152, 22);
            this.muMakeDestinationFile.Text = "生成最终文件";
            this.muMakeDestinationFile.Click += new System.EventHandler(this.muMakeDestinationFile_Click);
            // 
            // muFtp
            // 
            this.muFtp.Name = "muFtp";
            this.muFtp.Size = new System.Drawing.Size(152, 22);
            this.muFtp.Text = "ftp配置";
            this.muFtp.Click += new System.EventHandler(this.muFtp_Click);
            // 
            // tsmlAbout
            // 
            this.tsmlAbout.Name = "tsmlAbout";
            this.tsmlAbout.Size = new System.Drawing.Size(44, 21);
            this.tsmlAbout.Text = "关于";
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmlFunc,
            this.tsmlAbout});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(658, 25);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "主页面菜单";
            // 
            // fbDialogMain
            // 
            this.fbDialogMain.FileName = "fnDialogMain";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 495);
            this.Controls.Add(this.msMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "frmMain";
            this.Text = "程序";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmlFunc;
        private System.Windows.Forms.ToolStripMenuItem tsmlAbout;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem muFtp;
        private System.Windows.Forms.OpenFileDialog fbDialogMain;
        private System.Windows.Forms.ToolStripMenuItem muMakeDestinationFile;

    }
}

