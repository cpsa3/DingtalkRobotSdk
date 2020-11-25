using DingtalkRobotSdk.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DingtalkRobotSdk
{
    /// <summary>
    /// 钉钉机器人Client
    /// </summary>
    public class DingtalkClient
    {
        /// <summary>
        /// 异步发送dingding信息
        /// </summary>
        /// <param name="webHookUrl">webhook的url地址</param>
        /// <param name="message">消息model</param>
        /// <returns></returns>
        public static async Task<DingtalkJsonResult> SendMessageAsync(string webHookUrl, DingDingMessage message)
        {
            if (message == null || string.IsNullOrEmpty(webHookUrl))
            {
                return new DingtalkJsonResult
                {
                    errmsg = "参数不正确",
                    errcode = -1
                };
            }
            var json = message.ToJson();
            return await SendAsync(webHookUrl, json);
        }

        /// <summary>
        /// 异步请求
        /// </summary>
        /// <param name="webHookUrl"></param>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <param name="timeoutSec"></param>
        /// <returns></returns>
        private static async Task<DingtalkJsonResult> SendAsync(string webHookUrl,string data, string contentType = "application/json", double timeoutSec = 30)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromSeconds(timeoutSec);

                var content = new StringContent(data, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                var response = await httpClient.PostAsync(webHookUrl, content);
                var result = JsonConvert.DeserializeObject<DingtalkJsonResult>(await response.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                return new DingtalkJsonResult { errmsg = ex.Message, errcode = -1 };
            }
        }
    }
}
