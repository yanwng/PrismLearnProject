using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// MainRegionView.xaml 的交互逻辑
    /// </summary>
    public partial class MainRegionView : Window
    {
        public MainRegionView(IRegionManager regionManager)
        {
            InitializeComponent();

            //将该窗口中的所有区域注册到总RegionManager中
            RegionManager.SetRegionManager(this,regionManager); 
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility=Visibility.Collapsed;
        }
    }
}
