using ConvMVVM.Core.IOC;
using ConvMVVM.WPF.Component;
using ConvMVVM.WPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TranslateServiceExample.View;
using TranslateServiceExample.ViewModel;

namespace TranslateServiceExample
{
    public class App : ConvMVVMApp
    {
        protected override void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {

            serviceCollection.RegisterCache<MainWindowViewModel>();

        }

        protected override void ConfigureServiceLocator()
        {
           
            ServiceLocator.ResourceContainer.ChangeResourceManager(TranslateServiceExample.Properties.Resources.ResourceManager);
            ServiceLocator.ResourceContainer.ChangeCulture("kr");
        }

        protected override Window CreateWindow(IServiceContainer serviceProvider)
        {
            return new MainWindowView();
        }

    }
}
