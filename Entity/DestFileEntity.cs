using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class DestFileEntity
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId{get;set;}
        /// <summary>
        /// 法国邮政订单号
        /// </summary>
        public string LbfOrderNumber{get;set;}
        /// <summary>
        /// 下单时间
        /// </summary>
        public string DateOrder{get;set;}
        /// <summary>
        /// 法国公司名称
        /// </summary>
        public string FrenchCompanyName{get;set;}
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string Brand{get;set;}
        /// <summary>
        /// 英文或法文产品名称
        /// </summary>
        public string EFullProductName{get;set;}
        /// <summary>
        /// EAN号码/条码号码	每个产品自带的条码号码，即参照文件ExportOrderDetailList中的商家编码
        /// </summary>
        public string ProductRef{get;set;}
        /// <summary>
        /// 购买数量
        /// </summary>
        public int Quantity{get;set;}
        /// <summary>
        /// 销售价格/每件(RMB)
        /// </summary>
        public decimal PricePerUnit{get;set;}
        /// <summary>
        /// 买家得到的优惠金额
        /// "根据公式Minimum Sales Price - Settlement_amount (RMB)计算。
        /// 如果遇到一个订单包含多个产品，可以先将多个产品的售价相加后进行计算＊Minimum Sales Price可以从LBF _Catalogue Produits得到，
        /// Settlement_amount (RMB)从ExportOrderList得到"
        /// </summary>
        public decimal CouponsRewards{get;set;}
        /// <summary>
        /// 买家支付的运费
        /// </summary>
        public string ShippingFees{get;set;}
        /// <summary>
        /// 买家最后支付货款的金额
        /// </summary>
        public decimal SettlementAmount{get;set;}
        /// <summary>
        /// 收件人英文姓名，通过软件自动翻译
        /// </summary>
        public string ERecipientName {get;set;}
        /// <summary>
        /// 设定为中国，遇到港澳台的情况，全部放入该栏，然后分别将台湾放入省，香港和澳门放入市一栏
        /// </summary>
        public string Country{get;set;}
        /// <summary>
        /// 省名英文翻译，根据中英文对照表格China province_city_postcode搜索得到
        /// </summary>
        public string ProvinceAutonomousRegion{get;set;}
        /// <summary>
        /// 市名英文翻译，根据中英文对照表格China province_city_postcode搜索得到
        /// </summary>
        public string City{get;set;}
        /// <summary>
        /// 搜索中文地址栏得到，需要设置成text格式，而不是数字格式。部分邮编以“0”开头。港澳台地区邮编从收货地址直接得到，无需再与China province_city_postcode进行对照
        /// </summary>
        public string PostCode{get;set;}
        /// <summary>
        /// 县名/镇名/区名
        /// </summary>
        public string CountyDistrict {get;set;}
        /// <summary>
        /// 英文地址
        /// </summary>
        public string AddressDetails { get; set; }
        /// <summary>
        /// 收件人电话号码	需要设置成text格式，而不是数字格式，手机号码以“1”开头
        /// </summary>
        public string ConsigneePhoneNumber{get;set;}
        /// <summary>
        /// 中文产品名称
        /// </summary>
        public string CFullProductName{get;set;}
        /// <summary>
        /// 收件人中文名称
        /// </summary>
        public string CRecipientName{get;set;}
        /// <summary>
        /// 收件人中文地址
        /// </summary>
        public string CDeliveryAddress{get;set;}
    }
}
