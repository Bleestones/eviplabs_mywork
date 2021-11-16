using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
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
            var progressReporter2 = new Progress<int>(percent => this.ProgressBar2.Value = percent);
            var slowBackgroundProcessor1 = new SlowBackgroundProcessor(this.EventList);
            var slowBackgroundProcessor2 = new SlowBackgroundProcessor(null);
            await Task.Run(() => slowBackgroundProcessor1.DoItAsync(progressReporter).ContinueWith(sbp2 => slowBackgroundProcessor2.DoItAsync(progressReporter2)));
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
                    Task.Delay(500).Wait();
                    progress.Report(i);
                    if (eventList != null)
                    {
                        await eventList.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            eventList.Items.Add($"SlowBackgroundProcessor <PJYRWJ> is at {i}percent.");
                        });
                    }
                }
            }
        }
    }
}
