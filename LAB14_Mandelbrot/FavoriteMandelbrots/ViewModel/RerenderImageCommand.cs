using System;
using System.Windows.Input;

namespace FavoriteMandelbrots.ViewModel
{
    // Re-renders the CurrentImage matching the current zoom window.
    public class RerenderImageCommand : CommandBase
    {
        public RerenderImageCommand(MainViewerViewModel mainViewerViewModel) : base(mainViewerViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            vm.RenderCurrentImage(vm.CurrentArea);
        }
    }
}
