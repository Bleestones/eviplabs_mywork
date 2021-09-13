using OpenCvSharp;

namespace TurkMite
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat img = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            var turkmite = new OriginalTurkmite(img);
            for(int i = 0; i < 13000; i++)
                turkmite.Step();
            Cv2.ImShow("TurkMite", turkmite.Image);
            Cv2.WaitKey();
        }
    }
}
