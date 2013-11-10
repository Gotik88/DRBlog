using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace DRBlog.Core.Infrastructure.DependencyInjection.Unity
{
    public class UnityIoCContainer : IoCContainer
    {
        private readonly UnityContainer _container;

        public UnityIoCContainer()
        {
            _container = new UnityContainer();
        }

        public override ComponentLifeStyle DefaultComponentLifeStyle
        {
            get
            {
                return ComponentLifeStyle.Singleton;
            }
        }

        public void Initialization()
        {
            _container.AddNewExtension<Microsoft.Practices.Unity.InterceptionExtension.Interception>();
        }

        #region Registration


        public void RegisterType<TService>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default) where TService : class
        {
            _container.RegisterType<TService>(); // should set life style
        }

        public void RegisterType<TService, TServiceImplementation>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
            where TService : class
            where TServiceImplementation : TService
        {
            _container.RegisterType<TService, TServiceImplementation>(); // should set life style
            /*container.AddNewExtension<Interception>();
            container.Configure<Interception>()
                .SetInterceptorFor<ILogger>(new TransparentProxyInterceptor());*/
        }

        #region by Convention (auto-registration)

        public void RegisterGeneric<TInterface, TService>(ComponentLifeStyle lifeStyle = ComponentLifeStyle.Default)
            where TService : class
            where TInterface : TService
        {
            _container.RegisterType(typeof(TInterface), typeof(TService));
        }

        // all types that implement an interface with IService/Service naming convention
        public void RegisterServiceToInterfaceConvention(Func<Type, bool> predicate = null)
        {
            if (predicate == null)
            {
                predicate = _ => true;
            }

            _container.RegisterTypes(AllClasses.FromLoadedAssemblies().Where(predicate), WithMappings.FromMatchingInterface, WithName.Default);
        }

        #endregion

        #endregion

        #region Interception
        // of using TransparentProxyInterceptor or InterfaceInterceptor - Unity create proxy object at run time and we can't cast to TServiceImplementation during run time
        // order of the interception behavior parameters determines the order of these behaviors in the pipeline (order i important)
        public void RegisterWithInstanceInterception<TService, TServiceImplementation>(params InterceptionMember[] interceptionBehaviors)
            where TService : class
            where TServiceImplementation : TService
        {
            interceptionBehaviors.ToList().Insert(0, new Interceptor(typeof(TransparentProxyInterceptor))); // allow intercept all TServiceImplementation interfaces , and InterfaceInterceptor - allow intercept only TService interface
            _container.RegisterType<TService, TServiceImplementation>(interceptionBehaviors.Cast<InjectionMember>().ToArray());
        }

        public void RegisterWithTypeInterception<TService, TServiceImplementation>(params InterceptionMember[] interceptionBehaviors)
            where TService : class
            where TServiceImplementation : TService
        {
            interceptionBehaviors.ToList().Insert(0, new Interceptor(typeof(VirtualMethodInterceptor))); // methods in TServiceImplementation should be virtual and class is public
            _container.RegisterType<TService, TServiceImplementation>(interceptionBehaviors.Cast<InjectionMember>().ToArray());
        }

        #endregion

        #region Interception by convention

        /*container.RegisterType<ITenantStore, TenantStore>(
new InterceptionBehavior<PolicyInjectionBehavior>(),
new Interceptor<InterfaceInterceptor>());
container.RegisterType<ISurveyStore, SurveyStore>(
new InterceptionBehavior<PolicyInjectionBehavior>(),
new Interceptor<InterfaceInterceptor>());
var first = new InjectionProperty("Order", 1);
var second = new InjectionProperty("Order", 2);
container.Configure<Interception>()
.AddPolicy("logging")
.AddMatchingRule<AssemblyMatchingRule>(
new InjectionConstructor(
new InjectionParameter("Tailspin.Web.Survey.Shared")))
.AddCallHandler<LoggingCallHandler>(
new ContainerControlledLifetimeManager(),
new InjectionConstructor(),
first);
container.Configure<Interception>()
.AddPolicy("caching")
.AddMatchingRule<MemberNameMatchingRule>(
new InjectionConstructor(new [] {"Get*", "Save*"}, true)))
.AddMatchingRule<NamespaceMatchingRule>(
new InjectionConstructor(
"Tailspin.Web.Survey.Shared.Stores", true)))
.AddCallHandler<CachingCallHandler>(
new ContainerControlledLifetimeManager(),
new InjectionConstructor(),
second);*/

        #endregion

        // Interception without Unity Container
        /* ITenantStore tenantStore = Intercept.ThroughProxy<ITenantStore>(
new TenantStore(tenantContainer, blobContainer),
new InterfaceInterceptor(),
new IInterceptionBehavior[] {
new LoggingInterceptionBehavior(), new CachingInterceptionBehavior()
});*/

    }
}
