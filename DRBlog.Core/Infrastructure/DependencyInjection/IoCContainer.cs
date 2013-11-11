using System;
using System.Collections.Generic;
using System.Reflection;

namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    public abstract class IoCContainer : IIoCContainerRegistration, IIoCMvcContainer, IIoCContainerResolution
    {
        // registration
        public abstract void RegisterInstance<TInstance>(TInstance instance, ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default);

        public abstract void RegisterType<TService>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default) where TService : class;

        public abstract void RegisterType<TService, TImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
            where TImplementation : TService;

        public abstract void RegisterGeneric(Type implementation, Type abstraction, ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default);
        public abstract void RegisterServiceToInterfaceConvention(Func<Type, bool> predicate);

        //public abstract void RegisterControllers(params Assembly[] controllerAssemblies);

        // resolution
        //public abstract T Resolve<T>(string key = "") where T : class;

        //public abstract object Resolve(Type type);

        //public abstract T[] ResolveAll<T>(string key = "");

        //public abstract T ResolveUnregistered<T>() where T : class;

        //public abstract object ResolveUnregistered(Type type);

        // public abstract bool TryResolve(Type serviceType, out object instance);

        //public abstract bool IsRegistered(Type serviceType);

        //public abstract object ResolveOptional(Type serviceType);
    }
}
