using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Linq2XmlSvgLab
{
    public class TaskTests
    {
        private readonly Solutions s1;
        private readonly Solutions s2;

        public TaskTests()
        {
            s1 = new Solutions("rectangles1.svg");
            s2 = new Solutions("rectangles2.svg");
        }

        [Fact]
        public void GetAllRectangles()
        {
            Assert.Equal(7, s1.GetAllRectangles().Count());
            Assert.Equal(12, s2.GetAllRectangles().Count());
        }

        [Fact]
        public void CountTextsWithValue()
        {
            Assert.Equal(1, s1.CountTextsWithValue("Négyzetek"));
            Assert.Equal(3, s1.CountTextsWithValue("Alma"));
            Assert.Equal(1, s1.CountTextsWithValue("Barack"));
            Assert.Equal(1, s1.CountTextsWithValue("Körte"));

            Assert.Equal(1, s2.CountTextsWithValue("Gyümölcsök"));
            Assert.Equal(3, s2.CountTextsWithValue("Szilva"));
            Assert.Equal(3, s2.CountTextsWithValue("Barack"));
            Assert.Equal(1, s2.CountTextsWithValue("Banán"));
            Assert.Equal(2, s2.CountTextsWithValue("Meggy"));
        }

        [Fact]
        public void GetRectanglesWithStrokeWidth()
        {
            Assert.Equal(2, s1.GetRectanglesWithStrokeWidth(1).Count());
            Assert.Equal(5, s1.GetRectanglesWithStrokeWidth(2).Count());

            Assert.Equal(8, s2.GetRectanglesWithStrokeWidth(1).Count());
            Assert.Equal(4, s2.GetRectanglesWithStrokeWidth(2).Count());
        }

        [Fact]
        public void GetColorOfRectanglesWithGivenX()
        {
            var correctColors = new string[] { "#ff0000", "#0000ff", "#ffffff" };
            var colors = s1.GetColorOfRectanglesWithGivenX(30);
            Assert.True(UnorderedCompareSequences(correctColors, colors));

            correctColors = new string[] { "#ffffff", "#ff0000", "#ff0000", "#0000ff" };
            colors = s2.GetColorOfRectanglesWithGivenX(20);
            Assert.True(UnorderedCompareSequences(correctColors, colors));
        }

        [Fact]
        public void GetRectangleLocationById()
        {
            AssertLocation(80.0, 180.0, s1.GetRectangleLocationById("rectTeal"));
            AssertLocation(20.0, 33.75, s2.GetRectangleLocationById("rectWhite"));
        }

        private void AssertLocation(double correctX, double correctY, (double X, double Y) result)
        {
            Assert.Equal(correctX, result.X, 3);
            Assert.Equal(correctY, result.Y, 3);
        }

        [Fact]
        public void GetIdOfRectangeWithLargestY()
        {
            Assert.Equal("rectTeal", s1.GetIdOfRectangeWithLargestY());
            Assert.Equal("rectLowerYellow", s2.GetIdOfRectangeWithLargestY());
        }

        [Fact]
        public void GetRectanglesAtLeastTwiceAsHighAsWide()
        {
            var ids = s1.GetRectanglesAtLeastTwiceAsHighAsWide().ToArray();
            Assert.Equal(2, ids.Length);
            Assert.Contains("rectBlue", ids);
            Assert.Contains("rectGreen", ids);

            ids = s2.GetRectanglesAtLeastTwiceAsHighAsWide().ToArray();
            Assert.Single(ids);
            Assert.Equal("rectLowerBlue", ids[0]);
        }

        [Fact]
        public void GetColorsOfRectsInGroup()
        {
            var colors = s1.GetColorsOfRectsInGroup("group1");
            Assert.True(UnorderedCompareSequences<string>(new string[] { "#ff0000", "#ffff00" },
                colors));

            colors = s2.GetColorsOfRectsInGroup("group2");
            Assert.True(UnorderedCompareSequences<string>(new string[] { "#00ff00", "#0000ff" },
                colors));
        }

        [Fact]
        public void GetRectanglesWithTextInside()
        {
            Assert.Equal(3, s1.GetRectanglesWithTextInside().Count());
            Assert.Equal(8, s2.GetRectanglesWithTextInside().Count());
        }

        [Fact]
        public void GetSingleTextInSingleRectangleWithColor()
        {
            Assert.Equal("Barack", s1.GetSingleTextInSingleRectangleWithColor("#ff00ff"));
            Assert.Null(s1.GetSingleTextInSingleRectangleWithColor("#00ff00"));
            Assert.Equal("Alma", s1.GetSingleTextInSingleRectangleWithColor("#ffffff"));

            Assert.Equal("Meggy", s2.GetSingleTextInSingleRectangleWithColor("#ff00ff"));
            Assert.Equal("Szilva", s2.GetSingleTextInSingleRectangleWithColor("#ffffff"));
        }

        [Fact]
        public void GetTextsOutsideRectangles()
        {
            var correctTexts = new string[] { "Alma", "Körte", "Négyzetek" };
            Assert.True(UnorderedCompareSequences(correctTexts, s1.GetTextsOutsideRectangles()));

            correctTexts = new string[] { "Banán", "Gyümölcsök" };
            Assert.True(UnorderedCompareSequences(correctTexts, s2.GetTextsOutsideRectangles()));
        }

        [Fact]
        public void GetSingleRectanglePairCloseToEachOther()
        {
            AssertIdPair("rectWhite", "rectBlue", s1.GetSingleRectanglePairCloseToEachOther(5.0));
            AssertIdPair("rectTeal", "rectGreen", s2.GetSingleRectanglePairCloseToEachOther(5.0));
        }

        private void AssertIdPair(string correctId1, string correctId2, (string id1, string id2) result)
        {
            Assert.True((result.id1 == correctId1 && result.id2 == correctId2)
                || (result.id1 == correctId2 && result.id2 == correctId1));
        }

        [Fact]
        public void GetBoundingRectangleColorListForEveryText()
        {
            var result = s1.GetBoundingRectangleColorListForEveryText();
            Assert.True(UnorderedCompareSequences<string>(new string[] { "#ffff00", "#ffffff" }, result["Alma"]));
            Assert.True(UnorderedCompareSequences<string>(new string[] { "#ff00ff" }, result["Barack"]));
            Assert.False(result.Contains("Szilva"));
            Assert.False(result["Körte"].Any());

            result = s2.GetBoundingRectangleColorListForEveryText();
            Assert.True(UnorderedCompareSequences<string>(new string[] { "#ffffff", "#00ffff", "#ffff00" }, result["Szilva"]));
            Assert.True(UnorderedCompareSequences<string>(new string[] { "#ff00ff", "#00ff00" }, result["Meggy"]));
            Assert.False(result.Contains("Alma"));
            Assert.False(result["Banán"].Any());

        }

        [Fact]
        public void ConcatenateOrderedTextsInsideRectangles()
        {
            string correctResult = "Alma, Alma, Barack";
            Assert.Equal(correctResult, s1.ConcatenateOrderedTextsInsideRectangles());

            correctResult = "Barack, Barack, Barack, Meggy, Meggy, Szilva, Szilva, Szilva";
            Assert.Equal(correctResult, s2.ConcatenateOrderedTextsInsideRectangles());
        }

        [Fact]
        public void GetEffectiveWidthAndHeightWithGivenStrokeThickness()
        {
            AssertWidthHeight(s1, 1, 110.0, 110.0);
            AssertWidthHeight(s1, 2, 140.0, 190.0);
            AssertWidthHeight(s2, 1, 170.0, 230.0);
            AssertWidthHeight(s2, 2, 170.0, 216.25);
        }

        private void AssertWidthHeight(Solutions s, int strokeThickness, double width, double height)
        {
            (double w, double h) = s.GetEffectiveWidthAndHeight(strokeThickness);
            Assert.Equal(width, w, 3);
            Assert.Equal(height, h, 3);
        }

        #region Helpers for the unit tests and their tests
        [Fact]
        public void TestUnorderedCompareSequences()
        {
            Assert.True(UnorderedCompareSequences(new int[] {1, 2, 3}, new int[] {1, 2, 3}));
            Assert.True(UnorderedCompareSequences(new int[] {1, 2, 3}, new int[] {1, 3, 2}));
            Assert.True(UnorderedCompareSequences(new int[] {1, 2, 2}, new int[] {2, 1, 2}));
            Assert.False(UnorderedCompareSequences(new int[] { 1 }, new int[] { 1, 2 }));
            Assert.False(UnorderedCompareSequences(new int[] { 1 }, new int[] { 2, 3}));
        }

        private bool UnorderedCompareSequences<T>(IEnumerable<T> s1, IEnumerable<T> s2)
        {
            return s1.OrderBy(i => i).SequenceEqual(s2.OrderBy(j => j));
        }
        #endregion
    }
}
