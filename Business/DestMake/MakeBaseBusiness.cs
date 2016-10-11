using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Helper;
using Microsoft.Office.Interop.Excel;

namespace Business.DestMake
{
    public abstract class MakeBaseBusiness
    {
        public MakeBaseBusiness(){}

        public Application Application { get; set; }
        public string FoldPath { get; set; }
        public List<List<string>> DataList { get; set; }
        public abstract string Extension { get; }

        public string FileName
        {
            get { return ConfigHelper.GetExcelExtesion(); }
        }

        public bool Init(MakeDestEntity entity)
        {
            InitDataList(entity);
            InitApplication(this.DataList);
            return true;
        }
        public bool Make(MakeDestEntity entity)
        {
            var file=CreateFile();
            if (entity.IsPushToFtp)
            {
                PushFileToFtp(file);
            }
            return true;
        }
        protected bool InitDataList(MakeDestEntity entity)
        {
            var result=new List<List<string>>();
            var excelhelper=new ExcelHelper(entity.OrderListFile);
            var orderlist = excelhelper.GetAllSheetData();
            excelhelper.InitExcel(entity.OrderDetailListFile);
            var orderdetailist = excelhelper.GetAllSheetData();
            orderlist.RemoveAt(0);
            orderlist.ForEach(x =>
            {
                var order=new List<string>();
                order.Add(string.IsNullOrEmpty(x[0])?"":x[0]);                                  //订单编号
                //todo:法国邮政订单号
                order.Add(string.IsNullOrEmpty(x[0]) ? "" : string.Format("{0}_{1}", x[0]));    //法国邮政订单号
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : x[17]);                            //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //法国公司名称
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                order.Add(string.IsNullOrEmpty(x[17]) ? "" : string.Format("{0}_{1}", x[17]));  //下单时间
                
            });

            this.DataList = result;
            return true;
        }
        protected bool InitApplication(List<List<string>> dataList)
        {
            this.Application= new Application();
            return true;
        }
        protected bool PushFileToFtp(string file)
        {
            return true;
        }

        /// <summary>
        /// make destination file to path
        /// </summary>
        /// <param name="extension">the file extension</param>
        /// <param name="dataList">data should be saved</param>
        /// <returns>the destination file including path</returns>
        public abstract string CreateFile();

        /*protected List<string> RunNext(MakeBaseBusiness next,MakeDestEntity entity)
        {
            next.Application = this.Application;
            next.DataList = next.DataList;
            var result = next.CreateFile(entity);
            return result;
        }*/ 
    }
}
