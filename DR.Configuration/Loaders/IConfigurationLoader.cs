

namespace DR.Configuration
{
    using System.Collections.Generic;
    using DR.Configuration.Parsers;
    using DR.Configuration.Settings;

    public interface IConfigurationLoader : IConfigurationParseStrategy
    {
        IList<Setting> Load(IConfigurationParseStrategy parseStrategy);
    }
}
