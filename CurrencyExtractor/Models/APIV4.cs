using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExtractor.Models
{
    public class APIV4
    {
        public string @base { get; set; }
        public string date { get; set; }
        public int time_last_updated { get; set; }
        public RatesV4 rates { get; set; }
    }
}
