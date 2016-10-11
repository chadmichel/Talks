using DPLRef.eCommerce.Accessors;
using DPLRef.eCommerce.Accessors.Catalog;
using DPLRef.eCommerce.Common.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DPLRef.eCommerce.Tests.AccessorTests
{
    [TestClass]
    public class CatalogAccessorTests : DbTestAccessorBase
    {
        private static AmbientContext Context
        {
            get
            {
                return new AmbientContext();
            }
        }
        private ICatalogAccessor CreateAccessor()
        {
            var accessor = new AccessorFactory(Context);
            var result = accessor.CreateAccessor<ICatalogAccessor>();
            return result;
        }

        private Product CreateProduct(WebStoreCatalog catalog)
        {
            var accessor = CreateAccessor();
            var product = new Product()
            {
                Name = "UNIT TEST PRODUCT",
                CatalogId = catalog.Id,
                IsDownloadable = true,
                IsAvailable = true
            };
            var saved = accessor.SaveProduct(product);
            return saved;
        }

        private WebStoreCatalog CreateCatalog()
        {
            var accessor = CreateAccessor();
            var catalog = new WebStoreCatalog()
            {
                Name = "UNIT TEST CATALOG",
                SellerId = 1
            };
            var saved = accessor.SaveCatalog(catalog);
            return saved;
        }
        
        [TestMethod]
        [TestCategory("Accessor Tests")]
        public void CatalogAccessor_Find_FindNone()
        {
            var accessor = CreateAccessor();
            var catalog = accessor.Find(99999);
            Assert.IsNull(catalog);
        }

        [TestMethod]
        [TestCategory("Accessor Tests")]
        public void CatalogAccessor_FindAllProductsForCatalog_None()
        {
            var accessor = CreateAccessor();
            var products = accessor.FindAllProductsForCatalog(99999);
            Assert.IsNotNull(products);
            Assert.AreEqual(0, products.Length);
        }

        [TestMethod]
        [TestCategory("Accessor Tests")]
        public void CatalogAccessor_FindAllProduct_None()
        {
            var accessor = CreateAccessor();
            var product = accessor.FindProduct(99999);
            Assert.IsNull(product);
        }

        [TestMethod]
        [TestCategory("Accessor Tests")]
        public void CatalogAccessor_Catalog_CRUD()
        {
            var accessor = CreateAccessor();
            var saved = CreateCatalog();
            Assert.IsNotNull(saved);
            Assert.IsTrue(saved.Id > 0);

            var loaded = accessor.Find(saved.Id);
            Assert.IsNotNull(loaded);
            Assert.IsTrue(loaded.Id > 0);
            Assert.AreEqual(saved.Id, loaded.Id);

            loaded.Name = "LOADED";
            accessor.SaveCatalog(loaded);
            var loaded2 = accessor.Find(loaded.Id);
            Assert.AreEqual("LOADED", loaded.Name);

            accessor.DeleteCatalog(loaded.Id);

            var loaded3 = accessor.Find(loaded.Id);
            Assert.IsNull(loaded3);
        }

        [TestMethod]
        [TestCategory("Accessor Tests")]
        public void CatalogAccessor_Product_CRUD()
        {
            var accessor = CreateAccessor();
            var catalog = CreateCatalog();
            var saved = CreateProduct(catalog);
            Assert.IsNotNull(saved);
            Assert.IsTrue(saved.Id > 0);

            var loaded = accessor.FindProduct(saved.Id);
            Assert.IsNotNull(loaded);
            Assert.IsTrue(loaded.Id > 0);
            Assert.AreEqual(saved.Id, loaded.Id);

            loaded.Name = "LOADED";
            accessor.SaveProduct(loaded);
            var loaded2 = accessor.FindProduct(loaded.Id);
            Assert.AreEqual("LOADED", loaded.Name);

            var products = accessor.FindAllProductsForCatalog(catalog.Id);
            Assert.IsNotNull(products);
            Assert.AreEqual(1, products.Length);

            accessor.DeleteProduct(loaded.Id);

            var loaded3 = accessor.FindProduct(loaded.Id);
            Assert.IsNull(loaded3);
        }



    }
}
