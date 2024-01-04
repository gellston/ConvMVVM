using AModule.View;
using AModule.ViewModel;
using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Module;
using ConvMVVM.Core.Service.RegionManager;
using ConvMVVM.WPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AModule
{
    public class Module : IModule
    {
        public void OnInitialized(IServiceContainer container)
        {

            var regionManager = container.GetService<IRegionManager>();
            regionManager.NavigateCache("MainContent", "AView");
        }

        public void OnInitResource(IServiceContainer container)
        {
        }

        public void OnInitServiceLocator()
        {
            ServiceLocator.RegionManager.RegisterCacheView<AView>();
        }

        public void RegisterService(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<AViewModel>();
        }
    }
}
