using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Entity;

namespace Helper
{
    public class TranslateHelper
    {
        public static string YouDaoC2E(string shouldTrans)
        {
            string result = "";
            var url = ConfigHelper.GetYouDaoUrl();
            url +="&q=" + shouldTrans;
            var response=HttpHelper.SendGetRequest(url, null, Encoding.UTF8, Encoding.UTF8);

            if (!string.IsNullOrEmpty(response))
            {
                var jsonhelper = new JsonHelper();
                var entity=jsonhelper.JsonDeserialize<YouDaoTransEntity>(response);
                result = entity.translation.FirstOrDefault();
            }

            return result;
        }
    }
}
