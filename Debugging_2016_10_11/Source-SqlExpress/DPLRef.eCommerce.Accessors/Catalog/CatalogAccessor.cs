using System.Collections.Generic;
using System.Linq;

namespace DPLRef.eCommerce.Accessors.Catalog
{
    class CatalogAccessor : AccessorBase, ICatalogAccessor
    {

        public WebStoreCatalog Find(int catalogId)
        {
            var db = new Models.eCommerceDbContext();
            var model = (from c in db.Catalogs
                        where c.Id == catalogId
                        join s in db.Sellers on c.SellerId equals s.Id
                        select new
                        {
                            Catalog = c,
                            SellerName = s.Name,
                            IsApproved = s.IsApproved
                        })
                        .FirstOrDefault();


            if (model != null)
            {
                var catalog = new WebStoreCatalog();
                DTOMapper.Map(model.Catalog, catalog);
                catalog.SellerName = model.SellerName;
                catalog.IsApproved = model.IsApproved;
                return catalog;
            }
            return null;
        }
 
        public WebStoreCatalog SaveCatalog(WebStoreCatalog catalog)
        {
            var db = new Models.eCommerceDbContext();
            Models.Catalog model = null;
            if (catalog.Id > 0)
            {
                model = db.Catalogs.Find(catalog.Id);
                DTOMapper.Map(catalog, model);
            }
            else
            {
                model = new Models.Catalog();
                DTOMapper.Map(catalog, model);
                db.Catalogs.Add(model);
            }
            db.SaveChanges();

            if (model != null && model.Id > 0)
            {
                // We want to reload, to ensure we get IsApproved and SellerName 
                // set correctly.
                var result = Find(model.Id);
                return result;
            }
            return null;
        }

        public void DeleteCatalog(int id)
        {
            var db = new Models.eCommerceDbContext();
            var model = db.Catalogs.Find(id);
            if (model != null)
            {
                db.Catalogs.Remove(model);
                db.SaveChanges();
            }
        }

        public WebStoreCatalog[] FindAllSellerCatalogs(int sellerId)
        {
            var db = new Models.eCommerceDbContext();
            var catalogModels = from c in db.Catalogs
                                where c.SellerId == sellerId
                                join s in db.Sellers on c.SellerId equals s.Id
                                select new 
                                {
                                    Catalog = c,
                                    SellerName = s.Name,
                                    IsApproved = s.IsApproved
                                };


            var result = new List<WebStoreCatalog>();
            foreach (var model in catalogModels)
            {
                var catalog = new WebStoreCatalog();
                DTOMapper.Map(model.Catalog, catalog);
                catalog.SellerName = model.SellerName;
                catalog.IsApproved = model.IsApproved;          
                result.Add(catalog);
            }
            return result.ToArray();
        }

        public Product[] FindAllProductsForCatalog(int catalogId)
        {
            var db = new Models.eCommerceDbContext();
            var productsModels = db.Products.Where(p => p.CatalogId == catalogId);
            var products = new List<Product>();
            if (productsModels.Count() > 0)
            {
                foreach (var p in productsModels)
                {
                    var product = new Product();
                    DTOMapper.Map(p, product);
                    products.Add(product);
                }
            }
            return products.ToArray();
        }

        public Product FindProduct(int id)
        {
            var db = new Models.eCommerceDbContext();
            var model = db.Products.Find(id);
            if (model != null)
            {
                var product = new Product();
                DTOMapper.Map(model, product);
                return product;
            }
            return null;
        }

        public Product SaveProduct(Product product)
        {
            var db = new Models.eCommerceDbContext();
            Models.Product model = null;
            if (product.Id > 0)
            {
                model = db.Products.Find(product.Id);
            }
            else
            {
                model = new Models.Product();
                 DTOMapper.Map(product, model);
                db.Products.Add(model);
            }
            db.SaveChanges();

            if (model != null)
            {
                var result = new Product();
                DTOMapper.Map(model, result);
                return result;
            }
            return null;
        }

        public void DeleteProduct(int id)
        {
            var db = new Models.eCommerceDbContext();
            var model = db.Products.Find(id);
            if (model != null)
            {
                db.Products.Remove(model);
                db.SaveChanges();
            }
        }
    }
}
