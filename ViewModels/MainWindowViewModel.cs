using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Services.Dialogs;
using PrismLearnProject.HelpClass;
using PrismLearnProject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PrismLearnProject.ViewModels
{
    public class MainWindowViewModel
    {
        public string TitleStr { get; set; } = "学习使我进步";

        public DelegateCommand ShowTitleCommand { get; set; }
        public DelegateCommand<string> OpenDialogView { get; set; } 
        public DelegateCommand<string> OpenWindowCommand { get; set; }

        public bool IsEnableMove { get; set; }
        

        IEventAggregator eventAggregator;
        IContainerProvider container;
        DialogService dialogService;

        public MainWindowViewModel(IEventAggregator _eventAggregator,IContainerProvider _container,DialogService _dialogService) 
        {
            ShowTitleCommand=new DelegateCommand(ShowTitle);
            OpenWindowCommand = new DelegateCommand<string>(OpenWindow);
            OpenDialogView = new DelegateCommand<string>(OpenDialog);
            
            container = _container;
            eventAggregator = _eventAggregator;
            dialogService= _dialogService;
          //  eventAggregator.GetEvent<EventMessageArgs>().Subscribe(ShowTitle);


        }

        //打开DialogView
        private void OpenDialog(string ViewName)
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("Message","我是模态弹窗的参数");
            dialogService.Show(ViewName, parameters, Result=> { MessageBox.Show(Result.Parameters.GetValue<string>("result")); });
        }

        private void OpenWindow(string windowName)
        {
            if (windowName == "ViewA")
                container.Resolve<ViewA>().Show();
            if (windowName == "ViewB")
                container.Resolve<ViewB>().Show();
        }

        //弹出当前窗口的title
        private void ShowTitle()
        {
            Task.Run(() =>
            {
                eventAggregator.GetEvent<EventMessageArgs>().Publish("MainView传入的参数");

            });
         }

        
    }
}
