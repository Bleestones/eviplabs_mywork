using OpenCvSharp;
using System;

namespace TurkMite
{
    class ThreeColorTurkmite : TurkmiteBase
    {
        readonly private Vec3b black = new Vec3b(0, 0, 0);
        readonly private Vec3b white = new Vec3b(255, 255, 255);
        readonly private Vec3b red = new Vec3b(0, 0, 255);

        public ThreeColorTurkmite(Mat image) : base(image)
        {
        }

        public override int PreferredIterationCount => 500000;

        protected override (Vec3b newColor, int deltaDirection) GetNextColorAndUpdateDirection(Vec3b currentColor)
        {
            return (currentColor == black) ? (white, 1) : ((currentColor == white) ? (red, -1) : (black, -1));
        }
    }
}
