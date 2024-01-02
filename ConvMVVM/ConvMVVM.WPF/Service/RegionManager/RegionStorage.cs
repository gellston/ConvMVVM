using ConvMVVM.Core.Service.RegionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvMVVM.WPF.Service.RegionManager
{
    public static class RegionStorage
    {
        #region Private Property
        private static Dictionary<string, IRegion> regions = new Dictionary<string, IRegion>();
        #endregion

        #region Function
        public static IRegion RegisterRegion(string regionKey, Type viewType, bool cached)
        {
            foreach (var region in regions)
            {
                if (region.Key == regionKey)
                {
                    throw new InvalidOperationException("Duplicate region key.");
                }
            }

            var _region = new Region(cached, viewType.Name);
            regions.Add(regionKey, _region);

            return _region;
        }

        public static void RegisterRegion(string regionKey)
        {
            var _region = new Region(true, "");
            regions.Add(regionKey, _region);
        }

        public static IRegion Region(string regionKey)
        {
            if (!regions.ContainsKey(regionKey))
            {
                return null;
            }

            var region = regions[regionKey];

            return region;
        }

        public static bool CheckExist(string regionKey)
        {
            if (regions.ContainsKey(regionKey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }

}
