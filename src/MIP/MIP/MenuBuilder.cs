using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MIP.Helpers;

namespace MIP
{
    /// <summary>
    /// This class follows the singleton design pattern
    /// It can make menus and direct the user to the action chosen in the menus
    /// </summary>
    class MenuBuilder
    {
        private List<string> _identifier;
        private Action _quit;
        private Action _back;
        private Action _main;
        static private MenuBuilder _menu;
        private string _quitCommand;
        private string _backCommand;
        private string _mainCommand;
        private string _quitText;
        private string _backText;
        private string _mainText;
        private int _commandLength;
        private string _seperator;

        private MenuBuilder()
        {
            _seperator = " - ";

            _quitText = "Quit";
            _backText = "Back";
            _mainText = "Go to Main";

            _quitCommand = "q";
            _backCommand = "b";
            _mainCommand = "m";
            _identifier = new List<string>();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (c + "" == _quitCommand || c + "" == _backCommand || c + "" == _mainCommand)
                {
                    continue;
                }
                _identifier.Add(c+"");
            }

        }

        public string LastSelected
        {
            get;
            private set;
        }

        /// <summary>
        /// This property allows outside users to access the single MenuBuilder object
        /// </summary>
        static public MenuBuilder GetMenu
        {
            get
            {
                if (_menu == null)
                {
                    _menu = new MenuBuilder();
                }

                return _menu;
            }
        }

        /// <summary>
        /// The action to be called when the user selects quit
        /// </summary>
        public Action Quit
        {
            get
            {
                return _quit;
            }

            set
            {
                if (_quit == null)
                {
                    _quit = value;
                }
            }
        }

        /// <summary>
        /// The action to be called when the user selects main menu
        /// </summary>
        public Action Main
        {
            get
            {
                return _main;
            }

            set
            {
                if (_main == null)
                {
                    _main = value;
                }
            }
        }

        /// <summary>
        /// The action to be called when the user selects back
        /// </summary>
        public Action Back
        {
            get
            {
                return _back;
            }

            set
            {
                _back = value;   
            }
        }

        /// <summary>
        /// Writes out a menu which has the text specified in the list, and a delegate
        /// called. Quit, back, and back to main options are added.
        /// </summary>
        /// <param name="funcText">List of Actions and strings. The strings are printed
        /// and the Action is invoked when the given text is selected</param>
        /// <param name="back">Action to return tu when back is selected</param>
        /// <param name="caller">The the Action which calls MakeMenu as the key along with a name as the value</param>
        public void MakeMenu(List<KeyValuePair<Action, string>> funcText, Action back, KeyValuePair<Action, string> caller)
        {
            MakeMenu(funcText, back, caller, _identifier.GetRange(0,funcText.Count));

            return;
        }

        /// <summary>
        /// Writes out a menu which has the text specified in the list, and a delegate to be
        /// called. Quit, back, and back to main options are added.
        /// </summary>
        /// <param name="funcText">List of Actions and strings. The strings are printed
        /// and the Action is invoked when the given text is selected</param>
        /// <param name="back">Action to return tu when back is selected</param>
        /// <param name="caller">The the Action which calls MakeMenu as the key along with a name as the value</param>
        /// <param name="identifier">List of identifiers which the user must choose between</param>
        public void MakeMenu(List<KeyValuePair<Action, string>> funcText, Action back,
            KeyValuePair<Action, string> caller, List<string> identifier)
        {
            MakeMenu(funcText, back, caller, identifier.GetRange(0, funcText.Count), "");

            return;
        }

        /// <summary>
        /// Writes out a menu which has the text specified in the list, and a delegate to be
        /// called. Quit, back, and back to main options are added.
        /// </summary>
        /// <param name="funcText">List of Actions and strings. The strings are printed
        /// and the Action is invoked when the given text is selected</param>
        /// <param name="back">Action to return tu when back is selected</param>
        /// <param name="caller">The the Action which calls MakeMenu as the key along with a name as the value</param>
        /// <param name="prologue">Text to be written after the headline but before the actual menu</param>
        public void MakeMenu(List<KeyValuePair<Action, string>> funcText,
            Action back, KeyValuePair<Action, string> caller, string prologue)
        {
            MakeMenu(funcText, back, caller, _identifier.GetRange(0, funcText.Count), prologue);

            return;
        }

        /// <summary>
        /// Writes out a menu which has the text specified in the list, and a delegate to be
        /// called. Quit, back, and back to main options are added.
        /// </summary>
        /// <param name="funcText">List of Actions and strings. The strings are printed
        /// and the Action is invoked when the given text is selected</param>
        /// <param name="back">Action to return tu when back is selected</param>
        /// <param name="caller">The the Action which calls MakeMenu as the key along with a name as the value</param>
        /// <param name="prologue">Text to be written after the headline but before the actual menu</param>
        /// <param name="identifier">List of identifiers which the user must choose between</param>
        public void MakeMenu(List<KeyValuePair<Action, string>> funcText, Action back,
            KeyValuePair<Action, string> caller, List<string> identifier, string prologue)
        {
            if (funcText.Count > identifier.Count)
            {
                throw new ArgumentException("Too many inputs");
            }
            try
            {
                funcText[funcText.Count - 1] = (new KeyValuePair<Action, string>
                    (funcText[funcText.Count - 1].Key, funcText[funcText.Count - 1].Value + "\n"));
            }
            catch (ArgumentOutOfRangeException)
            { }

            identifier.Add(_backCommand);
            funcText.Add(new KeyValuePair<Action, string>(back, _backText));
            identifier.Add(_mainCommand);
            funcText.Add(new KeyValuePair<Action, string>(_main, _mainText));
            identifier.Add(_quitCommand);
            funcText.Add(new KeyValuePair<Action, string>(_quit, _quitText));
            _commandLength = 1;

            MakeCleanMenu(funcText, back, caller, identifier, prologue);
        }

        /// <summary>
        /// Writes out a menu which has the text specified in the list, and a delegate
        /// called.
        /// </summary>
        /// <param name="funcText">List of Actions and strings. The strings are printed
        /// and the Action is invoked when the given text is selected</param>
        /// <param name="back">Action to return tu when back is selected</param>
        /// <param name="caller">The the Action which calls MakeMenu as the key along with a name as the value</param>
        public void MakeCleanMenu(List<KeyValuePair<Action, string>> funcText, Action back, KeyValuePair<Action, string> caller)
        {
            MakeCleanMenu(funcText, back, caller, _identifier, "");

            return;
        }

        /// <summary>
        /// Writes out a menu which has the text specified in the list, and a delegate to be
        /// called.
        /// </summary>
        /// <param name="funcText">List of Actions and strings. The strings are printed
        /// and the Action is invoked when the given text is selected</param>
        /// <param name="back">Action to return tu when back is selected</param>
        /// <param name="caller">The the Action which calls MakeMenu as the key along with a name as the value</param>
        /// <param name="prologue">Text to be written after the headline but before the actual menu</param>
        public void MakeCleanMenu(List<KeyValuePair<Action, string>> funcText, Action back,
            KeyValuePair<Action, string> caller,string prologue)
        {
            MakeCleanMenu(funcText, back, caller, _identifier,prologue);

            return;
        }

        /// <summary>
        /// Writes out a menu which has the text specified in the list, and a delegate to be
        /// called.
        /// </summary>
        /// <param name="funcText">List of Actions and strings. The strings are printed
        /// and the Action is invoked when the given text is selected</param>
        /// <param name="back">Action to return tu when back is selected</param>
        /// <param name="caller">The the Action which calls MakeMenu as the key along with a name as the value</param>
        /// <param name="identifier">List of identifiers which the user must choose between</param>
        public void MakeCleanMenu(List<KeyValuePair<Action, string>> funcText, Action back,
            KeyValuePair<Action, string> caller, List<string> identifier)
        {
            MakeCleanMenu(funcText, back, caller, identifier, ConsoleColor.Green, "");
        }
        /// <summary>
        /// Writes out a menu which has the text specified in the list, and a delegate to be
        /// called.
        /// </summary>
        /// <param name="funcText">List of Actions and strings. The strings are printed
        /// and the Action is invoked when the given text is selected</param>
        /// <param name="back">Action to return tu when back is selected</param>
        /// <param name="caller">The the Action which calls MakeMenu as the key along with a name as the value</param>
        /// <param name="prologue">Text to be written after the headline but before the actual menu</param>
        /// <param name="identifier">List of identifiers which the user must choose between</param>

        public void MakeCleanMenu(List<KeyValuePair<Action, string>> funcText, Action back,
            KeyValuePair<Action, string> caller, List<string> identifier,string prologue)
        {
            MakeCleanMenu(funcText, back, caller, identifier, ConsoleColor.Green, prologue);
        }

        /// <summary>
        /// Writes out a menu which has the text specified in the list, and a delegate to be
        /// called.
        /// </summary>
        /// <param name="funcText">List of Actions and strings. The strings are printed
        /// and the Action is invoked when the given text is selected</param>
        /// <param name="back">Action to return tu when back is selected</param>
        /// <param name="caller">The the Action which calls MakeMenu as the key along with a name as the value</param>
        /// <param name="prologue">Text to be written after the headline but before the actual menu</param>
        /// <param name="identifier">List of identifiers which the user must choose between</param>
        /// <param name="commandColor">Color of the identifiers and the command
        /// which the user enters</param>
        public void MakeCleanMenu(List<KeyValuePair<Action, string>> funcText, Action back,
            KeyValuePair<Action, string> caller, List<string> identifier,
            ConsoleColor commandColor, string prologue)
        {
            if (funcText == null || identifier == null)
            {
                throw new ArgumentNullException("No argument to MakeCleanMenu are allowed to be null");
            }
            if (back == null)
            {
                _back = Program.NoBack;
            }
            else
            {
                _back = back;
            }
            string input;
            if (funcText.Count > identifier.Count)
            {
                throw new ArgumentException("Too many inputs");
            }

            int maxLenght = 0;
            //Find the maximum length amoung the strings to print in the menu lines
            foreach (var item in funcText)
            {
                if (item.Value.Length > maxLenght)
                {
                    maxLenght = item.Value.Length;
                }
            }

            _commandLength = 0;
            //Find the maximum length amoung the identifiers
            foreach (var item in identifier)
            {
                if (item.Length > _commandLength)
                {
                    _commandLength = item.Length;
                }
            }

            maxLenght += _commandLength + _seperator.Length;
            int headerSize = maxLenght;
            if (caller.Value != null && headerSize < caller.Value.Length + 4)
            {
                headerSize = caller.Value.Length + 4;
            }
            Console.WriteLine();
            if (caller.Value != null && caller.Value != "")
            {
                //Printing the head line with "=" before and after the text
                int length = caller.Value.Length;
                WriteSeveral("=", (headerSize - length) / 2 - 1);
                Console.Write(" " + caller.Value + " ");
                WriteSeveral("=", (headerSize - length) / 2 - 1);
                if ((headerSize - length) % 2 == 1)
                {
                    Console.Write("=");
                }
            }
            else
            {
                //Printing "=" as the header
                WriteSeveral("=", headerSize);
            }
            Console.WriteLine();
            Console.WriteLine(prologue);

            //Each iteration writes a single menu lien
            for (int i = 0; i < funcText.Count; i++)
            {
                Console.ForegroundColor = commandColor;
                Console.Write(identifier[i]);
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = identifier[i].Length; j < _commandLength; j++)
                {
                    //Indenting for the text after identifier
                    Console.Write(" ");
                }

                Console.Write(_seperator);
                Console.WriteLine(funcText[i].Value);
            }

            Console.WriteLine("Enter your choice:");
            int enterRow = Console.CursorTop;
            Console.ForegroundColor = commandColor;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                LastSelected = input;
                if (input == _quitCommand)
                {
                    //Quit command selected, the caller is to be returned to
                    //whould the user decline exiting
                    Program.QuitBack = caller;
                }

                for (int i = 0; i < funcText.Count; i++)
                {
                    if (input == identifier[i])
                    {
                        //The identifier is found
                        funcText[i].Key();
                        return;
                    }
                }

                //Clean up the incorrect input
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

                //The user may enter again
                Console.WriteLine("Incorrect identifier \"{0}\". Please try again:", input.Truncate(10));
                Console.ForegroundColor = commandColor;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Prints <code>input</code> <code>count</code> times
        /// </summary>
        /// <param name="input">The string to print</param>
        /// <param name="count">The number of times to print</param>
        private void WriteSeveral(string input, int count)
        {
            while (count > 0)
            {
                count--;
                Console.Write(input);
            }

            return;
        }
    }
}