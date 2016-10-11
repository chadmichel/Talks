using DPLRef.eCommerce.Accessors.Notifications;
using DPLRef.eCommerce.Engines.Notification;

namespace DPLRef.eCommerce.Managers.Notification
{
    class NotificationManager : ManagerBase, INotificationManager
    {
        #region IServiceContractBase
        public override string TestMe(string input)
        {
            input = base.TestMe(input);
            input = EngineFactory.CreateEngine<IEmailFormattingEngine>().TestMe(input);
            input = AccessorFactory.CreateAccessor<IEmailAccessor>().TestMe(input);

            return input;
        }
        #endregion
    }
}
