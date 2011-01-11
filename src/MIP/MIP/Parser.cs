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
                    string _line;
                    

                    while ((_line = reader.ReadLine()) != null)
                    {
                        if ( _line.Contains("[InternalHarddrives]"))
                        {
                            int i = 0;
                            string[] temp = new string[7];
                            int startIndex = _line.IndexOf('\x0009', 0);
                            
                            while (i < 7)
                            {

                                temp[i]=_line.Substring(_line.IndexOf('\x0009',startIndex),
                                    ((_line.IndexOf('\x0009',startIndex+1)-(_line.IndexOf('\x0009',startIndex)))));
                                startIndex = _line.IndexOf('\x0009', startIndex+1);
                                
                                Console.WriteLine(temp[i]);
                                i++;
                            }

                            try
                            {
                                InternalHarddrive product = new InternalHarddrive ( 
                                    temp[0],                                    //name
                                    temp[1].Cast<double>().FirstOrDefault(),    //price
                                    temp[2].Cast<int>().FirstOrDefault(),       //productcode
                                    temp[3],                                    //manufacture
                                    temp[4].Cast<int>().FirstOrDefault(),       //capacity
                                    temp[5].Cast<int>().FirstOrDefault(),       //RPM
                                    temp[6].Cast<double>().FirstOrDefault());   //formfactor
                                ProductList.Add(product);
                        }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error in the init file");
                                Console.WriteLine(e.Message);
                            }

                            
                        }

                        
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


