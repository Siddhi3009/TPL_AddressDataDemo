namespace ThirdPartyLibraryDemo
{
    using CsvHelper;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Text;
    class JSonCSVManipulation
    {
        /// <summary>
        /// Read from one CSV File and Write to other JSON File
        /// </summary>
        public static void ImplementCSVToJSON()
        {
            string exportFilePath = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\34. ThirdPartyLibraryDemo\TPL_AddressDataDemo\ThirdPartyLibraryDemo\Utility\AddressDetails.json";
            string importFilePath = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\34. ThirdPartyLibraryDemo\TPL_AddressDataDemo\ThirdPartyLibraryDemo\Utility\Address.csv";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Data Reading done successfully from Address.csv file");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.FirstName);
                    Console.Write("\t" + addressData.LastName);
                    Console.Write("\t" + addressData.Address);
                    Console.Write("\t" + addressData.City);
                    Console.Write("\t" + addressData.State);
                    Console.Write("\t" + addressData.Code);
                    Console.Write("\n");
                }
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, records);
                }
            }
        }
        /// <summary>
        /// Read From JSON File and Write to CSV File
        /// </summary>
        public static void ReadJSONWriteCSV()
        {
            string importFilePath = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\34. ThirdPartyLibraryDemo\TPL_AddressDataDemo\ThirdPartyLibraryDemo\Utility\AddressDetails.json";
            string exportFilePath = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\34. ThirdPartyLibraryDemo\TPL_AddressDataDemo\ThirdPartyLibraryDemo\Utility\AddressDetails.csv";
            IList<AddressData> addressData = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFilePath));
            Console.WriteLine("Reading From JSON to CSV");
            using (var writer = new StreamWriter(exportFilePath))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords(addressData);
            }
        }
    }
}
