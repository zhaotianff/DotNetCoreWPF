using DataGridDemo.Model;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
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

namespace DataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.grid1.ItemsSource = Student.GetDemoData();

            this.grid2.ItemsSource = GetDataFromDB().DefaultView;

            DataGridComboBoxColumn dataGridComboBoxColumn = this.grid3.Columns[4] as DataGridComboBoxColumn;
            dataGridComboBoxColumn.ItemsSource = Project.GetDemoProjects();
            this.grid3.ItemsSource = User.GetDemoUsers();
        }

        private DataTable GetDataFromDB()
        {
            var sql = "Select * from patient";
            var constr = $"data source = {Environment.CurrentDirectory + "\\patient.db"};version=3";
            using(SQLiteConnection con = new SQLiteConnection(constr))
            {
                con.Open();

                if (con.State != ConnectionState.Open)
                    return new DataTable();

                using (SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    sQLiteDataAdapter.Fill(dt);
                    return dt;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dt = GetDataTableFromDataGrid(this.grid2);
            UpdateToDb(dt);
            MessageBox.Show("更新成功");
        }

        private DataTable GetDataTableFromDataGrid(DataGrid dataGrid)
        {
            return ((DataView)dataGrid.ItemsSource).Table;
        }

        private void UpdateToDb(DataTable dt)
        {
            var constr = $"data source = {Environment.CurrentDirectory + "\\patient.db"};version=3";
            using (SQLiteConnection con = new SQLiteConnection(constr))
            {
                con.Open();
                if (con.State != ConnectionState.Open)
                    return;

                var sql = "Select * from patient";
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = new SQLiteCommand(sql, con);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(da);
                da.Update(dt);
            }
                
        }
    }
}