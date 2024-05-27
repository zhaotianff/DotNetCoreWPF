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
    /// RecordSizeAndPosWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RecordSizeAndPosWindow : Window
    {
        public RecordSizeAndPosWindow()
        {
            InitializeComponent();

            var winSize = Properties.Settings.Default.WindowSize;
            var winPos = Properties.Settings.Default.WindowPos;
            if (winSize.Width != 0 && winSize.Height != 0)
            {
                this.Left = winPos.X;
                this.Top = winPos.Y;
                this.Width = winSize.Width;
                this.Height = winSize.Height;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //使用RestoreBounds属性获取窗口在最小化或最大化之前的大小和位置
            var restoreBounds = this.RestoreBounds;

            Properties.Settings.Default.WindowPos = new System.Drawing.Point() { X = (int)restoreBounds.X, Y = (int)restoreBounds.Y };
            Properties.Settings.Default.WindowSize = new System.Drawing.Size() { Width = (int)restoreBounds.Width, Height = (int)restoreBounds.Height };

            //保存
            Properties.Settings.Default.Save();
        }
    }
}
