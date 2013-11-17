using System;


namespace DR.Configuration.Loaders
{
    public class ConfigurationLoaderFactory : IConfigurationLoaderFactory
    {
        public IConfigurationLoader Create(ConfigurationType configType)
        {
            IConfigurationLoader configurationLoader = null;

            switch (configType)
            {
                case ConfigurationType.WebConfig:
                    configurationLoader = new WebConfigConfigurationLoader();
                    break;

                case ConfigurationType.DataBase:

                    break;

                case ConfigurationType.File:
                    throw new NotImplementedException("The are no implementation for file configuration");
                    break;

                default:
                    throw new Exception("Incorrect Inversion Of Control Container Type");
            }

            return configurationLoader;
        }
    }
}
