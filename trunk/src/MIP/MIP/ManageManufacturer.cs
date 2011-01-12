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
        /// This askes for name and url of a new manefacturer, then adds it
        /// to the manufacturerlist.
        /// If the name is not unique, the user is asked to enter another name
        /// If the url is invalid, the user is asked to enter another url
        /// </summary>
        static public void AddManufacturer()
        {           
            Console.Clear();
            Console.WriteLine("Adding Manufacturer.\n");
            string name = Toolbox.GetString("Enter name:", //checks if the name is in use, askes again if it is. 
                x => Parser.ManufacturerList.FirstOrDefault(y => y.Name.ToUpper() == x.ToUpper()) == null &&
                x.Length >= 1);
            string url = Toolbox.GetString("Enter url (Must start with \"http://\"):", x => x.StartsWith("http://"));

            Manufacturer temp = new Manufacturer(
                name,
                url);

            Parser.ManufacturerList.Add(temp); //adds to a list containing all manufacturers
            Console.WriteLine("Manufacturer with above specifications added. Press any key to continue.");
            Console.ReadKey();
            ManageManufacturers();
        }

        /// <summary>
        /// When the remove manufacturer is called it shows a list of all the manufacturers
        /// when a manufacturer is selected the PromptMenu is called and the selected manufacturer is saved in ToDelete
        /// </summary>
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
                list.Add(new KeyValuePair<Action, string>(PromptMenu, item.ToSearchResultString()));
                identifier.Add(i + "");
                i++;
            }

            if (list.Count > 0)
            {
                //if there are one or more manufacturer in the system, then they are showed on a list
                MenuBuilder.GetMenu.MakeMenu(list, ManageManufacturers, new KeyValuePair<Action, string>(RemoveManufacturer, "Remove Manufacturer"), identifier);
            }
            else
            {
                //If there are no manufactures the message "No products were found!" is displayed
                MenuBuilder.GetMenu.MakeMenu(list, ManageManufacturers, new KeyValuePair<Action, string>(RemoveManufacturer, "Remove Manufacturer"), identifier,
                    "\nNo products were found!\n");
            }
        }

        /// <summary>
        /// This showes a Prompt menu where the user have to confirm that he want to delete the given manufacturer 
        /// If the user answers YES then RemoveSpecificManufacturer is called
        /// If the user answers NO then Rthe user is send back to the place where user came from (it is stored in PromptMenuBack)
        /// </summary>
        static void PromptMenu()
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

        /// <summary>
        /// If there are producs made by the manufacturer who is being deleted, then the manufacturer is not deleted. 
        /// Else is the manufacturere deleted
        ///
        /// </summary>
        static public void RemoveSpecificManufacturer()
        {
            var temp = ToDelete; // contains the manufacturer which is about to be deleted
            if (Parser.ProductList.FirstOrDefault(x => x.Manufacturer.Name == temp.Name) != null)
            {
                //If there exist producs which are made by the current manufacturer
                Console.WriteLine("\"" + temp.Name + "\" still have producs in the system, delete all producs before deleating the manufacturer." + 
                    " Press any key to continue.");
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
