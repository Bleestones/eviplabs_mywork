using Xunit;
using Common;

namespace Tests
{
    public class SquareTests
    {
        [Fact]
        public void FiveSquareTest()
        {
            var squareGenerator = new SquareGenerator(5).GenerateTexts();
            Assert.Contains(squareGenerator, value => value.Contains("25"));
        }
    }
}
