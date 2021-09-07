using Xunit;

namespace LAB03_TextHandlingIoLab2
{
    public class PlusCodeTests
    {
        // https://en.wikipedia.org/wiki/Open_Location_Code
        Solutions solutions = new Solutions();

        [Fact]
        public void IsPlusCode()
        {
            // Tipp: hasznos lehet a darabszám jelölés a reguláris kifejezésekben:
            //  https://docs.microsoft.com/en-us/dotnet/standard/base-types/quantifiers-in-regular-expressions
            Assert.True(solutions.IsPlusCode(@"8FVXF3F5+6X"));
            Assert.True(solutions.IsPlusCode(@"8FRVWV5J+JH"));
            Assert.False(solutions.IsPlusCode(@"8FVXF1F5+6X")); // "1" nem lehet benne, lásd Wikipedia...
        }

        [Fact]
        public void IsPlusCodeInBudapest()
        {
            Assert.True(solutions.IsPlusCodeInBudapest(@"F3F5+6X Budapest"));
        }

        [Fact]
        public void CollectFullPlusCodes()
        {
            string[] result = solutions.CollectFullPlusCodes(TextSource.ShortTextForPlusCodes);
            Assert.Equal(6, result.Length);
            Assert.Contains(@"8FVXF3F5+6X", result);
            Assert.Contains(@"8FRVWV5J+JH", result);
            Assert.Contains(@"7Q622X5W+PF", result);
            Assert.Contains(@"8FVXF3H5+GPX", result);
            Assert.Contains(@"8FVXG28V+2C", result);
            Assert.Contains(@"7J3XWRJP+J8", result);
        }


    }
}
