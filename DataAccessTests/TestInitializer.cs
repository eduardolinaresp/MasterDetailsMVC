using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;

namespace DataAccessTests
{
    [TestClass]
    public class TestInitializer
    {
        private static DataAccessFactory daFactory;

        public static DataAccessFactory DaFactory {
            get
            {
                return daFactory;
            }
        }

        //[TestInitialize]
        public static void Initialize(TestContext testContext)
        {
            string connString = "Server=LocalServer;Database=NadeemInvoiceDemo; Trusted_Connection=True";
            daFactory = new DataAccessFactory(connString);
        }
    }
}
