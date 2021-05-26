using Loan.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan.NUnit.Test
{
    [TestFixture]
    [Category("Product")]
    public class ProductComparerShould
    {
        private List<LoanProduct> _products;
        private ProductComparer _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Run after last test in this test class (fixture) executes
            // e.g. disposing of shared expensive setup performed in OneTimeSetUp

            // products.Dispose(); e.g. if products implemented IDisposable
        }

        [SetUp]
        public void Setup()
        {
            _products = new List<LoanProduct>
            {
                new LoanProduct(1, "LowRate", 1),
                new LoanProduct(2, "MediumRate", 2),
                new LoanProduct(3, "HighRate", 2.54m)
            };
            _sut = new ProductComparer(new LoanAmount("USD", 355_200m), _products);
        }

        [TearDown]
        public void TearDown() 
        {
            // Runs after each test executes
            // sut.Dispose();
        }

        [Test]
        public void ReturnCorrectNumberOfComparisons()
        {
            List<MonthlyRepaymentComparison> comparisons = _sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Has.Exactly(3).Items);
        }

        [Test]
        public void NotReturnDuplicateComparisons()
        {
            _products.Add(new LoanProduct(1, "LowRate", 1));

            List<MonthlyRepaymentComparison> comparisons = _sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Is.Not.Unique);
        }

        [Test]
        public void ReturnComparisonForFirstProduct()
        {           
            List<MonthlyRepaymentComparison> comparisons =
                _sut.CompareMonthlyRepayments(new LoanTerm(30));

            // Need to also know the expected monthly repayment
            var expectedProduct = new MonthlyRepaymentComparison("LowRate", 1, 1142.46m);
            Assert.That(comparisons, Does.Contain(expectedProduct));
        }

        [Test]
        public void ReturnComparisonForFirstProduct_WithPartialKnownExpectedValues()
        {

            List<MonthlyRepaymentComparison> comparisons = _sut.CompareMonthlyRepayments(new LoanTerm(30));

            // Don't care about the expected monthly repayment, only that the product is there
            //Assert.That(comparisons, Has.Exactly(1)
            //    .Property(nameof(MonthlyRepaymentComparison.ProductName)).EqualTo("LowRate")
            //    .And
            //    .Property(nameof(MonthlyRepaymentComparison.InterestRate)).EqualTo(1)
            //    .And
            //    .Property(nameof(MonthlyRepaymentComparison.MonthlyRepayment)).GreaterThan(1));

            Assert.That(comparisons, Has.Exactly(1)
                                       .Matches<MonthlyRepaymentComparison>(
                                               item => item.ProductName == "LowRate" &&
                                                       item.InterestRate == 1 &&
                                                       item.MonthlyRepayment > 1));
        }       
    }
}
