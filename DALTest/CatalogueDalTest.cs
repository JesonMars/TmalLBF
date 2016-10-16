using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DALTest
{
    /// <summary>
    /// CatalogueDalTest 的摘要说明
    /// </summary>
    [TestClass]
    public class CatalogueDalTest
    {
        public CatalogueDalTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        [TestMethod]
        public void SelectListTest()
        {
            var entity = new CatalogueEntity();
            entity.EBrand = "Baghera";
            entity.ProductRef = "882";
            var dal = new CatalogueDal();
            var result=dal.SelectList(entity);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count>0);
        }
    }
}
