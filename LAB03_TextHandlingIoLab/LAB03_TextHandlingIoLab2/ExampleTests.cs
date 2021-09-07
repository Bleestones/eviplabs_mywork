using Xunit;

namespace LAB03_TextHandlingIoLab2
{
    public class ExampleTests
    {
        Solutions solutions = new Solutions();

        [Fact]
        public void MatchingExample()
        {
            Assert.True(solutions.MatchingExample());
        }

        [Fact]
        public void CollectingMatchesExample()
        {
            string[] result = solutions.CollectingMatchesExample();
            Assert.Equal(2, result.Length);
            Assert.Contains(@"<valami>", result);
            Assert.Contains(@"<még valami>", result);
        }
    }
}