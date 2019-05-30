using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Customers.Entity;

namespace Customers
{
    public abstract class Processor
    {
        public static ICollection<Customer> Deserialize(string data) => JsonConvert.DeserializeObject<ICollection<Customer>>(data);

        //distance in km
        public static IList<Customer> GetClosestCustomers(ICollection<Customer> customers, Location location, int distance) =>
            customers.Where(c => Locator.IsCloseTo(location, c.UserLocation, distance)).OrderBy(c => c.UserId).ToArray();

        public static string Serialize(ICollection<Customer> customers) =>
            JsonConvert.SerializeObject(customers);

        protected abstract string GetData(string inputLocation);

        protected abstract void SaveData(string data, string outputLocation);

        //distance in km
        public void Run(string inputLocation, string outputLocation, int distance, double latitude, double longitude) =>
            SaveData(Serialize(GetClosestCustomers(Deserialize(GetData(inputLocation)), new Location(latitude, longitude),
            distance)), outputLocation);
    }
}