using System;
using System.Collections.Generic;
using System.Text;

namespace DingtalkRobotSdk.Models.Messages
{
    public class FeedCardMessage : DingDingMessage
    {
        public override string msgtype => "feedCard";

        public FeedCardMessageItem feedCard { get; set; }
    }

    public class FeedCardMessageItem
    {
        public List<FeedCardLinkItem> links { get; set; }
    }

    public class FeedCardLinkItem
    {
        /// <summary>
        /// 单条信息文本
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 点击单条信息到跳转链接
        /// </summary>
        public string messageURL { get; set; }

        /// <summary>
        /// 单条信息后面图片的URL
        /// </summary>
        public string picURL { get; set; }
    }
}
