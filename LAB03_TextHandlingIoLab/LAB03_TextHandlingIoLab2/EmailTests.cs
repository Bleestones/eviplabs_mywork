using Xunit;

namespace LAB03_TextHandlingIoLab2
{
    public class EmailTests
    {
        Solutions solutions = new Solutions();

        [Fact]
        public void ValidEmails()
        {
            Assert.True(solutions.IsEmailAddress(@"someone@example.com"));
            Assert.True(solutions.IsEmailAddress(@"someone@there.example.com"));
        }

        [Fact]
        public void InvalidEmails()
        {
            Assert.False(solutions.IsEmailAddress(@"someone.example.com"));
            Assert.False(solutions.IsEmailAddress(@"someone.example."));
            Assert.False(solutions.IsEmailAddress(@"@example.com"));
        }

        [Fact]
        public void CollectEmails()
        {
            string[] result = solutions.CollectEmailAddresses(TextSource.ShortTextWithEmails);
            Assert.Equal(4, result.Length);
            Assert.Contains(@"valaki@example.com", result);
            Assert.Contains(@"nagyfonok@nagyceg.example.com", result);
            Assert.Contains(@"itt.es.ott@bme.hu", result);
            Assert.Contains(@"info@bkk.hu", result);
        }
    }
}
