using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismLearnProject.ViewModels.Regions
{
    public class RegionAViewModel : BindableBase, INavigationAware
    {

        public int Count { get; set { SetProperty(ref field, value); if (value >= 10) IsEnable = false; } }

        public bool IsEnable { get; set { SetProperty(ref field, value); } } = true;
        public DelegateCommand CountIncreate => field ?? (field = new DelegateCommand(() => { Count++; }).ObservesCanExecute(()=> IsEnable));

        public IRegionNavigationJournal journal { get; set { SetProperty(ref field, value); } }

        public DelegateCommand GoForward => field ?? (field = new DelegateCommand(() => 
        { if (journal.CanGoForward) journal.GoForward();  }));

        public DelegateCommand GoBack => field ?? (field = new DelegateCommand(() =>
        { if (journal.CanGoBack) journal.GoBack(); }));

        public RegionAViewModel()
        {
            
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            journal = navigationContext.NavigationService.Journal;

            //GoBack?.ObservesCanExecute(() => journal.CanGoBack);

            //GoForward?.ObservesCanExecute(() => journal.CanGoForward);

            
        }
    }
}
