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

namespace ListBoxDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AddToListBox1();
            AddToListBox3();
            AddToListBox4();
        }

        private void AddToListBox4()
        {
            List<Student> students = new List<Student>();
            Student student = new Student() {Id = 1,Name = "小浃" };
            Student student1 = new Student() { Id = 2,Name = "新海诚"};
            students.Add(student);
            students.Add(student1);
            this.listbox4.ItemsSource = students;
        }

        private void AddToListBox1()
        {
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");

            this.listbox1.ItemsSource = list;
        }

        private void AddToListBox3()
        {
            ListBoxItem listBoxItem = new ListBoxItem();
            listBoxItem.Content = "HelloWorld";

            ListBoxItem listBoxItem2 = new ListBoxItem();
            listBoxItem2.Content = DateTime.Now;

            ListBoxItem listBoxItem3 = new ListBoxItem();
            listBoxItem3.Content = new Image() {Height=150,Stretch=Stretch.Uniform, Source = new BitmapImage(new Uri("https://img0.baidu.com/it/u=2560415768,2503528984&fm=253&app=138&size=w931&n=0&f=JPEG&fmt=auto?sec=1717261200&t=9c08bc35cfa6953d1b68c3bdcbc7e8f9")) };

            this.listbox3.Items.Add(listBoxItem);
            this.listbox3.Items.Add(listBoxItem2);
            this.listbox3.Items.Add(listBoxItem3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.listbox1.SelectedIndex == -1)
                return;

            var element = this.listbox1.ItemContainerGenerator.ContainerFromIndex(this.listbox1.SelectedIndex);

            MessageBox.Show($"类型:{element.GetType()}\r\n内容:{element.ToString()}");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.listbox4.SelectedValue.ToString());
        }

        private void listbox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var removedItems = e.RemovedItems;//取消选中的项
            var addedItems = e.AddedItems;    //新选中的项
        }
    }
}