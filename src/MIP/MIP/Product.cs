using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    abstract class Product
    {
        private string _name;
        private double _price;
        private int _productcode;
        private List<int> codeList = new List<int>(); //List which contains all used productcodes, is used to check to if the code is unique

        public Product(string name, double price, int productcode)
        {
            Name = name;
            Price = price;
            ProductCode = productcode;

        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value != null && value != "") // the name must not be null or a blank string
                {
                    _name = value;

                }
            }
        }
        

        public double Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (value != null && value >= 0) // the price must not be null or a negative number
                {
                _price = value;
                }
            }  
        }

        // the ProcutCode is an int 
        internal int ProductCode
        {
            get
            {
                return _productcode;
            }

            set
            {
                if (!codeList.Contains(value)) // the product code must be unique
                {
                    codeList.Add(value);
                    _productcode = value;

                }
            }
        }




    }
}
