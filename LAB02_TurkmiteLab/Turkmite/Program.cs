using OpenCvSharp;

namespace TurkMite
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat img = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            //var turkmite = new OriginalTurkmite(img);
            var turkmite = new LabTurkmite(img);
            for(int i = 0; i < turkmite.PreferredIterationCount; i++)
                turkmite.Step();
            Cv2.ImShow("TurkMite", turkmite.Image);
            Cv2.WaitKey();
        }
    }
}
