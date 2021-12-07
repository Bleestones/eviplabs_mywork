using System;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace ZH2
{
    public class ButtonCommand : ICommand
    {
        private readonly SolidColorBrush colorGreen = new SolidColorBrush(Colors.Green);
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            DataModel dataModel = (DataModel)parameter;
            if(dataModel.ColorChangeEnabled)
            {
                dataModel.FillBrush = colorGreen;
            }
        }
    }
}
