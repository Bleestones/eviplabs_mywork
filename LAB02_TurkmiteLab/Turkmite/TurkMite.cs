﻿using OpenCvSharp;
using System;

namespace TurkMite
{
    class TurkMite
    {
        private int x;
        private int y;
        private readonly (int x, int y)[] delta;
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

        private Vec3b GetNextColorAndUpdateDirection(Vec3b currentColor)
        {
            if (currentColor == black)
            {
                direction++;
                return white;
            }
            else
            {
                direction--;
                return black;
            }
        }
    }
}
