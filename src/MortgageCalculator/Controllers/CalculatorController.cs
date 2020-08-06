using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MortgageCalculator.Shared;
using MortgageCalculator.Shared.Investment;
using MortgageCalculator.Shared.MortgageCalculations;
using MotgageCalculator.Domain.Factory;

namespace MortgageCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorFactory _calcFactory;
        public CalculatorController(ICalculatorFactory calculatorFactory)
        {
            _calcFactory = calculatorFactory;
        }

        [HttpPost]
        [Route("calculateMortgage")]
        public async Task<IActionResult> CalcMortgageAsync([FromBody]MortgageCalculationRequest request)
        {
            try
            {
                ValidateRequest(request);
                var calc = _calcFactory.GetCalculator(request);
                var result = await calc.CalculateAsync(request);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [Route("calculateInvestment")]
        public async Task<IActionResult> CalcInvestmentAsync([FromBody]InvestmentRequest request)
        {
            try
            {
                ValidateRequest(request);
                var calc = _calcFactory.GetCalculator(request);
                var result = await calc.CalculateAsync(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private void ValidateRequest(ICalculatorRequest request)
        {
            if(request == null)
            {
                throw new ArgumentException("Request must be initialized");
            }
        }
    }
}