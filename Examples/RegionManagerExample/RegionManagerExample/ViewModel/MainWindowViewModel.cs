using ConvMVVM.Core.Attributes;
using ConvMVVM.Core.Component;
using ConvMVVM.Core.Service.RegionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RegionManagerExample.ViewModel
{
    partial class MainWindowViewModel : NotifyObject
    {
        #region Private Property
        private readonly IRegionManager regionManager;
        #endregion

        #region Constructor
        public MainWindowViewModel(IRegionManager regionManager) { 
        
            this.regionManager = regionManager;
        }
        #endregion

        #region Command
        [RelayCommand]
        public void Test()
        {
            this.regionManager.NavigateCache("MainContent", "AView");
        }
        #endregion
    }
}
