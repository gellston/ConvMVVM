﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConvMVVM.Core.DI
{
    public class Container : IContainer
    {
        #region Private Property
        private readonly IServiceCollection serviceCollection;
        private readonly Dictionary<Type, object> cacheObjects = new Dictionary<Type, object>();
        #endregion

        #region Constructor
        public Container(IServiceCollection services)
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
                if(defaultConstructors.Count() <= 0)
                {
                    throw new InvalidOperationException("There is no constructor");
                }

                if (cacheOrNot == false && callback == null)
                {
                    var defaultConstructor = defaultConstructors[0];
                    var defaultParams = defaultConstructor.GetParameters();
                    var parameters = defaultParams.Select(param => Create(param.ParameterType)).ToArray();
                    var service = defaultConstructor.Invoke(parameters);
                    return service;
                }
                
                if(cacheOrNot == false && callback != null)
                {
                    //var service = callback(this);
                    //var methodInfo = callback.GetType().GetMethod("Invoke");
                    //var method = methodInfo.MakeGenericMethod()

                  



                    return null;
                }

                if(cacheOrNot == true && callback == null)
                {
                    if (this.cacheObjects.ContainsKey(type) == true)
                        return this.cacheObjects[type];

                    var defaultConstructor = defaultConstructors[0];
                    var defaultParams = defaultConstructor.GetParameters();
                    var parameters = defaultParams.Select(param => Create(param.ParameterType)).ToArray();
                    var service = defaultConstructor.Invoke(parameters);
                    this.cacheObjects[type] = service;
                    return service;
                }

                if(cacheOrNot == true && callback != null)
                {
                    if (this.cacheObjects.ContainsKey(type) == true)
                        return this.cacheObjects[type];

                    //var service = callback(this);
                    //this.cacheObjects[type] = service;
                    return null;
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

        #endregion
    }
}
