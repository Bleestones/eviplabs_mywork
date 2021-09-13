using OpenCvSharp;
using System;

namespace TurkMite
{
    abstract class TurkmiteBase
    {
        public Mat Image { get; }
        private Mat.Indexer<Vec3b> indexer;
        private int x;
        private int y;
        private readonly (int x, int y)[] delta;
        protected int direction { get; set; }  // 0 up, 1 right, 2 down, 3 left

        public TurkmiteBase(Mat image)
        {
            indexer = image.GetGenericIndexer<Vec3b>();
            x = Image.Cols / 2;
            y = Image.Rows / 2;
            direction = 0;
            delta = new (int x, int y)[] { (0, -1), (1, 0), (0, 1), (-1, 0) };
        }

        public void Step()
        {
            indexer[y, x] = GetNextColorAndUpdateDirection(indexer[y,x]);
            PerformMove();
        }

        private void PerformMove()
        {
            direction = (direction + 4) % 4;
            x += delta[direction].x;
            y += delta[direction].y;
            x = Math.Max(0, Math.Min(x, Image.Cols - 1));
            y = Math.Max(0, Math.Min(y, Image.Rows - 1));
        }

        protected abstract Vec3b GetNextColorAndUpdateDirection(Vec3b currentColor);
    }
}
