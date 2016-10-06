using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entity;
using System.Collections.Generic;

namespace DALTest
{
    
    
    /// <summary>
    ///这是 CrudBaseTest 的测试类，旨在
    ///包含所有 CrudBaseTest 单元测试
    ///</summary>
    [TestClass()]
    public class CrudBaseTest:CrudBase<CitiesEntity>
    {
        [TestMethod]
        public void DeleteAllTest()
        {
            var result=DeleteAll(new CitiesEntity());
            Assert.IsInstanceOfType(result,typeof (int));
            Assert.IsTrue(result>0);
        }

        [TestMethod]
        public void TestSelectLast()
        {
            var curlBase=new CrudBase<FtpConfigEntity>();
            var city=curlBase.SelectLast();
            Assert.IsNotNull(city);
            Assert.IsInstanceOfType(city, typeof(FtpConfigEntity));
        }

        [TestMethod]
        public void TestInsert()
        {
            var curlBase = new CrudBase<FtpConfigEntity>();
            var entity=new FtpConfigEntity();
            entity.FtpHost = "192.168.12.1";
            entity.FtpPassword = "123";
            entity.FtpUserName = "haha";
            entity.Ctime = DateTime.Now;

            var result = curlBase.Insert(entity);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 0);
        }
    }
}
