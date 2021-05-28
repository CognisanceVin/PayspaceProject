using ProgressiveTaxCalculator.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.BusinessLogic.DomainManager
{
    public class RatesManager : IRates
    {
        /// <summary>
        /// Gets the progressive Rate given the income
        /// </summary>summary>
        /// <param name="income"></param>
        /// <returns>progress rate</returns>
        public decimal getProgressiveRates(decimal income)
        {
            if (income > 0 && income <= 8350)
                return 0.1m;
            else if (income > 8350 && income <= 33950)
                return 0.15m;
            else if (income > 33950 && income <= 82250)
                return 0.25m;
            else if (income > 82250 && income <= 171550)
                return 0.28m;
            else if (income > 171550 && income <= 372950)
                return 0.33m;
            else
                return 0.35m;
        }


        /// <summary>
        /// Determines what kind of tax rate to look for
        /// </summary>summary>
        /// <param name="income"></param><param name="code"></param>
        /// <returns>calculated rate</returns>
        public decimal getRates(string code, decimal income)
        {
            switch(code)
            {
                case "7441":
                    return getProgressiveRates(income);
                case "A100":
                    return getFlatValue(income);
                case "7000":
                    return getFlatRate();
                case "1000":
                    return getProgressiveRates(income);
            }
            return 0;
        }
        /// <summary>
        /// Gets the Flat Rate
        /// </summary>summary>
        /// <returns>flat rate of 0.175m</returns>
        public decimal getFlatRate()
        {
            return 0.175m;
        }
        /// <summary>
        /// Gets the Flat Valuegiven the income
        /// </summary>summary>
        /// <param name="income"></param>
        /// <returns>Flat Value</returns>
        public decimal getFlatValue(decimal income)
        {
            if (income >= 0)
            {
                if (income > 200000)
                    return 10000;
                else 
                    return 0.05m;
            }
            else
                throw new IndexOutOfRangeException("invalid amount for Flat Value tax.");            
        }
    }
}
