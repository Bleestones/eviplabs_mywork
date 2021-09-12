using OpenCvSharp;
using System;

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

                var delta = new (int x, int y)[] { (0,-1), (1, 0) , (0, 1) , (-1, 0)};
                x += delta[direction].x;
                y += delta[direction].y;

                x = Math.Max(0, Math.Min(x, img.Cols - 1));
                y = Math.Max(0, Math.Min(y, img.Rows - 1));

            }
            Cv2.ImShow("TurkMite", img);
            Cv2.WaitKey();
        }
    }
}
