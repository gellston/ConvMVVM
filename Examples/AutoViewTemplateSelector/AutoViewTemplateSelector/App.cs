using AutoViewTemplateSelector.View;
using AutoViewTemplateSelector.ViewModel;
using ConvMVVM.Core.IOC;
using ConvMVVM.WPF.Component;
using ConvMVVM.WPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoViewTemplateSelector
{
    public class App : ConvMVVMApp
    {
        protected override void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<MainWindowViewModel>();
        }

        protected override void ConfigureServiceLocator()
        {
            ServiceLocator.RegionManager.RegisterNoneCacheView<AView>();
            ServiceLocator.RegionManager.RegisterNoneCacheView<BView>();
            ServiceLocator.RegionManager.RegisterNoneCacheView<CView>();
            ServiceLocator.RegionManager.RegisterNoneCacheView<FallbackView>();

        }

        protected override Window CreateWindow(IServiceContainer serviceProvider)
        {
            return new MainWindowView();
        }
    }
}
