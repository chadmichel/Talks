using Microsoft.VisualStudio.TestTools.UnitTesting;
using DPLRef.eCommerce.Managers;
using DPLRef.eCommerce.Common.Shared;
using DPLRef.eCommerce.Contracts.Admin.Catalog;
using DPLRef.eCommerce.Contracts.Admin.Sales;
using DPLRef.eCommerce.Contracts.BackOfficeAdmin.Remittance;
using DPLRef.eCommerce.Contracts.WebStore.Catalog;
using DPLRef.eCommerce.Contracts.WebStore.Sales;
using DPLRef.eCommerce.Managers.Notification;

namespace DPLRef.eCommerce.Tests.SmokeTests
{
    [TestClass]
    public class SmokeTest
    {
        private static AmbientContext Context
        {
            get
            {
                return new AmbientContext();
            }
        }

        [TestMethod]
        [TestCategory("Smoke Tests")]
        public void SmokeTest_OrderManager()
        {
            string input = "SmokeTest_OrderManager";
            ManagerFactory _factory = new ManagerFactory(Context);
            // Test for ICartManager, IOrderManager, IReturnsManager
            Assert.AreEqual("SmokeTest_OrderManager : OrderManager : CartAccessor : TaxCalculationEngine : TaxRulesAccessor : VolumeDiscountCalculationEngine : VolumeDiscountRulesAccessor : CouponValidationEngine : CouponRulesAccessor", _factory.CreateManager<IOrderManager>().TestMe(input));
            Assert.AreEqual("SmokeTest_OrderManager : OrderManager : CartAccessor : TaxCalculationEngine : TaxRulesAccessor : VolumeDiscountCalculationEngine : VolumeDiscountRulesAccessor : CouponValidationEngine : CouponRulesAccessor", _factory.CreateManager<ICartManager>().TestMe(input));
            Assert.AreEqual("SmokeTest_OrderManager : OrderManager : CartAccessor : TaxCalculationEngine : TaxRulesAccessor : VolumeDiscountCalculationEngine : VolumeDiscountRulesAccessor : CouponValidationEngine : CouponRulesAccessor", _factory.CreateManager<IReturnsManager>().TestMe(input));
        }

        [TestMethod]
        [TestCategory("Smoke Tests")]
        public void SmokeTest_CatalogManager()
        {
            string input = "SmokeTest_CatalogManager";
            ManagerFactory _factory = new ManagerFactory(Context);
            // Smoke test for both interfaces implemented by Catalog Manager
            Assert.AreEqual("SmokeTest_CatalogManager : CatalogManager : CatalogAccessor", _factory.CreateManager<IWebStoreCatalogManager>().TestMe(input));
            Assert.AreEqual("SmokeTest_CatalogManager : CatalogManager : CatalogAccessor", _factory.CreateManager<IAdminCatalogManager>().TestMe(input));
        }

        [TestMethod]
        [TestCategory("Smoke Tests")]
        public void SmokeTest_NotificationManager()
        {
            string input = "SmokeTest_NotificationManager";
            ManagerFactory _factory = new ManagerFactory(Context);
            // Smoke test for both interfaces implemented by Notification Manager
            Assert.AreEqual("SmokeTest_NotificationManager : NotificationManager : EmailFormattingEngine : EmailAccessor", _factory.CreateManager<INotificationManager>().TestMe(input));
        }

        [TestMethod]
        [TestCategory("Smoke Tests")]
        public void SmokeTest_RemittanceManager()
        {
            string input = "SmokeTest_RemittanceManager";
            ManagerFactory _factory = new ManagerFactory(Context);
            // Smoke test for both interfaces implemented by Remittancen Manager
            Assert.AreEqual("SmokeTest_RemittanceManager : RemittanceManager : RemittanceAccessor", _factory.CreateManager<IRemittanceManager>().TestMe(input));
        }
    }
}
