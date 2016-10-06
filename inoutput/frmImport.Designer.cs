namespace inoutput
{
    partial class frmImport
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbArcancil = new System.Windows.Forms.GroupBox();
            this.btnSelectArcancil = new System.Windows.Forms.Button();
            this.btnImportArcancil = new System.Windows.Forms.Button();
            this.txtImportArcancil = new System.Windows.Forms.TextBox();
            this.statusBarMain = new System.Windows.Forms.StatusStrip();
            this.toolStripPbMain = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSlMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbCity = new System.Windows.Forms.GroupBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtFileSelect = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tmProgress = new System.Windows.Forms.Timer(this.components);
            this.pnlMain.SuspendLayout();
            this.gbArcancil.SuspendLayout();
            this.statusBarMain.SuspendLayout();
            this.gbCity.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSize = true;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMain.Controls.Add(this.gbArcancil);
            this.pnlMain.Controls.Add(this.statusBarMain);
            this.pnlMain.Controls.Add(this.gbCity);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(645, 430);
            this.pnlMain.TabIndex = 4;
            // 
            // gbArcancil
            // 
            this.gbArcancil.Controls.Add(this.btnSelectArcancil);
            this.gbArcancil.Controls.Add(this.btnImportArcancil);
            this.gbArcancil.Controls.Add(this.txtImportArcancil);
            this.gbArcancil.Location = new System.Drawing.Point(29, 204);
            this.gbArcancil.Name = "gbArcancil";
            this.gbArcancil.Size = new System.Drawing.Size(513, 113);
            this.gbArcancil.TabIndex = 3;
            this.gbArcancil.TabStop = false;
            this.gbArcancil.Text = "产品初始化";
            // 
            // btnSelectArcancil
            // 
            this.btnSelectArcancil.Location = new System.Drawing.Point(336, 47);
            this.btnSelectArcancil.Name = "btnSelectArcancil";
            this.btnSelectArcancil.Size = new System.Drawing.Size(69, 23);
            this.btnSelectArcancil.TabIndex = 2;
            this.btnSelectArcancil.Text = "选择";
            this.btnSelectArcancil.UseVisualStyleBackColor = true;
            // 
            // btnImportArcancil
            // 
            this.btnImportArcancil.Location = new System.Drawing.Point(407, 47);
            this.btnImportArcancil.Name = "btnImportArcancil";
            this.btnImportArcancil.Size = new System.Drawing.Size(70, 23);
            this.btnImportArcancil.TabIndex = 1;
            this.btnImportArcancil.Text = "导入";
            this.btnImportArcancil.UseVisualStyleBackColor = true;
            // 
            // txtImportArcancil
            // 
            this.txtImportArcancil.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtImportArcancil.Location = new System.Drawing.Point(14, 48);
            this.txtImportArcancil.Name = "txtImportArcancil";
            this.txtImportArcancil.ReadOnly = true;
            this.txtImportArcancil.Size = new System.Drawing.Size(322, 21);
            this.txtImportArcancil.TabIndex = 0;
            this.txtImportArcancil.Text = "请选择产品文件";
            // 
            // statusBarMain
            // 
            this.statusBarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripPbMain,
            this.toolStripSlMain});
            this.statusBarMain.Location = new System.Drawing.Point(0, 404);
            this.statusBarMain.Name = "statusBarMain";
            this.statusBarMain.Size = new System.Drawing.Size(641, 22);
            this.statusBarMain.TabIndex = 1;
            this.statusBarMain.Text = "Main页面状态";
            // 
            // toolStripPbMain
            // 
            this.toolStripPbMain.Name = "toolStripPbMain";
            this.toolStripPbMain.RightToLeftLayout = true;
            this.toolStripPbMain.Size = new System.Drawing.Size(200, 16);
            // 
            // toolStripSlMain
            // 
            this.toolStripSlMain.Name = "toolStripSlMain";
            this.toolStripSlMain.Size = new System.Drawing.Size(44, 17);
            this.toolStripSlMain.Text = "主页面";
            // 
            // gbCity
            // 
            this.gbCity.Controls.Add(this.btnSelectFile);
            this.gbCity.Controls.Add(this.btnImport);
            this.gbCity.Controls.Add(this.txtFileSelect);
            this.gbCity.Location = new System.Drawing.Point(29, 56);
            this.gbCity.Name = "gbCity";
            this.gbCity.Size = new System.Drawing.Size(513, 113);
            this.gbCity.TabIndex = 0;
            this.gbCity.TabStop = false;
            this.gbCity.Text = "城市初始化";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(336, 47);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(69, 23);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "选择";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(407, 47);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(70, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtFileSelect
            // 
            this.txtFileSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFileSelect.Location = new System.Drawing.Point(14, 48);
            this.txtFileSelect.Name = "txtFileSelect";
            this.txtFileSelect.ReadOnly = true;
            this.txtFileSelect.Size = new System.Drawing.Size(322, 21);
            this.txtFileSelect.TabIndex = 0;
            this.txtFileSelect.Text = "请选择城市文件";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(29, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 33);
            this.panel1.TabIndex = 3;
            // 
            // tmProgress
            // 
            this.tmProgress.Interval = 300;
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 430);
            this.Controls.Add(this.pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImport";
            this.Text = "数据初始化";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.gbArcancil.ResumeLayout(false);
            this.gbArcancil.PerformLayout();
            this.statusBarMain.ResumeLayout(false);
            this.statusBarMain.PerformLayout();
            this.gbCity.ResumeLayout(false);
            this.gbCity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.StatusStrip statusBarMain;
        private System.Windows.Forms.ToolStripProgressBar toolStripPbMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSlMain;
        private System.Windows.Forms.GroupBox gbCity;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtFileSelect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbArcancil;
        private System.Windows.Forms.Button btnSelectArcancil;
        private System.Windows.Forms.Button btnImportArcancil;
        private System.Windows.Forms.TextBox txtImportArcancil;
        private System.Windows.Forms.Timer tmProgress;



    }
}