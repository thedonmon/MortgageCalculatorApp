using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageCalculator.Shared
{
    public class Mortgage
    {
        [JsonProperty("interest_rate")]
        public double InterestRate { get; set; }
        
        [JsonProperty("loan_amortization_term_mo")]
        public int LoanAmortizationTerm { get; set; }

    }
}
