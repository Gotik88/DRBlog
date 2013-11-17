
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using DR.Configuration.Parsers;
using DR.Configuration.Settings;

namespace DR.Configuration.Loaders.ParseStrategies
{
    internal class WebConfigSectionParseStrategy : IConfigurationParseStrategy
    {
        private List<Setting> _settings = new List<Setting>();

        public void Parse(NameValueCollection nameValueCollection)
        {
            if (nameValueCollection != null)
            {
                _settings = nameValueCollection.Cast<NameObjectCollectionBase>().Select(nvc => new Setting
                {
                    Key =nvc.
                });

                return _settings;
            }
        }

        private 
    }
}
