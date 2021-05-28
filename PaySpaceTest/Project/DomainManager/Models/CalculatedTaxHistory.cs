using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DomainManager.Models
{
    public class CalculatedTaxHistory
    {
        //public Guid uId { get; set; }
        public int id { get; set; }
        public string postalCode { get; set; }
        public decimal annualIncome { get; set; }
        public decimal calculatedTax { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateCalculated { get; set; }
    }
}
