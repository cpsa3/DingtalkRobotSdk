using System;
using System.Collections.Generic;
using System.Text;

namespace DingtalkRobotSdk.Models
{
    /// <summary>
    /// @ 配置
    /// </summary>
    public class AtSetting
    {
        /// <summary>
        /// 被@人的手机号
        /// </summary>
        public List<string> atMobiles { get; set; } = new List<string>();

        /// <summary>
        /// 是否@所有人
        /// </summary>
        public bool isAtAll { get; set; }
    }
}
