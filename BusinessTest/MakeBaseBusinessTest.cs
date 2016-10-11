using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
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
            entity.OrderListFile = @"\\vmware-host\Shared Folders\桌面\Archive\ExportOrderList201609231016.xltx";
            entity.OrderDetailListFile = @"\\vmware-host\Shared Folders\桌面\Archive\ExportOrderDetailList2016092310161.xlsx";
            var result=InitDataList(entity);
            Assert.IsTrue(result);
        }


        public override string Extension
        {
            get { throw new NotImplementedException(); }
        }

        public override string CreateFile()
        {
            throw new NotImplementedException();
        }
    }
}
