using ConvMVVM.Core.IOC;
using ConvMVVM.WPF.Component;
using RelayCommandExample.View;
using RelayCommandExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RelayCommandExample
{
    internal class App : ConvMVVMApp
    {

        protected override void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<MainWindowViewModel>();
        }

        protected override Window CreateWindow(IServiceContainer serviceProvider)
        {
            return new MainWindowView();
        }
    }
}
