using System.ServiceModel;

namespace PrintServiceHost
{
    [ServiceContract(Name ="IPrintContract", Namespace = "urn:ps")]
    public interface IPrintContract
    {
        [OperationContract]
        string SendToPrintQueue(PrintInfo printInfo);
    }

    public interface IPrintChannel : IPrintContract, IClientChannel { }
}
