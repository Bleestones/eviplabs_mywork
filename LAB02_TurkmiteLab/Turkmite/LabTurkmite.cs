using OpenCvSharp;

namespace TurkMite
{
    public class LabTurkmite : TurkmiteBase
    {
        readonly protected Vec3b black = new Vec3b(0, 0, 0);
        readonly protected Vec3b red = new Vec3b(0, 0, 255);
        readonly protected Vec3b yellow = new Vec3b(0, 255, 255);
        protected int internalCounter {get; set;}

        public override int PreferredIterationCount => 30000;

        protected override (Vec3b newColor, int deltaDirection) GetNextColorAndUpdateDirection(Vec3b currentColor)
        {
            if (currentColor == black)
                internalCounter++;
            return (currentColor == red) ? (yellow, 3) : ((currentColor == yellow) ? (black, 1) : ((IsInternalCounterAndUpdateEven()) ? (red, 3) : (yellow, 3)));
        }

        public LabTurkmite(Mat image) : base(image)
        {
            internalCounter = 0;
        }

        private bool IsInternalCounterAndUpdateEven()
        {
            return (internalCounter % 2 == 0) ? (true) : (false);
        }
    }
}
