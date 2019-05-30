using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Customers.Entity
{
    public class Customer : Location
    {
        public Customer(int userId, string name, double latitude, double longitude) : base(latitude, longitude)
        {
            UserId = userId;
            Name = name;
        }

        [JsonProperty("user_id", Required = Required.Always)]
        public int UserId { get; private set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; private set; }

        [IgnoreDataMemberAttribute]
        public Location UserLocation => new Location(Latitude, Longitude);
    }
}