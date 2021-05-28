using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainManager.Models
{
    public class TaxModel
    {

        [Required(ErrorMessage = "You must provide your annual income.")]        
        public decimal AnnualIncome { get; set; }

        [Required(ErrorMessage = "You must provide postal code.")]
        public string PostalCode { get; set; }

    }
}
