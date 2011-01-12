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
            string name = GetString("Enter name:");
            string url = GetString("Enter url:", x => x.StartsWith("http://"));

            Manufacturer temp = new Manufacturer(
                name,
                url);

            Parser.ManufacturerList.Add(temp);
            Console.WriteLine("Manufacturer with above specifications added. Press any key to continue.");
            Console.ReadKey();
            MainMenu();
        }

    }
}
