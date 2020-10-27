namespace ThirdPartyLibraryDemo
{
    using CsvHelper;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class CSVHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string exportFilePath = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\34. ThirdPartyLibraryDemo\TPL_AddressDataDemo\ThirdPartyLibraryDemo\Utility\export.csv";
            string importFilePath = @"C:\Users\Administrator\Desktop\BridgeLabz Practice\34. ThirdPartyLibraryDemo\TPL_AddressDataDemo\ThirdPartyLibraryDemo\Utility\Address.csv";
            //Reading From CSV File
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Data Reading done successfully from Address.csv file");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t"+addressData.FirstName);
                    Console.Write("\t" + addressData.LastName);
                    Console.Write("\t" + addressData.Address);
                    Console.Write("\t" + addressData.City);
                    Console.Write("\t" + addressData.State);
                    Console.Write("\t" + addressData.Code);
                    Console.Write("\n");
                }
                //Writing to CSV File
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
            
        }
    }
}
