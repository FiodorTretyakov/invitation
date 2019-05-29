using System;
using Newtonsoft.Json;

namespace Customers.Entity
{
    public class Customer : Location
    {
        [JsonProperty("used_id", Required = Required.Always)]
        public int UserId { get; private set; }

        [JsonProperty("name", Required = Required.Always)]
        public string name { get; private set; }
    }
}