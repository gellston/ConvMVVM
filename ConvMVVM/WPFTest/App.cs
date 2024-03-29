﻿using ConvMVVM.Core.IOC;
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
            serviceCollection.RegisterCache<AViewModel>();
            serviceCollection.RegisterNoneCache<Func<object[], AViewModel>>((container) =>
            {
                return (object[] param) => {

                    return container.GetService<AViewModel>(param);
                };
            });
        }


        protected override void ConfigureServiceProvider(IServiceContainer serviceProvider)
        {


        }


        protected override void ConfigureServiceLocator()
        {

  
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
