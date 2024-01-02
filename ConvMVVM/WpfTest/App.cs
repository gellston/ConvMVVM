using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Module;
using ConvMVVM.WPF.Component;
using ConvMVVM.WPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfTest.View;
using WpfTest.ViewModel;

namespace WpfTest
{
    public class App : ConvMVVMApp
    {

        #region Event Handler

        protected override void ConfigureServiceLocator()
        {
            ServiceLocator.DialogService.RegisterDialog<AWindowView>();
            ServiceLocator.RegionManager.RegisterCacheView<AView>();
        }

        protected override void ConfigureModule(ModuleCollection modules)
        {
    
        }

        protected override void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<AWindowViewModel>();
            serviceCollection.RegisterCache<AViewModel>();
            serviceCollection.RegisterCache<MainWindowViewModel>();
        }

        protected override void ConfigureServiceProvider(IServiceContainer serviceProvider)
        {

        }

        protected override Window CreateWindow(IServiceContainer serviceProvider)
        {
            var window = new MainWindowView();
            return window;
        }
        #endregion

    }
}
