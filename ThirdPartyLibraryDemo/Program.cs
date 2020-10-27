using System;

namespace ThirdPartyLibraryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CSVHandler.ImplementCSVDataHandling();
            JSonCSVManipulation.ImplementCSVToJSON();
            JSonCSVManipulation.ReadJSONWriteCSV();
        }
    }
}
