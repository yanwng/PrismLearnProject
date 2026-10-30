using Prism.Ioc;
using Prism.Unity;
using PrismLearnProject.ViewModels;
using PrismLearnProject.Views;
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
        }
    }

}
