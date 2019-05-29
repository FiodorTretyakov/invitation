using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Customers.Entity;

namespace Customers
{
    public abstract class Processor
    {
        public ICollection<Customer> Deserialize(string data) => JsonConvert.DeserializeObject<ICollection<Customer>>(data);

        public ICollection<Customer> GetClosestCustomers(ICollection<Customer> customers, Location location, int distance) =>
            customers.Where(c => Locator.IsCloseTo(location, c.UserLocation, distance)).OrderBy(c => c.UserId).ToArray();

        public string Serialize(ICollection<Customer> customers)
        {
            return JsonConvert.SerializeObject(customers);
        }

        protected abstract string GetData(string inputLocation);

        protected abstract void SaveData(string data, string outputLocation);

        public void Run(string inputLocation, string outputLocation, int distance, Location location) =>
            SaveData(Serialize(GetClosestCustomers(Deserialize(GetData(inputLocation)), location, distance)), outputLocation);
    }
}