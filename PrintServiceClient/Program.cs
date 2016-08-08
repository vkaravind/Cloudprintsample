using Microsoft.ServiceBus;
using PrintServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PrintServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Https;
            var cf = new ChannelFactory<IPrintChannel>(
    new NetTcpRelayBinding { IsDynamic = true },
    new EndpointAddress(ServiceBusEnvironment.CreateServiceUri("sb", "[Servicebusnamespace]", "printservice"))); //add Servicebusnamespace

            cf.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior
            { TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("[KeyName]", "[Key]") });//add SAS keyname and key
            IPrintChannel channel = cf.CreateChannel();
            channel.Open();

            Console.WriteLine(channel.SendToPrintQueue(new PrintInfo { DocumentName = "sample.pdf", ContainerName = "documents", PrintQueueName = "queue1" })); // update document name and container name as applicable.

            channel.Close();
            cf.Close();            
        }
    }
}
