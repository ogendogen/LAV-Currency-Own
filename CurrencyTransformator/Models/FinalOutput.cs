using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTransformator.Models
{
    public class FinalOutput
    {
        public string Currency { get; set; }
        public string Date { get; set; }
        public RatesFinal TargetCurrencies { get; set; }
    }
}
