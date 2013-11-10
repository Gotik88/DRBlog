using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DRBlog.Core.Infrastructure.DependencyInjection.Autofac;
using DRBlog.Core.Infrastructure.Engine;
using DRBlog.Framework.Mvc;
using DRBlog.Web.Builders;
using DRBlog.Web.Infrastructure;

namespace DRBlog.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            EngineContext.Initialize();
            DependencyResolver.SetResolver(new MvcDependencyResolver());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}