using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessInterface;
using Component;

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
    }
}
