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
        private static string[] currencies = {
            "CAD",
            "HKD",
            "ISK",
            "PHP",
            "DKK",
            "HUF",
            "CZK",
            "GBP",
            "RON",
            "SEK",
            "IDR",
            "INR",
            "BRL",
            "RUB",
            "HRK",
            "JPY",
            "THB",
            "CHF",
            "EUR",
            "MYR",
            "BGN",
            "TRY",
            "CNY",
            "NOK",
            "NZD",
            "ZAR",
            "USD",
            "MXN",
            "SGD",
            "AUD",
            "ILS",
            "KRW",
            "PLN"
            };

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

        public static IEnumerable<MediatedSchema> GetAllFromWeb(IProgress<string> progress)
        {
            WebClient webClient = new WebClient();

            int counter = 0;
            foreach (var curr in currencies)
            {
                counter++;
                string apiv4 = webClient.DownloadString("https://api.exchangerate-api.com/v4/latest/" + curr);
                string api = webClient.DownloadString("https://api.exchangeratesapi.io/latest?base=" + curr);
                progress.Report(counter + "/" + currencies.Length + " extracted");

                yield return Deserializer.DeserializeToMediatedSchema(api, apiv4);
            }
        }
    }
}
