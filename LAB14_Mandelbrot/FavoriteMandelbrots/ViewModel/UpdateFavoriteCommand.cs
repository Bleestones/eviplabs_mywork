using System;

namespace FavoriteMandelbrots.ViewModel
{
    public class UpdateFavoriteCommand : CommandBase
    {
        public UpdateFavoriteCommand(MainViewerViewModel mainViewerViewModel)
            : base(mainViewerViewModel)
        {
        }

        // Parameter: currently selected favorite (vm)
        public async override void Execute(object parameter)
        {
            // Update the currently selected favorite based on the current
            //  zoom window.
            AreaViewModel selectedVM = (AreaViewModel)parameter;
            if (selectedVM != null)
                selectedVM.UpdateModel(vm.CurrentArea);
            else
            {
                var m = new Windows.UI.Popups.MessageDialog("Select the favorite to update first...");
                await m.ShowAsync();
            }
        }
    }
}
