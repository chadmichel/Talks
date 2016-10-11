using DPLRef.eCommerce.Common.Shared;
using System.ServiceModel;

// ReSharper disable once CheckNamespace
namespace DPLRef.eCommerce.Contracts.WebStore.Catalog
{

    [ServiceContract]
    public interface IWebStoreCatalogManager : IServiceContractBase
    {
        /// <summary>
        /// Return the webstore catalog detail and product summary information that is required to show a webstore page
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        WebStoreCatalogResponse ShowCatalog();
        
        /// <summary>
        /// Returns the details of a specific product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [OperationContract]
        WebStoreProductResponse ShowProduct(int productId);
    }
}
