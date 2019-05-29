using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Customers.Entity;

namespace Customers
{
    public class Processor
    {
        public static ICollection<Customer> Deserialize(string data) => JsonConvert.DeserializeObject<ICollection<Customer>>(data);

        public static IReadOnlyDictionary<int, string> GetClosestCustomers(ICollection<Customer> customers, Location location, int distance) =>
            customers.Where(c => Locator.IsCloseTo(location, c.UserLocation, distance)).OrderBy(c => c.UserId)
                .ToDictionary(c => c.UserId, c => c.Name);
    }
}