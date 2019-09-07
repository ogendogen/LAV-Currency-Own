using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using CurrencyExtractor.Models;
using Newtonsoft.Json;

namespace CurrencyExtractor
{
    public static class Extractor
    {
        public static MediatedSchema GetOutputFromFile(string apiLayerPath, string exChangeRatesPath)
        {
            string rawApiLayer = File.ReadAllText(apiLayerPath);
            string rawExChangeRates = File.ReadAllText(exChangeRatesPath);

            return Deserializer.DeserializeToMediatedSchema(rawApiLayer, rawExChangeRates);
        }

        public static MediatedSchema GetOutputFromWeb(string currency="EUR")
        {
            WebClient webClient = new WebClient();

            string apiv4 = webClient.DownloadString("https://api.exchangerate-api.com/v4/latest/" + currency);
            string api = webClient.DownloadString("https://api.exchangeratesapi.io/latest?base=" + currency);

            return Deserializer.DeserializeToMediatedSchema(api, apiv4);
        }
    }
}
