using System.Collections.Generic;

namespace DPLRef.eCommerce.Common.Shared
{
    public abstract class FactoryBase
    {
        public AmbientContext Context { get; private set; }

        public FactoryBase(AmbientContext context)
        {
            Context = context;
        }

        readonly Dictionary<string, object> _overrides = new Dictionary<string, object>();

        public void AddOverride<T>(T obj)
        {
            _overrides.Add(typeof(T).Name, obj);
        }

        public T CheckOverrides<T>() where T : class
        {
            // overrides dictionary enables mocking in unit tests
            if (_overrides.ContainsKey(typeof(T).Name))
                return _overrides[typeof(T).Name] as T;

            return null;
        }
    }
}
