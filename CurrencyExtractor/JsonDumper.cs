using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CurrencyExtractor.Models;
using Newtonsoft.Json;

namespace CurrencyExtractor
{
    public static class JsonDumper
    {
        public static void DumpJsonToFile(string path, MediatedSchema finalJson)
        {
            try
            {
                string serialized = JsonConvert.SerializeObject(finalJson, Formatting.Indented);
                File.WriteAllText(path, serialized);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error during serialization. Message: " + e.Message);
            }
        }
    }
}
