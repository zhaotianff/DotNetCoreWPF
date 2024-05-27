using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindowDemo
{
    /// <summary>
    /// IrregularElementWindowWithResize.xaml 的交互逻辑
    /// </summary>
    public partial class IrregularElementWindowWithResize : Window
    {
        private bool isPressed = false;

        public IrregularElementWindowWithResize()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isPressed = true;
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isPressed = false;
            var rect = sender as Rectangle;
            rect.ReleaseMouseCapture();  
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                Rectangle rect = sender as Rectangle;
                rect.CaptureMouse();
                var currentPos = e.GetPosition(this.content);
                double newWidth = currentPos.X + 5;
                if(newWidth > 0)
                {
                    this.Width = newWidth + 5; 
                }
            }
        }
    }
}
