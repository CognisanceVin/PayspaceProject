using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.BusinessLogic.Enumerables
{
    public class Enumerations
    {
        public enum ePostalCode
        {
            [Description("Residetial")]
            Residetial = 7441,
            [Description("Work")]
            Work = 2,
            [Description("Postal")]
            Postal = 3,
        }
    }
}
