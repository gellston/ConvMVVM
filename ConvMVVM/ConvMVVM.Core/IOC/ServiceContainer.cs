

using ConvMVVM.Core.Component;
using System.Reflection;

namespace ConvMVVM.Core.IOC
{
    public class ServiceContainer : IServiceContainer
    {
        #region Private Property
        private readonly IServiceCollection serviceCollection;
        private readonly Dictionary<Type, object> cacheObjects = new Dictionary<Type, object>();
        #endregion//

        #region Constructor
        public ServiceContainer(IServiceCollection services)
        {
            if(services == null)
            {
                throw new InvalidOperationException("Invalid service collection");
            }
            this.serviceCollection = services;
        }
        #endregion


        #region Private Functions
        public object Create(Type type)
        {
            if (!this.serviceCollection.CheckType(type))
            {
                throw new InvalidOperationException("There is no service key");
            }
            try
            {

                var typeInfo = this.serviceCollection.GetType(type);

                var objectType = typeInfo.Item1;
                var cacheOrNot = typeInfo.Item2;
                var cacheObject = typeInfo.Item3;
                var callback = typeInfo.Item4;
                var defaultConstructors = objectType.GetConstructors();
                if(defaultConstructors.Count() <= 0 && cacheObject == null)
                {
                    throw new InvalidOperationException("There is no constructor");
                }

                if (cacheOrNot == false && callback == null && cacheObject == null)
                {
                    var defaultConstructor = defaultConstructors[0];
                    var defaultParams = defaultConstructor.GetParameters();
                    var parameters = defaultParams.Select(param => Create(param.ParameterType)).ToArray();
                    var service = defaultConstructor.Invoke(parameters);
                    if (service.GetType().IsSubclassOf(typeof(NotifyObject)))
                    {
                        var _service = service as NotifyObject;
                        _service.OnActive();
                    }
                    return service;
                }
                
                if(cacheOrNot == false && callback != null && cacheObject == null)
                {
                    var methodInfo = callback.GetType().GetMethod("Invoke");
                    var service = methodInfo.Invoke(callback, new[] { this });
                    if (service.GetType().IsSubclassOf(typeof(NotifyObject)))
                    {
                        var _service = service as NotifyObject;
                        _service.OnActive();
                    }
                    return service;
                }

                if(cacheOrNot == true && callback == null && cacheObject == null)
                {
                    if (this.cacheObjects.ContainsKey(type) == true)
                        return this.cacheObjects[type];

                    var defaultConstructor = defaultConstructors[0];
                    var defaultParams = defaultConstructor.GetParameters();
                    var parameters = defaultParams.Select(param => Create(param.ParameterType)).ToArray();
                    var service = defaultConstructor.Invoke(parameters);
                    this.cacheObjects[type] = service;
                    if (service.GetType().IsSubclassOf(typeof(NotifyObject)))
                    {
                        var _service = service as NotifyObject;
                        _service.OnActive();
                    }
                    return service;
                }

                if(cacheOrNot == true && callback != null && cacheObject == null)
                {
                    if (this.cacheObjects.ContainsKey(type) == true)
                        return this.cacheObjects[type];

                    var methodInfo = callback.GetType().GetMethod("Invoke");
                    var service = methodInfo.Invoke(callback, new[] { this });
                    this.cacheObjects[type] = service;
                    if (service.GetType().IsSubclassOf(typeof(NotifyObject)))
                    {
                        var _service = service as NotifyObject;
                        _service.OnActive();
                    }
                    return service;
                }

                if (cacheOrNot == true && callback == null && cacheObject != null)
                {
                    if (this.cacheObjects.ContainsKey(type) == true)
                        return this.cacheObjects[type];

                    this.cacheObjects[type] = cacheObject;
                    if (cacheObject.GetType().IsSubclassOf(typeof(NotifyObject)))
                    {
                        var _service = cacheObject as NotifyObject;
                        _service.OnActive();
                    }
                    return cacheObject;
                }

                throw new InvalidOperationException("Invalid service collection infomation");
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

        public object GetService(Type serviceType)
        {
            try
            {
                return Create(serviceType);
            }catch(Exception ex)
            {
                throw new InvalidOperationException("Unknown", ex);
            }
        }

        public TInterface GetService<TInterface>(params object[] properties)
        {
            try
            {
                return (TInterface)GetService(typeof(TInterface), properties);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unknown", ex);
            }
        }
        public object GetService(Type serviceType, params object[] properties)
        {
            try
            {
                var vm = Create(serviceType);
                var type = vm.GetType();
                if(type != null)
                {
                    MethodInfo[] methodInfos = type.GetMethods();
                    foreach(var property in properties)
                    {
                        var methodInfo = methodInfos.Where(x => x.Name == "Inject" && 
                                                                x.GetParameters().Length == 1 && 
                                                                x.ReturnType == typeof(void))
                                                    .Where(x => x.GetParameters()[0].ParameterType == property.GetType()).Single();
                        methodInfo.Invoke(vm, new object[] { property });
                    }
                }

                return vm;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unknown", ex);
            }
        }


        public Type KeyType(string key)
        {
            return this.serviceCollection.KeyType(key);
        }
        #endregion
    }
}
