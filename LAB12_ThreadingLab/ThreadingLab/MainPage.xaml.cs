using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ThreadingLab
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Blocker_Click(object sender, RoutedEventArgs e)
        {
            Task.Delay(3000).Wait();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
        }

        private async void Start_ClickAsync(object sender, RoutedEventArgs e)
        {
            EventList.Items.Add("Start clicked");
            var progressReporter = new Progress<int>(percent => this.ProgressBar.Value = percent);
            var slowBackgroundProcessor = new SlowBackgroundProcessor(this.EventList);
            await slowBackgroundProcessor.DoItAsync(progressReporter);
            EventList.Items.Add("Start finished");
        }

        class SlowBackgroundProcessor
        {
            private ListBox eventList;

            public SlowBackgroundProcessor(ListBox eventList)
            {
                this.eventList = eventList;
            }

            public async Task DoItAsync(IProgress<int> progress)
            {
                for (int i = 0; i <= 100; i += 10)
                {
                    await Task.Delay(500);
                    progress.Report(i);
                    eventList.Items.Add($"SlowBackgroundProcessor <PJYRWJ> is at {i}percent.");
                }
            }
        }
    }
}
