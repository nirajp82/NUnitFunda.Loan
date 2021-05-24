using Loan.Domain.Applications;
using NUnit.Framework;

namespace Loan.NUnit.Test
{
    [TestFixture]
    public class LoanTermShould
    {
        [Test]
        public void ReturnTermInMonths()
        {
            var sut = new LoanTerm(1);

            Assert.That(sut.ToMonths(), Is.EqualTo(12));
        }
    }
}
