using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Media;

namespace ZH2
{
    public class DataModel : INotifyPropertyChanged
    {
        private bool colorChangeEnabled;

        public bool ColorChangeEnabled
        {
            get { return colorChangeEnabled; }
            set 
            { 
                if(colorChangeEnabled != value)
                {
                    colorChangeEnabled = value;
                    Notify();
                }
            }
        }

        private Brush fillBrush;

        public event PropertyChangedEventHandler PropertyChanged;

        public Brush FillBrush
        {
            get { return fillBrush; }
            set 
            { 
                if(fillBrush != value)
                {
                    fillBrush = value;
                    Notify();
                }
            }
        }

        protected void Notify([CallerMemberName] string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
