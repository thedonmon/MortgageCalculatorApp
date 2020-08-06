using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageCalculator.Shared
{
    public class Extras
    {
        [JsonProperty("property_taxes")]
        public double PropertyTaxes { get; set; }

        [JsonProperty("home_insurance")]
        public double HomeInsuranceAnnual { get; set; }

        [JsonProperty("utilities")]
        public List<Utility> Utilities { get; set; } = new List<Utility>();

        [JsonProperty("hoa_dues")]
        public double HOADues { get; set; }
    }
}
