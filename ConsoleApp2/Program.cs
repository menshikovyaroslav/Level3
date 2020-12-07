using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                var t = new Thread(PrintTime);
                t.IsBackground = true;
                t.Name = $"Поток {i}";
                t.Start();
            }

            Console.ReadKey();
        }

        static object _locker = new object();

        static void PrintTime()
        {
            lock (_locker)
            {
                var currThread = Thread.CurrentThread;
                Console.Write($"Поток запущен {currThread.Name}");
                Thread.Sleep(10);
                Console.WriteLine();
                Thread.Sleep(10);
                Console.WriteLine($"Поток завершен {currThread.Name}");
            }


        }
    }
}
