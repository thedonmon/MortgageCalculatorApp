using MortgageCalculator.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotgageCalculator.Domain.Calculators.Interface
{
    public interface ICalculator
    {
        Task<IResult> CalculateAsync(ICalculatorRequest request);
    }
}
