using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyExtractor.Models;

namespace CurrencyTransformator
{
    public static class Validator
    {
        public static void ValidateMediatedSchemaObject(MediatedSchema mediatedSchemaObject, out bool differentCurrency, out bool differentDate)
        {
            if (mediatedSchemaObject.API.@base != mediatedSchemaObject.APIV4.@base)
            {
                differentCurrency = true;
            }
            else
            {
                differentCurrency = false;
            }

            if (mediatedSchemaObject.API.date != mediatedSchemaObject.APIV4.date)
            {
                DateTime APIDT = DateTime.Parse(mediatedSchemaObject.API.date);
                DateTime APIV4DT = DateTime.Parse(mediatedSchemaObject.APIV4.date);

                if (APIDT.AddDays(1.0) == APIV4DT)
                {
                    differentDate = false;
                }
                else
                {
                    differentDate = true;
                }
            }
            else
            {
                differentDate = false;
            }
        }
    }
}
