using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainThread = Thread.CurrentThread;
            Console.WriteLine($"Главный поток = {mainThread.ManagedThreadId}");

            //   Parallel.Invoke(new ParallelOptions() {MaxDegreeOfParallelism = 1 }, ParallelMethod, ParallelMethod, ParallelMethod, ()=> { Console.WriteLine("Начало X"); Console.WriteLine("Окончание X"); });

            //var result = Parallel.For(0, 10, (i, state) =>
            //{
            //    if (i > 5) state.Break();
            //    else ParallelMethod(i);
            //});

            //Console.WriteLine($"Метод был выполнен: {result.LowestBreakIteration} раз");

            var list = Enumerable.Range(0, 100).Select(i => $"Message {i}");

            var messages = list.Where(i => i.EndsWith("0"));

            var count = list
                .AsParallel()
                .WithDegreeOfParallelism(1)
                .Where(message =>
            {
                ParallelMethod(message);
                return (message.EndsWith("0"));
            }).Count();

            Console.WriteLine($"count = {count}");

            //  Parallel.ForEach(messages, listEl => ParallelMethod(listEl));


            Console.ReadLine();
        }

        static void ParallelMethod(string text)
        {
            var t = Thread.CurrentThread;
            Console.WriteLine($"Метод запущен из потока {t.ManagedThreadId}, text={text}");
            Thread.Sleep(20);
            Console.WriteLine($"Метод завершен в потоке {t.ManagedThreadId}, text={text}");
        }
        static void ParallelMethod(int i)
        {
            var t = Thread.CurrentThread;
            Console.WriteLine($"Метод запущен из потока {t.ManagedThreadId}, i={i}");
            Thread.Sleep(200);
            Console.WriteLine($"Метод завершен в потоке {t.ManagedThreadId}, i={i}");
        }
    }
}
