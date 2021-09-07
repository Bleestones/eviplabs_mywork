using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace DataBindingLab.ViewModel
{
    public class IsExpense2ColorConverter : IValueConverter
    {
        private readonly SolidColorBrush red = new SolidColorBrush(Colors.Red);
        private readonly SolidColorBrush green = new SolidColorBrush(Colors.Green);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isExpense = (bool)value;
            return isExpense ? red : green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
