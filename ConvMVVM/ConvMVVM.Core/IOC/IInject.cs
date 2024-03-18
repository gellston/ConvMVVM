using System;
using System.Collections.Generic;
using System.Text;

namespace ConvMVVM.Core.IOC
{
    public interface IInject<T>
    {
        public void Inject(T instance); 
    }
}
