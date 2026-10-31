using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismLearnProject.ViewModels.Regions
{
    public class RegionAViewModel : BindableBase, INavigationAware,IRegionMemberLifetime
    {

        public int Count { get; set { SetProperty(ref field, value); if (value >= 10) IsEnable = false; } }

        //是否允许Count++
        public bool IsEnable { get; set { SetProperty(ref field, value); } } = true;
        public DelegateCommand CountIncreate => field ?? (field = new DelegateCommand(() => { Count++; }).ObservesCanExecute(()=> IsEnable));

        public IRegionNavigationJournal journal { get; set { SetProperty(ref field, value); } }

        public bool CanForward { get; set { SetProperty(ref field, value); } } = true;

        public DelegateCommand GoForward => field ?? (field = new DelegateCommand(() =>
        { if (journal.CanGoForward) { journal.GoForward(); } CanForward = journal.CanGoForward; }));
            //.ObservesCanExecute(()=>CanForward);

        public bool CanBack { get; set { SetProperty(ref field, value); } } = true;
        public DelegateCommand GoBack => field ?? (field = new DelegateCommand(() =>
        { if (journal.CanGoBack) journal.GoBack(); CanBack = journal.CanGoBack; }));

        //区域跳转或关闭后是否保持对象存活，如果为可重复进入则为true，否则IsNavigationTarget将会失效
        public bool KeepAlive => true; 

        //.ObservesCanExecute(()=>CanBack);

        public RegionAViewModel()
        {
            
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //true:重复进入该区域时不会创建新对象
            //false:重复进入该区域时会重新创建新对象
                
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
