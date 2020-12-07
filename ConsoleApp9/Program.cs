using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static List<string> _list = new List<string>();

        static Dictionary<int, string> _dict = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    _list.Add($"Строка {i}");
            //}

            for (int i = 0; i < 5; i++)
            {
                var t = new Thread(Work);
                t.IsBackground = true;
                t.Start();
            }

            Console.ReadKey();
        }

        static object _lockerForList = new object();

        static int _counter = 0;

        static void Work()
        {
            //while (true)
            //{
            //    lock (_lockerForList)
            //    {
            //        _list.Add($"Строка new");
            //        Thread.Sleep(10);
            //    }
            //}
            while (true)
            {
                lock (_lockerForList)
                {
                    _dict[_counter] = "Text";
                    _counter++;
                    Thread.Sleep(10);
                }
            }
        }
    }
}
