using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Module;
using ConvMVVM.Core.Module.Extensions;
using ConvMVVM.Core.Service.RegionManager;
using ConvMVVM.WPF.Component;
using ConvMVVM.WPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTest.View;
using WPFTest.ViewModel;

namespace WPFTest
{
    internal class App : ConvMVVMApp
    {


        protected override void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {

            serviceCollection.RegisterCache<MainWindowViewModel>();
            serviceCollection.RegisterCache<AWindowViewModel>();
            serviceCollection.RegisterCache<BWindowViewModel>();
            serviceCollection.RegisterCache<AViewModel>();
            serviceCollection.RegisterCache<TestViewModel>();
       
        }


        protected override void ConfigureServiceProvider(IServiceContainer serviceProvider)
        {
            var regionManager = serviceProvider.GetService<IRegionManager>();
            regionManager.NavigateCache("TestView", "TestView");
            regionManager.NavigateCache("AView", "AView");
        }


        protected override void ConfigureServiceLocator()
        {

            ServiceLocator.RegionManager.RegisterCacheView<TestView>("TestView");
            ServiceLocator.RegionManager.RegisterCacheView<AView>("AView");

            ServiceLocator.DialogService.RegisterDialog<AWindowView>();
            ServiceLocator.DialogService.RegisterDialog<BWindowView>();
           

           
        }

        protected override void ConfigureModule(ModuleCollection modules)
        {
    

        }

        protected override Window CreateWindow(IServiceContainer serviceProvider)
        {
            return new MainWindowView();
        }
    }
}
