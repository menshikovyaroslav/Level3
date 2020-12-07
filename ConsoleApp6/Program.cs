using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isMutexFree;
            var mutex = new Mutex(true, "MyMutex", out isMutexFree);

            if (!isMutexFree)
            {
                Console.WriteLine("У Вас запущена копия данного приложения");
            }

            Console.ReadKey();
        }
    }
}
