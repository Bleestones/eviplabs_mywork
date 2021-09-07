using Numbers;
using Xunit;

namespace Tests
{
    public class PrimeTests
    {
        [Fact]
        public void CountPrimeNumbers100Returns25()
        {
            var p = new CountPrimeNumbers(100);
            Assert.Equal(25, p.CalculateSolution());
        }

        [Fact]
        public void SumOfPrimeNumbers100Returns1060()
        {
            var p = new SumOfPrimeNumbers(100);
            Assert.Equal(1060, p.CalculateSolution());
        }
    }
}
