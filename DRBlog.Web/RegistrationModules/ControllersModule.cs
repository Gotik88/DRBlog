using System.Reflection;
using DRBlog.Core.Infrastructure.DependencyInjection;
using DRBlog.Core.Infrastructure.DependencyInjection.Module;

namespace DRBlog.Web.Modules
{
    public class ControllersModule : IIoCModule
    {
        public void Load(IoCContainer container)
        {
            container.RegisterControllers(Assembly.GetExecutingAssembly());
        }
    }
}