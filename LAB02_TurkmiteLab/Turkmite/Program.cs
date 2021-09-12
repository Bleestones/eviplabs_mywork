using OpenCvSharp;

namespace TurkMite
{
    class Program
    {
        static void Main()
        {
            Mat img = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            var indexer = img.GetGenericIndexer<Vec3b>();
            int x = 100;
            int y = 100;
            int direction = 0;  // 0 up, 1 right, 2 down, 3 left
            Vec3b black = new Vec3b(0, 0, 0);
            Vec3b white = new Vec3b(255, 255, 255);
            for(int i=0; i<13000; i++)
            {
                Vec3b currentColor = indexer[y, x];
                if (currentColor == black)
                {
                    indexer[y, x] = white;
                    direction++;
                }
                else
                {
                    indexer[y, x] = black;
                    direction--;
                }

                direction = (direction + 4) % 4;

                switch(direction)
                {
                    case 0:
                        y--;
                        break;
                    case 1:
                        x++;
                        break;
                    case 2:
                        y++;
                        break;
                    case 3:
                        x--;
                        break;
                }
                if (x < 0)
                    x = 199;
                if (x > 199)
                    x = 0;
                if (y < 0)
                    y = 199;
                if (y > 199)
                    y = 0;
            }
            Cv2.ImShow("TurkMite", img);
            Cv2.WaitKey();
        }
    }
}
