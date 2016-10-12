using DPLRef.eCommerce.Accessors.Catalog;
using DPLRef.eCommerce.Common.Shared;
using System;
using DPLRef.eCommerce.Accessors.Notifications;
using DPLRef.eCommerce.Accessors.Remittance;
using DPLRef.eCommerce.Accessors.Sales;

namespace DPLRef.eCommerce.Accessors
{
    public class AccessorFactory : FactoryBase
    {
        public AccessorFactory(AmbientContext context) : base(context) { }

        public T CreateAccessor<T>() where T : class
        {
            T result = null;

            result = base.CheckOverrides<T>();
            if (result == null)
            {

                if (typeof(T) == typeof(ICartAccessor))
                    result = new CartAccessor() as T;

                if (typeof(T) == typeof(ICatalogAccessor))
                    result = new CatalogAccessor() as T;

                if (typeof(T) == typeof(ICouponRulesAccessor))
                    result = new CouponRulesAccessor() as T;

                if (typeof(T) == typeof(IEmailAccessor))
                    result = new EmailAccessor() as T;

                if (typeof(T) == typeof(IOrderAccessor))
                    result = new OrderAccessor() as T;

                if (typeof(T) == typeof(IPaymentAccessor))
                    result = new PaymentAccessor() as T;

                if (typeof(T) == typeof(IRemittanceAccessor))
                    result = new RemittanceAccessor() as T;

                if (typeof(T) == typeof(ISellerAccessor))
                    result = new SellerAccessor() as T;

                if (typeof(T) == typeof(IShippingAccessor))
                    result = new ShippingAccessor() as T;

                if (typeof(T) == typeof(IShippingRulesAccessor))
                    result = new ShippingRulesAccessor() as T;

                if (typeof(T) == typeof(ITaxRulesAccessor))
                    result = new TaxRulesAccessor() as T;

                if (typeof(T) == typeof(IVolumeDiscountRulesAccessor))
                    result = new VolumeDiscountRulesAccessor() as T;
            }
            if (result is AccessorBase)
                (result as AccessorBase).Context = Context;

            return result;
        }
    }
}
