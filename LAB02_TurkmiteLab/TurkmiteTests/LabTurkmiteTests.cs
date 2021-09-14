using Xunit;
using TurkMite;
using OpenCvSharp;

namespace LabTurkmiteTests
{
    public class LabTurkmiteTests
    {
        TestLabTurkmite turkmite = new TestLabTurkmite(new Mat(10, 10, MatType.CV_8UC3, new Scalar(0, 0, 0)));

        [Fact]
        public void BlackFieldAndCounterCorrectThenColorYellow()
        {
            var result = turkmite.GetNextColorAndUpdateDirection(turkmite.Black);
            Assert.Equal(turkmite.Yellow, result.newColor);
            Assert.Equal(3, result.deltaDirection);
        }

        private class TestLabTurkmite : LabTurkmite
        {
            public Vec3b Black { get { return black; } }
            public Vec3b Red { get { return red; } }
            public Vec3b Yellow { get { return yellow; } }

            public new (Vec3b newColor, int deltaDirection) GetNextColorAndUpdateDirection(Vec3b currentColor)
            {
                return (base.GetNextColorAndUpdateDirection(currentColor));
            }

            public TestLabTurkmite(Mat image) : base(image)
            {
            }
        }
    }
}
