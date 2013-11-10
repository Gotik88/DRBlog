
namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    public interface ILifestyleConverter
    {
        void ConvertTo(ComponentLifeStyle lifestyle);
    }
}
