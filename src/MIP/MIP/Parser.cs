using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MIP
{
    class Parser
    {

        static List<Product> ProductList = new List<Product>();


        /// <summary>
        /// Reads string from the init.txt file in the following format:
        /// Name/string.Price/int.ProductCode/int.Class
        /// Cannot read special characters like æ,ø,å.
        /// </summary>
        static public void parser()
        {
            try
            {
                using (StreamReader reader = new StreamReader("Init.txt"))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        while (line.Contains("[hardrives]")){
                            
                        }
                        
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Connot read or find file");
                Console.WriteLine(e.Message);
            }
        }
    }
}


