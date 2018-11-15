using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wechat.Demo.Config
{
    public class ConfigHelper
    {
        static readonly IniFile IniFile = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "config.ini");

        /// <summary>
        /// 写入
        /// </summary>
        public static void Set(string section, string key, string val)
        {
            IniFile.WriteValue(section, key, val);
        }

        /// <summary>
        /// 读取
        /// </summary>
        public static string Get(string section, string key)
        {
            return IniFile.ReadValue(section, key);
        }
    }
}
