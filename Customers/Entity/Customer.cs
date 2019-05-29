using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Customers.Entity
{
    [Serializable]
    public class Customer : Location
    {
        public Customer(double latitude, double longitude) : base(latitude, longitude)
        {
        }

        [JsonProperty("used_id", Required = Required.Always)]
        public int UserId { get; private set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; private set; }

        [IgnoreDataMemberAttribute]
        public Location UserLocation => new Location(Latitude, Longitude);
    }
}