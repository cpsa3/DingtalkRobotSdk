using System;
using System.Collections.Generic;
using System.Text;

namespace DingtalkRobotSdk.Models.Messages
{
    public class MarkdownMessage : DingDingMessage
    {
        public override string msgtype
        {
            get { return "markdown"; }
        }

        public MarkdownMessageItem markdown { get; set; }

        public AtSetting at { get; set; }
    }

    public class MarkdownMessageItem
    {
        public string title { get; set; }
        public string text { get; set; }
    }
}
