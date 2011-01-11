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
            Menu.GetMenu.Quit = Quit;
            Menu.GetMenu.Main = MainMenu;

            //Parser.parser();
            MainMenu();
            Console.ReadLine();

        }

        static public KeyValuePair<Action, string> QuitBack
        {
            get;
            set;
        }

        static public Action NoBackNext
        {
            get;
            set;
        }

        static void MainMenu()
        {
            Console.Clear();
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            list.Add(new KeyValuePair<Action, string>(InitializeSearch, "Search"));
            list.Add(new KeyValuePair<Action, string>(Cart, "Cart"));
            NoBackNext = MainMenu;

            Menu.GetMenu.MakeMenu(list, NoBack, new KeyValuePair<Action, string>(MainMenu, "Main Menu"));
        }

        static void InitializeSearch()
        { 
        
        }

        static void Cart()
        {
            Cart myCart = new Cart();
            Console.Clear();
            String cart = Console.ReadLine();
            String[] cartfunction = cart.Split(' ');
            if (cartfunction[0] == "Add")
            {
                try
                {
                    int number = Convert.ToInt32(cartfunction[1]);
                    int product = Convert.ToInt32(cartfunction[2]);
                    myCart.AddToCart(number, product);
                }
                catch
                {
                    Console.Write("Your input was not in the correct format!");
                }
            }
            else if (cartfunction[0] == "Remove")
            {
                try
                {
                    int number = Convert.ToInt32(cartfunction[1]);
                    int product = Convert.ToInt32(cartfunction[2]);
                    myCart.RemoveFromCart(number,product);
                }
                catch 
                {
                    Console.Write("Your input was not in the correct format!");
                }
            }
            else if (cartfunction[0] == "CheckOut")
            {
                    myCart.CheckOut();
            }
            else if (cartfunction[0] == "Clear")
            {
                    myCart.Clear();
            }
            else if (cartfunction[0] == "Print")
            {
                myCart.PrintCart();
            }
        }

        static public void NoBack()
        {
            Console.Clear();
            Console.WriteLine("Cannot go back! Press any key to continue.");
            Console.ReadKey(true);
            Console.Clear();
            NoBackNext();
        }

        static void Quit()
        {
            Console.Clear();
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            list.Add(new KeyValuePair<Action, string>(Kill, "Yes, exit"));
            QuitBack = new KeyValuePair<Action,string>(QuitBack.Key,"No, go back to \"" + QuitBack.Value + "\"");
            list.Add(QuitBack);

            List<string> identifiers = new List<string>();
            identifiers.Add("Y");
            identifiers.Add("N");

            Menu.GetMenu.MakeCleanMenu(list, new KeyValuePair<Action,string>(null,"Quit"), identifiers);
            return;
        }

        static void Kill()
        {
            Environment.Exit(0);
        }
    }
}
