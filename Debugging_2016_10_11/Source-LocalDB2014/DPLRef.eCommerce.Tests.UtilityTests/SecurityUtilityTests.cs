using System;
using DPLRef.eCommerce.Common.Shared;
using DPLRef.eCommerce.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DPLRef.eCommerce.Tests.UtilityTests
{
    [TestClass]
    public class SecurityUtilityTests
    {
        [TestMethod]
        [TestCategory("Utilities")]
        public void SecurityUtility_SellerAuthenticated()
        {
            AmbientContext context = new AmbientContext();
            context.SellerAuthToken = "Blah";
            context.SellerId = 1;

            UtilityFactory utilFactory = new UtilityFactory(context);

            ISecurityUtility securityUtility = utilFactory.CreateUtility<ISecurityUtility>();

            Assert.IsTrue(securityUtility.SellerAuthenticated());

            context.SellerAuthToken = "Invalid";
            utilFactory = new UtilityFactory(context);
            securityUtility = utilFactory.CreateUtility<ISecurityUtility>();

            Assert.IsFalse(securityUtility.SellerAuthenticated());

            context.SellerAuthToken = "";
            utilFactory = new UtilityFactory(context);
            securityUtility = utilFactory.CreateUtility<ISecurityUtility>();

            Assert.IsFalse(securityUtility.SellerAuthenticated());
        }
    }
}
