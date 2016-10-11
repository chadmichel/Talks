using DPLRef.eCommerce.Accessors.Catalog;
using DPLRef.eCommerce.Common.Shared;
using Admin = DPLRef.eCommerce.Contracts.Admin.Catalog;
using WebStore = DPLRef.eCommerce.Contracts.WebStore.Catalog;
using CatAcc = DPLRef.eCommerce.Accessors.Catalog;
using System;
using System.Collections.Generic;
using DPLRef.eCommerce.Common.Utilities;

namespace DPLRef.eCommerce.Managers.Catalog
{
    class CatalogManager : ManagerBase, WebStore.IWebStoreCatalogManager, Admin.IAdminCatalogManager
    {

        #region IAdminCatalogManager

        Admin.AdminCatalogsResponse Admin.IAdminCatalogManager.FindCatalogs()
        {
            try
            {
                // authenticate the user as a seller
                if (UtilityFactory.CreateUtility<ISecurityUtility>().SellerAuthenticated())
                {
                    var catalogs = AccessorFactory.CreateAccessor<ICatalogAccessor>()
                        .FindAllSellerCatalogs(Context.SellerId);

                    List<Admin.WebStoreCatalog> catalogList = new List<Admin.WebStoreCatalog>();
                    foreach (var catalog in catalogs)
                    {
                        Admin.WebStoreCatalog wsCatalog = new Admin.WebStoreCatalog();
                        DTOMapper.Map(catalog, wsCatalog);
                        catalogList.Add(wsCatalog);
                    }
                    return new Admin.AdminCatalogsResponse()
                    {
                        Success = true,
                        Catalogs = catalogList.ToArray()
                    };

                }
                return new Admin.AdminCatalogsResponse()
                {
                    Success = false,
                    Message = "Seller not authenticated"
                };
            }
            catch (Exception)
            {
                // TODO: Log this exception
                return new Admin.AdminCatalogsResponse()
                {
                    Success = false,
                    Message = "There was a problem accessing this seller's catalogs"
                };
            }

        }

        void Admin.IAdminCatalogManager.SaveCatalog()
        {
            throw new NotImplementedException();
        }

        void Admin.IAdminCatalogManager.SaveProduct()
        {
            throw new NotImplementedException();
        }

        Admin.AdminCatalogResponse Admin.IAdminCatalogManager.ShowCatalog()
        {
            try
            {
                // authenticate the user as a seller
                if (UtilityFactory.CreateUtility<ISecurityUtility>().SellerAuthenticated())
                {
                    var catalog = AccessorFactory.CreateAccessor<ICatalogAccessor>()
                        .Find(Context.CatalogId);

                    if (catalog != null)
                    {
                        Admin.WebStoreCatalog wsCatalog = new Admin.WebStoreCatalog();
                        DTOMapper.Map(catalog, wsCatalog);

                        return new Admin.AdminCatalogResponse()
                        {
                            Success = true,
                            Catalog = wsCatalog
                        };
                    }
                    return new Admin.AdminCatalogResponse()
                    {
                        Success = false,
                        Message = "Catalog not found"
                    };
                }
                return new Admin.AdminCatalogResponse()
                {
                    Success = false,
                    Message = "Seller not authenticated"
                };
            }
            catch (Exception)
            {
                // TODO: Log this exception
                return new Admin.AdminCatalogResponse()
                {
                    Success = false,
                    Message = "There was a problem accessing the catalog"
                };
            }
        }

        Admin.Product Admin.IAdminCatalogManager.ShowProduct(int productId)
        {
            try
            {
                //authenticate the seller
                if (UtilityFactory.CreateUtility<ISecurityUtility>().SellerAuthenticated())
                {
                    
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return null;
        }

        #endregion

        #region IWebStoreCatalogManager

        WebStore.WebStoreCatalogResponse WebStore.IWebStoreCatalogManager.ShowCatalog()
        {
            try
            {
                // Get the webstore catalog
                WebStore.WebStoreCatalog webstoreCatalog = new WebStore.WebStoreCatalog();
                ICatalogAccessor catalogAccessor = AccessorFactory.CreateAccessor<ICatalogAccessor>();
                CatAcc.WebStoreCatalog accCatalog = catalogAccessor.Find(Context.CatalogId);

                // Get the webstore catalog products
                if (accCatalog != null)
                {
                    DTOMapper.Map(accCatalog, webstoreCatalog);

                    CatAcc.Product[] catalogProducts = catalogAccessor.FindAllProductsForCatalog(Context.CatalogId);
                    List<WebStore.ProductSummary> productList = new List<WebStore.ProductSummary>();

                    foreach (var catalogProduct in catalogProducts)
                    {
                        WebStore.ProductSummary product = new WebStore.ProductSummary();
                        DTOMapper.Map(catalogProduct, product);
                        productList.Add(product);
                    }
                    webstoreCatalog.Products = productList.ToArray();

                    return new WebStore.WebStoreCatalogResponse()
                    {
                        Success = true,
                        Catalog = webstoreCatalog
                    };
                }
                return new WebStore.WebStoreCatalogResponse()
                {
                    Success = false,
                    Message = "Catalog not found"
                };
            }
            catch (Exception)
            {
                // TODO: Log this exception
                return new WebStore.WebStoreCatalogResponse()
                {
                    Success = false,
                    Message = "There was a problem accessing the catalog"
                };
            }
        }

        WebStore.WebStoreProductResponse WebStore.IWebStoreCatalogManager.ShowProduct(int productId)
        {
            try
            {
                WebStore.ProductDetail productDetail = new WebStore.ProductDetail();
                CatAcc.Product catProduct = AccessorFactory.CreateAccessor<ICatalogAccessor>().FindProduct(productId);

                if (catProduct != null)
                {
                    DTOMapper.Map(AccessorFactory.CreateAccessor<ICatalogAccessor>().FindProduct(productId), productDetail);

                    return new WebStore.WebStoreProductResponse()
                    {
                        Success = true,
                        Product = productDetail
                    };
                }
                return new WebStore.WebStoreProductResponse()
                {
                    Success = false,
                    Message = "Product not found"
                };

            }
            catch (Exception)
            {
                // TODO: Log this exception
                return new WebStore.WebStoreProductResponse()
                {
                    Success = false,
                    Message = "There was a problem accessing the product"
                };
            }
        }

        #endregion

        #region IServiceContractBase

        string IServiceContractBase.TestMe(string input)
        {
            input = base.TestMe(input);
            input = AccessorFactory.CreateAccessor<ICatalogAccessor>().TestMe(input);

            return input;
        }

        #endregion

    }
}
