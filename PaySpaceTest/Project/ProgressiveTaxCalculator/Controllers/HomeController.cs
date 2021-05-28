using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DomainManager;
using DomainManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgressiveTaxCalculator.DB;

namespace ProgressiveTaxCalculator.Controllers
{
    public class HomeController : Controller
    {

        private TaxCalculatorManager _taxCalcManager = new TaxCalculatorManager();
        private string message;
        public IActionResult Index(string res)
        {
           
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveForm(TaxModel TaxData)
        {
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(TaxData.PostalCode))
                {
                    decimal result = _taxCalcManager.SaveTaxData(TaxData);

                    TempData["Message"] = message = String.Format("Saved successfully. Your tax is R{0}", result.ToString("#.00"));

                    return RedirectToAction("Index");                        
                }
                else
                {
                    TempData["Message"]= message = "Invalid form data.";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Message"]= message = "Form is incomplete.";
                return RedirectToAction("Index");
            }
           
            //throw new NotImplementedException("Create Method");
        }
    }
}
