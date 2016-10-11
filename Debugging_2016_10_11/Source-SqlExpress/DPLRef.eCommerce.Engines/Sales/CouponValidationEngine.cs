using DPLRef.eCommerce.Accessors.Sales;

namespace DPLRef.eCommerce.Engines.Sales
{
    class CouponValidationEngine : EngineBase, ICouponValidationEngine
    {
        public override string TestMe(string input)
        {
            input = base.TestMe(input);
            input = AccessorFactory.CreateAccessor<ICouponRulesAccessor>().TestMe(input);
            return input;
        }
    }
}
