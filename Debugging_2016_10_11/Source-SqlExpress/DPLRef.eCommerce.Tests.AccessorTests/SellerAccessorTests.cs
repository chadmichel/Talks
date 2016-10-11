using DPLRef.eCommerce.Accessors;
using DPLRef.eCommerce.Accessors.Remittance;
using DPLRef.eCommerce.Common.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DPLRef.eCommerce.Tests.AccessorTests
{
    [TestClass]
    public class SellerAccessorTests : DbTestAccessorBase
    {
        #region Helpers

        private static AmbientContext Context
        {
            get
            {
                return new AmbientContext();
            }
        }
        private static ISellerAccessor CreateAccessor()
        {
            var accessor = new AccessorFactory(Context);
            var result = accessor.CreateAccessor<ISellerAccessor>();
            return result;
        }

        public static Seller CreateSeller()
        {
            var accessor = CreateAccessor();
            var seller = new Seller()
            {
                Name = "UNIT TEST SELLER",
                IsApproved = true,
                UserName = "UNIT TEST USER",
            };
            var saved = accessor.Save(seller);
            return saved;
        }

        #endregion

        [TestMethod]
        [TestCategory("Accessor Tests")]
        public void SellerAccessor_Find_FindNone()
        {
            var accessor = CreateAccessor();
            var seller = accessor.Find(-1);
            Assert.IsNull(seller);
        }

        [TestMethod]
        [TestCategory("Accessor Tests")]
        public void SellerAccessor_Seller_CRUD()
        {
            var accessor = CreateAccessor();
            var created = CreateSeller();
            Assert.IsTrue(created.Id > 0);

            var loaded = accessor.Find(created.Id);
            Assert.IsNotNull(loaded);
            Assert.AreEqual(created.Id, loaded.Id);

            loaded.Name = "UPDATED";
            var updated = accessor.Save(loaded);
            Assert.IsNotNull(updated);
            Assert.AreEqual(created.Id, updated.Id);
            Assert.AreEqual("UPDATED", updated.Name);

            accessor.Delete(updated.Id);

            var loadedFail = accessor.Find(updated.Id);
            Assert.IsNull(loadedFail);  
        }
       
    }
}
