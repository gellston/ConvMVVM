using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvMVVM.Core.DI
{
    public class Container : IContainer
    {
        #region Private Property
        private readonly Dictionary<Type, Tuple<Type, bool>> types = new Dictionary<Type, Tuple<Type, bool>>();

        #endregion

        #region Private Functions
        public object Create(Type type)
        {
            if (!this.types.ContainsKey(type))
            {
                throw new InvalidOperationException("There is no service key");
            }
            try
            {
                var typeInfo = this.types[type];
                var cacheOrNot = typeInfo.Item2;
                var defaultConstructors = typeInfo.Item1.GetConstructors();
                if(defaultConstructors.Count() <= 0)
                {
                    throw new InvalidOperationException("There is no constructor");
                }
                var defaultConstructor = defaultConstructors[0];
                var defaultParams = defaultConstructor.GetParameters();
                var parameters = defaultParams.Select(param => Create(param.ParameterType)).ToArray();

                var service = defaultConstructor.Invoke(parameters);
                return service;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unknown", ex);
            }
        }
        #endregion

        #region Functions

        public TInterface GetService<TInterface>() where TInterface : class
        {
            try
            {
                return (TInterface)Create(typeof(TInterface));
            }catch(Exception ex)
            {
                throw new InvalidOperationException("Unknown", ex);
            }

        }

        public void RegisterCache<TInterface, TImplementation>() where TImplementation : TInterface
        {
            this.types[typeof(TInterface)] = new Tuple<Type, bool>(typeof(TImplementation), true);
        }

        public void RegisterCache<TImplementation>() where TImplementation : class
        {
            this.types[typeof(TImplementation)] = new Tuple<Type, bool>(typeof(TImplementation), true);
        }

        public void RegisterNonCache<TInterface, TImplementation>() where TImplementation : TInterface
        {
            this.types[typeof(TInterface)] = new Tuple<Type, bool>(typeof(TImplementation), false);
        }

        public void RegisterNonCache<TImplementation>() where TImplementation : class
        {
            this.types[typeof(TImplementation)] = new Tuple<Type, bool>(typeof(TImplementation), false);
        }

        #endregion
    }
}
