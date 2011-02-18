using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP.Helpers
{
    public static class Strings
    {
        /// <summary>
        /// This function will delete everything after the defined string length 
        /// and add "..." after the string
        /// </summary>
        /// <param name="input">String you wish to parse</param>
        /// <param name="length">Input string length you wish to delete rest of the string after</param>
        /// <returns></returns>
 
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
