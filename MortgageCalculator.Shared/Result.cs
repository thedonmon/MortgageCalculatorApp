using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageCalculator.Shared
{
    public class Result<T> : IResult 
    {
        public Guid ResultId => Guid.NewGuid();
        public T data { get; set; }
        public string message { get; set; }
    }
}
