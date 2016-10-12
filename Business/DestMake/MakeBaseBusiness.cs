using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            var regex = ConfigHelper.GetPostCodeRegex();
            orderlistdata.ForEach(x=>
            {
                var order=new OrderEntity();
                order.OrderId = x[0]; //订单号
                order.DateOrder = x[17];//订单创建时间
                order.ShippingFees = x[4];//运费
                order.AddressDetails =x[13];//收获地址
                order.CDeliveryAddress = x[13];//收获地址
                var addresss = order.AddressDetails.Split(' ');
                order.City = addresss[1];//城市名称，默认的是收获地址的第一个
                order.ProvinceAutonomousRegion = addresss[0];//省份名称
                order.ConsigneePhoneNumber = x[16];//收货人联系电话
                order.Country = addresss[1]="CN";//国家
                order.CountyDistrict = TranslateHelper.YouDaoC2E(addresss[2]);//县/镇/区v
                order.SettlementAmount = x[8];//实际付款金额
                order.RecipientName = TranslateHelper.YouDaoC2E(x[12]);//收款人英文姓名

                var postmatch = Regex.Match(order.AddressDetails, regex);
                var postcode = "";
                if (postmatch != null) {
                    postcode = postmatch.Value;
                }
                order.PostCode =postcode.Replace("(","").Replace(")","");//邮政编码
                order.AddressDetails = TranslateHelper.YouDaoC2E(order.AddressDetails.Replace(postcode,""));//详细地址
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
