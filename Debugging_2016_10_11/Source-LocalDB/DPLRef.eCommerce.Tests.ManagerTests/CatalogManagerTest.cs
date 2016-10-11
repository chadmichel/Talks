using Microsoft.VisualStudio.TestTools.UnitTesting;
using DPLRef.eCommerce.Managers;
using Moq;
using DPLRef.eCommerce.Accessors;
using acc = DPLRef.eCommerce.Accessors.Catalog;
using Admin = DPLRef.eCommerce.Contracts.Admin.Catalog;
using DPLRef.eCommerce.Common.Shared;
using WebStore = DPLRef.eCommerce.Contracts.WebStore.Catalog;

namespace DPLRef.eCommerce.Tests.ManagerTests
{
    [TestClass]
    public class CatalogManagerTest
    {

        #region Helpers
        private static AccessorFactory SetupMockAccessorFactory()
        {

            Mock<acc.ICatalogAccessor> mockAccessor = new Mock<acc.ICatalogAccessor>();
            mockAccessor.Setup(ca => ca.Find(1)).Returns(() =>
            {
                return new acc.WebStoreCatalog()
                {
                    Id = 1,
                    Name = "My Webstore"
                };
            });
            mockAccessor.Setup(ca => ca.FindAllSellerCatalogs(1)).Returns(() => new acc.WebStoreCatalog[]
            {   new acc.WebStoreCatalog()
                {
                    Id = 1,
                    Name = "My Webstore"
                },
                new acc.WebStoreCatalog()
                {
                    Id = 2,
                    Name = "My Second Webstore"
                }
            });
            mockAccessor.Setup(ca => ca.FindAllProductsForCatalog(1)).Returns(() => new acc.Product[]
            {
                new acc.Product()
                {
                    Id = 1,
                    Name = "My Product",
                    Summary = "My Product Summary"
                },
                new acc.Product()
                {
                    Id = 2,
                    Name = "My Second Product",
                    Summary = "My Second Product Summary"
                }
            });
            mockAccessor.Setup(ca => ca.FindProduct(1)).Returns(() => new acc.Product()
            {
                Id = 1,
                Name = "My Product",
                Summary = "My Product Summary"
            });
            AccessorFactory accFactory = new AccessorFactory(new AmbientContext());
            accFactory.AddOverride<acc.ICatalogAccessor>(mockAccessor.Object);
            return accFactory;
        }
        #endregion

        #region IWebStoreCatalogManager

        [TestMethod]
        [TestCategory("Managers-WebStore")]
        public void CatalogManager_FindWebStoreCatalogEmpty()
        {
            AmbientContext context = new AmbientContext()
            {
                CatalogId = 2
            };
            ManagerFactory mgrFactory = new ManagerFactory(context);
            WebStore.IWebStoreCatalogManager mgr = mgrFactory.CreateManager<WebStore.IWebStoreCatalogManager>(null, SetupMockAccessorFactory(), null);
            var response = mgr.ShowCatalog();

            Assert.IsFalse(response.Success);
            Assert.IsNull(response.Catalog);
            Assert.AreEqual("Catalog not found", response.Message);
        }

        [TestMethod]
        [TestCategory("Managers-WebStore")]
        public void CatalogManager_FindWebStoreCatalog()
        {
            AmbientContext context = new AmbientContext()
            {
                CatalogId = 1
            };
            ManagerFactory mgrFactory = new ManagerFactory(context);
            WebStore.IWebStoreCatalogManager mgr = mgrFactory.CreateManager<WebStore.IWebStoreCatalogManager>(null, SetupMockAccessorFactory(), null);
            var response = mgr.ShowCatalog();
            WebStore.WebStoreCatalog catalog = response.Catalog;

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, catalog.Id);
            Assert.AreEqual(2, catalog.Products.Length);
            Assert.AreEqual("My Product",catalog.Products[0].Name);
            Assert.AreEqual("My Second Product",catalog.Products[1].Name);
            Assert.AreEqual("My Webstore", catalog.Name);
        }

        [TestMethod]
        [TestCategory("Managers-WebStore")]
        public void CatalogManager_FindWebStoreProduct()
        {
            AmbientContext context = new AmbientContext();
            ManagerFactory mgrFactory = new ManagerFactory(context);
            var mgr = mgrFactory.CreateManager<WebStore.IWebStoreCatalogManager>(null, SetupMockAccessorFactory(), null);
            var response = mgr.ShowProduct(1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Product.Id);
            Assert.AreEqual(response.Product.Name, "My Product");

            response = mgr.ShowProduct(-1);

            Assert.IsFalse(response.Success);
            Assert.IsNull(response.Product);
            Assert.AreEqual(response.Message, "Product not found");
        }
        #endregion  

        #region IAdminCatalogManager
        [TestMethod]
        [TestCategory("Managers-Admin")]
        public void CatalogManager_FindAdminCatalogListEmpty()
        {
            AmbientContext context = new AmbientContext()
            {
                SellerId = -1,
                SellerAuthToken = "MyToken"
            };
            ManagerFactory mgrFactory = new ManagerFactory(context);
            var mgr = mgrFactory.CreateManager<Admin.IAdminCatalogManager>(null, SetupMockAccessorFactory(), null);
            var response = mgr.FindCatalogs();

            Assert.IsTrue(response.Success);
            Assert.AreEqual(0, response.Catalogs.Length);
        }

        [TestMethod]
        [TestCategory("Managers-Admin")]
        public void CatalogManager_FindAdminCatalogList()
        {
            AmbientContext context = new AmbientContext()
            {
                SellerId = 1,
                SellerAuthToken = "MyToken"
            };
            ManagerFactory mgrFactory = new ManagerFactory(context);
            var mgr = mgrFactory.CreateManager<Admin.IAdminCatalogManager>(null, SetupMockAccessorFactory(), null);
            var response = mgr.FindCatalogs();

            Assert.IsTrue(response.Success);
            Assert.AreEqual(2, response.Catalogs.Length);
        }

        [TestMethod]
        [TestCategory("Managers-Admin")]
        public void CatalogManager_FindAdminCatalogListNoAuth()
        {
            AmbientContext context = new AmbientContext()
            {
                SellerId = 1,
                SellerAuthToken = ""
            };
            ManagerFactory mgrFactory = new ManagerFactory(context);
            var mgr = mgrFactory.CreateManager<Admin.IAdminCatalogManager>(null, SetupMockAccessorFactory(), null);
            var response = mgr.FindCatalogs();

            Assert.IsFalse(response.Success);
            Assert.AreEqual("Seller not authenticated", response.Message);
            Assert.IsNull(response.Catalogs);
        }
        #endregion

        [TestMethod]
        [TestCategory("Managers-Admin")]
        public void CatalogManager_ShowAdminCatalogEmpty()
        {
            AmbientContext context = new AmbientContext()
            {
                SellerId = 1,
                SellerAuthToken = "MyToken",
                CatalogId = -1
            };
            ManagerFactory mgrFactory = new ManagerFactory(context);
            var mgr = mgrFactory.CreateManager<Admin.IAdminCatalogManager>(null, SetupMockAccessorFactory(), null);
            var response = mgr.ShowCatalog();

            Assert.IsFalse(response.Success);
            Assert.IsNull(response.Catalog);
            Assert.AreEqual("Catalog not found", response.Message);
        }

        [TestMethod]
        [TestCategory("Managers-Admin")]
        public void CatalogManager_ShowAdminCatalog()
        {
            AmbientContext context = new AmbientContext()
            {
                SellerId = 1,
                SellerAuthToken = "MyToken",
                CatalogId = 1
            };
            ManagerFactory mgrFactory = new ManagerFactory(context);
            var mgr = mgrFactory.CreateManager<Admin.IAdminCatalogManager>(null, SetupMockAccessorFactory(), null);
            var response = mgr.ShowCatalog();

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Catalog.Id);
            Assert.AreEqual("My Webstore", response.Catalog.Name);
        }
        [TestMethod]
        [TestCategory("Managers-Admin")]
        public void CatalogManager_ShowAdminCatalogNoAuth()
        {
            AmbientContext context = new AmbientContext()
            {
                SellerId = 1,
                SellerAuthToken = "",
                CatalogId = 1
            };
            ManagerFactory mgrFactory = new ManagerFactory(context);
            var mgr = mgrFactory.CreateManager<Admin.IAdminCatalogManager>(null, SetupMockAccessorFactory(), null);
            var response = mgr.ShowCatalog();

            Assert.IsFalse(response.Success);
            Assert.AreEqual("Seller not authenticated", response.Message);
            Assert.IsNull(response.Catalog);
        }
    }
}
