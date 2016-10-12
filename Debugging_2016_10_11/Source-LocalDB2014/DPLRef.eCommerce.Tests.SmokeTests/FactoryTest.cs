using DPLRef.eCommerce.Accessors;
using DPLRef.eCommerce.Accessors.Catalog;
using DPLRef.eCommerce.Accessors.Notifications;
using DPLRef.eCommerce.Accessors.Remittance;
using DPLRef.eCommerce.Accessors.Sales;
using DPLRef.eCommerce.Common.Shared;
using DPLRef.eCommerce.Common.Utilities;
using DPLRef.eCommerce.Contracts.Admin.Catalog;
using DPLRef.eCommerce.Contracts.BackOfficeAdmin.Remittance;
using DPLRef.eCommerce.Contracts.WebStore.Catalog;
using DPLRef.eCommerce.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DPLRef.eCommerce.Contracts.Admin.Sales;
using DPLRef.eCommerce.Contracts.WebStore.Sales;
using DPLRef.eCommerce.Engines;
using DPLRef.eCommerce.Engines.Notification;
using DPLRef.eCommerce.Engines.Sales;
using DPLRef.eCommerce.Managers.Notification;

namespace DPLRef.eCommerce.Tests.SmokeTests
{
    /// <summary>
    /// Summary description for FactoryTest
    /// </summary>
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        [TestCategory("Factory Tests")]
        public void FactoryTest_ManagerFactory()
        {
            AmbientContext context = new AmbientContext();
            ManagerFactory factory =new ManagerFactory(context);

            //Catalog
            Assert.IsTrue(factory.CreateManager<IAdminCatalogManager>() != null);
            Assert.IsTrue(factory.CreateManager<IWebStoreCatalogManager>() != null);
            // Notification
            Assert.IsTrue(factory.CreateManager<INotificationManager>() != null);
            // Remittance
            Assert.IsTrue(factory.CreateManager<IRemittanceManager>() != null);
            // Sales
            Assert.IsTrue(factory.CreateManager<IReturnsManager>() != null);
            Assert.IsTrue(factory.CreateManager<ICartManager>() != null);
            Assert.IsTrue(factory.CreateManager<IOrderManager>() != null);
        }

        [TestMethod]
        [TestCategory("Factory Tests")]
        public void FactoryTest_EngineFactory()
        {
            AmbientContext context = new AmbientContext();
            EngineFactory factory = new EngineFactory(context);

            // Notification
            Assert.IsTrue(factory.CreateEngine<IEmailFormattingEngine>() != null);
            // Sales
            Assert.IsTrue(factory.CreateEngine<ICouponValidationEngine>() != null);
            Assert.IsTrue(factory.CreateEngine<ITaxCalculationEngine>() != null);
            Assert.IsTrue(factory.CreateEngine<IVolumeDiscountCalculationEngine>() != null);
        }

        [TestMethod]
        [TestCategory("Factory Tests")]
        public void FactoryTest_AccessorFactory()
        {
            AmbientContext context = new AmbientContext();
            AccessorFactory factory = new AccessorFactory(context);

            // Catalog
            Assert.IsTrue(factory.CreateAccessor<ICatalogAccessor>() != null);
            // Notification
            Assert.IsTrue(factory.CreateAccessor<IEmailAccessor>() != null);
            // Remittance
            Assert.IsTrue(factory.CreateAccessor<IRemittanceAccessor>() != null);
            Assert.IsTrue(factory.CreateAccessor<ISellerAccessor>() != null);
            // Sales
            Assert.IsTrue(factory.CreateAccessor<ICartAccessor>() != null);
            Assert.IsTrue(factory.CreateAccessor<ICouponRulesAccessor>() != null);
            Assert.IsTrue(factory.CreateAccessor<IOrderAccessor>() != null);
            Assert.IsTrue(factory.CreateAccessor<IPaymentAccessor>() != null);
            Assert.IsTrue(factory.CreateAccessor<IShippingAccessor>() != null);
            Assert.IsTrue(factory.CreateAccessor<IShippingRulesAccessor>() != null);
            Assert.IsTrue(factory.CreateAccessor<ITaxRulesAccessor>() != null);
            Assert.IsTrue(factory.CreateAccessor<IVolumeDiscountRulesAccessor>() != null);
        }

        [TestMethod]
        [TestCategory("Factory Tests")]
        public void FactoryTest_UtilityFactory()
        {
            AmbientContext context = new AmbientContext();
            UtilityFactory factory = new UtilityFactory(context);

            // Security
            Assert.IsTrue(factory.CreateUtility<ISecurityUtility>() != null);
        }
    }
}
