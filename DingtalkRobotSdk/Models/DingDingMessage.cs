using Newtonsoft.Json;

namespace DingtalkRobotSdk.Models
{
    /// <summary>
    /// 抽象钉钉消息类型
    /// </summary>
    public abstract class DingDingMessage : IDingDingMessage
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public abstract string msgtype { get; }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
