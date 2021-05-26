﻿using Loan.Domain.Applications;
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
        [TestCaseSource(typeof(MonthlyRepaymentTestData),nameof(MonthlyRepaymentTestData.TestCases))]
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
        [TestCaseSource(typeof(MonthlyRepaymentTestDataWithReturn),nameof(MonthlyRepaymentTestDataWithReturn.TestCases))]
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
    }
}
