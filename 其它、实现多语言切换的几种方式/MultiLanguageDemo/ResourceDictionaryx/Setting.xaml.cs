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
using System.Windows.Shapes;
using System.Xml;
using ResourceDictionaryx;

namespace PictureBrowser
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Setting : Window
    {
        public Setting(int index)
        {
            InitializeComponent();
            this.combox_Language.SelectedIndex = index;
        }

        private void combox_Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeLanguage(this.combox_Language.SelectedIndex);
        }


        /// <summary>
        /// 切换 语言
        /// </summary>
        /// <param name="index"></param>
        public void ChangeLanguage(int index)
        {
            ResourceDictionary rd = new ResourceDictionary();
            switch(index)
            {
                case 0:
                    rd.Source = new Uri("Language/zh-CN.xaml", UriKind.Relative);
                    break;
                case 1:
                    rd.Source = new Uri("Language/en-US.xaml", UriKind.Relative);
                    break;
                default:
                    break;
            }            
            Application.Current.Resources.MergedDictionaries[0] = rd;
        }
    }
}
