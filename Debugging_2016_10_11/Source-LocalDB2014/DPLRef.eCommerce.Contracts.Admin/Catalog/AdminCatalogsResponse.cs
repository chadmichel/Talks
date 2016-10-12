using DPLRef.eCommerce.Common.Shared;

namespace DPLRef.eCommerce.Contracts.Admin.Catalog
{
    public class AdminCatalogsResponse : ResponseBase
    {
        public WebStoreCatalog[] Catalogs { get; set; }
    }
}
