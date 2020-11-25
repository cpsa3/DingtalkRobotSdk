using DingtalkRobotSdk;
using DingtalkRobotSdk.Models;
using DingtalkRobotSdk.Models.Messages;
using GitlabWebhook.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitlabWebhook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private const string webHookUrl = "https://oapi.dingtalk.com/robot/send?access_token=xxx";
        
        [HttpPost]
        public bool Test([FromBody] Webhook model)
        {
            if (!HttpContext.Request.Headers.TryGetValue("X-Gitlab-Event", out var key))
            {
                return false;
            }

            if(key == "Pipeline Hook")
            {
                SendPipelineHook(model);

            }
            return true;
        }

        private void SendPipelineHook(Webhook model)
        {
            if(model is null)
            {
                return;
            }

            MarkdownMessage message = new MarkdownMessage
            {
                markdown = new MarkdownMessageItem
                {
                    title = "GitLab Pipeline Hook",
                    text = $"#### pipeline {model.object_attributes.id}  \n" +
                    $"> - [status] {model.object_attributes.status}\n" +
                    $"> - [triggerer] {model.user.name} \n" +
                    $"> - [commit] [{model.commit.message}]({model.commit.url}) \n" + 
                    $"\n\n" +
                    $"详情 [link](http://git.greedyint.com/xiaobao-community/xiaobao-ddd-framework/pipelines/{model.object_attributes.id}) \n"
                },
                at = new AtSetting
                {
                    atMobiles = new System.Collections.Generic.List<string> { "15267853123" },
                    isAtAll = false
                }
            };

            _ = DingtalkClient.SendMessageAsync(webHookUrl, message).Result;
        }
    }
}
