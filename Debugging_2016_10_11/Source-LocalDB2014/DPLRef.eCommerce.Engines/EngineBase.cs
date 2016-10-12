using DPLRef.eCommerce.Accessors;
using DPLRef.eCommerce.Common.Shared;

namespace DPLRef.eCommerce.Engines
{
    abstract class EngineBase : ServiceContractBase
    {
        public AccessorFactory AccessorFactory { get; set; }

        protected EngineBase()
        {
            
        }
    }
}
