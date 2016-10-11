﻿using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HelperTest
{
    
    
    /// <summary>
    ///这是 FileStructTest 的测试类，旨在
    ///包含所有 FileStructTest 单元测试
    ///</summary>
    [TestClass()]
    public class FileStructTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///FileStruct 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void FileStructConstructorTest()
        {
            FileStruct target = new FileStruct();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///CreateTime 的测试
        ///</summary>
        [TestMethod()]
        public void CreateTimeTest()
        {
            FileStruct target = new FileStruct(); // TODO: 初始化为适当的值
            DateTime expected = new DateTime(); // TODO: 初始化为适当的值
            DateTime actual;
            target.CreateTime = expected;
            actual = target.CreateTime;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///IsDirectory 的测试
        ///</summary>
        [TestMethod()]
        public void IsDirectoryTest()
        {
            FileStruct target = new FileStruct(); // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            target.IsDirectory = expected;
            actual = target.IsDirectory;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///Name 的测试
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            FileStruct target = new FileStruct(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///Path 的测试
        ///</summary>
        [TestMethod()]
        public void PathTest()
        {
            FileStruct target = new FileStruct(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.Path = expected;
            actual = target.Path;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
