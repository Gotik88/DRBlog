

namespace DR.Configuration.Loaders
{
    public interface IConfigurationLoaderFactory
    {
        IConfigurationLoader Create(ConfigurationType configurationType);
    }
}
