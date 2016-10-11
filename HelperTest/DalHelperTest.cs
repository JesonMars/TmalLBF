using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace HelperTest
{
    
    
    /// <summary>
    ///这是 DalHelperTest 的测试类，旨在
    ///包含所有 DalHelperTest 单元测试
    ///</summary>
    [TestClass()]
    public class DalHelperTest
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
        ///DalHelper 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void DalHelperConstructorTest()
        {
            DalHelper target = new DalHelper();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///ExecuteDataSet 的测试
        ///</summary>
        [TestMethod()]
        public void ExecuteDataSetTest()
        {
            string sql = string.Empty; // TODO: 初始化为适当的值
            SqlParameterCollection parameterCollection = null; // TODO: 初始化为适当的值
            DataSet expected = null; // TODO: 初始化为适当的值
            DataSet actual;
            actual = DalHelper.ExecuteDataSet(sql, parameterCollection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ExecuteNonQuery 的测试
        ///</summary>
        [TestMethod()]
        public void ExecuteNonQueryTest()
        {
            string sql = string.Empty; // TODO: 初始化为适当的值
            SqlParameterCollection parameterCollection = null; // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            actual = DalHelper.ExecuteNonQuery(sql, parameterCollection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetCon 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void GetConTest()
        {
            DbConnection expected = null; // TODO: 初始化为适当的值
            DbConnection actual;
            actual = DalHelper_Accessor.GetCon();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
