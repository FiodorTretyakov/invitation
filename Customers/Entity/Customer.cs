using System;
using Newtonsoft.Json;

namespace Customers.Entity
{
    public class Customer : Location
    {
        public Customer(double latitude, double longitude) : base(latitude, longitude)
        {
        }

        [JsonProperty("used_id", Required = Required.Always)]
        public int UserId { get; private set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; private set; }

        public Location GetLocation()
        {
            return new Location(Latitude, Longitude);
        }
    }
}