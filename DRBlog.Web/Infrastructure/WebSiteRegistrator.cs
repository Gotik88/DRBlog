using DRBlog.Core.Infrastructure.DependencyInjection.RegistrationBuilder;
using DRBlog.Framework.Mvc.Modules;
using DRBlog.Web.Modules;

namespace DRBlog.Web.Infrastructure
{
    public class WebSiteRegistrator
    {
        private readonly IRegistrationBuilder _builder;

        public WebSiteRegistrator(IRegistrationBuilder builder)
        {
            _builder = builder;
        }

        public void RegisterModules()
        {
            _builder.RegisterModule(new WebTypesModule());
            _builder.RegisterModule(new ControllersModule());
            _builder.RegisterModule(new DataLayerModule());
            _builder.RegisterModule(new ServicesModule());
        }
    }
}