using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvMVVM.Core.DI
{
    public interface IContainer
    {
        public TInterface GetService<TInterface>() where TInterface: class;
    }
}
