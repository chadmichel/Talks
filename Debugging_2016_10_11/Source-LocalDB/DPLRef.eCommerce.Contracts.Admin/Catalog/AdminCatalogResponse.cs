using DPLRef.eCommerce.Common.Shared;

namespace DPLRef.eCommerce.Contracts.Admin.Catalog
{
    public class AdminCatalogResponse : ResponseBase
    {
        public WebStoreCatalog Catalog { get; set; }
    }
}
