using Loan.Domain.Applications;
using NUnit.Framework;
using System;

namespace Loan.NUnit.Test
{
    [TestFixture]
    public class LoanTermShould
    {
        [Test]
        public void MonthsInLoanTerm()
        {
            var sut = new LoanTerm(1);

            Assert.That(sut.ToMonths(), Is.EqualTo(12));
        }

        [Test]
        public void YearsInLoanTerm()
        {
            var sut = new LoanTerm(1);

            Assert.That(sut.Years, Is.EqualTo(1));
        }

        [Test]
        public void LoanTermValueEquality()
        {
            var loanTerm1 = new LoanTerm(1);
            var loanTermAnother1 = new LoanTerm(1);
            Assert.That(loanTerm1, Is.EqualTo(loanTermAnother1));
        }

        [Test]
        public void LoanTermValueNotEqual()
        {
            var loanTerm1 = new LoanTerm(1);
            var loanTerm2 = new LoanTerm(2);
            Assert.That(loanTerm1, Is.Not.EqualTo(loanTerm2));
        }

        [Test]
        public void ReferenceEqualityExample()
        {
            var loanTerm1 = new LoanTerm(1);
            var loanTerm1Ref = loanTerm1;               
            var loanTermAnother1 = new LoanTerm(1);
            Assert.That(loanTerm1, Is.SameAs(loanTerm1Ref));
            Assert.That(loanTerm1, Is.Not.SameAs(loanTermAnother1));
        }

        [Test]
        public void IsDoubleWithInRange() 
        {
            double result = 1.0 / 3.0;
            Assert.That(result, Is.EqualTo(0.33).Within(0.004));
            Assert.That(result, Is.EqualTo(0.33).Within(10).Percent);
        }

        [Test]
        public void NotAllowZeroYears() 
        {
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                            .With
                            .Property("Message")
                            .EqualTo($"Please specify a value greater than 0. (Parameter 'years')"));

            // Correct ex and para name but don't care about the message
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                             .With
                             .Property("ParamName")
                             .EqualTo(nameof(LoanTerm.Years)));

            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                                         .With
                                         .Matches<ArgumentOutOfRangeException>(
                                             ex => ex.ParamName == nameof(LoanTerm.Years)));
        }
    }
}
