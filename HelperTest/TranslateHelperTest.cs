using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            string shouldTrans = "张店区"; // TODO: 初始化为适当的值
            string actual;
            actual = TranslateHelper.YouDaoC2E(shouldTrans);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void JuHeZiDianTest()
        {
            string shouldTrans = "张"; // TODO: 初始化为适当的值
            string actual;
            actual = TranslateHelper.JuHeZiDian(shouldTrans);
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void Print() {
            var dic = new Dictionary<string, string>();
            dic.Add("dictrict", "区");
            dic.Add("county", "县");
            dic.Add("town", "镇");
            var jsonhelper=new JsonHelper();
            string str = jsonhelper.JsonSerializer(dic);
            var data = "[{'Key':'dictrict','Value':'区'},{'Key':'county','Value':'县'},{'Key':'town','Value':'镇'}]".Replace("'", "\"");
            var dd = jsonhelper.JsonDeserialize<Dictionary<string, string>>(data);
            Console.Write(str);
        }

        [TestMethod]
        public void TestTransCountyToPinYin()
        {
            var data = "海淀黄庄";
            var result = TranslateHelper.TransCountyToPinYin(data);
            Assert.IsFalse(result.PinYin=="");
        }

        [TestMethod]
        public void TestHanZi2PinYin()
        {
            var data = "海淀黄庄";
            var result = TranslateHelper.HanZi2PinYin(data);
            Assert.IsFalse(result == "");
        }

        [TestMethod]
        public void TestUpper()
        {
            var data = "Institut Caméane";
            var result = data.ToUpper();
            Assert.IsFalse(result == "");
        }

        [TestMethod]
        public void TestGetAddress()
        {
            var data = "上海 上海市 浦东新区 唐镇创新西路333号 唐丰苑 27号楼801 DAx(450016)";
            var result = CityHelper.GetAddress(data);
            Assert.IsFalse(result=="");
        }

    }
}
