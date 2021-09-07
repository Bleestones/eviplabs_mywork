using FavoriteMandelbrots.Model;
using FavoriteMandelbrots.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace FavoriteMandelbrots.ViewModel
{
    public class MainViewerViewModel : ObservableObject
    {
        #region Currently shown area
        public WriteableBitmap CurrentImage { get; set; }
        private Area LastRenderedArea;

        public Area CurrentArea { get; set; }

        private readonly Area StartingArea = new Area() { Left = -1.6F, Right = 0.6F, Top = -1.2F, Bottom = 1.2F };

        // EVIP: we need this as we cannot send PropertyChanged event for a property inside CurrentArea.
        public string AreaAsText => CurrentArea.AsString;
        #endregion

        #region Favorites management
        public ObservableCollection<AreaViewModel> Favorites { get; set; }
            = new ObservableCollection<AreaViewModel>();

        // EVIP: Commands to bind to.
        public AddToFavoritesCommand AddToFavoritesCommand { get; set; }
        public UpdateFavoriteCommand UpdateFavoriteCommand { get; set; }
        public SaveFavoritesCommand SaveFavoritesCommand { get; set; }
        public AddFavoritesFromFileCommand AddFavoritesFromFileCommand { get; set; }
        #endregion

        public MainViewerViewModel(MainViewer viewer)
        {
            // Add starting area to the list of favorites
            Favorites = new ObservableCollection<AreaViewModel>();
            var startingAreaVm = new AreaViewModel(StartingArea.Clone(), this);
            Favorites.Add(startingAreaVm);
            startingAreaVm.NotifyAllPropertiesChanged();

            // Create remaining parts of view model
            AddToFavoritesCommand = new AddToFavoritesCommand(this);
            UpdateFavoriteCommand = new UpdateFavoriteCommand(this);
            RerenderImageCommand = new RerenderImageCommand(this);
            SaveFavoritesCommand = new SaveFavoritesCommand(this);

            // EVIP: ICommand which needs an Action<> to be set, so it can use it during its execution.
            // Note: We need to provide the method to add an Area to the favorites list.
            //  Example for providing an action (to invoke for all loaded elements) as a constructor parameter
            //  of type Action<Area>.
            AddFavoritesFromFileCommand = new AddFavoritesFromFileCommand(this, AddToFavoritesCommand.Add);

            // EVIP: Cloning to avoid manipulation of
            //  the same instance from many points.
            CurrentArea = StartingArea.Clone();
            // Note: After cloning, we need to subscribe to the event of the new instance.
            CurrentArea.PropertyChanged += CurrentArea_PropertyChanged;
        }

        private void CurrentArea_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify(nameof(CurrentArea));
            // We need to notify the views about the change in AreaAsText,
            //  as it depends on CurrentArea
            Notify(nameof(AreaAsText));
        }

        public string DebugViewPortDataString { get; set; } = "pending...";

        internal void UpdateCurrentArea(double x, double y, double w, double h, double zoomFactor)
        {
            // Image coordinates of visible upper left and lower right corners?
            double imageLeft = x / zoomFactor;
            double imageRight = imageLeft + w / zoomFactor;
            double imageTop = y / zoomFactor;
            double imageBottom = imageTop + h / zoomFactor;

            // Complex numbers (mb: Mandelbrot set coordinates) belonding to these image coordinates?
            CurrentArea.Left = ImageX2MandelbrotRe(imageLeft);
            CurrentArea.Right = ImageX2MandelbrotRe(imageRight);
            CurrentArea.Top = ImageY2MandelbrotIm(imageTop);
            CurrentArea.Bottom = ImageY2MandelbrotIm(imageBottom);

            // EVIP: string interpolation
            DebugViewPortDataString = $"TL {x:G4}-{y:G4}, w{w:G4}, h{h:G4}, z{zoomFactor:G4}";
            Notify(nameof(DebugViewPortDataString));
        }

        private double ImageX2MandelbrotRe(double imageX)
        {
            double proportion = imageX / CurrentImageRenderWidth;
            return LastRenderedArea.Left + proportion * (LastRenderedArea.Right - LastRenderedArea.Left);
        }

        private double ImageY2MandelbrotIm(double imageY)
        {
            double proportion = imageY / CurrentImageRenderHeight;
            return LastRenderedArea.Top + proportion * (LastRenderedArea.Bottom - LastRenderedArea.Top);
        }

        #region Re-rendering CurrentImage based on view window (given as Favorite)
        public RerenderImageCommand RerenderImageCommand { get; set; }

        // EVIP: Constant attributes to avoid hardwired and redundant
        //  (and hard-to-read) numeric constants throughout the code.
        public const int CurrentImageRenderWidth = 1000;
        public const int CurrentImageRenderHeight = 1000;

        internal void RenderCurrentImage(Area favorite)
        {
            LastRenderedArea = CurrentArea.Clone();
            CurrentImage = LastRenderedArea.Render(
                CurrentImageRenderWidth, CurrentImageRenderHeight);
            Notify(nameof(CurrentImage));
            // Notify others in case they want to do something, like
            //  resetting a ScrollViewer which we should not know about here.
            CurrentImageRerendered?.Invoke();
        }

        // EVIP: defining an event
        // Event fired if the CurrentImage has been rerendered and so the
        //  ScrollViewer needs to be reset to the default position and zoom level.
        public delegate void CurrentImageRerenderedDelegate();
        public event CurrentImageRerenderedDelegate CurrentImageRerendered;
        #endregion
    }
}
