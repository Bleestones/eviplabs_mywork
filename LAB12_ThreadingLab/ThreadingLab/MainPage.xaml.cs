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

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            EventList.Items.Add("Start clicked");
            var progressReporter = new Progress<int>(percent => this.ProgressBar.Value = percent);
            var slowBackgroundProcessor = new SlowBackgroundProcessor(this.EventList);
            slowBackgroundProcessor.DoIt(progressReporter);
            EventList.Items.Add("Start finished");
        }

        class SlowBackgroundProcessor
        {
            private ListBox eventList;

            public SlowBackgroundProcessor(ListBox eventList)
            {
                this.eventList = eventList;
            }

            public void DoIt(IProgress<int> progress)
            {
                for (int i = 0; i <= 100; i += 10)
                {
                    Task.Delay(500).Wait();
                    progress.Report(i);
                }
            }
        }
    }
}
