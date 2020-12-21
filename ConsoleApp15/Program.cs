using Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    [Description("Main Program")]
    class Program
    {
        static void Main(string[] args)
        {
            var programType = typeof(Program);
            var description = programType.GetCustomAttribute<DescriptionAttribute>()?.Description;

            var mail = new Mail();
            mail.SendMail("", "", "", "");

            Console.WriteLine($"description= {description}");

            Console.ReadLine();
        }
    }
}
