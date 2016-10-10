namespace inoutput
{
    partial class FrmMakeDestinationFile
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
            this.components = new System.ComponentModel.Container();
            this.gbSelectFile = new System.Windows.Forms.GroupBox();
            this.btnSelectOrderDetailList = new System.Windows.Forms.Button();
            this.txtSelectOrderDetailList = new System.Windows.Forms.TextBox();
            this.btnSelectOrderList = new System.Windows.Forms.Button();
            this.txtSelectOrderList = new System.Windows.Forms.TextBox();
            this.btnMake = new System.Windows.Forms.Button();
            this.cbXlsx = new System.Windows.Forms.CheckBox();
            this.cbXls = new System.Windows.Forms.CheckBox();
            this.cbCsv = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectFoler = new System.Windows.Forms.Button();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.cbUploadToFtp = new System.Windows.Forms.CheckBox();
            this.fdOpen = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslDes = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmProgress = new System.Windows.Forms.Timer(this.components);
            this.fbdSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.gbSelectFile.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelectFile
            // 
            this.gbSelectFile.Controls.Add(this.btnSelectOrderDetailList);
            this.gbSelectFile.Controls.Add(this.txtSelectOrderDetailList);
            this.gbSelectFile.Controls.Add(this.btnSelectOrderList);
            this.gbSelectFile.Controls.Add(this.txtSelectOrderList);
            this.gbSelectFile.Location = new System.Drawing.Point(41, 49);
            this.gbSelectFile.Name = "gbSelectFile";
            this.gbSelectFile.Size = new System.Drawing.Size(435, 139);
            this.gbSelectFile.TabIndex = 1;
            this.gbSelectFile.TabStop = false;
            this.gbSelectFile.Text = "选择文件";
            // 
            // btnSelectOrderDetailList
            // 
            this.btnSelectOrderDetailList.Location = new System.Drawing.Point(336, 91);
            this.btnSelectOrderDetailList.Name = "btnSelectOrderDetailList";
            this.btnSelectOrderDetailList.Size = new System.Drawing.Size(69, 23);
            this.btnSelectOrderDetailList.TabIndex = 4;
            this.btnSelectOrderDetailList.Text = "选择";
            this.btnSelectOrderDetailList.UseVisualStyleBackColor = true;
            // 
            // txtSelectOrderDetailList
            // 
            this.txtSelectOrderDetailList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSelectOrderDetailList.Location = new System.Drawing.Point(14, 92);
            this.txtSelectOrderDetailList.Name = "txtSelectOrderDetailList";
            this.txtSelectOrderDetailList.ReadOnly = true;
            this.txtSelectOrderDetailList.Size = new System.Drawing.Size(322, 21);
            this.txtSelectOrderDetailList.TabIndex = 3;
            // 
            // btnSelectOrderList
            // 
            this.btnSelectOrderList.Location = new System.Drawing.Point(336, 47);
            this.btnSelectOrderList.Name = "btnSelectOrderList";
            this.btnSelectOrderList.Size = new System.Drawing.Size(69, 23);
            this.btnSelectOrderList.TabIndex = 2;
            this.btnSelectOrderList.Text = "选择";
            this.btnSelectOrderList.UseVisualStyleBackColor = true;
            // 
            // txtSelectOrderList
            // 
            this.txtSelectOrderList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSelectOrderList.Location = new System.Drawing.Point(14, 48);
            this.txtSelectOrderList.Name = "txtSelectOrderList";
            this.txtSelectOrderList.ReadOnly = true;
            this.txtSelectOrderList.Size = new System.Drawing.Size(322, 21);
            this.txtSelectOrderList.TabIndex = 0;
            // 
            // btnMake
            // 
            this.btnMake.Location = new System.Drawing.Point(199, 430);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(70, 23);
            this.btnMake.TabIndex = 1;
            this.btnMake.Text = "生成";
            this.btnMake.UseVisualStyleBackColor = true;
            // 
            // cbXlsx
            // 
            this.cbXlsx.AutoSize = true;
            this.cbXlsx.Location = new System.Drawing.Point(125, 32);
            this.cbXlsx.Name = "cbXlsx";
            this.cbXlsx.Size = new System.Drawing.Size(48, 16);
            this.cbXlsx.TabIndex = 5;
            this.cbXlsx.Text = "xlsx";
            this.cbXlsx.UseVisualStyleBackColor = true;
            // 
            // cbXls
            // 
            this.cbXls.AutoSize = true;
            this.cbXls.Checked = true;
            this.cbXls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbXls.Location = new System.Drawing.Point(77, 32);
            this.cbXls.Name = "cbXls";
            this.cbXls.Size = new System.Drawing.Size(42, 16);
            this.cbXls.TabIndex = 6;
            this.cbXls.Text = "xls";
            this.cbXls.UseVisualStyleBackColor = true;
            // 
            // cbCsv
            // 
            this.cbCsv.AutoSize = true;
            this.cbCsv.Checked = true;
            this.cbCsv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCsv.Location = new System.Drawing.Point(28, 32);
            this.cbCsv.Name = "cbCsv";
            this.cbCsv.Size = new System.Drawing.Size(42, 16);
            this.cbCsv.TabIndex = 7;
            this.cbCsv.Text = "csv";
            this.cbCsv.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCsv);
            this.groupBox1.Controls.Add(this.cbXlsx);
            this.groupBox1.Controls.Add(this.cbXls);
            this.groupBox1.Location = new System.Drawing.Point(41, 336);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 71);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择最终文件类型";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectFoler);
            this.groupBox2.Controls.Add(this.txtDestinationFolder);
            this.groupBox2.Location = new System.Drawing.Point(41, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 94);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择最终文件保存路径";
            // 
            // btnSelectFoler
            // 
            this.btnSelectFoler.Location = new System.Drawing.Point(336, 45);
            this.btnSelectFoler.Name = "btnSelectFoler";
            this.btnSelectFoler.Size = new System.Drawing.Size(69, 23);
            this.btnSelectFoler.TabIndex = 6;
            this.btnSelectFoler.Text = "选择";
            this.btnSelectFoler.UseVisualStyleBackColor = true;
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDestinationFolder.Location = new System.Drawing.Point(14, 46);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.ReadOnly = true;
            this.txtDestinationFolder.Size = new System.Drawing.Size(322, 21);
            this.txtDestinationFolder.TabIndex = 5;
            // 
            // cbUploadToFtp
            // 
            this.cbUploadToFtp.AutoSize = true;
            this.cbUploadToFtp.Checked = true;
            this.cbUploadToFtp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUploadToFtp.Location = new System.Drawing.Point(43, 434);
            this.cbUploadToFtp.Name = "cbUploadToFtp";
            this.cbUploadToFtp.Size = new System.Drawing.Size(114, 16);
            this.cbUploadToFtp.TabIndex = 7;
            this.cbUploadToFtp.Text = "推送到ftp服务器";
            this.cbUploadToFtp.UseVisualStyleBackColor = true;
            // 
            // fdOpen
            // 
            this.fdOpen.FileName = "fdOpen";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbProgress,
            this.tsslDes});
            this.statusStrip.Location = new System.Drawing.Point(0, 495);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(596, 22);
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip1";
            // 
            // pbProgress
            // 
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(200, 16);
            // 
            // tsslDes
            // 
            this.tsslDes.Name = "tsslDes";
            this.tsslDes.Size = new System.Drawing.Size(56, 17);
            this.tsslDes.Text = "生成文件";
            // 
            // tmProgress
            // 
            this.tmProgress.Interval = 1500;
            // 
            // FrmMakeDestinationFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 517);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbUploadToFtp);
            this.Controls.Add(this.gbSelectFile);
            this.Controls.Add(this.btnMake);
            this.Name = "FrmMakeDestinationFile";
            this.Text = "生成最终文件";
            this.gbSelectFile.ResumeLayout(false);
            this.gbSelectFile.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSelectFile;
        private System.Windows.Forms.Button btnSelectOrderDetailList;
        private System.Windows.Forms.TextBox txtSelectOrderDetailList;
        private System.Windows.Forms.Button btnSelectOrderList;
        private System.Windows.Forms.TextBox txtSelectOrderList;
        private System.Windows.Forms.Button btnMake;
        private System.Windows.Forms.CheckBox cbXls;
        private System.Windows.Forms.CheckBox cbXlsx;
        private System.Windows.Forms.CheckBox cbCsv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbUploadToFtp;
        private System.Windows.Forms.Button btnSelectFoler;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.OpenFileDialog fdOpen;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar pbProgress;
        private System.Windows.Forms.ToolStripStatusLabel tsslDes;
        private System.Windows.Forms.Timer tmProgress;
        private System.Windows.Forms.FolderBrowserDialog fbdSelectFolder;
    }
}