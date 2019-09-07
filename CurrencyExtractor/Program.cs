using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyExtractor.Models;

namespace CurrencyExtractor
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
                MediatedSchema finalOutput = Extractor.GetOutputFromFile("live.json", "latest.json");
                Console.WriteLine("FinalOutput object deserialized");

                Console.WriteLine("Writing to file");
                JsonDumper.DumpJsonToFile("final.json", finalOutput);

                Console.WriteLine("Extraction successful");
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
