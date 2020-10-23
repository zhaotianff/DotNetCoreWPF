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

namespace TabControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tab.Items.Add(new TabItem() { Header = "Added Item" });
        }

        private void tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl ti = (sender as TabControl);
            this.Dispatcher.BeginInvoke(new Action(()=> {
                MessageBox.Show(ti.SelectedIndex.ToString());
            })); 
        }
    }
}
