using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckServiceState
{
    public class ServiceConfig
    {
        /// <summary>
        /// Name of the service to monitor
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Delay in seconds between checks
        /// </summary>
        public int Delay { get; set; }

        public ServiceConfig(string name, int delay =60)
        {
            Name = name;
            Delay = delay;
        }
    }
}
