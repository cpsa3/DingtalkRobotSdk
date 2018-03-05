using DingtalkRobotSdk.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public static async Task<string> GetAsync(string url)
        {
            var httpClient = new HttpClient(new HttpClientHandler { UseCookies = false });
            httpClient.DefaultRequestHeaders.Add("Referer", "https://www.maccosmetics.com/esearch?form_id=perlgem_search_form&search=lunar");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.167 Safari/537.36");
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8,ja;q=0.7,zh-TW;q=0.6");
            httpClient.DefaultRequestHeaders.Add("Cookie", "_ga=GA1.2.315129244.1516279992; PSN=%7B%7D; SESSION=590147252-72a6f9c9aefde3e724f7aaf3e3213a5184f6e6e322139dc6cd213387f4565dfc; LOCALE=en_US; ngglobal=7d77ffed61902066; btcartcookie=; tms_generic_enable_bobo=1; AMCV_esteelauder=MCAID%7C2D304C5F852AA990-60000300600079DC; LPVID=ZmODNhMjIyZTcxMGNlNmJk; AKAMAI_DETECTED_LOCALE=cn_CN; AKA_A2=1; ak_bmsc=36E024A2E79F56E8A6E1CB8275B1BB6241980224502600004FFB905A968E6D27~plvi2C0KCCMdprJqAmNPYOKfMtJWIdu+a8bD4MDW9L/gvSW/93lFRAKTgrBl0snrVXUluGJmt56ueSShTApciJzIL+ul3xINlyOjCBYGvUHpqvJfaZKhFx6O4ApQyBWRbg8Oi7z1Qjz6SgqsHnbySnX9XJgzdABnLuV4cMPoGtYjghCPcyry0vCSuAiJmPxQrSi43+khO77kGvhqlX1oCe3sdZ/tIiweGW3a9dTjDaxpQ=; client.isMobile=0; has_js=1; _gid=GA1.2.1567997832.1519450962; _gac_UA-45704538-3=1.1519450962.CjwKCAiAlL_UBRBoEiwAXKgW5_dB4wGefgbjRjweQtPjtAV44egTy3QZNsWtzxpoCZgcxydMeFDinhoCIOMQAvD_BwE; MP_CONFIG=%7B%22language_id%22%3A48%2C%22country_id%22%3A1%7D; Auser=0%7C0%7C0%7C0%7C0%7C0%7C0%7C0%7C0-null; ngsession=3cb1614a52428856; s_cc=true; _gac_UA-109276500-2=1.1519450967.CjwKCAiAlL_UBRBoEiwAXKgW5_dB4wGefgbjRjweQtPjtAV44egTy3QZNsWtzxpoCZgcxydMeFDinhoCIOMQAvD_BwE; LPSID-48719195=OkyC4Tv4R_2ALLmgoaLO7w; __olapicU=1519450999207; SSESS387e0dc39e5148a83fc39223d3cab9f6=pUr6h8TfnS4I7DuH2nhD67ltfx32MFkNnUZiVk_trk0; SESS387e0dc39e5148a83fc39223d3cab9f6=65vMGO43rLz42hiK7jkVfa-PX7LrqYzQqrX8bn4Wv5I; s_sq=%5B%5BB%5D%5D; FE_USER_CART=available%3A%26csr_logged_in%3A0%26current_available%3A%26first_name%3A%26full_name%3A%26is_loyalty_member%3A0%26is_pro%3A0%26is_rewards_eligible%3A0%26item_count%3A%26loyalty_level%3A0%26loyalty_level_name%3A%26next_level%3A1%26next_level_name%3ASeduced%26pc_email_optin%3A0%26points%3A%26points_to_next_level%3A0%26region_id%3A%26signed_in%3A0; bm_sv=22336326FC64D3D12F359165F56EA6B8~iE1AkXqwX8ICGenqNG2AxWrGTri9lflZO3LV8KaHspiqzibPVlfD6WFZcOw+v7e/dshsNzQgam4clF8Lst5oVSMbuC0CA9eJ1LLebzSCqOIFOpDriOzhqW7KBYPVR3sbRTTxaryokXJRRrVvUqCY4f3UYP/WEZ3eYR3mSxzOO9M=; s_pers=%20pn%3D10%7C1522043410976%3B%20v21%3DSPP%2520%257C%2520Lipstick%2520%252F%2520Lunar%2520New%2520Year%7C1519455236448%3B; s_sess=%20v24%3Dnoclick%3B%20TYPEAHEAD%3Dnoterm%3B%20event16%3Dnoclick%3B%20COLLECTIONS%3Dnocol%3B; _uetsid=_uet1b3ee88a; _gat_gtag_UA_109276500_2=1;");


            var jsonString = await httpClient.GetStringAsync(url);
            return jsonString;
        }
    }
}
