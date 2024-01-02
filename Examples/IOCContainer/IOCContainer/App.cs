using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Module;
using ConvMVVM.WPF.Component;
using IOCContainer.Service;
using IOCContainer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IOCContainer
{
    public class App : ConvMVVMApp
    {

        protected override void ConfigureModule(ModuleCollection modules)
        {
           
        }

        protected override void ConfigureServiceLocator()
        {

        }

        protected override void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<ITestService, TestService>();
            serviceCollection.RegisterCache<MainWindowViewModel>();
        }

        protected override void ConfigureServiceProvider(IServiceContainer serviceProvider)
        {
           
        }

        protected override Window CreateWindow(IServiceContainer serviceProvider)
        {
            return new View.MainWindowView();
        }
    }
}
