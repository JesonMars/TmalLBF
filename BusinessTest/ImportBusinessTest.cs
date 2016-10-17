using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessInterface;
using Component;
using System.Text.RegularExpressions;
using log4net;

namespace ComponentTest
{
    /// <summary>
    ///这是 ImportBusinessTest 的测试类，旨在
    ///包含所有 ImportBusinessTest 单元测试
    ///</summary>
    [TestClass]
    public class ImportBusinessTest
    {
        [TestMethod]
        public void TestImportCitiesFromExcel()
        {
            LogManager.GetLogger(typeof(ImportBusinessTest)).Info("run",new Exception("hhahaha"));
            var factory = Factory.Instance().GetService<IImportBusiness>();
            var result=factory.ImportCitiesFromExcel(@"\\vmware-host\Shared Folders\桌面\Fwd_ 用户订单文件开发\Chinaprovince_city.xls");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestImportArcancilFromExcel()
        {
            var factory = Factory.Instance().GetService<IImportBusiness>();
            var result = factory.ImportArcancilFromExcel(@"\\vmware-host\Shared Folders\桌面\Fwd_ 用户订单文件开发\arcancil20productlist.xlsx");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestImportCatalogueFromExcel()
        {
            var factory = Factory.Instance().GetService<IImportBusiness>();
            var result = factory.ImportCatalogueFromExcel(@"\\vmware-host\Shared Folders\桌面\Archive\LBF _Catalogue Produits Nom de la Marque Cliente V02.xlsx");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRegex() {
            var str = "浙江省 宁波市 余姚市 朗霞街道创业园区北路七号 家家超市(315400)";
            var regex = @"\([0-9a-zA-Z]{6,10}\)";
            var result=Regex.Match(str,regex);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Value));
        }

    }
}
