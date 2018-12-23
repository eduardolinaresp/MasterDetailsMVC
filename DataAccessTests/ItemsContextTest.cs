using System;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModels.Stocks;

namespace DataAccessTests
{
    [TestClass]
    public class ItemsContextTest
    {
        private static IItemsRepo itemsContext;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            string connString = "Data Source=.;Initial Catalog=NadeemInvoiceDemo;Integrated Security=True;";
            var daFactory = new DataAccessFactory(connString);
            itemsContext = daFactory.GetItemsRepo();
            //itemsContext = TestInitializer.DaFactory.GetItemsContext();
        }

        [TestMethod]
        public void TestGet()
        {
            var items = itemsContext.Get().Result;
            Assert.IsNotNull(items);
            //Assert.IsTrue(items.Count > 0);
        }

        [TestMethod]
        public void TestAdd()
        {
            var randomName = $"TEST_ITEM_{DateTime.Now.ToString("YYYYMMDDHHmmss")}";
            var item = new Item
            {
                Name = randomName,
                Price = 10.20M,
                Description = "Test Item",
                Unit = "Kg"
            };

            var result = itemsContext.Add(item).Result;
            Assert.IsTrue(result > 0);

        }
    }
}
