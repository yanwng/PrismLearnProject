using Prism.Commands;
using Prism.Ioc;
using Prism.Unity;
using PrismLearnProject.ViewModels;
using PrismLearnProject.Views;
using PrismLearnProject.Views.Regions;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PrismLearnProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<ViewAViewModel>();
            //containerRegistry.Register<ViewBViewModel>();
            //containerRegistry.Register<ViewA>();
            //containerRegistry.Register<ViewB>();

            containerRegistry.RegisterDialog<DialogViewA>();
            containerRegistry.RegisterDialog<DialogViewB>();
            containerRegistry.RegisterDialogWindow<DialogParent>();

            //注册一个复合命令
            containerRegistry.RegisterSingleton<CompositeCommand>();

            //注册含区域的窗口为单例
            containerRegistry.RegisterSingleton<MainRegionView>();

            //注册区域页面
            containerRegistry.RegisterForNavigation<RegionA>();
            containerRegistry.RegisterForNavigation<RegionB>();
            containerRegistry.RegisterForNavigation<RegionC>();
        }
    }

}
