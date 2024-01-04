using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Module;
using ConvMVVM.Core.Module.Extensions;
using ConvMVVM.WPF.Component;
using ModuleExample.View;
using ModuleExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuleExample
{
    internal class App : ConvMVVMApp
    {

        protected override void ConfigureModule(ModuleCollection modules)
        {
            modules.AddModule<AModule.Module>();
        }

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
