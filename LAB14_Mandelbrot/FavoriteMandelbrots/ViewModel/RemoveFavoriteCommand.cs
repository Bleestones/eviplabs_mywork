using FavoriteMandelbrots.Model;
using FavoriteMandelbrots.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavoriteMandelbrots.ViewModel
{
    public class RemoveFavoriteCommand : CommandBase
    {
        public RemoveFavoriteCommand(MainViewerViewModel vm) : base(vm)
        {
        }

        public async override void Execute(object parameter)
        {
            AreaViewModel selectedVM = (AreaViewModel)parameter;
            if (selectedVM != null)
                vm.Favorites.Remove(selectedVM);
            else
            {
                var m = new Windows.UI.Popups.MessageDialog("Select the favorite to remove first...");
                await m.ShowAsync();
            }
        }
    }
}
