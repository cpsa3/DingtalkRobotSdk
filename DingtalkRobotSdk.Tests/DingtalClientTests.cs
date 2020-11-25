using System.Collections.Generic;
using DingtalkRobotSdk.Models;
using DingtalkRobotSdk.Models.Messages;
using Xunit;

namespace DingtalkRobotSdk.Tests
{
    public class DingtalClientTests
    {
        private const string webHookUrl = "https://oapi.dingtalk.com/robot/send?access_token=9e26497f947eb775e1895efe20b45301d8244d92d0088da8f493e0e7f82f404a";

        [Fact]
        public void Test()
        {
            var a = 1;
            Assert.Equal(1, a);
        }


        [Fact]
        public void TextMessageTest()
        {
            TextMessage message = new TextMessage
            {
                text = new TextMessageItem
                {
                    content = "GitLab 测试TextMessage"
                },
                at = new AtSetting
                {
                    isAtAll = false
                }
            };

            var result = DingtalkClient.SendMessageAsync(webHookUrl, message).Result;
        }

        [Fact]
        public void LinkMessageTest()
        {
            LinkMessage message = new LinkMessage
            {
                link = new LinkMessageItem
                {
                    title = "GitLab 时代的火车向前开",
                    messageUrl = "https://mp.weixin.qq.com/s?__biz=MzA4NjMwMTA2Ng==&mid=2650316842&idx=1&sn=60da3ea2b29f1dcc43a7c8e4a7c97a16&scene=2&srcid=09189AnRJEdIiWVaKltFzNTw&from=timeline&isappinstalled=0&key=&ascene=2&uin=&devicetype=android-23&version=26031933&nettype=WIFI",
                    picUrl = "",
                    text = @"这个即将发布的新版本，创始人陈航（花名“无招”）称它为“红树林”。而在此之前，每当面临重大升级，产品经理们都会取一个应景的代号，这一次，为什么是“红树林”？"
                }
            };

            var result = DingtalkClient.SendMessageAsync(webHookUrl, message).Result;

            Assert.Equal(0, result.errcode);
        }

        [Fact]
        public void MarkdownMessageTest()
        {
            MarkdownMessage message = new MarkdownMessage
            {
                markdown = new MarkdownMessageItem
                {
                    title = "GitLab 杭州天气",
                    text = "#### 杭州天气 @150XXXXXXXX \n> 9度，西北风1级，空气良89，相对温度73%\n> ![screenshot](https://img.alicdn.com/tfs/TB1NwmBEL9TBuNjy1zbXXXpepXa-2400-1218.png)\n> ###### 10点20分发布 [天气](https://www.dingtalk.com) \n"
                },
                at = new AtSetting
                {
                    atMobiles = new System.Collections.Generic.List<string> { "15267853123" },
                    isAtAll = false
                }
            };

            var result = DingtalkClient.SendMessageAsync(webHookUrl, message).Result;
            Assert.Equal(0, result.errcode);
        }

        [Fact]
        public void FullActionCardMessageTest()
        {
            FullActionCardMessage message = new FullActionCardMessage
            {
                actionCard = new FullActionCardMessageItem
                {
                    title = "GitLab 乔布斯 20 年前想打造一间苹果咖啡厅，而它正是 Apple Store 的前身",
                    text = @"![screenshot](@lADOpwk3K80C0M0FoA) 
### 乔布斯 20 年前想打造的苹果咖啡厅 
Apple Store 的设计正从原来满满的科技感走向生活化，而其生活化的走向其实可以追溯到 20 年前苹果一个建立咖啡馆的计划",
                    btnOrientation = 0,
                    hideAvatar = 0,
                    singleTitle = "阅读全文",
                    singleURL = "https://www.baidu.com"
                }
            };

            var result = DingtalkClient.SendMessageAsync(webHookUrl, message).Result;
            Assert.Equal(0, result.errcode);
        }

        [Fact]
        public void SingleActionCardMessageTest()
        {
            SingleActionCardMessage message = new SingleActionCardMessage
            {
                actionCard = new SingleActionCardMessageItem
                {
                    title = "GitLab 乔布斯 20 年前想打造一间苹果咖啡厅，而它正是 Apple Store 的前身",
                    text = @"![screenshot](@lADOpwk3K80C0M0FoA) 
### 乔布斯 20 年前想打造的苹果咖啡厅 
Apple Store 的设计正从原来满满的科技感走向生活化，而其生活化的走向其实可以追溯到 20 年前苹果一个建立咖啡馆的计划",
                    btnOrientation = 0,
                    hideAvatar = 0,
                    btns = new List<SingleActionCardBtn>
                    {
                         new SingleActionCardBtn
                         {
                             title = "内容不错",
                             actionURL ="www.baidu.com"
                         },
                         new SingleActionCardBtn
                         {
                              title = "不感兴趣",
                              actionURL = "www.google.com"
                         }
                    }
                }
            };

            var result = DingtalkClient.SendMessageAsync(webHookUrl, message).Result;
            Assert.Equal(0, result.errcode);
        }

        [Fact]
        public void FeedCardMessageTest()
        {
            FeedCardMessage message = new FeedCardMessage
            {
                feedCard = new FeedCardMessageItem
                {
                    links = new List<FeedCardLinkItem>
                    {
                        new FeedCardLinkItem
                        {
                             title = "GitLab 90后泪目测试 曾被成为脑残一代的我们 长大了",
                             messageURL = "https://mp.weixin.qq.com/s/6N-i1S_ycvLJhVJiRmERZQ",
                             picURL = "https://mmbiz.qpic.cn/mmbiz_png/0WvIQqWiafkkdibCvLibDXicfytDthFvjn4x8BefIqs058rPDYqiaFYqca2MOBezcwLqibngVRbL0KTMNnKhKITHuLHg/640?wx_fmt=gif&tp=webp&wxfrom=5&wx_lazy=1"
                        },
                        new FeedCardLinkItem
                        {
                             title = "史卷 | 中国最神秘的一个城市，没有名称，只有一个代号404",
                             messageURL = "https://mp.weixin.qq.com/s/uKYfpdCoqRlokCiKLzIoEA",
                             picURL = ""
                        }
                    }
                }
            };

            var result = DingtalkClient.SendMessageAsync(webHookUrl, message).Result;
            Assert.Equal(0, result.errcode);
        }
    }
}
