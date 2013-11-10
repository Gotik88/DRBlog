using System.Reflection;

namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    public interface IIoCMvcContainer
    {
        void RegisterControllers(params Assembly[] controllerAssemblies);
    }
}
