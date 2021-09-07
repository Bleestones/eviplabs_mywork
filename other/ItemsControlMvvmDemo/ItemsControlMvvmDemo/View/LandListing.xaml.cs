using ItemsControlMvvmDemo.ViewModel;
using Windows.UI.Xaml.Controls;

namespace ItemsControlMvvmDemo.View
{
    public sealed partial class LandListing : UserControl
    {
        public LandViewModel[] Lands { get; set; }
        public LandListing()
        {
            this.InitializeComponent();
        }
    }
}
