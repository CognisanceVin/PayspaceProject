
using DomainManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainManager.Interfaces
{
    public interface ITaxCalculator
    {
         decimal Calculate(decimal rate, decimal income);
         bool SaveTaxRecord(TaxModel data, decimal tax);
         decimal SaveTaxData(TaxModel data);

    }
}
