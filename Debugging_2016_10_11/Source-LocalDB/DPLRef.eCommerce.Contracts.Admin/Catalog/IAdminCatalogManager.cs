using System.ServiceModel;
using DPLRef.eCommerce.Common.Shared;

namespace DPLRef.eCommerce.Contracts.Admin.Catalog
{
    [ServiceContract]
    public interface IAdminCatalogManager : IServiceContractBase
    {
        /// <summary>
        /// Shows the list of catalogs for the authenticated seller
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        AdminCatalogsResponse FindCatalogs();

        /// <summary>
        /// Shows a specific catalog for the authenticated seller
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        AdminCatalogResponse ShowCatalog();

        /// <summary>
        /// Updates a specific catalog for the authenticated seller
        /// </summary>
        [OperationContract]
        void SaveCatalog();

        /// <summary>
        /// Shows a specific product for the authenticated seller
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Product ShowProduct(int productId);

        /// <summary>
        /// Updates a specific product for the authenticated seller
        /// </summary>
        [OperationContract]
        void SaveProduct();
    }
}
