using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Customers;
using Customers.Entity;

namespace Test
{
    [TestClass]
    public class ProcessorTest
    {
        public static IList<Customer> TestCustomers => new List<Customer>
            {
                {new Customer(2, "Victoria", 53.6110885, -6.1883887)},
                {new Customer(1, "Caroline", 53.3353929, -6.2489314)},
                {new Customer(3, "Christine", 51.9138467,-8.4811045)},
                {new Customer(5, "Theodore", 53.1427392,-9.7774248)},
            };

        public const string SerializedData =
            "[{\"used_id\":2,\"name\":\"Victoria\"},{\"used_id\":1,\"name\":\"Caroline\"},{\"used_id\":3,\"name\":\"Christine\"},{\"used_id\":5,\"name\":\"Theodore\"}]";

        public const string RawData =
            "[{\"used_id\":2,\"name\":\"Victoria\",\"latitude\":53.6110885,\"longitude\":-6.1883887},{\"used_id\":1,\"name\":\"Caroline\",\"latitude\":53.3353929,\"longitude\":-6.2489314},{\"used_id\":3,\"name\":\"Christine\",\"latitude\":51.9138467,\"longitude\":-8.4811045},{\"used_id\":5,\"name\":\"Theodore\",\"latitude\":53.1427392,\"longitude\":-9.7774248}]";

        [TestMethod]
        public void GetClosestCustomersTest()
        {
            var customers = TestCustomers;
            var closeCustomers = FileProcessor.GetClosestCustomers(customers, new Location(53.2779097, -6.1145984), 100);

            Assert.AreEqual(2, closeCustomers.Count);
            Assert.AreEqual(customers[1].Name, closeCustomers[0].Name);
            Assert.AreEqual(customers[0].Name, closeCustomers[1].Name);
            Assert.AreEqual(customers[1].UserId, closeCustomers[0].UserId);
            Assert.AreEqual(customers[0].UserId, closeCustomers[1].UserId);
        }

        [TestMethod]
        public void SerializeTest()
        {
            var data = FileProcessor.Serialize(TestCustomers);

            Assert.IsNotNull(data);
            Assert.AreEqual(SerializedData, data);
        }

        [TestMethod]
        public void DeserializeTest()
        {
            var customers = FileProcessor.Deserialize(RawData);

            Assert.IsNotNull(customers);
            Assert.AreEqual(TestCustomers.Count, customers.Count);

            for (var i = 0; i < customers.Count; i++)
            {
                Assert.AreEqual(TestCustomers[i].Latitude, customers[i].Latitude);
                Assert.AreEqual(TestCustomers[i].Longitude, customers[i].Longitude);
                Assert.AreEqual(TestCustomers[i].UserId, customers[i].UserId);
                Assert.AreEqual(TestCustomers[i].Name, customers[i].Name);
            }
        }
    }
}