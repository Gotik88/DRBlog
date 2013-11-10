using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Mvc;

namespace DRBlog.Core.Infrastructure.DependencyInjection.Autofac
{
    public static class AutofacLifestyleConverter
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> Lifestyle<TLimit, TActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> component, ComponentLifeStyle lifestyle)
        {
            switch (lifestyle)
            {
                case ComponentLifeStyle.Singleton:
                    return component.SingleInstance(); // every dependent component or call to Resolve()
                                                      //within a single ILifetimeScope gets the same, shared instance. Dependent components in
                                                     //different lifetime scopes will get different instances.
                //component.InstancePerDependency(); // every dependent component or call to Resolve()  gets the same, shared instance.

                case ComponentLifeStyle.Transient:
                    return component.OwnedByLifetimeScope(); // every dependent component or call to Resolve() gets a new, unique instance (default.)

                case ComponentLifeStyle.PerThread:
                    new NotImplementedException();
                    break;

                case ComponentLifeStyle.PerLifetimeScope:
                    return component.InstancePerLifetimeScope(); //every dependent component or call to Resolve() within
                                                                // a ILifetimeScope tagged with any of the provided tags value gets the same, shared instance.
                                                                // Dependent components in lifetime scopes that are children of the tagged scope will
                                                                // share the parent's instance. If no appropriately tagged scope can be found in the
                                                                // hierarchy an <see cref="T:Autofac.Core.DependencyResolutionException"/> is thrown.

                    // InstancePerOwned<TService>(object serviceKey) 
                                                                //every dependent component or call to Resolve()
                                                                //within a ILifetimeScope created by an owned instance gets the same, shared instance.
                                                                //Dependent components in lifetime scopes that are children of the owned instance scope will
                                                                //share the parent's instance. If no appropriate owned instance scope can be found in the
                                                                //hierarchy an <see cref="T:Autofac.Core.DependencyResolutionException"/> is thrown.
                case ComponentLifeStyle.PerWebRequest:
                    return component.InstancePerHttpRequest();

                case ComponentLifeStyle.Pooled:
                    new NotImplementedException();
                    break;
            }

            return component;
        }
    }
}
