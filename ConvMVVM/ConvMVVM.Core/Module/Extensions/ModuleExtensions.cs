using System;
using System.Collections.Generic;
using System.Text;

namespace ConvMVVM.Core.Module.Extensions
{
    public static class ModuleExtensions
    {
        #region Static Functions
        public static ModuleCollection AddModule<TModule>(this ModuleCollection moduleCollection) where TModule : class
        {
            IModule module = (IModule)Activator.CreateInstance(typeof(TModule));
            moduleCollection.Add(module);
            return moduleCollection;
        }

        #endregion


    }
}
