using System;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace UwpBindingAndCommandDemo
{
    class IncreaseCommand : ICommand
    {
        Counters model;

        public IncreaseCommand(Counters dataModel)
        {
            model = dataModel;
            model.PropertyChanged += Model_PropertyChanged;
        }

        private void Model_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !(model.CounterA > 5);
        }

        public void Execute(object parameter)
        {
            model.CounterA++;
        }
    }

    class Counters : INotifyPropertyChanged
    {
        private int counterA;
        public int CounterA
        {
            get => counterA;
            set
            {
                if (counterA != value)
                {
                    counterA = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(CounterA)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    class Counter2ColorConverter : IValueConverter
    {
        private readonly SolidColorBrush brown =
            new SolidColorBrush(Colors.SandyBrown);
        private readonly SolidColorBrush blue =
            new SolidColorBrush(Colors.LightSteelBlue);

        public object Convert(object value, Type targetType,
            object parameter, string language)
        {
            int counter = (int)value;
            return counter < 3 ? brown : blue;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public sealed partial class MainPage : Page
    {
        IncreaseCommand IncCommand;
        Counters CountersModel;

        public MainPage()
        {
            this.InitializeComponent();
            CountersModel = new Counters();
            IncCommand = new IncreaseCommand(CountersModel);
        }
    }
}
