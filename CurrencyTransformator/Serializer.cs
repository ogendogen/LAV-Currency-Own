using CurrencyTransformator.Models;
using CurrencyExtractor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyTransformator
{
    public static class Serializer
    {
        public static string SerializeFinalOutput(FinalOutput finalOutput)
        {
            return JsonConvert.SerializeObject(finalOutput, Formatting.Indented);
        }

        public static string SerializeMediatedSchema(CurrencyExtractor.Models.MediatedSchema mediatedSchema)
        {
            return JsonConvert.SerializeObject(mediatedSchema, Formatting.Indented);
        }
    }
}
