using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace LAB07_UWP_Basics
{
    /// <summary>
    /// Interaction logic for CoeffUserControl.xaml
    /// </summary>
    public partial class CoeffUserControl : UserControl
    {
        public char CoeffLetter { get; set; }
        public const string CoeffPostfix = " coefficient";
        public string CoeffName { get => CoeffLetter + CoeffPostfix; }

        public event System.EventHandler<KeyRoutedEventArgs> TextBox_KeyDownEv;
        public event System.EventHandler<Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs> Slider_ValueChangedEv;

        public CoeffUserControl(char coeffLetter)
        {
            CoeffLetter = coeffLetter;
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
            => TextBox_KeyDownEv?.Invoke(sender, e);

        private void Slider_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
            => Slider_ValueChangedEv?.Invoke(sender, e);
    }
}
