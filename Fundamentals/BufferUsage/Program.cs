using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;


namespace BufferUsage
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Enumerable.Range(1, 100).ToObservable().Buffer(10).Subscribe(buffer =>
            {
                Console.WriteLine($"Buffer Size is {buffer.Count}");
                foreach (var item in buffer)
                {
                    Console.WriteLine(item);
                }
            });

            Enumerable.Range(1, 100).Select( DoSomeWork).
                ToObservable().Buffer(TimeSpan.FromSeconds(3)).Subscribe(buffer =>
            {
                Console.WriteLine($"Buffer Size is {buffer.Count}");
                foreach (var item in buffer)
                {
                    Console.WriteLine(item);
                }
            });
        }

        private static int DoSomeWork(int i)
        {
            Thread.Sleep(i*10);
            return i;
        }
    }
}