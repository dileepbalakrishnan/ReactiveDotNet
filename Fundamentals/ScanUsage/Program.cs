using System;
using System.Reactive.Linq;

namespace ScanUsage
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}.ToObservable().Scan((x, y) => x + y).Subscribe(Console.WriteLine);
        }
    }
}