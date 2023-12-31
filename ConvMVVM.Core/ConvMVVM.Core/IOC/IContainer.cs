

namespace ConvMVVM.Core.IOC
{
    public interface IContainer
    {
        public TInterface GetService<TInterface>() where TInterface: class;
    }
}
