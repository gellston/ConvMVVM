using ConvMVVM.Core.Service.RegionManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ConvMVVM.WPF.Service.RegionManager
{
    public class RegionManager : IRegionManager
    {
        #region Private Property

        #endregion

        #region Constructor
        public RegionManager()
        {

        }
        #endregion

        #region Dependency Property
        public static DependencyProperty RegionNameProperty = DependencyProperty.RegisterAttached("RegionName", typeof(string), typeof(RegionManager), new PropertyMetadata("", OnRegionNameChanged));
        #endregion

        #region Static Function
        private static bool IsInDesignMode(DependencyObject element)
        {
            return DesignerProperties.GetIsInDesignMode(element);
        }
        #endregion

        #region Event Handler
        public static string GetRegionName(DependencyObject obj)
        {
            return (string)obj.GetValue(RegionNameProperty);
        }

        public static void SetRegionName(DependencyObject obj, string value)
        {
            obj.SetValue(RegionNameProperty, value);
        }

        private static void OnRegionNameChanged(DependencyObject element, DependencyPropertyChangedEventArgs args)
        {
            if (!IsInDesignMode(element))
            {
                var regionKey = GetRegionName(element);
                var contentControl = element as ContentControl;
                if (contentControl != null)
                {
                    if ((string)args.NewValue != "")
                    {

                        try
                        {

                            if (!RegionStorage.CheckExist(regionKey))
                            {
                                RegionStorage.RegisterRegion(regionKey);
                            }

                            var region = RegionStorage.Region(regionKey);
                            region.Sources.Add(new WeakReference(contentControl));
                            region.OnContentUpdate -= OnContentUpdate;
                            region.OnContentUpdate += OnContentUpdate;

                            if (region.Cached == true)
                            {
                                region.NavigateCacheView();
                            }
                            else
                            {
                                region.NavigateNoneCacheView();
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }

                    }
                }
            }
        }
                                            //ContentControl      //FrameworkElement
        private static void OnContentUpdate(object target, object content)
        {

            var contentControl = (ContentControl)target;
            if (contentControl == null) return;

            contentControl.Content = content;
        }


        #endregion

        #region Function
        public void NavigateCache(string regionName, string viewName)
        {
            try
            {
                var region = RegionStorage.Region(regionName);
                region.SourceViewName = viewName;
                region.Cached = true;
                region.NavigateCacheView();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void NavigateCache(string regionName, string viewName, INotifyPropertyChanged viewModel)
        {
            try
            {

                var region = RegionStorage.Region(regionName);
                region.SourceViewName = viewName;
                region.Cached = true;
                region.NavigateCacheView(viewModel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void NavigateNoneCache(string regionName, string viewName)
        {
            try
            {

                var region = RegionStorage.Region(regionName);
                region.SourceViewName = viewName;
                region.Cached = false;
                region.NavigateNoneCacheView();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void NavigateNoneCache(string regionName, string viewName, INotifyPropertyChanged viewModel)
        {
            try
            {
                var region = RegionStorage.Region(regionName);
                region.SourceViewName = viewName;
                region.Cached = false;
                region.NavigateNoneCacheView(viewModel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void RegisterCacheView(Type type)
        {
            ViewTypeStorage.RegisterCacheView(type);
            ViewTypeStorage.CreateCacheView(type.Name);
        }

        public void RegisterCacheView<TView>() where TView : class
        {
            this.RegisterCacheView(typeof(TView));
        }




        public void RegisterNoneCacheView(Type type)
        {
            ViewTypeStorage.RegisterNoneCacheView(type);
        }

        public void RegisterNoneCacheView<TView>() where TView : class
        {
            this.RegisterNoneCacheView(typeof(TView));
        }


        public void RegisterCacheView(string regionName, Type type)
        {
            ViewTypeStorage.RegisterCacheView(type);
            ViewTypeStorage.CreateCacheView(type.Name);

            if (RegionStorage.CheckExist(regionName))
            {
                var region = RegionStorage.Region(regionName);
                region.SourceViewName = type.Name;
                region.Cached = true;
            }
            else
            {
                RegionStorage.RegisterRegion(regionName, type, true);
            }
        }

        public void RegisterCacheView<TView>(string regionName) where TView : class
        {
            this.RegisterCacheView(regionName, typeof(TView));
        }

        public void RegisterNoneCacheView(string regionName, Type type)
        {
            ViewTypeStorage.RegisterNoneCacheView(type);

            if (RegionStorage.CheckExist(regionName))
            {
                var region = RegionStorage.Region(regionName);
                region.SourceViewName = type.Name;
                region.Cached = false;
            }
            else
            {
                RegionStorage.RegisterRegion(regionName, type, false);
            }
        }

        public void RegisterNoneCacheView<TView>(string regionName) where TView : class
        {
            this.RegisterNoneCacheView(regionName, typeof(TView));
        }
        #endregion

    }
}
