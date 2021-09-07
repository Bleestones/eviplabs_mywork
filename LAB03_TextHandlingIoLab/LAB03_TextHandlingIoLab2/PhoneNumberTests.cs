using Xunit;

namespace LAB03_TextHandlingIoLab2
{
    public class PhoneNumberTests
    {
        Solutions solutions = new Solutions();

        [Fact]
        public void ValidPhoneNumbers()
        {
            Assert.True(solutions.IsPhoneNumber(@"+3614633702"));
            Assert.True(solutions.IsPhoneNumber(@"+36-30-123-4567"));
        }

        [Fact]
        public void InvalidPhoneNumbers()
        {
            // Tipp: A ^ és $ jelek a szöveg elejére és végére "illeszkednek". Ezzel tudod elérni, hogy
            //  a Regex ne illeszkedhessen a szöveg egy rövidebb részére, hanem az egészet le kell, hogy fedje.
            Assert.False(solutions.IsPhoneNumber(@"36707654321"));
            Assert.False(solutions.IsPhoneNumber(@"+362012345F6"));
        }

        [Fact]
        public void IsHungarianMobilePhoneNumber()
        {
            Assert.True(solutions.IsHungarianMobilePhoneNumber(@"+36707654321"));
            Assert.True(solutions.IsHungarianMobilePhoneNumber(@"+3620-123-4567"));
            Assert.False(solutions.IsHungarianMobilePhoneNumber(@"+3614633702"));
            Assert.False(solutions.IsHungarianMobilePhoneNumber(@"+36-42-123-456"));
        }

        [Fact]
        public void CollectPhoneNumbers()
        {
            // Tipp: itt fontos lesz, hogy a telefonszám végét szóköz vagy vessző jelzi (a példa szövegben
            //  legalábbis), de az már nem a szám része. A Regex illesztésekor a match.Groups
            //  tartalmazza a zárójeles részek illesztését. Pl. ha "ab(..)c"-t illesztek "abxyc"-re, akkor
            //  a match.Groups[1].Captures[0].Value az első zárójeles rész értékét tartalmazza, most "xy"-t.
            string[] result = solutions.CollectPhoneNumbers(TextSource.ShortTextWithPhoneNumbers);
            Assert.Equal(5, result.Length);
            Assert.Contains(@"+36701234567", result);
            Assert.Contains(@"+1-202-555-0114", result);
            Assert.Contains(@"06201237654", result);
            Assert.Contains(@"+36201234567", result);
            Assert.Contains(@"+3614633702", result);
        }
    }
}
