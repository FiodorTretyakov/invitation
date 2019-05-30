using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Customers;
using Customers.Entity;
using System.Threading.Tasks;

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
            "[{\"user_id\":2,\"name\":\"Victoria\"},{\"user_id\":1,\"name\":\"Caroline\"},{\"user_id\":3,\"name\":\"Christine\"},{\"user_id\":5,\"name\":\"Theodore\"}]";

        public static async Task<string> GetRawData() => await File.ReadAllTextAsync("customers.txt").ConfigureAwait(false);

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
        public async Task DeserializeTest()
        {
            var customers = FileProcessor.Deserialize(await GetRawData().ConfigureAwait(false));

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

        [TestMethod]
        public async Task GetDataTest()
        {
            var data = new FileProcessor().GetData("https://raw.githubusercontent.com/FiodorTretyakov/invitation/master/Test/customers.txt");

            Assert.IsNotNull(data);
            Assert.AreEqual(await GetRawData().ConfigureAwait(false), data);
        }

        [TestMethod]
        public async Task SaveDataTest()
        {
            var outputPath = "output.json";

            try
            {
                var rawData = await GetRawData().ConfigureAwait(false);
                new FileProcessor().SaveData(rawData, outputPath);

                Assert.IsTrue(File.Exists(outputPath));
                var data = await File.ReadAllTextAsync(outputPath).ConfigureAwait(false);

                Assert.IsNotNull(data);
                Assert.AreEqual(rawData, data);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                File.Delete(outputPath);
            }
        }
    }
}