using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;

namespace Customers
{
    public class FileProcessor : Processor
    {
        public override string GetData(string inputLocation)
        {
            using (var client = new HttpClient())
            {
                return client.GetStringAsync(inputLocation).Result;
            };
        }

        public override void SaveData(string data, string outputLocation) =>
            File.WriteAllText(outputLocation, data);
    }
}