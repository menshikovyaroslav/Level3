using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static Mutex _mutex = new Mutex();
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
            _mutex.WaitOne();

            var currThread = Thread.CurrentThread;
            Console.Write($"Поток запущен {currThread.Name}");
            Thread.Sleep(10);
            Console.WriteLine();
            Thread.Sleep(10);
            Console.WriteLine($"Поток завершен {currThread.Name}");

            _mutex.ReleaseMutex();
        }
    }
}
