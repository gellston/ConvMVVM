using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConvMVVM.Core.IOC
{
    public class ServiceCollection : IServiceCollection
    {
        #region Private Property
        private readonly Dictionary<Type, Tuple<Type, bool, object, object>> Types = new Dictionary<Type, Tuple<Type, bool, object, object>>();
        #endregion

        #region Constructor
        internal ServiceCollection()
        {

        }
        #endregion

        #region Static Functions
        public static IServiceCollection Create()
        {
            return new ServiceCollection();
        }
        #endregion

        #region Private Functions
        private Tuple<Type, bool, object, object> CreateTypeInfo(Type type, bool cache, object cacheObject, object callback )
        {
            return new Tuple<Type, bool, object, object>(type, cache, cacheObject, callback);
        }
        #endregion

        #region Public Functions
        public void RegisterCache<TInterface, TImplementation>() where TImplementation : TInterface
        {
            this.Types[typeof(TInterface)] = this.CreateTypeInfo(typeof(TImplementation), true, null, null);
        }

        public void RegisterCache<TImplementation>() where TImplementation : class
        {
            this.Types[typeof(TImplementation)] = this.CreateTypeInfo(typeof(TImplementation), true, null, null);
        }

        public void RegisterCache<TImplementation>(TImplementation implementation) where TImplementation : class
        {
            this.Types[typeof(TImplementation)] = this.CreateTypeInfo(typeof(TImplementation), true, implementation, null);
        }

        public void RegisterNoneCache<TInterface, TImplementation>() where TImplementation : TInterface
        {
            this.Types[typeof(TInterface)] = this.CreateTypeInfo(typeof(TImplementation), false, null, null);
        }

        public void RegisterNoneCache<TImplementation>() where TImplementation : class
        {
            this.Types[typeof(TImplementation)] = this.CreateTypeInfo(typeof(TImplementation), false, null, null);
        }

        public void RegisterCache<TInterface, TImplementation>(TImplementation implementation) where TImplementation : TInterface
        {
            this.Types[typeof(TInterface)] = this.CreateTypeInfo(typeof(TImplementation), true, implementation, null);
        }

        public void RegisterCache<TInterface, TImplementation>(Func<IContainer, TInterface> factory) where TImplementation : TInterface
        {
            this.Types[typeof(TInterface)] = this.CreateTypeInfo(typeof(TImplementation), true, null, factory);
        }

        public void RegisterNoneCache<TInterface, TImplementation>(Func<IContainer, TInterface> factory) where TImplementation : TInterface
        {
            this.Types[typeof(TInterface)] = this.CreateTypeInfo(typeof(TImplementation), false, null, factory);
        }

        public void RegisterCache<TImplementation>(Func<IContainer, TImplementation> factory) where TImplementation : class
        {
            this.Types[typeof(TImplementation)] = this.CreateTypeInfo(typeof(TImplementation), true, null, factory);
        }
        public void RegisterNoneCache<TImplementation>(Func<IContainer, TImplementation> factory) where TImplementation : class
        {
            this.Types[typeof(TImplementation)] = this.CreateTypeInfo(typeof(TImplementation), false, null, factory);
        }

        public bool CheckType(Type type)
        {
            if (this.Types.ContainsKey(type)) return true;
            else return false;
        }

        public IContainer CreateContainer()
        {
            return new Container(this);
        }

        public Tuple<Type, bool, object, object> GetType(Type type)
        {
            if (!CheckType(type))
            {
                throw new InvalidOperationException("Invalid key type");
            }

            return this.Types[type];
        }


        #endregion
    }
}
