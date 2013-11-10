
using DRBlog.Core.Infrastructure.DependencyInjection;
using DRBlog.Core.Infrastructure.DependencyInjection.Module;
using DRBlog.Services;

namespace DRBlog.Web.Modules
{
    public class ServicesModule : IIoCModule
    {
        public void Load(IoCContainer container)
        {
            container.RegisterType<IBlogService, BlogService>(ComponentLifeStyle.PerWebRequest);
        }
    }
}