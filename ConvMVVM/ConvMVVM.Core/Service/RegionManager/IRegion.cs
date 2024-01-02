using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConvMVVM.Core.Service.RegionManager
{
    public interface IRegion
    {
        #region Property
        public bool Cached { get; set; }
        public string SourceViewName { get; set; }
        public List<WeakReference> Sources { get; }
        #endregion

        #region Function
        public void NavigateCacheView();
        public void NavigateCacheView(INotifyPropertyChanged viewModel);
        public void NavigateNoneCacheView();
        public void NavigateNoneCacheView(INotifyPropertyChanged viewModel);
        #endregion

        #region Event
        public event Action<object, object> OnContentUpdate;
        #endregion
    }

}
