using System;
using System.Collections.Generic;
using System.Text;

namespace DingtalkRobotSdk.Models.Messages
{
    public class FullActionCardMessage : DingDingMessage
    {
        public override string msgtype => "actionCard";

        public FullActionCardMessageItem actionCard { get; set; }
    }

    public class FullActionCardMessageItem
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
        /// 单个按钮的方案。(设置此项和singleURL后btns无效。)
        /// </summary>
        public string singleTitle { get; set; }

        /// <summary>
        /// 点击singleTitle按钮触发的URL
        /// </summary>
        public string singleURL { get; set; }
    }
}
