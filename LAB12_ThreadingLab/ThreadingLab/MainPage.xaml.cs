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
        private CancellationTokenSource cancellationTokenSource;
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
            cancellationTokenSource.Cancel(true);
            cancellationTokenSource.Dispose();
        }

        private async void Start_ClickAsync(object sender, RoutedEventArgs e)
        {
            EventList.Items.Add("Start clicked");
            cancellationTokenSource = new CancellationTokenSource();
            var progressReporter = new Progress<int>(percent => this.ProgressBar.Value = percent);
            var progressReporter2 = new Progress<int>(percent => this.ProgressBar2.Value = percent);
            var slowBackgroundProcessor1 = new SlowBackgroundProcessor(this.EventList);
            var slowBackgroundProcessor2 = new SlowBackgroundProcessor(null);
            try
            {
                await Task.Run(() => slowBackgroundProcessor1.DoItAsync(progressReporter, cancellationTokenSource.Token))
                            .ContinueWith(sbp2 => slowBackgroundProcessor2.DoItAsync(progressReporter2), TaskContinuationOptions.NotOnCanceled);
            }
            catch (OperationCanceledException)
            {
                EventList.Items.Add("Process cancelled!");
            }
            EventList.Items.Add("Start finished");
        }

        class SlowBackgroundProcessor
        {
            private ListBox eventList;

            public SlowBackgroundProcessor(ListBox eventList)
            {
                this.eventList = eventList;
            }

            public async Task DoItAsync(IProgress<int> progress, CancellationToken token = default(CancellationToken))
            {
                for (int i = 0; i <= 100; i += 10)
                {
                    Task.Delay(500).Wait();
                    if (token.IsCancellationRequested)
                    {
                        throw new OperationCanceledException();
                    }
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
