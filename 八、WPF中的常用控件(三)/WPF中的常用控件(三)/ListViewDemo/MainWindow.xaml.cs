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

namespace ListViewDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadListView1Data();
            CreateListView2();
            LoadListView2Data();
            LoadListView3Data();
        }

        private void LoadListView3Data()
        {
            this.listview3.ItemsSource = Model.GetTestData();
        }

        private void LoadListView1Data()
        {
            var list = new List<Employee>();

            Employee employee1 = new Employee() { FirstName = "FirstName1",LastName = "LastName1",EmployeeNumber = "100"};
            Employee employee2 = new Employee() { FirstName = "FirstName2", LastName = "LastName2", EmployeeNumber = "200" };
            Employee employee3 = new Employee() { FirstName = "FirstName3", LastName = "LongLongLongLongLongLongLongName3", EmployeeNumber = "300" };

            list.Add(employee1);
            list.Add(employee2);
            list.Add(employee3);

            this.listview1.ItemsSource = list;
        }

        private void CreateListView2()
        {
            GridView myGridView = new GridView();
            myGridView.AllowsColumnReorder = true;
            myGridView.ColumnHeaderToolTip = "Employee Information";

            GridViewColumn gvc1 = new GridViewColumn();
            gvc1.DisplayMemberBinding = new Binding("FirstName");
            gvc1.Header = "FirstName";
            gvc1.Width = 100;
            myGridView.Columns.Add(gvc1);
            GridViewColumn gvc2 = new GridViewColumn();
            gvc2.DisplayMemberBinding = new Binding("LastName");
            gvc2.Header = "Last Name";
            gvc2.Width = 100;
            myGridView.Columns.Add(gvc2);
            GridViewColumn gvc3 = new GridViewColumn();
            gvc3.DisplayMemberBinding = new Binding("EmployeeNumber");
            gvc3.Header = "Employee No.";
            gvc3.Width = double.NaN;
            myGridView.Columns.Add(gvc3);

            this.listview2.View = myGridView;
        }

        private void LoadListView2Data()
        {
            var list = new List<Employee>();

            Employee employee1 = new Employee() { FirstName = "FirstName1", LastName = "LastName1", EmployeeNumber = "100" };
            Employee employee2 = new Employee() { FirstName = "FirstName2", LastName = "LastName2", EmployeeNumber = "200" };

            list.Add(employee1);
            list.Add(employee2);

            this.listview2.ItemsSource = list;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewName = (this.combox.SelectedItem as ComboBoxItem)?.Content;
            this.listview3.View = (ViewBase)this.FindResource(viewName?.ToString());
        }
    }
}