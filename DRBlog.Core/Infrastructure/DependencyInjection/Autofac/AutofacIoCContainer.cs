using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace DRBlog.Core.Infrastructure.DependencyInjection.Autofac
{
    public class AutofacIoCContainer : IoCContainer
    {
        private readonly ContainerBuilder _container;

        public AutofacIoCContainer()
        {
            _container = new ContainerBuilder();
            _container.RegisterModule(new AutofacWebTypesModule());
            // model binder injection
            _container.RegisterModelBinders(Assembly.GetExecutingAssembly());
            _container.RegisterModelBinderProvider();
            Initialization();
        }

        private void Initialization()
        {
            IContainer container = _container.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public ILifetimeScope Scope()
        {
            try
            {
                return null; //AutofacRequestLifetimeHttpModule.GetLifetimeScope(_container.Build(), null);
            }
            catch
            {
                return _container.Build();
            }
        }

        #region Registration

        // Singleton as default lifestyle

        public override void RegisterInstance<TInstance>(TInstance instance, ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
        {
            _container.RegisterInstance(instance).As<TInstance>().Lifestyle(lifeStyle);
        }

        public override void RegisterType<TService>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
        {
            _container.RegisterType<TService>().Lifestyle(lifeStyle);
        }

        public override void RegisterType<TService, TImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
        {
            _container.RegisterType<TImplementation>().As<TService>().Lifestyle(lifeStyle);
        }

        public override void RegisterGeneric(Type implementation, Type abstraction, ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
        {
            _container.RegisterGeneric(implementation).As(abstraction).Lifestyle(lifeStyle);
        }

        public override void RegisterServiceToInterfaceConvention(Func<Type, bool> predicate = null)
        {
            if (predicate == null)
            {
                predicate = _ => true;
            }

            _container.RegisterTypes().Where(predicate);
        }

        public override void RegisterControllers(params Assembly[] controllerAssemblies)
        {
            _container.RegisterControllers(controllerAssemblies);
        }

        #endregion

        #region Resolution

        public override T Resolve<T>(string key = "")
        {
            if (string.IsNullOrEmpty(key))
            {
                return Scope().Resolve<T>();
            }
            return Scope().ResolveKeyed<T>(key);
        }

        public override object Resolve(Type type)
        {
            return Scope().Resolve(type);
        }

        public override T[] ResolveAll<T>(string key = "")
        {
            if (string.IsNullOrEmpty(key))
            {
                return Scope().Resolve<IEnumerable<T>>().ToArray();
            }
            return Scope().ResolveKeyed<IEnumerable<T>>(key).ToArray();
        }

        public override T ResolveUnregistered<T>()
        {
            return ResolveUnregistered(typeof(T)) as T;
        }

        public override object ResolveUnregistered(Type type)
        {
            var constructors = type.GetConstructors();
            foreach (var constructor in constructors)
            {
                try
                {
                    var parameters = constructor.GetParameters();
                    var parameterInstances = new List<object>();
                    foreach (var parameter in parameters)
                    {
                        var service = Resolve(parameter.ParameterType);
                        if (service == null) throw new Exception("Unkown dependency");
                        parameterInstances.Add(service);
                    }
                    return Activator.CreateInstance(type, parameterInstances.ToArray());
                }
                catch (Exception)
                {

                }
            }
            throw new Exception("No contructor was found that had all the dependencies satisfied.");
        }

        public override bool TryResolve(Type serviceType, out object instance)
        {
            return Scope().TryResolve(serviceType, out instance);
        }

        public override bool IsRegistered(Type serviceType)
        {
            return Scope().IsRegistered(serviceType);
        }

        public override object ResolveOptional(Type serviceType)
        {
            return Scope().ResolveOptional(serviceType);
        }

        #endregion

    }
}
