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
        public List<DestFileEntity> DataList { get; set; }
        public abstract string Extension { get; }

        public string FileName
        {
            get { return ConfigHelper.GetExcelExtesion(); }
        }

        public bool Init(MakeDestEntity entity)
        {
            InitDestFileEntitys(entity);
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
        protected bool InitDestFileEntitys(MakeDestEntity entity)
        {
            var result=new List<DestFileEntity>();

#region 初始化订单列表数据
            var excelhelper=new ExcelHelper(entity.OrderListFile);
            var orderlistdata = excelhelper.GetAllSheetData();
            orderlistdata.RemoveAt(0);
            var orders=new List<OrderEntity>();
            var regex = ConfigHelper.GetPostCodeRegex();
            foreach (var x in orderlistdata)
            {
                if (string.IsNullOrEmpty(x[0]))
                {
                    continue;
                }
                var order = new OrderEntity();
                order.OrderId = x[0]; //订单号
                order.DateOrder = x[17];//订单创建时间
                order.ShippingFees = x[4];//运费
                order.AddressDetails = x[13];//收获地址
                order.CDeliveryAddress = x[13];//收获地址
                var addresss = order.AddressDetails.Split(' ');
                order.City = addresss[1];//城市名称，默认的是收获地址的第一个
                order.ProvinceAutonomousRegion = addresss[0];//省份名称
                order.ConsigneePhoneNumber = x[16];//收货人联系电话
                order.Country = addresss[1] = "CN";//国家
                order.CountyDistrict = TranslateHelper.YouDaoC2E(addresss[2]);//县/镇/区v
                order.SettlementAmount = x[8];//实际付款金额
                order.ERecipientName = TranslateHelper.YouDaoC2E(x[12]);//收款人英文姓名
                order.CRecipientName = x[12];//收款人英文姓名

                var postmatch = Regex.Match(order.AddressDetails, regex);
                var postcode = "";
                postcode = postmatch.Value;
                order.PostCode = postcode.Replace("(", "").Replace(")", "");//邮政编码
                order.AddressDetails = TranslateHelper.YouDaoC2E(order.AddressDetails.Replace(postcode, ""));//详细地址
                orders.Add(order);
            }
#endregion

#region 初始化订单详情列表数据
            excelhelper.InitExcel(entity.OrderDetailListFile);
            var orderdetailistdata = excelhelper.GetAllSheetData();
            var orderdetails = new List<OrderDetailEntity>();
            if (orderdetailistdata != null && orderdetailistdata.Count > 0)
            {
                orderdetailistdata.RemoveAt(0);
                foreach (var x in orderdetailistdata)
                {
                    if (string.IsNullOrEmpty(x[0]) || Regex.IsMatch(x[0], @"[\u4e00-\u9fa5]"))
                    {
                        continue;
                    }
                    var orderdetail = new OrderDetailEntity();
                    orderdetail.OrderId = string.IsNullOrEmpty(x[0]) ? "" : x[0];
                    orderdetail.ProductName = x[1];
                    orderdetail.Price = decimal.Parse(x[2]);
                    orderdetail.Count = int.Parse(x[3]);
                    orderdetail.OutSysId = x[4];
                    orderdetail.ProductProperty = x[5];
                    orderdetail.PackagesInfo = x[6];
                    orderdetail.Note = x[7];
                    orderdetail.OrderStatus = x[8];
                    orderdetail.ProductRef = x[9];
                    orderdetails.Add(orderdetail);
                }
            }
#endregion

#region 生成导出的数据实体
            var cataloguedal = Factory.Instance().GetService<ICatalogueDal>();
            orderdetails.ForEach(x =>
            {
                var destFileEntity=new DestFileEntity();
                var catalogueEntitys = cataloguedal.SelectList(new CatalogueEntity(){ProductRef =x.ProductRef});
                var catalogueEntity = catalogueEntitys.FirstOrDefault() ?? new CatalogueEntity();
                var order = orders.FirstOrDefault(o => o.OrderId == x.OrderId) ?? new OrderEntity();

                destFileEntity.OrderId = x.OrderId;//订单编号
                destFileEntity.LbfOrderNumber = string.Format("{0}_{1}", x.OrderId, catalogueEntity.EBrand);    //法国邮政订单号
                destFileEntity.DateOrder = order.DateOrder;//下单时间
                destFileEntity.FrenchCompanyName =catalogueEntity.FCompany;//法国公司名称
                destFileEntity.Brand = catalogueEntity.EBrand;
                destFileEntity.EFullProductName = catalogueEntity.EFullProductName;
                destFileEntity.ProductRef = x.ProductRef;
                destFileEntity.Quantity = x.Count;
                destFileEntity.PricePerUnit = catalogueEntity.RmbMiniSalePrice;
                //todo:CouponsRewards
                var miniPrice = orderdetails.Where(o => o.OrderId == x.OrderId).Sum(o =>
                {
                    var firstOrDefault = cataloguedal.SelectList(new CatalogueEntity() {ProductRef = o.ProductRef}).FirstOrDefault();
                    return firstOrDefault==null?0:firstOrDefault.RmbMiniSalePrice*o.Count;
                });
                destFileEntity.CouponsRewards = decimal.Round((miniPrice - decimal.Parse(order.SettlementAmount)) /
                                                orderdetails.Count(o => o.OrderId == x.OrderId),2);
                destFileEntity.ShippingFees = order.ShippingFees;
                //todo:SettlementAmount
                destFileEntity.SettlementAmount =decimal.Round(decimal.Parse(order.SettlementAmount) / orderdetails.Count(o => o.OrderId == x.OrderId),2);
                destFileEntity.ERecipientName = order.ERecipientName.ToUpper();
                destFileEntity.Country = order.Country;
                destFileEntity.ProvinceAutonomousRegion = order.ProvinceAutonomousRegion;
                destFileEntity.City = order.City;
                destFileEntity.PostCode = order.PostCode;
                destFileEntity.CountyDistrict = order.CountyDistrict;
                destFileEntity.AddressDetails = order.AddressDetails;
                destFileEntity.ConsigneePhoneNumber = order.ConsigneePhoneNumber;
                destFileEntity.CFullProductName = x.ProductName;
                destFileEntity.CRecipientName = order.CRecipientName;
                destFileEntity.CDeliveryAddress = order.CDeliveryAddress;
                destFileEntity.ConsigneePhoneNumber = order.ConsigneePhoneNumber;
                result.Add(destFileEntity);
            });
#endregion

            this.DataList = result;
            return true;
        }
        protected bool InitApplication(List<DestFileEntity> dataList)
        {
            this.Application= new Application();
            return true;
        }
        protected bool PushFileToFtp(string file)
        {
            var ftpconfigdal = Factory.Instance().GetService<IFtpDal>();
            var config=ftpconfigdal.SelectLast();
            var ftpHelper = new FtpHelper(config.FtpHost,config.FtpPath,config.FtpUserName,config.FtpPassword);
            ftpHelper.Upload(file);
            return true;
        }

        /// <summary>
        /// make destination file to path
        /// </summary>
        /// <param name="extension">the file extension</param>
        /// <param name="dataList">data should be saved</param>
        /// <returns>the destination file including path</returns>
        public virtual string CreateFile()
        {
            var excelHelper = new ExcelHelper();
            var filename = string.Format(@"{0}\{1}.{2}", FoldPath, ConfigHelper.GetDestFileName(), Extension);
            excelHelper.ExportExcel(filename, new List<List<string>>(), "Expected file order",XlFileFormat.xlExcel8);
            return filename;
        }

        /*protected List<string> RunNext(MakeBaseBusiness next,MakeDestEntity entity)
        {
            next.Application = this.Application;
            next.DataList = next.DataList;
            var result = next.CreateFile(entity);
            return result;
        }*/ 
    }
}
