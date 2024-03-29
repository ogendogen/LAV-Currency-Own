﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyExtractor;
using CurrencyExtractor.Models;
using CurrencyTransformator;
using CurrencyTransformator.Models;

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
                Console.WriteLine("Starting integration...");
                MediatedSchema mediated = Extractor.GetOutputFromWeb("EUR");
                Console.WriteLine("Mediated schema object deserialized");

                Console.WriteLine("Extraction successful");
                Console.WriteLine("Starting transformation...");

                bool differentCurrency, differentDate;
                Validator.ValidateMediatedSchemaObject(mediated, out differentCurrency, out differentDate);
                if (differentCurrency)
                {
                    Console.WriteLine("Curriencies are different. Validation failed. Stopping.");
                    Console.ReadKey();
                    return;
                }
                if (differentDate)
                {
                    Console.WriteLine("Dates are different. Validation failed. Stopping.");
                    Console.ReadKey();
                    return;
                }

                FinalOutput finalOutput = Transformator.TransformToOutput(mediated);
                string serialized = Serializer.SerializeFinalOutput(finalOutput);
                Console.WriteLine("Transformation completed");

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
