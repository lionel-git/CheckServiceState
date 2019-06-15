using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckServiceState
{
    public class Configuration
    {
        public List<ServiceConfig> ServiceConfigs { get; set; }

        public Configuration()
        {
            ServiceConfigs = new List<ServiceConfig>();            
        }       
    }
}
