using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP.Helpers
{
    public static class Strings
    {
        static public string Truncate(this string input, int length)
        {
            if (input.Length > length)
            {
                return input.Substring(0, length - 3) + "...";
            }

            return input;
        }
    }
}
