using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PrismLearnProject.ViewModels
{
    internal class DialogViewBViewModel : IDialogAware
    {
        public string Title => "我是ViewB";

        public bool IsEnableClose { get; set; } = true;

        public event Action<IDialogResult> RequestClose;


        public bool CanCloseDialog()
        {
            return IsEnableClose;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}
