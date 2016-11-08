using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Business;
using Business.DestMake;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessTest
{
    /// <summary>
    /// MakeBaseBusinessTest 的摘要说明
    /// </summary>
    [TestClass]
    public class MakeBaseBusinessTest:MakeBaseBusiness
    {
        public MakeBaseBusinessTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        [TestMethod]
        public void TestInitDataList()
        {
            var entity = new MakeDestEntity();
            entity.OrderListFile = @"D:\g\outsource\TmallLBF\TmalLBF\Archive\ExportOrderList201609231016.xlsx";
            entity.OrderDetailListFile = @"D:\g\outsource\TmallLBF\TmalLBF\Archive\ExportOrderDetailList2016092310161.xlsx";
            var business = new MakeDestBusiness();
            entity.IsMakeCsv = true;
            entity.IsMakeXlsx = true;
            entity.IsMakeXls = true;
            entity.DestFolder = @"D:\g\outsource\TmallLBF\TmalLBF\Archive";
            var result=business.Make(entity);
            //var result=InitDestFileEntitys(entity);
            Assert.IsNull(result);
        }


        public override string Extension
        {
            get { throw new NotImplementedException(); }
        }

        public override string CreateFile()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestFtp()
        {
            var rresult = this.PushFileToFtp(@"\\vmware-host\Shared Folders\桌面\bank\bank-names.txt");
        }
    }
}
