using DPLRef.eCommerce.Common.Shared;

namespace DPLRef.eCommerce.Common.Utilities
{
    public class UtilityFactory : FactoryBase
    {
        public UtilityFactory(AmbientContext context) : base(context) { }

        public T CreateUtility<T>() where T : class
        {
            T result = null;

            result = base.CheckOverrides<T>();
            if (result == null)
            {

                if (typeof(T) == typeof(ISecurityUtility))
                    result = new SecurityUtility() as T;

            }
            if (result is UtilityBase)
                (result as UtilityBase).Context = Context;

            return result;
        }
    }
}
