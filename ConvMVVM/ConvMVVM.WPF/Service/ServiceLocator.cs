using ConvMVVM.Core.Service.DialogService;
using ConvMVVM.Core.Service.RegionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvMVVM.WPF.Service
{
    public partial class ServiceLocator
    {
        private static IDialogService dialogService = null;
        public static IDialogService DialogService
        {
            get
            {
                if(dialogService == null)
                    dialogService = new DialogService.DialogService();

                return dialogService;
            }
        }


        private static IRegionManager regionManager = null;
        public static IRegionManager RegionManager
        {
            get
            {
                if(regionManager == null)
                    regionManager = new RegionManager.RegionManager();

                return regionManager;
            }
        }

    }
}
