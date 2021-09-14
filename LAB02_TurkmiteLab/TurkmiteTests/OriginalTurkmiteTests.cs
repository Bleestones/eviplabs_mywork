using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkMite;
using Xunit;

namespace TurkmiteTests
{
    public class OriginalTurkmiteTests
    {
        TestOriginalTurkmite turkmite = new TestOriginalTurkmite(new Mat(10, 10, MatType.CV_8UC3, new Scalar(0, 0, 0)));

        [Fact]
        public void BlackField_Correct()
        {
            var result = turkmite.GetNextColorAndUpdateDirection(turkmite.Black);
            Assert.Equal(turkmite.White, result.newColor);
            Assert.Equal(1, result.deltaDirection);
        }

        [Fact]
        public void WhiteField_Correct()
        {
            var result = turkmite.GetNextColorAndUpdateDirection(turkmite.White);
            Assert.Equal(turkmite.Black, result.newColor);
            Assert.Equal(-1, result.deltaDirection);
        }

        private class TestOriginalTurkmite : OriginalTurkmite
        {
            public new(Vec3b newColor, int deltaDirection) GetNextColorAndUpdateDirection(Vec3b currentColor)
            {
                return base.GetNextColorAndUpdateDirection(currentColor);
            }

            public Vec3b White { get { return white; } }
            public Vec3b Black { get { return black; } }

            public TestOriginalTurkmite(Mat image) : base(image)
            {
            }
        }

    }
}
