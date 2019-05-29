using System;
using Newtonsoft.Json;

namespace Customers
{
    public class Customer
    {
        [JsonProperty("latitude", Required = Required.Always)]
        public double Latitude { get; private set; }
        
        [JsonProperty("used_id", Required = Required.Always)]
        public int UserId  { get; private set; }

        [JsonProperty("name", Required = Required.Always)]
        public string name  { get; private set; }

        [JsonProperty("longitude", Required = Required.Always)]
        public double Longitude { get; private set; }
    }
}