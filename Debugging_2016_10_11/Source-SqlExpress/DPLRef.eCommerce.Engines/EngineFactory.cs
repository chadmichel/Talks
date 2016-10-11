using System;
using DPLRef.eCommerce.Common.Shared;
using DPLRef.eCommerce.Accessors;
using DPLRef.eCommerce.Engines.Notification;
using DPLRef.eCommerce.Engines.Sales;

namespace DPLRef.eCommerce.Engines
{
    public class EngineFactory : FactoryBase
    {
        public EngineFactory(AmbientContext context) 
            : base(context)
        {
          
        }

        public T CreateEngine<T>() where T : class
        {
            return CreateEngine<T>(null);
        }

        public T CreateEngine<T>(AccessorFactory accessorFactory) where T : class
        {
            T result = null;

            result = base.CheckOverrides<T>();
            if (result == null)
            {
                if (typeof(T) == typeof(ICouponValidationEngine))
                    result = new CouponValidationEngine() as T;

                if (typeof(T) == typeof(IEmailFormattingEngine))
                    result = new EmailFormattingEngine() as T;

                if (typeof(T) == typeof(ITaxCalculationEngine))
                    result = new TaxCalculationEngine() as T;

                if (typeof(T) == typeof(IVolumeDiscountCalculationEngine))
                    result = new VolumeDiscountCalculationEngine() as T;
            }

            if (accessorFactory == null)
            {
                accessorFactory = new AccessorFactory(Context);
            }

            if (result is EngineBase)
            {
                (result as EngineBase).Context = Context;
                (result as EngineBase).AccessorFactory = accessorFactory;
            }

            return result;
        }
    }
}
