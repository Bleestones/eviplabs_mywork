using FavoriteMandelbrots.Model;
using System;
using System.Windows.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace FavoriteMandelbrots.ViewModel
{
    public class AreaViewModel : ObservableObject
    {
        public AreaViewModel(Area model, MainViewerViewModel mainViewerVM)
        {
            this.Model = model;
            model.PropertyChanged += Model_PropertyChanged;
            ShowCommand = new ShowInMainViewerCommand(model, mainViewerVM);
        }

        // EVIP: Nested class (command not meant to be used elsewhere)
        public class ShowInMainViewerCommand : CommandBase
        {
            public ShowInMainViewerCommand(Area model, MainViewerViewModel mainViewerVM)
                : base(mainViewerVM)
            {
                this.model = model;
            }

            private Area model;

            public override void Execute(object parameter)
            {
                // Should not replace the CurrentArea because that is data-binded to the UI.
                model.CopyTo(vm.CurrentArea);
                vm.RerenderImageCommand.Execute(null);
            }
        }

        public ShowInMainViewerCommand ShowCommand { get; }

        public Area Model { get; private set; }

        public string AsString => Model.AsString;

        internal void UpdateModel(Area newFavorite)
        {
            Model.PropertyChanged -= Model_PropertyChanged;
            Model = newFavorite.Clone();
            Model.PropertyChanged += Model_PropertyChanged;
            // EVIP: all properties may have changed,
            //  so we send notification about all of them.
            NotifyAllPropertiesChanged();
        }

        public void NotifyAllPropertiesChanged()
        {
            Model.NotifyAllPropertiesChanged();
        }

        // EVIP: image for data binding
        public WriteableBitmap Thumbnail { get; set; }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // nameof(): renaming the properties cannot cause inconsistencies.
            Notify(e.PropertyName);
            Notify(nameof(AsString));  // This depends on all others...
            if (e.PropertyName == nameof(Model.Top)
                || e.PropertyName == nameof(Model.Bottom)
                || e.PropertyName == nameof(Model.Left)
                || e.PropertyName == nameof(Model.Right))
                UpdateThumbnail();
        }

        const int thumbnailWidth = 50;
        const int thumbnailHeight = 50;
        private void UpdateThumbnail()
        {
            Thumbnail = Model.Render(thumbnailWidth, thumbnailHeight);
            Notify(nameof(Thumbnail));
        }

    }
}
