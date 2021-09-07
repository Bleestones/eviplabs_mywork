using System.Diagnostics;
using System.Numerics;
using Windows.Foundation;
using Windows.UI.Xaml.Media.Imaging;

namespace MandelbrotCommon
{
    // EVIP: Base class for everything which can render an image from a rectangle in the complex plane.
    // EVIP: Method (Render) in base class calls abstract method in derived class.
    public abstract class ImageRendererBase
    {
        public WriteableBitmap Render(Complex topLeft, Complex bottomRight, int width, int height)
        {
            WriteableBitmap image = new WriteableBitmap(width, height);
            // EVIP: using Complex to represent complex numbers.
            this.topLeft.X = (float)topLeft.Real;
            this.topLeft.Y = (float)topLeft.Imaginary;
            this.bottomRight.X = (float)bottomRight.Real;
            this.bottomRight.Y = (float)bottomRight.Imaginary;
            this.imageSize.Width = width;
            this.imageSize.Height = height;

            // EVIP: StopWatch for performance evaluation
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Render(image);  // This is implemented in subclasses.
            // EVIP: Debug.WriteLine: writing to the Output window from UWP apps.
            Debug.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds}ms");
            return image;
        }

        // This is meant to perform the true rendering into a given bitmap.
        protected abstract void Render(WriteableBitmap image);

        protected Size imageSize;
        protected Point topLeft;
        protected Point bottomRight;

        // For demo purpuses, one can ask for a default image. This depends on the implementation,
        //  for example where a nice part of the Mandelbrot set lies.
        public abstract WriteableBitmap RenderDefault();

        // Helper method to convert image location to image location + complex number in Linq expressions
        protected (Point p, Complex c) ToScaledComplex(Point p)
        {
            double wComplex = bottomRight.X - topLeft.X;
            double wImg = imageSize.Width;
            double hComplex = bottomRight.Y - topLeft.Y;
            double hImg = imageSize.Height;
            double re = topLeft.X + (p.X / wImg) * wComplex;
            double im = topLeft.Y + (p.Y / hImg) * hComplex;
            return (p, new Complex(re, im));
        }
    }
}