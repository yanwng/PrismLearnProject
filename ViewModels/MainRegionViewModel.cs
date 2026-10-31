using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace PrismLearnProject.ViewModels
{
    public class MainRegionViewModel:BindableBase
    {
        
        IRegionManager regionManager;

        //public DelegateCommand<string> ExChanageRegion  => field ?? (field = new DelegateCommand<string>(ChanageRegion));
        public DelegateCommand<string> ExChanageRegion {  get; set; }

        public MainRegionViewModel(IRegionManager _regionManager)
        {
            ExChanageRegion = new DelegateCommand<string>(ChanageRegion);
            regionManager = _regionManager;
            
        }

        private void ChanageRegion(string parameter)
        {
            string[] strings = parameter.Split(','); //第一个为导航到的View，第二个为需要导航的Region
            regionManager.RequestNavigate(strings[1], strings[0]);
            //regionManager.AddToRegion("MainRegion", regionManager.Regions.FirstOrDefault(view=>view.Name==ViewName));
        }   
    }
}
