using DRBlog.Core.Infrastructure.Engine;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DRBlog.Framework.Mvc
{
    public class MvcDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return EngineContext.Current.ContainerManager.Container.ResolveOptional(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var type = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)EngineContext.Current.ContainerManager.Container.Resolve(type);
        }
    }
}
