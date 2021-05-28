using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainManager.Interfaces
{
     interface IRates
    {
        decimal getProgressiveRates(decimal income);
        decimal getFlatRate();
        decimal getFlatValue(decimal income);
        decimal getRates(string rate, decimal income);
    }
}
