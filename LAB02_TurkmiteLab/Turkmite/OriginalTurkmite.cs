using OpenCvSharp;

namespace TurkMite
{
    public class OriginalTurkmite : TurkmiteBase
    {
        readonly protected Vec3b black = new Vec3b(0, 0, 0);
        readonly protected Vec3b white = new Vec3b(255, 255, 255);

        public OriginalTurkmite(Mat image) : base(image)
        {
        }

        public override int PreferredIterationCount => 13000;

        protected override (Vec3b newColor, int deltaDirection) GetNextColorAndUpdateDirection(Vec3b currentColor)
        {
            return (currentColor == black) ? (white, 1) : (black, -1);
        }
    }
}
