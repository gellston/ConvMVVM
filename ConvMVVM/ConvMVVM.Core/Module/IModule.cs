using ConvMVVM.Core.IOC;


namespace ConvMVVM.Core.Module
{
    public interface IModule
    {

        public void OnInitialized(IServiceContainer container);

        public void RegisterService(IServiceCollection serviceCollection);

        public void OnInitServiceLocator();

        public void OnInitResource(IServiceContainer container);

    }
}
