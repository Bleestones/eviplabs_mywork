using Xunit;
using TurkMite;
using OpenCvSharp;

namespace TurkmiteTests
{
    public class TurkmiteBaseTests
    {
        private TestTurkmiteBase turkmite = new TestTurkmiteBase(new Mat(10, 10, MatType.CV_8UC3));
        [Fact]
        public void GetNextColorAndUpdateDirection_IsCalled()
        {
            turkmite.Step();
            Assert.True(turkmite.GetNextColorAndUpdateDirectionInvoked);
        }

        [Fact]
        public void PerformMove_DirectionCorrect()
        {
            turkmite.X = 5;
            turkmite.Y = 5;
            turkmite.D = 0; //up
            turkmite.PerformMove(0);
            AssertTurkmiteState(5, 4, 0);
            turkmite.PerformMove(1);
            AssertTurkmiteState(6, 4, 1);
            turkmite.PerformMove(1);
            AssertTurkmiteState(6, 5, 2);
            turkmite.PerformMove(1);
            AssertTurkmiteState(5, 5, 3);
            turkmite.PerformMove(1);
            AssertTurkmiteState(5, 4, 0);
            turkmite.PerformMove(-1);
            AssertTurkmiteState(4, 4, 3);
        }

        [Fact]
        public void ImageBoundaryWorks()
        {
            AssertMove(5, 0, 0, 5, 0);
            AssertMove(5, 9, 2, 5, 9);
            AssertMove(9, 5, 1, 9, 5);
            AssertMove(0, 5, 3, 0, 5);
        }

        private void AssertMove(int startX, int startY, int direction, int finalX, int finalY)
        {
            turkmite.X = startX;
            turkmite.Y = startY;
            turkmite.D = direction;
            turkmite.PerformMove(0);
            AssertTurkmiteState(finalX, finalY, direction);
        }

        private void AssertTurkmiteState(int x, int y, int d)
        {
            Assert.Equal(x, turkmite.X);
            Assert.Equal(y, turkmite.Y);
            Assert.Equal(d, turkmite.D);
        }

        //test class
        class TestTurkmiteBase : TurkmiteBase
        {
            public int X { get { return this.x; } set { this.x = value; } }
            public int Y { get { return this.y; } set { this.y = value; } }
            public int D { get { return this.direction; } set { this.direction = value; } }

            public TestTurkmiteBase(Mat img) : base(img)
            {
            }

            public bool GetNextColorAndUpdateDirectionInvoked = false;

            protected override (Vec3b newColor, int deltaDirection) GetNextColorAndUpdateDirection(Vec3b currentColor)
            {
                // Mocked to monitor invocation
                GetNextColorAndUpdateDirectionInvoked = true;
                return (new Vec3b(0, 0, 0), 0);
            }
            public new void PerformMove(int deltaDirection)
            {
                base.PerformMove(deltaDirection);
            }

            public override int PreferredIterationCount => 0;
        }
    }
}
