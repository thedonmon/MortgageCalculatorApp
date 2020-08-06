using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageCalculator.Shared
{
    public class Utility
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cost")]
        public double Cost { get; set; }
    }
}
