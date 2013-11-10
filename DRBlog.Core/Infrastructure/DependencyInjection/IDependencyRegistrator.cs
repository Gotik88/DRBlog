
namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    public interface IDependencyRegistrator
    {
        void Register(IIoCContainer container);

        int Order { get; }
    }
}
