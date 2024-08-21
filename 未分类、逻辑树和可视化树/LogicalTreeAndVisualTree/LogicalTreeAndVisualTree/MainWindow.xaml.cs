using System.Diagnostics;
using System.Reflection.Emit;
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
using System.Xml.Linq;

namespace LogicalTreeAndVisualTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void PrintLogicalTree(object parent, int level)
        {
            var parentObj = parent as DependencyObject;
            var typeName = parent.GetType().FullName;
            var name = "";
            if (parentObj != null)
            {
                name = (string)(parentObj.GetValue(FrameworkElement.NameProperty) ?? "");
            }
            else
            {
                name = parent.ToString();
            }

            AppendText(GetIndentString().Substring(0, level * 2));
            AppendText($"{typeName}:", true);
            AppendText($" {name}");
            AppendText(Environment.NewLine);

            if (parentObj == null)
                return;

            var children = LogicalTreeHelper.GetChildren(parentObj);
            foreach (object child in children)
            {
                PrintLogicalTree(child, level + 1);
            }
        }

        public void PrintVisualTree(DependencyObject parent, int level)
        {
            string typeName = parent.GetType().FullName ?? parent.GetType().Name;
            string name = (string)(parent.GetValue(FrameworkElement.NameProperty) ?? "");
            AppendText(GetIndentString().Substring(0, level * 2));
            AppendText($"{typeName}:",true);
            AppendText($" {name}");
            AppendText(Environment.NewLine);
            for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                PrintVisualTree(child, level + 1);
            }
        }

        private void AppendText(string text,bool isbold = false)
        {
            if (this.rtbox.Document.Blocks.Count == 0)
            {
                Paragraph paragraph = new Paragraph(isbold ? new Bold(new Run(text)) : new Run(text));
                this.rtbox.Document.Blocks.Add(paragraph);
            }
            else
            {
                (this.rtbox.Document.Blocks.ElementAt(0) as Paragraph)?.Inlines.Add(isbold ? new Bold(new Run(text)) : new Run(text));
            }
        }

        private void ClearText()
        {
            this.rtbox.Document.Blocks.Clear();
        }

        private void GetVisualTree_Click(object sender, RoutedEventArgs e)
        {
            ClearText();
            PrintVisualTree(this.grid, 0);
        }

        private void GetLogicalTree_Click(object sender, RoutedEventArgs e)
        {
            ClearText();
            PrintLogicalTree(this.grid, 0);
        }

        private string GetIndentString()
        {
            return " ".PadLeft(100, ' ');
        }

        private void GetChildViaLogicalTree_Click(object sender, RoutedEventArgs e)
        {
            var obj = this.grid.FindName("btn1");
            MessageBox.Show(obj.GetType().FullName);
        }

        private void GetChildViaVisualTree_Click(object sender, RoutedEventArgs e)
        {
            //查找控件模板中的名称为Border的控件
            var border = EnumVisual(this.btn1, "Border");
            if (border != null)
            {
                var borderObj = border as Border;

                if (borderObj != null)
                {
                    borderObj.CornerRadius = new CornerRadius(10);
                }
            }

            //也可以通过下面的方式
            //object findObj = this.btn1.Template.FindName("Border",this.btn1);
        }

        public Visual EnumVisual(Visual myVisual,string controlName)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                var nameObj = childVisual.GetValue(NameProperty);

                if (nameObj != null && nameObj.ToString() == controlName)
                    return childVisual;

                EnumVisual(childVisual,controlName);
            }

            return null;
        }
    }
}