using Xunit;
using TurkMite;
using OpenCvSharp;

namespace LabTurkmiteTests
{
    public class LabTurkmiteTests
    {
        TestLabTurkmite turkmite = new TestLabTurkmite(new Mat(10, 10, MatType.CV_8UC3, new Scalar(0, 0, 0)));

        [Fact]
        public void BlackField_ThenColorYellow()
        {
            var result = turkmite.GetNextColorAndUpdateDirection(turkmite.Black);
            Assert.Equal(turkmite.Yellow, result.newColor);
            Assert.Equal(3, result.deltaDirection);
        }

        [Fact]
        public void BlackField_ThenColorRed()
        {
            turkmite.InternalCounter++;
            var result = turkmite.GetNextColorAndUpdateDirection(turkmite.Black);
            Assert.Equal(turkmite.Red, result.newColor);
            Assert.Equal(3, result.deltaDirection);
        }

        [Fact]
        public void RedField_ThenDirectionAndColorCorrect()
        {
            var result = turkmite.GetNextColorAndUpdateDirection(turkmite.Red);
            Assert.Equal(turkmite.Yellow, result.newColor);
            Assert.Equal(3, result.deltaDirection);
        }

        [Fact]
        public void YellowField_ThenDirectionAndColorCorrect()
        {
            var result = turkmite.GetNextColorAndUpdateDirection(turkmite.Yellow);
            Assert.Equal(turkmite.Black, result.newColor);
            Assert.Equal(1, result.deltaDirection);
        }

        [Fact]
        public void InternalCounterEvenIsCorrect()
        {
            turkmite.InternalCounter = 3;
            Assert.False(turkmite.IsInternalCounterAndUpdateEven());
        }

        private class TestLabTurkmite : LabTurkmite
        {
            public Vec3b Black { get { return black; } }
            public Vec3b Red { get { return red; } }
            public Vec3b Yellow { get { return yellow; } }
            public int InternalCounter { get { return internalCounter; } set { this.internalCounter = value; } }

            public new (Vec3b newColor, int deltaDirection) GetNextColorAndUpdateDirection(Vec3b currentColor)
            {
                return (base.GetNextColorAndUpdateDirection(currentColor));
            }

            public new bool IsInternalCounterAndUpdateEven()
            {
                return (base.IsInternalCounterAndUpdateEven());
            }

            public TestLabTurkmite(Mat image) : base(image)
            {
            }
        }
    }
}
