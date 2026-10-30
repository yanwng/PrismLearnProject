using Prism.Events;
using PrismLearnProject.HelpClass;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PrismLearnProject.ViewModels
{
    
    public class ViewAViewModel
    {
        public string TitleStr { get; set; } = "我是ViewA";

        public ViewAViewModel( IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<EventMessageArgs>().Subscribe(ShowTitle);
        }

        //弹出当前窗口的title
        private void ShowTitle(string param)
        {
            MessageBox.Show(TitleStr + param);
        }

    }
}
