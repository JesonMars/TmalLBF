using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;

namespace HelperTest
{
    
    
    /// <summary>
    ///这是 FtpHelperTest 的测试类，旨在
    ///包含所有 FtpHelperTest 单元测试
    ///</summary>
    [TestClass()]
    public class FtpHelperTest
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
        ///FtpHelper 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void FtpHelperConstructorTest()
        {
            string ftpServerIP = string.Empty; // TODO: 初始化为适当的值
            string ftpRemotePath = string.Empty; // TODO: 初始化为适当的值
            string ftpUserID = string.Empty; // TODO: 初始化为适当的值
            string ftpPassword = string.Empty; // TODO: 初始化为适当的值
            FtpHelper target = new FtpHelper(ftpServerIP, ftpRemotePath, ftpUserID, ftpPassword);
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///AppendFile 的测试
        ///</summary>
        [TestMethod()]
        public void AppendFileTest()
        {
            string ftpServerIP = string.Empty; // TODO: 初始化为适当的值
            string ftpRemotePath = string.Empty; // TODO: 初始化为适当的值
            string ftpUserID = string.Empty; // TODO: 初始化为适当的值
            string ftpPassword = string.Empty; // TODO: 初始化为适当的值
            FtpHelper target = new FtpHelper(ftpServerIP, ftpRemotePath, ftpUserID, ftpPassword); // TODO: 初始化为适当的值
            byte[] fileInfo = null; // TODO: 初始化为适当的值
            string fileName = string.Empty; // TODO: 初始化为适当的值
            target.AppendFile(fileInfo, fileName);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///AppendFile 的测试
        ///</summary>
        [TestMethod()]
        public void AppendFileTest1()
        {
            string ftpServerIP = string.Empty; // TODO: 初始化为适当的值
            string ftpRemotePath = string.Empty; // TODO: 初始化为适当的值
            string ftpUserID = string.Empty; // TODO: 初始化为适当的值
            string ftpPassword = string.Empty; // TODO: 初始化为适当的值
            FtpHelper target = new FtpHelper(ftpServerIP, ftpRemotePath, ftpUserID, ftpPassword); // TODO: 初始化为适当的值
            string fileInfo = string.Empty; // TODO: 初始化为适当的值
            string fileName = string.Empty; // TODO: 初始化为适当的值
            target.AppendFile(fileInfo, fileName);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///CreateDirectory 的测试
        ///</summary>
        [TestMethod()]
        public void CreateDirectoryTest()
        {
            string ftpServerIP = string.Empty; // TODO: 初始化为适当的值
            string ftpRemotePath = string.Empty; // TODO: 初始化为适当的值
            string ftpUserID = string.Empty; // TODO: 初始化为适当的值
            string ftpPassword = string.Empty; // TODO: 初始化为适当的值
            FtpHelper target = new FtpHelper(ftpServerIP, ftpRemotePath, ftpUserID, ftpPassword); // TODO: 初始化为适当的值
            string remoteDirectoryName = string.Empty; // TODO: 初始化为适当的值
            target.CreateDirectory(remoteDirectoryName);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///DeleteFile 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteFileTest()
        {
            string ftpServerIP = string.Empty; // TODO: 初始化为适当的值
            string ftpRemotePath = string.Empty; // TODO: 初始化为适当的值
            string ftpUserID = string.Empty; // TODO: 初始化为适当的值
            string ftpPassword = string.Empty; // TODO: 初始化为适当的值
            FtpHelper target = new FtpHelper(ftpServerIP, ftpRemotePath, ftpUserID, ftpPassword); // TODO: 初始化为适当的值
            string remoteFileName = string.Empty; // TODO: 初始化为适当的值
            target.DeleteFile(remoteFileName);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///GotoDirectory 的测试
        ///</summary>
        [TestMethod()]
        public void GotoDirectoryTest()
        {
            string ftpServerIP = string.Empty; // TODO: 初始化为适当的值
            string ftpRemotePath = string.Empty; // TODO: 初始化为适当的值
            string ftpUserID = string.Empty; // TODO: 初始化为适当的值
            string ftpPassword = string.Empty; // TODO: 初始化为适当的值
            FtpHelper target = new FtpHelper(ftpServerIP, ftpRemotePath, ftpUserID, ftpPassword); // TODO: 初始化为适当的值
            string DirectoryName = string.Empty; // TODO: 初始化为适当的值
            bool IsRoot = false; // TODO: 初始化为适当的值
            target.GotoDirectory(DirectoryName, IsRoot);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///IsExistFile 的测试
        ///</summary>
        [TestMethod()]
        public void IsExistFileTest()
        {
            string ftpServerIP = string.Empty; // TODO: 初始化为适当的值
            string ftpRemotePath = string.Empty; // TODO: 初始化为适当的值
            string ftpUserID = string.Empty; // TODO: 初始化为适当的值
            string ftpPassword = string.Empty; // TODO: 初始化为适当的值
            FtpHelper target = new FtpHelper(ftpServerIP, ftpRemotePath, ftpUserID, ftpPassword); // TODO: 初始化为适当的值
            string remoteName = string.Empty; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.IsExistFile(remoteName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ListFiles 的测试
        ///</summary>
        [TestMethod()]
        public void ListFilesTest()
        {
            string ftpServerIP = string.Empty; // TODO: 初始化为适当的值
            string ftpRemotePath = string.Empty; // TODO: 初始化为适当的值
            string ftpUserID = string.Empty; // TODO: 初始化为适当的值
            string ftpPassword = string.Empty; // TODO: 初始化为适当的值
            FtpHelper target = new FtpHelper(ftpServerIP, ftpRemotePath, ftpUserID, ftpPassword); // TODO: 初始化为适当的值
            List<string> expected = null; // TODO: 初始化为适当的值
            List<string> actual;
            actual = target.ListFiles();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///Open 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void OpenTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            FtpHelper_Accessor target = new FtpHelper_Accessor(param0); // TODO: 初始化为适当的值
            Uri uri = null; // TODO: 初始化为适当的值
            string ftpMethod = string.Empty; // TODO: 初始化为适当的值
            FtpWebResponse expected = null; // TODO: 初始化为适当的值
            FtpWebResponse actual;
            actual = target.Open(uri, ftpMethod);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///OpenRequest 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void OpenRequestTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            FtpHelper_Accessor target = new FtpHelper_Accessor(param0); // TODO: 初始化为适当的值
            Uri uri = null; // TODO: 初始化为适当的值
            string ftpMethod = string.Empty; // TODO: 初始化为适当的值
            FtpWebRequest expected = null; // TODO: 初始化为适当的值
            FtpWebRequest actual;
            actual = target.OpenRequest(uri, ftpMethod);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SetTimeOut 的测试
        ///</summary>
        [TestMethod()]
        public void SetTimeOutTest()
        {
            string ftpServerIP = string.Empty; // TODO: 初始化为适当的值
            string ftpRemotePath = string.Empty; // TODO: 初始化为适当的值
            string ftpUserID = string.Empty; // TODO: 初始化为适当的值
            string ftpPassword = string.Empty; // TODO: 初始化为适当的值
            FtpHelper target = new FtpHelper(ftpServerIP, ftpRemotePath, ftpUserID, ftpPassword); // TODO: 初始化为适当的值
            int timeOut = 0; // TODO: 初始化为适当的值
            target.SetTimeOut(timeOut);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///Upload 的测试
        ///</summary>
        [TestMethod()]
        public void UploadTest()
        {
            string ftpServerIP = string.Empty; // TODO: 初始化为适当的值
            string ftpRemotePath = string.Empty; // TODO: 初始化为适当的值
            string ftpUserID = string.Empty; // TODO: 初始化为适当的值
            string ftpPassword = string.Empty; // TODO: 初始化为适当的值
            FtpHelper target = new FtpHelper(ftpServerIP, ftpRemotePath, ftpUserID, ftpPassword); // TODO: 初始化为适当的值
            string localFilePath = string.Empty; // TODO: 初始化为适当的值
            target.Upload(localFilePath);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///ftpPassword 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void ftpPasswordTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            FtpHelper_Accessor target = new FtpHelper_Accessor(param0); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.ftpPassword = expected;
            actual = target.ftpPassword;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ftpRemotePath 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void ftpRemotePathTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            FtpHelper_Accessor target = new FtpHelper_Accessor(param0); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.ftpRemotePath = expected;
            actual = target.ftpRemotePath;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ftpServerIP 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void ftpServerIPTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            FtpHelper_Accessor target = new FtpHelper_Accessor(param0); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.ftpServerIP = expected;
            actual = target.ftpServerIP;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ftpURI 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void ftpURITest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            FtpHelper_Accessor target = new FtpHelper_Accessor(param0); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.ftpURI = expected;
            actual = target.ftpURI;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ftpUserID 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void ftpUserIDTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            FtpHelper_Accessor target = new FtpHelper_Accessor(param0); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            target.ftpUserID = expected;
            actual = target.ftpUserID;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///timeOut 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Helper.dll")]
        public void timeOutTest()
        {
            PrivateObject param0 = null; // TODO: 初始化为适当的值
            FtpHelper_Accessor target = new FtpHelper_Accessor(param0); // TODO: 初始化为适当的值
            int expected = 0; // TODO: 初始化为适当的值
            int actual;
            target.timeOut = expected;
            actual = target.timeOut;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
