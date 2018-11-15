using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Wechat.Demo.Wechat
{
    public class IpadDll
    {
        /// <summary>
        /// 账户与密码登录方式
        /// </summary>
        /// <param name="objects">接口对象指针</param>
        /// <param name="user">用户名</param>
        /// <param name="password">二维码验证密码</param>
        /// <param name="result">二级指针，json字符串，返回执行结果</param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXUserLogin")]
        public static extern void WXUserLogin(int objects, string user, string password, int result);

        /// <summary>
        /// 手机登陆
        /// </summary>
        /// <param name="objects">接口对象指针</param>
        /// <param name="user">用户名</param>
        /// <param name="password">二维码验证密码</param>
        /// <param name="result">二级指针，json字符串，返回执行结果</param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXPhoneLogin")]
        public static extern void WXPhoneLogin(int objects, string user, string password, int result);

        /// <summary>
        /// 获取登陆验证码
        /// </summary>
        /// <param name="objects">接口对象指针</param>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <param name="result">二级指针，json字符串，返回执行结果</param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXGetLoginVerifyCode")]
        public static extern void WXGetLoginVerifyCode(int objects, string phone_number, int result);

        /// <summary>
        /// 发送登陆验证码
        /// </summary>
        /// <param name="objects">接口对象指针</param>
        /// <param name="phone_number">手机号码,格式+8613666666666</param>
        /// <param name="verify_code">验证码</param>
        /// <param name="result">二级指针，json字符串，返回执行结果</param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSendLoginVerifyCode")]
        public static extern void WXSendLoginVerifyCode(int objects, string phone_number, string verify_code, int result);

        /// <summary>
        /// 获取指定用户详细信息
        /// </summary>
        /// <param name="objects">接口对象指针</param>
        /// <param name="user">目标微信帐户</param>
        /// <param name="result">二级指针，json字符串，返回执行结果</param>
        [DllImport("wxpad.dll", EntryPoint = "WXGetContact")]
        public static extern void WXGetContact(int objects, string user, int result);

        /// <summary>
        /// 获取好友朋友圈信息
        /// </summary>
        /// <param name="objects">接口对象指针</param>
        /// <param name="user">对方用户名</param>
        /// <param name="id"></param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXSnsUserPage")]
        public static extern void WXSnsUserPage(int objects, string user, string id, int result);

        /// <summary>
        /// 获取朋友圈消息详情(例如评论)
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="id">朋友圈消息id</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXSnsObjectDetail")]
        public static extern void WXSnsObjectDetail(int objects, string id, int result);

        /// <summary>
        /// 朋友圈操作(删除评论，取消赞)
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="id">朋友圈消息id</param>
        /// <param name="type">操作类型,4为删除评论，5为取消赞</param>
        /// <param name="comment">当type为4时，对应删除评论的id，通过WXSnsObjectDetail接口获取。当type为5时，comment不可用，置为0.</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXSnsObjectOp")]
        public static extern void WXSnsObjectOp(int objects, string id, int type, int comment, int result);

        /// <summary>
        /// 搜索指定用户详细信息
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="user">目标微信帐户</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXSearchContact")]
        public static extern void WXSearchContact(int objects, string user, int result);

        /// <summary>
        /// 主动添加好友
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="stranger">对方stranger字符串，例如v1_caa184cca678097XXXXXXXXXXXXXXXXXXXX70340e8ae5f3cad28347ad4@stranger</param>
        /// <param name="strangerV2">对方stranger字符串</param>
        /// <param name="type">添加好友来源</param>
        /// <param name="verify">添加好友时的验证信息</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXAddUser")]
        public static extern void WXAddUser(int objects, string stranger, string strangerV2, int type, string verify, int result);

        /// <summary>
        /// 删除指定好友
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="user">对方用户名</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXDeleteUser")]
        public static extern void WXDeleteUser(int objects, string user, int result);

        /// <summary>
        /// 接受好友请求
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="stranger">对方stranger字符串，例如v1_caa184cca678097XXXXXXXXXXXXXXXXXXXX70340e8ae5f3cad28347ad4@stranger</param>
        /// <param name="ticket">好友请求ticket</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXAcceptUser")]
        public static extern void WXAcceptUser(int objects, string stranger, string ticket, int result);

        /// <summary>
        /// 心跳
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="result">二级指针，返回执行结果</param>
        [DllImport("wxpad.dll", EntryPoint = "WXHeartBeat")]
        public static extern void WXHeartBeat(int objects, int result);

        /// <summary>
        /// 获取登录token
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXGetLoginToken")]
        public static extern void WXGetLoginToken(int objects, int result);

        /// <summary>
        /// 二次自动登录
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="token">调用WXGetLoginToken获取token字段数据</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXLoginRequest")]
        public static extern void WXLoginRequest(int objects, string token, int result);

        /// <summary>
        /// 二次自动登录
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="token">调用WXGetLoginToken获取token字段数据</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXAutoLogin")]
        public static extern void WXAutoLogin(int objects, string token, int result);

        /// <summary>
        /// 加载62数据
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="wxdata"></param>
        /// <param name="wx_size"></param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXLoadWxDat")]
        public static extern void WXLoadWxDat(int objects, byte[] wxdata, int wx_size, int result);

        /// <summary>
        /// 获取url访问token
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="user">公众号用户名gh_*******开头的</param>
        /// <param name="url">http://xxxxxxxxxxxxx访问连接</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXGetRequestToken")]
        public static extern void WXGetRequestToken(int objects, string user, string url, int result);

        /// <summary>
        /// 返回公众号信息
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="user">公众号或V1</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXGetSubscriptionInfo")]
        public static extern void WXGetSubscriptionInfo(int objects, string user, int result);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="image_data">图片数据</param>
        /// <param name="image_size">图片大小</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXSetHeadImage")]
        public static extern void WXSetHeadImage(int objects, byte[] image_data, int image_size, int result);

        /// <summary>
        /// 发送文字消息
        /// </summary>
        /// <param name="user">对方用户名</param>
        /// <param name="content">消息内容</param>
        /// <param name="at">@好友列表，json数组 {"wxid1","wxid2"} 不at传null</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXSendMsg")]
        public static extern void WXSendMsg(int wxuser, string user, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))] string content, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))] string at, int result);
        
        /// <summary>
        /// 设置代理
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="proxy">http代理服务器，格式192.168.1.1:8888 </param>
        /// <param name="type">代理类型，1为http代理，2为socks4，3为socks5(需要用户名和密码)</param>
        /// <param name="user">代理的用户名,socks5需要。</param>
        /// <param name="password">代理的密码,socks5需要。</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXSetProxyInfo")]
        public static extern void WXSetProxyInfo(int objects, string proxy, int type, string user, string password, int result);

        /// <summary>
        /// 查看附近的人
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="logitude">浮点数，经度</param>
        /// <param name="latitude">浮点数，维度</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXGetPeopleNearby")]
        public static extern void WXGetPeopleNearby(int objects, double logitude, double latitude, int result);

        /// <summary>
        /// 接收红包
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="red_packet">整个红包消息结构</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXReceiveRedPacket")]
        public static extern void WXReceiveRedPacket(int objects, string red_packet, int result);

        /// <summary>
        /// 查看红包
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="red_packet">整个红包消息结构</param>
        /// <param name="index">0代表第一页 11代表第二页  +11代表翻页</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXQueryRedPacket")]
        public static extern void WXQueryRedPacket(int objects, string red_packet, int index, int result);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="toUser">接收目标</param>
        /// <param name="image_data">图片</param>
        /// <param name="image_size">图片大小</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXSendImage", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern void WXSendImage(int objects, string toUser, byte[] image_data, int image_size, int result);

        /// <summary>
        /// 打招呼
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="stranger">对方的stranger串</param>
        /// <param name="content">消息内容，可为空。为空时显示打了个招呼</param>
        /// <param name="result"></param>
        [DllImport("wxpad.dll", EntryPoint = "WXSayHello")]
        public static extern void WXSayHello(int objects, string stranger, string content, int result);

        /// <summary>
        /// 授权及验证
        /// </summary>
        /// <param name="IP">IP</param>
        /// <param name="port">端口</param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSetNetworkVerifyInfo")]
        public static extern int WXSetNetworkVerifyInfo(string ip, int port);

        /// <summary>
        /// 获取消息语音(语音消息大于20秒时通过该接口获取)
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="msg">转账消息</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXGetMsgVoice")]
        public static extern int WXGetMsgVoice(int objects, string msg, int result);

        /// <summary>
        /// 接受转账
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="transfer">转账消息</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXTransferOperation")]
        public static extern int WXTransferOperation(int objects, string transfer, int result);

        /// <summary>
        /// 发送朋友圈
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="content">消息结构</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSendMoments")]
        public static extern int WXSendMoments(int objects, string content, int result);

        /// <summary>
        /// 群发消息
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="user">用户名json数组 ["AB1","AC2","AD3"]</param>
        /// <param name="content">消息内容，可为空。为空时显示打了个招呼</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXMassMessage")]
        public static extern int WXMassMessage(int objects, string user, string content, int result);

        /// <summary>
        /// 生成62数据
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXGenerateWxDat")]
        public static extern int WXGenerateWxDat(int objects, int result);

        /// <summary>
        /// 领取红包
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="red_packet">整个红包消息结构</param>
        /// <param name="key">通过接受红包返回的key</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXOpenRedPacket")]
        public static extern int WXOpenRedPacket(int objects, string red_packet, string key, int result);

        /// <summary>
        /// 发送APP消息(分享应用或者朋友圈链接等)
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="user">对方用户名</param>
        /// <param name="content">消息内容(整个消息结构<appmsg xxxxxxxxx>)</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSendAppMsg")]
        public static extern int WXSendAppMsg(int objects, string user, string content, int result);

        /// <summary>
        /// 同步收藏消息(用户获取收藏对象的id)
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="key">同步的key，第一次调用设置为空</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXFavSync")]
        public static extern int WXFavSync(int objects, string key, int result);

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="fav_object">收藏对象结构(<favitem type=5xxxxxx)</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXFavAddItem")]
        public static extern int WXFavAddItem(int objects, string fav_object, int result);

        /// <summary>
        /// 获取收藏对象的详细信息
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="id">收藏对象id</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXFavGetItem")]
        public static extern int WXFavGetItem(int objects, int id, int result);

        /// <summary>
        /// 删除收藏对象
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="id">收藏对象id</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXFavDeleteItem")]
        public static extern int WXFavDeleteItem(int objects, int id, int result);

        /// <summary>
        /// 获取所有标签列表
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXGetContactLabelList")]
        public static extern int WXGetContactLabelList(int objects, int result);

        /// <summary>
        /// 获取所有标签列表
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="label">标签内容</param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXAddContactLabel")]
        public static extern int WXAddContactLabel(int objects, string label, int result);

        /// <summary>
        /// 从列表删除标签
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="id">标签id</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXDeleteContactLabel")]
        public static extern int WXDeleteContactLabel(int objects, int id, int result);

        /// <summary>
        /// 设置用户标签
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="user">用户名</param>
        /// <param name="id">标签id</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSetContactLabel")]
        public static extern int WXSetContactLabel(int objects, string user, int id, int result);

        /// <summary>
        /// 分享名片
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="user">对方用户名</param>
        /// <param name="wxid">微信ID</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXShareCard")]
        public static extern int WXShareCard(int objects, string user, string wxid, string title, int result);

        /// <summary>
        /// 执行公众号菜单
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="user">公众号用户名gh* 开头的</param>
        /// <param name="id">通过WXGetSubscriptionInfo获取</param>
        /// <param name="key">通过WXGetSubscriptionInfo获取</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSubscriptionCommand")]
        public static extern int WXSubscriptionCommand(int objects, string user, int id, string key, int result);

        /// <summary>
        /// 访问/阅读url
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="url">访问的链接</param>
        /// <param name="key">token中的key</param>
        /// <param name="uin">token中的uin</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXRequestUrl")]
        public static extern int WXRequestUrl(int objects, string url, string key, string uin, int result);

        /// <summary>
        /// 重置同步信息
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSyncReset")]
        public static extern int WXSyncReset(int objects);

        /// <summary>
        /// 添加群成员
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="chatroom">群用户名</param>
        /// <param name="user">成员用户名</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXAddChatRoomMember")]
        public static extern int WXAddChatRoomMember(int objects, string chatroom, string user, int result);

        /// <summary>
        /// 创建群
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="user">用户名json数组，例如["wxid_g58r112lnw0q22"</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXCreateChatRoom")]
        public static extern int WXCreateChatRoom(int objects, string user, int result);

        /// <summary>
        /// 邀请群成员
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="chatroom">群用户名</param>
        /// <param name="user">成员用户名</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXInviteChatRoomMember")]
        public static extern int WXInviteChatRoomMember(int objects, string chatroom, string user, int result);

        /// <summary>
        /// 获取二维码信息
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="path">本地二维码图片全路径</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXQRCodeDecode")]
        public static extern int WXQRCodeDecode(int objects, string path, int result);

        /// <summary>
        /// 获取其他设备登陆请求
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="login_url">通过二维码扫描获取的url</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXExtDeviceLoginGet")]
        public static extern int WXExtDeviceLoginGet(int objects, string login_url, int result);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="objects">接口对象指针</param>
        /// <param name="toUser">接收目标</param>
        /// <param name="image_data">图片</param>
        /// <param name="object1"></param>
        /// <param name="object2">接口对象指针</param>
        /// <param name="image_size">图片大小</param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSendVoice")]
        public static extern int WXSendVoice(int objects, string toUser, byte[] image_data, int object1, int object2, int image_size);


        /// <summary>
        /// 确认其他设备登陆请求
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="login_url">通过二维码扫描获取的url</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXExtDeviceLoginOK")]
        public static extern int WXExtDeviceLoginOK(int objects, string login_url, int result);

        /// <summary>
        /// 设置个人信息
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="nick_name">昵称</param>
        /// <param name="unsigned">签名</param>
        /// <param name="sex">性别，1男，2女</param>
        /// <param name="country">国家，CN</param>
        /// <param name="provincia">地区，省，Zhejiang</param>
        /// <param name="city">城市，Hangzhou</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSetUserInfo")]
        public static extern int WXSetUserInfo(int objects, string nick_name, string unsigned, int sex, string country, string provincia, string city, int result);

        /// <summary>
        /// 初始化接口(对象)
        /// </summary>
        /// <param name="objects">接口对象二级指针,分配一个对象</param>
        /// <param name="device_name">格式 xxxx 的ipad</param>
        /// <param name="device_type">格式 <softtype><k3>9.0.2</k3><k9>iPad</k9><k10>2</k10><k19>58BF17B5-2D8E-4BFB-A97E-38F1226F13F8</k19><k20>710DECBB-7176-4E50-83D3-C24BA2070356</k20><k21>neihe_5GHz</k21><k22>(null)</k22><k24>94:10:3e:8e:8:43</k24><k33>\345\276\256\344\277\241</k33><k47>1</k47><k50>1</k50><k51>com.tencent.xin</k51><k54>iPad4,4</k54></softtype></param>
        /// <param name="device_uuid">格式 以上面k20一致 710DECBB-7176-4E50-83D3-C24BA2070356</param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXInitialize")]
        public static extern int WXInitialize(int objects, string device_name, string device_type, string device_uuid);

        /// <summary>
        /// 获取扫码登录二维码
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXGetQRCode")]
        public static extern int WXGetQRCode(int objects, int result);

        /// <summary>
        /// 设置http服务地址相关信息
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="server">服务地址</param>
        /// <param name="sign">开发者相关信息{"code":"123456"}</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSetHttpServer")]
        public static extern int WXSetHttpServer(int objects, string server, string sign, int timeout, int result);

        /// <summary>
        /// 获取群成员资料
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="chatroom">群ID</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXGetChatRoomMember")]
        public static extern int WXGetChatRoomMember(int objects, string chatroom, int result);

        /// <summary>
        /// 检查二维码状态 //需循环调用
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXCheckQRCode", CharSet = CharSet.Ansi)]
        public static extern int WXCheckQRCode(int objects, int result);

        /// <summary>
        /// 二维码登陆
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="user">用户名</param>
        /// <param name="password">二维码验证密码</param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXQRCodeLogin")]
        public static extern int WXQRCodeLogin(int objects, string user, string password, int result);

        /// <summary>
        /// 帐户注销
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXLogout")]
        public static extern int WXLogout(int objects, int result);


        /// <summary>
        /// 同步包含通讯录及微信消息，不要与WXSyncMessage一起使用
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSyncMsg")]
        public static extern int WXSyncMsg(int objects, int result);

        /// <summary>
        /// 只同步聊天信息，，不要与WXSyncMsg一起使用
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSyncMessage")]
        public static extern int WXSyncMessage(int objects, int result);

        /// <summary>
        /// 只同步通讯录信息
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSyncContact")]
        public static extern int WXSyncContact(int objects, int result);

        /// <summary>
        /// 释放内存，使用一个函数后将接收返回值的指针做初始化释放内存
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXRelease")]
        public static extern int WXRelease(int result);

        /// <summary>
        /// 设置接收消息通知回调函数
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="sync_msg_cb">回调函数指针</param>
        /// <returns></returns>

        [DllImport("wxpad.dll", EntryPoint = "WXSetRecvMsgCallBack")]
        public static extern int WXSetRecvMsgCallBack(int objects, DllcallBack sync_msg_cb);

        /// <summary>
        /// 设置同步消息回调函数
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="sync_msg_cb">回调函数指针</param>
        /// <returns></returns>
        [DllImport("wxpad.dll", EntryPoint = "WXSetSyncMsgCallBack")]
        public static extern int WXSetSyncMsgCallBack(int objects, DllcallBack sync_msg_cb);

        public delegate int DllcallBack(int objects, int sync_msg_cb);


        public static string FakeUuId()
        {
            return randomstr(8) + "-" + randomstr(4) + "-" + randomL(4) + "-" + randomL(4) + "-" + randomL(12);
        }

        public static string FakeMac()
        {
            int min = 0;
            int max = 16;
            var sn = string.Format("{0}{1}:{2}{3}:{4}{5}:{6}{7}:{8}{9}:{10}{11}",
                random.Next(min, max).ToString("x"),//0
                random.Next(min, max).ToString("x"),//
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),//5
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),
                random.Next(min, max).ToString("x"),//10
                random.Next(min, max).ToString("x")
            ).ToUpper();
            return sn;
        }
        static Random random = new Random();
        static string randomstr(int n)
        {
            List<int> ilist = new List<int>();
            for (int i = 0; i < n; i++)
            {
                ilist.Add(random.Next(0, 9));
            }
            return string.Join("", ilist).PadLeft(n, '0');

        }
        static string randomL(int n)
        {
            List<int> ilist = new List<int>();
            for (int i = 0; i < n; i++)
            {
                ilist.Add(random.Next(0, 9));
            }
            return Convert.ToInt64(string.Join("", ilist)).ToString("X").PadLeft(n, '0');

        }
    }
}
