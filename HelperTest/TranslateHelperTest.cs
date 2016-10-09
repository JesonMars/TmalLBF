using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HelperTest
{
    
    
    /// <summary>
    ///这是 TranslateHelperTest 的测试类，旨在
    ///包含所有 TranslateHelperTest 单元测试
    ///</summary>
    [TestClass]
    public class TranslateHelperTest
    {
        /// <summary>
        ///YouDaoC2E 的测试
        ///</summary>
        [TestMethod]
        public void YouDaoC2ETest()
        {
            string shouldTrans = "张王先"; // TODO: 初始化为适当的值
            string actual;
            actual = TranslateHelper.YouDaoC2E(shouldTrans);
            Assert.IsNotNull(actual);
        }
    }
}
