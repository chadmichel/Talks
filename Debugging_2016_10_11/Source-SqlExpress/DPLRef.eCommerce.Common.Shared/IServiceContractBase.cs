using System.ServiceModel;

namespace DPLRef.eCommerce.Common.Shared
{
    [ServiceContract]
    public interface IServiceContractBase
    {
        [OperationContract]
        string TestMe(string input);
    }
}
