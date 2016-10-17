using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using log4net;
using log4net.Config;

namespace HelperTest
{
    
    
    /// <summary>
    ///这是 ConfigHelperTest 的测试类，旨在
    ///包含所有 ConfigHelperTest 单元测试
    ///</summary>
    [TestClass()]
    public class ConfigHelperTest
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ConfigHelperTest));
        public ConfigHelperTest()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.xml"));
        }
        /// <summary>
        ///GetDestFileName 的测试
        ///</summary>
        [TestMethod()]
        public void GetDestFileNameTest()
        {
            //LogManager.GetLogger(typeof(ConfigHelperTest)).Info("run here", new Exception("test log"));
            logger.Error("fd",new Exception("fdsfdsfdsfdsf"));
            string actual;
            actual = ConfigHelper.GetDestFileName();
            Assert.IsFalse(string.IsNullOrEmpty(actual));
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
