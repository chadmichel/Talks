using DPLRef.eCommerce.Accessors.Sales;

namespace DPLRef.eCommerce.Engines.Sales
{
    class VolumeDiscountCalculationEngine : EngineBase, IVolumeDiscountCalculationEngine
    {
        public override string TestMe(string input)
        {
            input = base.TestMe(input);
            input = AccessorFactory.CreateAccessor<IVolumeDiscountRulesAccessor>().TestMe(input);
            return input;
        }
    }
}
