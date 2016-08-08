using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
