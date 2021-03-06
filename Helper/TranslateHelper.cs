﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
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

        public static string HanZi2PinYin(string data)
        {
            string result = "";
            try
            {
                var url = ConfigHelper.GetHanZi2PinYinUrl();
                url = string.Format(url, DateTime.Now.ToString("yyyyMMddHHmmss"), data);
                var response = HttpHelper.SendGetRequest(url, null, Encoding.UTF8, Encoding.UTF8);

                if (!string.IsNullOrEmpty(response))
                {
                    var jsonhelper = new JsonHelper();
                    var entity = jsonhelper.JsonDeserialize<HanZi2PinYinEntity>(response);
                    //LogHelper.Log(response, null, LogHelper.LogType.Info);
                    result = (entity != null && entity.showapi_res_body != null) ? entity.showapi_res_body.data : "";
                }
                Thread.Sleep(500);
            }
            catch (Exception exception)
            {
                LogHelper.Log(exception.Message, exception, LogHelper.LogType.Error);
            }

            return result;
        }

        public static string JuHeZiDianBetch(string data)
        {
            StringBuilder result = new StringBuilder();
            if (string.IsNullOrEmpty(data))
            {
                return result.ToString();
            }
            try
            {
                var getJuheZiDianUrl = ConfigHelper.GetJuHeZiDianUrl();
                data.ToList().ForEach(x =>
                {
                    var url = getJuheZiDianUrl + x;
                    var response = HttpHelper.SendGetRequest(url, null, Encoding.UTF8, Encoding.UTF8);

                    if (!string.IsNullOrEmpty(response))
                    {
                        var jsonhelper = new JsonHelper();
                        var entity = jsonhelper.JsonDeserialize<JuHeZiDianEntity>(response);
                        result.Append(string.Format("{0} ", ((entity != null && entity.result != null) ? entity.result.py : "")));
                    }
                });
            }
            catch (Exception exception)
            {
                LogHelper.Log(exception.Message, exception, LogHelper.LogType.Error);
            }

            return result.ToString();
        }

        /// <summary>
        /// 地区翻译为拼音
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static TransCountyToPinYinEntity TransCountyToPinYin(string data)
        {
            var result=new TransCountyToPinYinEntity() { 
                    IsNormal=true,PinYin=""
                };
            if (string.IsNullOrEmpty(data)){
                result.IsNormal = false;
                return result;
            }

            //获取区、县、镇
            var countyStr = ConfigHelper.GetCounty();
            var fanyidicsstr = ConfigHelper.GetFanYiDics();
            var jsonHelper = new JsonHelper();
            var fanyidics = jsonHelper.JsonDeserialize<Dictionary<string, string>>(fanyidicsstr);
            if (fanyidics.ContainsKey(data))
            {
                result.PinYin = fanyidics[data];
                return result;
            }

            var countyDics = jsonHelper.JsonDeserialize<Dictionary<string, string>>(countyStr);
            var last = data.Last();
            var lastEn = countyDics.FirstOrDefault(x => x.Value == last.ToString());
            if (lastEn.Key!=(null)) {
                data = data.Substring(0,data.Length - 1);
            }
            var pinyin = TranslateHelper.HanZi2PinYin(data);
            if (!string.IsNullOrEmpty(pinyin)) {
                pinyin += lastEn.Key == (null) ? "" : string.Format(" {0}", lastEn.Key);
            }
            if (lastEn.Key == null) {
                result.IsNormal = false;
            }
            result.PinYin = pinyin;

            return result;
        }
    }
}
