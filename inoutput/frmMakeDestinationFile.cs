using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Helper;
using Entity;
using Component;
using BusinessInterface;

namespace inoutput
{
    public partial class FrmMakeDestinationFile : Form
    {
        private string _strorderlisttext = "请选择订单列表文件";
        private string _strorderdetaillisttext = "请选择订单详情列表文件";
        private string _strDestinationFolderText = "请选择最终文件保存的路径";
        public FrmMakeDestinationFile()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.pbProgress.Step = 10;
            this.pbProgress.Maximum = 100;
            this.pbProgress.Minimum = 0;
            this.txtSelectOrderList.Text = _strorderlisttext;
            this.txtSelectOrderDetailList.Text = _strorderdetaillisttext;
            this.txtDestinationFolder.Text = _strDestinationFolderText;
            
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            this.btnSelectFoler.Click += new EventHandler(this.btnSelectFoler_Click);
            this.btnSelectOrderList.Click += new EventHandler(this.btnSelectOrderList_Click);
            this.btnSelectOrderDetailList.Click += new EventHandler(this.btnSelectOrderDetailList_Click);
            this.fdOpen.FileOk+=new CancelEventHandler(this.fdOpen_FileOk);
        }

        private void btnMake_Click(object sender, EventArgs e)
        {
            DisableControl();
            if (!ExcelHelper.IsExcel(txtSelectOrderList.Text))
            {
                MessageBox.Show("订单文件必须符合excel格式，请重新选择!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnableControl();
                return;
            }
            if (!ExcelHelper.IsExcel(txtSelectOrderDetailList.Text))
            {
                MessageBox.Show("订单详情文件必须符合excel格式，请重新选择!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnableControl();
                return;
            }
            if (!Directory.Exists(txtDestinationFolder.Text))
            {
                MessageBox.Show("请选择文件保存路径!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnableControl();
                return;
            }
            using (var background=new BackgroundWorker())
            {   
                ProcessStart("文件生成中...");
                background.RunWorkerCompleted += new RunWorkerCompletedEventHandler((object o, RunWorkerCompletedEventArgs d) =>
                {
                    ProcessEnd();
                    EnableControl();
                });
                background.DoWork+=new DoWorkEventHandler((object o, DoWorkEventArgs d) =>
                {
                    var entity = new MakeDestEntity();
                    entity.IsMakeCsv = this.cbCsv.Checked;
                    entity.IsMakeXls = this.cbXls.Checked;
                    entity.IsMakeXlsx = this.cbXlsx.Checked;
                    entity.IsPushToFtp = this.cbUploadToFtp.Checked;
                    entity.OrderListFile = txtSelectOrderList.Text;
                    entity.OrderDetailListFile = txtSelectOrderDetailList.Text;
                    entity.DestFolder = txtDestinationFolder.Text;
                    var business = Factory.Instance().GetService<IMakeDestBusiness>();
                    var result=business.Make(entity);
                    if (result){
                        MessageBox.Show("生成成功！");
                    }
                    else {
                        MessageBox.Show("生成失败！");
                    }
                    
                    
                });
                background.RunWorkerAsync();
            }
            
        }

        private void btnSelectFoler_Click(object sender, EventArgs e)
        {
            var result=fbdSelectFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDestinationFolder.Text = fbdSelectFolder.SelectedPath;
            }
        }

        private void btnSelectOrderList_Click(object sender, EventArgs e)
        {
            var result = fdOpen.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSelectOrderList.Text = fdOpen.FileName;
            }
        }

        private void btnSelectOrderDetailList_Click(object sender, EventArgs e)
        {
            var result = fdOpen.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSelectOrderDetailList.Text = fdOpen.FileName;
            }
            
        }

        private void fdOpen_FileOk(object sender, EventArgs e)
        {
            var dialog = (OpenFileDialog) sender;
            var file = dialog.FileName;
            var excel = ConfigHelper.GetExcelExtesion();
            if (!ExcelHelper.IsExcel(file))
            {
                MessageBox.Show(string.Format("请选择后缀名为{0}的文件!",excel), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var cancelEvents = (CancelEventArgs)e;
                cancelEvents.Cancel = true;
                return;
            }
        }

        private void ProcessStart(string note)
        {
            this.tsslDes.Text = note;
            this.tmProgress.Enabled = true;
            this.tmProgress.Interval = 300;
            tmProgress.Tick+=new EventHandler(this.tmProgress_Tick);
        }

        private void ProcessEnd()
        {
            this.tsslDes.Text = "无任务";
            this.tmProgress.Enabled = false;
            this.pbProgress.Value = 0;
        }

        private void tmProgress_Tick(object sender, EventArgs e)
        {
            if (this.pbProgress.Value != 100)
            {
                this.pbProgress.Value += 4;
            }
            else
            {
                this.pbProgress.Value = 0;
            }
        }

        private void DisableControl()
        {
            this.btnMake.Enabled = false;
        }

        private void EnableControl()
        {
            this.btnMake.Enabled = true;
        }

    }
}
