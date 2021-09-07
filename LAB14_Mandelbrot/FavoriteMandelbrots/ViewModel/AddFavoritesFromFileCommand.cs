using FavoriteMandelbrots.Model;
using System;
using System.IO;
using System.Xml.Linq;
using Windows.Storage;

namespace FavoriteMandelbrots.ViewModel
{
    public class AddFavoritesFromFileCommand : CommandBase
    {
        private readonly Action<Area> addAction;

        public AddFavoritesFromFileCommand(MainViewerViewModel vm, Action<Area> addAction)
            : base(vm)
        {
            this.addAction = addAction;
        }

        public async override void Execute(object parameter)
        {
        }
    }
}