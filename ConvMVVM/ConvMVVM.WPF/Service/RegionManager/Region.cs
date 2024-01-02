using ConvMVVM.Core.Service.RegionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;

namespace ConvMVVM.WPF.Service.RegionManager
{
    internal class Region : IRegion
    {

        #region Private Property
        private List<WeakReference> viewReferenceList = new List<WeakReference>();
        #endregion

        #region Constructor
        public Region(bool cached, string sourceViewName)
        {
            
        }
        #endregion

        #region Property
        public List<WeakReference> Sources
        {

            get
            {

                var deadControl = viewReferenceList.Where(data => data.IsAlive == false).ToList();
                foreach (var dead in deadControl)
                {
                    viewReferenceList.Remove(dead);
                }

                return viewReferenceList;
            }
        }

        public bool Cached { get; set; } = false;

        public string SourceViewName { get; set; } = "";

        #endregion

        #region Event
                           //ContentControl, FrameworkElement
        public event Action<object, object> OnContentUpdate;
        #endregion


        #region Function
        public void NavigateCacheView()
        {
            try
            {

                if (this.OnContentUpdate != null)
                {
                    var view = ViewTypeStorage.CreateCacheView(this.SourceViewName);
                    var sources = this.Sources;
                    foreach (var source in sources)
                    {
                        var contentControl = source.Target as ContentControl;
                        if (contentControl == null) continue;
                        this.OnContentUpdate(contentControl, view);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

        }

        public void NavigateCacheView(INotifyPropertyChanged viewModel)
        {
            try
            {
                if (this.OnContentUpdate != null)
                {
                    var view = ViewTypeStorage.CreateCacheView(this.SourceViewName);
                    var sources = this.Sources;
                    foreach (var source in sources)
                    {
                        var contentControl = source.Target as ContentControl;
                        if (contentControl == null) continue;
                        contentControl.DataContext = viewModel;
                        this.OnContentUpdate(contentControl, view);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }


        public void NavigateNoneCacheView()
        {
            try
            {
                if (this.OnContentUpdate != null)
                {

                    var sources = this.Sources;
                    foreach (var source in sources)
                    {
                        var view = ViewTypeStorage.CreateNoneCacheView(this.SourceViewName);
                        var contentControl = source.Target as ContentControl;
                        if (contentControl == null) continue;
                        this.OnContentUpdate(contentControl, view);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public void NavigateNoneCacheView(INotifyPropertyChanged viewModel)
        {
            try
            {
                if (this.OnContentUpdate != null)
                {
                    var sources = this.Sources;
                    foreach (var source in sources)
                    {
                        var view = ViewTypeStorage.CreateNoneCacheView(this.SourceViewName);
                        var contentControl = source.Target as ContentControl;
                        if (contentControl == null) continue;
                        contentControl.DataContext = viewModel;
                        this.OnContentUpdate(contentControl, view);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        #endregion
    }
}
