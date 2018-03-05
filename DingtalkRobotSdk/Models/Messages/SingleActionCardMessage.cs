using System;
using System.Collections.Generic;
using System.Text;

namespace DingtalkRobotSdk.Models.Messages
{
    public class SingleActionCardMessage : DingDingMessage
    {
        public override string msgtype => "actionCard";

        public SingleActionCardMessageItem actionCard { get; set; }
    }

    public class SingleActionCardMessageItem
    {
        /// <summary>
        /// 首屏会话透出的展示内容
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// markdown格式的消息
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 0-正常发消息者头像,1-隐藏发消息者头像
        /// </summary>
        public int hideAvatar { get; set; }

        /// <summary>
        /// 0-按钮竖直排列，1-按钮横向排列
        /// </summary>
        public int btnOrientation { get; set; }

        /// <summary>
        /// 按钮的信息：title-按钮方案，actionURL-点击按钮触发的URL
        /// </summary>
        public List<SingleActionCardBtn> btns { get; set; }
    }

    public class SingleActionCardBtn
    {
        public string title { get; set; }
        public string actionURL { get; set; }
    }
}
