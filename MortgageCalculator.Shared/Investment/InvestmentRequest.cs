using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageCalculator.Shared.Investment
{
    public class InvestmentRequest : ICalculatorRequest
    {
        public Guid RequestId => Guid.NewGuid();
    }
}
