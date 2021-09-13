using OpenCvSharp;

namespace TurkMite
{
    class Program
    {
        static void Main(string[] args)
        {
            var turkmite = new TurkMite();
            for(int i = 0; i < 13000; i++)
                turkmite.Step();
            Cv2.ImShow("TurkMite", turkmite.Image);
            Cv2.WaitKey();
        }
    }
}
