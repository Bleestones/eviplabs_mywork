using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Basics
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            stackPanel.Background = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void colorBtn_Click(object sender, RoutedEventArgs e)
        {
            colorBtn.Foreground = new SolidColorBrush(Windows.UI.Colors.Yellow);
            colorBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkBlue);
        }

        private byte changed = 0;
        private void backgroundBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (changed)
            {
                case 0:
                    {
                        stackPanel.Background = new SolidColorBrush(Windows.UI.Colors.DarkOrange);
                        changed = 1;
                        break;
                    }
                case 1:
                    {
                        stackPanel.Background = new SolidColorBrush(Windows.UI.Colors.Black);
                        changed = 0;
                        break;
                    }
            }
        }
    }
}
