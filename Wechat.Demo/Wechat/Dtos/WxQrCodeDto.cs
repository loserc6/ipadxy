using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wechat.Demo.Wechat.Dtos
{
    public class WxQrCodeDto
    {
        [JsonProperty("qr_code")]
        public string QrCode { get; set; }
    }
}
