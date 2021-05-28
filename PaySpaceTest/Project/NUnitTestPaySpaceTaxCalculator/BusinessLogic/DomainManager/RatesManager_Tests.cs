using DomainManager;
using NUnit.Framework;
namespace NUnitTestPaySpaceTaxCalculator.BusinessLogic.DomainManager
{
    public class RatesManager_Tests
    {
        private RatesManager _rates;
        [SetUp]
        public void Setup()
        {
            _rates = new RatesManager();
        }

        [Test]
        public void getRates_Test()
        {
            decimal AnnualIncome = 57900m;
            string PostalCode = "7441";
            decimal result = _rates.getRates(PostalCode, AnnualIncome);
            Assert.AreEqual(0.25m, result);
        }

        [Test]
        public void getRates_TestIsProgressiveRate()
        {
            decimal AnnualIncome = 57900m;
            string PostalCode = "1000";
            decimal result = _rates.getRates(PostalCode, AnnualIncome);
            Assert.AreEqual(0.25m, result);
        }


        [Test]
        public void getRates_TestIsFlatRate()
        {
            decimal AnnualIncome = 57900m;
            string PostalCode = "7000";
            decimal result = _rates.getRates(PostalCode, AnnualIncome);
            Assert.AreEqual(0.175m, result);
        }


        [Test]
        public void getRates_TestIsFlatValue()
        {
            decimal AnnualIncome = 570900m;
            string PostalCode = "A100";
            decimal result = _rates.getRates(PostalCode, AnnualIncome);
            Assert.AreEqual(10000m, result);
        }


        [Test]
        public void getProgressiveRates_Test()
        {
            decimal AnnualIncome = 57900m;            
            decimal result = _rates.getProgressiveRates(AnnualIncome);
            Assert.AreEqual(0.25m, result);
        }

        [Test]
        public void getFlatValue_Test()
        {
            decimal AnnualIncome = 57900m;
            decimal result = _rates.getFlatValue(AnnualIncome);
            Assert.AreEqual(0.05m, result);
        }

        [Test]
        public void getFlatRate_Test()
        {
            decimal result = _rates.getFlatRate();
            Assert.AreEqual(0.175m, result);
        }
    }
}
