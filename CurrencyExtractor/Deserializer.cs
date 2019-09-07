using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyExtractor.Models;
using Newtonsoft.Json;

namespace CurrencyExtractor
{
    public static class Deserializer
    {
        public static MediatedSchema DeserializeToMediatedSchema(string rawApiJson, string rawAPIV4Json)
        {
            MediatedSchema finalOutput = new MediatedSchema();
            finalOutput.API = JsonConvert.DeserializeObject<API>(rawApiJson);
            finalOutput.APIV4 = JsonConvert.DeserializeObject<APIV4>(rawAPIV4Json);

            return finalOutput;
        }
    }
}
