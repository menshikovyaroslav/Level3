using Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            var asm = Assembly.GetExecutingAssembly();

            Console.WriteLine($"Location: {asm.Location}");
            Console.WriteLine($"FullName: {asm.FullName}");
            Console.WriteLine($"GetName: {asm.GetName()}");

            var car = GetCar();
            var type = car.GetType();



            //if (type == typeof(Bmw))
            //{
            //    Console.WriteLine($"Car is Bmw");
            //}
            //if (type == typeof(Volvo))
            //{
            //    Console.WriteLine($"Car is Volvo");
            //}

            var mail = new Mail("mail.ru", 789);

            var mailType = mail.GetType();

            //var constructor = mailType.GetConstructor(new[] {typeof(string) });
            //var constructor2 = mailType.GetConstructor(new Type[] { typeof(string), typeof(int) });

            //var obj = Activator.CreateInstance(mailType);

            //var obj2 = constructor.Invoke(new[] { "test string" });
            //var obj3 = constructor2.Invoke(new object[] { "test string", 10 });

            //      Console.WriteLine($"Car type: {type}");


            var pr = mailType.GetField("Something", BindingFlags.NonPublic);
        //    Console.WriteLine($"{pr.Name} = {pr.PropertyType}");


            var v = pr.GetValue(mail);
            pr.SetValue(mail, "New value");

            Console.ReadLine();
        }

        static ICar GetCar()
        {
            return new Bmw();
        }
    }

    interface ICar
    {
        string Name { get; }
    }

    class Bmw : ICar
    {
        public string Name => "BMW";
    }

    class Volvo : ICar
    {
        public string Name => "VOLVO";
    }
}
