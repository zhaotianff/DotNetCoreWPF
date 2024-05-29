using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordBoxDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.pbox.Paste();

            this.pbox.Clear();

            this.pbox.SelectAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.pbox.Password);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.pbox.Password = "HelloWorld";
        }
    }
}