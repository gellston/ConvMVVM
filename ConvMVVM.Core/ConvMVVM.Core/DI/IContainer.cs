using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvMVVM.Core.DI
{
    public interface IContainer
    {
        public void RegisterCache<TInterface, TImplementation>() where TImplementation : TInterface ;
        public void RegisterNonCache<TInterface, TImplementation>() where TImplementation: TInterface;
        public void RegisterCache<TImplementation>() where TImplementation : class;
        public void RegisterNonCache<TImplementation>()where TImplementation : class;
        public TInterface GetService<TInterface>() where TInterface: class;
    }
}
