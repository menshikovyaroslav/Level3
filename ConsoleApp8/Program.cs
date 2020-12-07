using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {

            ThreadPool.GetAvailableThreads(out var a1, out var a2);
            ThreadPool.GetMinThreads(out var min1, out var min2);
            ThreadPool.GetMaxThreads(out var max1, out var max2);

            ThreadPool.SetMinThreads(500, 500);
            ThreadPool.SetMaxThreads(500, 500);

            var timer = Stopwatch.StartNew();

            var list = new List<string>();
            for (int i = 0; i < 500; i++)
            {
                list.Add($"Поток {i}");
            }

            for (int i = 0; i < 500; i++)
            {
                var local_i = i;
                ThreadPool.QueueUserWorkItem(o => PrintTime(list[local_i]));


                //var t = new Thread(PrintTime);
                //t.IsBackground = true;
                //t.Name = list[i];
                //t.Start();
            }

            timer.Stop();

            var millisec = timer.ElapsedMilliseconds;
            Console.WriteLine($"Time: {millisec}");

            Console.ReadKey();

        }

        static void PrintTime(string name)
        {
       //     var currThread = Thread.CurrentThread;
            Console.WriteLine($"Поток запущен {name}");
            Console.WriteLine($"Поток завершен {name}");
            Thread.Sleep(500);

        }
    }
}
