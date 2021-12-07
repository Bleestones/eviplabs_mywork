using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace ZH2
{
    public class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            DataModel dataModel = (DataModel)parameter;
            if(dataModel.ColorChangeEnabled)
            {
                dataModel.FillBrush = new SolidColorBrush(Colors.Green);
            }
        }
    }
}
