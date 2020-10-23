using FrameDemo.Pages;
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

namespace FrameDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Page1 page1 = new Page1();
        Page2 page2 = new Page2();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Source = new Uri("Pages/Page1.xaml",UriKind.Relative);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.frame.Source = new Uri("Pages/Page2.xaml",UriKind.Relative);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Pages/Page1.xaml", UriKind.Relative));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new Uri("Pages/Page2.xaml", UriKind.Relative));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if(this.frame.CanGoBack)
                this.frame.GoBack();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (this.frame.CanGoForward)
                this.frame.GoForward();
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
            MessageBox.Show("导航完成");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(page1);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            this.frame.Content = page2;
        }
    }
}
