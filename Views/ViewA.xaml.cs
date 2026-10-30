using Prism.Commands;
using Prism.Ioc;
using PrismLearnProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
    /// ViewA.xaml 的交互逻辑
    /// </summary>
    public partial class ViewA : Window
    {
        
       public CompositeCommand composite;
        public ViewA()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
           ViewAViewModel model = (ViewAViewModel)DataContext;
            ContainerLocator.Container.Resolve<CompositeCommand>().UnregisterCommand(model.IncreateCount);
        }
    }
}
