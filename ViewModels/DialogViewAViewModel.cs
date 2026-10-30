using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PrismLearnProject.ViewModels
{
    internal class DialogViewAViewModel :BindableBase ,IDialogAware
    {
        public string Title => "DialogViewA";

        public string Message { get; 
            set 
                { 
                    SetProperty(ref field, value); 
                } 
        }



        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("Message");
        }
    }
}
