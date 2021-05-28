using ProgressiveTaxCalculator.DB;
using ProgressiveTaxCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.BusinessLogic.Interfaces
{
    public interface ITaxCalculator
    {
        public decimal Calculate(decimal rate, decimal income);
        public bool SaveTaxRecord(TaxModel data, decimal tax);
        public decimal SaveTaxData(TaxModel data);

    }
}
