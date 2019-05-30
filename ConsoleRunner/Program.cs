using System;
using Customers;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please, specify the URL to download the input file.");
                return;
            }
            new FileProcessor().Run(args[0], "output.json", 100, 53.339428, -6.257664);
        }
    }
}
