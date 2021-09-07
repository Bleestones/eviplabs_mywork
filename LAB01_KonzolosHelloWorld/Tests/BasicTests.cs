using Numbers;
using Xunit;

namespace Tests
{
    public class BasicTests
    {
        [Fact]
        public void SumOfNumbersFor10Returns45()
        {
            // SumOfNumbers public kell, hogy legyen.
            //  Ahhoz meg a SolutionProviderBase-nek is publicnak kell lennie.
            SumOfNumbers son = new SumOfNumbers(10);
            Assert.Equal(45, son.CalculateSolution());
        }
    }
}
