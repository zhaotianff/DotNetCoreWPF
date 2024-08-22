using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace DynamicListBoxDataTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var list = new List<ImageDetail>();

            list.Add(new ImageDetail() {Title = "scene1", ImageUrl = "https://myfreetime.cn/usr/uploads/2024/4/%E6%B8%85%E5%B9%B3%E8%B0%83%C2%B7%E5%90%8D%E8%8A%B1%E5%80%BE%E5%9B%BD%E4%B8%A4%E7%9B%B8%E6%AC%A2/jk.jpg" });
            list.Add(new ImageDetail() { Title = "scene2", ImageUrl = "https://myfreetime.cn/usr/uploads/2024/4/%E6%B8%85%E5%B9%B3%E8%B0%83%C2%B7%E5%90%8D%E8%8A%B1%E5%80%BE%E5%9B%BD%E4%B8%A4%E7%9B%B8%E6%AC%A2/jk2.jpg" });

            this.listbox.ItemsSource = list;
        }

        private void CreateDataTemplate_Click(object sender, RoutedEventArgs e)
        {
            DataTemplate template = new DataTemplate();

            //创建一个Grid
            FrameworkElementFactory gridFactory = new FrameworkElementFactory(typeof(Grid));

            //创建行
            FrameworkElementFactory row1 = new FrameworkElementFactory(typeof(RowDefinition));
            FrameworkElementFactory row2 = new FrameworkElementFactory(typeof(RowDefinition));
            row2.SetValue(RowDefinition.HeightProperty, new GridLength(30));

            //添加行
            gridFactory.AppendChild(row1);
            gridFactory.AppendChild(row2);

            //添加图像
            FrameworkElementFactory imageFactory = new FrameworkElementFactory(typeof(Image));
            imageFactory.SetValue(Image.SourceProperty, new Binding("ImageUrl"));  //Source
            imageFactory.SetValue(Image.WidthProperty, 150d);                      //Width
            imageFactory.SetValue(Image.HeightProperty, 150d);                     //Height
            gridFactory.AppendChild(imageFactory);

            //添加标题
            FrameworkElementFactory labelFactory = new FrameworkElementFactory(typeof(Label));
            labelFactory.SetValue(Label.ContentProperty, new Binding("Title")); //内容
            labelFactory.SetValue(Label.FontWeightProperty, FontWeights.Bold);  //加粗
            labelFactory.SetValue(Grid.RowProperty, 1);                         //Grid.Row = 1
            labelFactory.SetValue(Label.HorizontalAlignmentProperty, HorizontalAlignment.Center);//HorizontalAlignment
            gridFactory.AppendChild(labelFactory);


            template.VisualTree = gridFactory;

            this.listbox.ItemTemplate = template;
        }

        private void CreateDataTemplateFromLocalFile_Click(object sender, RoutedEventArgs e)
        {
            //bin/Debug目录下
            var templateFile = Environment.CurrentDirectory + "\\template.xaml";
            var xaml = System.IO.File.ReadAllText(templateFile);
            using(StringReader sr = new StringReader(xaml))
            {
                XmlReader reader = XmlReader.Create(sr);
                var template = XamlReader.Load(reader) as DataTemplate;
                this.listbox.ItemTemplate = template;
            }
        }
    }
}