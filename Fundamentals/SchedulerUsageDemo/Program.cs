using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;

namespace SchedulerUsageDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"Application Thread - {Thread.CurrentThread.ManagedThreadId}");
            "Hello World".ToObservable(Scheduler.Default).Subscribe(
                s =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Thread - {Thread.CurrentThread.ManagedThreadId}, Value - {s}");
                },
                exception =>
                {
                    Console.WriteLine($"Thread - {Thread.CurrentThread.ManagedThreadId}");
                },
                () =>
                {
                    Console.WriteLine($"Thread - {Thread.CurrentThread.ManagedThreadId}, Completed.");
                }
            );
            Console.ReadLine();
        }
    }
}