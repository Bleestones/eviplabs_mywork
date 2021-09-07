using FavoriteMandelbrots.Model;

namespace FavoriteMandelbrots.ViewModel
{
    public class AddToFavoritesCommand : CommandBase
    {
        public AddToFavoritesCommand(MainViewerViewModel vm)
            : base(vm)
        {
        }

        public override void Execute(object parameter)
        {
            Add(vm.CurrentArea.Clone());
        }

        public void Add(Area area)
        {
            var newAreaVM = new AreaViewModel(area, vm);
            vm.Favorites.Add(newAreaVM);
            // Now we need to notify the UI about the new values.
            newAreaVM.NotifyAllPropertiesChanged();
        }
    }
}
