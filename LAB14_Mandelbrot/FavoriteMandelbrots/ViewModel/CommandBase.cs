using System;
using System.Windows.Input;

namespace FavoriteMandelbrots.ViewModel
{
    public abstract class CommandBase : ICommand
    {
        protected readonly MainViewerViewModel vm;
        public CommandBase(MainViewerViewModel vm)
        {
            this.vm = vm;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        // EVIP: default interface method in base class.
        //  Other solution appears in C# 8.0 as interface defaults.
        public bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);
    }
}
