using System;
using Microsoft.Practices.Unity;

namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    internal static class IoCContainerRegistrationsExtension
    {
        public static string GetMappingAsString(this ContainerRegistration registration)
        {
            string regName, regType, mapTo, lifetime;
            var r = registration.RegisteredType;
            regType = r.Name + GetGenericArgumentsList(r);
            var m = registration.MappedToType;
            mapTo = m.Name + GetGenericArgumentsList(m);
            regName = registration.Name ?? "[default]";
            lifetime = registration.LifetimeManagerType.Name;
            if (mapTo != regType)
            {
                mapTo = " -> " + mapTo;
            }
            else
            {
                mapTo = string.Empty;
            }
            lifetime = lifetime.Substring(
                0, lifetime.Length - "LifetimeManager".Length);
            return string.Format(
                "+ {0}{1} '{2}' {3}", regType, mapTo, regName, lifetime);
        }

        private static string GetGenericArgumentsList(Type type)
        {
            if (type.GetGenericArguments().Length == 0) return string.Empty;
            string arglist = string.Empty;
            bool first = true;
            foreach (Type t in type.GetGenericArguments())
            {
                arglist += first ? t.Name : ", " + t.Name;
                first = false;
                if (t.GetGenericArguments().Length > 0)
                {
                    arglist += GetGenericArgumentsList(t);
                }
            }
            return "<" + arglist + ">";
        }
    }
}
