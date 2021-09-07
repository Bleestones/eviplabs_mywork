using Xunit;

namespace LAB03_TextHandlingIoLab2
{
    public class MusicBoxTests
    {
        Solutions solutions = new Solutions();

        /// <summary>
        /// Minden olyan dolog benne van a zenedobozban, aminek a nevében van zenei szolmizációs hang:
        /// dó, ré, mi, fá, szó, lá, ti
        /// </summary>

        [Fact]
        public void IsInsideMusicBox()
        {
            Assert.True(solutions.IsInsideMusicBox(@"mi"));
            Assert.True(solutions.IsInsideMusicBox(@"fűzfák"));
        }

        [Fact]
        public void IsNotInsideMusicBox()
        {
            Assert.False(solutions.IsInsideMusicBox(@"kampósbot"));
            Assert.False(solutions.IsInsideMusicBox(@"ékszer"));
            Assert.False(solutions.IsInsideMusicBox(@"zene"));
        }

        [Fact]
        public void CollectWhatsInsideMusicBox()
        {
            // Kigyűjti azokat a szavakat, melyek benne vannak a zenedobozban.
            string[] result = solutions.CollectWhatsInsideMusicBox(TextSource.ShortTextForMusicBox);
            Assert.Equal(5, result.Length);
            Assert.Contains(@"mi", result);
            Assert.Contains(@"fához", result);
            Assert.Contains(@"dóm", result);
            Assert.Contains(@"szóval", result);
            Assert.Contains(@"látogatókat", result);
        }

        [Fact]
        public void HighlightNotesInMusicBox()
        {
            // * karakterekkel körbeveszi a zenei hangot a szóban.
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/substitutions-in-regular-expressions
            Assert.Equal(@"a*mi*nósav", solutions.HightlightNotesInMusicBox(@"aminósav"));
            Assert.Equal(@"tölgy*fá*ban", solutions.HightlightNotesInMusicBox(@"tölgyfában"));
            Assert.Equal(@"*szó*val", solutions.HightlightNotesInMusicBox(@"szóval"));
            Assert.Equal(@"Ba*lá*zs", solutions.HightlightNotesInMusicBox(@"Balázs"));
        }
    }
}
