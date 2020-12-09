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
    /// Interaction logic for ResizeWindow.xaml
    /// </summary>
    public partial class ResizeWindow : Window
    {
        public ResizeWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ResizeMode = (ResizeMode)this.combox_ResizeMode.SelectedIndex;
        }
    }
}
