using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;

namespace RepeatAndTakeDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // This should print 1 five times with an inetraval of 250ms between two prints
            Enumerable.Range(1, 1).ToObservable().Repeat().Take(5).Subscribe(x =>
            {
                Thread.Sleep(250);
                Console.WriteLine(x);
            });
        }
    }
}