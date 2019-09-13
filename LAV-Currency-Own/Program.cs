using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyExtractor;
using CurrencyExtractor.Models;
using CurrencyTransformator;
using CurrencyTransformator.Models;
using System.IO;

namespace GAV_Currency_Own
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start extracting process...");
            Console.ReadKey();

            try
            {
                Console.WriteLine("Starting extraction...");
                CurrencyExtractor.Models.MediatedSchema mediatedSchema = Extractor.GetOutputFromWeb("EUR");
                Console.WriteLine("Mediated schema object deserialized");

                Console.WriteLine("Extraction successful");
                string serialized = Serializer.SerializeMediatedSchema(mediatedSchema);
                File.WriteAllText("lav-output.json", serialized);

                Console.WriteLine("Output serialized");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured. Logging details...");
                Logger.LogException("ErrorLogs.log", e);
                Console.WriteLine("Logging finished. Press any key to stop application");
                Console.ReadKey();
            }
        }
    }
}
