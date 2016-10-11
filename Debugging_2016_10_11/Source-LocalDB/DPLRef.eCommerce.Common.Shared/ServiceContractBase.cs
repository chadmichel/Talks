using NLog;
using System;

namespace DPLRef.eCommerce.Common.Shared
{
    public class ServiceContractBase
    {
        // just to make sure all our manager, engines, and accessors have a TestMe method for smoke tests
        public virtual string TestMe(string input)
        {
            string result = string.Format("{0} : {1}", input, GetType().Name);
            Console.WriteLine(result);
            return result;
        }

        private static Logger _logger;
        protected static Logger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = LogManager.GetCurrentClassLogger();
                }

                return _logger;
            }
        }

        public AmbientContext Context
        {
            get; set;
        }
    }
}
