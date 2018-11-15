using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Wechat.Demo.Config
{
    public class IniFile
    {
        //文件INI名称 
        private readonly string _path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public IniFile(string path)
        {
            this._path = path;
        }

        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="section">配置节</param>
        /// <param name="key">键名</param>
        /// <param name="value">键值</param>
        public void WriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this._path);
        }

        /// <summary>
        /// 读取制定INI文件键值
        /// </summary>
        /// <param name="section">配置节</param>
        /// <param name="key">键名</param>
        /// <returns></returns> 
        public string ReadValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, this._path);
            return temp.ToString();
        }
    }
}
