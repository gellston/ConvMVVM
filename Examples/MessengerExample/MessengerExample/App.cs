using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Module;
using ConvMVVM.Core.Service.RegionManager;
using ConvMVVM.WPF.Component;
using ConvMVVM.WPF.Service;
using MessengerExample.View;
using MessengerExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessengerExample
{
    public class App : ConvMVVMApp
    {

        protected override void ConfigureServiceLocator()
        {
            ServiceLocator.RegionManager.RegisterCacheView<MainWindowView>();
            ServiceLocator.RegionManager.RegisterCacheView<AView>();
            ServiceLocator.RegionManager.RegisterCacheView<BView>();
        }


        protected override void ConfigureModule(ModuleCollection modules)
        {

        }


        protected override void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<MainWindowViewModel>();
            serviceCollection.RegisterCache<AViewModel>();
            serviceCollection.RegisterCache<BViewModel>();
        }


        protected override void ConfigureServiceProvider(IServiceContainer serviceProvider)
        {
    

        }

        protected override Window CreateWindow(IServiceContainer serviceProvider)
        {
            var regionManager = serviceProvider.GetService<IRegionManager>();
            regionManager.NavigateCache("AView", "AView");
            regionManager.NavigateCache("BView", "BView");

            return new MainWindowView();
        }
    }
}
