﻿using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Module;
using ConvMVVM.WPF.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConvMVVM.WPF.Component
{
    public partial class ConvMVVMApp : Application
    {
        #region Constructor
        public ConvMVVMApp()
        {
        
            ConfigureModule(Modules);
            Services = ConfigureServices();
            ConfigureServiceLocator();

        }
        #endregion

        #region Private Property
        public IServiceContainer Services { get; }
        public ModuleCollection Modules { get; } = new ModuleCollection();
        #endregion

        #region Event Handler
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            foreach (var module in Modules)
            {
                module.OnInitResource(Services);
            }

            foreach (var module in Modules)
            {
                module.OnInitServiceLocator();
            }


            var window = CreateWindow(Services);
            window.Show();


            foreach (var module in Modules)
            {
                module.OnInitialized(Services);
            }


        }
        #endregion

        #region Function
        private IServiceContainer ConfigureServices()
        {
            var services = ServiceCollection.Create();
            services.AddDialogService();
            services.AddRegionManager();
            services.AddResourceContainer();
            services.AddTranslateService();


            foreach (var module in Modules)
            {
                module.RegisterService(services);
            }

            ConfigureServiceCollection(services);

            var serviceProvider = services.CreateContainer();
            serviceProvider.AddDialogServiceLocator();
            serviceProvider.AddViewModelLocator();


            ConfigureServiceProvider(serviceProvider);

            return serviceProvider;
        }


        protected virtual Window CreateWindow(IServiceContainer serviceProvider)
        {
            var window = new Window();
            return window;
        }

        protected virtual void ConfigureServiceLocator()
        {

        }

        protected virtual void ConfigureModule(ModuleCollection modules)
        {

        }


        protected virtual void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {

        }

        protected virtual void ConfigureServiceProvider(IServiceContainer serviceProvider)
        {

        }

        #endregion
    }
}
