using System;

namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    public interface IIoCContainerResolution
    {
        bool TryResolve(Type serviceType, out object instance);

        object Resolve(Type type);

        T Resolve<T>(string key = "") where T : class;

        T[] ResolveAll<T>(string key = "");

        bool IsRegistered(Type serviceType);

        object ResolveUnregistered(Type type);

        T ResolveUnregistered<T>() where T : class;

        object ResolveOptional(Type serviceType);
    }
}
