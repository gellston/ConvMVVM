using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Service.RegionManager;
using ConvMVVM.WPF.Component;
using ConvMVVM.WPF.Service;
using RegionManagerExample.View;
using RegionManagerExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RegionManagerExample
{
    public class App : ConvMVVMApp
    {
        protected override void ConfigureServiceLocator()
        {
            //ServiceLocator.RegionManager.RegisterCacheView<AView>();
        }

        protected override void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<MainWindowViewModel>();
            serviceCollection.RegisterCache<AViewModel>();
        }

        protected override void ConfigureServiceProvider(IServiceContainer serviceProvider)
        {
            var regionManager = serviceProvider.GetService<IRegionManager>();
            regionManager.RegisterCacheView<AView>();
        }

        protected override Window CreateWindow(IServiceContainer serviceProvider)
        {
            return new MainWindowView();
        }
    }
}
