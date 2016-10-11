using DPLRef.eCommerce.Common.Shared;

namespace DPLRef.eCommerce.Common.Utilities
{
    public interface ISecurityUtility : IServiceContractBase
    {
        bool SellerAuthenticated();
    }
}
