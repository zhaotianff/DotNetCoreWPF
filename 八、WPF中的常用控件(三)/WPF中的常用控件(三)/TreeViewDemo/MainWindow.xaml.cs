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

namespace TreeViewDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddTreeView2();
            AddTreeView3();
        }

        private void AddTreeView3()
        {
            var list = new List<Student>();

            Student student1 = new Student();
            student1.Name = "小湔";
            student1.SubItems = new List<SubItem>() { new SubItem() { Id = "1"} };

            Student student2 = new Student();
            student2.Name = "立海大";
            student2.SubItems = new List<SubItem>() { new SubItem() { Id = "2" } };

            list.Add(student1);
            list.Add(student2);

            this.tree3.ItemsSource = list;
        }

        private void AddTreeView2()
        {
            TreeViewItem item1 = new TreeViewItem();
            item1.Header = "小湔";

            TreeViewItem item1SubItem1 = new TreeViewItem();
            item1SubItem1.Header = "1";
            TreeViewItem item1SubItem2 = new TreeViewItem();
            item1SubItem2.Header = "80";

            //每一个TreeViewItem都是一个ItemsControl控件
            item1.Items.Add(item1SubItem1);
            item1.Items.Add(item1SubItem2);

            TreeViewItem item2 = new TreeViewItem();
            item2.Header = "立海大";

            TreeViewItem item2SubItem1 = new TreeViewItem();
            item2SubItem1.Header = "2";
            TreeViewItem item2SubItem2 = new TreeViewItem();
            item2SubItem2.Header = "80";

            item2.Items.Add(item2SubItem1);
            item2.Items.Add(item2SubItem2);

            this.tree2.Items.Add(item1);
            this.tree2.Items.Add(item2);
        }
    }
}