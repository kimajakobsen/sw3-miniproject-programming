using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class ManageManufacturer
    {
        static public void AddManufacturer()
        {
            Console.Clear();
            Console.WriteLine("Adding Manufacturer.\n");
            string name = Toolbox.GetString("Enter name:");
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
            Console.Clear();
            Console.WriteLine("Remove Manufacturer.\n");





            string name = Toolbox.GetString("Enter name:");
            string url = Toolbox.GetString("Enter url:", x => x.StartsWith("http://"));

            Manufacturer temp = new Manufacturer(
                name,
                url);

            Parser.ManufacturerList.Add(temp);
            Console.WriteLine("Manufacturer with above specifications added. Press any key to continue.");
            Console.ReadKey();
            Program.MainMenu();
        }

    }
}
