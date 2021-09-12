using OpenCvSharp;

namespace TurkMite
{
    class Program
    {
        static void Main(string[] args)
        {
            var turkmite = new TurkMite();
            turkmite.Run();
            Cv2.ImShow("TurkMite", turkmite.Image);
            Cv2.WaitKey();
        }
    }
}
