using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var timeClass = new TimeClass();
            for (int i = 0; i < 10; i++)
            {
                var t = new Thread(timeClass.Work);
                t.IsBackground = true;
                t.Name = $"Поток {i}";
                t.Start();
            }

            Console.ReadKey();
        }
    }

    [Synchronization]
    public class TimeClass : ContextBoundObject
    {
        public void Work()
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
