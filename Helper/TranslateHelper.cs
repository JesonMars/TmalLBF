using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using Entity;

namespace Helper
{
    public class TranslateHelper
    {
        public static string YouDaoC2E(string shouldTrans)
        {
            string result = "";
            try
            {
                var url = ConfigHelper.GetYouDaoUrl();
                url += "&q=" + shouldTrans;
                var response = HttpHelper.SendGetRequest(url, null, Encoding.UTF8, Encoding.UTF8);

                if (!string.IsNullOrEmpty(response))
                {
                    var jsonhelper = new JsonHelper();
                    var entity = jsonhelper.JsonDeserialize<YouDaoTransEntity>(response);
                    result = entity.translation.FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                LogHelper.Log(exception.Message,exception,LogHelper.LogType.Error);
            }

            return result;
        }

        public static string JuHeZiDian(string data)
        {
            string result = "";
            try
            {
                var url = ConfigHelper.GetJuHeZiDianUrl();
                url +=data;
                var response = HttpHelper.SendGetRequest(url, null, Encoding.UTF8, Encoding.UTF8);

                if (!string.IsNullOrEmpty(response))
                {
                    var jsonhelper = new JsonHelper();
                    var entity = jsonhelper.JsonDeserialize<JuHeZiDianEntity>(response);
                    result = (entity!=null && entity.result!=null) ?entity.result.py:"";
                }
            }
            catch (Exception exception)
            {
                LogHelper.Log(exception.Message, exception, LogHelper.LogType.Error);
            }

            return result;
        }
    }
}
