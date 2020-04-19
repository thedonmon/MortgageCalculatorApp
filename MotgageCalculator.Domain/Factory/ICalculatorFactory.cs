using MortgageCalculator.Shared;
using MortgageCalculator.Shared.MortgageCalculations;
using MotgageCalculator.Domain.Calculators.Implementation;
using MotgageCalculator.Domain.Calculators.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotgageCalculator.Domain.Factory
{
    public interface ICalculatorFactory
    {
        ICalculator GetCalculator(ICalculatorRequest request);
    }
    public class CalcualtorFactory : ICalculatorFactory
    {
        public ICalculator GetCalculator(ICalculatorRequest request)
        {
            if (request.GetType() == typeof(MortgageCalculationRequest))
                return new MortgagePropertyCalculator();
            else
                throw new NotImplementedException("This request type doesnt support calculations at the moment");
        }
    }
}
