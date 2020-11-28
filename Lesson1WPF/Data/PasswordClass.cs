using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Data
{
    public static class PasswordClass
    {
        public static string Encode(string password)
        {
            var result = "";
            foreach (var c in password)
            {
                var ch = c;
                ch--;
                result += ch;
            }
            return result;
        }

        public static string Decode(string codedPassword)
        {
            var result = "";
            foreach (var c in codedPassword)
            {
                var ch = c;
                ch++;
                result += ch;
            }
            return result;
        }
    }
}
