using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessInterface;
using Component;
using Helper;

namespace inoutput
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
            this.tmProgress.Enabled = false;
            this.btnSelectFile.Click +=new EventHandler(this.btnSelectFile_Click);
            this.btnSelectArcancil.Click+=new EventHandler(this.btnSelectArcancil_Click);
            this.btnImportArcancil.Click+=new EventHandler(this.btnImportArcancil_Click);
            this.SizeChanged+=new EventHandler(this.frmImport_SizeChanged);
        }

        private void frmImport_SizeChanged(object sender,EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState=FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// the cities select button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var txt=this.OpenFileDialog();
            if (!string.IsNullOrEmpty(txt))
            {
                this.txtFileSelect.Text = txt;
            }
            else
            {
                MessageBox.Show("您未选取任何文件！");
            }
        }

        /// <summary>
        /// the event happens when you confirm the select file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileDialog_FileOK(object sender, EventArgs e)
        {
            var fileDialog = (OpenFileDialog) sender;
            var fileName = fileDialog.FileName;
            var extension = FileHelper.GetFileExtension(fileName);
            var shouldExtension = ConfigurationSettings.AppSettings.Get("exceltype");

            if (!shouldExtension.Contains(extension))
            {
                MessageBox.Show(string.Format(@"请选择excel文件，后缀名为{0}",shouldExtension));
                var cancelEvents = (CancelEventArgs) e;
                cancelEvents.Cancel = true;
                return;
            }
        }

        private void txtFileSelect_TextChanged(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            if (!string.IsNullOrEmpty(txt.Text) && File.Exists(txt.Text))
            {

            }
        }

        /// <summary>
        /// import cities data,init the cities
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            
            DisableComponent();
            var file = this.txtFileSelect.Text;

            if (string.IsNullOrEmpty(file) || file == "请选择城市文件")
            {
                MessageBox.Show("请选择城市文件后再进行导入操作");
                EnableComponent();
                return;
            }

            
            PrograssInit("正在导入城市文件...");
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BW_RunWorkerCompletedEventArgs);

                bw.DoWork += new DoWorkEventHandler((object o, DoWorkEventArgs d) =>
                {
                    var business = Factory.Instance().GetService<IImportBusiness>();
                    var result = business.ImportCitiesFromExcel(file);
                    if (result)
                    {
                        MessageBox.Show("城市文件导入成功！");
                    }
                    else
                    {
                        MessageBox.Show("城市文件导入失败，请重新操作！");
                    }

                });
                bw.RunWorkerAsync();
            }

        }

        /// <summary>
        /// the select arcancil click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectArcancil_Click(object sender, EventArgs e)
        {
            var file=this.OpenFileDialog();
            if (!string.IsNullOrEmpty(file))
            {
                this.txtImportArcancil.Text = file;
            }
            else
            {
                MessageBox.Show("您未选取任何文件！");
            }
        }

        /// <summary>
        /// the import arcancil click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportArcancil_Click(object sender, EventArgs e)
        {
            //first disabled the component
            DisableComponent();
            //check the file
            var file = this.txtImportArcancil.Text;
            if (string.IsNullOrEmpty(file) || file == "请选择产品文件")
            {
                MessageBox.Show("请选择产品文件后再进行导入操作");
                EnableComponent();
                return;
            }

            PrograssInit("正在导入产品文件...");
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BW_RunWorkerCompletedEventArgs);
                
                bw.DoWork+=new DoWorkEventHandler((object o,DoWorkEventArgs d) =>
                {
                    var business = Factory.Instance().GetService<IImportBusiness>();
                    var result= business.ImportArcancilFromExcel(file);
                    if (result)
                    {
                        MessageBox.Show("产品文件导入成功！");
                    }
                    else
                    {
                        MessageBox.Show("产品文件导入失败，请重新操作！");
                    }
                    
                });
                bw.RunWorkerAsync();
            }
        }

        private string OpenFileDialog()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.FileOk += new CancelEventHandler(this.fileDialog_FileOK);
            fileDialog.ShowDialog();
            return fileDialog.FileName;
        }

        private void EnableComponent()
        {
            btnImport.Enabled = true;
            btnSelectFile.Enabled = true;
            btnSelectFile.Enabled = true;
            btnImportArcancil.Enabled = true;
            btnSelectArcancil.Enabled = true;
        }

        private void DisableComponent()
        {
            btnImport.Enabled = false;
            btnSelectFile.Enabled = false;
            btnSelectFile.Enabled = false;
            btnImportArcancil.Enabled = false;
            btnSelectArcancil.Enabled = false;
        }

        /// <summary>
        /// after the background worker has been done then execute this event to enable the component and disable the prograssbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BW_RunWorkerCompletedEventArgs(object sender, RunWorkerCompletedEventArgs e)
        {
            PrograssClose();
        }
        /// <summary>
        /// init the prograss
        /// </summary>
        private void PrograssInit(string str)
        {
            bool result = false;
            this.toolStripPbMain.Style = ProgressBarStyle.Continuous;
            this.toolStripPbMain.Value = 0;
            this.tmProgress.Enabled = true;
            this.tmProgress.Interval = 300;
            this.tmProgress.Tick += new EventHandler(this.tmProgress_Tick);
            this.toolStripSlMain.Text = str;
            
        }

        /// <summary>
        /// close the prograss
        /// </summary>
        private void PrograssClose()
        {
            this.tmProgress.Enabled = false;
            this.toolStripPbMain.Value = 0;
            this.toolStripSlMain.Text = "主页面";
            EnableComponent();
        }

        private void tmProgress_Tick(object sender,EventArgs e)
        {
            ToolStripProgressBar bar = this.toolStripPbMain; //(ToolStripProgressBar)sender;
            if (bar.Value == 100)
            {
                bar.Value = 0;
            }
            else
            {
                bar.Value += 4;
            }
        }

    }
}
