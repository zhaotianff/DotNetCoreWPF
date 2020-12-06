using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindowDemo
{
    /// <summary>
    /// Interaction logic for WindowStyleWindow.xaml
    /// </summary>
    public partial class WindowStyleWindow : Window
    {
        public WindowStyleWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.WindowStyle = (WindowStyle)combox_WindowStyle.SelectedIndex;
        }
    }
}
