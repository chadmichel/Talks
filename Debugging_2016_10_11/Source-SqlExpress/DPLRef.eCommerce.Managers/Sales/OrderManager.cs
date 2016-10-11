using DPLRef.eCommerce.Accessors.Sales;
using DPLRef.eCommerce.Contracts.Admin.Sales;
using DPLRef.eCommerce.Contracts.WebStore.Sales;
using DPLRef.eCommerce.Engines.Sales;

namespace DPLRef.eCommerce.Managers.Sales
{
    class OrderManager : ManagerBase, ICartManager, IOrderManager, IReturnsManager
    {
        #region IServiceContractBase
        public override string TestMe(string input)
        {
            input = base.TestMe(input);
            input = AccessorFactory.CreateAccessor<ICartAccessor>().TestMe(input);
            input = EngineFactory.CreateEngine<ITaxCalculationEngine>().TestMe(input);
            input = EngineFactory.CreateEngine<IVolumeDiscountCalculationEngine>().TestMe(input);
            input = EngineFactory.CreateEngine<ICouponValidationEngine>().TestMe(input);
            return input;
        }
        #endregion
    }
}
