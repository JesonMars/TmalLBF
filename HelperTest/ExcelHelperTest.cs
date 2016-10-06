using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelperTest
{
    [TestClass]
    public class ExcelHelperTest
    {
        [TestMethod]
        public void TestGetDataBySheetName()
        {
            var excel = new ExcelHelper(@"\\vmware-host\Shared Folders\桌面\Fwd_ 用户订单文件开发\Chinaprovince_city.xls");
            var rows=excel.GetDataBySheetName(1);
            Assert.IsNotNull(rows);
        }

        [TestMethod]
        public void TestGetDicsBySheetName()
        {
            var excel = new ExcelHelper(@"\\vmware-host\Shared Folders\桌面\Fwd_ 用户订单文件开发\Chinaprovince_city.xls");
            var headers=new List<string>();
            headers.Add("Province");
            headers.Add("");
            headers.Add("City/County/Prefecture");
            headers.Add("");
            var rows = excel.GetDicsExceptHeader(1);
            Assert.IsNotNull(rows);
        }

        [TestMethod]
        public void TestIsExcel()
        {
            var rows = ExcelHelper.IsExcel(@"\\vmware-host\Shared Folders\桌面\Fwd_ 用户订单文件开发\Chinaprovince_city.xls");
            Assert.IsTrue(rows);
        }

        [TestMethod]
        public void TestGetAllSheetData()
        {
            var rows =new ExcelHelper(@"\\vmware-host\Shared Folders\桌面\Fwd_ 用户订单文件开发\Chinaprovince_city.xls");
            var data = rows.GetAllSheetData();
            Assert.IsNotNull(data);
            foreach (var list in data)
            {
                foreach (var s in list)
                {
                    Console.Write(String.Format(@"{0} ",s));
                }
                Console.WriteLine();
            }
        }

    }
}
