using DPLRef.eCommerce.Accessors.Remittance;
using DPLRef.eCommerce.Contracts.BackOfficeAdmin.Remittance;

namespace DPLRef.eCommerce.Managers.Remittance
{
    class RemittanceManager : ManagerBase, IRemittanceManager
    {
        #region IServiceContractBase
        public override string TestMe(string input)
        {
            input = base.TestMe(input);
            input = AccessorFactory.CreateAccessor<IRemittanceAccessor>().TestMe(input);

            return input;
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
