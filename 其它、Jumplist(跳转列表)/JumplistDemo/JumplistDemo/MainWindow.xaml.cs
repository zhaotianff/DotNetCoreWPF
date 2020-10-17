using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace JumplistDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : TianXiaTech.BlurWindow
    {
        private const string Baidu = "baidu";
        private const string Google = "google";
        private const string BaiduUrl = "https://www.baidu.com";
        private const string GoogleUrl = "https://www.google.com";

        public MainWindow(string [] args)
        {
            InitializeComponent();
            ParseArgs(args);
        }

        private void ParseArgs(string [] args)
        {
            if(args.Length > 0)
            {
                switch(args[0])
                {
                    case Baidu:
                        OpenUrl(BaiduUrl);
                        break;
                    case Google:
                        OpenUrl(GoogleUrl);
                        break;
                }
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
             OpenUrl(this.tboxurl.Text);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.browser.GetBrowser().Reload();
        }

        private void OpenUrl(string url)
        {
            this.browser.Address = url;
        }
    }
}
