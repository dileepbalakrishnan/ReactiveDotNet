using System;
using System.Reactive.Linq;

namespace CustomObserver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var observable = Observable.Create<int>(observer =>
            {
                const int a = 10;
                var b = 2;
                try
                {
                    observer.OnNext(a / b);
                    b--;
                    observer.OnNext(a / b);
                    b--;
                    observer.OnNext(a / b);
                    observer.OnCompleted();
                }
                catch (Exception e)
                {
                    observer.OnError(e);
                }
                return () => { };
            });
            observable.Subscribe(Console.WriteLine, e => Console.WriteLine("Error occured : " + e.Message),
                () => Console.WriteLine("Completed."));
            Console.ReadLine();
        }
    }
}