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

namespace NestedElements
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

        private void TestMethod()
        {
            /*
             * <Window>
                   <Grid>
                        <Button Content="OK"/>
                        <Label Content="label"/>
                        <TextBox/>
                   </Grid>
               </Window>
            */

            //以上XAML代码实际对应以下C#代码

            Grid grid = new Grid();

            Button button = new Button();
            button.Content = "OK";

            Label label = new Label();
            label.Content = "label";

            TextBox textBox = new TextBox();

            grid.Children.Add(button);
            grid.Children.Add(label);
            grid.Children.Add(textBox);

            this.Content = grid;
            
        }
    }
}
