using DPLRef.eCommerce.Accessors.Sales;

namespace DPLRef.eCommerce.Engines.Sales
{
    class TaxCalculationEngine : EngineBase, ITaxCalculationEngine
    {
        public override string TestMe(string input)
        {
            input = base.TestMe(input);
            input = AccessorFactory.CreateAccessor<ITaxRulesAccessor>().TestMe(input);
            return input;
        }
    }
}
