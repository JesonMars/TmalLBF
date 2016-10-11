using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Component;
using Entity;
using BusinessInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentTest
{
    /// <summary>
    /// FactoryTest 的摘要说明
    /// </summary>
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void TestInstance()
        {
            var result=Factory.Instance();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result,typeof(Factory));
        }

        [TestMethod]
        public void TestGetService()
        {
            var result = Factory.Instance();
            var testentity=result.GetService<IBaseBusiness>();
            //Console.Write(testentity.test("get service success"));
            Assert.IsNotNull(testentity);
            Assert.IsInstanceOfType(testentity, typeof(IBaseBusiness));
        }

        [TestMethod]
        public void TestGetServiceLoad()
        {
            var result = Factory.Instance();
            var testentity = result.GetServiceByLoad<IBaseBusiness>();
           // Console.Write(testentity.test("get service load success"));
            Assert.IsNotNull(testentity);
            Assert.IsInstanceOfType(testentity, typeof(IBaseBusiness));
        }
    }
}
