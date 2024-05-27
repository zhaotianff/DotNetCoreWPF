using Microsoft.Win32;
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

namespace WindowDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadSystemParameters();
        }

        private void LoadSystemParameters()
        {
            lbl_FullScreenSize.Content = $"工作区域宽度 :{SystemParameters.FullPrimaryScreenWidth} 高度:{SystemParameters.FullPrimaryScreenHeight}";
            lbl_ScreenSize.Content = $"屏幕宽度 :{SystemParameters.PrimaryScreenWidth} 高度:{SystemParameters.PrimaryScreenHeight}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TransparencyWindow transparencyWindow = new TransparencyWindow();
            transparencyWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //使用XAML布局
            XAMLWindow xAMLWindow = new XAMLWindow();
            xAMLWindow.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //使用代码创建 
            Window window = new Window();
            window.Width = 720;
            window.Height = 500;
            window.Background = Brushes.LightSkyBlue;
            window.Title = "Window 1";

            Grid grid = new Grid();

            Label label = new Label();
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.Content = "Hello World";
            label.FontSize = 30;
            grid.Children.Add(label);

            window.Content = grid;

            window.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WindowStyleWindow windowStyleWindow = new WindowStyleWindow();
            windowStyleWindow.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            IconWindow iconWindow = new IconWindow();
            iconWindow.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ResizeWindow resizeWindow = new ResizeWindow();
            resizeWindow.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            XAMLWindow xAMLWindow = new XAMLWindow();
            xAMLWindow.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            XAMLWindow xAMLWindow = new XAMLWindow();
            xAMLWindow.ShowDialog();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Button_Click_9(object sender, RoutedEventArgs e)
        {
            //隐藏窗口
            this.Visibility = Visibility.Hidden;

            //等待2秒后又显示窗口
            await Task.Delay(2000);
            this.Visibility = Visibility.Visible;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            //在窗口的Closing事件中添加 e.Cancel = true
            //可以阻止窗口关闭
            this.Closing += Window_Closing;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            DialogResultWindow dialogResultWindow = new DialogResultWindow();

            var result = dialogResultWindow.ShowDialog();

            MessageBox.Show(result.ToString());
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            XAMLWindow xAMLWindow = new XAMLWindow();
            xAMLWindow.Owner = this; //设置XAMLWindow的拥有者为当前窗口
            xAMLWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner; //XAMLWindow的启动位置设置为当前窗口的中央
            xAMLWindow.Show();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            XAMLWindow xAMLWindow = new XAMLWindow();
            xAMLWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen; //XAMLWindow的启动位置设置为屏幕中央
            xAMLWindow.Show();
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            XAMLWindow xAMLWindow = new XAMLWindow();
            xAMLWindow.WindowStartupLocation = WindowStartupLocation.Manual; //XAMLWindow的启动位置设置为手动
            xAMLWindow.Left = 80; //距离屏幕左边边缘的距离是80
            xAMLWindow.Top = 100;  //距离屏幕顶部边缘的距离是100
            xAMLWindow.Show();
        }

        private void GetScreenParamters()
        {
            //多个屏幕时
            System.Windows.Forms.Screen[] allScreen = System.Windows.Forms.Screen.AllScreens;

            //屏幕1的工作区域
            var firstScreenWorkingArea = allScreen[0].WorkingArea;
            var width = firstScreenWorkingArea.Width;
            var height = firstScreenWorkingArea.Height;
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            RecordSizeAndPosWindow recordSizeAndPosWindow = new RecordSizeAndPosWindow();
            recordSizeAndPosWindow.Show();
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            PngWindow pngWindow = new PngWindow();
            pngWindow.Show();
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            PathWindow pathWindow = new PathWindow();
            pathWindow.Show();
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            IrregularElementWindow irregularElementWindow = new IrregularElementWindow();
            irregularElementWindow.Show();
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            IrregularElementWindowWithResize irregularElementWindow = new IrregularElementWindowWithResize();
            irregularElementWindow.Show();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
        }
    }
}
