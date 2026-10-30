using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismLearnProject.HelpClass;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PrismLearnProject.ViewModels
{
    
    public class ViewAViewModel:BindableBase
    {
        public string TitleStr { get; set; } = "我是ViewA";

        public int Count { get; set { SetProperty(ref field, value); } }

        public DelegateCommand IncreateCount { get; set; }
        public ViewAViewModel( IEventAggregator eventAggregator,CompositeCommand composite)
        {
            IncreateCount = new DelegateCommand(() => { Count++; });
            composite.RegisterCommand( IncreateCount);
            
            eventAggregator.GetEvent<EventMessageArgs>().Subscribe(ShowTitle);
        }

        //弹出当前窗口的title
        private void ShowTitle(string param)
        {
            MessageBox.Show(TitleStr + param);
        }

    }
}
