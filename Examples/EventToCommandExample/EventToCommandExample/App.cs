using ConvMVVM.Core.IOC;
using ConvMVVM.WPF.Component;
using EventToCommandExample.View;
using EventToCommandExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EventToCommandExample
{
    public class App : ConvMVVMApp
    {

        #region Constructor
        public App() { }
        #endregion

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
