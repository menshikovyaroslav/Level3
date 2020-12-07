using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static Semaphore _semaphore = new Semaphore(3,3);
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                var t = new Thread(PrintTime);
                t.IsBackground = true;
                t.Name = i.ToString();
                t.Start();
            }

            Console.ReadKey();
        }

        static void PrintTime()
        {
            _semaphore.WaitOne();

            var currThread = Thread.CurrentThread;
            Console.WriteLine($"Поток запущен {currThread.Name}");
            Console.WriteLine($"Поток завершен {currThread.Name}");
            Thread.Sleep(3000);

            _semaphore.Release();
        }
    }
}
