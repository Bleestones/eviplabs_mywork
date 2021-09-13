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
            Assert.Equal(5, turkmite.X);
            Assert.Equal(4, turkmite.Y);
            Assert.Equal(0, turkmite.D);
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
