using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ZH2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public DataModel DataModel { get; set; }
        public ButtonCommand ButtonCommand { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            DataModel = new DataModel();
            ButtonCommand = new ButtonCommand();
            DataModel.FillBrush = new SolidColorBrush(Colors.Yellow);
        }
    }
}
