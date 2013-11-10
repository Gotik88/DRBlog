

namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    public class IoCContainerManager
    {
        private readonly IoCContainer _container;

        public IoCContainerManager(IoCContainer container)
        {
            _container = container;
        }

        public IoCContainer Container
        {
            get { return _container; }
        }
    }
}
