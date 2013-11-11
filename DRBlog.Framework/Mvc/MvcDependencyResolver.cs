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
            return null;
            //return EngineContext.Current.ContainerManager.Container.ResolveOptional(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return null;
            // var type = typeof(IEnumerable<>).MakeGenericType(serviceType);
            //return (IEnumerable<object>)EngineContext.Current.ContainerManager.Container.Resolve(type);
        }
    }
}
