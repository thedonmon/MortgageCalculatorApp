using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageCalculator.Shared
{
    public class MortgageResult
    {
        [JsonProperty("mortgage")]
        public double Mortgage { get; set; }
        [JsonProperty("property_taxes")]
        public double PropertyTaxes { get; set; }

        public double HomeInsurance { get; set; }
        public double UtilitiesCost { get; set; }
        public double AssociationDues { get; set; }
        public double Total => Mortgage + PropertyTaxes + HomeInsurance + UtilitiesCost + AssociationDues;
    }
}
