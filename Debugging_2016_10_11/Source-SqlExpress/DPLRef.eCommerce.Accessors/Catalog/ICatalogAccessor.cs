using DPLRef.eCommerce.Common.Shared;
using System.ServiceModel;

// Cencept : Accessor
// Sub System : Catalog
namespace DPLRef.eCommerce.Accessors.Catalog
{
    [ServiceContract]
    public interface ICatalogAccessor : IServiceContractBase
    {
        [OperationContract]
        WebStoreCatalog Find(int catalogId);

        [OperationContract]
        WebStoreCatalog SaveCatalog(WebStoreCatalog catalog);

        [OperationContract]
        void DeleteCatalog(int id);

        [OperationContract]
        WebStoreCatalog[] FindAllSellerCatalogs(int sellerId);

        [OperationContract]
        Product FindProduct(int id);

        [OperationContract]
        Product SaveProduct(Product product);

        [OperationContract]
        void DeleteProduct(int id);

        [OperationContract]
        Product[] FindAllProductsForCatalog(int catalogId);

    }
}
