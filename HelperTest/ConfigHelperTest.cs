using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HelperTest
{
    
    
    /// <summary>
    ///这是 ConfigHelperTest 的测试类，旨在
    ///包含所有 ConfigHelperTest 单元测试
    ///</summary>
    [TestClass()]
    public class ConfigHelperTest
    {


        /// <summary>
        ///ConfigHelper 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ConfigHelperConstructorTest()
        {
            ConfigHelper target = new ConfigHelper();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///GetAppSetting 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void GetAppSettingTest()
        {
            string key = string.Empty; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConfigHelper_Accessor.GetAppSetting(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetBusinessSuffix 的测试
        ///</summary>
        [TestMethod()]
        public void GetBusinessSuffixTest()
        {
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConfigHelper.GetBusinessSuffix();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetDalSuffix 的测试
        ///</summary>
        [TestMethod()]
        public void GetDalSuffixTest()
        {
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConfigHelper.GetDalSuffix();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetDestFileName 的测试
        ///</summary>
        [TestMethod()]
        public void GetDestFileNameTest()
        {
            string actual;
            actual = ConfigHelper.GetDestFileName();
            Assert.IsFalse(string.IsNullOrEmpty(actual));
        }

        /// <summary>
        ///GetEntitySuffix 的测试
        ///</summary>
        [TestMethod()]
        public void GetEntitySuffixTest()
        {
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConfigHelper.GetEntitySuffix();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetExcelExtesion 的测试
        ///</summary>
        [TestMethod()]
        public void GetExcelExtesionTest()
        {
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConfigHelper.GetExcelExtesion();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetYouDaoUrl 的测试
        ///</summary>
        [TestMethod()]
        public void GetYouDaoUrlTest()
        {
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = ConfigHelper.GetYouDaoUrl();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
