using System;
using System.Web;
using DRBlog.Core.Infrastructure.DependencyInjection;
using DRBlog.Core.Infrastructure.DependencyInjection.Module;

namespace DRBlog.Framework.Mvc.Modules
{
    public class WebTypesModule : IIoCModule
    {
        public void Load(IoCContainer container)
        {
            var context = new HttpContextWrapper(HttpContext.Current);

            container.RegisterInstance<HttpContextBase>(context, ComponentLifeStyle.PerWebRequest);
            container.RegisterInstance<HttpRequestBase>(context.Request, ComponentLifeStyle.PerWebRequest);
            container.RegisterInstance<HttpResponseBase>(context.Response, ComponentLifeStyle.PerWebRequest);
            container.RegisterInstance<HttpServerUtilityBase>(context.Server, ComponentLifeStyle.PerWebRequest);
            container.RegisterInstance<HttpSessionStateBase>(context.Session, ComponentLifeStyle.PerWebRequest);
        }
    }
}
