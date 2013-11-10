using Castle.MicroKernel.Registration;

namespace DRBlog.Core.Infrastructure.DependencyInjection.CastleWindsor
{
    public static class CastleWindsorLifestyleConverter
    {
        public static ComponentRegistration<TService> Lifestyle<TService>(this ComponentRegistration<TService> component, ComponentLifeStyle lifestyle)
              where TService : class
        {
            switch (lifestyle)
            {
                case ComponentLifeStyle.Singleton:
                    return component.LifestyleSingleton();

                case ComponentLifeStyle.Transient:
                    return component.LifestyleTransient();

                case ComponentLifeStyle.PerThread:
                    return component.LifestylePerThread();

                case ComponentLifeStyle.PerWebRequest:
                    return component.LifestylePerWebRequest();

                case ComponentLifeStyle.Pooled:
                    return component.LifestylePooled();
            }

            return component;
        }
    }
}
