using System;
using System.Collections.Generic;
using System.Text;

namespace DingtalkRobotSdk.Models.Messages
{
    public class LinkMessage : DingDingMessage
    {
        public LinkMessageItem link { get; set; }

        public override string msgtype
        {
            get { return "link"; }
        }
    }

    public class LinkMessageItem
    {
        public string text { get; set; }

        public string title { get; set; }

        public string picUrl { get; set; }

        public string messageUrl { get; set; }
    }
}
