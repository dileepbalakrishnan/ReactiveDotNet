using System;
using System.Reactive;
using System.Reactive.Linq;

namespace ObserverAndObservableDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var observable = "Observable And Observer".ToObservable();
            var observer = Observer.Create<char>(Console.WriteLine);
            observable.Subscribe(observer);
            Console.ReadLine();
        }
    }
}