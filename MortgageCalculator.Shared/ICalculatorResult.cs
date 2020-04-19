using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageCalculator.Shared
{
    public interface ICalculatorResult
    {
        IResult Result { get; set; }
    }
}
