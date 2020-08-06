using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortgageCalculator.Shared
{
    public class Purchase
    {
        [JsonProperty("purchase_price")]
        public double PurchasePrice { get; set; }
        [JsonProperty("down_payment_percentage")]
        public double DownPaymentPercentage { get; set; }

        public double DownPayment => PurchasePrice * (DownPaymentPercentage/100);
        public double LoanAmount => PurchasePrice - DownPayment;

    }
}
