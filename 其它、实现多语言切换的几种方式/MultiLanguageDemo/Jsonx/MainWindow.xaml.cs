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

namespace Jsonx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LanguageHelper.Instance.LanguageChanged += Instance_LanguageChanged;
            LoadCulture(LanguageHelper.Instance.CurrentCulture);
        }

        private void Instance_LanguageChanged(System.Globalization.CultureInfo obj)
        {
            //这里可以对语言更改进行处理
            switch(obj.Name)
            {
                case "zh-CN":
                    break;
                case "en-US":
                    break;
            }
        }

        private void LoadCulture(System.Globalization.CultureInfo culture)
        {
            switch(culture.Name)
            {
                case "zh-CN":
                    combox_Culture.SelectedIndex = 0;
                    break;
                case "en-US":
                    combox_Culture.SelectedIndex = 1;
                    break;
            }
        }

        private void combox_Culture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var culture = "zh-CN";

            switch(combox_Culture.SelectedIndex)
            {
                case 0:
                    culture = "zh-CN";
                    break;
                case 1:
                    culture = "en-US";
                    break;
            }

            if (culture == null)
                return;

            LanguageHelper.Instance.CurrentCulture = new System.Globalization.CultureInfo(culture.ToString().Replace("_", "-"));
        }
    }
}
