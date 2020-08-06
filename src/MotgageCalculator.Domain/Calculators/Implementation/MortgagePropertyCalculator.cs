using MortgageCalculator.Shared;
using MortgageCalculator.Shared.MortgageCalculations;
using MotgageCalculator.Domain.Calculators.Interface;
using MotgageCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotgageCalculator.Domain.Calculators.Implementation
{
    public class MortgagePropertyCalculator : ICalculator
    {
        public async Task<IResult> CalculateAsync(ICalculatorRequest request)
        {
            var mortgageRequest = (MortgageCalculationRequest)request;
            if (mortgageRequest != null)
            {
                var mortgageResult = new MortgageResult();
                var mortgageModel = CalculateMortgageModel(mortgageRequest.Mortgage, mortgageRequest.Purchase);
                
                mortgageResult.Mortgage = mortgageModel.Interest + mortgageModel.Principle + mortgageModel.PMI;
                
                var yearlyPropertyTax = mortgageRequest.Purchase.PurchasePrice * 0.0223;
                
                mortgageResult.PropertyTaxes = yearlyPropertyTax / 12;
                mortgageResult.HomeInsurance = mortgageRequest.Extras.HomeInsuranceAnnual / 12;
                mortgageResult.UtilitiesCost = mortgageRequest.Extras.Utilities.Sum(x => x.Cost);
                mortgageResult.AssociationDues = mortgageRequest.Extras.HOADues;

                return new Result<MortgageResult>
                {
                    data = mortgageResult
                };
            }
            return new Result<MortgageResult>();

        }
        private MortgageCalculationModel CalculateMortgageModel(Mortgage m, Purchase p)
        {
            var model = new MortgageCalculationModel();
            var rate = (double)m.InterestRate / 100 / 12;

            var principal = -FinancialFunctions.PPMT(rate, 1, m.LoanAmortizationTerm, p.LoanAmount, 0, 0);

            var interestPayment = -FinancialFunctions.IPMT(rate, 1, m.LoanAmortizationTerm, p.LoanAmount, 0, 0);


            model.Interest = interestPayment;
            model.Principle = principal;
            if (p.DownPaymentPercentage < 20)
            {
                model.PMI = (p.LoanAmount * ((0.4) / 100)) / 12;

                return model;
            }

            return model;
        }
    }
}
