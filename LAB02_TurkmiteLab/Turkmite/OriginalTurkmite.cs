using OpenCvSharp;

namespace TurkMite
{
    class OriginalTurkmite : TurkmiteBase
    {
        readonly private Vec3b black = new Vec3b(0, 0, 0);
        readonly private Vec3b white = new Vec3b(255, 255, 255);

        public OriginalTurkmite(Mat image) : base(image)
        {
        }

        protected override Vec3b GetNextColorAndUpdateDirection(Vec3b currentColor)
        {
            if (currentColor == black)
            {
                direction++;
                return white;
            }
            else
            {
                direction--;
                return black;
            }
        }
    }
}
