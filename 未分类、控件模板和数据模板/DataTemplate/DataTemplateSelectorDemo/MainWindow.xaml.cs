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

namespace DataTemplateSelectorDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //创建测试数据
            Disk disk = new Disk();
            disk.DiskName = "D:\\";

            Folder folder = new Folder();
            folder.FullPath = "D:\\Software";
            folder.Size = 1024;
            disk.Folders.Add(folder);

            Disk disk2 = new Disk();
            disk2.DiskName = "E:\\";

            Folder folder2 = new Folder();
            folder2.FullPath = "E:\\Documents";
            folder2.Size = 2048;
            disk2.Folders.Add(folder2);

            List<Disk> disks = new List<Disk>();
            disks.Add(disk);
            disks.Add(disk2);

            this.treeview.ItemTemplateSelector = new NodeDataTemplateSelector();
            this.treeview.ItemsSource = disks;



            List<FileData> fileDatas = new List<FileData>();
            FileData1 fileData1 = new FileData1();
            fileData1.FileName = "1.jpg";
            fileData1.FileData1Property = "1.jpg property";
            FileData2 fileData2 = new FileData2();
            fileData2.FileName = "2.jpg";
            fileData2.FileData2Property = "2.jpg property";
            fileDatas.Add(fileData1);
            fileDatas.Add(fileData2);
            this.listbox.ItemTemplateSelector = new ItemDataTemplateSelector();
            this.listbox.ItemsSource = fileDatas;
        }
    }
}
