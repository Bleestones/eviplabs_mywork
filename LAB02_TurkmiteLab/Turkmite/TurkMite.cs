using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkMite
{
    class TurkMite
    {
        private int x = 100;
        private int y = 100;
        private int direction = 0;  // 0 up, 1 right, 2 down, 3 left
        //this will be constant because it will never modified.
        private readonly Vec3b black = new Vec3b(0, 0, 0);
        private readonly Vec3b white = new Vec3b(255, 255, 255);

        public Mat Image { get; }
        private Mat.Indexer<Vec3b> indexer;
        public TurkMite()
        {
            Image = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            indexer = Image.GetGenericIndexer<Vec3b>();
        }

        public void Run()
        {
            for (int i = 0; i < 13000; i++)
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

                var delta = new (int x, int y)[] { (0, -1), (1, 0), (0, 1), (-1, 0) };
                x += delta[direction].x;
                y += delta[direction].y;

                x = Math.Max(0, Math.Min(x, Image.Cols - 1));
                y = Math.Max(0, Math.Min(y, Image.Rows - 1));

            }
        }
    }
}
