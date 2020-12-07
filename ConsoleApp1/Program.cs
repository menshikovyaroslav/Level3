using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread = Thread.CurrentThread;
            thread.Name = "Main thread";

            var threadId = thread.ManagedThreadId;
            var name = thread.Name;
            var priority = thread.Priority;

            Console.WriteLine($"id={threadId}, name={name}, priority={priority}");

            var t = new Thread(PrintTime);
            t.IsBackground = true;
            t.Start();

            //var t2 = new Thread(new ParameterizedThreadStart(PrintTimeParameter));
            //t2.IsBackground = true;
            //t2.Start("Hello world");

            //var t3 = new Thread(() => PrintTimeParameter("Hello world"));
            //t3.IsBackground = true;
            //t3.Start();

            var time = new Time("New text", 100);
            new Thread(time.Print).Start();

            while (true)
            {
                Console.ReadLine();
            }

        }

        static void PrintTime()
        {
            while (true)
            {
                var now = DateTime.Now;
                Console.Title = $"{now.ToString("HH:mm:ss.ffff")}";
                Thread.Sleep(100);
            }
        }

        static void PrintTimeParameter(object text)
        {
            var txt = text.ToString();

            while (true)
            {
                var now = DateTime.Now;
                Console.Title = $"{now.ToString("HH:mm:ss.ffff")} {txt}";
                Thread.Sleep(100);
            }
        }
    }

    class Time
    {
        string _text;
        int _count;
        public Time(string text, int count)
        {
            _text = text;
            _count = count;
        }

        public void Print()
        {
            for (int i = 0; i < _count; i++)
            {
                var now = DateTime.Now;
                Console.Title = $"{now.ToString("HH:mm:ss.ffff")} {_text}";
                Thread.Sleep(100);
            }
        }
    }
}
