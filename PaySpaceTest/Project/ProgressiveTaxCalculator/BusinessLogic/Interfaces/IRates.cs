using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.BusinessLogic.Interfaces
{
    public interface IRates
    {
        public decimal getProgressiveRates(decimal income);
        public decimal getFlatRate();
        public decimal getFlatValue(decimal income);
        public decimal getRates(string rate, decimal income);
    }
}
