using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class ManageManufacturer
    {
        /// <summary>
        /// The menu manage menu
        /// </summary>
        static public void ManageManufacturers()
        {
            Console.Clear();
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            list.Add(new KeyValuePair<Action, string>(AddManufacturer, "Add a new Manufacturer"));
            list.Add(new KeyValuePair<Action, string>(RemoveManufacturer, "Remove an existing Manufacturer"));

            MenuBuilder.GetMenu.MakeMenu(list, Program.MainMenu, new KeyValuePair<Action, string>(ManageManufacturers, "Manage Manufacturer"));
            Program.MainMenu();
        }

        /// <summary>
        /// this is a object save a defult return point, it is used in RemoveManufacturer()
        /// </summary>
        static public KeyValuePair<Action, string> PromptMenuBack
        {
            get;
            set;
        }

        /// <summary>
        /// Contains the chosen manufacturer which the user wants to delete 
        /// </summary>
        static public Manufacturer ToDelete
        {
            get;
            set;

        }


        /// <summary>
        /// 
        /// </summary>
        static public void AddManufacturer()
        {           
            Console.Clear();
            Console.WriteLine("Adding Manufacturer.\n");
            string name = Toolbox.GetString("Enter name:",
                x => Parser.ManufacturerList.FirstOrDefault(y => y.Name.ToUpper() == x.ToUpper()) == null);
            string url = Toolbox.GetString("Enter url:", x => x.StartsWith("http://"));

            Manufacturer temp = new Manufacturer(
                name,
                url);

            Parser.ManufacturerList.Add(temp);
            Console.WriteLine("Manufacturer with above specifications added. Press any key to continue.");
            Console.ReadKey();
            Program.MainMenu();
        }

        static public void RemoveManufacturer()
        {
            PromptMenuBack = new KeyValuePair<Action, string>(RemoveManufacturer, "Remove Manufacturer");
            var searchResult = Parser.ManufacturerList;
            Console.Clear();
            int i = 1;
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            List<string> identifier = new List<string>();
            foreach (var item in searchResult)
            {
                list.Add(new KeyValuePair<Action, string>(PrompteMenu, item.ToSearchResultString()));
                identifier.Add(i + "");
                i++;
            }

            if (list.Count > 0)
            {
                MenuBuilder.GetMenu.MakeMenu(list, ManageManufacturers, new KeyValuePair<Action, string>(RemoveManufacturer, "Remove Manufacturer"), identifier);
            }
            else
            {
                MenuBuilder.GetMenu.MakeMenu(list, ManageManufacturers, new KeyValuePair<Action, string>(RemoveManufacturer, "Remove Manufacturer"), identifier,
                    "\nNo products were found!\n");
            }
        }


        static void PrompteMenu()
        {
            int index = int.Parse(MenuBuilder.GetMenu.LastSelected);
            ToDelete = Parser.ManufacturerList[index - 1];
            Console.Clear();
            List<KeyValuePair<Action, string>> list = new List<KeyValuePair<Action, string>>();
            list.Add(new KeyValuePair<Action, string>(RemoveSpecificManufacturer, "Yes, delete"));
            PromptMenuBack = new KeyValuePair<Action, string>(PromptMenuBack.Key, "No, go back to \"" + PromptMenuBack.Value + "\"");
            list.Add(PromptMenuBack);

            List<string> identifiers = new List<string>();
            identifiers.Add("Y");
            identifiers.Add("N");

            MenuBuilder.GetMenu.MakeCleanMenu(list, ManageManufacturers, new KeyValuePair<Action, string>(null, "Quit"), identifiers);
            return;
        }


        static public void RemoveSpecificManufacturer()
        {

            var temp = ToDelete;

            if (Parser.ProductList.FirstOrDefault(x => x.Manufacturer.Name == temp.Name) != null)
            {
                //If there exist producs which are made by the current manufacturer
                Console.WriteLine("\"" + temp.Name + "\" still have producs in the system, delete all producs before deleating the manufacturer. Press any key to continue.");
                Console.ReadKey();
                ManageManufacturers();  
            }
            else
            {
                //If the system dose not contain any producs made by the current manufacturer
                Parser.ManufacturerList.Remove(temp);
                Console.WriteLine("\"" + temp.ToSearchResultString() + "\" has been removed. Press any key to continue.");
                Console.ReadKey();
                ManageManufacturers();  
            }
        }
    }
}
