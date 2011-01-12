using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace MIP
{
    static class Parser
    {

        /// <summary>
        /// A List of all the products
        /// </summary>
        static List<Product> _productList = new List<Product>();

        /// <summary>
        /// This points to list of all the products 
        /// This code is used by the parser to save products from the init file.
        /// </summary>
        public static List<Product> ProductList
        {
            get
            {
                return _productList;
            }
            private set
            {
                _productList = value;
            }
        }

        /// <summary>
        /// A list containing all the manufacturers
        /// </summary>
        static List<Manufacturer> _manufacturerList = new List<Manufacturer>();

        /// <summary>
        /// This points to list of all the manufacturers 
        /// This code is used by the parser to save manufacturers from the init file.
        /// </summary>
        public static List<Manufacturer> ManufacturerList
        {
            get
            {
                return _manufacturerList;
            }
            private set
            {
                _manufacturerList = value;
            }
        }

        /// <summary>
        /// Adds a product of type Internal harddrive from the external init file to the list of products
        /// Takes input in the following form: (note the tabs)
        /// [InternalHarddrives]	name	price	productCode 	Name of manufacturer	capacity	rounds per minut    Form factor
        /// </summary>
        /// <param name="_line">The line being searched</param>
        static private void InternalHarddrivesParser(string _line)
        {
            int i = 0;
            // The internal harddisk take 7 input, the array temp contains all the data from the string when it is extracted. 
            string[] temp = new string[7]; 
            int startIndex = _line.IndexOf('\x0009', 0); //startIndex is set to the first occurrence of tab

            while (i < 7) // external harddisk takes 7 input. Starts from zero.
            { 
                    try
                    {
                        //This finds the substring from one tab to the next tab and saves it in temp
                        //substring ( from tab plus one, length from current tab to next tab)  
                        temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1,
                            ((_line.IndexOf('\x0009', startIndex + 1) - (_line.IndexOf('\x0009', startIndex)) - 1)));
                        startIndex = _line.IndexOf('\x0009', startIndex + 1); // set startIndex to the next tab
                        
                        
                    }
                    catch (ArgumentException)
                    {

                    //if the last word is reached, then an exception is cast. It then takes the string 
                    //from the current tab to the end of the line and saves in temp.
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1);
                    }
                    i++;
            }

            try
            {
                  
                InternalHarddrive product = new InternalHarddrive(
                    temp[0],                  //name
                    double.Parse(temp[1]),    //price
                    int.Parse(temp[2]),       //productcode
                    ManufacturerList.FirstOrDefault(x=> x.Name == temp[3]), //manufacture
                    int.Parse(temp[4]),       //capacity
                    int.Parse(temp[5]),       //RPM
                    double.Parse(temp[6]));   //formfactor
                ProductList.Add(product); // saves the object to the product list
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in InternalHarddrive data");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Adds a product of type External harddrive from the external init file to the list of products
        /// Takes input in the following form: (note the tabs)
        /// [ExternalHarddrives]	name	price	productCode 	Name of manufacturer	capacity	rounds per minut    height  width   depth
        /// </summary>
        /// <param name="_line">The line being searched</param>
        static private void ExternalHarddrivesParser(string _line)
        {
            int i = 0;
            // The external harddisk take 9 input, the array temp contains all the data from the string when it is extracted. 
            string[] temp = new string[9];
            int startIndex = _line.IndexOf('\x0009', 0); //startIndex is set to the first occurrence of tab

            while (i < 9) // External harddisk takes 9 input, Starts from zero.
            {
                try
                {
                    //This finds the substring from one tab to the next tab and saves it in temp
                    //substring ( from tab plus one, length from current tab to next tab)  
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1,
                        ((_line.IndexOf('\x0009', startIndex + 1) - (_line.IndexOf('\x0009', startIndex)) - 1)));
                    startIndex = _line.IndexOf('\x0009', startIndex + 1); // set startIndex to the next tab
                    

                }
                catch (ArgumentException)
                {

                    //if the last word is reached, then an exception is cast. It then takes the string 
                    //from the current tab to the end of the line and saves in temp.
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1);
                }
                i++;
            }

            try
            {
                ExternalHarddrive product = new ExternalHarddrive(
                    temp[0],                  //name
                    double.Parse(temp[1]),    //price
                    int.Parse(temp[2]),       //productcode
                    ManufacturerList.FirstOrDefault(x => x.Name == temp[3]), //manufacture
                    int.Parse(temp[4]),       //capacity
                    int.Parse(temp[5]),       //RPM
                    double.Parse(temp[6]),      //height
                    double.Parse(temp[7]),   //width
                    double.Parse(temp[8]));   //depth
                ProductList.Add(product); // saves the object to the product list
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in ExternalHarddrive data");
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Adds a product of type Flash from the external init file to the list of products
        /// Takes input in the following form: (note the tabs)
        /// [Flash]	name	price	productcode	manufacturer	capacity	secureUSB
        /// </summary>
        /// <param name="_line">The line being searched</param>
        static private void FlashParser(string _line)
        {
            int i = 0;
            // The flash take 6 input, the array temp contains all the data from the string when it is extracted. 
            string[] temp = new string[6];
            int startIndex = _line.IndexOf('\x0009', 0); //startIndex is set to the first occurrence of tab

            while (i < 6) // flash takes 6 input, Starts from zero.
            {
                try
                {
                    //This finds the substring from one tab to the next tab and saves it in temp
                    //substring ( from tab plus one, length from current tab to next tab)  
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1,
                        ((_line.IndexOf('\x0009', startIndex + 1) - (_line.IndexOf('\x0009', startIndex)) - 1)));
                    startIndex = _line.IndexOf('\x0009', startIndex + 1); // set startIndex to the next tab
                    

                }
                catch (ArgumentException)
                {

                    //when the last word of the line is reached, then an exception is cast. It then takes the string 
                    //from the current tab to the end of the line and saves in temp.
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1);
                }
                i++;
            }

            try
            {

                FlashStorage product = new FlashStorage(
                    temp[0],                  //name
                    double.Parse(temp[1]),    //price
                    int.Parse(temp[2]),       //productcode
                    ManufacturerList.FirstOrDefault(x => x.Name == temp[3]), //manufacture
                    int.Parse(temp[4]),       //capacity
                    bool.Parse(temp[5]));       //secureUSB                   
                ProductList.Add(product); // saves the object to the product list
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Flash data");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Adds manufactures to from the init file to the ManufacturerList
        /// Takes input in the following form: (note the tabs)
        /// [Manufacturer]  Sony    http://sony.dk
        /// </summary>
        /// <param name="_line"></param>
        static private void Manufacturer(string _line)
        {
            int i = 0;
            // a manufacturer take 2 input, the array temp contains all the data from the string when it is extracted. 
            string[] temp = new string[2];
            int startIndex = _line.IndexOf('\x0009', 0); //startIndex is set to the first occurrence of tab

            while (i < 2) // manufacturer takes 2 input, starts from 0
            {
                try
                {
                    //This finds the substring from one tab to the next tab and saves it in temp
                    //substring ( from tab plus one, length from current tab to next tab)  
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1,
                        ((_line.IndexOf('\x0009', startIndex + 1) - (_line.IndexOf('\x0009', startIndex)) - 1)));
                    startIndex = _line.IndexOf('\x0009', startIndex + 1); // set startIndex to the next tab
                    

                }
                catch (ArgumentException)
                {

                    //if the last word is reached, then an exception is cast. It then takes the string 
                    //from the current tab to the end of the line and saves in temp.
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1);
                }
                i++;
            }

            try
            {

                Manufacturer manu = new Manufacturer(
                    temp[0],                  //name
                    temp[1]);                 //url
                 ManufacturerList.Add(manu); // saves the object to the product list
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading manufactureres ");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Reads the Init.txt file each line at a time
        /// when a product keyword is meet, the function calls the correct function to andre that specifik product
        /// </summary>
        static public void Parse()
        {
            try
            {

                using (StreamReader reader = new StreamReader("Init.txt"))
                {
                    string _line;
                    while ((_line = reader.ReadLine()) != null)
                    {

                        if (_line.Contains("[Manufacturer]"))
                        {
                            Manufacturer(_line);
                        }

                        if (_line.Contains("[InternalHarddrives]"))
                        {
                            InternalHarddrivesParser(_line);
                        }

                        if (_line.Contains("[ExternalHarddrives]"))
                        {
                            ExternalHarddrivesParser(_line);
                        }

                        if (_line.Contains("[Flash]"))
                        {
                            FlashParser(_line);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

            }
        }
    }
}


