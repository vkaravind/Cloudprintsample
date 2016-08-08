using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PrintServiceHost
{
    [ServiceContract(Name = "IPrintContract", Namespace = "urn:ps")]
    public interface IPrintContract
    {
        [OperationContract]
        string SendToPrintQueue(PrintInfo printInfo);
    }

    public interface IPrintChannel : IPrintContract, IClientChannel { }
}
