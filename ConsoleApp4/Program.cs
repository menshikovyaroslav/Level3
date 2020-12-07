using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var manual_reset_event = new ManualResetEvent(false);
            var auto_reset_event = new AutoResetEvent(false);

            var starter = auto_reset_event;
            starter.Reset();

            for (int i = 0; i < 10; i++)
            {
                var local_i = i;

                new Thread(() =>
                {
                    Console.WriteLine($"Поток запущен {local_i}");
                    starter.WaitOne();
                    Console.WriteLine($"Поток завершен {local_i}");
                }).Start();
            }

            while (true)
            {
                var command = Console.ReadLine();
                switch (command)
                {
                    case "set":
                    starter.Set();
                    break;
                    case "reset":
                        starter.Reset();
                        break;
                    case "new":
                        new Thread(() =>
                        {
                            Console.WriteLine($"Поток запущен X");
                            starter.WaitOne();
                            Console.WriteLine($"Поток завершен X");
                        }).Start();
                        break;
                    default:
                        break;
            }

            }
        }
    }
}