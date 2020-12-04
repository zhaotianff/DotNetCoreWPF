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
using System.Xml;

namespace Xmlx
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : TianXiaTech.BlurWindow
    {

        Utility u = new Utility();
        XmlDataProvider xdp;
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void combox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.combox.SelectedIndex >= 0)
            {
                this.xdp = u.ChooseLanguage(this,(this.combox.SelectedItem as ComboBoxItem).Content.ToString());
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1(this,xdp);           
            w.ShowDialog();
        }
    }
}
