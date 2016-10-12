using DPLRef.eCommerce.Accessors;
using DPLRef.eCommerce.Common.Shared;
using DPLRef.eCommerce.Engines;
using System;
using DPLRef.eCommerce.Common.Utilities;
using DPLRef.eCommerce.Contracts.Admin.Catalog;
using DPLRef.eCommerce.Contracts.Admin.Sales;
using DPLRef.eCommerce.Contracts.BackOfficeAdmin.Remittance;
using DPLRef.eCommerce.Contracts.WebStore.Catalog;
using DPLRef.eCommerce.Contracts.WebStore.Sales;
using DPLRef.eCommerce.Managers.Notification;
using DPLRef.eCommerce.Managers.Remittance;
using DPLRef.eCommerce.Managers.Sales;

namespace DPLRef.eCommerce.Managers
{
    public class ManagerFactory : FactoryBase
    {
        public ManagerFactory(AmbientContext context) : base(context)
        {
        }

        public T CreateManager<T>() where T : class
        {
            T result = CreateManager<T>(null, null, null);
            return result;
        }

        public T CreateManager<T>(
            EngineFactory engineFactory, AccessorFactory accessorFactory, UtilityFactory utilityFactory) where T : class
        {
            if (Context == null)
            {
                throw new InvalidOperationException("Context cannot be null");
            }

            if (engineFactory == null)
            {
                engineFactory = new EngineFactory(Context);
            }

            if (accessorFactory == null)
            {
                accessorFactory = new AccessorFactory(Context);
            }

            if (utilityFactory == null)
            {
                utilityFactory = new UtilityFactory(Context);
            }

            T result = GetManager<T>();

            if (result is ManagerBase)
                (result as ManagerBase).Context = Context;
            else
                throw new InvalidOperationException("All managers must inherit from ManagerBase");

            (result as ManagerBase).EngineFactory = engineFactory;

            (result as ManagerBase).AccessorFactory = accessorFactory;

            (result as ManagerBase).UtilityFactory = utilityFactory;

            return result;
        }

        private T GetManager<T>() where T : class
        {
            T result = null;

            result = base.CheckOverrides<T>();
            if (result != null)
                return result;

            if ((typeof(T) == typeof(ICartManager)) ||
                (typeof(T) == typeof(IOrderManager)) ||
                (typeof(T) == typeof(IReturnsManager)))
                result = new OrderManager() as T;

            if ((typeof(T) == typeof(IWebStoreCatalogManager)) ||
                (typeof(T) == typeof(IAdminCatalogManager)))
                result = new Catalog.CatalogManager() as T;

            if (typeof(T) == typeof(INotificationManager))
                result = new NotificationManager() as T;

            if (typeof(T) == typeof(IRemittanceManager))
                result = new RemittanceManager() as T;

            if (result == null)
                throw new ArgumentException($"{typeof(T).Name} is not supported by this factory");

            if (result is ManagerBase)
            {
                return result;
            }
            throw new InvalidOperationException($"{typeof(T).Name} does not implement ManagerBase");
        }
    }
}
