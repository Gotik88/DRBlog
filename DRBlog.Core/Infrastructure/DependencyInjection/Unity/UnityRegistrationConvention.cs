using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace DRBlog.Core.Infrastructure.DependencyInjection.Unity
{
    class UnityRegistrationConvention : RegistrationConvention
    {
        public override Func<Type, IEnumerable<Type>> GetFromTypes()
        {
            return t => t.GetTypeInfo().ImplementedInterfaces;
        }
        public override Func<Type, IEnumerable<InjectionMember>> GetInjectionMembers()
        {
            return null;
        }
        public override Func<Type, LifetimeManager> GetLifetimeManager()
        {
            return t => new ContainerControlledLifetimeManager();
        }
        public override Func<Type, string> GetName()
        {
            return t => t.Name;
        }
        public override IEnumerable<Type> GetTypes()
        {
            return null;
            /*yield return typeof(SomeType);
            yield return typeof(SomeType);*/
        }
    }
}
