using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;

namespace SimpleConcurrency
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread - {Thread.CurrentThread.ManagedThreadId}");
            var query = "Hello, Rx.Net!".Select(c => c.ToString() + " ").ToObservable(NewThreadScheduler.Default);
            query.Subscribe(HandleItem, OnCompleted);
            Console.ReadLine();
        }

        private static void HandleItem(string item)
        {
            Console.WriteLine($"{item} - {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void OnCompleted()
        {
            Console.WriteLine();
            Console.WriteLine("Done");
        }
    }
}