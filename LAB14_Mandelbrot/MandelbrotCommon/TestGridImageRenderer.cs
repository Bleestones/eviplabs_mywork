using System;
using System.Linq;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;

namespace MandelbrotCommon
{
    public class TestGridImageRenderer : ImageRendererBase
    {
        public override WriteableBitmap RenderDefault()
        {
            return Render(new Complex(-1.0F, -1.0F), new Complex(1.0F, 1.0F),
                1000, 1000);
        }

        protected override void Render(WriteableBitmap image)
        {
            // EVIP: Linq to render pixel colors in parallel.
            image.GetAllPixelLocations().AsParallel()
                .Select(p => ToScaledComplex(p))
                .Select(c => GetGridColor(c))
                .SetPixels(image);
        }

        // Note: pixel color is either black or gray depending on the location.
        private (Point p, Color c) GetGridColor((Point p, Complex c) input)
        {
            double re = input.c.Real * 5.0;
            double im = input.c.Imaginary * 5.0;
            double roundedRe = Math.Round(re);
            double roundedIm = Math.Round(im);
            if (Math.Abs(re - roundedRe) < 0.01
                || Math.Abs(im - roundedIm) < 0.01)
                return (input.p, Colors.Black);
            return (input.p, Colors.LightGray);
        }
    }
}
