using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageCalculator.Shared.MortgageCalculations
{
    public class MortgageCalculationRequest : ICalculatorRequest
    {
        public Purchase Purchase { get; set; }
        public Mortgage Mortgage { get; set; }
        public Extras Extras { get; set; }
        public Guid RequestId => Guid.NewGuid();
    }
}
