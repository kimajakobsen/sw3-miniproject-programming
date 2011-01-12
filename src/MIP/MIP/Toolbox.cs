using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MIP.Helpers;

namespace MIP
{
    /// <summary>
    /// Contains GetString, GetInt, GetDouble, and GetBool.
    /// These classes take a input which need to be printet and wait 
    /// for the user to enter a input where a condition is true.
    /// The text is printet. Input from user is recived and condition is checked,
    /// if the input was valid then it print what the user just entered.
    /// else it ask for a new input.
    /// 
    /// </summary>
    static class Toolbox
    {
        /// <summary>
        /// Sets the predicate to return true and calls the GetString
        /// </summary>
        /// <param name="text">The text that needs to be displayed</param>
        /// <returns>Calles GetString(text,True)</returns>
        static public string GetString(string text)
        {
            return GetString(text, new Predicate<string>(x => true));
        }

        /// <summary>
        /// prints a string and expects a string input from the user.
        /// </summary>
        /// <param name="text">The text that needs to be displayed</param>
        /// <param name="predicate">A condition</param>
        /// <returns>prints the text which was inputed</returns>
        static public string GetString(string text, Predicate<string> predicate)
        {
            string input;
            Console.WriteLine(text); //print text
            int enterRow = Console.CursorTop; //saves the current row
            Console.ForegroundColor = ConsoleColor.Green; //sets the text to green
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White; //sets the text back to white
            while (!predicate(input)) //if the predicate is false
            {
                Console.SetCursorPosition(0, enterRow);
                for (int i = 0; i < input.Length; i++)
                {
                    Console.Write(" "); // delete the invalid input the user just entered.
                }
                Console.SetCursorPosition(0, enterRow - 1);
                for (int i = 0; i < 80; i++) //delete the above line (a line is 80 chars long) 
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(0, enterRow - 1);
                Console.WriteLine("Incorrect input \"{0}\". {1}", input.Truncate(10), text); //prints the error message
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            return input;
        }

        /// <summary>
        /// Sets the predicate to return true and calls the GetInt
        /// </summary>
        /// <param name="text">The text that needs to be displayed</param>
        /// <returns>Calles GetInt(text,True)</returns>
        static public int GetInt(string text)
        {
            return GetInt(text, new Predicate<int>(x => true));
        }

        /// <summary>
        /// prints a string and expects a int input from the user.
        /// </summary>
        /// <param name="text">The text that needs to be displayed</param>
        /// <param name="predicate">A condition</param>
        /// <returns>prints the int which was inputed</returns>
        static public int GetInt(string text, Predicate<int> predicate)
        {
            string input;
            int result;
            Console.WriteLine(text);
            int enterRow = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (!int.TryParse(input, out result) || !predicate(result)) //if the string cannot be passed to a int or the condition is false
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

        /// <summary>
        /// Sets the predicate to return true and calls the GetDouble
        /// </summary>
        /// <param name="text">The text that needs to be displayed</param>
        /// <returns>Calles GetDouble(text,True)</returns>
        static public double GetDouble(string text)
        {
            return GetDouble(text, new Predicate<double>(x => true));
        }

        /// <summary>
        /// prints a string and expects a Double input from the user.
        /// </summary>
        /// <param name="text">The text that needs to be displayed</param>
        /// <param name="predicate">A condition</param>
        /// <returns>Double which was inputed</returns>
        static public double GetDouble(string text, Predicate<double> predicate)
        {
            string input;
            double result;
            Console.WriteLine(text);
            int enterRow = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (!double.TryParse(input, out result) || !predicate(result)) //if the string cannot be passed to a double or the condition is false
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

        /// <summary>
        /// Sets the predicate to return true and calls the GetBool
        /// </summary>
        /// <param name="text">The text that needs to be displayed</param>
        /// <returns>Calles GetBool(text,True)</returns>
        static public bool GetBool(string text)
        {
            return GetBool(text, new Predicate<bool>(x => true));
        }

        /// <summary>
        /// prints a string and expects a bool input from the user.
        /// </summary>
        /// <param name="text">The text that needs to be displayed</param>
        /// <param name="predicate">A condition</param>
        /// <returns>Bool which was inputed</returns>
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
