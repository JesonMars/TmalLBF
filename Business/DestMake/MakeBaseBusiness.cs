using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Component;
using DALInterface;
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

#region 初始化订单列表数据
            var excelhelper=new ExcelHelper(entity.OrderListFile);
            var orderlistdata = excelhelper.GetAllSheetData();
            var orders=new List<OrderEntity>();
            orderlistdata.ForEach(x=>
            {
                var order=new OrderEntity();
                order.OrderId = x[0];
                order.DateOrder = x[17];
                order.ShippingFees = x[4];
                order.AddressDetails =string.IsNullOrEmpty(x[36])?x[36]:x[13];
                order.CDeliveryAddress = string.IsNullOrEmpty(x[36]) ? x[36] : x[13];
                var addresss = order.AddressDetails.Split(' ');
                order.City = addresss[1];
                order.ProvinceAutonomousRegion = addresss[0];
                order.ConsigneePhoneNumber = x[16];
                order.Country = addresss[1]=="海外"?"中国"+addresss[0]:"CN";
                order.CountyDistrict = addresss[2];
                order.PostCode = addresss[addresss.Length - 1].Substring(addresss[addresss.Length - 1].Length-8,8);
                order.SettlementAmount = x[8];
                order.RecipientName = x[12];
            });
#endregion

#region 初始化订单详情列表数据
            excelhelper.InitExcel(entity.OrderDetailListFile);
            var orderdetailistdata = excelhelper.GetAllSheetData();
            var orderdetails = new List<OrderDetailEntity>();
            if (orderdetailistdata != null && orderdetailistdata.Count > 0)
            {
                orderdetailistdata.RemoveAt(0);
                orderdetailistdata.ForEach(x =>
                {
                    var orderdetail = new OrderDetailEntity();
                    orderdetail.OrderId = string.IsNullOrEmpty(x[0]) ? "" : x[0];
                    orderdetail.ProductName = x[1];
                    orderdetail.Price = decimal.Parse(x[2]);
                    orderdetail.Count = int.Parse(x[3]);
                    orderdetail.OutSysId = x[4];
                    orderdetail.ProductProperty = x[5];
                    orderdetail.PackagesInfo = x[6];
                    orderdetail.Note = x[7];
                    orderdetail.OrderId = x[8];
                    orderdetail.ProductRef = x[9];
                    orderdetails.Add(orderdetail);
                });
            }
#endregion

            var cataloguedal = Factory.Instance().GetService<ICatalogueDal>();
            orderlistdata.ForEach(x =>
            {
                var order=new List<string>();
                var orderDetailEntity = orderdetails.FirstOrDefault(o=>o.OrderId==x[0]);
                if (orderDetailEntity != null)
                {
                    var catalogueEntity = cataloguedal.SelectList(new CatalogueEntity()
                    {
                        ProductRef = orderDetailEntity.ProductRef
                    });
                }
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
