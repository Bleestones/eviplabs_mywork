using FavoriteMandelbrots.ViewModel;
using Windows.UI.Xaml.Controls;

namespace FavoriteMandelbrots.View
{
    public sealed partial class MainViewer : UserControl
    {
        private MainViewerViewModel viewModel;
        public MainViewer()
        {
            // Initialize view model and model.
            viewModel = new MainViewerViewModel(this);

            this.InitializeComponent();

            // EVIP: event in the view model needs to be handled in the view.
            //  Reason: viewport of the ScrollViewer needs to be reset to cover the full image.
            viewModel.CurrentImageRerendered += ViewModel_CurrentImageRerendered;
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            // View model needs to known where the current viewport (visible part of the image) is.
            double x = ScrollViewer.HorizontalOffset;
            double y = ScrollViewer.VerticalOffset;
            double w = ScrollViewer.ViewportWidth;
            double h = ScrollViewer.ViewportHeight;
            double z = ScrollViewer.ZoomFactor;
            viewModel.UpdateCurrentArea(x, y, w, h, z);
        }

        private void ViewModel_CurrentImageRerendered()
        {
            // Note: Image and ScrollView are both squares
            double zoomFactor = ScrollViewer.Width / viewModel.CurrentImage.PixelWidth;
            ScrollViewer.ChangeView(0.0, 0.0, (float)zoomFactor);
        }

        private void UserControl_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // EVIP: Loaded event fired after everything is created and initialized.
            //  If we would try to render the image earlier (in ctor), the ScrollViewer and thus the
            //  MainViewerViewModel.CurrentArea is not property initialized to know which part of the
            //  Mandelbrot set to render.
            this.viewModel.RerenderImageCommand.Execute(null);
        }
    }
}
