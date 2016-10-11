using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace HelperTest
{
    
    
    /// <summary>
    ///这是 JsonHelperTest 的测试类，旨在
    ///包含所有 JsonHelperTest 单元测试
    ///</summary>
    [TestClass()]
    public class JsonHelperTest
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
        ///JsonHelper 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void JsonHelperConstructorTest()
        {
            Encoding e = null; // TODO: 初始化为适当的值
            JsonHelper target = new JsonHelper(e);
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///JsonHelper 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void JsonHelperConstructorTest1()
        {
            JsonHelper target = new JsonHelper();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///ConvertDateStringToJsonDate 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void ConvertDateStringToJsonDateTest()
        {
            Match m = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = JsonHelper_Accessor.ConvertDateStringToJsonDate(m);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ConvertJsonDateToDateString 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void ConvertJsonDateToDateStringTest()
        {
            Match m = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = JsonHelper_Accessor.ConvertJsonDateToDateString(m);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeserializeJsonToObject 的测试
        ///</summary>
        public void DeserializeJsonToObjectTestHelper<T>()
            where T : class
        {
            JsonHelper target = new JsonHelper(); // TODO: 初始化为适当的值
            string json = string.Empty; // TODO: 初始化为适当的值
            T expected = null; // TODO: 初始化为适当的值
            T actual;
            actual = target.DeserializeJsonToObject<T>(json);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        [TestMethod()]
        public void DeserializeJsonToObjectTest()
        {
            DeserializeJsonToObjectTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///JsonDeserialize 的测试
        ///</summary>
        [TestMethod()]
        public void JsonDeserializeTest()
        {
            JsonHelper target = new JsonHelper(); // TODO: 初始化为适当的值
            string jsonString = string.Empty; // TODO: 初始化为适当的值
            Type t = null; // TODO: 初始化为适当的值
            object expected = null; // TODO: 初始化为适当的值
            object actual;
            actual = target.JsonDeserialize(jsonString, t);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///JsonDeserialize 的测试
        ///</summary>
        public void JsonDeserializeTest1Helper<T>()
        {
            JsonHelper target = new JsonHelper(); // TODO: 初始化为适当的值
            string jsonString = string.Empty; // TODO: 初始化为适当的值
            T expected = default(T); // TODO: 初始化为适当的值
            T actual;
            actual = target.JsonDeserialize<T>(jsonString);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        [TestMethod()]
        public void JsonDeserializeTest1()
        {
            JsonDeserializeTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///JsonDeserializeNoTime 的测试
        ///</summary>
        public void JsonDeserializeNoTimeTestHelper<T>()
        {
            JsonHelper target = new JsonHelper(); // TODO: 初始化为适当的值
            string jsonString = string.Empty; // TODO: 初始化为适当的值
            T expected = default(T); // TODO: 初始化为适当的值
            T actual;
            actual = target.JsonDeserializeNoTime<T>(jsonString);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        [TestMethod()]
        public void JsonDeserializeNoTimeTest()
        {
            JsonDeserializeNoTimeTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///JsonSerializer 的测试
        ///</summary>
        public void JsonSerializerTestHelper<T>()
        {
            JsonHelper target = new JsonHelper(); // TODO: 初始化为适当的值
            T t = default(T); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.JsonSerializer<T>(t);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        [TestMethod()]
        public void JsonSerializerTest()
        {
            JsonSerializerTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///JsonSerializer 的测试
        ///</summary>
        [TestMethod()]
        public void JsonSerializerTest1()
        {
            JsonHelper target = new JsonHelper(); // TODO: 初始化为适当的值
            object obj = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.JsonSerializer(obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///NewtonsoftSerializeObject 的测试
        ///</summary>
        [TestMethod()]
        public void NewtonsoftSerializeObjectTest()
        {
            JsonHelper target = new JsonHelper(); // TODO: 初始化为适当的值
            object obj = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.NewtonsoftSerializeObject(obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
