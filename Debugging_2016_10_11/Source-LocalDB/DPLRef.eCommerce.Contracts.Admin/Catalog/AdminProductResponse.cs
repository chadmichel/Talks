using DPLRef.eCommerce.Common.Shared;

namespace DPLRef.eCommerce.Contracts.Admin.Catalog
{
    public class AdminProductResponse : ResponseBase
    {
        public WebStoreCatalog Catalog { get; set; }
    }
}
