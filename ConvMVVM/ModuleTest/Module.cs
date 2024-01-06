
using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Module;
using ConvMVVM.WPF.Service;
using ModuleTest.View;
using ModuleTest.ViewModel;

namespace ModuleTest
{
    public class Module : IModule
    {
        public void OnInitialized(IServiceContainer container)
        {
            
        }

        public void OnInitResource(IServiceContainer container)
        {
            
        }

        public void OnInitServiceLocator()
        {
            ServiceLocator.DialogService.RegisterDialog<BView>();
        }

        public void RegisterService(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<BViewModel>();
        }
    }

}
