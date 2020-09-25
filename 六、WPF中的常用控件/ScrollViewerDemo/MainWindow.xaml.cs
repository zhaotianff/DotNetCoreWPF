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

namespace ScrollViewerDemo
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

        private void ScrollToTop_Click(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToTop();
        }

        private void ScrollToEnd_Click(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToEnd();
        }

        private void LineLeft_Click(object sender, RoutedEventArgs e)
        {
            scroll.LineLeft();
        }

        private void LineRight_Click(object sender, RoutedEventArgs e)
        {
            scroll.LineRight();
        }

        private void ScrollToVerticalOffset_Click(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToVerticalOffset(20);
        }

        private void ScrollToHorizontalOffset_Click(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToHorizontalOffset(40);
        }

        private void PageDown_Click(object sender, RoutedEventArgs e)
        {
            scroll.PageDown();
        }

        private void PageRight_Click(object sender, RoutedEventArgs e)
        {
            scroll.PageRight();
        }
    }
}
