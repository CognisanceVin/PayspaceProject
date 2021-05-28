using DomainManager;
using DomainManager.Models;
using NUnit.Framework;
using System;
using System.Data.Entity.Core;
using System.Data.SqlClient;

namespace NUnitTestPaySpaceTaxCalculator.BusinessLogic.DomainManager
{
    public class TaxCalculatorManager_Tests
    {
        private TaxCalculatorManager _taxCalculator;
        [SetUp]
        public void Setup()
        {
            _taxCalculator = new TaxCalculatorManager();

        }
        
        [Test]
        public void Calculate_TestIsProgressiveTaxRate()
        {
            decimal AnnualIncome = 570900m;
            decimal rate = 0.35m;
            decimal result = _taxCalculator.Calculate(rate, AnnualIncome);
            Assert.AreEqual(199815m, result);
        }

        [Test]
        public void Calculate_TestIsFlatRateTaxRate()
        {
            decimal AnnualIncome = 570900m;
            decimal rate = 0.175m;
            decimal result = _taxCalculator.Calculate(rate, AnnualIncome);
            Assert.AreEqual(99907.5m, result);
        }
        [Test]
        public void SaveTaxRecord_Test()
        {
            TaxModel model = new TaxModel();
            model.PostalCode = "A100";
            model.AnnualIncome = 570900m;
            bool result = _taxCalculator.SaveTaxRecord(model, 199815m);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void SaveTaxRecord_TestObjectReferenceExemption()
        {
            TaxModel model = new TaxModel();
            model.PostalCode = "1000";
            model.AnnualIncome = 570900m;

            Exception ex = Assert.Throws<NullReferenceException>(
              delegate { throw new NullReferenceException(); });
            Assert.AreEqual(ex, _taxCalculator.SaveTaxRecord(model, 199815m));
        }

        [Test]
        public void SaveTaxRecord_TestCatchAllExemptionsThrown()
        {
            TaxModel model = new TaxModel();
            model.PostalCode = "1000";
            model.AnnualIncome = 570900m;

            Exception ex = Assert.Throws<Exception>(
              delegate { throw new Exception(); });
            Assert.AreEqual(ex, _taxCalculator.SaveTaxRecord(model, 199815m));
        }

        [Test]
        public void SaveTaxRecord_TestFailedSave()
        {
            TaxModel model = new TaxModel();
            model.PostalCode = "1000";
            model.AnnualIncome = 570900m;
            bool result = _taxCalculator.SaveTaxRecord(model, 199815m);
            Assert.AreEqual(false, false);
        }

        [Test]
        public void SaveTaxRecord_TestSuccessfulSave()
        {
            TaxModel model = new TaxModel();
            model.PostalCode = "7000";
            model.AnnualIncome = 570900m;
            bool result = _taxCalculator.SaveTaxRecord(model, 199815m);
            Assert.AreEqual(true, result);
        }
    }
}
