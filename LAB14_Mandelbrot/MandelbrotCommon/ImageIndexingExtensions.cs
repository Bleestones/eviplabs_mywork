using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;

namespace MandelbrotCommon
{
    // EVIP: static class for extension methods
    static class ImageIndexingExtensions
    {
        public static void SetPixels(this IEnumerable<(Point, Color)> values,
            WriteableBitmap image)
        {
            // EVIP: using context of WritableBitmap.
            //  (Otherwise, it will be extremely slow.)
            // EVIP: using and IDisposable
            using (image.GetBitmapContext())
            {
                // EVIP: Tuple and deconstruction
                foreach ((Point p, Color c) in values)
                    image.SetPixel((int)p.X, (int)p.Y, c);
            }
        }

        // EVIP: yield return to create IEnumerable
        // EVIP: Enumerable.Range
        public static IEnumerable<Point> GetAllPixelLocations(int width, int height)
        {
            foreach (int y in Enumerable.Range(0, height - 1))
                foreach (int x in Enumerable.Range(0, width - 1))
                    yield return new Point(x, y);
        }

        // EVIP: alternative parameter list for a polymorph method to make calling side
        //  more compact and readable.
        public static IEnumerable<Point>
            GetAllPixelLocations(this WriteableBitmap image)
        {
            return GetAllPixelLocations(image.PixelWidth, image.PixelHeight);
        }

    }
}
