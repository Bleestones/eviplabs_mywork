using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DrawingAndShapesDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShapeStackPanel.Children.Add(
                new Rectangle()
                {
                    Width = 20,
                    Height = 50,
                    Fill = new SolidColorBrush(Colors.Red)
                });


            var rect = new Rectangle()
            {
                Width = 140,
                Height = 20,
                Fill = new SolidColorBrush(Colors.Red),
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 3
            };
            MyCanvas.Children.Add(rect);
            // EVIP: Setting attached property from code
            Canvas.SetLeft(rect, 80);
            Canvas.SetTop(rect, 150);

            // EVIP: Adding polyline from code
            // EVIP: Without setting the position of the Polyline,
            //  we can use "absoulte" locations to define its points.
            var p = new Polygon()
            {
                Fill = new SolidColorBrush(Colors.Red),
                Stroke = new SolidColorBrush(Colors.Black)
            };
            p.Points.Add(new Point(100, 10));
            p.Points.Add(new Point(80, 10));
            p.Points.Add(new Point(80, 100));
            p.Points.Add(new Point(90, 100));
            p.Points.Add(new Point(90, 20));
            p.Points.Add(new Point(100, 20));

            MyCanvas.Children.Add(p);
            //Canvas.SetLeft(p, 0); // We could set other location...
            //Canvas.SetTop(p, 0);
        }
    }
}
