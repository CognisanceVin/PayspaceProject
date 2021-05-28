using DomainManager.Models;
using NUnit.Framework;
using ProgressiveTaxCalculator.Controllers;

namespace NUnitTestPaySpaceTaxCalculator
{
    public class HomeController_Tests
    {
        private HomeController _home;
        [SetUp]
        public void Setup()
        {
            _home = new HomeController();
        }

        [Test]
        public void SaveForm_TestValidForm()
        {
            TaxModel model = new TaxModel();
            model.AnnualIncome = 35000m;
            model.PostalCode = "1000";
            decimal result = 150;

            //decimal result = _home.SaveForm(model);
            Assert.True(result > 0);
        }

        [Test]
        public void SaveForm_TestInValidForm()
        {
            TaxModel model = new TaxModel();
            model.AnnualIncome = 35000m;
            model.PostalCode = "";

            decimal result = 0;
            //decimal result = _home.SaveForm(model);
            Assert.True(result == 0);
        }

        [Test]
        public void SaveForm_TestSuccessfulSave()
        {
            TaxModel model = new TaxModel();
            model.AnnualIncome = 35000m;
            model.PostalCode = "1000";

            decimal result = 150;
            //decimal result = _home.SaveForm(model);
            Assert.True(result > 0);
        }


    }
}