using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MIP.Helpers;

namespace MIP
{
    class Program
    {
        static Stack<List<Product>> _previousStack;

        static void Main(string[] args)
        {
            _previousStack = new Stack<List<Product>>();
            MenuBuilder.GetMenu.Quit = Quit;
            MenuBuilder.GetMenu.Main = MainMenu;

            Parser.Parse();
            MainMenu();
            

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

        /// <summary>
        /// Responsible for handling the main menu
        /// </summary>
        static public void MainMenu()
        {
            try
            {
                Console.Clear();
                List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
                list.Add(new KeyValuePair<Action, string>(InitializeSearch, "Search"));
                list.Add(new KeyValuePair<Action, string>(Cart, "Cart"));
                list.Add(new KeyValuePair<Action, string>(ManageProducts.ManageProduct, "Manage products"));
                list.Add(new KeyValuePair<Action, string>(ManageManufacturer.ManageManufacturers, "Manage manufacturer"));
                NoBackNext = MainMenu;

                MenuBuilder.GetMenu.MakeMenu(list, NoBack, new KeyValuePair<Action, string>(MainMenu, "Main Menu"));
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("An occured! Press any key to go to Main Menu.");
                Console.ReadKey(true);
                Console.Clear();
                MainMenu();
            }
        }

        #region Search

        static void InitializeSearch()
        {
            SearchMain(Search.Initiate());
        }

        static void SearchMain(List<Product> searchResult)
        {
            _previousStack.Push(searchResult);
            Console.Clear();
            int i = 1;
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            List<string> identifier = new List<string>();
            foreach (var item in searchResult)
            {
                list.Add(new KeyValuePair<Action, string>(AddToCart, item.ToSearchResultString().Truncate(60)));
                identifier.Add(i + "");
                i++;
            }
            try
            {
                list[list.Count - 1] = (new KeyValuePair<Action, string>(AddToCart, list[list.Count - 1].Value + "\n"));
            }
            catch (ArgumentOutOfRangeException)
            { }

            if (list.Count > 0)
            {
                char c = 'A';
                list.Add(new KeyValuePair<Action, string>(SearchProductCode, "Search by product code"));
                identifier.Add(c + "");
                c++;
                list.Add(new KeyValuePair<Action, string>(SearchPrice, "Filter by price"));
                identifier.Add(c + "");
                c++;
                list.Add(new KeyValuePair<Action, string>(SearchStorage, "Filter by storage capacity"));
                identifier.Add(c + "");
                c++;
                list.Add(new KeyValuePair<Action, string>(SearchText, "Filter for product/manufacture name"));
                identifier.Add(c + "");
                c++;
                list.Add(new KeyValuePair<Action, string>(InitializeSearch, "Reset search"));
                identifier.Add(c + "");
                MenuBuilder.GetMenu.MakeMenu(list, SearchBack, new KeyValuePair<Action, string>(InitializeSearch, "Search"), identifier,
                    "Below is a list of products.\n"+
                    "Use the numbers to add a product to your cart and the large letters from 'A' to '" + c + "' " +
                    "to filter the list.\n");
            }
            else
            {
                MenuBuilder.GetMenu.MakeMenu(list, SearchBack, new KeyValuePair<Action, string>(InitializeSearch, "Search"), identifier,
                    "\nNo products were found!\n");
            }

            
        }

        static void SearchProductCode()
        {
            Console.Clear();
            Console.WriteLine("Enter a product code to search for:");
            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            int i;
            while (!int.TryParse(input, out i))
            {
                Console.Clear();
                Console.WriteLine("Invalid input \"{0}\". Please enter a new product code to search for:",input.Truncate(10));
                input = Console.ReadLine();
            }

            SearchMain(Search.SearchProductCode(_previousStack.Peek(),i));
            return;
        }

        static void SearchPrice()
        {
            Console.Clear();
            Console.WriteLine("Enter a price range to search in(e.g. 1000-2000, use '*' as wildcard):");
            double maxI, minI;
            string min;
            string max;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                input.Trim();
                input += " ";
                int indexSplit = input.IndexOf('-');
                min = input.Substring(0, indexSplit).Trim();
                max = input.Substring(indexSplit + 1).Trim();

                if (min == "*" || min == "")
                {
                    min = "0";
                    continue;
                }
                if (max == "*" || max == "")
                {
                    max = int.MaxValue + "";
                }
                Console.Clear();
                Console.WriteLine("Invalid input \"{0}\". Please enter a new price range to search in:", input.Truncate(10));
            }
            while (!double.TryParse(min, out minI) || !double.TryParse(max, out maxI));

            SearchMain(Search.SearchPriceRange(_previousStack.Peek(), minI,maxI));
            return;
        }

        static void SearchStorage()
        {
            Console.Clear();
            Console.WriteLine("Enter a storage range(in GB) to search in(e.g. 512-2048, use '*' as wildcard):");
            int maxI, minI;
            string min;
            string max;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                input.Trim();
                input += " ";
                int indexSplit = input.IndexOf('-');
                min = input.Substring(0, indexSplit).Trim();
                max = input.Substring(indexSplit + 1).Trim();

                if (min == "*" || min == "")
                {
                    min = "0";
                    continue;
                }
                if (max == "*" || max == "")
                {
                    max = int.MaxValue + "";
                }
                Console.Clear();
                Console.WriteLine("Invalid input \"{0}\". Please enter a new storage range(GB) to search in:", input.Truncate(10));
            }
            while (!int.TryParse(min, out minI) || !int.TryParse(max, out maxI));

            SearchMain(Search.SearchStorageRange(_previousStack.Peek(), minI, maxI));
            return;
        }

        static void SearchText()
        {
            Console.Clear();
            Console.WriteLine("Enter a text to search for in name and manufacturer(case insensitive):");
            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            SearchMain(Search.SearchText(_previousStack.Peek(), input));
            return;
        }

        static void AddToCart()
        {
            int index = int.Parse(MenuBuilder.GetMenu.LastSelected);
            int amount = Toolbox.GetInt("How many do you want to add to your cart?:", x => x >= 0);
            MIP.Cart.GetCart.AddToCart(amount, _previousStack.Peek()[index-1].ProductCode);
            SearchMain(_previousStack.Pop());
            return;
        }

        static void SearchBack()
        {
            try
            {
                _previousStack.Pop();
                SearchMain(_previousStack.Pop());
            }
            catch (InvalidOperationException)
            {
                MainMenu();
            }

            return;
        }

#endregion

        /// <summary>
        /// Shows the content of the cart and allows the user perform checkout, clear cart, and remove
        /// </summary>
        static void Cart()
        {
            Console.Clear();
            Cart myCart = MIP.Cart.GetCart;
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            list.Add(new KeyValuePair<Action, string>(CheckOut, "Checkout"));
            list.Add(new KeyValuePair<Action, string>(ClearCart, "Clear cart"));
            list.Add(new KeyValuePair<Action, string>(RemoveMenu, "Remove"));
            NoBackNext = MainMenu;

            MenuBuilder.GetMenu.MakeMenu(list,MainMenu, new KeyValuePair<Action, string>(Cart, "Cart Menu"),myCart.CartToPrint() + "\n");
        }

        static void RemoveMenu()
        {
            Console.Clear();
            int i = 1;
            Cart myCart = MIP.Cart.GetCart;
            List<string> identifier = new List<string>();
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            foreach (var item in myCart.GetOrderList())
            {
                String itemName = "";
                for (int j = 0; j < Parser.ProductList.Count; j++)
                {
                    if (item.Productcode == Parser.ProductList[j].ProductCode)
                    {
                        itemName = Parser.ProductList[j].ToSearchResultString();
                    }
                }
                list.Add(new KeyValuePair<Action, string>(RemoveFromCart, itemName));
                identifier.Add(i + "");
                i++;
            }
            NoBackNext = MainMenu;
            if (myCart.GetOrderList().Count == 0)
            {
                MenuBuilder.GetMenu.MakeMenu(list, MainMenu, new KeyValuePair<Action, string>(RemoveMenu, "Cart Menu"), "There are no items in your cart\n");
            }
            else
            {
                MenuBuilder.GetMenu.MakeMenu(list, MainMenu, new KeyValuePair<Action, string>(RemoveMenu, "Cart Menu"), identifier);
            }
        }

        static void RemoveFromCart()
        {

            int index = int.Parse(MenuBuilder.GetMenu.LastSelected);
            int amount = Toolbox.GetInt("How many do you want to remove from your cart?:", x => x >= 0);
            MIP.Cart.GetCart.RemoveFromCart(amount, MIP.Cart.GetCart.GetOrderList()[index-1].Productcode);
            Cart();
            return;
        }

        static void ClearCart()
        {
            MIP.Cart.GetCart.Clear();
            Console.WriteLine("Cart cleared. Press any key to continue.");
            Console.ReadKey();
            MainMenu();
        }

        static void CheckOut()
        {
            Console.Clear();
            if (MIP.Cart.GetCart.GetOrderList().Count == 0)
            {
                Console.WriteLine("No items to checkout. Press any key to continue.");
                Console.ReadKey();
                MainMenu();
                return;
            }
            
            Console.WriteLine("The products will be sent to your address, please pay " + MIP.Cart.GetCart.TotalPrice + " kr.");
            MIP.Cart.GetCart.Clear();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            MainMenu();
            return;
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

            MenuBuilder.GetMenu.MakeCleanMenu(list, MainMenu, new KeyValuePair<Action,string>(null,"Quit"), identifiers);
            return;
        }

        static void Kill()
        {
            Environment.Exit(0);
        }        
    }
}