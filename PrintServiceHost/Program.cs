using Microsoft.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PrintServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Https;
            ServiceHost sh = new ServiceHost(typeof(PrintService));
            
            sh.Open();
            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();
            sh.Close();
        }
    }
}
