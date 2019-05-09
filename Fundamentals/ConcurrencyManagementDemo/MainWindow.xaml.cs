using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Windows;

namespace ConcurrencyManagementDemo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            txtNumbers.Clear();
            Enumerable.Range(1, 20).Select(x =>
                {
                    Thread.Sleep(100);
                    return x.ToString();
                }).ToObservable(NewThreadScheduler.Default).ObserveOn(DispatcherScheduler.Current)
                .Subscribe(x => { txtNumbers.AppendText(x + "\n"); }, () => Console.WriteLine(@"All Done!"));
        }
    }
}