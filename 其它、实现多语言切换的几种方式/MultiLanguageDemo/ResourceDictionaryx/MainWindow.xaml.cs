using PictureBrowser;
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

namespace ResourceDictionaryx
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();        
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            //切换语言
            Setting setting = new Setting(0);
            setting.ShowDialog();
        }
    }
}
