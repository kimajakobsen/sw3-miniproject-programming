using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class Program
    {

        static void Main(string[] args)
        {
            Parser.parser();
            Console.ReadLine();

        }

        static public KeyValuePair<Action, string> QuitBack
        {
            get;
            set;
        }

        static void MainMenu()
        {
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            list.Add(new KeyValuePair<Action, string>(InitializeSearch, "Search"));
            list.Add(new KeyValuePair<Action, string>(Cart, "Cart"));
        }

        static void InitializeSearch()
        { 
        
        }

        static void Cart()
        { 
        
        }

        static void Quit()
        {
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            list.Add(new KeyValuePair<Action, string>(Kill, "Yes, exit"));
            QuitBack = new KeyValuePair<Action,string>(QuitBack.Key,"No, go back to \"" + QuitBack.Value + "\"");
            list.Add(QuitBack);

            List<string> identifiers = new List<string>();
            identifiers.Add("Y");
            identifiers.Add("N");

            Menu.GetMenu.MakeCleanMenu(list, QuitBack, identifiers);
            return;
        }

        static void Kill()
        {
            Environment.Exit(0);
        }
    }
}
