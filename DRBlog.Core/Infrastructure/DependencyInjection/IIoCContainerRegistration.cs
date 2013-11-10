using System;

namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    public interface IIoCContainerRegistration
    {
        void RegisterInstance<TInstance>(TInstance instance, ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default) where TInstance : class;

        void RegisterType<TService>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default) where TService : class;

        void RegisterType<TService, TImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
            where TImplementation : TService;

        // registration by convention
        void RegisterGeneric(Type implementation, Type abstraction, ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default);

        void RegisterServiceToInterfaceConvention(Func<Type, bool> predicate);
    }
}
