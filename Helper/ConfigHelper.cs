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
    }
}
