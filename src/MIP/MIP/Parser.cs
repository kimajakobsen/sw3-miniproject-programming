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
        /// 
        /// </summary>
        static List<Product> ProductList = new List<Product>();

        /// <summary>
        /// Returns the list
        /// </summary>
        public static List<Product> GetList
        {
            get
            {
                return ProductList;
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        static List<Manufacturer> ManufacturerList = new List<Manufacturer>();

        /// <summary>
        /// Returns the list
        /// </summary>
        static List<Manufacturer> GetManufacturer
        {
            get
            {
                return ManufacturerList;
            }
        }

        /// <summary>
        /// Adds a product of type Internal harddrive from the external init file to the list of products
        /// </summary>
        /// <param name="_line">The line being searched</param>
        static private void InternalHarddrivesParser(string _line)
        {
            int i = 0;
            // The internal harddisk take 7 input, the array temp contains all the data from the string when it is extracted. 
            string[] temp = new string[7]; 
            int startIndex = _line.IndexOf('\x0009', 0); //startIndex is set to the first occurrence of tab

            while (i < 6) // internal harddisk takes 7 input, the counter startes from 0 thus 6
            { 
                    try
                    {
                        //This finds the substring from one tab to the next tab and saves it in temp
                        //substring ( from tab plus one, length from current tab to next tab)  
                        temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1,
                            ((_line.IndexOf('\x0009', startIndex + 1) - (_line.IndexOf('\x0009', startIndex)) - 1)));
                        startIndex = _line.IndexOf('\x0009', startIndex + 1); // set startIndex to the next tab
                        i++;
                        
                    }
                    catch (ArgumentException)
                    {

                    //if the last word is reached, then an exception is cast. It then takes the string 
                    //from the current tab to the end of the line and saves in temp.
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1);
                    }
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
                Console.WriteLine("Error in the init file");
                Console.WriteLine(e.Message);
            }
        }

        static private void ExternalHarddrivesParser(string _line)
        {
            int i = 0;
            // The internal harddisk take 9 input, the array temp contains all the data from the string when it is extracted. 
            string[] temp = new string[9];
            int startIndex = _line.IndexOf('\x0009', 0); //startIndex is set to the first occurrence of tab

            while (i < 8) // External harddisk takes 9 input, the counter startes from 0 thus 8
            {
                try
                {
                    //This finds the substring from one tab to the next tab and saves it in temp
                    //substring ( from tab plus one, length from current tab to next tab)  
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1,
                        ((_line.IndexOf('\x0009', startIndex + 1) - (_line.IndexOf('\x0009', startIndex)) - 1)));
                    startIndex = _line.IndexOf('\x0009', startIndex + 1); // set startIndex to the next tab
                    i++;

                }
                catch (ArgumentException)
                {

                    //if the last word is reached, then an exception is cast. It then takes the string 
                    //from the current tab to the end of the line and saves in temp.
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1);
                }
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
                Console.WriteLine("Error in the init file");
                Console.WriteLine(e.Message);
            }
        }

        static private void FlashParser(string _line)
        {
            int i = 0;
            // The internal harddisk take 6 input, the array temp contains all the data from the string when it is extracted. 
            string[] temp = new string[6];
            int startIndex = _line.IndexOf('\x0009', 0); //startIndex is set to the first occurrence of tab

            while (i < 5) // internal harddisk takes 6 input, the counter startes from 0 thus 5
            {
                try
                {
                    //This finds the substring from one tab to the next tab and saves it in temp
                    //substring ( from tab plus one, length from current tab to next tab)  
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1,
                        ((_line.IndexOf('\x0009', startIndex + 1) - (_line.IndexOf('\x0009', startIndex)) - 1)));
                    startIndex = _line.IndexOf('\x0009', startIndex + 1); // set startIndex to the next tab
                    i++;

                }
                catch (ArgumentException)
                {

                    //if the last word is reached, then an exception is cast. It then takes the string 
                    //from the current tab to the end of the line and saves in temp.
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1);
                }
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
                Console.WriteLine("Error in the init file");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_line"></param>
        static private void Manufacturer(string _line)
        {
            int i = 0;
            // a manufacturer take 2 input, the array temp contains all the data from the string when it is extracted. 
            string[] temp = new string[2];
            int startIndex = _line.IndexOf('\x0009', 0); //startIndex is set to the first occurrence of tab

            while (i < 1) // internal harddisk takes 7 input, the counter startes from 0 thus 6
            {
                try
                {
                    //This finds the substring from one tab to the next tab and saves it in temp
                    //substring ( from tab plus one, length from current tab to next tab)  
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1,
                        ((_line.IndexOf('\x0009', startIndex + 1) - (_line.IndexOf('\x0009', startIndex)) - 1)));
                    startIndex = _line.IndexOf('\x0009', startIndex + 1); // set startIndex to the next tab
                    i++;

                }
                catch (ArgumentException)
                {

                    //if the last word is reached, then an exception is cast. It then takes the string 
                    //from the current tab to the end of the line and saves in temp.
                    temp[i] = _line.Substring(_line.IndexOf('\x0009', startIndex) + 1);
                }
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
                Console.WriteLine("Error in the init file");
                Console.WriteLine(e.Message);
            }
        }

        static public void Parse()
        {
            try
            {

                using (StreamReader reader = new StreamReader("TestFile.txt"))
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


