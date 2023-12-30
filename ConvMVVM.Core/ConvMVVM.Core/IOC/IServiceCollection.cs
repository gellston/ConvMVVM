using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvMVVM.Core.IOC
{
    public interface IServiceCollection
    {
        public void RegisterCache<TInterface, TImplementation>() where TImplementation : TInterface;
        public void RegisterNoneCache<TInterface, TImplementation>() where TImplementation : TInterface;

        public void RegisterCache<TImplementation>() where TImplementation : class;
        public void RegisterCache<TImplementation>(TImplementation implementation) where TImplementation : class;
        public void RegisterNoneCache<TImplementation>() where TImplementation : class;

        public void RegisterCache<TInterface, TImplementation>(TImplementation implementation) where TImplementation : TInterface;
        //public void RegisterNoneCache<TInterface, TImplementation>(TImplementation implementation) where TImplementation : TInterface;

        public void RegisterCache<TInterface, TImplementation>(Func<IContainer, TInterface> factory) where TImplementation : TInterface;
        public void RegisterNoneCache<TInterface, TImplementation>(Func<IContainer, TInterface> factory) where TImplementation : TInterface;

        public void RegisterCache<TImplementation>(Func<IContainer, TImplementation> factory) where TImplementation : class;
        public void RegisterNoneCache<TImplementation>(Func<IContainer, TImplementation> factory) where TImplementation : class;


        public bool CheckType(Type type);


        public Tuple<Type, bool, object, object> GetType(Type type);

        public IContainer CreateContainer();
    }
}
