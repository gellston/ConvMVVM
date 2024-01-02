using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConvMVVM.WPF.Service.RegionManager
{
    internal static class ViewTypeStorage
    {
        #region Private Property
        public static Dictionary<string, Type> cacheViewType = new Dictionary<string, Type>();
        public static Dictionary<string, Type> nonCacheViewType = new Dictionary<string, Type>();
        public static Dictionary<string, FrameworkElement> cacheView = new Dictionary<string, FrameworkElement>();


        #endregion


        #region Static Function
        public static void RegisterCacheView(Type type)
        {
            if (!cacheViewType.ContainsKey(type.Name))
            {
                cacheViewType.Add(type.Name, type);
            }
        }

        public static void RegisterNoneCacheView(Type type)
        {
            if (!nonCacheViewType.ContainsKey(type.Name))
            {
                nonCacheViewType.Add(type.Name, type);
            }
        }



        public static Type CacheView(string name)
        {
            if (!cacheViewType.ContainsKey(name))
                return null;

            return cacheViewType[name];
        }

        public static Type NoneCacheView(string name)
        {
            if (!nonCacheViewType.ContainsKey(name))
                return null;

            return nonCacheViewType[name];
        }


        public static FrameworkElement CreateCacheView(string name)
        {
            var type = ViewTypeStorage.CacheView(name);
            if (type == null)
                return null;

            if (!cacheView.ContainsKey(type.Name))
            {
                var view = (FrameworkElement)Activator.CreateInstance(type);
                cacheView.Add(name, view);
            }

            return cacheView[name];
        }

        public static FrameworkElement CreateNoneCacheView(string name)
        {
            var type = ViewTypeStorage.NoneCacheView(name);
            if (type == null)
                return null;

            var view = (FrameworkElement)Activator.CreateInstance(type);
            return view;
        }

        #endregion

    }
}
