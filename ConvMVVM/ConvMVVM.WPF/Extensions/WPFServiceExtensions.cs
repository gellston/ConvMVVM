using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Service.DialogService;
using ConvMVVM.Core.Service.RegionManager;
using ConvMVVM.Core.Service.TranslateService;
using ConvMVVM.WPF.Service;
using ConvMVVM.WPF.Service.EnumStateManager;
using ConvMVVM.WPF.Service.RegionManager;
using ConvMVVM.WPF.Service.ResourceContainer;
using ConvMVVM.WPF.Service.TranslateService;
using ConvMVVM.WPF.Service.ViewModelLocator;

namespace ConvMVVM.WPF.Extensions
{
    internal static class ConvMVVMWpfExtensions
    {

        #region Static Function


        //ServiceRegister
        internal static IServiceCollection AddDialogService(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<IDialogService>(ServiceLocator.DialogService);
            return serviceCollection;
        }

        internal static IServiceCollection AddRegionManager(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<IRegionManager>(ServiceLocator.RegionManager);
            return serviceCollection;
        }

        internal static IServiceCollection AddTranslateService(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<ITranslateService>(new TranslateService());
            return serviceCollection;
        }


        internal static IServiceCollection AddResourceContainer(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<IResourceContainer>(ResourceContainer.Instance);

            return serviceCollection;
        }

        internal static IServiceCollection AddEnumStateManager(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<IEnumStateManager>(new EnumStateManager());

            return serviceCollection;
        }




        //ServiceLocator
        internal static IServiceContainer AddDialogServiceLocator(this IServiceContainer serviceContainer)
        {
            ServiceLocator.DialogService.SetServiceProvider(serviceContainer);
            return serviceContainer;
        }

        internal static IServiceContainer AddViewModelLocator(this IServiceContainer serviceContainer)
        {
            ViewModelLocator.SetServiceProvider(serviceContainer);

            return serviceContainer;
        }
        #endregion

    }
}
