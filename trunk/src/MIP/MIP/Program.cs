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

        static void MainMenu()
        {
            Console.Clear();
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            list.Add(new KeyValuePair<Action, string>(InitializeSearch, "Search"));
            list.Add(new KeyValuePair<Action, string>(Cart, "Cart"));
            list.Add(new KeyValuePair<Action, string>(AddProduct, "Add product"));
            NoBackNext = MainMenu;

            MenuBuilder.GetMenu.MakeMenu(list, NoBack, new KeyValuePair<Action, string>(MainMenu, "Main Menu"));
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
                list.Add(new KeyValuePair<Action, string>(AddToCart, item.ToSearchResultString()));
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
                list.Add(new KeyValuePair<Action, string>(SearchPrice, "Search by price"));
                identifier.Add(c + "");
                c++;
                list.Add(new KeyValuePair<Action, string>(SearchStorage, "Search by storage capacity"));
                identifier.Add(c + "");
                c++;
                list.Add(new KeyValuePair<Action, string>(SearchText, "Search for product/manufacture name"));
                identifier.Add(c + "");
                MenuBuilder.GetMenu.MakeMenu(list, SearchBack, new KeyValuePair<Action, string>(InitializeSearch, "Search"), identifier);
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
            Console.WriteLine("Enter a price range to search in(e.g. 1000-2000):");
            double maxI, minI;
            string min;
            string max;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                input.Trim();
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
            Console.WriteLine("Enter a storage range(in GB) to search in(e.g. 512-2048):");
            int maxI, minI;
            string min;
            string max;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                input.Trim();
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
            while (!int.TryParse(min, out minI) || !int.TryParse(max, out maxI));

            SearchMain(Search.SearchStorageRange(_previousStack.Peek(), minI, maxI));
            return;
        }

        static void SearchText()
        {
            Console.Clear();
            Console.WriteLine("Enter a text to search for in name and manufacturer:");
            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            SearchMain(Search.SearchText(_previousStack.Peek(), input));
            return;
        }

        static void AddToCart()
        {
            int index = int.Parse(MenuBuilder.GetMenu.LastSelected);
            int amount = GetInt("How many do you want to add to your cart?:", x => x >= 0);
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

        static void Cart2()
        {
            Console.Clear();
            Cart myCart = MIP.Cart.GetCart;
            myCart.PrintCart();
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            list.Add(new KeyValuePair<Action, string>(myCart.CheckOut, "CheckOut"));
            list.Add(new KeyValuePair<Action, string>(myCart.Clear, "Clear cart"));
            list.Add(new KeyValuePair<Action, string>(RemoveFromCart, "Remove"));
            NoBackNext = MainMenu;

            MenuBuilder.GetMenu.MakeMenu(list,MainMenu, new KeyValuePair<Action, string>(Cart2, "Cart Menu"));
        }

        static void RemoveFromCart()
        {
            Console.Clear();
            Console.WriteLine("Enter a text to search for:");
            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            SearchMain(Search.SearchText(_previousStack.Peek(), input));
            return;
        }

        static void Cart()
        {
            Cart myCart = MIP.Cart.GetCart;
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
                    MainMenu();
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
                    Console.ReadLine();
                    MainMenu();
                }
                catch 
                {
                    Console.Write("Your input was not in the correct format!");
                }
            }
            else if (cartfunction[0] == "CheckOut")
            {
                    myCart.CheckOut();
                    Console.ReadLine();
                    MainMenu();
            }
            else if (cartfunction[0] == "Clear")
            {
                    myCart.Clear();
                    MainMenu();
            }
            else if (cartfunction[0] == "Print")
            {   //The Print do not work with 0 cartfunction[1] arguments
                myCart.PrintCart();
                Console.ReadLine();
                MainMenu();
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

            MenuBuilder.GetMenu.MakeCleanMenu(list, MainMenu, new KeyValuePair<Action,string>(null,"Quit"), identifiers);
            return;
        }

        static void Kill()
        {
            Environment.Exit(0);
        }

        #region Add Product

        static void AddProduct()
        {
            Console.Clear();
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            list.Add(new KeyValuePair<Action, string>(AddInternalHarddrive, "Add internal harddrive"));
            list.Add(new KeyValuePair<Action, string>(AddExternalHarddrive, "Add internal harddrive"));
            list.Add(new KeyValuePair<Action, string>(AddFlashStorage, "Add flash storage device"));

            MenuBuilder.GetMenu.MakeMenu(list, MainMenu, new KeyValuePair<Action, string>(AddProduct, "Add Product"));
            MainMenu();
        }

        static void AddInternalHarddrive()
        {
            string name = GetString("Enter name:", x => x.Length >= 5);
            double price = GetDouble("Enter price:");
            int productCode = GetInt("Enter product code:",x =>
                Parser.ProductList.FirstOrDefault(y => y.ProductCode == x) == null);
            string manu = GetString("Enter product manufacturer:", x =>
                Parser.ManufacturerList.FirstOrDefault(y => y.Name.ToUpper() == x.ToUpper()) != null);
            int store = GetInt("Enter storage capacity:", x => x > 0);
            int rpm = GetInt("Enter rpm:", x => Enum.IsDefined(typeof(ERPM), x));
            double form = GetDouble("Enter form factor:", x => Enum.IsDefined(typeof(EFormFactor), x));

            InternalHarddrive temp = new InternalHarddrive(
                name,
                price,
                productCode,
                Parser.ManufacturerList.FirstOrDefault(x => x.Name == manu),
                store,
                rpm,
                form);

            Parser.ProductList.Add(temp);
        }

        static void AddExternalHarddrive()
        {
            string name = GetString("Enter name:", x => x.Length >= 5);
            double price = GetDouble("Enter price:");
            int productCode = GetInt("Enter product code:", x =>
                Parser.ProductList.FirstOrDefault(y => y.ProductCode == x) == null);
            string manu = GetString("Enter product manufacturer:", x =>
                Parser.ManufacturerList.FirstOrDefault(y => y.Name.ToUpper() == x.ToUpper()) != null);
            int store = GetInt("Enter storage capacity:", x => x > 0);
            int rpm = GetInt("Enter rpm:", x => Enum.IsDefined(typeof(ERPM), x));
            double height = GetDouble("Enter height:");
            double width = GetDouble("Enter width:");
            double depth = GetDouble("Enter depth:");

            ExternalHarddrive temp = new ExternalHarddrive(
                name,
                price,
                productCode,
                Parser.ManufacturerList.FirstOrDefault(x => x.Name == manu),
                store,
                rpm,
                height,
                width,
                depth);

            Parser.ProductList.Add(temp);
        }

        static void AddFlashStorage()
        {
            string name = GetString("Enter name:", x => x.Length >= 5);
            double price = GetDouble("Enter price:");
            int productCode = GetInt("Enter product code:", x =>
                Parser.ProductList.FirstOrDefault(y => y.ProductCode == x) == null);
            string manu = GetString("Enter product manufacturer:", x =>
                Parser.ManufacturerList.FirstOrDefault(y => y.Name.ToUpper() == x.ToUpper()) != null);
            int store = GetInt("Enter storage capacity:", x => x > 0);
            int rpm = GetInt("Enter rpm:", x => Enum.IsDefined(typeof(ERPM), x));
            bool secure = GetBool("Enter secure usb:");

            FlashStorage temp = new FlashStorage(
                name,
                price,
                productCode,
                Parser.ManufacturerList.FirstOrDefault(x => x.Name == manu),
                store,
                secure);

            Parser.ProductList.Add(temp);
        }

        #endregion

        static string GetString(string text)
        {
            return GetString(text, new Predicate<string>(x => true));
        }


        static string GetString(string text, Predicate<string> predicate)
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
                Console.WriteLine("Incorrect input \"{0}\". {1}", input.Truncate(10),text);
                Console.ForegroundColor = ConsoleColor.Green;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            return input;
        }

        static int GetInt(string text)
        {
            return GetInt(text, new Predicate<int>(x => true));
        }

        static int GetInt(string text, Predicate<int> predicate)
        {
            string input;
            int result;
            Console.WriteLine(text);
            int enterRow = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (!int.TryParse(input, out result) && !predicate(result))
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

        static double GetDouble(string text)
        {
            return GetDouble(text, new Predicate<double>( x => true));
        }

        static double GetDouble(string text, Predicate<double> predicate)
        {
            string input;
            double result;
            Console.WriteLine(text);
            int enterRow = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (!double.TryParse(input, out result) && !predicate(result))
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

        static bool GetBool(string text)
        {
            return GetBool(text, new Predicate<bool>(x => true));
        }

        static bool GetBool(string text, Predicate<bool> predicate)
        {
            string input;
            bool result;
            Console.WriteLine(text);
            int enterRow = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (!bool.TryParse(input, out result) && !predicate(result))
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
