using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.Web;
using System.Collections.Generic;

namespace HelperTest
{
    
    
    /// <summary>
    ///这是 HttpHelperTest 的测试类，旨在
    ///包含所有 HttpHelperTest 单元测试
    ///</summary>
    [TestClass()]
    public class HttpHelperTest
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
        ///HttpHelper 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void HttpHelperConstructorTest()
        {
            HttpHelper target = new HttpHelper();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///BuilderGetRequestUrl 的测试
        ///</summary>
        [TestMethod()]
        public void BuilderGetRequestUrlTest()
        {
            string baseurl = string.Empty; // TODO: 初始化为适当的值
            NameValueCollection parameters = null; // TODO: 初始化为适当的值
            Encoding reqencode = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.BuilderGetRequestUrl(baseurl, parameters, reqencode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///BuilderGetRequestUrlNoEncode 的测试
        ///</summary>
        [TestMethod()]
        public void BuilderGetRequestUrlNoEncodeTest()
        {
            string baseurl = string.Empty; // TODO: 初始化为适当的值
            NameValueCollection parameters = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.BuilderGetRequestUrlNoEncode(baseurl, parameters);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ConfigHttpWebRequest 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void ConfigHttpWebRequestTest()
        {
            HttpWebRequest req = null; // TODO: 初始化为适当的值
            int timeout = 0; // TODO: 初始化为适当的值
            HttpHelper_Accessor.ConfigHttpWebRequest(req, timeout);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///EncodeString 的测试
        ///</summary>
        [TestMethod()]
        public void EncodeStringTest()
        {
            string input = string.Empty; // TODO: 初始化为适当的值
            Encoding desEncoding = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.EncodeString(input, desEncoding);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///EncodeString 的测试
        ///</summary>
        [TestMethod()]
        public void EncodeStringTest1()
        {
            string input = string.Empty; // TODO: 初始化为适当的值
            Encoding srcEncoding = null; // TODO: 初始化为适当的值
            Encoding desEncoding = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.EncodeString(input, srcEncoding, desEncoding);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetRequestParameters 的测试
        ///</summary>
        [TestMethod()]
        public void GetRequestParametersTest()
        {
            HttpRequest request = null; // TODO: 初始化为适当的值
            Encoding encode = null; // TODO: 初始化为适当的值
            NameValueCollection expected = null; // TODO: 初始化为适当的值
            NameValueCollection actual;
            actual = HttpHelper.GetRequestParameters(request, encode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetRequestParameters 的测试
        ///</summary>
        [TestMethod()]
        public void GetRequestParametersTest1()
        {
            HttpRequest request = null; // TODO: 初始化为适当的值
            string encode = string.Empty; // TODO: 初始化为适当的值
            NameValueCollection expected = null; // TODO: 初始化为适当的值
            NameValueCollection actual;
            actual = HttpHelper.GetRequestParameters(request, encode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ParseQueryString 的测试
        ///</summary>
        [TestMethod()]
        public void ParseQueryStringTest()
        {
            HttpHelper target = new HttpHelper(); // TODO: 初始化为适当的值
            string input = string.Empty; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            NameValueCollection expected = null; // TODO: 初始化为适当的值
            NameValueCollection actual;
            actual = target.ParseQueryString(input, encoding);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///PostAndRedirect 的测试
        ///</summary>
        [TestMethod()]
        public void PostAndRedirectTest()
        {
            string url = string.Empty; // TODO: 初始化为适当的值
            NameValueCollection parameters = null; // TODO: 初始化为适当的值
            HttpContext context = null; // TODO: 初始化为适当的值
            HttpHelper.PostAndRedirect(url, parameters, context);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///PostJsonDataToUrl 的测试
        ///</summary>
        [TestMethod()]
        public void PostJsonDataToUrlTest()
        {
            string data = string.Empty; // TODO: 初始化为适当的值
            string url = string.Empty; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.PostJsonDataToUrl(data, url);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///PostJsonDataToUrl 的测试
        ///</summary>
        [TestMethod()]
        public void PostJsonDataToUrlTest1()
        {
            string data = string.Empty; // TODO: 初始化为适当的值
            string url = string.Empty; // TODO: 初始化为适当的值
            int timeout = 0; // TODO: 初始化为适当的值
            Dictionary<string, string> headers = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.PostJsonDataToUrl(data, url, timeout, headers);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///PostJsonDataToUrl 的测试
        ///</summary>
        [TestMethod()]
        public void PostJsonDataToUrlTest2()
        {
            byte[] data = null; // TODO: 初始化为适当的值
            string url = string.Empty; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.PostJsonDataToUrl(data, url);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///PostJsonDataToUrl 的测试
        ///</summary>
        [TestMethod()]
        public void PostJsonDataToUrlTest3()
        {
            byte[] data = null; // TODO: 初始化为适当的值
            string url = string.Empty; // TODO: 初始化为适当的值
            int timeout = 0; // TODO: 初始化为适当的值
            Dictionary<string, string> headers = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.PostJsonDataToUrl(data, url, timeout, headers);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SendGetRequest 的测试
        ///</summary>
        [TestMethod()]
        public void SendGetRequestTest()
        {
            string baseurl = string.Empty; // TODO: 初始化为适当的值
            NameValueCollection parameters = null; // TODO: 初始化为适当的值
            Encoding reqencode = null; // TODO: 初始化为适当的值
            Encoding resencode = null; // TODO: 初始化为适当的值
            int timeOut = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.SendGetRequest(baseurl, parameters, reqencode, resencode, timeOut);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SendGetRequest 的测试
        ///</summary>
        [TestMethod()]
        public void SendGetRequestTest1()
        {
            string url = string.Empty; // TODO: 初始化为适当的值
            string encodetype = string.Empty; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = HttpHelper.SendGetRequest(url, encodetype);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SendGetRequest 的测试
        ///</summary>
        [TestMethod()]
        public void SendGetRequestTest2()
        {
            string baseurl = string.Empty; // TODO: 初始化为适当的值
            NameValueCollection parameters = null; // TODO: 初始化为适当的值
            Encoding reqencode = null; // TODO: 初始化为适当的值
            Encoding resencode = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.SendGetRequest(baseurl, parameters, reqencode, resencode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SendJsonRequest 的测试
        ///</summary>
        public void SendJsonRequestTestHelper<T>()
        {
            string url = string.Empty; // TODO: 初始化为适当的值
            string method = string.Empty; // TODO: 初始化为适当的值
            T param = default(T); // TODO: 初始化为适当的值
            Action<HttpWebRequest> reqSetFunc = null; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            Func<T, string> serializeFunc = null; // TODO: 初始化为适当的值
            HttpHelper.ResponseInfo expected = null; // TODO: 初始化为适当的值
            HttpHelper.ResponseInfo actual;
            actual = HttpHelper.SendJsonRequest<T>(url, method, param, reqSetFunc, encoding, serializeFunc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        [TestMethod()]
        public void SendJsonRequestTest()
        {
            SendJsonRequestTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///SendPostRequest 的测试
        ///</summary>
        [TestMethod()]
        public void SendPostRequestTest()
        {
            string url = string.Empty; // TODO: 初始化为适当的值
            NameValueCollection parameters = null; // TODO: 初始化为适当的值
            Encoding reqencode = null; // TODO: 初始化为适当的值
            Encoding resencode = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.SendPostRequest(url, parameters, reqencode, resencode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SendPostRequest 的测试
        ///</summary>
        [TestMethod()]
        public void SendPostRequestTest1()
        {
            string url = string.Empty; // TODO: 初始化为适当的值
            string paras = string.Empty; // TODO: 初始化为适当的值
            string encodetype = string.Empty; // TODO: 初始化为适当的值
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = HttpHelper.SendPostRequest(url, paras, encodetype);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SendPostRequest 的测试
        ///</summary>
        [TestMethod()]
        public void SendPostRequestTest2()
        {
            string url = string.Empty; // TODO: 初始化为适当的值
            NameValueCollection parameters = null; // TODO: 初始化为适当的值
            Encoding reqencode = null; // TODO: 初始化为适当的值
            Encoding resencode = null; // TODO: 初始化为适当的值
            int timeOut = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.SendPostRequest(url, parameters, reqencode, resencode, timeOut);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SendQueryRequest 的测试
        ///</summary>
        [TestMethod()]
        public void SendQueryRequestTest()
        {
            string url = string.Empty; // TODO: 初始化为适当的值
            string method = string.Empty; // TODO: 初始化为适当的值
            NameValueCollection param = null; // TODO: 初始化为适当的值
            Action<HttpWebRequest> reqSetFunc = null; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            HttpHelper.ResponseInfo expected = null; // TODO: 初始化为适当的值
            HttpHelper.ResponseInfo actual;
            actual = HttpHelper.SendQueryRequest(url, method, param, reqSetFunc, encoding);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UrlDecode 的测试
        ///</summary>
        [TestMethod()]
        public void UrlDecodeTest()
        {
            string input = string.Empty; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.UrlDecode(input, encoding);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UrlEncode 的测试
        ///</summary>
        [TestMethod()]
        public void UrlEncodeTest()
        {
            string input = string.Empty; // TODO: 初始化为适当的值
            Encoding encoding = null; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = HttpHelper.UrlEncode(input, encoding);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DefaultTimeout 的测试
        ///</summary>
        [TestMethod()]
        public void DefaultTimeoutTest()
        {
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            HttpHelper.DefaultTimeout = expected;
            actual = HttpHelper.DefaultTimeout;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
