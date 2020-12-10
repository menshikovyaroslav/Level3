using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            //var task = Task.Run(() =>
            //{
            //    return 2 + 2;
            //});

            var t1 = Task.Run(()=>
            {
                var t = Thread.CurrentThread;
                Console.WriteLine($"Метод запущен из потока {t.ManagedThreadId}");
                Thread.Sleep(2000);
                Console.WriteLine($"Метод завершен в потоке {t.ManagedThreadId}");
            });

            var t2 = Task.Run(() =>
            {
                var t = Thread.CurrentThread;
                Console.WriteLine($"Метод запущен из потока {t.ManagedThreadId}");
                Thread.Sleep(1000);
                Console.WriteLine($"Метод завершен в потоке {t.ManagedThreadId}");
            });

            var t3 = Task.Run(() =>
            {
                var t = Thread.CurrentThread;
                Console.WriteLine($"Метод запущен из потока {t.ManagedThreadId}");
                Thread.Sleep(3000);
                Console.WriteLine($"Метод завершен в потоке {t.ManagedThreadId}");
            });

            //     Task.WaitAll(t1, t2, t3);
            var i = Task.WaitAny(t1, t2, t3);

            Console.WriteLine($"Готов {i}");

            //var task = Task.Factory.StartNew(obj => ParallelMethod((string)obj), "Hello world");

            //task.ContinueWith(o =>
            //{
            //    Console.WriteLine($"Метод ContinueWith");
            //}, TaskContinuationOptions.None);

            //        var result = task.Result;
            //       Console.WriteLine(result);

            Console.ReadLine();
        }

        static void ParallelMethod(string text)
        {
            var t = Thread.CurrentThread;
            Console.WriteLine($"Метод запущен из потока {t.ManagedThreadId}, text={text}");

            Thread.Sleep(2000);
            Console.WriteLine($"Метод завершен в потоке {t.ManagedThreadId}, text={text}");
        }
    }
}
