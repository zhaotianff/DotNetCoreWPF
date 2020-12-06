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

namespace WindowDemo
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
            TransparencyWindow transparencyWindow = new TransparencyWindow();
            transparencyWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //使用XAML布局
            XAMLWindow xAMLWindow = new XAMLWindow();
            xAMLWindow.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //使用代码创建 
            Window window = new Window();
            window.Width = 720;
            window.Height = 500;
            window.Background = Brushes.LightSkyBlue;
            window.Title = "Window 1";

            Grid grid = new Grid();

            Label label = new Label();
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.Content = "Hello World";
            label.FontSize = 30;
            grid.Children.Add(label);

            window.Content = grid;

            window.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WindowStyleWindow windowStyleWindow = new WindowStyleWindow();
            windowStyleWindow.Show();
        }
    }
}
