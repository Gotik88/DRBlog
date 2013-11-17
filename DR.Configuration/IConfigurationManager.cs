
namespace DR.Configuration
{
    public interface IConfigurationManager
    {
        IConfigurationLoader ConfigurationLoader { get; set; }

        ConfigurationContext Context { get; }

        void RefreshConfiguration();
    }
}
