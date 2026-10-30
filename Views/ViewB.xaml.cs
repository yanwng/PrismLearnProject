using PrismLearnProject.ViewModels;
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
using Prism.Ioc;
using Prism.Commands;

namespace PrismLearnProject.Views
{
    /// <summary>
    /// ViewB.xaml 的交互逻辑
    /// </summary>
    public partial class ViewB : Window
    {
        public ViewB()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            ViewBViewModel model = (ViewBViewModel)DataContext;

            //不取消注册会导致后台继续执行Command
            ContainerLocator.Container.Resolve<CompositeCommand>().UnregisterCommand(model.IncreateCount);
                
        }
    }
}
