using System;
using System.Collections.Generic;
using System.Linq;
using DRBlog.Core.Infrastructure.DependencyInjection.Autofac;
using DRBlog.Core.Infrastructure.DependencyInjection.CastleWindsor;
using DRBlog.Core.Infrastructure.DependencyInjection.Unity;

namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    public static class IoCContainerFactory
    {
        public static IoCContainer CreateContainer(IoCContainerType containerType)
        {
            IoCContainer container;

            switch (containerType)
            {
                case IoCContainerType.Autofac:
                    container = new AutofacIoCContainer();
                    break;

                case IoCContainerType.CastleWindsor:
                    container = new CastleWindsorIoCContainer();
                    break;

                case IoCContainerType.Unity:
                    container = new UnityIoCContainer();
                    break;

                default:
                    throw new Exception("Incorrect Inversion Of Control Container Type");
            }

            return container;
        }
    }
}
