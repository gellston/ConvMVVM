using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConvMVVM.Core.Service.RegionManager
{
    public interface IRegionManager
    {
        #region Function
        public void RegisterCacheView(Type type);
        public void RegisterNoneCacheView(Type type);
        public void RegisterCacheView<TView>() where TView : class;
        public void RegisterNoneCacheView<TView>() where TView : class;
        public void RegisterCacheView(string regionName, Type type);
        public void RegisterCacheView<TView>(string regionName) where TView : class;
        public void RegisterNoneCacheView(string regionName, Type type);
        public void RegisterNoneCacheView<TView>(string regionName) where TView : class;
        public void NavigateCache(string regionName, string viewName);
        public void NavigateCache(string regionName, string viewName, INotifyPropertyChanged viewModel);
        public void NavigateNoneCache(string regionName, string viewName);
        public void NavigateNoneCache(string regionName, string viewName, INotifyPropertyChanged viewModel);
        #endregion
    }

}
