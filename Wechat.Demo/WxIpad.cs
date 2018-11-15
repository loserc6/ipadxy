using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wechat.Demo.Config;
using Wechat.Demo.Wechat;
using Wechat.Demo.Wechat.Dtos;

namespace Wechat.Demo
{
    public class WxIpad
    {
        readonly string dllIP = string.Empty;
        readonly int dllPort = 0;

        public delegate void StatusBar(string value);
        public delegate void QrLoginInfo(Image image);
        public delegate void UserLogin(WxUserDataDto user);

        int wxUser;
        int pushStr;
        WxUserDto user = new WxUserDto();

        public WxIpad()
        {
            this.dllIP = ConfigHelper.Get("DllPort", "ip");
            this.dllPort = int.Parse(ConfigHelper.Get("DllPort", "port"));

            outputDelegate += MessageCall;

            Task.Factory.StartNew(() =>
            {
                try
                {
                    this.Init();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    MsgDelegate.Show($"error：{e.Message}");
                    throw;
                }
            });
        }

        public IpadDll.DllcallBack outputDelegate { get; set; }
        unsafe void Init()
        {
            fixed (int* WxUser = &wxUser, PushStr = &pushStr)
            {
                string uuid = IpadDll.FakeUuId();
                var mac = IpadDll.FakeMac();

                var ret = IpadDll.WXSetNetworkVerifyInfo(this.dllIP, this.dllPort);
                if (ret != 1)
                {
                    MsgDelegate.Show("授权失败：" + ret);
                    return;
                }
                var key = string.Format(@"<softtype><k3>9.0.2</k3><k9>iPad</k9><k10>2</k10><k19>58BF17B5-2D8E-4BFB-A97E-38F1226F13F8</k19><k20>{0}</k20><k21>neihe_5GHz</k21><k22>(null)</k22><k24>{1}</k24><k33>\345\276\256\344\277\241</k33><k47>1</k47><k50>1</k50><k51>com.tencent.xin</k51><k54>iPad4,4</k54></softtype>", uuid, mac);
                IpadDll.WXInitialize((int)WxUser, "鎴戠殑IPAD", key, uuid);
                IpadDll.WXSetRecvMsgCallBack(wxUser, outputDelegate);

                IpadDll.WXGetQRCode(wxUser, (int)PushStr);

                var msg = Marshal.PtrToStringAnsi(new IntPtr(Convert.ToInt32(pushStr)));
                WxQrCodeDto qrcode = Newtonsoft.Json.JsonConvert.DeserializeObject<WxQrCodeDto>(msg);//反序列化

                var img = Base64StringToImage(qrcode.QrCode);
                MsgDelegate.QrLogin(img);

                WXReleaseEX(ref pushStr);
                WxQrResultDto qrCoderesult = null;
                while (true)
                {
                    IpadDll.WXCheckQRCode(wxUser, (int)PushStr);
                    var datas = MarshalNativeToManaged((IntPtr)pushStr);
                    if (datas == null)
                    {
                        continue;
                    }
                    string sstr = datas.ToString();
                    qrCoderesult = Newtonsoft.Json.JsonConvert.DeserializeObject<WxQrResultDto>(sstr);
                    WXReleaseEX(ref pushStr);
                    bool breakok = false;
                    switch (qrCoderesult.Status)
                    {
                        case 0: MsgDelegate.Show("请扫描二维码"); break;
                        case 1: MsgDelegate.Show("请点在手机上点确认"); break;
                        case 2: MsgDelegate.Show("正在登录中.."); breakok = true; break;
                        case 3: MsgDelegate.Show("已过期"); break;
                        case 4: MsgDelegate.Show("取消操作了"); breakok = true; break;
                    }
                    if (breakok) { break; }
                }

                if (qrCoderesult.Status == 2)
                {
                    var username = qrCoderesult.UserName;
                    this.user.wxid = qrCoderesult.UserName;
                    this.user.name = qrCoderesult.NickName;
                    var pass = qrCoderesult.Password;
                    IpadDll.WXQRCodeLogin(wxUser, username, pass, (int)PushStr);
                    var datas = MarshalNativeToManaged((IntPtr)pushStr);
                    string sstr = datas.ToString();
                    WXReleaseEX(ref pushStr);
                    WxUserDataDto userdata = Newtonsoft.Json.JsonConvert.DeserializeObject<WxUserDataDto>(sstr);//反序列化
                    if (userdata.Status == -301)
                    {
                        Thread.Sleep(1000);
                        IpadDll.WXQRCodeLogin(wxUser, username, pass, (int)PushStr);
                        datas = MarshalNativeToManaged((IntPtr)pushStr);
                        sstr = datas.ToString();
                        WXReleaseEX(ref pushStr);
                        MsgDelegate.Show("微信重定向");
                        userdata = Newtonsoft.Json.JsonConvert.DeserializeObject<WxUserDataDto>(sstr);//反序列化

                        if (userdata.Status == 0)
                        {
                            MsgDelegate.Show("登录成功");
                            IpadDll.WXHeartBeat(wxUser, (int)PushStr);
                            datas = MarshalNativeToManaged((IntPtr)pushStr);
                            sstr = datas.ToString();
                            WXReleaseEX(ref pushStr);

                            MsgDelegate.UserLogin(userdata);
                            Task.Run(new Action(this.SyncList));
                            return;
                        }
                        else
                        {
                            MsgDelegate.UserLogin(null);
                            MsgDelegate.Show("登录失败");
                        }

                    }

                    if (userdata.Status == 0)
                    {
                        MsgDelegate.Show("登录成功");
                        IpadDll.WXHeartBeat(wxUser, (int)PushStr);
                        datas = MarshalNativeToManaged((IntPtr)pushStr);
                        sstr = datas.ToString();
                        WXReleaseEX(ref pushStr);

                        MsgDelegate.UserLogin(userdata);
                        Task.Run(new Action(this.SyncList));
                        return;
                    }
                    else
                    {
                        MsgDelegate.UserLogin(null);
                        MsgDelegate.Show("登录失败");
                    }
                }
                else
                {
                    MsgDelegate.UserLogin(null);
                    MsgDelegate.Show("登录失败");
                }
            }
        }

        public unsafe void SyncList()
        {
            
        }

        /// <summary>
        /// 消息回调
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int MessageCall(int a, int b)
        {
            if (b == -1)
            {
                MsgDelegate.Show($"用户已退出");
                return 0;
            }
            MsgDelegate.Show($"消息：a={a}, b={b}");
            return 0;
        }
        private void WXReleaseEX(ref int hande)
        {
            IpadDll.WXRelease(hande);
            hande = 0;
        }
        private Bitmap Base64StringToImage(string basestr)
        {
            Bitmap bitmap = null;
            try
            {
                String inputStr = basestr;
                byte[] arr = Convert.FromBase64String(inputStr);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                ms.Close();
                bitmap = bmp;
            }
            catch (Exception ex)
            {
                MsgDelegate.Show("图片转换失败：" + ex.Message);
            }

            return bitmap;
        }
        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            if (pNativeData == IntPtr.Zero)
            {
                return null;
            }
            List<byte> list = new List<byte>();
            int num = 0;
            for (; ; )
            {
                byte b = Marshal.ReadByte(pNativeData, num);
                if (b == 0)
                {
                    break;
                }
                list.Add(b);
                num++;
            }
            return Encoding.UTF8.GetString(list.ToArray(), 0, list.Count);
        }
    }
}
