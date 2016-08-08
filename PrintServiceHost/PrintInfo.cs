using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PrintServiceHost
{
    [DataContract]
    public class PrintInfo
    {
        [DataMember]
        public string DocumentName { get; set; }


        [DataMember]
        public string ContainerName { get; set; }

        [DataMember]
        public string PrintQueueName { get; set; }
    }
}
