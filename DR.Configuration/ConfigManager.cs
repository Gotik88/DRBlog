using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Configuration
{
    public class ConfigManager : IConfigurationManager
    {
        public IConfigurationLoader Loader { get; set; }
        
    }
}
