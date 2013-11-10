using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.ModelBuilder.Descriptors;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace DRBlog.Core.Infrastructure.DependencyInjection.CastleWindsor
{
    public class CastleWindsorIoCContainer : IoCContainer
    {
        private readonly WindsorContainer _container;

        public CastleWindsorIoCContainer()
        {
            _container = new WindsorContainer();
        }

        #region Registration

        // Singleton as default lifestyle

        public void RegisterInstance<TService>(TService instance, ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
        {
            _container.Register(Component.For<TService>().Instance(instance).Lifestyle(lifeStyle)); // When you register an existing instance, even if you specify a lifestyle it will be ignored. 
        }

        public void RegisterType<TService>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
        {
            _container.Register(RegisterInstance<TService>().Lifestyle(lifeStyle));
        }

        public void RegisterType<TService, TServiceImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
            where TService : class
            where TServiceImplementation : TService
        {
            _container.Register(RegisterInstance<TService, TServiceImplementation>().Lifestyle(lifeStyle));
        }

        public void RegisterGeneric<TService, TServiceImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
            where TService : class
            where TServiceImplementation : TService
        {
            _container.Register(Component.For(typeof(TService)).ImplementedBy(typeof(TServiceImplementation)).Lifestyle(lifeStyle));
        }

        private static ComponentRegistration<TService> RegisterInstance<TService, TServiceImplementation>()
            where TService : class
            where TServiceImplementation : TService
        {
            return Component.For<TService>().ImplementedBy<TServiceImplementation>();
        }

        private static ComponentRegistration<TService> RegisterInstance<TService>() where TService : class
        {
            return Component.For<TService>();
        }

        public void RegisterTypeForward<TService1, TService2, TServiceImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
            where TService1 : class
            where TServiceImplementation : TService1, TService2
        {
            _container.Register(Component.For<TService1, TService2>().ImplementedBy<TServiceImplementation>());
        }

        public void RegisterPrimitiveDependency<TService, TServiceImplementation>(string name, object value, ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
            where TService : class
            where TServiceImplementation : TService
        {
            _container.Register(Component.For<TService>().ImplementedBy<TServiceImplementation>().DependsOn(Dependency.OnValue(name, value)));
        }

        public void RegisterPrimitiveDependency<TService, TServiceImplementation, TDependency>(object value, ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
            where TService : class
            where TServiceImplementation : TService
            where TDependency : class
        {
            _container.Register(Component.For<TService>().ImplementedBy<TServiceImplementation>().DependsOn(Dependency.OnValue<TDependency>(value)));
        }

        public void RegisterForAllExcept<TService, TServiceImplementation, TExceptService, TExceptServiceImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
            where TService : class
            where TServiceImplementation : TService
            where TExceptService : class
            where TExceptServiceImplementation : TExceptService
        {
            _container.Register(Component.For<TExceptService>().ImplementedBy<TExceptServiceImplementation>().DependsOn(Dependency.OnComponent<TService, TServiceImplementation>()));
        }

        public void RegisterEmbeddedResource<TService, TResources>(string dependencyName, string resourceName, ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
            where TService : class
        {
            _container.Register(Component.For<TService>().DependsOn(Dependency.OnResource<TResources>(dependencyName, resourceName)));
        }

        #region Conditional registration

        public void RegisterPrimitiveDependency<TService, TServiceImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
           where TService : class
        {
            _container.Register(Component.For(typeof(TService)).ImplementedBy(typeof(TServiceImplementation)).OnlyNewServices());
        }

        #endregion

        #region Register by convention



        #endregion

        #endregion

    }
}
