using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MIP.Helpers;

namespace MIP
{
    static class Toolbox
    {
        static public string GetString(string text)
        {
            return GetString(text, new Predicate<string>(x => true));
        }


        static public string GetString(string text, Predicate<string> predicate)
        {
            string input;
            Console.WriteLine(text);
            int enterRow = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (!predicate(input))
            {
                Console.SetCursorPosition(0, enterRow);
                for (int i = 0; i < input.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(0, enterRow - 1);
                for (int i = 0; i < 80; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(0, enterRow - 1);
                Console.WriteLine("Incorrect input \"{0}\". {1}", input.Truncate(10), text);
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            return input;
        }

        static public int GetInt(string text)
        {
            return GetInt(text, new Predicate<int>(x => true));
        }

        static public int GetInt(string text, Predicate<int> predicate)
        {
            string input;
            int result;
            Console.WriteLine(text);
            int enterRow = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (!int.TryParse(input, out result) || !predicate(result))
            {
                Console.SetCursorPosition(0, enterRow);
                for (int i = 0; i < input.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(0, enterRow - 1);
                for (int i = 0; i < 80; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(0, enterRow - 1);
                Console.WriteLine("Incorrect input \"{0}\". {1}", input.Truncate(10), text);
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            return result;
        }

        static public double GetDouble(string text)
        {
            return GetDouble(text, new Predicate<double>(x => true));
        }

        static public double GetDouble(string text, Predicate<double> predicate)
        {
            string input;
            double result;
            Console.WriteLine(text);
            int enterRow = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (!double.TryParse(input, out result) || !predicate(result))
            {
                Console.SetCursorPosition(0, enterRow);
                for (int i = 0; i < input.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(0, enterRow - 1);
                for (int i = 0; i < 80; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(0, enterRow - 1);
                Console.WriteLine("Incorrect input \"{0}\". {1}", input.Truncate(10), text);
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            return result;
        }

        static public bool GetBool(string text)
        {
            return GetBool(text, new Predicate<bool>(x => true));
        }

        static public bool GetBool(string text, Predicate<bool> predicate)
        {
            string input;
            bool result;
            Console.WriteLine(text);
            int enterRow = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (!bool.TryParse(input, out result) | !predicate(result))
            {
                Console.SetCursorPosition(0, enterRow);
                for (int i = 0; i < input.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(0, enterRow - 1);
                for (int i = 0; i < 80; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(0, enterRow - 1);
                Console.WriteLine("Incorrect input \"{0}\". {1}", input.Truncate(10), text);
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            return result;
        }
    }
}
