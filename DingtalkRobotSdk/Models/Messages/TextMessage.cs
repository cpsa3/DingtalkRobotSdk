using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DingtalkRobotSdk.Models.Messages
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextMessage : DingDingMessage
    {
        public AtSetting at { get; set; }
        public TextMessageItem text { get; set; }
        public override string msgtype
        {
            get { return "text"; }
        }
    }

    public class TextMessageItem
    {
        public string content { get; set; }
    }
}
