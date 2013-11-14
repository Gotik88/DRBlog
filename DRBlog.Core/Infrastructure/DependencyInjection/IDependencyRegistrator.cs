
namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    public interface IDependencyRegistrator
    {
        void Register(IoCContainer container);

        int Order { get; }
    }
}
