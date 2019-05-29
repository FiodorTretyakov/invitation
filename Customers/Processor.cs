using System.Collections.Generic;
using Newtonsoft.Json;
using Customers.Entity;

namespace Customers
{
    public class Processor
    {
        public static ICollection<Customer> Deserialize(string data) => JsonConvert.DeserializeObject<ICollection<Customer>>(data);

        public static bool IsCloseTo(Location to, Location from)
        {
            return true;
        }
    }
}