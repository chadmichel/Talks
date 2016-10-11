using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DPLRef.eCommerce.Tests.AccessorTests
{
    [TestClass]
    public abstract class DbTestAccessorBase 
    {
        TransactionScope transaction;

        [TestInitialize()]
        public void Init()
        {
            transaction = new TransactionScope();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            transaction.Dispose();
        }
    }
}
