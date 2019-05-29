using Newtonsoft.Json;

namespace Customers.Entity
{
    public class Location
    {
        [JsonProperty("latitude", Required = Required.Always)]
        public double Latitude { get; private set; }

        [JsonProperty("longitude", Required = Required.Always)]
        public double Longitude { get; private set; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}