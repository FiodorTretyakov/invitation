using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;

namespace Customers
{
    public class FileProcessor : Processor
    {
        protected override string GetData(string inputLocation)
        {
            using (var client = new HttpClient())
            {
                return client.GetStringAsync(inputLocation).Result;
            };
        }

        protected override void SaveData(string data, string outputLocation)
        {
            File.WriteAllText(outputLocation, data);
        }
    }
}