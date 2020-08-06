using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageCalculator.Shared.MortgageCalculations
{
    public class MortgageCalculationRequest : ICalculatorRequest
    {
        [JsonProperty("purchase")]
        public Purchase Purchase { get; set; }
        [JsonProperty("mortgage")]
        public Mortgage Mortgage { get; set; }
        [JsonProperty("extras")]
        public Extras Extras { get; set; }
        [JsonProperty("requestId")]
        public Guid RequestId => Guid.NewGuid();
    }
}
