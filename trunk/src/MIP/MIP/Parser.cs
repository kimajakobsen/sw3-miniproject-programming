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
                        if ( _line.Contains("[internalHardrives]"))
                        {
                            int i = 0;
                            string[] temp = new string[6];
                            while (i <= 6)
                            {
                                  
                                temp[i]=_line.Substring(_line.IndexOf('\x0009',i+1),
                                    ((_line.IndexOf('\x0009',i+2)-(_line.IndexOf('\x0009',i+1)))));
                            }

                            try
                            {
                                InternalHarddrive product = new InternalHarddrive { 
                                    Name = temp[0],
                                    Price = temp[1].Cast<double>().FirstOrDefault(), 
                                    ProductCode = temp[2].Cast<int>().FirstOrDefault(),
                                    Storage = temp[3].Cast<int>().FirstOrDefault(),
                                    Rpm = temp[4].Cast<int>().FirstOrDefault(),
                                    FormFactor = temp[5].Cast<int>().FirstOrDefault()};
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error in the init file");
                                Console.WriteLine(e.Message);
                            }

                            
                        }


                        
                            reader.ReadLine()
                            
    


                        
                        
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


