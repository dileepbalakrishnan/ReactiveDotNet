using System;
using System.Linq;
using System.Reactive.Linq;

namespace HelloRx
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var query = "Hello, Rx.Net!".Select(c => c.ToString() + " ").ToObservable();
            query.Subscribe(Console.Write, OnCompleted);
        }

        private static void OnCompleted()
        {
            Console.WriteLine();
            Console.WriteLine("Done");
        }
    }
}