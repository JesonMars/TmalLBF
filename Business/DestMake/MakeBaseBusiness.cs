﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
        public string FoldPath { get; set; }
        public List<List<string>> DataList { get; set; }
        public abstract string Extension { get; }

        public string FileName
        {
            get { return ConfigHelper.GetExcelExtesion(); }
        }

        public string Init(MakeDestEntity entity)
        {
            var result=InitDestFileEntitys(entity);
            FoldPath = entity.DestFolder;
            return result;
        }
        public bool Make(MakeDestEntity entity)
        {
            var file=CreateFile();
            try
            {
                if (entity.IsPushToFtp)
                {
                    PushFileToFtp(file);
                }
            }
            catch (Exception ex)
            {
                
            }
            return true;
        }
        protected string InitDestFileEntitys(MakeDestEntity entity)
        {
            StringBuilder resultMsg = new StringBuilder();
            var result=new List<DestFileEntity>();
            //定义出错的订单列表
            var delOrderIds=new List<string>();

#region 初始化订单列表数据
            var excelhelper=new ExcelHelper(entity.OrderListFile);
            var orderlistdata = excelhelper.GetAllSheetData();
            excelhelper.Dispose();
            orderlistdata.RemoveAt(0);
            var orders=new List<OrderEntity>();
            var regex = ConfigHelper.GetPostCodeRegex();

#region 初始化province city实体类

            var cityDal = Factory.Instance().GetService<ICityDal>();
            var cityEntitys = cityDal.SelectAll();

#endregion

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
                order.AddressDetails =string.IsNullOrEmpty(x[39])? x[13]:x[39];//收获地址
                order.CDeliveryAddress =order.AddressDetails;//收获地址

                //获取邮政编码
                var postcode = "";
                if (!string.IsNullOrEmpty(x[39]))
                {
                    var cityCur = cityEntitys.FirstOrDefault(c => { return order.AddressDetails != null && order.AddressDetails.IndexOf(c.Pc) == 0; });
                    postcode = cityCur != null ? string.Format("{0}0000", cityCur.PostCode.Substring(0,2)) : "";
                    resultMsg.AppendLine(string.IsNullOrEmpty(postcode)?"订单："+order.OrderId+"未找到邮编地址，请手动输入":"订单："+order.OrderId+"使用修改后的收获地址");
                    order.PostCode = postcode;
                }
                else
                {
                    var postmatch = Regex.Match(x[13], regex);
                    postcode = postmatch.Value;
                    order.PostCode = postcode.Replace("(", "").Replace(")", "");
                }
                

                var addresss = Regex.Split(order.AddressDetails, "\\s{1,}");
                var cityEntity = new CitiesEntity();
                var iscon = false;
                try
                {
                    
                    if (addresss.Length >= 3)
                    {
                        order.CCity = addresss[1]; //城市名称，默认的是收获地址的第一个
                        order.CProvinceAutonomousRegion = addresss[0]; //省份名称
                        order.Country = addresss[1] = "CN"; //国家
                        order.CCountyDistrict = addresss[2]; //县/镇/区,中文名

                        cityEntity = GetCityByPostCode(order, cityEntitys);
                        order.ECity = CityHelper.IsMunicipality(order.CProvinceAutonomousRegion, order.CCity) ? cityEntity.Pe : cityEntity.Citye;
                        order.EProvinceAutonomousRegion = cityEntity.Pe;
                        //判断是否为直辖市
                        order.ECountyDistrict = CityHelper.IsMunicipality(order.CProvinceAutonomousRegion, order.CCity) && cityEntity.Cityc == order.CCountyDistrict ? cityEntity.Citye : TranslateHelper.YouDaoC2E(order.CCountyDistrict);//县/镇/区,英文名
                    }
                    else
                    {
                        cityEntity = GetAddressByPostCode(order.PostCode, order.AddressDetails, cityEntitys);
                        order.CCity = cityEntity.Cityc;
                        order.CProvinceAutonomousRegion = cityEntity.Pc;
                        order.Country ="CN"; //国家
                        order.ECity = CityHelper.IsMunicipality(order.CProvinceAutonomousRegion, order.CCity) ? cityEntity.Pe : cityEntity.Citye;
                        order.EProvinceAutonomousRegion = cityEntity.Pe;
                        order.CCountyDistrict = "请手动补充"; //县/镇/区,中文名
                        order.ECountyDistrict = "请手动补充";
                     }
                }
                catch (Exception e)
                {
                    resultMsg.AppendFormat("订单：{0}，导入失败,收获地址不符合规范！\r\n", order.OrderId);
                    delOrderIds.Add(order.OrderId);
                    iscon = true;
                }
                if (iscon)
                {
                    continue;
                }

                order.ConsigneePhoneNumber = x[16];//收货人联系电话
                order.SettlementAmount = x[8];//实际付款金额
                order.CRecipientName = x[12];//收款人中文姓名
                order.ERecipientName = TransNameToPin(x[12]);//收款人英文姓名
                order.AddressDetails = TranslateHelper.YouDaoC2E(string.Join(" ", Regex.Replace(order.CDeliveryAddress.Replace(postcode, ""), @".*\s", "")));//详细地址    
                    
                orders.Add(order);
            }
#endregion

#region 初始化订单详情列表数据
            excelhelper.InitExcel(entity.OrderDetailListFile);
            var orderdetailistdata = excelhelper.GetAllSheetData();
            excelhelper.Dispose();
            var orderdetails = new List<OrderDetailEntity>();
            if (orderdetailistdata != null && orderdetailistdata.Count > 0)
            {
                orderdetailistdata.RemoveAt(0);
                foreach (var x in orderdetailistdata)
                {
                    if (string.IsNullOrEmpty(x[0]) || Regex.IsMatch(x[0], @"[\u4e00-\u9fa5]") || delOrderIds.Exists(d=>d==x[0]))
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

#region 初始化catalogue
            var cataloguedal = Factory.Instance().GetService<ICatalogueDal>();
            var catalogueEntitys = cataloguedal.SelectAll();
#endregion

#region 生成导出的数据实体
            catalogueEntitys.ForEach(c =>
            {
                foreach (var x in orderdetails.FindAll(x => (
                    x.ProductRef == c.BarEnCode || x.ProductRef == (c.ProductRef ?? ""))))
                {
                    if (string.IsNullOrEmpty(c.ProductRef))
                    {
                        if (string.IsNullOrEmpty(c.CFullProductName) || !x.ProductName.Contains(c.CFullProductName))
                        {
                            continue;
                        }
                    }
                    var destFileEntity = new DestFileEntity();
                    var order = orders.FirstOrDefault(o => o.OrderId == x.OrderId) ?? new OrderEntity();
                    var catalogueEntity = c;
                    destFileEntity.OrderId = x.OrderId;//订单编号
                    destFileEntity.LbfOrderNumber = string.Format("{0}_{1}", x.OrderId, catalogueEntity.EBrand);    //法国邮政订单号
                    destFileEntity.DateOrder = order.DateOrder;//下单时间
                    destFileEntity.FrenchCompanyName = catalogueEntity.FCompany;//法国公司名称
                    destFileEntity.Brand = catalogueEntity.EBrand;
                    destFileEntity.EFullProductName = catalogueEntity.EFullProductName;
                    destFileEntity.ProductRef = string.IsNullOrEmpty(x.ProductRef) ? catalogueEntity.BarEnCode : x.ProductRef;
                    destFileEntity.Quantity = x.Count;
                    destFileEntity.PricePerUnit = catalogueEntity.RmbMiniSalePrice;
                    destFileEntity.ShippingFees = catalogueEntity.RmbShippingCost.ToString();
                    destFileEntity.TotalShippingFees = order.ShippingFees;
                    destFileEntity.Country = order.Country;
                    destFileEntity.ProvinceAutonomousRegion = order.EProvinceAutonomousRegion;
                    destFileEntity.City = order.ECity;
                    destFileEntity.CountyDistrict = order.ECountyDistrict;
                    destFileEntity.PostCode = order.PostCode;
                    destFileEntity.AddressDetails = order.AddressDetails;
                    destFileEntity.CFullProductName = x.ProductName;
                    destFileEntity.CRecipientName = order.CRecipientName;
                    destFileEntity.ERecipientName = order.ERecipientName;
                    destFileEntity.CDeliveryAddress = order.CDeliveryAddress;
                    destFileEntity.ConsigneePhoneNumber = order.ConsigneePhoneNumber;
                    result.Add(destFileEntity);
                }
            });
            
#region 计算优惠金额和支付贷款金额
            foreach (var destFileEntities in result.GroupBy(x=>x.OrderId))
            {
                var order = orders.FirstOrDefault(x => x.OrderId == destFileEntities.FirstOrDefault().OrderId);
                var settleamount = MathHelper.Parse(order.SettlementAmount);
                var shippingFee = MathHelper.Parse(order.ShippingFees);
                var salePrice = destFileEntities.Sum(d => d.PricePerUnit * d.Quantity);
                var count = destFileEntities.Count();
                var couponsRewards = decimal.Round((salePrice - (settleamount-shippingFee)) / count, 2);
                foreach (var destFileEntity in destFileEntities)
                {
                    destFileEntity.CouponsRewards = couponsRewards;
                    destFileEntity.ShippingFees = decimal.Round(shippingFee / count, 2).ToString(CultureInfo.CurrentCulture);
                    destFileEntity.SettlementAmount = (destFileEntity.PricePerUnit - couponsRewards)*destFileEntity.Quantity;
                }
            }
#endregion
#endregion

#region 加载最终数据
            var datalist=new List<List<string>>();
            var destHead = ConfigHelper.GetDestFileHead();
            datalist.Add(destHead);
            (from a in result orderby a.FrenchCompanyName,a.Brand,a.DateOrder select a).ToList().ForEach(r =>
            {
                var data=new List<string>();
                data.Add(string.Format("'{0}", r.OrderId));
                data.Add(r.LbfOrderNumber);
                data.Add(DateTime.Parse(r.DateOrder).ToString("yyyy/M/d HH:mm"));
                data.Add(r.FrenchCompanyName);
                data.Add(r.Brand);
                data.Add(r.EFullProductName);
                data.Add(Regex.IsMatch(r.ProductRef,@"^[1-9]\d*$")?string.Format("'{0}",r.ProductRef):r.ProductRef);
                data.Add(r.Quantity.ToString());
                data.Add(r.PricePerUnit.ToString());
                data.Add(r.CouponsRewards.ToString());
                data.Add(r.ShippingFees.ToString());
                data.Add(r.SettlementAmount.ToString());
                data.Add(r.ERecipientName);
                data.Add(r.Country);
                data.Add(r.ProvinceAutonomousRegion);
                data.Add(r.City);
                data.Add(string.Format("'{0}", r.PostCode));
                data.Add(r.CountyDistrict);
                data.Add(r.AddressDetails);
                data.Add(string.Format("{0}", r.ConsigneePhoneNumber));
                data.Add(r.CFullProductName);
                data.Add(r.CRecipientName);
                data.Add(r.CDeliveryAddress);
                data.Add(string.Format("{0}", r.ConsigneePhoneNumber));
                datalist.Add(data);
            });
            this.DataList = datalist;
#endregion

            var successOrderids = result.Select(x => x.OrderId).ToList();
            var failedOrders= orderdetails.Where(a => !successOrderids.Contains(a.OrderId));
            if (failedOrders!=null && failedOrders.Count() > 0)
            {
                resultMsg.AppendFormat("订单：{0}，导出失败，请手动添加！", string.Join(",", failedOrders.Select(a => a.OrderId).ToArray()));
            }
            return resultMsg.ToString();
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

        private CitiesEntity GetAddressByPostCode(string postCode, string address, List<CitiesEntity> cityEntitys)
        {
            var cityEntity=new CitiesEntity();
            if (!string.IsNullOrEmpty(postCode) && postCode.Length == 6 && postCode != "000000")
            {
                string pchead = postCode.Substring(0, ConfigHelper.GetPostCodeHeadCount()); //如果第三位是0则获取前四位，否则获取前三位
                var citiesEntities =
                    cityEntitys.Where(c => c.PostCode.IndexOf(pchead, StringComparison.Ordinal) == 0).ToList();
                if (citiesEntities.Count() > 0)
                {
                    cityEntity = citiesEntities.FirstOrDefault(c => address.Contains(c.Cityc.Trim()) &&
                                                                    address.Contains(c.Pc.Trim())) ??
                                 cityEntitys.FirstOrDefault(c => address.Contains(c.Cityc.Trim()) &&
                                                                 address.Contains(c.Pc.Trim()));
                    if (cityEntity == null)
                    {
                        cityEntity = citiesEntities.FirstOrDefault();
                    }
                }
            }
            else
            {
                cityEntity = cityEntitys.FirstOrDefault(c => address.Contains(c.Cityc.Trim()) &&
                                                                 address.Contains(c.Pc.Trim()));
            }
            return cityEntity;
        }

        private CitiesEntity GetCityByPostCode(OrderEntity order, List<CitiesEntity> cityEntitys)
        {
            #region 检验邮编
            var cityEntity = new CitiesEntity();
            if (!string.IsNullOrEmpty(order.PostCode) && order.PostCode.Length == 6 && order.PostCode != "000000")
            {
                string pchead = order.PostCode.Substring(0, ConfigHelper.GetPostCodeHeadCount()); //如果第三位是0则获取前四位，否则获取前三位
                var citiesEntities =
                    cityEntitys.Where(c => c.PostCode.IndexOf(pchead, StringComparison.Ordinal) == 0).ToList();
                if (citiesEntities.Count() > 0)
                {
                    cityEntity = citiesEntities.FirstOrDefault(c => (order.CCity.Contains(c.Cityc.Trim()) || order.CCountyDistrict.Contains(c.Cityc.Trim())) &&
                                                                  order.CProvinceAutonomousRegion.Contains(c.Pc.Trim())) ??
                                cityEntitys.FirstOrDefault(c => (order.CCity.Contains(c.Cityc.Trim()) ||
                                                                           order.CCountyDistrict.Contains(c.Cityc.Trim())) &&
                                                                          order.CProvinceAutonomousRegion.Contains(c.Pc.Trim()));
                    if (cityEntity == null)
                    {
                        cityEntity = citiesEntities.FirstOrDefault();
                    }
                }
            }
            else
            {
                cityEntity =
                        cityEntitys.FirstOrDefault(
                            c => (order.CCity.Contains(c.Cityc.Trim()) || order.CCountyDistrict.Contains(c.Cityc.Trim())) && order.CProvinceAutonomousRegion.Contains(c.Pc.Trim()));
            }
            if (cityEntity == null)
            {
                cityEntity = new CitiesEntity();
            }
            #endregion

            return cityEntity;
        }

        private string TransNameToPin(string name)
        {
            var result = new StringBuilder();
            foreach (var c in name)
            {
                var en=TranslateHelper.JuHeZiDian(c.ToString());
                result.Append(en.ToUpper());
                result.Append(" ");
            }
            return result.Length>0?result.Remove(result.Length - 1, 1).ToString():"";
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
