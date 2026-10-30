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

namespace PrismLearnProject.Views
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

        public bool IsEnable { get; set; }

        public Point PreMousePoint { get; set; }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PreMousePoint = e.GetPosition(null);
            IsEnable = true;
            Mouse.Capture(this);
            
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsEnable = false;
            Mouse.Capture(null);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsEnable) 
            {
                Point point = e.GetPosition(null);
                this.Left += point.X - PreMousePoint.X;
                this.Top += point.Y - PreMousePoint.Y;
            }


            

        }
    }
}
