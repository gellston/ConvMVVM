

namespace ConvMVVM.Core.IOC
{
    public interface IServiceContainer
    {

        #region Public Functions
        public TInterface GetService<TInterface>() where TInterface: class;
        public object GetService(Type serviceType); 
        public Type KeyType(string key);
        public TInterface GetService<TInterface>(params object[] properties);
        public object GetService(Type serviceType, params object[] properties);
        #endregion
    }
}
