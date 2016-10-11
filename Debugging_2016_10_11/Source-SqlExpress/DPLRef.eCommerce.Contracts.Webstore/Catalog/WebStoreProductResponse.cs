using DPLRef.eCommerce.Common.Shared;

namespace DPLRef.eCommerce.Contracts.WebStore.Catalog
{
    public class WebStoreProductResponse : ResponseBase
    {
        public ProductDetail Product { get; set; }
    }
}
