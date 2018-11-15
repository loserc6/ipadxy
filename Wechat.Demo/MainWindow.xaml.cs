using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Wechat.Demo.Config;
using Wechat.Demo.Wechat;
using Wechat.Demo.Wechat.Dtos;
using Image = System.Drawing.Image;

namespace Wechat.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WxIpad WxIpad { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Loaded += (o, args) => Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.OnLoad));
        }

        private void OnLoad()
        {
            MsgDelegate.Show += this.ShowStatusMessage;
            MsgDelegate.QrLogin += this.ShowLoginByQr;
            MsgDelegate.UserLogin += this.ShowUserLogin;

            //this.ImgQrLogin.Source = new BitmapImage(new Uri("https://qr.api.cli.im/qr?data=asfa&level=H&transparent=false&bgcolor=%23ffffff&forecolor=%23000000&blockpixel=12&marginblock=1&logourl=&size=260&kid=cliim&key=545835687c08600567c36ec470454607"));
            this.LoadInitData();
        }
        private void LoadInitData()
        {
            this.Txt62Data.Text = ConfigHelper.Get("WeChatConfig", "62data1") + ConfigHelper.Get("WeChatConfig", "62data2");
            this.TxtUserName.Text = ConfigHelper.Get("WeChatConfig", "username");
            this.TxtPassowrd.Text = ConfigHelper.Get("WeChatConfig", "password");
        }

        /// <summary>
        /// 微信登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.BtnLogin.IsEnabled = false;
            this.BtnLogin.Content = "登录中";
            this.ShowStatusMessage("请求登录");

            Dispatcher.InvokeAsync(this.LoginWxDefault);
            //if (this.Ckb62Data.IsEnabled)
            //{
            //    this.LoginWxBy62Data();
            //}
            //else
            //{
            //    this.LoginWxBy62Data();
            //}
        }

        async Task LoginWxDefault()
        {
            await Task.Run(() =>
            {
                WxIpad = new WxIpad();
            });
        }

        async Task LoginWxBy62Data()
        {
            await Task.Run(() =>
            {
                WxIpad = new WxIpad();
            });
        }

        void ShowStatusMessage(string value)
        {
            Dispatcher.Invoke(() =>
            {
                this.StatusBar.Text = value;
            });
        }
        void ShowLoginByQr(Image image)
        {
            Dispatcher.Invoke(() =>
            {
                this.ImgQrLogin.Source = ConvertBitmapImage(image);
            });
        }
        void ShowUserLogin(WxUserDataDto user)
        {
            if(user != null)
            {
                //登录成功
                Dispatcher.Invoke(() =>
                {
                    this.BtnLogin.Content = "登录成功";
                    this.Title = $"DEMO：{user.NickName}（{user.UserName}）";
                });
            }
            else
            {
                //登录失败
                Dispatcher.Invoke(() => this.BtnLogin.Content = "登录失败，请重试");
                this.BtnLogin.IsEnabled = true;
            }
        }
        BitmapImage ConvertBitmapImage(Image img)
        {
            using (img)
            using (var memory = new MemoryStream())
            {
                img.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
    }
}
