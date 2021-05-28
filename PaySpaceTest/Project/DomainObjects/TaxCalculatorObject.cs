using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DomainObjects
{
    [Serializable]
    [DataContract]
    public class TaxCalculatorObject
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public decimal calculatedTax { get; set; }
        [DataMember]
        public DateTime dateCalculated { get; set; }
        [DataMember]
        public decimal annualIncome { get; set; }
        [DataMember]
        public string postalCode { get; set; }
    }
}
