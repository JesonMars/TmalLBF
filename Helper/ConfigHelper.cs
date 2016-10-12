using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Helper
{
    public class ConfigHelper
    {
        private static string GetAppSetting(string key)
        {
            var result=ConfigurationSettings.AppSettings.Get(key);
            return string.IsNullOrEmpty(result) ? "" : result;
        }
        public static string GetBusinessSuffix()
        {
            return GetAppSetting("BusinessSuffix");
        }

        public static string GetDalSuffix()
        {
            return GetAppSetting("DalSuffix");
        }

        public static string GetEntitySuffix()
        {
            return GetAppSetting("EntitySuffix");
        }

        public static string GetYouDaoUrl()
        {
            var youdaourl = GetAppSetting("youdaourl");
            return youdaourl.Replace("|", "&");
        }

        public static string GetExcelExtesion()
        {
            var exten=GetAppSetting("exceltype");
            return exten;
        }

        public static string GetDestFileName()
        {
            var name =new StringBuilder(GetAppSetting("destfilename"));
            name.Append(DateTime.Now.ToString("Mddyyyy"));
            return name.ToString();
        }
        public static string GetPostCodeRegex()
        {
            var name = new StringBuilder(GetAppSetting("postcoderegex"));
            return name.ToString();
        }
    }
}
