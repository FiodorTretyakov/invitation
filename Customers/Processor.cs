using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Customers.Entity;

namespace Customers
{
    public abstract class Processor
    {
        public ICollection<Customer> Deserialize(string data) => JsonConvert.DeserializeObject<ICollection<Customer>>(data);

        public IReadOnlyDictionary<int, string> GetClosestCustomers(ICollection<Customer> customers, Location location, int distance) =>
            customers.Where(c => Locator.IsCloseTo(location, c.UserLocation, distance)).OrderBy(c => c.UserId)
                .ToDictionary(c => c.UserId, c => c.Name);

        protected abstract string GetData(string inputLocation);

        protected abstract void SaveData(IReadOnlyDictionary <int, string> customers, string outputLocation);

        public void Run(string inputLocation, string outputLocation, int distance, Location location) =>
            SaveData(GetClosestCustomers(Deserialize(GetData(inputLocation)), location, distance), outputLocation);
    }
}