using MandelbrotCommon;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ShowFixedMandelbrot
{
    // EVIP: application using the MandelbrotCommon class library. Almost everything is in the library as reuseable components.
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // EVIP: simple, good old event handler. No command pattern.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // EVIP: ImageRendererBase allows alternate
            //  implementations for testing purposes
            ImageRendererBase renderer = new Mandelbrot();
            //ImageRendererBase renderer = new TestGridImageRenderer();
            Image.Source = renderer.RenderDefault();
        }
    }
}
