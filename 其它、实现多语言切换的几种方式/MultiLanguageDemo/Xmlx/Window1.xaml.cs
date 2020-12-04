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

namespace Xmlx
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : TianXiaTech.BlurWindow
    {
        MainWindow m;
        XmlDataProvider xdp;
        Utility u = new Utility();

        public Window1(MainWindow m,XmlDataProvider xdp)
        {
            InitializeComponent();

            this.xdp = xdp;
            this.m = m;
            window.DataContext = xdp;
            
        }

        private void combox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.combox.SelectedIndex >= 0)
            {
                this.xdp = u.ChooseLanguage(this, (this.combox.SelectedItem as ComboBoxItem).Content.ToString());
                this.m.DataContext = this.xdp;
            }
        }
    }
}
