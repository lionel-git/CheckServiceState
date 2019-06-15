using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using Newtonsoft.Json;

namespace CheckServiceState
{
    class Program
    {
        private static string CheckState(string serviceName)
        {
            ServiceController sc = new ServiceController(serviceName);
            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    return "Starting";
                default:
                    return "Status Changing";
            }
        }


        static void TestConfig()
        {
            var configuration = new Configuration();
            configuration.ServiceConfigs.Add(new ServiceConfig("CheckDisk", 10));
            configuration.ServiceConfigs.Add(new ServiceConfig("CheckDisk2", 70));
            string output = JsonConvert.SerializeObject(configuration, Formatting.Indented);
            Console.WriteLine(output);
        }
        static void TestLoadConfig()
        {
            var content = File.ReadAllText("config.json");
            var configuration = JsonConvert.DeserializeObject<Configuration>(content);            
        }

        static void Main(string[] args)
        {
            try
            {
                //TestConfig(); return;
                //TestLoadConfig(); return;

                string serviceName = "CheckDisk";
                var ret = CheckState(serviceName);
                Console.WriteLine($"{serviceName} => {ret}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
