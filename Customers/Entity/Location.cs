using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Customers.Entity
{
    public class Location
    {
        [IgnoreDataMemberAttribute]
        [JsonProperty("latitude", Required = Required.Always)]
        public double Latitude { get; private set; }

        [IgnoreDataMemberAttribute]
        [JsonProperty("longitude", Required = Required.Always)]
        public double Longitude { get; private set; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}