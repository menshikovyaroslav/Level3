using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support
{
    public static class Coder
    {
        public static string Encode(string pass)
        {
            var result = "";
            foreach (var c in pass)
            {
                var ch = c;
                ch--;
                result += ch;
            }
            return result;
        }

        public static string Decode(string code)
        {
            var result = "";
            foreach (var c in code)
            {
                var ch = c;
                ch++;
                result += ch;
            }
            return result;
        }
    }
}
