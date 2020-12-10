using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainThread = Thread.CurrentThread;
            Console.WriteLine($"Главный поток = {mainThread.ManagedThreadId}");

            //var task = new Task(ParallelMethod);
            //task.Start();

            var task = Task.Run(()=>
            {
                ParallelMethod();
            });



            Console.WriteLine("Перед wait");
            task.Wait();
            Console.WriteLine("После wait");

            task.ContinueWith(o =>
            {
                Console.WriteLine("После вызова метода");
            });

            Console.ReadLine();
        }

        static void ParallelMethod()
        {
            var t = Thread.CurrentThread;
            Console.WriteLine($"Метод запущен из потока {t.ManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine($"Метод завершен в потоке {t.ManagedThreadId}");
        }
    }
}
