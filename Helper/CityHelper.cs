using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public class CityHelper
    {
        /// <summary>
        /// 是否是直辖市
        /// </summary>
        /// <param name="province">省份</param>
        /// <param name="city">城市</param>
        /// <returns>true，属于直辖市；false，不属于直辖市</returns>
        public static bool IsMunicipality(string province,string city)
        {
            return city.Contains(province);
        }
    }
}
