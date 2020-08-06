using System;
using System.Collections.Generic;
using System.Text;

namespace MotgageCalculator.Domain.Models
{
    public class MortgageCalculationModel
    {
        public double Principle { get; set; }
        public double Interest { get; set; }
        public double PMI { get; set; }
    }
}
