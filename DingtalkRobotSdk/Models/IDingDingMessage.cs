using System;
using System.Collections.Generic;
using System.Text;

namespace DingtalkRobotSdk.Models
{
    /// <summary>
    /// 钉钉机器人消息类型接口
    /// </summary>
    public interface IDingDingMessage
    {
        string ToJson();
    }
}
