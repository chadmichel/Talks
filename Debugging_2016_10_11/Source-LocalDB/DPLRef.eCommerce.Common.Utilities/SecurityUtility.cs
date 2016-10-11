using System;

namespace DPLRef.eCommerce.Common.Utilities
{
    class SecurityUtility : UtilityBase, ISecurityUtility
    {
        public bool SellerAuthenticated()
        {
            //authenticate so long as the token <> "Invalid", NULL or ""
            if (Context.SellerAuthToken == "Invalid" || String.IsNullOrEmpty(Context.SellerAuthToken))
            {
                return false;
            }
            return true;
        }
    }
}
