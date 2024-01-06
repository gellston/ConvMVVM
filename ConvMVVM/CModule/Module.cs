
using CModule.View;
using CModule.ViewModel;
using ConvMVVM.Core.IOC;
using ConvMVVM.Core.Module;
using ConvMVVM.WPF.Service;

namespace CModule
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

            ServiceLocator.DialogService.RegisterDialog<CWindowView>();
 
        }

        public void RegisterService(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<CWindowViewModel>();
        }
    }

}
