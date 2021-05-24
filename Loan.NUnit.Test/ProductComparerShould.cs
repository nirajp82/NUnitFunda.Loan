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
    public class ProductComparerShould
    {
        [Test]
        public void ReturnCorrectNumberOfComparisons()
        {
            List<LoanProduct> products = GetLoanProduct();

            var sut = new ProductComparer(new LoanAmount("USD", 355_200m), products);

            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Has.Exactly(3).Items);
        }

        [Test]
        public void NotReturnDuplicateComparisons()
        {
            List<LoanProduct> products = GetLoanProduct();
            products.Add( new LoanProduct(1, "LowRate", 1));

            var sut = new ProductComparer(new LoanAmount("USD", 355_200m), products);

            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Is.Not.Unique);
        }

        [Test]
        public void ReturnComparisonForFirstProduct()
        {
            List<LoanProduct> products = GetLoanProduct();

            var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparisons =
                sut.CompareMonthlyRepayments(new LoanTerm(30));

            // Need to also know the expected monthly repayment
            var expectedProduct = new MonthlyRepaymentComparison("LowRate", 1, 643.28m);
            Assert.That(comparisons, Does.Contain(expectedProduct));
        }

        [Test]
        public void ReturnComparisonForFirstProduct_WithPartialKnownExpectedValues()
        {

            List<LoanProduct> products = GetLoanProduct();
            var sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);

            List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

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

        private static List<LoanProduct> GetLoanProduct()
        {
            return new List<LoanProduct>
            {
                new LoanProduct(1, "LowRate", 1),
                new LoanProduct(2, "MediumRate", 2),
                new LoanProduct(3, "HighRate", 2.54m)
            };
        }
    }
}
