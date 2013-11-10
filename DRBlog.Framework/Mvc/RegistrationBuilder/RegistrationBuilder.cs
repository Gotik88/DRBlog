using DRBlog.Core.Infrastructure.DependencyInjection;
using DRBlog.Core.Infrastructure.DependencyInjection.Module;
using DRBlog.Core.Infrastructure.DependencyInjection.RegistrationBuilder;

namespace DRBlog.Web.Builders
{
    public class RegistrationBuilder : IRegistrationBuilder
    {
        private readonly IoCContainer _container;

        public IoCContainer GetContainer
        {
            get { return _container; }
        }

        public RegistrationBuilder(IoCContainer container)
        {
            _container = container;
        }

        public void RegisterModule(IIoCModule module)
        {
            module.Load(_container);
        }
    }
}