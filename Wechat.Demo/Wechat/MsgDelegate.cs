using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Demo.Wechat
{
    public class MsgDelegate
    {
        public static WxIpad.QrLoginInfo QrLogin { set; get; }
        public static WxIpad.StatusBar Show { set; get; }
        public static WxIpad.UserLogin UserLogin { set; get; }
    }
}
