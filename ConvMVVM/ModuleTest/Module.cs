
using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Module;
using ConvMVVM.Core.Service.RegionManager;
using ConvMVVM.WPF.Service;
using ModuleTest.View;
using ModuleTest.ViewModel;

namespace ModuleTest
{
    public class Module : IModule
    {
        public void OnInitialized(IServiceContainer container)
        {

            var regionManager = container.GetService<IRegionManager>();
            regionManager.NavigateCache("MainContent", "BView");
        }

        public void OnInitResource(IServiceContainer container)
        {
            
        }

        public void OnInitServiceLocator()
        {
            ServiceLocator.RegionManager.RegisterCacheView<BView>();
        }

        public void RegisterService(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<BViewModel>();
        }
    }

}
