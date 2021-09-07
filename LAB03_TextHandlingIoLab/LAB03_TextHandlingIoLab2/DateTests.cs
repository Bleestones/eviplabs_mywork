using Xunit;

namespace LAB03_TextHandlingIoLab2
{
    public class DateTests
    {
        Solutions solutions = new Solutions();

        [Fact]
        public void CollectDates()
        {
            // Tipp: itt is szükség lesz a Regex-en belüli zárójeles részek elérésére,
            //  mint a CollectPhoneNumbers unit tesztben.
            //  Emellett kelleni fog az int.Parse metódus is, ami számmá alakítja a stringet,
            //  hogy tudd ellenőrizni, pl. a hónap kisebb-e, mint 13.
            string[] result = solutions.CollectDates(TextSource.ShortTextForDates);
            Assert.Equal(2, result.Length);
            Assert.Contains(@"2019-08-22", result);
            Assert.Contains(@"2018/08/31", result);
        }
    }
}
