using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Configuration;
using DR.Configuration.Parsers;
using DR.Configuration.Settings;

namespace DR.Configuration.Loaders
{
    public internal class WebConfigConfigurationLoader : IConfigurationLoader
    {
         private IConfigurationParseStrategy _parseStrategy;

        public WebConfigConfigurationLoader(IConfigurationParseStrategy parseStrategy)
        {
            _parseStrategy = parseStrategy;

           // _config=Config.ConfigurationManager.OpenExeConfiguration(Config.ConfigurationUserLevel.None);
        }

        public IList<Setting> Load()
        {
            var webConfigSettings = new NameValueCollection();
            LoadFromAllSections(webConfigSettings);
            
            var settings= _parseStrategy.Parse(webConfigSettings);
            return settings;
        }

#region Load

         private NameValueCollection LoadAppSettings()
         {
           return ConfigManager.AppSettings; // will call GetSection("appSettings")
        }

        private void LoadFromAllSections(NameValueCollection webConfigSettings)
        {
            webConfigSettings.Add(LoadAppSettings());
            webConfigSettings.Add(LoadSections());
        }

        private static Dictionary<string,object> GetSettings(Config.ConfigurationSectionGroup configSectionGroup)
        {
            var settings = new Dictionary<string,object>();

            foreach (Config.ConfigurationSectionGroup csg in configSectionGroup.SectionGroups)
                settings.Add(GetSettings(csg));

            foreach (Config.ConfigurationSection cs in configSectionGroup.Sections)
                settings.Add(configSectionGroup.SectionGroupName + "/" + cs.SectionInformation.SectionName);

            return settings;
        }

        private NameValueCollection LoadSections()
        {
            var settings = new Dictionary<string,object>();
            foreach (Config.ConfigurationSectionGroup csg in _config.SectionGroups)
                settings.Add(GetSettings(csg));

            foreach (Config.ConfigurationSection cs in _config.Sections)
                settings.Add(cs.SectionInformation.SectionName);

            return null;
        }

#endregion
    }
}
