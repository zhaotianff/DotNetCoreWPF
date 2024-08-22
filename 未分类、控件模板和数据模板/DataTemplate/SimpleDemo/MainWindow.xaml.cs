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

namespace SimpleDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            var list = new List<Student>();
            list.Add(new Student() {Id = 1,Name = "意在" });
            list.Add(new Student() { Id = 2, Name = "奎文" });

            this.list1.ItemsSource = list;
            this.list2.ItemsSource = list;
        }
    }
}