using Loan.Domain.Applications;
using NUnit.Framework;

namespace Loan.NUnit.Test
{
    [TestFixture]
    public class LoanRepaymentCalculatorShould
    {
        [Test]
        [TestCase(200_000, 6.5, 30, 1264.14)]
        [TestCase(200_000, 10, 30, 1755.14)]
        [TestCase(500_000, 10, 30, 4387.86)]
        public void CalculateCorrectMonthlyRepayment(decimal principal,
                                                    decimal interestRate,
                                                    int termInYears,
                                                    decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(
                                     new LoanAmount("USD", principal),
                                     interestRate,
                                     new LoanTerm(termInYears));
            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        [Test]
        [TestCase(200_000, 6.5, 30, ExpectedResult = 1264.14)]
        [TestCase(200_000, 10, 30, ExpectedResult = 1755.14)]
        [TestCase(500_000, 10, 30, ExpectedResult = 4387.86)]
        public decimal CalculateCorrectMonthlyRepayment_AlternateUseOfTestCase(decimal principal,
                                             decimal interestRate,
                                             int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            return sut.CalculateMonthlyRepayment(
                                     new LoanAmount("USD", principal),
                                     interestRate,
                                     new LoanTerm(termInYears));
        }


        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestData), nameof(MonthlyRepaymentTestData.TestCases))]
        public void CalculateCorrectMonthlyRepayment_UsingTestCaseSource(decimal principal,
                                                    decimal interestRate,
                                                    int termInYears,
                                                    decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(
                                     new LoanAmount("USD", principal),
                                     interestRate,
                                     new LoanTerm(termInYears));
            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }


        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestDataWithReturn), nameof(MonthlyRepaymentTestDataWithReturn.TestCases))]
        public decimal CalculateCorrectMonthlyRepayment_UsingTestCaseSourceWithReturn(decimal principal,
                                            decimal interestRate,
                                            int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            return sut.CalculateMonthlyRepayment(
                                     new LoanAmount("USD", principal),
                                     interestRate,
                                     new LoanTerm(termInYears));
        }


        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentCsvData), nameof(MonthlyRepaymentCsvData.GetTestCases), new object[] { "data.csv" })]
        public void CalculateCorrectMonthlyRepayment_UsingTestCaseSource_CSV(decimal principal,
                                                   decimal interestRate,
                                                   int termInYears,
                                                   decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();
            var monthlyPayment = sut.CalculateMonthlyRepayment(
                                     new LoanAmount("USD", principal),
                                     interestRate,
                                     new LoanTerm(termInYears));
            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }


        [Test]
        public void CalculateCorrectMonthlyRepayment_Combinatorial(
           [Values(100_000, 200_000, 500_000)] decimal principal,
           [Values(6.5, 10, 20)] decimal interestRate,
           [Values(10, 20, 30)] int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            var monthlyPayment = sut.CalculateMonthlyRepayment(
                new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        }

        [Test]
        [Sequential]
        public void CalculateCorrectMonthlyRepayment_Sequential(
                    [Values(200_000, 200_000, 500_000)] decimal principal,
                    [Values(6.5, 10, 10)] decimal interestRate,
                    [Values(30, 30, 30)] int termInYears,
                    [Values(1264.14, 1755.14, 4387.86)] decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();

            var monthlyPayment = sut.CalculateMonthlyRepayment(
                new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));

            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        [Test]
        public void CalculateCorrectMonthlyRepayment_Range(
            [Range(5, 10, 1)] decimal principal,
            [Range(0.5, 20.00, 0.5)] decimal interestRate,
            [Values(10, 20, 30)] int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            sut.CalculateMonthlyRepayment(
                new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        }
    }
}
