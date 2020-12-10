using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainThread = Thread.CurrentThread;
            Console.WriteLine($"Главный поток {mainThread.ManagedThreadId}");

            Work();

            Console.ReadLine();
        }

        static async void Work()
        {
            await SomeThingAsync();
        }

        static async Task SomeThingAsync()
        {
            var currThread = Thread.CurrentThread;
            Console.WriteLine($"Перед async потоком {currThread.ManagedThreadId}");

            await Task.Run(()=>
            {
                var mainThread = Thread.CurrentThread;
                Console.WriteLine($"Из async потока {mainThread.ManagedThreadId}");
            });

            Console.WriteLine($"После async потока {currThread.ManagedThreadId}");
        }

    }
}
