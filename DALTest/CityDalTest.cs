using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entity;
using System.Collections.Generic;

namespace DALTest
{
    
    
    /// <summary>
    ///这是 CityDalTest 的测试类，旨在
    ///包含所有 CityDalTest 单元测试
    ///</summary>
    [TestClass()]
    public class CityDalTest
    {
        /// <summary>
        ///Insert 的测试
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            CityDal target = new CityDal(); // TODO: 初始化为适当的值
            List<CitiesEntity> cities = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = target.Insert(cities);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
