using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExtractor.Models
{
    public class API
    {
        public Rates rates { get; set; }
        public string @base { get; set; }
        public string date { get; set; }
    }
}
