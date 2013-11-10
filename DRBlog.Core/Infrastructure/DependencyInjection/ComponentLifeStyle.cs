namespace DRBlog.Core.Infrastructure.DependencyInjection
{
    public enum ComponentLifeStyle
    {
        Singleton = 0,
        Transient = 1,
        PerLifetimeScope = 2,
        PerThread = 3,
        PerWebRequest = 4,
        Pooled = 5,
        CustomLifeStyle = 6,

        Default = 7
    }
}
