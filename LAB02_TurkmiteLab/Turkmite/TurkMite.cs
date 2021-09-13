using OpenCvSharp;
using System;

namespace TurkMite
{
    class TurkMite
    {
        private int x;
        private int y;
        private int direction { get; set; }  // 0 up, 1 right, 2 down, 3 left
        //this will be constant because it will never modified.
        private readonly Vec3b black = new Vec3b(0, 0, 0);
        private readonly Vec3b white = new Vec3b(255, 255, 255);

        public Mat Image { get; }
        private Mat.Indexer<Vec3b> indexer;
        public TurkMite()
        {
            Image = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            indexer = Image.GetGenericIndexer<Vec3b>();
            x = Image.Cols / 2;
            y = Image.Rows / 2;
            direction = 0;
        }

        public void Run()
        {
            for (int i = 0; i < 13000; i++)
            {
                Vec3b currentColor = indexer[y, x];

                (int deltaDirection, Vec3b newColor) = Step(currentColor);
                direction += deltaDirection;
                indexer[y, x] = newColor;

                direction = (direction + 4) % 4;

                var delta = new (int x, int y)[] { (0, -1), (1, 0), (0, 1), (-1, 0) };
                x += delta[direction].x;
                y += delta[direction].y;

                x = Math.Max(0, Math.Min(x, Image.Cols - 1));
                y = Math.Max(0, Math.Min(y, Image.Rows - 1));

            }
        }

        private (int deltaDirection, Vec3b newColor) Step(Vec3b currentColor)
        {
            if (currentColor == black)
            {
                return (1, white);
            }
            else
            {
                return (-1, black);
            }
        }
    }
}
